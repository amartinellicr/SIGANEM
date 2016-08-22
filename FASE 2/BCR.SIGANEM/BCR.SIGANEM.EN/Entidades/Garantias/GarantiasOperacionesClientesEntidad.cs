using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasOperacionesClientesEntidad : GarantiasOperacionesConsultaEntidad
    {

        #region PROPIEDADES

        #region CLIENTE SICC

        private string _tipoIdentificacionSICC;
        public string TipoIdentificacionSICC
        {
            get
            {
                return _tipoIdentificacionSICC;
            }
            set
            {
                _tipoIdentificacionSICC = value;
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

        private string _nombreClienteSICC;
        public string NombreClienteSICC
        {
            get
            {
                return _nombreClienteSICC;
            }
            set
            {
                _nombreClienteSICC = value;
            }
        }

        private DateTime? _fechaConstitucionSICC;
        public DateTime? FechaConstitucionSICC
        {
            get
            {
                return _fechaConstitucionSICC;
            }
            set
            {
                _fechaConstitucionSICC = value;
            }
        }

        private DateTime? _fechaVencimientoSICC;
        public DateTime? FechaVencimientoSICC
        {
            get
            {
                return _fechaVencimientoSICC;
            }
            set
            {
                _fechaVencimientoSICC = value;
            }
        }

        private int _oficinaDeudorSICC;
        public int OficinaDeudorSICC
        {
            get
            {
                return _oficinaDeudorSICC;
            }
            set
            {
                _oficinaDeudorSICC = value;
            }
        }

        private string _estadoOperacionSICC;
        public string EstadoOperacionSICC
        {
            get
            {
                return _estadoOperacionSICC;
            }
            set
            {
                _estadoOperacionSICC = value;
            }
        }

        #endregion

        #region CLIENTE RUC

        private string _tipoIdentificacionRUC;
        public string TipoIdentificacionRUC
        {
            get
            {
                return _tipoIdentificacionRUC;
            }
            set
            {
                _tipoIdentificacionRUC = value;
            }
        }

        private string _identificacionClienteRUC;
        public string IdentificacionClienteRUC
        {
            get
            {
                return _identificacionClienteRUC;
            }
            set
            {
                _identificacionClienteRUC = value;
            }
        }

        private string _categoriaRiesgoDeudor;
        public string CategoriaRiesgoDeudor
        {
            get
            {
                return _categoriaRiesgoDeudor;
            }
            set
            {
                _categoriaRiesgoDeudor = value;
            }
        }

        #endregion

        #region SALDOS

        private decimal? _saldo;
        public decimal? Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                _saldo = value;
            }
        }

        private decimal? _saldoColonizado;
        public decimal? SaldoColonizado
        {
            get
            {
                return _saldoColonizado;
            }
            set
            {
                _saldoColonizado = value;
            }
        }

        private decimal? _saldoOriginal;
        public decimal? SaldoOriginal
        {
            get
            {
                return _saldoOriginal;
            }
            set
            {
                _saldoOriginal = value;
            }
        }

        private decimal? _saldoOriginalColonizado;
        public decimal? SaldoOriginalColonizado
        {
            get
            {
                return _saldoOriginalColonizado;
            }
            set
            {
                _saldoOriginalColonizado = value;
            }
        }

        #endregion

        #region CLIENTE SUGEF

        private int _indDesembolso;
        public int IndDesembolso
        {
            get
            {
                return _indDesembolso;
            }
            set
            {
                _indDesembolso = value;
            }
        }

        private string _identificacionSugef;
        public string IdentificacionSugef
        {
            get
            {
                return _identificacionSugef;
            }
            set
            {
                _identificacionSugef = value;
            }
        }

        private string _tipoIdentificacionSugef;
        public string TipoIdentificacionSugef
        {
            get
            {
                return _tipoIdentificacionSugef;
            }
            set
            {
                _tipoIdentificacionSugef = value;
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