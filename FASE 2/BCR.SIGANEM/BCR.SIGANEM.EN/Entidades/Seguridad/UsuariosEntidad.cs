using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class UsuariosEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Consecutivo de la tabla
        /// </summary>
        private int _idUsuario;
        public int IdUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
            }
        }

        /// <summary>
        /// Propiedad: Codigo del usuario
        /// </summary>
        private string _codUsuario;
        public string CodUsuario
        {
            get
            {
                return _codUsuario;
            }
            set
            {
                _codUsuario = value;
            }
        }

        /// <summary>
        /// Propiedad: Nombre usuario
        /// </summary>
        private string _nombreUsuario;
        public string NombreUsuario
        {
            get
            {
                return _nombreUsuario;
            }
            set
            {
                _nombreUsuario = value;
            }
        }

        /// <summary>
        /// Propiedad: Id del Tipo de Rol
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
        /// Propiedad: Codigo Tipo del Rol
        /// </summary>
        private string _codTipoRol;
        public string CodTipoRol
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
        /// Propiedad: Cantidad de Intentos de Ingreso
        /// </summary>
        private int _cantidadIntento;
        public int CantidadIntento
        {
            get
            {
                return _cantidadIntento;
            }
            set
            {
                _cantidadIntento = value;
            }
        }

        /// <summary>
        /// Propiedad: Bloqueado
        /// </summary>
        private Boolean _bloqueado;
        public Boolean Bloqueado
        {
            get
            {
                return _bloqueado;
            }
            set
            {
                _bloqueado = value;
            }
        }

        /// <summary>
        /// Propiedad: DesBloqueado
        /// </summary>
        private string _desBloqueado;
        public string DesBloqueado
        {
            get
            {
                return _desBloqueado;
            }
            set
            {
                _desBloqueado = value;
            }
        }

        /// <summary>
        /// Propiedad: Conectado
        /// </summary>
        private Boolean _conectado;
        public Boolean Conectado
        {
            get
            {
                return _conectado;
            }
            set
            {
                _conectado = value;
            }
        }

        /// <summary>
        /// Propiedad: DesConectado
        /// </summary>
        private string _desConectado;
        public string DesConectado
        {
            get
            {
                return _desConectado;
            }
            set
            {
                _desConectado = value;
            }
        }

        /// <summary>
        /// Propiedad: Fecha de Intentos de Ingreso
        /// </summary>
        private DateTime? _fechaIntento;
        public DateTime? FechaIntento
        {
            get
            {
                return _fechaIntento;
            }
            set
            {
                _fechaIntento = value;
            }
        }

        /// <summary>
        /// Propiedad: Ultima Conexión
        /// </summary>
        private DateTime? _ultimaConexion;
        public DateTime?  UltimaConexion
        {
            get
            {
                return _ultimaConexion;
            }
            set
            {
                _ultimaConexion = value;
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
