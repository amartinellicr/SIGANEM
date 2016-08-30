using System;
using System.Web;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.EN;
using BCR.SIGANEM.BL;
using BCR.SIGANEM.UT;


[WebService(Namespace = "http://bancobcr.com/", Description = "SERVICIO WEB LISTAS")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SiganemListasWS : System.Web.Services.WebService
{

    #region PROPIEDADES

    #region NEGOCIO

    private RolesNegocio rolesNegocio = new RolesNegocio();
    private GarantiasNegocio garantiasNegocio = new GarantiasNegocio();
    private MantenimientosNegocio mantenimientosNegocio = new MantenimientosNegocio();
    private ProcesosNegocio procesosNegocio = new ProcesosNegocio();
  
    #endregion

    #region UTILIDADES

    private RegistrarEventLog registrarEventLog = new RegistrarEventLog();
    private LectorConfiguracion lectorConfiguracion = new LectorConfiguracion();

    #endregion

    #endregion

    #region CONSTRUCTOR

    public SiganemListasWS()
    {

    }

    #endregion

    #region METODOS PUBLICOS LISTAS

    #region CONFIGURACION

    #region ACTIVOS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE ACTIVOS PARA UNA LISTA")]
    public List<ListaEntidad> ActivosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ActivosLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    #region ADMINISTRACION DE CONTENIDOS

    [WebMethod(Description = "PROCEDIMIENTO: OBTIENE EL CODIGO Y NOMBRE DE LA PANTALLA")]
    public PantallasEntidad AdministracionesContenidosConsultaPantallas(PantallasEntidad _entidad)
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

            consulta = mantenimientosNegocio.Instancia.AdministracionesContenidosConsultaPantallas(conexion, _entidad);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: OBTIENE LAS PESTANAS DE LA PANTALLA")]
    public List<NodoMenuEntidad> AdministracionesContenidosConsultaPestanas(PantallasEntidad _entidad)
    {
        List<NodoMenuEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.AdministracionesContenidosConsultaPestanas(conexion, _entidad);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: OBTIENE LOS CONTROLES DE LA PANTALLA")]
    public List<ControlEntidad> AdministracionesContenidosConsultaControl(PantallasEntidad _entidad)
    {
        List<ControlEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.AdministracionesContenidosConsultaControl(conexion, _entidad);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CALIFICACIONES EMPRESAS CALIFICADORAS CON LA CATEGORIA DE RIESGO PARA UNA LISTA")]
    public List<ListaEntidad> CalificacionesEmpresasCalificadorasCategoriaRiesgoLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasCategoriaRiesgoLista(conexion, _filtro);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CALIFICACIONES EMPRESAS CALIFICADORAS CON LA CALIFICACION PARA UNA LISTA")]
    public List<ListaEntidad> CalificacionesEmpresasCalificadorasCalificacionLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;
        string[] filtros = _filtro.Split('|');

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CalificacionesEmpresasCalificadorasCalificacionLista(conexion, filtros[0], filtros[1]);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CANTONES PARA UNA LISTA")]
    public List<ListaEntidad> CantonesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;
        String conexionBitacora = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CantonesLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CATEGORIAS CALIFICACIONES PARA UNA LISTA")]
    public List<ListaEntidad> CategoriasCalificacionesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CategoriasCalificacionesLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CATEGORIAS RIESGOS EMPRESAS CALIFICADORAS PARA UNA LISTA")]
    public List<ListaEntidad> CategoriasRiesgosEmpresasCalificadorasLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.CategoriasRiesgosEmpresasCalificadorasLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CLASES AERONAVES PARA UNA LISTA")]
    public List<ListaEntidad> ClasesAeronavesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ClasesAeronavesLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CLASES BUQUES PARA UNA LISTA")]
    public List<ListaEntidad> ClasesBuquesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ClasesBuquesLista(conexion, _filtro);
            
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO: 1-24493227
    #region CLASES GARANTIAS PRT17

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CLASES CLASES GARANTIAS PRT17 PARA UNA LISTA")]
    public List<ListaEntidad> ClasesGarantiasPRT17Lista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ClasesGarantiasPRT17Lista(conexion, _filtro);
            
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region CLASES TIPOS  BIENES

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CLASES TIPOS DE BIENES PARA UNA LISTA")]
    public List<ListaEntidad> ClasesTiposBienesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ClasesTiposBienesLista(conexion, _filtro);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }
    //REQUERIMIENTO: 1-24493227
    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CLASE GARANTIAS PRT 17 SEGUN EL TIPO BIEN PARA UNA LISTA")]
    public List<ListaEntidad> ClasesTiposBienesClasesGarantiasPrt17Lista(String idTipoBien, String codClaseTipoBien)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ClasesTiposBienesClasesGarantiasPrt17Lista(conexion, idTipoBien, codClaseTipoBien);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CLASES VEHICULOS PARA UNA LISTA")]
    public List<ListaEntidad> ClasesVehiculosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ClasesVehiculosLista(conexion, _filtro);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CLASES VEHICULOS PARA UNA LISTA")]
    public List<ListaEntidad> ClasesVehiculosLista2(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.ClasesVehiculosLista2(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CODIGOS DUPLICADOS PARA UNA LISTA")]
    public List<ListaEntidad> CodigosDuplicadosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CodigosDuplicadosLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE CODIGOS DUPLICADOS PARA UNA LISTA")]
    public List<ListaEntidad> CodigosHorizontalidadLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.CodigosHorizontalidadLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE DISTRITOS PARA UNA LISTA")]
    public List<ListaEntidad> DistritosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;
        String conexionBitacora = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DistritosLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE EMISIONES INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> EmisionesInstrumentosEmisorLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosEmisorLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;

        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE EMISIONES INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> EmisionesInstrumentosISINLista(String _filtro)
    {
        string[] variable = _filtro.Split('|');
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosISINLista(conexion, variable[0], variable[1]);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;

        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE EMISIONES INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> EmisionesInstrumentosSerieLista(String _filtro)
    {
        if (_filtro.Equals(""))
            _filtro = " | | ";

        string[] variable = _filtro.Split('|');
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosSerieLista(conexion, variable[0], variable[1], variable[2]);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;

        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE EMISIONES INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> EmisionesInstrumentosTipoClasificacionPremioLista(String _filtro)
    {
        if (_filtro.Equals(""))
            _filtro = " | | | ";

        string[] variable = _filtro.Split('|');
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosTipoClasificacionPremioLista(conexion, variable[0], variable[1], variable[2], variable[3]);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;

        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE EMISIONES INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> EmisionesInstrumentosFechaVencimientoLista(String _filtro)
    {
        if (_filtro.Equals(""))
            _filtro = " | | | | ";

        string[] variable = _filtro.Split('|');
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosFechaVencimientoLista(conexion, variable[0], variable[1], variable[2], variable[3], variable[4]);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;

        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE EMISIONES INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> EmisionesInstrumentosMonedaLista(String _filtro)
    {
        if (_filtro.Equals(""))
            _filtro = " | | | | ";

        string[] variable = _filtro.Split('|');
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisionesInstrumentosMonedaLista(conexion, variable[0], variable[1], variable[2], variable[3], variable[4]);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE EMISORES PARA UNA LISTA")]
    public List<ListaEntidad> EmisoresLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.EmisoresLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE EMPRESAS CALIFICADORAS PARA UNA LISTA")]
    public List<ListaEntidad> EmpresasCalificadorasLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EmpresasCalificadorasLista(conexion, _filtro);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    #region ESTADOS GARANTIAS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE ESTADOS GARANTIAS PARA UNA LISTA")]
    public List<ListaEntidad> EstadosGarantiasLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.EstadosGarantiasLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE GRADOS GRAVAMENES PARA UNA LISTA")]
    public List<ListaEntidad> GradosGravamenesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.GradosGravamenesLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE INDICADORES MONEDAS EXTRANJERAS PARA UNA LISTA")]
    public List<ListaEntidad> IndicadoresMonedasExtranjerasLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.IndicadoresMonedasExtranjerasLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> InstrumentosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.InstrumentosLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;

        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> InstrumentosFiltradoLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.InstrumentosFiltradoLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;

        }
    }
    
    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE INSTRUMENTOS PARA UNA LISTA SEGÚN LAS EMISIONES")]
    public List<ListaEntidad> InstrumentosEmisionesFiltradoLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.InstrumentosEmisionesFiltradoLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;

        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE INSTRUMENTOS PARA UNA LISTA POR TIPO DE INSTRUMENTO")]
    public List<ListaEntidad> InstrumentosTipoInstrumentoLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.InstrumentosTipoInstrumentoLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE MONEDAS PARA UNA LISTA")]
    public List<ListaEntidad> MonedasLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.MonedasLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE PLAZOS CALIFICACIONES PARA UNA LISTA")]
    public DataSet PlazosCalificacionesLista(String _filtro)
    {
        DataSet consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PlazosCalificacionesLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE PLAZOS CALIFICACIONES PARA UNA LISTA")]
    public List<ListaEntidad> PlazosCalificacionesListas(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.PlazosCalificacionesListas(conexion, _filtro);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    #region POLIZAS TIPOS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE POLIZAS LISTA PARA UNA LISTA")]
    public List<ListaEntidad> PolizasTiposLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.PolizasTiposLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE PROVINCIAS PARA UNA LISTA")]
    public List<ListaEntidad> ProvinciasLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ProvinciasLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE REGÍMENES FISCALIZACIONES PARA UNA LISTA")]
    public List<ListaEntidad> RegimenesFiscalizacionesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.RegimenesFiscalizacionesLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO: 1-24493227
    #region TENENCIAS PRT15

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TENENCIAS PRT15 PARA UNA LISTA")]
    public List<ListaEntidad> TenenciasPRT15Lista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TenenciasPRT15Lista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion 
    
    //REQUERIMIENTO: 1-24493227
    #region TENENCIAS PRT17

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TENENCIAS PRT15 PARA UNA LISTA")]
    public List<ListaEntidad> TenenciasPRT17Lista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TenenciasPRT17Lista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion 

    #region TIPOS ALMACENES 

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS ALMACENES PARA UNA LISTA")]
    public List<ListaEntidad> TiposAlmacenesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposAlmacenesLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS ASIGNACIONES CALIFICACIONES PARA UNA LISTA")]
    public List<ListaEntidad> TiposAsignacionesCalificacionesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposAsignacionesCalificacionesLista(conexion, _filtro);
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
    #region TIPOS AVALES FIANZAS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS AVALES FIANZAS PARA UNA LISTA")]
    public List<ListaEntidad> TiposAvalesFianzasLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposAvalesFianzasLista(conexion, _filtro);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    #region TIPOS AVALES

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS AVALES PARA UNA LISTA")]
    public List<ListaEntidad> TipoAvalLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TipoAvalLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS BIENES PARA UNA LISTA")]
    public List<ListaEntidad> TiposBienesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposBienesLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS CLASIFICACIONES INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> TiposClasificacionesInstrumentosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposClasificacionesInstrumentosLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS CLASIFICACIONES INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> TiposClasificacionesInstrumentosListaEntidad(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposClasificacionesInstrumentosListaEntidad(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO: 1-24493227
    #region TIPOS DOCUMENTOS LEGALES

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS DOCUMENTOS LEGALES PARA UNA LISTA")]
    public List<ListaEntidad> TiposDocumentosLegalesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposDocumentosLegalesLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS ENTIDADES PARA UNA LISTA")]
    public List<ListaEntidad> TiposEntidadesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposEntidadesLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS ESTADOS AVALUOS PARA UNA LISTA")]
    public List<ListaEntidad> TiposEstadosAvaluosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposEstadosAvaluosLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS GARANTIAS PARA UNA LISTA")]
    public List<ListaEntidad> TiposGarantiasLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposGarantiasLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS GRADOS PARA UNA LISTA")]
    public List<ListaEntidad> TiposGradosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposGradosLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS GRUPOS FINANCIEROS PARA UNA LISTA")]
    public List<ListaEntidad> TiposGruposFinancierosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposGruposFinancierosLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS IDENTIFICACIONES RUC PARA UNA LISTA")]
    public List<ListaEntidad> TiposIdentificacionesRUCLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposIdentificacionesRUCLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS DE INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> TiposInstrumentosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposInstrumentosLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS DE INSTRUMENTOS PARA UNA LISTA")]
    public List<ListaEntidad> TiposInstrumentosFiltradoInstrumentosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposInstrumentosFiltradoInstrumentosLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS LIQUIDEZ PARA UNA LISTA")]
    public List<ListaEntidad> TiposLiquidezLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposLiquidezLista(conexion, _filtro);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO: 1-24493227
    #region TIPOS MITIGADORES RIESGOS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS MITIGADORES RIESGOS PARA UNA LISTA")]
    public List<ListaEntidad> TiposMitigadoresRiesgosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposMitigadoresRiesgosLista(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS MONEDAS PARA UNA LISTA")]
    public List<ListaEntidad> TiposMonedasLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposMonedasLista(conexion, _filtro);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS PERSONAS PARA UNA LISTA")]
    public List<ListaEntidad> TiposPersonasLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposPersonasLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS PERSONAS TIPOS 1, 2 y 3 PARA UNA LISTA")]
    public List<ListaEntidad> TiposPersonasLista123(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposPersonasLista123(conexion, _filtro);

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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS SERVICIOS PARA UNA LISTA")]
    public List<ListaEntidad> TiposServiciosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposServiciosLista(conexion, _filtro);

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
    #region TIPOS TASADORES

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS TASADORES PARA UNA LISTA")]
    public List<ListaEntidad> TiposTasadoresLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TiposTasadoresLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    //REQUERIMIENTO:1-24292751
    #region TIPOS VALORES

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPOS VALORES PARA UNA LISTA")]
    public List<ListaEntidad> TiposValoresLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposValoresLista(conexion, _filtro);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }
    //REQUERIMIENTO: 1-24493227
    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TENENCIA PRT17 SEGGUN TIPO VALOR  TIPO INSTRUMENTO PARA UNA LISTA")]
    public List<ListaEntidad> TiposValoresTenenciasTiposInstrumentosLista(String idTipoInstrumento, String idTipoValor)
    {
        List<ListaEntidad> consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = mantenimientosNegocio.Instancia.TiposValoresTenenciasTiposInstrumentosLista(conexion, idTipoInstrumento, idTipoValor);
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

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE ZONAS TASADORES PARA UNA LISTA")]
    public List<ListaEntidad> ZonasTasadoresLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.ZonasTasadoresLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }

    #endregion

    #region VALORES GENERICOS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS GENERICO (INTERNO / EXTERNO) PARA UNA LISTA")]
    public List<ListaEntidad> DefaultInternoExternoLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        ListaEntidad _elemento = null;

        try
        {
            consulta = new List<ListaEntidad>();

            _elemento = new ListaEntidad();
            _elemento.Valor = "I";
            _elemento.Texto = "Interno";

            consulta.Add(_elemento);

            _elemento = new ListaEntidad();
            _elemento.Valor = "X";
            _elemento.Texto = "Externo";

            consulta.Add(_elemento);
            
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
			throw ex;
        }
    }
    
    //REQUERIMIENTO: 1-24493227
    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS GENERICO (SI / NO) PARA UNA LISTA")]
    public List<ListaEntidad> DefaultSiNoLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.DefaultSiNoLista(conexion, _filtro);

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

    #region SEGURIDAD

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE ROLES PARA UNA LISTA")]
    public List<ListaEntidad> RolesLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = rolesNegocio.Instancia.RolesLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region GARANTIAS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE PARAMETROS PARA LA FECHA VENCIMIENTO AVALUO SUGEF")]
    public ListaEntidad GarantiasRealesFechaVencimientoAvaluoSUGEF(String _filtro)
    {
        ListaEntidad consulta = null;
        string conexion = string.Empty;
        string conexionBitacora = string.Empty;

        try
        {
            #region CONEXION BASE DATOS

            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            conexionBitacora = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDBita);

            #endregion

            consulta = garantiasNegocio.Instancia.GarantiasRealesFechaVencimientoAvaluoSUGEF(conexion, _filtro);
            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPO OPERACION PARA UNA LISTA")]
    public List<ListaEntidad> GarantiasOperacionesTipoOperacionLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasOperacionesTipoOperacionLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPO OPERACION PARA UNA LISTA")]
    public List<ListaEntidad> GarantiasOperacionesTipoIdentificacionLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = garantiasNegocio.Instancia.GarantiasOperacionesTipoIdentificacionLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion
    
    #region INSCRIPCION GARANTIAS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPO INDICADORES INSCRIPCIONES PARA UNA LISTA")]
    public List<ListaEntidad> TipoIndicadorInscripcionLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TipoIndicadorInscripcionLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }
  
    #endregion

    #region FIDEICOMISO GARANTIAS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE TIPO DOCUMENTO FIDEICOMISO PARA UNA LISTA")]
    public List<ListaEntidad> TipoDocumentoFideicomisoLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = mantenimientosNegocio.Instancia.TipoDocumentoFideicomisoLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region PROCESOS

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE PROCESOS PARA UNA LISTA")]
    public List<ListaEntidad> ProcesosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = procesosNegocio.Instancia.ProcesosLista(conexion, _filtro);

            return consulta;
        }
        catch (Exception ex)
        {
            registrarEventLog.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    #endregion

    #region ARCHIVOS SALIDA

    [WebMethod(Description = "PROCEDIMIENTO: DEVUELVE EL SET DE DATOS DE ARVHIVOS PARA UNA LISTA")]
    public List<ListaEntidad> ArchivosLista(String _filtro)
    {
        List<ListaEntidad> consulta = null;
        String conexion = String.Empty;

        try
        {
            conexion = lectorConfiguracion.ObtenerValorLlave(Resources.Resource.nomBDMain);
            consulta = procesosNegocio.Instancia.ArchivosLista(conexion, _filtro);

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
