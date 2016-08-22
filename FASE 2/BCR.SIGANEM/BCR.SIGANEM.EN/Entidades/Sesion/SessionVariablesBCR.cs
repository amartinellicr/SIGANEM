using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class SessionVariablesBCR
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Codigo de la sesion
        /// </summary>        
        private string _idSesion;
        public string IdSesion 
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
        /// Propiedad: Nombre de la Variable
        /// </summary>        
        private string _nombreVariable;
        public string NombreVariable 
        {
            get
            {
                return _nombreVariable;
            }
            set
            {
                _nombreVariable = value;
            }
        }

        /// <summary>
        /// Propiedad: Valor de la Variable
        /// </summary>        
        private string _valorVariable;
        public string ValorVariable
        {
            get
            {
                return _valorVariable;
            }
            set
            {
                _valorVariable = value;
            }
        }

        /// <summary>
        /// Propiedad: Fecha de registro de la Variable
        /// </summary>        
        private string _fechaRegistro;
        public string FechaRegistro
        {
            get
            {
                return _fechaRegistro;
            }
            set
            {
                _fechaRegistro = value;
            }
        }

        /// <summary>
        /// Propiedad: Persistencia de la Variable
        /// </summary>        
        private bool _persistente;
        public bool Persistente
        {
            get
            {
                return _persistente;
            }
            set
            {
                _persistente = value;
            }
        }

        #endregion

    }
}
