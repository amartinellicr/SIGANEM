using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class TiposCapacidadesPagosEntidad
    {

        #region PROPIEDADES

        private int _idTipoCapacidadPago;
        public int IdTipoCapacidadPago
        {
            get
            {
                return _idTipoCapacidadPago;
            }
            set
            {
                _idTipoCapacidadPago = value;
            }
        }

        private int _codTipoCapacidadPago;
        public int CodTipoCapacidadPago
        {
            get
            {
                return _codTipoCapacidadPago;
            }
            set
            {
                _codTipoCapacidadPago = value;
            }
        }

        private string _desTipoCapacidadPago;
        public string DesTipoCapacidadPago
        {
            get
            {
                return _desTipoCapacidadPago;
            }
            set
            {
                _desTipoCapacidadPago = value;
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
