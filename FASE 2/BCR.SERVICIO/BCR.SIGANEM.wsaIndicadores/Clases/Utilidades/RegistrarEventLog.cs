using System;
using System.Web;
using System.Text;
using System.Security;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Generic;
using System.Security.Permissions;


namespace BCR.SIGANEM.wsaIndicadores
{

    /// <summary>
    /// RegistrarEventLog
    /// </summary>
    /// <Description>CLASE PARA REGISTRAR EXCEPCIONES EN EVENT VIEWER</Description>
    /// <Author>Francisco Guevara</Author>
    public class RegistrarEventLog
    {

        #region PROPIEDADES

        private EventLog _registroEventos = new EventLog();
        
        #endregion

        #region METODOS PUBLICOS

        /// <summary>
        /// CREA EL OBJETO PARA ESCRIBIR EN EL REGISTRO DE EVENTOS.
        /// </summary>
        /// <returns>EventLog</returns>
        /// <Author>Francisco Guevara</Author>
        private EventLog CrearEventLog()
        {
            EventLog registroEventos = new EventLog();
            string NombreLog = wsaIndicadores.Properties.Generales._nombreLog;
            string NombreSource = wsaIndicadores.Properties.Generales._nombreSource;

            try
            {
                //SI EL EL LOG NO EXISTE SE CREA
                if (!EventLog.SourceExists(NombreLog))
                {
                    EventLog.CreateEventSource(NombreLog, NombreLog);
                    EventLog.WriteEntry(NombreLog, "El Log: " + NombreLog + " fue creado satisfactoriamente", EventLogEntryType.Information);
                }

                registroEventos.Source = NombreSource;
                registroEventos.Log = NombreLog;

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
        /// <param name="excepcion">EL OBJETO EXCEPCION QUE CONTIENE LA INFORMACIÓN POR REGISTRAR</param>
        /// <Author>Francisco Guevara</Author>
        public void RegistrarMensajeLog(Exception excepcion)
        {
            _registroEventos = CrearEventLog();
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
                _registroEventos.WriteEntry("Se ha generado el siguiente error en el sistema. Excepción no controlada." + "\n\n" + sb.ToString(), EventLogEntryType.Error);                
                _registroEventos.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// REGISTRA UN MENSAJE DE ERROR EN EL LOG DE EVENTOS DEL SISTEMA
        /// </summary>
        /// <param name="excepcion">MENSAJE DE LA EXCEPCIÓN</param>
        /// <param name="mensajeControlado">MENSAJE controlado</param>
        /// <Author>Francisco Guevara</Author>
        public void RegistrarMensajeLog(Exception excepcion, string mensajeControlado)
        {
            _registroEventos = CrearEventLog();
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
                    sb.Append(mensajeControlado);
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
                _registroEventos.WriteEntry("Se ha generado el siguiente error en el sistema. Excepción no controlada." + "\n\n" + sb.ToString(), EventLogEntryType.Error);
                _registroEventos.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// REGISTRA EL MENSAJE EN EL LOG DE EVENTOS DEL SISTEMA SEGUN SU TIPO (INFORMACION, ADVERTENCIA O ERROR)
        /// </summary>
        /// <param name="excepcion">MENSAJE DE LA EXCEPCIÓN</param>
        /// <param name="tipo">TIPO DE ENTRADA AL LOG: INFORMACION, ADVERTENCIA O ERROR</param>
        /// <Author>Francisco Guevara</Author>
        public void RegistrarMensajeLog(string excepcion, string tipo)
        {
            _registroEventos = CrearEventLog();

            try
            {
                switch (tipo.ToUpper())
                {
                    case "INFORMACION":
                        _registroEventos.WriteEntry(excepcion, EventLogEntryType.Information);
                        break;
                    case "ADVERTENCIA":
                        _registroEventos.WriteEntry(excepcion, EventLogEntryType.Warning);
                        break;
                    case "ERROR":
                        _registroEventos.WriteEntry(excepcion, EventLogEntryType.Error);
                        break;
                }
                _registroEventos.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// REGISTRA UN MENSAJE DE ERROR EN EL LOG DE EVENTOS DEL SISTEMA.
        /// </summary>
        /// <param name="excepcion">MENSAJE DE LA EXCEPCIÓN</param>
        /// <param name="mensajeControlado">MENSAJE controlado</param>
        /// <param name="origen">ORIGEN DEL ERROR</param>
        /// <param name="pila">PILA DE SEGUIMIENTO DEL ERROR</param>
        /// <Author>Francisco Guevara</Author>
        public void RegistrarMensajeLog(string excepcion, string mensajeControlado, string origen, string pila)
        {
            _registroEventos = CrearEventLog();
            StringBuilder sb = new StringBuilder();

            try
            {
                #region MENSAJE DE ERROR

                sb.Append("Mensaje: \n");
                sb.Append(excepcion);
                sb.Append("\n\n");
                sb.Append("Origen: \n");
                sb.Append(origen);
                sb.Append("\n\n");
                sb.Append("Pila de Seguimiento: \n");
                sb.Append(pila);

                #endregion

                _registroEventos.WriteEntry(mensajeControlado + "\n\n" + sb.ToString(), EventLogEntryType.Error);
                _registroEventos.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
