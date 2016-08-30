using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasFiduciariasEntidad
    {

        #region PROPIEDADES

        private int _idGarantiaFiduciaria;
        public int IdGarantiaFiduciaria
        {
            get
            {
                return _idGarantiaFiduciaria;
            }
            set
            {
                _idGarantiaFiduciaria = value;
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

        private int _idTipoAsignacionCalificacion;
        public int IdTipoAsignacionCalificacion
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

        private int _idTipoAvalFianza;
        public int IdTipoAvalFianza
        {
            get
            {
                return _idTipoAvalFianza;
            }
            set
            {
                _idTipoAvalFianza = value;
            }
        }

        private int _idTipoIdentificacionRUC;
        public int IdTipoIdentificacionRUC
        {
            get
            {
                return _idTipoIdentificacionRUC;
            }
            set
            {
                _idTipoIdentificacionRUC = value;
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

        private string _codGarantia;
        public string CodGarantia
        {
            get
            {
                return _codGarantia;
            }
            set
            {
                _codGarantia = value;
            }
        }

        private string _nombreRUC;
        public string NombreRUC
        {
            get
            {
                return _nombreRUC;
            }
            set
            {
                _nombreRUC = value;
            }
        }

        private string _identificacionSICC;
        public string IdentificacionSICC
        {
            get
            {
                return _identificacionSICC;
            }
            set
            {
                _identificacionSICC = value;
            }
        }

        private string _desTipoIdentificacionRUC;
        public string DesTipoIdentificacionRUC
        {
            get
            {
                return _desTipoIdentificacionRUC;
            }
            set
            {
                _desTipoIdentificacionRUC = value;
            }
        }

        private string _desTipoAvalFianza;
        public string DesTipoAvalFianza
        {
            get
            {
                return _desTipoAvalFianza;
            }
            set
            {
                _desTipoAvalFianza = value;
            }
        }

        private DateTime? _fechaVerificacionAsalariado;
        public DateTime? FechaVerificacionAsalariado
        {
            get
            {
                return _fechaVerificacionAsalariado;
            }
            set
            {
                _fechaVerificacionAsalariado = value;
            }
        }

        private Decimal? _salarioNetoFiador;
        public Decimal? SalarioNetoFiador
        {
            get
            {
                return _salarioNetoFiador;
            }
            set
            {
                _salarioNetoFiador = value;
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
