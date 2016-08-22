using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class RUCClientesEntidad
    {

        #region PROPIEDADES

        private string _idRUC;
        public string IdRUC
        {
            get
            {
                return _idRUC;
            }
            set
            {
                _idRUC = value;
            }
        }

        private string _tipoIdentificacionRUC;
        public string TipoIdentificacionRUC
        {
            get
            {
                return _tipoIdentificacionRUC;
            }
            set
            {
                _tipoIdentificacionRUC = value;
            }
        }

        private string _identificacionClienteRUC;
        public string IdentificacionClienteRUC
        {
            get
            {
                return _identificacionClienteRUC;
            }
            set
            {
                _identificacionClienteRUC = value;
            }
        }

        private string _descNombreRUC;
        public string DescNombreRUC
        {
            get
            {
                return _descNombreRUC;
            }
            set
            {
                _descNombreRUC = value;
            }
        }

        #endregion

    }
}
