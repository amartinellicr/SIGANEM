using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class InscripcionGarantiasRealesEntidad
    {
        #region PROPIEDADES

        private int _idInscripcionGarantiaReal;
        public int IdInscripcionGarantiaReal
        {
            get
            {
                return _idInscripcionGarantiaReal;
            }
            set
            {
                _idInscripcionGarantiaReal = value;
            }
        }

        private int _idGarantiaOperacion;
        public int IdGarantiaOperacion
        {
            get
            {
                return _idGarantiaOperacion;
            }
            set
            {
                _idGarantiaOperacion = value;
            }
        }

        private int _idOperacion;
        public int IdOperacion
        {
            get
            {
                return _idOperacion;
            }
            set
            {
                _idOperacion = value;
            }
        }

        private int _idGarantiaReal;
        public int IdGarantiaReal
        {
            get
            {
                return _idGarantiaReal;
            }
            set
            {
                _idGarantiaReal = value;
            }
        }

        private int _indInscripcion;
        public int IndInscripcion
        {
            get
            {
                return _indInscripcion;
            }
            set
            {
                _indInscripcion = value;
            }
        }

        private DateTime? _fechaAnotacion;
        public DateTime? FechaAnotacion
        {
            get
            {
                return _fechaAnotacion;
            }
            set
            {
                _fechaAnotacion = value;
            }
        }

        private DateTime? _fechaIscripcion;
        public DateTime? FechaInscripcion
        {
            get
            {
                return _fechaIscripcion;
            }
            set
            {
                _fechaIscripcion = value;
            }
        }

        private string _partido;
        public string Partido
        {
            get
            {
                return _partido;
            }
            set
            {
                _partido = value;
            }
        }

        private string _tomo;
        public string Tomo
        {
            get
            {
                return _tomo;
            }
            set
            {
                _tomo = value;
            }
        }
        
        private string _folio;
        public string Folio
        {
            get
            {
                return _folio;
            }
            set
            {
                _folio = value;
            }
        }

        private string _asiento;
        public string Asiento
        {
            get
            {
                return _asiento;
            }
            set
            {
                _asiento = value;
            }
        }

        private string _secuencia;
        public string Secuencia
        {
            get
            {
                return _secuencia;
            }
            set
            {
                _secuencia = value;
            }
        }

        private string _subSecuencia;
        public string SubSecuencia
        {
            get
            {
                return _subSecuencia;
            }
            set
            {
                _subSecuencia = value;
            }
        }

        private string _consecutivo;
        public string Consecutivo
        {
            get
            {
                return _consecutivo;
            }
            set
            {
                _consecutivo = value;
            }
        }

        private string _desNumeroOperacion;
        public string DesNumeroOperacion
        {
            get
            {
                return _desNumeroOperacion;
            }
            set
            {
                _desNumeroOperacion = value;
            }
        }

        private string _numeroBien;
        public string NumeroBien
        {
            get
            {
                return _numeroBien;
            }
            set
            {
                _numeroBien = value;
            }
        }

        private string _desTipoBien;
        public string DesTipoBien
        {
            get
            {
                return _desTipoBien;
            }
            set
            {
                _desTipoBien = value;
            }
        }
        
        private string _desIndInscripcion;
        public string DesIndInscripcion
        {
            get
            {
                return _desIndInscripcion;
            }
            set
            {
                _desIndInscripcion = value;
            }
        }

        private int? _idAbogado;
        public int? IdAbogado
        {
            get
            {
                return _idAbogado;
            }
            set
            {
                _idAbogado = value;
            }
        }

        private string _comentario;
        public string Comentario
        {
            get
            {
                return _comentario;
            }
            set
            {
                _comentario = value;
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
