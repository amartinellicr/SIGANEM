using System;
using System.Data;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;
using BCR.SIGANEM.EN;

namespace BCR.SIGANEM.BL
{
    public interface IrolesNegocio
    {
        RespuestaEntidad RolesInsertar(String conexion, String conexionBitacora, TiposRolesEntidad tiposRoles, BitacorasEntidad bitacora);
        RespuestaEntidad RolesModificar(String conexion, String conexionBitacora, TiposRolesEntidad tipoRol, BitacorasEntidad bitacora);
        RespuestaEntidad RolesEliminar(String conexion, String conexionBitacora, TiposRolesEntidad tiposRoles, BitacorasEntidad bitacora);
        List<TiposRolesEntidad> RolesConsultar(String conexion, ParametrosConsultaEntidad entidad);
        TiposRolesEntidad RolesConsultarDetalle(String conexion, String conexionBitacora, TiposRolesEntidad tiposRoles, BitacorasEntidad bitacora);
        Int32 RolesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
        List<ListaEntidad> RolesLista(String conexion, String filtro);
        Int32 RolesUsuariosConsultar(String conexion, TiposRolesEntidad tipoRol);
    }
}
