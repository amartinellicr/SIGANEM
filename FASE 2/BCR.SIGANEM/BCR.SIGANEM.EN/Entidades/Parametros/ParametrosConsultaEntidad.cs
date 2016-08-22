using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class ParametrosConsultaEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Inicio de Fila
        /// </summary>
        private int _indiceInicioFila;
        public int IndiceInicioFila
        {
            get
            {
                return _indiceInicioFila;
            }
            set
            {
                _indiceInicioFila = value;
            }
        }

        /// <summary>
        /// Propiedad: Maximo de filas
        /// </summary>
        private int _maximoFilas;
        public int MaximoFilas
        {
            get
            {
                return _maximoFilas;
            }
            set
            {
                _maximoFilas = value;
            }
        }

        /// <summary>
        /// Propiedad: Valor del Filtro
        /// </summary>
        private string _valorFiltro;
        public string ValorFiltro
        {
            get
            {
                return _valorFiltro;
            }
            set
            {
                _valorFiltro = value;
            }
        }

        /// <summary>
        /// Propiedad: Filtro de la columna
        /// </summary>
        private string _columnaFiltro;
        public string ColumnaFiltro
        {
            get
            {
                return _columnaFiltro;
            }
            set
            {
                _columnaFiltro = value;
            }
        }

        /// <summary>
        /// Propiedad: Ordenacion de la columna
        /// </summary>
        private string _columnaOrdenar;
        public string ColumnaOrdenar
        {
            get
            {
                return _columnaOrdenar;
            }
            set
            {
                _columnaOrdenar = value;
            }
        }

        #endregion

    }
}
