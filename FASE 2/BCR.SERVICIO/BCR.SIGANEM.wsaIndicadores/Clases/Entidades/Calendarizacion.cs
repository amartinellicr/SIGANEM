using System;
using System.Xml;
using System.Text;
using System.Configuration;
using System.Collections.Generic;

namespace BCR.SIGANEM.wsaIndicadores.Utilidades
{
    /// <summary>
    /// Calendarizacion
    /// </summary>
    /// <Description>CLASE PARA LA CALENDARIZACIÓN DE PROCESOS DEL SERVICIO WINDOWS</Description>
    /// <Author>Francisco Guevara</Author>
    public class Calendarizacion : IConfigurationSectionHandler
    {

        #region IConfigurationSectionHandler MEMBERS

        public object Create(object parent, object configContext, XmlNode nodoEsquema)
        {
            // INFORMACIÓN DEL ESQUEMA DE CALENDARIZACIÓN
            EsquemaEjecucion esquema = new EsquemaEjecucion();

            #region OBTENER EL ESQUEMA
            XmlAttribute attEsquema;
            try
            {
                attEsquema = nodoEsquema.Attributes["Esquema"];

            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un problema con la sección 'EsquemaEjecucion' en el archivo de configuración. " +
                    "No se encuentra el atributo 'Esquema'", ex);
            }
            #endregion
            #region ASIGNAR EL ESQUEMA
            switch (attEsquema.InnerText)
            {
                case "SEMANAL":
                    esquema.TipoEsquema = Esquema.SEMANAL;
                    break;
                //case "DIARIO":
                //    esquema.TipoEsquema = Esquema.DIARIO;
                //    break;
                default:
                    throw new Exception("Hubo un problema con la sección 'EsquemaEjecucion' en el archivo de configuración. " +
                        "El valor del atributo 'Esquema' no es válido.'");
            }
            #endregion
            #region CALENDARIZACION SEMANAL
            try
            {
                XmlNode nodoSemanal = nodoEsquema.SelectSingleNode("Semanal");
                esquema.HoraLunes = TimeSpan.Parse(nodoSemanal.SelectSingleNode("Lunes").Attributes["Hora"].InnerText);
                esquema.HoraMartes = TimeSpan.Parse(nodoSemanal.SelectSingleNode("Martes").Attributes["Hora"].InnerText);
                esquema.HoraMiercoles = TimeSpan.Parse(nodoSemanal.SelectSingleNode("Miercoles").Attributes["Hora"].InnerText);
                esquema.HoraJueves = TimeSpan.Parse(nodoSemanal.SelectSingleNode("Jueves").Attributes["Hora"].InnerText);
                esquema.HoraViernes = TimeSpan.Parse(nodoSemanal.SelectSingleNode("Viernes").Attributes["Hora"].InnerText);
                esquema.HoraSabado = TimeSpan.Parse(nodoSemanal.SelectSingleNode("Sabado").Attributes["Hora"].InnerText);
                esquema.HoraDomingo = TimeSpan.Parse(nodoSemanal.SelectSingleNode("Domingo").Attributes["Hora"].InnerText);
            }
            catch (Exception ex)
            {

                throw new Exception("Hubo un problema con la sección 'EsquemaEjecucion' en el archivo de configuración " +
                    "en la sub-sección 'Semanal'.", ex);
            }
            #endregion
            #region CALENDARIZACION  DIARIO
            //try
            //{
            //    XmlNode nodoDiario = nodoEsquema.SelectSingleNode("Diario");
            //    esquema.Diario_IntervaloMilesimas = double.Parse(nodoDiario.Attributes["IntervaloMinutos"].InnerText) * ServiceControlProcess.MultiplicadorMinutosAMilesimas;
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception("Hubo un problema con la sección 'EsquemaEjecucion' en el archivo de configuración " +
            //        "en la sub-sección 'Diario'.", ex);
            //}
            #endregion

            return esquema;
        }

        #endregion
    }
}