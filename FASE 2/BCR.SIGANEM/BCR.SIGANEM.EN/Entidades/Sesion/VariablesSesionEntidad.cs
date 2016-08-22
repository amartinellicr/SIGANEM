using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class VariablesSesionEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Consecutivo de Sesion
        /// </summary>
        private string _idSesion;
        public string idSesion
        {
            get
            {
                return _idSesion;
            }
            set
            {
                _idSesion = value;
            }
        }

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

        /// <summary>
        /// Propiedad: Persistencia
        /// </summary>
        private bool _persistencia;
        public bool Persistencia
        {
            get
            {
                return _persistencia;
            }
            set
            {
                _persistencia = value;
            }
        }

        #endregion

    }
}
