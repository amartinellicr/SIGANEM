﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class UsosSuelosActualEntornosEntidad
    {

        #region PROPIEDADES

        private int _idUsoSueloActualEntorno;
        public int IdUsoSueloActualEntorno
        {
            get
            {
                return _idUsoSueloActualEntorno;
            }
            set
            {
                _idUsoSueloActualEntorno = value;
            }
        }

        private int _codUsoSueloActualEntorno;
        public int CodUsoSueloActualEntorno
        {
            get
            {
                return _codUsoSueloActualEntorno;
            }
            set
            {
                _codUsoSueloActualEntorno = value;
            }
        }

        private String _desUsoSueloActualEntorno;
        public String DesUsoSueloActualEntorno
        {
            get
            {
                return _desUsoSueloActualEntorno;
            }
            set
            {
                _desUsoSueloActualEntorno = value;
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
