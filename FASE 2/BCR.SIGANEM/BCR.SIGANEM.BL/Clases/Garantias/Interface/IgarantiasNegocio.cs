using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.EN;
using BCR.SIGANEM.UT;


namespace BCR.SIGANEM.BL
{
    public interface IgarantiasNegocio
    {
        #region AVALES
        List<GarantiasAvalesEntidad> GarantiasAvalesConsultar(String conexion, ParametrosConsultaEntidad entidad);
        int GarantiasAvalesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
        RespuestaEntidad GarantiasAvalesInsertar(String conexion, String conexionBitacora, GarantiasAvalesEntidad _avales, BitacorasEntidad _bitacora);
        GarantiasAvalesEntidad GarantiasAvalesConsultarDetalle(String conexion, String conexionBitacora, GarantiasAvalesEntidad _avales, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasAvalesModificar(String conexion, String conexionBitacora, GarantiasAvalesEntidad _avales, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasAvalesEliminar(String conexion, String conexionBitacora, GarantiasAvalesEntidad _avales, BitacorasEntidad _bitacora);
        
        #endregion

        #region FIDUCIARIAS

        RespuestaEntidad GarantiasFiduciariasInsertar(String conexion, String conexionBitacora, GarantiasFiduciariasEntidad _fiduciaria, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasFiduciariasModificar(String conexion, String conexionBitacora, GarantiasFiduciariasEntidad _fiduciaria, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasFiduciariasEliminar(String conexion, String conexionBitacora, GarantiasFiduciariasEntidad _fiduciaria, BitacorasEntidad _bitacora);
        List<GarantiasFiduciariasEntidad> GarantiasFiduciariasConsultar(String conexion, ParametrosConsultaEntidad entidad);
        GarantiasFiduciariasEntidad GarantiasFiduciariasConsultarDetalle(String conexion, String conexionBitacora, GarantiasFiduciariasEntidad _fiduciaria, BitacorasEntidad _bitacora);
        int GarantiasFiduciariasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        #region FIDEICOMISO

        RespuestaEntidad GarantiasFideicomisosValidar(String conexion, String conexionBitacora, GarantiasFideicomisosEntidad _fideicomisos, BitacorasEntidad _bitacora);
        GarantiasFideicomisosEntidad GarantiasFideicomisosConsultarDetalle(String conexion, String conexionBitacora, GarantiasFideicomisosEntidad _fideicomisos, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasFideicomisosModificar(String conexion, String conexionBitacora, GarantiasFideicomisosEntidad _entidad, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasFideicomisosInsertar(String conexion, String conexionBitacora, GarantiasFideicomisosEntidad _, BitacorasEntidad _bitacora);
        
        #region PRIORIDADES

        RespuestaEntidad GarantiasFideicomisosPrioridadesInsertar(String conexion, String conexionBitacora, GarantiasFideicomisosPrioridadesEntidad _fidecomisos, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasFideicomisosPrioridadesModificar(String conexion, String conexionBitacora, GarantiasFideicomisosPrioridadesEntidad _fidecomisos, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasFideicomisosPrioridadesEliminar(String conexion, String conexionBitacora, GarantiasFideicomisosPrioridadesEntidad _fidecomisos, BitacorasEntidad _bitacora);
        List<GarantiasFideicomisosPrioridadesEntidad> GarantiasFideicomisosPrioridadesConsultar(String conexion, ParametrosConsultaEntidad entidad);
        GarantiasFideicomisosPrioridadesEntidad GarantiasFideicomisosPrioridadesConsultarDetalle(String conexion, String conexionBitacora, GarantiasFideicomisosPrioridadesEntidad _fidecomisos, BitacorasEntidad _bitacora);
        List<GarantiasFideicomisosPrioridadesEntidad> GarantiasFideicomisosPrioridadesConsultarGridInterno(String conexion, GarantiasFideicomisosPrioridadesEntidad entidad);        
        int GarantiasFideicomisosPrioridadesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        #region ADJUNTOS

        RespuestaEntidad GarantiasFideicomisosArchivosInsertar(String conexion, String conexionBitacora, GarantiasFideicomisosAdjuntosEntidad _adjuntos, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasFideicomisosArchivosModificar(String conexion, String conexionBitacora, GarantiasFideicomisosAdjuntosEntidad _adjuntos, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasFideicomisosArchivosEliminar(String conexion, String conexionBitacora, GarantiasFideicomisosAdjuntosEntidad _adjuntos, BitacorasEntidad _bitacora);
        List<GarantiasFideicomisosAdjuntosEntidad> GarantiasFideicomisosArchivosConsultar(String conexion, ParametrosConsultaEntidad entidad);
        GarantiasFideicomisosAdjuntosEntidad GarantiasFideicomisosArchivosConsultarDetalle(String conexion, String conexionBitacora, GarantiasFideicomisosAdjuntosEntidad _adjuntos, BitacorasEntidad _bitacora);
        List<GarantiasFideicomisosAdjuntosEntidad> GarantiasFideicomisosArchivosConsultarGridInterno(String conexion, GarantiasFideicomisosAdjuntosEntidad entidad);
        int GarantiasFideicomisosArchivosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        #region FIDEICOMISOS FIDEICOMETIDAS

        RespuestaEntidad GarantiasFideicomisosFideicometidasInsertar(String conexion, String conexionBitacora, GarantiasFideicomisosFideicometidasEntidad fideicometida, BitacorasEntidad bitacora);
        RespuestaEntidad GarantiasFideicomisosFideicometidasInsertarTotal(String conexion, String conexionBitacora, GarantiasFideicomisosFideicometidasEntidad fideicometida, BitacorasEntidad bitacora);
        RespuestaEntidad GarantiasFideicomisosFideicometidasModificar(String conexion, String conexionBitacora, GarantiasFideicomisosFideicometidasEntidad fideicometida, BitacorasEntidad bitacora);
        RespuestaEntidad GarantiasFideicomisosFideicometidasEliminar(String conexion, String conexionBitacora, GarantiasFideicomisosFideicometidasEntidad fideicometida, BitacorasEntidad bitacora);
        GarantiasFideicomisosFideicometidasEntidad GarantiasFideicomisosFideicometidasConsultarDetalle(String conexion, String conexionBitacora, GarantiasFideicomisosFideicometidasEntidad fideicometida, BitacorasEntidad bitacora);
        List<GarantiasFideicomisosFideicometidasEntidad> GarantiasFideicomisosFideicometidasConsultarGridInterno(String conexion, GarantiasFideicomisosFideicometidasEntidad entidad);
        GarantiasRealesEntidad GarantiasFideicomisosFideicometidaGarantiasRealesBusqueda(String conexion, GarantiasRealesEntidad entidad);
        GarantiasValoresEntidad GarantiasFideicomisosFideicometidasValoresBusqueda(String conexion, GarantiasValoresEntidad entidad);
       
        #endregion

        #region FIDEICOMISOS

        RespuestaEntidad GarantiasFideicomisosEliminar(String conexion, String conexionBitacora, GarantiasFideicomisosEntidad _, BitacorasEntidad _bitacora);
        List<GarantiasFideicomisosEntidad> GarantiasFideicomisosConsultar(String conexion, ParametrosConsultaEntidad entidad);
        List<GarantiasFideicomisosEntidad> GarantiasFideicomisosConsultarGridInterno(String conexion, GarantiasFideicomisosEntidad entidad);
        int GarantiasFideicomisosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        #endregion

        #region VALORES

        RespuestaEntidad GarantiasValoresValidar(String conexion, String conexionBitacora, GarantiasValoresEntidad _entidad, BitacorasEntidad _bitacora);

        RespuestaEntidad GarantiasValoresInsertar(String conexion, String conexionBitacora, GarantiasValoresEntidad _valores, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasValoresModificar(String conexion, String conexionBitacora, GarantiasValoresEntidad _valores, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasValoresEliminar(String conexion, String conexionBitacora, GarantiasValoresEntidad _valores, BitacorasEntidad _bitacora);
        List<GarantiasValoresEntidad> GarantiasValoresConsultar(String conexion, ParametrosConsultaEntidad entidad);
        GarantiasValoresEntidad GarantiasValoresConsultarDetalle(String conexion, String conexionBitacora, GarantiasValoresEntidad _valores, BitacorasEntidad _bitacora);
        int GarantiasValoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #region REQUERIMIENTO 1-24653531 CONSULTA CDP

        String GarantiasValoresCrearTrama(String conexion, String numeroCDP);
        GarantiasValoresRespuestaISINEntidad GarantiasValoresConsultarISIN(String conexion, String valorISIN);

        #endregion

        #endregion

        #region REALES

        RespuestaEntidad GarantiasRealesInsertarGenerales(String conexion, String conexionBitacora, GarantiasRealesEntidad _reales, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasRealesEliminar(String conexion, String conexionBitacora, GarantiasRealesEntidad _reales, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasRealesValidar(String conexion, String conexionBitacora, GarantiasRealesEntidad _reales, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasRealesModificar(String conexion, String conexionBitacora, GarantiasRealesEntidad _fiduciaria, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasRealesModificarTipoBien(String conexion, String conexionBitacora, GarantiasRealesEntidad _fiduciaria, BitacorasEntidad _bitacora);
        ListaEntidad GarantiasRealesFechaVencimientoAvaluoSUGEF(String conexion, String filtro);
        List<GarantiasRealesEntidad> GarantiasRealesConsultar(String conexion, ParametrosConsultaEntidad entidad);
        GarantiasRealesEntidad GarantiasRealesConsultarDetalle(String conexion, String conexionBitacora, GarantiasRealesEntidad _reales, BitacorasEntidad _bitacora);
        int GarantiasRealesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        RespuestaEntidad GarantiasRealesTasadoresInsertar(String conexion, String conexionBitacora, GarantiasRealesTasadoresEntidad _realesTasadores, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasRealesTasadoresEliminar(String conexion, String conexionBitacora, GarantiasRealesTasadoresEntidad _realesTasadores, BitacorasEntidad _bitacora);
        List<TasadoresEntidad> GarantiasRealesTasadoresConsultar(String conexion);
        List<TasadoresEntidad> GarantiasRealesPersonasTasadorasConsultar(String conexion);
        List<GarantiasRealesTasadoresEntidad> GarantiasRealesTasadoresConsultarGridInterno(String conexion, int parametro);
        List<GarantiasRealesTasadoresEntidad> GarantiasRealesTasadoresPersonasTasadorasConsultaDetalle(String conexion, String conexionBitacora, GarantiasRealesTasadoresEntidad _realesTasadores, BitacorasEntidad _bitacora);

        RespuestaEntidad GarantiasRealesCedulasInsertar(String conexion, String conexionBitacora, GarantiasRealesCedulasEntidad _realesCedulas, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasRealesCedulasEliminar(String conexion, String conexionBitacora, GarantiasRealesCedulasEntidad _realesCedulas, BitacorasEntidad _bitacora);
        List<GarantiasRealesCedulasEntidad> GarantiasRealesCedulasConsultarGridInterno(String conexion, int parametro);
        
        //B16S01        
        String GarantiasRealesPolizaCrearTrama(String conexion, String identificacionRUC);
        List<PolizaEntidad> GarantiasRealesPolizaGridInterno(String conexion, PolizaEntidad entidad);
        RespuestaEntidad GarantiasRealesPolizaInsertar(String conexion, String conexionBitacora, PolizaEntidad entidad, BitacorasEntidad bitacora);
        RespuestaEntidad GarantiasRealesPolizaEliminar(String conexion, String conexionBitacora, PolizaEntidad entidad, BitacorasEntidad _bitacora);
        PolizaEntidad GarantiasRealesPolizaConsultaDetalle(String conexion, String conexionBitacora, PolizaEntidad entidad, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasRealesPolizaModificar(String conexion, String conexionBitacora, PolizaEntidad entidad, BitacorasEntidad _bitacora);

        #endregion

        #region OPERACIONES

        #region REQUERIMIENTO 1-24493201 INTERFAZ SICC

        List<GarantiasOperacionesEntidad> GarantiasOperacionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
        int GarantiasOperacionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
        GarantiasOperacionesClientesEntidad GarantiasOperacionesConsultaDataBridge(String conexion, String conexionSICC, GarantiasOperacionesConsultaEntidad entidad);
        RespuestaEntidad GarantiasOperacionesValidar(String conexion, String conexionBitacora, GarantiasOperacionesClientesEntidad _entidad, BitacorasEntidad _bitacora);

        List<ListaEntidad> GarantiasOperacionesTipoOperacionLista(String conexion, String _filtro);
        List<ListaEntidad> GarantiasOperacionesTipoIdentificacionLista(String conexion, String _filtro);

        #endregion

        #region INTERFAZ SIEF HISTORICO

        GarantiasOperacionesClientesEntidad GarantiasOperacionesConsultaRuc(String conexion, String conexionSief, GarantiasOperacionesClientesEntidad entidad);

        #endregion

        #region REQUERIMIENTO 1-24493227 GARANTIAS

        RespuestaEntidad GarantiasOperacionesInsertarRelacion(String conexion, String conexionBitacora, GarantiasOperacionesRelacionEntidad _entidad, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasOperacionesModificarRelacion(String conexion, String conexionBitacora, GarantiasOperacionesRelacionEntidad _entidad, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasOperacionesEliminarRelacion(String conexion, String conexionBitacora, GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora);
        GarantiasOperacionesRelacionEntidad GarantiasOperacionesConsultarRelacion(String conexion, String conexionBitacora, GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora);
        List<GarantiasOperacionesEntidad> GarantiasOperacionesConsultarGarantiasGrid(String conexion, int IdGarantiaOperacion);
        List<ListaEntidad> GarantiasOperacionesFechaVencimientoGarantia(String conexion, String _filtro);
        List<ListaEntidad> GarantiasOperacionesFechaPrescripcionGarantia(String conexion, String _filtro);
        GarantiasOperacionesRelacionEntidad OperacionesGarantiasRealesBusqueda(String conexion, GarantiasOperacionesRelacionEntidad _entidad);
        GarantiasOperacionesRelacionEntidad OperacionesGarantiasValoresBusqueda(String conexion, GarantiasOperacionesRelacionEntidad _entidad);
        GarantiasOperacionesRelacionEntidad OperacionesGarantiasFiduciariasBusqueda(String conexion, GarantiasOperacionesRelacionEntidad _entidad);
        GarantiasOperacionesRelacionEntidad OperacionesGarantiasAvalesBusqueda(String conexion, GarantiasOperacionesRelacionEntidad _entidad);

        RespuestaEntidad GarantiasOperacionesEliminar(String conexion, String conexionBitacora, GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora);
        GarantiasOperacionesEntidad GarantiasOperacionesConsultarDetalle(String conexion, String conexionBitacora, GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasOperacionesModificar(String conexion, String conexionBitacora, GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora);

        #region RQ_MANT_2016022310547690_Backlog_865

        #region RELACION GARANTIA FIDEICOMISO

        GarantiasOperacionesRelacionEntidad OperacionesGarantiasFideicomisosBusqueda(String conexion, GarantiasOperacionesRelacionEntidad _entidad);

        #endregion

        #endregion

        #endregion

        #region REQUERIMIENTO 1-24493262 REPLICAS SICC

        String GarantiasOperacionesCrearTrama(String conexion, String idGarantiaOperacion, String codAccion, String fechaPrescripcion);
        RespuestaEntidad GarantiasOperacionesEstadoReplica(String conexion, String idGarantiaOperacion, int indEstadoReplicado, String codUsuario, DateTime? fechaPrescripcionActualizada);

        #region Relacion Avales

        List<ListaEntidad> CategoriasCalificacionesTiposMitigadoresRiesgos(String conexion, String _filtro, String tipoGarantia);
        
        #endregion

        #endregion

        #endregion

        #region GRAVAMENES GARANTIAS

        List<GarantiasGravemenesEntidad> GarantiasGravamenesConsultarGridInterno(String conexion, GarantiasGravemenesEntidad entidad);
        RespuestaEntidad GarantiasGravamenesInsertar(String conexion, String conexionBitacora, GarantiasGravemenesEntidad entidad, BitacorasEntidad bitacora);
        RespuestaEntidad GarantiasGravamenesEliminar(String conexion, String conexionBitacora, GarantiasGravemenesEntidad entidad, BitacorasEntidad _bitacora);
        GarantiasGravemenesEntidad GarantiasGravamenesConsultaDetalle(String conexion, String conexionBitacora, GarantiasGravemenesEntidad entidad, BitacorasEntidad _bitacora);
        RespuestaEntidad GarantiasGravamenesModificar(String conexion, String conexionBitacora, GarantiasGravemenesEntidad entidad, BitacorasEntidad _bitacora);

        #endregion

        #region INSCRIPCION GARANTIAS REALES

        List<InscripcionGarantiasRealesEntidad> InscripcionGarantiasRealesConsultar(String conexion, ParametrosConsultaEntidad entidad);
        RespuestaEntidad InscripcionGarantiasRealesEliminar(String conexion, String conexionBitacora, InscripcionGarantiasRealesEntidad _reales, BitacorasEntidad _bitacora);
        int InscripcionGarantiasRealesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
        List<GarantiasOperacionesEntidad> InscripcionGarantiasRealesOperacionesConsultar(String conexion, GarantiasRealesEntidad entidad);
        RespuestaEntidad InscripcionGarantiasRealesInsertar(String conexion, String conexionBitacora, InscripcionGarantiasRealesEntidad _inscripcionGarantias, BitacorasEntidad _bitacora);
        InscripcionGarantiasRealesEntidad InscripcionGarantiasRealesConsultarDetalle(String conexion, String conexionBitacora, InscripcionGarantiasRealesEntidad _inscripcionGarantias, BitacorasEntidad _bitacora);
        RespuestaEntidad InscripcionGarantiasRealesModificar(String conexion, String conexionBitacora, InscripcionGarantiasRealesEntidad _inscripcionGarantias, BitacorasEntidad _bitacora);

        #endregion

        #region MOBILIARIAS GARANTIAS REALES

        List<MobiliariaGarantiasRealesEntidad> MobiliariaGarantiasRealesConsultar(String conexion, ParametrosConsultaEntidad entidad);
        RespuestaEntidad MobiliariaGarantiasRealesEliminar(String conexion, String conexionBitacora, MobiliariaGarantiasRealesEntidad _reales, BitacorasEntidad _bitacora);
        int MobiliariaGarantiasRealesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
        List<GarantiasOperacionesEntidad> MobiliariaGarantiasRealesOperacionesConsultar(String conexion, GarantiasRealesEntidad entidad);
        RespuestaEntidad MobiliariaGarantiasRealesInsertar(String conexion, String conexionBitacora, MobiliariaGarantiasRealesEntidad _mobiliariaGarantias, BitacorasEntidad _bitacora);
        MobiliariaGarantiasRealesEntidad MobiliariaGarantiasRealesConsultarDetalle(String conexion, String conexionBitacora, MobiliariaGarantiasRealesEntidad _mobiliariaGarantias, BitacorasEntidad _bitacora);
        RespuestaEntidad MobiliariaGarantiasRealesModificar(String conexion, String conexionBitacora, MobiliariaGarantiasRealesEntidad _mobiliariaGarantias, BitacorasEntidad _bitacora);

        #endregion  

    }
}
