using System;
using System.Web;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.EN;
using BCR.SIGANEM.BL;
using BCR.SIGANEM.UT;


[WebService(Namespace = "http://bancobcr.com/", Description = "SERVICIO WEB SEGURIDAD")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SiganemSeguridadWS : System.Web.Services.WebService
{

    #region PROPIEDADES

    #region NEGOCIO

    private RolesNegocio rolesNegocio = new RolesNegocio();
    private SitemapNegocio sitemapNegocio = new SitemapNegocio();
    private UsuariosNegocio usuariosNegocio = new UsuariosNegocio();
    private BitacoraNegocio bitacoraNegocio = new BitacoraNegocio();
    private MensajesNegocio mensajesNegocio = new MensajesNegocio();
    private ParametrosBienesNegocio parametrosBienesNegocio = new ParametrosBienesNegocio();
    private IndicadoresEconomicosNegocio indicadoresNegocio = new IndicadoresEconomicosNegocio();

    #endregion

    #region UTILIDADES

    private RegistrarEventLog registrarEventLog = new RegistrarEventLog();
    private LectorConfiguracion lectorConfiguracion = new LectorConfiguracion();

    #endregion

    #endregion

    #region CONSTRUCTOR

    public SiganemSeguridadWS()
    {
        
    }

    #endregion

    #region METODOS PUBLICOS SEGURIDAD

    #region INDICES PRECIOS CONSUMIDOR

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE INDICES PRECIOS CONSUMIDOR")]
    public RespuestaEntidad IndicesPreciosConsumidorInsertar(IndicesPreciosConsumidorEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = indicadoresNegocio.Instancia.IndicesPreciosConsumidorInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE INDICES PRECIOS CONSUMIDOR")]
    public List<IndicesPreciosConsumidorEntidad> IndicesPreciosConsumidorConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<IndicesPreciosConsumidorEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = indicadoresNegocio.Instancia.IndicesPreciosConsumidorConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE INDICES PRECIOS CONSUMIDOR")]
    public int IndicesPreciosConsumidorTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = indicadoresNegocio.Instancia.IndicesPreciosConsumidorTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE LA ULTIMA CONSULTA DE INDICES PRECIOS CONSUMIDOR AL BCCR")]
    public MensajesEntidad IndicesPreciosConsumidorConsultarBCCR()
    {
        MensajesEntidad consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = indicadoresNegocio.Instancia.IndicesPreciosConsumidorConsultarBCCR(conexion);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region USUARIOS

    #region REGISTRO CONEXION

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DEL USUARIO VALIDANDO EL ACCESO")]
    public bool UsuariosObtenerAcceso(string codUsuario)
    {
        bool valido = false;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            valido = usuariosNegocio.Instancia.UsuariosValidar(conexion, codUsuario);

            return valido;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DEL USUARIO CONSULTANDO LOS INTENTOS")]
    public UsuariosEntidad UsuariosObtenerIntentos(string codUsuario)
    {
        UsuariosEntidad intentos = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            intentos = usuariosNegocio.Instancia.UsuariosConsultarIntentos(conexion, codUsuario);

            return intentos;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DEL USUARIO VALIDANDO EL ACCESO")]
    public RespuestaEntidad UsuariosRegistrarIntentos(UsuariosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        int resultado = 0;
        RespuestaEntidad valido = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            valido = usuariosNegocio.Instancia.UsuariosActualizarIntentos(conexion, _entidad);
            resultado = bitacoraNegocio.Instancia.BitacoraRegistrar(conexionBitacora, _bitacora);//CAMBIO FGUEVARA

            return valido;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DEL USUARIO VALIDANDO EL ACCESO")]
    public RespuestaEntidad UsuariosRegistrarConexion(UsuariosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        int resultado = 0;
        RespuestaEntidad valido = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            valido = usuariosNegocio.Instancia.UsuariosActualizarConexion(conexion, _entidad);
            resultado = bitacoraNegocio.Instancia.BitacoraRegistrar(conexionBitacora, _bitacora);//CAMBIO FGUEVARA

            return valido;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE SI EL USUARIO TIENE PERMISOS PARA INGRESAR A UNA PAGINA")]
    public int UsuariosValidarAcceso(string codUsuario, string desPagina)
    {
        int resultado = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            resultado = usuariosNegocio.Instancia.UsuariosValidarAcceso(conexion, codUsuario, desPagina);

            return resultado;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE SI EL USUARIO TIENE PERMISOS PARA INGRESAR A UNA PAGINA POR CODIGO DE PAGINA")]
    public int UsuariosValidarAccesoCodigo(string codUsuario, string codPagina)
    {
        int resultado = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            resultado = usuariosNegocio.UsuariosValidarAccesoCodigo(conexion, codUsuario, codPagina);

            return resultado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DEL ROL DEL USUARIO")]
    public UsuariosEntidad UsuariosObtenerRolUsuario(string codUsuario)
    {
        UsuariosEntidad resultado = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            resultado = usuariosNegocio.Instancia.UsuariosDatosRoles(conexion, codUsuario);

            return resultado;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region MANTENIMIENTO

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE USUARIOS")]
    public RespuestaEntidad UsuariosInsertar(UsuariosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = usuariosNegocio.Instancia.UsuariosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE USUARIOS")]
    public RespuestaEntidad UsuariosModificar(UsuariosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = usuariosNegocio.Instancia.UsuariosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE USUARIOS")]
    public RespuestaEntidad UsuariosEliminar(UsuariosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = usuariosNegocio.Instancia.UsuariosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE USUARIOS")]
    public List<UsuariosEntidad> UsuariosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<UsuariosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = usuariosNegocio.Instancia.UsuariosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE USUARIOS")]
    public UsuariosEntidad UsuariosConsultarDetalle(UsuariosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        UsuariosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = usuariosNegocio.Instancia.UsuariosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE USUARIOS")]
    public int UsuariosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = usuariosNegocio.Instancia.UsuariosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    #endregion

    #region ROLES

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS DE ROLES")]
    public RespuestaEntidad RolesInsertar(TiposRolesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = rolesNegocio.Instancia.RolesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS DE ROLES")]
    public RespuestaEntidad RolesModificar(TiposRolesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = rolesNegocio.Instancia.RolesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS DE ROLES")]
    public RespuestaEntidad RolesEliminar(TiposRolesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = rolesNegocio.Instancia.RolesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS DE ROLES")]
    public List<TiposRolesEntidad> RolesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposRolesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = rolesNegocio.Instancia.RolesConsultar(conexion, _entidad);
            
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS DE ROLES")]
    public TiposRolesEntidad RolesConsultarDetalle(TiposRolesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposRolesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = rolesNegocio.Instancia.RolesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS DE ROLES")]
    public int RolesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = rolesNegocio.Instancia.RolesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CANTIDAD DE USUARIOS POR TIPOS DE ROLES")]
    public int RolesUsuariosConsultar(TiposRolesEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = rolesNegocio.Instancia.RolesUsuariosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    #region SITEMAP SISTEMA

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE LOS ELEMENTOS PADRE")]
    public List<PantallasEntidad> PantallasConsulta()
    {
        List<PantallasEntidad> resultado = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            resultado = sitemapNegocio.Instancia.PantallasConsulta(conexion);

            return resultado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ACTIVOS")]
    public PantallasEntidad PantallasConsultarDetalle(PantallasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        PantallasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = sitemapNegocio.Instancia.PantallasConsultaDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE PANTALLAS SEGUN ROLES")]
    public RespuestaEntidad PantallasRolesInsertar(PantallasRolesEntidad _entidad)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = sitemapNegocio.Instancia.PantallasRolesInsertar(conexion, _entidad);
            
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE PANTALLAS SEGUN ROLES")]
    public RespuestaEntidad PantallasRolesEliminar(PantallasRolesEntidad _entidad)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = sitemapNegocio.Instancia.PantallasRolesEliminar(conexion, _entidad);
            
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA UN REGISTRO DE PANTALLAS SEGUN ROLES")]
    public List<PantallasRolesEntidad> PantallasRolesConsultaDetalle(PantallasRolesEntidad _entidad)
    {
        List<PantallasRolesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = sitemapNegocio.Instancia.PantallasRolesConsultaDetalle(conexion, _entidad);
            
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    #region TIPOS CAMBIOS

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS CAMBIOS")]
    public RespuestaEntidad TiposCambiosInsertar(TiposCambiosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = indicadoresNegocio.Instancia.TiposCambiosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS CAMBIOS")]
    public List<TiposCambiosEntidad> TiposCambiosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposCambiosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = indicadoresNegocio.Instancia.TiposCambiosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS CAMBIOS")]
    public int TiposCambiosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = indicadoresNegocio.Instancia.TiposCambiosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE LA ULTIMA CONSULTA DE TIPOS CAMBIOS AL BCCR")]
    public MensajesEntidad TiposCambiosConsultarBCCR()
    {
        MensajesEntidad consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = indicadoresNegocio.Instancia.TiposCambiosConsultarBCCR(conexion);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region MENSAJES SISTEMA

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ACTIVOS")]
    public MensajesEntidad MensajesConsulta(MensajesEntidad _entidad)
    {
        MensajesEntidad consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mensajesNegocio.Instancia.MensajesConsulta(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    //CONTROL DE CAMBIO 1-24372961
    #region PARAMETROS SISTEMA

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE PARAMETROS DEL SISTEMA")]
    public RespuestaEntidad ParametrosBienesModificar(ParametrosBienesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = parametrosBienesNegocio.Instancia.ParametrosBienesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE PARAMETROS DEL SISTEMA")]
    public List<ParametrosBienesEntidad> ParametrosBienesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<ParametrosBienesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = parametrosBienesNegocio.Instancia.ParametrosBienesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE PARAMETROS DEL SISTEMA")]
    public ParametrosBienesEntidad ParametrosBienesConsultarDetalle(ParametrosBienesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ParametrosBienesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = parametrosBienesNegocio.Instancia.ParametrosBienesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE PARAMETROS DEL SISTEMA")]
    public int ParametrosBienesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = parametrosBienesNegocio.Instancia.ParametrosBienesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #endregion

}