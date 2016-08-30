﻿using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class DistribucionesZonasTasadoresEntidad : DistritosEntidad 
    {

         #region PROPIEDADES

        private int _idDistribucionZonaTasador;
        public int IdDistribucionZonaTasador
        {
            get
            {
                return _idDistribucionZonaTasador;
            }
            set
            {
                _idDistribucionZonaTasador = value;
            }
        }

        private int _idZonaTasador;
        public int IdZonaTasador
        {
            get
            {
                return _idZonaTasador;
            }
            set
            {
                _idZonaTasador = value;
            }
        }

        private string _codZonaTasador;
        public string CodZonaTasador
        {
            get
            {
                return _codZonaTasador;
            }
            set
            {
                _codZonaTasador = value;
            }
        }

        private string _desZonaTasador;
        public string DesZonaTasador
        {
            get
            {
                return _desZonaTasador;
            }
            set
            {
                _desZonaTasador = value;
            }
        }

        private string _codTipoDistribucionZonaTasador;
        public string CodTipoDistribucionZonaTasador
        {
            get
            {
                return _codTipoDistribucionZonaTasador;
            }
            set
            {
                _codTipoDistribucionZonaTasador = value;
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