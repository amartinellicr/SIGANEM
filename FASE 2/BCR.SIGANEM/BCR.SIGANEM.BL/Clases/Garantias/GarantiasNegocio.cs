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
    public class GarantiasNegocio : IgarantiasNegocio
    {

        #region PROPIEDADES

        #region INSTANCIA

        /// <summary>
        /// Instancia: Creacion de instancia de la interfaz
        /// </summary>
        private IgarantiasNegocio _instancia;
        public IgarantiasNegocio Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    return new GarantiasNegocio();
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

        public GarantiasNegocio()
        {

        }

        #endregion

        #region METODOS PUBLICOS

        #region AVALES

        public List<GarantiasAvalesEntidad>GarantiasAvalesConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<GarantiasAvalesEntidad> retorno = new List<GarantiasAvalesEntidad>();
            GarantiasAvalesEntidad elemento;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Avales_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasAvalesEntidad();
                        elemento.IdGarantiaAval = int.Parse(dr[0].ToString());
                        elemento.DesTipoAval = dr[5].ToString();
                        elemento.NumeroAval = dr[1].ToString();
                        elemento.MontoAvalado = Decimal.Parse(dr[2].ToString());
                        elemento.DesFechaEmision = dr[13].ToString();
                        elemento.IdDeudor = dr[4].ToString();

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

        public int GarantiasAvalesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

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

                value = transaccionDA.TransaccionRows(conexion, "Garantias_Avales_Total_Filas", paramTransaccion);
                return value;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad GarantiasAvalesInsertar(String conexion, String conexionBitacora, GarantiasAvalesEntidad _avales, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {              
                new SqlParameter("@piId_Tipo_Aval", _avales.IdTipoAval),
                new SqlParameter("@psNumero_Aval", _avales.NumeroAval),
                new SqlParameter("pdMonto_Avalado", _avales.MontoAvalado),
                new SqlParameter("@psCod_Garantia_BCR", _avales.CodGarantiaBCR),
                new SqlParameter("@pdtFecha_Emision", _avales.FechaEmision),
                new SqlParameter("@pdtFecha_Vencimiento", _avales.FechaVencimiento),
                new SqlParameter("@piId_Tipo_Persona_Deudor", _avales.IdTipoPersonaDeudor),
                new SqlParameter("@psId_Deudor", _avales.IdDeudor),
                new SqlParameter("@piId_Tipo_Asignacion_Calificacion", _avales.IdTipoAsignacionCalificacion),
                new SqlParameter("@piId_Plazo_Calificacion", _avales.IdPlazoCalificacion),
                new SqlParameter("@piId_Empresa_Calificadora", _avales.IdEmpresaCalificadora),
                new SqlParameter("@piId_Categoria_Riesgo_Empresa_Calificadora", _avales.IdCategoriaRiesgoEmpresaCalificadora),
                new SqlParameter("@piId_Calificacion_Empresa_Calificadora", _avales.IdCalificacionEmpresaCalificadora),
                new SqlParameter("@psCod_Usuario", _avales.CodUsuarioIngreso),
                new SqlParameter("@psInd_Metodo_Insercion", _avales.IndMetodoInsercion),
                
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Avales_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
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

        public GarantiasAvalesEntidad GarantiasAvalesConsultarDetalle(String conexion, String conexionBitacora, GarantiasAvalesEntidad _avales, BitacorasEntidad _bitacora)
        {
            GarantiasAvalesEntidad retorno = new GarantiasAvalesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Aval", _avales.IdGarantiaAval)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Aval", _avales.IdGarantiaAval.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Avales_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Avales_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdGarantiaAval = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.IdTipoAval = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    
                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        retorno.NumeroAval = rowsAffected.Tables[0].Rows[0][2].ToString();
                    else
                        retorno.NumeroAval = null;

                   if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        retorno.MontoAvalado = decimal.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    else
                        retorno.MontoAvalado = null;
                    
                     if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                        retorno.CodGarantiaBCR = rowsAffected.Tables[0].Rows[0][4].ToString();
                    else
                        retorno.CodGarantiaBCR = null;

                    if (rowsAffected.Tables[0].Rows[0][5].ToString().Length > 0)
                        retorno.FechaEmision = DateTime.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    else
                        retorno.FechaEmision = null;

                    if (rowsAffected.Tables[0].Rows[0][6].ToString().Length > 0)
                        retorno.FechaVencimiento = DateTime.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
                    else
                        retorno.FechaVencimiento = null;

                    retorno.IdTipoPersonaDeudor = int.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());

                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        retorno.IdDeudor = rowsAffected.Tables[0].Rows[0][8].ToString();
                    else
                        retorno.IdDeudor = null;

                    retorno.IdTipoAsignacionCalificacion = int.Parse(rowsAffected.Tables[0].Rows[0][9].ToString());

                    if (rowsAffected.Tables[0].Rows[0][10].ToString().Length > 0)
                        retorno.IdPlazoCalificacion = int.Parse(rowsAffected.Tables[0].Rows[0][10].ToString());
                    else
                        retorno.IdPlazoCalificacion = null;

                    if (rowsAffected.Tables[0].Rows[0][11].ToString().Length > 0)
                    retorno.IdEmpresaCalificadora = int.Parse(rowsAffected.Tables[0].Rows[0][11].ToString());
                    else
                        retorno.IdEmpresaCalificadora = null;

                    if (rowsAffected.Tables[0].Rows[0][12].ToString().Length > 0)
                    retorno.IdCategoriaRiesgoEmpresaCalificadora = int.Parse(rowsAffected.Tables[0].Rows[0][12].ToString());
                    else
                        retorno.IdCategoriaRiesgoEmpresaCalificadora = null;

                    if (rowsAffected.Tables[0].Rows[0][13].ToString().Length > 0)
                    retorno.IdCalificacionEmpresaCalificadora = int.Parse(rowsAffected.Tables[0].Rows[0][13].ToString());
                    else
                        retorno.IdCalificacionEmpresaCalificadora = null;

                    //REQUERIMIENTO: 1-24381561
                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][14].ToString();

                    if (rowsAffected.Tables[0].Rows[0][15].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][15].ToString());
                    else
                        retorno.FechaIngreso = null;

                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][16].ToString();

                    if (rowsAffected.Tables[0].Rows[0][17].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][17].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;

                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][18].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][19].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][20].ToString();

                    //Ajuste Cloaiza - Req F02S03 Relación a Garantía Operaciones
                    if (rowsAffected.Tables[0].Rows[0][21].ToString().Length > 0)
                        retorno.DesTipoPersonaDeudor = rowsAffected.Tables[0].Rows[0][21].ToString();
                    else
                        retorno.DesTipoPersonaDeudor = null;
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad GarantiasAvalesModificar(String conexion, String conexionBitacora, GarantiasAvalesEntidad _avales, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {              
                new SqlParameter("@piId_Garantia_Aval", _avales.IdGarantiaAval),
                new SqlParameter("@piId_Tipo_Aval", _avales.IdTipoAval),
                new SqlParameter("@psNumero_Aval", _avales.NumeroAval),
                new SqlParameter("@pdMonto_Avalado", _avales.MontoAvalado),
                new SqlParameter("@psCod_Garantia_BCR", _avales.CodGarantiaBCR),
                new SqlParameter("@pdtFecha_Emision", _avales.FechaEmision),
                new SqlParameter("@pdtFecha_Vencimiento", _avales.FechaVencimiento),
                new SqlParameter("@piId_Tipo_Persona_Deudor", _avales.IdTipoPersonaDeudor),
                new SqlParameter("@psId_Deudor", _avales.IdDeudor),
                new SqlParameter("@piId_Tipo_Asignacion_Calificacion", _avales.IdTipoAsignacionCalificacion),
                new SqlParameter("@piId_Plazo_Calificacion", _avales.IdPlazoCalificacion),
                new SqlParameter("@piId_Empresa_Calificadora", _avales.IdEmpresaCalificadora),
                new SqlParameter("@piId_Categoria_Riesgo_Empresa_Calificadora", _avales.IdCategoriaRiesgoEmpresaCalificadora),
                new SqlParameter("@piId_Calificacion_Empresa_Calificadora", _avales.IdCalificacionEmpresaCalificadora),
                new SqlParameter("@psCod_Usuario", _avales.CodUsuarioIngreso),
                new SqlParameter("@psInd_Metodo_Insercion", _avales.IndMetodoInsercion),               
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Aval", _avales.IdGarantiaAval.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Garantias_Avales_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Garantias_Avales_Consulta_Detalle", _bitacora);
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

        public RespuestaEntidad GarantiasAvalesEliminar(String conexion, String conexionBitacora, GarantiasAvalesEntidad _avales, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Aval", _avales.IdGarantiaAval),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", _avales.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Aval", _avales.IdGarantiaAval.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Avales_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Avales_Consulta_Detalle", _bitacora);
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

        #endregion

        #region FIDEICOMISOS

        public RespuestaEntidad GarantiasFideicomisosValidar(String conexion, String conexionBitacora, GarantiasFideicomisosEntidad fideicomisos, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psCod_Fideicomiso", fideicomisos.CodFidecomiso),
                new SqlParameter("@psNombre_Fideicomiso", fideicomisos.NombreFideicomiso),
                new SqlParameter("@pdtFecha_Constitucion", fideicomisos.FechaConstitucion),
                new SqlParameter("@pdtFecha_Vencimiento", fideicomisos.FechaVencimiento),
                new SqlParameter("@piId_Tipo_Moneda_Valor_Nominal", fideicomisos.IdTipoMonedaValorNominal),
                new SqlParameter("@pdValor_Nominal", fideicomisos.ValorNominal),   
                new SqlParameter("@psInd_Metodo_Insercion", fideicomisos.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", fideicomisos.CodUsuarioIngreso)            
            };

            #endregion

            try
            {
                #region VALIDAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Fideicomisos_Valida", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
                if (!rowsAffected.Equals(null))
                {
                    elemento = new RespuestaEntidad();
                    if (!rowsAffected.Tables[0].Rows[0][0].ToString().Contains(","))
                    {
                        elemento.ValorEstado = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                        elemento.ValorEstadoCadena = rowsAffected.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        elemento.ValorEstado = 0;
                        elemento.ValorEstadoCadena = rowsAffected.Tables[0].Rows[0][0].ToString();
                    }

                    int numError;
                    if (int.TryParse(rowsAffected.Tables[0].Rows[0][1].ToString(), out numError))
                    {
                        elemento.ValorError = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    }
                    else
                    {
                        elemento.ValorError = 0;
                        elemento.ValorErrorCadena = rowsAffected.Tables[0].Rows[0][1].ToString();
                    }


                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GarantiasFideicomisosEntidad GarantiasFideicomisosConsultarDetalle(String conexion, String conexionBitacora, GarantiasFideicomisosEntidad fideicomisos, BitacorasEntidad bitacora)
        {
            GarantiasFideicomisosEntidad retorno = new GarantiasFideicomisosEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", fideicomisos.IdGarantiaFideicomiso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Fideicomiso", fideicomisos.IdGarantiaFideicomiso.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Fideicomisos_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Fideicomisos_Consulta_Detalle", bitacora);
                if (!rowsAffected.Equals(null))
                {
                    if (rowsAffected.Tables[0].Rows[0][0].ToString().Length > 0)
                        retorno.IdGarantiaFideicomiso = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    else
                        retorno.IdGarantiaFideicomiso = null;

                    if (rowsAffected.Tables[0].Rows[0][1].ToString().Length > 0)
                        retorno.CodFidecomisoBCR = rowsAffected.Tables[0].Rows[0][1].ToString();
                    else
                        retorno.CodFidecomisoBCR = null;

                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        retorno.CodFidecomiso = rowsAffected.Tables[0].Rows[0][2].ToString();
                    else
                        retorno.CodFidecomiso = null;

                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        retorno.NombreFideicomiso = rowsAffected.Tables[0].Rows[0][3].ToString();
                    else
                        retorno.NombreFideicomiso = null;

                    if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                        retorno.FechaConstitucion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    else
                        retorno.FechaConstitucion = null;

                    if (rowsAffected.Tables[0].Rows[0][5].ToString().Length > 0)
                        retorno.FechaVencimiento = DateTime.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    else
                        retorno.FechaVencimiento = null;

                    if (rowsAffected.Tables[0].Rows[0][6].ToString().Length > 0)
                        retorno.IdTipoMonedaValorNominal = int.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
                    else
                        retorno.IdTipoMonedaValorNominal = null;

                    if (rowsAffected.Tables[0].Rows[0][7].ToString().Length > 0)
                        retorno.ValorNominal = Decimal.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());
                    else
                        retorno.ValorNominal = null;

                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][8].ToString();

                    if (rowsAffected.Tables[0].Rows[0][9].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][9].ToString());
                    else
                        retorno.FechaIngreso = null;

                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][10].ToString();

                    if (rowsAffected.Tables[0].Rows[0][11].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][11].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;

                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][12].ToString();

                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][15].ToString();

                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][16].ToString();

                    if (rowsAffected.Tables[0].Rows[0][13].ToString().Length > 0)
                        retorno.IdEstadoGarantia = int.Parse(rowsAffected.Tables[0].Rows[0][13].ToString());
                    else
                        retorno.IdEstadoGarantia = null;

                    if (rowsAffected.Tables[0].Rows[0][17].ToString().Length > 0)
                        retorno.DesFechaConstitucion = rowsAffected.Tables[0].Rows[0][17].ToString();
                    else
                        retorno.DesFechaConstitucion = null;

                    if (rowsAffected.Tables[0].Rows[0][18].ToString().Length > 0)
                        retorno.DesFechaVencimiento = rowsAffected.Tables[0].Rows[0][18].ToString();
                    else
                        retorno.DesFechaVencimiento = null;
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad GarantiasFideicomisosModificar(String conexion, String conexionBitacora, GarantiasFideicomisosEntidad _entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso_Act", _entidad.IdGarantiaFideicomiso),
                new SqlParameter("@psId_Fideicomiso_BCR",_entidad.CodFidecomisoBCR),
                new SqlParameter("@psCod_Fideicomiso",_entidad.CodFidecomiso),
                new SqlParameter("@psNombre_Fideicomiso",_entidad.NombreFideicomiso),
                new SqlParameter("@pdtFecha_Constitucion",_entidad.FechaConstitucion),
                new SqlParameter("@pdtFecha_Vencimiento",_entidad.FechaVencimiento),
                new SqlParameter("@piId_Tipo_Moneda_Valor_Nominal",_entidad.IdTipoMonedaValorNominal),
                new SqlParameter("@pdValor_Nominal",_entidad.ValorNominal),
                new SqlParameter("@pbEstado_Registro", bool.Parse("false")),
                new SqlParameter("@psInd_Metodo_Insercion", _entidad.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _entidad.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Fideicomiso", _entidad.IdGarantiaFideicomiso.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Fideicomisos_Actualiza_Generales", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Fideicomisos_Consulta_Detalle", _bitacora);
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

        public RespuestaEntidad GarantiasFideicomisosInsertar(String conexion, String conexionBitacora, GarantiasFideicomisosEntidad fideicomisos, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", fideicomisos.IdGarantiaFideicomiso),            
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Fideicomisos__Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public RespuestaEntidad GarantiasFideicomisosEliminar(String conexion, String conexionBitacora, GarantiasFideicomisosEntidad fideicomisos, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso_Act", fideicomisos.IdGarantiaFideicomiso),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", fideicomisos.CodUsuarioIngreso)     
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Fideicomiso", fideicomisos.IdGarantiaFideicomiso.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Fideicomisos_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Fideicomisos_Consulta_Detalle", bitacora);
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

        public List<GarantiasFideicomisosEntidad> GarantiasFideicomisosConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<GarantiasFideicomisosEntidad> retorno = new List<GarantiasFideicomisosEntidad>();
            GarantiasFideicomisosEntidad elemento;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Fideicomisos_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasFideicomisosEntidad();
                        elemento.IdGarantiaFideicomiso = int.Parse(dr[0].ToString());
                        elemento.DesFideicomiso = dr[1].ToString();
                        elemento.CodFidecomisoBCR = dr[2].ToString();
                        elemento.ValorNominal = Decimal.Parse(dr[3].ToString());
                        elemento.DesFechaVencimiento = dr[5].ToString();
                        elemento.CodFideicomiso = dr[13].ToString();

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

        public int GarantiasFideicomisosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

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

                value = transaccionDA.TransaccionRows(conexion, "Fideicomisos_Total_Filas", paramTransaccion);
                return value;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GarantiasFideicomisosEntidad> GarantiasFideicomisosConsultarGridInterno(String conexion, GarantiasFideicomisosEntidad entidad)
        {
            List<GarantiasFideicomisosEntidad> retorno = new List<GarantiasFideicomisosEntidad>();
            GarantiasFideicomisosEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", entidad.IdGarantiaFideicomiso)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Fideicomisos__Consulta_Grid_Interno", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasFideicomisosEntidad();
                        elemento.IdGarantiaFideicomiso = int.Parse(dr[0].ToString());

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

        #region ADJUNTOS

        public RespuestaEntidad GarantiasFideicomisosArchivosInsertar(String conexion, String conexionBitacora, GarantiasFideicomisosAdjuntosEntidad adjuntos, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", adjuntos.IdGarantiaFideicomiso),
	            new SqlParameter("@piTipo_Documento", adjuntos.IdTipoFideicomisoAdjunto),
	            new SqlParameter("@psNombre_Documento", adjuntos.NombreAdjunto),
	            new SqlParameter("@psInd_Metodo_Insercion", adjuntos.IndMetodoInsercion),
	            new SqlParameter("@psCod_Usuario_Ingreso", adjuntos.CodUsuarioIngreso),
	            new SqlParameter("@psCod_Usuario_Ultima_Modificacion", null),
	            new SqlParameter("@psInd_Accion_Registro", null),
                //new SqlParameter("@piId_Archivos_Fideicomiso", 1),              
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Archivos_Fideicomisos_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public RespuestaEntidad GarantiasFideicomisosArchivosModificar(String conexion, String conexionBitacora, GarantiasFideicomisosAdjuntosEntidad adjuntos, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", adjuntos.IdGarantiaFideicomiso),
	            new SqlParameter("@piTipo_Documento", adjuntos.IdTipoFideicomisoAdjunto),
	            new SqlParameter("@psNombre_Documento", adjuntos.NombreAdjunto),
	            new SqlParameter("@psInd_Metodo_Insercion", adjuntos.IndMetodoInsercion),
	            new SqlParameter("@psCod_Usuario_Ingreso", adjuntos.CodUsuarioIngreso),
	            new SqlParameter("@psCod_Usuario_Ultima_Modificacion", adjuntos.CodUsuarioUltimaModificacion),
	            new SqlParameter("@piId_Archivos_Fideicomiso", adjuntos.IdGarantiaFideicomisoAdjunto)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Archivos_Fideicomiso", adjuntos.IdGarantiaFideicomisoAdjunto.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Archivos_Fideicomisos_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Archivos_Fideicomisos_Consulta_Detalle", bitacora);
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

        public RespuestaEntidad GarantiasFideicomisosArchivosEliminar(String conexion, String conexionBitacora, GarantiasFideicomisosAdjuntosEntidad adjuntos, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Archivos_Fideicomiso", adjuntos.IdGarantiaFideicomisoAdjunto),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", adjuntos.CodUsuarioIngreso)     
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Archivos_Fideicomiso", adjuntos.IdGarantiaFideicomisoAdjunto.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Archivos_Fideicomisos_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Archivos_Fideicomisos_Consulta_Detalle", bitacora);
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

        public List<GarantiasFideicomisosAdjuntosEntidad> GarantiasFideicomisosArchivosConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<GarantiasFideicomisosAdjuntosEntidad> retorno = new List<GarantiasFideicomisosAdjuntosEntidad>();
            GarantiasFideicomisosAdjuntosEntidad elemento;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Archivos_Fideicomisos_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasFideicomisosAdjuntosEntidad();
                        elemento.IdGarantiaFideicomisoAdjunto = int.Parse(dr[0].ToString());
                        elemento.IdGarantiaFideicomiso = int.Parse(dr[1].ToString());
                        elemento.IdTipoFideicomisoAdjunto = int.Parse(dr[2].ToString());
                        elemento.NombreAdjunto = dr[3].ToString();
                        elemento.IndMetodoInsercion = dr[4].ToString();
                        elemento.FechaIngreso = DateTime.Parse(dr[5].ToString());
                        elemento.CodUsuarioIngreso = dr[6].ToString();
                        elemento.FechaUltimaModificacion = DateTime.Parse(dr[7].ToString());
                        elemento.CodUsuarioUltimaModificacion = dr[8].ToString();
                        elemento.DesUsuarioIngreso = dr[10].ToString();
                        elemento.DesUsuarioUltimaModificacion = dr[11].ToString();

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

        public GarantiasFideicomisosAdjuntosEntidad GarantiasFideicomisosArchivosConsultarDetalle(String conexion, String conexionBitacora, GarantiasFideicomisosAdjuntosEntidad adjuntos, BitacorasEntidad bitacora)
        {
            GarantiasFideicomisosAdjuntosEntidad retorno = new GarantiasFideicomisosAdjuntosEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Archivos_Fideicomiso", adjuntos.IdGarantiaFideicomisoAdjunto),
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Archivos_Fideicomiso", adjuntos.IdGarantiaFideicomisoAdjunto.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Archivos_Fideicomisos_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Archivos_Fideicomisos_Consulta_Detalle", bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdGarantiaFideicomisoAdjunto = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.IdGarantiaFideicomiso = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());

                    retorno.IdTipoFideicomisoAdjunto = int.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    retorno.NombreAdjunto = rowsAffected.Tables[0].Rows[0][4].ToString();

                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][5].ToString();

                    if (rowsAffected.Tables[0].Rows[0][6].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
                    else
                        retorno.FechaIngreso = null;

                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][7].ToString();

                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;

                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][9].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][11].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][12].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GarantiasFideicomisosArchivosTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

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

                value = transaccionDA.TransaccionRows(conexion, "Archivos_Fideicomisos_Total_Filas", paramTransaccion);
                return value;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GarantiasFideicomisosAdjuntosEntidad> GarantiasFideicomisosArchivosConsultarGridInterno(String conexion, GarantiasFideicomisosAdjuntosEntidad entidad)
        {
            List<GarantiasFideicomisosAdjuntosEntidad> retorno = new List<GarantiasFideicomisosAdjuntosEntidad>();
            GarantiasFideicomisosAdjuntosEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", entidad.IdGarantiaFideicomiso)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Archivos_Fideicomisos_Consulta_Grid_Interno", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasFideicomisosAdjuntosEntidad();

                        elemento.IdGarantiaFideicomisoAdjunto = int.Parse(dr[0].ToString());
                        elemento.IdGarantiaFideicomiso = int.Parse(dr[1].ToString());

                        elemento.IdTipoFideicomisoAdjunto = int.Parse(dr[2].ToString());
                        elemento.DesTipoArchivoFideicomiso = dr[3].ToString();
                        elemento.NombreAdjunto = dr[4].ToString();

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

        #region FIDEICOMETIDAS

        public RespuestaEntidad GarantiasFideicomisosFideicometidasInsertar(String conexion, String conexionBitacora, GarantiasFideicomisosFideicometidasEntidad fideicometida, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", fideicometida.IdGarantiaFideicomiso),   
                new SqlParameter("@piId_Tipo_Garantia", fideicometida.IdTipoGarantia), 
                new SqlParameter("@piId_Garantia_Real", fideicometida.IdGarantiaReal), 
                new SqlParameter("@piId_Garantia_Valor", fideicometida.IdGarantiaValor), 
                new SqlParameter("@psId_Dueno", fideicometida.IdDueno), 
                new SqlParameter("@psNombre_Dueno", fideicometida.NombreDueno), 
                new SqlParameter("@piId_Tipo_Moneda_Valor_Nominal", fideicometida.IdTipoMonendaValorNominal), 
                new SqlParameter("@pdValor_Nominal", fideicometida.ValorNominal), 
                new SqlParameter("@pdMonto_Mitigador", fideicometida.MontoMitigador), 
                new SqlParameter("@pdPorcentaje_Aceptacion_No_Terreno_SUGEF", fideicometida.PorcentajeAceptacionNoTerrenoSUGEF), 
                new SqlParameter("@pdPorcentaje_Aceptacion_Terreno_SUGEF", fideicometida.PorcentajeAceptacionTerrenoSUGEF), 
                new SqlParameter("@pdPorcentaje_Aceptacion_SUGEF", fideicometida.PorcentajeAceptacionSUGEF), 
                new SqlParameter("@pdPorcentaje_Aceptacion_BCR", fideicometida.PorcentajeAceptacionBCR), 
                new SqlParameter("@piId_Tipo_Mitigador_Riesgo", fideicometida.IdTipoMitigadorRiego), 
                new SqlParameter("@piId_Tipo_Documento_Legal", fideicometida.IdTipoDocumentoLegal), 
                new SqlParameter("@piId_Tipo_Indicador_Inscripcion", fideicometida.IdTipoIndicadorInscripcion), 
                new SqlParameter("@pdtFecha_Presentacion", fideicometida.FechaPresentacion), 
                new SqlParameter("@piId_Formato_Identificacion_Vehiculo", fideicometida.IdFormatoIdentificacionVehiculo), 
                new SqlParameter("@pbInd_Deudor_Habita", fideicometida.IndDeudorHabita), 
                new SqlParameter("@pbEstado_Registro", fideicometida.IndEstadoRegistro), 
                new SqlParameter("@psInd_Metodo_Insercion", fideicometida.IndMetodoInsercion), 
                new SqlParameter("@pdtFecha_Ingreso", null), 
                //new SqlParameter("@pdtFecha_Ingreso", fideicometida.FechaIngreso), 
                new SqlParameter("@psCod_Usuario_Ingreso", fideicometida.CodUsuarioIngreso), 
                new SqlParameter("@pdtFecha_Ultima_Modificacion", fideicometida.FechaUltimaModificacion), 
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", fideicometida.CodUsuarioUltimaModificacion), 
                new SqlParameter("@psInd_Accion_Registro", fideicometida.IndAccionRegistro)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Fideicometidas_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public RespuestaEntidad GarantiasFideicomisosFideicometidasInsertarTotal(String conexion, String conexionBitacora, GarantiasFideicomisosFideicometidasEntidad fideicometida, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", fideicometida.IdGarantiaFideicomiso),   
                new SqlParameter("@piId_Tipo_Garantia", fideicometida.IdTipoGarantia), 
                new SqlParameter("@piId_Garantia_Real", fideicometida.IdGarantiaReal), 
                new SqlParameter("@piId_Garantia_Valor", fideicometida.IdGarantiaValor), 
                new SqlParameter("@psId_Dueno", fideicometida.IdDueno), 
                new SqlParameter("@psNombre_Dueno", fideicometida.NombreDueno), 
                new SqlParameter("@piId_Tipo_Moneda_Valor_Nominal", fideicometida.IdTipoMonendaValorNominal), 
                new SqlParameter("@pdValor_Nominal", fideicometida.ValorNominal), 
                new SqlParameter("@pdMonto_Mitigador", fideicometida.MontoMitigador), 
                new SqlParameter("@pdPorcentaje_Aceptacion_No_Terreno_SUGEF", fideicometida.PorcentajeAceptacionNoTerrenoSUGEF), 
                new SqlParameter("@pdPorcentaje_Aceptacion_Terreno_SUGEF", fideicometida.PorcentajeAceptacionTerrenoSUGEF), 
                new SqlParameter("@pdPorcentaje_Aceptacion_SUGEF", fideicometida.PorcentajeAceptacionSUGEF), 
                new SqlParameter("@pdPorcentaje_Aceptacion_BCR", fideicometida.PorcentajeAceptacionBCR), 
                new SqlParameter("@piId_Tipo_Mitigador_Riesgo", fideicometida.IdTipoMitigadorRiego), 
                new SqlParameter("@piId_Tipo_Documento_Legal", fideicometida.IdTipoDocumentoLegal), 
                new SqlParameter("@piId_Tipo_Indicador_Inscripcion", fideicometida.IdTipoIndicadorInscripcion), 
                new SqlParameter("@pdtFecha_Presentacion", fideicometida.FechaPresentacion), 
                new SqlParameter("@piId_Formato_Identificacion_Vehiculo", fideicometida.IdFormatoIdentificacionVehiculo), 
                new SqlParameter("@pbInd_Deudor_Habita", fideicometida.IndDeudorHabita), 
                new SqlParameter("@pbEstado_Registro", fideicometida.IndEstadoRegistro), 
                new SqlParameter("@psInd_Metodo_Insercion", fideicometida.IndMetodoInsercion), 
                new SqlParameter("@pdtFecha_Ingreso", fideicometida.FechaIngreso), 
                new SqlParameter("@psCod_Usuario_Ingreso", fideicometida.CodUsuarioIngreso), 
                new SqlParameter("@pdtFecha_Ultima_Modificacion", fideicometida.FechaUltimaModificacion), 
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", fideicometida.CodUsuarioUltimaModificacion), 
                new SqlParameter("@psInd_Accion_Registro", fideicometida.IndAccionRegistro),
                new SqlParameter("@piId_Garantia_Fideicomiso", fideicometida.IndAccionRegistro)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Fideicometidas_Inserta_Total", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public RespuestaEntidad GarantiasFideicomisosFideicometidasModificar(String conexion, String conexionBitacora, GarantiasFideicomisosFideicometidasEntidad fideicometida, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Fideicomiso_Act", fideicometida.IdGarantiaFideicomisoFideicometida),   
                new SqlParameter("@psId_Dueno", fideicometida.IdDueno), 
                new SqlParameter("@psNombre_Dueno", fideicometida.NombreDueno), 
                new SqlParameter("@piId_Tipo_Moneda_Valor_Nominal", fideicometida.IdTipoMonendaValorNominal),
                new SqlParameter("@pdValor_Nominal", fideicometida.ValorNominal), 
                new SqlParameter("@pdMonto_Mitigador", fideicometida.MontoMitigador), 
                new SqlParameter("@pdPorcentaje_Aceptacion_No_Terreno_SUGEF", fideicometida.PorcentajeAceptacionNoTerrenoSUGEF), 
                new SqlParameter("@pdPorcentaje_Aceptacion_Terreno_SUGEF", fideicometida.PorcentajeAceptacionTerrenoSUGEF), 
                new SqlParameter("@pdPorcentaje_Aceptacion_SUGEF", fideicometida.PorcentajeAceptacionSUGEF), 
                new SqlParameter("@pdPorcentaje_Aceptacion_BCR", fideicometida.PorcentajeAceptacionBCR), 
                new SqlParameter("@piId_Tipo_Mitigador_Riesgo", fideicometida.IdTipoMitigadorRiego), 
                new SqlParameter("@piId_Tipo_Documento_Legal", fideicometida.IdTipoDocumentoLegal), 
                new SqlParameter("@piId_Tipo_Indicador_Inscripcion", fideicometida.IdTipoIndicadorInscripcion), 
                new SqlParameter("@pdtFecha_Presentacion", fideicometida.FechaPresentacion), 
                new SqlParameter("@piId_Formato_Identificacion_Vehiculo", fideicometida.IdFormatoIdentificacionVehiculo), 
                new SqlParameter("@pbInd_Deudor_Habita", fideicometida.IndDeudorHabita), 
                new SqlParameter("@pbEstado_Registro", 1), 
                new SqlParameter("@psInd_Metodo_Insercion", fideicometida.IndMetodoInsercion), 
                new SqlParameter("@pdtFecha_Ingreso", fideicometida.FechaIngreso), 
                new SqlParameter("@psCod_Usuario", fideicometida.CodUsuarioIngreso), 
                new SqlParameter("@pdtFecha_Ultima_Modificacion", fideicometida.FechaUltimaModificacion), 
                new SqlParameter("@psInd_Accion_Registro", fideicometida.IndAccionRegistro)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Fideicomiso", fideicometida.IdGarantiaFideicomisoFideicometida.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Garantias_Fideicometidas_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Garantias_Fideicometidas_Consulta_Detalle", bitacora);
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

        public RespuestaEntidad GarantiasFideicomisosFideicometidasEliminar(String conexion, String conexionBitacora, GarantiasFideicomisosFideicometidasEntidad fideicometida, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Fideicomiso_Act", fideicometida.IdGarantiaFideicomisoFideicometida),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", fideicometida.CodUsuarioIngreso)     
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Fideicomiso", fideicometida.IdGarantiaFideicomiso.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Fideicometidas_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Fideicometidas_Consulta_Detalle", bitacora);
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

        public GarantiasFideicomisosFideicometidasEntidad GarantiasFideicomisosFideicometidasConsultarDetalle(String conexion, String conexionBitacora, GarantiasFideicomisosFideicometidasEntidad fideicometida, BitacorasEntidad bitacora)
        {
            GarantiasFideicomisosFideicometidasEntidad retorno = new GarantiasFideicomisosFideicometidasEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Fideicomiso", fideicometida.IdGarantiaFideicomisoFideicometida)   
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Fideicomiso", fideicometida.IdGarantiaFideicomisoFideicometida.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Fideicometidas_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Fideicometidas_Consulta_Detalle", bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdGarantiaFideicomisoFideicometida = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());

                    if (rowsAffected.Tables[0].Rows[0][1].ToString().Length > 0)
                        retorno.IdGarantiaFideicomiso = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    else
                        retorno.IdGarantiaFideicomiso = null;

                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        retorno.IdTipoGarantia = int.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    else
                        retorno.IdTipoGarantia = null;

                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        retorno.IdGarantiaReal = int.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    else
                        retorno.IdGarantiaReal = null;

                    if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                        retorno.IdGarantiaValor = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    else
                        retorno.IdGarantiaValor = null;

                    retorno.IdDueno = rowsAffected.Tables[0].Rows[0][5].ToString();
                    retorno.NombreDueno = rowsAffected.Tables[0].Rows[0][6].ToString();

                    if (rowsAffected.Tables[0].Rows[0][7].ToString().Length > 0)
                        retorno.IdTipoMonendaValorNominal = int.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());
                    else
                        retorno.IdTipoMonendaValorNominal = null;

                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        retorno.ValorNominal = decimal.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    else
                        retorno.ValorNominal = null;

                    if (rowsAffected.Tables[0].Rows[0][9].ToString().Length > 0)
                        retorno.MontoMitigador = decimal.Parse(rowsAffected.Tables[0].Rows[0][9].ToString());
                    else
                        retorno.MontoMitigador = null;

                    if (rowsAffected.Tables[0].Rows[0][10].ToString().Length > 0)
                        retorno.PorcentajeAceptacionNoTerrenoSUGEF = decimal.Parse(rowsAffected.Tables[0].Rows[0][10].ToString());
                    else
                        retorno.PorcentajeAceptacionNoTerrenoSUGEF = null;

                    if (rowsAffected.Tables[0].Rows[0][11].ToString().Length > 0)
                        retorno.PorcentajeAceptacionTerrenoSUGEF = decimal.Parse(rowsAffected.Tables[0].Rows[0][11].ToString());
                    else
                        retorno.PorcentajeAceptacionTerrenoSUGEF = null;

                    if (rowsAffected.Tables[0].Rows[0][12].ToString().Length > 0)
                        retorno.PorcentajeAceptacionSUGEF = decimal.Parse(rowsAffected.Tables[0].Rows[0][12].ToString());
                    else
                        retorno.PorcentajeAceptacionSUGEF = null;

                    if (rowsAffected.Tables[0].Rows[0][13].ToString().Length > 0)
                        retorno.PorcentajeAceptacionBCR = decimal.Parse(rowsAffected.Tables[0].Rows[0][13].ToString());
                    else
                        retorno.PorcentajeAceptacionBCR = null;

                    if (rowsAffected.Tables[0].Rows[0][14].ToString().Length > 0)
                        retorno.IdTipoMitigadorRiego = int.Parse(rowsAffected.Tables[0].Rows[0][14].ToString());
                    else
                        retorno.IdTipoMitigadorRiego = null;

                    if (rowsAffected.Tables[0].Rows[0][15].ToString().Length > 0)
                        retorno.IdTipoDocumentoLegal = int.Parse(rowsAffected.Tables[0].Rows[0][15].ToString());
                    else
                        retorno.IdTipoDocumentoLegal = null;

                    if (rowsAffected.Tables[0].Rows[0][16].ToString().Length > 0)
                        retorno.IdTipoIndicadorInscripcion = int.Parse(rowsAffected.Tables[0].Rows[0][16].ToString());
                    else
                        retorno.IdTipoIndicadorInscripcion = null;

                    if (rowsAffected.Tables[0].Rows[0][17].ToString().Length > 0)
                        retorno.FechaPresentacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][17].ToString());
                    else
                        retorno.FechaPresentacion = null;

                    if (rowsAffected.Tables[0].Rows[0][18].ToString().Length > 0)
                        retorno.IdFormatoIdentificacionVehiculo = int.Parse(rowsAffected.Tables[0].Rows[0][18].ToString());
                    else
                        retorno.IdFormatoIdentificacionVehiculo = null;

                    if (rowsAffected.Tables[0].Rows[0][19].ToString().Length > 0)
                        retorno.IndDeudorHabita = int.Parse(rowsAffected.Tables[0].Rows[0][19].ToString());
                    else
                        retorno.IndDeudorHabita = null;

                    if (rowsAffected.Tables[0].Rows[0][20].ToString().Length > 0)
                        retorno.IndEstadoRegistro = int.Parse(rowsAffected.Tables[0].Rows[0][20].ToString());
                    else
                        retorno.IndEstadoRegistro = null;

                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][21].ToString();

                    if (rowsAffected.Tables[0].Rows[0][22].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][22].ToString());
                    else
                        retorno.FechaIngreso = null;

                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][23].ToString();

                    if (rowsAffected.Tables[0].Rows[0][24].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][24].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;

                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][25].ToString();
                    retorno.IndAccionRegistro = rowsAffected.Tables[0].Rows[0][26].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][27].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][28].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GarantiasFideicomisosFideicometidasEntidad> GarantiasFideicomisosFideicometidasConsultarGridInterno(String conexion, GarantiasFideicomisosFideicometidasEntidad fideicometida)
        {
            List<GarantiasFideicomisosFideicometidasEntidad> retorno = new List<GarantiasFideicomisosFideicometidasEntidad>();
            GarantiasFideicomisosFideicometidasEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", fideicometida.IdGarantiaFideicomiso)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Fideicometidas_Consulta_Grid_Interno", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasFideicomisosFideicometidasEntidad();

                        if (dr[0].ToString().Length > 0)
                            elemento.IdGarantiaFideicomisoFideicometida = int.Parse(dr[0].ToString());
                        else
                            elemento.IdGarantiaFideicomisoFideicometida = null;

                        if (dr[1].ToString().Length > 0)
                            elemento.DesTipoGarantia = dr[1].ToString();
                        else
                            elemento.DesTipoGarantia = null;

                        if (dr[2].ToString().Length > 0)
                            elemento.CodIdGarantia = dr[2].ToString();
                            //elemento.IdGarantia = int.Parse(dr[2].ToString());
                        else
                            elemento.CodIdGarantia = null;

                        if (dr[3].ToString().Length > 0)
                            elemento.ValorNominal = decimal.Parse(dr[3].ToString());
                        else
                            elemento.ValorNominal = null;

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

        public GarantiasRealesEntidad GarantiasFideicomisosFideicometidaGarantiasRealesBusqueda(String conexion, GarantiasRealesEntidad entidad)
        {
            GarantiasRealesEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Clase_Aeronave", entidad.IdClaseAeronave),
                new SqlParameter("@piId_Clase_Buque", entidad.IdClaseBuque),
                new SqlParameter("@piId_Clase_Tipo_Bien", entidad.IdClaseTipoBien),
                new SqlParameter("@piId_Clase_Vehiculo", entidad.IdClaseVehiculo),
                new SqlParameter("@piId_Codigo_Duplicado", entidad.IdCodigoDuplicado),
                new SqlParameter("@piId_Codigo_Horizontalidad", entidad.IdCodigoHorizontalidad),
                new SqlParameter("@piId_Provincia", entidad.IdProvincia),
                new SqlParameter("@piId_Tipo_Bien", entidad.IdTipoBien),
                new SqlParameter("@psCodigo_Bien", entidad.CodBien),
                new SqlParameter("@piFormato_Identificacion_Vehiculo", entidad.FormatoIdentificacionVehiculo)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Fideicomisos_Garantias_Reales_Busqueda", paramTransaccion);
                if (rowsAffected.Tables[0].Rows.Count != 0)
                {
                    elemento = new GarantiasRealesEntidad();
                    elemento.IdGarantiaReal = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    //ID TIPO MONEDA
                    elemento.DesTipoMoneda = rowsAffected.Tables[0].Rows[0][1].ToString();
                    //MONTO ULTIMA TASACION TERRENO
                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        elemento.MontoUltimaTasacionTerreno = decimal.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    else
                        elemento.MontoUltimaTasacionTerreno = null;
                    //MONTO ULTIMA TASACION NO TERRENO
                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        elemento.MontoUltimaTasacionNoTerreno = decimal.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    else
                        elemento.MontoUltimaTasacionNoTerreno = null;
                    //MONTO TOTAL ULTIMA TASACION
                    if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                        elemento.MontoTotalUltimaTasacion = decimal.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    else
                        elemento.MontoTotalUltimaTasacion = null;
                    //MONTO TASACION ACTUALIZADA TERRENO
                    if (rowsAffected.Tables[0].Rows[0][5].ToString().Length > 0)
                        elemento.MontoTasacionActualizadaTerreno = decimal.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    else
                        elemento.MontoTasacionActualizadaTerreno = null;
                    //MONTO TASACION ACTUALIZADA NO TERRENO
                    if (rowsAffected.Tables[0].Rows[0][6].ToString().Length > 0)
                        elemento.MontoTasacionActualizadaNoTerreno = decimal.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
                    else
                        elemento.MontoTasacionActualizadaNoTerreno = null;
                    //MONTO TOTAL ULTIMA TASACION ACTUALIZADA
                    if (rowsAffected.Tables[0].Rows[0][7].ToString().Length > 0)
                        elemento.MontoTotalTasacionActualizada = decimal.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());
                    else
                        elemento.MontoTotalTasacionActualizada = null;
                    //FECHA ULTIMA TASACION GARANTIA
                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        elemento.FechaUltimaTasacionGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][8].ToString().Trim());
                    else
                        elemento.FechaUltimaTasacionGarantia = null;
                    //FECHA ULTIMO SEGUIMIENTO GARANTIA
                    if (rowsAffected.Tables[0].Rows[0][9].ToString().Length > 0)
                        elemento.FechaUltimoSeguimientoGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][9].ToString().Trim());
                    else
                        elemento.FechaUltimoSeguimientoGarantia = null;
                    //MONTO VALOR TOTAL CEDULA
                    if (rowsAffected.Tables[0].Rows[0][10].ToString().Length > 0)
                        elemento.MontoValorTotalCedula = decimal.Parse(rowsAffected.Tables[0].Rows[0][10].ToString());
                    else
                        elemento.MontoValorTotalCedula = null;
                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GarantiasValoresEntidad GarantiasFideicomisosFideicometidasValoresBusqueda(String conexion, GarantiasValoresEntidad entidad)
        {
            GarantiasValoresEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Valor", entidad.IdTipoValor),
                new SqlParameter("@piId_Tipo_Instrumento", entidad.IdTipoInstrumento),
                new SqlParameter("@piId_Instrumento", entidad.IdInstrumento),
                new SqlParameter("@piId_Emisor", entidad.IdEmisor),
                new SqlParameter("@psISIN", entidad.ISIN),
                new SqlParameter("@psSerie", entidad.Serie),
                new SqlParameter("@psCod_Garantia_BCR", entidad.CodGarantiaBCR),
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Fideicomisos_Garantias_Valores_Busqueda", paramTransaccion);
                if (rowsAffected.Tables[0].Rows.Count != 0)
                {
                    elemento = new GarantiasValoresEntidad();
                    elemento.IdGarantiaValor = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());

                    //MONEDA VALOR MERCADO
                    elemento.MonedaValorMercado = rowsAffected.Tables[0].Rows[0][1].ToString();

                    //MONTO VALOR MERCADO
                    elemento.MontoValorMercado = decimal.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());

                    //VALOR MERCADO COLINIZADO
                    elemento.MontoValorMercadoColonizado = decimal.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());

                    //MONEDA VALOR FACIAL
                    elemento.MonedaValorFacial = rowsAffected.Tables[0].Rows[0][4].ToString();

                    //MONTO VALOR FACIAL
                    elemento.MontoValorFacial = decimal.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());

                    //VALOR FACIAL COLINIZADO
                    elemento.MontoValorFacialColonizado = decimal.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
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

        #region PRIORIDADES

        public RespuestaEntidad GarantiasFideicomisosPrioridadesInsertar(String conexion, String conexionBitacora, GarantiasFideicomisosPrioridadesEntidad prioridades, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", prioridades.IdGarantiaFideicomiso),
                new SqlParameter("@piId_Tipo_Grado", prioridades.IdTipoGradoPrioridad),
                new SqlParameter("@piId_Tipo_Moneda", prioridades.IdTipoMonedaSaldoPrioridad),
                new SqlParameter("@pdSaldo_Prioridad", prioridades.SaldoPrioridad),
                new SqlParameter("@piId_Tipo_Identificacion_RUC", prioridades.IdTipoPersonaBeneficiario),
                new SqlParameter("@psId_Beneficiario", prioridades.IdBeneficiario),
                new SqlParameter("@psNombre_Beneficiario", prioridades.NombreBenefiario),
                new SqlParameter("@psInd_Metodo_Insercion", prioridades.IndMetodoInsercion),
                new SqlParameter("@pdtFecha_Ingreso", null),
                new SqlParameter("@psCod_Usuario_Ingreso", prioridades.CodUsuarioIngreso),
                new SqlParameter("@pdtFecha_Ultima_Modificacion", null),
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", null),     
                new SqlParameter("@psInd_Accion_Registro", null),
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Grados_Prioridades_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public RespuestaEntidad GarantiasFideicomisosPrioridadesModificar(String conexion, String conexionBitacora, GarantiasFideicomisosPrioridadesEntidad prioridades, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS
            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Grado", prioridades.IdTipoGradoPrioridad),
                new SqlParameter("@piId_Grado_Prioridad_Act", prioridades.IdGarantiaFideicomisosPrioridad),
                new SqlParameter("@pdSaldo_Prioridad", prioridades.SaldoPrioridad),
                //new SqlParameter("@psNombre_Beneficiario", prioridades.NombreBenefiario),
                new SqlParameter("@psInd_Metodo_Insercion", prioridades.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", prioridades.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Grado_Prioridad", prioridades.IdGarantiaFideicomisosPrioridad.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Grados_Prioridades_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Grados_Prioridades_Consulta_Detalle", bitacora);
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

        public RespuestaEntidad GarantiasFideicomisosPrioridadesEliminar(String conexion, String conexionBitacora, GarantiasFideicomisosPrioridadesEntidad prioridades, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Grado_Prioridad", prioridades.IdGarantiaFideicomisosPrioridad),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", prioridades.CodUsuarioIngreso)                
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Grado_Prioridad", prioridades.IdGarantiaFideicomisosPrioridad.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Grados_Prioridades_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Grados_Prioridades_Consulta_Detalle", bitacora);
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

        public List<GarantiasFideicomisosPrioridadesEntidad> GarantiasFideicomisosPrioridadesConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<GarantiasFideicomisosPrioridadesEntidad> retorno = new List<GarantiasFideicomisosPrioridadesEntidad>();
            GarantiasFideicomisosPrioridadesEntidad elemento;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Grados_Prioridades_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasFideicomisosPrioridadesEntidad();
                        elemento.IdGarantiaFideicomisosPrioridad = int.Parse(dr[0].ToString());
                        elemento.IdTipoMonedaSaldoPrioridad = Convert.ToInt32(dr[1].ToString());
                        elemento.SaldoPrioridad = Convert.ToDecimal(dr[2].ToString());
                        elemento.IdTipoPersonaBeneficiario = Convert.ToInt32(dr[3].ToString());
                        elemento.IdBeneficiario = dr[5].ToString();
                        elemento.NombreBenefiario = dr[6].ToString();
                        elemento.IndMetodoInsercion = dr[7].ToString();
                        elemento.FechaIngreso = Convert.ToDateTime(dr[8].ToString());
                        elemento.CodUsuarioIngreso = dr[9].ToString();
                        elemento.FechaUltimaModificacion = Convert.ToDateTime(dr[10].ToString());
                        elemento.CodUsuarioUltimaModificacion = dr[11].ToString();
                        elemento.DesUsuarioIngreso = dr[13].ToString();
                        elemento.DesUsuarioUltimaModificacion = dr[14].ToString();

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

        public GarantiasFideicomisosPrioridadesEntidad GarantiasFideicomisosPrioridadesConsultarDetalle(String conexion, String conexionBitacora, GarantiasFideicomisosPrioridadesEntidad prioridades, BitacorasEntidad bitacora)
        {
            GarantiasFideicomisosPrioridadesEntidad retorno = new GarantiasFideicomisosPrioridadesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Grado_Prioridad", prioridades.IdGarantiaFideicomisosPrioridad)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Grado_Prioridad", prioridades.IdGarantiaFideicomisosPrioridad.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Grados_Prioridades_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Grados_Prioridades_Consulta_Detalle", bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdGarantiaFideicomisosPrioridad = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString()); //EMPIEZA ENN 0
                    //CLS Grado Prioridad
                    if (rowsAffected.Tables[0].Rows[0][15].ToString().Length > 0)
                        retorno.IdTipoGradoPrioridad = int.Parse(rowsAffected.Tables[0].Rows[0][15].ToString());
                    else
                        retorno.IdTipoGradoPrioridad = null;

                    if (rowsAffected.Tables[0].Rows[0][1].ToString().Length > 0)
                        retorno.IdTipoMonedaSaldoPrioridad = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    else
                        retorno.IdTipoMonedaSaldoPrioridad = null;

                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        retorno.SaldoPrioridad = decimal.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    else
                        retorno.SaldoPrioridad = null;

                    if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                        retorno.IdTipoPersonaBeneficiario = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    else
                        retorno.IdTipoPersonaBeneficiario = null;

                    retorno.IdBeneficiario = rowsAffected.Tables[0].Rows[0][5].ToString();
                    
                    retorno.NombreBenefiario = rowsAffected.Tables[0].Rows[0][6].ToString();
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
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][13].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][14].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GarantiasFideicomisosPrioridadesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

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

                value = transaccionDA.TransaccionRows(conexion, "Grados_Prioridades_Total_Filas", paramTransaccion);
                return value;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GarantiasFideicomisosPrioridadesEntidad> GarantiasFideicomisosPrioridadesConsultarGridInterno(String conexion, GarantiasFideicomisosPrioridadesEntidad prioridades)
        {
            List<GarantiasFideicomisosPrioridadesEntidad> retorno = new List<GarantiasFideicomisosPrioridadesEntidad>();
            GarantiasFideicomisosPrioridadesEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Fideicomiso", prioridades.IdGarantiaFideicomiso)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Grados_Prioridades_Consulta_Grid_Interno", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasFideicomisosPrioridadesEntidad();

                        if (dr[0].ToString().Length > 0)
                            elemento.IdGarantiaFideicomisosPrioridad = int.Parse(dr[0].ToString());
                        else
                            elemento.IdGarantiaFideicomisosPrioridad = null;

                        if (dr[1].ToString().Length > 0)
                            elemento.DesTipoGradoPrioridad = dr[1].ToString();
                        else
                            elemento.DesTipoGradoPrioridad = null;

                        if (dr[2].ToString().Length > 0)
                            elemento.DesTipoMonedaSaldoPrioridad = dr[2].ToString();
                        else
                            elemento.DesTipoMonedaSaldoPrioridad = null;

                        if (dr[3].ToString().Length > 0)
                            elemento.SaldoPrioridad = decimal.Parse(dr[3].ToString());
                        else
                            elemento.SaldoPrioridad = null;

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

        #endregion

        #region FIDUCIARIAS

        public RespuestaEntidad GarantiasFiduciariasInsertar(String conexion, String conexionBitacora, GarantiasFiduciariasEntidad fiduciaria, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Identificacion_RUC", fiduciaria.IdTipoIdentificacionRUC),
                new SqlParameter("@piId_Tipo_Aval_Fianza", fiduciaria.IdTipoAvalFianza),
                new SqlParameter("@piId_Tipo_Asignacion_Calificacion", fiduciaria.IdTipoAsignacionCalificacion),
                new SqlParameter("@piId_Empresa_Calificadora", fiduciaria.IdEmpresaCalificadora),
                new SqlParameter("@piId_Categoria_Riesgo_Empresa_Calificadora", fiduciaria.IdCategoriaRiesgoEmpresaCalificadora),
                new SqlParameter("@piId_Calificacion_Empresa_Calificadora", fiduciaria.IdCalificacionEmpresaCalificadora),
                new SqlParameter("@psCod_Garantia", fiduciaria.CodGarantia),
                new SqlParameter("@psIdentificacion_SICC", fiduciaria.IdentificacionSICC),
                new SqlParameter("@psNombre_RUC", fiduciaria.NombreRUC),
                new SqlParameter("@pnSalario_Neto_Fiador", fiduciaria.SalarioNetoFiador),
                new SqlParameter("@pdtFecha_Verificacion_Asalariado", fiduciaria.FechaVerificacionAsalariado),
                new SqlParameter("@psInd_Metodo_Insercion", fiduciaria.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", fiduciaria.CodUsuarioIngreso),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@pdFecha_Ingreso", null),
                new SqlParameter("@pdFecha_Ultima_Modificacion", null),
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", null),
                new SqlParameter("@psInd_Accion_Registro", null)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Fiduciarias_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public RespuestaEntidad GarantiasFiduciariasModificar(String conexion, String conexionBitacora, GarantiasFiduciariasEntidad fiduciaria, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Fiduciaria", fiduciaria.IdGarantiaFiduciaria),
                new SqlParameter("@piId_Tipo_Identificacion_RUC", fiduciaria.IdTipoIdentificacionRUC),
                new SqlParameter("@piId_Tipo_Aval_Fianza", fiduciaria.IdTipoAvalFianza),
                new SqlParameter("@piId_Tipo_Asignacion_Calificacion", fiduciaria.IdTipoAsignacionCalificacion),
                new SqlParameter("@piId_Empresa_Calificadora", fiduciaria.IdEmpresaCalificadora),
                new SqlParameter("@piId_Categoria_Riesgo_Empresa_Calificadora", fiduciaria.IdCategoriaRiesgoEmpresaCalificadora),
                new SqlParameter("@piId_Calificacion_Empresa_Calificadora", fiduciaria.IdCalificacionEmpresaCalificadora),
                new SqlParameter("@psCod_Garantia", fiduciaria.CodGarantia),
                new SqlParameter("@psIdentificacion_SICC", fiduciaria.IdentificacionSICC),
                new SqlParameter("@psNombre_RUC", fiduciaria.NombreRUC),
                new SqlParameter("@pnSalario_Neto_Fiador", fiduciaria.SalarioNetoFiador),
                new SqlParameter("@pdtFecha_Verificacion_Asalariado", fiduciaria.FechaVerificacionAsalariado),
                new SqlParameter("@psInd_Metodo_Insercion", fiduciaria.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", fiduciaria.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Fiduciaria", fiduciaria.IdGarantiaFiduciaria.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Garantias_Fiduciarias_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Garantias_Fiduciarias_Consulta_Detalle", bitacora);
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

        public RespuestaEntidad GarantiasFiduciariasEliminar(String conexion, String conexionBitacora, GarantiasFiduciariasEntidad fiduciaria, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Fiduciaria", fiduciaria.IdGarantiaFiduciaria),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", fiduciaria.CodUsuarioIngreso)                
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Fiduciaria", fiduciaria.IdGarantiaFiduciaria.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Fiduciarias_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Fiduciarias_Consulta_Detalle", bitacora);
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

        public List<GarantiasFiduciariasEntidad> GarantiasFiduciariasConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<GarantiasFiduciariasEntidad> retorno = new List<GarantiasFiduciariasEntidad>();
            GarantiasFiduciariasEntidad elemento;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Fiduciarias_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasFiduciariasEntidad();
                        elemento.IdGarantiaFiduciaria = int.Parse(dr[0].ToString());
                        elemento.DesTipoIdentificacionRUC = dr[1].ToString();
                        elemento.CodGarantia = dr[2].ToString();
                        elemento.NombreRUC = dr[3].ToString();
                        elemento.DesTipoAvalFianza = dr[4].ToString();

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

        public GarantiasFiduciariasEntidad GarantiasFiduciariasConsultarDetalle(String conexion, String conexionBitacora, GarantiasFiduciariasEntidad fiduciaria, BitacorasEntidad bitacora)
        {
            GarantiasFiduciariasEntidad retorno = new GarantiasFiduciariasEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Fiduciaria", fiduciaria.IdGarantiaFiduciaria)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Fiduciaria", fiduciaria.IdGarantiaFiduciaria.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Fiduciarias_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Fiduciarias_Consulta_Detalle", bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdTipoIdentificacionRUC = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.IdTipoAvalFianza = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    retorno.IdTipoAsignacionCalificacion = int.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());

                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        retorno.IdEmpresaCalificadora = int.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    else
                        retorno.IdEmpresaCalificadora = null;

                    if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                        retorno.IdPlazoCalificacion = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    else
                        retorno.IdPlazoCalificacion = null;

                    if (rowsAffected.Tables[0].Rows[0][5].ToString().Length > 0)
                        retorno.IdCategoriaRiesgoEmpresaCalificadora = int.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    else
                        retorno.IdCategoriaRiesgoEmpresaCalificadora = null;

                    if (rowsAffected.Tables[0].Rows[0][6].ToString().Length > 0)
                        retorno.IdCalificacionEmpresaCalificadora = int.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
                    else
                        retorno.IdCalificacionEmpresaCalificadora = null;

                    retorno.CodGarantia = rowsAffected.Tables[0].Rows[0][7].ToString();
                    retorno.IdentificacionSICC = rowsAffected.Tables[0].Rows[0][8].ToString();
                    retorno.NombreRUC = rowsAffected.Tables[0].Rows[0][9].ToString();

                    if (rowsAffected.Tables[0].Rows[0][10].ToString().Length > 0)
                        retorno.SalarioNetoFiador = decimal.Parse(rowsAffected.Tables[0].Rows[0][10].ToString());
                    else
                        retorno.SalarioNetoFiador = null;

                    if (rowsAffected.Tables[0].Rows[0][11].ToString().Length > 0)
                        retorno.FechaVerificacionAsalariado = DateTime.Parse(rowsAffected.Tables[0].Rows[0][11].ToString());
                    else
                        retorno.FechaVerificacionAsalariado = null;

                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][12].ToString();
                    if (rowsAffected.Tables[0].Rows[0][13].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][13].ToString());
                    else
                        retorno.FechaIngreso = null;
                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][14].ToString();
                    if (rowsAffected.Tables[0].Rows[0][15].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][15].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;
                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][16].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][17].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][18].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GarantiasFiduciariasTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

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

                value = transaccionDA.TransaccionRows(conexion, "Garantias_Fiduciarias_Total_Filas", paramTransaccion);
                return value;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region VALORES

        public RespuestaEntidad GarantiasValoresValidar(String conexion, String conexionBitacora, GarantiasValoresEntidad _entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Calificacion_Empresa_Calificadora", _entidad.IdCalificacionEmpresaCalificadora),
                new SqlParameter("@piId_Categoria_Riesgo_Empresa_Calificadora", _entidad.IdCategoriaRiesgoEmpresaCalificadora),
                new SqlParameter("@piId_Emisor", _entidad.IdEmisor),
                new SqlParameter("@piId_Empresa_Calificadora", _entidad.IdEmpresaCalificadora),
                new SqlParameter("@piId_Instrumento", _entidad.IdInstrumento),
                new SqlParameter("@piId_Moneda_Valor_Facial", _entidad.IdMonedaValorFacial),
                new SqlParameter("@piId_Moneda_Valor_Mercado", _entidad.IdMonedaValorMercado),
                new SqlParameter("@piId_Tipo_Asignacion_Calificacion", _entidad.IdTipoAsignacionCalificacion),
                new SqlParameter("@piId_Tipo_Persona_Emisor", _entidad.IdTipoPersonaEmisor),
                new SqlParameter("@psCod_Garantia", _entidad.CodGarantia),
                new SqlParameter("@psCod_Garantia_BCR", _entidad.CodGarantiaBCR),
                new SqlParameter("@pdtFecha_Constitucion_Garantia", _entidad.FechaConstitucionGarantia),
                new SqlParameter("@pdtFecha_Valor_Mercado", _entidad.FechaValorMercado),

                new SqlParameter("@pdtFecha_Vencimiento", _entidad.FechaVencimiento),
                new SqlParameter("@psIdentificacion_Emisor", _entidad.IdentificacionEmisor),
                new SqlParameter("@psIdentificacion_Instrumento", _entidad.IdentificacionInstrumento),
                new SqlParameter("@psISIN", _entidad.ISIN),
                new SqlParameter("@pnMonto_Valor_Facial", _entidad.MontoValorFacial),
                new SqlParameter("@pnMonto_Valor_Mercado", _entidad.MontoValorMercado),
                new SqlParameter("@pnPremio", _entidad.Premio),
                new SqlParameter("@psSerie", _entidad.Serie),
                new SqlParameter("@piId_Tipo_Clasificacion_Instrumento", int.Parse(_entidad.ClasificacionInstrumento)),
                new SqlParameter("@piId_Tipo_Valor", _entidad.IdTipoValor),
                new SqlParameter("@piId_Tipo_Instrumento", _entidad.IdTipoInstrumento),
                new SqlParameter("@pbInd_Busqueda_ISIN", _entidad.IndBusquedaISIN),
                new SqlParameter("@piId_Estado_Garantia", _entidad.IdEstadoGarantia),

                new SqlParameter("@psInd_Metodo_Insercion", _entidad.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _entidad.CodUsuarioIngreso)
            };

            #endregion

            try
            {
                #region VALIDAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Valores_Valida", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    elemento = new RespuestaEntidad();
                    //if (!rowsAffected.Tables[0].Rows[0][0].ToString().Contains(","))
                    //{
                    //    elemento.ValorEstado = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    //    elemento.ValorEstadoCadena = rowsAffected.Tables[0].Rows[0][0].ToString();
                    //}
                    //else
                    //{
                    //    elemento.ValorEstado = 0;
                    //    elemento.ValorEstadoCadena = rowsAffected.Tables[0].Rows[0][0].ToString();
                    //}

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

        public RespuestaEntidad GarantiasValoresInsertar(String conexion, String conexionBitacora, GarantiasValoresEntidad _valores, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Calificacion_Empresa_Calificadora", _valores.IdCalificacionEmpresaCalificadora),
                new SqlParameter("@piId_Categoria_Riesgo_Empresa_Calificadora", _valores.IdCategoriaRiesgoEmpresaCalificadora),
                new SqlParameter("@piId_Emisor", _valores.IdEmisor),
                new SqlParameter("@piId_Empresa_Calificadora", _valores.IdEmpresaCalificadora),
                new SqlParameter("@piId_Instrumento", _valores.IdInstrumento),
                new SqlParameter("@piId_Moneda_Valor_Facial", _valores.IdMonedaValorFacial),
                new SqlParameter("@piId_Moneda_Valor_Mercado", _valores.IdMonedaValorMercado),
                new SqlParameter("@piId_Tipo_Asignacion_Calificacion", _valores.IdTipoAsignacionCalificacion),
                new SqlParameter("@piId_Tipo_Persona_Emisor", _valores.IdTipoPersonaEmisor),
                new SqlParameter("@psCod_Garantia", _valores.CodGarantia),
                new SqlParameter("@psCod_Garantia_BCR", _valores.CodGarantiaBCR),
                new SqlParameter("@pdtFecha_Constitucion_Garantia", _valores.FechaConstitucionGarantia),
                new SqlParameter("@pdtFecha_Valor_Mercado", _valores.FechaValorMercado),
                new SqlParameter("@pdtFecha_Vencimiento", _valores.FechaVencimiento),
                new SqlParameter("@psIdentificacion_Emisor", _valores.IdentificacionEmisor),
                new SqlParameter("@psIdentificacion_Instrumento", _valores.IdentificacionInstrumento),
                new SqlParameter("@psISIN", _valores.ISIN),
                new SqlParameter("@pnMonto_Valor_Facial", _valores.MontoValorFacial),
                new SqlParameter("@pnMonto_Valor_Mercado", _valores.MontoValorMercado),
                new SqlParameter("@pnPremio", _valores.Premio),
                new SqlParameter("@psSerie", _valores.Serie),
                new SqlParameter("@piId_Tipo_Clasificacion_Instrumento", int.Parse(_valores.ClasificacionInstrumento)),
                new SqlParameter("@piId_Tipo_Valor", _valores.IdTipoValor),
                new SqlParameter("@piId_Tipo_Instrumento", _valores.IdTipoInstrumento),
                new SqlParameter("@psInd_Metodo_Insercion", _valores.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _valores.CodUsuarioIngreso),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@pdFecha_Ingreso", null),
                new SqlParameter("@pdFecha_Ultima_Modificacion", null),
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", null),
                new SqlParameter("@psInd_Accion_Registro", null),
                //REQUERIMIENTO: 1-24292751
                new SqlParameter("@pbInd_Busqueda_ISIN", _valores.IndBusquedaISIN)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Valores_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
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

        public RespuestaEntidad GarantiasValoresModificar(String conexion, String conexionBitacora, GarantiasValoresEntidad _valores, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Valor", _valores.IdGarantiaValor),
                new SqlParameter("@piId_Calificacion_Empresa_Calificadora", _valores.IdCalificacionEmpresaCalificadora),
                new SqlParameter("@piId_Categoria_Riesgo_Empresa_Calificadora", _valores.IdCategoriaRiesgoEmpresaCalificadora),
                new SqlParameter("@piId_Emisor", _valores.IdEmisor),
                new SqlParameter("@piId_Empresa_Calificadora", _valores.IdEmpresaCalificadora),
                new SqlParameter("@piId_Instrumento", _valores.IdInstrumento),
                new SqlParameter("@piId_Moneda_Valor_Facial", _valores.IdMonedaValorFacial),
                new SqlParameter("@piId_Moneda_Valor_Mercado", _valores.IdMonedaValorMercado),
                new SqlParameter("@piId_Tipo_Asignacion_Calificacion", _valores.IdTipoAsignacionCalificacion),
                new SqlParameter("@piId_Tipo_Persona_Emisor", _valores.IdTipoPersonaEmisor),
                new SqlParameter("@psCod_Garantia", _valores.CodGarantia),
                new SqlParameter("@psCod_Garantia_BCR", _valores.CodGarantiaBCR),
                new SqlParameter("@pdtFecha_Constitucion_Garantia", _valores.FechaConstitucionGarantia),
                new SqlParameter("@pdtFecha_Valor_Mercado", _valores.FechaValorMercado),
                new SqlParameter("@pdtFecha_Vencimiento", _valores.FechaVencimiento),
                new SqlParameter("@psIdentificacion_Emisor", _valores.IdentificacionEmisor),
                new SqlParameter("@psIdentificacion_Instrumento", _valores.IdentificacionInstrumento),
                new SqlParameter("@psISIN", _valores.ISIN),
                new SqlParameter("@pnMonto_Valor_Facial", _valores.MontoValorFacial),
                new SqlParameter("@pnMonto_Valor_Mercado", _valores.MontoValorMercado),
                new SqlParameter("@pnPremio", _valores.Premio),
                new SqlParameter("@psSerie", _valores.Serie),
                new SqlParameter("@piCod_Tipo_Clasificacion_Instrumento", int.Parse(_valores.ClasificacionInstrumento)),
                new SqlParameter("@piId_Tipo_Valor", _valores.IdTipoValor),
                //REQUERIMIENTO: 1-24292751
                new SqlParameter("@piId_Tipo_Instrumento", _valores.IdTipoInstrumento),
                new SqlParameter("@psInd_Metodo_Insercion", _valores.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _valores.CodUsuarioIngreso),
                //REQUERIMIENTO: 1-24292751
                new SqlParameter("@pbInd_Busqueda_ISIN", _valores.IndBusquedaISIN),
                new SqlParameter("@piId_Estado_Garantia", _valores.IdEstadoGarantia)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Valor", _valores.IdGarantiaValor.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Garantias_Valores_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Garantias_Valores_Consulta_Detalle", _bitacora);
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

        public RespuestaEntidad GarantiasValoresEliminar(String conexion, String conexionBitacora, GarantiasValoresEntidad _valores, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Valor", _valores.IdGarantiaValor),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", _valores.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Valor", _valores.IdGarantiaValor.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Valores_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Valores_Consulta_Detalle", _bitacora);
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

        public List<GarantiasValoresEntidad> GarantiasValoresConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<GarantiasValoresEntidad> retorno = new List<GarantiasValoresEntidad>();
            GarantiasValoresEntidad elemento;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Valores_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasValoresEntidad();
                        elemento.IdGarantiaValor = int.Parse(dr[0].ToString());
                        elemento.CodGarantiaBCR = dr[1].ToString();
                        elemento.DesInstrumento = dr[2].ToString();
                        elemento.DesEmisor = dr[3].ToString();
                        if (dr[4].ToString().Length > 0)
                            elemento.MontoValorFacial = decimal.Parse(dr[4].ToString());
                        else
                            elemento.MontoValorFacial = null;
                        elemento.DesTipoValor = dr[5].ToString();

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

        public GarantiasValoresEntidad GarantiasValoresConsultarDetalle(String conexion, String conexionBitacora, GarantiasValoresEntidad _valores, BitacorasEntidad _bitacora)
        {
            GarantiasValoresEntidad retorno = new GarantiasValoresEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Valor", _valores.IdGarantiaValor)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Valor", _valores.IdGarantiaValor.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Valores_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Valores_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdGarantiaValor = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.CodGarantiaBCR = rowsAffected.Tables[0].Rows[0][1].ToString().ToUpper();
                    retorno.IdTipoInstrumento = int.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    retorno.IdInstrumento = int.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    retorno.IdEmisor = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    retorno.ISIN = rowsAffected.Tables[0].Rows[0][5].ToString().ToUpper();
                    retorno.Serie = rowsAffected.Tables[0].Rows[0][6].ToString().ToUpper();
                    retorno.CodGarantia = rowsAffected.Tables[0].Rows[0][7].ToString().ToUpper();
                    retorno.IdTipoPersonaEmisor = int.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    retorno.IdentificacionEmisor = rowsAffected.Tables[0].Rows[0][9].ToString();
                    retorno.IdentificacionInstrumento = rowsAffected.Tables[0].Rows[0][10].ToString();
                    if (rowsAffected.Tables[0].Rows[0][11].ToString().Length > 0)
                        retorno.Premio = decimal.Parse(rowsAffected.Tables[0].Rows[0][11].ToString());
                    else
                        retorno.Premio = null;
                    retorno.IdTipoAsignacionCalificacion = int.Parse(rowsAffected.Tables[0].Rows[0][12].ToString());
                    if (rowsAffected.Tables[0].Rows[0][13].ToString().Length > 0)
                        retorno.IdPlazoCalificacion = int.Parse(rowsAffected.Tables[0].Rows[0][13].ToString());
                    else
                        retorno.IdPlazoCalificacion = null;
                    if (rowsAffected.Tables[0].Rows[0][14].ToString().Length > 0)
                        retorno.IdEmpresaCalificadora = int.Parse(rowsAffected.Tables[0].Rows[0][14].ToString());
                    else
                        retorno.IdEmpresaCalificadora = null;
                    if (rowsAffected.Tables[0].Rows[0][15].ToString().Length > 0)
                        retorno.IdCategoriaRiesgoEmpresaCalificadora = int.Parse(rowsAffected.Tables[0].Rows[0][15].ToString());
                    else
                        retorno.IdCategoriaRiesgoEmpresaCalificadora = null;
                    if (rowsAffected.Tables[0].Rows[0][16].ToString().Length > 0)
                        retorno.IdCalificacionEmpresaCalificadora = int.Parse(rowsAffected.Tables[0].Rows[0][16].ToString());
                    else
                        retorno.IdCalificacionEmpresaCalificadora = null;
                    if (rowsAffected.Tables[0].Rows[0][17].ToString().Length > 0)
                        retorno.IdMonedaValorFacial = int.Parse(rowsAffected.Tables[0].Rows[0][17].ToString());
                    else
                        retorno.IdMonedaValorFacial = null;
                    if (rowsAffected.Tables[0].Rows[0][18].ToString().Length > 0)
                        retorno.MontoValorFacial = decimal.Parse(rowsAffected.Tables[0].Rows[0][18].ToString());
                    else
                        retorno.MontoValorFacial = null;
                    retorno.IdMonedaValorMercado = int.Parse(rowsAffected.Tables[0].Rows[0][19].ToString());
                    if (rowsAffected.Tables[0].Rows[0][20].ToString().Length > 0)
                        retorno.MontoValorMercado = decimal.Parse(rowsAffected.Tables[0].Rows[0][20].ToString());
                    else
                        retorno.MontoValorMercado = null;
                    retorno.FechaConstitucionGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][21].ToString());
                    retorno.FechaValorMercado = DateTime.Parse(rowsAffected.Tables[0].Rows[0][22].ToString());
                    if (rowsAffected.Tables[0].Rows[0][23].ToString().Length > 0)
                        retorno.FechaVencimiento = DateTime.Parse(rowsAffected.Tables[0].Rows[0][23].ToString());
                    else
                        retorno.FechaVencimiento = null;
                    retorno.ClasificacionInstrumento = rowsAffected.Tables[0].Rows[0][24].ToString();
                    retorno.IdTipoValor = int.Parse(rowsAffected.Tables[0].Rows[0][25].ToString());

                    //REQUERIMIENTO: 1-24292751
                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][26].ToString();
                    if (rowsAffected.Tables[0].Rows[0][27].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][27].ToString());
                    else
                        retorno.FechaIngreso = null;
                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][28].ToString();
                    if (rowsAffected.Tables[0].Rows[0][29].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][29].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;
                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][30].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][31].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][32].ToString();

                    //REQUERIMIENTO: 1-24653531
                    retorno.IndBusquedaISIN = bool.Parse(rowsAffected.Tables[0].Rows[0][33].ToString());

                    //REQUERIMIENTO: 1-24653531
                    if (retorno.IdTipoValor.Equals(2) && retorno.IndBusquedaISIN.Equals(true))
                    {
                        retorno.ValorBusqueda = rowsAffected.Tables[0].Rows[0][1].ToString().ToUpper();
                    }
                    if (retorno.IdTipoValor.Equals(1) && retorno.IndBusquedaISIN.Equals(true))
                    {
                        retorno.ValorBusqueda = rowsAffected.Tables[0].Rows[0][5].ToString().ToUpper();
                    }

                    if (rowsAffected.Tables[0].Rows[0][34].ToString().Length > 0)
                        retorno.IdEstadoGarantia = int.Parse(rowsAffected.Tables[0].Rows[0][34].ToString());
                    else
                        retorno.IdEstadoGarantia = null;

                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GarantiasValoresTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

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

                value = transaccionDA.TransaccionRows(conexion, "Garantias_Valores_Total_Filas", paramTransaccion);
                return value;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region REQUERIMIENTO 1-24653531 CONSULTA CDP

        public String GarantiasValoresCrearTrama(String conexion, String numeroCDP)
        {
            string elemento = string.Empty;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piNumCDP", numeroCDP),
            };

            #endregion

            try
            {
                #region CREAR TRAMA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Valores_Trama", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = dr[0].ToString();
                    }
                }
                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GarantiasValoresRespuestaISINEntidad GarantiasValoresConsultarISIN(String conexion, String valorISIN)
        {
            GarantiasValoresRespuestaISINEntidad retorno = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
                    {
                        new SqlParameter("@psISIN", valorISIN)
                    };

            #endregion

            try
            {
                #region CONSULTAR ISIN

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Emisiones_Instrumentos_ISIN_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    if (rowsAffected.Tables[0].Rows.Count > 0)
                    {
                        retorno = new GarantiasValoresRespuestaISINEntidad();
                        retorno.IdTipoInstrumento = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                        retorno.IdInstrumento = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                        retorno.IdEmisor = int.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                        retorno.ISIN = rowsAffected.Tables[0].Rows[0][3].ToString();
                        retorno.ClasificacionInstrumento = rowsAffected.Tables[0].Rows[0][4].ToString();
                        if (rowsAffected.Tables[0].Rows[0][5].ToString().Length > 0)
                            retorno.Premio = decimal.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                        else
                            retorno.Premio = null;
                        retorno.IdMonedaValorFacial = int.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
                        if (rowsAffected.Tables[0].Rows[0][7].ToString().Length > 0)
                            retorno.FechaVencimiento = DateTime.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());
                        else
                            retorno.FechaVencimiento = null;
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

        #endregion

        #region REALES

        public RespuestaEntidad GarantiasRealesInsertarGenerales(String conexion, String conexionBitacora, GarantiasRealesEntidad _reales, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Clase_Aeronave", _reales.IdClaseAeronave),
                new SqlParameter("@piId_Clase_Buque", _reales.IdClaseBuque),
                new SqlParameter("@piId_Clase_Tipo_Bien", _reales.IdClaseTipoBien),
                new SqlParameter("@piId_Clase_Vehiculo", _reales.IdClaseVehiculo),
                new SqlParameter("@piId_Codigo_Duplicado", _reales.IdCodigoDuplicado),
                new SqlParameter("@piId_Codigo_Horizontalidad", _reales.IdCodigoHorizontalidad),
                new SqlParameter("@piId_Provincia", _reales.IdProvincia),
                new SqlParameter("@piId_Tipo_Bien", _reales.IdTipoBien),
                new SqlParameter("@piId_Tipo_Liquidez", _reales.IdTipoLiquidez),
                new SqlParameter("@piId_Tipo_Moneda", _reales.IdTipoMoneda),
                new SqlParameter("@psCodigo_Bien", _reales.CodBien),
                new SqlParameter("@pbEstado_Registro_Garantia", bool.Parse("false")) ,
                new SqlParameter("@piFormato_Identificacion_Vehiculo", _reales.FormatoIdentificacionVehiculo),
                new SqlParameter("@psInd_Metodo_Insercion", _reales.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _reales.CodUsuarioIngreso),
                new SqlParameter("@piId_Estad_Garantia", null),
                new SqlParameter("@piId_Tipo_Almacen", null)
            };


            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Reales_Inserta_Generales", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
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

        public List<GarantiasRealesEntidad> GarantiasRealesConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<GarantiasRealesEntidad> retorno = new List<GarantiasRealesEntidad>();
            GarantiasRealesEntidad elemento;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Reales_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasRealesEntidad();
                        elemento.IdGarantiaReal = int.Parse(dr[0].ToString());
                        elemento.DesTipoBien = dr[1].ToString();
                        elemento.CodBien = dr[2].ToString();

                        if (dr[3].ToString().Length > 0)
                            elemento.MontoUltimaTasacionNoTerreno = decimal.Parse(dr[3].ToString());
                        else
                            elemento.MontoUltimaTasacionNoTerreno = null;

                        if (dr[4].ToString().Length > 0)
                            elemento.MontoUltimaTasacionTerreno = decimal.Parse(dr[4].ToString());
                        else
                            elemento.MontoUltimaTasacionTerreno = null;

                        if (dr[5].ToString().Length > 0)
                            elemento.FechaUltimaTasacionGarantia = DateTime.Parse(dr[5].ToString());
                        else
                            elemento.FechaUltimaTasacionGarantia = null;

                        if (dr[6].ToString().Length > 0)
                            elemento.MontoTasacionActualizadaNoTerreno = decimal.Parse(dr[6].ToString());
                        else
                            elemento.MontoTasacionActualizadaNoTerreno = null;

                        if (dr[7].ToString().Length > 0)
                            elemento.MontoTasacionActualizadaTerreno = decimal.Parse(dr[7].ToString());
                        else
                            elemento.MontoTasacionActualizadaTerreno = null;

                        if (dr[8].ToString().Length > 0)
                            elemento.FechaUltimoSeguimientoGarantia = DateTime.Parse(dr[8].ToString());
                        else
                            elemento.FechaUltimoSeguimientoGarantia = null;

                        if (elemento.MontoTasacionActualizadaNoTerreno != null && elemento.MontoTasacionActualizadaTerreno != null)
                            elemento.MontoTotalTasacionActualizada = elemento.MontoTasacionActualizadaNoTerreno + elemento.MontoTasacionActualizadaTerreno;
                        else
                        {
                            if (elemento.MontoTasacionActualizadaNoTerreno == null && elemento.MontoTasacionActualizadaTerreno != null)
                                elemento.MontoTotalTasacionActualizada = elemento.MontoTasacionActualizadaTerreno;
                            else
                            {
                                if (elemento.MontoTasacionActualizadaNoTerreno != null && elemento.MontoTasacionActualizadaTerreno == null)
                                    elemento.MontoTotalTasacionActualizada = elemento.MontoTasacionActualizadaNoTerreno;
                            }
                        }

                        if (elemento.MontoUltimaTasacionNoTerreno != null && elemento.MontoUltimaTasacionTerreno != null)
                            elemento.MontoTotalUltimaTasacion = elemento.MontoUltimaTasacionNoTerreno + elemento.MontoUltimaTasacionTerreno;
                        else
                        {
                            if (elemento.MontoUltimaTasacionNoTerreno == null && elemento.MontoUltimaTasacionTerreno != null)
                                elemento.MontoTotalUltimaTasacion = elemento.MontoUltimaTasacionTerreno;
                            else
                            {
                                if (elemento.MontoUltimaTasacionNoTerreno != null && elemento.MontoUltimaTasacionTerreno == null)
                                    elemento.MontoTotalUltimaTasacion = elemento.MontoUltimaTasacionNoTerreno;
                            }
                        }

                        if (dr[9].ToString().Length > 0)
                            elemento.DesFechaUltimaTasacionGarantia = dr[9].ToString();
                        else
                            elemento.DesFechaUltimaTasacionGarantia = null;

                        if (dr[10].ToString().Length > 0)
                            elemento.DesFechaUltimoSeguimientoGarantia = dr[10].ToString();
                        else
                            elemento.DesFechaUltimoSeguimientoGarantia = null;

                        if (dr[11].ToString().Length > 0)
                            elemento.DesMontoTotalUltimaTasacion = dr[11].ToString();
                        else
                            elemento.DesMontoTotalUltimaTasacion = null;

                        if (dr[12].ToString().Length > 0)
                            elemento.DesMontoTotalTasacionActualizada = dr[12].ToString();
                        else
                            elemento.DesMontoTotalTasacionActualizada = null;

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

        public ListaEntidad GarantiasRealesFechaVencimientoAvaluoSUGEF(String conexion, String filtro)
        {
            ListaEntidad retorno = null;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Reales_Fecha_Vencimiento_Avaluo_SUGEF", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        retorno = new ListaEntidad();
                        retorno.Valor = dr[0].ToString();
                        retorno.Texto = dr[1].ToString();

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

        public RespuestaEntidad GarantiasRealesEliminar(String conexion, String conexionBitacora, GarantiasRealesEntidad _reales, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", _reales.IdGarantiaReal),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", _reales.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real", _reales.IdGarantiaReal.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Reales_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Reales_Consulta_Detalle", _bitacora);
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

        public RespuestaEntidad GarantiasRealesModificar(String conexion, String conexionBitacora, GarantiasRealesEntidad _reales, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", _reales.IdGarantiaReal),
                new SqlParameter("@pdtFecha_Ultimo_Seguimiento_Garantia", _reales.FechaUltimoSeguimientoGarantia),
                new SqlParameter("@pdtFecha_Vencimiento_Avaluo_SUGEF", _reales.FechaVencimientoAvaluoSUGEF),
                new SqlParameter("@pbBono_Prenda", _reales.BonoPrenda),
                new SqlParameter("@pbCedula_Hipotecaria", _reales.CedulaHipotecaria),
                new SqlParameter("@pdtFecha_Construcción_Garantia", _reales.FechaConstruccionGarantia),
                new SqlParameter("@pdtFecha_Actualizacion_Garantia", _reales.FechaActualizacionGarantia),
                new SqlParameter("@pdtFecha_Fabricacion_Garantia", _reales.FechaFabricacionGarantia),
                new SqlParameter("@pdtFecha_Ultima_Tasacion_Garantia", _reales.FechaUltimaTasacionGarantia),
                new SqlParameter("@pbHipoteca_Abierta", _reales.HipotecaAbierta),
                new SqlParameter("@pnMonto_Ultima_Tasacion_No_Terreno", _reales.MontoUltimaTasacionNoTerreno),
                new SqlParameter("@pnMonto_Ultima_Tasacion_Terreno", _reales.MontoUltimaTasacionTerreno),
                new SqlParameter("@pnMonto_Tasacion_Actualizada_No_Terreno", _reales.MontoTasacionActualizadaNoTerreno),
                new SqlParameter("@pnMonto_Tasacion_Actualizada_Terreno", _reales.MontoTasacionActualizadaTerreno),
                new SqlParameter("@pnMonto_Valor_Total_Cedula", _reales.MontoValorTotalCedula),
                new SqlParameter("@piId_Tipo_Liquidez", _reales.IdTipoLiquidez),
                new SqlParameter("@piId_Tipo_Moneda", _reales.IdTipoMoneda),
                new SqlParameter("@psInd_Metodo_Insercion", _reales.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _reales.CodUsuarioIngreso),
                new SqlParameter("@piId_Estado_Garantia", _reales.IdEstadoGarantia),
                new SqlParameter("@piId_Tipo_Almacen", _reales.IdTipoAlmacen),
                new SqlParameter("@psJustificacion", _reales.Justificacion)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real", _reales.IdGarantiaReal.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Garantias_Reales_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Garantias_Reales_Consulta_Detalle", _bitacora);
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

        public RespuestaEntidad GarantiasRealesModificarTipoBien(String conexion, String conexionBitacora, GarantiasRealesEntidad _reales, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", _reales.IdGarantiaReal),
                new SqlParameter("@piCod_Tipo_Bien", _reales.CodTipoBien),
                new SqlParameter("@psInd_Metodo_Insercion", _reales.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _reales.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real", _reales.IdGarantiaReal.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Garantias_Reales_Actualiza_Tipo_Bien", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Garantias_Reales_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    int tabla = rowsAffected.Tables.Count;
                    if (tabla > 0)
                        tabla--;

                    elemento = new RespuestaEntidad();
                    if (!rowsAffected.Tables[tabla].Rows[0][0].ToString().Equals("0"))
                    {
                        //PROCESO SATISFACTORIO
                        elemento.ValorEstado = 1;
                        elemento.ValorEstadoCadena = rowsAffected.Tables[tabla].Rows[0][0].ToString();
                    }
                    else
                        elemento.ValorEstado = int.Parse(rowsAffected.Tables[tabla].Rows[0][0].ToString());

                    elemento.ValorError = int.Parse(rowsAffected.Tables[tabla].Rows[0][1].ToString());
                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad GarantiasRealesValidar(String conexion, String conexionBitacora, GarantiasRealesEntidad _reales, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Clase_Aeronave", _reales.IdClaseAeronave),
                new SqlParameter("@piId_Clase_Buque", _reales.IdClaseBuque),
                new SqlParameter("@piId_Clase_Tipo_Bien", _reales.IdClaseTipoBien),
                new SqlParameter("@piId_Clase_Vehiculo", _reales.IdClaseVehiculo),
                new SqlParameter("@piId_Codigo_Duplicado", _reales.IdCodigoDuplicado),
                new SqlParameter("@piId_Codigo_Horizontalidad", _reales.IdCodigoHorizontalidad),
                new SqlParameter("@piId_Provincia", _reales.IdProvincia),
                new SqlParameter("@piId_Tipo_Bien", _reales.IdTipoBien),
                //new SqlParameter("@piId_Tipo_Garantia", null),
                new SqlParameter("@piId_Tipo_Liquidez", _reales.IdTipoLiquidez),
                new SqlParameter("@piId_Tipo_Moneda", _reales.IdTipoMoneda),
                new SqlParameter("@psCodigo_Bien", _reales.CodBien),
                new SqlParameter("@Formato_Identificacion_Vehiculo", _reales.FormatoIdentificacionVehiculo),
                new SqlParameter("@psInd_Metodo_Insercion", _reales.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _reales.CodUsuarioIngreso)
            };

            #endregion

            try
            {
                #region VALIDAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Reales_Valida", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    elemento = new RespuestaEntidad();
                    if (!rowsAffected.Tables[0].Rows[0][0].ToString().Contains(","))
                    {
                        elemento.ValorEstado = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                        elemento.ValorEstadoCadena = rowsAffected.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        elemento.ValorEstado = 0;
                        elemento.ValorEstadoCadena = rowsAffected.Tables[0].Rows[0][0].ToString();
                    }

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

        public GarantiasRealesEntidad GarantiasRealesConsultarDetalle(String conexion, String conexionBitacora, GarantiasRealesEntidad _reales, BitacorasEntidad _bitacora)
        {
            GarantiasRealesEntidad retorno = new GarantiasRealesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", _reales.IdGarantiaReal)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real", _reales.IdGarantiaReal.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Reales_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Reales_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    if (rowsAffected.Tables[0].Rows[0][0].ToString().Length > 0)
                        retorno.IdClaseAeronave = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    else
                        retorno.IdClaseAeronave = null;

                    if (rowsAffected.Tables[0].Rows[0][1].ToString().Length > 0)
                        retorno.IdClaseBuque = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    else
                        retorno.IdClaseBuque = null;

                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        retorno.IdClaseTipoBien = int.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    else
                        retorno.IdClaseTipoBien = null;

                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        retorno.IdClaseVehiculo = int.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    else
                        retorno.IdClaseVehiculo = null;

                    if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                        retorno.IdCodigoDuplicado = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    else
                        retorno.IdCodigoDuplicado = null;

                    if (rowsAffected.Tables[0].Rows[0][5].ToString().Length > 0)
                        retorno.IdCodigoHorizontalidad = int.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    else
                        retorno.IdCodigoHorizontalidad = null;

                    if (rowsAffected.Tables[0].Rows[0][6].ToString().Length > 0)
                        retorno.IdProvincia = int.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
                    else
                        retorno.IdProvincia = null;

                    retorno.IdTipoBien = int.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());

                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        retorno.IdTipoLiquidez = int.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    else
                        retorno.IdTipoLiquidez = null;

                    if (rowsAffected.Tables[0].Rows[0][9].ToString().Length > 0)
                        retorno.IdTipoMoneda = int.Parse(rowsAffected.Tables[0].Rows[0][9].ToString());
                    else
                        retorno.IdTipoMoneda = null;

                    if (rowsAffected.Tables[0].Rows[0][10].ToString().Length > 0)
                        retorno.FechaUltimoSeguimientoGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][10].ToString());
                    else
                        retorno.FechaUltimoSeguimientoGarantia = null;

                    if (rowsAffected.Tables[0].Rows[0][11].ToString().Length > 0)
                        retorno.FechaVencimientoAvaluoSUGEF = DateTime.Parse(rowsAffected.Tables[0].Rows[0][11].ToString());
                    else
                        retorno.FechaVencimientoAvaluoSUGEF = null;

                    if (rowsAffected.Tables[0].Rows[0][12].ToString().Length > 0)
                        retorno.CodBien = rowsAffected.Tables[0].Rows[0][12].ToString();
                    else
                        retorno.CodBien = string.Empty;

                    if (rowsAffected.Tables[0].Rows[0][13].ToString().Length > 0)
                        retorno.BonoPrenda = int.Parse(rowsAffected.Tables[0].Rows[0][13].ToString());
                    else
                        retorno.BonoPrenda = null;

                    if (rowsAffected.Tables[0].Rows[0][14].ToString().Length > 0)
                        retorno.CedulaHipotecaria = int.Parse(rowsAffected.Tables[0].Rows[0][14].ToString());
                    else
                        retorno.CedulaHipotecaria = null;

                    if (rowsAffected.Tables[0].Rows[0][16].ToString().Length > 0)
                        retorno.FechaConstruccionGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][16].ToString());
                    else
                        retorno.FechaConstruccionGarantia = null;

                    if (rowsAffected.Tables[0].Rows[0][17].ToString().Length > 0)
                        retorno.FechaActualizacionGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][17].ToString());
                    else
                        retorno.FechaActualizacionGarantia = null;

                    if (rowsAffected.Tables[0].Rows[0][18].ToString().Length > 0)
                        retorno.FechaFabricacionGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][18].ToString());
                    else
                        retorno.FechaFabricacionGarantia = null;

                    if (rowsAffected.Tables[0].Rows[0][19].ToString().Length > 0)
                        retorno.FechaUltimaTasacionGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][19].ToString());
                    else
                        retorno.FechaUltimaTasacionGarantia = null;

                    if (rowsAffected.Tables[0].Rows[0][20].ToString().Length > 0)
                        retorno.HipotecaAbierta = int.Parse(rowsAffected.Tables[0].Rows[0][20].ToString());
                    else
                        retorno.HipotecaAbierta = null;

                    if (rowsAffected.Tables[0].Rows[0][21].ToString().Length > 0)
                        retorno.MontoUltimaTasacionNoTerreno = decimal.Parse(rowsAffected.Tables[0].Rows[0][21].ToString());
                    else
                        retorno.MontoUltimaTasacionNoTerreno = null;

                    if (rowsAffected.Tables[0].Rows[0][22].ToString().Length > 0)
                        retorno.MontoUltimaTasacionTerreno = decimal.Parse(rowsAffected.Tables[0].Rows[0][22].ToString());
                    else
                        retorno.MontoUltimaTasacionTerreno = null;

                    if (rowsAffected.Tables[0].Rows[0][23].ToString().Length > 0)
                        retorno.MontoTasacionActualizadaNoTerreno = decimal.Parse(rowsAffected.Tables[0].Rows[0][23].ToString());
                    else
                        retorno.MontoTasacionActualizadaNoTerreno = null;

                    if (rowsAffected.Tables[0].Rows[0][24].ToString().Length > 0)
                        retorno.MontoTasacionActualizadaTerreno = decimal.Parse(rowsAffected.Tables[0].Rows[0][24].ToString());
                    else
                        retorno.MontoTasacionActualizadaTerreno = null;

                    if (rowsAffected.Tables[0].Rows[0][25].ToString().Length > 0)
                        retorno.MontoValorTotalCedula = decimal.Parse(rowsAffected.Tables[0].Rows[0][25].ToString());
                    else
                        retorno.MontoValorTotalCedula = null;

                    if (rowsAffected.Tables[0].Rows[0][26].ToString().Length > 0)
                        retorno.DesClaseVehiculo = rowsAffected.Tables[0].Rows[0][26].ToString();
                    else
                        retorno.DesClaseVehiculo = null;

                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][27].ToString();
                    if (rowsAffected.Tables[0].Rows[0][28].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][28].ToString());
                    else
                        retorno.FechaIngreso = null;
                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][29].ToString();
                    if (rowsAffected.Tables[0].Rows[0][30].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][30].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;
                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][31].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][32].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][33].ToString();

                    if (rowsAffected.Tables[0].Rows[0][34].ToString().Length > 0)
                        retorno.FormatoIdentificacionVehiculo = int.Parse(rowsAffected.Tables[0].Rows[0][34].ToString());
                    else
                        retorno.FormatoIdentificacionVehiculo = null;

                    if (rowsAffected.Tables[0].Rows[0][35].ToString().Length > 0)
                        retorno.IdEstadoGarantia = int.Parse(rowsAffected.Tables[0].Rows[0][35].ToString());
                    else
                        retorno.IdEstadoGarantia = null;

                    if (rowsAffected.Tables[0].Rows[0][36].ToString().Length > 0)
                        retorno.IdTipoAlmacen = int.Parse(rowsAffected.Tables[0].Rows[0][36].ToString());
                    else
                        retorno.IdTipoAlmacen = null;

                    retorno.Justificacion = rowsAffected.Tables[0].Rows[0][37].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GarantiasRealesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

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

                value = transaccionDA.TransaccionRows(conexion, "Garantias_Reales_Total_Filas", paramTransaccion);
                return value;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad GarantiasRealesTasadoresInsertar(String conexion, String conexionBitacora, GarantiasRealesTasadoresEntidad _realesTasadores, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", _realesTasadores.IdGarantiaReal),
                new SqlParameter("@piId_Tasador", _realesTasadores.IdTasador),
                new SqlParameter("@psInd_Metodo_Insercion", _realesTasadores.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _realesTasadores.CodUsuarioIngreso),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@pdFecha_Ingreso", null),
                new SqlParameter("@pdFecha_Ultima_Modificacion", null),
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", null),
                new SqlParameter("@psInd_Accion_Registro", null)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Reales_Tasadores_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
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

        public RespuestaEntidad GarantiasRealesTasadoresEliminar(String conexion, String conexionBitacora, GarantiasRealesTasadoresEntidad _realesTasadores, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real_Tasador", _realesTasadores.IdGarantiaRealTasador),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", _realesTasadores.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Tasador", _realesTasadores.IdGarantiaRealTasador.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Reales_Tasadores_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Reales_Tasadores_Consulta_Detalle", _bitacora);
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

        public List<TasadoresEntidad> GarantiasRealesTasadoresConsultar(String conexion)
        {
            List<TasadoresEntidad> retorno = new List<TasadoresEntidad>();
            TasadoresEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Reales_Empresas_Tasadoras_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new TasadoresEntidad();
                        elemento.IdTasador = int.Parse(dr[0].ToString());
                        elemento.DesTipoPersona = dr[1].ToString();
                        elemento.CodTasador = dr[2].ToString();
                        elemento.DesNombreTasador = dr[3].ToString();

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

        public List<TasadoresEntidad> GarantiasRealesPersonasTasadorasConsultar(String conexion)
        {
            List<TasadoresEntidad> retorno = new List<TasadoresEntidad>();
            TasadoresEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Reales_Personas_Tasadoras_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new TasadoresEntidad();
                        elemento.IdTasador = int.Parse(dr[0].ToString());
                        elemento.DesTipoPersona = dr[1].ToString();
                        elemento.CodTasador = dr[2].ToString();
                        elemento.DesNombreTasador = dr[3].ToString();

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

        public List<GarantiasRealesTasadoresEntidad> GarantiasRealesTasadoresConsultarGridInterno(String conexion, int parametro)
        {
            List<GarantiasRealesTasadoresEntidad> retorno = new List<GarantiasRealesTasadoresEntidad>();
            GarantiasRealesTasadoresEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", parametro)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Reales_Tasadores_Consulta_Grid_Interno", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasRealesTasadoresEntidad();
                        elemento.IdGarantiaRealTasador = int.Parse(dr[0].ToString());
                        elemento.DesTipoPersona = dr[1].ToString();
                        elemento.CodTasador = dr[2].ToString();
                        elemento.DesNombreTasador = dr[3].ToString();
                        elemento.Id_Visible = 1;

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

        public List<GarantiasRealesTasadoresEntidad> GarantiasRealesTasadoresPersonasTasadorasConsultaDetalle(String conexion, String conexionBitacora, GarantiasRealesTasadoresEntidad _realesTasadores, BitacorasEntidad _bitacora)
        {
            List<GarantiasRealesTasadoresEntidad> retorno = new List<GarantiasRealesTasadoresEntidad>();
            GarantiasRealesTasadoresEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", _realesTasadores.IdGarantiaReal)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real", _realesTasadores.IdGarantiaReal.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Reales_Tasadores_Personas_Tasadoras_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Reales_Consulta_Detalle", _bitacora);

                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasRealesTasadoresEntidad();
                        elemento.IdGarantiaReal = int.Parse(dr[0].ToString());
                        elemento.DesTipoPersona = dr[1].ToString();
                        elemento.CodTasador = dr[2].ToString();
                        elemento.DesNombreTasador = dr[3].ToString();
                        elemento.OrigenTasador = dr[4].ToString();

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

        public RespuestaEntidad GarantiasRealesCedulasInsertar(String conexion, String conexionBitacora, GarantiasRealesCedulasEntidad _realesCedulas, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", _realesCedulas.IdGarantiaReal),
                new SqlParameter("@piId_Tipo_Moneda", _realesCedulas.IdMoneda),
                new SqlParameter("@pdtFecha_Prescripcion_Cedula", _realesCedulas.FechaPrescripcionCedula),
                new SqlParameter("@pdtFecha_Vencimiento_Cedula", _realesCedulas.FechaVencimientoCedula),
                new SqlParameter("@piGrado_Gravamen", _realesCedulas.IdGradoGravamen),
                new SqlParameter("@pnMonto_Valor_Facial", _realesCedulas.ValorFacial),
                new SqlParameter("@piNumero_Cedula", _realesCedulas.Cedula),
                new SqlParameter("@psSerie", _realesCedulas.Serie),
                new SqlParameter("@psInd_Metodo_Insercion", _realesCedulas.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _realesCedulas.CodUsuarioIngreso),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@pdFecha_Ingreso", null),
                new SqlParameter("@pdFecha_Ultima_Modificacion", null),
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", null),
                new SqlParameter("@psInd_Accion_Registro", null)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Reales_Cedulas_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
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

        public RespuestaEntidad GarantiasRealesCedulasEliminar(String conexion, String conexionBitacora, GarantiasRealesCedulasEntidad _realesCedulas, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real_Cedula", _realesCedulas.IdGarantiaRealCedula),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", _realesCedulas.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Cedula", _realesCedulas.IdGarantiaRealCedula.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Reales_Cedulas_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Reales_Cedulas_Consulta_Detalle", _bitacora);
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

        public List<GarantiasRealesCedulasEntidad> GarantiasRealesCedulasConsultarGridInterno(String conexion, int parametro)
        {
            List<GarantiasRealesCedulasEntidad> retorno = new List<GarantiasRealesCedulasEntidad>();
            GarantiasRealesCedulasEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", parametro)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Reales_Cedulas_Consulta_Grid_Interno", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasRealesCedulasEntidad();
                        elemento.IdGarantiaRealCedula = int.Parse(dr[0].ToString());
                        elemento.Serie = dr[1].ToString();
                        elemento.Cedula = int.Parse(dr[2].ToString());
                        elemento.DesGradoGravamen = dr[3].ToString();
                        elemento.FechaVencimientoCedula = DateTime.Parse(dr[4].ToString());
                        elemento.FechaPrescripcionCedula = DateTime.Parse(dr[5].ToString());
                        elemento.DesMoneda = dr[6].ToString();
                        elemento.ValorFacial = decimal.Parse(dr[7].ToString());
                        elemento.Id_Visible = 1;

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

        //B16S01
        public String GarantiasRealesPolizaCrearTrama(String conexion, String identificacionRUC)
        {
            string elemento = string.Empty;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psIdentificacionRUC", identificacionRUC),
            };

            #endregion

            try
            {
                #region CREAR TRAMA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Reales_Poliza_Trama", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = dr[0].ToString();
                    }
                }
                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PolizaEntidad> GarantiasRealesPolizaGridInterno(String conexion, PolizaEntidad entidad)
        {
            List<PolizaEntidad> retorno = new List<PolizaEntidad>();
            PolizaEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", entidad.IdGarantiaReal)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Reales_Polizas_Consulta_Grid_Interno", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new PolizaEntidad();
                        elemento.IdPoliza = int.Parse(dr[0].ToString());
                        elemento.IdGarantiaReal = int.Parse(dr[1].ToString());
                        if (dr[2].ToString().Length > 0)
                            elemento.Nsap = long.Parse(dr[2].ToString());
                        elemento.NPoliza = dr[3].ToString();
                        elemento.FechaEmision = DateTime.Parse(dr[4].ToString());
                        elemento.FechaVencimiento = DateTime.Parse(dr[5].ToString());
                        elemento.IdTipoNivelPoliza = dr[6].ToString();
                        elemento.Id_Visible = 1;

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

        public RespuestaEntidad GarantiasRealesPolizaInsertar(String conexion, String conexionBitacora, PolizaEntidad entidad, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", entidad.IdGarantiaReal),
                new SqlParameter("@piId_Tipo_Poliza", entidad.IdTipoNivelPoliza),
                new SqlParameter("@pdNumero_SAP", entidad.Nsap),
                new SqlParameter("@psNumero_Poliza", entidad.NPoliza),
                new SqlParameter("@pdtFecha_Emision", entidad.FechaEmision),
                new SqlParameter("@pdtFecha_Vencimiento", entidad.FechaVencimiento),
                new SqlParameter("@piId_Tipo_Moneda", entidad.IdTipoMoneda),
                new SqlParameter("@pdMonto_Poliza", entidad.MontoPoliza),
                new SqlParameter("@pdMonto_Poliza_Colonizado", entidad.MontoPolizaColonizado),
                new SqlParameter("@pbCoberturas", entidad.IndCobertura),
                new SqlParameter("@piId_Tipo_Identificacion_RUC", entidad.IdTipoIdentificacionRUC),
                new SqlParameter("@psIdentificacion_RUC", entidad.Identificacion),
                new SqlParameter("@psInd_Metodo_Insercion", entidad.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario_Ingreso", entidad.CodUsuarioIngreso),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@pdtFecha_Ingreso", null),
                new SqlParameter("@pdtFecha_Ultima_Modificacion", null),
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", null),
                new SqlParameter("@psInd_Accion_Registro", null)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Reales_Polizas_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public RespuestaEntidad GarantiasRealesPolizaEliminar(String conexion, String conexionBitacora, PolizaEntidad entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real_Poliza", entidad.IdPoliza),                
                new SqlParameter("@psCod_Usuario", entidad.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Poliza", entidad.IdPoliza.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Reales_Polizas_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Reales_Polizas_Consulta_Detalle", _bitacora);
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

        public PolizaEntidad GarantiasRealesPolizaConsultaDetalle(String conexion, String conexionBitacora, PolizaEntidad entidad, BitacorasEntidad _bitacora)
        {
            PolizaEntidad retorno = new PolizaEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real_Poliza", entidad.IdPoliza)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Poliza", entidad.IdPoliza.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Reales_Polizas_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Reales_Polizas_Consulta_Detalle", _bitacora);

                if (!rowsAffected.Equals(null))
                {
                    retorno.IdPoliza = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.IdGarantiaReal = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    retorno.IdTipoNivelPoliza = rowsAffected.Tables[0].Rows[0][2].ToString();
                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        retorno.Nsap = long.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    retorno.NPoliza = rowsAffected.Tables[0].Rows[0][4].ToString();
                    retorno.FechaEmision = DateTime.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    retorno.FechaVencimiento = DateTime.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
                    retorno.IdTipoMoneda = int.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());
                    retorno.MontoPoliza = decimal.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    if (rowsAffected.Tables[0].Rows[0][9].ToString().Length > 0)
                        retorno.MontoPolizaColonizado = decimal.Parse(rowsAffected.Tables[0].Rows[0][9].ToString());
                    retorno.IndCobertura = rowsAffected.Tables[0].Rows[0][10].ToString();
                    retorno.IdTipoIdentificacionRUC = int.Parse(rowsAffected.Tables[0].Rows[0][11].ToString());
                    retorno.Identificacion = rowsAffected.Tables[0].Rows[0][12].ToString();

                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][13].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad GarantiasRealesPolizaModificar(String conexion, String conexionBitacora, PolizaEntidad entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real_Poliza", entidad.IdPoliza),
                new SqlParameter("@piId_Garantia_Real", entidad.IdGarantiaReal),
                new SqlParameter("@piId_Tipo_Poliza", entidad.IdTipoNivelPoliza),
                new SqlParameter("@pdNumero_SAP", entidad.Nsap),
                new SqlParameter("@psNumero_Poliza", entidad.NPoliza),
                new SqlParameter("@pdtFecha_Emision", entidad.FechaEmision),
                new SqlParameter("@pdtFecha_Vencimiento", entidad.FechaVencimiento),
                new SqlParameter("@piId_Tipo_Moneda", entidad.IdTipoMoneda),
                new SqlParameter("@pdMonto_Poliza", entidad.MontoPoliza),
                new SqlParameter("@pdMonto_Poliza_Colonizado", entidad.MontoPolizaColonizado),
                new SqlParameter("@pbCoberturas", entidad.IndCobertura),
                new SqlParameter("@piId_Tipo_Identificacion_RUC", entidad.IdTipoIdentificacionRUC),
                new SqlParameter("@psIdentificacion_RUC", entidad.Identificacion),
                new SqlParameter("@psInd_Metodo_Insercion", entidad.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", entidad.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Poliza", entidad.IdPoliza.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Reales_Polizas_Actualiza", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Reales_Polizas_Consulta_Detalle", _bitacora);

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

        #endregion
                
        #region OPERACIONES

        #region REQUERIMIENTO 1-24493201 INTERFAZ SICC

        public List<GarantiasOperacionesEntidad> GarantiasOperacionesConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<GarantiasOperacionesEntidad> retorno = new List<GarantiasOperacionesEntidad>();
            GarantiasOperacionesEntidad elemento;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Operaciones_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasOperacionesEntidad();
                        elemento.IdGarantiaOperacion = int.Parse(dr[0].ToString());
                        elemento.DesTipoOperacion = dr[1].ToString();
                        elemento.DesNumeroOperacion = dr[2].ToString();
                        elemento.TipoIdentificacionRUC = dr[3].ToString();
                        elemento.IdentificacionClienteRUC = dr[4].ToString();

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

        public int GarantiasOperacionesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

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

                value = transaccionDA.TransaccionRows(conexion, "Operaciones_Total_Filas", paramTransaccion);
                return value;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GarantiasOperacionesClientesEntidad GarantiasOperacionesConsultaDataBridge(String conexion, String conexionSICC, GarantiasOperacionesConsultaEntidad entidad)
        {
            GarantiasOperacionesClientesEntidad retorno = null;
            String query = string.Empty;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Operacion", entidad.IdTipoOperacion),
                new SqlParameter("@psConta", entidad.Conta),
                new SqlParameter("@psOficina", entidad.Oficina),
                new SqlParameter("@psMoneda", entidad.Moneda),
                new SqlParameter("@psProd", entidad.Producto),
                new SqlParameter("@psNumero", entidad.Numero)
            };

            #endregion

            try
            {
                #region OBTENER QUERY

                query = transaccionDA.TransaccionConsultaString(conexion, "Operaciones_Consulta_DataBridge", paramTransaccion);

                #endregion

                #region CONSULTAR SICC

                rowsAffected = transaccionDA.TransaccionConsultaDataBridge(conexionSICC, query);
                if (!rowsAffected.Equals(null))
                {
                    if (rowsAffected.Tables[0].Rows.Count > 0)
                    {
                        retorno = new GarantiasOperacionesClientesEntidad();
                        retorno.IdentificacionSICC = rowsAffected.Tables[0].Rows[0][0].ToString().Trim();
                        retorno.NombreClienteSICC = rowsAffected.Tables[0].Rows[0][1].ToString().Trim();
                        retorno.TipoIdentificacionSICC = rowsAffected.Tables[0].Rows[0][2].ToString().Trim();
                        //VALIDACION FECHA CONSTITUCION
                        if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                            retorno.FechaConstitucionSICC = DateTime.Parse(rowsAffected.Tables[0].Rows[0][3].ToString().Trim());
                        else
                            retorno.FechaConstitucionSICC = null;
                        //VALIDACION FECHA VENCIMIENTO
                        if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                            retorno.FechaVencimientoSICC = DateTime.Parse(rowsAffected.Tables[0].Rows[0][4].ToString().Trim());
                        else
                            retorno.FechaVencimientoSICC = null;
                        retorno.OficinaDeudorSICC = int.Parse(rowsAffected.Tables[0].Rows[0][5].ToString().Trim());
                        retorno.EstadoOperacionSICC = rowsAffected.Tables[0].Rows[0][6].ToString().Trim();
                        if (rowsAffected.Tables[0].Rows[0][8].ToString().Trim().Length > 0)
                            retorno.Saldo = decimal.Parse(rowsAffected.Tables[0].Rows[0][8].ToString().Trim());
                        if (rowsAffected.Tables[0].Rows[0][9].ToString().Trim().Length > 0)
                            retorno.SaldoColonizado = decimal.Parse(rowsAffected.Tables[0].Rows[0][9].ToString().Trim());
                        if (rowsAffected.Tables[0].Rows[0][10].ToString().Trim().Length > 0)
                            retorno.SaldoOriginal = decimal.Parse(rowsAffected.Tables[0].Rows[0][10].ToString().Trim());
                        if (rowsAffected.Tables[0].Rows[0][11].ToString().Trim().Length > 0)
                            retorno.SaldoOriginalColonizado = decimal.Parse(rowsAffected.Tables[0].Rows[0][11].ToString().Trim());
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

        public RespuestaEntidad GarantiasOperacionesValidar(String conexion, String conexionBitacora, GarantiasOperacionesClientesEntidad _entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Operacion", _entidad.IdTipoOperacion),
                new SqlParameter("@psConta", _entidad.Conta),
                new SqlParameter("@psOficina", _entidad.Oficina),
                new SqlParameter("@psMoneda", _entidad.Moneda),
                new SqlParameter("@psProd", _entidad.Producto),
                new SqlParameter("@psNumero", _entidad.Numero),
                new SqlParameter("@piId_Tipo_Identificacion_RUC", _entidad.TipoIdentificacionRUC),
                new SqlParameter("@psIdentificacion_RUC", _entidad.IdentificacionClienteRUC),
                new SqlParameter("@psCod_Tipo_Identificacion_SICC", _entidad.TipoIdentificacionSICC),
                new SqlParameter("@psIdentificacion_SICC", _entidad.IdentificacionSICC),
                new SqlParameter("@pbDesembolso", _entidad.IndDesembolso),
                new SqlParameter("@psInd_Metodo_Insercion", _entidad.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _entidad.CodUsuarioIngreso)
            };

            #endregion

            try
            {
                #region VALIDAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Operaciones_Valida", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    elemento = new RespuestaEntidad();
                    if (!rowsAffected.Tables[0].Rows[0][0].ToString().Contains(","))
                    {
                        elemento.ValorEstado = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                        elemento.ValorEstadoCadena = rowsAffected.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        elemento.ValorEstado = 0;
                        elemento.ValorEstadoCadena = rowsAffected.Tables[0].Rows[0][0].ToString();
                    }

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

        public List<ListaEntidad> GarantiasOperacionesTipoOperacionLista(String conexion, String _filtro)
        {
            List<ListaEntidad> retorno = new List<ListaEntidad>();
            ListaEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psFiltro", _filtro)
            };

            #endregion

            try
            {

                #region LISTA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Tipos_Operaciones_Lista", paramTransaccion);
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

        public List<ListaEntidad> GarantiasOperacionesTipoIdentificacionLista(String conexion, String _filtro)
        {
            List<ListaEntidad> retorno = new List<ListaEntidad>();
            ListaEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psFiltro", _filtro)
            };

            #endregion

            try
            {

                #region LISTA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Tipos_Identificaciones_RUC_SICC_Lista", paramTransaccion);
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

        public GarantiasOperacionesClientesEntidad GarantiasOperacionesConsultaRuc(String conexion, String conexionSief, GarantiasOperacionesClientesEntidad entidad)
        {
            GarantiasOperacionesClientesEntidad retorno = null;
            String query = string.Empty;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Identificacion_RUC", entidad.TipoIdentificacionRUC),
                new SqlParameter("@psIdentificacion_RUC", entidad.IdentificacionClienteRUC)
            };

            #endregion

            try
            {
                #region OBTENER QUERY

                query = transaccionDA.TransaccionConsultaString(conexion, "Operaciones_Consulta_RUC", paramTransaccion);

                #endregion

                #region CONSULTAR SICC

                rowsAffected = transaccionDA.TransaccionConsultaRuc(conexionSief, query);
                if (!rowsAffected.Equals(null))
                {
                    if (rowsAffected.Tables[0].Rows.Count > 0)
                    {
                        retorno = new GarantiasOperacionesClientesEntidad();
                        retorno.TipoIdentificacionRUC = rowsAffected.Tables[0].Rows[0][0].ToString().Trim();
                        retorno.IdentificacionClienteRUC = rowsAffected.Tables[0].Rows[0][1].ToString().Trim();
                        retorno.CategoriaRiesgoDeudor = rowsAffected.Tables[0].Rows[0][2].ToString().Trim();
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

        #region REQUERIMIENTO 1-24493227 GARANTIAS

        #region GARANTIAS RELACIONES

        public RespuestaEntidad GarantiasOperacionesInsertarRelacion(String conexion, String conexionBitacora, GarantiasOperacionesRelacionEntidad _entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Operacion", _entidad.IdOperacion),
                new SqlParameter("@piId_Tipo_Garantia", _entidad.IdTipoGarantia),
                new SqlParameter("@piId_Garantia_Fiduciaria", _entidad.IdGarantiaFiduciaria),
                new SqlParameter("@piId_Garantia_Valor", _entidad.IdGarantiaValor),
                new SqlParameter("@piId_Garantia_Real", _entidad.IdGarantiaReal),
                new SqlParameter("@piId_Tipo_Moneda_Monto_Gravamen", _entidad.IdTipoMonedaGradoGravamen),
                new SqlParameter("@pnMonto_Grado_Gravamen", _entidad.MontoGradoGravamen),
                new SqlParameter("@piId_Grado_Gravamen", _entidad.IdGradoGravamen),
                new SqlParameter("@pdtFecha_Constitucion_Garantia", _entidad.FechaConstitucionGarantia),
                new SqlParameter("@piId_Clase_Garantia_PRT17", _entidad.IdClaseGarantiaPrt17),
                new SqlParameter("@piId_Tenencia_PRT_15", _entidad.IdTenenciaPrt15),
                new SqlParameter("@piId_Tenencia_PRT_17", _entidad.IdTenenciaPrt17),
                new SqlParameter("@pbInd_Deudor_Habita", _entidad.IdDeudorHabita),
                new SqlParameter("@pbInd_Recomendacion_Perito", _entidad.IdIndicadorRecomendacion),
                new SqlParameter("@pbInd_Inspeccion_Garantia", _entidad.IdIndicadorInspeccion),
                new SqlParameter("@piId_Tipo_Mitigador_Riesgo", _entidad.IdTipoMitigadorRiesgo),
                new SqlParameter("@piId_Tipo_Documento_Legal", _entidad.IdTipoDocumentoLegal),
                new SqlParameter("@pnMonto_Mitigador", _entidad.MontoMitigador),
                new SqlParameter("@pnPorcentaje_Aceptacion_BCR", _entidad.PorcentajeAceptBCR),
               //new SqlParameter("@pnPorcentaje_Aceptacion_SUGEF", _entidad.PorcentajeAceptSugef),
                new SqlParameter("@pnPorcentaje_Responsabilidad_SUGEF", _entidad.PorcentajeResponSugef),
                //new SqlParameter("@pbInd_Poliza", _entidad.IdPoliza),
                new SqlParameter("@piPartido", _entidad.IdPartido),
                
                 //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", _entidad.CodUsuarioIngreso),
                new SqlParameter("@pdFecha_Ingreso", null),
                new SqlParameter("@pdFecha_Ultima_Modificacion", null),
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", null),
                new SqlParameter("@psInd_Accion_Registro", null),
                new SqlParameter("@psInd_Metodo_Insercion", _entidad.IndMetodoInsercion),
                new SqlParameter("@piInd_Estado_Replicado", _entidad.IndEstadoReplicado),
                new SqlParameter("@pdtFecha_Prescripcion_Garantia", _entidad.FechaPrescripcionGarantia),
                new SqlParameter("@pnPorcentaje_Aceptacion_No_Terreno_SUGEF", _entidad.PorcentajeAceptNoTerrenoSugef),
                new SqlParameter("@pnPorcentaje_Aceptacion_Terreno_SUGEF", _entidad.PorcentajeAceptTerrenoSugef),
                new SqlParameter("@pnMonto_Mitigador_Calculado", _entidad.MontoMitigadorCalculado),
                new SqlParameter("@pnPorcentaje_Responsabilidad_Legal", _entidad.PorcentajeResponLegal),
                new SqlParameter("@piId_Garantia_Aval", _entidad.IdGarantiaAval),

                //REQUERIMIENTO: RQ_MANT_2016022310547690_Backlog_865
                new SqlParameter("@piId_Fideicomiso", _entidad.IdFideicomiso),
                new SqlParameter("@piId_Tipo_Indicador_Inscripcion", _entidad.IndInscripcion)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Operaciones_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
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

        public RespuestaEntidad GarantiasOperacionesModificarRelacion(String conexion, String conexionBitacora, GarantiasOperacionesRelacionEntidad _entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Operacion", _entidad.IdGarantiaOperacion),                
                new SqlParameter("@piId_Tipo_Moneda_Monto_Gravamen", _entidad.IdTipoMonedaGradoGravamen),
                new SqlParameter("@pnMonto_Grado_Gravamen", _entidad.MontoGradoGravamen),
                new SqlParameter("@piId_Grado_Gravamen", _entidad.IdGradoGravamen),
                new SqlParameter("@pdtFecha_Constitucion_Garantia", _entidad.FechaConstitucionGarantia),
                new SqlParameter("@piId_Clase_Garantia_PRT17", _entidad.IdClaseGarantiaPrt17),
                new SqlParameter("@piId_Tenencia_PRT_15", _entidad.IdTenenciaPrt15),
                new SqlParameter("@piId_Tenencia_PRT_17", _entidad.IdTenenciaPrt17),
                new SqlParameter("@pbInd_Deudor_Habita", _entidad.IdDeudorHabita),
                new SqlParameter("@pbInd_Recomendacion_Perito", _entidad.IdIndicadorRecomendacion),
                new SqlParameter("@pbInd_Inspeccion_Garantia", _entidad.IdIndicadorInspeccion),
                new SqlParameter("@piId_Tipo_Mitigador_Riesgo", _entidad.IdTipoMitigadorRiesgo),
                new SqlParameter("@piId_Tipo_Documento_Legal", _entidad.IdTipoDocumentoLegal),
                new SqlParameter("@pnMonto_Mitigador", _entidad.MontoMitigador),
                new SqlParameter("@pnPorcentaje_Aceptacion_BCR", _entidad.PorcentajeAceptBCR),
               //new SqlParameter("@pnPorcentaje_Aceptacion_SUGEF", _entidad.PorcentajeAceptSugef),
                new SqlParameter("@pnPorcentaje_Responsabilidad_SUGEF", _entidad.PorcentajeResponSugef),
               // new SqlParameter("@pbInd_Poliza", _entidad.IdPoliza),
                new SqlParameter("@piPartido", _entidad.IdPartido),
                new SqlParameter("@psInd_Metodo_Insercion", _entidad.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _entidad.CodUsuarioIngreso),
                new SqlParameter("@piInd_Estado_Replicado", _entidad.IndEstadoReplicado),
                new SqlParameter("@pdtFecha_Prescripcion_Garantia", _entidad.FechaPrescripcionGarantia),
                new SqlParameter("@pnPorcentaje_Aceptacion_No_Terreno_SUGEF", _entidad.PorcentajeAceptNoTerrenoSugef),
                new SqlParameter("@pnPorcentaje_Aceptacion_Terreno_SUGEF", _entidad.PorcentajeAceptTerrenoSugef),
                new SqlParameter("@pnMonto_Mitigador_Calculado", _entidad.MontoMitigadorCalculado),
                new SqlParameter("@pnPorcentaje_Responsabilidad_Legal", _entidad.PorcentajeResponLegal),

                //REQUERIMIENTO: RQ_MANT_2016022310547690_Backlog_865
                new SqlParameter("@piId_Tipo_Indicador_Inscripcion", _entidad.IndInscripcion),
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Operacion", _entidad.IdGarantiaOperacion.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Garantias_Operaciones_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Garantias_Operaciones_Consulta_Detalle", _bitacora);
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

        public RespuestaEntidad GarantiasOperacionesEliminarRelacion(String conexion, String conexionBitacora, GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Operacion", _entidad.IdGarantiaOperacion),
                new SqlParameter("@psCod_Usuario", _entidad.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Operacion", _entidad.IdGarantiaOperacion.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Operaciones_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Operaciones_Consulta_Detalle", _bitacora);
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

        public GarantiasOperacionesRelacionEntidad GarantiasOperacionesConsultarRelacion(String conexion, String conexionBitacora, GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora)
        {
            GarantiasOperacionesRelacionEntidad retorno = new GarantiasOperacionesRelacionEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Operacion", _entidad.IdGarantiaOperacion)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Operacion", _entidad.IdGarantiaOperacion.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Operaciones_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Operaciones_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    //ID OPERACION
                    retorno.IdOperacion = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    //ID TIPO GARANTIA
                    retorno.IdTipoGarantia = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    //ID GARANTIA FIDUCIARIA
                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        retorno.IdGarantiaFiduciaria = int.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    else
                        retorno.IdGarantiaFiduciaria = null;
                    //ID GARANTIA VALOR
                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        retorno.IdGarantiaValor = int.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    else
                        retorno.IdGarantiaValor = null;
                    //ID GARANTIA REAL
                    if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                        retorno.IdGarantiaReal = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    else
                        retorno.IdGarantiaReal = null;
                    //IND ESTADO REPLICADO
                    retorno.IndEstadoReplicado = int.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    //ID TIPO MONEDA MONTO GRAVAMEN
                    if (rowsAffected.Tables[0].Rows[0][6].ToString().Length > 0)
                        retorno.IdTipoMonedaGradoGravamen = int.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());
                    else
                        retorno.IdTipoMonedaGradoGravamen = null;
                    //MONTO GRADO GRAVAMEN
                    retorno.MontoGradoGravamen = decimal.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());
                    //ID GRADO GRAVAMEN
                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        retorno.IdGradoGravamen = int.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    else
                        retorno.IdGradoGravamen = null;
                    //FECHA CONSTITUCION GARANTIA
                    if (rowsAffected.Tables[0].Rows[0][9].ToString().Length > 0)
                        retorno.FechaConstitucionGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][9].ToString());
                    else
                        retorno.FechaConstitucionGarantia = null;
                    //ID CLASE GARANTIA PRT17
                    if (rowsAffected.Tables[0].Rows[0][10].ToString().Length > 0)
                        retorno.IdClaseGarantiaPrt17 = int.Parse(rowsAffected.Tables[0].Rows[0][10].ToString());
                    else
                        retorno.IdClaseGarantiaPrt17 = null;
                    //ID TENENCIA PRT15
                    if (rowsAffected.Tables[0].Rows[0][11].ToString().Length > 0)
                        retorno.IdTenenciaPrt15 = int.Parse(rowsAffected.Tables[0].Rows[0][11].ToString());
                    else
                        retorno.IdTenenciaPrt15 = null;
                    //ID TENENCIA PRT17
                    if (rowsAffected.Tables[0].Rows[0][12].ToString().Length > 0)
                        retorno.IdTenenciaPrt17 = int.Parse(rowsAffected.Tables[0].Rows[0][12].ToString());
                    else
                        retorno.IdTenenciaPrt17 = null;
                    //ID DEUDOR HABITA
                    if ((!rowsAffected.Tables[0].Rows[0].IsNull(13)) && (bool.Parse(rowsAffected.Tables[0].Rows[0][13].ToString())))
                        retorno.IdDeudorHabita = 1;
                    else
                        retorno.IdDeudorHabita = 0;
                    //IND RECOMENDACION PERITO
                    if ((!rowsAffected.Tables[0].Rows[0].IsNull(14)) && (bool.Parse(rowsAffected.Tables[0].Rows[0][14].ToString())))
                        retorno.IdIndicadorRecomendacion = 1;
                    else
                        retorno.IdIndicadorRecomendacion = 0;
                    //IND INSPECCION GARANTIA
                    if ((!rowsAffected.Tables[0].Rows[0].IsNull(15)) && (bool.Parse(rowsAffected.Tables[0].Rows[0][15].ToString())))
                        retorno.IdIndicadorInspeccion = 1;
                    else
                        retorno.IdIndicadorInspeccion = 0;
                    //ID TIPO MITIGADOR RIESGO
                    if (rowsAffected.Tables[0].Rows[0][16].ToString().Length > 0)
                        retorno.IdTipoMitigadorRiesgo = int.Parse(rowsAffected.Tables[0].Rows[0][16].ToString());
                    else
                        retorno.IdTipoMitigadorRiesgo = null;
                    //ID TIPO DOCUMENTO LEGAL
                    if (rowsAffected.Tables[0].Rows[0][17].ToString().Length > 0)
                        retorno.IdTipoDocumentoLegal = int.Parse(rowsAffected.Tables[0].Rows[0][17].ToString());
                    else
                        retorno.IdTipoDocumentoLegal = null;
                    //MONTO MITIGADOR
                    if (rowsAffected.Tables[0].Rows[0][18].ToString().Length > 0)
                        retorno.MontoMitigador = decimal.Parse(rowsAffected.Tables[0].Rows[0][18].ToString());
                    else
                        retorno.MontoMitigador = null;

                    //MONTO MITIGADOR CALCULADO cloaiza 28/10/15 B16S03
                    if (rowsAffected.Tables[0].Rows[0][19].ToString().Length > 0)
                        retorno.MontoMitigadorCalculado = decimal.Parse(rowsAffected.Tables[0].Rows[0][19].ToString());
                    else
                        retorno.MontoMitigadorCalculado = null;

                    //PORCENTAJE ACEPTACION BCR 
                    retorno.PorcentajeAceptBCR = decimal.Parse(rowsAffected.Tables[0].Rows[0][20].ToString());

                    //PORCENTAJE ACEPTACION SUGEF cloaiza 28/10/15 B16S03
                    // retorno.PorcentajeAceptSugef = decimal.Parse(rowsAffected.Tables[0].Rows[0][20].ToString());

                    //PORCENTAJE ACEPTACION NO TERRENO SUGEF cloaiza 28/10/15 B16S03
                    if (rowsAffected.Tables[0].Rows[0][21].ToString().Length > 0)
                        retorno.PorcentajeAceptNoTerrenoSugef = decimal.Parse(rowsAffected.Tables[0].Rows[0][21].ToString());
                    else
                        retorno.PorcentajeAceptNoTerrenoSugef = null;

                    //PORCENTAJE ACEPTACION TERRENO SUGEF cloaiza 28/10/15 B16S03
                    if (rowsAffected.Tables[0].Rows[0][22].ToString().Length > 0)
                        retorno.PorcentajeAceptTerrenoSugef = decimal.Parse(rowsAffected.Tables[0].Rows[0][22].ToString());
                    else
                        retorno.PorcentajeAceptTerrenoSugef = null;

                    //PORCENTAJE RESPONSABILIDAD SUGEF
                    if (rowsAffected.Tables[0].Rows[0][23].ToString().Length > 0)
                        retorno.PorcentajeResponSugef = decimal.Parse(rowsAffected.Tables[0].Rows[0][23].ToString());
                    else
                        retorno.PorcentajeResponSugef = null;
                    //PORCENTAJE RESPONSABILIDAD LEGAL cloaiza 28/10/15 B16S03
                    if (rowsAffected.Tables[0].Rows[0][24].ToString().Length > 0)
                        retorno.PorcentajeResponLegal = decimal.Parse(rowsAffected.Tables[0].Rows[0][24].ToString());
                    else
                        retorno.PorcentajeResponLegal = null;

                    //ID POLIZA
                    /*if (bool.Parse(rowsAffected.Tables[0].Rows[0][22].ToString()))
                        retorno.IdPoliza = 1;
                    else
                        retorno.IdPoliza = 0;*/

                    //ID PARTIDO
                    if (rowsAffected.Tables[0].Rows[0][25].ToString().Length > 0)
                        retorno.IdPartido = int.Parse(rowsAffected.Tables[0].Rows[0][25].ToString());
                    else
                        retorno.IdPartido = null;
                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][26].ToString();
                    if (rowsAffected.Tables[0].Rows[0][27].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][27].ToString());
                    else
                        retorno.FechaIngreso = null;
                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][28].ToString();
                    if (rowsAffected.Tables[0].Rows[0][29].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][29].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;
                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][30].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][31].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][32].ToString();
                    
                    //ID FIDEICOMISO
                    if (rowsAffected.Tables[0].Rows[0][33].ToString().Length > 0)
                        retorno.IdFideicomiso = int.Parse(rowsAffected.Tables[0].Rows[0][33].ToString());
                    else
                        retorno.IdFideicomiso = null;

                    //ID GARANTIA AVAL
                    if (rowsAffected.Tables[0].Rows[0][34].ToString().Length > 0)
                        retorno.IdGarantiaAval = int.Parse(rowsAffected.Tables[0].Rows[0][34].ToString());
                    else
                        retorno.IdGarantiaAval = null;

                    //ID  TIPO INDICADOR INSCRIPCION
                    if (rowsAffected.Tables[0].Rows[0][35].ToString().Length > 0)
                        retorno.IndInscripcion = int.Parse(rowsAffected.Tables[0].Rows[0][35].ToString());
                    else
                        retorno.IndInscripcion = null;


                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GarantiasOperacionesEntidad> GarantiasOperacionesConsultarGarantiasGrid(String conexion, int IdGarantiaOperacion)
        {
            List<GarantiasOperacionesEntidad> retorno = new List<GarantiasOperacionesEntidad>();
            GarantiasOperacionesEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Operacion", IdGarantiaOperacion)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Operaciones_Consulta_Grid_Interno", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    if (rowsAffected.Tables[0].Rows.Count != 0)
                    {
                        foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                        {
                            elemento = new GarantiasOperacionesEntidad();
                            elemento.IdGarantiaOperacion = int.Parse(dr[0].ToString());
                            elemento.DesTipoOperacion = dr[1].ToString();
                            elemento.IdGarantia = dr[2].ToString();
                            elemento.DesEstadoReplicado = dr[3].ToString();
                            elemento.DesTipoBien = dr[4].ToString();
                            elemento.DesClaseTipoBien = dr[5].ToString();

                            retorno.Add(elemento);
                        }
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

        public GarantiasOperacionesRelacionEntidad OperacionesGarantiasRealesBusqueda(String conexion, GarantiasOperacionesRelacionEntidad _entidad)
        {
            GarantiasOperacionesRelacionEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Clase_Aeronave", _entidad.IdClaseAeronave),
                new SqlParameter("@piId_Clase_Buque", _entidad.IdClaseBuque),
                new SqlParameter("@piId_Clase_Tipo_Bien", _entidad.IdClaseTipoBien),
                new SqlParameter("@piId_Clase_Vehiculo", _entidad.IdClaseVehiculo),
                new SqlParameter("@piId_Codigo_Duplicado", _entidad.IdCodigoDuplicado),
                new SqlParameter("@piId_Codigo_Horizontalidad", _entidad.IdCodigoHorizontalidad),
                new SqlParameter("@piId_Provincia", _entidad.IdProvincia),
                new SqlParameter("@piId_Tipo_Bien", _entidad.IdTipoBien),
                new SqlParameter("@psCodigo_Bien", _entidad.CodigoBien),
                new SqlParameter("@piFormato_Identificacion_Vehiculo", _entidad.IdFormatoIdentificacionVehiculo)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Operaciones_Garantias_Reales_Busqueda", paramTransaccion);
                if (rowsAffected.Tables[0].Rows.Count != 0)
                {
                    elemento = new GarantiasOperacionesRelacionEntidad();
                    elemento.IdGarantiaReal = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    //ID TIPO MONEDA
                    elemento.TipoMoneda = rowsAffected.Tables[0].Rows[0][1].ToString();
                    //MONTO ULTIMA TASACION TERRENO
                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        elemento.MontoUltimaTasacionTerreno = decimal.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    else
                        elemento.MontoUltimaTasacionTerreno = null;
                    //MONTO ULTIMA TASACION NO TERRENO
                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        elemento.MontoUltimaTasacionNoTerreno = decimal.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    else
                        elemento.MontoUltimaTasacionNoTerreno = null;
                    //MONTO TOTAL ULTIMA TASACION
                    if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                        elemento.MontoTotalUltimaTasacion = decimal.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    else
                        elemento.MontoTotalUltimaTasacion = null;
                    //TIPO LIQUIDEZ
                    elemento.TipoLiquidez = rowsAffected.Tables[0].Rows[0][5].ToString();
                    //FECHA ULTIMA TASACION GARANTIA
                    if (rowsAffected.Tables[0].Rows[0][6].ToString().Length > 0)
                        elemento.FechaUltimaTasacionGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][6].ToString().Trim());
                    else
                        elemento.FechaUltimaTasacionGarantia = null;
                    //FECHA ULTIMO SEGUIMIENTO GARANTIA
                    if (rowsAffected.Tables[0].Rows[0][7].ToString().Length > 0)
                        elemento.FechaUltimoSeguimientoGarantia = DateTime.Parse(rowsAffected.Tables[0].Rows[0][7].ToString().Trim());
                    else
                        elemento.FechaUltimoSeguimientoGarantia = null;
                    //MONTO VALOR TOTAL CEDULA
                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        elemento.MontoValorTotalCedula = decimal.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    else
                        elemento.MontoValorTotalCedula = null;
                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GarantiasOperacionesRelacionEntidad OperacionesGarantiasValoresBusqueda(String conexion, GarantiasOperacionesRelacionEntidad _entidad)
        {
            GarantiasOperacionesRelacionEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Valor", _entidad.IdTipoValor),
                new SqlParameter("@piId_Tipo_Instrumento", _entidad.IdTipoInstrumento),
                new SqlParameter("@piId_Instrumento", _entidad.IdInstrumento),
                new SqlParameter("@piId_Emisor", _entidad.IdEmisor),
                new SqlParameter("@psISIN", _entidad.ISIN),
                new SqlParameter("@psSerie", _entidad.Serie),
                new SqlParameter("@psCod_Garantia_BCR", _entidad.CodGarantiaBCR),
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Operaciones_Garantias_Valores_Busqueda", paramTransaccion);
                if (rowsAffected.Tables[0].Rows.Count != 0)
                {
                    elemento = new GarantiasOperacionesRelacionEntidad();
                    elemento.IdGarantiaValor = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    //TIPO MONEDA VALOR FACIAL
                    elemento.TipoMonedaValorFacial = rowsAffected.Tables[0].Rows[0][1].ToString();
                    //MONTO VALOR FACIAL
                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        elemento.MontoValorFacial = Decimal.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    else
                        elemento.MontoValorFacial = null;
                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GarantiasOperacionesRelacionEntidad OperacionesGarantiasFiduciariasBusqueda(String conexion, GarantiasOperacionesRelacionEntidad _entidad)
        {
            GarantiasOperacionesRelacionEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Identificacion_RUC", _entidad.IdTipoIdentificacionRUC),
                new SqlParameter("@psIdentificacion", _entidad.IdentificacionRUC),
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Operaciones_Garantias_Fiduciarias_Busqueda", paramTransaccion);
                if (rowsAffected.Tables[0].Rows.Count != 0)
                {
                    elemento = new GarantiasOperacionesRelacionEntidad();
                    elemento.IdGarantiaFiduciaria = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    //IDENTIFICACION SICC
                    elemento.IdentificacionSICC = rowsAffected.Tables[0].Rows[0][1].ToString();
                    //SALARIO NETO FIADOR
                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        elemento.SalarioNetoFiador = decimal.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    else
                        elemento.SalarioNetoFiador = null;
                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GarantiasOperacionesRelacionEntidad OperacionesGarantiasAvalesBusqueda(String conexion, GarantiasOperacionesRelacionEntidad _entidad)
        {
            GarantiasOperacionesRelacionEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Aval", _entidad.IdTipoAval),
                new SqlParameter("@psNumero_Aval", _entidad.NumeroAval),
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Operaciones_Garantias_Avales_Busqueda", paramTransaccion);
                if (rowsAffected.Tables[0].Rows.Count != 0)
                {
                    elemento = new GarantiasOperacionesRelacionEntidad();
                    elemento.IdGarantiaAval= int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    //TIPO AVAL
                    elemento.IdTipoAval = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    //NUMERO AVAL
                    elemento.NumeroAval = rowsAffected.Tables[0].Rows[0][2].ToString();

                    ////TIPO IDENTIFICACION
                    //elemento.IdTipoPersonaAvalista = int.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    //DESCRIPCION TIPO IDENTIFICACION
                    elemento.DesTipoPersonaAvalista = rowsAffected.Tables[0].Rows[0][3].ToString();

                    //MONTO AVALADO
                    if (rowsAffected.Tables[0].Rows[0][4].ToString().Length > 0)
                        elemento.MontoAvalado = decimal.Parse(rowsAffected.Tables[0].Rows[0][5].ToString());
                    else
                        elemento.MontoAvalado = null;

                    //IDENTIFICACION AVALISTA
                    elemento.CodAvalista = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());

                }

                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ListaEntidad> GarantiasOperacionesFechaVencimientoGarantia(String conexion, String _filtro)
        {
            List<ListaEntidad> retorno = new List<ListaEntidad>();
            ListaEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psFiltro", _filtro)
            };

            #endregion

            try
            {

                #region LISTA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Operaciones_Fecha_Vencimiento_Garantia", paramTransaccion);
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

        public List<ListaEntidad> GarantiasOperacionesFechaPrescripcionGarantia(String conexion, String _filtro)
        {
            List<ListaEntidad> retorno = new List<ListaEntidad>();
            ListaEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psFiltro", _filtro)
            };

            #endregion

            try
            {

                #region LISTA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Operaciones_Fecha_Prescripcion_Garantia", paramTransaccion);
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

        #region RQ_MANT_2016022310547690_Backlog_865

        #region RELACION GARANTIA FIDEICOMISO

        public GarantiasOperacionesRelacionEntidad OperacionesGarantiasFideicomisosBusqueda(String conexion, GarantiasOperacionesRelacionEntidad _entidad)
        {
            GarantiasOperacionesRelacionEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@psId_Fideicomiso_BCR", _entidad.IdFideicomisoBCR)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Operaciones_Garantias_Fideicomisos_Busqueda", paramTransaccion);
                if (rowsAffected.Tables[0].Rows.Count != 0)
                {
                    elemento = new GarantiasOperacionesRelacionEntidad();
                    elemento.IdFideicomiso = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());

                    //TIPO MONEDA VALOR NOMINAL
                    elemento.DesTipoMonedaValorNominal = rowsAffected.Tables[0].Rows[0][2].ToString();

                    //VALOR NOMINAL
                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        elemento.ValorNominal = decimal.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    else
                        elemento.ValorNominal = null;
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

        #endregion

        #endregion

        public RespuestaEntidad GarantiasOperacionesEliminar(String conexion, String conexionBitacora, GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Operacion", _entidad.IdGarantiaOperacion),
                new SqlParameter("@psCod_Usuario", _entidad.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Operacion", _entidad.IdGarantiaOperacion.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Operaciones_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Operaciones_Consulta_Detalle", _bitacora);
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

        public GarantiasOperacionesEntidad GarantiasOperacionesConsultarDetalle(String conexion, String conexionBitacora, GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora)
        {
            GarantiasOperacionesEntidad retorno = new GarantiasOperacionesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Operacion", _entidad.IdGarantiaOperacion)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Operacion", _entidad.IdGarantiaOperacion.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Operaciones_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Operaciones_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    //ID OPERACION
                    retorno.IdGarantiaOperacion = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    //ID TIPO OPERACION
                    retorno.IdTipoOperacion = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    //CONTA
                    retorno.Conta = rowsAffected.Tables[0].Rows[0][2].ToString();
                    //OFICINA
                    retorno.Oficina = rowsAffected.Tables[0].Rows[0][3].ToString();
                    //MONEDA
                    retorno.Moneda = rowsAffected.Tables[0].Rows[0][4].ToString();
                    //PRODUCTO
                    retorno.Producto = rowsAffected.Tables[0].Rows[0][5].ToString();
                    //NUMERO
                    retorno.Numero = rowsAffected.Tables[0].Rows[0][6].ToString();
                    //TIPO IDENTIFICACION RUC
                    if (rowsAffected.Tables[0].Rows[0][7].ToString().Length > 0)
                        retorno.TipoIdentificacionRUC = rowsAffected.Tables[0].Rows[0][7].ToString();
                    else
                        retorno.TipoIdentificacionRUC = null;
                    //IDENTIFICACION CLIENTE RUC
                    retorno.IdentificacionClienteRUC = rowsAffected.Tables[0].Rows[0][8].ToString();
                    //TIPO IDENTIFICACION SICC
                    retorno.TipoIdentificacionSICC = rowsAffected.Tables[0].Rows[0][9].ToString();
                    //IDENTIFICACION SICC
                    retorno.IdentificacionSICC = rowsAffected.Tables[0].Rows[0][10].ToString();

                    //IND DESEMBOLSO
                    if (rowsAffected.Tables[0].Rows[0][11].ToString().Length > 0)

                        retorno.IndDesembolso = bool.Parse(rowsAffected.Tables[0].Rows[0][11].ToString()) ? 1 : 0;
                    else
                        retorno.IndDesembolso = 0;

                    //ESTADO REGISTRO OPERACION
                    retorno.DesEstadoReplicado = rowsAffected.Tables[0].Rows[0][12].ToString();

                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][13].ToString();
                    if (rowsAffected.Tables[0].Rows[0][14].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][14].ToString());
                    else
                        retorno.FechaIngreso = null;
                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][15].ToString();

                    if (rowsAffected.Tables[0].Rows[0][16].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][16].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;
                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][17].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][18].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][19].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad GarantiasOperacionesModificar(String conexion, String conexionBitacora, GarantiasOperacionesEntidad _entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Operacion", _entidad.IdGarantiaOperacion),
                new SqlParameter("@psInd_Metodo_Insercion", _entidad.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario", _entidad.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Operacion", _entidad.IdGarantiaOperacion.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Operaciones_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Operaciones_Consulta_Detalle", _bitacora);
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

        #endregion

        #region REQUERIMIENTO 1-24493262 REPLICAS SICC

        public String GarantiasOperacionesCrearTrama(String conexion, String idGarantiaOperacion, String codAccion, String fechaPrescripcion)
        {
            string elemento = string.Empty;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Operacion", idGarantiaOperacion),
                new SqlParameter("@psCod_Accion", codAccion),
                new SqlParameter("@psFecha_Prescripcion", fechaPrescripcion)
            };

            #endregion

            try
            {
                #region CREAR TRAMA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Operaciones_Trama", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = dr[0].ToString();
                    }
                }
                return elemento;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad GarantiasOperacionesEstadoReplica(String conexion, String idGarantiaOperacion, int indEstadoReplicado, String codUsuario, DateTime? _fechaPrescripcionActualizada)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Operacion", idGarantiaOperacion),
                new SqlParameter("@piInd_Estado_Replicado", indEstadoReplicado),
                new SqlParameter("@pdtFecha_Prescripcion_Garantia", _fechaPrescripcionActualizada),                
                new SqlParameter("@psCod_Usuario", codUsuario)
                
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, "Garantias_Operaciones_Estado_Replica", paramTransaccion);
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

        #endregion

        #region Relacion Avales

        public List<ListaEntidad> CategoriasCalificacionesTiposMitigadoresRiesgos(String conexion, String _filtro, String tipoGarantia)
        {
            List<ListaEntidad> retorno = new List<ListaEntidad>();
            ListaEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Garantia", tipoGarantia),
                new SqlParameter("@piId_Tipo_Mitigador_Riesgo", _filtro)
            };

            #endregion

            try
            {

                #region LISTA

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Operaciones_Porcentaje_Aceptacion_Sugef", paramTransaccion);
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

        #endregion
        #endregion

        #region GRAVAMENES GARANTIAS

        public List<GarantiasGravemenesEntidad> GarantiasGravamenesConsultarGridInterno(String conexion, GarantiasGravemenesEntidad entidad)
        {
            List<GarantiasGravemenesEntidad> retorno = new List<GarantiasGravemenesEntidad>();
            GarantiasGravemenesEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real", entidad.IdGarantiaReal),
                new SqlParameter("@piId_Garantia_Valor", entidad.IdGarantiaValor)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Gravamenes_Consulta_Grid_Interno", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasGravemenesEntidad();
                        elemento.IdGravamen = int.Parse(dr[0].ToString());
                        elemento.DesGradoGravamen = dr[2].ToString();
                        elemento.DesTipoMonedaMontoGravamen = dr[3].ToString();
                        if (dr[4].ToString().Length > 0)
                            elemento.SaldoGradoGravamen = decimal.Parse(dr[4].ToString());
                        else
                            elemento.SaldoGradoGravamen = null;
                        elemento.EntidadAcreedora = dr[5].ToString();
                        elemento.Id_Visible = 1;

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

        public RespuestaEntidad GarantiasGravamenesInsertar(String conexion, String conexionBitacora, GarantiasGravemenesEntidad entidad, BitacorasEntidad bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Gravamen", entidad.IdGravamen),
                new SqlParameter("@piId_Garantia_Real", entidad.IdGarantiaReal),
                new SqlParameter("@piId_Garantia_Valor", entidad.IdGarantiaValor),
                new SqlParameter("@piId_Grado_Gravamen", entidad.IdGradoGravamen),
                new SqlParameter("@piId_Tipo_Moneda_Monto_Gravamen", entidad.IdTipoMonedaMontoGravamen),
                new SqlParameter("@pdSaldo_Grado_Gravamen", entidad.SaldoGradoGravamen),
                new SqlParameter("@psEntidad_Acreedora", entidad.EntidadAcreedora),
                new SqlParameter("@psInd_Metodo_Insercion", entidad.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario_Ingreso", entidad.CodUsuarioIngreso),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@pdtFecha_Ingreso", null),
                new SqlParameter("@pdtFecha_Ultima_Modificacion", null),
                new SqlParameter("@psCod_Usuario_Ultima_Modificacion", null),
                new SqlParameter("@psInd_Accion_Registro", null)
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Gravamenes_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, bitacora);
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

        public RespuestaEntidad GarantiasGravamenesEliminar(String conexion, String conexionBitacora, GarantiasGravemenesEntidad entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Gravamen", entidad.IdGravamen),                
                new SqlParameter("@psCod_Usuario", entidad.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Gravamen", entidad.IdGravamen.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Gravamenes_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Gravamenes_Consulta_Detalle", _bitacora);
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

        public GarantiasGravemenesEntidad GarantiasGravamenesConsultaDetalle(String conexion, String conexionBitacora, GarantiasGravemenesEntidad entidad, BitacorasEntidad _bitacora)
        {
            GarantiasGravemenesEntidad retorno = new GarantiasGravemenesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Gravamen", entidad.IdGravamen)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Gravamen", entidad.IdGravamen.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Gravamenes_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Gravamenes_Consulta_Detalle", _bitacora);

                if (!rowsAffected.Equals(null))
                {
                    retorno.IdGravamen = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.IdGradoGravamen = int.Parse(rowsAffected.Tables[0].Rows[0][2].ToString());
                    retorno.IdTipoMonedaMontoGravamen = int.Parse(rowsAffected.Tables[0].Rows[0][3].ToString());
                    retorno.SaldoGradoGravamen = decimal.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    retorno.EntidadAcreedora = rowsAffected.Tables[0].Rows[0][5].ToString();
                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][6].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad GarantiasGravamenesModificar(String conexion, String conexionBitacora, GarantiasGravemenesEntidad entidad, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Gravamen", entidad.IdGravamen),
                new SqlParameter("@piId_Garantia_Real", entidad.IdGarantiaReal),
                new SqlParameter("@piId_Garantia_Valor", entidad.IdGarantiaValor),
                new SqlParameter("@piId_Grado_Gravamen", entidad.IdGradoGravamen),
                new SqlParameter("@piId_Tipo_Moneda_Monto_Gravamen", entidad.IdTipoMonedaMontoGravamen),
                new SqlParameter("@pdSaldo_Grado_Gravamen", entidad.SaldoGradoGravamen),
                new SqlParameter("@psEntidad_Acreedora", entidad.EntidadAcreedora),
                new SqlParameter("@psInd_Metodo_Insercion", entidad.IndMetodoInsercion),
                new SqlParameter("@psCod_Usuario_Modificacion", entidad.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Gravamen", entidad.IdGravamen.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Gravamenes_Actualiza", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Gravamenes_Consulta_Detalle", _bitacora);

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

        #endregion

        #region INSCRIPCION GARANTIAS REALES

        public List<InscripcionGarantiasRealesEntidad> InscripcionGarantiasRealesConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<InscripcionGarantiasRealesEntidad> retorno = new List<InscripcionGarantiasRealesEntidad>();
            InscripcionGarantiasRealesEntidad elemento;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Reales_Inscripciones_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new InscripcionGarantiasRealesEntidad();
                        elemento.IdInscripcionGarantiaReal = int.Parse(dr[0].ToString());
                        elemento.DesNumeroOperacion = dr[5].ToString();
                        elemento.NumeroBien = dr[2].ToString();
                        elemento.DesTipoBien = dr[3].ToString();
                        elemento.DesIndInscripcion = dr[7].ToString();

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

        public RespuestaEntidad InscripcionGarantiasRealesEliminar(String conexion, String conexionBitacora, InscripcionGarantiasRealesEntidad _reales, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real_Inscripcion", _reales.IdInscripcionGarantiaReal),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", _reales.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Inscripcion", _reales.IdInscripcionGarantiaReal.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Reales_Inscripciones_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Reales_Inscripciones_Consulta_Detalle", _bitacora);
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

        public int InscripcionGarantiasRealesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

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

                value = transaccionDA.TransaccionRows(conexion, "Garantias_Reales_Inscripciones_Total_Filas", paramTransaccion);
                return value;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GarantiasOperacionesEntidad> InscripcionGarantiasRealesOperacionesConsultar(String conexion, GarantiasRealesEntidad entidad)
        {
            List<GarantiasOperacionesEntidad> retorno = new List<GarantiasOperacionesEntidad>();
            GarantiasOperacionesEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Bien", entidad.IdTipoBien),
                new SqlParameter("@piId_Clase_Tipo_Bien", entidad.IdClaseTipoBien),
                new SqlParameter("@piId_Provincia", entidad.IdProvincia),
                new SqlParameter("@piId_Codigo_Horizontalidad", entidad.IdCodigoHorizontalidad),
                new SqlParameter("@piId_Codigo_Duplicado", entidad.IdCodigoDuplicado),
                new SqlParameter("@piId_Clase_Buque", entidad.IdClaseBuque),
                new SqlParameter("@piId_Clase_Aeronave", entidad.IdClaseAeronave),
                new SqlParameter("@piId_Clase_Vehiculo", entidad.IdClaseVehiculo),
                new SqlParameter("@piFormato_Identificacion_Vehiculo", entidad.FormatoIdentificacionVehiculo),
                new SqlParameter("@psCodigo_Bien", entidad.CodBien)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Inscripcion_Garantia_Operacion_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasOperacionesEntidad();
                        elemento.IdGarantiaOperacion = int.Parse(dr[0].ToString());
                        elemento.Operacion = int.Parse(dr[1].ToString());
                        elemento.DesNumeroOperacion = dr[2].ToString();
                        elemento.DesTipoOperacion = dr[3].ToString();

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

        public RespuestaEntidad InscripcionGarantiasRealesInsertar(String conexion, String conexionBitacora, InscripcionGarantiasRealesEntidad _inscripcionGarantias, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {              
                new SqlParameter("@piId_Garantia_Operacion", _inscripcionGarantias.IdGarantiaOperacion),
                new SqlParameter("@piId_Tipo_Indicador_Inscripcion", _inscripcionGarantias.IndInscripcion),
                new SqlParameter("@pdtFecha_Anotacion", _inscripcionGarantias.FechaAnotacion),
                new SqlParameter("@pdtFecha_Inscripcion", _inscripcionGarantias.FechaInscripcion),
                new SqlParameter("@psTomo", _inscripcionGarantias.Tomo),
                new SqlParameter("@psFolio", _inscripcionGarantias.Folio),
                new SqlParameter("@psAsiento", _inscripcionGarantias.Asiento),
                new SqlParameter("@psSecuencia", _inscripcionGarantias.Secuencia),
                new SqlParameter("@psSubsecuencia", _inscripcionGarantias.SubSecuencia),
                new SqlParameter("@psConsecutivo", _inscripcionGarantias.Consecutivo),
                new SqlParameter("@piId_Notario", _inscripcionGarantias.IdAbogado),
                new SqlParameter("@psComentario", _inscripcionGarantias.Comentario),
                new SqlParameter("@psCod_Usuario", _inscripcionGarantias.CodUsuarioIngreso),
                new SqlParameter("@psInd_Metodo_Insercion", _inscripcionGarantias.IndMetodoInsercion),
                
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Reales_Inscripciones_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
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

        public InscripcionGarantiasRealesEntidad InscripcionGarantiasRealesConsultarDetalle(String conexion, String conexionBitacora, InscripcionGarantiasRealesEntidad _inscripcionGarantias, BitacorasEntidad _bitacora)
        {
            InscripcionGarantiasRealesEntidad retorno = new InscripcionGarantiasRealesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real_Inscripcion", _inscripcionGarantias.IdInscripcionGarantiaReal)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Inscripcion", _inscripcionGarantias.IdInscripcionGarantiaReal.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Reales_Inscripciones_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Reales_Inscripciones_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdInscripcionGarantiaReal = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.IdGarantiaReal = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    retorno.IdOperacion = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());
                    retorno.IndInscripcion = int.Parse(rowsAffected.Tables[0].Rows[0][6].ToString());

                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        retorno.FechaAnotacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][8].ToString());
                    else
                        retorno.FechaAnotacion = null;

                    if (rowsAffected.Tables[0].Rows[0][9].ToString().Length > 0)
                        retorno.FechaInscripcion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][9].ToString());
                    else
                        retorno.FechaInscripcion = null;

                    if (rowsAffected.Tables[0].Rows[0][10].ToString().Length > 0)
                        retorno.Partido = rowsAffected.Tables[0].Rows[0][10].ToString();
                    else
                        retorno.Partido = null;

                    if (rowsAffected.Tables[0].Rows[0][11].ToString().Length > 0)
                        retorno.Tomo = rowsAffected.Tables[0].Rows[0][11].ToString();
                    else
                        retorno.Tomo = null;

                    if (rowsAffected.Tables[0].Rows[0][12].ToString().Length > 0)
                        retorno.Folio = rowsAffected.Tables[0].Rows[0][12].ToString();
                    else
                        retorno.Folio = null;

                    if (rowsAffected.Tables[0].Rows[0][13].ToString().Length > 0)
                        retorno.Asiento = rowsAffected.Tables[0].Rows[0][13].ToString();
                    else
                        retorno.Asiento = null;

                    if (rowsAffected.Tables[0].Rows[0][14].ToString().Length > 0)
                        retorno.Secuencia = rowsAffected.Tables[0].Rows[0][14].ToString();
                    else
                        retorno.Secuencia = null;

                    if (rowsAffected.Tables[0].Rows[0][15].ToString().Length > 0)
                        retorno.SubSecuencia = rowsAffected.Tables[0].Rows[0][15].ToString();
                    else
                        retorno.SubSecuencia = null;

                    if (rowsAffected.Tables[0].Rows[0][16].ToString().Length > 0)
                        retorno.Consecutivo = rowsAffected.Tables[0].Rows[0][16].ToString();
                    else
                        retorno.Consecutivo = null;

                    if (rowsAffected.Tables[0].Rows[0][5].ToString().Length > 0)
                        retorno.DesNumeroOperacion = rowsAffected.Tables[0].Rows[0][5].ToString();
                    else
                        retorno.DesNumeroOperacion = null;

                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        retorno.NumeroBien = rowsAffected.Tables[0].Rows[0][2].ToString();
                    else
                        retorno.NumeroBien = null;

                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        retorno.DesTipoBien = rowsAffected.Tables[0].Rows[0][3].ToString();
                    else
                        retorno.DesTipoBien = null;

                    if (rowsAffected.Tables[0].Rows[0][7].ToString().Length > 0)
                        retorno.DesIndInscripcion = rowsAffected.Tables[0].Rows[0][7].ToString();
                    else
                        retorno.DesIndInscripcion = null;


                    if (rowsAffected.Tables[0].Rows[0][17].ToString().Length > 0)
                        retorno.IdAbogado = int.Parse(rowsAffected.Tables[0].Rows[0][17].ToString());
                    else
                        retorno.IdAbogado = null;


                    if (rowsAffected.Tables[0].Rows[0][19].ToString().Length > 0)
                        retorno.Comentario = rowsAffected.Tables[0].Rows[0][19].ToString();
                    else
                        retorno.Comentario = null;

                    retorno.IdGarantiaOperacion = int.Parse(rowsAffected.Tables[0].Rows[0][20].ToString());

                    //REQUERIMIENTO: 1-24381561
                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][21].ToString();

                    if (rowsAffected.Tables[0].Rows[0][22].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][22].ToString());
                    else
                        retorno.FechaIngreso = null;

                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][23].ToString();

                    if (rowsAffected.Tables[0].Rows[0][24].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][24].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;

                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][25].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][26].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][27].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad InscripcionGarantiasRealesModificar(String conexion, String conexionBitacora, InscripcionGarantiasRealesEntidad _inscripcionGarantias, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {              
                new SqlParameter("@piId_Garantia_Real_Inscripcion", _inscripcionGarantias.IdInscripcionGarantiaReal),
                new SqlParameter("@piId_Garantia_Operacion", _inscripcionGarantias.IdGarantiaOperacion),
                new SqlParameter("@piId_Tipo_Indicador_Inscripcion", _inscripcionGarantias.IndInscripcion),
                new SqlParameter("@pdtFecha_Anotacion", _inscripcionGarantias.FechaAnotacion),
                new SqlParameter("@pdtFecha_Inscripcion", _inscripcionGarantias.FechaInscripcion),
                new SqlParameter("@psTomo", _inscripcionGarantias.Tomo),
                new SqlParameter("@psFolio", _inscripcionGarantias.Folio),
                new SqlParameter("@psAsiento", _inscripcionGarantias.Asiento),
                new SqlParameter("@psSecuencia", _inscripcionGarantias.Secuencia),
                new SqlParameter("@psSubsecuencia", _inscripcionGarantias.SubSecuencia),
                new SqlParameter("@psConsecutivo", _inscripcionGarantias.Consecutivo),
                new SqlParameter("@piId_Notario", _inscripcionGarantias.IdAbogado),
                new SqlParameter("@psComentario", _inscripcionGarantias.Comentario),
                new SqlParameter("@psCod_Usuario", _inscripcionGarantias.CodUsuarioIngreso),
                new SqlParameter("@psInd_Metodo_Insercion", _inscripcionGarantias.IndMetodoInsercion),               
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Inscripcion", _inscripcionGarantias.IdInscripcionGarantiaReal.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Garantias_Reales_Inscripciones_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Garantias_Reales_Inscripciones_Consulta_Detalle", _bitacora);
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

        #endregion

        #region MOBILIARIA GARANTIAS REALES

        public List<MobiliariaGarantiasRealesEntidad> MobiliariaGarantiasRealesConsultar(String conexion, ParametrosConsultaEntidad entidad)
        {
            List<MobiliariaGarantiasRealesEntidad> retorno = new List<MobiliariaGarantiasRealesEntidad>();
            MobiliariaGarantiasRealesEntidad elemento;
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

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Garantias_Reales_Mobiliarias_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new MobiliariaGarantiasRealesEntidad();
                        elemento.IdMobiliariaGarantiaReal = int.Parse(dr[0].ToString());
                        elemento.DesNumeroOperacion = dr[5].ToString();
                        elemento.NumeroBien = dr[2].ToString();
                        elemento.DesTipoBien = dr[3].ToString();
                        elemento.FechaPublicacion = DateTime.Parse(dr[7].ToString());

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

        public RespuestaEntidad MobiliariaGarantiasRealesEliminar(String conexion, String conexionBitacora, MobiliariaGarantiasRealesEntidad _reales, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real_Mobiliaria", _reales.IdMobiliariaGarantiaReal),
                //REQUERIMIENTO: 1-24381561
                new SqlParameter("@psCod_Usuario", _reales.CodUsuarioIngreso)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Mobiliaria", _reales.IdMobiliariaGarantiaReal.ToString()));

            #endregion

            try
            {
                #region ELIMINAR

                rowsAffected = transaccionDA.TransaccionEliminar(conexion, conexionBitacora, "Garantias_Reales_Mobiliarias_Elimina", paramTransaccion, EnumTipoBitacora.ELIMINAR, itemConsulta, "Garantias_Reales_Mobiliarias_Consulta_Detalle", _bitacora);
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

        public int MobiliariaGarantiasRealesTotalFilas(String conexion, ParametrosTotalFilasEntidad entidad)
        {
            int value;

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

                value = transaccionDA.TransaccionRows(conexion, "Garantias_Reales_Mobiliarias_Total_Filas", paramTransaccion);
                return value;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GarantiasOperacionesEntidad> MobiliariaGarantiasRealesOperacionesConsultar(String conexion, GarantiasRealesEntidad entidad)
        {
            List<GarantiasOperacionesEntidad> retorno = new List<GarantiasOperacionesEntidad>();
            GarantiasOperacionesEntidad elemento;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Tipo_Bien", entidad.IdTipoBien),
                new SqlParameter("@piId_Clase_Tipo_Bien", entidad.IdClaseTipoBien),
                new SqlParameter("@piId_Clase_Vehiculo", entidad.IdClaseVehiculo),
                new SqlParameter("@piFormato_Identificacion_Vehiculo", entidad.FormatoIdentificacionVehiculo),
                new SqlParameter("@psCodigo_Bien", entidad.CodBien)
            };

            #endregion

            try
            {
                #region CONSULTAR

                rowsAffected = transaccionDA.TransaccionConsulta(conexion, "Mobiliaria_Garantia_Operacion_Consulta", paramTransaccion);
                if (!rowsAffected.Equals(null))
                {
                    foreach (DataRow dr in rowsAffected.Tables[0].Rows)
                    {
                        elemento = new GarantiasOperacionesEntidad();
                        elemento.IdGarantiaOperacion = int.Parse(dr[0].ToString());
                        elemento.Operacion = int.Parse(dr[1].ToString());
                        elemento.DesNumeroOperacion = dr[2].ToString();
                        elemento.DesTipoOperacion = dr[3].ToString();

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

        public MobiliariaGarantiasRealesEntidad MobiliariaGarantiasRealesConsultarDetalle(String conexion, String conexionBitacora, MobiliariaGarantiasRealesEntidad _mobiliariaGarantias, BitacorasEntidad _bitacora)
        {
            MobiliariaGarantiasRealesEntidad retorno = new MobiliariaGarantiasRealesEntidad();
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {
                new SqlParameter("@piId_Garantia_Real_Mobiliaria", _mobiliariaGarantias.IdMobiliariaGarantiaReal)
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Mobiliaria", _mobiliariaGarantias.IdMobiliariaGarantiaReal.ToString()));

            #endregion

            try
            {
                #region CONSULTAR DETALLE

                rowsAffected = transaccionDA.TransaccionConsultaDetalle(conexion, conexionBitacora, "Garantias_Reales_Mobiliarias_Consulta_Detalle", paramTransaccion, EnumTipoBitacora.CONSULTAR, itemConsulta, "Garantias_Reales_Mobiliarias_Consulta_Detalle", _bitacora);
                if (!rowsAffected.Equals(null))
                {
                    retorno.IdMobiliariaGarantiaReal = int.Parse(rowsAffected.Tables[0].Rows[0][0].ToString());
                    retorno.IdGarantiaReal = int.Parse(rowsAffected.Tables[0].Rows[0][1].ToString());
                    retorno.IdOperacion = int.Parse(rowsAffected.Tables[0].Rows[0][4].ToString());

                    if (rowsAffected.Tables[0].Rows[0][6].ToString().Length > 0)
                        retorno.Consecutivo = rowsAffected.Tables[0].Rows[0][6].ToString();
                    else
                        retorno.Consecutivo = null;

                    if (rowsAffected.Tables[0].Rows[0][7].ToString().Length > 0)
                        retorno.FechaPublicacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][7].ToString());
                    else
                        retorno.FechaPublicacion = null;

                    if (rowsAffected.Tables[0].Rows[0][8].ToString().Length > 0)
                        retorno.Vin = rowsAffected.Tables[0].Rows[0][8].ToString();
                    else
                        retorno.Vin = null;

                    if (rowsAffected.Tables[0].Rows[0][9].ToString().Length > 0)
                        retorno.Motor = rowsAffected.Tables[0].Rows[0][9].ToString();
                    else
                        retorno.Motor = null;

                    if (rowsAffected.Tables[0].Rows[0][10].ToString().Length > 0)
                        retorno.Descripcion = rowsAffected.Tables[0].Rows[0][10].ToString();
                    else
                        retorno.Descripcion = null;

                    if (rowsAffected.Tables[0].Rows[0][5].ToString().Length > 0)
                        retorno.DesNumeroOperacion = rowsAffected.Tables[0].Rows[0][5].ToString();
                    else
                        retorno.DesNumeroOperacion = null;

                    if (rowsAffected.Tables[0].Rows[0][2].ToString().Length > 0)
                        retorno.NumeroBien = rowsAffected.Tables[0].Rows[0][2].ToString();
                    else
                        retorno.NumeroBien = null;

                    if (rowsAffected.Tables[0].Rows[0][3].ToString().Length > 0)
                        retorno.DesTipoBien = rowsAffected.Tables[0].Rows[0][3].ToString();
                    else
                        retorno.DesTipoBien = null;

                    retorno.IdGarantiaOperacion = int.Parse(rowsAffected.Tables[0].Rows[0][11].ToString());

                    //REQUERIMIENTO: 1-24381561
                    retorno.IndMetodoInsercion = rowsAffected.Tables[0].Rows[0][12].ToString();

                    if (rowsAffected.Tables[0].Rows[0][13].ToString().Length > 0)
                        retorno.FechaIngreso = DateTime.Parse(rowsAffected.Tables[0].Rows[0][13].ToString());
                    else
                        retorno.FechaIngreso = null;

                    retorno.CodUsuarioIngreso = rowsAffected.Tables[0].Rows[0][14].ToString();

                    if (rowsAffected.Tables[0].Rows[0][15].ToString().Length > 0)
                        retorno.FechaUltimaModificacion = DateTime.Parse(rowsAffected.Tables[0].Rows[0][15].ToString());
                    else
                        retorno.FechaUltimaModificacion = null;

                    retorno.CodUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][16].ToString();
                    retorno.DesUsuarioIngreso = rowsAffected.Tables[0].Rows[0][17].ToString();
                    retorno.DesUsuarioUltimaModificacion = rowsAffected.Tables[0].Rows[0][18].ToString();
                }

                return retorno;

                #endregion
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RespuestaEntidad MobiliariaGarantiasRealesInsertar(String conexion, String conexionBitacora, MobiliariaGarantiasRealesEntidad _mobiliariaGarantias, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {              
                new SqlParameter("@piId_Garantia_Operacion", _mobiliariaGarantias.IdGarantiaOperacion),
                new SqlParameter("@psConsecutivo", _mobiliariaGarantias.Consecutivo),
                new SqlParameter("@pdtFecha_Publicacion", _mobiliariaGarantias.FechaPublicacion),
                new SqlParameter("@psVIN", _mobiliariaGarantias.Vin),
                new SqlParameter("@psMotor", _mobiliariaGarantias.Motor),
                new SqlParameter("@psDescripcion", _mobiliariaGarantias.Descripcion),
                new SqlParameter("@psCod_Usuario", _mobiliariaGarantias.CodUsuarioIngreso),
                new SqlParameter("@psInd_Metodo_Insercion", _mobiliariaGarantias.IndMetodoInsercion),                
            };

            #endregion

            try
            {
                #region INSERTAR

                rowsAffected = transaccionDA.TransaccionInsertar(conexion, conexionBitacora, "Garantias_Reales_Mobiliarias_Inserta", paramTransaccion, EnumTipoBitacora.INSERTAR, _bitacora);
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

        public RespuestaEntidad MobiliariaGarantiasRealesModificar(String conexion, String conexionBitacora, MobiliariaGarantiasRealesEntidad _mobiliariaGarantias, BitacorasEntidad _bitacora)
        {
            RespuestaEntidad elemento = null;
            DataSet rowsAffected;

            #region PARAMETROS

            SqlParameter[] paramTransaccion = new SqlParameter[]
            {              
                new SqlParameter("@piId_Garantia_Real_Mobiliaria", _mobiliariaGarantias.IdMobiliariaGarantiaReal),
                new SqlParameter("@piId_Garantia_Operacion", _mobiliariaGarantias.IdGarantiaOperacion),
                new SqlParameter("@psConsecutivo", _mobiliariaGarantias.Consecutivo),
                new SqlParameter("@pdtFecha_Publicacion", _mobiliariaGarantias.FechaPublicacion),
                new SqlParameter("@psVIN", _mobiliariaGarantias.Vin),
                new SqlParameter("@psMotor", _mobiliariaGarantias.Motor),
                new SqlParameter("@psDescripcion", _mobiliariaGarantias.Descripcion),
                new SqlParameter("@psCod_Usuario", _mobiliariaGarantias.CodUsuarioIngreso),
                new SqlParameter("@psInd_Metodo_Insercion", _mobiliariaGarantias.IndMetodoInsercion),               
            };

            #endregion

            #region KeyValuePair LIST

            List<KeyValuePair<string, string>> itemConsulta = new List<KeyValuePair<string, string>>();
            itemConsulta.Add(helper.CrearKeyValuePairItem("@piId_Garantia_Real_Mobiliaria", _mobiliariaGarantias.IdMobiliariaGarantiaReal.ToString()));

            #endregion

            try
            {
                #region MODIFICAR

                rowsAffected = transaccionDA.TransaccionModificar(conexion, conexionBitacora, "Garantias_Reales_Mobiliarias_Actualiza", paramTransaccion, EnumTipoBitacora.ACTUALIZAR, itemConsulta, "Garantias_Reales_Mobiliarias_Consulta_Detalle", _bitacora);
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

        #endregion

        #endregion

    }
}

