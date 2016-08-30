using System;
using System.Text;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;
using System.Collections.Generic;

using BCR.SIGANEM.DA;
using BCR.SIGANEM.EN;
using BCR.SIGANEM.UT;


namespace BCR.SIGANEM.BL
{
    public class BitacoraNegocio : IbitacoraNegocio
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private IbitacoraNegocio _instancia;
        public IbitacoraNegocio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    return new BitacoraNegocio();
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
        private BitacoraAcceso bitacoraDA = new BitacoraAcceso();
        private BitacoraFlags bitacoraFlags = new BitacoraFlags();

        #endregion

        #region CONSTANTES

        private const string _insertarBitacora = "pa_Bitacora_Inserta";

        #endregion

        #endregion

        #region CONSTRUCTOR Y FINALIZADOR

        public BitacoraNegocio()
        {
            
        }

        #endregion

        #region METODOS PUBLICOS
        //CAMBIO FGUEVARA
        public int BitacoraRegistrar(string conexion, BitacorasEntidad bitacora)
        {
            Int32 rowsAffected;
            
            #region PARAMETROS

            SqlParameter[] paramBitacora = new SqlParameter[]
            {
                new SqlParameter("@piCod_Accion", bitacora.CodAccion),
                new SqlParameter("@piCod_Modulo", bitacora.CodModulo),
                new SqlParameter("@piCod_Empresa", bitacora.CodEmpresa),
                new SqlParameter("@psCod_Sistema", bitacora.CodSistema),                
                new SqlParameter("@psCod_Usuario", bitacora.CodUsuario),
                new SqlParameter("@psDato_Nuevo", helper.ToDBNull(bitacora.DatoNuevo)),
                new SqlParameter("@psDato_Actualizado", helper.ToDBNull(bitacora.DatoActualizado)),
                new SqlParameter("@psDato_Eliminado", helper.ToDBNull(bitacora.DatoEliminado)),
                new SqlParameter("@psDes_Registro", helper.ToDBNull(bitacora.DesRegistro))
            };

            #endregion

            try
            {
                #region REGISTRAR BITACORA

                rowsAffected = bitacoraDA.BitacorasInsertar(conexion, _insertarBitacora, paramBitacora);
                
                return rowsAffected;

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
