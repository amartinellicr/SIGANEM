using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;
using System.ServiceProcess;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;

using BCR.SIGANEM.wsaIndicadores.SiganemIndicadoresWS;


namespace BCR.SIGANEM.wsaIndicadores
{
    public partial class wsaIndicadoresServices : ServiceBase
    {

        #region VARIABLES

        #region CONSTANTES

        //VARIABLE CON VALOR DE 1 MINUTO (60000)
        public const double MultiplicadorMinutosAMilesimas = 60000;

        #endregion

        #region VARIABLES

        private bool ejecutadoHoy = false;

        private Thread _hiloEjecucion;
        private AutoResetEvent doneEvento = new AutoResetEvent(false);

        private EsquemaEjecucion esquemaEjecucion = null;
        private LectorFechasSistema _fechas = new LectorFechasSistema();

        private IndicadorEconomicoEntidad _indicadorEntidad = null;
        private AppSettingEntidad _appEntidad = new AppSettingEntidad();
        private List<SiganemIndicadoresWS.RespuestaEntidad> _respuestaEntidad = null;

        #endregion

        #region REFERENCIAS

        private RegistrarEventLog _registrarEventLog = new RegistrarEventLog();
        private SiganemIndicadoresWS.BitacorasEntidad _bitacorasEntidad = new SiganemIndicadoresWS.BitacorasEntidad();
        private SiganemIndicadoresWS.SiganemIndicadoresWS _wsIndicadores = new SiganemIndicadoresWS.SiganemIndicadoresWS();

        #endregion

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// CONSTRUCTOR DEL SERVICIO
        /// </summary>
        /// <Author>Francisco Guevara</Author>
        public wsaIndicadoresServices()
        {
            InitializeComponent();
        }

        /// <summary>
        /// EVENTO DE INCIALIZACIÓN DEL SERVICIO
        /// </summary>
        /// <Author>Francisco Guevara</Author>
        protected override void OnStart(string[] args)
        {
            try
            {
                #region INICIA HILO DEL SERVICIO
                doneEvento.Reset();
                //CREA HILO DE EJECUCIÓN DEL SERVICIO
                _hiloEjecucion = new Thread(PreparaEjecucion);
                _hiloEjecucion.Name = "Indicadores Económicos SIGANEM";
                _hiloEjecucion.Start();
                #endregion

                //ASIGNA LA DIRECCION DE LOS SERVICIOS WEB
                this.AsignaWebServicesTypeNames();
            }
            catch (Exception ex)
            {
                //LOG DEL ERROR
                _registrarEventLog.RegistrarMensajeLog(ex, "El servicio ha fallado al  iniciarse." + "\n\n" + "Error: " + ex.Message + "\n\n" 
                                                        + ex.StackTrace);
                timer1.Stop();
            }

            //REGISTRAR EJECUCION LOG
            _registrarEventLog.RegistrarMensajeLog("El servicio se inició satisfactoriamente con los siguientes parámetros: \n\n" +
                                                     "Intervalo ejecución: " + wsaIndicadores.Properties.Settings.Default.IntervaloEjecucion + " minuto(s) \n" +
                                                     "\n", "INFORMACION");
        }

        /// <summary>
        /// EVENTO DE FINALIZACIÓN DEL SERVICIO
        /// </summary>
        /// <Author>Francisco Guevara</Author>
        protected override void OnStop()
        {
            try
            {
                #region FINALIZA HILO DEL SERVICIO
                doneEvento.Set();
                _hiloEjecucion = null;
                #endregion

                //REGISTRAR EJECUCION LOG
                _registrarEventLog.RegistrarMensajeLog("El servicio se ha detenido satisfactoriamente.", "INFORMACION");
            }
            catch (Exception ex)
            {
                //LOG DEL ERROR
                _registrarEventLog.RegistrarMensajeLog(ex, "El servicio ha fallado al ser detenido." + "\n\n" + "Error: " + ex.Message + "\n\n" 
                                                        + ex.StackTrace);
            }
        }

        #endregion

        #region VALORES SERVICIO

