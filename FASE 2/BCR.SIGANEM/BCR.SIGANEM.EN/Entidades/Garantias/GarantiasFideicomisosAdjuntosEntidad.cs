using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class GarantiasFideicomisosAdjuntosEntidad
    {
        
        #region PROPIEDADES

        private int? _idGarantiaFideicomisoAdjunto;
        public int? IdGarantiaFideicomisoAdjunto
        {
            get { return _idGarantiaFideicomisoAdjunto; }
            set { _idGarantiaFideicomisoAdjunto = value; }
        }

        private int? _idGarantiaFideicomiso;
        public int? IdGarantiaFideicomiso
        {
            get { return _idGarantiaFideicomiso; }
            set { _idGarantiaFideicomiso = value; }
        }

        private int? _idTipoFideicomisoAdjunto;
        public int? IdTipoFideicomisoAdjunto
        {
            get { return _idTipoFideicomisoAdjunto; }
            set { _idTipoFideicomisoAdjunto = value; }
        }

        private string _DesTipoArchivoFideicomiso;
        public string DesTipoArchivoFideicomiso
        {
            get { return _DesTipoArchivoFideicomiso; }
            set { _DesTipoArchivoFideicomiso = value; }
        }

        private string _nombreAdjunto;
        public string NombreAdjunto
        {
            get { return _nombreAdjunto; }
            set { _nombreAdjunto = value; }
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
