using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

using BCR.SIGANEM.EN;

namespace BCR.SIGANEM.BL
{
    //CONTROL DE CAMBIO 1-24372961
    public interface IparametrosBienesNegocio
    {
        RespuestaEntidad ParametrosBienesModificar(String _conexion, String _conexionBitacora, ParametrosBienesEntidad _entidad, BitacorasEntidad _bitacora);
        List<ParametrosBienesEntidad> ParametrosBienesConsultar(String _conexion, ParametrosConsultaEntidad _entidad);
        ParametrosBienesEntidad ParametrosBienesConsultarDetalle(String _conexion, String _conexionBitacora, ParametrosBienesEntidad _entidad, BitacorasEntidad _bitacora);
        Int32 ParametrosBienesTotalFilas(String _conexion, ParametrosTotalFilasEntidad _entidad);
    }
}
