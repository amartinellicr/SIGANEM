using System;
using System.Text;
using System.Configuration;
using System.Collections.Generic;



namespace BCR.SIGANEM.UT
{
    public class LectorConfiguracion
    {

        #region METODOS PUBLICOS

        public string ObtenerValorLlave(String llave)
        {
            return ConfigurationManager.ConnectionStrings[llave].ToString();
        }

        #endregion


    }
}
