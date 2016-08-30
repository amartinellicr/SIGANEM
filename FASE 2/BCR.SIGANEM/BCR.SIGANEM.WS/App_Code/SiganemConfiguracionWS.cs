using System;
using System.Web;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.EN;
using BCR.SIGANEM.BL;
using BCR.SIGANEM.UT;


[WebService(Namespace = "http://bancobcr.com/", Description = "SERVICIO WEB CONFIGURACION CATALOGOS")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SiganemConfiguracionWS : System.Web.Services.WebService
{

    #region PROPIEDADES

    #region NEGOCIO

    private ReportesNegocio reportesNegocio = new ReportesNegocio();
    private MantenimientosNegocio mantenimientosNegocio = new MantenimientosNegocio();
    private ProcesosNegocio procesosNegocio = new ProcesosNegocio();

    #endregion

    #region UTILIDADES

    private RegistrarEventLog registrarEventLog = new RegistrarEventLog();
    private LectorConfiguracion lectorConfiguracion = new LectorConfiguracion();

    #endregion

    #endregion

    #region CONSTRUCTOR

    public SiganemConfiguracionWS()
    {

    }

    #endregion

    #region METODOS PUBLICOS CONFIGURACION CATALOGOS

    #region ACTIVOS

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ACTIVOS")]
    public RespuestaEntidad ActivosInsertar(ActivosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ActivosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ACTIVOS")]
    public RespuestaEntidad ActivosModificar(ActivosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ActivosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ACTIVOS")]
    public ActivosEntidad ActivosConsultarDetalle(ActivosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ActivosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ActivosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE APLICABLES")]
    public RespuestaEntidad AplicablesInsertar(AplicablesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.AplicablesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE APLICABLES")]
    public RespuestaEntidad AplicablesModificar(AplicablesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.AplicablesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE APLICABLES")]
    public AplicablesEntidad AplicablesConsultarDetalle(AplicablesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        AplicablesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.AplicablesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE BIENES VALORAR")]
    public RespuestaEntidad BienesValorarInsertar(BienesValorarEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.BienesValorarInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE BIENES VALORAR")]
    public RespuestaEntidad BienesValorarModificar(BienesValorarEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.BienesValorarModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE BIENES VALORAR")]
    public BienesValorarEntidad BienesValorarConsultarDetalle(BienesValorarEntidad _entidad, BitacorasEntidad _bitacora)
    {
        BienesValorarEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.BienesValorarConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CAJAS BREAKERS")]
    public RespuestaEntidad CajasBreakersInsertar(CajasBreakersEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CajasBreakersInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CAJAS BREAKERS")]
    public RespuestaEntidad CajasBreakersModificar(CajasBreakersEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CajasBreakersModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CAJAS BREAKERS")]
    public CajasBreakersEntidad CajasBreakersConsultarDetalle(CajasBreakersEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CajasBreakersEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CajasBreakersConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CALIFICACIONES EMPRESAS CALIFICADORAS")]
    public RespuestaEntidad CalificacionesEmpresasCalificadorasInsertar(CalificacionesEmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CALIFICACIONES EMPRESAS CALIFICADORAS CON FUENTE DATATABLE")]
    public RespuestaEntidad CalificacionesEmpresasCalificadorasInsertarDataTable(DataTable dt, CalificacionesEmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //ID = -1 NUEVO REGISTRO && IND_VISIBLE = 1 VISIBLE
                if (dt.Rows[i][0].ToString().Equals("-1") && dt.Rows[i][dt.Columns.Count - 1].ToString().Equals("1"))
                {
                    _entidad.Calificacion = dt.Rows[i][3].ToString();
                    _entidad.idCategoriaRiesgoEmpresaCalificadora = int.Parse(dt.Rows[i][1].ToString());
                    consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
                }
            }


            //consulta = _mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CALIFICACIONES EMPRESAS CALIFICADORAS")]
    public RespuestaEntidad CalificacionesEmpresasCalificadorasModificar(CalificacionesEmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CALIFICACIONES EMPRESAS CALIFICADORAS")]
    public RespuestaEntidad CalificacionesEmpresasCalificadorasModificarDataTable(DataTable dt, CalificacionesEmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //ID = -1 NUEVO REGISTRO && IND_VISIBLE = 1 VISIBLE
                if (dt.Rows[i][0].ToString().Equals("-1") && dt.Rows[i][dt.Columns.Count - 1].ToString().Equals("1"))
                {
                    _entidad.Calificacion = dt.Rows[i][3].ToString();
                    _entidad.idCategoriaRiesgoEmpresaCalificadora = int.Parse(dt.Rows[i][1].ToString());
                    consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
                }

                //ID != -1 REGISTRO ANTIGUO && IND_VISIBLE = 0 NO VISIBLE
                if ((!dt.Rows[i][0].ToString().Equals("-1")) && (dt.Rows[i][dt.Columns.Count - 1].ToString().Equals("0")))
                {
                    _entidad.IdCalificacionEmpresaCalificadora = int.Parse(dt.Rows[i][0].ToString());
                    consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
                }
            }

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CALIFICACIONES EMPRESAS CALIFICADORAS GRID")]
    public List<CalificacionesEmpresasCalificadorasEntidad> CalificacionesEmpresasCalificadorasConsultarGrid(String parametro)
    {
        List<CalificacionesEmpresasCalificadorasEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasConsultarGrid(conexion, parametro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

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

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CALIFICACIONES EMPRESAS CALIFICADORAS")]
    public RespuestaEntidad CalificacionesEmpresasCalificadorasEliminar(CalificacionesEmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasEliminar(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CANALIZACIONES ELÉCTRICAS")]
    public RespuestaEntidad CanalizacionesElectricasInsertar(CanalizacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CanalizacionesElectricasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CANALIZACIONES ELÉCTRICAS")]
    public RespuestaEntidad CanalizacionesElectricasModificar(CanalizacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CanalizacionesElectricasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CANALIZACIONES ELÉCTRICAS")]
    public CanalizacionesElectricasEntidad CanalizacionesElectricasConsultarDetalle(CanalizacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CanalizacionesElectricasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CanalizacionesElectricasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CANOAS BAJANTES")]
    public RespuestaEntidad CanoasBajantesInsertar(CanoasBajantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CanoasBajantesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CANOAS BAJANTES")]
    public RespuestaEntidad CanoasBajantesModificar(CanoasBajantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CanoasBajantesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CANOAS BAJANTES")]
    public CanoasBajantesEntidad CanoasBajantesConsultarDetalle(CanoasBajantesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CanoasBajantesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CanoasBajantesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CANTIDADES FINCAS")]
    public RespuestaEntidad CantidadesFincasInsertar(CantidadesFincasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CantidadesFincasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CANTIDADES FINCAS")]
    public RespuestaEntidad CantidadesFincasModificar(CantidadesFincasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CantidadesFincasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CANTIDADES FINCAS")]
    public CantidadesFincasEntidad CantidadesFincasConsultarDetalle(CantidadesFincasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CantidadesFincasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CantidadesFincasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CANTONES")]
    public RespuestaEntidad CantonesInsertar(CantonesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CantonesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CANTONES")]
    public RespuestaEntidad CantonesModificar(CantonesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CantonesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CANTONES")]
    public CantonesEntidad CantonesConsultarDetalle(CantonesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CantonesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CantonesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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
    #region CARACTERISTICAS TASADORES

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CARACTERISTICAS TASADORES EXTERNO")]
    public RespuestaEntidad CaracteristicasTasadoresInsertar(CaracteristicasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CaracteristicasTasadoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CARACTERISTICAS TASADORES CON FUENTE DATATABLE EXTERNO")]
    public RespuestaEntidad CaracteristicasTasadoresInsertarDataTable(DataTable dt, CaracteristicasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //ID = -1 NUEVO REGISTRO && IND_VISIBLE = 1 VISIBLE
                if (dt.Rows[i][0].ToString().Equals("-1") && dt.Rows[i][dt.Columns.Count - 1].ToString().Equals("1"))
                {
                    _entidad.CodEmpresaTasadora = dt.Rows[i][1].ToString();
                    _entidad.DesEmpresaTasadora = dt.Rows[i][2].ToString();
                    _entidad.IdTipoServicio = int.Parse(dt.Rows[i][3].ToString());
                    _entidad.IdTipoPersona = int.Parse(dt.Rows[i][5].ToString());
                    _entidad.IdZonaTasador = int.Parse(dt.Rows[i][6].ToString());
                    consulta = mantenimientosNegocio.Instancia.CaracteristicasTasadoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
                }
            }

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CARACTERISTICAS TASADORES INTERNO")]
    public RespuestaEntidad CaracteristicasTasadoresInsertarInterno(CaracteristicasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            _entidad.CodEmpresaTasadora = string.Empty;
            _entidad.DesEmpresaTasadora = string.Empty;
            consulta = mantenimientosNegocio.Instancia.CaracteristicasTasadoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CARACTERISTICAS TASADORES EXTERNO")]
    public RespuestaEntidad CaracteristicasTasadoresModificarDataTable(DataTable dt, CaracteristicasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //ID = -1 NUEVO REGISTRO && IND_VISIBLE = 1 VISIBLE
                if (dt.Rows[i][0].ToString().Equals("-1") && dt.Rows[i][dt.Columns.Count - 1].ToString().Equals("1"))
                {
                    _entidad.CodEmpresaTasadora = dt.Rows[i][1].ToString();
                    _entidad.DesEmpresaTasadora = dt.Rows[i][2].ToString();
                    _entidad.IdTipoServicio = int.Parse(dt.Rows[i][3].ToString());
                    _entidad.IdTipoPersona = int.Parse(dt.Rows[i][5].ToString());
                    _entidad.IdZonaTasador = int.Parse(dt.Rows[i][6].ToString());
                    consulta = mantenimientosNegocio.Instancia.CaracteristicasTasadoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
                }

                //ID != -1 REGISTRO ANTIGUO && IND_VISIBLE = 0 NO VISIBLE
                if ((!dt.Rows[i][0].ToString().Equals("-1")) && (dt.Rows[i][dt.Columns.Count - 1].ToString().Equals("0")))
                {
                    _entidad.IdCaracteristicaTasador = int.Parse(dt.Rows[i][0].ToString());
                    consulta = mantenimientosNegocio.Instancia.CaracteristicasTasadoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
                }
            }

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CARACTERISTICAS TASADORES INTERNO")]
    public RespuestaEntidad CaracteristicasTasadoresModificarDataTableInterno(DataTable dt, CaracteristicasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //ID = -1 NUEVO REGISTRO && IND_VISIBLE = 1 VISIBLE
                if (dt.Rows[i][0].ToString().Equals("-1") && dt.Rows[i][dt.Columns.Count - 1].ToString().Equals("1"))
                {
                    _entidad.CodEmpresaTasadora = string.Empty;
                    _entidad.DesEmpresaTasadora = string.Empty;
                    _entidad.IdTipoServicio = int.Parse(dt.Rows[i][1].ToString());
                    _entidad.IdTipoPersona = int.Parse(dt.Rows[i][3].ToString());
                    _entidad.IdZonaTasador = int.Parse(dt.Rows[i][4].ToString());
                    consulta = mantenimientosNegocio.Instancia.CaracteristicasTasadoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
                }

                //ID != -1 REGISTRO ANTIGUO && IND_VISIBLE = 0 NO VISIBLE
                if ((!dt.Rows[i][0].ToString().Equals("-1")) && (dt.Rows[i][dt.Columns.Count - 1].ToString().Equals("0")))
                {
                    _entidad.IdCaracteristicaTasador = int.Parse(dt.Rows[i][0].ToString());
                    consulta = mantenimientosNegocio.Instancia.CaracteristicasTasadoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
                }
            }

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CARACTERISTICAS TASADORES GRID")]
    public List<CaracteristicasTasadoresEntidad> CaracteristicasTasadoresConsultarGrid(String parametro)
    {
        List<CaracteristicasTasadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CaracteristicasTasadoresConsultarGrid(conexion, parametro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CARACTERISTICAS TASADORES GRID INTERNO")]
    public List<CaracteristicasTasadoresEntidad> CaracteristicasTasadoresConsultarGridInterno(String parametro)
    {
        List<CaracteristicasTasadoresEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CaracteristicasTasadoresConsultarGridInterno(conexion, parametro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CARACTERISTICAS TASADORES")]
    public RespuestaEntidad CaracteristicasTasadoresEliminar(CaracteristicasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CaracteristicasTasadoresEliminar(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CATEGORÍAS CALIFICACIONES")]
    public RespuestaEntidad CategoriasCalificacionesInsertar(CategoriasCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CATEGORÍAS CALIFICACIONES")]
    public RespuestaEntidad CategoriasCalificacionesModificar(CategoriasCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CATEGORÍAS CALIFICACIONES")]
    public CategoriasCalificacionesEntidad CategoriasCalificacionesConsultarDetalle(CategoriasCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CategoriasCalificacionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO 1-24653624
    #region CATEGORIAS CALIFICACIONES TIPOS MITIGADORES RIESGOS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS COMPLETO DE CATEGORIAS CALIFICACIONES TIPOS MITIGADORES RIESGOS")]
    public List<CategoriasCalificacionesTiposMitigadoresRiesgosEntidad> CategoriasCalificacionesTiposMitigadoresRiesgosConsultarGrid(string _filtro)
    {
        List<CategoriasCalificacionesTiposMitigadoresRiesgosEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesTiposMitigadoresRiesgosConsultarGrid(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ELIMINA UN REGISTRO DE CATEGORIAS CALIFICACIONES TIPOS MITIGADORES RIESGOS")]
    public RespuestaEntidad CategoriasCalificacionesTiposMitigadoresRiesgosEliminar(CategoriasCalificacionesTiposMitigadoresRiesgosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesTiposMitigadoresRiesgosEliminar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CATEGORIAS CALIFICACIONES TIPOS MITIGADORES RIESGOS")]
    public RespuestaEntidad CategoriasCalificacionesTiposMitigadoresRiesgosInsertar(CategoriasCalificacionesTiposMitigadoresRiesgosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesTiposMitigadoresRiesgosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CATEGORIAS CALIFICACIONES TIPOS MITIGADORES RIESGOS")]
    public CategoriasCalificacionesTiposMitigadoresRiesgosEntidad CategoriasCalificacionesTiposMitigadoresRiesgosConsultarDetalle(CategoriasCalificacionesTiposMitigadoresRiesgosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CategoriasCalificacionesTiposMitigadoresRiesgosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesTiposMitigadoresRiesgosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CATEGORÍAS RIESGOS DEUDORES")]
    public RespuestaEntidad CategoriasRiesgosDeudoresInsertar(CategoriasRiesgosDeudoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosDeudoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CATEGORÍAS RIESGOS DEUDORES")]
    public RespuestaEntidad CategoriasRiesgosDeudoresModificar(CategoriasRiesgosDeudoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosDeudoresModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CATEGORÍAS RIESGOS DEUDORES")]
    public CategoriasRiesgosDeudoresEntidad CategoriasRiesgosDeudoresConsultarDetalle(CategoriasRiesgosDeudoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CategoriasRiesgosDeudoresEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosDeudoresConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CATEGORIAS RIESGOS EMPRESAS CALIFICADORAS")]
    public RespuestaEntidad CategoriasRiesgosEmpresasCalificadorasInsertar(CategoriasRiesgosEmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosEmpresasCalificadorasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CATEGORIAS RIESGOS EMPRESAS CALIFICADORAS")]
    public RespuestaEntidad CategoriasRiesgosEmpresasCalificadorasModificar(CategoriasRiesgosEmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosEmpresasCalificadorasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CATEGORIAS RIESGOS EMPRESAS CALIFICADORAS")]
    public CategoriasRiesgosEmpresasCalificadorasEntidad CategoriasRiesgosEmpresasCalificadorasConsultarDetalle(CategoriasRiesgosEmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CategoriasRiesgosEmpresasCalificadorasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosEmpresasCalificadorasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CERRAJERÍAS PIEZAS SANITARIAS")]
    public RespuestaEntidad CerrajeriasPiezasSanitariasInsertar(CerrajeriasPiezasSanitariasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CerrajeriasPiezasSanitariasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CERRAJERÍAS PIEZAS SANITARIAS")]
    public RespuestaEntidad CerrajeriasPiezasSanitariasModificar(CerrajeriasPiezasSanitariasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CerrajeriasPiezasSanitariasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CERRAJERÍAS PIEZAS SANITARIAS")]
    public CerrajeriasPiezasSanitariasEntidad CerrajeriasPiezasSanitariasConsultarDetalle(CerrajeriasPiezasSanitariasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CerrajeriasPiezasSanitariasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CerrajeriasPiezasSanitariasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CIELOS RASOS")]
    public RespuestaEntidad CielosRasosInsertar(CielosRasosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CielosRasosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CIELOS RASOS")]
    public RespuestaEntidad CielosRasosModificar(CielosRasosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CielosRasosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CIELOS RASOS")]
    public CielosRasosEntidad CielosRasosConsultarDetalle(CielosRasosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CielosRasosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CielosRasosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CLASES AERONAVES")]
    public RespuestaEntidad ClasesAeronavesInsertar(ClasesAeronavesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesAeronavesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CLASES AERONAVES")]
    public RespuestaEntidad ClasesAeronavesModificar(ClasesAeronavesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesAeronavesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CLASES AERONAVES")]
    public ClasesAeronavesEntidad ClasesAeronavesConsultarDetalle(ClasesAeronavesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ClasesAeronavesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ClasesAeronavesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CLASES BUQUES")]
    public RespuestaEntidad ClasesBuquesInsertar(ClasesBuquesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesBuquesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CLASES BUQUES")]
    public RespuestaEntidad ClasesBuquesModificar(ClasesBuquesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesBuquesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CLASES BUQUES")]
    public ClasesBuquesEntidad ClasesBuquesConsultarDetalle(ClasesBuquesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ClasesBuquesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ClasesBuquesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CLASES GARANTÍAS PRT17")]
    public RespuestaEntidad ClasesGarantiasPrt17Insertar(ClasesGarantiasPrt17Entidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesGarantiasPrt17Insertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CLASES GARANTÍAS PRT17")]
    public RespuestaEntidad ClasesGarantiasPrt17Modificar(ClasesGarantiasPrt17Entidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesGarantiasPrt17Modificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CLASES GARANTÍAS PRT17")]
    public ClasesGarantiasPrt17Entidad ClasesGarantiasPrt17ConsultarDetalle(ClasesGarantiasPrt17Entidad _entidad, BitacorasEntidad _bitacora)
    {
        ClasesGarantiasPrt17Entidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ClasesGarantiasPrt17ConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CLASES VEHÍCULOS")]
    public RespuestaEntidad ClasesVehiculosInsertar(ClasesVehiculosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesVehiculosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CLASES VEHÍCULOS")]
    public RespuestaEntidad ClasesVehiculosModificar(ClasesVehiculosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ClasesVehiculosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CLASES VEHÍCULOS")]
    public ClasesVehiculosEntidad ClasesVehiculosConsultarDetalle(ClasesVehiculosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ClasesVehiculosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ClasesVehiculosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CÓDIGOS DUPLICADOS")]
    public RespuestaEntidad CodigosDuplicadosInsertar(CodigosDuplicadosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CodigosDuplicadosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CÓDIGOS DUPLICADOS")]
    public RespuestaEntidad CodigosDuplicadosModificar(CodigosDuplicadosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CodigosDuplicadosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CÓDIGOS DUPLICADOS")]
    public CodigosDuplicadosEntidad CodigosDuplicadosConsultarDetalle(CodigosDuplicadosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CodigosDuplicadosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CodigosDuplicadosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CÓDIGOS HORIZONTALIDAD")]
    public RespuestaEntidad CodigosHorizontalidadInsertar(CodigosHorizontalidadEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CodigosHorizontalidadInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CÓDIGOS HORIZONTALIDAD")]
    public RespuestaEntidad CodigosHorizontalidadModificar(CodigosHorizontalidadEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CodigosHorizontalidadModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CÓDIGOS HORIZONTALIDAD")]
    public CodigosHorizontalidadEntidad CodigosHorizontalidadConsultarDetalle(CodigosHorizontalidadEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CodigosHorizontalidadEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CodigosHorizontalidadConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE COLINDANTES")]
    public RespuestaEntidad ColindantesInsertar(ColindantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ColindantesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE COLINDANTES")]
    public RespuestaEntidad ColindantesModificar(ColindantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ColindantesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE COLINDANTES")]
    public ColindantesEntidad ColindantesConsultarDetalle(ColindantesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ColindantesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ColindantesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE CUBIERTAS TECHOS")]
    public RespuestaEntidad CubiertasTechosInsertar(CubiertasTechosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CubiertasTechosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE CUBIERTAS TECHOS")]
    public RespuestaEntidad CubiertasTechosModificar(CubiertasTechosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.CubiertasTechosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE CUBIERTAS TECHOS")]
    public CubiertasTechosEntidad CubiertasTechosConsultarDetalle(CubiertasTechosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        CubiertasTechosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CubiertasTechosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE DECISIONES")]
    public RespuestaEntidad DecisionesInsertar(DecisionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DecisionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE DECISIONES")]
    public RespuestaEntidad DecisionesModificar(DecisionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DecisionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE DECISIONES")]
    public DecisionesEntidad DecisionesConsultarDetalle(DecisionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        DecisionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.DecisionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE DELIMITACIONES LINDEROS")]
    public RespuestaEntidad DelimitacionesLinderosInsertar(DelimitacionesLinderosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DelimitacionesLinderosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE DELIMITACIONES LINDEROS")]
    public RespuestaEntidad DelimitacionesLinderosModificar(DelimitacionesLinderosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DelimitacionesLinderosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE DELIMITACIONES LINDEROS")]
    public DelimitacionesLinderosEntidad DelimitacionesLinderosConsultarDetalle(DelimitacionesLinderosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        DelimitacionesLinderosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.DelimitacionesLinderosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE DERECHOS")]
    public RespuestaEntidad DerechosInsertar(DerechosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DerechosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE DERECHOS")]
    public RespuestaEntidad DerechosModificar(DerechosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DerechosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE DERECHOS")]
    public DerechosEntidad DerechosConsultarDetalle(DerechosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        DerechosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.DerechosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE DISTRIBUCIONES ZONAS TASADORES")]
    public RespuestaEntidad DistribucionZonasTasadoresInsertar(DistribucionesZonasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DistribucionZonasTasadoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE DISTRIBUCIONES ZONAS TASADORES")]
    public RespuestaEntidad DistribucionZonasTasadoresModificar(DistribucionesZonasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DistribucionZonasTasadoresModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE DISTRIBUCIONES ZONAS TASADORES")]
    public DistribucionesZonasTasadoresEntidad DistribucionZonasTasadoresConsultarDetalle(DistribucionesZonasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        DistribucionesZonasTasadoresEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.DistribucionZonasTasadoresConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE DISTRITOS")]
    public RespuestaEntidad DistritosInsertar(DistritosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DistritosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE DISTRITOS")]
    public RespuestaEntidad DistritosModificar(DistritosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.DistritosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE DISTRITOS")]
    public DistritosEntidad DistritosConsultarDetalle(DistritosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        DistritosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.DistritosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE EMISIONES INSTRUMENTOS")]
    public RespuestaEntidad EmisionesInstrumentosInsertar(EmisionesInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE EMISIONES INSTRUMENTOS")]
    public RespuestaEntidad EmisionesInstrumentosModificar(EmisionesInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE EMISIONES INSTRUMENTOS")]
    public EmisionesInstrumentosEntidad EmisionesInstrumentosConsultarDetalle(EmisionesInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EmisionesInstrumentosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE EMISORES")]
    public RespuestaEntidad EmisoresInsertar(EmisoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmisoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE EMISORES")]
    public RespuestaEntidad EmisoresModificar(EmisoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmisoresModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE EMISORES")]
    public EmisoresEntidad EmisoresConsultarDetalle(EmisoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EmisoresEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EmisoresConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE EMPRESAS CALIFICADORAS")]
    public RespuestaEntidad EmpresasCalificadorasInsertar(EmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmpresasCalificadorasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE EMPRESAS CALIFICADORAS")]
    public RespuestaEntidad EmpresasCalificadorasModificar(EmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmpresasCalificadorasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE EMPRESAS CALIFICADORAS")]
    public EmpresasCalificadorasEntidad EmpresasCalificadorasConsultarDetalle(EmpresasCalificadorasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EmpresasCalificadorasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EmpresasCalificadorasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE EMPRESAS TASADORAS")]
    public RespuestaEntidad EmpresasTasadorasInsertar(TasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmpresasTasadorasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE EMPRESAS TASADORAS")]
    public RespuestaEntidad EmpresasTasadorasModificar(TasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EmpresasTasadorasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE EMPRESAS TASADORAS")]
    public TasadoresEntidad EmpresasTasadorasConsultarDetalle(TasadoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TasadoresEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EmpresasTasadorasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ENCHAPES")]
    public RespuestaEntidad EnchapesInsertar(EnchapesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EnchapesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ENCHAPES")]
    public RespuestaEntidad EnchapesModificar(EnchapesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EnchapesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ENCHAPES")]
    public EnchapesEntidad EnchapesConsultarDetalle(EnchapesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EnchapesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EnchapesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ENFOQUES")]
    public RespuestaEntidad EnfoquesInsertar(EnfoquesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EnfoquesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ENFOQUES")]
    public RespuestaEntidad EnfoquesModificar(EnfoquesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EnfoquesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ENFOQUES")]
    public EnfoquesEntidad EnfoquesConsultarDetalle(EnfoquesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EnfoquesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EnfoquesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ENTIDADES")]
    public RespuestaEntidad EntidadesInsertar(EntidadesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EntidadesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ENTIDADES")]
    public RespuestaEntidad EntidadesModificar(EntidadesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EntidadesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ENTIDADES")]
    public EntidadesEntidad EntidadesConsultarDetalle(EntidadesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EntidadesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EntidadesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ENTREPISOS")]
    public RespuestaEntidad EntrepisosInsertar(EntrepisosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EntrepisosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ENTREPISOS")]
    public RespuestaEntidad EntrepisosModificar(EntrepisosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EntrepisosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ENTREPISOS")]
    public EntrepisosEntidad EntrepisosConsultarDetalle(EntrepisosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EntrepisosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EntrepisosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ESCALERAS")]
    public RespuestaEntidad EscalerasInsertar(EscalerasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EscalerasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ESCALERAS")]
    public RespuestaEntidad EscalerasModificar(EscalerasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EscalerasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ESCALERAS")]
    public EscalerasEntidad EscalerasConsultarDetalle(EscalerasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EscalerasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EscalerasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ESTADOS AVALÚOS")]
    public RespuestaEntidad EstadosAvaluosInsertar(EstadosAvaluosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstadosAvaluosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ESTADOS AVALÚOS")]
    public RespuestaEntidad EstadosAvaluosModificar(EstadosAvaluosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstadosAvaluosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ESTADOS AVALÚOS")]
    public EstadosAvaluosEntidad EstadosAvaluosConsultarDetalle(EstadosAvaluosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EstadosAvaluosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EstadosAvaluosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ESTADOS CONSTRUCCIONES")]
    public RespuestaEntidad EstadosConstruccionesInsertar(EstadosConstruccionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstadosConstruccionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ESTADOS CONSTRUCCIONES")]
    public RespuestaEntidad EstadosConstruccionesModificar(EstadosConstruccionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstadosConstruccionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ESTADOS CONSTRUCCIONES")]
    public EstadosConstruccionesEntidad EstadosConstruccionesConsultarDetalle(EstadosConstruccionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EstadosConstruccionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EstadosConstruccionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ESTADOS INSTALACIONES ELÉCTRICAS")]
    public RespuestaEntidad EstadosInstalacionesElectricasInsertar(EstadosInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstadosInstalacionesElectricasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ESTADOS INSTALACIONES ELÉCTRICAS")]
    public RespuestaEntidad EstadosInstalacionesElectricasModificar(EstadosInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstadosInstalacionesElectricasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ESTADOS INSTALACIONES ELÉCTRICAS")]
    public EstadosInstalacionesElectricasEntidad EstadosInstalacionesElectricasConsultarDetalle(EstadosInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EstadosInstalacionesElectricasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EstadosInstalacionesElectricasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ESTRUCTURAS TECHOS")]
    public RespuestaEntidad EstructurasTechosInsertar(EstructurasTechosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstructurasTechosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ESTRUCTURAS TECHOS")]
    public RespuestaEntidad EstructurasTechosModificar(EstructurasTechosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.EstructurasTechosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ESTRUCTURAS TECHOS")]
    public EstructurasTechosEntidad EstructurasTechosConsultarDetalle(EstructurasTechosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        EstructurasTechosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EstructurasTechosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE FISCALIZADORES")]
    public RespuestaEntidad FiscalizadoresInsertar(FiscalizadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.FiscalizadoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE FISCALIZADORES")]
    public RespuestaEntidad FiscalizadoresModificar(FiscalizadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.FiscalizadoresModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE FISCALIZADORES")]
    public FiscalizadoresEntidad FiscalizadoresConsultarDetalle(FiscalizadoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        FiscalizadoresEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.FiscalizadoresConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE FORMAS")]
    public RespuestaEntidad FormasInsertar(FormasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.FormasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE FORMAS")]
    public RespuestaEntidad FormasModificar(FormasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.FormasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE FORMAS")]
    public FormasEntidad FormasConsultarDetalle(FormasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        FormasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.FormasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE GRADOS GRAVÁMENES")]
    public RespuestaEntidad GradosGravamenesInsertar(GradosGravamenesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.GradosGravamenesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE GRADOS GRAVÁMENES")]
    public RespuestaEntidad GradosGravamenesModificar(GradosGravamenesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.GradosGravamenesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE GRADOS GRAVÁMENES")]
    public GradosGravamenesEntidad GradosGravamenesConsultarDetalle(GradosGravamenesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        GradosGravamenesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.GradosGravamenesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE GRUPOS FINANCIEROS")]
    public RespuestaEntidad GruposFinancierosInsertar(GruposFinancierosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.GruposFinancierosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE GRUPOS FINANCIEROS")]
    public RespuestaEntidad GruposFinancierosModificar(GruposFinancierosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.GruposFinancierosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE GRUPOS FINANCIEROS")]
    public GruposFinancierosEntidad GruposFinancierosConsultarDetalle(GruposFinancierosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        GruposFinancierosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.GruposFinancierosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE GRUPOS RIESGOS DEUDORES")]
    public RespuestaEntidad GruposRiesgosDeudoresInsertar(GruposRiesgosDeudoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.GruposRiesgosDeudoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE GRUPOS RIESGOS DEUDORES")]
    public RespuestaEntidad GruposRiesgosDeudoresModificar(GruposRiesgosDeudoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.GruposRiesgosDeudoresModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE GRUPOS RIESGOS DEUDORES")]
    public GruposRiesgosDeudoresEntidad GruposRiesgosDeudoresConsultarDetalle(GruposRiesgosDeudoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        GruposRiesgosDeudoresEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.GruposRiesgosDeudoresConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE INDICACIONES AJUSTES ÁREAS")]
    public RespuestaEntidad IndicacionesAjustesAreasInsertar(IndicacionesAjustesAreasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.IndicacionesAjustesAreasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE INDICACIONES AJUSTES ÁREAS")]
    public RespuestaEntidad IndicacionesAjustesAreasModificar(IndicacionesAjustesAreasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.IndicacionesAjustesAreasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE INDICACIONES AJUSTES ÁREAS")]
    public IndicacionesAjustesAreasEntidad IndicacionesAjustesAreasConsultarDetalle(IndicacionesAjustesAreasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        IndicacionesAjustesAreasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.IndicacionesAjustesAreasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE INDICADORES GENERADORES DIVISAS")]
    public RespuestaEntidad IndicadoresGeneradoresDivisasInsertar(IndicadoresGeneradoresDivisasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.IndicadoresGeneradoresDivisasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE INDICADORES GENERADORES DIVISAS")]
    public RespuestaEntidad IndicadoresGeneradoresDivisasModificar(IndicadoresGeneradoresDivisasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.IndicadoresGeneradoresDivisasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE INDICADORES GENERADORES DIVISAS")]
    public IndicadoresGeneradoresDivisasEntidad IndicadoresGeneradoresDivisasConsultarDetalle(IndicadoresGeneradoresDivisasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        IndicadoresGeneradoresDivisasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.IndicadoresGeneradoresDivisasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE INDICADORES MONEDAS EXTRANJERAS")]
    public RespuestaEntidad IndicadoresMonedasExtranjerasInsertar(IndicadoresMonedasExtranjerasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.IndicadoresMonedasExtranjerasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE INDICADORES MONEDAS EXTRANJERAS")]
    public RespuestaEntidad IndicadoresMonedasExtranjerasModificar(IndicadoresMonedasExtranjerasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.IndicadoresMonedasExtranjerasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE INDICADORES MONEDAS EXTRANJERAS")]
    public IndicadoresMonedasExtranjerasEntidad IndicadoresMonedasExtranjerasConsultarDetalle(IndicadoresMonedasExtranjerasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        IndicadoresMonedasExtranjerasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.IndicadoresMonedasExtranjerasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE INSTRUMENTOS")]
    public RespuestaEntidad InstrumentosInsertar(InstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.InstrumentosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE INSTRUMENTOS")]
    public RespuestaEntidad InstrumentosModificar(InstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.InstrumentosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE INSTRUMENTOS")]
    public InstrumentosEntidad InstrumentosConsultarDetalle(InstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        InstrumentosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.InstrumentosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE INTERRUPTORES INSTALACIONES ELÉCTRICAS")]
    public RespuestaEntidad InterruptoresInstalacionesElectricasInsertar(InterruptoresInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.InterruptoresInstalacionesElectricasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE INTERRUPTORES INSTALACIONES ELÉCTRICAS")]
    public RespuestaEntidad InterruptoresInstalacionesElectricasModificar(InterruptoresInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.InterruptoresInstalacionesElectricasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE INTERRUPTORES INSTALACIONES ELÉCTRICAS")]
    public InterruptoresInstalacionesElectricasEntidad InterruptoresInstalacionesElectricasConsultarDetalle(InterruptoresInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        InterruptoresInstalacionesElectricasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.InterruptoresInstalacionesElectricasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE LOTES SEGREGADOS")]
    public RespuestaEntidad LotesSegregadosInsertar(LotesSegregadosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.LotesSegregadosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE LOTES SEGREGADOS")]
    public RespuestaEntidad LotesSegregadosModificar(LotesSegregadosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.LotesSegregadosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE LOTES SEGREGADOS")]
    public LotesSegregadosEntidad LotesSegregadosConsultarDetalle(LotesSegregadosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        LotesSegregadosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.LotesSegregadosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE MATERIALES CONSTRUCCIONES PREDOMINANTES")]
    public RespuestaEntidad MaterialesConstruccionesPredominantesInsertar(MaterialesConstruccionesPredominantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesConstruccionesPredominantesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE MATERIALES CONSTRUCCIONES PREDOMINANTES")]
    public RespuestaEntidad MaterialesConstruccionesPredominantesModificar(MaterialesConstruccionesPredominantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesConstruccionesPredominantesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE MATERIALES CONSTRUCCIONES PREDOMINANTES")]
    public MaterialesConstruccionesPredominantesEntidad MaterialesConstruccionesPredominantesConsultarDetalle(MaterialesConstruccionesPredominantesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        MaterialesConstruccionesPredominantesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.MaterialesConstruccionesPredominantesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE MATERIALES PAREDES EXTERNAS INTERNAS")]
    public RespuestaEntidad MaterialesParedesExternasInternasInsertar(MaterialesExternosInternosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasInternasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE MATERIALES PAREDES EXTERNAS INTERNAS")]
    public RespuestaEntidad MaterialesParedesExternasInternasModificar(MaterialesExternosInternosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasInternasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE MATERIALES PAREDES EXTERNAS INTERNAS")]
    public MaterialesExternosInternosEntidad MaterialesParedesExternasInternasConsultarDetalle(MaterialesExternosInternosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        MaterialesExternosInternosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasInternasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE MATERIALES PAREDES EXTERNAS TAPICHELES")]
    public RespuestaEntidad MaterialesParedesExternasTapichelesInsertar(MaterialesExternosTapichelesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasTapichelesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE MATERIALES PAREDES EXTERNAS TAPICHELES")]
    public RespuestaEntidad MaterialesParedesExternasTapichelesModificar(MaterialesExternosTapichelesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasTapichelesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE MATERIALES PAREDES EXTERNAS TAPICHELES")]
    public MaterialesExternosTapichelesEntidad MaterialesParedesExternasTapichelesConsultarDetalle(MaterialesExternosTapichelesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        MaterialesExternosTapichelesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.MaterialesParedesExternasTapichelesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE MATERIALES PISOS")]
    public RespuestaEntidad MaterialesPisosInsertar(MaterialesPisosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesPisosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE MATERIALES PISOS")]
    public RespuestaEntidad MaterialesPisosModificar(MaterialesPisosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesPisosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE MATERIALES PISOS")]
    public MaterialesPisosEntidad MaterialesPisosConsultarDetalle(MaterialesPisosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        MaterialesPisosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.MaterialesPisosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE MATERIALES PUERTAS")]
    public RespuestaEntidad MaterialesPuertasInsertar(MaterialesPuertasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesPuertasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE MATERIALES PUERTAS")]
    public RespuestaEntidad MaterialesPuertasModificar(MaterialesPuertasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesPuertasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE MATERIALES PUERTAS")]
    public MaterialesPuertasEntidad MaterialesPuertasConsultarDetalle(MaterialesPuertasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        MaterialesPuertasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.MaterialesPuertasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE MATERIALES VÍAS ACCESO")]
    public RespuestaEntidad MaterialesViasAccesoInsertar(MaterialesViasAccesoEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesViasAccesoInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE MATERIALES VÍAS ACCESO")]
    public RespuestaEntidad MaterialesViasAccesoModificar(MaterialesViasAccesoEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MaterialesViasAccesoModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE MATERIALES VÍAS ACCESO")]
    public MaterialesViasAccesoEntidad MaterialesViasAccesoConsultarDetalle(MaterialesViasAccesoEntidad _entidad, BitacorasEntidad _bitacora)
    {
        MaterialesViasAccesoEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.MaterialesViasAccesoConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE MONEDAS")]
    public RespuestaEntidad MonedasInsertar(MonedasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MonedasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE MONEDAS")]
    public RespuestaEntidad MonedasModificar(MonedasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.MonedasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE MONEDAS")]
    public MonedasEntidad MonedasConsultarDetalle(MonedasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        MonedasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.MonedasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE NIVELES SOCIOECONÓMICOS")]
    public RespuestaEntidad NivelesSocioeconomicosInsertar(NivelesSocioeconomicosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NivelesSocioeconomicosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE NIVELES SOCIOECONÓMICOS")]
    public RespuestaEntidad NivelesSocioeconomicosModificar(NivelesSocioeconomicosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NivelesSocioeconomicosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE NIVELES SOCIOECONÓMICOS")]
    public NivelesSocioeconomicosEntidad NivelesSocioeconomicosConsultarDetalle(NivelesSocioeconomicosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        NivelesSocioeconomicosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.NivelesSocioeconomicosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE NIVELES TERRENOS")]
    public RespuestaEntidad NivelesTerrenosInsertar(NivelesTerrenoEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NivelesTerrenosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE NIVELES TERRENOS")]
    public RespuestaEntidad NivelesTerrenosModificar(NivelesTerrenoEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NivelesTerrenosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE NIVELES TERRENOS")]
    public NivelesTerrenoEntidad NivelesTerrenosConsultarDetalle(NivelesTerrenoEntidad _entidad, BitacorasEntidad _bitacora)
    {
        NivelesTerrenoEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.NivelesTerrenosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE NOTARIOS")]
    public RespuestaEntidad NotariosInsertar(NotariosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NotariosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE NOTARIOS")]
    public RespuestaEntidad NotariosModificar(NotariosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NotariosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE NOTARIOS")]
    public NotariosEntidad NotariosConsultarDetalle(NotariosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        NotariosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.NotariosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE NÚMEROS LÍNEAS")]
    public RespuestaEntidad NumerosLineasInsertar(NumerosLineasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NumerosLineasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE NÚMEROS LÍNEAS")]
    public RespuestaEntidad NumerosLineasModificar(NumerosLineasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.NumerosLineasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE NÚMEROS LÍNEAS")]
    public NumerosLineasEntidad NumerosLineasConsultarDetalle(NumerosLineasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        NumerosLineasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.NumerosLineasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE OrientORIENTACIONESaciones")]
    public RespuestaEntidad OrientacionesInsertar(OrientacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.OrientacionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ORIENTACIONES")]
    public RespuestaEntidad OrientacionesModificar(OrientacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.OrientacionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ORIENTACIONES")]
    public OrientacionesEntidad OrientacionesConsultarDetalle(OrientacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        OrientacionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.OrientacionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE PENDIENTES")]
    public RespuestaEntidad PendientesInsertar(PendientesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PendientesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE PENDIENTES")]
    public RespuestaEntidad PendientesModificar(PendientesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PendientesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE PENDIENTES")]
    public PendientesEntidad PendientesConsultarDetalle(PendientesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        PendientesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.PendientesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE PINTURAS")]
    public RespuestaEntidad PinturasInsertar(PinturasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PinturasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE PINTURAS")]
    public RespuestaEntidad PinturasModificar(PinturasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PinturasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE PINTURAS")]
    public PinturasEntidad PinturasConsultarDetalle(PinturasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        PinturasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.PinturasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE PLANES INVERSIONES")]
    public RespuestaEntidad PlanesInversionesInsertar(PlanesInversionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PlanesInversionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE PLANES INVERSIONES")]
    public RespuestaEntidad PlanesInversionesModificar(PlanesInversionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PlanesInversionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE PLANES INVERSIONES")]
    public PlanesInversionesEntidad PlanesInversionesConsultarDetalle(PlanesInversionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        PlanesInversionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.PlanesInversionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE PLAZOS CALIFICACIONES")]
    public RespuestaEntidad PlazosCalificacionesInsertar(PlazosCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PlazosCalificacionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE PLAZOS CALIFICACIONES")]
    public RespuestaEntidad PlazosCalificacionesModificar(PlazosCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PlazosCalificacionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE PLAZOS CALIFICACIONES")]
    public PlazosCalificacionesEntidad PlazosCalificacionesConsultarDetalle(PlazosCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        PlazosCalificacionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.PlazosCalificacionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE PROVINCIAS")]
    public RespuestaEntidad ProvinciasInsertar(ProvinciasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ProvinciasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE PROVINCIAS")]
    public RespuestaEntidad ProvinciasModificar(ProvinciasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ProvinciasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE PROVINCIAS")]
    public ProvinciasEntidad ProvinciasConsultarDetalle(ProvinciasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ProvinciasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ProvinciasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE PUNTOS REFERENCIAS")]
    public RespuestaEntidad PuntosReferenciasInsertar(PuntosReferenciasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PuntosReferenciasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE PUNTOS REFERENCIAS")]
    public RespuestaEntidad PuntosReferenciasModificar(PuntosReferenciasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.PuntosReferenciasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE PUNTOS REFERENCIAS")]
    public PuntosReferenciasEntidad PuntosReferenciasConsultarDetalle(PuntosReferenciasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        PuntosReferenciasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.PuntosReferenciasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE REGÍMENES FISCALIZACIONES")]
    public RespuestaEntidad RegimenesFiscalizacionesInsertar(RegimenesFiscalizacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.RegimenesFiscalizacionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE REGÍMENES FISCALIZACIONES")]
    public RespuestaEntidad RegimenesFiscalizacionesModificar(RegimenesFiscalizacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.RegimenesFiscalizacionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE REGÍMENES FISCALIZACIONES")]
    public RegimenesFiscalizacionesEntidad RegimenesFiscalizacionesConsultarDetalle(RegimenesFiscalizacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        RegimenesFiscalizacionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.RegimenesFiscalizacionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE REPORTES ROLES")]
    public RespuestaEntidad ReportesRolesInsertar(ReportesRolesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ReportesRolesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE REPORTES ROLES")]
    public RespuestaEntidad ReportesRolesModificar(ReportesRolesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ReportesRolesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE REPORTES ROLES")]
    public ReportesRolesEntidad ReportesRolesConsultarDetalle(ReportesRolesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ReportesRolesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ReportesRolesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE REPORTES SEGUI")]
    public RespuestaEntidad ReportesSEGUIInsertar(ReportesSeguiEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ReportesSeguiInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE REPORTES SEGUI")]
    public RespuestaEntidad ReportesSEGUIModificar(ReportesSeguiEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ReportesSeguiModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE REPORTES SEGUI")]
    public ReportesSeguiEntidad ReportesSEGUIConsultarDetalle(ReportesSeguiEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ReportesSeguiEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ReportesSeguiConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE SECCIONES")]
    public RespuestaEntidad SeccionesInsertar(SeccionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SeccionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE SECCIONES")]
    public RespuestaEntidad SeccionesModificar(SeccionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SeccionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE SECCIONES")]
    public SeccionesEntidad SeccionesConsultarDetalle(SeccionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        SeccionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.SeccionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE SISTEMAS CONSTRUCTIVOS")]
    public RespuestaEntidad SistemasConstructivosInsertar(SistemasConstructivosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SistemasConstructivosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE SISTEMAS CONSTRUCTIVOS")]
    public RespuestaEntidad SistemasConstructivosModificar(SistemasConstructivosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SistemasConstructivosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE SISTEMAS CONSTRUCTIVOS")]
    public SistemasConstructivosEntidad SistemasConstructivosConsultarDetalle(SistemasConstructivosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        SistemasConstructivosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.SistemasConstructivosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE SITUACIONES")]
    public RespuestaEntidad SituacionesInsertar(SituacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SituacionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE SITUACIONES")]
    public RespuestaEntidad SituacionesModificar(SituacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SituacionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE SITUACIONES")]
    public SituacionesEntidad SituacionesConsultarDetalle(SituacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        SituacionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.SituacionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE SOLICITANTES")]
    public RespuestaEntidad SolicitantesInsertar(SolicitantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SolicitantesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE SOLICITANTES")]
    public RespuestaEntidad SolicitantesModificar(SolicitantesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.SolicitantesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE SOLICITANTES")]
    public SolicitantesEntidad SolicitantesConsultarDetalle(SolicitantesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        SolicitantesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.SolicitantesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TASADORES")]
    public RespuestaEntidad TasadoresInsertar(TasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TasadoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TASADORES")]
    public RespuestaEntidad TasadoresModificar(TasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TasadoresModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TASADORES")]
    public TasadoresEntidad TasadoresConsultarDetalle(TasadoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TasadoresEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TasadoresConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TENENCIAS PRT15")]
    public RespuestaEntidad TenenciasPRT15Insertar(TenenciasPrt15Entidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TenenciasPRT15Insertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TENENCIAS PRT15")]
    public RespuestaEntidad TenenciasPRT15Modificar(TenenciasPrt15Entidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TenenciasPRT15Modificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TENENCIAS PRT15")]
    public TenenciasPrt15Entidad TenenciasPRT15ConsultarDetalle(TenenciasPrt15Entidad _entidad, BitacorasEntidad _bitacora)
    {
        TenenciasPrt15Entidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TenenciasPRT15ConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TENENCIAS PRT17")]
    public RespuestaEntidad TenenciasPRT17Insertar(TenenciasPrt17Entidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TenenciasPRT17Insertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TENENCIAS PRT17")]
    public RespuestaEntidad TenenciasPRT17Modificar(TenenciasPrt17Entidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TenenciasPRT17Modificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TENENCIAS PRT17")]
    public TenenciasPrt17Entidad TenenciasPRT17ConsultarDetalle(TenenciasPrt17Entidad _entidad, BitacorasEntidad _bitacora)
    {
        TenenciasPrt17Entidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TenenciasPRT17ConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS ADJUDICACIONES BIENES")]
    public RespuestaEntidad TiposAdjudicacionesBienesInsertar(TiposAdjudicacionesBienesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposAdjudicacionesBienesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS ADJUDICACIONES BIENES")]
    public RespuestaEntidad TiposAdjudicacionesBienesModificar(TiposAdjudicacionesBienesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposAdjudicacionesBienesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS ADJUDICACIONES BIENES")]
    public TiposAdjudicacionesBienesEntidad TiposAdjudicacionesBienesConsultarDetalle(TiposAdjudicacionesBienesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposAdjudicacionesBienesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposAdjudicacionesBienesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS ASIGNACIONES CALIFICACIONES")]
    public RespuestaEntidad TiposAsignacionesCalificacionesInsertar(TiposAsignacionesCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposAsignacionesCalificacionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS ASIGNACIONES CALIFICACIONES")]
    public RespuestaEntidad TiposAsignacionesCalificacionesModificar(TiposAsignacionesCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposAsignacionesCalificacionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS ASIGNACIONES CALIFICACIONES")]
    public TiposAsignacionesCalificacionesEntidad TiposAsignacionesCalificacionesConsultarDetalle(TiposAsignacionesCalificacionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposAsignacionesCalificacionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposAsignacionesCalificacionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS AVALES")]
    public RespuestaEntidad TipoAvalInsertar(TiposAvalesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TipoAvalInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS AVALES")]
    public RespuestaEntidad TipoAvalModificar(TiposAvalesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TipoAvalModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS AVALES")]
    public TiposAvalesEntidad TipoAvalConsultarDetalle(TiposAvalesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposAvalesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TipoAvalConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS AVALES FIANZAS")]
    public RespuestaEntidad TiposAvalesFianzasInsertar(TiposAvalesFianzasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposAvalesFianzasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS AVALES FIANZAS")]
    public RespuestaEntidad TiposAvalesFianzasModificar(TiposAvalesFianzasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposAvalesFianzasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS AVALES FIANZAS")]
    public TiposAvalesFianzasEntidad TiposAvalesFianzasConsultarDetalle(TiposAvalesFianzasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposAvalesFianzasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposAvalesFianzasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS BIENES")]
    public RespuestaEntidad TiposBienesInsertar(TiposBienesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposBienesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS BIENES")]
    public RespuestaEntidad TiposBienesModificar(TiposBienesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposBienesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS BIENES")]
    public TiposBienesEntidad TiposBienesConsultarDetalle(TiposBienesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposBienesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposBienesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS CARTERAS")]
    public RespuestaEntidad TiposCarterasInsertar(TiposCarterasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposCarterasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS CARTERAS")]
    public RespuestaEntidad TiposCarterasModificar(TiposCarterasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposCarterasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS CARTERAS")]
    public TiposCarterasEntidad TiposCarterasConsultarDetalle(TiposCarterasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposCarterasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposCarterasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS CASOS")]
    public RespuestaEntidad TiposCasosInsertar(TiposCasosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposCasosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS CASOS")]
    public RespuestaEntidad TiposCasosModificar(TiposCasosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposCasosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS CASOS")]
    public TiposCasosEntidad TiposCasosConsultarDetalle(TiposCasosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposCasosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposCasosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS CAPACIDADES PAGOS")]
    public RespuestaEntidad TiposCapacidadesPagosInsertar(TiposCapacidadesPagosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposCapacidadesPagosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS CAPACIDADES PAGOS")]
    public RespuestaEntidad TiposCapacidadesPagosModificar(TiposCapacidadesPagosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposCapacidadesPagosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS CAPACIDADES PAGOS")]
    public TiposCapacidadesPagosEntidad TiposCapacidadesPagosConsultarDetalle(TiposCapacidadesPagosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposCapacidadesPagosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposCapacidadesPagosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS CLASIFICACIONES INSTRUMENTOS")]
    public RespuestaEntidad TiposClasificacionesInstrumentosInsertar(TiposClasificacionesInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposClasificacionesInstrumentosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS CLASIFICACIONES INSTRUMENTOS")]
    public RespuestaEntidad TiposClasificacionesInstrumentosModificar(TiposClasificacionesInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposClasificacionesInstrumentosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS CLASIFICACIONES INSTRUMENTOS")]
    public TiposClasificacionesInstrumentosEntidad TiposClasificacionesInstrumentosConsultarDetalle(TiposClasificacionesInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposClasificacionesInstrumentosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposClasificacionesInstrumentosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS COMPORTAMIENTOS PAGOS")]
    public RespuestaEntidad TiposComportamientosPagosInsertar(TiposComportamientosPagosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposComportamientosPagosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS COMPORTAMIENTOS PAGOS")]
    public RespuestaEntidad TiposComportamientosPagosModificar(TiposComportamientosPagosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposComportamientosPagosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS COMPORTAMIENTOS PAGOS")]
    public TiposComportamientosPagosEntidad TiposComportamientosPagosConsultarDetalle(TiposComportamientosPagosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposComportamientosPagosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposComportamientosPagosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS CONSTRUCCIONES")]
    public RespuestaEntidad TiposConstruccionesInsertar(TiposConstruccionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposConstruccionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS CONSTRUCCIONES")]
    public RespuestaEntidad TiposConstruccionesModificar(TiposConstruccionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposConstruccionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS CONSTRUCCIONES")]
    public TiposConstruccionesEntidad TiposConstruccionesConsultarDetalle(TiposConstruccionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposConstruccionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposConstruccionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS DOCUMENTOS LEGALES")]
    public RespuestaEntidad TiposDocumentosLegalesInsertar(TiposDocumentosLegalesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposDocumentosLegalesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS DOCUMENTOS LEGALES")]
    public RespuestaEntidad TiposDocumentosLegalesModificar(TiposDocumentosLegalesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposDocumentosLegalesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS DOCUMENTOS LEGALES")]
    public TiposDocumentosLegalesEntidad TiposDocumentosLegalesConsultarDetalle(TiposDocumentosLegalesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposDocumentosLegalesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposDocumentosLegalesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS ENTIDADES")]
    public RespuestaEntidad TiposEntidadesInsertar(TiposEntidadesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposEntidadesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS ENTIDADES")]
    public RespuestaEntidad TiposEntidadesModificar(TiposEntidadesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposEntidadesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS ENTIDADES")]
    public TiposEntidadesEntidad TiposEntidadesConsultarDetalle(TiposEntidadesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposEntidadesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposEntidadesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS EMISORES")]
    public RespuestaEntidad TiposEmisoresInsertar(TiposEmisoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposEmisoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS EMISORES")]
    public RespuestaEntidad TiposEmisoresModificar(TiposEmisoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposEmisoresModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS EMISORES")]
    public TiposEmisoresEntidad TiposEmisoresConsultarDetalle(TiposEmisoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposEmisoresEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposEmisoresConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS ESTADOS AVALÚOS")]
    public RespuestaEntidad TiposEstadosAvaluosInsertar(TiposEstadosAvaluosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposEstadosAvaluosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS ESTADOS AVALÚOS")]
    public RespuestaEntidad TiposEstadosAvaluosModificar(TiposEstadosAvaluosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposEstadosAvaluosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS ESTADOS AVALÚOS")]
    public TiposEstadosAvaluosEntidad TiposEstadosAvaluosConsultarDetalle(TiposEstadosAvaluosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposEstadosAvaluosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposEstadosAvaluosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS GARANTIAS")]
    public RespuestaEntidad TiposGarantiasInsertar(TiposGarantiasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposGarantiasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS GARANTIAS")]
    public RespuestaEntidad TiposGarantiasModificar(TiposGarantiasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposGarantiasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS GARANTIAS")]
    public TiposGarantiasEntidad TiposGarantiasConsultarDetalle(TiposGarantiasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposGarantiasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposGarantiasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS GRADOS")]
    public RespuestaEntidad TiposGradosInsertar(TiposGradosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposGradosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS GRADOS")]
    public RespuestaEntidad TiposGradosModificar(TiposGradosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposGradosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS GRADOS")]
    public TiposGradosEntidad TiposGradosConsultarDetalle(TiposGradosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposGradosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposGradosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS GRUPOS FINANCIEROS")]
    public RespuestaEntidad TiposGruposFinancierosInsertar(TiposGruposFinancierosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposGruposFinancierosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS GRUPOS FINANCIEROS")]
    public RespuestaEntidad TiposGruposFinancierosModificar(TiposGruposFinancierosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposGruposFinancierosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS GRUPOS FINANCIEROS")]
    public TiposGruposFinancierosEntidad TiposGruposFinancierosConsultarDetalle(TiposGruposFinancierosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposGruposFinancierosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposGruposFinancierosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS INDICADORES INSCRIPCIONES")]
    public RespuestaEntidad TiposIndicadoresInscripcionesInsertar(TiposIndicadoresInscripcionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposIndicadoresInscripcionesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS INDICADORES INSCRIPCIONES")]
    public RespuestaEntidad TiposIndicadoresInscripcionesModificar(TiposIndicadoresInscripcionesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposIndicadoresInscripcionesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS INDICADORES INSCRIPCIONES")]
    public TiposIndicadoresInscripcionesEntidad TiposIndicadoresInscripcionesConsultarDetalle(TiposIndicadoresInscripcionesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposIndicadoresInscripcionesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposIndicadoresInscripcionesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS IDENTIFICACIONES RUC")]
    public RespuestaEntidad TiposIdentificacionesRUCInsertar(TiposIdentificacionesRUCEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposIdentificacionesRUCInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS IDENTIFICACIONES RUC")]
    public RespuestaEntidad TiposIdentificacionesRUCModificar(TiposIdentificacionesRUCEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposIdentificacionesRUCModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS IDENTIFICACIONES RUC")]
    public TiposIdentificacionesRUCEntidad TiposIdentificacionesRUCConsultarDetalle(TiposIdentificacionesRUCEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposIdentificacionesRUCEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposIdentificacionesRUCConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS INGRESOS")]
    public RespuestaEntidad TiposIngresosInsertar(TiposIngresosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposIngresosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS INGRESOS")]
    public RespuestaEntidad TiposIngresosModificar(TiposIngresosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposIngresosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS INGRESOS")]
    public TiposIngresosEntidad TiposIngresosConsultarDetalle(TiposIngresosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposIngresosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposIngresosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS INMUEBLES")]
    public RespuestaEntidad TiposInmueblesInsertar(TiposInmueblesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposInmueblesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS INMUEBLES")]
    public RespuestaEntidad TiposInmueblesModificar(TiposInmueblesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposInmueblesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS INMUEBLES")]
    public TiposInmueblesEntidad TiposInmueblesConsultarDetalle(TiposInmueblesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposInmueblesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposInmueblesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS INSTRUMENTOS")]
    public RespuestaEntidad TiposInstrumentosInsertar(TiposInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposInstrumentosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS INSTRUMENTOS")]
    public RespuestaEntidad TiposInstrumentosModificar(TiposInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposInstrumentosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS INSTRUMENTOS")]
    public TiposInstrumentosEntidad TiposInstrumentosConsultarDetalle(TiposInstrumentosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposInstrumentosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposInstrumentosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS LIQUIDEZ")]
    public RespuestaEntidad TiposLiquidezInsertar(TiposLiquidezEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposLiquidezInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS LIQUIDEZ")]
    public RespuestaEntidad TiposLiquidezModificar(TiposLiquidezEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposLiquidezModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS LIQUIDEZ")]
    public TiposLiquidezEntidad TiposLiquidezConsultarDetalle(TiposLiquidezEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposLiquidezEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposLiquidezConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS MITIGADORES RIESGOS")]
    public RespuestaEntidad TiposMitigadoresRiesgosInsertar(TiposMitigadoresRiesgosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposMitigadoresRiesgosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS MITIGADORES RIESGOS")]
    public RespuestaEntidad TiposMitigadoresRiesgosModificar(TiposMitigadoresRiesgosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposMitigadoresRiesgosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS MITIGADORES RIESGOS")]
    public TiposMitigadoresRiesgosEntidad TiposMitigadoresRiesgosConsultarDetalle(TiposMitigadoresRiesgosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposMitigadoresRiesgosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposMitigadoresRiesgosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS MONEDAS")]
    public RespuestaEntidad TiposMonedasInsertar(TiposMonedasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposMonedasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS MONEDAS")]
    public RespuestaEntidad TiposMonedasModificar(TiposMonedasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposMonedasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS MONEDAS")]
    public TiposMonedasEntidad TiposMonedasConsultarDetalle(TiposMonedasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposMonedasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposMonedasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS PERSONAS")]
    public RespuestaEntidad TiposPersonasInsertar(TiposPersonasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposPersonasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS PERSONAS")]
    public RespuestaEntidad TiposPersonasModificar(TiposPersonasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposPersonasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS PERSONAS")]
    public TiposPersonasEntidad TiposPersonasConsultarDetalle(TiposPersonasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposPersonasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposPersonasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS PÓLIZAS")]
    public RespuestaEntidad TiposPolizasInsertar(TiposPolizasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposPolizasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS PÓLIZAS")]
    public RespuestaEntidad TiposPolizasModificar(TiposPolizasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposPolizasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS PÓLIZAS")]
    public TiposPolizasEntidad TiposPolizasConsultarDetalle(TiposPolizasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposPolizasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposPolizasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS SERVICIOS")]
    public RespuestaEntidad TiposServiciosInsertar(TiposServiciosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposServiciosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS SERVICIOS")]
    public RespuestaEntidad TiposServiciosModificar(TiposServiciosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposServiciosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS SERVICIOS")]
    public TiposServiciosEntidad TiposServiciosConsultarDetalle(TiposServiciosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposServiciosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposServiciosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TIPOS ZONAS")]
    public RespuestaEntidad TiposZonasInsertar(TiposZonasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposZonasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TIPOS ZONAS")]
    public RespuestaEntidad TiposZonasModificar(TiposZonasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TiposZonasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TIPOS ZONAS")]
    public TiposZonasEntidad TiposZonasConsultarDetalle(TiposZonasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TiposZonasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposZonasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE TOPOGRAFÍAS")]
    public RespuestaEntidad TopografiasInsertar(TopografiasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TopografiasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE TOPOGRAFÍAS")]
    public RespuestaEntidad TopografiasModificar(TopografiasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.TopografiasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE TOPOGRAFÍAS")]
    public TopografiasEntidad TopografiasConsultarDetalle(TopografiasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        TopografiasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TopografiasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE UNIDADES")]
    public RespuestaEntidad UnidadesInsertar(UnidadesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.UnidadesInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE UNIDADES")]
    public RespuestaEntidad UnidadesModificar(UnidadesEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.UnidadesModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE UNIDADES")]
    public UnidadesEntidad UnidadesConsultarDetalle(UnidadesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        UnidadesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.UnidadesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE USOS SUELOS ACTUAL ENTORNOS")]
    public RespuestaEntidad UsosSuelosActualEntornosInsertar(UsosSuelosActualEntornosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.UsosSuelosActualEntornosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE USOS SUELOS ACTUAL ENTORNOS")]
    public RespuestaEntidad UsosSuelosActualEntornosModificar(UsosSuelosActualEntornosEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.UsosSuelosActualEntornosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE USOS SUELOS ACTUAL ENTORNOS")]
    public UsosSuelosActualEntornosEntidad UsosSuelosActualEntornosConsultarDetalle(UsosSuelosActualEntornosEntidad _entidad, BitacorasEntidad _bitacora)
    {
        UsosSuelosActualEntornosEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.UsosSuelosActualEntornosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE VENTANAS")]
    public RespuestaEntidad VentanasInsertar(VentanasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.VentanasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE VENTANAS")]
    public RespuestaEntidad VentanasModificar(VentanasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.VentanasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE VENTANAS")]
    public VentanasEntidad VentanasConsultarDetalle(VentanasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        VentanasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.VentanasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE VERJAS")]
    public RespuestaEntidad VerjasInsertar(VerjasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.VerjasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE VERJAS")]
    public RespuestaEntidad VerjasModificar(VerjasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.VerjasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE VERJAS")]
    public VerjasEntidad VerjasConsultarDetalle(VerjasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        VerjasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.VerjasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE VÍAS ACCESOS")]
    public RespuestaEntidad ViasAccesosInsertar(ViasAccesoEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ViasAccesosInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE VÍAS ACCESOS")]
    public RespuestaEntidad ViasAccesosModificar(ViasAccesoEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ViasAccesosModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE VÍAS ACCESOS")]
    public ViasAccesoEntidad ViasAccesosConsultarDetalle(ViasAccesoEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ViasAccesoEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ViasAccesosConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE VOLTAJES INSTALACIONES ELECTRICAS")]
    public RespuestaEntidad VoltajesInstalacionesElectricasInsertar(VoltajesInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.VoltajesInstalacionesElectricasInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE VOLTAJES INSTALACIONES ELECTRICAS")]
    public RespuestaEntidad VoltajesInstalacionesElectricasModificar(VoltajesInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.VoltajesInstalacionesElectricasModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE VOLTAJES INSTALACIONES ELECTRICAS")]
    public VoltajesInstalacionesElectricasEntidad VoltajesInstalacionesElectricasConsultarDetalle(VoltajesInstalacionesElectricasEntidad _entidad, BitacorasEntidad _bitacora)
    {
        VoltajesInstalacionesElectricasEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.VoltajesInstalacionesElectricasConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
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

    [WebMethod(Description = "PROCEDIMIENTO: INSERTA UN REGISTRO DE ZONAS TASADORES")]
    public RespuestaEntidad ZonasTasadoresInsertar(ZonasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ZonasTasadoresInsertar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: ACTUALIZA UN REGISTRO DE ZONAS TASADORES")]
    public RespuestaEntidad ZonasTasadoresModificar(ZonasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
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

            consulta = mantenimientosNegocio.Instancia.ZonasTasadoresModificar(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE ZONAS TASADORES")]
    public ZonasTasadoresEntidad ZonasTasadoresConsultarDetalle(ZonasTasadoresEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ZonasTasadoresEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ZonasTasadoresConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region REPORTES

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS FILTRADO DE REPORTES")]
    public ReportesEntidad ReportesConsultarDetalle(ReportesEntidad _entidad, BitacorasEntidad _bitacora)
    {
        ReportesEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = reportesNegocio.Instancia.ReportesConsultarDetalle(conexion, conexionBitacora, _entidad, _bitacora);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: GENERA UN ARCHIVO DE SALIDA")]
    public RespuestaEntidad EjecutarArchivo(int archivo, byte generar, BitacorasEntidad _bitacora)
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

            consulta = procesosNegocio.Instancia.EjecutarArchivo(conexion, conexionBitacora, archivo, generar, _bitacora);
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