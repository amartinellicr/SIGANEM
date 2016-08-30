using System;
using System.Web;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.EN;
using BCR.SIGANEM.BL;
using BCR.SIGANEM.UT;


[WebService(Namespace = "http://bancobcr.com/", Description = "SERVICIO WEB CONSULTAS CONFIGURACION")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SiganemConsultasWS : System.Web.Services.WebService
{
    
    #region PROPIEDADES

    #region NEGOCIO

    private MantenimientosNegocio mantenimientosNegocio = new MantenimientosNegocio();
    private ProcesosNegocio procesosNegocio = new ProcesosNegocio();

    #endregion

    #region UTILIDADES

    private RegistrarEventLog registrarEventLog = new RegistrarEventLog();
    private LectorConfiguracion lectorConfiguracion = new LectorConfiguracion();

    #endregion

    #endregion

    #region CONSTRUCTOR

    public SiganemConsultasWS()
    {
        
    }

    #endregion

    #region METODOS PUBLICOS CONFIGURACION CATALOGOS

    #region ACTIVOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ACTIVOS")]
    public RespuestaEntidad ActivosEliminar(ActivosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ActivosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ACTIVOS")]
    public List<ActivosEntidad> ActivosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<ActivosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ActivosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ACTIVOS")]
    public int ActivosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ActivosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region APLICABLES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE APLICABLES")]
    public RespuestaEntidad AplicablesEliminar(AplicablesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.AplicablesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE APLICABLES")]
    public List<AplicablesEntidad> AplicablesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<AplicablesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.AplicablesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE APLICABLES")]
    public int AplicablesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.AplicablesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region BIENES VALORAR

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE BIENES VALORAR")]
    public RespuestaEntidad BienesValorarEliminar(BienesValorarEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.BienesValorarEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE BIENES VALORAR")]
    public List<BienesValorarEntidad> BienesValorarConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<BienesValorarEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.BienesValorarConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE BIENES VALORAR")]
    public int BienesValorarTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.BienesValorarTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CAJAS BREAKERS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CAJAS BREAKERS")]
    public RespuestaEntidad CajasBreakersEliminar(CajasBreakersEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CajasBreakersEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CAJAS BREAKERS")]
    public List<CajasBreakersEntidad> CajasBreakersConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CajasBreakersEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CajasBreakersConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CAJAS BREAKERS")]
    public int CajasBreakersTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CajasBreakersTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region CALIFICACIONES EMPRESAS CALIFICADORAS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CALIFICACIONES EMPRESAS CALIFICADORAS")]
    public CalificacionesEmpresasCalificadorasEntidad CalificacionesEmpresasCalificadorasConsultarDetalle(CalificacionesEmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CalificacionesEmpresasCalificadorasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CALIFICACIONES EMPRESAS CALIFICADORAS")]
    public int CalificacionesEmpresasCalificadorasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CANALIZACIONES ELÉCTRICAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CANALIZACIONES ELÉCTRICAS")]
    public RespuestaEntidad CanalizacionesElectricasEliminar(CanalizacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CanalizacionesElectricasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CANALIZACIONES ELÉCTRICAS")]
    public List<CanalizacionesElectricasEntidad> CanalizacionesElectricasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CanalizacionesElectricasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CanalizacionesElectricasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CANALIZACIONES ELÉCTRICAS")]
    public int CanalizacionesElectricasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CanalizacionesElectricasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CANOAS BAJANTES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CANOAS BAJANTES")]
    public RespuestaEntidad CanoasBajantesEliminar(CanoasBajantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CanoasBajantesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CANOAS BAJANTES")]
    public List<CanoasBajantesEntidad> CanoasBajantesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CanoasBajantesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CanoasBajantesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CANOAS BAJANTES")]
    public int CanoasBajantesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CanoasBajantesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CANTIDADES FINCAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CANTIDADES FINCAS")]
    public RespuestaEntidad CantidadesFincasEliminar(CantidadesFincasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CantidadesFincasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CANTIDADES FINCAS")]
    public List<CantidadesFincasEntidad> CantidadesFincasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CantidadesFincasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CantidadesFincasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CANTIDADES FINCAS")]
    public int CantidadesFincasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CantidadesFincasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CANTONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CANTONES")]
    public RespuestaEntidad CantonesEliminar(CantonesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CantonesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CANTONES")]
    public List<CantonesEntidad> CantonesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CantonesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CantonesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CANTONES")]
    public int CantonesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CantonesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CATEGORÍAS CALIFICACIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CATEGORÍAS CALIFICACIONES")]
    public RespuestaEntidad CategoriasCalificacionesEliminar(CategoriasCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CATEGORÍAS CALIFICACIONES")]
    public List<CategoriasCalificacionesEntidad> CategoriasCalificacionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CategoriasCalificacionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CATEGORÍAS CALIFICACIONES")]
    public int CategoriasCalificacionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CATEGORÍAS RIESGOS DEUDORES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CATEGORÍAS RIESGOS DEUDORES")]
    public RespuestaEntidad CategoriasRiesgosDeudoresEliminar(CategoriasRiesgosDeudoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosDeudoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CATEGORÍAS RIESGOS DEUDORES")]
    public List<CategoriasRiesgosDeudoresEntidad> CategoriasRiesgosDeudoresConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CategoriasRiesgosDeudoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosDeudoresConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CATEGORÍAS RIESGOS DEUDORES")]
    public int CategoriasRiesgosDeudoresTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosDeudoresTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region CATEGORIAS RIESGOS EMPRESAS CALIFICADORAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CATEGORIAS RIESGOS EMPRESAS CALIFICADORAS")]
    public RespuestaEntidad CategoriasRiesgosEmpresasCalificadorasEliminar(CategoriasRiesgosEmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosEmpresasCalificadorasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CATEGORIAS RIESGOS EMPRESAS CALIFICADORAS")]
    public List<CategoriasRiesgosEmpresasCalificadorasEntidad> CategoriasRiesgosEmpresasCalificadorasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CategoriasRiesgosEmpresasCalificadorasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosEmpresasCalificadorasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CATEGORIAS RIESGOS EMPRESAS CALIFICADORAS")]
    public int CategoriasRiesgosEmpresasCalificadorasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosEmpresasCalificadorasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CERRAJERÍAS PIEZAS SANITARIAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CERRAJERÍAS PIEZAS SANITARIAS")]
    public RespuestaEntidad CerrajeriasPiezasSanitariasEliminar(CerrajeriasPiezasSanitariasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CerrajeriasPiezasSanitariasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CERRAJERÍAS PIEZAS SANITARIAS")]
    public List<CerrajeriasPiezasSanitariasEntidad> CerrajeriasPiezasSanitariasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CerrajeriasPiezasSanitariasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CerrajeriasPiezasSanitariasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CERRAJERÍAS PIEZAS SANITARIAS")]
    public int CerrajeriasPiezasSanitariasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CerrajeriasPiezasSanitariasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CIELOS RASOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CIELOS RASOS")]
    public RespuestaEntidad CielosRasosEliminar(CielosRasosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CielosRasosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CIELOS RASOS")]
    public List<CielosRasosEntidad> CielosRasosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CielosRasosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CielosRasosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CIELOS RASOS")]
    public int CielosRasosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CielosRasosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CLASES AERONAVES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CLASES AERONAVES")]
    public RespuestaEntidad ClasesAeronavesEliminar(ClasesAeronavesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesAeronavesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CLASES AERONAVES")]
    public List<ClasesAeronavesEntidad> ClasesAeronavesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<ClasesAeronavesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ClasesAeronavesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CLASES AERONAVES")]
    public int ClasesAeronavesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ClasesAeronavesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CLASES BUQUES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CLASES BUQUES")]
    public RespuestaEntidad ClasesBuquesEliminar(ClasesBuquesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesBuquesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CLASES BUQUES")]
    public List<ClasesBuquesEntidad> ClasesBuquesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<ClasesBuquesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ClasesBuquesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CLASES BUQUES")]
    public int ClasesBuquesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ClasesBuquesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CLASES GARANTÍAS PRT17

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CLASES GARANTÍAS PRT17")]
    public RespuestaEntidad ClasesGarantiasPrt17Eliminar(ClasesGarantiasPrt17Entidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesGarantiasPrt17Eliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CLASES GARANTÍAS PRT17")]
    public List<ClasesGarantiasPrt17Entidad> ClasesGarantiasPrt17Consultar(ParametrosConsultaEntidad _entidad)
    {
        List<ClasesGarantiasPrt17Entidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ClasesGarantiasPrt17Consultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CLASES GARANTÍAS PRT17")]
    public int ClasesGarantiasPrt17TotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ClasesGarantiasPrt17TotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CLASES VEHÍCULOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CLASES VEHÍCULOS")]
    public RespuestaEntidad ClasesVehiculosEliminar(ClasesVehiculosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesVehiculosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CLASES VEHÍCULOS")]
    public List<ClasesVehiculosEntidad> ClasesVehiculosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<ClasesVehiculosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ClasesVehiculosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CLASES VEHÍCULOS")]
    public int ClasesVehiculosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ClasesVehiculosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CÓDIGOS DUPLICADOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CÓDIGOS DUPLICADOS")]
    public RespuestaEntidad CodigosDuplicadosEliminar(CodigosDuplicadosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CodigosDuplicadosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CÓDIGOS DUPLICADOS")]
    public List<CodigosDuplicadosEntidad> CodigosDuplicadosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CodigosDuplicadosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CodigosDuplicadosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CÓDIGOS DUPLICADOS")]
    public int CodigosDuplicadosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CodigosDuplicadosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CÓDIGOS HORIZONTALIDAD

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CÓDIGOS HORIZONTALIDAD")]
    public RespuestaEntidad CodigosHorizontalidadEliminar(CodigosHorizontalidadEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CodigosHorizontalidadEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CÓDIGOS HORIZONTALIDAD")]
    public List<CodigosHorizontalidadEntidad> CodigosHorizontalidadConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CodigosHorizontalidadEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CodigosHorizontalidadConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CÓDIGOS HORIZONTALIDAD")]
    public int CodigosHorizontalidadTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CodigosHorizontalidadTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region COLINDANTES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE COLINDANTES")]
    public RespuestaEntidad ColindantesEliminar(ColindantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ColindantesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE COLINDANTES")]
    public List<ColindantesEntidad> ColindantesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<ColindantesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ColindantesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE COLINDANTES")]
    public int ColindantesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ColindantesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CUBIERTAS TECHOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CUBIERTAS TECHOS")]
    public RespuestaEntidad CubiertasTechosEliminar(CubiertasTechosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CubiertasTechosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CUBIERTAS TECHOS")]
    public List<CubiertasTechosEntidad> CubiertasTechosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<CubiertasTechosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CubiertasTechosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE CUBIERTAS TECHOS")]
    public int CubiertasTechosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CubiertasTechosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region DECISIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE DECISIONES")]
    public RespuestaEntidad DecisionesEliminar(DecisionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DecisionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE DECISIONES")]
    public List<DecisionesEntidad> DecisionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<DecisionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DecisionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE DECISIONES")]
    public int DecisionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DecisionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region DELIMITACIONES LINDEROS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE DELIMITACIONES LINDEROS")]
    public RespuestaEntidad DelimitacionesLinderosEliminar(DelimitacionesLinderosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DelimitacionesLinderosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE DELIMITACIONES LINDEROS")]
    public List<DelimitacionesLinderosEntidad> DelimitacionesLinderosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<DelimitacionesLinderosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DelimitacionesLinderosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE DELIMITACIONES LINDEROS")]
    public int DelimitacionesLinderosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DelimitacionesLinderosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region DERECHOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE DERECHOS")]
    public RespuestaEntidad DerechosEliminar(DerechosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DerechosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE DERECHOS")]
    public List<DerechosEntidad> DerechosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<DerechosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DerechosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE DERECHOS")]
    public int DerechosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DerechosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region DISTRIBUCIONES ZONAS TASADORES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE DISTRIBUCIONES ZONAS TASADORES")]
    public RespuestaEntidad DistribucionZonasTasadoresEliminar(DistribucionesZonasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DistribucionZonasTasadoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE DISTRIBUCIONES ZONAS TASADORES")]
    public List<DistribucionesZonasTasadoresEntidad> DistribucionZonasTasadoresConsultar(ParametrosConsultaEntidad _entidad, string _zona)
    {
        List<DistribucionesZonasTasadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DistribucionZonasTasadoresConsultar(conexion, _entidad, _zona);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE DISTRIBUCIONES ZONAS TASADORES")]
    public int DistribucionZonasTasadoresTotalFilas(ParametrosTotalFilasEntidad _entidad, string _zona)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DistribucionZonasTasadoresTotalFilas(conexion, _entidad, _zona);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region DISTRITOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE DISTRITOS")]
    public RespuestaEntidad DistritosEliminar(DistritosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DistritosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE DISTRITOS")]
    public List<DistritosEntidad> DistritosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<DistritosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DistritosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE DISTRITOS")]
    public int DistritosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DistritosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region EMISIONES INSTRUMENTOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE EMISIONES INSTRUMENTOS")]
    public RespuestaEntidad EmisionesInstrumentosEliminar(EmisionesInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE EMISIONES INSTRUMENTOS")]
    public List<EmisionesInstrumentosEntidad> EmisionesInstrumentosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EmisionesInstrumentosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE EMISIONES INSTRUMENTOS")]
    public int EmisionesInstrumentosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region EMISORES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE EMISORES")]
    public RespuestaEntidad EmisoresEliminar(EmisoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmisoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE EMISORES")]
    public List<EmisoresEntidad> EmisoresConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EmisoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisoresConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE EMISORES")]
    public int EmisoresTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisoresTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region EMPRESAS CALIFICADORAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE EMPRESAS CALIFICADORAS")]
    public RespuestaEntidad EmpresasCalificadorasEliminar(EmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmpresasCalificadorasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE EMPRESAS CALIFICADORAS")]
    public List<EmpresasCalificadorasEntidad> EmpresasCalificadorasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EmpresasCalificadorasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmpresasCalificadorasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE EMPRESAS CALIFICADORAS")]
    public int EmpresasCalificadorasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmpresasCalificadorasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region EMPRESAS TASADORES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE EMPRESAS TASADORAS")]
    public RespuestaEntidad EmpresasTasadorasEliminar(TasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmpresasTasadorasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE EMPRESAS TASADORAS")]
    public List<TasadoresEntidad> EmpresasTasadorasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TasadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmpresasTasadorasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE EMPRESAS TASADORAS")]
    public int EmpresasTasadorasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmpresasTasadorasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ENCHAPES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ENCHAPES")]
    public RespuestaEntidad EnchapesEliminar(EnchapesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EnchapesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ENCHAPES")]
    public List<EnchapesEntidad> EnchapesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EnchapesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EnchapesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ENCHAPES")]
    public int EnchapesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EnchapesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ENFOQUES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ENFOQUES")]
    public RespuestaEntidad EnfoquesEliminar(EnfoquesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EnfoquesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ENFOQUES")]
    public List<EnfoquesEntidad> EnfoquesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EnfoquesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EnfoquesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ENFOQUES")]
    public int EnfoquesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EnfoquesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ENTIDADES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ENTIDADES")]
    public RespuestaEntidad EntidadesEliminar(EntidadesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EntidadesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ENTIDADES")]
    public List<EntidadesEntidad> EntidadesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EntidadesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EntidadesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ENTIDADES")]
    public int EntidadesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EntidadesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ENTREPISOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ENTREPISOS")]
    public RespuestaEntidad EntrepisosEliminar(EntrepisosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EntrepisosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ENTREPISOS")]
    public List<EntrepisosEntidad> EntrepisosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EntrepisosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EntrepisosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ENTREPISOS")]
    public int EntrepisosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EntrepisosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ESCALERAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ESCALERAS")]
    public RespuestaEntidad EscalerasEliminar(EscalerasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EscalerasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ESCALERAS")]
    public List<EscalerasEntidad> EscalerasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EscalerasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EscalerasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ESCALERAS")]
    public int EscalerasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EscalerasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ESTADOS AVALÚOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ESTADOS AVALÚOS")]
    public RespuestaEntidad EstadosAvaluosEliminar(EstadosAvaluosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstadosAvaluosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ESTADOS AVALÚOS")]
    public List<EstadosAvaluosEntidad> EstadosAvaluosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EstadosAvaluosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EstadosAvaluosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ESTADOS AVALÚOS")]
    public int EstadosAvaluosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EstadosAvaluosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ESTADOS CONSTRUCCIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ESTADOS CONSTRUCCIONES")]
    public RespuestaEntidad EstadosConstruccionesEliminar(EstadosConstruccionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstadosConstruccionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ESTADOS CONSTRUCCIONES")]
    public List<EstadosConstruccionesEntidad> EstadosConstruccionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EstadosConstruccionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EstadosConstruccionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ESTADOS CONSTRUCCIONES")]
    public int EstadosConstruccionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EstadosConstruccionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ESTADOS INSTALACIONES ELÉCTRICAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ESTADOS INSTALACIONES ELÉCTRICAS")]
    public RespuestaEntidad EstadosInstalacionesElectricasEliminar(EstadosInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstadosInstalacionesElectricasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ESTADOS INSTALACIONES ELÉCTRICAS")]
    public List<EstadosInstalacionesElectricasEntidad> EstadosInstalacionesElectricasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EstadosInstalacionesElectricasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EstadosInstalacionesElectricasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ESTADOS INSTALACIONES ELÉCTRICAS")]
    public int EstadosInstalacionesElectricasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EstadosInstalacionesElectricasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ESTRUCTURAS TECHOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ESTRUCTURAS TECHOS")]
    public RespuestaEntidad EstructurasTechosEliminar(EstructurasTechosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstructurasTechosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ESTRUCTURAS TECHOS")]
    public List<EstructurasTechosEntidad> EstructurasTechosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<EstructurasTechosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EstructurasTechosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ESTRUCTURAS TECHOS")]
    public int EstructurasTechosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EstructurasTechosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region FISCALIZADORES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE FISCALIZADORES")]
    public RespuestaEntidad FiscalizadoresEliminar(FiscalizadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.FiscalizadoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE FISCALIZADORES")]
    public List<FiscalizadoresEntidad> FiscalizadoresConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<FiscalizadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.FiscalizadoresConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE FISCALIZADORES")]
    public int FiscalizadoresTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.FiscalizadoresTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region FORMAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE FORMAS")]
    public RespuestaEntidad FormasEliminar(FormasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.FormasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE FORMAS")]
    public List<FormasEntidad> FormasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<FormasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.FormasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE FORMAS")]
    public int FormasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.FormasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region GRADOS GRAVÁMENES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GRADOS GRAVÁMENES")]
    public RespuestaEntidad GradosGravamenesEliminar(GradosGravamenesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.GradosGravamenesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE GRADOS GRAVÁMENES")]
    public List<GradosGravamenesEntidad> GradosGravamenesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<GradosGravamenesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.GradosGravamenesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE GRADOS GRAVÁMENES")]
    public int GradosGravamenesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.GradosGravamenesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region GRUPOS FINANCIEROS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GRUPOS FINANCIEROS")]
    public RespuestaEntidad GruposFinancierosEliminar(GruposFinancierosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.GruposFinancierosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE GRUPOS FINANCIEROS")]
    public List<GruposFinancierosEntidad> GruposFinancierosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<GruposFinancierosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.GruposFinancierosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE GRUPOS FINANCIEROS")]
    public int GruposFinancierosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.GruposFinancierosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region GRUPOS RIESGOS DEUDORES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE GRUPOS RIESGOS DEUDORES")]
    public RespuestaEntidad GruposRiesgosDeudoresEliminar(GruposRiesgosDeudoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.GruposRiesgosDeudoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE GRUPOS RIESGOS DEUDORES")]
    public List<GruposRiesgosDeudoresEntidad> GruposRiesgosDeudoresConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<GruposRiesgosDeudoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.GruposRiesgosDeudoresConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE GRUPOS RIESGOS DEUDORES")]
    public int GruposRiesgosDeudoresTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.GruposRiesgosDeudoresTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region INDICACIONES AJUSTES ÁREAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE INDICACIONES AJUSTES ÁREAS")]
    public RespuestaEntidad IndicacionesAjustesAreasEliminar(IndicacionesAjustesAreasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.IndicacionesAjustesAreasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE INDICACIONES AJUSTES ÁREAS")]
    public List<IndicacionesAjustesAreasEntidad> IndicacionesAjustesAreasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<IndicacionesAjustesAreasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.IndicacionesAjustesAreasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE INDICACIONES AJUSTES ÁREAS")]
    public int IndicacionesAjustesAreasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.IndicacionesAjustesAreasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region INDICADORES GENERADORES DIVISAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE INDICADORES GENERADORES DIVISAS")]
    public RespuestaEntidad IndicadoresGeneradoresDivisasEliminar(IndicadoresGeneradoresDivisasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.IndicadoresGeneradoresDivisasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE INDICADORES GENERADORES DIVISAS")]
    public List<IndicadoresGeneradoresDivisasEntidad> IndicadoresGeneradoresDivisasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<IndicadoresGeneradoresDivisasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.IndicadoresGeneradoresDivisasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE INDICADORES GENERADORES DIVISAS")]
    public int IndicadoresGeneradoresDivisasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.IndicadoresGeneradoresDivisasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region INDICADORES MONEDAS EXTRANJERAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE INDICADORES MONEDAS EXTRANJERAS")]
    public RespuestaEntidad IndicadoresMonedasExtranjerasEliminar(IndicadoresMonedasExtranjerasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.IndicadoresMonedasExtranjerasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE INDICADORES MONEDAS EXTRANJERAS")]
    public List<IndicadoresMonedasExtranjerasEntidad> IndicadoresMonedasExtranjerasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<IndicadoresMonedasExtranjerasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.IndicadoresMonedasExtranjerasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE INDICADORES MONEDAS EXTRANJERAS")]
    public int IndicadoresMonedasExtranjerasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.IndicadoresMonedasExtranjerasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region INSTRUMENTOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE INSTRUMENTOS")]
    public RespuestaEntidad InstrumentosEliminar(InstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.InstrumentosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE INSTRUMENTOS")]
    public List<InstrumentosEntidad> InstrumentosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<InstrumentosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.InstrumentosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE INSTRUMENTOS")]
    public int InstrumentosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.InstrumentosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region INTERRUPTORES INSTALACIONES ELÉCTRICAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE INTERRUPTORES INSTALACIONES ELÉCTRICAS")]
    public RespuestaEntidad InterruptoresInstalacionesElectricasEliminar(InterruptoresInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.InterruptoresInstalacionesElectricasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE INTERRUPTORES INSTALACIONES ELÉCTRICAS")]
    public List<InterruptoresInstalacionesElectricasEntidad> InterruptoresInstalacionesElectricasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<InterruptoresInstalacionesElectricasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.InterruptoresInstalacionesElectricasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE INTERRUPTORES INSTALACIONES ELÉCTRICAS")]
    public int InterruptoresInstalacionesElectricasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.InterruptoresInstalacionesElectricasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region LOTES SEGREGADOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE LOTES SEGREGADOS")]
    public RespuestaEntidad LotesSegregadosEliminar(LotesSegregadosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.LotesSegregadosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE LOTES SEGREGADOS")]
    public List<LotesSegregadosEntidad> LotesSegregadosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<LotesSegregadosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.LotesSegregadosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE LOTES SEGREGADOS")]
    public int LotesSegregadosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.LotesSegregadosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region MATERIALES CONSTRUCCIONES PREDOMINANTES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE MATERIALES CONSTRUCCIONES PREDOMINANTES")]
    public RespuestaEntidad MaterialesConstruccionesPredominantesEliminar(MaterialesConstruccionesPredominantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesConstruccionesPredominantesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE MATERIALES CONSTRUCCIONES PREDOMINANTES")]
    public List<MaterialesConstruccionesPredominantesEntidad> MaterialesConstruccionesPredominantesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<MaterialesConstruccionesPredominantesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesConstruccionesPredominantesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE MATERIALES CONSTRUCCIONES PREDOMINANTES")]
    public int MaterialesConstruccionesPredominantesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesConstruccionesPredominantesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region MATERIALES PAREDES EXTERNAS INTERNAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE MATERIALES PAREDES EXTERNAS INTERNAS")]
    public RespuestaEntidad MaterialesParedesExternasInternasEliminar(MaterialesExternosInternosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasInternasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE MATERIALES PAREDES EXTERNAS INTERNAS")]
    public List<MaterialesExternosInternosEntidad> MaterialesParedesExternasInternasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<MaterialesExternosInternosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasInternasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE MATERIALES PAREDES EXTERNAS INTERNAS")]
    public int MaterialesParedesExternasInternasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasInternasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region MATERIALES PAREDES EXTERNAS TAPICHELES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE MATERIALES PAREDES EXTERNAS TAPICHELES")]
    public RespuestaEntidad MaterialesParedesExternasTapichelesEliminar(MaterialesExternosTapichelesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasTapichelesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE MATERIALES PAREDES EXTERNAS TAPICHELES")]
    public List<MaterialesExternosTapichelesEntidad> MaterialesParedesExternasTapichelesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<MaterialesExternosTapichelesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasTapichelesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE MATERIALES PAREDES EXTERNAS TAPICHELES")]
    public int MaterialesParedesExternasTapichelesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasTapichelesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region MATERIALES PISOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE MATERIALES PISOS")]
    public RespuestaEntidad MaterialesPisosEliminar(MaterialesPisosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesPisosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE MATERIALES PISOS")]
    public List<MaterialesPisosEntidad> MaterialesPisosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<MaterialesPisosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesPisosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE MATERIALES PISOS")]
    public int MaterialesPisosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesPisosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region MATERIALES PUERTAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE MATERIALES PUERTAS")]
    public RespuestaEntidad MaterialesPuertasEliminar(MaterialesPuertasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesPuertasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE MATERIALES PUERTAS")]
    public List<MaterialesPuertasEntidad> MaterialesPuertasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<MaterialesPuertasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesPuertasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE MATERIALES PUERTAS")]
    public int MaterialesPuertasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesPuertasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region MATERIALES VÍAS ACCESO

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE MATERIALES VÍAS ACCESO")]
    public RespuestaEntidad MaterialesViasAccesoEliminar(MaterialesViasAccesoEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesViasAccesoEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE MATERIALES VÍAS ACCESO")]
    public List<MaterialesViasAccesoEntidad> MaterialesViasAccesoConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<MaterialesViasAccesoEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesViasAccesoConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE MATERIALES VÍAS ACCESO")]
    public int MaterialesViasAccesoTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MaterialesViasAccesoTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region MONEDAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE MONEDAS")]
    public RespuestaEntidad MonedasEliminar(MonedasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MonedasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE MONEDAS")]
    public List<MonedasEntidad> MonedasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<MonedasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MonedasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE MONEDAS")]
    public int MonedasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MonedasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region NIVELES SOCIOECONÓMICOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE NIVELES SOCIOECONÓMICOS")]
    public RespuestaEntidad NivelesSocioeconomicosEliminar(NivelesSocioeconomicosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NivelesSocioeconomicosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE NIVELES SOCIOECONÓMICOS")]
    public List<NivelesSocioeconomicosEntidad> NivelesSocioeconomicosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<NivelesSocioeconomicosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.NivelesSocioeconomicosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE NIVELES SOCIOECONÓMICOS")]
    public int NivelesSocioeconomicosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.NivelesSocioeconomicosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region NIVELES TERRENOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE NIVELES TERRENOS")]
    public RespuestaEntidad NivelesTerrenosEliminar(NivelesTerrenoEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NivelesTerrenosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE NIVELES TERRENOS")]
    public List<NivelesTerrenoEntidad> NivelesTerrenosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<NivelesTerrenoEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.NivelesTerrenosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE NIVELES TERRENOS")]
    public int NivelesTerrenosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.NivelesTerrenosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region NOTARIOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE NOTARIOS")]
    public RespuestaEntidad NotariosEliminar(NotariosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NotariosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE NOTARIOS")]
    public List<NotariosEntidad> NotariosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<NotariosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.NotariosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE NOTARIOS")]
    public int NotariosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.NotariosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS POR IDENTIFICACION DE NOTARIOS")]
    public List<NotariosEntidad> NotariosConsultarIdentificacion(NotariosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        List<NotariosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);

            #endregion

            consulta = mantenimientosNegocio.Instancia.NotariosConsultarIdentificacion(conexion, _entidad);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region NÚMEROS LÍNEAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE NÚMEROS LÍNEAS")]
    public RespuestaEntidad NumerosLineasEliminar(NumerosLineasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NumerosLineasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE NÚMEROS LÍNEAS")]
    public List<NumerosLineasEntidad> NumerosLineasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<NumerosLineasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.NumerosLineasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE NÚMEROS LÍNEAS")]
    public int NumerosLineasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.NumerosLineasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ORIENTACIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ORIENTACIONES")]
    public RespuestaEntidad OrientacionesEliminar(OrientacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.OrientacionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ORIENTACIONES")]
    public List<OrientacionesEntidad> OrientacionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<OrientacionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.OrientacionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ORIENTACIONES")]
    public int OrientacionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.OrientacionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region PENDIENTES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE PENDIENTES")]
    public RespuestaEntidad PendientesEliminar(PendientesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PendientesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE PENDIENTES")]
    public List<PendientesEntidad> PendientesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<PendientesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PendientesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE PENDIENTES")]
    public int PendientesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PendientesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region PINTURAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE PINTURAS")]
    public RespuestaEntidad PinturasEliminar(PinturasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PinturasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE PINTURAS")]
    public List<PinturasEntidad> PinturasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<PinturasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PinturasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE PINTURAS")]
    public int PinturasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PinturasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region PLANES INVERSIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE PLANES INVERSIONES")]
    public RespuestaEntidad PlanesInversionesEliminar(PlanesInversionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PlanesInversionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE PLANES INVERSIONES")]
    public List<PlanesInversionesEntidad> PlanesInversionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<PlanesInversionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PlanesInversionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE PLANES INVERSIONES")]
    public int PlanesInversionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PlanesInversionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region PLAZOS CALIFICACIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE PLAZOS CALIFICACIONES")]
    public RespuestaEntidad PlazosCalificacionesEliminar(PlazosCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PlazosCalificacionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE PLAZOS CALIFICACIONES")]
    public List<PlazosCalificacionesEntidad> PlazosCalificacionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<PlazosCalificacionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PlazosCalificacionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE PLAZOS CALIFICACIONES")]
    public int PlazosCalificacionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PlazosCalificacionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region PROVINCIAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE PROVINCIAS")]
    public RespuestaEntidad ProvinciasEliminar(ProvinciasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ProvinciasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE PROVINCIAS")]
    public List<ProvinciasEntidad> ProvinciasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<ProvinciasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ProvinciasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE PROVINCIAS")]
    public int ProvinciasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ProvinciasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region PUNTOS REFERENCIAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE PUNTOS REFERENCIAS")]
    public RespuestaEntidad PuntosReferenciasEliminar(PuntosReferenciasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PuntosReferenciasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE PUNTOS REFERENCIAS")]
    public List<PuntosReferenciasEntidad> PuntosReferenciasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<PuntosReferenciasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PuntosReferenciasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE PUNTOS REFERENCIAS")]
    public int PuntosReferenciasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PuntosReferenciasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region REGÍMENES FISCALIZACIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE REGÍMENES FISCALIZACIONES")]
    public RespuestaEntidad RegimenesFiscalizacionesEliminar(RegimenesFiscalizacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.RegimenesFiscalizacionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE REGÍMENES FISCALIZACIONES")]
    public List<RegimenesFiscalizacionesEntidad> RegimenesFiscalizacionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<RegimenesFiscalizacionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.RegimenesFiscalizacionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE REGÍMENES FISCALIZACIONES")]
    public int RegimenesFiscalizacionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.RegimenesFiscalizacionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region REPORTES ROLES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE REPORTES ROLES")]
    public RespuestaEntidad ReportesRolesEliminar(ReportesRolesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ReportesRolesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE REPORTES ROLES")]
    public List<ReportesRolesEntidad> ReportesRolesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<ReportesRolesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ReportesRolesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE REPORTES ROLES")]
    public int ReportesRolesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ReportesRolesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region REPORTES SEGUI

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE REPORTES SEGUI")]
    public RespuestaEntidad ReportesSEGUIEliminar(ReportesSeguiEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ReportesSeguiEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE REPORTES SEGUI")]
    public List<ReportesSeguiEntidad> ReportesSEGUIConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<ReportesSeguiEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ReportesSeguiConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE REPORTES SEGUI")]
    public int ReportesSEGUITotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ReportesSeguiTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region SECCIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE SECCIONES")]
    public RespuestaEntidad SeccionesEliminar(SeccionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SeccionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE SECCIONES")]
    public List<SeccionesEntidad> SeccionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<SeccionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.SeccionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE SECCIONES")]
    public int SeccionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.SeccionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region SISTEMAS CONSTRUCTIVOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE SISTEMAS CONSTRUCTIVOS")]
    public RespuestaEntidad SistemasConstructivosEliminar(SistemasConstructivosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SistemasConstructivosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE SISTEMAS CONSTRUCTIVOS")]
    public List<SistemasConstructivosEntidad> SistemasConstructivosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<SistemasConstructivosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.SistemasConstructivosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE SISTEMAS CONSTRUCTIVOS")]
    public int SistemasConstructivosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.SistemasConstructivosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region SITUACIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE SITUACIONES")]
    public RespuestaEntidad SituacionesEliminar(SituacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SituacionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE SITUACIONES")]
    public List<SituacionesEntidad> SituacionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<SituacionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.SituacionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE SITUACIONES")]
    public int SituacionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.SituacionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region SOLICITANTES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE SOLICITANTES")]
    public RespuestaEntidad SolicitantesEliminar(SolicitantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SolicitantesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE SOLICITANTES")]
    public List<SolicitantesEntidad> SolicitantesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<SolicitantesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.SolicitantesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE SOLICITANTES")]
    public int SolicitantesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.SolicitantesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region TASADORES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TASADORES")]
    public RespuestaEntidad TasadoresEliminar(TasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TasadoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TASADORES")]
    public List<TasadoresEntidad> TasadoresConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TasadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TasadoresConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TASADORES")]
    public int TasadoresTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TasadoresTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TASADORES INTERNOS")]
    public List<TasadoresEntidad> TasadoresConsultarInterno(ParametrosConsultaEntidad _entidad)
    {
        List<TasadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TasadoresConsultarInterno(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TASADORES")]
    public int TasadoresTotalFilasInterno(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TasadoresTotalFilasInterno(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TENENCIAS PRT15

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TENENCIAS PRT15")]
    public RespuestaEntidad TenenciasPRT15Eliminar(TenenciasPrt15Entidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TenenciasPRT15Eliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TENENCIAS PRT15")]
    public List<TenenciasPrt15Entidad> TenenciasPRT15Consultar(ParametrosConsultaEntidad _entidad)
    {
        List<TenenciasPrt15Entidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TenenciasPRT15Consultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TENENCIAS PRT15")]
    public int TenenciasPRT15TotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TenenciasPRT15TotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TENENCIAS PRT17

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TENENCIAS PRT17")]
    public RespuestaEntidad TenenciasPRT17Eliminar(TenenciasPrt17Entidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TenenciasPRT17Eliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TENENCIAS PRT17")]
    public List<TenenciasPrt17Entidad> TenenciasPRT17Consultar(ParametrosConsultaEntidad _entidad)
    {
        List<TenenciasPrt17Entidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TenenciasPRT17Consultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TENENCIAS PRT17")]
    public int TenenciasPRT17TotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TenenciasPRT17TotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS ADJUDICACIONES BIENES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS ADJUDICACIONES BIENES")]
    public RespuestaEntidad TiposAdjudicacionesBienesEliminar(TiposAdjudicacionesBienesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposAdjudicacionesBienesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS ADJUDICACIONES BIENES")]
    public List<TiposAdjudicacionesBienesEntidad> TiposAdjudicacionesBienesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposAdjudicacionesBienesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposAdjudicacionesBienesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS ADJUDICACIONES BIENES")]
    public int TiposAdjudicacionesBienesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposAdjudicacionesBienesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS ASIGNACIONES CALIFICACIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS ASIGNACIONES CALIFICACIONES")]
    public RespuestaEntidad TiposAsignacionesCalificacionesEliminar(TiposAsignacionesCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposAsignacionesCalificacionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS ASIGNACIONES CALIFICACIONES")]
    public List<TiposAsignacionesCalificacionesEntidad> TiposAsignacionesCalificacionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposAsignacionesCalificacionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposAsignacionesCalificacionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS ASIGNACIONES CALIFICACIONES")]
    public int TiposAsignacionesCalificacionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposAsignacionesCalificacionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
       #region TIPOS AVALES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS AVALES")]
    public RespuestaEntidad TipoAvalEliminar(TiposAvalesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TipoAvalEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS AVALES")]
    public List<TiposAvalesEntidad> TipoAvalConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposAvalesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TipoAvalConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS AVALES")]
    public int TipoAvalTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TipoAvalTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion
    
    #region TIPOS AVALES FIANZAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS AVALES FIANZAS")]
    public RespuestaEntidad TiposAvalesFianzasEliminar(TiposAvalesFianzasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposAvalesFianzasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS AVALES FIANZAS")]
    public List<TiposAvalesFianzasEntidad> TiposAvalesFianzasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposAvalesFianzasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposAvalesFianzasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS AVALES FIANZAS")]
    public int TiposAvalesFianzasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposAvalesFianzasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS BIENES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS BIENES")]
    public RespuestaEntidad TiposBienesEliminar(TiposBienesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposBienesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS BIENES")]
    public List<TiposBienesEntidad> TiposBienesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposBienesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposBienesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS BIENES")]
    public int TiposBienesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposBienesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS CARTERAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS CARTERAS")]
    public RespuestaEntidad TiposCarterasEliminar(TiposCarterasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposCarterasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS CARTERAS")]
    public List<TiposCarterasEntidad> TiposCarterasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposCarterasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposCarterasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS CARTERAS")]
    public int TiposCarterasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposCarterasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS CASOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS CASOS")]
    public RespuestaEntidad TiposCasosEliminar(TiposCasosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposCasosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS CASOS")]
    public List<TiposCasosEntidad> TiposCasosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposCasosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposCasosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS CASOS")]
    public int TiposCasosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposCasosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS CAPACIDADES PAGOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS CAPACIDADES PAGOS")]
    public RespuestaEntidad TiposCapacidadesPagosEliminar(TiposCapacidadesPagosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposCapacidadesPagosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS CAPACIDADES PAGOS")]
    public List<TiposCapacidadesPagosEntidad> TiposCapacidadesPagosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposCapacidadesPagosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposCapacidadesPagosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS CAPACIDADES PAGOS")]
    public int TiposCapacidadesPagosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposCapacidadesPagosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS CLASIFICACIONES INSTRUMENTOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS CLASIFICACIONES INSTRUMENTOS")]
    public RespuestaEntidad TiposClasificacionesInstrumentosEliminar(TiposClasificacionesInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposClasificacionesInstrumentosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS CLASIFICACIONES INSTRUMENTOS")]
    public List<TiposClasificacionesInstrumentosEntidad> TiposClasificacionesInstrumentosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposClasificacionesInstrumentosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposClasificacionesInstrumentosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS CLASIFICACIONES INSTRUMENTOS")]
    public int TiposClasificacionesInstrumentosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposClasificacionesInstrumentosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS COMPORTAMIENTOS PAGOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS COMPORTAMIENTOS PAGOS")]
    public RespuestaEntidad TiposComportamientosPagosEliminar(TiposComportamientosPagosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposComportamientosPagosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS COMPORTAMIENTOS PAGOS")]
    public List<TiposComportamientosPagosEntidad> TiposComportamientosPagosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposComportamientosPagosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposComportamientosPagosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS COMPORTAMIENTOS PAGOS")]
    public int TiposComportamientosPagosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposComportamientosPagosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS CONSTRUCCIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS CONSTRUCCIONES")]
    public RespuestaEntidad TiposConstruccionesEliminar(TiposConstruccionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposConstruccionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS CONSTRUCCIONES")]
    public List<TiposConstruccionesEntidad> TiposConstruccionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposConstruccionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposConstruccionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS CONSTRUCCIONES")]
    public int TiposConstruccionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposConstruccionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS DOCUMENTOS LEGALES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS DOCUMENTOS LEGALES")]
    public RespuestaEntidad TiposDocumentosLegalesEliminar(TiposDocumentosLegalesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposDocumentosLegalesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS DOCUMENTOS LEGALES")]
    public List<TiposDocumentosLegalesEntidad> TiposDocumentosLegalesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposDocumentosLegalesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposDocumentosLegalesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS DOCUMENTOS LEGALES")]
    public int TiposDocumentosLegalesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposDocumentosLegalesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS ENTIDADES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS ENTIDADES")]
    public RespuestaEntidad TiposEntidadesEliminar(TiposEntidadesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposEntidadesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS ENTIDADES")]
    public List<TiposEntidadesEntidad> TiposEntidadesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposEntidadesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposEntidadesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS ENTIDADES")]
    public int TiposEntidadesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposEntidadesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS EMISORES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS EMISORES")]
    public RespuestaEntidad TiposEmisoresEliminar(TiposEmisoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposEmisoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS EMISORES")]
    public List<TiposEmisoresEntidad> TiposEmisoresConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposEmisoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposEmisoresConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS EMISORES")]
    public int TiposEmisoresTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposEmisoresTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS ESTADOS AVALÚOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS ESTADOS AVALÚOS")]
    public RespuestaEntidad TiposEstadosAvaluosEliminar(TiposEstadosAvaluosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposEstadosAvaluosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS ESTADOS AVALÚOS")]
    public List<TiposEstadosAvaluosEntidad> TiposEstadosAvaluosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposEstadosAvaluosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposEstadosAvaluosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS ESTADOS AVALÚOS")]
    public int TiposEstadosAvaluosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposEstadosAvaluosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS GARANTIAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS GARANTIAS")]
    public RespuestaEntidad TiposGarantiasEliminar(TiposGarantiasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposGarantiasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS GARANTIAS")]
    public List<TiposGarantiasEntidad> TiposGarantiasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposGarantiasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposGarantiasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS GARANTIAS")]
    public int TiposGarantiasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposGarantiasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS GRADOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS GRADOS")]
    public RespuestaEntidad TiposGradosEliminar(TiposGradosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposGradosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS GRADOS")]
    public List<TiposGradosEntidad> TiposGradosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposGradosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposGradosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS GRADOS")]
    public int TiposGradosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposGradosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS GRUPOS FINANCIEROS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS GRUPOS FINANCIEROS")]
    public RespuestaEntidad TiposGruposFinancierosEliminar(TiposGruposFinancierosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposGruposFinancierosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS GRUPOS FINANCIEROS")]
    public List<TiposGruposFinancierosEntidad> TiposGruposFinancierosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposGruposFinancierosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposGruposFinancierosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS GRUPOS FINANCIEROS")]
    public int TiposGruposFinancierosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposGruposFinancierosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS INDICADORES INSCRIPCIONES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS INDICADORES INSCRIPCIONES")]
    public RespuestaEntidad TiposIndicadoresInscripcionesEliminar(TiposIndicadoresInscripcionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposIndicadoresInscripcionesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS INDICADORES INSCRIPCIONES")]
    public List<TiposIndicadoresInscripcionesEntidad> TiposIndicadoresInscripcionesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposIndicadoresInscripcionesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposIndicadoresInscripcionesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS INDICADORES INSCRIPCIONES")]
    public int TiposIndicadoresInscripcionesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposIndicadoresInscripcionesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region TIPOS IDENTIFICACIONES RUC

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS IDENTIFICACIONES RUC")]
    public RespuestaEntidad TiposIdentificacionesRUCEliminar(TiposIdentificacionesRUCEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposIdentificacionesRUCEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS IDENTIFICACIONES RUC")]
    public List<TiposIdentificacionesRUCEntidad> TiposIdentificacionesRUCConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposIdentificacionesRUCEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposIdentificacionesRUCConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS IDENTIFICACIONES RUC")]
    public int TiposIdentificacionesRUCTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposIdentificacionesRUCTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS INGRESOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS INGRESOS")]
    public RespuestaEntidad TiposIngresosEliminar(TiposIngresosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposIngresosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS INGRESOS")]
    public List<TiposIngresosEntidad> TiposIngresosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposIngresosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposIngresosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS INGRESOS")]
    public int TiposIngresosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposIngresosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS INMUEBLES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS INMUEBLES")]
    public RespuestaEntidad TiposInmueblesEliminar(TiposInmueblesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposInmueblesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS INMUEBLES")]
    public List<TiposInmueblesEntidad> TiposInmueblesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposInmueblesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposInmueblesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS INMUEBLES")]
    public int TiposInmueblesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposInmueblesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS INSTRUMENTOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS INSTRUMENTOS")]
    public RespuestaEntidad TiposInstrumentosEliminar(TiposInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposInstrumentosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS INSTRUMENTOS")]
    public List<TiposInstrumentosEntidad> TiposInstrumentosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposInstrumentosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposInstrumentosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS INSTRUMENTOS")]
    public int TiposInstrumentosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposInstrumentosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS LIQUIDEZ

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS LIQUIDEZ")]
    public RespuestaEntidad TiposLiquidezEliminar(TiposLiquidezEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposLiquidezEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS LIQUIDEZ")]
    public List<TiposLiquidezEntidad> TiposLiquidezConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposLiquidezEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposLiquidezConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS LIQUIDEZ")]
    public int TiposLiquidezTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposLiquidezTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS MITIGADORES RIESGOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS MITIGADORES RIESGOS")]
    public RespuestaEntidad TiposMitigadoresRiesgosEliminar(TiposMitigadoresRiesgosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposMitigadoresRiesgosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS MITIGADORES RIESGOS")]
    public List<TiposMitigadoresRiesgosEntidad> TiposMitigadoresRiesgosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposMitigadoresRiesgosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposMitigadoresRiesgosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS MITIGADORES RIESGOS")]
    public int TiposMitigadoresRiesgosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposMitigadoresRiesgosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS MONEDAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS MONEDAS")]
    public RespuestaEntidad TiposMonedasEliminar(TiposMonedasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposMonedasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS MONEDAS")]
    public List<TiposMonedasEntidad> TiposMonedasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposMonedasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposMonedasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS MONEDAS")]
    public int TiposMonedasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposMonedasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS PERSONAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS PERSONAS")]
    public RespuestaEntidad TiposPersonasEliminar(TiposPersonasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposPersonasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS PERSONAS")]
    public List<TiposPersonasEntidad> TiposPersonasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposPersonasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposPersonasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS PERSONAS")]
    public int TiposPersonasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposPersonasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS PÓLIZAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS PÓLIZAS")]
    public RespuestaEntidad TiposPolizasEliminar(TiposPolizasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposPolizasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS PÓLIZAS")]
    public List<TiposPolizasEntidad> TiposPolizasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposPolizasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposPolizasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS PÓLIZAS")]
    public int TiposPolizasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposPolizasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region TIPOS SERVICIOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS SERVICIOS")]
    public RespuestaEntidad TiposServiciosEliminar(TiposServiciosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposServiciosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS SERVICIOS")]
    public List<TiposServiciosEntidad> TiposServiciosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposServiciosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposServiciosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS SERVICIOS")]
    public int TiposServiciosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposServiciosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TIPOS ZONAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TIPOS ZONAS")]
    public RespuestaEntidad TiposZonasEliminar(TiposZonasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposZonasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TIPOS ZONAS")]
    public List<TiposZonasEntidad> TiposZonasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TiposZonasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposZonasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TIPOS ZONAS")]
    public int TiposZonasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposZonasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region TOPOGRAFÍAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE TOPOGRAFÍAS")]
    public RespuestaEntidad TopografiasEliminar(TopografiasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TopografiasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE TOPOGRAFÍAS")]
    public List<TopografiasEntidad> TopografiasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<TopografiasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TopografiasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE TOPOGRAFÍAS")]
    public int TopografiasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TopografiasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region UNIDADES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE UNIDADES")]
    public RespuestaEntidad UnidadesEliminar(UnidadesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.UnidadesEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE UNIDADES")]
    public List<UnidadesEntidad> UnidadesConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<UnidadesEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.UnidadesConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE UNIDADES")]
    public int UnidadesTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.UnidadesTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region USOS SUELOS ACTUAL ENTORNOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE USOS SUELOS ACTUAL ENTORNOS")]
    public RespuestaEntidad UsosSuelosActualEntornosEliminar(UsosSuelosActualEntornosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.UsosSuelosActualEntornosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE USOS SUELOS ACTUAL ENTORNOS")]
    public List<UsosSuelosActualEntornosEntidad> UsosSuelosActualEntornosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<UsosSuelosActualEntornosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.UsosSuelosActualEntornosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE USOS SUELOS ACTUAL ENTORNOS")]
    public int UsosSuelosActualEntornosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.UsosSuelosActualEntornosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region VENTANAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE VENTANAS")]
    public RespuestaEntidad VentanasEliminar(VentanasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.VentanasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE VENTANAS")]
    public List<VentanasEntidad> VentanasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<VentanasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.VentanasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE VENTANAS")]
    public int VentanasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.VentanasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region VERJAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE VERJAS")]
    public RespuestaEntidad VerjasEliminar(VerjasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.VerjasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE VERJAS")]
    public List<VerjasEntidad> VerjasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<VerjasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.VerjasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE VERJAS")]
    public int VerjasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.VerjasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region VÍAS ACCESOS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE VÍAS ACCESOS")]
    public RespuestaEntidad ViasAccesosEliminar(ViasAccesoEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ViasAccesosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE VÍAS ACCESOS")]
    public List<ViasAccesoEntidad> ViasAccesosConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<ViasAccesoEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ViasAccesosConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE VÍAS ACCESOS")]
    public int ViasAccesosTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ViasAccesosTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region VOLTAJES INSTALACIONES ELECTRICAS

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE VOLTAJES INSTALACIONES ELECTRICAS")]
    public RespuestaEntidad VoltajesInstalacionesElectricasEliminar(VoltajesInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.VoltajesInstalacionesElectricasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE VOLTAJES INSTALACIONES ELECTRICAS")]
    public List<VoltajesInstalacionesElectricasEntidad> VoltajesInstalacionesElectricasConsultar(ParametrosConsultaEntidad _entidad)
    {
        List<VoltajesInstalacionesElectricasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.VoltajesInstalacionesElectricasConsultar(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE VOLTAJES INSTALACIONES ELECTRICAS")]
    public int VoltajesInstalacionesElectricasTotalFilas(ParametrosTotalFilasEntidad _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.VoltajesInstalacionesElectricasTotalFilas(conexion, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24105296
    #region ZONAS TASADORES

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE ZONAS TASADORES")]
    public RespuestaEntidad ZonasTasadoresEliminar(ZonasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ZonasTasadoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE ZONAS TASADORES")]
    public List<ZonasTasadoresEntidad> ZonasTasadoresConsultar(ParametrosConsultaEntidad _entidad, string _zona)
    {
        List<ZonasTasadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ZonasTasadoresConsultar(conexion, _entidad, _zona);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE ZONAS TASADORES")]
    public int ZonasTasadoresTotalFilas(ParametrosTotalFilasEntidad _entidad, string _zona)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ZonasTasadoresTotalFilas(conexion, _entidad, _zona);

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

    #region METODOS PUBLICOS PROCESOS

    #region PROCESOS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE BITACORA PROCESOS")]
    public List<BitacoraProcesosDetalle> BitacoraProcesosConsultar(BitacoraProcesosConsulta _consulta, ParametrosConsultaEntidad _entidad)
    {
        List<BitacoraProcesosDetalle> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = procesosNegocio.Instancia.BitacoraProcesosConsultar(conexion,_consulta, _entidad);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL TOTAL DE LOS REGISTROS DEL SET DE DATOS DE BITACORA PROCESOS")]
    public int BitacoraProcesosTotalFilas(BitacoraProcesosConsulta _entidad)
    {
        int consulta = 0;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = procesosNegocio.Instancia.BitacoraProcesosTotalFilas(conexion, _entidad);

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