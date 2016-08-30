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
    public class MensajesNegocio : ImensajesNegocio
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private ImensajesNegocio _instancia;
        public ImensajesNegocio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    return new MensajesNegocio();
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

        #region CONSTANTES

        private const string _consultarMensaje = "Mensajes_Consulta";

        #endregion

        #endregion

        #region CONSTRUCTOR Y FINALIZADOR

        public MensajesNegocio()
        {

        }

        #endregion

        #region METODOS PUBLICOS

        public MensajesEntidad MensajesConsulta(string conexion, MensajesEntidad entidad)
        {
            MensajesEntidad elemento = null;
            DataSet valor = null;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psCod_Mensaje", entidad.CodMensaje)
            };

            #endregion

            try
            {
                #region CONSULTAR

                valor = transaccionDA.TransaccionConsulta(conexion, _consultarMensaje, paramTransaccion);
                if (!valor.Equals(null))
                {
                    elemento = new MensajesEntidad();
                    elemento.IdMensaje = int.Parse(valor.Tables[0].Rows[0][0].ToString());
                    elemento.CodMensaje = valor.Tables[0].Rows[0][1].ToString();
                    elemento.DesMensaje = valor.Tables[0].Rows[0][2].ToString();
                    elemento.TipoMensaje = int.Parse(valor.Tables[0].Rows[0][3].ToString());
                    elemento.DesTipoMensaje = valor.Tables[0].Rows[0][5].ToString();
                }
                return elemento;

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
