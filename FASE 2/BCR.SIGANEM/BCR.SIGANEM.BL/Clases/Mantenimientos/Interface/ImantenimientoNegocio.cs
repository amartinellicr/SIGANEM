using System;
using System.Text;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.EN;


namespace BCR.SIGANEM.BL
{
    public interface ImantenimientoNegocio
    {

        #region ACTIVOS

            RespuestaEntidad ActivosInsertar(String conexion, String conexionBitacora, ActivosEntidad activo, BitacorasEntidad _bitacora);
            RespuestaEntidad ActivosModificar(String conexion, String conexionBitacora, ActivosEntidad activo, BitacorasEntidad _bitacora);
            RespuestaEntidad ActivosEliminar(String conexion, String conexionBitacora, ActivosEntidad activo, BitacorasEntidad _bitacora);
            List<ActivosEntidad> ActivosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            ActivosEntidad ActivosConsultarDetalle(String conexion, String conexionBitacora, ActivosEntidad activo, BitacorasEntidad _bitacora);
            Int32 ActivosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> ActivosLista(String conexion, String filtro);

        #endregion 

        #region ADMINISTRACIONES CONTENIDOS

            PantallasEntidad AdministracionesContenidosConsultaPantallas(String conexion, PantallasEntidad pantalla);    
            DataSet AdministracionesContenidosConsultaPantalla(String conexion, PantallasEntidad pantalla);
            List<NodoMenuEntidad> AdministracionesContenidosConsultaPestanas(String conexion, PantallasEntidad pantalla);
            DataSet AdministracionesContenidosConsultaPestana(String conexion, PantallasEntidad pantalla);
            List<ControlEntidad> AdministracionesContenidosConsultaControl(String conexion, PantallasEntidad pantalla);
            DataSet AdministracionesContenidosConsultaControles(String conexion, PantallasEntidad pantalla);

        #endregion 

        #region APLICABLES

            RespuestaEntidad AplicablesInsertar(String conexion, String conexionBitacora, AplicablesEntidad aplicable, BitacorasEntidad _bitacora);
            RespuestaEntidad AplicablesModificar(String conexion, String conexionBitacora, AplicablesEntidad aplicable, BitacorasEntidad _bitacora);
            RespuestaEntidad AplicablesEliminar(String conexion, String conexionBitacora, AplicablesEntidad aplicable, BitacorasEntidad _bitacora);
            List<AplicablesEntidad> AplicablesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            AplicablesEntidad AplicablesConsultarDetalle(String conexion, String conexionBitacora, AplicablesEntidad aplicable, BitacorasEntidad _bitacora);
            Int32 AplicablesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region BIENES VALORAR

            RespuestaEntidad BienesValorarInsertar(String conexion, String conexionBitacora, BienesValorarEntidad bienValorar, BitacorasEntidad _bitacora);
            RespuestaEntidad BienesValorarModificar(String conexion, String conexionBitacora, BienesValorarEntidad bienValorar, BitacorasEntidad _bitacora);
            RespuestaEntidad BienesValorarEliminar(String conexion, String conexionBitacora, BienesValorarEntidad bienValorar, BitacorasEntidad _bitacora);
            List<BienesValorarEntidad> BienesValorarConsultar(String conexion, ParametrosConsultaEntidad entidad);
            BienesValorarEntidad BienesValorarConsultarDetalle(String conexion, String conexionBitacora, BienesValorarEntidad bienValorar, BitacorasEntidad _bitacora);
            Int32 BienesValorarTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region CAJAS BREAKERS

            RespuestaEntidad CajasBreakersInsertar(String conexion, String conexionBitacora, CajasBreakersEntidad cajaBreaker, BitacorasEntidad _bitacora);
            RespuestaEntidad CajasBreakersModificar(String conexion, String conexionBitacora, CajasBreakersEntidad cajaBreaker, BitacorasEntidad _bitacora);
            RespuestaEntidad CajasBreakersEliminar(String conexion, String conexionBitacora, CajasBreakersEntidad cajaBreaker, BitacorasEntidad _bitacora);
            List<CajasBreakersEntidad> CajasBreakersConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CajasBreakersEntidad CajasBreakersConsultarDetalle(String conexion, String conexionBitacora, CajasBreakersEntidad cajaBreaker, BitacorasEntidad _bitacora);
            Int32 CajasBreakersTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        //REQUERIMIENTO: 1-24105296
        #region CALIFICACIONES EMPRESAS CALIFICADORAS

            RespuestaEntidad CalificacionesEmpresasCalificadorasInsertar(String conexion, String conexionBitacora, CalificacionesEmpresasCalificadorasEntidad entidad, BitacorasEntidad _bitacora);
            RespuestaEntidad CalificacionesEmpresasCalificadorasModificar(String conexion, String conexionBitacora, CalificacionesEmpresasCalificadorasEntidad entidad, BitacorasEntidad _bitacora);
            RespuestaEntidad CalificacionesEmpresasCalificadorasEliminar(String conexion, String conexionBitacora, CalificacionesEmpresasCalificadorasEntidad entidad, BitacorasEntidad _bitacora);
            List<CalificacionesEmpresasCalificadorasEntidad> CalificacionesEmpresasCalificadorasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CalificacionesEmpresasCalificadorasEntidad CalificacionesEmpresasCalificadorasConsultarDetalle(String conexion, String conexionBitacora, CalificacionesEmpresasCalificadorasEntidad entidad, BitacorasEntidad _bitacora);
            Int32 CalificacionesEmpresasCalificadorasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<CalificacionesEmpresasCalificadorasEntidad> CalificacionesEmpresasCalificadorasConsultarGrid(String conexion, String parametro);
            List<ListaEntidad> CalificacionesEmpresasCalificadorasCategoriaRiesgoLista(String conexion, String filtro);
            List<ListaEntidad> CalificacionesEmpresasCalificadorasCalificacionLista(String conexion, String filtro, String filtro2);

        #endregion 

        #region CANALIZACIONES ELECTRICAS

            RespuestaEntidad CanalizacionesElectricasInsertar(String conexion, String conexionBitacora, CanalizacionesElectricasEntidad canalizacionElectrica, BitacorasEntidad _bitacora);
            RespuestaEntidad CanalizacionesElectricasModificar(String conexion, String conexionBitacora, CanalizacionesElectricasEntidad canalizacionElectrica, BitacorasEntidad _bitacora);
            RespuestaEntidad CanalizacionesElectricasEliminar(String conexion, String conexionBitacora, CanalizacionesElectricasEntidad canalizacionElectrica, BitacorasEntidad _bitacora);
            List<CanalizacionesElectricasEntidad> CanalizacionesElectricasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CanalizacionesElectricasEntidad CanalizacionesElectricasConsultarDetalle(String conexion, String conexionBitacora, CanalizacionesElectricasEntidad canalizacionElectrica, BitacorasEntidad _bitacora);
            Int32 CanalizacionesElectricasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region CANOAS BAJANTES

            RespuestaEntidad CanoasBajantesInsertar(String conexion, String conexionBitacora, CanoasBajantesEntidad canoaBajante, BitacorasEntidad _bitacora);
            RespuestaEntidad CanoasBajantesModificar(String conexion, String conexionBitacora, CanoasBajantesEntidad canoaBajante, BitacorasEntidad _bitacora);
            RespuestaEntidad CanoasBajantesEliminar(String conexion, String conexionBitacora, CanoasBajantesEntidad canoaBajante, BitacorasEntidad _bitacora);
            List<CanoasBajantesEntidad> CanoasBajantesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CanoasBajantesEntidad CanoasBajantesConsultarDetalle(String conexion, String conexionBitacora, CanoasBajantesEntidad canoaBajante, BitacorasEntidad _bitacora);
            Int32 CanoasBajantesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region CANTIDADES FINCAS

            RespuestaEntidad CantidadesFincasInsertar(String conexion, String conexionBitacora, CantidadesFincasEntidad cantidadFinca, BitacorasEntidad _bitacora);
            RespuestaEntidad CantidadesFincasModificar(String conexion, String conexionBitacora, CantidadesFincasEntidad cantidadFinca, BitacorasEntidad _bitacora);
            RespuestaEntidad CantidadesFincasEliminar(String conexion, String conexionBitacora, CantidadesFincasEntidad cantidadFinca, BitacorasEntidad _bitacora);
            List<CantidadesFincasEntidad> CantidadesFincasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CantidadesFincasEntidad CantidadesFincasConsultarDetalle(String conexion, String conexionBitacora, CantidadesFincasEntidad cantidadFinca, BitacorasEntidad _bitacora);
            Int32 CantidadesFincasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region CANTONES

            RespuestaEntidad CantonesInsertar(String conexion, String conexionBitacora, CantonesEntidad canton, BitacorasEntidad _bitacora);
            RespuestaEntidad CantonesModificar(String conexion, String conexionBitacora, CantonesEntidad canton, BitacorasEntidad _bitacora);
            RespuestaEntidad CantonesEliminar(String conexion, String conexionBitacora, CantonesEntidad canton, BitacorasEntidad _bitacora);
            List<CantonesEntidad> CantonesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CantonesEntidad CantonesConsultarDetalle(String conexion, String conexionBitacora, CantonesEntidad canton, BitacorasEntidad _bitacora);
            Int32 CantonesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> CantonesLista(String conexion, String filtro);

        #endregion

        //REQUERIMIENTO: 1-24105296
        #region CARACTERISTICAS TASADORES

            RespuestaEntidad CaracteristicasTasadoresInsertar(String conexion, String conexionBitacora, CaracteristicasTasadoresEntidad entidad, BitacorasEntidad _bitacora);
            RespuestaEntidad CaracteristicasTasadoresModificar(String conexion, String conexionBitacora, CaracteristicasTasadoresEntidad entidad, BitacorasEntidad _bitacora);
            RespuestaEntidad CaracteristicasTasadoresEliminar(String conexion, String conexionBitacora, CaracteristicasTasadoresEntidad entidad, BitacorasEntidad _bitacora);
            List<CaracteristicasTasadoresEntidad> CaracteristicasTasadoresConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CaracteristicasTasadoresEntidad CaracteristicasTasadoresConsultarDetalle(String conexion, String conexionBitacora, CaracteristicasTasadoresEntidad entidad, BitacorasEntidad _bitacora);
            Int32 CaracteristicasTasadoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<CaracteristicasTasadoresEntidad> CaracteristicasTasadoresConsultarGrid(String conexion, String parametro);
            List<CaracteristicasTasadoresEntidad> CaracteristicasTasadoresConsultarGridInterno(String conexion, String parametro);

        #endregion 

        #region CATEGORIAS CALIFICACIONES

            RespuestaEntidad CategoriasCalificacionesInsertar(String conexion, String conexionBitacora, CategoriasCalificacionesEntidad categoriaCalificacion, BitacorasEntidad _bitacora);
            RespuestaEntidad CategoriasCalificacionesModificar(String conexion, String conexionBitacora, CategoriasCalificacionesEntidad categoriaCalificacion, BitacorasEntidad _bitacora);
            RespuestaEntidad CategoriasCalificacionesEliminar(String conexion, String conexionBitacora, CategoriasCalificacionesEntidad categoriaCalificacion, BitacorasEntidad _bitacora);
            List<CategoriasCalificacionesEntidad> CategoriasCalificacionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CategoriasCalificacionesEntidad CategoriasCalificacionesConsultarDetalle(String conexion, String conexionBitacora, CategoriasCalificacionesEntidad categoriaCalificacion, BitacorasEntidad _bitacora);
            Int32 CategoriasCalificacionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> CategoriasCalificacionesLista(String conexion, String filtro);

        #endregion 

        //REQUERIMIENTO 1-24653624
        #region CATEGORIAS CALIFICACIONES TIPOS MITIGADORES RIESGOS

            RespuestaEntidad CategoriasCalificacionesTiposMitigadoresRiesgosInsertar(String conexion, String conexionBitacora, CategoriasCalificacionesTiposMitigadoresRiesgosEntidad entidad, BitacorasEntidad _bitacora);
            RespuestaEntidad CategoriasCalificacionesTiposMitigadoresRiesgosEliminar(String conexion, String conexionBitacora, CategoriasCalificacionesTiposMitigadoresRiesgosEntidad entidad, BitacorasEntidad _bitacora);
            List<CategoriasCalificacionesTiposMitigadoresRiesgosEntidad> CategoriasCalificacionesTiposMitigadoresRiesgosConsultarGrid(String conexion, String filtro);
            CategoriasCalificacionesTiposMitigadoresRiesgosEntidad CategoriasCalificacionesTiposMitigadoresRiesgosConsultarDetalle(String conexion, String conexionBitacora, CategoriasCalificacionesTiposMitigadoresRiesgosEntidad entidad, BitacorasEntidad _bitacora);
    
        #endregion

        #region CATEGORIAS RIESGOS DEUDORES

            RespuestaEntidad CategoriasRiesgosDeudoresInsertar(String conexion, String conexionBitacora, CategoriasRiesgosDeudoresEntidad categoriaRiesgo, BitacorasEntidad _bitacora);
            RespuestaEntidad CategoriasRiesgosDeudoresModificar(String conexion, String conexionBitacora, CategoriasRiesgosDeudoresEntidad categoriaRiesgo, BitacorasEntidad _bitacora);
            RespuestaEntidad CategoriasRiesgosDeudoresEliminar(String conexion, String conexionBitacora, CategoriasRiesgosDeudoresEntidad categoriaRiesgo, BitacorasEntidad _bitacora);
            List<CategoriasRiesgosDeudoresEntidad> CategoriasRiesgosDeudoresConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CategoriasRiesgosDeudoresEntidad CategoriasRiesgosDeudoresConsultarDetalle(String conexion, String conexionBitacora, CategoriasRiesgosDeudoresEntidad categoriaRiesgo, BitacorasEntidad _bitacora);
            Int32 CategoriasRiesgosDeudoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 
        
        //REQUERIMIENTO: 1-24105296
        #region CATEGORIAS RIESGOS EMPRESAS CALIFICADORAS

