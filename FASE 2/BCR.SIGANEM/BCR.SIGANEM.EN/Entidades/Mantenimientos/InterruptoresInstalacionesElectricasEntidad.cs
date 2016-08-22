using System;
using System.Collections.Generic;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class InterruptoresInstalacionesElectricasEntidad
    {

        #region PROPIEDADES

        private int _idInterruptorInstalacionElectrica;
        public int IdInterruptorInstalacionElectrica
        {
            get
            {
                return _idInterruptorInstalacionElectrica;
            }
            set
            {
                _idInterruptorInstalacionElectrica = value;
            }
        }

        private int _codInterruptorInstalacionElectrica;
        public int CodInterruptorInstalacionElectrica
        {
            get
            {
                return _codInterruptorInstalacionElectrica;
            }
            set
            {
                _codInterruptorInstalacionElectrica = value;
            }
        }

        private string _desInterruptorInstalacionElectrica;
        public string DesInterruptorInstalacionElectrica
        {
            get
            {
                return _desInterruptorInstalacionElectrica;
            }
            set
            {
                _desInterruptorInstalacionElectrica = value;
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