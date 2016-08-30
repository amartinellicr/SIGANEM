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

public partial class wucOperacionRelacionAvales : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region VARIABLES

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

    public void LimpiarBarraMensaje()
    {
        this.divBarraMensaje.Visible = false;
    }

    public void LimpiarContenidoControlAvales()
    {

        #region LIMPIAR MENSAJES

        //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
        if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
        {
            this.divBarraMensaje.Visible = false;
        }

        #endregion

        /*B18S03*/
        this.txtNAval.Text = string.Empty;
        this.txtIdentificacionAvalista.Text = string.Empty;
        this.txtMontoGradoGravamen.Text = string.Empty;
        this.txtMontoMitigador.Text = string.Empty;
        this.txtMontoMitigadorCalculado.Text = string.Empty;
        this.txtFechaConstitucionGarantia.Text = string.Empty;
        this.txtFechaVencimientoGarantia.Text = string.Empty;
        this.txtFechaPrescripcionGarantia.Text = string.Empty;
        this.txtPorcentajeAceptBCR.Text = string.Empty;
        this.txtPorcentajeAceptSugef.Text = string.Empty;
        this.txtPorcentajeResponSugef.Text = string.Empty;
        this.txtPorcentajeResponLegal.Text = string.Empty;
        /*B18S03*/

        //Correccion javendano 2015-01-08
        _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoDocumentoLegal, "29");
        _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoMitigadorRiesgo, "0");

    }

    public void CargarContenidoControlAvales(List<ControlEntidad> controles)
    {
        try
        {
            AsignaWebServicesTypeNames();
            ControlEntidad controlSeleccionado = null;

            #region APARTADO GENERAL

            #region TIPO AVAL

            controlSeleccionado = BuscarControlesAvales(controles, this.lblIdTipoAval.ID);
            this.lblIdTipoAval.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesAvales(controles, this.ddlIdTipoAval.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoAval, string.Empty);

            #endregion
            #region N° AVAL

            controlSeleccionado = BuscarControlesAvales(controles, this.lblNAval.ID);
            this.lblNAval.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, this.txtNAval.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtNAval);
            ////Ajuste javendano 2015-01-09
            //this.mskIdentificacionRUC.InputDirection = MaskedEditInputDirection.LeftToRight;
            //this.mskIdentificacionRUC.AutoComplete = false;
            //txtIdentificacionRUC.ToolTip = "#-####-####";

            #endregion

            #endregion
            #region APARTADO DETALLE

            #region TIPO IDENTIFICACION AVALISTA

            controlSeleccionado = BuscarControlesAvales(controles, this.lblIdTipoIdentificacionAvalista.ID);
            this.lblIdTipoIdentificacionAvalista.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, this.txtIdTipoIdentificacionAvalista.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtIdTipoIdentificacionAvalista);

            #endregion
            #region IDENTIFICACION AVALISTA

            controlSeleccionado = BuscarControlesAvales(controles, this.lblIdentificacionAvalista.ID);
            this.lblIdentificacionAvalista.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, this.txtIdentificacionAvalista.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtIdentificacionAvalista);

            #endregion
            #region MONTO AVALADO

            controlSeleccionado = BuscarControlesAvales(controles, this.lblMontoAvalado.ID);
            this.lblMontoAvalado.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, this.txtMontoAvalado.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtMontoAvalado);

            #endregion

            #endregion
            #region APARTADO ADICIONALES

            #region CLASE GARANTIA

            controlSeleccionado = BuscarControlesAvales(controles, lblIdClaseGarantiaPrt17.ID);
            lblIdClaseGarantiaPrt17.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesAvales(controles, ddlIdClaseGarantiaPrt17.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdClaseGarantiaPrt17, "20");
            //AdministrarBlanco("ddlIdClaseGarantiaPrt17", true);

            #endregion
            #region TIPO MITIGADOR RIESGO

            controlSeleccionado = BuscarControlesAvales(controles, lblIdTipoMitigadorRiesgo.ID);
            lblIdTipoMitigadorRiesgo.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesAvales(controles, ddlIdTipoMitigadorRiesgo.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoMitigadorRiesgo, "29");
            //AdministrarBlanco("ddlIdTipoMitigadorRiesgo", true);

            #endregion

            #region CODIGO TENENCIA

            controlSeleccionado = BuscarControlesAvales(controles, lblIdTenenciaPrt15.ID);
            lblIdTenenciaPrt15.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesAvales(controles, ddlIdTenenciaPrt15.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTenenciaPrt15, "37");
            //AdministrarBlanco("ddlIdTenenciaPrt15", true);

            #endregion
            #region TIPO DOCUMENTO

            controlSeleccionado = BuscarControlesAvales(controles, lblIdTipoDocumentoLegal.ID);
            lblIdTipoDocumentoLegal.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesAvales(controles, ddlIdTipoDocumentoLegal.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoDocumentoLegal, "29");
            //AdministrarBlanco("ddlIdTipoDocumentoLegal", true);

            #endregion

            #region GRADO GRAVAMEN

            controlSeleccionado = BuscarControlesAvales(controles, lblIdGradoGravamen.ID);
            lblIdGradoGravamen.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesAvales(controles, ddlIdGradoGravamen.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdGradoGravamen, "1");
            //AdministrarBlanco("ddlIdGradoGravamen", true);

            #endregion
            #region MONTO MITIGADOR

            controlSeleccionado = BuscarControlesAvales(controles, lblMontoMitigador.ID);
            lblMontoMitigador.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, txtMontoMitigador.ID);
            CargarTextBoxControl(controlSeleccionado, txtMontoMitigador, mskMontoMitigador);
            //Ajustes javendano 2015-01-12
            //this.wmMontoMitigador.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion

            #region TIPO MONEDA GRADO GRAVAMEN

            controlSeleccionado = BuscarControlesAvales(controles, lblIdTipoMonedaGradoGravamen.ID);
            lblIdTipoMonedaGradoGravamen.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesAvales(controles, ddlIdTipoMonedaGradoGravamen.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoMonedaGradoGravamen, string.Empty);

            #endregion
            #region MONTO MITIGADOR CALCULADO

            controlSeleccionado = BuscarControlesAvales(controles, lblMontoMitigadorCalculado.ID);
            lblMontoMitigadorCalculado.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, txtMontoMitigadorCalculado.ID);
            CargarTextBoxControl(controlSeleccionado, txtMontoMitigadorCalculado, mskMontoMitigadorCalculado);
            //Ajustes javendano 2015-01-12
            // this.wmMontoMitigadorCalculado.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            //DESHABILITA EL CAMPO MONTO MITIGADOR CALCULADO 
            this.txtMontoMitigadorCalculado.Enabled = false;

            #endregion

            #region MONTO GRAVAMEN

            controlSeleccionado = BuscarControlesAvales(controles, lblMontoGradoGravamen.ID);
            lblMontoGradoGravamen.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, txtMontoGradoGravamen.ID);
            CargarTextBoxControl(controlSeleccionado, txtMontoGradoGravamen, mskMontoGradoGravamen);
            //Ajustes cloaiza 2015-10-20
            //this.wmMontoGradoGravamenAvales.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion
            #region PORCENTAJE ACEPTACIÓN BCR

            controlSeleccionado = BuscarControlesAvales(controles, lblPorcentajeAceptBCR.ID);
            lblPorcentajeAceptBCR.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, txtPorcentajeAceptBCR.ID);
            CargarTextBoxControl(controlSeleccionado, txtPorcentajeAceptBCR, mskPorcentajeAceptBCR);
            //Ajustes javendano 2015-01-12
            this.wmPorcentajeAceptBCR.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            ////DESHABILITA EL CAMPO PORCENTAJE ACEPTACION TERRENO 
            //this.txtPorcentajeAceptBCR.Enabled = false;

            #endregion

            #region FECHA CONSTITUCION

            controlSeleccionado = BuscarControlesAvales(controles, lblFechaConstitucionGarantia.ID);
            lblFechaConstitucionGarantia.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, txtFechaConstitucionGarantia.ID);
            CargarTextBoxControl(controlSeleccionado, txtFechaConstitucionGarantia, imgFechaConstitucionGarantia);

            #endregion
            #region PORCENTAJE ACEPTACIÓN SUGEF

            controlSeleccionado = BuscarControlesAvales(controles, lblPorcentajeAceptSugef.ID);
            lblPorcentajeAceptSugef.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, txtPorcentajeAceptSugef.ID);
            CargarTextBoxControl(controlSeleccionado, txtPorcentajeAceptSugef, mskPorcentajeAceptSugef);
            //Ajustes javendano 2015-01-12
            //this.wmPorcentajeAceptTerrenoSugef.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            //DESHABILITA EL CAMPO PORCENTAJE ACEPTACION TERRENO 
            this.txtPorcentajeAceptSugef.Enabled = false;

            #endregion

            #region FECHA VENCIMIENTO

            controlSeleccionado = BuscarControlesAvales(controles, lblFechaVencimientoGarantia.ID);
            lblFechaVencimientoGarantia.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, txtFechaVencimientoGarantia.ID);
            CargarTextBoxControl(controlSeleccionado, txtFechaVencimientoGarantia, imgFechaVencimientoGarantia);

            #endregion
            #region PORCENTAJE RESPONSABILIDAD SUGEF

            controlSeleccionado = BuscarControlesAvales(controles, lblPorcentajeResponSugef.ID);
            lblPorcentajeResponSugef.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, txtPorcentajeResponSugef.ID);
            CargarTextBoxControl(controlSeleccionado, txtPorcentajeResponSugef, mskPorcentajeResponSugef);
            ////Ajustes javendano 2015-01-12
            //this.wmPorcentajeResponSugef.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            //DESHABILITA EL CAMPO PORCENTAJE RESPONSABILIDAD SUGEF Ajustes cloaiza 2015-10-20
            this.txtPorcentajeResponSugef.Enabled = false;

            #endregion

        
            #region FECHA PRESCRIPCION

            controlSeleccionado = BuscarControlesAvales(controles, lblFechaPrescripcionGarantia.ID);
            lblFechaPrescripcionGarantia.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, txtFechaPrescripcionGarantia.ID);
            CargarTextBoxControl(controlSeleccionado, txtFechaPrescripcionGarantia, imgFechaPrescripcionGarantia);

            #endregion          
            #region PORCENTAJE RESPONSABILIDAD LEGAL

            controlSeleccionado = BuscarControlesAvales(controles, lblPorcentajeResponLegal.ID);
            lblPorcentajeResponLegal.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesAvales(controles, txtPorcentajeResponLegal.ID);
            CargarTextBoxControl(controlSeleccionado, txtPorcentajeResponLegal, mskPorcentajeResponLegal);
            //////Ajustes javendano 2015-01-12
            //this.wmPorcentajeResponLegal.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion
           
            #endregion

            updAvalesPopUpControl.Update();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void HabilitarContenidoExcepcionesAdicionales(bool estado)
    {
        this.txtPorcentajeAceptBCR.Enabled = estado;
    }

    public void HabilitarContenidoExcepcionesGenerales(bool estado)
    {
        this.txtPorcentajeAceptBCR.Enabled = estado;
        this.txtMontoMitigador.Enabled = estado;
        this.txtMontoGradoGravamen.Enabled = estado;
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

                //_entidad.IdTipoIdentificacionRUC = int.Parse(ddlIdTipoIdentificacionRUC.SelectedItem.Value);
                //_entidad.IdentificacionRUC = txtIdentificacionRUC.Text;

                _entidad.IdTipoAval = int.Parse(ddlIdTipoAval.SelectedItem.Value);
                _entidad.NumeroAval = txtNAval.Text;


                #endregion

                _consulta = wsGarantias.OperacionesGarantiasAvalesBusqueda(_entidad);

                if (ValidarCaracterEspecial(txtNAval.Text))
                {

                    //MENSAJE DE ERROR POR CARACTER ESPECIAL
                    InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_2");
                    mpeInformarBox.Show();
                   
                }
                else
                {
                    if (_consulta != null)
                    {
                        idGarantiaAvalesOculto.Value = _consulta.IdGarantiaAval.ToString();
                        txtIdTipoIdentificacionAvalista.Text = _consulta.DesTipoPersonaAvalista.ToString();
                        txtIdentificacionAvalista.Text = _consulta.CodAvalista.ToString();
                        txtMontoAvalado.Text = _consulta.MontoAvalado.ToString();

                        //DESHABILITAR LA TABLA GENERALES
                        _generadorControles.Bloquear_Controles(tableGeneral, false);
                        //HABILITAR LA TABLA ADICIONALES
                        tableAdicionales.Disabled = false;
                        btnConsultarGarantia.Enabled = false;
                        btnConsultarGarantia.CssClass = "botonConsultarRelacionDisabled";

                        HabilitarContenidoExcepcionesGenerales(true);
                    }
                    else
                    {
                        // MENSAJE SESIÓN CADUCADA
                        this.InformarBox1_SetConfirmationBoxEvent(null, e, "GAR_1");
                        this.mpeInformarBox.Show();
                    }
                    updAvalesPopUpControl.Update();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public GarantiasWS.RespuestaEntidad DeControlesAEntidad(int tipoAccion)
    {
        GarantiasWS.RespuestaEntidad result = new GarantiasWS.RespuestaEntidad();
        
        try
        {
            string[] sesion = valorSesionOculto.Value.Split('|');
            
            _entidad.IdOperacion = int.Parse(sesion[3]);
            _entidad.IdGarantiaOperacion = int.Parse(sesion[3]);
            _entidad.IdGarantiaAval = int.Parse(idGarantiaAvalesOculto.Value);
            _entidad.IdTipoGarantia = int.Parse(sesion[4]);

            #region APARTADO DETALLE

            //TIPO IDENTIFICACION AVALISTA
            //_entidad.IdTipoPersonaAvalista = int.Parse(txtIdTipoIdentificacionAvalista.Text);
            _entidad.DesTipoPersonaAvalista = txtIdTipoIdentificacionAvalista.Text;
            //IDENTIFICACION AVALISTA
            _entidad.CodAvalista = int.Parse(txtIdentificacionAvalista.Text);
            ////IDENTIFICACION SICC
            //_entidad.IdentificacionSICC = txtIdentificacionSICC.Text;
            //MONTO AVALADO
            if (txtMontoAvalado.Text.Length < 1)
                _entidad.MontoAvalado = null;
            else
                _entidad.MontoAvalado = decimal.Parse(txtMontoAvalado.Text);

            #endregion
            #region APARTADO ADICIONALES

            //CLASE DE GARANTIA
            _entidad.IdClaseGarantiaPrt17 = int.Parse(ddlIdClaseGarantiaPrt17.SelectedItem.Value);
            //CODIGO DE TENDENCIA
            _entidad.IdTenenciaPrt15 = int.Parse(ddlIdTenenciaPrt15.SelectedItem.Value);
            //GRADO GRAVAMEN
            _entidad.IdGradoGravamen = int.Parse(ddlIdGradoGravamen.SelectedItem.Value);
            //TIPO MONEDA GRADO GRAVAMEN
            _entidad.IdTipoMonedaGradoGravamen = int.Parse(ddlIdTipoMonedaGradoGravamen.SelectedItem.Value);
            //MONTO GRADO GRAVAMEN
            _entidad.MontoGradoGravamen = decimal.Parse(txtMontoGradoGravamen.Text);
            //TIPO MITIGADOR RIESGO
            _entidad.IdTipoMitigadorRiesgo = int.Parse(ddlIdTipoMitigadorRiesgo.SelectedItem.Value);
            //TIPO DOCUMENTO LEGAL
            _entidad.IdTipoDocumentoLegal = int.Parse(ddlIdTipoDocumentoLegal.SelectedItem.Value);
           
            //MONTO MITIGADOR
            if (txtMontoMitigador.Text.Length > 0)
                _entidad.MontoMitigador = decimal.Parse(txtMontoMitigador.Text);
            else
                _entidad.MontoMitigador = null;
            
            //MONTO MITIGADOR CALCULADO
            if (txtMontoMitigadorCalculado.Text.Length > 0 && txtMontoMitigadorCalculado.Text.Length <= 22)
                _entidad.MontoMitigadorCalculado = decimal.Parse(txtMontoMitigadorCalculado.Text);
            else
                //_entidad.MontoMitigadorCalculado = decimal.Parse(wmMontoMitigadorCalculado.WatermarkText);
            _entidad.MontoMitigadorCalculado = null;
            
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
                //_entidad.PorcentajeAceptNoTerrenoSugef = 0;
            else
                _entidad.PorcentajeAceptNoTerrenoSugef = null;
            //_entidad.PorcentajeAceptSugef = decimal.Parse(wmPorcentajeAceptSugef.WatermarkText);

            //PORCENTAJE RESPONSABILIDAD SUGEF
            if (txtPorcentajeResponSugef.Text.Length > 0)
                _entidad.PorcentajeResponSugef = decimal.Parse(txtPorcentajeResponSugef.Text);
            else
                _entidad.PorcentajeResponSugef = null;
            //_entidad.PorcentajeResponSugef = decimal.Parse(wmPorcentajeResponSugef.WatermarkText);

            //PORCENTAJE RESPONSABILIDAD LEGAL
            if (txtPorcentajeResponLegal.Text.Length > 0)
                _entidad.PorcentajeResponLegal = decimal.Parse(txtPorcentajeResponLegal.Text);
            else
                _entidad.PorcentajeResponLegal = null;
            //_entidad.PorcentajeResponLegal = decimal.Parse(wmPorcentajeResponSugef.WatermarkText);
           
            #endregion
            //REQUERIMIENTO BLOQUE 7 1-24381561
            #region CONTROL DE REGISTRO

            _entidad.CodUsuarioIngreso = sesion[2];
            _entidad.IndMetodoInsercion = Resources.Resource._metodoInsercion;

            #endregion
            #region DIRECCIONAMIENTO SEGUN EL TIPO DE ACCION

            //bool validarFechas = ValidarFechaVencimiento(this.txtFechaConstitucionGarantia.Text, txtFechaVencimientoGarantia.Text, txtFechaPrescripcionGarantia.Text);
            //if (!validarFechas)
            //{
            //    result.ValorError = -1;
            //}
            //else
            //{
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
            //}

                
            

            #endregion

            return result;
        }
        catch
        {
           throw;
        }
        
    }

    public void DeEntidadAControles(GarantiasOperacionesRelacionEntidad _entidadOperacion, GarantiasAvalesEntidad _entidadAvales)
    {
        try
        {
            idGarantiaAvalesOculto.Value = _entidadOperacion.IdGarantiaAval.ToString();

            #region APARTADO DETALLE

            //TIPO IDENTIFICACION AVALISTA
            //txtIdTipoIdentificacionAvalista.Text = _entidadAvales.IdTipoPersonaDeudor.ToString();
            txtIdTipoIdentificacionAvalista.Text = _entidadAvales.DesTipoPersonaDeudor.ToString();
            //NUMERO AVAL
            txtNAval.Text = _entidadAvales.NumeroAval.ToString();

            //IDENTIFICACION AVALISTA
            txtIdentificacionAvalista.Text = _entidadAvales.IdDeudor.ToString();
            //MONTO AVALADO
            txtMontoAvalado.Text = _entidadAvales.MontoAvalado.ToString();

            #endregion

            #region APARTADO ADICIONALES

            //CLASE DE GARANTIA
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdClaseGarantiaPrt17, _entidadOperacion.IdClaseGarantiaPrt17.ToString());
            //CODIGO DE TENDENCIA
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTenenciaPrt15, _entidadOperacion.IdTenenciaPrt15.ToString());
            //GRADO GRAVAMEN
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdGradoGravamen, _entidadOperacion.IdGradoGravamen.ToString());
            //TIPO MONEDA GRADO GRAVAMEN
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoMonedaGradoGravamen, _entidadOperacion.IdTipoMonedaGradoGravamen.ToString());
            //MONTO GRADO GRAVAMEN
            txtMontoGradoGravamen.Text = _entidadOperacion.MontoGradoGravamen.ToString();
            //TIPO MITIGADOR RIESGO
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoMitigadorRiesgo, _entidadOperacion.IdTipoMitigadorRiesgo.ToString());
            //TIPO DOCUMENTO LEGAL
            _generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoDocumentoLegal, _entidadOperacion.IdTipoDocumentoLegal.ToString());           
            //MONTO MITIGADOR
            txtMontoMitigador.Text = _entidadOperacion.MontoMitigador.ToString();
            //MONTO MITIGADOR CALCULADO
            if (_entidadOperacion.MontoMitigadorCalculado.ToString().Length > 0)
                txtMontoMitigadorCalculado.Text = string.Format("{0:N}", _entidadOperacion.MontoMitigadorCalculado);
            else
                txtMontoMitigadorCalculado.Text = string.Empty;
            //PORCENTAJE ACEPTACION BCR
            if (_entidadOperacion.PorcentajeAceptBCR.ToString().Length > 0)
                txtPorcentajeAceptBCR.Text = _entidadOperacion.PorcentajeAceptBCR.ToString();
            else
                txtPorcentajeAceptBCR.Text = "0";
            //PORCENTAJE ACEPTACION SUGEF
            txtPorcentajeAceptSugef.Text = _entidadOperacion.PorcentajeAceptNoTerrenoSugef.ToString();
            //PORCENTAJE RESPONSABILIDAD SUGEF
            txtPorcentajeResponSugef.Text = _entidadOperacion.PorcentajeResponSugef.ToString();
            //PORCENTAJE RESPONSABILIDAD LEGAL
            txtPorcentajeResponLegal.Text = _entidadOperacion.PorcentajeResponLegal.ToString();

            #endregion
        }
        catch
        {
            throw;
        }
    }
    /*B18S03*/
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

                updAvalesPopUpControl.Update();

                fueraRango = true;
            }
            return fueraRango;
        }
        catch
        {
            throw;
        }
    }

    public void OperacionMontoMitigadorCalculado(string tipoGarantia, string valorColonizado, string valorOriginalColonizado)
    {
        try
        {
             Decimal campo = 0;
             
            //SI TIPO DE GARANTIA = (1 - OPERACION) : SALDO COLONIZADO, DE LO CONTRARIO SALDO ORIGINAL COLONIZADO
             if (!string.IsNullOrEmpty(txtPorcentajeAceptBCR.Text))
             {
                 if (Decimal.Parse(txtPorcentajeAceptBCR.Text) > 0)
                 {
                     if (int.Parse(tipoGarantia) == 1)
                         campo = (Decimal.Parse(valorColonizado) * Decimal.Parse(txtPorcentajeAceptBCR.Text)) / 100;
                     else
                         campo = ((Decimal.Parse(valorOriginalColonizado) * Decimal.Parse(txtPorcentajeAceptBCR.Text)) / 100);

                     string montoMitigadorCalculado = String.Format("{0:N}", campo);
                     txtMontoMitigadorCalculado.Text = montoMitigadorCalculado;
                 }
                 else
                 {
                     this.txtMontoMitigadorCalculado.Text = campo.ToString();
                 }

             }
             else
             {
                 this.txtMontoMitigadorCalculado.Text = campo.ToString();
             }
             
        }
        catch
        {
            throw;
        }
    }

    #region METODOS PARA DROPDOWNLIST

    ///*B18S03*/
    //protected void ddlIdTipoIdentificacionRUC_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string valorSeleccionado = string.Empty;

    //    if (mskIdentificacionRUC != null && txtIdentificacionRUC != null)
    //    {
    //        txtIdentificacionRUC.Text = string.Empty;

    //        valorSeleccionado = ddlIdTipoIdentificacionRUC.SelectedItem.Text.Substring(0, 3);

    //        //ESTABLECE LA MASCARA SEGUN EL TIPO DE IDENTIFICACION
    //        switch (valorSeleccionado)
    //        {
    //            case "1 -":
    //                mskIdentificacionRUC.Enabled = true;
    //                mskIdentificacionRUC.Mask = "9-9999-9999";
    //                mskIdentificacionRUC.Filtered = string.Empty;
    //                txtIdentificacionRUC.ToolTip = "#-####-####";
    //                //txtIdentificacionRUC.MaxLength = 12;
    //                break;
    //            case "2 -":
    //                mskIdentificacionRUC.Enabled = true;
    //                mskIdentificacionRUC.Mask = "9-999-999999";
    //                mskIdentificacionRUC.Filtered = string.Empty;
    //                txtIdentificacionRUC.ToolTip = "#-###-######";
    //                //txtIdentificacionRUC.MaxLength = 12;
    //                break;
    //            case "5 -":
    //                mskIdentificacionRUC.Enabled = false;
    //                txtIdentificacionRUC.MaxLength = 17;
    //                //Ajuste javendano 2015-01-09
    //                txtIdentificacionRUC.ToolTip = "Texto Id Garantía";
    //                break;
    //            default:
    //                txtIdentificacionRUC.MaxLength = 30;
    //                mskIdentificacionRUC.Enabled = false;
    //                //Ajuste javendano 2015-01-09
    //                txtIdentificacionRUC.ToolTip = "Texto Id Garantía";
    //                break;
    //        }
    //        updAvalesPopUpControl.Update();
    //    }
    //}
    ///*B18S03*/

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

    protected void txtPorcentajeAceptBCR_TextChanged(object sender, EventArgs e)
    {
    //    try
       // {
        if (!string.IsNullOrEmpty(txtPorcentajeAceptBCR.Text))
        {
            PorcentajeAceptBCR(sender, e);
        }
       // }
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
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

    private void PorcentajeAceptBCR(object sender, EventArgs e)
    {
        try
        {
            string[] sesion = valorSesionOculto.Value.Split('|');
            string TipoOperacion = sesion[5];
            string ValorColonizado = sesion[6];
            string ValorOriginalColonizado = sesion[7];
            //this.txtPorcentajeAceptSugef.Text = this.txtPorcentajeAceptBCR.Text;
            this.txtPorcentajeResponSugef.Text = this.txtPorcentajeAceptBCR.Text;
            this.txtPorcentajeResponLegal.Text = this.txtPorcentajeAceptBCR.Text;

            OperacionMontoMitigadorCalculado(TipoOperacion, ValorColonizado, ValorOriginalColonizado);
            
            updAvalesPopUpControl.Update();

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

    private ControlEntidad BuscarControlesAvales(List<ControlEntidad> controlEntidad, string nombreControl)
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

            if (_textBox.ID.Contains("Monto") || _textBox.ID.Contains("Porcentaje") || _textBox.ID.Contains("Salario"))
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
        _dropDownList.DataSource = LlenarDropDownList(_control.MetodoServicioWeb, _filtro);
        _dropDownList.DataValueField = "Valor";
        _dropDownList.DataTextField = "Texto";
        _dropDownList.DataBind();
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
            return null;
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
        updAvalesPopUpControl.Update();
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