using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BCR.SIGANEM.EN;

namespace BCR.SIGANEM.BL
{
    public interface IprocesosNegocio
    {
        #region BITACORA PROCESOS

        List<BitacoraProcesosDetalle> BitacoraProcesosConsultar(String conexion, BitacoraProcesosConsulta consulta, ParametrosConsultaEntidad entidad);
        Int32 BitacoraProcesosTotalFilas(String conexion, BitacoraProcesosConsulta entidad);

        #endregion 

        #region PROCESOS

        List<ListaEntidad> ProcesosLista(String conexion, String filtro);

        #endregion

        #region ARCHIVOS SALIDA

        List<ListaEntidad> ArchivosLista(String conexion, String filtro);
        RespuestaEntidad EjecutarArchivo(String conexion, String conexionBitacora, int archivo, byte generar, BitacorasEntidad _bitacora);

        #endregion

    }
}
