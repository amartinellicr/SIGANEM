using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class BCRClientesEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Id SICC
        /// </summary>
        private string _idSICC;
        public string IdSICC
        {
            get
            {
                return _idSICC;
            }
            set
            {
                _idSICC = value;
            }
        }

        /// <summary>
        /// Propiedad: Nombre del CLiente
        /// </summary>
        private string _descNombre;
        public string DescNombre
        {
            get
            {
                return _descNombre;
            }
            set
            {
                _descNombre = value;
            }
        }

        #endregion

    }
}
