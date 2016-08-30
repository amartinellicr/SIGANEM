using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasValoresRespuestaCDPEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: ValorEstado
        /// </summary>
        private int _valorEstado;
        public int ValorEstado
        {
            get
            {
                return _valorEstado;
            }
            set
            {
                _valorEstado = value;
            }
        }

        /// <summary>
        /// Propiedad: NumeroCDP
        /// </summary>
        private int _numeroCDP;
        public int NumeroCDP
        {
            get
            {
                return _numeroCDP;
            }
            set
            {
                _numeroCDP = value;
            }
        }

        /// <summary>
        /// Propiedad: MonedaCDP
        /// </summary>
        private int _MonedaCDP;
        public int MonedaCDP
        {
            get
            {
                return _MonedaCDP;
            }
            set
            {
                _MonedaCDP = value;
            }
        }

        /// <summary>
        /// Propiedad: FechaEmisionCDP
        /// </summary>
        private DateTime _fechaEmisionCDP;
        public DateTime FechaEmisionCDP
        {
            get
            {
                return _fechaEmisionCDP;
            }
            set
            {
                _fechaEmisionCDP = value;
            }
        }

        /// <summary>
        /// Propiedad: FechaVencimientoCDP
        /// </summary>
        private DateTime _fechaVencimientoCDP;
        public DateTime FechaVencimientoCDP
        {
            get
            {
                return _fechaVencimientoCDP;
            }
            set
            {
                _fechaVencimientoCDP = value;
            }
        }

        /// <summary>
        /// Propiedad: MontoCDP
        /// </summary>
        private Decimal? _montoCDP;
        public Decimal? MontoCDP
        {
            get
            {
                return _montoCDP;
            }
            set
            {
                _montoCDP = value;
            }
        }

        #endregion

    }
}
