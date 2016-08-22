using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasValoresRespuestaISINEntidad
    {

        #region PROPIEDADES

        private int _idTipoInstrumento;
        public int IdTipoInstrumento
        {
            get
            {
                return _idTipoInstrumento;
            }
            set
            {
                _idTipoInstrumento = value;
            }
        }

        private int _idInstrumento;
        public int IdInstrumento
        {
            get
            {
                return _idInstrumento;
            }
            set
            {
                _idInstrumento = value;
            }
        }

        private int _idEmisor;
        public int IdEmisor
        {
            get
            {
                return _idEmisor;
            }
            set
            {
                _idEmisor = value;
            }
        }

        private string _ISIN;
        public string ISIN
        {
            get
            {
                return _ISIN;
            }
            set
            {
                _ISIN = value;
            }
        }

        private string _clasificacionInstrumento;
        public string ClasificacionInstrumento
        {
            get
            {
                return _clasificacionInstrumento;
            }
            set
            {
                _clasificacionInstrumento = value;
            }
        }

        private Decimal? _premio;
        public Decimal? Premio
        {
            get
            {
                return _premio;
            }
            set
            {
                _premio = value;
            }
        }

        private int? _idMonedaValorFacial;
        public int? IdMonedaValorFacial
        {
            get
            {
                return _idMonedaValorFacial;
            }
            set
            {
                _idMonedaValorFacial = value;
            }
        }

        private DateTime? _fechaVencimiento;
        public DateTime? FechaVencimiento
        {
            get
            {
                return _fechaVencimiento;
            }
            set
            {
                _fechaVencimiento = value;
            }
        }

        #endregion

    }
}
