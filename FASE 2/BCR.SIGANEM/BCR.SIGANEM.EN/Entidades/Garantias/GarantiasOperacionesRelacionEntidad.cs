using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasOperacionesRelacionEntidad
    {

        #region PROPIEDADES

        private int _idGarantiaOperacion;
        public int IdGarantiaOperacion
        {
            get
            {
                return _idGarantiaOperacion;
            }
            set
            {
                _idGarantiaOperacion = value;
            }
        }

        private int _idOperacion;
        public int IdOperacion
        {
            get
            {
                return _idOperacion;
            }
            set
            {
                _idOperacion = value;
            }
        }

        private int _idTipoGarantia;
        public int IdTipoGarantia
        {
            get
            {
                return _idTipoGarantia;
            }
            set
            {
                _idTipoGarantia = value;
            }
        }

        #region CONSULTA GRID INTERNO

        private string _idGarantia;
        public string IdGarantia
        {
            get
            {
                return _idGarantia;
            }
            set
            {
                _idGarantia = value;
            }
        }

        private string _desTipoGarantia;
        public string DesTipoGarantia
        {
            get
            {
                return _desTipoGarantia;
            }
            set
            {
                _desTipoGarantia = value;
            }
        }

        private int _indEstadoReplicado;
        public int IndEstadoReplicado
        {
            get
            {
                return _indEstadoReplicado;
            }
            set
            {
                _indEstadoReplicado = value;
            }
        }

        #endregion

        #region GARANTIAS FIDUCIARIAS

        #region GENERAL

        private int? _idTipoIdentificacionRUC;
        public int? IdTipoIdentificacionRUC
        {
            get
            {
                return _idTipoIdentificacionRUC;
            }
            set
            {
                _idTipoIdentificacionRUC = value;
            }
        }

        private string _identificacionRUC;
        public string IdentificacionRUC
        {
            get
            {
                return _identificacionRUC;
            }
            set
            {
                _identificacionRUC = value;
            }
        }

        #endregion

        #region DETALLE

        private int? _idGarantiaFiduciaria;
        public int? IdGarantiaFiduciaria
        {
            get
            {
                return _idGarantiaFiduciaria;
            }
            set
            {
                _idGarantiaFiduciaria = value;
            }
        }

        private Decimal? _salarioNetoFiador;
        public Decimal? SalarioNetoFiador
        {
            get
            {
                return _salarioNetoFiador;
            }
            set
            {
                _salarioNetoFiador = value;
            }
        }

        private string _identificacionSICC;
        public string IdentificacionSICC
        {
            get
            {
                return _identificacionSICC;
            }
            set
            {
                _identificacionSICC = value;
            }
        }

        #endregion

        #endregion

        #region GARANTIAS VALORES

        #region GENERAL

        private int? _idTipoValor;
        public int? IdTipoValor
        {
            get
            {
                return _idTipoValor;
            }
            set
            {
                _idTipoValor = value;
            }
        }

        private int? _idTipoInstrumento;
        public int? IdTipoInstrumento
        {
            get
            {
                return _idTipoInstrumento;
            }
            set
            {
                _idTipoInstrumento = value;
            }
        }

        private int? _idInstrumento;
        public int? IdInstrumento
        {
            get
            {
                return _idInstrumento;
            }
            set
            {
                _idInstrumento = value;
            }
        }

        private int? _idEmisor;
        public int? IdEmisor
        {
            get
            {
                return _idEmisor;
            }
            set
            {
                _idEmisor = value;
            }
        }

        private string _ISIN;
        public string ISIN
        {
            get
            {
                return _ISIN;
            }
            set
            {
                _ISIN = value;
            }
        }

        private string _serie;
        public string Serie
        {
            get
            {
                return _serie;
            }
            set
            {
                _serie = value;
            }
        }

        private string _codGarantiaBCR;
        public string CodGarantiaBCR
        {
            get
            {
                return _codGarantiaBCR;
            }
            set
            {
                _codGarantiaBCR = value;
            }
        }

        #endregion

        #region DETALLE

        private int? _idGarantiaValor;
        public int? IdGarantiaValor
        {
            get
            {
                return _idGarantiaValor;
            }
            set
            {
                _idGarantiaValor = value;
            }
        }

        private string _TipoMonedaValorFacial;
        public string TipoMonedaValorFacial
        {
            get
            {
                return _TipoMonedaValorFacial;
            }
            set
            {
                _TipoMonedaValorFacial = value;
            }
        }

        private decimal? _montoValorFacial;
        public decimal? MontoValorFacial
        {
            get
            {
                return _montoValorFacial;
            }
            set
            {
                _montoValorFacial = value;
            }
        }

        #endregion

        #endregion

        #region GARANTIAS REALES

        #region GENERAL

        private int? _idTipoBien;
        public int? IdTipoBien
        {
            get
            {
                return _idTipoBien;
            }
            set
            {
                _idTipoBien = value;
            }
        }

        private int? _idClaseTipoBien;
        public int? IdClaseTipoBien
        {
            get
            {
                return _idClaseTipoBien;
            }
            set
            {
                _idClaseTipoBien = value;
            }
        }

        private int? _idProvincia;
        public int? IdProvincia
        {
            get
            {
                return _idProvincia;
            }
            set
            {
                _idProvincia = value;
            }
        }

        private int? _idCodigoHorizontalidad;
        public int? IdCodigoHorizontalidad
        {
            get
            {
                return _idCodigoHorizontalidad;
            }
            set
            {
                _idCodigoHorizontalidad = value;
            }
        }

        private int? _idCodigoDuplicado;
        public int? IdCodigoDuplicado
        {
            get
            {
                return _idCodigoDuplicado;
            }
            set
            {
                _idCodigoDuplicado = value;
            }
        }

        private int? _idClaseBuque;
        public int? IdClaseBuque
        {
            get
            {
                return _idClaseBuque;
            }
            set
            {
                _idClaseBuque = value;
            }
        }

        private int? _idClaseAeronave;
        public int? IdClaseAeronave
        {
            get
            {
                return _idClaseAeronave;
            }
            set
            {
                _idClaseAeronave = value;
            }
        }

        private int? _idClaseVehiculo;
        public int? IdClaseVehiculo
        {
            get
            {
                return _idClaseVehiculo;
            }
            set
            {
                _idClaseVehiculo = value;
            }
        }

        private int? _idFormatoIdentificacionVehiculo;
        public int? IdFormatoIdentificacionVehiculo
        {
            get
            {
                return _idFormatoIdentificacionVehiculo;
            }
            set
            {
                _idFormatoIdentificacionVehiculo = value;
            }
        }

        private string _codigoBien;
        public string CodigoBien
        {
            get
            {
                return _codigoBien;
            }
            set
            {
                _codigoBien = value;
            }
        }

        #endregion

        #region DETALLE

        private int? _idGarantiaReal;
        public int? IdGarantiaReal
        {
            get
            {
                return _idGarantiaReal;
            }
            set
            {
                _idGarantiaReal = value;
            }
        }

        private string _TipoMoneda;
        public string TipoMoneda
        {
            get
            {
                return _TipoMoneda;
            }
            set
            {
                _TipoMoneda = value;
            }
        }

        private string _TipoLiquidez;
        public string TipoLiquidez
        {
            get
            {
                return _TipoLiquidez;
            }
            set
            {
                _TipoLiquidez = value;
            }
        }

        private decimal? _montoUltimaTasacionTerreno;
        public decimal? MontoUltimaTasacionTerreno
        {
            get
            {
                return _montoUltimaTasacionTerreno;
            }
            set
            {
                _montoUltimaTasacionTerreno = value;
            }
        }

        private decimal? _montoUltimaTasacionNoTerreno;
        public decimal? MontoUltimaTasacionNoTerreno
        {
            get
            {
                return _montoUltimaTasacionNoTerreno;
            }
            set
            {
                _montoUltimaTasacionNoTerreno = value;
            }
        }

        private decimal? _montoTotalUltimaTasacion;
        public decimal? MontoTotalUltimaTasacion
        {
            get
            {
                return _montoTotalUltimaTasacion;
            }
            set
            {
                _montoTotalUltimaTasacion = value;
            }
        }

        private DateTime? _fechaUltimaTasacionGarantia;
        public DateTime? FechaUltimaTasacionGarantia
        {
            get
            {
                return _fechaUltimaTasacionGarantia;
            }
            set
            {
                _fechaUltimaTasacionGarantia = value;
            }
        }

        private DateTime? _fechaUltimoSeguimientoGarantia;
        public DateTime? FechaUltimoSeguimientoGarantia
        {
            get
            {
                return _fechaUltimoSeguimientoGarantia;
            }
            set
            {
                _fechaUltimoSeguimientoGarantia = value;
            }
        }

        private decimal? _montoValorTotalCedula;
        public decimal? MontoValorTotalCedula
        {
            get
            {
                return _montoValorTotalCedula;
            }
            set
            {
                _montoValorTotalCedula = value;
            }
        }

        #endregion

        #endregion

        #region GARANTIAS AVALES

        #region GENERAL

        private int? _idTipoAval;
        public int? IdTipoAval
        {
            get
            {
                return _idTipoAval;
            }
            set
            {
                _idTipoAval = value;
            }
        }

        private string _numeroAval;
        public string NumeroAval
        {
            get
            {
                return _numeroAval; ;
            }
            set
            {
                _numeroAval = value;
            }
        }

        #endregion

        #region DETALLE

        private int? _idGarantiaAval;
        public int? IdGarantiaAval
        {
            get
            {
                return _idGarantiaAval;
            }
            set
            {
                _idGarantiaAval = value;
            }
        }

        private decimal? _montoAvalado;
        public decimal? MontoAvalado
        {
            get
            {
                return _montoAvalado;
            }
            set
            {
                _montoAvalado = value;
            }
        }

        private int? _idTipoPersonaAvalista;
        public int? IdTipoPersonaAvalista
        {
            get
            {
                return _idTipoPersonaAvalista;
            }
            set
            {
                _idTipoPersonaAvalista = value;
            }
        }

        private string _desTipoPersonaAvalista;
        public string DesTipoPersonaAvalista
        {
            get
            {
                return _desTipoPersonaAvalista;
            }
            set
            {
                _desTipoPersonaAvalista = value;
            }
        }

        private int? _codAvalista;
        public int? CodAvalista
        {
            get
            {
                return _codAvalista;
            }
            set
            {
                _codAvalista = value;
            }
        }

        #endregion

        #endregion

        #region ADICIONALES GENERALES

        private int? _idTipoMonedaGradoGravamen;
        public int? IdTipoMonedaGradoGravamen
        {
            get
            {
                return _idTipoMonedaGradoGravamen;
            }
            set
            {
                _idTipoMonedaGradoGravamen = value;
            }
        }

        private int? _idTipoMitigadorRiesgo;
        public int? IdTipoMitigadorRiesgo
        {
            get
            {
                return _idTipoMitigadorRiesgo;
            }
            set
            {
                _idTipoMitigadorRiesgo = value;
            }
        }

        private int? _idTipoDocumentoLegal;
        public int? IdTipoDocumentoLegal
        {
            get
            {
                return _idTipoDocumentoLegal;
            }
            set
            {
                _idTipoDocumentoLegal = value;
            }
        }

        private int? _idGradoGravamen;
        public int? IdGradoGravamen
        {
            get
            {
                return _idGradoGravamen;
            }
            set
            {
                _idGradoGravamen = value;
            }
        }

        private int? _idClaseGarantiaPrt17;
        public int? IdClaseGarantiaPrt17
        {
            get
            {
                return _idClaseGarantiaPrt17;
            }
            set
            {
                _idClaseGarantiaPrt17 = value;
            }
        }

        private int? _idTenenciaPrt15;
        public int? IdTenenciaPrt15
        {
            get
            {
                return _idTenenciaPrt15;
            }
            set
            {
                _idTenenciaPrt15 = value;
            }
        }

        private int? _idTenenciaPrt17;
        public int? IdTenenciaPrt17
        {
            get
            {
                return _idTenenciaPrt17;
            }
            set
            {
                _idTenenciaPrt17 = value;
            }
        }

        private int _idDeudorHabita;
        public int IdDeudorHabita
        {
            get
            {
                return _idDeudorHabita;
            }
            set
            {
                _idDeudorHabita = value;
            }
        }

        private int _idIndicadorRecomendacion;
        public int IdIndicadorRecomendacion
        {
            get
            {
                return _idIndicadorRecomendacion;
            }
            set
            {
                _idIndicadorRecomendacion = value;
            }
        }

        private int _idIndicadorInspeccion;
        public int IdIndicadorInspeccion
        {
            get
            {
                return _idIndicadorInspeccion;
            }
            set
            {
                _idIndicadorInspeccion = value;
            }
        }
        
        //private int _idPoliza;
        //public int IdPoliza
        //{
        //    get
        //    {
        //        return _idPoliza;
        //    }
        //    set
        //    {
        //        _idPoliza = value;
        //    }
        //}

        private Decimal _montoGradoGravamen;
        public Decimal MontoGradoGravamen
        {
            get
            {
                return _montoGradoGravamen;
            }
            set
            {
                _montoGradoGravamen = value;
            }
        }

        private Decimal? _montoMitigador;
        public Decimal? MontoMitigador
        {
            get
            {
                return _montoMitigador;
            }
            set
            {
                _montoMitigador = value;
            }
        }

        private Decimal? _montoMitigadorCalculado;
        public Decimal? MontoMitigadorCalculado
        {
            get
            {
                return _montoMitigadorCalculado;
            }
            set
            {
                _montoMitigadorCalculado = value;
            }
        }

        private DateTime? _fechaConstitucionGarantia;
        public DateTime? FechaConstitucionGarantia
        {
            get
            {
                return _fechaConstitucionGarantia;
            }
            set
            {
                _fechaConstitucionGarantia = value;
            }
        }

        private DateTime? _fechaVencimientoGarantia;
        public DateTime? FechaVencimientoGarantia
        {
            get
            {
                return _fechaVencimientoGarantia;
            }
            set
            {
                _fechaVencimientoGarantia = value;
            }
        }

        private DateTime? _fechaPrescripcionGarantia;
        public DateTime? FechaPrescripcionGarantia
        {
            get
            {
                return _fechaPrescripcionGarantia;
            }
            set
            {
                _fechaPrescripcionGarantia = value;
            }
        }

        private Decimal _porcentajeAceptBCR;
        public Decimal PorcentajeAceptBCR
        {
            get
            {
                return _porcentajeAceptBCR;
            }
            set
            {
                _porcentajeAceptBCR = value;
            }
        }

        private Decimal? _porcentajeAceptSugef;
        public Decimal? PorcentajeAceptSugef
        {
            get
            {
                return _porcentajeAceptSugef;
            }
            set
            {
                _porcentajeAceptSugef = value;
            }
        }

        private Decimal? _porcentajeAceptNoTerrenoSugef;
        public Decimal? PorcentajeAceptNoTerrenoSugef
        {
            get
            {
                return _porcentajeAceptNoTerrenoSugef;
            }
            set
            {
                _porcentajeAceptNoTerrenoSugef = value;
            }
        }

        private Decimal? _porcentajeAceptTerrenoSugef;
        public Decimal? PorcentajeAceptTerrenoSugef
        {
            get
            {
                return _porcentajeAceptTerrenoSugef;
            }
            set
            {
                _porcentajeAceptTerrenoSugef = value;
            }
        }

        private Decimal? _porcentajeResponSugef;
        public Decimal? PorcentajeResponSugef
        {
            get
            {
                return _porcentajeResponSugef;
            }
            set
            {
                _porcentajeResponSugef = value;
            }
        }

        private Decimal? _porcentajeResponLegal;
        public Decimal? PorcentajeResponLegal
        {
            get
            {
                return _porcentajeResponLegal;
            }
            set
            {
                _porcentajeResponLegal = value;
            }
        }

        #endregion

        #region REQUERIMIENTO: 1-24493262

        private int? _idPartido;
        public int? IdPartido
        {
            get
            {
                return _idPartido;
            }
            set
            {
                _idPartido = value;
            }
        }

        #endregion

        #region REQUERIMIENTO: 1-24381561

        private string _IndMetodoInsercion;
        public string IndMetodoInsercion
        {
            get
            {
                return _IndMetodoInsercion;
            }
            set
            {
                _IndMetodoInsercion = value;
            }
        }

        private DateTime? _FechaIngreso;
        public DateTime? FechaIngreso
        {
            get
            {
                return _FechaIngreso;
            }
            set
            {
                _FechaIngreso = value;
            }
        }

        private string _CodUsuarioIngreso;
        public string CodUsuarioIngreso
        {
            get
            {
                return _CodUsuarioIngreso;
            }
            set
            {
                _CodUsuarioIngreso = value;
            }
        }

        private string _DesUsuarioIngreso;
        public string DesUsuarioIngreso
        {
            get
            {
                return _DesUsuarioIngreso;
            }
            set
            {
                _DesUsuarioIngreso = value;
            }
        }

        private DateTime? _FechaUltimaModificacion;
        public DateTime? FechaUltimaModificacion
        {
            get
            {
                return _FechaUltimaModificacion;
            }
            set
            {
                _FechaUltimaModificacion = value;
            }
        }

        private string _CodUsuarioUltimaModificacion;
        public string CodUsuarioUltimaModificacion
        {
            get
            {
                return _CodUsuarioUltimaModificacion;
            }
            set
            {
                _CodUsuarioUltimaModificacion = value;
            }
        }

        private string _DesUsuarioUltimaModificacion;
        public string DesUsuarioUltimaModificacion
        {
            get
            {
                return _DesUsuarioUltimaModificacion;
            }
            set
            {
                _DesUsuarioUltimaModificacion = value;
            }
        }

        #endregion

        #region REQUERIMIENTO: RQ_MANT_2016022310547690_Backlog_865

        #region RELACION GARANTIA FIDEICOMISO

        #region GENERAL

        private int? _idFideicomiso;
        public int? IdFideicomiso
        {
            get { return _idFideicomiso; }
            set { _idFideicomiso = value; }
        }

        private string _idFideicomisoBCR;
        public string IdFideicomisoBCR
        {
            get { return _idFideicomisoBCR; }
            set { _idFideicomisoBCR = value; }
        }

        #endregion

        #region DETALLE

        private string _desTipoMonedaValorNominal;
        public string DesTipoMonedaValorNominal
        {
            get { return _desTipoMonedaValorNominal; }
            set { _desTipoMonedaValorNominal = value; }
        }

        private decimal? _valorNominal;
        public decimal? ValorNominal
        {
            get { return _valorNominal; }
            set { _valorNominal = value; }
        }

        #endregion

        #region DATAS ADICIONALES

        private int? _indInscripcion;
        public int? IndInscripcion
        {
            get { return _indInscripcion; }
            set { _indInscripcion = value; }
        }

        #endregion

        #endregion

        #endregion

        #endregion

    }
}
