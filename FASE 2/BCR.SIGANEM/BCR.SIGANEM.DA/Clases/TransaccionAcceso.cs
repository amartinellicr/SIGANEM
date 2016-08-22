using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.UT;
using BCR.SIGANEM.EN;


namespace BCR.SIGANEM.DA
{
    public class TransaccionAcceso : ItransaccionAcceso
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private ItransaccionAcceso _Instancia;
        public ItransaccionAcceso Instancia
        {
            get
            {
                if (_Instancia == null)
                {
                    return new TransaccionAcceso();
                }
                return _Instancia;
            }
            set
            {
                if (_Instancia == null)
                {
                    _Instancia = value;
                }
            }
        }

        #endregion

        #region VARIABLES

        private bool disponible = false;
        private sqlHelper sqlHelper = new sqlHelper();
        private BitacoraAcceso bitacoraAcceso = new BitacoraAcceso();

        #endregion

        #region CONSTANTES

        private const string _insertarBitacora = "pa_Bitacora_Inserta";

        #endregion

        #endregion

        #region CONSTRUCTOR Y FINALIZADOR

        public TransaccionAcceso()
        {
            
        }

        ~TransaccionAcceso()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region METODOS PUBLICOS

        #region DATABRIDGE

        //REQUERIMIENTO: 1-24493201 GARANTÍAS DE OPERACIONES – INTERFAZ SICC
        public DataSet TransaccionConsultaDataBridge(string conexion, string query)
        {
            DataSet resultado = null;

            try
            {
                #region CONSULTAR

                resultado = sqlHelper.ConsultaDataBridge(conexion, query);
                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
			finally
			{
				resultado = null;
			}
        }

        public DataSet TransaccionConsultaRuc(string conexion, string query)
        {
            DataSet resultado = null;

            try
            {
                #region CONSULTAR

                resultado = sqlHelper.ConsultaRuc(conexion, query);
                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                resultado = null;
            }
        }

        #endregion

        #region REGISTRAR BITACORA

        public DataSet TransaccionInsertar(string conexion, string connBitacora, string procedimiento, SqlParameter[] parametros, EnumTipoBitacora tipoBitacora, BitacorasEntidad bitacora)
        {
            DataSet resultado;
            string datoNuevo = string.Empty;

            try
            {
                #region INSERTAR

                #region REGISTRAR INFORMACION

                if (tipoBitacora == EnumTipoBitacora.INSERTAR)
                {
                    datoNuevo = bitacoraAcceso.Instancia.NewData(parametros);
                }

                #endregion

                #region REALIZAR TRANSACCION

                resultado = sqlHelper.ConsultaDataSet(conexion, procedimiento, parametros);

                #endregion

                #region REGISTRAR TRANSACCION BITACORA

                #region PARAMETROS BITACORA

                SqlParameter[] paramBitacora = new SqlParameter[]
                    {
                        new SqlParameter("@piCod_Accion", bitacora.CodAccion),
                        new SqlParameter("@piCod_Modulo", bitacora.CodModulo),
                        new SqlParameter("@piCod_Empresa", bitacora.CodEmpresa),
                        new SqlParameter("@psCod_Sistema", bitacora.CodSistema),                
                        new SqlParameter("@psCod_Usuario", bitacora.CodUsuario),
                        new SqlParameter("@psDato_Nuevo", datoNuevo),
                        new SqlParameter("@psDato_Actualizado", DBNull.Value),
                        new SqlParameter("@psDato_Eliminado", DBNull.Value),
                        new SqlParameter("@psDes_Registro", DBNull.Value)
                    };

                #endregion

                int retornoBitacora = bitacoraAcceso.Instancia.BitacorasInsertar(connBitacora, _insertarBitacora, paramBitacora);

                #endregion

                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet TransaccionModificar(string conexion, string connBitacora, string procedimiento, SqlParameter[] parametros, EnumTipoBitacora tipoBitacora, List<KeyValuePair<string, string>> arrayOldValues, string spConsulta, BitacorasEntidad bitacora)
        {
            DataSet resultado;
            string datoNuevo = string.Empty;
            string datoAnterior = string.Empty;

            try
            {
                #region MODIFICAR

                #region REGISTRAR INFORMACION

                if (tipoBitacora == EnumTipoBitacora.ACTUALIZAR)
                {
                    datoNuevo = bitacoraAcceso.Instancia.NewData(parametros);
                    datoAnterior = bitacoraAcceso.Instancia.OldData(conexion, spConsulta, arrayOldValues);
                }

                #endregion

                #region REALIZAR TRANSACCION

                resultado = sqlHelper.ConsultaDataSet(conexion, procedimiento, parametros);

                #endregion

                #region REGISTRAR TRANSACCION BITACORA

                #region PARAMETROS BITACORA

                SqlParameter[] paramBitacora = new SqlParameter[]
                    {
                        new SqlParameter("@piCod_Accion", bitacora.CodAccion),
                        new SqlParameter("@piCod_Modulo", bitacora.CodModulo),
                        new SqlParameter("@piCod_Empresa", bitacora.CodEmpresa),
                        new SqlParameter("@psCod_Sistema", bitacora.CodSistema),                
                        new SqlParameter("@psCod_Usuario", bitacora.CodUsuario),
                        new SqlParameter("@psDato_Nuevo", datoNuevo),
                        new SqlParameter("@psDato_Actualizado", datoAnterior),
                        new SqlParameter("@psDato_Eliminado", DBNull.Value),
                        new SqlParameter("@psDes_Registro", DBNull.Value)
                    };

                #endregion

                int retornoBitacora = bitacoraAcceso.Instancia.BitacorasInsertar(connBitacora, _insertarBitacora, paramBitacora);

                #endregion

                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet TransaccionEliminar(string conexion, string connBitacora, string procedimiento, SqlParameter[] parametros, EnumTipoBitacora tipoBitacora, List<KeyValuePair<string, string>> arrayDeleteValues, string spConsulta, BitacorasEntidad bitacora)
        {
            DataSet resultado;
            string datoEliminado = string.Empty;

            try
            {
                #region ELIMINAR

                #region REGISTRAR INFORMACION

                if (tipoBitacora == EnumTipoBitacora.ELIMINAR)
                {
                    datoEliminado = bitacoraAcceso.Instancia.OldData(conexion, spConsulta, arrayDeleteValues);
                }

                #endregion

                #region REALIZAR TRANSACCION

                resultado = sqlHelper.ConsultaDataSet(conexion, procedimiento, parametros);

                #endregion

                #region REGISTRAR TRANSACCION BITACORA

                #region PARAMETROS BITACORA

                SqlParameter[] paramBitacora = new SqlParameter[]
                    {
                        new SqlParameter("@piCod_Accion", bitacora.CodAccion),
                        new SqlParameter("@piCod_Modulo", bitacora.CodModulo),
                        new SqlParameter("@piCod_Empresa", bitacora.CodEmpresa),
                        new SqlParameter("@psCod_Sistema", bitacora.CodSistema),                
                        new SqlParameter("@psCod_Usuario", bitacora.CodUsuario),
                        new SqlParameter("@psDato_Nuevo", DBNull.Value),
                        new SqlParameter("@psDato_Actualizado", DBNull.Value),
                        new SqlParameter("@psDato_Eliminado", datoEliminado),
                        new SqlParameter("@psDes_Registro", DBNull.Value)
                    };

                #endregion

                int retornoBitacora = bitacoraAcceso.Instancia.BitacorasInsertar(connBitacora, _insertarBitacora, paramBitacora);

                #endregion

                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
			finally
			{
				resultado = null;
			}
        }

        public DataSet TransaccionConsultaDetalle(string conexion, string connBitacora, string procedimiento, SqlParameter[] parametros, EnumTipoBitacora tipoBitacora, List<KeyValuePair<string, string>> arrayOldValues, string spConsulta, BitacorasEntidad bitacora)
        {
            string datoAnterior = string.Empty;
            DataSet resultado = null;

            try
            {
                #region CONSULTAR DETALLE

                #region REGISTRAR INFORMACION

                if (tipoBitacora == EnumTipoBitacora.CONSULTAR)
                {
                    datoAnterior = bitacoraAcceso.Instancia.OldData(conexion, spConsulta, arrayOldValues);
                }

                #endregion

                #region REALIZAR TRANSACCION

                resultado = sqlHelper.ConsultaDataSet(conexion, procedimiento, parametros);

                #endregion

                #region REGISTRAR TRANSACCION BITACORA

                #region PARAMETROS BITACORA

                SqlParameter[] paramBitacora = new SqlParameter[]
                    {
                        new SqlParameter("@piCod_Accion", bitacora.CodAccion),
                        new SqlParameter("@piCod_Modulo", bitacora.CodModulo),
                        new SqlParameter("@piCod_Empresa", bitacora.CodEmpresa),
                        new SqlParameter("@psCod_Sistema", bitacora.CodSistema),                
                        new SqlParameter("@psCod_Usuario", bitacora.CodUsuario),
                        new SqlParameter("@psDato_Nuevo", DBNull.Value),
                        new SqlParameter("@psDato_Actualizado", DBNull.Value),
                        new SqlParameter("@psDato_Eliminado", DBNull.Value),
                        new SqlParameter("@psDes_Registro", datoAnterior)
                    };

                #endregion

                int _rBitacora = bitacoraAcceso.Instancia.BitacorasInsertar(connBitacora, _insertarBitacora, paramBitacora);

                #endregion

                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
			finally
			{
				resultado = null;
			}
        }
        
        #endregion
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        #region SIN REGISTRAR BITACORA

        public DataSet TransaccionInsertar(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            DataSet resultado;
            string datoNuevo = string.Empty;

            try
            {
                #region INSERTAR

                resultado = sqlHelper.ConsultaDataSet(conexion, procedimiento, parametros);
                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
			finally
			{
				resultado = null;
			}
        }

        public DataSet TransaccionModificar(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            DataSet resultado;
            string datoNuevo = string.Empty;
            string datoAnterior = string.Empty;

            try
            {
                #region MODIFICAR

                resultado = sqlHelper.ConsultaDataSet(conexion, procedimiento, parametros);
                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
			finally
			{
				resultado = null;
			}
        }

        public DataSet TransaccionEliminar(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            DataSet resultado;
            string datoEliminado = string.Empty;

            try
            {
                #region ELIMINAR

                resultado = sqlHelper.ConsultaDataSet(conexion, procedimiento, parametros);
                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
			finally
			{
				resultado = null;
			}
        }

        public int TransaccionRows(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            Int32 resultado;

            try
            {
                #region CONTADOR LINEA

                resultado = sqlHelper.ResultInt(conexion, procedimiento, parametros);
                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet TransaccionConsulta(string conexion, string procedimiento)
        {
            DataSet resultado = null;

            try
            {
                #region CONSULTAR

                resultado = sqlHelper.ConsultaDataSet(conexion, procedimiento);
                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
			finally
			{
				resultado = null;
			}
        }

        public DataSet TransaccionConsulta(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            DataSet resultado = null;

            try
            {
                #region CONSULTAR

                resultado = sqlHelper.ConsultaDataSet(conexion, procedimiento, parametros);
                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
			finally
			{
				resultado = null;
			}
        }

        public string TransaccionConsultaString(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            string resultado = string.Empty;

            try
            {
                #region CONSULTAR

                resultado = sqlHelper.ConsultaString(conexion, procedimiento, parametros);
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

        #region MIEMBRO IDISPOSABLE

        protected virtual void Dispose(bool disposing)
        {
            if (!disponible)
            {
                if (disposing)
                {
                    if (bitacoraAcceso != null)
                    {
                        bitacoraAcceso.Dispose();
                        bitacoraAcceso = null;
                    }
                }
                sqlHelper = null;
                disponible = true;
            }
        }

        #endregion

    }
}
