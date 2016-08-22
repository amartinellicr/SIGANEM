using System;
using Resources;
using System.Net;
using System.Web;
using System.Data;
using System.Transactions;
using System.Web.Services;
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel.Description;

using BCR.SIGANEM.UT;
using BCR.SIGANEM.EN;

using ActiveDirectoryWS;
using ServicioSesionesWCF;


[WebService(Namespace = "http://bancobcr.com/", Description = "SERVICIO WEB MANEJADOR DE SESIONES")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SiganemSesionesWCF : System.Web.Services.WebService 
{

    #region PROPIEDADES

    #region VARIABLES

    protected string SistemaWCF
    {
        get
        {
            return ConfigurationManager.AppSettings["SistemaWCF"].ToString();
        }
    }

    protected int ExpiracionWCF
    {
        get
        {
            return int.Parse(ConfigurationManager.AppSettings["ExpiracionWCF"].ToString());
        }
    }

    #endregion

    #region REFERENCIAS

    private Respuesta respuesta = new Respuesta();
    private RespuestaSesion respuestaSesion = new RespuestaSesion();
    private ActiveDirectory wsActiveDirectory = new ActiveDirectory();
    private RegistrarEventLog registrarEventLog = new RegistrarEventLog();
    private SvAdministrarSesionesClient wcfSesiones = new SvAdministrarSesionesClient("BasicHttpBinding_ISvAdministrarSesiones");

    #endregion

    #endregion

    #region CONSTRUCTOR

    public SiganemSesionesWCF()
    {
        wsActiveDirectory.Url = ConfigurationManager.AppSettings["ActiveDirectoryWS"].ToString();
    }

    #endregion

    #region METODOS PUBLICOS MANEJADOR SESIONES

    #region USUARIOS

    [WebMethod(Description = "PROCEDIMIENTO: VALIDA SI EL USUARIO EXISTE EN ACTIVE DIRECTORY")]
    public bool UsuarioExisteAd(string codigoUsuario)
    {
        try
        {
            //DEVUELVE EL RESULTADO
            return wsActiveDirectory.ExisteUsuario(codigoUsuario);
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: VALIDA LA CORRECTA AUTENTICACIÓN DEL USUARIO EN ACTIVE DIRECTORY")]
    public bool UsuarioAutenticadoAd(string codigoUsuario, string password)
    {
        try
        {
            //DEVUELVE EL RESULTADO
            return wsActiveDirectory.Autenticar(codigoUsuario, password);
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL NOMBRE COMPLETO DEL USUARIO EN ACTIVE DIRECTORY")]
    public string UsuarioNombreAd(string codigoUsuario)
    {
        try
        {
            //DEVUELVE EL RESULTADO
            return wsActiveDirectory.TraerDatosUsuario(codigoUsuario).DisplayName;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    #region SESIONES

    [WebMethod(Description = "PROCEDIMIENTO: CREA LA SESIÓN DEL USUARIO")]
    public RespuestaSesion CrearSesion(Int64 codigoUsuario)
    {
        try
        {
            //CREDENCIALES DEL SERVICIO
            wcfSesiones.ClientCredentials.Windows.ClientCredential = wcfCredenciales();

            //CREAR SESION DEL USUARIO
            return wcfSesiones.CrearSesion(SistemaWCF, codigoUsuario.ToString(), ExpiracionWCF, false);
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINAR LA SESIÓN DEL USUARIO")]
    public Respuesta EliminarSesion(string idSesion)
    {
        try
        {
            //CREDENCIALES DEL SERVICIO
            wcfSesiones.ClientCredentials.Windows.ClientCredential = wcfCredenciales();
            
            //ELIMINAR SESION DEL USUARIO
            return wcfSesiones.EliminarSesion(idSesion);
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTAR LA SESIÓN DEL USUARIO")]
    public RespuestaConsultaSesion ConsultarSesion(string idSesion)
    {
        try
        {
            //CREDENCIALES DEL SERVICIO
            wcfSesiones.ClientCredentials.Windows.ClientCredential = wcfCredenciales();

            //CONSULTAR SESION DEL USUARIO
            return wcfSesiones.ConsultarSesion(idSesion);
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    //[WebMethod(Description = "PROCEDIMIENTO: CREA VARIABLE DE SESIÓN DEL USUARIO")]
    //public Respuesta CrearVariable(VariablesSesionEntidad Variables)
    //{
    //    try
    //    {
    //        //CREDENCIALES DEL SERVICIO
    //        wcfSesiones.ClientCredentials.Windows.ClientCredential = wcfCredenciales();

    //        //CREAR VARIABLE DEL USUARIO
    //        return wcfSesiones.CrearVariable(Variables.idSesion, Variables.Nombre, Variables.Valor, Variables.Persistencia);
    //    }
    //    catch (Exception ex)
    //    {
    //        registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
    //        throw ex;
    //    }
    //}

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINAR LA VARIABLE DE SESIÓN DEL USUARIO")]
    public Respuesta EliminarVariable(VariablesSesionEntidad Variables)
    {
        try
        {
            //CREDENCIALES DEL SERVICIO
            wcfSesiones.ClientCredentials.Windows.ClientCredential = wcfCredenciales();

            //ELIMINAR VARIABLE DEL USUARIO
            return wcfSesiones.EliminarVariable(Variables.idSesion, Variables.Nombre);
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    //[WebMethod(Description = "PROCEDIMIENTO: CONSULTA LAS VARIABLES DE SESIÓN")]
    //public VariableSesion ConsultarVariable(VariablesSesionEntidad Variables)
    //{
    //    try
    //    {
    //        //CREDENCIALES DEL SERVICIO
    //        wcfSesiones.ClientCredentials.Windows.ClientCredential = wcfCredenciales();

    //        //CONSULTAR VARIABLE DEL USUARIO
    //        return wcfSesiones.ConsultarVariable(Variables.idSesion, Variables.Nombre);
    //    }
    //    catch (Exception ex)
    //    {
    //        registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
    //        throw ex;
    //    }
    //}
    
    private NetworkCredential wcfCredenciales()
    {
        var credenciales = new ClientCredentials();
        var credencialesRed = new NetworkCredential();
        string credenciasRuc = ConfigurationManager.AppSettings["CredWCF"].ToString();

        //SPLIT DE LAS CREDENCIALES ASIGNADAS
        string[] credencialesConfig = credenciasRuc.Split(';');
        credencialesRed.Domain = credencialesConfig[0];
        credencialesRed.UserName = @credencialesConfig[1];
        credencialesRed.Password = credencialesConfig[2];

        //DEVUELVE LOS VALORES DE LA CREDENCIAL
        return credencialesRed;
    }

    #endregion

    #endregion

}