using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class GarantiasFideicomisosPrioridadesEntidad
    {

        #region PROPIEDADES

        private int? _idGarantiaFideicomisosPrioridad;
        public int? IdGarantiaFideicomisosPrioridad
        {
            get { return _idGarantiaFideicomisosPrioridad; }
            set { _idGarantiaFideicomisosPrioridad = value; }
        }

        private int? _idGarantiaFideicomiso;
        public int? IdGarantiaFideicomiso
        {
            get { return _idGarantiaFideicomiso; }
            set { _idGarantiaFideicomiso = value; }
        }

        private int? _idTipoGradoPrioridad;
        public int? IdTipoGradoPrioridad
        {
            get { return _idTipoGradoPrioridad; }
            set { _idTipoGradoPrioridad = value; }
        }

        private string _desTipoGradoPrioridad;

        public string DesTipoGradoPrioridad
        {
            get { return _desTipoGradoPrioridad; }
            set { _desTipoGradoPrioridad = value; }
        }

        private string _desTipoMonedaSaldoPrioridad;

        public string DesTipoMonedaSaldoPrioridad
        {
            get { return _desTipoMonedaSaldoPrioridad; }
            set { _desTipoMonedaSaldoPrioridad = value; }
        }
        
        private int? _idTipoMonedaSaldoPrioridad;
        public int? IdTipoMonedaSaldoPrioridad
        {
            get { return _idTipoMonedaSaldoPrioridad; }
            set { _idTipoMonedaSaldoPrioridad = value; }
        }

        private decimal? _saldoPrioridad;
        public decimal? SaldoPrioridad
        {
            get { return _saldoPrioridad; }
            set { _saldoPrioridad = value; }
        }

        private int? _idTipoPersonaBeneficiario;
        public int? IdTipoPersonaBeneficiario
        {
            get { return _idTipoPersonaBeneficiario; }
            set { _idTipoPersonaBeneficiario = value; }
        }

        private string _idBeneficiario;
        public string IdBeneficiario
        {
            get { return _idBeneficiario; }
            set { _idBeneficiario = value; }
        }

        private string _nombreBenefiario;
        public string NombreBenefiario
        {
            get { return _nombreBenefiario; }
            set { _nombreBenefiario = value; }
        }

        private decimal? _tipoCambio;
        public decimal? TipoCambio
        {
            get { return _tipoCambio; }
            set { _tipoCambio = value; }
        }

        private decimal? _saldoColonizado;
        public decimal? SaldoColonizado
        {
            get { return _saldoColonizado; }
            set { _saldoColonizado = value; }
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