            RespuestaEntidad CategoriasRiesgosEmpresasCalificadorasInsertar(String conexion, String conexionBitacora, CategoriasRiesgosEmpresasCalificadorasEntidad categoriaRiesgoEmpresaCalificadora, BitacorasEntidad _bitacora);
            RespuestaEntidad CategoriasRiesgosEmpresasCalificadorasModificar(String conexion, String conexionBitacora, CategoriasRiesgosEmpresasCalificadorasEntidad categoriaRiesgoEmpresaCalificadora, BitacorasEntidad _bitacora);
            RespuestaEntidad CategoriasRiesgosEmpresasCalificadorasEliminar(String conexion, String conexionBitacora, CategoriasRiesgosEmpresasCalificadorasEntidad categoriaRiesgoEmpresaCalificadora, BitacorasEntidad _bitacora);
            List<CategoriasRiesgosEmpresasCalificadorasEntidad> CategoriasRiesgosEmpresasCalificadorasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CategoriasRiesgosEmpresasCalificadorasEntidad CategoriasRiesgosEmpresasCalificadorasConsultarDetalle(String conexion, String conexionBitacora, CategoriasRiesgosEmpresasCalificadorasEntidad categoriaRiesgoEmpresaCalificadora, BitacorasEntidad _bitacora);
            int CategoriasRiesgosEmpresasCalificadorasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> CategoriasRiesgosEmpresasCalificadorasLista(String conexion, String filtro);

        #endregion 

        #region CERRAJERIAS PIEZAS SANITARIAS

            RespuestaEntidad CerrajeriasPiezasSanitariasInsertar(String conexion, String conexionBitacora, CerrajeriasPiezasSanitariasEntidad cerrajeriaPiezaSanitaria, BitacorasEntidad _bitacora);
            RespuestaEntidad CerrajeriasPiezasSanitariasModificar(String conexion, String conexionBitacora, CerrajeriasPiezasSanitariasEntidad cerrajeriaPiezaSanitaria, BitacorasEntidad _bitacora);
            RespuestaEntidad CerrajeriasPiezasSanitariasEliminar(String conexion, String conexionBitacora, CerrajeriasPiezasSanitariasEntidad cerrajeriaPiezaSanitaria, BitacorasEntidad _bitacora);
            List<CerrajeriasPiezasSanitariasEntidad> CerrajeriasPiezasSanitariasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CerrajeriasPiezasSanitariasEntidad CerrajeriasPiezasSanitariasConsultarDetalle(String conexion, String conexionBitacora, CerrajeriasPiezasSanitariasEntidad cerrajeriaPiezaSanitaria, BitacorasEntidad _bitacora);
            Int32 CerrajeriasPiezasSanitariasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region CIELOS RASOS

            RespuestaEntidad CielosRasosInsertar(String conexion, String conexionBitacora, CielosRasosEntidad cieloRaso, BitacorasEntidad _bitacora);
            RespuestaEntidad CielosRasosModificar(String conexion, String conexionBitacora, CielosRasosEntidad cieloRaso, BitacorasEntidad _bitacora);
            RespuestaEntidad CielosRasosEliminar(String conexion, String conexionBitacora, CielosRasosEntidad cieloRaso, BitacorasEntidad _bitacora);
            List<CielosRasosEntidad> CielosRasosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CielosRasosEntidad CielosRasosConsultarDetalle(String conexion, String conexionBitacora, CielosRasosEntidad cieloRaso, BitacorasEntidad _bitacora);
            Int32 CielosRasosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region CLASES AERONAVES

            RespuestaEntidad ClasesAeronavesInsertar(String conexion, String conexionBitacora, ClasesAeronavesEntidad claseAeronave, BitacorasEntidad _bitacora);
            RespuestaEntidad ClasesAeronavesModificar(String conexion, String conexionBitacora, ClasesAeronavesEntidad claseAeronave, BitacorasEntidad _bitacora);
            RespuestaEntidad ClasesAeronavesEliminar(String conexion, String conexionBitacora, ClasesAeronavesEntidad claseAeronave, BitacorasEntidad _bitacora);
            List<ClasesAeronavesEntidad> ClasesAeronavesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            ClasesAeronavesEntidad ClasesAeronavesConsultarDetalle(String conexion, String conexionBitacora, ClasesAeronavesEntidad claseAeronave, BitacorasEntidad _bitacora);
            Int32 ClasesAeronavesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> ClasesAeronavesLista(String conexion, String filtro);

        #endregion 

        #region CLASES BUQUES

            RespuestaEntidad ClasesBuquesInsertar(String conexion, String conexionBitacora, ClasesBuquesEntidad claseBuque, BitacorasEntidad _bitacora);
            RespuestaEntidad ClasesBuquesModificar(String conexion, String conexionBitacora, ClasesBuquesEntidad claseBuque, BitacorasEntidad _bitacora);
            RespuestaEntidad ClasesBuquesEliminar(String conexion, String conexionBitacora, ClasesBuquesEntidad claseBuque, BitacorasEntidad _bitacora);
            List<ClasesBuquesEntidad> ClasesBuquesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            ClasesBuquesEntidad ClasesBuquesConsultarDetalle(String conexion, String conexionBitacora, ClasesBuquesEntidad claseBuque, BitacorasEntidad _bitacora);
            Int32 ClasesBuquesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> ClasesBuquesLista(String conexion, String filtro);

        #endregion

        //REQUERIMIENTO: 1-24493227
        #region CLASES GARANTIAS PRT17

            RespuestaEntidad ClasesGarantiasPrt17Insertar(String conexion, String conexionBitacora, ClasesGarantiasPrt17Entidad claseGarantiaPrt17, BitacorasEntidad _bitacora);
            RespuestaEntidad ClasesGarantiasPrt17Modificar(String conexion, String conexionBitacora, ClasesGarantiasPrt17Entidad claseGarantiaPrt17, BitacorasEntidad _bitacora);
            RespuestaEntidad ClasesGarantiasPrt17Eliminar(String conexion, String conexionBitacora, ClasesGarantiasPrt17Entidad claseGarantiaPrt17, BitacorasEntidad _bitacora);
            List<ClasesGarantiasPrt17Entidad> ClasesGarantiasPrt17Consultar(String conexion, ParametrosConsultaEntidad entidad);
            ClasesGarantiasPrt17Entidad ClasesGarantiasPrt17ConsultarDetalle(String conexion, String conexionBitacora, ClasesGarantiasPrt17Entidad claseGarantiaPrt17, BitacorasEntidad _bitacora);
            Int32 ClasesGarantiasPrt17TotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> ClasesGarantiasPRT17Lista(String conexion, String filtro);

        #endregion 

        #region CLASES TIPOS BIENES

            List<ListaEntidad> ClasesTiposBienesLista(String conexion, String filtro);
            //REQUERIMIENTO: 1-24493227    
            List<ListaEntidad> ClasesTiposBienesClasesGarantiasPrt17Lista(String conexion, String idTipoBien, String codClaseTipoBien);

        #endregion

        #region CLASES VEHICULOS

            RespuestaEntidad ClasesVehiculosInsertar(String conexion, String conexionBitacora, ClasesVehiculosEntidad claseVehiculo, BitacorasEntidad _bitacora);
            RespuestaEntidad ClasesVehiculosModificar(String conexion, String conexionBitacora, ClasesVehiculosEntidad claseVehiculo, BitacorasEntidad _bitacora);
            RespuestaEntidad ClasesVehiculosEliminar(String conexion, String conexionBitacora, ClasesVehiculosEntidad claseVehiculo, BitacorasEntidad _bitacora);
            List<ClasesVehiculosEntidad> ClasesVehiculosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            ClasesVehiculosEntidad ClasesVehiculosConsultarDetalle(String conexion, String conexionBitacora, ClasesVehiculosEntidad claseVehiculo, BitacorasEntidad _bitacora);
            Int32 ClasesVehiculosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> ClasesVehiculosLista(String conexion, String filtro);
            List<ListaEntidad> ClasesVehiculosLista2(String conexion, String filtro);

        #endregion 

        #region CODIGOS DUPLICADOS

            RespuestaEntidad CodigosDuplicadosInsertar(String conexion, String conexionBitacora, CodigosDuplicadosEntidad codigoDuplicado, BitacorasEntidad _bitacora);
            RespuestaEntidad CodigosDuplicadosModificar(String conexion, String conexionBitacora, CodigosDuplicadosEntidad codigoDuplicado, BitacorasEntidad _bitacora);
            RespuestaEntidad CodigosDuplicadosEliminar(String conexion, String conexionBitacora, CodigosDuplicadosEntidad codigoDuplicado, BitacorasEntidad _bitacora);
            List<CodigosDuplicadosEntidad> CodigosDuplicadosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CodigosDuplicadosEntidad CodigosDuplicadosConsultarDetalle(String conexion, String conexionBitacora, CodigosDuplicadosEntidad codigoDuplicado, BitacorasEntidad _bitacora);
            Int32 CodigosDuplicadosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> CodigosDuplicadosLista(String conexion, String filtro);

        #endregion 

        #region CODIGOS HORIZONTALIDAD

            RespuestaEntidad CodigosHorizontalidadInsertar(String conexion, String conexionBitacora, CodigosHorizontalidadEntidad codigoHorizontalidad, BitacorasEntidad _bitacora);
            RespuestaEntidad CodigosHorizontalidadModificar(String conexion, String conexionBitacora, CodigosHorizontalidadEntidad codigoHorizontalidad, BitacorasEntidad _bitacora);
            RespuestaEntidad CodigosHorizontalidadEliminar(String conexion, String conexionBitacora, CodigosHorizontalidadEntidad codigoHorizontalidad, BitacorasEntidad _bitacora);
            List<CodigosHorizontalidadEntidad> CodigosHorizontalidadConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CodigosHorizontalidadEntidad CodigosHorizontalidadConsultarDetalle(String conexion, String conexionBitacora, CodigosHorizontalidadEntidad codigoHorizontalidad, BitacorasEntidad _bitacora);
            Int32 CodigosHorizontalidadTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> CodigosHorizontalidadLista(String conexion, String filtro);

        #endregion 

        #region COLINDANTES

            RespuestaEntidad ColindantesInsertar(String conexion, String conexionBitacora, ColindantesEntidad colindante, BitacorasEntidad _bitacora);
            RespuestaEntidad ColindantesModificar(String conexion, String conexionBitacora, ColindantesEntidad colindante, BitacorasEntidad _bitacora);
            RespuestaEntidad ColindantesEliminar(String conexion, String conexionBitacora, ColindantesEntidad colindante, BitacorasEntidad _bitacora);
            List<ColindantesEntidad> ColindantesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            ColindantesEntidad ColindantesConsultarDetalle(String conexion, String conexionBitacora, ColindantesEntidad colindante, BitacorasEntidad _bitacora);
            Int32 ColindantesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region CUBIERTAS TECHOS

            RespuestaEntidad CubiertasTechosInsertar(String conexion, String conexionBitacora, CubiertasTechosEntidad cubiertaTecho, BitacorasEntidad _bitacora);
            RespuestaEntidad CubiertasTechosModificar(String conexion, String conexionBitacora, CubiertasTechosEntidad cubiertaTecho, BitacorasEntidad _bitacora);
            RespuestaEntidad CubiertasTechosEliminar(String conexion, String conexionBitacora, CubiertasTechosEntidad cubiertaTecho, BitacorasEntidad _bitacora);
            List<CubiertasTechosEntidad> CubiertasTechosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            CubiertasTechosEntidad CubiertasTechosConsultarDetalle(String conexion, String conexionBitacora, CubiertasTechosEntidad cubiertaTecho, BitacorasEntidad _bitacora);
            Int32 CubiertasTechosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region DECISIONES

            RespuestaEntidad DecisionesInsertar(String conexion, String conexionBitacora, DecisionesEntidad decision, BitacorasEntidad _bitacora);
            RespuestaEntidad DecisionesModificar(String conexion, String conexionBitacora, DecisionesEntidad decision, BitacorasEntidad _bitacora);
            RespuestaEntidad DecisionesEliminar(String conexion, String conexionBitacora, DecisionesEntidad decision, BitacorasEntidad _bitacora);
            List<DecisionesEntidad> DecisionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            DecisionesEntidad DecisionesConsultarDetalle(String conexion, String conexionBitacora, DecisionesEntidad decision, BitacorasEntidad _bitacora);
            Int32 DecisionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region DELIMITACIONES LINDEROS

            RespuestaEntidad DelimitacionesLinderosInsertar(String conexion, String conexionBitacora, DelimitacionesLinderosEntidad delimitacionLindero, BitacorasEntidad _bitacora);
            RespuestaEntidad DelimitacionesLinderosModificar(String conexion, String conexionBitacora, DelimitacionesLinderosEntidad delimitacionLindero, BitacorasEntidad _bitacora);
            RespuestaEntidad DelimitacionesLinderosEliminar(String conexion, String conexionBitacora, DelimitacionesLinderosEntidad delimitacionLindero, BitacorasEntidad _bitacora);
            List<DelimitacionesLinderosEntidad> DelimitacionesLinderosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            DelimitacionesLinderosEntidad DelimitacionesLinderosConsultarDetalle(String conexion, String conexionBitacora, DelimitacionesLinderosEntidad delimitacionLindero, BitacorasEntidad _bitacora);
            Int32 DelimitacionesLinderosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region DERECHOS

            RespuestaEntidad DerechosInsertar(String conexion, String conexionBitacora, DerechosEntidad derecho, BitacorasEntidad _bitacora);
            RespuestaEntidad DerechosModificar(String conexion, String conexionBitacora, DerechosEntidad derecho, BitacorasEntidad _bitacora);
            RespuestaEntidad DerechosEliminar(String conexion, String conexionBitacora, DerechosEntidad derecho, BitacorasEntidad _bitacora);
            List<DerechosEntidad> DerechosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            DerechosEntidad DerechosConsultarDetalle(String conexion, String conexionBitacora, DerechosEntidad derecho, BitacorasEntidad _bitacora);
            Int32 DerechosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        //REQUERIMIENTO: 1-24105296
        #region DISTRIBUCIÓN ZONAS TASADORES

