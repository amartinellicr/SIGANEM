using System;
using System.Text;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.DA;
using BCR.SIGANEM.EN;
using BCR.SIGANEM.UT;

namespace BCR.SIGANEM.BL
{
    public class ProcesosNegocio : IprocesosNegocio
    {
        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private IprocesosNegocio _instancia;
        public IprocesosNegocio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    return new ProcesosNegocio();
                }
                return _instancia;
            }
            set
            {
                if (_instancia == null)
                {
                    _instancia = value;
                }
            }
        }

        #endregion

        #region VARIABLES

        private HelperClass helper = new HelperClass();
        private TransaccionAcceso transaccionDA = new TransaccionAcceso();

        #endregion

        #endregion

        #region CONSTRUCTOR Y FINALIZADOR

        public ProcesosNegocio()
        {

        }

        #endregion

        #region METODOS PUBLICOS

        #region BITACORA PROCESOS

        public List<BitacoraProcesosDetalle> BitacoraProcesosConsultar(String conexion, BitacoraProcesosConsulta consulta, ParametrosConsultaEntidad entidad)
        {
            List<BitacoraProcesosDetalle> retorno = new List<BitacoraProcesosDetalle>();
            BitacoraProcesosDetalle elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                       new SqlParameter("@piIndice_Inicio_Fila", entidad.IndiceInicioFila),
                       new SqlParameter("@piMaximo_Filas", entidad.MaximoFilas),
                       new SqlParameter("@piId_Proceso", consulta.IdProceso),
                       new SqlParameter("@pdtFecha_Desde", GeneradorControles.ConvertirFecha(consulta.FechaDesde, EnumFormatoFecha.AAAAMMDD) ),
                       new SqlParameter("@pdtFecha_Hasta", GeneradorControles.ConvertirFecha(consulta.FechaHasta, EnumFormatoFecha.AAAAMMDD) )
                    };

            #endregion

            try
            {

                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Bitacoras_Procesos_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new BitacoraProcesosDetalle();
                        elemento.IdBitacoraProceso = int.Parse(dr[0].ToString());
                        elemento.DesProceso = dr[1].ToString();
                        elemento.DesEstado = dr[2].ToString();
                        elemento.FechaEjecucion = DateTime.Parse(dr[3].ToString());
                        elemento.DesFechaEjecucion = GeneradorControles.ConvertirFecha(elemento.FechaEjecucion, EnumFormatoFecha.DDMMAAAAHHMMSSTT);

                        retorno.Add(elemento);
                    }
                }

                return retorno;

                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int BitacoraProcesosTotalFilas(String conexion, BitacoraProcesosConsulta entidad)
        {
            int value;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@piId_Proceso", entidad.IdProceso),
                        new SqlParameter("@pdtFecha_Desde", GeneradorControles.ConvertirFecha(entidad.FechaDesde, EnumFormatoFecha.AAAAMMDD)),
                        new SqlParameter("@pdtFecha_Hasta", GeneradorControles.ConvertirFecha(entidad.FechaHasta, EnumFormatoFecha.AAAAMMDD))
                    };

            #endregion

            try
            {

                #region TOTAL FILAS

                value = transaccionDA.TransaccionRows(conexion, "Bitacoras_Procesos_Total_Filas", paramTransaccion);

                return value;

                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region PROCESOS

        public List<ListaEntidad> ProcesosLista(String conexion, String filtro)
        {
            List<ListaEntidad> retorno = new List<ListaEntidad>();
            ListaEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@psFiltro", filtro)
                    };

            #endregion

            try
            {

                #region LISTA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Procesos_Lista", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new ListaEntidad();
                        elemento.Valor = dr[0].ToString();
                        elemento.Texto = dr[1].ToString();

                        retorno.Add(elemento);
                    }
                }
                return retorno;

                #endregion


            }
            catch (Exception)
            {
                throw;
            }
        }
      
        #endregion

        #region ARCHIVOS SALIDA

        public List<ListaEntidad> ArchivosLista(String conexion, String filtro)
        {
            List<ListaEntidad> retorno = new List<ListaEntidad>();
            ListaEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@psFiltro", filtro)
                    };

            #endregion

            try
            {

                #region LISTA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Archivos_Lista", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new ListaEntidad();
                        elemento.Valor = dr[0].ToString();
                        elemento.Texto = dr[1].ToString();

                        retorno.Add(elemento);
                    }
                }
                return retorno;

                #endregion


            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad EjecutarArchivo(String conexion, String conexionBitacora, int archivo, byte generar, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {              
                new SqlParameter("@piId_Archivo", archivo),
                new SqlParameter("@pbGenerar", generar),             
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Archivo", archivo.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Archivos_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Archivos_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    elemento = new RespuestaEntidad();
                    elemento.ValorEstado = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    elemento.ValorError = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion
    }
}
