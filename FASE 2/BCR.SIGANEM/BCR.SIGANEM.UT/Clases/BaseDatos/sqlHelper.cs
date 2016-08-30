using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace BCR.SIGANEM.UT
{
    public class sqlHelper
    {

        #region PROPIEDADES

        #region VARIABLES

        /// <summary>
        /// Propiedad: Conexion SQL
        /// </summary>
        private SqlConnection _sqlConnectionGlobal;
        protected SqlConnection SqlConnectionGlobal
        {
            get { return _sqlConnectionGlobal; }
            set { _sqlConnectionGlobal = value; }
        }

        /// <summary>
        /// Propiedad: Comando SQL
        /// </summary>
        private SqlCommand _sqlCommandGlobal;
        protected SqlCommand SqlCommandGlobal
        {
            get { return _sqlCommandGlobal; }
            set { _sqlCommandGlobal = value; }
        }

        /// <summary>
        /// Propiedad: Adaptador de datos SQL
        /// </summary>
        private SqlDataAdapter _sqlDataAdapter;
        protected SqlDataAdapter SqlDataAdapter
        {
            get { return _sqlDataAdapter; }
            set { _sqlDataAdapter = value; }
        }

        /// <summary>
        /// Propiedad: Lector de datos SQL
        /// </summary>
        private SqlDataReader _sqlDataReader;
        public SqlDataReader SqlDataReader
        {
            get { return _sqlDataReader; }
            set { _sqlDataReader = value; }
        }

        /// <summary>
        /// Propiedad: Set de datos
        /// </summary>
        private DataSet _dataSet;
        protected DataSet DataSet
        {
            get { return _dataSet; }
            set { _dataSet = value; }
        }

        /// <summary>
        /// Propiedad: 
        /// </summary>
        private DataTable _dataTable;
        protected DataTable DataTable
        {
            get { return _dataTable; }
            set { _dataTable = value; }
        }

        #endregion

        #endregion

        #region METODOS PUBLICOS

        #region CREAR PARAMETROS

        public SqlParameter CreateSqlParameter(string paramName, object paramValue)
        {
            SqlParameter parameter = new SqlParameter(paramName, paramValue);

            return parameter;
        }

        #endregion

        #region RESULTADO ENTERO

        public int ResultInt(string conexion, string procedimiento)
        {
            SqlConnection _connection = null;
            SqlParameter returnedValue = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {

                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();
                    returnedValue = SqlCommandGlobal.CreateParameter();
                    returnedValue.Direction = ParameterDirection.ReturnValue;
                    returnedValue.SqlDbType = SqlDbType.Int;
                    returnedValue.ParameterName = "@ReturnValue";

                    SqlCommandGlobal.Parameters.Add(returnedValue);
                    SqlDataReader = SqlCommandGlobal.ExecuteReader();
                    SqlCommandGlobal.ExecuteNonQuery();

                    return (int)returnedValue.Value;
                }

            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }
        }

        public int ResultInt(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            SqlConnection _connection = null;
            SqlParameter returnedValue = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();
                    returnedValue = SqlCommandGlobal.CreateParameter();
                    returnedValue.Direction = ParameterDirection.ReturnValue;
                    returnedValue.SqlDbType = SqlDbType.Int;
                    returnedValue.ParameterName = "@ReturnValue";

                    SqlCommandGlobal.Parameters.Add(returnedValue);
                    foreach (SqlParameter param in parametros)
                    {
                        SqlCommandGlobal.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                    SqlCommandGlobal.ExecuteNonQuery();

                    return (int)returnedValue.Value;
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }
        }

        #endregion

        #region CONSULTAS GENERALES

        #region RESULTADO LIST

        public List<string> ConsultaLista(string conexion, string procedimiento)
        {
            List<string> consultaLista;
            consultaLista = new List<string>();
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    SqlConnectionGlobal.Open();
                    using (SqlDataReader reader = SqlCommandGlobal.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            consultaLista.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return consultaLista;
        }

        public List<string> ConsultaLista(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            List<string> consultaLista;
            consultaLista = new List<string>();
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    foreach (SqlParameter param in parametros)
                    {
                        SqlCommandGlobal.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }

                    SqlConnectionGlobal.Open();
                    using (SqlDataReader reader = SqlCommandGlobal.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            consultaLista.Add(reader.GetString(0));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return consultaLista;
        }

        #endregion

        #region RESULTADO STRING

        public string ConsultaString(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            string consultaLista;
            consultaLista = string.Empty;
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    foreach (SqlParameter param in parametros)
                    {
                        SqlCommandGlobal.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }

                    _connection.Open();
                    using (SqlDataReader reader = SqlCommandGlobal.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            consultaLista = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return consultaLista;
        }

        #endregion

        #region RESULTADO DATASET

        public DataSet ConsultaDataSet(string conexion, string procedimiento)
        {
            _dataSet = null;
            _dataSet = new DataSet();
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();

                    _sqlDataAdapter = new SqlDataAdapter();
                    _sqlDataAdapter.SelectCommand = SqlCommandGlobal;
                    _sqlDataAdapter.Fill(_dataSet);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return _dataSet;
        }

        public DataSet ConsultaDataSet(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            _dataSet = null;
            _dataSet = new DataSet();
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();
                    foreach (SqlParameter param in parametros)
                    {
                        SqlCommandGlobal.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }

                    _sqlDataAdapter = new SqlDataAdapter();
                    _sqlDataAdapter.SelectCommand = SqlCommandGlobal;
                    _sqlDataAdapter.Fill(_dataSet);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return _dataSet;
        }

        public DataSet ConsultaDataSetBitacora(string conexion, string procedimiento, List<SqlParameter> parametros)
        {
            _dataSet = null;
            _dataSet = new DataSet();
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();
                    foreach (SqlParameter param in parametros)
                    {
                        SqlCommandGlobal.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }

                    _sqlDataAdapter = new SqlDataAdapter();
                    _sqlDataAdapter.SelectCommand = SqlCommandGlobal;
                    _sqlDataAdapter.Fill(_dataSet);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return _dataSet;
        }

        #endregion

        #region RESULTADO DATATABLE

        public DataTable ConsultaDataTable(string conexion, string procedimiento)
        {
            _dataTable = null;
            _dataTable = new DataTable();
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();
                    _sqlDataAdapter = new SqlDataAdapter();
                    _sqlDataAdapter.SelectCommand = SqlCommandGlobal;
                    _sqlDataAdapter.Fill(_dataTable);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return _dataTable;
        }

        public DataTable ConsultaDataTable(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            _dataTable = null;
            _dataTable = new DataTable();
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();
                    foreach (SqlParameter param in parametros)
                    {
                        SqlCommandGlobal.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }

                    _sqlDataAdapter = new SqlDataAdapter();
                    _sqlDataAdapter.SelectCommand = SqlCommandGlobal;
                    _sqlDataAdapter.Fill(_dataTable);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return _dataTable;
        }

        public DataTable ConsultaDataTableBitacora(string conexion, string procedimiento, List<SqlParameter> parametros)
        {
            _dataTable = null;
            _dataTable = new DataTable();
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    SqlConnectionGlobal.Open();
                    foreach (SqlParameter pair in parametros)
                    {
                        SqlCommandGlobal.Parameters.AddWithValue(pair.ParameterName, pair.Value);
                    }

                    _sqlDataAdapter = new SqlDataAdapter();
                    _sqlDataAdapter.SelectCommand = SqlCommandGlobal;
                    _sqlDataAdapter.Fill(_dataTable);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return _dataTable;
        }

        #endregion

        #region RESULTADO DATABRIDGE

        //REQUERIMIENTO: 1-24493201 GARANTÍAS DE OPERACIONES – INTERFAZ SICC
        public DataSet ConsultaDataBridge(string conexion, string query)
        {
            _dataSet = null;
            _dataSet = new DataSet();
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = query.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.Text;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();

                    _sqlDataAdapter = new SqlDataAdapter();
                    _sqlDataAdapter.SelectCommand = SqlCommandGlobal;
                    _sqlDataAdapter.Fill(_dataSet);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return _dataSet;
        }

        #endregion

        #region RESULTADO RUC

        public DataSet ConsultaRuc(string conexion, string query)
        {
            _dataSet = null;
            _dataSet = new DataSet();
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = query.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.Text;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();

                    _sqlDataAdapter = new SqlDataAdapter();
                    _sqlDataAdapter.SelectCommand = SqlCommandGlobal;
                    _sqlDataAdapter.Fill(_dataSet);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return _dataSet;
        }

        #endregion

        #endregion

        #region TRANSACCIONES GENERALES

        public int Transaccion(string conexion, string procedimiento)
        {
            int rowsAffected;
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();
                    rowsAffected = SqlCommandGlobal.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return rowsAffected;
        }

        public int Transaccion(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            int rowsAffected;
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();
                    foreach (SqlParameter param in parametros)
                    {
                        SqlCommandGlobal.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                    rowsAffected = SqlCommandGlobal.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return rowsAffected;
        }

        public int TransaccionBitacora(string conexion, string procedimiento, SqlParameter[] parametros)
        {
            int rowsAffected;
            SqlConnection _connection = null;

            try
            {
                using (_connection = new SqlConnection(conexion))
                {
                    SqlCommandGlobal = new SqlCommand();
                    SqlCommandGlobal.CommandText = procedimiento.Trim().ToString();
                    SqlCommandGlobal.CommandType = CommandType.StoredProcedure;
                    SqlCommandGlobal.Connection = _connection;

                    _connection.Open();
                    foreach (SqlParameter param in parametros)
                    {
                        SqlCommandGlobal.Parameters.AddWithValue(param.ParameterName, param.Value);
                    }
                    rowsAffected = SqlCommandGlobal.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }

            return rowsAffected;
        }

        #endregion

        #endregion

    }
}