            RespuestaEntidad DistribucionZonasTasadoresInsertar(String conexion, String conexionBitacora, DistribucionesZonasTasadoresEntidad DistribucionesZonasTasadores, BitacorasEntidad _bitacora);
            RespuestaEntidad DistribucionZonasTasadoresModificar(String conexion, String conexionBitacora, DistribucionesZonasTasadoresEntidad DistribucionesZonasTasadores, BitacorasEntidad _bitacora);
            RespuestaEntidad DistribucionZonasTasadoresEliminar(String conexion, String conexionBitacora, DistribucionesZonasTasadoresEntidad DistribucionesZonasTasadores, BitacorasEntidad _bitacora);
            List<DistribucionesZonasTasadoresEntidad> DistribucionZonasTasadoresConsultar(String conexion, ParametrosConsultaEntidad entidad, string _zona);
            DistribucionesZonasTasadoresEntidad DistribucionZonasTasadoresConsultarDetalle(String conexion, String conexionBitacora, DistribucionesZonasTasadoresEntidad DistribucionesZonasTasadores, BitacorasEntidad _bitacora);
            int DistribucionZonasTasadoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad, string _zona);

        #endregion 

        #region DISTRITOS

            RespuestaEntidad DistritosInsertar(String conexion, String conexionBitacora, DistritosEntidad distrito, BitacorasEntidad _bitacora);
            RespuestaEntidad DistritosModificar(String conexion, String conexionBitacora, DistritosEntidad distrito, BitacorasEntidad _bitacora);
            RespuestaEntidad DistritosEliminar(String conexion, String conexionBitacora, DistritosEntidad distrito, BitacorasEntidad _bitacora);
            List<DistritosEntidad> DistritosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            DistritosEntidad DistritosConsultarDetalle(String conexion, String conexionBitacora, DistritosEntidad distrito, BitacorasEntidad _bitacora);
            Int32 DistritosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> DistritosLista(String conexion, String filtro);

        #endregion 

        #region EMISIONES INSTRUMENTOS

            RespuestaEntidad EmisionesInstrumentosInsertar(String conexion, String conexionBitacora, EmisionesInstrumentosEntidad emisionInstrumento, BitacorasEntidad _bitacora);
            RespuestaEntidad EmisionesInstrumentosModificar(String conexion, String conexionBitacora, EmisionesInstrumentosEntidad emisionInstrumento, BitacorasEntidad _bitacora);
            RespuestaEntidad EmisionesInstrumentosEliminar(String conexion, String conexionBitacora, EmisionesInstrumentosEntidad emisionInstrumento, BitacorasEntidad _bitacora);
            List<EmisionesInstrumentosEntidad> EmisionesInstrumentosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EmisionesInstrumentosEntidad EmisionesInstrumentosConsultarDetalle(String conexion, String conexionBitacora, EmisionesInstrumentosEntidad emisionInstrumento, BitacorasEntidad _bitacora);
            Int32 EmisionesInstrumentosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> EmisionesInstrumentosEmisorLista(String conexion, String filtro);
            List<ListaEntidad> EmisionesInstrumentosISINLista(String conexion, String idInstrumento, String idEmisor);
            List<ListaEntidad> EmisionesInstrumentosSerieLista(String conexion, String idInstrumento, String idEmisor, String ISIN);
            List<ListaEntidad> EmisionesInstrumentosTipoClasificacionPremioLista(String conexion, String idInstrumento, String idEmisor, String ISIN, String serie);
            List<ListaEntidad> EmisionesInstrumentosFechaVencimientoLista(String conexion, String idInstrumento, String idEmisor, String ISIN, String serie, String premio);
            List<ListaEntidad> EmisionesInstrumentosMonedaLista(String conexion, String idInstrumento, String idEmisor, String ISIN, String serie, String idClasificacionInstrumento);

        #endregion 

        #region EMISORES

            RespuestaEntidad EmisoresInsertar(String conexion, String conexionBitacora, EmisoresEntidad emisor, BitacorasEntidad _bitacora);
            RespuestaEntidad EmisoresModificar(String conexion, String conexionBitacora, EmisoresEntidad emisor, BitacorasEntidad _bitacora);
            RespuestaEntidad EmisoresEliminar(String conexion, String conexionBitacora, EmisoresEntidad emisor, BitacorasEntidad _bitacora);
            List<EmisoresEntidad> EmisoresConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EmisoresEntidad EmisoresConsultarDetalle(String conexion, String conexionBitacora, EmisoresEntidad emisor, BitacorasEntidad _bitacora);
            Int32 EmisoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> EmisoresLista(String conexion, String filtro);

        #endregion 

        //REQUERIMIENTO: 1-24105296
        #region EMPRESAS CALIFICADORAS

            RespuestaEntidad EmpresasCalificadorasInsertar(String conexion, String conexionBitacora, EmpresasCalificadorasEntidad activo, BitacorasEntidad _bitacora);
            RespuestaEntidad EmpresasCalificadorasModificar(String conexion, String conexionBitacora, EmpresasCalificadorasEntidad activo, BitacorasEntidad _bitacora);
            RespuestaEntidad EmpresasCalificadorasEliminar(String conexion, String conexionBitacora, EmpresasCalificadorasEntidad activo, BitacorasEntidad _bitacora);
            List<EmpresasCalificadorasEntidad> EmpresasCalificadorasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EmpresasCalificadorasEntidad EmpresasCalificadorasConsultarDetalle(String conexion, String conexionBitacora, EmpresasCalificadorasEntidad activo, BitacorasEntidad _bitacora);
            Int32 EmpresasCalificadorasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> EmpresasCalificadorasLista(String conexion, String filtro);

        #endregion 
        
        //REQUERIMIENTO: 1-24105296
        #region EMPRESAS TASADORAS

            RespuestaEntidad EmpresasTasadorasInsertar(String conexion, String conexionBitacora, TasadoresEntidad tasador, BitacorasEntidad _bitacora);
            RespuestaEntidad EmpresasTasadorasModificar(String conexion, String conexionBitacora, TasadoresEntidad tasador, BitacorasEntidad _bitacora);
            RespuestaEntidad EmpresasTasadorasEliminar(String conexion, String conexionBitacora, TasadoresEntidad tasador, BitacorasEntidad _bitacora);
            List<TasadoresEntidad> EmpresasTasadorasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TasadoresEntidad EmpresasTasadorasConsultarDetalle(String conexion, String conexionBitacora, TasadoresEntidad tasador, BitacorasEntidad _bitacora);
            int EmpresasTasadorasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region ENCHAPES

            RespuestaEntidad EnchapesInsertar(String conexion, String conexionBitacora, EnchapesEntidad enchape, BitacorasEntidad _bitacora);
            RespuestaEntidad EnchapesModificar(String conexion, String conexionBitacora, EnchapesEntidad enchape, BitacorasEntidad _bitacora);
            RespuestaEntidad EnchapesEliminar(String conexion, String conexionBitacora, EnchapesEntidad enchape, BitacorasEntidad _bitacora);
            List<EnchapesEntidad> EnchapesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EnchapesEntidad EnchapesConsultarDetalle(String conexion, String conexionBitacora, EnchapesEntidad enchape, BitacorasEntidad _bitacora);
            Int32 EnchapesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region ENFOQUES

            RespuestaEntidad EnfoquesInsertar(String conexion, String conexionBitacora, EnfoquesEntidad enfoque, BitacorasEntidad _bitacora);
            RespuestaEntidad EnfoquesModificar(String conexion, String conexionBitacora, EnfoquesEntidad enfoque, BitacorasEntidad _bitacora);
            RespuestaEntidad EnfoquesEliminar(String conexion, String conexionBitacora, EnfoquesEntidad enfoque, BitacorasEntidad _bitacora);
            List<EnfoquesEntidad> EnfoquesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EnfoquesEntidad EnfoquesConsultarDetalle(String conexion, String conexionBitacora, EnfoquesEntidad enfoque, BitacorasEntidad _bitacora);
            Int32 EnfoquesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region ENTIDADES

            RespuestaEntidad EntidadesInsertar(String conexion, String conexionBitacora, EntidadesEntidad entidad, BitacorasEntidad _bitacora);
            RespuestaEntidad EntidadesModificar(String conexion, String conexionBitacora, EntidadesEntidad entidad, BitacorasEntidad _bitacora);
            RespuestaEntidad EntidadesEliminar(String conexion, String conexionBitacora, EntidadesEntidad entidad, BitacorasEntidad _bitacora);
            List<EntidadesEntidad> EntidadesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EntidadesEntidad EntidadesConsultarDetalle(String conexion, String conexionBitacora, EntidadesEntidad entidad, BitacorasEntidad _bitacora);
            Int32 EntidadesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region ENTREPISOS

            RespuestaEntidad EntrepisosInsertar(String conexion, String conexionBitacora, EntrepisosEntidad entrepiso, BitacorasEntidad _bitacora);
            RespuestaEntidad EntrepisosModificar(String conexion, String conexionBitacora, EntrepisosEntidad entrepiso, BitacorasEntidad _bitacora);
            RespuestaEntidad EntrepisosEliminar(String conexion, String conexionBitacora, EntrepisosEntidad entrepiso, BitacorasEntidad _bitacora);
            List<EntrepisosEntidad> EntrepisosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EntrepisosEntidad EntrepisosConsultarDetalle(String conexion, String conexionBitacora, EntrepisosEntidad entrepiso, BitacorasEntidad _bitacora);
            Int32 EntrepisosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region ESCALERAS

            RespuestaEntidad EscalerasInsertar(String conexion, String conexionBitacora, EscalerasEntidad escalera, BitacorasEntidad _bitacora);
            RespuestaEntidad EscalerasModificar(String conexion, String conexionBitacora, EscalerasEntidad escalera, BitacorasEntidad _bitacora);
            RespuestaEntidad EscalerasEliminar(String conexion, String conexionBitacora, EscalerasEntidad escalera, BitacorasEntidad _bitacora);
            List<EscalerasEntidad> EscalerasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EscalerasEntidad EscalerasConsultarDetalle(String conexion, String conexionBitacora, EscalerasEntidad escalera, BitacorasEntidad _bitacora);
            Int32 EscalerasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region ESTADOS AVALUOS

            RespuestaEntidad EstadosAvaluosInsertar(String conexion, String conexionBitacora, EstadosAvaluosEntidad estadoAvaluo, BitacorasEntidad _bitacora);
            RespuestaEntidad EstadosAvaluosModificar(String conexion, String conexionBitacora, EstadosAvaluosEntidad estadoAvaluo, BitacorasEntidad _bitacora);
            RespuestaEntidad EstadosAvaluosEliminar(String conexion, String conexionBitacora, EstadosAvaluosEntidad estadoAvaluo, BitacorasEntidad _bitacora);
            List<EstadosAvaluosEntidad> EstadosAvaluosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EstadosAvaluosEntidad EstadosAvaluosConsultarDetalle(String conexion, String conexionBitacora, EstadosAvaluosEntidad estadoAvaluo, BitacorasEntidad _bitacora);
            Int32 EstadosAvaluosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        #region ESTADOS CONSTRUCCIONES

            RespuestaEntidad EstadosConstruccionesInsertar(String conexion, String conexionBitacora, EstadosConstruccionesEntidad estadoConstruccion, BitacorasEntidad _bitacora);
            RespuestaEntidad EstadosConstruccionesModificar(String conexion, String conexionBitacora, EstadosConstruccionesEntidad estadoConstruccion, BitacorasEntidad _bitacora);
            RespuestaEntidad EstadosConstruccionesEliminar(String conexion, String conexionBitacora, EstadosConstruccionesEntidad estadoConstruccion, BitacorasEntidad _bitacora);
            List<EstadosConstruccionesEntidad> EstadosConstruccionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EstadosConstruccionesEntidad EstadosConstruccionesConsultarDetalle(String conexion, String conexionBitacora, EstadosConstruccionesEntidad estadoConstruccion, BitacorasEntidad _bitacora);
            Int32 EstadosConstruccionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region ESTADOS GARANTIAS

            List<ListaEntidad> EstadosGarantiasLista(String conexion, String filtro);

        #endregion

        #region ESTADOS INSTALACIONES ELECTRICAS

            RespuestaEntidad EstadosInstalacionesElectricasInsertar(String conexion, String conexionBitacora, EstadosInstalacionesElectricasEntidad estadoInstalacionElectrica, BitacorasEntidad _bitacora);
            RespuestaEntidad EstadosInstalacionesElectricasModificar(String conexion, String conexionBitacora, EstadosInstalacionesElectricasEntidad estadoInstalacionElectrica, BitacorasEntidad _bitacora);
            RespuestaEntidad EstadosInstalacionesElectricasEliminar(String conexion, String conexionBitacora, EstadosInstalacionesElectricasEntidad estadoInstalacionElectrica, BitacorasEntidad _bitacora);
            List<EstadosInstalacionesElectricasEntidad> EstadosInstalacionesElectricasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EstadosInstalacionesElectricasEntidad EstadosInstalacionesElectricasConsultarDetalle(String conexion, String conexionBitacora, EstadosInstalacionesElectricasEntidad estadoInstalacionElectrica, BitacorasEntidad _bitacora);
            Int32 EstadosInstalacionesElectricasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region ESTRUCTURAS TECHOS

            RespuestaEntidad EstructurasTechosInsertar(String conexion, String conexionBitacora, EstructurasTechosEntidad estructuraTecho, BitacorasEntidad _bitacora);
            RespuestaEntidad EstructurasTechosModificar(String conexion, String conexionBitacora, EstructurasTechosEntidad estructuraTecho, BitacorasEntidad _bitacora);
            RespuestaEntidad EstructurasTechosEliminar(String conexion, String conexionBitacora, EstructurasTechosEntidad estructuraTecho, BitacorasEntidad _bitacora);
            List<EstructurasTechosEntidad> EstructurasTechosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            EstructurasTechosEntidad EstructurasTechosConsultarDetalle(String conexion, String conexionBitacora, EstructurasTechosEntidad estructuraTecho, BitacorasEntidad _bitacora);
            Int32 EstructurasTechosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 
        
        //REQUERIMIENTO: 1-24105296
        #region FISCALIZADORES

