using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class GarantiasFideicomisosEntidad
    {

        #region PROPIEDADES

        private int? _idGarantiaFideicomiso;
        public int? IdGarantiaFideicomiso
        {
            get { return _idGarantiaFideicomiso; }
            set { _idGarantiaFideicomiso = value; }
        }

        private string _codFidecomisoBCR;
        public string CodFidecomisoBCR
        {
            get { return _codFidecomisoBCR; }
            set { _codFidecomisoBCR = value; }
        }

        private string _codFidecomiso;
        public string CodFidecomiso
        {
            get { return _codFidecomiso; }
            set { _codFidecomiso = value; }
        }

        private string _codFideicomiso;
        public string CodFideicomiso
        {
            get { return _codFideicomiso; }
            set { _codFideicomiso = value; }
        }

        private string _nombreFideicomiso;
        public string NombreFideicomiso
        {
            get { return _nombreFideicomiso; }
            set { _nombreFideicomiso = value; }
        }

        private DateTime? _fechaConstitucion;
        public DateTime? FechaConstitucion
        {
            get { return _fechaConstitucion; }
            set { _fechaConstitucion = value; }
        }

        private string _desFechaConstitucion;
        public string DesFechaConstitucion
        {
            get
            {
                return _desFechaConstitucion;
            }
            set
            {
                _desFechaConstitucion = value;
            }
        }

        private DateTime? _fechaVencimiento;
        public DateTime? FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }

        private string _desFechaVencimiento;
        public string DesFechaVencimiento
        {
            get
            {
                return _desFechaVencimiento;
            }
            set
            {
                _desFechaVencimiento = value;
            }
        }

        private int? _idTipoMonedaValorNominal;
        public int? IdTipoMonedaValorNominal
        {
            get { return _idTipoMonedaValorNominal; }
            set { _idTipoMonedaValorNominal = value; }
        }

        private string _desFideicomiso;
        public string DesFideicomiso
        {
            get
            {
                return _desFideicomiso;
            }
            set
            {
                _desFideicomiso = value;
            }
        }

        private decimal? _valorNominal;
        public decimal? ValorNominal
        {
            get { return _valorNominal; }
            set { _valorNominal = value; }
        }

        private int? _idEstadoGarantia;
        public int? IdEstadoGarantia
        {
            get { return _idEstadoGarantia; }
            set { _idEstadoGarantia = value; }
        }

        private string _indMetodoInsercion;
        public string IndMetodoInsercion
        {
            get { return _indMetodoInsercion; }
            set { _indMetodoInsercion = value; }
        }

        private DateTime? _fechaIngreso;
        public DateTime? FechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }

        private string _codUsuarioIngreso;
        public string CodUsuarioIngreso
        {
            get { return _codUsuarioIngreso; }
            set { _codUsuarioIngreso = value; }
        }

        private string _desUsuarioIngreso;
        public string DesUsuarioIngreso
        {
            get { return _desUsuarioIngreso; }
            set { _desUsuarioIngreso = value; }
        }

        private DateTime? _fechaUltimaModificacion;
        public DateTime? FechaUltimaModificacion
        {
            get { return _fechaUltimaModificacion; }
            set { _fechaUltimaModificacion = value; }
        }

        private string _codUsuarioUltimaModificacion;
        public string CodUsuarioUltimaModificacion
        {
            get { return _codUsuarioUltimaModificacion; }
            set { _codUsuarioUltimaModificacion = value; }
        }

        private string _desUsuarioUltimaModificacion;
        public string DesUsuarioUltimaModificacion
        {
            get { return _desUsuarioUltimaModificacion; }
            set { _desUsuarioUltimaModificacion = value; }
        }

        #endregion

    }
}
