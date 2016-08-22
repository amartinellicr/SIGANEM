using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class TiposMonedasEntidad : IndicadoresMonedasExtranjerasEntidad 
    {

        #region PROPIEDADES

        private int _idTipoMoneda;
        public int IdTipoMoneda
        {
            get
            {
                return _idTipoMoneda;
            }
            set
            {
                _idTipoMoneda = value;
            }
        }

        private string _codTipoMoneda;
        public string CodTipoMoneda
        {
            get
            {
                return _codTipoMoneda;
            }
            set
            {
                _codTipoMoneda = value;
            }
        }

        private string _desTipoMoneda;
        public string DesTipoMoneda
        {
            get
            {
                return _desTipoMoneda;
            }
            set
            {
                _desTipoMoneda = value;
            }
        }

        private string _pais;
        public string Pais
        {
            get
            {
                return _pais;
            }
            set
            {
                _pais = value;
            }
        }

        private string _capital;
        public string Capital
        {
            get
            {
                return _capital;
            }
            set
            {
                _capital = value;
            }
        }

        private string _fraccionMonetaria;
        public string FraccionMonetaria
        {
            get
            {
                return _fraccionMonetaria;
            }
            set
            {
                _fraccionMonetaria = value;
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
