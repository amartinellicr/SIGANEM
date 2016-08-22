using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class EmpresasCalificadorasEntidad : PlazosCalificacionesEntidad
    {

        #region PROPIEDADES

        private int _idEmpresaCalificadora;
        public int IdEmpresaCalificadora
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

        private string _codEmpresaCalificadora;
        public string CodEmpresaCalificadora
        {
            get
            {
                return _codEmpresaCalificadora;
            }
            set
            {
                _codEmpresaCalificadora = value;
            }
        }

        private string _desEmpresaCalificadora;
        public string DesEmpresaCalificadora
        {
            get
            {
                return _desEmpresaCalificadora;
            }
            set
            {
                _desEmpresaCalificadora = value;
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