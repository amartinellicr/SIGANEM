using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasRealesTasadoresEntidad : GarantiasRealesEntidad
    {

        #region PROPIEDADES

        private int _idGarantiaRealTasador;
        public int IdGarantiaRealTasador
        {
            get
            {
                return _idGarantiaRealTasador;
            }
            set
            {
                _idGarantiaRealTasador = value;
            }
        }

        private int _idVisible;
        public int Id_Visible
        {
            get
            {
                return _idVisible;
            }
            set
            {
                _idVisible = value;
            }
        }

        private int _idTasador;
        public int IdTasador
        {
            get
            {
                return _idTasador;
            }
            set
            {
                _idTasador = value;
            }
        }

        private string _codTasador;
        public string CodTasador
        {
            get
            {
                return _codTasador;
            }
            set
            {
                _codTasador = value;
            }
        }

        private string _desNombreTasador;
        public string DesNombreTasador
        {
            get
            {
                return _desNombreTasador;
            }
            set
            {
                _desNombreTasador = value;
            }
        }

        private string _desTipoPersona;
        public string DesTipoPersona
        {
            get
            {
                return _desTipoPersona;
            }
            set
            {
                _desTipoPersona = value;
            }
        }

        private string _origenTasador;
        public string OrigenTasador
        {
            get
            {
                return _origenTasador;
            }
            set
            {
                _origenTasador = value;
            }
        }

        #endregion

    }
}