        /// <summary>
        /// ASIGNA LA DIRECCION AL SERVICIO WEB DEL BCCR
        /// </summary>
        /// <Author>Francisco Guevara</Author>
        protected void AsignaWebServicesTypeNames()
        {
            try
            {
                string _culture = wsaIndicadores.Properties.Settings.Default.Culture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(_culture);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(_culture);

                _wsIndicadores.Url = wsaIndicadores.Properties.Settings.Default.SiganemIndicadoresWS;
            }
            catch (Exception ex)
            {
                //LOG DEL ERROR
                _registrarEventLog.RegistrarMensajeLog(ex, "Error en asignación de ruta web para el servicio de consulta.");
                throw ex;
            }
        }

        /// <summary>
        /// ASIGNA VALOR DE TIPO CAMBIO A LA ENTIDAD PARA ENVIARLOS AL WEB SERVICE
        /// </summary>
        /// <Author>Francisco Guevara</Author>
        private void AsignaValoresServicioWindows(String tipoServicio)
        {
            _indicadorEntidad = new SiganemIndicadoresWS.IndicadorEconomicoEntidad();
            _respuestaEntidad = new List<SiganemIndicadoresWS.RespuestaEntidad>();

            try
            {
                #region VALORES GENERICOS

                _indicadorEntidad.NombreBanco = wsaIndicadores.Properties.Generales._nombreBanco;
                _indicadorEntidad.SubNiveles = wsaIndicadores.Properties.Generales._subNivel;
                _indicadorEntidad.CodUsuarioIngreso = wsaIndicadores.Properties.Bitacora._usuario;
                _indicadorEntidad.IndMetodoInsercion = wsaIndicadores.Properties.Bitacora._metodoInsercion;

                #endregion

                #region VALORES POR SERVICIO

                switch (tipoServicio)
                {
                    case "TC":
                        _indicadorEntidad.Indicador = wsaIndicadores.Properties.Settings.Default.SistemaTC;
                        _indicadorEntidad.FechaInicio = _fechas.ObtenerDiaAnterior().ToShortDateString();
                        _indicadorEntidad.FechaFinal = _fechas.ObtenerDiaActual().ToShortDateString();
                        AsignarValoresBitacora(wsaIndicadores.Properties.Bitacora._moduloTC);
                        break;
                    case "IPC":
                        _indicadorEntidad.Indicador = wsaIndicadores.Properties.Settings.Default.SistemaIPC;
                        _indicadorEntidad.FechaInicio = _fechas.ObtenerUltimoDiaMesAnterior().ToShortDateString();
                        _indicadorEntidad.FechaFinal = _fechas.ObtenerUltimoDiaMesAnterior().ToShortDateString();
                        AsignarValoresBitacora(wsaIndicadores.Properties.Bitacora._moduloIPC);
                        break;
                }

                #endregion

            }
            catch (Exception ex)
            {
                //LOG DEL ERROR
                _registrarEventLog.RegistrarMensajeLog(ex, "Error en asignación de valores para el servicio de consulta: " 
                                                        + tipoServicio);
                throw ex;
            }
        }

        /// <summary>
        /// ASIGNA LOS VALORES DE LA BITACORA
        /// </summary>
        /// <Author>Francisco Guevara</Author>
        private SiganemIndicadoresWS.BitacorasEntidad AsignarValoresBitacora(string _codModulo)
        {
            try
            {
                #region ENTIDAD BITACORA

                _bitacorasEntidad.CodAccion = int.Parse(wsaIndicadores.Properties.Bitacora._accion);
                _bitacorasEntidad.CodModulo = int.Parse(_codModulo);
                _bitacorasEntidad.CodEmpresa = int.Parse(wsaIndicadores.Properties.Bitacora._empresa);
                _bitacorasEntidad.CodSistema = wsaIndicadores.Properties.Bitacora._sistema;
                _bitacorasEntidad.CodUsuario = wsaIndicadores.Properties.Bitacora._usuario;

                #endregion

                return _bitacorasEntidad;
            }
            catch (Exception ex)
            {
                //LOG DEL ERROR
                _registrarEventLog.RegistrarMensajeLog(ex, "Error en asignación de valores para la bitacora del servicio de consulta: " 
                                                        + _codModulo);
                throw ex;
            }
        }

