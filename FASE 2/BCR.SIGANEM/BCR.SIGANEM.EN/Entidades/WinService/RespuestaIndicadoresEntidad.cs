using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class RespuestaIndicadoresEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Indicador de consulta
        /// </summary>
        private string _idIndicador;
        public string IdIndicador
        {
            get
            {
                return _idIndicador;
            }
            set
            {
                _idIndicador = value;
            }
        }

        private DateTime _fechaIndicador;
        public DateTime FechaIndicador
        {
            get
            {
                return _fechaIndicador;
            }
            set
            {
                _fechaIndicador = value;
            }
        }

        private decimal _valorIndicador;
        public decimal ValorIndicador
        {
            get
            {
                return _valorIndicador;
            }
            set
            {
                _valorIndicador = value;
            }
        }

        #endregion

    }
}
