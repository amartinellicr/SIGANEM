using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasRealesEntidad : TiposBienesEntidad
    {

        #region PROPIEDADES

        private int _idGarantiaReal;
        public int IdGarantiaReal
        {
            get
            {
                return _idGarantiaReal;
            }
            set
            {
                _idGarantiaReal = value;
            }
        }

        private int? _idClaseAeronave;
        public int? IdClaseAeronave
        {
            get
            {
                return _idClaseAeronave;
            }
            set
            {
                _idClaseAeronave = value;
            }
        }

        private int? _idClaseBuque;
        public int? IdClaseBuque
        {
            get
            {
                return _idClaseBuque;
            }
            set
            {
                _idClaseBuque = value;
            }
        }

        private int? _idClaseTipoBien;
        public int? IdClaseTipoBien
        {
            get
            {
                return _idClaseTipoBien;
            }
            set
            {
                _idClaseTipoBien = value;
            }
        }

        private int? _idClaseVehiculo;
        public int? IdClaseVehiculo
        {
            get
            {
                return _idClaseVehiculo;
            }
            set
            {
                _idClaseVehiculo = value;
            }
        }

        private int? _idCodigoDuplicado;
        public int? IdCodigoDuplicado
        {
            get
            {
                return _idCodigoDuplicado;
            }
            set
            {
                _idCodigoDuplicado = value;
            }
        }

        private int? _idCodigoHorizontalidad;
        public int? IdCodigoHorizontalidad
        {
            get
            {
                return _idCodigoHorizontalidad;
            }
            set
            {
                _idCodigoHorizontalidad = value;
            }
        }

        private int? _idProvincia;
        public int? IdProvincia
        {
            get
            {
                return _idProvincia;
            }
            set
            {
                _idProvincia = value;
            }
        }

        private int? _idTipoLiquidez;
        public int? IdTipoLiquidez
        {
            get
            {
                return _idTipoLiquidez;
            }
            set
            {
                _idTipoLiquidez = value;
            }
        }

        private int? _idTipoMoneda;
        public int? IdTipoMoneda
        {
            get
            {
                return _idTipoMoneda;
            }
            set
            {
                _idTipoMoneda = value;
            }
        }

        private int? _idTipoAlmacen;
        public int? IdTipoAlmacen
        {
            get
            {
                return _idTipoAlmacen;
            }
            set
            {
                _idTipoAlmacen = value;
            }
        }

        private int? _idEstadoGarantia;
        public int? IdEstadoGarantia
        {
            get
            {
                return _idEstadoGarantia;
            }
            set
            {
                _idEstadoGarantia = value;
            }
        }

        private int? _bonoPrenda;
        public int? BonoPrenda
        {
            get
            {
                return _bonoPrenda;
            }
            set
            {
                _bonoPrenda = value;
            }
        }

        private int? _cedulaHipotecaria;
        public int? CedulaHipotecaria
        {
            get
            {
                return _cedulaHipotecaria;
            }
            set
            {
                _cedulaHipotecaria = value;
            }
        }

        private int? _estadoRegistroGarantia;
        public int? EstadoRegistroGarantia
        {
            get
            {
                return _estadoRegistroGarantia;
            }
            set
            {
                _estadoRegistroGarantia = value;
            }
        }

        private int? _formatoIdentificacionVehiculo;
        public int? FormatoIdentificacionVehiculo
        {
            get
            {
                return _formatoIdentificacionVehiculo;
            }
            set
            {
                _formatoIdentificacionVehiculo = value;
            }
        }

        private int? _hipotecaAbierta;
        public int? HipotecaAbierta
        {
            get
            {
                return _hipotecaAbierta;
            }
            set
            {
                _hipotecaAbierta = value;
            }
        }

        private int? _indGravamen;
        public int? IndGravamen
        {
            get
            {
                return _indGravamen;
            }
            set
            {
                _indGravamen = value;
            }
        }

        private string _codBien;
        public string CodBien
        {
            get
            {
                return _codBien;
            }
            set
            {
                _codBien = value;
            }
        }

        private string _desTipoMoneda;
        public string DesTipoMoneda
        {
            get
            {
                return _desTipoMoneda;
            }
            set
            {
                _desTipoMoneda = value;
            }
        }

        private string _desClaseVehiculo;
        public string DesClaseVehiculo
        {
            get
            {
                return _desClaseVehiculo;
            }
            set
            {
                _desClaseVehiculo = value;
            }
        }

        private string _desFechaUltimaTasacionGarantia;
        public string DesFechaUltimaTasacionGarantia
        {
            get
            {
                return _desFechaUltimaTasacionGarantia;
            }
            set
            {
                _desFechaUltimaTasacionGarantia = value;
            }
        }

        private string _desFechaUltimoSeguimientoGarantia;
        public string DesFechaUltimoSeguimientoGarantia
        {
            get
            {
                return _desFechaUltimoSeguimientoGarantia;
            }
            set
            {
                _desFechaUltimoSeguimientoGarantia = value;
            }
        }

        private string _desMontoTotalUltimaTasacion;
        public string DesMontoTotalUltimaTasacion
        {
            get
            {
                return _desMontoTotalUltimaTasacion;
            }
            set
            {
                _desMontoTotalUltimaTasacion = value;
            }
        }

        private string _desMontoTotalTasacionActualizada;
        public string DesMontoTotalTasacionActualizada
        {
            get
            {
                return _desMontoTotalTasacionActualizada;
            }
            set
            {
                _desMontoTotalTasacionActualizada = value;
            }
        }

        private decimal? _montoUltimaTasacionNoTerreno;
        public decimal? MontoUltimaTasacionNoTerreno
        {
            get
            {
                return _montoUltimaTasacionNoTerreno;
            }
            set
            {
                _montoUltimaTasacionNoTerreno = value;
            }
        }

        private decimal? _montoUltimaTasacionTerreno;
        public decimal? MontoUltimaTasacionTerreno
        {
            get
            {
                return _montoUltimaTasacionTerreno;
            }
            set
            {
                _montoUltimaTasacionTerreno = value;
            }
        }

        private decimal? _montoTotalUltimaTasacion;
        public decimal? MontoTotalUltimaTasacion
        {
            get
            {
                return _montoTotalUltimaTasacion;
            }
            set
            {
                _montoTotalUltimaTasacion = value;
            }
        }

        private decimal? _montoTasacionActualizadaNoTerreno;
        public decimal? MontoTasacionActualizadaNoTerreno
        {
            get
            {
                return _montoTasacionActualizadaNoTerreno;
            }
            set
            {
                _montoTasacionActualizadaNoTerreno = value;
            }
        }

        private decimal? _montoTasacionActualizadaTerreno;
        public decimal? MontoTasacionActualizadaTerreno
        {
            get
            {
                return _montoTasacionActualizadaTerreno;
            }
            set
            {
                _montoTasacionActualizadaTerreno = value;
            }
        }

        private decimal? _montoTotalTasacionActualizada;
        public decimal? MontoTotalTasacionActualizada
        {
            get
            {
                return _montoTotalTasacionActualizada;
            }
            set
            {
                _montoTotalTasacionActualizada = value;
            }
        }

        private decimal? _montoValorTotalCedula;
        public decimal? MontoValorTotalCedula
        {
            get
            {
                return _montoValorTotalCedula;
            }
            set
            {
                _montoValorTotalCedula = value;
            }
        }

        private DateTime? _fechaUltimoSeguimientoGarantia;
        public DateTime? FechaUltimoSeguimientoGarantia
        {
            get
            {
                return _fechaUltimoSeguimientoGarantia;
            }
            set
            {
                _fechaUltimoSeguimientoGarantia = value;
            }
        }

        private DateTime? _fechaVencimientoAvaluoSUGEF;
        public DateTime? FechaVencimientoAvaluoSUGEF
        {
            get
            {
                return _fechaVencimientoAvaluoSUGEF;
            }
            set
            {
                _fechaVencimientoAvaluoSUGEF = value;
            }
        }

        private DateTime? _fechaConstruccionGarantia;
        public DateTime? FechaConstruccionGarantia
        {
            get
            {
                return _fechaConstruccionGarantia;
            }
            set
            {
                _fechaConstruccionGarantia = value;
            }
        }

        private DateTime? _fechaActualizacionGarantia;
        public DateTime? FechaActualizacionGarantia
        {
            get
            {
                return _fechaActualizacionGarantia;
            }
            set
            {
                _fechaActualizacionGarantia = value;
            }
        }

        private DateTime? _fechaFabricacionGarantia;
        public DateTime? FechaFabricacionGarantia
        {
            get
            {
                return _fechaFabricacionGarantia;
            }
            set
            {
                _fechaFabricacionGarantia = value;
            }
        }

        private DateTime? _fechaUltimaTasacionGarantia;
        public DateTime? FechaUltimaTasacionGarantia
        {
            get
            {
                return _fechaUltimaTasacionGarantia;
            }
            set
            {
                _fechaUltimaTasacionGarantia = value;
            }
        }

        private string justificacion;
        public string Justificacion
        {
            get { return justificacion; }
            set { justificacion = value; }
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
