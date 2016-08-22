using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class RespuestaEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: 
        /// </summary>
        private int _valorEstado;
        public int ValorEstado
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
        /// Propiedad: 
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
        /// Propiedad: 
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

        /// <summary>
        /// Propiedad: 
        /// </summary>
        private string _valorErrorCadena;
        public string ValorErrorCadena
        {
            get
            {
                return _valorErrorCadena;
            }
            set
            {
                _valorErrorCadena = value;
            }
        }

        #endregion

    }
}
