using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class MobiliariaGarantiasRealesEntidad
    {
        #region PROPIEDADES

        private int _idMobiliariaGarantiaReal;
        public int IdMobiliariaGarantiaReal
        {
            get
            {
                return _idMobiliariaGarantiaReal;
            }
            set
            {
                _idMobiliariaGarantiaReal = value;
            }
        }
  
        private int _idGarantiaReal;
        public int IdGarantiaReal
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

        private string _consecutivo;
        public string Consecutivo
        {
            get
            {
                return _consecutivo;
            }
            set
            {
                _consecutivo = value;
            }
        }

        private string _desNumeroOperacion;
        public string DesNumeroOperacion
        {
            get
            {
                return _desNumeroOperacion;
            }
            set
            {
                _desNumeroOperacion = value;
            }
        }

        private string _numeroBien;
        public string NumeroBien
        {
            get
            {
                return _numeroBien;
            }
            set
            {
                _numeroBien = value;
            }
        }

        private string _desTipoBien;
        public string DesTipoBien
        {
            get
            {
                return _desTipoBien;
            }
            set
            {
                _desTipoBien = value;
            }
        }

        private DateTime? _fechaPublicacion;
        public DateTime? FechaPublicacion
        {
            get
            {
                return _fechaPublicacion;
            }
            set
            {
                _fechaPublicacion = value;
            }
        }

        private string _vin;
        public string Vin
        {
            get
            {
                return _vin;
            }
            set
            {
                _vin = value;
            }
        }

        private string _motor;
        public string Motor
        {
            get
            {
                return _motor;
            }
            set
            {
                _motor = value;
            }
        }

        private string _descripcion;
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
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
