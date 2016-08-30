using System;
using System.Text;
using System.Collections.Generic;


namespace BCR.SIGANEM.EN
{
    public class GarantiasOperacionesConsultaEntidad
    {

        #region PROPIEDADES

        private int _idTipoOperacion;
        public int IdTipoOperacion
        {
            get
            {
                return _idTipoOperacion;
            }
            set
            {
                _idTipoOperacion = value;
            }
        }

        private string _conta;
        public string Conta
        {
            get
            {
                return _conta;
            }
            set
            {
                _conta = value;
            }
        }

        private string _oficina;
        public string Oficina
        {
            get
            {
                return _oficina;
            }
            set
            {
                _oficina = value;
            }
        }

        private string _moneda;
        public string Moneda
        {
            get
            {
                return _moneda;
            }
            set
            {
                _moneda = value;
            }
        }

        private string _producto;
        public string Producto
        {
            get
            {
                return _producto;
            }
            set
            {
                _producto = value;
            }
        }

        private string _numero;
        public string Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                _numero = value;
            }
        }

        #endregion

    }
}