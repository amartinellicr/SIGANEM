using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class BitacoraProcesosDetalle : ProcesosEntidad
    {
        #region PROPIEDADES

        private int idBitacoraProceso;
        public int IdBitacoraProceso
        {
            get { return idBitacoraProceso; }
            set { idBitacoraProceso = value; }
        }
        
        private string desEstado;
        public string DesEstado
        {
            get { return desEstado; }
            set { desEstado = value; }
        }

        private DateTime fechaEjecucion;
        public DateTime FechaEjecucion
        {
            get { return fechaEjecucion; }
            set { fechaEjecucion = value; }
        }

        private string desFechaEjecucion;
        public string DesFechaEjecucion
        {
            get { return desFechaEjecucion; }
            set { desFechaEjecucion = value; }
        }

        #endregion
    }
}
