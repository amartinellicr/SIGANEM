using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class PolizaEntidad
    {
        #region PROPIEDADES

        private int idPoliza;
        public int IdPoliza
        {
            get { return idPoliza; }
            set { idPoliza = value; }
        }

        private int idGarantiaReal;
        public int IdGarantiaReal
        {
            get { return idGarantiaReal; }
            set { idGarantiaReal = value; }
        }
                
        private string idTipoNivelPoliza;
        public string IdTipoNivelPoliza
        {
            get { return idTipoNivelPoliza; }
            set { idTipoNivelPoliza = value; }
        }

        private Int64? nsap;
        public Int64? Nsap
        {
            get { return nsap; }
            set { nsap = value; }
        }

        private string nPoliza;
        public string NPoliza
        {
            get { return nPoliza; }
            set { nPoliza = value; }
        }

        private DateTime fechaEmision;
        public DateTime FechaEmision
        {
            get { return fechaEmision; }
            set { fechaEmision = value; }
        }

        private DateTime fechaVencimiento;
        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }

        private int idTipoMoneda;
        public int IdTipoMoneda
        {
            get { return idTipoMoneda; }
            set { idTipoMoneda = value; }
        }

        private decimal montoPoliza;
        public decimal MontoPoliza
        {
            get { return montoPoliza; }
            set { montoPoliza = value; }
        }

        private decimal? montoPolizaColonizado;
        public decimal? MontoPolizaColonizado
        {
            get { return montoPolizaColonizado; }
            set { montoPolizaColonizado = value; }
        }

        private string indCobertura;
        public string IndCobertura
        {
            get { return indCobertura; }
            set { indCobertura = value; }
        }

        private int idTipoIdentificacionRUC;
        public int IdTipoIdentificacionRUC
        {
            get { return idTipoIdentificacionRUC; }
            set { idTipoIdentificacionRUC = value; }
        }

        private string identificacion;
        public string Identificacion
        {
            get { return identificacion; }
            set { identificacion = value; }
        }

        private int _idVisible;
        public int Id_Visible
        {
            get
            {
                return _idVisible;
            }
            set
            {
                _idVisible = value;
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
