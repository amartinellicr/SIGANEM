using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class MensajesEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Consecutivo de la tabla
        /// </summary>
        private int _idMensaje;
        public int IdMensaje
        {
            get
            {
                return _idMensaje;
            }
            set
            {
                _idMensaje = value;
            }
        }

        /// <summary>
        /// Propiedad: Codigo del mensaje
        /// </summary>
        private string _codMensaje;
        public string CodMensaje
        {
            get
            {
                return _codMensaje;
            }
            set
            {
                _codMensaje = value;
            }
        }

        /// <summary>
        /// Propiedad: Descripcion del mensaje
        /// </summary>
        private string _desMensaje;
        public string DesMensaje
        {
            get
            {
                return _desMensaje;
            }
            set
            {
                _desMensaje = value;
            }
        }

        /// <summary>
        /// Propiedad: Excepcion del sistema
        /// </summary>
        private string _causaMensaje;
        public string CausaMensaje
        {
            get
            {
                return _causaMensaje;
            }
            set
            {
                _causaMensaje = value;
            }
        }

        /// <summary>
        /// Propiedad: tipo del mensaje
        /// </summary>
        private int _tipoMensaje;
        public int TipoMensaje
        {
            get
            {
                return _tipoMensaje;
            }
            set
            {
                _tipoMensaje = value;
            }
        }

        /// <summary>
        /// Propiedad: Excepcion del sistema
        /// </summary>
        private string _desTipoMensaje;
        public string DesTipoMensaje
        {
            get
            {
                return _desTipoMensaje;
            }
            set
            {
                _desTipoMensaje = value;
            }
        }

        #endregion

    }
}