        private SiganemIndicadoresWS.BitacorasEntidad RegistraEjecucionIndicadoresServicio()
        {
            SiganemIndicadoresWS.BitacorasEntidad _bitacoraTemp = new SiganemIndicadoresWS.BitacorasEntidad();

            #region ENTIDAD BITACORA

            _bitacoraTemp.CodAccion = 1000;
            _bitacoraTemp.CodModulo = 1;
            _bitacoraTemp.CodEmpresa = int.Parse(wsaIndicadores.Properties.Bitacora._empresa);
            _bitacoraTemp.CodSistema = wsaIndicadores.Properties.Bitacora._sistema;
            _bitacoraTemp.CodUsuario = wsaIndicadores.Properties.Bitacora._usuario;
            _bitacoraTemp.DesRegistro = "Se ha iniciado la ejecución del Servicio Windows.";

            #endregion

            return _bitacoraTemp;
        }

        #endregion

        #region EJECUCION SERVICIO

        /// <summary>
        /// CREA EVENTO DE INICIALIZACION DEL TIMER Y CALENDARIZA EL SERVICIO
        /// </summary>
        /// <Author>Francisco Guevara</Author>
        private void PreparaEjecucion()
        {
            try
            {
                timer1.Elapsed += new System.Timers.ElapsedEventHandler(IniciaEjecucion);
                //CONFIGURAR ESQUEMA DE EJECUCIÓN
                this.ConfigurarServicio();
                //SUBPROCESO BLOQUEADO INFINITAMENTE
                Thread.Sleep(System.Threading.Timeout.Infinite);
            }
            catch (Exception ex)
            {
                //LOG DEL ERROR
                _registrarEventLog.RegistrarMensajeLog(ex, "No se ha podido inicializar la ejecución del Servicio."
                                                        + "\n\n" + "Error: " + ex.Message + "\n\n" + ex.StackTrace);
                throw ex;
            }
        }

        /// <summary>
        /// MÉTODO QUE SE EJECUTA EL CUMPLIRSE EL INTERVALO ESPECIFICADO PARA EL CONTADOR
        /// </summary>
        /// <Author>Francisco Guevara</Author>
        void IniciaEjecucion(object sender, System.Timers.ElapsedEventArgs e)
        {
            //DETENER CONTADOR
            timer1.Stop();

            switch (esquemaEjecucion.TipoEsquema)
            {
                //ESQUEMA DE EJECUCIÓN: SEMANAL
                case Esquema.SEMANAL:
                    TimeSpan horaProgramada = new TimeSpan();
                    switch (DateTime.Today.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            horaProgramada = esquemaEjecucion.HoraLunes;
                            break;
                        case DayOfWeek.Tuesday:
                            horaProgramada = esquemaEjecucion.HoraMartes;
                            break;
                        case DayOfWeek.Wednesday:
                            horaProgramada = esquemaEjecucion.HoraMiercoles;
                            break;
                        case DayOfWeek.Thursday:
                            horaProgramada = esquemaEjecucion.HoraJueves;
                            break;
                        case DayOfWeek.Friday:
                            horaProgramada = esquemaEjecucion.HoraViernes;
                            break;
                        case DayOfWeek.Saturday:
                            horaProgramada = esquemaEjecucion.HoraSabado;
                            break;
                        case DayOfWeek.Sunday:
                            horaProgramada = esquemaEjecucion.HoraDomingo;
                            break;
                    }

                    //DETERMINAR SI PASÓ LA HORA DE EJECUCIÓN O NO
                    int resultadoComparacionHoras = horaProgramada.CompareTo(DateTime.Now.TimeOfDay);

                    if ((resultadoComparacionHoras > 0) && ejecutadoHoy)
                    {
                        ejecutadoHoy = false;
                    }
                    else if ((resultadoComparacionHoras <= 0) && !ejecutadoHoy)
                    {
                        this.EjecutarServicio();
                        ejecutadoHoy = true;
                    }

                    break;
            }

            //REINICIAR CONTADOR
            timer1.Start();
        }

