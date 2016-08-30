using System;
using System.Web;
using System.Text;
using System.Security;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Generic;
using System.Security.Permissions;

using BCR.SIGANEM.UT;


namespace BCR.SIGANEM.UT
{
    public class RegistrarEventLog
    {

        #region PROPIEDADES

        private EventLog registroEventos = new EventLog();

        #endregion

        #region METODOS PUBLICOS

        /// <summary>
        /// CREA EL OBJETO PARA ESCRIBIR EN EL REGISTRO DE EVENTOS.
        /// </summary>
        /// <returns>EventLog</returns>
        private EventLog CrearEventLog(string source)
        {
            EventLog registroEventos = new EventLog();
            String nombreEvento = Resource._eventoSIGANEM;

            try
            {
                //SI EL EL LOG NO EXISTE SE CREA
                if (!EventLog.SourceExists(nombreEvento))
                {
                    EventLog.CreateEventSource(nombreEvento, nombreEvento);
                    EventLog.WriteEntry(nombreEvento, "El Log: " + nombreEvento + " fue creado satisfactoriamente", EventLogEntryType.Information);
                }

                registroEventos.Source = source;
                registroEventos.Log = nombreEvento;

                return registroEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// REGISTRA UN MENSAJE DE ERROR EN EL LOG DE EVENTOS DEL SISTEMA
        /// </summary>
        /// <param name="_excepcion">EL OBJETO EXCEPCION QUE CONTIENE LA INFORMACIÓN POR REGISTRAR</param>
        public void RegistrarMensajeLog(Exception excepcion, string source)
        {
            registroEventos = CrearEventLog(source);
            StringBuilder sb = new StringBuilder();

            try
            {
                int nivel = 1;

                while (excepcion != null)
                {
                    #region MENSAJE DE ERROR

                    sb.Append("Excepción Nivel #" + nivel + "\n\n");
                    sb.Append("Id Excepción: \n");
                    sb.Append(excepcion.GetHashCode());
                    sb.Append("\n\n");
                    sb.Append("Excepción: \n");
                    sb.Append(excepcion.GetType().FullName);
                    sb.Append("\n\n");
                    sb.Append("Mensaje: \n");
                    sb.Append(excepcion.Message);
                    sb.Append("\n\n");
                    sb.Append("Origen: \n");
                    sb.Append(excepcion.Source);
                    sb.Append("\n\n");
                    sb.Append("Pila de Seguimiento: \n");
                    sb.Append(excepcion.StackTrace);
                    sb.Append("\n\n\n");

                    #endregion

                    excepcion = excepcion.InnerException;
                    nivel++;
                }
                registroEventos.WriteEntry("Se ha generado el siguiente error en el sistema. Excepción no controlada." + "\n\n" + sb.ToString(), EventLogEntryType.Error);                
                registroEventos.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// REGISTRA EL MENSAJE EN EL LOG DE EVENTOS DEL SISTEMA SEGUN SU TIPO (INFORMACION, ADVERTENCIA O ERROR)
        /// </summary>
        /// <param name="_mensaje">MENSAJE DE LA EXCEPCIÓN</param>
        /// <param name="_tipo">TIPO DE ENTRADA AL LOG: INFORMACION, ADVERTENCIA O ERROR</param>
        public void RegistrarMensajeLog(string mensaje, string tipo, string source)
        {
            registroEventos = CrearEventLog(source);

            try
            {
                switch (tipo.ToUpper())
                {
                    case "INFORMACION":
                        registroEventos.WriteEntry(mensaje, EventLogEntryType.Information);
                        break;
                    case "ADVERTENCIA":
                        registroEventos.WriteEntry(mensaje, EventLogEntryType.Warning);
                        break;
                    case "ERROR":
                        registroEventos.WriteEntry(mensaje, EventLogEntryType.Error);
                        break;
                }
                registroEventos.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// REGISTRA UN MENSAJE DE ERROR EN EL LOG DE EVENTOS DEL SISTEMA.
        /// </summary>
        /// <param name="_mensaje">MENSAJE DE LA EXCEPCIÓN</param>
        /// <param name="_origen">ORIGEN DEL ERROR</param>
        /// <param name="_pila">PILA DE SEGUIMIENTO DEL ERROR</param>
        public void RegistrarMensajeLog(string mensaje, string origen, string pila, string source)
        {
            registroEventos = CrearEventLog(source);
            StringBuilder sb = new StringBuilder();

            try
            {
                #region MENSAJE DE ERROR

                sb.Append("Mensaje: \n");
                sb.Append(mensaje);
                sb.Append("\n\n");
                sb.Append("Origen: \n");
                sb.Append(origen);
                sb.Append("\n\n");
                sb.Append("Pila de Seguimiento: \n");
                sb.Append(pila);

                #endregion

                registroEventos.WriteEntry("Se ha generado el siguiente error en el sistema. Excepción no controlada." + "\n\n" + sb.ToString(), EventLogEntryType.Error);
                registroEventos.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
