using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.wsaIndicadores
{
    public class EsquemaEjecucion
    {

        #region PROPIEDADES

        private Esquema _tipoEsquema;
        public Esquema TipoEsquema
        {
            get { return _tipoEsquema; }
            set { _tipoEsquema = value; }
        }

        private TimeSpan _horaLunes;
        public TimeSpan HoraLunes
        {
            get { return _horaLunes; }
            set { _horaLunes = value; }
        }

        private TimeSpan _horaMartes;
        public TimeSpan HoraMartes
        {
            get { return _horaMartes; }
            set { _horaMartes = value; }
        }

        private TimeSpan _horaMiercoles;
        public TimeSpan HoraMiercoles
        {
            get { return _horaMiercoles; }
            set { _horaMiercoles = value; }
        }

        private TimeSpan _horaJueves;
        public TimeSpan HoraJueves
        {
            get { return _horaJueves; }
            set { _horaJueves = value; }
        }

        private TimeSpan _horaViernes;
        public TimeSpan HoraViernes
        {
            get { return _horaViernes; }
            set { _horaViernes = value; }
        }

        private TimeSpan _horaSabado;
        public TimeSpan HoraSabado
        {
            get { return _horaSabado; }
            set { _horaSabado = value; }
        }

        private TimeSpan _horaDomingo;
        public TimeSpan HoraDomingo
        {
            get { return _horaDomingo; }
            set { _horaDomingo = value; }
        }

        #endregion

    }
}