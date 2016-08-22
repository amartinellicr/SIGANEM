using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class ListaItemsBCREntidad
    {
        
        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Codigo Sistema
        /// </summary>
        private string _codSistema;
        public string CodSistema
        {
            get
            {
                return _codSistema;
            }
            set
            {
                _codSistema = value;
            }
        }

        /// <summary>
        /// Propiedad: Codigo Usuario
        /// </summary>
        private string _codUsuario;
        public string CodUsuario
        {
            get
            {
                return _codUsuario;
            }
            set
            {
                _codUsuario = value;
            }
        }

        /// <summary>
        /// Propiedad: Codigo Item
        /// </summary>
        private string _codItem;
        public string CodItem
        {
            get
            {
                return _codItem;
            }
            set
            {
                _codItem = value;
            }
        }

        /// <summary>
        /// Propiedad: Valor Item
        /// </summary>
        private string _valItem;
        public string _ValItem
        {
            get
            {
                return _valItem;
            }
            set
            {
                _valItem = value;
            }
        }

        #endregion

    }
}
