using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class EntidadesEntidad : RegimenesFiscalizacionesEntidad
    {

        #region PROPIEDADES

        private int _idEntidad;
        public int IdEntidad
        {
            get
            {
                return _idEntidad;
            }
            set
            {
                _idEntidad = value;
            }
        }

        private int _idActivo;
        public int IdActivo
        {
            get
            {
                return _idActivo;
            }
            set
            {
                _idActivo = value;
            }
        }

        private int _idTipoEntidad;
        public int IdTipoEntidad
        {
            get
            {
                return _idTipoEntidad;
            }
            set
            {
                _idTipoEntidad = value;
            }
        }

        private String _codEntidad;
        public String CodEntidad
        {
            get
            {
                return _codEntidad;
            }
            set
            {
                _codEntidad = value;
            }
        }

        private String _desEntidad;
        public String DesEntidad
        {
            get
            {
                return _desEntidad;
            }
            set
            {
                _desEntidad = value;
            }
        }

        private int _codActivo;
        public int CodActivo
        {
            get
            {
                return _codActivo;
            }
            set
            {
                _codActivo = value;
            }
        }

        private String _desActivo;
        public String DesActivo
        {
            get
            {
                return _desActivo;
            }
            set
            {
                _desActivo = value;
            }
        }

        private int _codTipoEntidad;
        public int CodTipoEntidad
        {
            get
            {
                return _codTipoEntidad;
            }
            set
            {
                _codTipoEntidad = value;
            }
        }

        private String _desTipoEntidad;
        public String DesTipoEntidad
        {
            get
            {
                return _desTipoEntidad;
            }
            set
            {
                _desTipoEntidad = value;
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