using System;
using System.Text;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.EN;

namespace BCR.SIGANEM.BL
{
    public interface IindicadoresEconomicosNegocio
    {

        #region INDICES PRECIOS CONSUMIDOR

        RespuestaEntidad IndicesPreciosConsumidorInsertar(String conexion, String conexionBitacora, IndicesPreciosConsumidorEntidad entidad, BitacorasEntidad bitacora);
        List<IndicesPreciosConsumidorEntidad> IndicesPreciosConsumidorConsultar(String conexion, ParametrosConsultaEntidad entidad);
        Int32 IndicesPreciosConsumidorTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
        MensajesEntidad IndicesPreciosConsumidorConsultarBCCR(String conexion);

        #endregion 

        #region TIPOS CAMBIOS

        RespuestaEntidad TiposCambiosInsertar(String conexion, String conexionBitacora, TiposCambiosEntidad entidad, BitacorasEntidad bitacora);
        List<TiposCambiosEntidad> TiposCambiosConsultar(String conexion, ParametrosConsultaEntidad entidad);
        Int32 TiposCambiosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
        MensajesEntidad TiposCambiosConsultarBCCR(String conexion);

        #endregion

        #region REGISTRAR EJECUCION SERVICIO

        int RegistraEjecucionServicioBitacora(String _conexionBitacora, BitacorasEntidad _bitacora);

        #endregion

    }
}
