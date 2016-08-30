using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace BCR.SIGANEM.DA
{
    public interface IbitacoraAcceso
    {
        string NewData(SqlParameter[] parametros);
        string OldData(string conexion, string subProcedimiento, List<KeyValuePair<string, string>> arrayParametros);
        int BitacorasInsertar(string conexion, string procedimiento, SqlParameter[] parametros);
        DataSet BitacorasConsultar(string conexion, string procedimiento, List<SqlParameter> parametros);
    }
}
