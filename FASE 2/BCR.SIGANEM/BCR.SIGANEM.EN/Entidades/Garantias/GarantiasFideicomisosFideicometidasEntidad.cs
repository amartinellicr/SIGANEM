using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class GarantiasFideicomisosFideicometidasEntidad
    {

        #region PROPIEDADES

        private int? _idGarantiaFideicomisoFideicometida;
        public int? IdGarantiaFideicomisoFideicometida
        {
            get { return _idGarantiaFideicomisoFideicometida; }
            set { _idGarantiaFideicomisoFideicometida = value; }
        }

        private int? _idGarantiaFideicomiso;
        public int? IdGarantiaFideicomiso
        {
            get { return _idGarantiaFideicomiso; }
            set { _idGarantiaFideicomiso = value; }
        }

        private int? _idTipoGarantia;
        public int? IdTipoGarantia
        {
            get { return _idTipoGarantia; }
            set { _idTipoGarantia = value; }
        }

        private string _desTipoGarantia;
        public string DesTipoGarantia
        {
            get { return _desTipoGarantia; }
            set { _desTipoGarantia = value; }
        }

        private int? _idGarantia;
        public int? IdGarantia
        {
            get { return _idGarantia; }
            set { _idGarantia = value; }
        }

        private int? _idGarantiaReal;
        public int? IdGarantiaReal
        {
            get { return _idGarantiaReal; }
            set { _idGarantiaReal = value; }
        }

        private string _codIdGarantia;
        public string CodIdGarantia
        {
            get { return _codIdGarantia; }
            set { _codIdGarantia = value; }
        }

        private int? _idGarantiaValor;
        public int? IdGarantiaValor
        {
            get { return _idGarantiaValor; }
            set { _idGarantiaValor = value; }
        }

        private string _idDueno;
        public string IdDueno
        {
            get { return _idDueno; }
            set { _idDueno = value; }
        }

        private string _nombreDueno;
        public string NombreDueno
        {
            get { return _nombreDueno; }
            set { _nombreDueno = value; }
        }

        private int? _idTipoMonendaValorNominal;
        public int? IdTipoMonendaValorNominal
        {
            get { return _idTipoMonendaValorNominal; }
            set { _idTipoMonendaValorNominal = value; }
        }

        private decimal? _valorNominal;
        public decimal? ValorNominal
        {
            get { return _valorNominal; }
            set { _valorNominal = value; }
        }

        private decimal? _montoMitigador;
        public decimal? MontoMitigador
        {
            get { return _montoMitigador; }
            set { _montoMitigador = value; }
        }

        private decimal? _porcentajeAceptacionTerrenoSUGEF;
        public decimal? PorcentajeAceptacionTerrenoSUGEF
        {
            get { return _porcentajeAceptacionTerrenoSUGEF; }
            set { _porcentajeAceptacionTerrenoSUGEF = value; }
        }

        private decimal? _porcentajeAceptacionNoTerrenoSUGEF;
        public decimal? PorcentajeAceptacionNoTerrenoSUGEF
        {
            get { return _porcentajeAceptacionNoTerrenoSUGEF; }
            set { _porcentajeAceptacionNoTerrenoSUGEF = value; }
        }

        private decimal? _porcentajeAceptacionSUGEF;
        public decimal? PorcentajeAceptacionSUGEF
        {
            get { return _porcentajeAceptacionSUGEF; }
            set { _porcentajeAceptacionSUGEF = value; }
        }

        private decimal? _porcentajeAceptacionBCR;
        public decimal? PorcentajeAceptacionBCR
        {
            get { return _porcentajeAceptacionBCR; }
            set { _porcentajeAceptacionBCR = value; }
        }

        private int? _idTipoMitigadorRiego;
        public int? IdTipoMitigadorRiego
        {
            get { return _idTipoMitigadorRiego; }
            set { _idTipoMitigadorRiego = value; }
        }

        private int? _idTipoDocumentoLegal;
        public int? IdTipoDocumentoLegal
        {
            get { return _idTipoDocumentoLegal; }
            set { _idTipoDocumentoLegal = value; }
        }

        private int? _idTipoIndicadorInscripcion;
        public int? IdTipoIndicadorInscripcion
        {
            get { return _idTipoIndicadorInscripcion; }
            set { _idTipoIndicadorInscripcion = value; }
        }

        private DateTime? _fechaPresentacion;
        public DateTime? FechaPresentacion
        {
            get { return _fechaPresentacion; }
            set { _fechaPresentacion = value; }
        }

        private int? _idFormatoIdentificacionVehiculo;
        public int? IdFormatoIdentificacionVehiculo
        {
            get { return _idFormatoIdentificacionVehiculo; }
            set { _idFormatoIdentificacionVehiculo = value; }
        }

        private int? _indDeudorHabita;
        public int? IndDeudorHabita
        {
            get { return _indDeudorHabita; }
            set { _indDeudorHabita = value; }
        }

        private int? _indEstadoRegistro;
        public int? IndEstadoRegistro
        {
            get { return _indEstadoRegistro; }
            set { _indEstadoRegistro = value; }
        }

        private string _indAccionRegistro;
        public string IndAccionRegistro
        {
            get { return _indAccionRegistro; }
            set { _indAccionRegistro = value; }
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
