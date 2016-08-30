using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasOperacionesEntidad : GarantiasOperacionesClientesEntidad
    {

        #region PROPIEDADES

        private int _idGarantiaOperacion;
        public int IdGarantiaOperacion
        {
            get
            {
                return _idGarantiaOperacion;
            }
            set
            {
                _idGarantiaOperacion = value;
            }
        }

        private int? _operacion;
        public int? Operacion
        {
            get
            {
                return _operacion;
            }
            set
            {
                _operacion = value;
            }
        }

        private string _desTipoOperacion;
        public string DesTipoOperacion
        {
            get
            {
                return _desTipoOperacion;
            }
            set
            {
                _desTipoOperacion = value;
            }
        }
        
        private string _idGarantia;
        public string IdGarantia
        {
            get
            {
                return _idGarantia;
            }
            set
            {
                _idGarantia = value;
            }
        }

        private string _desEstadoReplicado;
        public string DesEstadoReplicado
        {
            get
            {
                return _desEstadoReplicado;
            }
            set
            {
                _desEstadoReplicado = value;
            }
        }

        private string _desNumeroOperacion;
        public string DesNumeroOperacion
        {
            get
            {
                return _desNumeroOperacion;
            }
            set
            {
                _desNumeroOperacion = value;
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

        #region REQUERIMIENTO 1-24493262

        private string _desTipoBien;
        public string DesTipoBien
        {
            get
            {
                return _desTipoBien;
            }
            set
            {
                _desTipoBien = value;
            }
        }

        private string _desClaseTipoBien;
        public string DesClaseTipoBien
        {
            get
            {
                return _desClaseTipoBien;
            }
            set
            {
                _desClaseTipoBien = value;
            }
        }

        #endregion

        #endregion

    }
}
