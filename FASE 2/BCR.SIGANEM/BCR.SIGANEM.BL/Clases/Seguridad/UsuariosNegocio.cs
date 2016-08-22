using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.DA;
using BCR.SIGANEM.EN;
using BCR.SIGANEM.UT;


namespace BCR.SIGANEM.BL
{
    public class UsuariosNegocio : IusuariosNegocio
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private IusuariosNegocio _instancia;
        public IusuariosNegocio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    return new UsuariosNegocio();
                }
                return _instancia;
            }
            set
            {
                if (_instancia == null)
                {
                    _instancia = value;
                }
            }
        }

        #endregion

        #region VARIABLES

        private HelperClass _helper = new HelperClass();
        private TransaccionAcceso _TransaccionDA = new TransaccionAcceso();

        #endregion

        #endregion
        
        #region CONSTRUCTOR Y FINALIZADOR

        public UsuariosNegocio()
        {

        }

        #endregion

        #region METODOS PUBLICOS

        #region REGISTRO CONEXION

        public bool UsuariosValidar(string conexion, string codUsuario)
        {
            DataSet rowsAffected = null;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psCod_Usuario", codUsuario)
            };

            #endregion

            try
            {
                #region VALIDAR

                rowsAffected = _TransaccionDA.TransaccionConsulta(conexion, "Usuarios_Validar", paramTransaccion);

                if (rowsAffected.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuariosEntidad UsuariosConsultarIntentos(string conexion, string codUsuario)
        {
            UsuariosEntidad retorno = new UsuariosEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psCod_Usuario", codUsuario)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = _TransaccionDA.TransaccionConsulta(conexion, "Usuarios_Consulta_Intentos", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    retorno.CantidadIntento = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.Bloqueado = bool.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    //CAMBIO ALEXANDER MENDEZ 20140730
                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        retorno.FechaIntento = DateTime.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    else
                        retorno.FechaIntento = null;
                    //CAMBIO ALEXANDER MENDEZ 20140730
                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        retorno.UltimaConexion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    else
                        retorno.UltimaConexion = null;
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad UsuariosActualizarIntentos(string conexion, UsuariosEntidad usuario)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psCod_Usuario", usuario.CodUsuario),
                new SqlParameter("@pbBloqueado", usuario.Bloqueado),
                new SqlParameter("@piCantidad_Intento", usuario.CantidadIntento),
                new SqlParameter("@pdtFecha_Intento", usuario.FechaIntento),
            };

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = _TransaccionDA.TransaccionModificar(conexion, "Usuarios_Actualiza_Intentos", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    elemento = new RespuestaEntidad();
                    elemento.ValorEstado = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    elemento.ValorError = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }

        }

        public RespuestaEntidad UsuariosActualizarConexion(string conexion, UsuariosEntidad usuario)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psCod_Usuario", usuario.CodUsuario),
                new SqlParameter("@pbConectado", usuario.Conectado),
                new SqlParameter("@pdtUltima_Conexion", usuario.UltimaConexion)
            };

            #endregion

            try
            {
                #region ACTUALIZAR

                rowsAffected = _TransaccionDA.TransaccionModificar(conexion, "Usuarios_Actualiza_Conexion", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    elemento = new RespuestaEntidad();
                    elemento.ValorEstado = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    elemento.ValorError = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Int32 UsuariosValidarAcceso(string conexion, string codUsuario, string desPagina)
        {
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psCod_Usuario", codUsuario),
                new SqlParameter("@psDes_Pagina", desPagina)
            };

            #endregion

            try
            {
                #region VALIDAR

                rowsAffected = _TransaccionDA.TransaccionConsulta(conexion, "Usuarios_Validar_Acceso", paramTransaccion);
                return int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Int32 UsuariosValidarAccesoCodigo(string conexion, string codUsuario, string codPagina)
        {
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psCod_Usuario", codUsuario),
                new SqlParameter("@psCod_Pagina", codPagina)
            };

            #endregion

            try
            {
                #region VALIDAR

                rowsAffected = _TransaccionDA.TransaccionConsulta(conexion, "Usuarios_Validar_Acceso_Codigo", paramTransaccion);
                return int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuariosEntidad UsuariosDatosRoles(string conexion, string codUsuario)
        {
            UsuariosEntidad retorno = new UsuariosEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psCod_Usuario", codUsuario)
            };

            #endregion

            try
            {
                #region VALIDAR

                rowsAffected = _TransaccionDA.TransaccionConsulta(conexion, "Usuarios_Validar", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdUsuario = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.CodUsuario = rowsAffected.Tables[0].Rows[0][1].ToString();
                    retorno.IdTipoRol = int.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    retorno.Bloqueado = bool.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region MANTENIMIENTO

        public RespuestaEntidad UsuariosInsertar(String conexion, String conexionBitacora, UsuariosEntidad usuario, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Rol", usuario.IdTipoRol),
                new SqlParameter("@psCod_Usuario", usuario.CodUsuario),
                new SqlParameter("@pbBloqueado", usuario.Bloqueado),
                new SqlParameter("@pbConectado", usuario.Conectado),
                new SqlParameter("@piCantidad_Intento", usuario.CantidadIntento),
                new SqlParameter("@psNombre_Usuario", usuario.NombreUsuario),
                new SqlParameter("@psInd_Metodo_Insercion", usuario.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario_Inserta", usuario.CodUsuarioIngreso)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = _TransaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Usuarios_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
                if (!rowsAffected.Equals(null))
                {
                    elemento = new RespuestaEntidad();
                    elemento.ValorEstado = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    elemento.ValorError = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad UsuariosModificar(String conexion, String conexionBitacora, UsuariosEntidad usuario, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Usuario", usuario.IdUsuario),
                new SqlParameter("@piId_Tipo_Rol", usuario.IdTipoRol),
                new SqlParameter("@psCod_Usuario", usuario.CodUsuario),
                new SqlParameter("@pbBloqueado", usuario.Bloqueado),
                new SqlParameter("@pbConectado", usuario.Conectado),
                new SqlParameter("@piCantidad_Intento", usuario.CantidadIntento),
                new SqlParameter("@psNombre_Usuario", usuario.NombreUsuario),
                new SqlParameter("@psInd_Metodo_Insercion", usuario.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario_Modifica", usuario.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> _itemConsulta = new List<KeyValuePair<string, string>>();
            _itemConsulta.Add(_helper.CrearKeyValuePairItem("@piId_Usuario", usuario.IdUsuario.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = _TransaccionDA.TransaccionModificar(conexion, conexionBitacora, "Usuarios_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, _itemConsulta, "Usuarios_Consulta_Detalle", bitacora);
                if (!rowsAffected.Equals(null))
                {
                    elemento = new RespuestaEntidad();
                    elemento.ValorEstado = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    elemento.ValorError = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                }
                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad UsuariosEliminar(String conexion, String conexionBitacora, UsuariosEntidad usuario, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@piId_Usuario", usuario.IdUsuario)
                    };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> _itemConsulta = new List<KeyValuePair<string, string>>();
            _itemConsulta.Add(_helper.CrearKeyValuePairItem("@piId_Usuario", usuario.IdUsuario.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = _TransaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Usuarios_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, _itemConsulta, "Usuarios_Consulta_Detalle", bitacora);
                if (!rowsAffected.Equals(null))
                {
                    elemento = new RespuestaEntidad();
                    elemento.ValorEstado = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    elemento.ValorError = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                }
                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UsuariosEntidad> UsuariosConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<UsuariosEntidad> retorno = new List<UsuariosEntidad>();
            UsuariosEntidad elemento;
            DataSet rowsAffected = null;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                       new SqlParameter("@piIndice_Inicio_Fila", entidad.IndiceInicioFila),
                       new SqlParameter("@piMaximo_Filas", entidad.MaximoFilas),
                       new SqlParameter("@psValores_Filtro", entidad.ValorFiltro),
                       new SqlParameter("@psColumnas_Filtros", entidad.ColumnaFiltro),
                       new SqlParameter("@psColumna_Ordenar", entidad.ColumnaOrdenar)
                    };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = _TransaccionDA.TransaccionConsulta(conexion, "Usuarios_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new UsuariosEntidad();
                        elemento.IdUsuario = int.Parse(dr[0].ToString());
                        elemento.IdTipoRol = int.Parse(dr[1].ToString());
                        elemento.CodUsuario = dr[2].ToString();
                        elemento.DesBloqueado = dr[3].ToString();
                        elemento.CantidadIntento = int.Parse(dr[4].ToString());
                        if (dr[5].ToString().Length > 0)
                            elemento.FechaIntento = DateTime.Parse(dr[5].ToString());
                        else
                            elemento.FechaIntento = null;
                        elemento.NombreUsuario = dr[6].ToString();
                        elemento.DesConectado = dr[7].ToString();
                        if (dr[8].ToString().Length > 0)
                            elemento.UltimaConexion = DateTime.Parse(dr[8].ToString());
                        else
                            elemento.UltimaConexion = null;
                        elemento.CodTipoRol = dr[9].ToString();
                        elemento.DesTipoRol = dr[10].ToString();

                        retorno.Add(elemento);
                    }
                }
                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuariosEntidad UsuariosConsultarDetalle(String conexion, String conexionBitacora, UsuariosEntidad usuario, BitacorasEntidad bitacora)
        {
            UsuariosEntidad retorno = new UsuariosEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Usuario", usuario.IdUsuario)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> _itemConsulta = new List<KeyValuePair<string, string>>();
            _itemConsulta.Add(_helper.CrearKeyValuePairItem("@piId_Usuario", usuario.IdUsuario.ToString()));

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = _TransaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Usuarios_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, _itemConsulta, "Usuarios_Consulta_Detalle", bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdUsuario = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.IdTipoRol = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    retorno.CodUsuario = rowsAffected.Tables[0].Rows[0][2].ToString();
                    retorno.Bloqueado = bool.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    retorno.CantidadIntento = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    if (rowsAffected.Tables[0].Rows[0][5].ToString().Length > 0)
                        retorno.FechaIntento = DateTime.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    else
                        retorno.FechaIntento = null;
                    retorno.NombreUsuario = rowsAffected.Tables[0].Rows[0][6].ToString();
                    retorno.Conectado = bool.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());
                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        retorno.FechaIntento = DateTime.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    else
                        retorno.FechaIntento = null;
                    retorno.CodTipoRol = rowsAffected.Tables[0].Rows[0][9].ToString();
                    retorno.DesTipoRol = rowsAffected.Tables[0].Rows[0][10].ToString();
                    
                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][11].ToString();
                    if (rowsAffected.Tables[0].Rows[0][12].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][12].ToString());
                    else
                        retorno.FechaIngreso = null;
                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][13].ToString();
                    if (rowsAffected.Tables[0].Rows[0][14].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][14].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;
                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][15].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][16].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][17].ToString();
                }
                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Int32 UsuariosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            Int32 retorno = 0;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@psValor_Filtro", entidad.ValorFiltro),
                        new SqlParameter("@psColumna_Filtro", entidad.ColumnaFiltro)
                    };

            #endregion

            try
            {
                #region TOTAL FILAS

                retorno = _TransaccionDA.TransaccionRows(conexion, "Usuarios_Total_Filas", paramTransaccion);
                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion

    }
}