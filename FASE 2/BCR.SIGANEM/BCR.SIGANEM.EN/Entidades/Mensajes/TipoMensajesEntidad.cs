using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class TipoMensajesEntidad
    {

        #region PROPIEDADES
        
        /// <summary>
        /// Propiedad: Consecutivo de la tabla
        /// </summary>
        private int _idTipoMensaje;
        public int IdTipoMensaje
        {
            get
            {
                return _idTipoMensaje;
            }
            set
            {
                _idTipoMensaje = value;
            }
        }

        /// <summary>
        /// Propiedad: Codigo del mensaje
        /// </summary>
        private int _codTipoMensaje;
        public int CodTipoMensaje
        {
            get
            {
                return _codTipoMensaje;
            }
            set
            {
                _codTipoMensaje = value;
            }
        }

        /// <summary>
        /// Propiedad: Descripcion del mensaje
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
