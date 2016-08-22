using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace BCR.SIGANEM.UT
{
    public class HelperClass
    {
       
        #region METODOS PUBLICOS
        
        public object ToDBNull(object value)
        {
            if (value != null)
            {
                return value;
            }
            else
            {
                return DBNull.Value;
            }
        }

        public KeyValuePair<string, int> CrearKeyValuePairItem(string key, int value)
        {
            return new KeyValuePair<string, int>(key, value);
        }

        public KeyValuePair<string, string> CrearKeyValuePairItem(string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }

        public KeyValuePair<string, Nullable<int>> CrearKeyValuePairItem(string key, Nullable<int> value)
        {
            return new KeyValuePair<string, Nullable<int>>(key, value);
        }

        public List<SqlParameter> CreateParamsKeyValuePair(List<KeyValuePair<string, string>> arrayParameters)
        {
            List<SqlParameter> sqlTableParameters = new List<SqlParameter>();

            foreach (KeyValuePair<string, string> obj in arrayParameters)
            {
                SqlParameter p = new SqlParameter(obj.Key, SqlDbType.Int);
                p.Value = obj.Value.ToString();
                sqlTableParameters.Add(p);
            }

            return sqlTableParameters;
        }

        public string CreateParamsData(DataTable tableData)
        {
            StringBuilder sbDatosBitacora = new StringBuilder();

            foreach (DataRow row in tableData.Rows)
            {
                for (int i = 0; i < tableData.Columns.Count; i++)
                {
                    DataColumn col = (DataColumn)tableData.Columns[i];

                    if (String.IsNullOrEmpty(row[i].ToString()))
                        sbDatosBitacora.Append(String.Concat("NULL", " | "));
                    else
                        sbDatosBitacora.Append(String.Concat(col.ColumnName, ": ", row[i].ToString(), " | "));
                }
            }

            return sbDatosBitacora.ToString();
        }

        #endregion

    }
}
