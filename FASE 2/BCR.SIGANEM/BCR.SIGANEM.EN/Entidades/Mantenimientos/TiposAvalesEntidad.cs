using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class TiposAvalesEntidad
    {

        #region PROPIEDADES

        private int _idTipoAval;
        public int IdTipoAval
        {
            get
            {
                return _idTipoAval;
            }
            set
            {
                _idTipoAval = value;
            }
        }

        private int _codTipoAval;
        public int CodTipoAval
        {
            get
            {
                return _codTipoAval;;
            }
            set
            {
                _codTipoAval = value;
            }
        }

        private String _desTipoAval;
        public String DesTipoAval
        {
            get
            {
                return _desTipoAval; ;
            }
            set
            {
                _desTipoAval = value;
            }
        }

        private int _idTipoPersona;
        public int IdTipoPersona
        {
            get
            {
                return _idTipoPersona;;
            }
            set
            {
                _idTipoPersona = value;
            }
        }

        private String _desTipoPersona;
        public String DesTipoPersona
        {
            get
            {
                return _desTipoPersona; ;
            }
            set
            {
                _desTipoPersona = value;
            }
        }

        private String _idAvalista;
        public String IdAvalista
        {
            get
            {
                return _idAvalista;;
            }
            set
            {
                _idAvalista = value;
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
