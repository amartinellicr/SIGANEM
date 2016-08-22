using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class TasadoresEntidad : TiposPersonasEntidad
    {

        #region PROPIEDADES

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

        private string _desOrigenTasador;
        public string DesOrigenTasador
        {
            get
            {
                return _desOrigenTasador;
            }
            set
            {
                _desOrigenTasador = value;
            }
        }

        private string codTipoTasador;
        public string CodTipoTasador
        {
            get
            {
                return codTipoTasador;
            }
            set
            {
                codTipoTasador = value;
            }
        }

        private string desTipoTasador;
        public string DesTipoTasador
        {
            get
            {
                return desTipoTasador;
            }
            set
            {
                desTipoTasador = value;
            }
        }

        #region REQUERIMIENTO: 1-24381561

        private string _IndMetodoInsercion;
        public string IndMetodoInsercion
        {
            get
            {
                return _IndMetodoInsercion;
            }
            set
            {
                _IndMetodoInsercion = value;
            }
        }

        private DateTime? _FechaIngreso;
        public DateTime? FechaIngreso
        {
            get
            {
                return _FechaIngreso;
            }
            set
            {
                _FechaIngreso = value;
            }
        }

        private string _CodUsuarioIngreso;
        public string CodUsuarioIngreso
        {
            get
            {
                return _CodUsuarioIngreso;
            }
            set
            {
                _CodUsuarioIngreso = value;
            }
        }

        private string _DesUsuarioIngreso;
        public string DesUsuarioIngreso
        {
            get
            {
                return _DesUsuarioIngreso;
            }
            set
            {
                _DesUsuarioIngreso = value;
            }
        }

        private DateTime? _FechaUltimaModificacion;
        public DateTime? FechaUltimaModificacion
        {
            get
            {
                return _FechaUltimaModificacion;
            }
            set
            {
                _FechaUltimaModificacion = value;
            }
        }

        private string _CodUsuarioUltimaModificacion;
        public string CodUsuarioUltimaModificacion
        {
            get
            {
                return _CodUsuarioUltimaModificacion;
            }
            set
            {
                _CodUsuarioUltimaModificacion = value;
            }
        }

        private string _DesUsuarioUltimaModificacion;
        public string DesUsuarioUltimaModificacion
        {
            get
            {
                return _DesUsuarioUltimaModificacion;
            }
            set
            {
                _DesUsuarioUltimaModificacion = value;
            }
        }

        #endregion

        #endregion

    }
}
