using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class CaracteristicasTasadoresEntidad : TasadoresEntidad 
    {

        #region PROPIEDADES

        private int _idCaracteristicaTasador;
        public int IdCaracteristicaTasador
        {
            get
            {
                return _idCaracteristicaTasador;
            }
            set
            {
                _idCaracteristicaTasador = value;
            }
        }

        private string _codEmpresaTasadora;
        public string CodEmpresaTasadora
        {
            get
            {
                return _codEmpresaTasadora;
            }
            set
            {
                _codEmpresaTasadora = value;
            }
        }

        private string _desEmpresaTasadora;
        public string DesEmpresaTasadora
        {
            get
            {
                return _desEmpresaTasadora;
            }
            set
            {
                _desEmpresaTasadora = value;
            }
        }

        private int _idTipoServicio;
        public int IdTipoServicio
        {
            get
            {
                return _idTipoServicio;
            }
            set
            {
                _idTipoServicio = value;
            }
        }

        private string _desTipoServicio;
        public string DesTipoServicio
        {
            get
            {
                return _desTipoServicio;
            }
            set
            {
                _desTipoServicio = value;
            }
        }

        private int _idZonaTasador;
        public int IdZonaTasador
        {
            get
            {
                return _idZonaTasador;
            }
            set
            {
                _idZonaTasador = value;
            }
        }

        private string _desZonaTasador;
        public string DesZonaTasador
        {
            get
            {
                return _desZonaTasador;
            }
            set
            {
                _desZonaTasador = value;
            }
        }

        private string _codTipoCaracteristicaTasador;
        public string CodTipoCaracteristicaTasador
        {
            get
            {
                return _codTipoCaracteristicaTasador;
            }
            set
            {
                _codTipoCaracteristicaTasador = value;
            }
        }

        private int _idTipoPersonaTasador;
        public int IdTipoPersonaTasador
        {
            get
            {
                return _idTipoPersonaTasador;
            }
            set
            {
                _idTipoPersonaTasador = value;
            }
        }

        private string _desTipoPersonaTasador;
        public string DesTipoPersonaTasador
        {
            get
            {
                return _desTipoPersonaTasador;
            }
            set
            {
                _desTipoPersonaTasador = value;
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
