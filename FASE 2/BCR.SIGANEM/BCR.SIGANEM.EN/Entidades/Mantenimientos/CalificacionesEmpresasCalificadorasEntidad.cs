using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class CalificacionesEmpresasCalificadorasEntidad : EmpresasCalificadorasEntidad 
    {

        #region PROPIEDADES

        private int _idCalificacionEmpresaCalificadora;
        public int IdCalificacionEmpresaCalificadora
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

        private int _idCategoriaRiesgoEmpresaCalificadora;
        public int idCategoriaRiesgoEmpresaCalificadora
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

        private string _codCategoriaRiesgoEmpresaCalificadora;
        public string CodCategoriaRiesgoEmpresaCalificadora
        {
            get
            {
                return _codCategoriaRiesgoEmpresaCalificadora;
            }
            set
            {
                _codCategoriaRiesgoEmpresaCalificadora = value;
            }
        }

        private string _calificacion;
        public string Calificacion
        {
            get
            {
                return _calificacion;
            }
            set
            {
                _calificacion = value;
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
