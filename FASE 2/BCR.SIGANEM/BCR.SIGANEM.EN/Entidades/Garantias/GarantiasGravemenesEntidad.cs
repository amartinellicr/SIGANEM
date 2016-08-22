using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class GarantiasGravemenesEntidad
    {
        #region PROPIEDADES

        private int _idGravamen;
        public int IdGravamen
        {
            get
            {
                return _idGravamen;
            }
            set
            {
                _idGravamen = value;
            }
        }

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

        private string _desGradoGravamen;
        public string DesGradoGravamen
        {
            get
            {
                return _desGradoGravamen;
            }
            set
            {
                _desGradoGravamen = value;
            }
        }

        private int? _idTipoMonedaMontoGravamen;
        public int? IdTipoMonedaMontoGravamen
        {
            get
            {
                return _idTipoMonedaMontoGravamen;
            }
            set
            {
                _idTipoMonedaMontoGravamen = value;
            }
        }

        private string _desTipoMonedaMontoGravamen;
        public string DesTipoMonedaMontoGravamen
        {
            get
            {
                return _desTipoMonedaMontoGravamen;
            }
            set
            {
                _desTipoMonedaMontoGravamen = value;
            }
        }

        private decimal? _saldoGradoGravamen;
        public decimal? SaldoGradoGravamen
        {
            get
            {
                return _saldoGradoGravamen;
            }
            set
            {
                _saldoGradoGravamen = value;
            }
        }

        private string _entidadAcreedora;
        public string EntidadAcreedora
        {
            get
            {
                return _entidadAcreedora;
            }
            set
            {
                _entidadAcreedora = value;
            }
        }

        private int? _idTipoCambio;
        public int? IdTipoCambio
        {
            get
            {
                return _idTipoCambio;
            }
            set
            {
                _idTipoCambio = value;
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

        private int _idVisible;
        public int Id_Visible
        {
            get
            {
                return _idVisible;
            }
            set
            {
                _idVisible = value;
            }
        }

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
