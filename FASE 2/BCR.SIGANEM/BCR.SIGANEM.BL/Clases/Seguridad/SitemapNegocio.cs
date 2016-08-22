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
    public class SitemapNegocio : IsitemapNegocio
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private IsitemapNegocio _instancia;
        public IsitemapNegocio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    return new SitemapNegocio();
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

        public SitemapNegocio()
        {

        }

        #endregion

        #region METODOS PUBLICOS

        public List<PantallasEntidad> PantallasConsulta(string conexion)
        {
            List<PantallasEntidad> retorno = new List<PantallasEntidad>();
            PantallasEntidad elemento;
            DataSet rowsAffected;

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Pantallas_Padres_Consulta");
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new PantallasEntidad();
                        elemento.CodPantalla = int.Parse(dr[0].ToString());
                        elemento.TituloPantalla = dr[1].ToString();
                        elemento.PadreOrigen = int.Parse(dr[2].ToString());
                        elemento.SubPadreOrigen = int.Parse(dr[3].ToString());
                        elemento.RutaPantalla = dr[4].ToString();
                        elemento.DesPantalla = dr[5].ToString();

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

        public PantallasEntidad PantallasConsultaDetalle(String conexion, String conexionBitacora, PantallasEntidad pantalla, BitacorasEntidad _bitacora)
        {
            PantallasEntidad retorno = new PantallasEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Pantalla", pantalla.IdPantalla)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Pantalla", pantalla.IdPantalla.ToString()));

            #endregion

            try
            {

                #region LISTA

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Pantallas_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Pantallas_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdPantalla = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.CodPantalla = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    retorno.TituloPantalla = rowsAffected.Tables[0].Rows[0][2].ToString();
                    retorno.PadreOrigen = int.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    retorno.SubPadreOrigen = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    retorno.RutaPantalla = rowsAffected.Tables[0].Rows[0][5].ToString();
                    retorno.DesPantalla = rowsAffected.Tables[0].Rows[0][6].ToString();

                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][7].ToString();
                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    else
                        retorno.FechaIngreso = null;
                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][9].ToString();
                    if (rowsAffected.Tables[0].Rows[0][10].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][10].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;
                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][11].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][12].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][13].ToString();

                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad PantallasRolesInsertar(String conexion, PantallasRolesEntidad pantallasRoles)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Rol", pantallasRoles.IdTipoRol),
                new SqlParameter("@piId_Pantalla", pantallasRoles.IdPantalla),
                new SqlParameter("@psInd_Metodo_Insercion", pantallasRoles.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", pantallasRoles.CodUsuarioIngreso)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, "Pantallas_Roles_Inserta", paramTransaccion);
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

        public RespuestaEntidad PantallasRolesEliminar(String conexion, PantallasRolesEntidad pantallasRoles)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@Id_Tipo_Rol", pantallasRoles.IdTipoRol)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@Id_Tipo_Rol", pantallasRoles.IdTipoRol.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, "Pantallas_Roles_Elimina", paramTransaccion);
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

        public List<PantallasRolesEntidad> PantallasRolesConsultaDetalle(String conexion, PantallasRolesEntidad pantallasRoles)
        {
            List<PantallasRolesEntidad> retorno = new List<PantallasRolesEntidad>();
            PantallasRolesEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Rol", pantallasRoles.IdTipoRol)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@Id_Tipo_Rol", pantallasRoles.IdTipoRol.ToString()));

            #endregion

            try
            {

                #region LISTA

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, "Pantallas_Roles_Consulta_Detalle", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new PantallasRolesEntidad();
                        elemento.IdTipoRol = int.Parse(dr[0].ToString());
                        elemento.IdPantalla = int.Parse(dr[1].ToString());

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

        #endregion

    }
}
