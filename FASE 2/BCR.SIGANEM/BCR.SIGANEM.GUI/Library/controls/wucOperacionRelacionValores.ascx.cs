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


public partial class wucOperacionRelacionValores : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region VARIABLES

    private StringBuilder _filtro = null;
    private string valorReemplazo = string.Empty;
    private BitacoraFlags _bitacoraBanderas = new BitacoraFlags();
    private MensajesEntidad _mensajesEntidad = new MensajesEntidad();
    private GeneradorControles _generadorControles = new GeneradorControles();
    private GarantiasWS.BitacorasEntidad _bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
    private GarantiasOperacionesRelacionEntidad _entidad = new GarantiasOperacionesRelacionEntidad();
    private GarantiasOperacionesRelacionEntidad _consulta = new GarantiasOperacionesRelacionEntidad();

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

        this.txtCodGarantiaBCR.Text = string.Empty;
        this.txtMontoMitigador.Text = string.Empty;
        this.txtMontoMitigadorCalculado.Text = string.Empty;
        this.txtMontoGradoGravamen.Text = string.Empty;
        this.txtMontoValorFacial.Text = string.Empty;
        this.txtFechaConstitucionGarantia.Text = string.Empty;
        this.txtPorcentajeAceptBCR.Text = string.Empty;
        this.txtFechaVencimientoGarantia.Text = string.Empty;
        this.txtPorcentajeAceptSugef.Text = string.Empty;
        this.txtFechaPrescripcionGarantia.Text = string.Empty;
        this.txtPorcentajeResponSugef.Text = string.Empty;
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
            #region TIPO INSTRUMENTO

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdTipoInstrumento.ID);
            this.lblIdTipoInstrumento.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdTipoInstrumento.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoInstrumento, string.Empty);
            _generadorControles.SeleccionarOpcionDropDownListCodigo(this.ddlIdTipoInstrumento, "1");

            #endregion
            #region INSTRUMENTO

            #region CONTRUIR FILTROS

            _filtro = new StringBuilder();
            _filtro.Append(ddlIdTipoInstrumento.SelectedValue.ToString());

            #endregion

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdInstrumento.ID);
            this.lblIdInstrumento.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdInstrumento.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdInstrumento, _filtro.ToString());
            _generadorControles.SeleccionarOpcionDropDownListCodigo(this.ddlIdInstrumento, "1");

            #endregion
            #region EMISOR

            #region CONTRUIR FILTROS

            _filtro = new StringBuilder();
            _filtro.Append(ddlIdInstrumento.SelectedValue.ToString());

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
            _filtro.Append(ddlIdInstrumento.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdEmisor.SelectedValue.ToString());

            #endregion

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdISIN.ID);
            this.lblIdISIN.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdISIN.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdISIN, _filtro.ToString());
            //_generadorControles.SeleccionarOpcionDropDownListCodigo(this.ddlISIN, "1");

            #endregion
            #region SERIE

            #region CONTRUIR FILTROS

            _filtro = new StringBuilder();
            _filtro.Append(ddlIdInstrumento.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdEmisor.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdISIN.SelectedValue.ToString());

            #endregion

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdSerie.ID);
            this.lblIdSerie.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdSerie.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdSerie, _filtro.ToString());
            //_generadorControles.SeleccionarOpcionDropDownListCodigo(this.ddlSerie, "1");

            #endregion
            #region COD GARANTIA BCR

            controlSeleccionado = BuscarControlesValores(controles, this.lblCodGarantiaBCR.ID);
            this.lblCodGarantiaBCR.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtCodGarantiaBCR.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtCodGarantiaBCR, this.mskCodGarantiaBCR);

            #endregion

            #endregion
            #region APARTADO DETALLE

            #region TIPO MONEDA FACIAL

            controlSeleccionado = BuscarControlesValores(controles, this.lblTipoMonedaFacial.ID);
            this.lblTipoMonedaFacial.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtTipoMonedaFacial.ID);
            CargarTextBoxControl(controlSeleccionado, txtTipoMonedaFacial);

            #endregion
            #region VALOR FACIAL

            controlSeleccionado = BuscarControlesValores(controles, this.lblMontoValorFacial.ID);
            this.lblMontoValorFacial.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtMontoValorFacial.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtMontoValorFacial);

            #endregion

            #endregion
            #region APARTADO ADICIONALES

            #region CLASE GARANTIA

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdClaseGarantiaPrt17.ID);
            this.lblIdClaseGarantiaPrt17.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdClaseGarantiaPrt17.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdClaseGarantiaPrt17, string.Empty);
            _generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIdClaseGarantiaPrt17, controlSeleccionado.ValorDefecto);

            #endregion
            #region CODIGO TENENCIA

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdTenenciaPrt15.ID);
            this.lblIdTenenciaPrt15.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdTenenciaPrt15.ID);

            #endregion
            #region GRADO GRAVAMEN

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdGradoGravamen.ID);
            this.lblIdGradoGravamen.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdGradoGravamen.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdGradoGravamen, string.Empty);
            AdministrarBlanco("ddlIdGradoGravamen", true);

            #endregion
            #region TIPO MITIGADOR RIESGO

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdTipoMitigadorRiesgo.ID);
            this.lblIdTipoMitigadorRiesgo.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdTipoMitigadorRiesgo.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoMitigadorRiesgo, controlSeleccionado.ValorServicioWeb);
            AdministrarBlanco("ddlIdTipoMitigadorRiesgo", true);

            #endregion
            #region TIPO MONEDA GRADO GRAVAMEN

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdTipoMonedaGradoGravamen.ID);
            this.lblIdTipoMonedaGradoGravamen.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdTipoMonedaGradoGravamen.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoMonedaGradoGravamen, string.Empty);

            #endregion
            #region TIPO DOCUMENTO

            controlSeleccionado = BuscarControlesValores(controles, this.lblIdTipoDocumentoLegal.ID);
            this.lblIdTipoDocumentoLegal.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesValores(controles, this.ddlIdTipoDocumentoLegal.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoDocumentoLegal, controlSeleccionado.ValorServicioWeb);
            _generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIdTipoDocumentoLegal, controlSeleccionado.ValorDefecto);

            #endregion
            #region MONTO GRAVAMEN

            controlSeleccionado = BuscarControlesValores(controles, this.lblMontoGradoGravamen.ID);
            this.lblMontoGradoGravamen.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtMontoGradoGravamen.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtMontoGradoGravamen, this.mskMontoGradoGravamenValores);
            //Ajustes cloaiza 2015-10-20
            this.wmMontoGradoGravamenValores.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion
            #region MONTO MITIGADOR

            controlSeleccionado = BuscarControlesValores(controles, this.lblMontoMitigador.ID);
            this.lblMontoMitigador.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtMontoMitigador.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtMontoMitigador, this.mskMontoMitigador);
            //Ajustes javendano 2015-01-12
            //this.wmMontoMitigador.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion
            #region MONTO MITIGADOR CALCULADO

            controlSeleccionado = BuscarControlesValores(controles, this.lblMontoMitigadorCalculado.ID);
            this.lblMontoMitigadorCalculado.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtMontoMitigadorCalculado.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtMontoMitigadorCalculado, this.mskMontoMitigadorCalculado);
            //Ajustes javendano 2015-01-12
            //this.wmMontoMitigadorCalculado.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            //DESHABILITA EL CAMPO MONTO MITIGADOR CALCULADO 
            this.txtMontoMitigadorCalculado.Enabled = false;

            #endregion
            #region FECHA CONSTITUCION

            controlSeleccionado = BuscarControlesValores(controles, this.lblFechaConstitucionGarantia.ID);
            this.lblFechaConstitucionGarantia.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtFechaConstitucionGarantia.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtFechaConstitucionGarantia, imgFechaConstitucionGarantia);

            #endregion
            #region FECHA VENCIMIENTO

            controlSeleccionado = BuscarControlesValores(controles, this.lblFechaVencimientoGarantia.ID);
            this.lblFechaVencimientoGarantia.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtFechaVencimientoGarantia.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtFechaVencimientoGarantia, imgFechaVencimientoGarantia);

            #endregion
            #region FECHA PRESCRIPCION

            controlSeleccionado = BuscarControlesValores(controles, this.lblFechaPrescripcionGarantia.ID);
            this.lblFechaPrescripcionGarantia.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtFechaPrescripcionGarantia.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtFechaPrescripcionGarantia, imgFechaPrescripcionGarantia);

            #endregion
            #region PORCENTAJE ACEPTACIÓN BCR

            controlSeleccionado = BuscarControlesValores(controles, this.lblPorcentajeAceptBCR.ID);
            this.lblPorcentajeAceptBCR.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtPorcentajeAceptBCR.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtPorcentajeAceptBCR, this.mskPorcentajeAceptBCR);
            //Ajustes javendano 2015-01-12
            this.wmPorcentajeAceptBCR.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion
            #region PORCENTAJE ACEPTACIÓN SUGEF

            controlSeleccionado = BuscarControlesValores(controles, this.lblPorcentajeAceptSugef.ID);
            this.lblPorcentajeAceptSugef.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtPorcentajeAceptSugef.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtPorcentajeAceptSugef, this.mskPorcentajeAceptSugef);
            //Ajustes javendano 2015-01-12
            this.wmPorcentajeAceptSugef.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion
            #region PORCENTAJE RESPONSABILIDAD SUGEF

            controlSeleccionado = BuscarControlesValores(controles, this.lblPorcentajeResponSugef.ID);
            this.lblPorcentajeResponSugef.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesValores(controles, this.txtPorcentajeResponSugef.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtPorcentajeResponSugef, this.mskPorcentajeResponSugef);
            ////Ajustes javendano 2015-01-12
            //this.wmPorcentajeResponSugef.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            //DESHABILITA EL CAMPO PORCENTAJE RESPONSABILIDAD SUGEF Ajustes cloaiza 2015-10-20
            this.txtPorcentajeResponSugef.Enabled = false;

            #endregion

            #endregion

            updValoresPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    protected void btnConsultarGarantia_Click(object sender, EventArgs e)
    {
        try
        {
            string[] sesion = valorSesionOculto.Value.Split('|');
            RespuestaConsultaSesion _sesion = wsSesiones.ConsultarSesion(sesion[0]);
            if (_sesion.Codigo == 0)
            {
                #region ENTIDAD CONSULTA

                _entidad.IdTipoValor = int.Parse(ddlIdTipoValor.SelectedValue);
                _entidad.IdTipoInstrumento = int.Parse(ddlIdTipoInstrumento.SelectedValue);
                _entidad.IdInstrumento = int.Parse(ddlIdInstrumento.SelectedValue);
                _entidad.IdEmisor = int.Parse(ddlIdEmisor.SelectedValue);
                _entidad.ISIN = ddlIdISIN.SelectedValue;
                _entidad.Serie = ddlIdSerie.SelectedValue;
                _entidad.CodGarantiaBCR = txtCodGarantiaBCR.Text;

                #endregion

                _consulta = wsGarantias.OperacionesGarantiasValoresBusqueda(_entidad);
                if (_consulta != null)
                {
                    idGarantiaValorOculto.Value = _consulta.IdGarantiaValor.ToString();
                    txtMontoValorFacial.Text = _consulta.MontoValorFacial.ToString();
                    txtTipoMonedaFacial.Text = _consulta.TipoMonedaValorFacial.ToString();

                    //DESHABILITAR LA TABLA GENERALES
                    _generadorControles.Bloquear_Controles(tableGeneral, false);
                    //HABILITAR LA TABLA ADICIONALES
                    tableAdicionales.Disabled = false;
                    btnConsultarGarantia.Enabled = false;
                    btnConsultarGarantia.CssClass = "botonConsultarRelacionDisabled";

                    #region ADMINISTRAR ESPACIOS BLANCOS

                    CargarTenenciaPRT15(ddlIdTenenciaPrt15);
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

            _entidad.IdOperacion = int.Parse(sesion[3]);
            _entidad.IdGarantiaOperacion = int.Parse(sesion[3]);
            _entidad.IdGarantiaValor = int.Parse(idGarantiaValorOculto.Value);
            _entidad.IdTipoGarantia = int.Parse(sesion[4]);


            #region APARTADO GENERAL

            //TIPO VALOR
            _entidad.IdTipoValor = int.Parse(ddlIdTipoValor.SelectedValue);
            //TIPO INSTRUMENTO
            _entidad.IdTipoInstrumento = int.Parse(ddlIdTipoInstrumento.SelectedValue);
            //INSTRUMENTO
            _entidad.IdInstrumento = int.Parse(ddlIdInstrumento.SelectedValue);
            //EMISOR
            _entidad.IdEmisor = int.Parse(ddlIdEmisor.SelectedValue);
            //ISIN
            _entidad.ISIN = ddlIdISIN.SelectedValue;
            //SERIE
            _entidad.Serie = ddlIdSerie.SelectedValue;
            //COD GARANTIA BCR
            _entidad.CodGarantiaBCR = txtCodGarantiaBCR.Text;

            #endregion
            #region APARTADO DETALLE

            //TIPO MONEDA VALOR FACIAL
            _entidad.TipoMoneda = txtTipoMonedaFacial.Text;
            //MONTO ULTIMA TASACION TERRENO
            _entidad.MontoValorFacial = decimal.Parse(txtMontoValorFacial.Text);

            #endregion
            #region APARTADO ADICIONALES

            //CLASE GARANTIA
            _entidad.IdClaseGarantiaPrt17 = int.Parse(ddlIdClaseGarantiaPrt17.SelectedItem.Value);
            //GRADO GRAVAMEN
            _entidad.IdGradoGravamen = int.Parse(ddlIdGradoGravamen.SelectedItem.Value);
            //TIPO MONEDA GRADO GRAVAMEN
            _entidad.IdTipoMonedaGradoGravamen = int.Parse(ddlIdTipoMonedaGradoGravamen.SelectedItem.Value);
            //TIPO DOCUMENTO LEGAL
            _entidad.IdTipoDocumentoLegal = int.Parse(ddlIdTipoDocumentoLegal.SelectedItem.Value);
            //TIPO MITIGADOR RIESGO
            _entidad.IdTipoMitigadorRiesgo = int.Parse(ddlIdTipoMitigadorRiesgo.SelectedItem.Value);
            //CODIGO TENENCIA
            _entidad.IdTenenciaPrt15 = int.Parse(ddlIdTenenciaPrt15.SelectedItem.Value);
            //MONTO GRADO GRAVAMEN
            //Ajuste cloaiza 2015-10-20
            if (txtMontoGradoGravamen.Text.Length > 0)
                _entidad.MontoGradoGravamen = decimal.Parse(txtMontoGradoGravamen.Text);
            else
                _entidad.MontoGradoGravamen = decimal.Parse(wmMontoGradoGravamenValores.WatermarkText);
            //MONTO MITIGADOR
            if (txtMontoMitigador.Text.Length > 0)
                _entidad.MontoMitigador = decimal.Parse(txtMontoMitigador.Text);
            else
                _entidad.MontoMitigador = null;
            //MONTO MITIGADOR CALCULADO
            //Ajuste javendano 2015-01-12
            if (txtMontoMitigadorCalculado.Text.Length > 0)
                _entidad.MontoMitigadorCalculado = decimal.Parse(txtMontoMitigadorCalculado.Text);
            else
                //_entidad.MontoMitigadorCalculado = decimal.Parse(wmMontoMitigadorCalculado.WatermarkText);
                _entidad.MontoMitigadorCalculado = null;
            //FECHA CONSTITUCION GARANTIA
            _entidad.FechaConstitucionGarantia = DateTime.Parse(txtFechaConstitucionGarantia.Text);
            //FECHA VENCIMIENTO GARANTIA
            _entidad.FechaVencimientoGarantia = DateTime.Parse(txtFechaVencimientoGarantia.Text);
            //FECHA PRESCRIPCION GARANTIA
            _entidad.FechaPrescripcionGarantia = DateTime.Parse(txtFechaPrescripcionGarantia.Text);
            //PORCENTAJE ACEPTACION BCR
            //Ajuste javendano 2015-01-12
            if (txtPorcentajeAceptBCR.Text.Length > 0)
                _entidad.PorcentajeAceptBCR = decimal.Parse(txtPorcentajeAceptBCR.Text);
            else
                _entidad.PorcentajeAceptBCR = decimal.Parse(wmPorcentajeAceptBCR.WatermarkText);
            //PORCENTAJE ACEPTACION SUGEF
            //Ajuste javendano 2015-01-12
            if (txtPorcentajeAceptSugef.Text.Length > 0)
                _entidad.PorcentajeAceptNoTerrenoSugef = decimal.Parse(txtPorcentajeAceptSugef.Text);
            else
                _entidad.PorcentajeAceptNoTerrenoSugef = decimal.Parse(wmPorcentajeAceptSugef.WatermarkText);
            //PORCENTAJE RESPONSABILIDAD SUGEF
            //Ajuste javendano 2015-01-12
            if (txtPorcentajeResponSugef.Text.Length > 0)
                _entidad.PorcentajeResponSugef = decimal.Parse(txtPorcentajeResponSugef.Text);
            else
                _entidad.PorcentajeResponSugef = null;

            #endregion
            //REQUERIMIENTO BLOQUE 7 1-24381561
            #region CONTROL DE REGISTRO

            _entidad.CodUsuarioIngreso = sesion[2];
            _entidad.IndMetodoInsercion = Resources.Resource._metodoInsercion;

            #endregion
            #region DIRECCIONAMIENTO SEGUN EL TIPO DE ACCION

            bool validarFechas = ValidarFechaVencimiento(this.txtFechaConstitucionGarantia.Text, txtFechaVencimientoGarantia.Text, txtFechaPrescripcionGarantia.Text);
            if (!validarFechas)
            {
                result.ValorError = -1;
            }
            else
            {
                //LA FECHA DE PRESCRIPCION NO SE DEBE DE GUARDAR AL INSERTAR O MODIFICAR UNA GARANTIA, SOLO SE DEBE REGRISTRAR AL REPLICAR
                _entidad.FechaPrescripcionGarantia = null;

                switch (tipoAccion)
                {
                    case 0:
                        _entidad.IndEstadoReplicado = (int)EnumTipoEstadoGarantia.PENDIENTE;
                        result = wsGarantias.GarantiasOperacionesInsertarRelacion(_entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));
                        break;
                    case 1:
                        _entidad.IndEstadoReplicado = ObtenerEstadoGarantia(estadoGarantiaOculto.Value);
                        result = wsGarantias.GarantiasOperacionesModificarRelacion(_entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));
                        break;
                }
            }

            return result;

            #endregion
        }
        catch
        {
            throw;
        }
    }

    public void DeEntidadAControles(GarantiasOperacionesRelacionEntidad _entidadOperacion, GarantiasValoresEntidad _entidadValores)
    {
        try
        {
            idGarantiaValorOculto.Value = _entidadOperacion.IdGarantiaValor.ToString();

            //Ajuste javendano 2015-01-09
            #region APARTADO ENCABEZADO

            //TIPO VALOR
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoValor, _entidadValores.IdTipoValor.ToString());
            ddlTipoValor(ddlIdTipoValor);
            //TIPO INSTRUMENTO
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoInstrumento, _entidadValores.IdTipoInstrumento.ToString());
            ddlTipoInstrumento(ddlIdTipoInstrumento);
            //INSTRUMENTO
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdInstrumento, _entidadValores.IdInstrumento.ToString());
            ddlInstrumento(ddlIdInstrumento);
            //EMISOR
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdEmisor, _entidadValores.IdEmisor.ToString());
            ddlEmisor(ddlIdEmisor);
            //ISIN
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdISIN, _entidadValores.ISIN.ToString());
            ddlISIN(ddlIdISIN);
            //SERIE
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdSerie, _entidadValores.Serie.ToString());
            ddlSerie(ddlIdSerie);
            //COD GARANTIA BCR
            txtCodGarantiaBCR.Text = _entidadValores.CodGarantiaBCR.ToString();

            #endregion

            #region APARTADO DETALLE

            btnConsultarGarantia_Click(null, null);

            #endregion

            #region APARTADO ADICIONALES
            //CLASE GARANTIA
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdClaseGarantiaPrt17, _entidadOperacion.IdClaseGarantiaPrt17.ToString());
            //GRADO GRAVAMEN
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdGradoGravamen, _entidadOperacion.IdGradoGravamen.ToString());
            //CODIGO TENENCIA
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTenenciaPrt15, _entidadOperacion.IdTenenciaPrt15.ToString());
            //TIPO DOCUMENTO LEGAL
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoDocumentoLegal, _entidadOperacion.IdTipoDocumentoLegal.ToString());
            //TIPO MITIGADOR RIESGO
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoMitigadorRiesgo, _entidadOperacion.IdTipoMitigadorRiesgo.ToString());
            //MONTO GRADO GRAVAMEN
            txtMontoGradoGravamen.Text = _entidadOperacion.MontoGradoGravamen.ToString();
            //MONTO MITIGADOR
            txtMontoMitigador.Text = _entidadOperacion.MontoMitigador.ToString();
            //MONTO MITIGADOR CALCULADO
            if (_entidadOperacion.MontoMitigadorCalculado.ToString().Length > 0)
                txtMontoMitigadorCalculado.Text = string.Format("{0:N}", _entidadOperacion.MontoMitigadorCalculado);
            else
                txtMontoMitigadorCalculado.Text = string.Empty;
            //PORCENTAJE ACEPTACION BCR
            txtPorcentajeAceptBCR.Text = _entidadOperacion.PorcentajeAceptBCR.ToString();
            //PORCENTAJE ACEPTACION SUGEF
            txtPorcentajeAceptSugef.Text = _entidadOperacion.PorcentajeAceptNoTerrenoSugef.ToString();
            //PORCENTAJE RESPONSABILIDAD SUGEF
            txtPorcentajeResponSugef.Text = _entidadOperacion.PorcentajeResponSugef.ToString();
            //INDICADOR RECOMENDACION PERITO
            _entidad.IdIndicadorRecomendacion = 0;
            //INDICADOR INSPECCION PERITO
            _entidad.IdIndicadorInspeccion = 0;
            //INDICADOR POLIZA
            //_entidad.IdPoliza = 0;
            //INDICADOR HABITA
            _entidad.IdDeudorHabita = 0;

            #endregion
        }
        catch
        {
            throw;
        }
    }

    public void DesplegarMensajeError(GarantiasWS.RespuestaEntidad _result)
    {
        #region LIMPIAR MENSAJES

        //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
        if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
        {
            this.divBarraMensaje.Visible = false;
        }

        #endregion

        if (_result.ValorError.Equals(-1))
        {
            BarraMensaje("SYS_35");
        }
        else
        {
            BarraMensaje("SQL_" + _result.ValorError);
        }
    }

    public bool ValidarPorcentajeAceptacion()
    {
        try
        {
            bool fueraRango = false;
            Decimal campo = 0;

            //SI CAMPO ES MENOS MAYOR A 100 O MENOR A CERO 
            if (txtPorcentajeAceptBCR.Text.Length > 0)
                campo = Decimal.Parse(this.txtPorcentajeAceptBCR.Text);
            else
                campo = Decimal.Parse(this.wmPorcentajeAceptBCR.WatermarkText);

            if (campo < 0 || campo > 100)
            {
                //MENSAJE DE ERROR DEL VALOR
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblPorcentajeAceptBCR.Text, "Mayor o Igual a 0 y Menor o Igual a 100");
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
                case "DDLIDTIPOINSTRUMENTO":
                    ddlTipoInstrumento(sender);
                    break;
                #endregion

                #region INSTRUMENTO
                case "DDLIDINSTRUMENTO":
                    ddlInstrumento(sender);
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

    private void ddlTipoInstrumento(object sender)
    {
        try
        {
            switch (ObtenerTipoValor())
            {
                case 1:
                    CargarInstrumento(sender);
                    CargarEmisor(ddlIdInstrumento);
                    CargarISIN(ddlIdEmisor, ddlIdInstrumento);
                    CargarSerie(ddlIdInstrumento, ddlIdEmisor, ddlIdISIN);
                    break;
            }

            updValoresPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void ddlInstrumento(object sender)
    {
        try
        {
            switch (ObtenerTipoValor())
            {
                case 1:
                    CargarEmisor(sender);
                    CargarISIN(ddlIdEmisor, ddlIdInstrumento);
                    CargarSerie(ddlIdInstrumento, ddlIdEmisor, ddlIdISIN);
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
                    CargarISIN(ddlIdEmisor, ddlIdInstrumento);
                    CargarSerie(ddlIdInstrumento, ddlIdEmisor, ddlIdISIN);
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
                    CargarSerie(ddlIdInstrumento, ddlIdEmisor, ddlIdISIN);
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

    protected void txtMontoGradoGravamen_TextChanged(object sender, EventArgs e)
    {
        try
        {
            MontoGradoGravamen(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void MontoGradoGravamen(object sender, EventArgs e)
    {
        try
        {
            //if (this.txtMontoGradoGravamen.Enabled)
            //{
            //    //MONTOGRADOGRAVAMEN DEBE SER MAYOR CERO
            //    string Monto = _generadorControles.EliminarErrorMascara(this.txtMontoGradoGravamen.Text);
            //    if (_generadorControles.ObtenerComparacion("0,01", Monto, EnumTipoComparacion.MAYOR, TypeCode.Decimal))
            //    {
            //        //LIMPIA LOS CAMPOS
            //        this.txtMontoGradoGravamen.Text = string.Empty;
            //        //MENSAJE DE ERROR DEL VALOR
            //        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblMontoGradoGravamen.Text, "Mayor a Cero");
            //        this.mpeInformarBox.Show();
            //    }
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region EXCEPCIONES TIPO VALORES

    private void InsertarExcepcionOtrosValores()
    {
        try
        {
            LimpiarContenidoFormulario();

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            ddlIdTipoInstrumento.Enabled = true;
            ddlIdInstrumento.Enabled = true;
            ddlIdEmisor.Enabled = true;

            CargarTipoInstrumento();
            CargarInstrumento(ddlIdTipoInstrumento);
            CargarEmisor(ddlIdInstrumento);

            #endregion

            #region ISIN / SERIE / ID GARANTIA

            ddlIdISIN.Enabled = true;
            ddlIdSerie.Enabled = true;
            CargarISIN(ddlIdEmisor, ddlIdInstrumento);
            CargarSerie(ddlIdInstrumento, ddlIdEmisor, ddlIdISIN);

            mskCodGarantiaBCR.Enabled = false;
            txtCodGarantiaBCR.MaxLength = 12;
            mskCodGarantiaBCR.Filtered = "^[a-zA-Z0-9-]*$";

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

            ddlIdTipoInstrumento.Enabled = false;
            ddlIdInstrumento.Enabled = false;
            ddlIdEmisor.Enabled = false;

            CargarTipoInstrumentoTodos();
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoInstrumento, "CDP-CI");
            CargarInstrumento(ddlIdTipoInstrumento);
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdInstrumento, "CDP-CI");
            CargarOtrosEmisores();
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdEmisor, "BCR");

            #endregion

            #region ISIN / SERIE / ID GARANTIA

            ddlIdISIN.Enabled = false;
            ddlIdSerie.Enabled = false;
            LimpiarDropDownList(ddlIdISIN);
            LimpiarDropDownList(ddlIdSerie);

            mskCodGarantiaBCR.Enabled = false;
            txtCodGarantiaBCR.MaxLength = 12;
            mskCodGarantiaBCR.Filtered = "^[a-zA-Z0-9-]*$";

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

            ddlIdTipoInstrumento.Enabled = false;
            ddlIdInstrumento.Enabled = false;
            ddlIdEmisor.Enabled = true;

            CargarTipoInstrumentoTodos();
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoInstrumento, "CDP-CI");
            CargarInstrumento(ddlIdTipoInstrumento);
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdInstrumento, "CDP-CI");
            CargarOtrosEmisores();

            #endregion

            #region ISIN / SERIE / ID GARANTIA

            ddlIdISIN.Enabled = false;
            ddlIdSerie.Enabled = false;
            LimpiarDropDownList(ddlIdISIN);
            LimpiarDropDownList(ddlIdSerie);

            mskCodGarantiaBCR.Enabled = false;
            txtCodGarantiaBCR.MaxLength = 12;
            mskCodGarantiaBCR.Filtered = "^[a-zA-Z0-9-]*$";

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

            ddlIdTipoInstrumento.Enabled = true;
            ddlIdInstrumento.Enabled = true;
            ddlIdEmisor.Enabled = true;

            CargarTipoInstrumentoTodos();
            CargarInstrumentosTodos();
            CargarOtrosEmisores();

            #endregion

            #region ISIN / SERIE / ID GARANTIA

            ddlIdISIN.Enabled = false;
            ddlIdSerie.Enabled = false;
            LimpiarDropDownList(ddlIdISIN);
            LimpiarDropDownList(ddlIdSerie);

            mskCodGarantiaBCR.Enabled = false;
            txtCodGarantiaBCR.MaxLength = 12;
            mskCodGarantiaBCR.Filtered = "^[a-zA-Z0-9-]*$";

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
    private bool ValidarCaracterEspecial(string texto)
    {
        bool existeCaracter = false;
        //NO SE PERMITEN CARACTERES ESPECIALES
        var regexItem = new Regex("^[a-zA-Z0-9-]*$");

        if (!regexItem.IsMatch(texto))
            existeCaracter = true;

        return existeCaracter;
    }

    private void LimpiarContenidoFormulario()
    {
        ddlIdTipoInstrumento.SelectedIndex = -1;
    }

    private int ObtenerTipoValor()
    {
        return int.Parse(ddlIdTipoValor.SelectedValue);
    }

    private string ObtenerTipoInstrumento()
    {
        return ddlIdTipoInstrumento.SelectedItem.Text.Split('-')[0].Trim();
    }

    private void CargarTipoInstrumento()
    {
        try
        {
            LimpiarDropDownList(ddlIdTipoInstrumento);
            if (ddlIdTipoInstrumento != null)
            {
                ddlIdTipoInstrumento.Items.Clear();
                ddlIdTipoInstrumento.DataSource = LlenarDropDownList("InstrumentosTipoInstrumentoLista", string.Empty);
                ddlIdTipoInstrumento.DataTextField = "Texto";
                ddlIdTipoInstrumento.DataValueField = "Valor";
                ddlIdTipoInstrumento.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarTipoInstrumentoTodos()
    {
        try
        {
            LimpiarDropDownList(ddlIdTipoInstrumento);
            if (ddlIdTipoInstrumento != null)
            {
                ddlIdTipoInstrumento.Items.Clear();
                ddlIdTipoInstrumento.DataSource = LlenarDropDownList("TiposInstrumentosFiltradoInstrumentosLista", string.Empty);
                ddlIdTipoInstrumento.DataTextField = "Texto";
                ddlIdTipoInstrumento.DataValueField = "Valor";
                ddlIdTipoInstrumento.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    private void CargarInstrumento(object sender)
    {
        try
        {
            LimpiarDropDownList(ddlIdInstrumento);
            if (ddlIdInstrumento != null)
            {
                ddlIdInstrumento.Items.Clear();
                ddlIdInstrumento.DataSource = LlenarDropDownList("InstrumentosEmisionesFiltradoLista", ((DropDownList)(sender)).SelectedValue.ToString());
                ddlIdInstrumento.DataTextField = "Texto";
                ddlIdInstrumento.DataValueField = "Valor";
                ddlIdInstrumento.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    private void CargarInstrumentosTodos()
    {
        try
        {
            LimpiarDropDownList(ddlIdInstrumento);
            if (ddlIdInstrumento != null)
            {
                ddlIdInstrumento.Items.Clear();
                ddlIdInstrumento.DataSource = LlenarDropDownList("InstrumentosLista", string.Empty);
                ddlIdInstrumento.DataTextField = "Texto";
                ddlIdInstrumento.DataValueField = "Valor";
                ddlIdInstrumento.DataBind();
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
            _filtro.Append(ddlIdInstrumento.SelectedValue.ToString());
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
            _filtro.Append(ddlIdInstrumento.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdEmisor.SelectedValue.ToString());
            _filtro.Append('|');
            _filtro.Append(ddlIdISIN.SelectedValue.ToString());

            #endregion

            LimpiarDropDownList(ddlIdSerie);
            if (ddlIdSerie != null)
            {
                ddlIdSerie.Items.Clear();
                ddlIdSerie.DataSource = LlenarDropDownList("EmisionesInstrumentosSerieLista", _filtro.ToString());
                ddlIdSerie.DataTextField = "Texto";
                ddlIdSerie.DataValueField = "Valor";
                ddlIdSerie.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    private void CargarTenenciaPRT15(DropDownList ddlTenenciaPrt15)
    {
        string _idTipoInstrumento = ddlIdTipoInstrumento.SelectedItem.Value;
        string _idTipoValor = ddlIdTipoValor.SelectedItem.Value;

        try
        {
            LimpiarDropDownList(ddlTenenciaPrt15);
            object _dataSource = wsListas.TiposValoresTenenciasTiposInstrumentosLista(_idTipoInstrumento, _idTipoValor);


            if (ddlTenenciaPrt15 != null)
            {
                ddlTenenciaPrt15.Items.Clear();
                ddlTenenciaPrt15.DataSource = _dataSource;
                ddlTenenciaPrt15.DataTextField = "Texto";
                ddlTenenciaPrt15.DataValueField = "Valor";
                ddlTenenciaPrt15.DataBind();

                if (ddlTenenciaPrt15.Items.Count > 1)
                    ddlTenenciaPrt15.Enabled = true;
                else
                    ddlTenenciaPrt15.Enabled = false;
            }
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region ENTIDADES

    protected GarantiasWS.BitacorasEntidad AsignarValoresBitacora(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA

            string[] sesion = valorSesionOculto.Value.Split('|');
            _bitacorasEntidad.CodAccion = _bitacoraBanderas.TipoBitacoraConsulta(_tipo);
            _bitacorasEntidad.CodModulo = int.Parse(sesion[1]);
            _bitacorasEntidad.CodEmpresa = int.Parse(Resources.Resource._empresa);
            _bitacorasEntidad.CodSistema = Resources.Resource._sistema;
            _bitacorasEntidad.CodUsuario = sesion[2];

            #endregion

            return _bitacorasEntidad;
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

    private void CargarTextBoxControl(ControlEntidad _control, TextBox _textBox)
    {
        #region TEXTBOX
        _textBox.Text = _control.ValorDefecto;
        _textBox.ToolTip = String.Concat("Texto ", _control.DesColumna);
        _textBox.Enabled = bool.Parse(_control.IndModificar);
        _textBox.Visible = bool.Parse(_control.IndVisible);
        _textBox.CssClass = _control.CssTipo;
        if (!_control.LongitudMaxima.Length.Equals(0))
            _textBox.Width = Unit.Parse((int.Parse(_control.LongitudMaxima) * 9).ToString() + "px");
        if (!_control.LongitudMaxima.Length.Equals(0))
            _textBox.MaxLength = Int32.Parse(_control.LongitudMaxima);
        if (!String.IsNullOrEmpty(_control.GrupoValidacion))
            _textBox.ValidationGroup = _control.GrupoValidacion;

        #endregion
    }

    private void CargarTextBoxControl(ControlEntidad _control, TextBox _textBox, ImageButton _imageButton)
    {
        #region TEXTBOX
        _textBox.Text = _control.ValorDefecto;
        _textBox.ToolTip = String.Concat("Texto ", _control.DesColumna);
        _textBox.Enabled = bool.Parse(_control.IndModificar);
        _textBox.Visible = bool.Parse(_control.IndVisible);
        _textBox.CssClass = _control.CssTipo;
        _textBox.MaxLength = Int32.Parse("10");
        if (!String.IsNullOrEmpty(_control.GrupoValidacion))
            _textBox.ValidationGroup = _control.GrupoValidacion;

        #endregion
        #region CALENDAR EXTENDER

        _imageButton.ToolTip = "Click para abrir el Calendario ";
        _imageButton.Enabled = bool.Parse(_control.IndModificar);
        _imageButton.Visible = bool.Parse(_control.IndVisible);
        _imageButton.CausesValidation = false;
        if (_imageButton.Enabled)
            _imageButton.ImageUrl = "~/Library/img/32/iconCalendario.gif";
        else
            _imageButton.ImageUrl = "~/Library/img/32/iconCalendario_dis.gif";

        #endregion
    }

    private void CargarTextBoxControl(ControlEntidad _control, TextBox _textBox, MaskedEditExtender _maskedEditExtender)
    {
        #region TEXTBOX
        _textBox.Text = _control.ValorDefecto;
        _textBox.ToolTip = String.Concat("Texto ", _control.DesColumna);
        _textBox.Enabled = bool.Parse(_control.IndModificar);
        _textBox.Visible = bool.Parse(_control.IndVisible);
        _textBox.CssClass = _control.CssTipo;
        if (!_control.LongitudMaxima.Length.Equals(0))
            _textBox.MaxLength = Int32.Parse(_control.LongitudMaxima);

        if (_textBox.ID.Contains("Porcentaje"))
            _textBox.Width = Unit.Parse("55px");
        else
        {
            if (!_control.LongitudMaxima.Length.Equals(0))
                _textBox.Width = Unit.Parse((int.Parse(_control.LongitudMaxima) * 9).ToString() + "px");
        }
        if (!String.IsNullOrEmpty(_control.GrupoValidacion))
            _textBox.ValidationGroup = _control.GrupoValidacion;

        #endregion
        #region MASKEDEDIT EXTENDER

        int m = Int32.Parse(_control.Mascara);
        if (m > 0)
        {
            _maskedEditExtender.ClearTextOnInvalid = true;
            _maskedEditExtender.ClearMaskOnLostFocus = true;
            _maskedEditExtender.InputDirection = MaskedEditInputDirection.RightToLeft;
            _maskedEditExtender.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();

            _maskedEditExtender.MaskType = _generadorControles.DeterminaTipoMascara(m);
            if (_textBox.ID.Contains("Monto") || _textBox.ID.Contains("Porcentaje"))
                _maskedEditExtender.Mask = _control.ValorMascara;
            else
                _maskedEditExtender.Mask = _generadorControles.DeterminaFormatoMascara(Int32.Parse(_control.LongitudMaxima), _control.ValorMascara);
        }
        else
        {
            _maskedEditExtender.MaskType = MaskedEditType.None;
        }

        #endregion
    }

    private void CargarDropDownListControl(ControlEntidad _control, DropDownList _dropDownList, string _filtro)
    {
        #region DROPDOWNLIST
        //LIMPIAR EL CONTROL DROPDOWNLIST
        LimpiarDropDownList(_dropDownList);
        //CARGAR EL DROPDOWNLIS
        if (!_control.MetodoServicioWeb.Equals(""))
        {
            _dropDownList.DataSource = LlenarDropDownList(_control.MetodoServicioWeb, _filtro);
            _dropDownList.DataValueField = "Valor";
            _dropDownList.DataTextField = "Texto";
            _dropDownList.DataBind();
        }
        _dropDownList.Enabled = bool.Parse(_control.IndModificar);
        _dropDownList.Visible = bool.Parse(_control.IndVisible);
        _dropDownList.CssClass = _control.CssTipo;

        #endregion
    }

    private void LimpiarDropDownList(DropDownList _dropDownList)
    {
        //BORRA LOS VALORES DEL DDL, SE DEBE DE REALIZAR DE ESTA MANERA PARA ELIMINAR LOS DATOS EN CACHÉ DEL OBJ
        _dropDownList.ClearSelection();
        _dropDownList.Items.Clear();
        _dropDownList.SelectedValue = null;
        _dropDownList.DataSource = null;
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

            return null;
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

    private bool ValidarFechaVencimiento(string fechaConstitucion, string fechaVencimiento, string fechaPrescripcion)
    {
        bool resultado = true;
        //FECHA VENCIMIENTO NO PUEDE SER MENOR A FECHA CONSTITUCION
        if (_generadorControles.ObtenerComparacion(fechaVencimiento, fechaConstitucion, EnumTipoComparacion.MENOR, TypeCode.DateTime))
        {
            resultado = false;
        }
        //FECHA VENCIMIENTO NO PUEDE SER MAYOR A FECHA PRESCRIPCION
        if (_generadorControles.ObtenerComparacion(fechaVencimiento, fechaPrescripcion, EnumTipoComparacion.MAYOR, TypeCode.DateTime))
        {
            resultado = false;
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
            InformarBox1.SetMessageBox(_mensaje.DesTipoMensaje, _mensaje.DesMensaje.Replace("@@@", valorReemplazo));
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