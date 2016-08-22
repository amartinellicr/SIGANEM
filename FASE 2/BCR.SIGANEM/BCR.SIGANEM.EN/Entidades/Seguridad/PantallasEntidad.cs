using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class PantallasEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Consecutivo de la tabla
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

        /// <summary>
        /// Propiedad: Codigo de la pantalla
        /// </summary>
        private int _codPantalla;
        public int CodPantalla
        {
            get
            {
                return _codPantalla;
            }
            set
            {
                _codPantalla = value;
            }
        }

        /// <summary>
        /// Propiedad: Titulo de la pantalla
        /// </summary>
        private string _tituloPantalla;
        public string TituloPantalla
        {
            get
            {
                return _tituloPantalla;
            }
            set
            {
                _tituloPantalla = value;
            }
        }

        /// <summary>
        /// Propiedad: Descripcion de la pantalla
        /// </summary>
        private string _desPantalla;
        public string DesPantalla
        {
            get
            {
                return _desPantalla;
            }
            set
            {
                _desPantalla = value;
            }
        }

        /// <summary>
        /// Propiedad: Ruta de la pantalla
        /// </summary>
        private string _rutaPantalla;
        public string RutaPantalla
        {
            get
            {
                return _rutaPantalla;
            }
            set
            {
                _rutaPantalla = value;
            }
        }

        /// <summary>
        /// Propiedad: Nodo del padre
        /// </summary>
        private int _padreOrigen;
        public int PadreOrigen
        {
            get
            {
                return _padreOrigen;
            }
            set
            {
                _padreOrigen = value;
            }
        }

        /// <summary>
        /// Propiedad: Nodo del sub padre
        /// </summary>
        private int _subPadreOrigen;
        public int SubPadreOrigen
        {
            get
            {
                return _subPadreOrigen;
            }
            set
            {
                _subPadreOrigen = value;
            }
        }

        /// <summary>
        /// Propiedad: Pestaña
        /// </summary>
        private string _pestana;
        public string Pestana
        {
            get
            {
                return _pestana;
            }
            set
            {
                _pestana = value;
            }
        }

        /// <summary>
        /// Propiedad: Modulo
        /// </summary>
        private string _modulo;
        public string Modulo
        {
            get
            {
                return _modulo;
            }
            set
            {
                _modulo = value;
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
