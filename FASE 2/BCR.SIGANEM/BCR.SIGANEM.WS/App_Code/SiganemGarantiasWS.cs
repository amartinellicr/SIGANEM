using System;
using System.Net;
using System.Web;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Web.Services;
using System.Configuration;
using System.Globalization;
using System.Data.SqlClient;
using System.Collections.Generic;

using MQServicioWS;
using ClientesWCF;
using BCR.SIGANEM.EN;
using BCR.SIGANEM.BL;
using BCR.SIGANEM.UT;
using System.ServiceModel.Description;


[WebService(Namespace = "http://bancobcr.com/", Description = "SERVICIO WEB GARANTIAS")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SiganemGarantiasWS : System.Web.Services.WebService 
{
    
    #region PROPIEDADES

    #region CONSTANTES

    private static string mensajeError = "Error. No hay conexión con el servicio: Consulta CDP-BCR.";

    #endregion

    #region NEGOCIO

    private GarantiasNegocio garantiasNegocio = new GarantiasNegocio();

    #endregion

    #region UTILIDADES

    private RegistrarEventLog registrarEventLog = new RegistrarEventLog();
    private LectorConfiguracion lectorConfiguracion = new LectorConfiguracion();

    #endregion

    #region REFERENCIAS

    private WSMQ wsMQ = new WSMQ();
    /*VARIABLE PARA CONSULTAR EN BCR CLIENTES*/
    private ConsultaClient WcfClienteConsultaBCRClientes = new ConsultaClient("BasicHttpBinding_IConsulta");

    #endregion

    #endregion

    #region CONSTRUCTOR

    public SiganemGarantiasWS()
    {
    }

    #endregion

    #region METODOS PUBLICOS GARANTIAS

    #region AVALES

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE GARANTIAS AVALES")]
    public List<GarantiasAvalesEntidad> GarantiasAvalesConsultar(ParametrosConsultaEntidad _entidad)
    {
        string conexion = string.Empty;
        List<GarantiasAvalesEntidad> consulta = null;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasAvalesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE GARANTIAS AVALES")]
    public int GarantiasAvalesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasAvalesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA LOS DATOS DE UNA GARANTIA AVAL")]
    public RespuestaEntidad GarantiasAvalesInsertar(GarantiasAvalesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasAvalesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: MODIFICA LOS DATOS DE UNA GARANTIA AVAL")]
    public RespuestaEntidad GarantiasAvalesModificar(GarantiasAvalesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasAvalesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE UNA GARANTIA AVAL")]
    public RespuestaEntidad GarantiasAvalesEliminar(GarantiasAvalesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasAvalesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE UNA GARANTIA AVAL")]
    public GarantiasAvalesEntidad GarantiasAvalesConsultarDetalle(GarantiasAvalesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        GarantiasAvalesEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasAvalesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region FIDEICOMISOS

    #region GARANTIAS RELACIONES

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UNA RELACION DE GARANTIA FIDEICOMETIDA")]
    public RespuestaEntidad GarantiasFideicomisosFideicometidasInsertar(GarantiasFideicomisosFideicometidasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = new RespuestaEntidad();
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosFideicometidasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }
    #endregion

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE GARANTIAS FIDEICOMISOS")]
    public List<GarantiasFideicomisosEntidad> GarantiasFideicomisosConsultar(ParametrosConsultaEntidad _entidad)
    {
        string conexion = string.Empty;
        List<GarantiasFideicomisosEntidad> consulta = null;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE GARANTIAS FIDEICOMISOS")]
    public int GarantiasFideicomisosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: VALIDAR UN REGISTRO DE GARANTIAS FIDEICOMISOS")]
    public RespuestaEntidad GarantiasFideicomisosValidar(GarantiasFideicomisosEntidad entidad, BitacorasEntidad bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosValidar(conexion, conexionBitacora, entidad, bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE GARANTIAS FIDEICOMISOS")]
    public GarantiasFideicomisosEntidad GarantiasFideicomisosConsultarDetalle(GarantiasFideicomisosEntidad entidad, BitacorasEntidad bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        GarantiasFideicomisosEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosConsultarDetalle(conexion, conexionBitacora, entidad, bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE GARANTIAS FIDEICOMISOS")]
    public RespuestaEntidad GarantiasFideicomisoInsertar(GarantiasFideicomisosEntidad entidad, BitacorasEntidad bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosInsertar(conexion, conexionBitacora, entidad, bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UNA GARANTIA FIDEICOMISO")]
    public RespuestaEntidad GarantiasFideicomisosModificar(GarantiasFideicomisosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GARANTIAS FIDEICOMISOS")]
    public RespuestaEntidad GarantiasFideicomisosEliminar(GarantiasFideicomisosEntidad entidad, BitacorasEntidad bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosEliminar(conexion, conexionBitacora, entidad, bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE GARANTIAS FIDEICOMISOS")]
    public List<GarantiasFideicomisosEntidad> GarantiasFideicomisoConsultarGridInterno(GarantiasFideicomisosEntidad entidad)
    {
        List<GarantiasFideicomisosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosConsultarGridInterno(conexion, entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #region ADJUNTOS

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ADJUNTOS")]
    public RespuestaEntidad GarantiasFideicomisoAdjuntosInsertar(GarantiasFideicomisosAdjuntosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosArchivosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ADJUNTOS")]
    public RespuestaEntidad GarantiasFideicomisoAdjuntosModificar(GarantiasFideicomisosAdjuntosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosArchivosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ADJUNTOS")]
    public RespuestaEntidad GarantiasFideicomisoAdjuntosEliminar(GarantiasFideicomisosAdjuntosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosArchivosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ADJUNTOS")]
    public List<GarantiasFideicomisosAdjuntosEntidad> GarantiasFideicomisoAdjuntosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<GarantiasFideicomisosAdjuntosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosArchivosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ADJUNTOS")]
    public GarantiasFideicomisosAdjuntosEntidad GarantiasFideicomisoAdjuntosConsultarDetalle(GarantiasFideicomisosAdjuntosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        GarantiasFideicomisosAdjuntosEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosArchivosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE ADJUNTOS")]
    public List<GarantiasFideicomisosAdjuntosEntidad> GarantiasFideicomisoAdjuntosConsultarGridInterno(GarantiasFideicomisosAdjuntosEntidad entidad)
    {
        List<GarantiasFideicomisosAdjuntosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosArchivosConsultarGridInterno(conexion, entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ADJUNTOS")]
    public int GarantiasFideicomisoAdjuntosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosArchivosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region PRIORIDADES

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE GRADOS PRIORIDADES")]
    public RespuestaEntidad GarantiasFideicomisoPrioridadesInsertar(GarantiasFideicomisosPrioridadesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosPrioridadesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE GRADOS PRIORIDADES")]
    public RespuestaEntidad GarantiasFideicomisoPrioridadesModificar(GarantiasFideicomisosPrioridadesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosPrioridadesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GRADOS PRIORIDADES")]
    public RespuestaEntidad GarantiasFideicomisoPrioridadesEliminar(GarantiasFideicomisosPrioridadesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosPrioridadesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE GRADOS PRIORIDADES")]
    public List<GarantiasFideicomisosPrioridadesEntidad> GarantiasFideicomisoPrioridadesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<GarantiasFideicomisosPrioridadesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosPrioridadesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE GRADOS PRIORIDADES")]
    public GarantiasFideicomisosPrioridadesEntidad GarantiasFideicomisoPrioridadesConsultarDetalle(GarantiasFideicomisosPrioridadesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        GarantiasFideicomisosPrioridadesEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosPrioridadesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE GRADOS PRIORIDADES")]
    public List<GarantiasFideicomisosPrioridadesEntidad> GarantiasFideicomisoPrioridadesConsultarGridInterno(GarantiasFideicomisosPrioridadesEntidad entidad)
    {
        List<GarantiasFideicomisosPrioridadesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosPrioridadesConsultarGridInterno(conexion, entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE GRADOS PRIORIDADES")]
    public int GarantiasFideicomisoPrioridadesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosPrioridadesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region FIDEICOMETIDAS
			
	[WebMethod(Description = "PROCEDIMIENTO: INSERTA EL TOTAL DE GARANTIAS FIDEICOMETIDAS")]
    public RespuestaEntidad GarantiasFideicomisosFideicometidasInsertarTotal(GarantiasFideicomisosFideicometidasEntidad entidad, BitacorasEntidad bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosFideicometidasInsertarTotal(conexion, conexionBitacora, entidad, bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }
	
	[WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO  DE GARANTIAS FIDEICOMETIDAS")]
    public RespuestaEntidad GarantiasFideicomisosFideicometidasModificar(GarantiasFideicomisosFideicometidasEntidad entidad, BitacorasEntidad bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosFideicometidasModificar(conexion, conexionBitacora, entidad, bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO  DE GARANTIAS FIDEICOMETIDAS")]
    public RespuestaEntidad GarantiasFideicomisosFideicometidasEliminar(GarantiasFideicomisosFideicometidasEntidad entidad, BitacorasEntidad bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosFideicometidasEliminar(conexion, conexionBitacora, entidad, bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }
	
	[WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO  DE GARANTIAS FIDEICOMETIDAS")]
    public GarantiasFideicomisosFideicometidasEntidad GarantiasFideicomisosFideicometidasConsultarDetalle(GarantiasFideicomisosFideicometidasEntidad entidad, BitacorasEntidad bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        GarantiasFideicomisosFideicometidasEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosFideicometidasConsultarDetalle(conexion, conexionBitacora, entidad, bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }
	
	[WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE GARANTIAS FIDEICOMETIDAS")]
	public List<GarantiasFideicomisosFideicometidasEntidad> GarantiasFideicomisosFideicometidasConsultarGridInterno(GarantiasFideicomisosFideicometidasEntidad entidad)
    {
        List<GarantiasFideicomisosFideicometidasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosFideicometidasConsultarGridInterno(conexion, entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }
		
	[WebMethod(Description = "PROCEDIMIENTO: CONSULTA LA GARANTIA REALES PARA LA RELACION CON GARANTIA FIDEICOMETIDAS")]
    public GarantiasRealesEntidad GarantiasFideicomisosFideicometidaGarantiasRealesBusqueda(GarantiasRealesEntidad entidad)
    {
		string conexion = string.Empty;
        GarantiasRealesEntidad consulta = null;

		try
		{
			conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFideicomisosFideicometidaGarantiasRealesBusqueda(conexion, entidad);

			return consulta;
		}
		catch (Exception ex)
		{
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
		}
	}
		
	[WebMethod(Description = "PROCEDIMIENTO: CONSULTA LA GARANTIA VALOR PARA LA RELACION CON GARANTIA FIDEICOMETIDAS")]
    public GarantiasValoresEntidad GarantiasFideicomisosFideicometidasValoresBusqueda(GarantiasValoresEntidad entidad)
	{
		string conexion = string.Empty;
		GarantiasValoresEntidad consulta = null;

		try
		{
			conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
			consulta = garantiasNegocio.Instancia.GarantiasFideicomisosFideicometidasValoresBusqueda(conexion, entidad);

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

    #region FIDUCIARIOS

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE GARANTIAS FIDUCIARIAS")]
    public RespuestaEntidad GarantiasFiduciariasInsertar(GarantiasFiduciariasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFiduciariasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE GARANTIAS FIDUCIARIAS")]
    public RespuestaEntidad GarantiasFiduciariasModificar(GarantiasFiduciariasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFiduciariasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GARANTIAS FIDUCIARIAS")]
    public RespuestaEntidad GarantiasFiduciariasEliminar(GarantiasFiduciariasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFiduciariasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE GARANTIAS FIDUCIARIAS")]
    public List<GarantiasFiduciariasEntidad> GarantiasFiduciariasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<GarantiasFiduciariasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFiduciariasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE GARANTIAS FIDUCIARIAS")] 
    public GarantiasFiduciariasEntidad GarantiasFiduciariasConsultarDetalle(GarantiasFiduciariasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        GarantiasFiduciariasEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasFiduciariasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE GARANTIAS FIDUCIARIAS")]
    public int GarantiasFiduciariasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasFiduciariasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    #region VALORES

    [WebMethod(Description = "PROCEDIMIENTO: VALIDAR UN REGISTRO DE GARANTIAS VALORES")]
    public RespuestaEntidad GarantiasValoresValidar(GarantiasValoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasValoresValidar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }


    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE GARANTIAS VALORES")]
    public RespuestaEntidad GarantiasValoresInsertar(GarantiasValoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasValoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE GARANTIAS VALORES")]
    public RespuestaEntidad GarantiasValoresModificar(GarantiasValoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasValoresModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GARANTIAS VALORES")]
    public RespuestaEntidad GarantiasValoresEliminar(GarantiasValoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasValoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE GARANTIAS VALORES")]
    public List<GarantiasValoresEntidad> GarantiasValoresConsultar(ParametrosConsultaEntidad _entidad)
    {
        string conexion = string.Empty;
        List<GarantiasValoresEntidad> consulta = null;
        
        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasValoresConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE GARANTIAS VALORES")]
    public GarantiasValoresEntidad GarantiasValoresConsultarDetalle(GarantiasValoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        GarantiasValoresEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasValoresConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
		catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE GARANTIAS VALORES")]
    public int GarantiasValoresTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasValoresTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CONSULTA A UN CDP ESPECÍFICO")]
    public GarantiasValoresRespuestaCDPEntidad GarantiasValoresConsultarCDP(String numeroCDP)
    {
        string trama = string.Empty;
        string conexion = string.Empty;
        GarantiasValoresRespuestaCDPEntidad consultaTrama = new GarantiasValoresRespuestaCDPEntidad();

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);

            #endregion

            #region CONSULTAR TRAMA CDP

            AsignaWebServicesTypeNames();
            trama = garantiasNegocio.Instancia.GarantiasValoresCrearTrama(conexion, numeroCDP);
            trama = wsMQ.MQCDPS(trama);

            consultaTrama = ObtenerValoresCDP(trama);

            #endregion

            return consultaTrama;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CONSULTA DE UN ISIN")]
    public GarantiasValoresRespuestaISINEntidad GarantiasValoresConsultarISIN(String _valorISIN)
    {
        GarantiasValoresRespuestaISINEntidad consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasValoresConsultarISIN(conexion, _valorISIN);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;

        }
    }

    #endregion

    #region REALES

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA LA SECCION GENERAL DE UNA GARANTIA REAL")]
    public RespuestaEntidad GarantiasRealesInsertarGenerales(GarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesInsertarGenerales(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE GARANTIAS REALES")]
    public List<GarantiasRealesEntidad> GarantiasRealesConsultar(ParametrosConsultaEntidad _entidad)
    {
        string conexion = string.Empty;
        List<GarantiasRealesEntidad> consulta = null;
        
        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasRealesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: VALIDAR UN REGISTRO DE GARANTIAS REALES")]
    public RespuestaEntidad GarantiasRealesValidar(GarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesValidar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE GARANTIAS REALES")]
    public GarantiasRealesEntidad GarantiasRealesConsultarDetalle(GarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        GarantiasRealesEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE GARANTIAS REALES")]
    public int GarantiasRealesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasRealesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GARANTIAS REALES")]
    public RespuestaEntidad GarantiasRealesEliminar(GarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE GARANTIAS REALES")]
    public RespuestaEntidad GarantiasRealesModificar(GarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA EL TIPO IEN DE UN REGISTRO DE GARANTIAS REALES")]
    public RespuestaEntidad GarantiasRealesModificarTipoBien(GarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesModificarTipoBien(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }


    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO TASADOR PARA GARANTIAS REALES")]
    public RespuestaEntidad GarantiasRealesTasadoresInsertar(GarantiasRealesTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesTasadoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO TASADOR DE GARANTIAS REALES")]
    public RespuestaEntidad GarantiasRealesTasadoresEliminar(GarantiasRealesTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesTasadoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE EMPRESAS TASADORAS PARA GARANTIAS REALES")]
    public List<TasadoresEntidad> GarantiasRealesTasadoresConsultar()
    {
        List<TasadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasRealesTasadoresConsultar(conexion);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE PERSONAS TASADORAS PARA GARANTIAS REALES")]
    public List<TasadoresEntidad> GarantiasRealesPersonasTasadorasConsultar()
    {
        List<TasadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasRealesPersonasTasadorasConsultar(conexion);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TASADORES ASOCIADOS A UNA GARANTIA REAL")]
    public List<GarantiasRealesTasadoresEntidad> GarantiasRealesTasadoresConsultarGridInterno(int _idGarantiaReal)
    {
        List<GarantiasRealesTasadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasRealesTasadoresConsultarGridInterno(conexion, _idGarantiaReal);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TASADORES Y PERSONAS TASADORAS ASOCIADOS A UNA GARANTIA REAL")]
    public List<GarantiasRealesTasadoresEntidad> GarantiasRealesTasadoresPersonasTasadorasConsultaDetalle(GarantiasRealesTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        List<GarantiasRealesTasadoresEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasRealesTasadoresPersonasTasadorasConsultaDetalle(conexion, conexionBitacora, _entidad, _bitacora);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO CEDULA PARA GARANTIAS REALES")]
    public RespuestaEntidad GarantiasRealesCedulasInsertar(GarantiasRealesCedulasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesCedulasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO CEDULAS DE GARANTIAS REALES")]
    public RespuestaEntidad GarantiasRealesCedulasEliminar(GarantiasRealesCedulasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesCedulasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CEDULAS ASOCIADAS A UNA GARANTIA REAL")]
    public List<GarantiasRealesCedulasEntidad> GarantiasRealesCedulasConsultarGridInterno(int _idGarantiaReal)
    {
        List<GarantiasRealesCedulasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasRealesCedulasConsultarGridInterno(conexion, _idGarantiaReal);

            return consulta;
        }
        catch (Exception ex)
        {
			registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }


    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE INFORMACION PARA UNA IDENTIFICACION RUC ESPECÍFICA")]
    public PolizaClienteEntidad GarantiasRealesPolizaConsultarCliente(String identificacionRUC)
    {
        string trama = string.Empty;
        string conexion = string.Empty;
        PolizaClienteEntidad retorno = new PolizaClienteEntidad();

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);

            #endregion

            #region CONSULTAR TRAMA CLIENTE

            //WcfClienteConsultaBCRClientes.ClientCredentials.Windows.ClientCredential = wcfCredenciales();

            trama = garantiasNegocio.Instancia.GarantiasRealesPolizaCrearTrama(conexion, identificacionRUC);
            DatosSalida respuesta = WcfClienteConsultaBCRClientes.ConsultaDinamicaCliente(trama);

            retorno = ObtenerDatosCliente(respuesta);

            #endregion

            return retorno;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE POLIZAS ASOCIADOS A UNA GARANTIA")]
    public List<PolizaEntidad> GarantiasRealesPolizaGridInterno(PolizaEntidad entidad)
    {
        List<PolizaEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasRealesPolizaGridInterno(conexion, entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE UNA POLIZA ASOCIADA A UNA GARANTIA")]
    public RespuestaEntidad GarantiasRealesPolizaInsertar(PolizaEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesPolizaInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE UNA POLIZA ASOCIADA A UNA GARANTIA")]
    public RespuestaEntidad GarantiasRealesPolizaEliminar(PolizaEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesPolizaEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE UNA POLIZA ASOCIADA A UNA GARANTIA")]
    public PolizaEntidad GarantiasRealesPolizaConsultaDetalle(PolizaEntidad _entidad, BitacorasEntidad _bitacora)
    {
        PolizaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasRealesPolizaConsultaDetalle(conexion, conexionBitacora, _entidad, _bitacora);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: MODIFICA UN REGISTRO DE UNA POLIZA ASOCIADA A UNA GARANTIA")]
    public RespuestaEntidad GarantiasRealesPolizaModificar(PolizaEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesPolizaModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region OPERACIONES

    #region REQUERIMIENTO 1-24493201 INTERFAZ SICC

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE GARANTIAS OPERACION")]
    public List<GarantiasOperacionesEntidad> GarantiasOperacionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<GarantiasOperacionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesConsultar(conexion, _entidad);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE GARANTIAS OPERACION")]
    public int GarantiasOperacionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasOperacionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DEL DATABRIDGE SICC")]
    public GarantiasOperacionesClientesEntidad GarantiasOperacionesConsultaDataBridge(GarantiasOperacionesConsultaEntidad _entidad)
    {
        GarantiasOperacionesClientesEntidad consulta = null;
        string query = string.Empty;
        string conexion = string.Empty;
        string conexionSICC = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionSICC = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomDataBridge);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesConsultaDataBridge(conexion, conexionSICC, _entidad);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE LA CATEGORIA DE RIESGO DEUDOR SEGUN SIEF HIST")]
    public GarantiasOperacionesClientesEntidad GarantiasOperacionesConsultaRuc(GarantiasOperacionesClientesEntidad _entidad)
    {
        GarantiasOperacionesClientesEntidad consulta = null;
        string query = string.Empty;
        string conexion = string.Empty;
        string conexionSief = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionSief = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomSiefHisto);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesConsultaRuc(conexion, conexionSief, _entidad);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: VALIDAR UN REGISTRO DE GARANTIAS OPERACION")]
    public RespuestaEntidad GarantiasOperacionesValidar(GarantiasOperacionesClientesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesValidar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region REQUERIMIENTO 1-24493227 GARANTIAS

    #region GARANTIAS RELACIONES

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UNA RELACION DE GARANTIA OPERACION")]
    public RespuestaEntidad GarantiasOperacionesInsertarRelacion(GarantiasOperacionesRelacionEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = new RespuestaEntidad();
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesInsertarRelacion(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UNA RELACION DE GARANTIA OPERACION")]
    public RespuestaEntidad GarantiasOperacionesModificarRelacion(GarantiasOperacionesRelacionEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesModificarRelacion(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UNA RELACION DE GARANTIA OPERACION")]
    public RespuestaEntidad GarantiasOperacionesEliminarRelacion(GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = new RespuestaEntidad();
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesEliminarRelacion(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE GARANTIAS OPERACION")]
    public GarantiasOperacionesRelacionEntidad GarantiasOperacionesConsultarRelacion(GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        GarantiasOperacionesRelacionEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesConsultarRelacion(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE GARANTIAS ASOCIADAS A UNA OPERACION")]
    public List<GarantiasOperacionesEntidad> GarantiasOperacionesConsultarGarantiasGrid(int _idGarantiaOperacion)
    {
        List<GarantiasOperacionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasOperacionesConsultarGarantiasGrid(conexion, _idGarantiaOperacion);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE FECHA VENCIMIENTO DE LA GARANTIA")]
    public List<ListaEntidad> GarantiasOperacionesFechaVencimientoGarantia(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasOperacionesFechaVencimientoGarantia(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE FECHA PRESCIPCION DE LA GARANTIA")]
    public List<ListaEntidad> GarantiasOperacionesFechaPrescripcionGarantia(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasOperacionesFechaPrescripcionGarantia(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA LA GARANTIA REAL PARA LA RELACION CON GARANTIA OPERACION")]
    public GarantiasOperacionesRelacionEntidad OperacionesGarantiasRealesBusqueda(GarantiasOperacionesRelacionEntidad _entidad)
    {
        string conexion = string.Empty;
        GarantiasOperacionesRelacionEntidad consulta = null;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.OperacionesGarantiasRealesBusqueda(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA LA GARANTIA VALRO PARA LA RELACION CON GARANTIA OPERACION")]
    public GarantiasOperacionesRelacionEntidad OperacionesGarantiasValoresBusqueda(GarantiasOperacionesRelacionEntidad _entidad)
    {
        string conexion = string.Empty;
        GarantiasOperacionesRelacionEntidad consulta = null;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.OperacionesGarantiasValoresBusqueda(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA LA GARANTIA FIDUCIARIA PARA LA RELACION CON GARANTIA OPERACION")]
    public GarantiasOperacionesRelacionEntidad OperacionesGarantiasFiduciariasBusqueda(GarantiasOperacionesRelacionEntidad _entidad)
    {
        string conexion = string.Empty;
        GarantiasOperacionesRelacionEntidad consulta = null;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.OperacionesGarantiasFiduciariasBusqueda(conexion, _entidad);
            
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA LA GARANTIA AVAL PARA LA RELACION CON GARANTIA OPERACION")]
    public GarantiasOperacionesRelacionEntidad OperacionesGarantiasAvalesBusqueda(GarantiasOperacionesRelacionEntidad _entidad)
    {
        string conexion = string.Empty;
        GarantiasOperacionesRelacionEntidad consulta = null;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.OperacionesGarantiasAvalesBusqueda(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GARANTIAS OPERACION")]
    public RespuestaEntidad GarantiasOperacionesEliminar(GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RespuestaEntidad consulta = new RespuestaEntidad();
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE GARANTIAS OPERACION")]
    public GarantiasOperacionesEntidad GarantiasOperacionesConsultarDetalle(GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        GarantiasOperacionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UNA GARANTIA OPERACION")]
    public RespuestaEntidad GarantiasOperacionesModificar(GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #region RQ_MANT_2016022310547690_Backlog_865

    #region RELACION GARANTIA FIDEICOMISO

    [WebMethod(Description = "PROCEDIMIENTO: CONSULTA LA GARANTIA FIDEICOMISO PARA LA RELACION CON GARANTIA OPERACION")]
    public GarantiasOperacionesRelacionEntidad OperacionesGarantiasFideicomisosBusqueda(GarantiasOperacionesRelacionEntidad _entidad)
    {
        string conexion = string.Empty;
        GarantiasOperacionesRelacionEntidad consulta = null;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.OperacionesGarantiasFideicomisosBusqueda(conexion, _entidad);

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

    #endregion

    #region REQUERIMIENTO 1-24493262 REPLICAS SICC

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE GARANTIAS OPERACION EN SICC")]
    public RespuestaSICCEntidad GarantiasOperacionesInsertarReplicaSICC(String _idGarantiaOperacion, String _fechaPrescripcion, DateTime _fechaPrescripcionActualizada, String _Estado, String _codUsuario)
    {
        string trama = string.Empty;
        string resultadoSICC = string.Empty;

        string conexion = string.Empty;
        RespuestaEntidad consulta = null;
        RespuestaSICCEntidad consultaSICC = null;
        EnumTipoAccionReplica enumTipoAccionReplica = new EnumTipoAccionReplica();

        try
        {
            #region CONEXION BASE DATOS

            AsignaWebServicesTypeNames();
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);

            #endregion
            #region CONSULTAR TRAMA
            trama = garantiasNegocio.Instancia.GarantiasOperacionesCrearTrama(conexion, _idGarantiaOperacion, enumTipoAccionReplica.CONSULTAR, _fechaPrescripcion);
            consultaSICC = ValidarMensajeTrama(wsMQ.MQPrest(trama));

            if (consultaSICC.ValorEstado.Equals("0"))
            {
                trama = garantiasNegocio.Instancia.GarantiasOperacionesCrearTrama(conexion, _idGarantiaOperacion, enumTipoAccionReplica.BORRAR, _fechaPrescripcion);
                consultaSICC = ValidarMensajeTrama(wsMQ.MQPrest(trama));
            }
            #endregion
            #region INSERTAR TRAMA
            trama = garantiasNegocio.Instancia.GarantiasOperacionesCrearTrama(conexion, _idGarantiaOperacion, enumTipoAccionReplica.AGREGAR, _fechaPrescripcion);
            consultaSICC = ValidarMensajeTrama(wsMQ.MQPrest(trama));

            if (consultaSICC.ValorEstado.Equals("0"))
                consulta = garantiasNegocio.Instancia.GarantiasOperacionesEstadoReplica(conexion, _idGarantiaOperacion, 1, _codUsuario, _fechaPrescripcionActualizada);
            #endregion

            return consultaSICC;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GARANTIAS OPERACION EN SICC")]
    public RespuestaSICCEntidad GarantiasOperacionesEliminarReplicaSICC(String _idGarantiaOperacion, String _fechaPrescripcion, String _codUsuario)
    {
        string trama = string.Empty;
        string resultadoSICC = string.Empty;

        string conexion = string.Empty;
        RespuestaEntidad consulta = null;
        RespuestaSICCEntidad consultaSICC = null;
        EnumTipoAccionReplica _EnumTipoAccionReplica = new EnumTipoAccionReplica();
        DateTime? fechaPrescripcionActualizada = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);

            #endregion

            #region BORRAR TRAMA SICC

            AsignaWebServicesTypeNames();
            trama = garantiasNegocio.Instancia.GarantiasOperacionesCrearTrama(conexion, _idGarantiaOperacion, _EnumTipoAccionReplica.BORRAR, _fechaPrescripcion);
            consultaSICC = ValidarMensajeTrama(wsMQ.MQPrest(trama));

            if (consultaSICC.ValorEstado.Equals("0"))
                consulta = garantiasNegocio.Instancia.GarantiasOperacionesEstadoReplica(conexion, _idGarantiaOperacion, 0, _codUsuario, fechaPrescripcionActualizada);

            #endregion

            return consultaSICC;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region RELACION AVALES

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE CATEGORIAS CALIFICACIONES TIPOS MITIGADORES RIESGOS FILTRADO")]
    public List<ListaEntidad> CategoriasCalificacionesTiposMitigadoresRiesgos(String _filtro, String tipoGarantia)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.CategoriasCalificacionesTiposMitigadoresRiesgos(conexion, _filtro, tipoGarantia);

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

    #region GRAVAMENES GARANTIAS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE GRAVAMENES ASOCIADOS A UNA GARANTIA")]
    public List<GarantiasGravemenesEntidad> GarantiasGravamenesConsultarGridInterno(GarantiasGravemenesEntidad entidad)
    {
        List<GarantiasGravemenesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasGravamenesConsultarGridInterno(conexion, entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE GRAVAMEN ASOCIADO A UNA GARANTIA")]
    public RespuestaEntidad GarantiasGravamenesInsertar(GarantiasGravemenesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasGravamenesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GRAVAMEN ASOCIADO A UNA GARANTIA")]
    public RespuestaEntidad GarantiasGravamenesEliminar(GarantiasGravemenesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasGravamenesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE GRAVAMEN ASOCIADO A UNA GARANTIA")]
    public GarantiasGravemenesEntidad GarantiasGravamenesConsultaDetalle(GarantiasGravemenesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        GarantiasGravemenesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasGravamenesConsultaDetalle(conexion, conexionBitacora, _entidad, _bitacora);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: MODIFICA UN REGISTRO DE GRAVAMEN ASOCIADO A UNA GARANTIA")]
    public RespuestaEntidad GarantiasGravamenesModificar(GarantiasGravemenesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasGravamenesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region INSCRIPCION GARANTIAS REALES

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA LOS DATOS DE UNA INSCRIPCION GARANTIA REAL")]
    public RespuestaEntidad InscripcionGarantiasRealesInsertar(InscripcionGarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.InscripcionGarantiasRealesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: MODIFICA LOS DATOS DE UNA INSCRIPCION GARANTIA REAL")]
    public RespuestaEntidad InscripcionGarantiasRealesModificar(InscripcionGarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.InscripcionGarantiasRealesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }   
    
    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE INSCRIPCION GARANTIAS REALES")]
    public List<InscripcionGarantiasRealesEntidad> InscripcionGarantiasRealesConsultar(ParametrosConsultaEntidad _entidad)
    {
        string conexion = string.Empty;
        List<InscripcionGarantiasRealesEntidad> consulta = null;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.InscripcionGarantiasRealesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE INSCRIPCION GARANTIAS REALES")]
    public int InscripcionGarantiasRealesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.InscripcionGarantiasRealesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE INSCRIPCION GARANTIAS REALES")]
    public RespuestaEntidad InscripcionGarantiasRealesEliminar(InscripcionGarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.InscripcionGarantiasRealesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE OPERACIONES ASOCIADAS A GARANTIAS REALES")]
    public List<GarantiasOperacionesEntidad> InscripcionGarantiasRealesOperacionesConsultar(GarantiasRealesEntidad _entidad)
    {
        List<GarantiasOperacionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);

            #endregion

            consulta = garantiasNegocio.Instancia.InscripcionGarantiasRealesOperacionesConsultar(conexion, _entidad);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE INSCRIPCION GARANTIAS REALES")]
    public InscripcionGarantiasRealesEntidad InscripcionGarantiasRealesConsultarDetalle(InscripcionGarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        InscripcionGarantiasRealesEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.InscripcionGarantiasRealesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }


    #endregion

    #region MOBILIARIA GARANTIAS REALES

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE MOBILIARIA GARANTIAS REALES")]
    public List<MobiliariaGarantiasRealesEntidad> MobiliariaGarantiasRealesConsultar(ParametrosConsultaEntidad _entidad)
    {
        string conexion = string.Empty;
        List<MobiliariaGarantiasRealesEntidad> consulta = null;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.MobiliariaGarantiasRealesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE MOBILIARIAS GARANTIAS REALES")]
    public int MobiliariaGarantiasRealesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.MobiliariaGarantiasRealesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE MOBILIARIA GARANTIAS REALES")]
    public RespuestaEntidad MobiliariaGarantiasRealesEliminar(MobiliariaGarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.MobiliariaGarantiasRealesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE OPERACIONES ASOCIADAS A GARANTIAS REALES")]
    public List<GarantiasOperacionesEntidad> MobiliariaGarantiasRealesOperacionesConsultar(GarantiasRealesEntidad _entidad)
    {
        List<GarantiasOperacionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);

            #endregion

            consulta = garantiasNegocio.Instancia.MobiliariaGarantiasRealesOperacionesConsultar(conexion, _entidad);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA LOS DATOS DE UNA MOBILIARIA GARANTIA REAL")]
    public RespuestaEntidad MobiliariaGarantiasRealesInsertar(MobiliariaGarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.MobiliariaGarantiasRealesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: MODIFICA LOS DATOS DE UNA MOBILIARIA GARANTIA REAL")]
    public RespuestaEntidad MobiliariaGarantiasRealesModificar(MobiliariaGarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        RespuestaEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.MobiliariaGarantiasRealesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE MOBILIARIA GARANTIAS REALES")]
    public MobiliariaGarantiasRealesEntidad MobiliariaGarantiasRealesConsultarDetalle(MobiliariaGarantiasRealesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        MobiliariaGarantiasRealesEntidad consulta = null;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.MobiliariaGarantiasRealesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    #region METODOS PRIVADOS GARANTIAS

    private void AsignaWebServicesTypeNames()
    {
        try
        {
            string ruta = ConfigurationManager.AppSettings["MQServicioWS"].ToString();
            wsMQ.Url = ValidaConexionServicioMQ(ruta);
        }
        catch (Exception)
        {
            registrarEventLog.RegistrarMensajeLog(mensajeError, "ERROR", Resources.Resource._eventoSource);
            throw new ArgumentException(mensajeError);
        }
    }

    private string ValidaConexionServicioMQ(string urlServicio)
    {
        string mensaje = string.Empty;

        if (ExisteConexion(urlServicio))
        {
            mensaje = urlServicio;
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

    private GarantiasValoresRespuestaCDPEntidad ObtenerValoresCDP(string trama)
    {
        GarantiasValoresRespuestaCDPEntidad entidad = new GarantiasValoresRespuestaCDPEntidad();

        try
        {
            XDocument doc = XDocument.Parse(trama);
            var errors = from e in doc.Descendants("R1340")
                         select new
                         {
                             respuest = e.Element("CODIGORESPUESTA").Value,
                             moneda = e.Element("MONEDA").Value,
                             monto = e.Element("MONTO").Value,
                             emision = e.Element("FECHAEMISION").Value,
                             vencimiento = e.Element("FECVECTO").Value.Trim(),
                             numeroCDP = e.Element("NUMCDP").Value
                         };

            string _culture = ConfigurationManager.AppSettings["Culture"].ToString();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(_culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_culture);

            foreach (var e in errors)
            {
                entidad.NumeroCDP = int.Parse(e.numeroCDP);
                entidad.ValorEstado = (int.Parse(e.numeroCDP) > 0) ? 0 : -1;
                entidad.MonedaCDP = int.Parse(e.moneda);
                entidad.FechaEmisionCDP = DateTime.Parse(e.emision);
                entidad.FechaVencimientoCDP = DateTime.Parse(e.vencimiento);
                string _monto = (decimal.Parse(e.monto) / 100).ToString();
                entidad.MontoCDP = decimal.Parse(_monto);
            }
        }
        catch
        {
            entidad = null;
        }

        return entidad;
    }

    private PolizaClienteEntidad ObtenerDatosCliente(DatosSalida respuesta)
    {
        PolizaClienteEntidad retornoCliente = new PolizaClienteEntidad();

        retornoCliente.CodigoError = respuesta.CodigoError.ToString();

        if (respuesta.CodigoError.Equals(0))
        {
            var doc = XDocument.Parse(respuesta.XmlRespuesta);
            var retorno = (from r in doc.Root.Elements("DatosSalida")
                           select new
                           {
                               Nombre = (string)r.Element("Nombre"),
                               PrimerApellido = (string)r.Element("Apellido1"),
                               SegundoApellido = (string)r.Element("Apellido2"),
                               RazonSocial = (string)r.Element("RazonSocial"),
                               Telefonos = (from tels in r.Elements("Telefonos").Elements("Telefonos")
                                            select new
                                            {
                                                TipoTelefono = tels.Attribute("Tipo_Telefono").Value.ToString(),
                                                NumTelefono = tels.Attribute("Telefono").Value.ToString()
                                            }).DefaultIfEmpty(),
                               Direcciones = (from dir in r.Elements("Direcciones").Elements("Direcciones")
                                              select new
                                              {
                                                  Provincia = dir.Attribute("Provincia").Value.ToString(),
                                                  Canton = dir.Attribute("Canton").Value.ToString(),
                                                  Distrito = dir.Attribute("Distrito").Value.ToString(),
                                                  Direccion = dir.Attribute("Direccion").Value.ToString(),
                                                  IndPrincipal = dir.Attribute("Indicador_Principal").Value.ToString()
                                              }).DefaultIfEmpty()

                           }).FirstOrDefault();


            if (retorno != null)
            {
                retornoCliente.Nombre = retorno.Nombre;
                retornoCliente.PrimerApellido = retorno.PrimerApellido;
                retornoCliente.SegundoApellido = retorno.SegundoApellido;
                retornoCliente.RazonSocial = retorno.RazonSocial;

                foreach (var a in retorno.Telefonos)
                {
                    if (a != null)
                    {
                        if (a.TipoTelefono.Contains("HABITACIÓN"))
                            retornoCliente.Telefono = a.NumTelefono;
                        if (a.TipoTelefono.Contains("MÓVIL"))
                            retornoCliente.TelefonoMovil = a.NumTelefono;
                        if (a.TipoTelefono.Contains("TRABAJO 1"))
                            retornoCliente.TelefonoTrabajo = a.NumTelefono;
                    }
                }

                int cantidad = (from direccion in retorno.Direcciones
                                group direccion by direccion.IndPrincipal into grupo
                                select grupo.Count()
                                 ).DefaultIfEmpty().Count();


                foreach (var d in retorno.Direcciones)
                {
                    if (d != null)
                    {
                        if (cantidad.Equals(1))
                        {
                            retornoCliente.Provincia = d.Provincia;
                            retornoCliente.Canton = d.Canton;
                            retornoCliente.Distrito = d.Distrito;
                            retornoCliente.Direccion = d.Direccion;
                        }
                        else
                        {
                            if (d.IndPrincipal.Equals("Y"))
                            {
                                retornoCliente.Provincia = d.Provincia;
                                retornoCliente.Canton = d.Canton;
                                retornoCliente.Distrito = d.Distrito;
                                retornoCliente.Direccion = d.Direccion;
                            }
                        }
                    }
                }
            }
        }

        return retornoCliente;
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

    //REQUERIMIENTO 1-24493262
    private RespuestaSICCEntidad ValidarMensajeTrama(string trama)
    {
        RespuestaSICCEntidad mensaje = new RespuestaSICCEntidad();

        XDocument doc = XDocument.Parse(trama);
        var errors = from e in doc.Descendants("HEADER")
                     select new
                     {
                         code = e.Element("CODIGORESPUESTA").Value,
                         msg = e.Element("DESCRIPCION").Value.Trim(),
                     };

        foreach (var e in errors)
        {
            mensaje.ValorEstado = e.code;
            mensaje.ValorEstadoCadena = e.msg;
        }

        return mensaje;
    }

    //REQUERIMIENTO 1-24493262
    private RespuestaEntidad GarantiasOperacionesEstadoReplica(String idGarantiaOperacion, int indEstadoReplicado, String codUsuario, DateTime? fechaPrescripcionActualizada)
    {
        RespuestaEntidad consulta = new RespuestaEntidad();
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasOperacionesEstadoReplica(conexion, idGarantiaOperacion, indEstadoReplicado, codUsuario, fechaPrescripcionActualizada);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

}
