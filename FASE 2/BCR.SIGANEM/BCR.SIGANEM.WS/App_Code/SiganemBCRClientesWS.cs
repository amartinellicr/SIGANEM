using System;
using Resources;
using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Web.Services;
using System.Configuration;
using System.Collections.Generic;
using System.ServiceModel.Description;

using BCR.SIGANEM.EN;
using BCR.SIGANEM.UT;

using SICCClientesWS;
using BCRClientesWCF;


[WebService(Namespace = "http://bancobcr.com/", Description = "SERVICIO WEB CONSULTAS BCR CLIENTES")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SiganemBCRClientesWS : System.Web.Services.WebService 
{

    #region PROPIEDADES

    #region NEGOCIO

    private RegistrarEventLog registrarEventLog = new RegistrarEventLog();
    
    #endregion

    #region REFERENCIAS

    private WSRUC wsServicioSICC = new WSRUC();
    private BCRClientesWCF.Respuesta wcfRespuesta = new BCRClientesWCF.Respuesta();
    private ServicioConsultaClient wcfClientes = new ServicioConsultaClient("NetTcpBinding_IServicioConsulta");

    #endregion

    #endregion

    #region CONSTRUCTOR

    public SiganemBCRClientesWS()
    {
        //Ajuste Pase Producción Fase1
        wsServicioSICC.Url = ConfigurationManager.AppSettings["SICCClientesWS"].ToString();
    }

    #endregion

    #region METODOS PUBLICOS BCR CLIENTES

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA CLIENTE EN BCR CLIENTES")]
    public List<BCRClientesEntidad> ConsultaClienteBCR(int _tipoPersona, string _identificacion, string _ipCliente)
    {
        string nombreCliente = string.Empty;
        BCRClientesEntidad elemento;
        List<BCRClientesEntidad> retorno = new List<BCRClientesEntidad>();

        ClienteFisico fisico = null;
        ClienteJuridico juridico = null;
        
        try
        {
            //CREDENCIALES DEL SERVICIO
            wcfClientes.ClientCredentials.Windows.ClientCredential = wcfCredenciales();

            wcfRespuesta = wcfClientes.ConsultarCliente(_tipoPersona, _identificacion, Resource._sistema, _ipCliente);
            if (wcfRespuesta.CodigoRespuesta.Equals(0))
            {
                /*SE DEBE DE REALIZAR ESTA VALIDACION DEBIDO A QUE EL SISTEMA BCR CLIENTES PRESENTA REGISTROS COMO "CLIENTES POTENCIALES"
                LOS CUALES NO PRESENTAN NINGUNA INFORMACION SICC, POR ESTE MOTIVO, AL SER UN VALOR NULO NO ES POSIBLE REALIZAR UNA 
                VALIDACION CON LA LONGITUD (LENGTH) Y POR ENDE SE DEBE DE UTILIZAR EL NULL*/
                if (!(wcfRespuesta.Cliente.IdentificacionesSICC == null))
                {
                    if ((wcfRespuesta.Cliente.IdentificacionesSICC.Length > 0))
                    {
                        if (_tipoPersona.Equals(2))
                        {
                            juridico = ((ClienteJuridico)wcfRespuesta.Cliente);
                            nombreCliente = juridico.RazonSocial;
                        }
                        else
                        {
                            fisico = ((ClienteFisico)wcfRespuesta.Cliente);
                            nombreCliente = string.Concat(fisico.Nombre, " ", fisico.Apellido1, " ", fisico.Apellido2);
                        }


                        for (int i = 0; i < wcfRespuesta.Cliente.IdentificacionesSICC.Length; i++)
                        {
                            elemento = new BCRClientesEntidad();
                            elemento.IdSICC = wcfRespuesta.Cliente.IdentificacionesSICC[i].ToString();
                            elemento.DescNombre = nombreCliente;

                            retorno.Add(elemento);
                        }
                    }
                }
            }
            wcfClientes.Close();
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }

        return retorno;

    }

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA CLIENTE SICC EN BCR CLIENTES RETORNANDO EL CLIENTE RUC")]
    public List<RUCClientesEntidad> ConsultaClienteRUC(int _tipoBusqueda, int  _tipoIdentificacion,string _identificacion)
    {
        string xmlData = String.Empty;
        List<RUCClientesEntidad> retorno = new List<RUCClientesEntidad>();

        try
        {
            xmlData = wsServicioSICC.BuscarCedulas(_tipoBusqueda, _tipoIdentificacion, _identificacion);

            var doc = XDocument.Parse(xmlData);
            retorno = (from r in doc.Root.Elements("Cedulas_RUC")
                         select new RUCClientesEntidad()
                         {
                             IdRUC = (string)r.Element("ruc_cliente"),
                             TipoIdentificacionRUC = (string)r.Element("tipo_id_ruc") + " - " + (string)r.Element("desc_tipo_id_ruc"),
                             IdentificacionClienteRUC = (string)r.Element("cedula_ruc"),
                             DescNombreRUC = (string)r.Element("nombre")
                         }).ToList();

        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }

        return retorno;

    }

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA CLIENTE RUC EN BCR CLIENTES RETORNANDO EL CLIENTE SUGEF")]
    public GarantiasOperacionesClientesEntidad ConsultaClienteSugef(string _tipoIdentificacionRuc, string _identificacionRuc)
    {
        SICCClientesWS.Respuesta xmlData = new SICCClientesWS.Respuesta();
        GarantiasOperacionesClientesEntidad retorno = new GarantiasOperacionesClientesEntidad();

        try
        {
            xmlData = wsServicioSICC.ValidarClienteRUC(_tipoIdentificacionRuc, _identificacionRuc);

            if (xmlData.CodigoRespuesta.Equals(0))
            {
                var doc = XDocument.Parse(xmlData.MensajeXML);
                retorno = (from r in doc.Root.Elements("HOMOLOGACION")
                           select new GarantiasOperacionesClientesEntidad()
                           {
                               IdentificacionSugef = (string)r.Attribute("IDENTIFICACION_TITULAR_SUGEF"),
                               TipoIdentificacionSugef = (string)r.Attribute("TIPO_IDENTIFICACION_SUGEF")
                           }).FirstOrDefault();
            }

            return retorno;

        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }

    }

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

}