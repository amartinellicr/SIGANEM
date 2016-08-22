using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class SessionBCREntidad : ListaItemsBCREntidad
    {
        
        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Codigo de sesion
        /// </summary>
        private string _codigo;
        public string Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }

        /// <summary>
        /// Propiedad: Descripcion de la sesion
        /// </summary>
        private string _descripcion;
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        /// <summary>
        /// Propiedad: Descripcion de la sesion
        /// </summary>
        private string _registro;
        public string Registro
        {
            get
            {
                return _registro;
            }
            set
            {
                _registro = value;
            }
        }

        /// <summary>
        /// Propiedad: Mensaje de error
        /// </summary>
        private string _excepcion;
        public string Excepcion
        {
            get
            {
                return _excepcion;
            }
            set
            {
                _excepcion = value;
            }
        }
        
        /// <summary>
        /// Propiedad: Indicador si la sesion es valida o no
        /// </summary>
        private bool _valido;
        public bool Valido
        {
            get
            {
                return _valido;
            }
            set
            {
                _valido = value;
            }
        }

        /// <summary>
        /// Propiedad: Fecha de creacion de la sesion
        /// </summary>
        private string _fechaCreacion;
        public string FechaCreacion
        {
            get
            {
                return _fechaCreacion;
            }
            set
            {
                _fechaCreacion = value;
            }
        }

        /// <summary>
        /// Propiedad: Nombre del Servidor
        /// </summary>
        private string _nombreServidor;
        public string NombreServidor
        {
            get
            {
                return _nombreServidor;
            }
            set
            {
                _nombreServidor = value;
            }
        }

        #endregion

    }
}
