using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class TiposRolesEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Consecutivo de la tabla
        /// </summary>
        private int _idTipoRol;
        public int IdTipoRol
        {
            get
            {
                return _idTipoRol;
            }
            set
            {
                _idTipoRol = value;
            }
        }

        /// <summary>
        /// Propiedad: Código del Tipo de Rol del usuario
        /// </summary>
        private int _codTipoRol;
        public int CodTipoRol
        {
            get
            {
                return _codTipoRol;
            }
            set
            {
                _codTipoRol = value;
            }
        }

        /// <summary>
        /// Propiedad: Descripcion del Tipo de Rol
        /// </summary>
        private string _desTipoRol;
        public string DesTipoRol
        {
            get
            {
                return _desTipoRol;
            }
            set
            {
                _desTipoRol = value;
            }
        }

        /// <summary>
        /// Propiedad: Indica si esta activo o no el Rol
        /// </summary>
        private Boolean _activo;
        public Boolean Activo
        {
            get
            {
                return _activo;
            }
            set
            {
                _activo = value;
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
