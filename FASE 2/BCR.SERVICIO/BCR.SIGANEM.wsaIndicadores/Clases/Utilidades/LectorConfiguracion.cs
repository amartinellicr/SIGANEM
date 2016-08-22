using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCR.SIGANEM.wsaIndicadores
{
    /// <summary>
    /// LectorConfiguracion
    /// </summary>
    /// <Description>MÉTODO PARA LA EL CÁLCULO DEL INTERVALO DE EJECUCIÓN DEL SERVICIO WINDOWS</Description>
    /// <Author>Francisco Guevara</Author>
    class LectorConfiguracion
    {

        #region METODOS PUBLICOS

        public static Double CalcularIntervaloEjecucion(double multiplicadorMinutosAMilesimas)
        {
            String intervaloString;
            double intervalo;

            try
            {
                intervaloString = wsaIndicadores.Properties.Settings.Default.IntervaloEjecucion;
                intervalo = double.Parse(intervaloString) * multiplicadorMinutosAMilesimas;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al leer el intervalo de ejecución del archivo de configuración.", ex);
            }

            return intervalo;
        }

        #endregion

    }
}
