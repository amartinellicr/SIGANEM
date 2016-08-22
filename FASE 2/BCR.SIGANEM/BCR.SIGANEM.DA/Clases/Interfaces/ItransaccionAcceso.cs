using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.UT;
using BCR.SIGANEM.EN;


namespace BCR.SIGANEM.DA
{
    public interface ItransaccionAcceso
    {
        //CONSULTAR DATABRIDGE
        DataSet TransaccionConsultaDataBridge(string conexion, string query);
        //REGISTRAR BITACORA
        DataSet TransaccionInsertar(string conexion, string connBitacora, string procedimiento, SqlParameter[] parametros, EnumTipoBitacora tipoBitacora, BitacorasEntidad bitacora);
        DataSet TransaccionModificar(string conexion, string connBitacora, string procedimiento, SqlParameter[] parametros, EnumTipoBitacora tipoBitacora, List<KeyValuePair<string, string>> arrayOldValues, string spConsulta, BitacorasEntidad bitacora);
        DataSet TransaccionEliminar(string conexion, string connBitacora, string procedimiento, SqlParameter[] parametros, EnumTipoBitacora tipoBitacora, List<KeyValuePair<string, string>> arrayDeleteValues, string spConsulta, BitacorasEntidad bitacora);
        DataSet TransaccionConsultaDetalle(string conexion, string connBitacora, string procedimiento, SqlParameter[] parametros, EnumTipoBitacora tipoBitacora, List<KeyValuePair<string, string>> arrayOldValues, string spConsulta, BitacorasEntidad bitacora);
        //SIN REGISTRAR BITACORA
        DataSet TransaccionInsertar(string conexion, string procedimiento, SqlParameter[] parametros);
        DataSet TransaccionModificar(string conexion, string procedimiento, SqlParameter[] parametros);
        DataSet TransaccionEliminar(string conexion, string procedimiento, SqlParameter[] parametros);
        int TransaccionRows(string conexion, string procedimiento, SqlParameter[] parametros);
        DataSet TransaccionConsulta(string conexion, string procedimiento);
        DataSet TransaccionConsulta(string conexion, string procedimiento, SqlParameter[] parametros);
        string TransaccionConsultaString(string conexion, string procedimiento, SqlParameter[] parametros);
    }
}
