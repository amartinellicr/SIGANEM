using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class RespuestaSICCEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Valor Estado
        /// </summary>
        private string _valorEstado;
        public string ValorEstado
        {
            get
            {
                return _valorEstado;
            }
            set
            {
                _valorEstado = value;
            }
        }

        /// <summary>
        /// Propiedad: Valor Estado Cadena
        /// </summary>
        private string _valorEstadoCadena;
        public string ValorEstadoCadena
        {
            get
            {
                return _valorEstadoCadena;
            }
            set
            {
                _valorEstadoCadena = value;
            }
        }

        /// <summary>
        /// Propiedad: Valor Error
        /// </summary>
        private int _valorError;
        public int ValorError
        {
            get
            {
                return _valorError;
            }
            set
            {
                _valorError = value;
            }
        }

        #endregion

    }
}
