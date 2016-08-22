using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.EN
{
    public class PolizaClienteEntidad : PolizaEntidad
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string primerApellido;
        public string PrimerApellido
        {
            get { return primerApellido; }
            set { primerApellido = value; }
        }

        private string segundoApellido;
        public string SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }

        private string razonSocial;
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        private string provincia;
        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        private string canton;
        public string Canton
        {
            get { return canton; }
            set { canton = value; }
        }

        private string distrito;
        public string Distrito
        {
            get { return distrito; }
            set { distrito = value; }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string telefonoMovil;
        public string TelefonoMovil
        {
            get { return telefonoMovil; }
            set { telefonoMovil = value; }
        }

        private string telefonoTrabajo;
        public string TelefonoTrabajo
        {
            get { return telefonoTrabajo; }
            set { telefonoTrabajo = value; }
        }


        private string codigoError;
        public string CodigoError
        {
            get { return codigoError; }
            set { codigoError = value; }
        }
        
        
    }
}
