using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class NotariosEntidad : TiposPersonasEntidad
    {

        #region PROPIEDADES

        private int _idNotario;
        public int IdNotario
        {
            get
            {
                return _idNotario;
            }
            set
            {
                _idNotario = value;
            }
        }

        private string _codNotario;
        public string CodNotario
        {
            get
            {
                return _codNotario;
            }
            set
            {
                _codNotario = value;
            }
        }

        private string _desNotario;
        public string DesNotario
        {
            get
            {
                return _desNotario;
            }
            set
            {
                _desNotario = value;
            }
        }

        private string _codTipoNotario;
        public string CodTipoNotario
        {
            get
            {
                return _codTipoNotario;
            }
            set
            {
                _codTipoNotario = value;
            }
        }

        private string _desTipoNotario;
        public string DesTipoNotario
        {
            get
            {
                return _desTipoNotario;
            }
            set
            {
                _desTipoNotario = value;
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
