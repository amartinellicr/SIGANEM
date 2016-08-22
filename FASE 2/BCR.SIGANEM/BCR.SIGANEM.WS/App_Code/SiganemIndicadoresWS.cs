using System;
using System.Web;
using System.Xml;
using System.Net;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ServiceModel.Description;

using BCR.SIGANEM.EN;
using BCR.SIGANEM.BL;
using BCR.SIGANEM.UT;

using wsIndicadoresEconomicos;


[WebService(Namespace = "http://bancobcr.com/", Description = "SERVICIO WEB INDICADORES ECONOMICOS BCCR")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SiganemIndicadoresWS : System.Web.Services.WebService
{

    #region PROPIEDADES

    #region CONSTANTES

    private static string mensajeError = "Error. No hay conexión con el servicio: Indicadores Económicos BCCR.";

    #endregion

    #region NEGOCIO

    private IndicadoresEconomicosNegocio indicadoresNegocio = new IndicadoresEconomicosNegocio();

    #endregion

    #region UTILIDADES

    private RegistrarEventLog registrarEventLog = new RegistrarEventLog();
    private LectorConfiguracion lectorConfiguracion = new LectorConfiguracion();

    #endregion

    #region REFERENCIAS

    private wsIndicadoresEconomicos.wsIndicadoresEconomicos wsIndicadores = new wsIndicadoresEconomicos.wsIndicadoresEconomicos();

    #endregion

    #endregion

    #region CONSTRUCTOR

    public SiganemIndicadoresWS()
    {
        
    }

    #endregion

    #region METODOS PUBLICOS INDICADORES ECONOMICOS

    [WebMethod(Description = "PROCEDIMIENTO: VALIDA LA CONEXION CON EL SERVICIO DEL BCCR")]
    public string ValidaConexionWebServiceIndicadores()
    {
        string mensaje = string.Empty;

        foreach (AppSettingEntidad _appEntidad in ObtenerValoresServicios())
        {
            if (ExisteConexion(_appEntidad.Valor))
            {
                mensaje = _appEntidad.Valor;
                break;
            }
        }

        if (!mensaje.Equals(""))
            return mensaje;
        else
            return mensajeError;
    }

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA UN INDICADOR ECONOMICO TIPO CAMBIO DEL BCCR")]
    public List<RespuestaEntidad> ConsultaIndicadorEconomicoTC(IndicadorEconomicoEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string xmlData = String.Empty;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        TiposCambiosEntidad _tiposCambio = null;
        RespuestaEntidad _retorno = new RespuestaEntidad();
        List<RespuestaEntidad> retorno = new List<RespuestaEntidad>();
        List<RespuestaIndicadoresEntidad> entidadBCCR = new List<RespuestaIndicadoresEntidad>();

        try
        {

            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            AsignaWebServicesTypeNames();
            xmlData = wsIndicadores.ObtenerIndicadoresEconomicosXML(_entidad.Indicador, _entidad.FechaInicio, _entidad.FechaFinal, _entidad.NombreBanco, _entidad.SubNiveles);

            var doc = XDocument.Parse(xmlData);
            entidadBCCR = (from r in doc.Root.Elements("INGC011_CAT_INDICADORECONOMIC")
                           select new RespuestaIndicadoresEntidad()
                           {
                               IdIndicador = (string)r.Element("COD_INDICADORINTERNO"),
                               FechaIndicador = (DateTime)r.Element("DES_FECHA"),
                               ValorIndicador = (Decimal)r.Element("NUM_VALOR")
                           }).ToList();

            foreach (RespuestaIndicadoresEntidad _entidadBCCR in entidadBCCR)
            {
                #region ASIGNAR IDENTIDAD TIPO CAMBIO
                _tiposCambio = new TiposCambiosEntidad();
                _tiposCambio.Fecha = _entidadBCCR.FechaIndicador;
                _tiposCambio.Valor = _entidadBCCR.ValorIndicador;
                _tiposCambio.IndMetodoInsercion = _entidad.IndMetodoInsercion;
                _tiposCambio.CodUsuarioIngreso = _entidad.CodUsuarioIngreso;

                #endregion

                _retorno = indicadoresNegocio.Instancia.TiposCambiosInsertar(conexion, conexionBitacora, _tiposCambio, _bitacora);
                retorno.Add(_retorno);
            }

            return retorno;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA UN INDICADOR ECONOMICO IPC DEL BCCR")]
    public List<RespuestaEntidad> ConsultaIndicadorEconomicoIPC(IndicadorEconomicoEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string xmlData = String.Empty;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        IndicesPreciosConsumidorEntidad _indicesEntidad = null;
        RespuestaEntidad elemento = new RespuestaEntidad();
        List<RespuestaEntidad> retorno = new List<RespuestaEntidad>();
        List<RespuestaIndicadoresEntidad> entidadBCCR = new List<RespuestaIndicadoresEntidad>();

        try
        {

            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            AsignaWebServicesTypeNames();
            xmlData = wsIndicadores.ObtenerIndicadoresEconomicosXML(_entidad.Indicador, _entidad.FechaInicio, _entidad.FechaFinal, _entidad.NombreBanco, _entidad.SubNiveles);

            var doc = XDocument.Parse(xmlData);
            entidadBCCR = (from r in doc.Root.Elements("INGC011_CAT_INDICADORECONOMIC")
                           select new RespuestaIndicadoresEntidad()
                           {
                               IdIndicador = (string)r.Element("COD_INDICADORINTERNO"),
                               FechaIndicador = (DateTime)r.Element("DES_FECHA"),
                               ValorIndicador = (Decimal)r.Element("NUM_VALOR")
                           }).ToList();

            foreach (RespuestaIndicadoresEntidad elementoBCCR in entidadBCCR)
            {
                #region ASIGNAR IDENTIDAD TIPO CAMBIO
                _indicesEntidad = new IndicesPreciosConsumidorEntidad();
                _indicesEntidad.Mes = elementoBCCR.FechaIndicador.Month;
                _indicesEntidad.DesMes = GeneradorControles.HomologarMes(elementoBCCR.FechaIndicador.Month);
                _indicesEntidad.Ano = elementoBCCR.FechaIndicador.Year;
                _indicesEntidad.Valor = elementoBCCR.ValorIndicador;
                _indicesEntidad.IndMetodoInsercion = _entidad.IndMetodoInsercion;
                _indicesEntidad.CodUsuarioIngreso = _entidad.CodUsuarioIngreso;

                #endregion

                elemento = indicadoresNegocio.Instancia.IndicesPreciosConsumidorInsertar(conexion, conexionBitacora, _indicesEntidad, _bitacora);
                retorno.Add(elemento);
            }

            return retorno;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: REGISTRA LA EJECUCION DEL SERVICIO PARA LOS INDICADORES")]
    public int RegistraEjecucionServicioBitacora(BitacorasEntidad _bitacora)
    {
        int retorno = 0;
        string conexionBitacora = string.Empty;

        try
        {

            #region CONEXION BASE DATOS

            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            retorno = indicadoresNegocio.Instancia.RegistraEjecucionServicioBitacora(conexionBitacora, _bitacora);

            return retorno;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }

    }

    #endregion

    #region METODOS PRIVADOS INDICADORES ECONOMICOS

    private void AsignaWebServicesTypeNames()
    {
        try
        {
            wsIndicadores.Url = ValidaConexionWebServiceIndicadores();
            wsIndicadores.Credentials = CredentialCache.DefaultCredentials;

            #region CONFIGURACION PROXY

            if (ConfigurationManager.AppSettings["ProxyBCR"].ToString().Trim().Length > 0)
            {
                //EJECUCION SERVER
                string rutaProxy = ConfigurationManager.AppSettings["ProxyBCR"].ToString();
                WebProxy proxy = new WebProxy(rutaProxy, true);
                wsIndicadores.Proxy = proxy;
                ////EJECUCION LOCAL
                //_wsIndicadores.Proxy = WebRequest.GetSystemWebProxy();
                wsIndicadores.Proxy.Credentials = CredentialCache.DefaultCredentials;
            }
            #endregion

        }
        catch
        {
            registrarEventLog.RegistrarMensajeLog(mensajeError, "ERROR", Resources.Resource._eventoSource);
            throw new ArgumentException(mensajeError);
        }
    }

    private string ValidaConexionWebService()
    {
        string mensaje = string.Empty;

        foreach (AppSettingEntidad _appEntidad in ObtenerValoresServicios())
        {
            if (ExisteConexion(_appEntidad.Valor))
            {
                mensaje = _appEntidad.Valor;
                break;
            }
        }

        if (!mensaje.Equals(""))
            return mensaje;
        else
            return null;
    }

    private bool ExisteConexion(string urlServicio)
    {
        bool retorno = true;
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlServicio + "?wsdl");
            #region CONFIGURACION PROXY
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "GET";
            request.Credentials = CredentialCache.DefaultCredentials;

            //EJECUCION SERVER
            if (ConfigurationManager.AppSettings["ProxyBCR"].ToString().Trim().Length > 0)
            {
                string rutaProxy = ConfigurationManager.AppSettings["ProxyBCR"].ToString();
                WebProxy proxy = new WebProxy(rutaProxy, true);
                request.Proxy = proxy;
                ////EJECUCION LOCAL
                //request.Proxy = WebRequest.GetSystemWebProxy();
                request.Proxy.Credentials = CredentialCache.DefaultCredentials;
            }
            #endregion
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
                retorno = false;
            response.Close();
        }
        catch
        {
            retorno = false;
        }
        return retorno;
    }

    static private List<AppSettingEntidad> ObtenerValoresServicios()
    {
        AppSettingEntidad appEntidad;
        List<AppSettingEntidad> entidad = new List<AppSettingEntidad>();

        if (!ConfigurationManager.AppSettings.Count.Equals(0))
        {
            foreach (string appName in ConfigurationManager.AppSettings.AllKeys)
            {
                if (appName.Contains("wsIndicadorEconomico"))
                {
                    appEntidad = new AppSettingEntidad();
                    appEntidad.Nombre = appName;
                    appEntidad.Valor = ConfigurationManager.AppSettings[appName];

                    entidad.Add(appEntidad);
                }
            }
        }

        return entidad;
    }

    #endregion

}