using System;
using System.Data;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;
using BCR.SIGANEM.EN;


namespace BCR.SIGANEM.BL
{
    public interface IusuariosNegocio
    {
        //REGISTRO CONEXION
        bool UsuariosValidar(string conexion, string codUsuario);
        UsuariosEntidad UsuariosConsultarIntentos(string conexion, string codUsuario);
        RespuestaEntidad UsuariosActualizarIntentos(string conexion, UsuariosEntidad usuario);
        RespuestaEntidad UsuariosActualizarConexion(string conexion, UsuariosEntidad usuario);
        Int32 UsuariosValidarAcceso(string conexion, string codUsuario, string desPagina);
        UsuariosEntidad UsuariosDatosRoles(string conexion, string codUsuario);
        //MANTENIMIENTO
        RespuestaEntidad UsuariosInsertar(String conexion, String conexionBitacora, UsuariosEntidad usuario, BitacorasEntidad bitacora);
        RespuestaEntidad UsuariosModificar(String conexion, String conexionBitacora, UsuariosEntidad usuario, BitacorasEntidad bitacora);
        RespuestaEntidad UsuariosEliminar(String conexion, String conexionBitacora, UsuariosEntidad usuario, BitacorasEntidad bitacora);
        List<UsuariosEntidad> UsuariosConsultar(String conexion, ParametrosConsultaEntidad entidad);
        UsuariosEntidad UsuariosConsultarDetalle(String conexion, String conexionBitacora, UsuariosEntidad usuario, BitacorasEntidad bitacora);
        Int32 UsuariosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad);
    }
}
