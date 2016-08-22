using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class EmisionesInstrumentosEntidad : MonedasEntidad
    {

        #region PROPIEDADES

        private int _idEmisionInstrumento;
        public int IdEmisionInstrumento
        {
            get
            {
                return _idEmisionInstrumento;
            }
            set
            {
                _idEmisionInstrumento = value;
            }
        }

        private int _idTipoClasificacionInstrumento;
        public int IdTipoClasificacionInstrumento
        {
            get
            {
                return _idTipoClasificacionInstrumento;
            }
            set
            {
                _idTipoClasificacionInstrumento = value;
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

        private int _codEmisionInstrumento;
        public int CodEmisionInstrumento
        {
            get
            {
                return _codEmisionInstrumento;
            }
            set
            {
                _codEmisionInstrumento = value;
            }
        }

        private int _codEmisorInstrumento;
        public int codEmisorInstrumento
        {
            get
            {
                return _codEmisorInstrumento;
            }
            set
            {
                _codEmisorInstrumento = value;
            }
        }

        private int _codTipoClasificacionInstrumento;
        public int codTipoClasificacionInstrumento
        {
            get
            {
                return _codTipoClasificacionInstrumento;
            }
            set
            {
                _codTipoClasificacionInstrumento = value;
            }
        }

        private string _codInstrumento;
        public string CodInstrumento
        {
            get
            {
                return _codInstrumento;
            }
            set
            {
                _codInstrumento = value;
            }
        }

        private string _codTipoInstrumento;
        public string CodTipoInstrumento
        {
            get
            {
                return _codTipoInstrumento;
            }
            set
            {
                _codTipoInstrumento = value;
            }
        }

        private string _codEmisor;
        public string CodEmisor
        {
            get
            {
                return _codEmisor;
            }
            set
            {
                _codEmisor = value;
            }
        }

        private string _desTipoClasificacionInstrumento;
        public string DesTipoClasificacionInstrumento
        {
            get
            {
                return _desTipoClasificacionInstrumento;
            }
            set
            {
                _desTipoClasificacionInstrumento = value;
            }
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

        private string _desTipoInstrumento;
        public string DesTipoInstrumento
        {
            get
            {
                return _desTipoInstrumento;
            }
            set
            {
                _desTipoInstrumento = value;
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

        private string _isin;
        public string Isin
        {
            get
            {
                return _isin;
            }
            set
            {
                _isin = value;
            }
        }

        private Double? _premio;
        public Double? Premio
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

        private DateTime? _vencimiento;
        public DateTime? Vencimiento
        {
            get
            {
                return _vencimiento;
            }
            set
            {
                _vencimiento = value;
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