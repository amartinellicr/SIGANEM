﻿using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class TiposIndicadoresInscripcionesEntidad
    {

        #region PROPIEDADES

        private int _idTipoIndicadorInscripcion;
        public int IdTipoIndicadorInscripcion
        {
            get
            {
                return _idTipoIndicadorInscripcion;
            }
            set
            {
                _idTipoIndicadorInscripcion = value;
            }
        }

        private int _codTipoIndicadorInscripcion;
        public int CodTipoIndicadorInscripcion
        {
            get
            {
                return _codTipoIndicadorInscripcion;
            }
            set
            {
                _codTipoIndicadorInscripcion = value;
            }
        }

        private string _desTipoIndicadorInscripcion;
        public string DesTipoIndicadorInscripcion
        {
            get
            {
                return _desTipoIndicadorInscripcion;
            }
            set
            {
                _desTipoIndicadorInscripcion = value;
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
