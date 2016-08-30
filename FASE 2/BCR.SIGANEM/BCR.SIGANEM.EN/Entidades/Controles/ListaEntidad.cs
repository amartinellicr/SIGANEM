using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class ListaEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Texto
        /// </summary>
        private string texto;
        public string Texto
        {
            get
            {
                return texto;
            }
            set
            {
                texto = value;
            }
        }

        /// <summary>
        /// Propiedad: Valor
        /// </summary>
        private string valor;
        public string Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }

        #endregion

    }
}
