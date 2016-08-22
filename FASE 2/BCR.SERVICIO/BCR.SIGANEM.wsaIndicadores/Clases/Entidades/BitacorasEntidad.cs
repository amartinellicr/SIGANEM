using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.wsaIndicadores
{
    public class BitacorasEntidad
    {
      
        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Codigo de la accion
        /// </summary>
        private int _codAccion;
        public int CodAccion
        {
            get
            {
                return _codAccion;
            }
            set
            {
                _codAccion = value;
            }
        }

        /// <summary>
        /// Propiedad: Codigo de modulo
        /// </summary>
        private int _codModulo;
        public int CodModulo
        {
            get
            {
                return _codModulo;
            }
            set
            {
                _codModulo = value;
            }
        }

        /// <summary>
        /// Propiedad: Codigo de empresa BCR
        /// </summary>
        private int _codEmpresa;
        public int CodEmpresa
        {
            get
            {
                return _codEmpresa;
            }
            set
            {
                _codEmpresa = value;
            }
        }

        /// <summary>
        /// Propiedad: Codigo del sistema
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
        /// Propiedad: codigo del usuario
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
        /// Propiedad: Valor del dato actualizado
        /// </summary>
        private string _datoActualizado;
        public string DatoActualizado
        {
            get
            {
                return _datoActualizado;
            }
            set
            {
                _datoActualizado = value;
            }
        }

        /// <summary>
        /// Propiedad: Valor del dato eliminado
        /// </summary>
        private string _datoEliminado;
        public string DatoEliminado
        {
            get
            {
                return _datoEliminado;
            }
            set
            {
                _datoEliminado = value;
            }
        }

        /// <summary>
        /// Propiedad: Valor del dato insertado
        /// </summary>
        private string _datoNuevo;
        public string DatoNuevo
        {
            get
            {
                return _datoNuevo;
            }
            set
            {
                _datoNuevo = value;
            }
        }

        /// <summary>
        /// Propiedad: Descripcion de la accion realizada
        /// </summary>
        private string _desRegistro;
        public string DesRegistro
        {
            get
            {
                return _desRegistro;
            }
            set
            {
                _desRegistro = value;
            }
        }

        #endregion

    }
}
