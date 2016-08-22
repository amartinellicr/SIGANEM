using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class GarantiasAvalesEntidad
    {
        private int _idGarantiaAval;
        public int IdGarantiaAval
        {
            get
            {
                return _idGarantiaAval;
            }
            set
            {
                _idGarantiaAval = value;
            }
        }

        private int? _idTipoAval;
        public int? IdTipoAval
        {
            get
            {
                return _idTipoAval;
            }
            set
            {
                _idTipoAval = value;
            }
        }

        private string _numeroAval;
        public string NumeroAval
        {
            get
            {
                return _numeroAval; ;
            }
            set
            {
                _numeroAval = value;
            }
        }

        private decimal? _montoAvalado;
        public decimal? MontoAvalado
        {
            get
            {
                return _montoAvalado;
            }
            set
            {
                _montoAvalado = value;
            }
        }

        private string _codGarantiaBCR;
        public string CodGarantiaBCR
        {
            get
            {
                return _codGarantiaBCR;
            }
            set
            {
                _codGarantiaBCR = value;
            }
        }

        private DateTime? _fechaEmision;
        public DateTime? FechaEmision
        {
            get
            {
                return _fechaEmision;
            }
            set
            {
                _fechaEmision = value;
            }
        }

        private string _desFechaEmision;
        public string DesFechaEmision
        {
            get
            {
                return _desFechaEmision;
            }
            set
            {
                _desFechaEmision = value;
            }
        }

        private DateTime? _fechaVencimiento;
        public DateTime? FechaVencimiento
        {
            get
            {
                return _fechaVencimiento;
            }
            set
            {
                _fechaVencimiento = value;
            }
        }

        private int? _idTipoPersonaDeudor;
        public int? IdTipoPersonaDeudor
        {
            get
            {
                return _idTipoPersonaDeudor;
            }
            set
            {
                _idTipoPersonaDeudor = value;
            }
        }

        private string _desTipoPersonaDeudor;
        public string DesTipoPersonaDeudor
        {
            get
            {
                return _desTipoPersonaDeudor;
            }
            set
            {
                _desTipoPersonaDeudor = value;
            }
        }

        private string _idDeudor;
        public string IdDeudor
        {
            get
            {
                return _idDeudor;
            }
            set
            {
                _idDeudor = value;
            }
        }

        private string _desTipoAval;
        public string DesTipoAval
        {
            get
            {
                return _desTipoAval;
            }
            set
            {
                _desTipoAval = value;
            }
        }

        private int? _idTipoAsignacionCalificacion;
        public int? IdTipoAsignacionCalificacion
        {
            get
            {
                return _idTipoAsignacionCalificacion;
            }
            set
            {
                _idTipoAsignacionCalificacion = value;
            }
        }

        private int? _idPlazoCalificacion;
        public int? IdPlazoCalificacion
        {
            get
            {
                return _idPlazoCalificacion;
            }
            set
            {
                _idPlazoCalificacion = value;
            }
        }

        private int? _idEmpresaCalificadora;
        public int? IdEmpresaCalificadora
        {
            get
            {
                return _idEmpresaCalificadora;
            }
            set
            {
                _idEmpresaCalificadora = value;
            }
        }

        private int? _idCategoriaRiesgoEmpresaCalificadora;
        public int? IdCategoriaRiesgoEmpresaCalificadora
        {
            get
            {
                return _idCategoriaRiesgoEmpresaCalificadora;
            }
            set
            {
                _idCategoriaRiesgoEmpresaCalificadora = value;
            }
        }

        private int? _idCalificacionEmpresaCalificadora;
        public int? IdCalificacionEmpresaCalificadora
        {
            get
            {
                return _idCalificacionEmpresaCalificadora;
            }
            set
            {
                _idCalificacionEmpresaCalificadora = value;
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

    }
}
