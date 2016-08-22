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
    public class ReportesNegocio : IreportesNegocio
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private IreportesNegocio _instancia;
        public IreportesNegocio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    return new ReportesNegocio();
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

        private bool disponible = false;
        private HelperClass helper = null;
        private TransaccionAcceso transaccionDA = null;

        #endregion

        #endregion
        
        #region CONSTRUCTOR Y FINALIZADOR

        public ReportesNegocio()
        {
            helper = new HelperClass();
            transaccionDA = new TransaccionAcceso();
        }

        ~ReportesNegocio()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region METODOS PUBLICOS

        #region MANTENIMIENTO

        public ReportesEntidad ReportesConsultarDetalle(String conexion, String conexionBitacora, ReportesEntidad entidad, BitacorasEntidad _bitacora)
        {
            ReportesEntidad retorno = new ReportesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Pantalla", entidad.IdPantalla)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Pantalla", entidad.IdPantalla.ToString()));

            #endregion

            try
            {

                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.Instancia.TransaccionConsultaDetalle(conexion, conexionBitacora, "Reportes_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Reportes_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdReporte = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.CodReporte = rowsAffected.Tables[0].Rows[0][1].ToString();
                    retorno.DesReporte = rowsAffected.Tables[0].Rows[0][2].ToString();
                    retorno.Parametros = rowsAffected.Tables[0].Rows[0][3].ToString();
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #endregion

        #region MIEMBRO IDISPOSABLE

        protected virtual void Dispose(bool disposing)
        {
            if (!disponible)
            {
                if (disposing)
                {
                    if (transaccionDA != null)
                    {
                        transaccionDA.Dispose();
                        transaccionDA = null;
                    }

                    if (helper != null)
                    {                        
                        helper = null;
                    }
                }
                disponible = true;
            }
        }

        #endregion

    }
}