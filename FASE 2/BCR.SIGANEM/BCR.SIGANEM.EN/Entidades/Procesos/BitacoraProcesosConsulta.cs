using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class BitacoraProcesosConsulta
    {
        #region PROPIEDADES

        private int idProceso;
        public int IdProceso
        {
            get { return idProceso; }
            set { idProceso = value; }
        }

        private DateTime fechaDesde;
        public DateTime FechaDesde
        {
            get { return fechaDesde; }
            set { fechaDesde = value; }
        }

        private DateTime fechaHasta;
        public DateTime FechaHasta
        {
            get { return fechaHasta; }
            set { fechaHasta = value; }
        }
        

        #endregion
    }
}
