using System;
using System.Data;
using System.Text;
using System.Collections.Generic;

using BCR.SIGANEM.EN;


namespace BCR.SIGANEM.BL
{
    public interface IsitemapNegocio
    {
        List<PantallasEntidad> PantallasConsulta(string conexion);
        PantallasEntidad PantallasConsultaDetalle(String conexion, String conexionBitacora, PantallasEntidad pantallasRoles, BitacorasEntidad _bitacora);
        RespuestaEntidad PantallasRolesInsertar(String conexion, PantallasRolesEntidad pantallasRoles);
        RespuestaEntidad PantallasRolesEliminar(String conexion, PantallasRolesEntidad pantallasRoles);
        List<PantallasRolesEntidad> PantallasRolesConsultaDetalle(String conexion, PantallasRolesEntidad pantallasRoles);
    }
}
