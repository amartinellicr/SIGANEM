using System;
using System.Web;
using System.Text;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Reflection;
using AjaxControlToolkit;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using ListasWS;
using SesionesWCF;
using GarantiasWS;
using SeguridadWS;

using BCR.SIGANEM.UT;


public partial class wucOperacionesRelacionGarantiaFideicomiso : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region VARIABLES

    private StringBuilder _filtro = null;
    private string _valorReemplazo = string.Empty;
    private MensajesEntidad _mensajesEntidad = new MensajesEntidad();
    private GeneradorControles _generadorControles = new GeneradorControles();

    #endregion

    #region REFERENCIAS

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemGarantiasWS wsGarantias = new SiganemGarantiasWS();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS EDITABLES

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            //ASIGNA LA RUTA DE LOS SERVICIOS WEB DEL WEB.CONFIG
            AsignaWebServicesTypeNames();

            #region MENSAJE INFORMAR

            Button wcBtnAccept = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            wcBtnAccept.Click += new EventHandler(BtnAceptarInformar_Click);

            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

            #region LIMPIAR MENSAJES

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
            {
                this.divBarraMensaje.Visible = false;
            }

            #endregion
        }
        catch
        {
            throw;
        }
    }

    public void LimpiarBarraMensaje()
    {
        this.divBarraMensaje.Visible = false;
    }

    public void LimpiarContenidoControlRelacionGarantiaFideicomiso()
    {

        #region LIMPIAR MENSAJES

        //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
        if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
        {
            this.divBarraMensaje.Visible = false;
        }

        #endregion

        this.txtIdFideicomisoBCR.Text = string.Empty;

        this.txtMontoMitigador.Text = string.Empty;
        this.txtMontoGradoGravamen.Text = string.Empty;
        this.txtPorcentajeResponsabilidadSUGEF.Text = string.Empty;
        this.txtFechaPrescripcionGarantia.Text = string.Empty;
    }

    public void CargarContenidoControlRelacionGarantiaFideicomiso(List<ControlEntidad> controles)
    {
        try
        {
            AsignaWebServicesTypeNames();
            ControlEntidad controlSeleccionado = null;

            #region APARTADO GENERAL

            #region ID FIDEICOMISO BCR

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblIdFideicomisoBCR.ID);
            this.lblIdFideicomisoBCR.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.txtIdFideicomisoBCR.ID);

            //CARGAR AL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, this.txtIdFideicomisoBCR);

            #endregion

            #endregion

            #region APARTADO DETALLE

            #region TIPO MONEDA VALOR NOMINAL

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblTipoMonedaValorNominal.ID);
            this.lblTipoMonedaValorNominal.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.txtTipoMonedaValorNominal.ID);

            //CARGAR AL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, this.txtTipoMonedaValorNominal);

            #endregion

            #region VALOR NOMINAL

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblValorNominal.ID);
            this.lblValorNominal.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.txtValorNominal.ID);

            //CARGAR AL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, this.txtValorNominal);

            #endregion

            #endregion

            #region APARTADO ADICIONALES

            #region CLASE GARANTIA

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblClaseGarantia.ID);
            this.lblClaseGarantia.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.ddlClaseGarantia.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlClaseGarantia, "20");

            #endregion

            #region CODIGO TENENCIA

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblCodigoTenencia.ID);
            this.lblCodigoTenencia.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.ddlCodigoTenencia.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlCodigoTenencia, "11");

            #endregion

            #region GRADO GRAVAMEN

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblGradoGravamen.ID);
            this.lblGradoGravamen.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.ddlGradoGravamen.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlGradoGravamen, "1");

            #endregion

            #region TIPO MONENDA MONTO GRAVEN

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblTipoMonedaMontoGraven.ID);
            this.lblTipoMonedaMontoGraven.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.ddlTipoMonedaMontoGraven.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlTipoMonedaMontoGraven, string.Empty);

            #endregion

            #region MONTO GRADO GRAVAMEN

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblMontoGradoGravamen.ID);
            this.lblMontoGradoGravamen.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.txtMontoGradoGravamen.ID);

            //CARGAR AL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, this.txtMontoGradoGravamen, this.mskMontoGradoGravamen);

            #endregion

            #region FECHA PRESCRIPCION GARANTIA

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblFechaPrescripcionGarantia.ID);
            this.lblFechaPrescripcionGarantia.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.txtFechaPrescripcionGarantia.ID);

            //CARGAR AL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, this.txtFechaPrescripcionGarantia);

            #endregion

            #region INDICADOR INSCRIPCION

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblIndInscripcion.ID);
            this.lblIndInscripcion.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.ddlIndInscripcion.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIndInscripcion, "0");

            #endregion

            #region TIPO MITIGADOR RIESGO

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblTipoMitigadorRiesgo.ID);
            this.lblTipoMitigadorRiesgo.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.ddlTipoMitigadorRiesgo.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlTipoMitigadorRiesgo, "24");

            #endregion

            #region TIPO DOCUMNENTO LEGAL

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblTipoDocumentoLegal.ID);
            this.lblTipoDocumentoLegal.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.ddlTipoDocumentoLegal.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlTipoDocumentoLegal, "23, 24, 25, 26");

            #endregion

            #region MONTO MITIGADOR

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblMontoMitigador.ID);
            this.lblMontoMitigador.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.txtMontoMitigador.ID);

            //CARGAR AL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, this.txtMontoMitigador, this.mskMontoMitigador);

            #endregion

            #region PORCENTAJE RESPONSABILIDAD SUGEF

            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.lblPorcentajeResponsabilidadSUGEF.ID);
            this.lblPorcentajeResponsabilidadSUGEF.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesRelacionGarantiaFideicomiso(controles, this.txtPorcentajeResponsabilidadSUGEF.ID);

            //CARGAR AL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, this.txtPorcentajeResponsabilidadSUGEF, this.mskPorcentajeResponsabilidadSUGEF);

            #endregion

            #endregion

            updRelacionGarantiaFideicomisoPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    public void EstadoControles(bool estado)
    {
        this.txtMontoGradoGravamen.Enabled = estado;
        this.ddlTipoDocumentoLegal.Enabled = estado;
    }

    protected void btnConsultarFideicomiso_Click(object sender, EventArgs e)
    {
        try
        {
            if(!ValidarCaracterEspecial(txtIdFideicomisoBCR.Text)) 
            {
                string[] sesion = valorSesionOculto.Value.Split('|');
                RespuestaConsultaSesion _sesion = wsSesiones.ConsultarSesion(sesion[0]);
                if (_sesion.Codigo == 0)
                {
                    #region ENTIDAD CONSULTA

                    GarantiasOperacionesRelacionEntidad entidadFideicomiso = new GarantiasOperacionesRelacionEntidad();
                    entidadFideicomiso.IdFideicomisoBCR = StaticParameters.RemoveSpecialCharacters(this.txtIdFideicomisoBCR.Text);

                    #endregion

                    GarantiasOperacionesRelacionEntidad consulta = wsGarantias.OperacionesGarantiasFideicomisosBusqueda(entidadFideicomiso);
                    if (consulta != null)
                    {
                        idFideicomisoOculto.Value = consulta.IdFideicomiso.ToString();

                        txtTipoMonedaValorNominal.Text = consulta.DesTipoMonedaValorNominal.ToString();
                        txtValorNominal.Text = consulta.ValorNominal.ToString();

                        //DESHABILITAR LA TABLA GENERALES
                        _generadorControles.Bloquear_Controles(tableGeneral, false);

                        //HABILITAR LA TABLA ADICIONALES
                        tableAdicionales.Disabled = false;

                        //HABILITAR CONTROLES
                        EstadoControles(true);

                        //DESHABILITAR BOTON CONSULTAR
                        btnConsultarFideicomiso.Enabled = false;
                        btnConsultarFideicomiso.CssClass = "botonConsultarRelacionDisabled";
                    }

                    else
                    {
                        //MENSAJE DE ERROR
                        this.InformarBox1_SetConfirmationBoxEvent(null, e, "GAR_1");
                        this.mpeInformarBox.Show();
                    }

                    updRelacionGarantiaFideicomisoPopUpControl.Update();
                }
            }

            else
            {
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_2");
                this.mpeInformarBox.Show();
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    public GarantiasWS.RespuestaEntidad DeControlesAEntidad(int tipoAccion)
    {
        try
        {
            string[] sesion = valorSesionOculto.Value.Split('|');
            GarantiasWS.RespuestaEntidad result = new GarantiasWS.RespuestaEntidad();

            GarantiasOperacionesRelacionEntidad entidadFideicomiso = new GarantiasOperacionesRelacionEntidad();
            entidadFideicomiso.IdOperacion = int.Parse(sesion[3]);
            entidadFideicomiso.IdGarantiaOperacion = int.Parse(sesion[3]);
            entidadFideicomiso.IdFideicomiso = int.Parse(idFideicomisoOculto.Value);
            entidadFideicomiso.IdTipoGarantia = int.Parse(sesion[4]);
 
            #region APARTADO ADICIONALES

            //CLASE GARANTIA
            entidadFideicomiso.IdClaseGarantiaPrt17 = int.Parse(ddlClaseGarantia.SelectedValue);

            //CODIGO TENENCIA
            entidadFideicomiso.IdTenenciaPrt15 = int.Parse(ddlCodigoTenencia.SelectedValue);

            //GRADO GRAVEMEN
            entidadFideicomiso.IdGradoGravamen = int.Parse(ddlGradoGravamen.SelectedValue);

            //TIPO MONEDA MONTO GRAVEN
            entidadFideicomiso.IdTipoMonedaGradoGravamen = int.Parse(ddlTipoMonedaMontoGraven.SelectedValue);

            //MONTO GRADO GRAVAMEN
            entidadFideicomiso.MontoGradoGravamen = decimal.Parse(txtMontoGradoGravamen.Text);

            //IND INSCRIPCION
            entidadFideicomiso.IndInscripcion = int.Parse(ddlIndInscripcion.SelectedValue);

            //TIPO MITIGADOR RIESGO
            entidadFideicomiso.IdTipoMitigadorRiesgo = int.Parse(ddlTipoMitigadorRiesgo.SelectedValue);

            //TIPO DOCUEMNTO LEGAL
            entidadFideicomiso.IdTipoDocumentoLegal = int.Parse(ddlTipoDocumentoLegal.SelectedValue);

            //MONTO MITIGADOR
            if (!string.IsNullOrEmpty(txtMontoMitigador.Text))
                entidadFideicomiso.MontoMitigador = decimal.Parse(txtMontoMitigador.Text);
            else
                entidadFideicomiso.MontoMitigador = null;

            //PORCENTAJE RESPONSABILIDAD SUGEF
            if (!string.IsNullOrEmpty(txtPorcentajeResponsabilidadSUGEF.Text))
                entidadFideicomiso.PorcentajeResponSugef = decimal.Parse(txtPorcentajeResponsabilidadSUGEF.Text);
            else
                entidadFideicomiso.PorcentajeResponSugef = null;

            #endregion

            #region CONTROL DE REGISTRO

            entidadFideicomiso.CodUsuarioIngreso = sesion[2];
            entidadFideicomiso.IndMetodoInsercion = Resources.Resource._metodoInsercion;

            #endregion

            #region DIRECCIONAMIENTO SEGUN EL TIPO DE ACCION

            entidadFideicomiso.FechaConstitucionGarantia = null;
            entidadFideicomiso.FechaPrescripcionGarantia = null;

            switch (tipoAccion)
            {
                case 0:
                    entidadFideicomiso.IndEstadoReplicado = (int)EnumTipoEstadoGarantia.PENDIENTE;
                    result = wsGarantias.GarantiasOperacionesInsertarRelacion(entidadFideicomiso, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));
                    break;

                case 1:
                    entidadFideicomiso.IndEstadoReplicado = ObtenerEstadoGarantia(estadoGarantiaOculto.Value);
                    result = wsGarantias.GarantiasOperacionesModificarRelacion(entidadFideicomiso, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));
                    break;
            }
            #endregion

            return result;
        }

        catch
        {
            throw;
        }
    }

    public void DeEntidadAControles(GarantiasOperacionesRelacionEntidad entidadOperacionRelacion, GarantiasFideicomisosEntidad entidadFideicomisos)
    {
        try
        {
            idFideicomisoOculto.Value = entidadFideicomisos.CodFidecomisoBCR.ToString();

            //Ajuste javendano 2015-01-09
            #region APARTADO ENCABEZADO

            //ID FIDEICOMISO BCR
            txtIdFideicomisoBCR.Text = idFideicomisoOculto.Value;

            #endregion

            #region APARTADO DETALLE

            btnConsultarFideicomiso_Click(null, null);

            #endregion

            #region APARTADO ADICIONALES

            //CLASE GARANTIA
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlClaseGarantia, entidadOperacionRelacion.IdClaseGarantiaPrt17.ToString());
            
            //CODIGO TENENCIA
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlCodigoTenencia, entidadOperacionRelacion.IdTenenciaPrt15.ToString());
            
            //GRADO GRAVEMEN
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlGradoGravamen, entidadOperacionRelacion.IdGradoGravamen.ToString());
            
            //TIPO MONEDA MONTO GRAVEN
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMonedaMontoGraven, entidadOperacionRelacion.IdTipoMonedaGradoGravamen.ToString());
            
            //MONTO GRADO GRAVAMEN
            txtMontoGradoGravamen.Text = entidadOperacionRelacion.MontoGradoGravamen.ToString();

            //IND INSCRIPCION
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIndInscripcion, entidadOperacionRelacion.IndInscripcion.ToString());
            
            //TIPO MITIGADOR RIESGO
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMitigadorRiesgo, entidadOperacionRelacion.IdTipoMitigadorRiesgo.ToString());
            
            //TIPO DOCUEMNTO LEGAL
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoDocumentoLegal, entidadOperacionRelacion.IdTipoDocumentoLegal.ToString());
            
            //MONTO MITIGADOR
            txtMontoMitigador.Text = entidadOperacionRelacion.MontoMitigador.ToString();

            //PORCENTAJE RESPONSABILIDAD SUGEF
            txtPorcentajeResponsabilidadSUGEF.Text = entidadOperacionRelacion.PorcentajeResponSugef.ToString();

            #endregion
        }

        catch
        {
            throw;
        }
    }

    public void DesplegarMensajeError(GarantiasWS.RespuestaEntidad result)
    {
        #region LIMPIAR MENSAJES

        //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
        if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
        {
            this.divBarraMensaje.Visible = false;
        }

        #endregion

        if (result.ValorError.Equals(-1))
        {
            BarraMensaje("SYS_35");
        }
        else
        {
            BarraMensaje("SQL_" + result.ValorError);
        }
    }

    public bool MontoGradoGravemen()
    {
        bool monto = true;
        try
        {
            if (this.txtMontoGradoGravamen.Enabled)
            {
                //MONTO GRADO GRAVAMEN DEBE SER MAYOR CERO
                string Monto = _generadorControles.EliminarErrorMascara(this.txtMontoGradoGravamen.Text);
                monto = _generadorControles.ObtenerComparacion("0,00", Monto, EnumTipoComparacion.MAYOR, TypeCode.Decimal);

                if (monto)
                {
                    //MENSAJE DE ERROR DEL VALOR
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblMontoGradoGravamen.Text, "Mayor a 0");
                    this.mpeInformarBox.Show();
                }
            }

            return monto;
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region EVENTOS DE CONTROLES

    //VALIDACION DE CARACTERES ESPECIALES
    public bool ValidarCaracterEspecial(string texto)
    {
        bool existeCaracter = false;
        //NO SE PERMITEN CARACTERES ESPECIALES
        var regexItem = new Regex("^[a-zA-Z0-9-]*$");

        if (!regexItem.IsMatch(texto))
            existeCaracter = true;

        return existeCaracter;
    }

    #endregion

    #region ENTIDADES

    protected GarantiasWS.BitacorasEntidad AsignarValoresBitacora(EnumTipoBitacora tipo)
    {
        try
        {
            #region ENTIDAD BITACORA

            string[] sesion = valorSesionOculto.Value.Split('|');

            GarantiasWS.BitacorasEntidad bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
            BitacoraFlags bitacoraBanderas = new BitacoraFlags();

            bitacorasEntidad.CodAccion = bitacoraBanderas.TipoBitacoraConsulta(tipo);
            bitacorasEntidad.CodModulo = int.Parse(sesion[1]);
            bitacorasEntidad.CodEmpresa = int.Parse(Resources.Resource._empresa);
            bitacorasEntidad.CodSistema = Resources.Resource._sistema;
            bitacorasEntidad.CodUsuario = sesion[2];

            #endregion

            return bitacorasEntidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS NO EDITABLES

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsListas.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();
            wsSesiones.Url = ConfigurationManager.AppSettings["SesionesWCF"].ToString();
            wsGarantias.Url = ConfigurationManager.AppSettings["GarantiasWS"].ToString();
            wsSeguridad.Url = ConfigurationManager.AppSettings["SeguridadWS"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(ConfigurationManager.AppSettings["Culture"].ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ConfigurationManager.AppSettings["Culture"].ToString());
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    //AGREGA O ELIMINA UN ITEM EN BLANCO
    private void AdministrarBlanco(string ddlNombre, bool agregar)
    {
        try
        {
            bool existeBlanco = false;
            int posicion = 0;
            DropDownList ddl = (DropDownList)this.FindControl(ddlNombre);

            if (ddl != null)
            {
                //VERIFICA SI EXISTE EL ITEM EN BLANCO Y SU POSICION
                for (int c = 0; c < ddl.Items.Count; c++)
                {
                    if (ddl.Items[c].Text.Equals(" "))
                    {
                        existeBlanco = true;
                        posicion = c;
                    }
                }

                //AGREGA UN NUEVO ITEM EN BLANCO
                if ((!existeBlanco) && (agregar))
                {
                    ddl.Items.Add(new ListItem(" ", "-1"));
                    ddl.SelectedValue = "-1";
                }

                //ELIMINA EL ITEM EN BLANCO
                if ((existeBlanco) && (!agregar))
                {
                    ddl.Items.RemoveAt(posicion);
                    ddl.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private ControlEntidad BuscarControlesRelacionGarantiaFideicomiso(List<ControlEntidad> controlEntidad, string nombreControl)
    {
        nombreControl = nombreControl.Replace("txt", "").Replace("ddl", "").Replace("imb", "").Replace("lbl", "").Replace("btn", "");
        ControlEntidad _control = (from control in controlEntidad
                                   where control.NombrePropiedad.Equals(nombreControl)
                                   select control).First();

        return _control;
    }

    private void CargarTextBoxControl(ControlEntidad control, TextBox textBox)
    {
        #region TEXTBOX

        textBox.Text = control.ValorDefecto;
        textBox.ToolTip = String.Concat("Texto ", control.DesColumna);
        textBox.Enabled = bool.Parse(control.IndModificar);
        textBox.Visible = bool.Parse(control.IndVisible);
        textBox.CssClass = control.CssTipo;

        if (!control.LongitudMaxima.Length.Equals(0))
            textBox.Width = Unit.Parse((int.Parse(control.LongitudMaxima) * 9).ToString() + "px");

        if (!control.LongitudMaxima.Length.Equals(0))
            textBox.MaxLength = Int32.Parse(control.LongitudMaxima);

        if (!String.IsNullOrEmpty(control.GrupoValidacion))
            textBox.ValidationGroup = control.GrupoValidacion;

        #endregion
    }

    private void CargarTextBoxControl(ControlEntidad control, TextBox textBox, ImageButton imageButton)
    {
        #region TEXTBOX

        textBox.Text = control.ValorDefecto;
        textBox.ToolTip = String.Concat("Texto ", control.DesColumna);
        textBox.Enabled = bool.Parse(control.IndModificar);
        textBox.Visible = bool.Parse(control.IndVisible);
        textBox.CssClass = control.CssTipo;
        textBox.MaxLength = Int32.Parse("10");

        if (!String.IsNullOrEmpty(control.GrupoValidacion))
            textBox.ValidationGroup = control.GrupoValidacion;

        #endregion

        #region CALENDAR EXTENDER

        imageButton.ToolTip = "Click para abrir el Calendario ";
        imageButton.Enabled = bool.Parse(control.IndModificar);
        imageButton.Visible = bool.Parse(control.IndVisible);
        imageButton.CausesValidation = false;

        if (imageButton.Enabled)
            imageButton.ImageUrl = "~/Library/img/32/iconCalendario.gif";
        else
            imageButton.ImageUrl = "~/Library/img/32/iconCalendario_dis.gif";

        #endregion
    }

    private void CargarTextBoxControl(ControlEntidad control, TextBox textBox, MaskedEditExtender maskedEditExtender)
    {
        #region TEXTBOX

        textBox.Text = control.ValorDefecto;
        textBox.ToolTip = String.Concat("Texto ", control.DesColumna);
        textBox.Enabled = bool.Parse(control.IndModificar);
        textBox.Visible = bool.Parse(control.IndVisible);
        textBox.CssClass = control.CssTipo;

        if (!control.LongitudMaxima.Length.Equals(0))
            textBox.MaxLength = Int32.Parse(control.LongitudMaxima);

        if (textBox.ID.Contains("Porcentaje"))
            textBox.Width = Unit.Parse("55px");
        else
        {
            if (!control.LongitudMaxima.Length.Equals(0))
                textBox.Width = Unit.Parse((int.Parse(control.LongitudMaxima) * 9).ToString() + "px");
        }

        if (!String.IsNullOrEmpty(control.GrupoValidacion))
            textBox.ValidationGroup = control.GrupoValidacion;

        #endregion

        #region MASKEDEDIT EXTENDER

        int m = Int32.Parse(control.Mascara);
        if (m > 0)
        {
            maskedEditExtender.ClearTextOnInvalid = true;
            maskedEditExtender.ClearMaskOnLostFocus = true;
            maskedEditExtender.InputDirection = MaskedEditInputDirection.RightToLeft;
            maskedEditExtender.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();

            maskedEditExtender.MaskType = _generadorControles.DeterminaTipoMascara(m);
            if (textBox.ID.Contains("Monto") || textBox.ID.Contains("Porcentaje") || textBox.ID.Contains("Valor"))
                maskedEditExtender.Mask = control.ValorMascara;
            else
                maskedEditExtender.Mask = _generadorControles.DeterminaFormatoMascara(Int32.Parse(control.LongitudMaxima), control.ValorMascara);
        }

        else
        {
            maskedEditExtender.MaskType = MaskedEditType.None;
        }

        #endregion
    }

    private void CargarDropDownListControl(ControlEntidad control, DropDownList dropDownList, string filtro)
    {
        #region DROPDOWNLIST

        //LIMPIAR EL CONTROL DROPDOWNLIST
        LimpiarDropDownList(dropDownList);

        //CARGAR EL DROPDOWNLIS
        if (!control.MetodoServicioWeb.Equals(""))
        {
            dropDownList.DataSource = LlenarDropDownList(control.MetodoServicioWeb, filtro);
            dropDownList.DataValueField = "Valor";
            dropDownList.DataTextField = "Texto";
            dropDownList.DataBind();
        }
        dropDownList.Enabled = bool.Parse(control.IndModificar);
        dropDownList.Visible = bool.Parse(control.IndVisible);
        dropDownList.CssClass = control.CssTipo;

        #endregion
    }

    private void LimpiarDropDownList(DropDownList dropDownList)
    {
        //BORRA LOS VALORES DEL DDL, SE DEBE DE REALIZAR DE ESTA MANERA PARA ELIMINAR LOS DATOS EN CACHÉ DEL OBJ
        dropDownList.ClearSelection();
        dropDownList.Items.Clear();
        dropDownList.SelectedValue = null;
        dropDownList.DataSource = null;
    }

    private Object LlenarDropDownList(string wsMethodName, string filtro)
    {
        try
        {
            Type ws = wsListas.GetType();
            MethodInfo method = ws.GetMethod(wsMethodName);
            var result = method.Invoke(wsListas, new object[] { filtro });

            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private int ObtenerEstadoGarantia(string estadoGarantia)
    {
        int resultado = 0;
        switch (estadoGarantia)
        {
            case "Pendiente":
                resultado = (int)EnumTipoEstadoGarantia.PENDIENTE;
                break;
            case "Replicado":
                resultado = (int)EnumTipoEstadoGarantia.ACTUALIZADO;
                break;
            case "Actualizado":
                resultado = (int)EnumTipoEstadoGarantia.ACTUALIZADO;
                break;
        }
        return resultado;
    }

    #region VENTANAS DE MENSAJES

    protected void BtnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBox.Hide();
        updRelacionGarantiaFideicomisoPopUpControl.Update();
    }

    #endregion

    #region MENSAJE CONFIRMAR

    //MUESTRA BARRA DE MENSAJE SUPERIOR
    private void BarraMensaje(string tipoAccion)
    {
        try
        {
            //REQUERIMIENTO: 1-24653531
            //MENSAJE DE VALIDACION DE CARACTERES ESPECIALES
            _mensajesEntidad.CodMensaje = tipoAccion;
            lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";

            //RETORNA MENSAJE DE ERROR
            lblBarraMensaje.Text = wsSeguridad.MensajesConsulta(_mensajesEntidad).DesMensaje;
            this.divBarraMensaje.Visible = true;
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    private MensajesEntidad Mensaje(string msgType)
    {
        try
        {
            _mensajesEntidad.CodMensaje = msgType.ToString();
            MensajesEntidad msj = wsSeguridad.MensajesConsulta(_mensajesEntidad);
            return msj;
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void InformarBox1_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad _mensaje = this.Mensaje(type);
            InformarBox1.SetMessageBox(_mensaje.DesTipoMensaje, _mensaje.DesMensaje.Replace("@@@", _valorReemplazo));
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void InformarBox1_SetConfirmationBoxEvent(object sender, EventArgs e, string type, string valorReemplazo1, string valorReemplazo2)
    {
        try
        {
            MensajesEntidad _mensaje = this.Mensaje(type);
            InformarBox1.SetMessageBox(_mensaje.DesTipoMensaje, _mensaje.DesMensaje.Replace("@@@", valorReemplazo1).Replace("@$@", valorReemplazo2));
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

}