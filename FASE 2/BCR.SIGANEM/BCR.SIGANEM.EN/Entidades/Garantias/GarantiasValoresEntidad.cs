using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasValoresEntidad
    {

        #region PROPIEDADES

        private int _idGarantiaValor;
        public int IdGarantiaValor
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

        private int? _idCalificacionEmpresaCalificadora;
        public int? IdCalificacionEmpresaCalificadora
        {
            get
            {
                return _idCalificacionEmpresaCalificadora;
            }
            set
            {
                _idCalificacionEmpresaCalificadora = value;
            }
        }

        private int? _idCategoriaRiesgoEmpresaCalificadora;
        public int? IdCategoriaRiesgoEmpresaCalificadora
        {
            get
            {
                return _idCategoriaRiesgoEmpresaCalificadora;
            }
            set
            {
                _idCategoriaRiesgoEmpresaCalificadora = value;
            }
        }

        private int _idEmisor;
        public int IdEmisor
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

        private int? _idEmpresaCalificadora;
        public int? IdEmpresaCalificadora
        {
            get
            {
                return _idEmpresaCalificadora;
            }
            set
            {
                _idEmpresaCalificadora = value;
            }
        }

        private int _idInstrumento;
        public int IdInstrumento
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

        private int? _idMonedaValorFacial;
        public int? IdMonedaValorFacial
        {
            get
            {
                return _idMonedaValorFacial;
            }
            set
            {
                _idMonedaValorFacial = value;
            }
        }

        private string _monedaValorFacial;
        public string MonedaValorFacial
        {
            get { return _monedaValorFacial; }
            set { _monedaValorFacial = value; }
        }

        private int _idMonedaValorMercado;
        public int IdMonedaValorMercado
        {
            get
            {
                return _idMonedaValorMercado;
            }
            set
            {
                _idMonedaValorMercado = value;
            }
        }

        private string _monedaValorMercado;
        public string MonedaValorMercado
        {
            get { return _monedaValorMercado; }
            set { _monedaValorMercado = value; }
        }

        private int _idTipoAsignacionCalificacion;
        public int IdTipoAsignacionCalificacion
        {
            get
            {
                return _idTipoAsignacionCalificacion;
            }
            set
            {
                _idTipoAsignacionCalificacion = value;
            }
        }
        
        private int? _idPlazoCalificacion;
        public int? IdPlazoCalificacion
        {
            get
            {
                return _idPlazoCalificacion;
            }
            set
            {
                _idPlazoCalificacion = value;
            }
        }

        private int _idTipoPersonaEmisor;
        public int IdTipoPersonaEmisor
        {
            get
            {
                return _idTipoPersonaEmisor;
            }
            set
            {
                _idTipoPersonaEmisor = value;
            }
        }

        private int _idTipoInstrumento;
        public int IdTipoInstrumento
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

        private string _codGarantia;
        public string CodGarantia
        {
            get
            {
                return _codGarantia;
            }
            set
            {
                _codGarantia = value;
            }
        }

        private string _clasificacionInstrumento;
        public string ClasificacionInstrumento
        {
            get
            {
                return _clasificacionInstrumento;
            }
            set
            {
                _clasificacionInstrumento = value;
            }
        }

        private string _identificacionEmisor;
        public string IdentificacionEmisor
        {
            get
            {
                return _identificacionEmisor;
            }
            set
            {
                _identificacionEmisor = value;
            }
        }

        private string _identificacionInstrumento;
        public string IdentificacionInstrumento
        {
            get
            {
                return _identificacionInstrumento;
            }
            set
            {
                _identificacionInstrumento = value;
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

        private DateTime _fechaConstitucionGarantia;
        public DateTime FechaConstitucionGarantia
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

        private DateTime _fechaValorMercado;
        public DateTime FechaValorMercado
        {
            get
            {
                return _fechaValorMercado;
            }
            set
            {
                _fechaValorMercado = value;
            }
        }

        private DateTime? _fechaVencimiento;
        public DateTime? FechaVencimiento
        {
            get
            {
                return _fechaVencimiento;
            }
            set
            {
                _fechaVencimiento = value;
            }
        }

        private Decimal? _premio;
        public Decimal? Premio
        {
            get
            {
                return _premio;
            }
            set
            {
                _premio = value;
            }
        }

        private Decimal? _montoValorFacial;
        public Decimal? MontoValorFacial
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

        private decimal? _montoValorFacialColonizado;
        public decimal? MontoValorFacialColonizado
        {
            get { return _montoValorFacialColonizado; }
            set { _montoValorFacialColonizado = value; }
        }

        private Decimal? _montoValorMercado;
        public Decimal? MontoValorMercado
        {
            get
            {
                return _montoValorMercado;
            }
            set
            {
                _montoValorMercado = value;
            }
        }

        private decimal? _montoValorMercadoColonizado;
        public decimal? MontoValorMercadoColonizado
        {
            get { return _montoValorMercadoColonizado; }
            set { _montoValorMercadoColonizado = value; }
        }

        private string _desEmisor;
        public string DesEmisor
        {
            get
            {
                return _desEmisor;
            }
            set
            {
                _desEmisor = value;
            }
        }

        private string _desInstrumento;
        public string DesInstrumento
        {
            get
            {
                return _desInstrumento;
            }
            set
            {
                _desInstrumento = value;
            }
        }

        private int? _idEstadoGarantia;
        public int? IdEstadoGarantia
        {
            get
            {
                return _idEstadoGarantia;
            }
            set
            {
                _idEstadoGarantia = value;
            }
        }

        private int? _estadoRegistroGarantia;
        public int? EstadoRegistroGarantia
        {
            get
            {
                return _estadoRegistroGarantia;
            }
            set
            {
                _estadoRegistroGarantia = value;
            }
        }
                
        #region REQUERIMIENTO: 1-24292751

        private int _idTipoValor;
        public int IdTipoValor
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

        private string _desTipoValor;
        public string DesTipoValor
        {
            get
            {
                return _desTipoValor;
            }
            set
            {
                _desTipoValor = value;
            }
        }

        #endregion

        #region REQUERIMIENTO: 1-24653531

        private bool _indBusquedaISIN;
        public bool IndBusquedaISIN
        {
            get
            {
                return _indBusquedaISIN;
            }
            set
            {
                _indBusquedaISIN = value;
            }
        }

        private string _valorBusqueda;
        public string ValorBusqueda
        {
            get
            {
                return _valorBusqueda;
            }
            set
            {
                _valorBusqueda = value;
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

        #endregion

    }
}