using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class FiscalizadoresEntidad : TiposPersonasEntidad
    {

        #region PROPIEDADES

        private int _idFiscalizador;
        public int IdFiscalizador
        {
            get
            {
                return _idFiscalizador;
            }
            set
            {
                _idFiscalizador = value;
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

        private string _codTipoFiscalizador;
        public string CodTipoFiscalizador
        {
            get
            {
                return _codTipoFiscalizador;
            }
            set
            {
                _codTipoFiscalizador = value;
            }
        }

        private string _desTipoFiscalizador;
        public string DesTipoFiscalizador
        {
            get
            {
                return _desTipoFiscalizador;
            }
            set
            {
                _desTipoFiscalizador = value;
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
