using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class PantallasRolesEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Consecutivo
        /// </summary>
        private int _idPantallaRol;
        public int IdPantallaRol
        {
            get
            {
                return _idPantallaRol;
            }
            set
            {
                _idPantallaRol = value;
            }
        }

        /// <summary>
        /// Propiedad: Id Rol
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
        /// Propiedad: Id Pantalla
        /// </summary>
        private int _idPantalla;
        public int IdPantalla
        {
            get
            {
                return _idPantalla;
            }
            set
            {
                _idPantalla = value;
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
