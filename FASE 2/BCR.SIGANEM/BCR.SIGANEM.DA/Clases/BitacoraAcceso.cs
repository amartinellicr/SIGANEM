using System;
using System.Text;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.UT;


namespace BCR.SIGANEM.DA
{
    public class BitacoraAcceso : IbitacoraAcceso
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private IbitacoraAcceso _Instancia;
        public IbitacoraAcceso Instancia
        {
            get
            {
                if (_Instancia == null)
                {
                    return new BitacoraAcceso();
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
        private HelperClass helper = new HelperClass();
        

        #endregion
        
        #endregion

        #region CONSTRUCTOR Y FINALIZADOR

        public BitacoraAcceso()
        {
            
        }

        ~BitacoraAcceso()
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

        public string NewData(SqlParameter[] parametros)
        {
            StringBuilder sbDatosBitacora = new StringBuilder();

            foreach (SqlParameter param in parametros)
            {
                if (param.Value != null)
                    if (param.ParameterName.Contains("@"))
                    {
                        sbDatosBitacora.Append(String.Concat(param.ParameterName.Replace('@', ' ').TrimStart(), ": ", param.Value, " | "));
                    }
                    else
                    {
                        sbDatosBitacora.Append(String.Concat(param.ParameterName, ": ", param.Value, " | "));
                    }
                else
                    sbDatosBitacora.Append(String.Concat("NULL", " | "));
            }

            return sbDatosBitacora.ToString();
        }

        public string OldData(string conexion, string subProcedimiento, List<KeyValuePair<string, string>> arrayParametros)
        {
            string olddata = string.Empty;

            DataSet ds = BitacorasConsultar(conexion, subProcedimiento, helper.CreateParamsKeyValuePair(arrayParametros));

            if (ds.Tables[0] != null)
                olddata = helper.CreateParamsData(ds.Tables[0]);
            else
                olddata = string.Empty;

            return olddata;
        }

        public int BitacorasInsertar(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            Int32 resultado;

            try
            {
                #region INSERTAR

                resultado = sqlHelper.Transaccion(conexion, procedimiento, parametros);
                return resultado;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet BitacorasConsultar(string conexion, string procedimiento, List<SqlParameter> parametros)
        {
            DataSet resultado = null;

            try
            {
                #region CONSULTAR

                resultado = sqlHelper.ConsultaDataSetBitacora(conexion, procedimiento, parametros);
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

        #region MIEMBRO IDISPOSABLE

        protected virtual void Dispose(bool disposing)
        {
            if (!disponible)
            {
                if (disposing)
                {
                    if (helper != null)
                    {
                        helper = null;
                    }
                }
                sqlHelper = null;
                disponible = true;
            }
        }

        #endregion

    }
}
