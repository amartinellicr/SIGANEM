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


public partial class wucGarantiasFideicomisoValores : System.Web.UI.UserControl
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

    public void LimpiarContenidoControlValores()
    {

        #region LIMPIAR MENSAJES

        //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
        if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
        {
            this.divBarraMensaje.Visible = false;
        }

        #endregion

        this.txtIdGarantiaBCR.Text = string.Empty;

        this.txtTipoMonedaValorMercado.Text = string.Empty;
        this.txtValorMercado.Text = string.Empty;
        this.txtValorMercadoColonizado.Text = string.Empty;
        this.txtTipoMonedaValorFacial.Text = string.Empty;
        this.txtValorFacial.Text = string.Empty;
        this.txtValorFacialColonizado.Text = string.Empty;

        this.txtIdDueno.Text = string.Empty;
        this.txtNombreDueno.Text = string.Empty;
        this.txtFechaPresentacion.Text = string.Empty;
    }

    public void CargarContenidoControlValores(List<ControlEntidad> controles)
    {
        try
        {
            AsignaWebServicesTypeNames();
            ControlEntidad controlSeleccionado = null;

            #region APARTADO GENERAL

            #region TIPO VALOR

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdTipoValor.ID);
            this.lblIdTipoValor.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdTipoValor.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoValor, string.Empty);
            _generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIdTipoValor, controlSeleccionado.ValorDefecto);

            #endregion

            #region TIPO INSTRUMENTO FINANCIERO

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdTipoInstrumentoFinanciero.ID);
            this.lblIdTipoInstrumentoFinanciero.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdInstrumentoFinanciero.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdInstrumentoFinanciero, string.Empty);
            _generadorControles.SeleccionarOpcionDropDownListCodigo(this.ddlIdInstrumentoFinanciero, "1");

            #endregion

            #region INSTRUMENTO FINANCIERO

            #region CONTRUIR FILTROS

            _filtro = new StringBuilder();
            _filtro.Append(ddlIdInstrumentoFinanciero.SelectedValue.ToString());

            #endregion

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdInstrumentoFinanciero.ID);
            this.lblIdInstrumentoFinanciero.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdInstrumentoFinanciero.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdInstrumentoFinanciero, _filtro.ToString());
            _generadorControles.SeleccionarOpcionDropDownListCodigo(this.ddlIdInstrumentoFinanciero, "1");

            #endregion

            #region EMISOR

            #region CONTRUIR FILTROS

            _filtro = new StringBuilder();
            _filtro.Append(ddlIdInstrumentoFinanciero.SelectedValue.ToString());

            #endregion

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdEmisor.ID);
            this.lblIdEmisor.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdEmisor.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdEmisor, _filtro.ToString());
            _generadorControles.SeleccionarOpcionDropDownListCodigo(this.ddlIdEmisor, "1");

            #endregion

            #region ISIN

            #region CONTRUIR FILTROS

            _filtro = new StringBuilder();
            _filtro.Append(ddlIdInstrumentoFinanciero.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdEmisor.SelectedValue.ToString());

            #endregion

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdISIN.ID);
            this.lblIdISIN.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdISIN.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, this.ddlIdISIN, _filtro.ToString());

            #endregion

            #region SERIE INSTRUMENTO

            #region CONTRUIR FILTROS

            _filtro = new StringBuilder();
            _filtro.Append(ddlIdInstrumentoFinanciero.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdEmisor.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdISIN.SelectedValue.ToString());

            #endregion

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdSerieInstrumento.ID);
            this.lblIdSerieInstrumento.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdSerieInstrumento.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, this.ddlIdSerieInstrumento, _filtro.ToString());

            #endregion

            #region ID GARANTIA BCR

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdGarantiaBCR.ID);
            this.lblIdGarantiaBCR.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtIdGarantiaBCR.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtIdGarantiaBCR);

            #endregion

            #endregion

            #region APARTADO DETALLE

            #region TIPO MONEDA VALOR MERCADO

            controlSeleccionado = BuscarControlesValores(controles, this.lblTipoMonedaValorMercado.ID);
            this.lblTipoMonedaValorMercado.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtTipoMonedaValorMercado.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtTipoMonedaValorMercado);

            #endregion

            #region VALOR MERCADO

            controlSeleccionado = BuscarControlesValores(controles, this.lblValorMercado.ID);
            this.lblValorMercado.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtValorMercado.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtValorMercado);

            #endregion

            #region VALOR MERCADO COLONIZADO

            controlSeleccionado = BuscarControlesValores(controles, this.lblValorMercadoColonizado.ID);
            this.lblValorMercadoColonizado.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtValorMercadoColonizado.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtValorMercadoColonizado);

            #endregion

            #region TIPO MONEDA VALOR FACIAL

            controlSeleccionado = BuscarControlesValores(controles, this.lblTipoMonedaValorFacial.ID);
            this.lblTipoMonedaValorFacial.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtTipoMonedaValorFacial.ID);
            CargarTextBoxControl(controlSeleccionado, txtTipoMonedaValorFacial);

            #endregion

            #region VALOR FACIAL

            controlSeleccionado = BuscarControlesValores(controles, this.lblValorFacial.ID);
            this.lblValorFacial.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtValorFacial.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtValorFacial);

            #endregion

            #region VALOR FACIAL COLONIZADO

            controlSeleccionado = BuscarControlesValores(controles, this.lblValorFacialColonizado.ID);
            this.lblValorFacialColonizado.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtValorFacialColonizado.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtValorFacialColonizado);

            #endregion

            #endregion

            #region APARTADO ADICIONALES

            #region ID DUEÑO

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdDueno.ID);
            this.lblIdDueno.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtIdDueno.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtIdDueno);

            #endregion

            #region NOMBRE DUEÑO

            controlSeleccionado = BuscarControlesValores(controles, this.lblNombreDueno.ID);
            this.lblNombreDueno.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtNombreDueno.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtNombreDueno);

            #endregion

            #region TIPO MONEDA VALOR NOMINAL

            controlSeleccionado = BuscarControlesValores(controles, this.lblTipoMonedaValorNominal.ID);
            this.lblTipoMonedaValorNominal.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlTipoMonedaValorNominal.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, this.ddlTipoMonedaValorNominal, string.Empty);

            #endregion

            #region VALOR NOMINAL

            controlSeleccionado = BuscarControlesValores(controles, this.lblValorNominal.ID);
            this.lblValorNominal.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtValorNominal.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtValorNominal, this.mskValorNominal);

            #endregion

            #region TIPO MITIGADOR RIESGO

            controlSeleccionado = BuscarControlesValores(controles, this.lblTipoMitagadorRiesgo.ID);
            this.lblTipoMitagadorRiesgo.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlTipoMitagadorRiesgo.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlTipoMitagadorRiesgo, "0, 10, 11, 12, 13, 14, 15");
            //AdministrarBlanco("ddlTipoMitagadorRiesgo", true);

            #endregion

            #region TIPO DOCUMENTO LEGAL

            controlSeleccionado = BuscarControlesValores(controles, this.lblTipoDocumentoLegal.ID);
            this.lblTipoDocumentoLegal.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlTipoDocumentoLegal.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, this.ddlTipoDocumentoLegal, "21");

            #endregion

            #region IND INSCRIPCION

            controlSeleccionado = BuscarControlesValores(controles, this.lblIndInscripcion.ID);
            this.lblIndInscripcion.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIndInscripcion.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIndInscripcion, controlSeleccionado.ValorServicioWeb);
            _generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndInscripcion, controlSeleccionado.ValorDefecto);

            #endregion

            #region FECHA PRESENTACION

            controlSeleccionado = BuscarControlesValores(controles, this.lblFechaPresentacion.ID);
            this.lblFechaPresentacion.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtFechaPresentacion.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtFechaPresentacion);

            #endregion

            #region MONTO MITGADOR

            controlSeleccionado = BuscarControlesValores(controles, this.lblMontoMitigador.ID);
            this.lblMontoMitigador.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtMontoMitigador.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtMontoMitigador, this.mskMontoMitigador);

            #endregion

            #region PORCENTAJE ACEPTACION SUGEF

            controlSeleccionado = BuscarControlesValores(controles, this.lblPorcentajeAceptacionSUGEF.ID);
            this.lblPorcentajeAceptacionSUGEF.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtPorcentajeAceptacionSUGEF.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtPorcentajeAceptacionSUGEF, this.mskPorcentajeAceptacionSUGEF);

            #endregion

            #region PORCENTAJE ACEPTACION BCR

            controlSeleccionado = BuscarControlesValores(controles, this.lblPorcentajeAceptacionBCR.ID);
            this.lblPorcentajeAceptacionBCR.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtPorcentajeAceptacionBCR.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtPorcentajeAceptacionBCR, this.mskPorcentajeAceptacionBCR);

            #endregion

            #endregion

            ddlTipoInstrumentoFinancieros(ddlIdInstrumentoFinanciero);
            InsertarExcepcionOtrosValores();
            updValoresPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    public void EstadoControles(bool estado)
    {
        this.txtIdDueno.Enabled = estado;
        this.txtNombreDueno.Enabled = estado;

        this.ddlTipoMitagadorRiesgo.Enabled = estado;
        this.txtPorcentajeAceptacionBCR.Enabled = estado;
    }

    protected void btnConsultarGarantia_Click(object sender, EventArgs e)
    {
        try
        {
            //if (!String.IsNullOrEmpty(txtIdGarantiaBCR.Text))
            //{
                if(!ValidarCaracterEspecial(txtIdGarantiaBCR.Text)) 
                {
                    string[] sesion = valorSesionOculto.Value.Split('|');
                    RespuestaConsultaSesion _sesion = wsSesiones.ConsultarSesion(sesion[0]);
                    if (_sesion.Codigo == 0)
                    {
                        #region ENTIDAD CONSULTA

                        GarantiasValoresEntidad entidadValor = new GarantiasValoresEntidad();
                        entidadValor.IdTipoValor = int.Parse(ddlIdTipoValor.SelectedValue);
                        entidadValor.IdTipoInstrumento = int.Parse(ddlIdTipoInstrumentoFinanciero.SelectedValue);
                        entidadValor.IdInstrumento = int.Parse(ddlIdInstrumentoFinanciero.SelectedValue);
                        entidadValor.IdEmisor = int.Parse(ddlIdEmisor.SelectedValue);
                        entidadValor.ISIN = ddlIdISIN.SelectedValue;
                        entidadValor.Serie = ddlIdSerieInstrumento.SelectedValue;
                        entidadValor.CodGarantiaBCR = StaticParameters.RemoveSpecialCharacters(this.txtIdGarantiaBCR.Text);

                        #endregion

                        GarantiasValoresEntidad consulta = wsGarantias.GarantiasFideicomisosFideicometidasValoresBusqueda(entidadValor);
                        if (consulta != null)
                        {
                            idGarantiaValorOculto.Value = consulta.IdGarantiaValor.ToString();

                            txtTipoMonedaValorMercado.Text = consulta.MonedaValorMercado;
                            txtValorMercado.Text = consulta.MontoValorMercado.ToString();
                            txtValorMercadoColonizado.Text = Math.Round(consulta.MontoValorMercadoColonizado.Value, 2).ToString();

                            txtTipoMonedaValorFacial.Text = consulta.MonedaValorFacial;
                            txtValorFacial.Text = consulta.MontoValorFacial.ToString();
                            txtValorFacialColonizado.Text = Math.Round(consulta.MontoValorFacialColonizado.Value, 2).ToString();

                            //DESHABILITAR LA TABLA GENERALES
                            _generadorControles.Bloquear_Controles(tableGeneral, false);

                            //HABILITAR LA TABLA ADICIONALES
                            tableAdicionales.Disabled = false;

                            //HABILITAR CONTROLES
                            EstadoControles(true);

                            //DESHABILITAR BOTON CONSULTAR
                            btnConsultarGarantia.Enabled = false;
                            btnConsultarGarantia.CssClass = "botonConsultarRelacionDisabled";

                                        #region ADMINISTRAR ESPACIOS BLANCOS

                        AdministrarBlanco("ddlIdGradoGravamen", false);
                        AdministrarBlanco("ddlIdTipoMitigadorRiesgo", false);

                        #endregion
                        }
                        else
                        {
                            // MENSAJE DE ERROR
                            this.InformarBox1_SetConfirmationBoxEvent(null, e, "GAR_1");
                            this.mpeInformarBox.Show();
                        }

                        updValoresPopUpControl.Update();
                    }
                }

                else
                {
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_2");
                    this.mpeInformarBox.Show();
                }
            //}

            //else
            //{
            //    //this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_29");
            //    //this.mpeInformarBox.Show();
            //}
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

            GarantiasFideicomisosFideicometidasEntidad entidadFideicometida = new GarantiasFideicomisosFideicometidasEntidad();
            entidadFideicometida.IdGarantiaFideicomiso = int.Parse(sesion[4]);

            if (!String.IsNullOrEmpty(idGarantiaFideicometida.Value))
                entidadFideicometida.IdGarantiaFideicomisoFideicometida = int.Parse(idGarantiaFideicometida.Value);

            entidadFideicometida.IdGarantiaValor = int.Parse(idGarantiaValorOculto.Value);
            entidadFideicometida.IdTipoGarantia = int.Parse(sesion[3]);

            #region APARTADO ADICIONALES

            //ID DUEÑO
            entidadFideicometida.IdDueno = txtIdDueno.Text;

            //NOMBRE DUEÑO
            entidadFideicometida.NombreDueno = txtNombreDueno.Text;

            //TIPO MONEDA VALOR NOMINAL
            entidadFideicometida.IdTipoMonendaValorNominal = int.Parse(ddlTipoMonedaValorNominal.SelectedItem.Value);

            //VALOR NOMINAL
            entidadFideicometida.ValorNominal = decimal.Parse(txtValorNominal.Text);

            //TIPO MITIGADOR RIESGO
            entidadFideicometida.IdTipoMitigadorRiego = int.Parse(ddlTipoMitagadorRiesgo.SelectedItem.Value);

            //TIPO DOCUMENTO LEGAL
            entidadFideicometida.IdTipoDocumentoLegal = int.Parse(ddlTipoDocumentoLegal.SelectedItem.Value);

            //IND INSCRIPCION
            entidadFideicometida.IdTipoIndicadorInscripcion = int.Parse(ddlIndInscripcion.SelectedItem.Value);

            //MONTO MITIGADOR
            entidadFideicometida.MontoMitigador = decimal.Parse(txtMontoMitigador.Text);

            //PORCENTAJE ACEPTACION SUGEF
            if(txtPorcentajeAceptacionSUGEF.Text.Trim().Length > 0)
            {
                entidadFideicometida.PorcentajeAceptacionSUGEF = decimal.Parse(txtPorcentajeAceptacionSUGEF.Text);
            }
            else
            {
                entidadFideicometida.PorcentajeAceptacionSUGEF = null;
            }            

            //PORCENTAJE ACEPTACION BCR
            entidadFideicometida.PorcentajeAceptacionBCR = decimal.Parse(txtPorcentajeAceptacionBCR.Text);

            #endregion

            //REQUERIMIENTO BLOQUE 7 1-24381561

            #region CONTROL DE REGISTRO

            entidadFideicometida.CodUsuarioIngreso = sesion[2];
            entidadFideicometida.IndMetodoInsercion = Resources.Resource._metodoInsercion;

            #endregion

            #region DIRECCIONAMIENTO SEGUN EL TIPO DE ACCION

            switch (tipoAccion)
            {
                case 0:
                    result = wsGarantias.GarantiasFideicomisosFideicometidasInsertar(entidadFideicometida, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));
                    break;

                case 1:
                    result = wsGarantias.GarantiasFideicomisosFideicometidasModificar(entidadFideicometida, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));
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

    public void DeEntidadAControles(GarantiasFideicomisosFideicometidasEntidad entidadOperacion, GarantiasValoresEntidad entidadValores)
    {
        try
        {
            idGarantiaValorOculto.Value = entidadOperacion.IdGarantiaValor.ToString();

            //Ajuste javendano 2015-01-09
            #region APARTADO ENCABEZADO

            //TIPO VALOR
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoValor, entidadValores.IdTipoValor.ToString());
            ddlTipoValor(ddlIdTipoValor);

            //TIPO INSTRUMENTO FINANCIEROS
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoInstrumentoFinanciero, entidadValores.IdTipoInstrumento.ToString());
            ddlTipoInstrumentoFinancieros(ddlIdTipoInstrumentoFinanciero);

            //INSTRUMENTO FINANCIEROS
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdInstrumentoFinanciero, entidadValores.IdInstrumento.ToString());
            ddlInstrumentoFinancieros(ddlIdInstrumentoFinanciero);

            //EMISOR
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdEmisor, entidadValores.IdEmisor.ToString());
            ddlEmisor(ddlIdEmisor);

            //ISIN
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdISIN, entidadValores.ISIN.ToString());
            ddlISIN(ddlIdISIN);

            //SERIE
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdSerieInstrumento, entidadValores.Serie.ToString());
            ddlSerie(ddlIdSerieInstrumento);

            //COD GARANTIA BCR
            txtIdGarantiaBCR.Text = entidadValores.CodGarantiaBCR.ToString();

            #endregion

            #region APARTADO DETALLE

            btnConsultarGarantia_Click(null, null);

            #endregion

            #region APARTADO ADICIONALES

            //ID DUEÑO
            txtIdDueno.Text = entidadOperacion.IdDueno;

            //NOMBRE DUEÑO
            txtNombreDueno.Text = entidadOperacion.NombreDueno;

            //TIPO MONEDA VALOR NOMINAL
            _generadorControles.SeleccionarOpcionDropDownList(ddlTipoMonedaValorNominal, entidadOperacion.IdTipoMonendaValorNominal.ToString());

            //VALOR NOMINAL
            txtValorNominal.Text = entidadOperacion.ValorNominal.ToString();

            //TIPO MITIGADOR RIESGOS
            _generadorControles.SeleccionarOpcionDropDownList(ddlTipoMitagadorRiesgo, entidadOperacion.IdTipoMitigadorRiego.ToString());

            //TIPO DOCUMENTO LEGAL
            _generadorControles.SeleccionarOpcionDropDownList(ddlTipoDocumentoLegal, entidadOperacion.IdTipoDocumentoLegal.ToString());

            //IND INSCRIPCION
            _generadorControles.SeleccionarOpcionDropDownList(ddlIndInscripcion, entidadOperacion.IdTipoDocumentoLegal.ToString());

            //FECHA PRESENTACION
            txtFechaPresentacion.Text = entidadOperacion.FechaPresentacion.ToString();

            //MONTO MITIGADOR
            txtMontoMitigador.Text = entidadOperacion.MontoMitigador.ToString();

            //PORCENTAJE RESPONSABILIDAD SUGEF
            txtPorcentajeAceptacionSUGEF.Text = entidadOperacion.PorcentajeAceptacionSUGEF.ToString();

            //PORCENTAJE RESPONSABILIDAD SUGEF
            txtPorcentajeAceptacionBCR.Text = entidadOperacion.PorcentajeAceptacionBCR.ToString();

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

    public bool ValidarPorcentajeAceptacionBCR()
    {
        try
        {
            bool fueraRango = false;
            Decimal campo = 0;

            //SI CAMPO ES MENOS MAYOR A 100 O MENOR A CERO 
            if (txtPorcentajeAceptacionBCR.Text.Length > 0)
                campo = Decimal.Parse(this.txtPorcentajeAceptacionBCR.Text);
            else
                campo = Decimal.Parse(this.wmPorcentajeAceptacionBCR.WatermarkText);

            if (campo < 0 || campo > 100)
            {
                //MENSAJE DE ERROR DEL VALOR
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblPorcentajeAceptacionBCR.Text, "Mayor o Igual a 0 y Menor o Igual a 100");
                this.mpeInformarBox.Show();

                fueraRango = true;
            }

            return fueraRango;
        }
        catch
        {
            throw;
        }
    }

    public bool ValidarPorcentajeAceptacionSUGEF()
    {
        try
        {
            bool fueraRango = false;
            Decimal campo = 0;

            //SI CAMPO ES MENOS MAYOR A 100 O MENOR A CERO 
            if (txtPorcentajeAceptacionSUGEF.Text.Length > 0)
            {
                campo = Decimal.Parse(this.txtPorcentajeAceptacionSUGEF.Text);
            }
            else if (this.wmPorcentajeAceptacionSUGEF.WatermarkText.Trim().Length > 0)
            {
                campo = Decimal.Parse(this.wmPorcentajeAceptacionSUGEF.WatermarkText);
            }
            else campo = 0;

            if (campo < 0 || campo > 100)
            {
                //MENSAJE DE ERROR DEL VALOR
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblPorcentajeAceptacionSUGEF.Text, "Mayor o Igual a 0 y Menor o Igual a 100");
                this.mpeInformarBox.Show();

                fueraRango = true;
            }

            return fueraRango;
        }
        catch
        {
            throw;
        }
    }

    #region METODOS PARA DROPDOWNLIST

    protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string idDropDownList = ((DropDownList)(sender)).ID.ToString().ToUpper();

            switch (idDropDownList)
            {

                #region TIPO VALOR

                case "DDLIDTIPOVALOR":
                    ddlTipoValor(sender);
                    break;

                #endregion

                #region TIPO INSTRUMENTO

                case "DDLIDTIPOINSTRUMENTOFINANCIERO":
                    ddlTipoInstrumentoFinancieros(sender);
                    break;

                #endregion

                #region INSTRUMENTO

                case "DDLIDINSTRUMENTOFINANCIERO":
                    ddlInstrumentoFinancieros(sender);
                    break;

                #endregion

                #region EMISOR

                case "DDLIDEMISOR":
                    ddlEmisor(sender);
                    break;

                #endregion

                #region ISIN

                case "DDLIDISIN":
                    ddlISIN(sender);
                    break;

                #endregion

                #region SERIE

                case "DDLSERIE":
                    ddlSerie(sender);
                    break;

                #endregion

            }
        }
        catch
        {
            throw;
        }
    }

    private void ddlTipoValor(object sender)
    {
        try
        {
            switch (ObtenerTipoValor())
            {
                case 1:
                    InsertarExcepcionOtrosValores();
                    break;
                case 2:
                    InsertarExcepcionCDPBCR();
                    break;
                case 3:
                    InsertarExcepcionCDPOtrosEmisores();
                    break;
                case 4:
                    InsertarExcepcionOtrosValoresExcepcion();
                    break;
            }
        }
        catch
        {
            throw;
        }
    }

    private void ddlTipoInstrumentoFinancieros(object sender)
    {
        try
        {
            switch (ObtenerTipoValor())
            {
                case 1:
                    CargarInstrumentoFinancieros(sender);
                    CargarEmisor(ddlIdInstrumentoFinanciero);
                    CargarISIN(ddlIdEmisor, ddlIdInstrumentoFinanciero);
                    CargarSerie(ddlIdInstrumentoFinanciero, ddlIdEmisor, ddlIdISIN);
                    break;
            }

            updValoresPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void ddlInstrumentoFinancieros(object sender)
    {
        try
        {
            switch (ObtenerTipoValor())
            {
                case 1:
                    CargarEmisor(sender);
                    CargarISIN(ddlIdEmisor, ddlIdInstrumentoFinanciero);
                    CargarSerie(ddlIdInstrumentoFinanciero, ddlIdEmisor, ddlIdISIN);
                    break;
            }

            updValoresPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void ddlEmisor(object sender)
    {
        try
        {
            switch (ObtenerTipoValor())
            {
                case 1:
                    CargarISIN(ddlIdEmisor, ddlIdInstrumentoFinanciero);
                    CargarSerie(ddlIdInstrumentoFinanciero, ddlIdEmisor, ddlIdISIN);
                    break;
            }

            updValoresPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void ddlISIN(object sender)
    {
        try
        {
            switch (ObtenerTipoValor())
            {
                case 1:
                    CargarSerie(ddlIdInstrumentoFinanciero, ddlIdEmisor, ddlIdISIN);
                    break;
            }

            updValoresPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void ddlSerie(object sender)
    {
        try
        {
            updValoresPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region METODOS TEXT CHANGED

    protected void txtMontoMitigador_TextChanged(object sender, EventArgs e)
    {
        try
        {
            MontoMitigador(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void MontoMitigador(object sender, EventArgs e)
    {
        try
        {
            if (this.txtMontoMitigador.Enabled)
            {
                //MONTOGRADOGRAVAMEN DEBE SER MAYOR CERO
                string Monto = _generadorControles.EliminarErrorMascara(this.txtMontoMitigador.Text);
                if (_generadorControles.ObtenerComparacion("0,01", Monto, EnumTipoComparacion.MAYOR, TypeCode.Decimal))
                {
                    //LIMPIA LOS CAMPOS
                    this.txtMontoMitigador.Text = string.Empty;

                    //MENSAJE DE ERROR DEL VALOR
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblMontoMitigador.Text, "Mayor a Cero");
                    this.mpeInformarBox.Show();
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtValorNominal_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ValorNominal(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ValorNominal(object sender, EventArgs e)
    {
        try
        {
            if (this.txtValorNominal.Enabled)
            {
                //MONTOGRADOGRAVAMEN DEBE SER MAYOR CERO
                string Monto = _generadorControles.EliminarErrorMascara(this.txtValorNominal.Text);
                if (_generadorControles.ObtenerComparacion("0,01", Monto, EnumTipoComparacion.MAYOR, TypeCode.Decimal))
                {
                    //LIMPIA LOS CAMPOS
                    this.txtValorNominal.Text = string.Empty;

                    //MENSAJE DE ERROR DEL VALOR
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblValorNominal.Text, "Mayor a Cero");
                    this.mpeInformarBox.Show();
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    //protected void txtIdGarantiaBCR_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        this.btnConsultarGarantia.CausesValidation = false;
    //    }

    //    catch (Exception ex)
    //    {
    //        Application["Exception"] = ex;
    //        Response.Redirect("~/Aplicacion/Error.aspx", false);
    //    }
    //}

    #endregion

    #region EXCEPCIONES TIPO VALORES

    private void InsertarExcepcionOtrosValores()
    {
        try
        {
            LimpiarContenidoFormulario();

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            ddlIdTipoInstrumentoFinanciero.Enabled = true;
            ddlIdInstrumentoFinanciero.Enabled = true;
            ddlIdEmisor.Enabled = true;

            CargarTipoInstrumentoFinancieros();
            CargarInstrumentoFinancieros(ddlIdTipoInstrumentoFinanciero);
            CargarEmisor(ddlIdInstrumentoFinanciero);

            #endregion

            #region ISIN / SERIE / ID GARANTIA

            ddlIdISIN.Enabled = true;
            ddlIdSerieInstrumento.Enabled = true;
            CargarISIN(ddlIdEmisor, ddlIdInstrumentoFinanciero);
            CargarSerie(ddlIdInstrumentoFinanciero, ddlIdEmisor, ddlIdISIN);

            txtIdGarantiaBCR.MaxLength = 12;

            #endregion

            updValoresPopUpControl.Update();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void InsertarExcepcionCDPBCR()
    {
        try
        {
            LimpiarContenidoFormulario();

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            ddlIdTipoInstrumentoFinanciero.Enabled = false;
            ddlIdInstrumentoFinanciero.Enabled = false;
            ddlIdEmisor.Enabled = false;

            CargarTipoInstrumentoFinancierosTodos();
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoInstrumentoFinanciero, "CDP-CI");

            CargarInstrumentoFinancieros(ddlIdTipoInstrumentoFinanciero);
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdInstrumentoFinanciero, "CDP-CI");

            CargarOtrosEmisores();
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdEmisor, "BCR");

            #endregion

            #region ISIN / SERIE / ID GARANTIA

            ddlIdISIN.Enabled = false;
            ddlIdSerieInstrumento.Enabled = false;
            LimpiarDropDownList(ddlIdISIN);
            LimpiarDropDownList(ddlIdSerieInstrumento);

            txtIdGarantiaBCR.MaxLength = 12;

            #endregion

            updValoresPopUpControl.Update();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void InsertarExcepcionCDPOtrosEmisores()
    {
        try
        {
            LimpiarContenidoFormulario();

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            ddlIdTipoInstrumentoFinanciero.Enabled = false;
            ddlIdInstrumentoFinanciero.Enabled = false;
            ddlIdEmisor.Enabled = true;

            CargarTipoInstrumentoFinancierosTodos();
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoInstrumentoFinanciero, "CDP-CI");

            CargarInstrumentoFinancieros(ddlIdTipoInstrumentoFinanciero);
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdInstrumentoFinanciero, "CDP-CI");

            CargarOtrosEmisores();

            #endregion

            #region ISIN / SERIE / ID GARANTIA

            ddlIdISIN.Enabled = false;
            ddlIdSerieInstrumento.Enabled = false;
            LimpiarDropDownList(ddlIdISIN);
            LimpiarDropDownList(ddlIdSerieInstrumento);

            txtIdGarantiaBCR.MaxLength = 12;

            #endregion

            updValoresPopUpControl.Update();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void InsertarExcepcionOtrosValoresExcepcion()
    {
        try
        {
            LimpiarContenidoFormulario();

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            ddlIdTipoInstrumentoFinanciero.Enabled = true;
            ddlIdInstrumentoFinanciero.Enabled = true;
            ddlIdEmisor.Enabled = true;

            CargarTipoInstrumentoFinancierosTodos();
            CargarInstrumentosFinancierosTodos();
            CargarOtrosEmisores();

            #endregion

            #region ISIN / SERIE / ID GARANTIA

            ddlIdISIN.Enabled = false;
            ddlIdSerieInstrumento.Enabled = false;
            LimpiarDropDownList(ddlIdISIN);
            LimpiarDropDownList(ddlIdSerieInstrumento);

            txtIdGarantiaBCR.MaxLength = 12;

            #endregion

            updValoresPopUpControl.Update();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region EVENTOS DE CONTROLES

    //VALIDACION DE CARACTERES ESPECIALES
    public bool ValidarCaracterEspecial(string texto)
    {
        bool existeCaracter = false;
        //NO SE PERMITEN CARACTERES ESPECIALES
        //var regexItem = new Regex("^[a-zA-Z0-9- ]*$");
        var regexItem = new Regex(@"^[a-zA-Z0-9 \-.,_:ÁÉÍÓÚÑáéíóúñ]*$");

        if (!regexItem.IsMatch(texto))
            existeCaracter = true;

        return existeCaracter;
    }

    private void LimpiarContenidoFormulario()
    {
        ddlIdTipoInstrumentoFinanciero.SelectedIndex = -1;
    }

    private int ObtenerTipoValor()
    {
        return int.Parse(ddlIdTipoValor.SelectedValue);
    }

    private string ObtenerTipoInstrumentoFinancieros()
    {
        return ddlIdTipoInstrumentoFinanciero.SelectedItem.Text.Split('-')[0].Trim();
    }

    private void CargarTipoInstrumentoFinancieros()
    {
        try
        {
            LimpiarDropDownList(ddlIdTipoInstrumentoFinanciero);
            if (ddlIdTipoInstrumentoFinanciero != null)
            {
                ddlIdTipoInstrumentoFinanciero.Items.Clear();
                ddlIdTipoInstrumentoFinanciero.DataSource = LlenarDropDownList("InstrumentosTipoInstrumentoLista", string.Empty);
                ddlIdTipoInstrumentoFinanciero.DataTextField = "Texto";
                ddlIdTipoInstrumentoFinanciero.DataValueField = "Valor";
                ddlIdTipoInstrumentoFinanciero.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarTipoInstrumentoFinancierosTodos()
    {
        try
        {
            LimpiarDropDownList(ddlIdTipoInstrumentoFinanciero);
            if (ddlIdTipoInstrumentoFinanciero != null)
            {
                ddlIdTipoInstrumentoFinanciero.Items.Clear();
                ddlIdTipoInstrumentoFinanciero.DataSource = LlenarDropDownList("TiposInstrumentosFiltradoInstrumentosLista", string.Empty);
                ddlIdTipoInstrumentoFinanciero.DataTextField = "Texto";
                ddlIdTipoInstrumentoFinanciero.DataValueField = "Valor";
                ddlIdTipoInstrumentoFinanciero.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    private void CargarInstrumentoFinancieros(object sender)
    {
        try
        {
            LimpiarDropDownList(ddlIdInstrumentoFinanciero);
            if (ddlIdInstrumentoFinanciero != null)
            {
                ddlIdInstrumentoFinanciero.Items.Clear();
                ddlIdInstrumentoFinanciero.DataSource = LlenarDropDownList("InstrumentosEmisionesFiltradoLista", ((DropDownList)(sender)).SelectedValue.ToString());
                ddlIdInstrumentoFinanciero.DataTextField = "Texto";
                ddlIdInstrumentoFinanciero.DataValueField = "Valor";
                ddlIdInstrumentoFinanciero.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    private void CargarInstrumentosFinancierosTodos()
    {
        try
        {
            LimpiarDropDownList(ddlIdInstrumentoFinanciero);
            if (ddlIdInstrumentoFinanciero != null)
            {
                ddlIdInstrumentoFinanciero.Items.Clear();
                ddlIdInstrumentoFinanciero.DataSource = LlenarDropDownList("InstrumentosLista", string.Empty);
                ddlIdInstrumentoFinanciero.DataTextField = "Texto";
                ddlIdInstrumentoFinanciero.DataValueField = "Valor";
                ddlIdInstrumentoFinanciero.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    private void CargarEmisor(object sender)
    {
        try
        {
            LimpiarDropDownList(ddlIdEmisor);
            if (ddlIdEmisor != null)
            {
                ddlIdEmisor.Items.Clear();
                ddlIdEmisor.DataSource = LlenarDropDownList("EmisionesInstrumentosEmisorLista", ((DropDownList)(sender)).SelectedValue.ToString());
                ddlIdEmisor.DataTextField = "Texto";
                ddlIdEmisor.DataValueField = "Valor";
                ddlIdEmisor.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    private void CargarOtrosEmisores()
    {
        try
        {
            LimpiarDropDownList(ddlIdEmisor);
            if (ddlIdEmisor != null)
            {
                ddlIdEmisor.Items.Clear();
                ddlIdEmisor.DataSource = LlenarDropDownList("EmisoresLista", string.Empty);
                ddlIdEmisor.DataTextField = "Texto";
                ddlIdEmisor.DataValueField = "Valor";
                ddlIdEmisor.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    private void CargarISIN(DropDownList ddlEmisor, DropDownList ddlInstrumento)
    {
        try
        {
            #region CONTRUIR FILTROS

            StringBuilder _filtro = new StringBuilder();
            _filtro.Append(ddlIdInstrumentoFinanciero.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdEmisor.SelectedValue.ToString());

            #endregion

            LimpiarDropDownList(ddlIdISIN);
            if (ddlIdISIN != null)
            {
                ddlIdISIN.Items.Clear();
                ddlIdISIN.DataSource = LlenarDropDownList("EmisionesInstrumentosISINLista", _filtro.ToString());
                ddlIdISIN.DataTextField = "Texto";
                ddlIdISIN.DataValueField = "Valor";
                ddlIdISIN.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    private void CargarSerie(DropDownList ddlInstrumento, DropDownList ddlEmisor, DropDownList ddlISIN)
    {
        try
        {
            #region CONSTRUIR FILTROS

            StringBuilder _filtro = new StringBuilder();
            _filtro.Append(ddlIdInstrumentoFinanciero.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdEmisor.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdISIN.SelectedValue.ToString());

            #endregion

            LimpiarDropDownList(ddlIdSerieInstrumento);
            if (ddlIdSerieInstrumento != null)
            {
                ddlIdSerieInstrumento.Items.Clear();
                ddlIdSerieInstrumento.DataSource = LlenarDropDownList("EmisionesInstrumentosSerieLista", _filtro.ToString());
                ddlIdSerieInstrumento.DataTextField = "Texto";
                ddlIdSerieInstrumento.DataValueField = "Valor";
                ddlIdSerieInstrumento.DataBind();
            }
        }
        catch
        {
            throw;
        }
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

    private ControlEntidad BuscarControlesValores(List<ControlEntidad> controlEntidad, string nombreControl)
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
        updValoresPopUpControl.Update();
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