using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasRealesCedulasEntidad 
    {

        #region PROPIEDADES

        private int _idGarantiaRealCedula;
        public int IdGarantiaRealCedula
        {
            get
            {
                return _idGarantiaRealCedula;
            }
            set
            {
                _idGarantiaRealCedula = value;
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

        private int _cedula;
        public int Cedula
        {
            get
            {
                return _cedula;
            }
            set
            {
                _cedula = value;
            }
        }

        private int _idGradoGravamen;
        public int IdGradoGravamen
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

        private DateTime _fechaVencimientoCedula;
        public DateTime FechaVencimientoCedula
        {
            get
            {
                return _fechaVencimientoCedula;
            }
            set
            {
                _fechaVencimientoCedula = value;
            }
        }

        private DateTime _fechaPrescripcionCedula;
        public DateTime FechaPrescripcionCedula
        {
            get
            {
                return _fechaPrescripcionCedula;
            }
            set
            {
                _fechaPrescripcionCedula = value;
            }
        }

        private int _idMoneda;
        public int IdMoneda
        {
            get
            {
                return _idMoneda;
            }
            set
            {
                _idMoneda = value;
            }
        }

        private string _desMoneda;
        public string DesMoneda
        {
            get
            {
                return _desMoneda;
            }
            set
            {
                _desMoneda = value;
            }
        }

        private decimal _valorFacial;
        public decimal ValorFacial
        {
            get
            {
                return _valorFacial;
            }
            set
            {
                _valorFacial = value;
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
