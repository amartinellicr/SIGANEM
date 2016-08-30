using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.DA;
using BCR.SIGANEM.EN;
using BCR.SIGANEM.UT;


namespace BCR.SIGANEM.BL
{
    public class IndicadoresEconomicosNegocio : IindicadoresEconomicosNegocio
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private IindicadoresEconomicosNegocio _instancia;
        public IindicadoresEconomicosNegocio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    return new IndicadoresEconomicosNegocio();
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
        private BitacoraNegocio bitacoraNegocio = new BitacoraNegocio();
        private TransaccionAcceso transaccionDA = new TransaccionAcceso();

        #endregion

        #endregion
        
        #region CONSTRUCTOR Y FINALIZADOR

        public IndicadoresEconomicosNegocio()
        {

        }

        #endregion

        #region METODOS PUBLICOS

        #region INDICES PRECIOS CONSUMIDOR

        public RespuestaEntidad IndicesPreciosConsumidorInsertar(String conexion, String conexionBitacora, IndicesPreciosConsumidorEntidad entidad, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@piMes", entidad.Mes),
                        new SqlParameter("@psDes_Mes", entidad.DesMes),
                        new SqlParameter("@piAno", entidad.Ano),
                        new SqlParameter("@pnValor", entidad.Valor),
                        new SqlParameter("@psInd_Metodo_Insercion", entidad.IndMetodoInsercion),
                        new SqlParameter("@psCod_Usuario", entidad.CodUsuarioIngreso)
                    };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Indices_Precios_Consumidor_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public List<IndicesPreciosConsumidorEntidad> IndicesPreciosConsumidorConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<IndicesPreciosConsumidorEntidad> retorno = new List<IndicesPreciosConsumidorEntidad>();
            IndicesPreciosConsumidorEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                       new SqlParameter("@piIndice_Inicio_Fila", entidad.IndiceInicioFila),
                       new SqlParameter("@piMaximo_Filas", entidad.MaximoFilas),
                       new SqlParameter("@psValores_Filtro", entidad.ValorFiltro),
                       new SqlParameter("@psColumnas_Filtros", entidad.ColumnaFiltro),
                       new SqlParameter("@psColumna_Ordenar", entidad.ColumnaOrdenar)
                    };

            #endregion

            try
            {

                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Indices_Precios_Consumidor_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new IndicesPreciosConsumidorEntidad();
                        elemento.IdIndicePrecioConsumidor = int.Parse(dr[0].ToString());
                        elemento.Mes = int.Parse(dr[1].ToString());
                        elemento.DesMes = dr[2].ToString();
                        elemento.Ano = int.Parse(dr[3].ToString());
                        elemento.Valor = decimal.Parse(dr[4].ToString());
                        elemento.PorcentajeInflacion = decimal.Parse(dr[5].ToString());

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

        public int IndicesPreciosConsumidorTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@psValor_Filtro", entidad.ValorFiltro),
                        new SqlParameter("@psColumna_Filtro", entidad.ColumnaFiltro)
                    };

            #endregion

            try
            {

                #region TOTAL FILAS

                value = transaccionDA.TransaccionRows(conexion, "Indices_Precios_Consumidor_Total_Filas", paramTransaccion);

                return value;

                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public MensajesEntidad IndicesPreciosConsumidorConsultarBCCR(String conexion)
        {
            MensajesEntidad retorno = new MensajesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                    };

            #endregion

            try
            {

                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Indices_Precios_Consumidor_Consulta_BCCR", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        retorno.DesMensaje = dr[0].ToString();
                        retorno.DesTipoMensaje = dr[1].ToString();
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

        #region TIPOS CAMBIOS

        public RespuestaEntidad TiposCambiosInsertar(String conexion, String conexionBitacora, TiposCambiosEntidad entidad, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@pdtFecha", entidad.Fecha),
                        new SqlParameter("@pnValor", entidad.Valor),
                        new SqlParameter("@psInd_Metodo_Insercion", entidad.IndMetodoInsercion),
                        new SqlParameter("@psCod_Usuario", entidad.CodUsuarioIngreso)
                    };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Tipos_Cambios_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public List<TiposCambiosEntidad> TiposCambiosConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<TiposCambiosEntidad> retorno = new List<TiposCambiosEntidad>();
            TiposCambiosEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                       new SqlParameter("@piIndice_Inicio_Fila", entidad.IndiceInicioFila),
                       new SqlParameter("@piMaximo_Filas", entidad.MaximoFilas),
                       new SqlParameter("@psValores_Filtro", entidad.ValorFiltro),
                       new SqlParameter("@psColumnas_Filtros", entidad.ColumnaFiltro),
                       new SqlParameter("@psColumna_Ordenar", entidad.ColumnaOrdenar)
                    };

            #endregion

            try
            {

                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Tipos_Cambios_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new TiposCambiosEntidad();
                        elemento.IdTipoCambio = int.Parse(dr[0].ToString());
                        elemento.Fecha = DateTime.Parse(dr[1].ToString());
                        elemento.DesFecha = dr[2].ToString();
                        elemento.Valor = decimal.Parse(dr[3].ToString());
                        elemento.PorcentajeDevaluacion = decimal.Parse(dr[4].ToString());

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

        public int TiposCambiosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int retorno;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@psValor_Filtro", entidad.ValorFiltro),
                        new SqlParameter("@psColumna_Filtro", entidad.ColumnaFiltro)
                    };

            #endregion

            try
            {

                #region TOTAL FILAS

                retorno = transaccionDA.TransaccionRows(conexion, "Tipos_Cambios_Total_Filas", paramTransaccion);

                return retorno;

                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public MensajesEntidad TiposCambiosConsultarBCCR(String conexion)
        {
            MensajesEntidad retorno = new MensajesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                    };

            #endregion

            try
            {

                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Tipos_Cambios_Consulta_BCCR", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        retorno.DesMensaje = dr[0].ToString();
                        retorno.DesTipoMensaje = dr[1].ToString();
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
        
        #region REGISTRAR EJECUCION SERVICIO

        public int RegistraEjecucionServicioBitacora(String _conexionBitacora, BitacorasEntidad _bitacora)
        {
            int resultado = 0;

            try
            {

                #region CONSULTAR
                //CAMBIO FGUEVARA
                resultado = bitacoraNegocio.Instancia.BitacoraRegistrar(_conexionBitacora, _bitacora);
                return resultado;

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