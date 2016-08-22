using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class CategoriasCalificacionesTiposMitigadoresRiesgosEntidad  
    {

        #region PROPIEDADES

        private int _idCategoriaCalificacionRiesgoTipoMitigador;
        public int IdCategoriaCalificacionRiesgoTipoMitigador
        {
            get
            {
                return _idCategoriaCalificacionRiesgoTipoMitigador;
            }
            set
            {
                _idCategoriaCalificacionRiesgoTipoMitigador = value;
            }
        }

        private int _idCategoriaCalificacion;
        public int IdCategoriaCalificacion
        {
            get
            {
                return _idCategoriaCalificacion;
            }
            set
            {
                _idCategoriaCalificacion = value;
            }
        }

        private int _idTipoMitigadorRiesgo;
        public int IdTipoMitigadorRiesgo
        {
            get
            {
                return _idTipoMitigadorRiesgo;
            }
            set
            {
                _idTipoMitigadorRiesgo = value;
            }
        }
		
		private int _idTipoGarantia;
        public int IdTipoGarantia
        {
            get
            {
                return _idTipoGarantia;
            }
            set
            {
                _idTipoGarantia = value;
            }
        }
		
		private string _desCategoriaCalificacion;
        public string DesCategoriaCalificacion
        {
            get
            {
                return _desCategoriaCalificacion;
            }
            set
            {
                _desCategoriaCalificacion = value;
            }
        }
		
		private string _desTipoGarantia;
        public string DesTipoGarantia
        {
            get
            {
                return _desTipoGarantia;
            }
            set
            {
                _desTipoGarantia = value;
            }
        }
		
		private decimal _porcentajeAceptacionCalificacionRiesgo;
        public decimal PorcentajeAceptacionCalificacionRiesgo
        {
            get
            {
                return _porcentajeAceptacionCalificacionRiesgo;
            }
            set
            {
                _porcentajeAceptacionCalificacionRiesgo = value;
            }
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