        /// <summary>
        /// DEFINIR INTERVALO DE REVISIÓN DE EJECUCIÓN CALENDARIZADOS SEGUN CONFIGURACION
        /// </summary>
        /// <Author>Francisco Guevara</Author>
        void ConfigurarServicio()
        {
            try
            {
                //OBTENER EL ESQUEMA DE EJECUCIÓN
                esquemaEjecucion = (EsquemaEjecucion)System.Configuration.ConfigurationManager.GetSection("EsquemaEjecucion");
                if (esquemaEjecucion.TipoEsquema == Esquema.SEMANAL)
                {
                    //double MultiplicadorMinutosAMilesimas
                    timer1.Interval = LectorConfiguracion.CalcularIntervaloEjecucion(MultiplicadorMinutosAMilesimas);
                }
            }
            catch (Exception ex)
            {
                if (esquemaEjecucion == null)
                {
                    //LOG DEL ERROR
                    _registrarEventLog.RegistrarMensajeLog(ex, "Error en el Esquema de Ejecución del Servicio de Windows.");
                    throw new ArgumentException("Esquema de Ejecucion", ex);
                }
                else
                {
                    //LOG DEL ERROR
                    _registrarEventLog.RegistrarMensajeLog(ex);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// EJECUTA EL TRABAJO DEL SERVICIO
        /// </summary>
        /// <Author>Francisco Guevara</Author>
        void EjecutarServicio()
        {
            int _resultBitacora = 0;

            while (!doneEvento.WaitOne(0, false))
            {
                _resultBitacora = _wsIndicadores.RegistraEjecucionServicioBitacora(RegistraEjecucionIndicadoresServicio());
                #region CONSULTA TIPO CAMBIO
                try
                {
                    Thread.Sleep(1000);

                    AsignaValoresServicioWindows("TC");
                    _respuestaEntidad = _wsIndicadores.ConsultaIndicadorEconomicoTC(_indicadorEntidad, _bitacorasEntidad).ToList();

                    if (!_respuestaEntidad.Count.Equals(0))
                    {
                        //LOG SATISFACTORIO
                        _registrarEventLog.RegistrarMensajeLog("Los registros han sido insertados en Tipo Cambio el día: "
                                                                + _fechas.ObtenerDiaActual().ToShortDateString() + ".", "INFORMACION");
                    }
                }
                catch (Exception ex)
                {
                    //LOG DEL ERROR
                    _registrarEventLog.RegistrarMensajeLog(ex, "Error al insertar los registros de Tipo Cambio."
                                                        + "\n\n" + "Error: " + ex.Message + "\n\n" + ex.StackTrace);
                    throw ex;
                }
                #endregion
                #region CONSULTA INDICE PRECIO CONSUMIDOR
                try
                {
                    Thread.Sleep(1000);

                    AsignaValoresServicioWindows("IPC");
                    _respuestaEntidad = _wsIndicadores.ConsultaIndicadorEconomicoIPC(_indicadorEntidad, _bitacorasEntidad).ToList();

                    if (!_respuestaEntidad.Count.Equals(0))
                    {
                        //LOG SATISFACTORIO
                        _registrarEventLog.RegistrarMensajeLog("Los registros han sido insertados en Indice Precio Consumidor el día: "
                                                                + _fechas.ObtenerDiaActual().ToShortDateString() + ".", "INFORMACION");
                    }
                }
                catch (Exception ex)
                {
                    //LOG DEL ERROR
                    _registrarEventLog.RegistrarMensajeLog(ex, "Error al insertar los registros de Indice Precio Consumidor."
                                                        + "\n\n" + "Error: " + ex.Message + "\n\n" + ex.StackTrace);
                    throw ex;
                }
                #endregion

                doneEvento.Set();
            }
        }

        #endregion

    }
}
