using System;
using System.Text;
using System.Collections.Generic;

namespace BCR.SIGANEM.wsaIndicadores
{
    public class AppSettingEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Nombre
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

        /// <summary>
        /// Propiedad: Valor
        /// </summary>
        private string _valor;
        public string Valor
        {
            get
            {
                return _valor;
            }
            set
            {
                _valor = value;
            }
        }

        #endregion

    }
}