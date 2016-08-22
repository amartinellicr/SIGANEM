using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class IndicesPreciosConsumidorEntidad
    {

        #region PROPIEDADES

        private int _idIndicePrecioConsumidor;
        public int IdIndicePrecioConsumidor
        {
            get
            {
                return _idIndicePrecioConsumidor;
            }
            set
            {
                _idIndicePrecioConsumidor = value;
            }
        }

        private int _mes;
        public int Mes
        {
            get
            {
                return _mes;
            }
            set
            {
                _mes = value;
            }
        }

        private string _desMes;
        public string DesMes
        {
            get
            {
                return _desMes;
            }
            set
            {
                _desMes = value;
            }
        }

        private int _ano;
        public int Ano
        {
            get
            {
                return _ano;
            }
            set
            {
                _ano = value;
            }
        }

        private decimal _valor;
        public decimal Valor
        {
            get
            {
                return _valor;
            }
            set
            {
                _valor = value;
            }
        }

        private decimal _porcentajeInflacion;
        public decimal PorcentajeInflacion
        {
            get
            {
                return _porcentajeInflacion;
            }
            set
            {
                _porcentajeInflacion = value;
            }
        }

        private DateTime _fechaDesde;
        public DateTime FechaDesde
        {
            get
            {
                return _fechaDesde;
            }
            set
            {
                _fechaDesde = value;
            }
        }

        private DateTime _fechaHasta;
        public DateTime FechaHasta
        {
            get
            {
                return _fechaHasta;
            }
            set
            {
                _fechaHasta = value;
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