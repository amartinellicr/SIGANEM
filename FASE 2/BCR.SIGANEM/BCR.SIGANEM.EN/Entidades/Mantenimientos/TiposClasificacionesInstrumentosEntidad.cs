using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class TiposClasificacionesInstrumentosEntidad
    {

        #region PROPIEDADES

        private int _idTipoClasificacionInstrumento;
        public int IdTipoClasificacionInstrumento
        {
            get
            {
                return _idTipoClasificacionInstrumento;
            }
            set
            {
                _idTipoClasificacionInstrumento = value;
            }
        }

        private int _codTipoClasificacionInstrumento;
        public int CodTipoClasificacionInstrumento
        {
            get
            {
                return _codTipoClasificacionInstrumento;
            }
            set
            {
                _codTipoClasificacionInstrumento = value;
            }
        }

        private string _desTipoClasificacionInstrumento;
        public string DesTipoClasificacionInstrumento
        {
            get
            {
                return _desTipoClasificacionInstrumento;
            }
            set
            {
                _desTipoClasificacionInstrumento = value;
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