            RespuestaEntidad FiscalizadoresInsertar(String conexion, String conexionBitacora, FiscalizadoresEntidad fiscalizador, BitacorasEntidad _bitacora);
            RespuestaEntidad FiscalizadoresModificar(String conexion, String conexionBitacora, FiscalizadoresEntidad fiscalizador, BitacorasEntidad _bitacora);
            RespuestaEntidad FiscalizadoresEliminar(String conexion, String conexionBitacora, FiscalizadoresEntidad fiscalizador, BitacorasEntidad _bitacora);
            List<FiscalizadoresEntidad> FiscalizadoresConsultar(String conexion, ParametrosConsultaEntidad entidad);
            FiscalizadoresEntidad FiscalizadoresConsultarDetalle(String conexion, String conexionBitacora, FiscalizadoresEntidad fiscalizador, BitacorasEntidad _bitacora);
            int FiscalizadoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region FORMAS

            RespuestaEntidad FormasInsertar(String conexion, String conexionBitacora, FormasEntidad forma, BitacorasEntidad _bitacora);
            RespuestaEntidad FormasModificar(String conexion, String conexionBitacora, FormasEntidad forma, BitacorasEntidad _bitacora);
            RespuestaEntidad FormasEliminar(String conexion, String conexionBitacora, FormasEntidad forma, BitacorasEntidad _bitacora);
            List<FormasEntidad> FormasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            FormasEntidad FormasConsultarDetalle(String conexion, String conexionBitacora, FormasEntidad forma, BitacorasEntidad _bitacora);
            Int32 FormasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region GRADOS GRAVAMENES

            RespuestaEntidad GradosGravamenesInsertar(String conexion, String conexionBitacora, GradosGravamenesEntidad gradoGravamen, BitacorasEntidad _bitacora);
            RespuestaEntidad GradosGravamenesModificar(String conexion, String conexionBitacora, GradosGravamenesEntidad gradoGravamen, BitacorasEntidad _bitacora);
            RespuestaEntidad GradosGravamenesEliminar(String conexion, String conexionBitacora, GradosGravamenesEntidad gradoGravamen, BitacorasEntidad _bitacora);
            List<GradosGravamenesEntidad> GradosGravamenesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            GradosGravamenesEntidad GradosGravamenesConsultarDetalle(String conexion, String conexionBitacora, GradosGravamenesEntidad gradoGravamen, BitacorasEntidad _bitacora);
            Int32 GradosGravamenesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> GradosGravamenesLista(String conexion, String filtro);

        #endregion 

        #region GRUPOS FINANCIEROS

            RespuestaEntidad GruposFinancierosInsertar(String conexion, String conexionBitacora, GruposFinancierosEntidad grupoFinanciero, BitacorasEntidad _bitacora);
            RespuestaEntidad GruposFinancierosModificar(String conexion, String conexionBitacora, GruposFinancierosEntidad grupoFinanciero, BitacorasEntidad _bitacora);
            RespuestaEntidad GruposFinancierosEliminar(String conexion, String conexionBitacora, GruposFinancierosEntidad grupoFinanciero, BitacorasEntidad _bitacora);
            List<GruposFinancierosEntidad> GruposFinancierosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            GruposFinancierosEntidad GruposFinancierosConsultarDetalle(String conexion, String conexionBitacora, GruposFinancierosEntidad grupoFinanciero, BitacorasEntidad _bitacora);
            Int32 GruposFinancierosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region GRUPOS RIESGOS DEUDORES

            RespuestaEntidad GruposRiesgosDeudoresInsertar(String conexion, String conexionBitacora, GruposRiesgosDeudoresEntidad grupoRiesgoDeudor, BitacorasEntidad _bitacora);
            RespuestaEntidad GruposRiesgosDeudoresModificar(String conexion, String conexionBitacora, GruposRiesgosDeudoresEntidad grupoRiesgoDeudor, BitacorasEntidad _bitacora);
            RespuestaEntidad GruposRiesgosDeudoresEliminar(String conexion, String conexionBitacora, GruposRiesgosDeudoresEntidad grupoRiesgoDeudor, BitacorasEntidad _bitacora);
            List<GruposRiesgosDeudoresEntidad> GruposRiesgosDeudoresConsultar(String conexion, ParametrosConsultaEntidad entidad);
            GruposRiesgosDeudoresEntidad GruposRiesgosDeudoresConsultarDetalle(String conexion, String conexionBitacora, GruposRiesgosDeudoresEntidad grupoRiesgoDeudor, BitacorasEntidad _bitacora);
            Int32 GruposRiesgosDeudoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region INDICACIONES AJUSTES AREAS

            RespuestaEntidad IndicacionesAjustesAreasInsertar(String conexion, String conexionBitacora, IndicacionesAjustesAreasEntidad indicacionAjuste, BitacorasEntidad _bitacora);
            RespuestaEntidad IndicacionesAjustesAreasModificar(String conexion, String conexionBitacora, IndicacionesAjustesAreasEntidad indicacionAjuste, BitacorasEntidad _bitacora);
            RespuestaEntidad IndicacionesAjustesAreasEliminar(String conexion, String conexionBitacora, IndicacionesAjustesAreasEntidad indicacionAjuste, BitacorasEntidad _bitacora);
            List<IndicacionesAjustesAreasEntidad> IndicacionesAjustesAreasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            IndicacionesAjustesAreasEntidad IndicacionesAjustesAreasConsultarDetalle(String conexion, String conexionBitacora, IndicacionesAjustesAreasEntidad indicacionAjuste, BitacorasEntidad _bitacora);
            Int32 IndicacionesAjustesAreasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region INDICADORES GENERADORES DIVISAS

            RespuestaEntidad IndicadoresGeneradoresDivisasInsertar(String conexion, String conexionBitacora, IndicadoresGeneradoresDivisasEntidad indicadorGeneradorDivisa, BitacorasEntidad _bitacora);
            RespuestaEntidad IndicadoresGeneradoresDivisasModificar(String conexion, String conexionBitacora, IndicadoresGeneradoresDivisasEntidad indicadorGeneradorDivisa, BitacorasEntidad _bitacora);
            RespuestaEntidad IndicadoresGeneradoresDivisasEliminar(String conexion, String conexionBitacora, IndicadoresGeneradoresDivisasEntidad indicadorGeneradorDivisa, BitacorasEntidad _bitacora);
            List<IndicadoresGeneradoresDivisasEntidad> IndicadoresGeneradoresDivisasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            IndicadoresGeneradoresDivisasEntidad IndicadoresGeneradoresDivisasConsultarDetalle(String conexion, String conexionBitacora, IndicadoresGeneradoresDivisasEntidad indicadorGeneradorDivisa, BitacorasEntidad _bitacora);
            Int32 IndicadoresGeneradoresDivisasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region INDICADORES MONEDAS EXTRANJERAS

            RespuestaEntidad IndicadoresMonedasExtranjerasInsertar(String conexion, String conexionBitacora, IndicadoresMonedasExtranjerasEntidad indicadorMonedaExtranjera, BitacorasEntidad _bitacora);
            RespuestaEntidad IndicadoresMonedasExtranjerasModificar(String conexion, String conexionBitacora, IndicadoresMonedasExtranjerasEntidad indicadorMonedaExtranjera, BitacorasEntidad _bitacora);
            RespuestaEntidad IndicadoresMonedasExtranjerasEliminar(String conexion, String conexionBitacora, IndicadoresMonedasExtranjerasEntidad indicadorMonedaExtranjera, BitacorasEntidad _bitacora);
            List<IndicadoresMonedasExtranjerasEntidad> IndicadoresMonedasExtranjerasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            IndicadoresMonedasExtranjerasEntidad IndicadoresMonedasExtranjerasConsultarDetalle(String conexion, String conexionBitacora, IndicadoresMonedasExtranjerasEntidad indicadorMonedaExtranjera, BitacorasEntidad _bitacora);
            Int32 IndicadoresMonedasExtranjerasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> IndicadoresMonedasExtranjerasLista(String conexion, String filtro);

        #endregion 

        #region INSTRUMENTOS

            RespuestaEntidad InstrumentosInsertar(String conexion, String conexionBitacora, InstrumentosEntidad instrumento, BitacorasEntidad _bitacora);
            RespuestaEntidad InstrumentosModificar(String conexion, String conexionBitacora, InstrumentosEntidad instrumento, BitacorasEntidad _bitacora);
            RespuestaEntidad InstrumentosEliminar(String conexion, String conexionBitacora, InstrumentosEntidad instrumento, BitacorasEntidad _bitacora);
            List<InstrumentosEntidad> InstrumentosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            InstrumentosEntidad InstrumentosConsultarDetalle(String conexion, String conexionBitacora, InstrumentosEntidad instrumento, BitacorasEntidad _bitacora);
            Int32 InstrumentosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> InstrumentosLista(String conexion, String filtro);
            List<ListaEntidad> InstrumentosFiltradoLista(String conexion, String filtro);
            List<ListaEntidad> InstrumentosEmisionesFiltradoLista(String conexion, String filtro);
            List<ListaEntidad> InstrumentosTipoInstrumentoLista(String conexion, String filtro);

        #endregion

        #region INTERRUPTORES INSTALACIONES ELECTRICAS

            RespuestaEntidad InterruptoresInstalacionesElectricasInsertar(String conexion, String conexionBitacora, InterruptoresInstalacionesElectricasEntidad interruptorInstalacionElectrica, BitacorasEntidad _bitacora);
            RespuestaEntidad InterruptoresInstalacionesElectricasModificar(String conexion, String conexionBitacora, InterruptoresInstalacionesElectricasEntidad interruptorInstalacionElectrica, BitacorasEntidad _bitacora);
            RespuestaEntidad InterruptoresInstalacionesElectricasEliminar(String conexion, String conexionBitacora, InterruptoresInstalacionesElectricasEntidad interruptorInstalacionElectrica, BitacorasEntidad _bitacora);
            List<InterruptoresInstalacionesElectricasEntidad> InterruptoresInstalacionesElectricasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            InterruptoresInstalacionesElectricasEntidad InterruptoresInstalacionesElectricasConsultarDetalle(String conexion, String conexionBitacora, InterruptoresInstalacionesElectricasEntidad interruptorInstalacionElectrica, BitacorasEntidad _bitacora);
            Int32 InterruptoresInstalacionesElectricasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region LOTES SEGREGADOS

            RespuestaEntidad LotesSegregadosInsertar(String conexion, String conexionBitacora, LotesSegregadosEntidad loteSegregado, BitacorasEntidad _bitacora);
            RespuestaEntidad LotesSegregadosModificar(String conexion, String conexionBitacora, LotesSegregadosEntidad loteSegregado, BitacorasEntidad _bitacora);
            RespuestaEntidad LotesSegregadosEliminar(String conexion, String conexionBitacora, LotesSegregadosEntidad loteSegregado, BitacorasEntidad _bitacora);
            List<LotesSegregadosEntidad> LotesSegregadosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            LotesSegregadosEntidad LotesSegregadosConsultarDetalle(String conexion, String conexionBitacora, LotesSegregadosEntidad loteSegregado, BitacorasEntidad _bitacora);
            Int32 LotesSegregadosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region MATERIALES CONSTRUCCIONES PREDOMINANTES

