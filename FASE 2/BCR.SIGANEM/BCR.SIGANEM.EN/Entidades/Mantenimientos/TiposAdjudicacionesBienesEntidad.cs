using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class TiposAdjudicacionesBienesEntidad
    {

        #region PROPIEDADES

        private int _idTipoAdjudicacionBien;
        public int IdTipoAdjudicacionBien
        {
            get
            {
                return _idTipoAdjudicacionBien;
            }
            set
            {
                _idTipoAdjudicacionBien = value;
            }
        }

        private int _codTipoAdjudicacionBien;
        public int CodTipoAdjudicacionBien
        {
            get
            {
                return _codTipoAdjudicacionBien;
            }
            set
            {
                _codTipoAdjudicacionBien = value;
            }
        }

        private string _desTipoAdjudicacionBien;
        public string DesTipoAdjudicacionBien
        {
            get
            {
                return _desTipoAdjudicacionBien;
            }
            set
            {
                _desTipoAdjudicacionBien = value;
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
