using System;
using System.Text;
using System.Collections.Generic;

namespace BCR.SIGANEM.EN
{
    public class NodoMenuEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Ruta del Menu
        /// </summary>
        private string _url;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        /// <summary>
        /// Propiedad: Nombre del Menu
        /// </summary>
        private string _nombre;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }
        
        #endregion 

    }
}
