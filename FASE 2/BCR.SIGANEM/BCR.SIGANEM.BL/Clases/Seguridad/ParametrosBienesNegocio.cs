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
    //CONTROL DE CAMBIO 1-24372961
    public class ParametrosBienesNegocio : IparametrosBienesNegocio
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private IparametrosBienesNegocio _instancia;
        public IparametrosBienesNegocio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    return new ParametrosBienesNegocio();
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

        public ParametrosBienesNegocio()
        {

        }

        #endregion

        #region METODOS PUBLICOS

        public RespuestaEntidad ParametrosBienesModificar(String _conexion, String _conexionBitacora, ParametrosBienesEntidad _entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Parametro_Bien", _entidad.IdParametroBien),
                new SqlParameter("@piMeses_Prescripcion_Aeronave", _entidad.MesesPrescripcionAeronave),
                new SqlParameter("@piMeses_Prescripcion_Alhaja", _entidad.MesesPrescripcionAlhaja),
                new SqlParameter("@piMeses_Prescripcion_Animal", _entidad.MesesPrescripcionAnimal),
                new SqlParameter("@piMeses_Prescripcion_Bien", _entidad.MesesPrescripcionBien),
                new SqlParameter("@piMeses_Prescripcion_Bono_Prenda", _entidad.MesesPrescripcionBonoPrenda),
                new SqlParameter("@piMeses_Prescripcion_Buque", _entidad.MesesPrescripcionBuque),
                new SqlParameter("@piMeses_Prescripcion_Cultivo_Fruto", _entidad.MesesPrescripcionCultivoFruto),
                new SqlParameter("@piMeses_Prescripcion_Edificacion", _entidad.MesesPrescripcionEdificacion),
                new SqlParameter("@piMeses_Prescripcion_Equipo_Computo", _entidad.MesesPrescripcionEquipoComputo),
                new SqlParameter("@piMeses_Prescripcion_Fianza", _entidad.MesesPrescripcionFianza),
                new SqlParameter("@piMeses_Prescripcion_Madera", _entidad.MesesPrescripcionMadera),
                new SqlParameter("@piMeses_Prescripcion_Maquinaria_Equipo", _entidad.MesesPrescripcionMaquinariaEquipo),
                new SqlParameter("@piMeses_Prescripcion_Materia_Prima", _entidad.MesesPrescripcionMateriaPrima),
                new SqlParameter("@piMeses_Prescripcion_Mobiliario", _entidad.MesesPrescripcionMobiliario),
                new SqlParameter("@piMeses_Prescripcion_Otro_Tipo_Bien", _entidad.MesesPrescripcionOtroTipoBien),
                new SqlParameter("@piMeses_Prescripcion_Terreno", _entidad.MesesPrescripcionTerreno),
                new SqlParameter("@piMeses_Prescripcion_Valor", _entidad.MesesPrescripcionValor),
                new SqlParameter("@piMeses_Prescripcion_Vehiculo", _entidad.MesesPrescripcionVehiculo),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Aeronave", _entidad.MesesVencimientoAvaluoAeronave),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Alhaja", _entidad.MesesVencimientoAvaluoAlhaja),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Animal", _entidad.MesesVencimientoAvaluoAnimal),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Buque", _entidad.MesesVencimientoAvaluoBuque),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Cultivo_Fruto", _entidad.MesesVencimientoAvaluoCultivoFruto),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Equipo_Computo", _entidad.MesesVencimientoAvaluoEquipoComputo),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Madera", _entidad.MesesVencimientoAvaluoMadera),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Maquinaria_Equipo", _entidad.MesesVencimientoAvaluoMaquinariaEquipo),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Materia_Prima", _entidad.MesesVencimientoAvaluoMateriaPrima),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Mobiliario", _entidad.MesesVencimientoAvaluoMobiliario),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Otro_Tipo_Bien", _entidad.MesesVencimientoAvaluoOtroTipoBien),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_Vehiculo", _entidad.MesesVencimientoAvaluoVehiculo),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_SUGEF_Edificacion", _entidad.MesesVencimientoAvaluoSUGEFEdificacion),
                new SqlParameter("@piMeses_Vencimiento_Avaluo_SUGEF_Terreno", _entidad.MesesVencimientoAvaluoSUGEFTerreno),               
                new SqlParameter("@piMeses_Seguimiento_Terreno", _entidad.MesesSeguimientoTerreno),
                new SqlParameter("@piMeses_Seguimiento_Edificacion", _entidad.MesesSeguimientoEdificacion),
                new SqlParameter("@piMeses_Seguimiento_Vehiculo", _entidad.MesesSeguimientoVehiculo),
                new SqlParameter("@piMeses_Seguimiento_Maquinaria_Equipo", _entidad.MesesSeguimientoMaquinariaEquipo),
                new SqlParameter("@piMeses_Seguimiento_Equipo_Computo", _entidad.MesesSeguimientoEquipoComputo),
                new SqlParameter("@piMeses_Seguimiento_Materia_Prima", _entidad.MesesSeguimientoMateriaPrima),
                new SqlParameter("@piMeses_Seguimiento_Mobiliario", _entidad.MesesSeguimientoMobiliario),
                new SqlParameter("@piMeses_Seguimiento_Maderas", _entidad.MesesSeguimientoMadera),
                new SqlParameter("@piMeses_Seguimiento_Aeronave", _entidad.MesesSeguimientoAeronave),
                new SqlParameter("@piMeses_Seguimiento_Buque", _entidad.MesesSeguimientoBuque),
                new SqlParameter("@piMeses_Seguimiento_Animal", _entidad.MesesSeguimientoAnimal),
                new SqlParameter("@piMeses_Seguimiento_Cultivo_Fruto", _entidad.MesesSeguimientoCultivoFruto),
                new SqlParameter("@piMeses_Seguimiento_Alhaja", _entidad.MesesSeguimientoAlhaja),
                new SqlParameter("@piMeses_Seguimiento_Otros_Bienes", _entidad.MesesSeguimientoOtroBien),
                new SqlParameter("@piMeses_Prescripcion_Fideicomiso", _entidad.MesesPrescripcionFideicomiso),
                new SqlParameter("@piMeses_Prescripcion_Factura_Cedida", _entidad.MesesPrescripcionFacturaCedida),
                new SqlParameter("@psInd_Metodo_Insercion", _entidad.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _entidad.CodUsuarioIngreso)

            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Parametro_Bien", _entidad.IdParametroBien.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(_conexion, _conexionBitacora, "Parametros_Bienes_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Parametros_Bienes_Consulta_Detalle", _bitacora);
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

        public List<ParametrosBienesEntidad> ParametrosBienesConsultar(String _conexion, ParametrosConsultaEntidad _entidad)
        {
            List<ParametrosBienesEntidad> retorno = new List<ParametrosBienesEntidad>();
            ParametrosBienesEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piIndice_Inicio_Fila", _entidad.IndiceInicioFila),
                new SqlParameter("@piMaximo_Filas", _entidad.MaximoFilas),
                new SqlParameter("@psValores_Filtro", _entidad.ValorFiltro),
                new SqlParameter("@psColumnas_Filtros", _entidad.ColumnaFiltro),
                new SqlParameter("@psColumna_Ordenar", _entidad.ColumnaOrdenar)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(_conexion, "Parametros_Bienes_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new ParametrosBienesEntidad();
                        elemento.IdParametroBien = int.Parse(dr[0].ToString());
                        elemento.MesesVencimientoAvaluoSUGEFTerreno = int.Parse(dr[1].ToString());
                        elemento.MesesVencimientoAvaluoSUGEFEdificacion = int.Parse(dr[2].ToString());
                        elemento.MesesVencimientoAvaluoVehiculo = int.Parse(dr[3].ToString());
                        elemento.MesesPrescripcionTerreno = int.Parse(dr[4].ToString());
                        elemento.MesesPrescripcionEdificacion = int.Parse(dr[5].ToString());
                        elemento.MesesPrescripcionVehiculo = int.Parse(dr[6].ToString());
                        elemento.MesesPrescripcionFianza = int.Parse(dr[7].ToString());
                        elemento.MesesPrescripcionValor = int.Parse(dr[8].ToString());

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

        public ParametrosBienesEntidad ParametrosBienesConsultarDetalle(String _conexion, String _conexionBitacora, ParametrosBienesEntidad _entidad, BitacorasEntidad _bitacora)
        {
            ParametrosBienesEntidad retorno = new ParametrosBienesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Parametro_Bien", _entidad.IdParametroBien)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Parametro_Bien", _entidad.IdParametroBien.ToString()));

            #endregion

            try
            {

                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(_conexion, _conexionBitacora, "Parametros_Bienes_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Parametros_Bienes_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdParametroBien = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.MesesPrescripcionAeronave = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    retorno.MesesPrescripcionAlhaja = int.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    retorno.MesesPrescripcionAnimal = int.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    retorno.MesesPrescripcionBien = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    retorno.MesesPrescripcionBonoPrenda = int.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    retorno.MesesPrescripcionBuque = int.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
                    retorno.MesesPrescripcionCultivoFruto = int.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());
                    retorno.MesesPrescripcionEdificacion = int.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    retorno.MesesPrescripcionEquipoComputo = int.Parse(rowsAffected.Tables[0].Rows[0][9].ToString());
                    retorno.MesesPrescripcionFianza = int.Parse(rowsAffected.Tables[0].Rows[0][10].ToString());
                    retorno.MesesPrescripcionMadera = int.Parse(rowsAffected.Tables[0].Rows[0][11].ToString());
                    retorno.MesesPrescripcionMaquinariaEquipo = int.Parse(rowsAffected.Tables[0].Rows[0][12].ToString());
                    retorno.MesesPrescripcionMateriaPrima = int.Parse(rowsAffected.Tables[0].Rows[0][13].ToString());
                    retorno.MesesPrescripcionMobiliario = int.Parse(rowsAffected.Tables[0].Rows[0][14].ToString());
                    retorno.MesesPrescripcionOtroTipoBien = int.Parse(rowsAffected.Tables[0].Rows[0][15].ToString());
                    retorno.MesesPrescripcionTerreno = int.Parse(rowsAffected.Tables[0].Rows[0][16].ToString());
                    retorno.MesesPrescripcionValor = int.Parse(rowsAffected.Tables[0].Rows[0][17].ToString());
                    retorno.MesesPrescripcionVehiculo = int.Parse(rowsAffected.Tables[0].Rows[0][18].ToString());
                    retorno.MesesVencimientoAvaluoAeronave = int.Parse(rowsAffected.Tables[0].Rows[0][19].ToString());
                    retorno.MesesVencimientoAvaluoAlhaja = int.Parse(rowsAffected.Tables[0].Rows[0][20].ToString());
                    retorno.MesesVencimientoAvaluoAnimal = int.Parse(rowsAffected.Tables[0].Rows[0][21].ToString());
                    retorno.MesesVencimientoAvaluoBuque = int.Parse(rowsAffected.Tables[0].Rows[0][22].ToString());
                    retorno.MesesVencimientoAvaluoCultivoFruto = int.Parse(rowsAffected.Tables[0].Rows[0][23].ToString());
                    retorno.MesesVencimientoAvaluoEquipoComputo = int.Parse(rowsAffected.Tables[0].Rows[0][24].ToString());
                    retorno.MesesVencimientoAvaluoMadera = int.Parse(rowsAffected.Tables[0].Rows[0][25].ToString());
                    retorno.MesesVencimientoAvaluoMaquinariaEquipo = int.Parse(rowsAffected.Tables[0].Rows[0][26].ToString());
                    retorno.MesesVencimientoAvaluoMateriaPrima = int.Parse(rowsAffected.Tables[0].Rows[0][27].ToString());
                    retorno.MesesVencimientoAvaluoMobiliario = int.Parse(rowsAffected.Tables[0].Rows[0][28].ToString());
                    retorno.MesesVencimientoAvaluoOtroTipoBien = int.Parse(rowsAffected.Tables[0].Rows[0][29].ToString());
                    retorno.MesesVencimientoAvaluoVehiculo = int.Parse(rowsAffected.Tables[0].Rows[0][30].ToString());
                    retorno.MesesVencimientoAvaluoSUGEFEdificacion = int.Parse(rowsAffected.Tables[0].Rows[0][31].ToString());
                    retorno.MesesVencimientoAvaluoSUGEFTerreno = int.Parse(rowsAffected.Tables[0].Rows[0][32].ToString());
                    retorno.MesesSeguimientoTerreno = int.Parse(rowsAffected.Tables[0].Rows[0][33].ToString());
                    retorno.MesesSeguimientoEdificacion = int.Parse(rowsAffected.Tables[0].Rows[0][34].ToString());
                    retorno.MesesSeguimientoVehiculo = int.Parse(rowsAffected.Tables[0].Rows[0][35].ToString());
                    retorno.MesesSeguimientoMaquinariaEquipo = int.Parse(rowsAffected.Tables[0].Rows[0][36].ToString()) ;
                    retorno.MesesSeguimientoEquipoComputo = int.Parse(rowsAffected.Tables[0].Rows[0][37].ToString());
                    retorno.MesesSeguimientoMateriaPrima = int.Parse(rowsAffected.Tables[0].Rows[0][38].ToString());
                    retorno.MesesSeguimientoMobiliario = int.Parse(rowsAffected.Tables[0].Rows[0][39].ToString());
                    retorno.MesesSeguimientoMadera = int.Parse(rowsAffected.Tables[0].Rows[0][40].ToString());
                    retorno.MesesSeguimientoAeronave = int.Parse(rowsAffected.Tables[0].Rows[0][41].ToString());
                    retorno.MesesSeguimientoBuque = int.Parse(rowsAffected.Tables[0].Rows[0][42].ToString());
                    retorno.MesesSeguimientoAnimal = int.Parse(rowsAffected.Tables[0].Rows[0][43].ToString());
                    retorno.MesesSeguimientoCultivoFruto = int.Parse(rowsAffected.Tables[0].Rows[0][44].ToString());
                    retorno.MesesSeguimientoAlhaja = int.Parse(rowsAffected.Tables[0].Rows[0][45].ToString());
                    retorno.MesesSeguimientoOtroBien = int.Parse(rowsAffected.Tables[0].Rows[0][46].ToString());
                    retorno.MesesPrescripcionFideicomiso = int.Parse(rowsAffected.Tables[0].Rows[0][47].ToString());
                    retorno.MesesPrescripcionFacturaCedida = int.Parse(rowsAffected.Tables[0].Rows[0][48].ToString());

                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][49].ToString();
                    if (rowsAffected.Tables[0].Rows[0][50].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][50].ToString());
                    else
                        retorno.FechaIngreso = null;
                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][51].ToString();
                    if (rowsAffected.Tables[0].Rows[0][52].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][52].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;
                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][53].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][54].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][55].ToString();
                }

                return retorno;

                #endregion

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Int32 ParametrosBienesTotalFilas(String _conexion, ParametrosTotalFilasEntidad _entidad)
        {
            int value;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@psValor_Filtro", _entidad.ValorFiltro),
                        new SqlParameter("@psColumna_Filtro", _entidad.ColumnaFiltro)
                    };

            #endregion

            try
            {

                #region TOTAL FILAS

                value = transaccionDA.TransaccionRows(_conexion, "Parametros_Bienes_Total_Filas", paramTransaccion);

                return value;

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
