﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class IndicadorEconomicoEntidad
    {

        #region PROPIEDADES

        /// <summary>
        /// Propiedad: Indicador de consulta
        /// </summary>
        private string _indicador;
        public string Indicador
        {
            get
            {
                return _indicador;
            }
            set
            {
                _indicador = value;
            }
        }

        /// <summary>
        /// Propiedad: FechaInicio
        /// </summary>
        private string _fechaInicio;
        public string FechaInicio
        {
            get
            {
                return _fechaInicio;
            }
            set
            {
                _fechaInicio = value;
            }
        }

        /// <summary>
        /// Propiedad: FechaFinal
        /// </summary>
        private string _fechaFinal;
        public string FechaFinal
        {
            get
            {
                return _fechaFinal;
            }
            set
            {
                _fechaFinal = value;
            }
        }

        /// <summary>
        /// Propiedad: NombreBanco
        /// </summary>
        private string _nombreBanco;
        public string NombreBanco
        {
            get
            {
                return _nombreBanco;
            }
            set
            {
                _nombreBanco = value;
            }
        }

        /// <summary>
        /// Propiedad: SubNiveles
        /// </summary>
        private string _subNiveles;
        public string SubNiveles
        {
            get
            {
                return _subNiveles;
            }
            set
            {
                _subNiveles = value;
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