            RespuestaEntidad MaterialesConstruccionesPredominantesInsertar(String conexion, String conexionBitacora, MaterialesConstruccionesPredominantesEntidad materialConstruccionPredominante, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesConstruccionesPredominantesModificar(String conexion, String conexionBitacora, MaterialesConstruccionesPredominantesEntidad materialConstruccionPredominante, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesConstruccionesPredominantesEliminar(String conexion, String conexionBitacora, MaterialesConstruccionesPredominantesEntidad materialConstruccionPredominante, BitacorasEntidad _bitacora);
            List<MaterialesConstruccionesPredominantesEntidad> MaterialesConstruccionesPredominantesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            MaterialesConstruccionesPredominantesEntidad MaterialesConstruccionesPredominantesConsultarDetalle(String conexion, String conexionBitacora, MaterialesConstruccionesPredominantesEntidad materialConstruccionPredominante, BitacorasEntidad _bitacora);
            Int32 MaterialesConstruccionesPredominantesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region MATERIALES EXTERNOS INTERNOS

            RespuestaEntidad MaterialesParedesExternasInternasInsertar(String conexion, String conexionBitacora, MaterialesExternosInternosEntidad materialExternoInterno, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesParedesExternasInternasModificar(String conexion, String conexionBitacora, MaterialesExternosInternosEntidad materialExternoInterno, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesParedesExternasInternasEliminar(String conexion, String conexionBitacora, MaterialesExternosInternosEntidad materialExternoInterno, BitacorasEntidad _bitacora);
            List<MaterialesExternosInternosEntidad> MaterialesParedesExternasInternasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            MaterialesExternosInternosEntidad MaterialesParedesExternasInternasConsultarDetalle(String conexion, String conexionBitacora, MaterialesExternosInternosEntidad materialExternoInterno, BitacorasEntidad _bitacora);
            Int32 MaterialesParedesExternasInternasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region MATERIALES EXTERNOS TAPICHELES

            RespuestaEntidad MaterialesParedesExternasTapichelesInsertar(String conexion, String conexionBitacora, MaterialesExternosTapichelesEntidad materialExternoTapichel, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesParedesExternasTapichelesModificar(String conexion, String conexionBitacora, MaterialesExternosTapichelesEntidad materialExternoTapichel, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesParedesExternasTapichelesEliminar(String conexion, String conexionBitacora, MaterialesExternosTapichelesEntidad materialExternoTapichel, BitacorasEntidad _bitacora);
            List<MaterialesExternosTapichelesEntidad> MaterialesParedesExternasTapichelesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            MaterialesExternosTapichelesEntidad MaterialesParedesExternasTapichelesConsultarDetalle(String conexion, String conexionBitacora, MaterialesExternosTapichelesEntidad materialExternoTapichel, BitacorasEntidad _bitacora);
            Int32 MaterialesParedesExternasTapichelesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region MATERIALES PISOS

            RespuestaEntidad MaterialesPisosInsertar(String conexion, String conexionBitacora, MaterialesPisosEntidad materialPiso, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesPisosModificar(String conexion, String conexionBitacora, MaterialesPisosEntidad materialPiso, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesPisosEliminar(String conexion, String conexionBitacora, MaterialesPisosEntidad materialPiso, BitacorasEntidad _bitacora);
            List<MaterialesPisosEntidad> MaterialesPisosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            MaterialesPisosEntidad MaterialesPisosConsultarDetalle(String conexion, String conexionBitacora, MaterialesPisosEntidad materialPiso, BitacorasEntidad _bitacora);
            Int32 MaterialesPisosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region MATERIALES PUERTAS

            RespuestaEntidad MaterialesPuertasInsertar(String conexion, String conexionBitacora, MaterialesPuertasEntidad materialPuerta, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesPuertasModificar(String conexion, String conexionBitacora, MaterialesPuertasEntidad materialPuerta, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesPuertasEliminar(String conexion, String conexionBitacora, MaterialesPuertasEntidad materialPuerta, BitacorasEntidad _bitacora);
            List<MaterialesPuertasEntidad> MaterialesPuertasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            MaterialesPuertasEntidad MaterialesPuertasConsultarDetalle(String conexion, String conexionBitacora, MaterialesPuertasEntidad materialPuerta, BitacorasEntidad _bitacora);
            Int32 MaterialesPuertasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region MATERIALES VIAS ACCESO

            RespuestaEntidad MaterialesViasAccesoInsertar(String conexion, String conexionBitacora, MaterialesViasAccesoEntidad materialViaAcceso, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesViasAccesoModificar(String conexion, String conexionBitacora, MaterialesViasAccesoEntidad materialViaAcceso, BitacorasEntidad _bitacora);
            RespuestaEntidad MaterialesViasAccesoEliminar(String conexion, String conexionBitacora, MaterialesViasAccesoEntidad materialViaAcceso, BitacorasEntidad _bitacora);
            List<MaterialesViasAccesoEntidad> MaterialesViasAccesoConsultar(String conexion, ParametrosConsultaEntidad entidad);
            MaterialesViasAccesoEntidad MaterialesViasAccesoConsultarDetalle(String conexion, String conexionBitacora, MaterialesViasAccesoEntidad materialViaAcceso, BitacorasEntidad _bitacora);
            Int32 MaterialesViasAccesoTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region MONEDAS

            RespuestaEntidad MonedasInsertar(String conexion, String conexionBitacora, MonedasEntidad moneda, BitacorasEntidad _bitacora);
            RespuestaEntidad MonedasModificar(String conexion, String conexionBitacora, MonedasEntidad moneda, BitacorasEntidad _bitacora);
            RespuestaEntidad MonedasEliminar(String conexion, String conexionBitacora, MonedasEntidad moneda, BitacorasEntidad _bitacora);
            List<MonedasEntidad> MonedasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            MonedasEntidad MonedasConsultarDetalle(String conexion, String conexionBitacora, MonedasEntidad moneda, BitacorasEntidad _bitacora);
            Int32 MonedasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> MonedasLista(String conexion, String filtro);

        #endregion

        #region NIVELES SOCIOECONOMICOS

            RespuestaEntidad NivelesSocioeconomicosInsertar(String conexion, String conexionBitacora, NivelesSocioeconomicosEntidad nivelSocioeconomico, BitacorasEntidad _bitacora);
            RespuestaEntidad NivelesSocioeconomicosModificar(String conexion, String conexionBitacora, NivelesSocioeconomicosEntidad nivelSocioeconomico, BitacorasEntidad _bitacora);
            RespuestaEntidad NivelesSocioeconomicosEliminar(String conexion, String conexionBitacora, NivelesSocioeconomicosEntidad nivelSocioeconomico, BitacorasEntidad _bitacora);
            List<NivelesSocioeconomicosEntidad> NivelesSocioeconomicosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            NivelesSocioeconomicosEntidad NivelesSocioeconomicosConsultarDetalle(String conexion, String conexionBitacora, NivelesSocioeconomicosEntidad nivelSocioeconomico, BitacorasEntidad _bitacora);
            Int32 NivelesSocioeconomicosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region NIVELES TERRENOS

            RespuestaEntidad NivelesTerrenosInsertar(String conexion, String conexionBitacora, NivelesTerrenoEntidad nivelTerreno, BitacorasEntidad _bitacora);
            RespuestaEntidad NivelesTerrenosModificar(String conexion, String conexionBitacora, NivelesTerrenoEntidad nivelTerreno, BitacorasEntidad _bitacora);
            RespuestaEntidad NivelesTerrenosEliminar(String conexion, String conexionBitacora, NivelesTerrenoEntidad nivelTerreno, BitacorasEntidad _bitacora);
            List<NivelesTerrenoEntidad> NivelesTerrenosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            NivelesTerrenoEntidad NivelesTerrenosConsultarDetalle(String conexion, String conexionBitacora, NivelesTerrenoEntidad nivelTerreno, BitacorasEntidad _bitacora);
            Int32 NivelesTerrenosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 
        
        //REQUERIMIENTO: 1-24105296
        #region NOTARIOS

            RespuestaEntidad NotariosInsertar(String conexion, String conexionBitacora, NotariosEntidad notario, BitacorasEntidad _bitacora);
            RespuestaEntidad NotariosModificar(String conexion, String conexionBitacora, NotariosEntidad notario, BitacorasEntidad _bitacora);
            RespuestaEntidad NotariosEliminar(String conexion, String conexionBitacora, NotariosEntidad notario, BitacorasEntidad _bitacora);
            List<NotariosEntidad> NotariosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            NotariosEntidad NotariosConsultarDetalle(String conexion, String conexionBitacora, NotariosEntidad notario, BitacorasEntidad _bitacora);
            int NotariosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<NotariosEntidad> NotariosConsultarIdentificacion(String conexion, NotariosEntidad notario);
            

        #endregion 

        #region NUMEROS LINEAS

            RespuestaEntidad NumerosLineasInsertar(String conexion, String conexionBitacora, NumerosLineasEntidad numeroLinea, BitacorasEntidad _bitacora);
            RespuestaEntidad NumerosLineasModificar(String conexion, String conexionBitacora, NumerosLineasEntidad numeroLinea, BitacorasEntidad _bitacora);
            RespuestaEntidad NumerosLineasEliminar(String conexion, String conexionBitacora, NumerosLineasEntidad numeroLinea, BitacorasEntidad _bitacora);
            List<NumerosLineasEntidad> NumerosLineasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            NumerosLineasEntidad NumerosLineasConsultarDetalle(String conexion, String conexionBitacora, NumerosLineasEntidad numeroLinea, BitacorasEntidad _bitacora);
            Int32 NumerosLineasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        #region ORIENTACIONES

            RespuestaEntidad OrientacionesInsertar(String conexion, String conexionBitacora, OrientacionesEntidad orientacion, BitacorasEntidad _bitacora);
            RespuestaEntidad OrientacionesModificar(String conexion, String conexionBitacora, OrientacionesEntidad orientacion, BitacorasEntidad _bitacora);
            RespuestaEntidad OrientacionesEliminar(String conexion, String conexionBitacora, OrientacionesEntidad orientacion, BitacorasEntidad _bitacora);
            List<OrientacionesEntidad> OrientacionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            OrientacionesEntidad OrientacionesConsultarDetalle(String conexion, String conexionBitacora, OrientacionesEntidad orientacion, BitacorasEntidad _bitacora);
            Int32 OrientacionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region PENDIENTES

            RespuestaEntidad PendientesInsertar(String conexion, String conexionBitacora, PendientesEntidad pendiente, BitacorasEntidad _bitacora);
            RespuestaEntidad PendientesModificar(String conexion, String conexionBitacora, PendientesEntidad pendiente, BitacorasEntidad _bitacora);
            RespuestaEntidad PendientesEliminar(String conexion, String conexionBitacora, PendientesEntidad pendiente, BitacorasEntidad _bitacora);
            List<PendientesEntidad> PendientesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            PendientesEntidad PendientesConsultarDetalle(String conexion, String conexionBitacora, PendientesEntidad pendiente, BitacorasEntidad _bitacora);
            Int32 PendientesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region PINTURAS

            RespuestaEntidad PinturasInsertar(String conexion, String conexionBitacora, PinturasEntidad pintura, BitacorasEntidad _bitacora);
            RespuestaEntidad PinturasModificar(String conexion, String conexionBitacora, PinturasEntidad pintura, BitacorasEntidad _bitacora);
            RespuestaEntidad PinturasEliminar(String conexion, String conexionBitacora, PinturasEntidad pintura, BitacorasEntidad _bitacora);
            List<PinturasEntidad> PinturasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            PinturasEntidad PinturasConsultarDetalle(String conexion, String conexionBitacora, PinturasEntidad pintura, BitacorasEntidad _bitacora);
            Int32 PinturasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region PLANES INVERSIONES

            RespuestaEntidad PlanesInversionesInsertar(String conexion, String conexionBitacora, PlanesInversionesEntidad planInversion, BitacorasEntidad _bitacora);
            RespuestaEntidad PlanesInversionesModificar(String conexion, String conexionBitacora, PlanesInversionesEntidad planInversion, BitacorasEntidad _bitacora);
            RespuestaEntidad PlanesInversionesEliminar(String conexion, String conexionBitacora, PlanesInversionesEntidad planInversion, BitacorasEntidad _bitacora);
            List<PlanesInversionesEntidad> PlanesInversionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            PlanesInversionesEntidad PlanesInversionesConsultarDetalle(String conexion, String conexionBitacora, PlanesInversionesEntidad planInversion, BitacorasEntidad _bitacora);
            Int32 PlanesInversionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        //REQUERIMIENTO: 1-24105296
        #region PLAZOS CALIFICACIONES

            RespuestaEntidad PlazosCalificacionesInsertar(String conexion, String conexionBitacora, PlazosCalificacionesEntidad entidad, BitacorasEntidad _bitacora);
            RespuestaEntidad PlazosCalificacionesModificar(String conexion, String conexionBitacora, PlazosCalificacionesEntidad entidad, BitacorasEntidad _bitacora);
            RespuestaEntidad PlazosCalificacionesEliminar(String conexion, String conexionBitacora, PlazosCalificacionesEntidad entidad, BitacorasEntidad _bitacora);
            List<PlazosCalificacionesEntidad> PlazosCalificacionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            PlazosCalificacionesEntidad PlazosCalificacionesConsultarDetalle(String conexion, String conexionBitacora, PlazosCalificacionesEntidad entidad, BitacorasEntidad _bitacora);
            Int32 PlazosCalificacionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            DataSet PlazosCalificacionesLista(String conexion, String filtro);
            List<ListaEntidad> PlazosCalificacionesListas(String conexion, String filtro);
            

        #endregion 

        #region POLIZAS TIPOS

            List<ListaEntidad> PolizasTiposLista(String conexion, String filtro);

        #endregion

        #region PROVINCIAS

            RespuestaEntidad ProvinciasInsertar(String conexion, String conexionBitacora, ProvinciasEntidad provincia, BitacorasEntidad _bitacora);
            RespuestaEntidad ProvinciasModificar(String conexion, String conexionBitacora, ProvinciasEntidad provincia, BitacorasEntidad _bitacora);
            RespuestaEntidad ProvinciasEliminar(String conexion, String conexionBitacora, ProvinciasEntidad provincia, BitacorasEntidad _bitacora);
            List<ProvinciasEntidad> ProvinciasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            ProvinciasEntidad ProvinciasConsultarDetalle(String conexion, String conexionBitacora, ProvinciasEntidad provincia, BitacorasEntidad _bitacora);
            Int32 ProvinciasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> ProvinciasLista(String conexion, String filtro);

        #endregion 

        #region PUNTOS REFERENCIAS

            RespuestaEntidad PuntosReferenciasInsertar(String conexion, String conexionBitacora, PuntosReferenciasEntidad puntoReferencia, BitacorasEntidad _bitacora);
            RespuestaEntidad PuntosReferenciasModificar(String conexion, String conexionBitacora, PuntosReferenciasEntidad puntoReferencia, BitacorasEntidad _bitacora);
            RespuestaEntidad PuntosReferenciasEliminar(String conexion, String conexionBitacora, PuntosReferenciasEntidad puntoReferencia, BitacorasEntidad _bitacora);
            List<PuntosReferenciasEntidad> PuntosReferenciasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            PuntosReferenciasEntidad PuntosReferenciasConsultarDetalle(String conexion, String conexionBitacora, PuntosReferenciasEntidad puntoReferencia, BitacorasEntidad _bitacora);
            Int32 PuntosReferenciasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region REGIMENES FISCALIZACIONES

            RespuestaEntidad RegimenesFiscalizacionesInsertar(String conexion, String conexionBitacora, RegimenesFiscalizacionesEntidad regimenFiscalizacion, BitacorasEntidad _bitacora);
            RespuestaEntidad RegimenesFiscalizacionesModificar(String conexion, String conexionBitacora, RegimenesFiscalizacionesEntidad regimenFiscalizacion, BitacorasEntidad _bitacora);
            RespuestaEntidad RegimenesFiscalizacionesEliminar(String conexion, String conexionBitacora, RegimenesFiscalizacionesEntidad regimenFiscalizacion, BitacorasEntidad _bitacora);
            List<RegimenesFiscalizacionesEntidad> RegimenesFiscalizacionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            RegimenesFiscalizacionesEntidad RegimenesFiscalizacionesConsultarDetalle(String conexion, String conexionBitacora, RegimenesFiscalizacionesEntidad regimenFiscalizacion, BitacorasEntidad _bitacora);
            Int32 RegimenesFiscalizacionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> RegimenesFiscalizacionesLista(String conexion, String filtro);

        #endregion

        //REQUERIMIENTO: 1-24105296
        #region REPORTES ROLES

            RespuestaEntidad ReportesRolesInsertar(String conexion, String conexionBitacora, ReportesRolesEntidad ReporteRoles, BitacorasEntidad _bitacora);
            RespuestaEntidad ReportesRolesModificar(String conexion, String conexionBitacora, ReportesRolesEntidad ReporteRoles, BitacorasEntidad _bitacora);
            RespuestaEntidad ReportesRolesEliminar(String conexion, String conexionBitacora, ReportesRolesEntidad ReporteRoles, BitacorasEntidad _bitacora);
            List<ReportesRolesEntidad> ReportesRolesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            ReportesRolesEntidad ReportesRolesConsultarDetalle(String conexion, String conexionBitacora, ReportesRolesEntidad ReporteRoles, BitacorasEntidad _bitacora);
            int ReportesRolesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        //REQUERIMIENTO: 1-24105296
        #region REPORTES SEGUI

            RespuestaEntidad ReportesSeguiInsertar(String conexion, String conexionBitacora, ReportesSeguiEntidad ReporteSegui, BitacorasEntidad _bitacora);
            RespuestaEntidad ReportesSeguiModificar(String conexion, String conexionBitacora, ReportesSeguiEntidad ReporteSegui, BitacorasEntidad _bitacora);
            RespuestaEntidad ReportesSeguiEliminar(String conexion, String conexionBitacora, ReportesSeguiEntidad ReporteSegui, BitacorasEntidad _bitacora);
            List<ReportesSeguiEntidad> ReportesSeguiConsultar(String conexion, ParametrosConsultaEntidad entidad);
            ReportesSeguiEntidad ReportesSeguiConsultarDetalle(String conexion, String conexionBitacora, ReportesSeguiEntidad ReporteSegui, BitacorasEntidad _bitacora);
            int ReportesSeguiTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region SECCIONES

            RespuestaEntidad SeccionesInsertar(String conexion, String conexionBitacora, SeccionesEntidad seccion, BitacorasEntidad _bitacora);
            RespuestaEntidad SeccionesModificar(String conexion, String conexionBitacora, SeccionesEntidad seccion, BitacorasEntidad _bitacora);
            RespuestaEntidad SeccionesEliminar(String conexion, String conexionBitacora, SeccionesEntidad seccion, BitacorasEntidad _bitacora);
            List<SeccionesEntidad> SeccionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            SeccionesEntidad SeccionesConsultarDetalle(String conexion, String conexionBitacora, SeccionesEntidad seccion, BitacorasEntidad _bitacora);
            Int32 SeccionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        #region SISTEMAS CONSTRUCTIVOS

            RespuestaEntidad SistemasConstructivosInsertar(String conexion, String conexionBitacora, SistemasConstructivosEntidad sistemaConstructivo, BitacorasEntidad _bitacora);
            RespuestaEntidad SistemasConstructivosModificar(String conexion, String conexionBitacora, SistemasConstructivosEntidad sistemaConstructivo, BitacorasEntidad _bitacora);
            RespuestaEntidad SistemasConstructivosEliminar(String conexion, String conexionBitacora, SistemasConstructivosEntidad sistemaConstructivo, BitacorasEntidad _bitacora);
            List<SistemasConstructivosEntidad> SistemasConstructivosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            SistemasConstructivosEntidad SistemasConstructivosConsultarDetalle(String conexion, String conexionBitacora, SistemasConstructivosEntidad sistemaConstructivo, BitacorasEntidad _bitacora);
            Int32 SistemasConstructivosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region SITUACIONES

            RespuestaEntidad SituacionesInsertar(String conexion, String conexionBitacora, SituacionesEntidad situacion, BitacorasEntidad _bitacora);
            RespuestaEntidad SituacionesModificar(String conexion, String conexionBitacora, SituacionesEntidad situacion, BitacorasEntidad _bitacora);
            RespuestaEntidad SituacionesEliminar(String conexion, String conexionBitacora, SituacionesEntidad situacion, BitacorasEntidad _bitacora);
            List<SituacionesEntidad> SituacionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            SituacionesEntidad SituacionesConsultarDetalle(String conexion, String conexionBitacora, SituacionesEntidad situacion, BitacorasEntidad _bitacora);
            Int32 SituacionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region SOLICITANTES

            RespuestaEntidad SolicitantesInsertar(String conexion, String conexionBitacora, SolicitantesEntidad solicitante, BitacorasEntidad _bitacora);
            RespuestaEntidad SolicitantesModificar(String conexion, String conexionBitacora, SolicitantesEntidad solicitante, BitacorasEntidad _bitacora);
            RespuestaEntidad SolicitantesEliminar(String conexion, String conexionBitacora, SolicitantesEntidad solicitante, BitacorasEntidad _bitacora);
            List<SolicitantesEntidad> SolicitantesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            SolicitantesEntidad SolicitantesConsultarDetalle(String conexion, String conexionBitacora, SolicitantesEntidad solicitante, BitacorasEntidad _bitacora);
            Int32 SolicitantesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        //REQUERIMIENTO: 1-24105296
        #region TASADORES

            RespuestaEntidad TasadoresInsertar(String conexion, String conexionBitacora, TasadoresEntidad tasador, BitacorasEntidad _bitacora);
            RespuestaEntidad TasadoresModificar(String conexion, String conexionBitacora, TasadoresEntidad tasador, BitacorasEntidad _bitacora);
            RespuestaEntidad TasadoresEliminar(String conexion, String conexionBitacora, TasadoresEntidad tasador, BitacorasEntidad _bitacora);
            List<TasadoresEntidad> TasadoresConsultar(String conexion, ParametrosConsultaEntidad entidad);
            List<TasadoresEntidad> TasadoresConsultarInterno(String conexion, ParametrosConsultaEntidad entidad);
            TasadoresEntidad TasadoresConsultarDetalle(String conexion, String conexionBitacora, TasadoresEntidad tasador, BitacorasEntidad _bitacora);
            Int32 TasadoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            Int32 TasadoresTotalFilasInterno(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        //REQUERIMIENTO: 1-24493227
        #region TENENCIAS PRT15

            RespuestaEntidad TenenciasPRT15Insertar(String conexion, String conexionBitacora, TenenciasPrt15Entidad tenenciaPRT15, BitacorasEntidad _bitacora);
            RespuestaEntidad TenenciasPRT15Modificar(String conexion, String conexionBitacora, TenenciasPrt15Entidad tenenciaPRT15, BitacorasEntidad _bitacora);
            RespuestaEntidad TenenciasPRT15Eliminar(String conexion, String conexionBitacora, TenenciasPrt15Entidad tenenciaPRT15, BitacorasEntidad _bitacora);
            List<TenenciasPrt15Entidad> TenenciasPRT15Consultar(String conexion, ParametrosConsultaEntidad entidad);
            TenenciasPrt15Entidad TenenciasPRT15ConsultarDetalle(String conexion, String conexionBitacora, TenenciasPrt15Entidad tenenciaPRT15, BitacorasEntidad _bitacora);
            Int32 TenenciasPRT15TotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TenenciasPRT15Lista(String conexion, String filtro);

        #endregion
        //REQUERIMIENTO: 1-24493227
        #region TENENCIAS PRT17

            RespuestaEntidad TenenciasPRT17Insertar(String conexion, String conexionBitacora, TenenciasPrt17Entidad tenenciaPRT17, BitacorasEntidad _bitacora);
            RespuestaEntidad TenenciasPRT17Modificar(String conexion, String conexionBitacora, TenenciasPrt17Entidad tenenciaPRT17, BitacorasEntidad _bitacora);
            RespuestaEntidad TenenciasPRT17Eliminar(String conexion, String conexionBitacora, TenenciasPrt17Entidad tenenciaPRT17, BitacorasEntidad _bitacora);
            List<TenenciasPrt17Entidad> TenenciasPRT17Consultar(String conexion, ParametrosConsultaEntidad entidad);
            TenenciasPrt17Entidad TenenciasPRT17ConsultarDetalle(String conexion, String conexionBitacora, TenenciasPrt17Entidad tenenciaPRT17, BitacorasEntidad _bitacora);
            Int32 TenenciasPRT17TotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TenenciasPRT17Lista(String conexion, String filtro);

        #endregion

        #region TIPOS ADJUDICACIONES BIENES

            RespuestaEntidad TiposAdjudicacionesBienesInsertar(String conexion, String conexionBitacora, TiposAdjudicacionesBienesEntidad tipoAdjudicacionBien, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposAdjudicacionesBienesModificar(String conexion, String conexionBitacora, TiposAdjudicacionesBienesEntidad tipoAdjudicacionBien, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposAdjudicacionesBienesEliminar(String conexion, String conexionBitacora, TiposAdjudicacionesBienesEntidad tipoAdjudicacionBien, BitacorasEntidad _bitacora);
            List<TiposAdjudicacionesBienesEntidad> TiposAdjudicacionesBienesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposAdjudicacionesBienesEntidad TiposAdjudicacionesBienesConsultarDetalle(String conexion, String conexionBitacora, TiposAdjudicacionesBienesEntidad tipoAdjudicacionBien, BitacorasEntidad _bitacora);
            Int32 TiposAdjudicacionesBienesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        #region TIPOS ALMACENES

            List<ListaEntidad> TiposAlmacenesLista(String conexion, String filtro);

        #endregion

        #region TIPOS ASIGNACIONES CALIFICACIONES

            RespuestaEntidad TiposAsignacionesCalificacionesInsertar(String conexion, String conexionBitacora, TiposAsignacionesCalificacionesEntidad tipoAsignacionCalificacion, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposAsignacionesCalificacionesModificar(String conexion, String conexionBitacora, TiposAsignacionesCalificacionesEntidad tipoAsignacionCalificacion, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposAsignacionesCalificacionesEliminar(String conexion, String conexionBitacora, TiposAsignacionesCalificacionesEntidad tipoAsignacionCalificacion, BitacorasEntidad _bitacora);
            List<TiposAsignacionesCalificacionesEntidad> TiposAsignacionesCalificacionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposAsignacionesCalificacionesEntidad TiposAsignacionesCalificacionesConsultarDetalle(String conexion, String conexionBitacora, TiposAsignacionesCalificacionesEntidad tipoAsignacionCalificacion, BitacorasEntidad _bitacora);
            Int32 TiposAsignacionesCalificacionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposAsignacionesCalificacionesLista(String conexion, String filtro);

        #endregion

        //REQUERIMIENTO: 1-24105296

            #region TIPOS AVALES

            RespuestaEntidad TipoAvalInsertar(String conexion, String conexionBitacora, TiposAvalesEntidad tipoAval, BitacorasEntidad _bitacora);
            RespuestaEntidad TipoAvalModificar(String conexion, String conexionBitacora, TiposAvalesEntidad tipoAval, BitacorasEntidad _bitacora);
            RespuestaEntidad TipoAvalEliminar(String conexion, String conexionBitacora, TiposAvalesEntidad tipoAval, BitacorasEntidad _bitacora);
            List<TiposAvalesEntidad> TipoAvalConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposAvalesEntidad TipoAvalConsultarDetalle(String conexion, String conexionBitacora, TiposAvalesEntidad tipoAval, BitacorasEntidad _bitacora);
            Int32 TipoAvalTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TipoAvalLista(String conexion, String filtro);

            #endregion 

        #region TIPOS AVALES FIANZAS

            RespuestaEntidad TiposAvalesFianzasInsertar(String conexion, String conexionBitacora, TiposAvalesFianzasEntidad TipoAvalFianza, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposAvalesFianzasModificar(String conexion, String conexionBitacora, TiposAvalesFianzasEntidad TipoAvalFianza, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposAvalesFianzasEliminar(String conexion, String conexionBitacora, TiposAvalesFianzasEntidad TipoAvalFianza, BitacorasEntidad _bitacora);
            List<TiposAvalesFianzasEntidad> TiposAvalesFianzasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposAvalesFianzasEntidad TiposAvalesFianzasConsultarDetalle(String conexion, String conexionBitacora, TiposAvalesFianzasEntidad TipoAvalFianza, BitacorasEntidad _bitacora);
            int TiposAvalesFianzasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposAvalesFianzasLista(String conexion, String filtro);

        #endregion 

        #region TIPOS BIENES

            RespuestaEntidad TiposBienesInsertar(String conexion, String conexionBitacora, TiposBienesEntidad tipoBien, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposBienesModificar(String conexion, String conexionBitacora, TiposBienesEntidad tipoBien, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposBienesEliminar(String conexion, String conexionBitacora, TiposBienesEntidad tipoBien, BitacorasEntidad _bitacora);
            List<TiposBienesEntidad> TiposBienesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposBienesEntidad TiposBienesConsultarDetalle(String conexion, String conexionBitacora, TiposBienesEntidad tipoBien, BitacorasEntidad _bitacora);
            Int32 TiposBienesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposBienesLista(String conexion, String filtro);

        #endregion 
        
        #region TIPOS CARTERAS

            RespuestaEntidad TiposCarterasInsertar(String conexion, String conexionBitacora, TiposCarterasEntidad tipoCartera, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposCarterasModificar(String conexion, String conexionBitacora, TiposCarterasEntidad tipoCartera, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposCarterasEliminar(String conexion, String conexionBitacora, TiposCarterasEntidad tipoCartera, BitacorasEntidad _bitacora);
            List<TiposCarterasEntidad> TiposCarterasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposCarterasEntidad TiposCarterasConsultarDetalle(String conexion, String conexionBitacora, TiposCarterasEntidad tipoCartera, BitacorasEntidad _bitacora);
            Int32 TiposCarterasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region TIPOS CASOS

            RespuestaEntidad TiposCasosInsertar(String conexion, String conexionBitacora, TiposCasosEntidad tipoCaso, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposCasosModificar(String conexion, String conexionBitacora, TiposCasosEntidad tipoCaso, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposCasosEliminar(String conexion, String conexionBitacora, TiposCasosEntidad tipoCaso, BitacorasEntidad _bitacora);
            List<TiposCasosEntidad> TiposCasosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposCasosEntidad TiposCasosConsultarDetalle(String conexion, String conexionBitacora, TiposCasosEntidad tipoCaso, BitacorasEntidad _bitacora);
            Int32 TiposCasosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region TIPOS CAPACIDADES PAGOS

            RespuestaEntidad TiposCapacidadesPagosInsertar(String conexion, String conexionBitacora, TiposCapacidadesPagosEntidad tipoCapacidadPago, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposCapacidadesPagosModificar(String conexion, String conexionBitacora, TiposCapacidadesPagosEntidad tipoCapacidadPago, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposCapacidadesPagosEliminar(String conexion, String conexionBitacora, TiposCapacidadesPagosEntidad tipoCapacidadPago, BitacorasEntidad _bitacora);
            List<TiposCapacidadesPagosEntidad> TiposCapacidadesPagosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposCapacidadesPagosEntidad TiposCapacidadesPagosConsultarDetalle(String conexion, String conexionBitacora, TiposCapacidadesPagosEntidad tipoCapacidadPago, BitacorasEntidad _bitacora);
            Int32 TiposCapacidadesPagosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region TIPOS CLASIFICACIONES INSTRUMENTOS

            RespuestaEntidad TiposClasificacionesInstrumentosInsertar(String conexion, String conexionBitacora, TiposClasificacionesInstrumentosEntidad tipoCalificacionInstrumento, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposClasificacionesInstrumentosModificar(String conexion, String conexionBitacora, TiposClasificacionesInstrumentosEntidad tipoCalificacionInstrumento, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposClasificacionesInstrumentosEliminar(String conexion, String conexionBitacora, TiposClasificacionesInstrumentosEntidad tipoCalificacionInstrumento, BitacorasEntidad _bitacora);
            List<TiposClasificacionesInstrumentosEntidad> TiposClasificacionesInstrumentosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposClasificacionesInstrumentosEntidad TiposClasificacionesInstrumentosConsultarDetalle(String conexion, String conexionBitacora, TiposClasificacionesInstrumentosEntidad tipoCalificacionInstrumento, BitacorasEntidad _bitacora);
            Int32 TiposClasificacionesInstrumentosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposClasificacionesInstrumentosLista(String conexion, String filtro);
            List<ListaEntidad> TiposClasificacionesInstrumentosListaEntidad(String conexion, String filtro);

        #endregion 

        #region TIPOS COMPORTAMIENTOS PAGOS

            RespuestaEntidad TiposComportamientosPagosInsertar(String conexion, String conexionBitacora, TiposComportamientosPagosEntidad tipoComportamientoPago, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposComportamientosPagosModificar(String conexion, String conexionBitacora, TiposComportamientosPagosEntidad tipoComportamientoPago, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposComportamientosPagosEliminar(String conexion, String conexionBitacora, TiposComportamientosPagosEntidad tipoComportamientoPago, BitacorasEntidad _bitacora);
            List<TiposComportamientosPagosEntidad> TiposComportamientosPagosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposComportamientosPagosEntidad TiposComportamientosPagosConsultarDetalle(String conexion, String conexionBitacora, TiposComportamientosPagosEntidad tipoComportamientoPago, BitacorasEntidad _bitacora);
            Int32 TiposComportamientosPagosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region TIPOS CONSTRUCCIONES

            RespuestaEntidad TiposConstruccionesInsertar(String conexion, String conexionBitacora, TiposConstruccionesEntidad tipoConstruccion, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposConstruccionesModificar(String conexion, String conexionBitacora, TiposConstruccionesEntidad tipoConstruccion, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposConstruccionesEliminar(String conexion, String conexionBitacora, TiposConstruccionesEntidad tipoConstruccion, BitacorasEntidad _bitacora);
            List<TiposConstruccionesEntidad> TiposConstruccionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposConstruccionesEntidad TiposConstruccionesConsultarDetalle(String conexion, String conexionBitacora, TiposConstruccionesEntidad tipoConstruccion, BitacorasEntidad _bitacora);
            Int32 TiposConstruccionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        //REQUERIMIENTO: 1-24493227
        #region TIPOS DOCUMENTOS LEGALES

            RespuestaEntidad TiposDocumentosLegalesInsertar(String conexion, String conexionBitacora, TiposDocumentosLegalesEntidad tipoDocumentoLegal, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposDocumentosLegalesModificar(String conexion, String conexionBitacora, TiposDocumentosLegalesEntidad tipoDocumentoLegal, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposDocumentosLegalesEliminar(String conexion, String conexionBitacora, TiposDocumentosLegalesEntidad tipoDocumentoLegal, BitacorasEntidad _bitacora);
            List<TiposDocumentosLegalesEntidad> TiposDocumentosLegalesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposDocumentosLegalesEntidad TiposDocumentosLegalesConsultarDetalle(String conexion, String conexionBitacora, TiposDocumentosLegalesEntidad tipoDocumentoLegal, BitacorasEntidad _bitacora);
            Int32 TiposDocumentosLegalesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposDocumentosLegalesLista(String conexion, String filtro);

        #endregion 

        #region TIPOS ENTIDADES

            RespuestaEntidad TiposEntidadesInsertar(String conexion, String conexionBitacora, TiposEntidadesEntidad tipoEntidad, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposEntidadesModificar(String conexion, String conexionBitacora, TiposEntidadesEntidad tipoEntidad, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposEntidadesEliminar(String conexion, String conexionBitacora, TiposEntidadesEntidad tipoEntidad, BitacorasEntidad _bitacora);
            List<TiposEntidadesEntidad> TiposEntidadesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposEntidadesEntidad TiposEntidadesConsultarDetalle(String conexion, String conexionBitacora, TiposEntidadesEntidad tipoEntidad, BitacorasEntidad _bitacora);
            Int32 TiposEntidadesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposEntidadesLista(String conexion, String filtro);

        #endregion 

        #region TIPOS EMISORES

            RespuestaEntidad TiposEmisoresInsertar(String conexion, String conexionBitacora, TiposEmisoresEntidad tipoEmisor, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposEmisoresModificar(String conexion, String conexionBitacora, TiposEmisoresEntidad tipoEmisor, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposEmisoresEliminar(String conexion, String conexionBitacora, TiposEmisoresEntidad tipoEmisor, BitacorasEntidad _bitacora);
            List<TiposEmisoresEntidad> TiposEmisoresConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposEmisoresEntidad TiposEmisoresConsultarDetalle(String conexion, String conexionBitacora, TiposEmisoresEntidad tipoEmisor, BitacorasEntidad _bitacora);
            Int32 TiposEmisoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region TIPOS ESTADOS AVALUOS

            RespuestaEntidad TiposEstadosAvaluosInsertar(String conexion, String conexionBitacora, TiposEstadosAvaluosEntidad tipoEstadoAvaluo, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposEstadosAvaluosModificar(String conexion, String conexionBitacora, TiposEstadosAvaluosEntidad tipoEstadoAvaluo, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposEstadosAvaluosEliminar(String conexion, String conexionBitacora, TiposEstadosAvaluosEntidad tipoEstadoAvaluo, BitacorasEntidad _bitacora);
            List<TiposEstadosAvaluosEntidad> TiposEstadosAvaluosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposEstadosAvaluosEntidad TiposEstadosAvaluosConsultarDetalle(String conexion, String conexionBitacora, TiposEstadosAvaluosEntidad tipoEstadoAvaluo, BitacorasEntidad _bitacora);
            Int32 TiposEstadosAvaluosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposEstadosAvaluosLista(String conexion, String filtro);

        #endregion

        #region TIPOS GARANTIAS

            RespuestaEntidad TiposGarantiasInsertar(String conexion, String conexionBitacora, TiposGarantiasEntidad tipoGarantia, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposGarantiasModificar(String conexion, String conexionBitacora, TiposGarantiasEntidad tipoGarantia, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposGarantiasEliminar(String conexion, String conexionBitacora, TiposGarantiasEntidad tipoGarantia, BitacorasEntidad _bitacora);
            List<TiposGarantiasEntidad> TiposGarantiasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposGarantiasEntidad TiposGarantiasConsultarDetalle(String conexion, String conexionBitacora, TiposGarantiasEntidad tipoGarantia, BitacorasEntidad _bitacora);
            Int32 TiposGarantiasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposGarantiasLista(String conexion, String filtro);

        #endregion 
        
        #region TIPOS GRADOS

            RespuestaEntidad TiposGradosInsertar(String conexion, String conexionBitacora, TiposGradosEntidad tipoGrado, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposGradosModificar(String conexion, String conexionBitacora, TiposGradosEntidad tipoGrado, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposGradosEliminar(String conexion, String conexionBitacora, TiposGradosEntidad tipoGrado, BitacorasEntidad _bitacora);
            List<TiposGradosEntidad> TiposGradosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposGradosEntidad TiposGradosConsultarDetalle(String conexion, String conexionBitacora, TiposGradosEntidad tipoGrado, BitacorasEntidad _bitacora);
            Int32 TiposGradosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposGradosLista(String conexion, String filtro);

        #endregion 

        #region TIPOS GRUPOS FINANCIEROS

            RespuestaEntidad TiposGruposFinancierosInsertar(String conexion, String conexionBitacora, TiposGruposFinancierosEntidad tipoGrupoFinanciero, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposGruposFinancierosModificar(String conexion, String conexionBitacora, TiposGruposFinancierosEntidad tipoGrupoFinanciero, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposGruposFinancierosEliminar(String conexion, String conexionBitacora, TiposGruposFinancierosEntidad tipoGrupoFinanciero, BitacorasEntidad _bitacora);
            List<TiposGruposFinancierosEntidad> TiposGruposFinancierosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposGruposFinancierosEntidad TiposGruposFinancierosConsultarDetalle(String conexion, String conexionBitacora, TiposGruposFinancierosEntidad tipoGrupoFinanciero, BitacorasEntidad _bitacora);
            Int32 TiposGruposFinancierosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposGruposFinancierosLista(String conexion, String filtro);

        #endregion 
        
        //REQUERIMIENTO: 1-24105296
        #region TIPOS IDENTIFICACIONES RUC

            RespuestaEntidad TiposIdentificacionesRUCInsertar(String conexion, String conexionBitacora, TiposIdentificacionesRUCEntidad tipoIdentificacionRUC, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposIdentificacionesRUCModificar(String conexion, String conexionBitacora, TiposIdentificacionesRUCEntidad tipoIdentificacionRUC, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposIdentificacionesRUCEliminar(String conexion, String conexionBitacora, TiposIdentificacionesRUCEntidad tipoIdentificacionRUC, BitacorasEntidad _bitacora);
            List<TiposIdentificacionesRUCEntidad> TiposIdentificacionesRUCConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposIdentificacionesRUCEntidad TiposIdentificacionesRUCConsultarDetalle(String conexion, String conexionBitacora, TiposIdentificacionesRUCEntidad tipoIdentificacionRUC, BitacorasEntidad _bitacora);
            int TiposIdentificacionesRUCTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposIdentificacionesRUCLista(String conexion, String filtro);

        #endregion 

        #region TIPOS INDICADORES INSCRIPCIONES

            RespuestaEntidad TiposIndicadoresInscripcionesInsertar(String conexion, String conexionBitacora, TiposIndicadoresInscripcionesEntidad tipoIndicadorInscripcion, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposIndicadoresInscripcionesModificar(String conexion, String conexionBitacora, TiposIndicadoresInscripcionesEntidad tipoIndicadorInscripcion, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposIndicadoresInscripcionesEliminar(String conexion, String conexionBitacora, TiposIndicadoresInscripcionesEntidad tipoIndicadorInscripcion, BitacorasEntidad _bitacora);
            List<TiposIndicadoresInscripcionesEntidad> TiposIndicadoresInscripcionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposIndicadoresInscripcionesEntidad TiposIndicadoresInscripcionesConsultarDetalle(String conexion, String conexionBitacora, TiposIndicadoresInscripcionesEntidad tipoIndicadorInscripcion, BitacorasEntidad _bitacora);
            Int32 TiposIndicadoresInscripcionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TipoIndicadorInscripcionLista(String conexion, String _filtro);

        #endregion 

        #region TIPOS DOCUMENTOS FIDEICOMISOS

            //RespuestaEntidad TiposIndicadoresInscripcionesInsertar(String conexion, String conexionBitacora, TiposIndicadoresInscripcionesEntidad tipoIndicadorInscripcion, BitacorasEntidad _bitacora);
            //RespuestaEntidad TiposIndicadoresInscripcionesModificar(String conexion, String conexionBitacora, TiposIndicadoresInscripcionesEntidad tipoIndicadorInscripcion, BitacorasEntidad _bitacora);
            //RespuestaEntidad TiposIndicadoresInscripcionesEliminar(String conexion, String conexionBitacora, TiposIndicadoresInscripcionesEntidad tipoIndicadorInscripcion, BitacorasEntidad _bitacora);
            //List<TiposIndicadoresInscripcionesEntidad> TiposIndicadoresInscripcionesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            //TiposIndicadoresInscripcionesEntidad TiposIndicadoresInscripcionesConsultarDetalle(String conexion, String conexionBitacora, TiposIndicadoresInscripcionesEntidad tipoIndicadorInscripcion, BitacorasEntidad _bitacora);
            //Int32 TiposIndicadoresInscripcionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TipoDocumentoFideicomisoLista(String conexion, String _filtro);

            #endregion 

        #region TIPOS INGRESOS

            RespuestaEntidad TiposIngresosInsertar(String conexion, String conexionBitacora, TiposIngresosEntidad tipoIngreso, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposIngresosModificar(String conexion, String conexionBitacora, TiposIngresosEntidad tipoIngreso, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposIngresosEliminar(String conexion, String conexionBitacora, TiposIngresosEntidad tipoIngreso, BitacorasEntidad _bitacora);
            List<TiposIngresosEntidad> TiposIngresosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposIngresosEntidad TiposIngresosConsultarDetalle(String conexion, String conexionBitacora, TiposIngresosEntidad tipoIngreso, BitacorasEntidad _bitacora);
            Int32 TiposIngresosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region TIPOS INMUEBLES

            RespuestaEntidad TiposInmueblesInsertar(String conexion, String conexionBitacora, TiposInmueblesEntidad tipoInmueble, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposInmueblesModificar(String conexion, String conexionBitacora, TiposInmueblesEntidad tipoInmueble, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposInmueblesEliminar(String conexion, String conexionBitacora, TiposInmueblesEntidad tipoInmueble, BitacorasEntidad _bitacora);
            List<TiposInmueblesEntidad> TiposInmueblesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposInmueblesEntidad TiposInmueblesConsultarDetalle(String conexion, String conexionBitacora, TiposInmueblesEntidad tipoInmueble, BitacorasEntidad _bitacora);
            Int32 TiposInmueblesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region TIPOS INSTRUMENTOS

            RespuestaEntidad TiposInstrumentosInsertar(String conexion, String conexionBitacora, TiposInstrumentosEntidad tipoInstrumento, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposInstrumentosModificar(String conexion, String conexionBitacora, TiposInstrumentosEntidad tipoInstrumento, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposInstrumentosEliminar(String conexion, String conexionBitacora, TiposInstrumentosEntidad tipoInstrumento, BitacorasEntidad _bitacora);
            List<TiposInstrumentosEntidad> TiposInstrumentosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposInstrumentosEntidad TiposInstrumentosConsultarDetalle(String conexion, String conexionBitacora, TiposInstrumentosEntidad tipoInstrumento, BitacorasEntidad _bitacora);
            Int32 TiposInstrumentosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposInstrumentosLista(String conexion, String filtro);
            List<ListaEntidad> TiposInstrumentosFiltradoInstrumentosLista(String conexion, String filtro);

        #endregion

        #region TIPOS LIQUIDEZ

            RespuestaEntidad TiposLiquidezInsertar(String conexion, String conexionBitacora, TiposLiquidezEntidad tipoLiquidez, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposLiquidezModificar(String conexion, String conexionBitacora, TiposLiquidezEntidad tipoLiquidez, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposLiquidezEliminar(String conexion, String conexionBitacora, TiposLiquidezEntidad tipoLiquidez, BitacorasEntidad _bitacora);
            List<TiposLiquidezEntidad> TiposLiquidezConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposLiquidezEntidad TiposLiquidezConsultarDetalle(String conexion, String conexionBitacora, TiposLiquidezEntidad tipoLiquidez, BitacorasEntidad _bitacora);
            Int32 TiposLiquidezTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposLiquidezLista(String conexion, String filtro);

        #endregion 

        //REQUERIMIENTO: 1-24493227
        #region TIPOS MITIGADORES RIESGOS

            RespuestaEntidad TiposMitigadoresRiesgosInsertar(String conexion, String conexionBitacora, TiposMitigadoresRiesgosEntidad tipoMitigadorRiesgo, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposMitigadoresRiesgosModificar(String conexion, String conexionBitacora, TiposMitigadoresRiesgosEntidad tipoMitigadorRiesgo, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposMitigadoresRiesgosEliminar(String conexion, String conexionBitacora, TiposMitigadoresRiesgosEntidad tipoMitigadorRiesgo, BitacorasEntidad _bitacora);
            List<TiposMitigadoresRiesgosEntidad> TiposMitigadoresRiesgosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposMitigadoresRiesgosEntidad TiposMitigadoresRiesgosConsultarDetalle(String conexion, String conexionBitacora, TiposMitigadoresRiesgosEntidad tipoMitigadorRiesgo, BitacorasEntidad _bitacora);
            Int32 TiposMitigadoresRiesgosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposMitigadoresRiesgosLista(String conexion, String filtro);

        #endregion 
        
        #region TIPOS MONEDAS

            RespuestaEntidad TiposMonedasInsertar(String conexion, String conexionBitacora, TiposMonedasEntidad tipoMoneda, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposMonedasModificar(String conexion, String conexionBitacora, TiposMonedasEntidad tipoMoneda, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposMonedasEliminar(String conexion, String conexionBitacora, TiposMonedasEntidad tipoMoneda, BitacorasEntidad _bitacora);
            List<TiposMonedasEntidad> TiposMonedasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposMonedasEntidad TiposMonedasConsultarDetalle(String conexion, String conexionBitacora, TiposMonedasEntidad tipoMoneda, BitacorasEntidad _bitacora);
            Int32 TiposMonedasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposMonedasLista(String conexion, String filtro);

        #endregion 

        #region TIPOS PERSONAS

            RespuestaEntidad TiposPersonasInsertar(String conexion, String conexionBitacora, TiposPersonasEntidad tipoPersona, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposPersonasModificar(String conexion, String conexionBitacora, TiposPersonasEntidad tipoPersona, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposPersonasEliminar(String conexion, String conexionBitacora, TiposPersonasEntidad tipoPersona, BitacorasEntidad _bitacora);
            List<TiposPersonasEntidad> TiposPersonasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposPersonasEntidad TiposPersonasConsultarDetalle(String conexion, String conexionBitacora, TiposPersonasEntidad tipoPersona, BitacorasEntidad _bitacora);
            Int32 TiposPersonasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposPersonasLista(String conexion, String filtro);
            List<ListaEntidad> TiposPersonasLista123(String conexion, String filtro);

        #endregion 

        #region TIPOS POLIZAS

            RespuestaEntidad TiposPolizasInsertar(String conexion, String conexionBitacora, TiposPolizasEntidad tipoPoliza, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposPolizasModificar(String conexion, String conexionBitacora, TiposPolizasEntidad tipoPoliza, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposPolizasEliminar(String conexion, String conexionBitacora, TiposPolizasEntidad tipoPoliza, BitacorasEntidad _bitacora);
            List<TiposPolizasEntidad> TiposPolizasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposPolizasEntidad TiposPolizasConsultarDetalle(String conexion, String conexionBitacora, TiposPolizasEntidad tipoPoliza, BitacorasEntidad _bitacora);
            Int32 TiposPolizasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        //REQUERIMIENTO: 1-24105296
        #region TIPOS TASADORES

            List<ListaEntidad> TiposTasadoresLista(String conexion, String filtro);

        #endregion

        //REQUERIMIENTO: 1-24105296
        #region TIPOS SERVICIOS

            RespuestaEntidad TiposServiciosInsertar(String conexion, String conexionBitacora, TiposServiciosEntidad tipoServicio, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposServiciosModificar(String conexion, String conexionBitacora, TiposServiciosEntidad tipoServicio, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposServiciosEliminar(String conexion, String conexionBitacora, TiposServiciosEntidad tipoServicio, BitacorasEntidad _bitacora);
            List<TiposServiciosEntidad> TiposServiciosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposServiciosEntidad TiposServiciosConsultarDetalle(String conexion, String conexionBitacora, TiposServiciosEntidad tipoServicio, BitacorasEntidad _bitacora);
            Int32 TiposServiciosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
            List<ListaEntidad> TiposServiciosLista(String conexion, String filtro);

        #endregion 
        
        //REQUERIMIENTO: 1-24292751
        #region TIPOS VALORES

            List<ListaEntidad> TiposValoresLista(String conexion, String filtro);
            //REQUERIMIENTO: 1-24493227
            List<ListaEntidad> TiposValoresTenenciasTiposInstrumentosLista(String conexion, String idTipoInstrumento, String idTipoValor);

        #endregion

        #region TIPOS ZONAS

            RespuestaEntidad TiposZonasInsertar(String conexion, String conexionBitacora, TiposZonasEntidad tipoZona, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposZonasModificar(String conexion, String conexionBitacora, TiposZonasEntidad tipoZona, BitacorasEntidad _bitacora);
            RespuestaEntidad TiposZonasEliminar(String conexion, String conexionBitacora, TiposZonasEntidad tipoZona, BitacorasEntidad _bitacora);
            List<TiposZonasEntidad> TiposZonasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TiposZonasEntidad TiposZonasConsultarDetalle(String conexion, String conexionBitacora, TiposZonasEntidad tipoZona, BitacorasEntidad _bitacora);
            Int32 TiposZonasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region TOPOGRAFIAS

            RespuestaEntidad TopografiasInsertar(String conexion, String conexionBitacora, TopografiasEntidad topografia, BitacorasEntidad _bitacora);
            RespuestaEntidad TopografiasModificar(String conexion, String conexionBitacora, TopografiasEntidad topografia, BitacorasEntidad _bitacora);
            RespuestaEntidad TopografiasEliminar(String conexion, String conexionBitacora, TopografiasEntidad topografia, BitacorasEntidad _bitacora);
            List<TopografiasEntidad> TopografiasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            TopografiasEntidad TopografiasConsultarDetalle(String conexion, String conexionBitacora, TopografiasEntidad topografia, BitacorasEntidad _bitacora);
            Int32 TopografiasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion

        #region UNIDADES

            RespuestaEntidad UnidadesInsertar(String conexion, String conexionBitacora, UnidadesEntidad unidad, BitacorasEntidad _bitacora);
            RespuestaEntidad UnidadesModificar(String conexion, String conexionBitacora, UnidadesEntidad unidad, BitacorasEntidad _bitacora);
            RespuestaEntidad UnidadesEliminar(String conexion, String conexionBitacora, UnidadesEntidad unidad, BitacorasEntidad _bitacora);
            List<UnidadesEntidad> UnidadesConsultar(String conexion, ParametrosConsultaEntidad entidad);
            UnidadesEntidad UnidadesConsultarDetalle(String conexion, String conexionBitacora, UnidadesEntidad unidad, BitacorasEntidad _bitacora);
            Int32 UnidadesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region USOS SUELOS ACTUAL ENTORNOS

            RespuestaEntidad UsosSuelosActualEntornosInsertar(String conexion, String conexionBitacora, UsosSuelosActualEntornosEntidad usoSueloActualEntorno, BitacorasEntidad _bitacora);
            RespuestaEntidad UsosSuelosActualEntornosModificar(String conexion, String conexionBitacora, UsosSuelosActualEntornosEntidad usoSueloActualEntorno, BitacorasEntidad _bitacora);
            RespuestaEntidad UsosSuelosActualEntornosEliminar(String conexion, String conexionBitacora, UsosSuelosActualEntornosEntidad usoSueloActualEntorno, BitacorasEntidad _bitacora);
            List<UsosSuelosActualEntornosEntidad> UsosSuelosActualEntornosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            UsosSuelosActualEntornosEntidad UsosSuelosActualEntornosConsultarDetalle(String conexion, String conexionBitacora, UsosSuelosActualEntornosEntidad usoSueloActualEntorno, BitacorasEntidad _bitacora);
            Int32 UsosSuelosActualEntornosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region VENTANAS

            RespuestaEntidad VentanasInsertar(String conexion, String conexionBitacora, VentanasEntidad ventana, BitacorasEntidad _bitacora);
            RespuestaEntidad VentanasModificar(String conexion, String conexionBitacora, VentanasEntidad ventana, BitacorasEntidad _bitacora);
            RespuestaEntidad VentanasEliminar(String conexion, String conexionBitacora, VentanasEntidad ventana, BitacorasEntidad _bitacora);
            List<VentanasEntidad> VentanasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            VentanasEntidad VentanasConsultarDetalle(String conexion, String conexionBitacora, VentanasEntidad ventana, BitacorasEntidad _bitacora);
            Int32 VentanasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region VERJAS

            RespuestaEntidad VerjasInsertar(String conexion, String conexionBitacora, VerjasEntidad verja, BitacorasEntidad _bitacora);
            RespuestaEntidad VerjasModificar(String conexion, String conexionBitacora, VerjasEntidad verja, BitacorasEntidad _bitacora);
            RespuestaEntidad VerjasEliminar(String conexion, String conexionBitacora, VerjasEntidad verja, BitacorasEntidad _bitacora);
            List<VerjasEntidad> VerjasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            VerjasEntidad VerjasConsultarDetalle(String conexion, String conexionBitacora, VerjasEntidad verja, BitacorasEntidad _bitacora);
            Int32 VerjasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region VIAS ACCESOS

            RespuestaEntidad ViasAccesosInsertar(String conexion, String conexionBitacora, ViasAccesoEntidad viaAcceso, BitacorasEntidad _bitacora);
            RespuestaEntidad ViasAccesosModificar(String conexion, String conexionBitacora, ViasAccesoEntidad viaAcceso, BitacorasEntidad _bitacora);
            RespuestaEntidad ViasAccesosEliminar(String conexion, String conexionBitacora, ViasAccesoEntidad viaAcceso, BitacorasEntidad _bitacora);
            List<ViasAccesoEntidad> ViasAccesosConsultar(String conexion, ParametrosConsultaEntidad entidad);
            ViasAccesoEntidad ViasAccesosConsultarDetalle(String conexion, String conexionBitacora, ViasAccesoEntidad viaAcceso, BitacorasEntidad _bitacora);
            Int32 ViasAccesosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 

        #region VOLTAJES INSTALACIONES ELECTRICAS

            RespuestaEntidad VoltajesInstalacionesElectricasInsertar(String conexion, String conexionBitacora, VoltajesInstalacionesElectricasEntidad voltajeInstalacionElectrica, BitacorasEntidad _bitacora);
            RespuestaEntidad VoltajesInstalacionesElectricasModificar(String conexion, String conexionBitacora, VoltajesInstalacionesElectricasEntidad voltajeInstalacionElectrica, BitacorasEntidad _bitacora);
            RespuestaEntidad VoltajesInstalacionesElectricasEliminar(String conexion, String conexionBitacora, VoltajesInstalacionesElectricasEntidad voltajeInstalacionElectrica, BitacorasEntidad _bitacora);
            List<VoltajesInstalacionesElectricasEntidad> VoltajesInstalacionesElectricasConsultar(String conexion, ParametrosConsultaEntidad entidad);
            VoltajesInstalacionesElectricasEntidad VoltajesInstalacionesElectricasConsultarDetalle(String conexion, String conexionBitacora, VoltajesInstalacionesElectricasEntidad voltajeInstalacionElectrica, BitacorasEntidad _bitacora);
            Int32 VoltajesInstalacionesElectricasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);

        #endregion 
        
        //REQUERIMIENTO: 1-24105296
        #region ZONAS TASADORES

            RespuestaEntidad ZonasTasadoresInsertar(String conexion, String conexionBitacora, ZonasTasadoresEntidad ZonaTasador, BitacorasEntidad _bitacora);
            RespuestaEntidad ZonasTasadoresModificar(String conexion, String conexionBitacora, ZonasTasadoresEntidad ZonaTasador, BitacorasEntidad _bitacora);
            RespuestaEntidad ZonasTasadoresEliminar(String conexion, String conexionBitacora, ZonasTasadoresEntidad ZonaTasador, BitacorasEntidad _bitacora);
            List<ZonasTasadoresEntidad> ZonasTasadoresConsultar(String conexion, ParametrosConsultaEntidad entidad, string _zona);
            ZonasTasadoresEntidad ZonasTasadoresConsultarDetalle(String conexion, String conexionBitacora, ZonasTasadoresEntidad ZonaTasador, BitacorasEntidad _bitacora);
            int ZonasTasadoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad, string _zona);
            List<ListaEntidad> ZonasTasadoresLista(String conexion, String filtro);

        #endregion 
        
        //REQUERIMIENTO: 1-24493227
        #region VALORES DEFAULT 

            List<ListaEntidad> DefaultSiNoLista(String conexion, String filtro);

        #endregion
    }
}




