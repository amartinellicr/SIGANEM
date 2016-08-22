using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class ParametrosTotalFilasEntidad
    {

        #region PROPIEDADES

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
        /// Propiedad: Columna del Filtro
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

        #endregion

    }
}
