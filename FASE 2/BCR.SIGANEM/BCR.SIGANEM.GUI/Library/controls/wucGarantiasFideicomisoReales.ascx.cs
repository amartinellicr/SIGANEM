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


public partial class wucGarantiasFideicomisoReales : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region VARIABLES

    private string valorReemplazo = string.Empty;
    private BitacoraFlags _bitacoraBanderas = new BitacoraFlags();
    private MensajesEntidad _mensajesEntidad = new MensajesEntidad();
    private GeneradorControles _generadorControles = new GeneradorControles();
    private GarantiasWS.BitacorasEntidad _bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
    /*CAMBIAR POR FIDEICOMETIDA*/
    private GarantiasRealesEntidad _entidad = new GarantiasRealesEntidad();
    private GarantiasRealesEntidad _consulta = new GarantiasRealesEntidad();

    #endregion

    #region CONTROLES

    #region VENTANA CONSULTA CLASE VEHICULO

    private GridView gridViewClaseVehiculo = null;
    private Button btnCerrarClaseVehiculo = null;
    private Button btnAceptarClaseVehiculo = null;

    #endregion

    #region GRID ADMINISTRACION CEDULAS

    private GridView gridCedulasInterno = null;

    #endregion

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

            //EFECTO DE AUTOCOMPLETAR PARA EL CAMPO N BIEN 
            //RQ_MANT_2016050410580724: BACKLOG 3943 - SE COMENTA
            //txtCodigoBien.Attributes.Add("onblur", "AutoCompletar('" + txtCodigoBien.ClientID + "','" + ddlTipoBien.ClientID + "','" + ddlIdFormatoIdentificacionVehiculo.ClientID + "','0')");

            #region MENSAJE INFORMAR

            Button wcBtnAccept = (Button)InformarBox1.FindControl("wucBtnAceptar");
            wcBtnAccept.Click += new EventHandler(BtnAceptarInformar_Click);

            InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

            #region LIMPIAR MENSAJES

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
            {
                this.divBarraMensaje.Visible = false;
            }

            #endregion

            #region VENTANA BUSQUEDA CLASE VEHICULO

            //GRID VENTANA BUSQUEDA CLASE VEHICULO
            GridViewClaseVehiculo(sender, e);

            #region BOTONES CLASE VEHICULO

            btnCerrarClaseVehiculo = ((Button)BusquedaClaseVehiculo.FindControl("cmdMainEmergenteCancelar"));
            btnCerrarClaseVehiculo.Click += new EventHandler(btnCerrarClaseVehiculo_Click);
            btnCerrarClaseVehiculo.CausesValidation = false;

            btnAceptarClaseVehiculo = ((Button)BusquedaClaseVehiculo.FindControl("cmdMainEmergenteAceptar"));
            btnAceptarClaseVehiculo.Click += new EventHandler(btnAceptarClaseVehiculo_Click);
            btnAceptarClaseVehiculo.CausesValidation = false;

            #region MENSAJE INFORMAR VENTANA BUSQUEDA CLASE VEHICULO

            Button btnAceptarInformarClaseVehiculo = (Button)InformarClaseVehiculo.FindControl("wucBtnAceptar");
            btnAceptarInformarClaseVehiculo.Click += new EventHandler(btnAceptarInformarClaseVehiculo_Click);
            btnAceptarInformarClaseVehiculo.CausesValidation = false;
            InformarClaseVehiculo.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarClaseVehiculo_SetConfirmationBoxEvent);

            #endregion

            #endregion

            #endregion

            #region VENTANA GRID CEDULAS

            grdCedulas.HabilitarBotonesControl(false);

            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            gridCedulasInterno = (GridView)grdCedulas.FindControl("MasterGridView");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            gridCedulasInterno.Init += new EventHandler(gridCedulasInterno_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            gridCedulasInterno_Init(sender, e);

            //ASIGNA DATA KEYS
            String[] DataKeysString = { "IdGarantiaRealCedula" };
            SetDataKeys(gridCedulasInterno, DataKeysString);

            if (!IsPostBack)
                grdCedulas.BindGridView(ConsultaCedulasInterno(0));

            #endregion
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void LimpiarBarraMensaje()
    {
        this.divBarraMensaje.Visible = false;
    }

    public void LimpiarGridCedulas()
    {
        grdCedulas.BindGridView(ConsultaCedulasInterno(0));
    }

    public void CargarContenidoControlReales(List<ControlEntidad> controles)
    {
        try
        {
            AsignaWebServicesTypeNames();
            ControlEntidad controlSeleccionado = null;

            #region APARTADO GENERAL

            #region TIPO BIEN

            controlSeleccionado = BuscarControlesReales(controles, lblTipoBien.ID);
            lblTipoBien.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlTipoBien.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlTipoBien, string.Empty);

            #endregion

            #region CLASE

            controlSeleccionado = BuscarControlesReales(controles, lblIdClaseTipoBien.ID);
            lblIdClaseTipoBien.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdClaseTipoBien.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdClaseTipoBien, string.Empty);

            #endregion

            #region PROVINCIA

            controlSeleccionado = BuscarControlesReales(controles, lblIdProvincia.ID);
            lblIdProvincia.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdProvincia.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdProvincia, string.Empty);

            #endregion

            #region HORIZONTAL

            controlSeleccionado = BuscarControlesReales(controles, lblIdCodigoHorizontalidad.ID);
            lblIdCodigoHorizontalidad.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdCodigoHorizontalidad.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdCodigoHorizontalidad, string.Empty);

            #endregion

            #region DUPLICADO

            controlSeleccionado = BuscarControlesReales(controles, lblIdCodigoDuplicado.ID);
            lblIdCodigoDuplicado.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdCodigoDuplicado.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdCodigoDuplicado, string.Empty);

            #endregion

            #region CLASE BUQUE

            controlSeleccionado = BuscarControlesReales(controles, lblIdClaseBuque.ID);
            lblIdClaseBuque.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdClaseBuque.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdClaseBuque, string.Empty);

            #endregion

            #region CLASE AERONAVE

            controlSeleccionado = BuscarControlesReales(controles, lblIdClaseAeronave.ID);
            lblIdClaseAeronave.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdClaseAeronave.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdClaseAeronave, string.Empty);

            #endregion

            #region CLASE VEHICULO

            controlSeleccionado = BuscarControlesReales(controles, lblClaseVehiculo.ID);
            lblClaseVehiculo.Text = controlSeleccionado.DesColumna;

            //ASIGNAR TEXTBOX AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, txtClaseVehiculo.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtClaseVehiculo);

            #endregion

            #region FORMATO IDENTIFICACION VEHICULO

            controlSeleccionado = BuscarControlesReales(controles, lblIdFormatoIdentificacionVehiculo.ID);
            lblIdFormatoIdentificacionVehiculo.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdFormatoIdentificacionVehiculo.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControlFormato(controlSeleccionado, ddlIdFormatoIdentificacionVehiculo, string.Empty);

            #endregion

            #region NUMERO BIEN

            controlSeleccionado = BuscarControlesReales(controles, lblCodigoBien.ID);
            lblCodigoBien.Text = controlSeleccionado.DesColumna;

            //ASIGNAR TEXTBOX AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, txtCodigoBien.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtCodigoBien);

            #endregion

            #endregion

            #region APARTADO DETALLE

            #region TIPO MONEDA

            controlSeleccionado = BuscarControlesReales(controles, lblIdTipoMoneda.ID);
            lblIdTipoMoneda.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtIdTipoMoneda.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtIdTipoMoneda);

            #endregion

            #region MONTO ULTIMA TASACION TERRENO

            controlSeleccionado = BuscarControlesReales(controles, lblMontoUltimaTasacionTerreno.ID);
            lblMontoUltimaTasacionTerreno.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtMontoUltimaTasacionTerreno.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtMontoUltimaTasacionTerreno);

            #endregion

            #region MONTO ULTIMA TASACION NO TERRENO

            controlSeleccionado = BuscarControlesReales(controles, lblMontoUltimaTasacionNoTerreno.ID);
            lblMontoUltimaTasacionNoTerreno.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtMontoUltimaTasacionNoTerreno.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtMontoUltimaTasacionNoTerreno);

            #endregion

            #region MONTO TOTAL ULTIMA TASACION

            controlSeleccionado = BuscarControlesReales(controles, lblMontoTotalUltimaTasacion.ID);
            lblMontoTotalUltimaTasacion.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtMontoTotalUltimaTasacion.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtMontoTotalUltimaTasacion);

            #endregion

            #region MONTO TASACION ACTUALIZADA TERRENO

            controlSeleccionado = BuscarControlesReales(controles, lblMontoTasacionActualizadaTerreno.ID);
            lblMontoTasacionActualizadaTerreno.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtMontoTasacionActualizadaTerreno.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtMontoTasacionActualizadaTerreno);

            #endregion

            #region MONTO TASACION ACTUALIZADA NO TERRENO

            controlSeleccionado = BuscarControlesReales(controles, lblMontoTasacionActualizadaNoTerreno.ID);
            lblMontoTasacionActualizadaNoTerreno.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtMontoTasacionActualizadaNoTerreno.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtMontoTasacionActualizadaNoTerreno);

            #endregion

            #region MONTO TOTAL ULTIMA TASACION ACTUALIZADA

            controlSeleccionado = BuscarControlesReales(controles, lblMontoTotalUltimaTasacionActualizada.ID);
            lblMontoTotalUltimaTasacionActualizada.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtMontoTotalUltimaTasacionActualizada.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtMontoTotalUltimaTasacionActualizada);

            #endregion

            #region FECHA ULTIMO SEGUIMIENTO GARANTIA

            controlSeleccionado = BuscarControlesReales(controles, lblFechaUltimoSeguimientoGarantia.ID);
            lblFechaUltimoSeguimientoGarantia.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtFechaUltimoSeguimientoGarantia.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtFechaUltimoSeguimientoGarantia);

            #endregion

            #region FECHA ULTIMA TASACION GARANTIA

            controlSeleccionado = BuscarControlesReales(controles, lblFechaUltimaTasacionGarantia.ID);
            lblFechaUltimaTasacionGarantia.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtFechaUltimaTasacionGarantia.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtFechaUltimaTasacionGarantia);

            #endregion

            #region VALOR TOTAL CEDULAS

            controlSeleccionado = BuscarControlesReales(controles, lblValorTotalCedulas.ID);
            lblValorTotalCedulas.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtValorTotalCedulas.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtValorTotalCedulas);
            #endregion

            #region CANTIDAD CEDULAS

            controlSeleccionado = BuscarControlesReales(controles, lblCantidadCedulas.ID);
            lblCantidadCedulas.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtCantidadCedulas.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtCantidadCedulas);
            #endregion

            #region VALOR TOTAL FACIAL

            controlSeleccionado = BuscarControlesReales(controles, lblValorTotalFacial.ID);
            lblValorTotalFacial.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtValorTotalFacial.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtValorTotalFacial);

            #endregion

            #endregion

            #region APARTADO ADICIONALES

            #region ID DUEÑO

            controlSeleccionado = BuscarControlesReales(controles, lblIdDueno.ID);
            lblIdDueno.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtIdDueno.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtIdDueno);

            #endregion

            #region MONTO MITIGADOR

            controlSeleccionado = BuscarControlesReales(controles, lblMontoMitigador.ID);
            lblMontoMitigador.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtMontoMitigador.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtMontoMitigador);

            #endregion

            #region NOMBRE DUEÑO

            controlSeleccionado = BuscarControlesReales(controles, lblNombreDueno.ID);
            lblNombreDueno.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtNombreDueno.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtNombreDueno);

            #endregion

            #region PORCENTAJE ACEPTACION TERRENO SUGEF

            controlSeleccionado = BuscarControlesReales(controles, lblPorcentajeAceptTerrenoSUGEF.ID);
            lblPorcentajeAceptTerrenoSUGEF.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtPorcentajeAceptTerrenoSUGEF.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtPorcentajeAceptTerrenoSUGEF);

            #endregion

            #region TIPO MONEDA VALOR NOMINAL

            controlSeleccionado = BuscarControlesReales(controles, lblIdTipoMonedaValorNominal.ID);
            lblIdTipoMonedaValorNominal.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdTipoMonedaValorNominal.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoMonedaValorNominal, string.Empty);

            #endregion

            #region PORCENTAJE ACEPTACION NO TERRENO SUGEF

            controlSeleccionado = BuscarControlesReales(controles, lblPorcentajeAceptNoTerrenoSUGEF.ID);
            lblPorcentajeAceptNoTerrenoSUGEF.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtPorcentajeAceptNoTerrenoSUGEF.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtPorcentajeAceptNoTerrenoSUGEF);

            #endregion

            #region VALOR NOMINAL

            controlSeleccionado = BuscarControlesReales(controles, lblValorNominal.ID);
            lblValorNominal.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtValorNominal.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtValorNominal);

            #endregion

            #region PORCENTAJE ACEPTACION BCR

            controlSeleccionado = BuscarControlesReales(controles, lblPorcentajeAceptBCR.ID);
            lblPorcentajeAceptBCR.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtPorcentajeAceptBCR.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtPorcentajeAceptBCR, this.mskPorcentajeAceptBCR);

            #endregion

            #region TIPO MITIGADOR RIESGO

            controlSeleccionado = BuscarControlesReales(controles, lblIdTipoMitigadorRiesgo.ID);
            lblIdTipoMitigadorRiesgo.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdTipoMitigadorRiesgo.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoMitigadorRiesgo, string.Empty);

            #endregion

            #region FECHA PRESENTACION

            controlSeleccionado = BuscarControlesReales(controles, lblFechaPresentacion.ID);
            lblFechaPresentacion.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesReales(controles, txtFechaPresentacion.ID);

            //CARGAR EL TEXTBOX CON INFORMACION
            CargarTextBoxControl(controlSeleccionado, txtFechaPresentacion);

            //TXT FECHA VENCIMIENTO
            this.txtFechaPresentacion.Attributes.Add("readonly", "readonly");
            this.calendarExtenderFechaPresentacion.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();

            #endregion

            #region TIPO DOCUMENTO LEGAL

            controlSeleccionado = BuscarControlesReales(controles, lblIdTipoDocumentoLegal.ID);
            lblIdTipoDocumentoLegal.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdTipoDocumentoLegal.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoDocumentoLegal, string.Empty);

            #endregion

            #region DEUDOR HABITA

            controlSeleccionado = BuscarControlesReales(controles, lblIdDeudorHabita.ID);
            lblIdDeudorHabita.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIdDeudorHabita.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdDeudorHabita, string.Empty);

            #endregion

            #region INDICADOR INSCRIPCION

            controlSeleccionado = BuscarControlesReales(controles, lblIndInscripcion.ID);
            lblIndInscripcion.Text = controlSeleccionado.DesColumna;

            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesReales(controles, ddlIndInscripcion.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIndInscripcion, "0,2,3");

            #endregion

            #endregion

            updRealesPopUpControl.Update();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void CargarContenidoDefaultReales()
    {
        try
        {

            #region LIMPIAR MENSAJES

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
            {
                this.divBarraMensaje.Visible = false;
            }

            #endregion

            //DDL TIPOS BIENES
            ddlTiposBienes();

            //DLL CODIGO HORIZONTALIDAD
            AdministrarBlanco(ddlIdCodigoHorizontalidad.ID, true);

            //DLL CODIGO DUPLICADO
            AdministrarBlanco(ddlIdCodigoDuplicado.ID, true);

            //DDL CLASE BUQUE       
            AdministrarBlanco(ddlIdClaseBuque.ID, true);

            //DDL CLASE AERONAVE  
            AdministrarBlanco(ddlIdClaseAeronave.ID, true);

            updRealesPopUpControl.Update();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void HabilitarContenidoGenerales(bool estado)
    {
        tableGeneral.Disabled = estado;
        if (estado)
        {
            btnClaseVehiculo.Enabled = !estado;
            btnClaseVehiculo.CssClass = "imgCmdBuscarGarantiaDisabled";
            btnConsultarGarantia.Enabled = !estado;
            btnConsultarGarantia.CssClass = "botonConsultarRelacionDisabled";
        }
        else
        {
            btnClaseVehiculo.Enabled = !estado;
            btnClaseVehiculo.CssClass = "imgCmdBuscarGarantia";
            btnConsultarGarantia.Enabled = !estado;
            btnConsultarGarantia.CssClass = "botonConsultarRelacion";
        }
    }

    public void HabilitarContenidoAdicionales(bool estado)
    {
        if (!estado)
        {
            this.ddlIdTipoMonedaValorNominal.Enabled = estado;
            this.txtValorNominal.Enabled = estado;
            this.txtMontoMitigador.Enabled = estado;
            this.txtPorcentajeAceptTerrenoSUGEF.Enabled = estado;
            this.txtPorcentajeAceptNoTerrenoSUGEF.Enabled = estado;
        }
    }

    public GarantiasWS.RespuestaEntidad DeControlesAEntidad(int tipoAccion)
    {
        try
        {
            string[] sesion = valorSesionOculto.Value.Split('|');
            GarantiasWS.RespuestaEntidad result = new GarantiasWS.RespuestaEntidad();

            GarantiasWS.GarantiasFideicomisosFideicometidasEntidad entidadFideicometida = new GarantiasWS.GarantiasFideicomisosFideicometidasEntidad();

            entidadFideicometida.IdGarantiaFideicomiso = int.Parse(sesion[3]);
            entidadFideicometida.IdGarantiaReal = int.Parse(idGarantiaRealOculto.Value);
            entidadFideicometida.IdTipoGarantia = int.Parse(sesion[4]);

            if (!String.IsNullOrEmpty(idGarantiaFideicometida.Value))
                entidadFideicometida.IdGarantiaFideicomisoFideicometida = int.Parse(idGarantiaFideicometida.Value);

            #region APARTADO ADICIONALES

            //ID DUEÑO
            entidadFideicometida.IdDueno = txtIdDueno.Text;

            //NOMBRE DUEÑO
            entidadFideicometida.NombreDueno = txtNombreDueno.Text;

            //TIPO MONEDA VALOR NOMINAL
            entidadFideicometida.IdTipoMonendaValorNominal = int.Parse(ddlIdTipoMonedaValorNominal.SelectedItem.Value);

            //VALOR NOMINAL
            entidadFideicometida.ValorNominal = decimal.Parse(txtValorNominal.Text);

            //TIPO MITIGADOR RIESGO
            entidadFideicometida.IdTipoMitigadorRiego = int.Parse(ddlIdTipoMitigadorRiesgo.SelectedItem.Value);

            //TIPO DOCUMENTO LEGAL
            entidadFideicometida.IdTipoDocumentoLegal = int.Parse(ddlIdTipoDocumentoLegal.SelectedItem.Value);

            //IND. INSCRIPCION
            entidadFideicometida.IdTipoIndicadorInscripcion = int.Parse(ddlIndInscripcion.SelectedItem.Value);

            //MONTO MITIGADOR
            if (txtMontoMitigador.Text.Length > 0)
                entidadFideicometida.MontoMitigador = decimal.Parse(txtMontoMitigador.Text);
            else
                entidadFideicometida.MontoMitigador = null;

            //PORCENTAJE ACEPTACION TERRENO SUGEF
            if (txtPorcentajeAceptTerrenoSUGEF.Text.Length > 0)
                entidadFideicometida.PorcentajeAceptacionTerrenoSUGEF = decimal.Parse(txtPorcentajeAceptTerrenoSUGEF.Text);
            else
                entidadFideicometida.PorcentajeAceptacionTerrenoSUGEF = null;

            //PORCENTAJE ACEPTACION NO TERRENO SUGEF
            //Ajuste javendano 2015-01-12
            if (txtPorcentajeAceptNoTerrenoSUGEF.Text.Length > 0)
                entidadFideicometida.PorcentajeAceptacionNoTerrenoSUGEF = decimal.Parse(txtPorcentajeAceptNoTerrenoSUGEF.Text);
            else
                entidadFideicometida.PorcentajeAceptacionNoTerrenoSUGEF = null;

            //PORCENTAJE ACEPTACION BCR
            //Ajuste javendano 2015-01-12
            if (txtPorcentajeAceptBCR.Text.Length > 0)
                entidadFideicometida.PorcentajeAceptacionBCR = decimal.Parse(txtPorcentajeAceptBCR.Text);
            else
                entidadFideicometida.PorcentajeAceptacionBCR = decimal.Parse(wmPorcentajeAceptBCR.WatermarkText);

            //FECHA PRESENTACION GARANTIA
            if (txtFechaPresentacion.Text.Length > 0)
                entidadFideicometida.FechaPresentacion = DateTime.Parse(txtFechaPresentacion.Text);
            else
                entidadFideicometida.FechaPresentacion = null;

            //INDICADOR HABITA
            entidadFideicometida.IndDeudorHabita = int.Parse(ddlIdDeudorHabita.SelectedItem.Value);

            #endregion

            //REQUERIMIENTO BLOQUE 7 1-24381561
            #region CONTROL DE REGISTRO

            entidadFideicometida.CodUsuarioIngreso = sesion[2];
            entidadFideicometida.IndMetodoInsercion = Resources.Resource._metodoInsercion;

            #endregion

            #region INSERTAR

            switch (tipoAccion)
            {
                case 0:
                    result = wsGarantias.GarantiasFideicomisosFideicometidasInsertar(entidadFideicometida, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));
                    break;

                case 1:
                    result = wsGarantias.GarantiasFideicomisosFideicometidasModificar(entidadFideicometida, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));
                    break;
            }

            return result;

            #endregion
        }

        catch
        {
            throw;
        }
    }

    public void DeEntidadAControles(GarantiasFideicomisosFideicometidasEntidad _entidadFideicometida, GarantiasRealesEntidad _entidadReales)
    {
        try
        {
            idGarantiaRealOculto.Value = _entidadFideicometida.IdGarantiaReal.ToString();

            //Ajustes javendano 2015-01-09
            #region APARTADO ENCABEZADO

            //TIPO BIEN
            _generadorControles.SeleccionarOpcionDropDownList(ddlTipoBien, _entidadReales.IdTipoBien.ToString());
            ddlTiposBienes();

            //CLASE TIPO BIEN
            ddlClaseTipoBien(ddlTipoBien.SelectedItem.Value);
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdClaseTipoBien, _entidadReales.IdClaseTipoBien.ToString());
            ddlClaseTipoBienEfectos();

            //FORMATO IDENTIFICACION VEHICULO
            ddlFormatoIdentificacionVehiculoIdentificacionVehiculo();
            CargarFormatoIdentificacionVehiculo(ddlTipoBien.SelectedItem.Text);
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdFormatoIdentificacionVehiculo, _entidadReales.FormatoIdentificacionVehiculo.ToString());

            //PROVINCIA
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdProvincia, _entidadReales.IdProvincia.ToString());

            //CODIGO HORIZONTALIDAD            
            if (_entidadReales.IdCodigoHorizontalidad != null)
            {
                chkEstadoHorizontal.Checked = false;
                chkCodigoHorizontal();
                _generadorControles.SeleccionarOpcionDropDownList(ddlIdCodigoHorizontalidad, _entidadReales.IdCodigoHorizontalidad.ToString());
            }

            //CODIGO DUPLICADO
            if (_entidadReales.IdCodigoDuplicado != null)
            {
                chkEstadoDuplicado.Checked = false;
                chkCodigoDuplicado();
                _generadorControles.SeleccionarOpcionDropDownList(ddlIdCodigoDuplicado, _entidadReales.IdCodigoDuplicado.ToString());
            }

            //CLASE BUQUE
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdClaseBuque, _entidadReales.IdClaseBuque.ToString());

            //CLASE AERONAVE
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdClaseAeronave, _entidadReales.IdClaseAeronave.ToString());

            //ID CLASE VEHICULO
            hdnIdClaseVehiculo.Value = _entidadReales.IdClaseVehiculo.ToString();
            txtDesClaseVehiculo.Text = _entidadReales.DesClaseVehiculo;

            //CODIGO BIEN
            txtCodigoBien.Text = _entidadReales.CodBien.ToString();

            #endregion

            #region APARTADO DETALLE

            btnConsultarGarantia_Click(null, null);

            #endregion

            #region APARTADO ADICIONALES

            //ID DUEÑO
            txtIdDueno.Text = _entidadFideicometida.IdDueno.ToString();

            //NOMBRE DUEÑO
            txtNombreDueno.Text = _entidadFideicometida.NombreDueno.ToString();

            //TIPO MONEDA VALOR NOMINAL
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoMonedaValorNominal, _entidadFideicometida.IdTipoMonendaValorNominal.ToString());

            //NOMBRE DUEÑO
            txtValorNominal.Text = _entidadFideicometida.ValorNominal.ToString();

            //TIPO MITIGADOR RIESGO
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoMitigadorRiesgo, _entidadFideicometida.IdTipoMitigadorRiego.ToString());

            //TIPO DOCUMENTO LEGAL
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoDocumentoLegal, _entidadFideicometida.IdTipoDocumentoLegal.ToString());

            //IND INSCRIPCION
            _generadorControles.SeleccionarOpcionDropDownList(ddlIndInscripcion, _entidadFideicometida.IdTipoIndicadorInscripcion.ToString());
            IndicadorInscripcionExcepcion();

            //MONTO MITIGADOR
            txtMontoMitigador.Text = _entidadFideicometida.MontoMitigador.ToString();

            //PORCENTAJE ACEPTACION TERRENO SUGEF
            if (_entidadFideicometida.PorcentajeAceptacionTerrenoSUGEF.ToString().Length > 0)
                txtPorcentajeAceptTerrenoSUGEF.Text = string.Format("{0:N}", _entidadFideicometida.PorcentajeAceptacionTerrenoSUGEF);
            else
                txtPorcentajeAceptTerrenoSUGEF.Text = string.Empty;

            //PORCENTAJE ACEPTACION NO TERRENO SUGEF
            if (_entidadFideicometida.PorcentajeAceptacionNoTerrenoSUGEF.ToString().Length > 0)
                txtPorcentajeAceptNoTerrenoSUGEF.Text = string.Format("{0:N}", _entidadFideicometida.PorcentajeAceptacionNoTerrenoSUGEF);
            else
                txtPorcentajeAceptNoTerrenoSUGEF.Text = string.Empty;

            //PORCENTAJE ACEPTACION BCR
            txtPorcentajeAceptBCR.Text = _entidadFideicometida.PorcentajeAceptacionBCR.ToString();

            //PORCENTAJE ACEPTACION TERRENO SUGEF
            if (_entidadFideicometida.PorcentajeAceptacionTerrenoSUGEF.ToString().Length > 0)
                txtPorcentajeAceptTerrenoSUGEF.Text = string.Format("{0:N}", _entidadFideicometida.PorcentajeAceptacionTerrenoSUGEF);
            else
                txtPorcentajeAceptTerrenoSUGEF.Text = string.Empty;

            //FECHA PRESENTACION
            if (!_entidadFideicometida.FechaPresentacion.ToString().Length.Equals(0))
                txtFechaPresentacion.Text = DateTime.Parse(_entidadFideicometida.FechaPresentacion.ToString()).ToShortDateString();

            //INDICADOR HABITA
            if (ddlIdDeudorHabita.Enabled)
            {
                _generadorControles.SeleccionarOpcionDropDownList(ddlIdDeudorHabita, _entidadFideicometida.IndDeudorHabita.ToString());
            }

            #endregion
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

                //TIPO BIEN
                _entidad.IdTipoBien = int.Parse(ddlTipoBien.SelectedValue);

                //CLASE TIPO BIEN
                if (ddlIdClaseTipoBien.SelectedItem.Value.Equals("-1"))
                    _entidad.IdClaseTipoBien = null;
                else
                    _entidad.IdClaseTipoBien = int.Parse(ddlIdClaseTipoBien.SelectedItem.Value);

                //PROVINCIA
                if (ddlIdProvincia.SelectedItem.Value.Equals("-1"))
                    _entidad.IdProvincia = null;
                else
                    _entidad.IdProvincia = int.Parse(ddlIdProvincia.SelectedItem.Value);

                //CODIGO HORIZONTALIDAD
                if (ddlIdCodigoHorizontalidad.SelectedItem.Value.Equals("-1"))
                    _entidad.IdCodigoHorizontalidad = null;
                else
                    _entidad.IdCodigoHorizontalidad = int.Parse(ddlIdCodigoHorizontalidad.SelectedItem.Value);

                //CODIGO DUPLICADO
                if (ddlIdCodigoDuplicado.SelectedItem.Value.Equals("-1"))
                    _entidad.IdCodigoDuplicado = null;
                else
                    _entidad.IdCodigoDuplicado = int.Parse(ddlIdCodigoDuplicado.SelectedItem.Value);

                //CLASE BUQUE
                if (ddlIdClaseBuque.SelectedItem.Value.Equals("-1"))
                    _entidad.IdClaseBuque = null;
                else
                    _entidad.IdClaseBuque = int.Parse(ddlIdClaseBuque.SelectedItem.Value);

                //CLASE AERONAVE
                if (ddlIdClaseAeronave.SelectedItem.Value.Equals("-1"))
                    _entidad.IdClaseAeronave = null;
                else
                    _entidad.IdClaseAeronave = int.Parse(ddlIdClaseAeronave.SelectedItem.Value);
                //CLASE VEHICULO
                if (hdnIdClaseVehiculo.Value.Length < 1)
                    _entidad.IdClaseVehiculo = null;
                else
                    _entidad.IdClaseVehiculo = int.Parse(hdnIdClaseVehiculo.Value);

                //FORMATO IDENTIFICACION
                if (ddlIdFormatoIdentificacionVehiculo.SelectedItem.Value.Equals("-1"))
                    _entidad.FormatoIdentificacionVehiculo = null;
                else
                    _entidad.FormatoIdentificacionVehiculo = int.Parse(ddlIdFormatoIdentificacionVehiculo.SelectedItem.Value);

                //CODIGO BIEN
                _entidad.CodBien = txtCodigoBien.Text;

                #endregion

                _consulta = wsGarantias.GarantiasFideicomisosFideicometidaGarantiasRealesBusqueda(_entidad);
                if (ValidarNumeroBien())
                {
                    //MENSAJE DE ERROR DE FORMATO
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_6", this.lblCodigoBien.Text, this.txtCodigoBien.ToolTip);
                    this.mpeInformarBox.Show();
                }

                else
                {
                    if (ValidarCaracterEspecial(txtCodigoBien.Text))
                    {
                        //MENSAJE DE ERROR POR CARACTER ESPECIAL
                        InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_2");
                        mpeInformarBox.Show();
                    }

                    else
                    {
                        if (_consulta != null)
                        {
                            #region SECCION DETALLE

                            idGarantiaRealOculto.Value = _consulta.IdGarantiaReal.ToString();
                            txtIdTipoMoneda.Text = _consulta.DesTipoMoneda.ToString();
                            txtMontoUltimaTasacionTerreno.Text = _consulta.MontoUltimaTasacionTerreno.ToString();
                            txtMontoUltimaTasacionNoTerreno.Text = _consulta.MontoUltimaTasacionNoTerreno.ToString();
                            txtMontoTotalUltimaTasacion.Text = _consulta.MontoTotalUltimaTasacion.ToString();
                            txtMontoTasacionActualizadaTerreno.Text = _consulta.MontoTasacionActualizadaTerreno.ToString();
                            txtMontoTasacionActualizadaNoTerreno.Text = _consulta.MontoTasacionActualizadaNoTerreno.ToString();
                            txtMontoTotalUltimaTasacionActualizada.Text = _consulta.MontoTotalTasacionActualizada.ToString();

                            if (!_consulta.FechaUltimoSeguimientoGarantia.ToString().Length.Equals(0))
                                txtFechaUltimoSeguimientoGarantia.Text = DateTime.Parse(_consulta.FechaUltimoSeguimientoGarantia.ToString()).ToShortDateString();

                            if (!_consulta.FechaUltimaTasacionGarantia.ToString().Length.Equals(0))
                                txtFechaUltimaTasacionGarantia.Text = DateTime.Parse(_consulta.FechaUltimaTasacionGarantia.ToString()).ToShortDateString();

                            #endregion

                            #region SECCION CEDULAS

                            if (this.ddlIdClaseTipoBien.SelectedItem.Text.Equals("Cédula Hipotecaria"))
                            {
                                txtValorTotalCedulas.Text = _consulta.MontoValorTotalCedula.ToString();
                                GridViewCedulasInternoActualizar(int.Parse(idGarantiaRealOculto.Value));
                            }

                            #endregion

                            //HABILITAR LA TABLA
                            //DESHABILITAR LA TABLA GENERALES
                            _generadorControles.Bloquear_Controles(tableGeneral, false);

                            HabilitarContenidoGenerales(true);
                            tableAdicionales.Disabled = false;

                            btnConsultarGarantia.Enabled = false;
                            btnConsultarGarantia.CssClass = "botonConsultarRelacionDisabled";

                            _generadorControles.Bloquear_Controles(tableAdicionales, true);
                            HabilitarContenidoAdicionales(false);

                            #region ADMINISTRAR ESPACIOS BLANCOS

                            AdministrarBlanco("ddlIdTipoMoneda", false);

                            #endregion

                            #region SECCION ADICIONAL EXCEPCIONES

                            IndicadorGarantiaExcepcion();
                            IndicadorDeudorHabitaExcepcion();
                            IndicadorInscripcionExcepcion();

                            TipoMitigadorExcepcion();
                            TipoDocumentoExcepcion();

                            #endregion
                        }

                        else
                        {
                            // MENSAJE DE ERROR
                            InformarBox1_SetConfirmationBoxEvent(null, e, "GAR_1");
                            mpeInformarBox.Show();
                        }
                    }
                }
            }

            updRealesPopUpControl.Update();
        }
        catch (Exception ex)
        {
            throw ex;
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

    /*VALIDACION DE CARACTERES ESPECIALES*/
    public bool ValidarCaracterEspecial(string texto)
    {
        bool existeCaracter = false;

        //NO SE PERMITEN CARACTERES ESPECIALES
        var regexItem = new Regex(@"^[a-zA-Z0-9 \-.,_:ÁÉÍÓÚÑáéíóúñ]*$");

        if (!regexItem.IsMatch(texto))
            existeCaracter = true;

        return existeCaracter;
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

    /*VALIDACION RANGO DE FECHA MENOR O IGUAL A LA FECHA ACTUAL*/
    public bool ValidarRangoFechaMenorIgualFechaActualFR()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        //FECHA ACTUAL
        string fechaActual = DateTime.Now.ToString();

        if (_generadorControles.ObtenerComparacion(this.txtFechaPresentacion.Text, fechaActual, EnumTipoComparacion.MAYORIGUAL, TypeCode.DateTime))
        {
            existeError = true;

            //MENSAJE DE ERROR DE FECHAS DIFERENTES
            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblFechaPresentacion.Text, "menor o igual a Fecha Actual");
            this.mpeInformarBox.Show();

            this.txtFechaPresentacion.Text = string.Empty;
        }
        return existeError;
    }

    #region  METODOS PARA LOS TEXBOX

    protected void txtFechaPresentacion_TextChanged(object sender, EventArgs e)
    {
        try
        {
            //ValidarRangoFechaMenorIgualFechaActual();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region METODOS PARA DROPDOWNLIST

    protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string idDropDownList = ((DropDownList)(sender)).ID.ToString().ToUpper();
            switch (idDropDownList)
            {

                #region TIPO BIEN

                case "DDLTIPOBIEN":
                    ddlTiposBienes();
                    break;

                #endregion

                #region CLASE TIPO BIEN

                case "DDLIDCLASETIPOBIEN":
                    ddlClaseTipoBienEfectos();
                    break;

                #endregion

                #region FORMATO IDENTIFICACION VEHICULO

                case "DDLIDFORMATOIDENTIFICACIONVEHICULO":
                    ddlFormatoIdentificacionVehiculoIdentificacionVehiculo();
                    break;

                #endregion

                #region INDICADOR INSCRIPCION

                case "DDLINDINSCRIPCION":
                    ddlIndInscripcionEfectos();
                    break;

                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlTiposBienes()
    {
        try
        {
            //REALIZA LA CARGA DE LA CLASE
            ddlClaseTipoBien(ddlTipoBien.SelectedItem.Value);

            //REALIZA LA CARGA DEL FORMATO IDENTIFICACION VEHICULO
            CargarFormatoIdentificacionVehiculo(ddlTipoBien.SelectedItem.Text);

            //EFECTO DE NUMERO DE BIEN [CONSTANTES]
            txtCodigoBien.Text = string.Empty;
            txtCodigoBien.MaxLength = 17;
            txtCodigoBien.ToolTip = "Alfanumérico de 17 caracteres";

            #region TIPO BIEN - TERRENOS - EDIFICACIONES

            if (ObtenerTipoBien().Equals(1) || ObtenerTipoBien().Equals(2))
            {
                //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO PROVINCIAS
                AdministrarBlanco(ddlIdProvincia.ID, false);
                ddlIdProvincia.Enabled = true;

                //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO HORIZONTALES                
                AdministrarBlanco(ddlIdCodigoHorizontalidad.ID, false);
                ddlIdCodigoHorizontalidad.Enabled = true;

                //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO DUPLICADOS                
                AdministrarBlanco(ddlIdCodigoDuplicado.ID, false);
                ddlIdCodigoDuplicado.Enabled = true;

                //EFECTO DE NUMERO DE BIEN
                txtCodigoBien.MaxLength = 6;
                txtCodigoBien.ToolTip = "Númerico de 6 caracteres";

                AdministrarBlanco(ddlIdCodigoDuplicado.ID, true);
                ddlIdCodigoDuplicado.Enabled = false;
                chkEstadoDuplicado.Checked = true;
                chkEstadoDuplicado.Enabled = true;

                AdministrarBlanco(ddlIdCodigoHorizontalidad.ID, true);
                ddlIdCodigoHorizontalidad.Enabled = false;
                chkEstadoHorizontal.Checked = true;
                chkEstadoHorizontal.Enabled = true;

                //RQ_MANT_2016050410580724: BACKLOG 3943
                //COMPLETA CON CEROS EL CAMPO NUMERO BIEN
                AutoCompletarNBien(false);

                //ELIMINA HIPOTECA ABIERTA DE DDLTIPOCLASE
                if (ddlIdClaseTipoBien.Items.Count > 0)
                {
                    int cantidad = this.ddlIdClaseTipoBien.Items.Count - 1;
                    for (int i = cantidad; i >= 0; i--)
                    {
                        if ((this.ddlIdClaseTipoBien.Items[i].Text.Equals("Hipoteca Abierta")))
                        {
                            this.ddlIdClaseTipoBien.Items.RemoveAt(i);
                        }
                    }
                }
            }
            else
            {
                //AGREGA EL ITEM EN BLANCO Y DESHABILITA EL COMBO PROVINCIAS
                AdministrarBlanco(ddlIdProvincia.ID, true);
                ddlIdProvincia.Enabled = false;

                //AGREGA EL ITEM EN BLANCO Y DESHABILITA EL COMBO HORIZONTALES
                AdministrarBlanco(ddlIdCodigoHorizontalidad.ID, true);
                ddlIdCodigoHorizontalidad.Enabled = false;

                //AGREGA EL ITEM EN BLANCO Y DESHABILITA EL COMBO DUPLICADOS
                AdministrarBlanco(ddlIdCodigoDuplicado.ID, true);
                ddlIdCodigoDuplicado.Enabled = false;

                //Control de Cambios 1.1
                chkEstadoDuplicado.Checked = false;
                chkEstadoDuplicado.Enabled = false;
                chkEstadoHorizontal.Checked = false;
                chkEstadoHorizontal.Enabled = false;

                //RQ_MANT_2016050410580724: BACKLOG 3943
                //COMPLETA CON CEROS EL CAMPO NUMERO BIEN
                AutoCompletarNBien(true);

                //ELIMINA BONO DE PRENDA DE DDLTIPOCLASE
                if (ddlIdClaseTipoBien.Items.Count > 0)
                {
                    int cantidad = this.ddlIdClaseTipoBien.Items.Count - 1;
                    //for (int i = 0; i < this.ddlTipoBien.Items.Count; i++)
                    for (int i = cantidad; i >= 0; i--)
                    {
                        if ((this.ddlIdClaseTipoBien.Items[i].Text.Equals("Bono de Prenda")))
                        {
                            this.ddlIdClaseTipoBien.Items.RemoveAt(i);
                            //i = this.ddlTipoBien.Items.Count;
                        }
                    }
                }
            }

            #endregion

            #region TIPO BIEN - VEHICULOS

            if (ObtenerTipoBien().Equals(3))
            {
                //HABILITA LOS CONTROLES DE CLASE VEHICULO
                txtClaseVehiculo.Text = string.Empty;
                hdnIdClaseVehiculo.Value = string.Empty;
                txtDesClaseVehiculo.Text = string.Empty;
                rfvDesClaseVehiculo.Enabled = true;
                txtClaseVehiculo.Enabled = true;
                btnClaseVehiculo.Enabled = true;
                btnClaseVehiculo.CssClass = "imgCmdBuscarGarantia";

                //COMBO FORMATO DE IDENTIFICACION VEHICULO
                ddlFormatoIdentificacionVehiculoIdentificacionVehiculo();

                //RQ_MANT_2016050410580724: BACKLOG 3943
                //COMPLETA CON CEROS EL CAMPO NUMERO BIEN
                AutoCompletarNBien(true);
            }
            else
            {
                //DESHABILITA LOS CONTROLES DE CLASE VEHICULO
                txtClaseVehiculo.Text = string.Empty;
                hdnIdClaseVehiculo.Value = string.Empty;
                lblclasev.Text = string.Empty;
                txtDesClaseVehiculo.Text = string.Empty;
                rfvDesClaseVehiculo.Enabled = false;
                txtClaseVehiculo.Enabled = false;
                btnClaseVehiculo.Enabled = false;
                btnClaseVehiculo.CssClass = "imgCmdBuscarGarantiaDisabled";
            }

            #endregion

            #region TIPO BIEN - AERONAVES

            if (ObtenerTipoBien().Equals(9))
            {
                //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE AERONAVE
                AdministrarBlanco(ddlIdClaseAeronave.ID, false);
                ddlIdClaseAeronave.Enabled = true;

                //Control de Cambios 1.1
                //EFECTO DE NUMERO DE BIEN
                txtCodigoBien.MaxLength = 6;
                txtCodigoBien.ToolTip = "Númerico de 6 caracteres";

                //RQ_MANT_2016050410580724: BACKLOG 3943
                //COMPLETA CON CEROS EL CAMPO NUMERO BIEN
                AutoCompletarNBien(true);
            }
            else
            {
                //AGREGA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE AERONAVE
                AdministrarBlanco(ddlIdClaseAeronave.ID, true);
                ddlIdClaseAeronave.Enabled = false;
            }

            #endregion

            #region TIPO BIEN - BUQUES

            if (ObtenerTipoBien().Equals(10))
            {
                //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE BUQUE
                AdministrarBlanco(ddlIdClaseBuque.ID, false);
                ddlIdClaseBuque.Enabled = true;

                //EFECTO DE NUMERO DE BIEN
                txtCodigoBien.MaxLength = 6;
                txtCodigoBien.ToolTip = "Númerico de 6 caracteres";

                //RQ_MANT_2016050410580724: BACKLOG 3943
                //COMPLETA CON CEROS EL CAMPO NUMERO BIEN
                AutoCompletarNBien(true);
            }
            else
            {
                //AGREGA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE BUQUE
                AdministrarBlanco(ddlIdClaseBuque.ID, true);
                ddlIdClaseBuque.Enabled = false;
            }

            #endregion

            updRealesPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void ddlClaseTipoBien(string valorFiltro)
    {
        string[] valorDefecto = null;
        try
        {
            //DDL CLASE TIPO BIEN
            LimpiarDropDownList(ddlIdClaseTipoBien);

            switch (valorFiltro)
            {
                case "1":
                case "2":
                case "3":
                    ddlIdClaseTipoBien.DataSource = LlenarDropDownList("ClasesTiposBienesLista", valorFiltro);
                    ddlIdClaseTipoBien.DataTextField = "Texto";
                    ddlIdClaseTipoBien.DataValueField = "Valor";
                    ddlIdClaseTipoBien.DataBind();

                    valorDefecto = "Hipoteca Común|Prenda Común".Split('|');
                    break;
            }

            if (ddlIdClaseTipoBien.Items.Count < 1)
            {
                LimpiarDropDownList(ddlIdClaseTipoBien);
                AdministrarBlanco(ddlIdClaseTipoBien.ID, true);
                ddlIdClaseTipoBien.Enabled = false;
            }
            else
            {
                if (ObtenerTipoBien().Equals(1) || ObtenerTipoBien().Equals(2))
                {
                    ddlIdClaseTipoBien.Enabled = true;
                    _generadorControles.SeleccionarOpcionDropDownListTexto(ddlIdClaseTipoBien, valorDefecto[0]);
                }
                else
                {
                    if (ObtenerTipoBien().Equals(3))
                    {
                        ddlIdClaseTipoBien.Enabled = true;
                        _generadorControles.SeleccionarOpcionDropDownListTexto(ddlIdClaseTipoBien, valorDefecto[1]);
                    }
                }
            }

            updRealesPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void ddlClaseTipoBienEfectos()
    {
        try
        {
            //SI EL TIPO DE BIEN ES IGUAL A 3 Y LA CLASE TIPO BIEN ES IGUAL A BONO PRENDA
            if (ObtenerTipoBien().Equals(3) && ObtenerClaseTipoBien().Equals(8))
            {
                txtClaseVehiculo.Text = string.Empty;
                txtDesClaseVehiculo.Text = string.Empty;
                hdnIdClaseVehiculo.Value = string.Empty;

                txtClaseVehiculo.Enabled = false;
                btnClaseVehiculo.Enabled = false;
                rfvDesClaseVehiculo.Enabled = false;

                _generadorControles.SeleccionarOpcionDropDownListTexto(ddlIdFormatoIdentificacionVehiculo, "Numérico 6 enteros");
                ddlIdFormatoIdentificacionVehiculo.Enabled = false;
            }

            //SI EL TIPO DE BIEN ES IGUAL A 3 Y LA CLASE TIPO BIEN ES DIFERENTE A BONO PRENDA
            if (ObtenerTipoBien().Equals(3) && !ObtenerClaseTipoBien().Equals(8))
            {
                txtClaseVehiculo.Text = string.Empty;
                txtDesClaseVehiculo.Text = string.Empty;
                hdnIdClaseVehiculo.Value = string.Empty;

                txtClaseVehiculo.Enabled = true;
                btnClaseVehiculo.Enabled = true;
                rfvDesClaseVehiculo.Enabled = true;

                ddlIdFormatoIdentificacionVehiculo.Enabled = true;
            }

            updRealesPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void ddlIndInscripcionEfectos()
    {
        try
        {
            //FECHA PRESENTACION 1 o 2 HABILITADO
            if (this.ddlIndInscripcion.SelectedItem.Text.Substring(0, 3).Equals("2 -") || this.ddlIndInscripcion.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
            {
                this.txtFechaPresentacion.Enabled = true;
                this.rfvFechaPresentacion.Enabled = true;
                this.calendarExtenderFechaPresentacion.Enabled = true;
                this.imbFechaPresentacion.Enabled = true;
            }
            else
            {
                this.txtFechaPresentacion.Enabled = false;
                this.rfvFechaPresentacion.Enabled = false;
                this.calendarExtenderFechaPresentacion.Enabled = false;
                this.imbFechaPresentacion.Enabled = false;
                this.txtFechaPresentacion.Text = string.Empty;
            }
            updRealesPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void ddlFormatoIdentificacionVehiculoIdentificacionVehiculo()
    {
        try
        {
            //EFECTO DE NUMERO DE BIEN [CONSTANTES]
            txtCodigoBien.Text = string.Empty;

            int IdentificacionVehiculo = int.Parse(ddlIdFormatoIdentificacionVehiculo.SelectedItem.Value);
            switch (IdentificacionVehiculo)
            {
                case 1:
                    //EFECTO DE NUMERO DE BIEN
                    txtCodigoBien.MaxLength = 6;
                    txtCodigoBien.ToolTip = "Númerico de 6 caracteres";
                    break;

                case 2:
                    //EFECTO DE NUMERO DE BIEN
                    txtCodigoBien.MaxLength = 6;
                    txtCodigoBien.ToolTip = "Alfanumérico 3 letras y 3 enteros (XXX999)";
                    break;

                case 3:
                    //EFECTO DE NUMERO DE BIEN
                    txtCodigoBien.MaxLength = 17;
                    txtCodigoBien.ToolTip = "Alfanumérico de 17 caracteres";
                    break;
            }

            updRealesPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void CargarFormatoIdentificacionVehiculo(string valorFiltro)
    {
        try
        {
            if (valorFiltro.Substring(0, 3).Equals("3 -"))
            {
                AdministrarBlanco(ddlIdFormatoIdentificacionVehiculo.ID, false);
                ddlIdFormatoIdentificacionVehiculo.Enabled = true;
            }
            else
            {
                AdministrarBlanco(ddlIdFormatoIdentificacionVehiculo.ID, true);
                ddlIdFormatoIdentificacionVehiculo.Enabled = false;
            }

            updRealesPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region METODOS PARA EL CHECKBOX

    protected void checkBox_OnCheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = ((CheckBox)(sender));
            switch (chk.ID.ToUpper())
            {
                #region CHK ESTADO HORIZONTAL

                case "CHKESTADOHORIZONTAL":
                    chkCodigoHorizontal();
                    break;

                #endregion

                #region CHK ESTADO DUPLICADO

                case "CHKESTADODUPLICADO":
                    chkCodigoDuplicado();
                    break;

                #endregion
            }
        }
        catch
        {
            throw;
        }
    }

    private void chkCodigoHorizontal()
    {
        try
        {
            if (chkEstadoHorizontal.Checked)
            {
                AdministrarBlanco(ddlIdCodigoHorizontalidad.ID, true);
                ddlIdCodigoHorizontalidad.Enabled = false;
            }
            else
            {
                AdministrarBlanco(ddlIdCodigoHorizontalidad.ID, false);
                ddlIdCodigoHorizontalidad.Enabled = true;
            }

            updRealesPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    private void chkCodigoDuplicado()
    {
        try
        {
            if (chkEstadoDuplicado.Checked)
            {
                AdministrarBlanco(ddlIdCodigoDuplicado.ID, true);
                ddlIdCodigoDuplicado.Enabled = false;
            }
            else
            {
                AdministrarBlanco(ddlIdCodigoDuplicado.ID, false);
                ddlIdCodigoDuplicado.Enabled = true;
            }

            updRealesPopUpControl.Update();
        }
        catch
        {
            throw;
        }
    }

    #endregion

    #region METODOS TEXT CHANGED

    //Ajustes javendano 2015-01-12
    protected void txtPorcentajeAceptBCR_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtPorcentajeAceptBCR.Text = GeneradorControles.ValorMinimo(((TextBox)sender), "0,00");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Ajustes javendano 2015-01-12
    protected void txtPorcentajeAceptTerrenoSugef_TextChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    txtPorcentajeAceptTerrenoSugef.Text = GeneradorControles.ValorMinimo(((TextBox)sender), "0,00");
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }

    //Ajustes javendano 2015-01-12
    protected void txtPorcentajeAceptNoTerrenoSugef_TextChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    txtPorcentajeAceptNoTerrenoSugef.Text = GeneradorControles.ValorMinimo(((TextBox)sender), "0,00");
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
    }

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

    #region METODOS PARA CLASE VEHICULO

    //REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE CLASE VEHICULO SELECCIONADO
    private void SeleccionarRegistroClaseVehiculo(object sender, EventArgs e)
    {
        try
        {
            //VALIDA QUE SOLO UN ELEMENTO SEA EL SELECCIONADO
            if (((wucGridEmergente)BusquedaClaseVehiculo).ContadorSeleccionados().Equals(1))
            {
                string[] valoresGrid;
                List<string> valorSeleccionado = ((wucGridEmergente)BusquedaClaseVehiculo).ObtenerValoresSeleccionados("lblValor");
                foreach (string valor in valorSeleccionado)
                {
                    valoresGrid = valor.Split('|');

                    hdnIdClaseVehiculo.Value = valoresGrid[1];
                    txtDesClaseVehiculo.Text = valoresGrid[0];
                }
                mpeBusquedaClaseVehiculo.Hide();
                updRealesPopUpControl.Update();
            }
            else
            {
                //VERIFICA SI EL GRID CONTIENE REGISTROS
                if (((wucGridEmergente)BusquedaClaseVehiculo).ContieneRegistros())
                {
                    mpeBusquedaClaseVehiculo.Hide();
                    InformarClaseVehiculo_SetConfirmationBoxEvent(sender, e, "SYS_4");
                    mpeInformarClaseVehiculo.Show();
                }
                else
                {
                    //SI EL REGISTRO A BUSCAR NO EXISTE
                    txtClaseVehiculo.Text = string.Empty;
                }
            }
        }
        catch
        {
            throw;
        }
    }

    //CONSULTA CLASES VEHICULOS
    private List<ListasWS.ListaEntidad> ConsultaClaseVehiculo(string filtro)
    {
        try
        {
            List<ListasWS.ListaEntidad> retorno = null;
            retorno = wsListas.ClasesVehiculosLista2(filtro).ToList();

            return retorno;
        }
        catch
        {
            throw;
        }
    }

    private void GridViewClaseVehiculo(object sender, EventArgs e)
    {
        // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
        gridViewClaseVehiculo = (GridView)BusquedaClaseVehiculo.FindControl("MasterGridView");
        BusquedaClaseVehiculo.TextoGridVacio("No hay Disponible ningún registro en este Catálogo.");

        // ASIGNA COLUMNAS PROPIAS DEL CONTROL
        gridViewClaseVehiculo.Init += new EventHandler(gridViewClaseVehiculo_Init);

        // ASIGNA COLUMNAS PROPIAS DEL CONTROL
        gridViewClaseVehiculo_Init(sender, e);

        //TITULOS
        ((Label)BusquedaClaseVehiculo.FindControl("lblTitulo")).Text = "Información Clase Vehículos";
        ((Label)BusquedaClaseVehiculo.FindControl("lblSubTitulo")).Text = "Seleccione un registro.";

        //ASIGNA DATA KEYS
        String[] DataKeysString = { "Texto" };
        SetDataKeys(gridViewClaseVehiculo, DataKeysString);
    }

    //EVENTO MENSAJES VENTANA EMERGENTE DE BUSQUEDA CLASE VEHICULO
    protected void InformarClaseVehiculo_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad _mensaje = Mensaje(type);
            InformarClaseVehiculo.SetMessageBox(_mensaje.DesTipoMensaje, _mensaje.DesMensaje.Replace("@@@", valorReemplazo));
        }
        catch
        {
            throw;
        }
    }

    /*BOTON DE BUSQUEDA PARA LA CLASE VEHICULO*/
    protected void btnClaseVehiculo_Click(object sender, EventArgs e)
    {
        try
        {
            string[] sesion = valorSesionOculto.Value.Split('|');
            RespuestaConsultaSesion _sesion = wsSesiones.ConsultarSesion(sesion[0]);
            if (_sesion.Codigo == 0)
            {
                if (ValidarCaracterEspecial(txtClaseVehiculo.Text))
                {
                    //MENSAJE DE ERROR POR CARACTER ESPECIAL
                    InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_2");
                    mpeInformarBox.Show();
                }
                else
                {
                    ((wucGridEmergente)BusquedaClaseVehiculo).BindGridView(ConsultaClaseVehiculo(txtClaseVehiculo.Text));
                    mpeBusquedaClaseVehiculo.Show();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region GRIDVIEW CLASE VEHICULO

    private void gridViewClaseVehiculo_Init(object sender, EventArgs e)
    {
        GridViewTemplate _gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        gridViewColumn = new GridViewColumn();
        gridViewClaseVehiculo.Columns.Add(gridViewColumn.CreateBoundField("Texto", string.Empty, "Descripción", HorizontalAlign.Center, false, true));

        TemplateField lblID = new TemplateField();
        _gvTemplate.CrearCamposGridNoVisibles(gridViewClaseVehiculo, "Valor", lblID);
    }

    #endregion

    #region VENTANA BUSQUEDA CLASE VEHICULO

    protected void btnCerrarClaseVehiculo_Click(object sender, EventArgs e)
    {
        mpeBusquedaClaseVehiculo.Hide();
        updRealesPopUpControl.Update();
    }

    protected void btnAceptarClaseVehiculo_Click(object sender, EventArgs e)
    {
        try
        {
            SeleccionarRegistroClaseVehiculo(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnAceptarInformarClaseVehiculo_Click(object sender, EventArgs e)
    {
        mpeInformarClaseVehiculo.Hide();
        mpeBusquedaClaseVehiculo.Show();
    }

    #endregion

    #endregion

    #region METODOS PARA ADMINISTRACION CEDULAS

    //CONSULTA GRID ADMINISTRACION CEDULAS
    private List<GarantiasRealesCedulasEntidad> ConsultaCedulasInterno(int filtro)
    {
        try
        {
            List<GarantiasRealesCedulasEntidad> retorno = null;
            retorno = wsGarantias.GarantiasRealesCedulasConsultarGridInterno(filtro).ToList();

            return retorno;
        }
        catch
        {
            throw;
        }
    }

    //ACTUALIZA LOS DATOS DEL GRIDVIEW ADMINISTRACION CEDULAS
    private void GridViewCedulasInternoActualizar(int _idGarantiaReal)
    {
        grdCedulas.BindGridView(ConsultaCedulasInterno(_idGarantiaReal));

        txtCantidadCedulas.Text = grdCedulas.ContadorElementos().ToString();
        txtValorTotalFacial.Text = grdCedulas.SumarElementos("ValorFacial").ToString();
    }

    private void gridCedulasInterno_Init(object sender, EventArgs e)
    {
        GridViewTemplate _gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        _gvTemplate.CrearCamposGridNoVisibles(gridCedulasInterno, "IdGarantiaRealCedula", lblID);

        gridViewColumn = new GridViewColumn();
        gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("Serie", string.Empty, "Serie", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("Cedula", string.Empty, "Cédula", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("DesGradoGravamen", string.Empty, "Grado Gravamen", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("FechaVencimientoCedula", "{0:d}", "Vencimiento", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("FechaPrescripcionCedula", "{0:d}", "Prescripción", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("DesMoneda", string.Empty, "Moneda", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("ValorFacial", string.Empty, "Valor Facial", HorizontalAlign.Center, false, true));

        TemplateField lblID2 = new TemplateField();
        _gvTemplate.CrearCamposGridNoVisibles(gridCedulasInterno, "Id_Visible", lblID2);
    }

    #endregion

    #region EVENTOS DE CONTROLES

    private int ObtenerTipoBien()
    {
        string _valorTipoBien = ddlTipoBien.SelectedItem.Text.Substring(0, 3).Trim();
        return int.Parse(_valorTipoBien.Replace("-", ""));
    }

    private int ObtenerIndInscripcion()
    {
        string _valorIndInscripcion = ddlIndInscripcion.SelectedItem.Text.Substring(0, 3).Trim();
        return int.Parse(_valorIndInscripcion.Replace("-", ""));
    }

    private int ObtenerClaseTipoBien()
    {
        return int.Parse(ddlIdClaseTipoBien.SelectedValue);
    }

    private int ObtenerFormatoVehiculo()
    {
        return int.Parse(ddlIdFormatoIdentificacionVehiculo.SelectedValue);
    }

    //VALIDACION DEL FORMATO DEL N BIEN
    private bool ValidarNumeroBien()
    {
        var regex6Numerico = new Regex(@"^\d{6}$");
        
        var regex3letras3numeros = new Regex(@"^[a-zA-Z]{3}\d{3}$");

        var regexNoVocales = new Regex(@"^[^aeiouAEIOU]{3}");

        //RQ_MANT_2016050410580724: BACKLOG 3943
        var regex6NumericoNoFijo = new Regex(@"^\d{1,6}$");

        //Control de Cambios 1.1
        var regex17alfanumericosFijo = new Regex(@"^([a-zA-Z]|\d){17}$");
        var regex17alfanumericos = new Regex(@"^([a-zA-Z]|\d){1,17}$");

        var regexLetras = new Regex("^[a-zA-Z]*$");

        bool existeError = false; // FALSE - NO | TRUE - SI
        bool existeErrorSoloLetras = false; // FALSE - NO | TRUE - SI

        //VALOR SELECCIONADO EN EL FORMATO DE IDENTIFICACION VEHICULO
        string valorFormatoIdentificacion = this.ddlIdFormatoIdentificacionVehiculo.SelectedItem.Text;

        //RQ_MANT_2016050410580724: BACKLOG 3943
        if (ObtenerTipoBien().Equals(1) || ObtenerTipoBien().Equals(2))
        {
            //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES NO FIJOS
            if (!regex6NumericoNoFijo.IsMatch(this.txtCodigoBien.Text))
            {
                existeError = true;
            }
        }
        else
        {
            if (ObtenerTipoBien().Equals(9) || ObtenerTipoBien().Equals(10))
            {
                //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES
                if (!regex6Numerico.IsMatch(this.txtCodigoBien.Text))
                {
                    existeError = true;
                }
            }
            else
            {
                if (!ObtenerTipoBien().Equals(3))
                {
                    //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES
                    if (!regex17alfanumericos.IsMatch(this.txtCodigoBien.Text))
                    {
                        existeError = true;
                    }
                }
            }
        }

        if (ObtenerTipoBien().Equals(3))
        {
            if (valorFormatoIdentificacion.Equals("Numérico 6 enteros"))
            {
                //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES
                if (!regex6Numerico.IsMatch(this.txtCodigoBien.Text))
                {
                    existeError = true;
                }
            }
            else
            {
                if (valorFormatoIdentificacion.Equals("Alfanumérico 3 letras y 3 enteros"))
                {
                    //VERIFICACION DEL FORMATO 3 LETRAS Y 3 NUMEROS
                    if (!regex3letras3numeros.IsMatch(this.txtCodigoBien.Text))
                    {
                        existeError = true;
                    }
                    if (!regexNoVocales.IsMatch(this.txtCodigoBien.Text))
                    {
                        existeError = true;
                    }
                }
                else
                {
                    //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES
                    if (!regex17alfanumericosFijo.IsMatch(this.txtCodigoBien.Text))
                    {
                        existeError = true;
                    }

                    ////VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES PERO NO DEBEN SER SOLO LETRAS
                    //if (regexLetras.IsMatch(this.txtCodigoBien.Text))
                    //{
                    //    existeError = true;
                    //    existeErrorSoloLetras = true;
                    //}
                }
            }
        }

        return existeError;
    }

    //RQ_MANT_2016050410580724: BACKLOG 3943
    private void AutoCompletarNBien(bool texto)
    {
        if (texto)
        {
            this.txtCodigoBien.Attributes.Add("onblur", "AutoCompletar('" + txtCodigoBien.ClientID + "','" + ddlTipoBien.ClientID + "','" + ddlIdFormatoIdentificacionVehiculo.ClientID + "','0')");
        }
        else
        {
            this.txtCodigoBien.Attributes.Add("onblur", "");
        }
    }

    #endregion

    #region EVENTOS EXCEPCIONES SECCION ADICIONALES

    private void IndicadorDeudorHabitaExcepcion()
    {
        switch (ObtenerTipoBien())
        {
            case 2:
                AdministrarBlanco("ddlIdDeudorHabita", false);
                break;

            default:
                ddlIdDeudorHabita.Enabled = false;
                break;
        }
    }

    public void IndicadorInscripcionExcepcion()
    {
        //updRealesPopUpControl.Update(); 
        if (this.ddlIndInscripcion.SelectedItem.Text.Substring(0, 3).Equals("2 -") || this.ddlIndInscripcion.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
        {
            this.txtFechaPresentacion.Enabled = true;
            this.rfvFechaPresentacion.Enabled = true;
            this.calendarExtenderFechaPresentacion.Enabled = true;
            this.imbFechaPresentacion.Enabled = true;
        }

        else
        {
            this.txtFechaPresentacion.Enabled = false;
            this.rfvFechaPresentacion.Enabled = false;
            this.calendarExtenderFechaPresentacion.Enabled = false;
            this.imbFechaPresentacion.Enabled = false;
            this.txtFechaPresentacion.Text = string.Empty;
        }
    }

    private void IndicadorPolizaExcepcion()
    {
        /*
        switch (ObtenerTipoBien())
        {
            case 2:
            case 3:
                AdministrarBlanco("ddlIdPoliza", false);
                break;
            default:
                ddlIdPoliza.Enabled = false;
                break;
        }
         */
    }

    private void IndicadorGarantiaExcepcion()
    {
        //Ajustes javendano 2015-01-12
        switch (ObtenerTipoBien())
        {
            case 3:
                switch (ObtenerClaseTipoBien())
                {
                    case 8:
                        break;

                    default:
                        AdministrarBlanco("ddlIdIndicadorRecomendacion", false);
                        AdministrarBlanco("ddlIdIndicadorInspeccion", false);
                        break;
                }

                break;

            default:
                AdministrarBlanco("ddlIdIndicadorRecomendacion", false);
                AdministrarBlanco("ddlIdIndicadorInspeccion", false);
                break;
        }
    }

    private void TipoMitigadorExcepcion()
    {
        string _filtro = string.Empty;

        try
        {
            switch (ObtenerTipoBien())
            {
                case 1:
                    switch (ObtenerClaseTipoBien())
                    {
                        case 1: //HIPOTECA COMUN TIPO BIEN 1
                        case 3: //HIPOTECA ABIERTA TIPO BIEN 1
                            _filtro = "1";
                            break;

                        case 2: //CEDULA HIPOTECARIA TIPO BIEN 1
                            _filtro = "4";
                            break;
                    }

                    ddlIdTipoMitigadorRiesgo.Enabled = false;
                    break;

                case 2:
                    switch (ObtenerClaseTipoBien())
                    {
                        case 4: //HIPOTECA COMUN TIPO BIEN 2
                        case 6: //HIPOTECA ABIERTA TIPO BIEN 2
                            _filtro = "2,3";
                            break;

                        case 5: //CEDULA HIPOTECARIA TIPO BIEN 2
                            _filtro = "5,6";
                            break;
                    }

                    AdministrarBlanco("ddlIdTipoMitigadorRiesgo", false);
                    ddlIdTipoMitigadorRiesgo.Enabled = true;
                    break;

                case 3: //TIPO BIEN 3
                    switch (ObtenerClaseTipoBien())
                    {
                        case 7: //PRENDA COMUN TIPO BIEN 3
                            _filtro = "7,8";
                            ddlIdTipoMitigadorRiesgo.Enabled = true;
                            AdministrarBlanco("ddlIdTipoMitigadorRiesgo", false);
                            break;

                        case 8: //BONO DE PRENDA TIPO BIEN 3
                            _filtro = "9";
                            ddlIdTipoMitigadorRiesgo.Enabled = false;
                            AdministrarBlanco("ddlIdTipoMitigadorRiesgo", true);
                            break;
                    }

                    break;

                default: //TIPO BIEN 4-14
                    _filtro = "7,8";
                    ddlIdTipoMitigadorRiesgo.Enabled = true;
                    AdministrarBlanco("ddlIdTipoMitigadorRiesgo", false);
                    break;
            }

            LimpiarDropDownList(ddlIdTipoMitigadorRiesgo);
            if (ddlIdTipoMitigadorRiesgo != null)
            {
                ddlIdTipoMitigadorRiesgo.Items.Clear();
                ddlIdTipoMitigadorRiesgo.DataSource = wsListas.TiposMitigadoresRiesgosLista(_filtro);
                ddlIdTipoMitigadorRiesgo.DataTextField = "Texto";
                ddlIdTipoMitigadorRiesgo.DataValueField = "Valor";
                ddlIdTipoMitigadorRiesgo.DataBind();
            }
        }
        catch
        {
            throw;
        }
    }

    private void TipoDocumentoExcepcion()
    {
        string _filtro = string.Empty;

        try
        {
            switch (ObtenerTipoBien())
            {
                case 1:
                case 2:
                    switch (ObtenerClaseTipoBien())
                    {
                        case 1: //HIPOTECA COMUN TIPO BIEN 1

                        case 4: //HIPOTECA COMUN TIPO BIEN 2

                        case 3: //HIPOTECA ABIERTA TIPO BIEN 1

                        case 6: //HIPOTECA ABIERTA TIPO BIEN 2
                            _filtro = "1,2,3,4";
                            break;

                        case 2: //CEDULA HIPOTECARIA TIPO BIEN 1

                        case 5: //CEDULA HIPOTECARIA TIPO BIEN 2
                            _filtro = "5,6,7,8";
                            break;
                    }

                    break;
                case 3:
                    switch (ObtenerClaseTipoBien())
                    {
                        case 7:
                            _filtro = "9,10,11,12,13,14,15,16,28";
                            break;
                        case 8:
                            _filtro = "17,18,19,20";
                            break;
                    }
                    break;
                default:
                    _filtro = "9,10,11,12,13,14,15,16,28";
                    break;
            }

            AdministrarBlanco("ddlIdTipoDocumentoLegal", false);
            ddlIdTipoDocumentoLegal.Enabled = true;

            LimpiarDropDownList(ddlIdTipoDocumentoLegal);
            if (ddlIdTipoDocumentoLegal != null)
            {
                ddlIdTipoDocumentoLegal.Items.Clear();
                ddlIdTipoDocumentoLegal.DataSource = wsListas.TiposDocumentosLegalesLista(_filtro);
                ddlIdTipoDocumentoLegal.DataTextField = "Texto";
                ddlIdTipoDocumentoLegal.DataValueField = "Valor";
                ddlIdTipoDocumentoLegal.DataBind();
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
            DropDownList ddl = (DropDownList)FindControl(ddlNombre);

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
        catch
        {
            throw;
        }
    }

    private ControlEntidad BuscarControlesReales(List<ControlEntidad> controlEntidad, string nombreControl)
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

        if (_control.ValorDefecto.Length > 0)
            _textBox.Text = _control.ValorDefecto;

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

    private void CargarDropDownListControl(ControlEntidad _control, DropDownList _dropDownList, string _filtro)
    {
        #region DROPDOWNLIST

        //LIMPIAR EL CONTROL DROPDOWNLIST
        LimpiarDropDownList(_dropDownList);

        //CARGAR EL DROPDOWNLIS
        _dropDownList.DataSource = LlenarDropDownList(_control.MetodoServicioWeb, _filtro);
        _dropDownList.DataValueField = "Valor";
        _dropDownList.DataTextField = "Texto";
        _dropDownList.DataBind();
        _dropDownList.Enabled = bool.Parse(_control.IndModificar);
        _dropDownList.Visible = bool.Parse(_control.IndVisible);
        _dropDownList.CssClass = _control.CssTipo;

        #endregion
    }

    private void CargarDropDownListControlFormato(ControlEntidad _control, DropDownList _dropDownList, string _filtro)
    {
        #region DROPDOWNLIST

        //LIMPIAR EL CONTROL DROPDOWNLIST
        LimpiarDropDownList(_dropDownList);

        //CARGAR EL DROPDOWNLIS
        _dropDownList.Items.Add(new ListItem("Numérico 6 enteros", "1"));
        _dropDownList.Items.Add(new ListItem("Alfanumérico 3 letras y 3 enteros", "2"));
        _dropDownList.Items.Add(new ListItem("Alfanumérico 17 caracteres", "3"));
        _dropDownList.SelectedIndex = 0;
        _dropDownList.Enabled = bool.Parse(_control.IndModificar);
        _dropDownList.Visible = bool.Parse(_control.IndVisible);
        _dropDownList.CssClass = _control.CssTipo;

        #endregion
    }

    private void LimpiarDropDownList(DropDownList _dropDownList)
    {
        //BORRA LOS Reales DEL DDL, SE DEBE DE REALIZAR DE ESTA MANERA PARA ELIMINAR LOS DATOS EN CACHÉ DEL OBJ
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
            return null;
            throw ex;
        }
    }

    private void SetDataKeys(GridView _gridView, String[] _dataKeysString)
    {
        _gridView.DataKeyNames = _dataKeysString;
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
        mpeInformarBox.Hide();
        updRealesPopUpControl.Update();
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
        catch
        {
            throw;
        }
    }

    protected void InformarBox1_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad _mensaje = Mensaje(type);
            InformarBox1.SetMessageBox(_mensaje.DesTipoMensaje, _mensaje.DesMensaje.Replace("@@@", valorReemplazo));
        }
        catch
        {
            throw;
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