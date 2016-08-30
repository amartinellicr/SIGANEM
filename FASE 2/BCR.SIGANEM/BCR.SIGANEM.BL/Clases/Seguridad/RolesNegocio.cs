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

    public class RolesNegocio : IrolesNegocio
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private IrolesNegocio _instancia;
        public IrolesNegocio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    return new RolesNegocio();
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

        private HelperClass helper = new HelperClass();
        private TransaccionAcceso transaccionDA = new TransaccionAcceso();

        #endregion

        #endregion

        #region CONSTRUCTOR Y FINALIZADOR

        public RolesNegocio()
        {

        }

        #endregion

        #region METODOS PUBLICOS

        public RespuestaEntidad RolesInsertar(String conexion, String conexionBitacora, TiposRolesEntidad tipoRol, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@piCod_Tipo_Rol", tipoRol.CodTipoRol),
                        new SqlParameter("@psDes_Tipo_Rol", tipoRol.DesTipoRol),
                        new SqlParameter("@pbActivo", tipoRol.Activo),
                        new SqlParameter("@psInd_Metodo_Insercion", tipoRol.IndMetodoInsercion),
                        new SqlParameter("@psCod_Usuario", tipoRol.CodUsuarioIngreso)
                    };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Tipos_Roles_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public RespuestaEntidad RolesModificar(String conexion, String conexionBitacora, TiposRolesEntidad tipoRol, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@piId_Tipo_Rol", tipoRol.IdTipoRol),
                        new SqlParameter("@piCod_Tipo_Rol", tipoRol.CodTipoRol),
                        new SqlParameter("@psDes_Tipo_Rol", tipoRol.DesTipoRol),
                        new SqlParameter("@pbActivo", tipoRol.Activo),
                        new SqlParameter("@psInd_Metodo_Insercion", tipoRol.IndMetodoInsercion),
                        new SqlParameter("@psCod_Usuario", tipoRol.CodUsuarioIngreso)
                    };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Tipo_Rol", tipoRol.IdTipoRol.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Tipos_Roles_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Tipos_Roles_Consulta_Detalle", bitacora);
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

        public RespuestaEntidad RolesEliminar(String conexion, String conexionBitacora, TiposRolesEntidad tipoRol, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@piId_Tipo_Rol", tipoRol.IdTipoRol)
                    };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Tipo_Rol", tipoRol.IdTipoRol.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Tipos_Roles_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Tipos_Roles_Consulta_Detalle", bitacora);
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

        public List<TiposRolesEntidad> RolesConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<TiposRolesEntidad> retorno = new List<TiposRolesEntidad>();
            TiposRolesEntidad elemento;
            DataSet rowsAffected;

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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Tipos_Roles_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new TiposRolesEntidad();
                        elemento.IdTipoRol = int.Parse(dr[0].ToString());
                        elemento.CodTipoRol = int.Parse(dr[1].ToString());
                        elemento.DesTipoRol = dr[2].ToString();
                        elemento.Activo = bool.Parse(dr[3].ToString());

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

        public TiposRolesEntidad RolesConsultarDetalle(String conexion, String conexionBitacora, TiposRolesEntidad tipoRol, BitacorasEntidad bitacora)
        {
            TiposRolesEntidad retorno = new TiposRolesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                        {
                            new SqlParameter("@piId_Tipo_Rol", tipoRol.IdTipoRol)
                        };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Tipo_Rol", tipoRol.IdTipoRol.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Tipos_Roles_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Tipos_Roles_Consulta_Detalle", bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno = new TiposRolesEntidad();
                    retorno.IdTipoRol = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.CodTipoRol = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    retorno.DesTipoRol = rowsAffected.Tables[0].Rows[0][2].ToString();
                    retorno.Activo = bool.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());

                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][4].ToString();
                    if (rowsAffected.Tables[0].Rows[0][5].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    else
                        retorno.FechaIngreso = null;
                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][6].ToString();
                    if (rowsAffected.Tables[0].Rows[0][7].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;
                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][8].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][9].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][10].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Int32 RolesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
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

                retorno = transaccionDA.TransaccionRows(conexion, "Tipos_Roles_Total_Filas", paramTransaccion);
                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ListaEntidad> RolesLista(String conexion, String filtro)
        {
            List<ListaEntidad> retorno = new List<ListaEntidad>();
            ListaEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psFiltro", filtro)
            };

            #endregion

            try
            {
                #region LISTA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Tipos_Roles_Lista", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new ListaEntidad();
                        elemento.Valor = dr[0].ToString();
                        elemento.Texto = dr[1].ToString();

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

        public Int32 RolesUsuariosConsultar(String conexion, TiposRolesEntidad tipoRol)
        {
            DataSet retorno = null;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Rol", tipoRol.IdTipoRol)
            };

            #endregion

            try
            {
                #region CONSULTAR

                retorno = transaccionDA.TransaccionConsulta(conexion, "Tipos_Roles_Usuarios_Consulta", paramTransaccion);
                return int.Parse(retorno.Tables[0].Rows[0][0].ToString());

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
