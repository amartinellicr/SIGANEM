using System;
using System.Net;
using System.Web;
using System.Text;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Reflection;
using AjaxControlToolkit;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using ListasWS;
using SesionesWCF;
using GarantiasWS;
using SeguridadWS;

using BCR.SIGANEM.UT;


public partial class wucOperacionRelacionFiduciaria : System.Web.UI.UserControl
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

    public void LimpiarContenidoControlFiduciaria()
    {

        #region LIMPIAR MENSAJES

        //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
        if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
        {
            this.divBarraMensaje.Visible = false;
        }

        #endregion

        this.txtIdentificacionRUC.Text = string.Empty;
        this.txtIdentificacionSICC.Text = string.Empty;
        this.txtSalarioNetoFiador.Text = string.Empty;
        this.txtMontoGradoGravamen.Text = string.Empty;
        this.txtMontoMitigador.Text = string.Empty;
        this.txtMontoMitigadorCalculado.Text = string.Empty;
        this.txtFechaConstitucionGarantia.Text = string.Empty;
        this.txtFechaVencimientoGarantia.Text = string.Empty;
        this.txtFechaPrescripcionGarantia.Text = string.Empty;
        this.txtPorcentajeAceptBCR.Text = string.Empty;
        this.txtPorcentajeAceptSugef.Text = string.Empty;
        this.txtPorcentajeResponSugef.Text = string.Empty;

        //Correccion javendano 2015-01-08
        _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoDocumentoLegal, "29");
        _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoMitigadorRiesgo, "0");

    }

    public void CargarContenidoControlFiduciaria(List<ControlEntidad> controles)
    {
        try
        {
            AsignaWebServicesTypeNames();
            ControlEntidad controlSeleccionado = null;

            #region APARTADO GENERAL

            #region TIPO IDENTIFICACION RUC

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblIdTipoIdentificacionRUC.ID);
            this.lblIdTipoIdentificacionRUC.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.ddlIdTipoIdentificacionRUC.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoIdentificacionRUC, string.Empty);

            #endregion
            #region IDENTIFICACION RUC

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblIdentificacionRUC.ID);
            this.lblIdentificacionRUC.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtIdentificacionRUC.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtIdentificacionRUC, this.mskIdentificacionRUC);
            //Ajuste javendano 2015-01-09
            this.mskIdentificacionRUC.InputDirection = MaskedEditInputDirection.LeftToRight;
            this.mskIdentificacionRUC.AutoComplete = false;
            txtIdentificacionRUC.ToolTip = "#-####-####";

            #endregion

            #endregion
            #region APARTADO DETALLE

            #region TIPO IDENTIFICACION SICC

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblIdentificacionSICC.ID);
            this.lblIdentificacionSICC.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtIdentificacionSICC.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtIdentificacionSICC);

            #endregion
            #region SALARIO NETO FIADOR

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblSalarioNetoFiador.ID);
            this.lblSalarioNetoFiador.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtSalarioNetoFiador.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtSalarioNetoFiador, this.mskSalarioNetoFiador);

            #endregion

            #endregion
            #region APARTADO ADICIONALES

            #region TIPO MONEDA

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblIdTipoMonedaGradoGravamen.ID);
            this.lblIdTipoMonedaGradoGravamen.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.ddlIdTipoMonedaGradoGravamen.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoMonedaGradoGravamen, string.Empty);

            #endregion
            #region TIPO DOCUMENTO

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblIdTipoDocumentoLegal.ID);
            this.lblIdTipoDocumentoLegal.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.ddlIdTipoDocumentoLegal.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoDocumentoLegal, string.Empty);
            _generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIdTipoDocumentoLegal, controlSeleccionado.ValorDefecto);

            #endregion
            #region TIPO MITIGADOR RIESGO

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblIdTipoMitigadorRiesgo.ID);
            this.lblIdTipoMitigadorRiesgo.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.ddlIdTipoMitigadorRiesgo.ID);
            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlIdTipoMitigadorRiesgo, string.Empty);
            _generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIdTipoMitigadorRiesgo, controlSeleccionado.ValorDefecto);

            #endregion
            #region MONTO GRAVAMEN

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblMontoGradoGravamen.ID);
            this.lblMontoGradoGravamen.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtMontoGradoGravamen.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtMontoGradoGravamen, this.mskMontoGradoGravamen);
            //Ajustes cloaiza 2015-10-20
            this.wmMontoGradoGravamenFiduciarias.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion
            #region MONTO MITIGADOR

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblMontoMitigador.ID);
            this.lblMontoMitigador.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtMontoMitigador.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtMontoMitigador, this.mskMontoMitigador);
            //Ajustes javendano 2015-01-12
            //this.wmMontoMitigador.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion
            #region FECHA CONSTITUCION

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblFechaConstitucionGarantia.ID);
            this.lblFechaConstitucionGarantia.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtFechaConstitucionGarantia.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtFechaConstitucionGarantia, imgFechaConstitucionGarantia);

            #endregion
            #region FECHA VENCIMIENTO

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblFechaVencimientoGarantia.ID);
            this.lblFechaVencimientoGarantia.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtFechaVencimientoGarantia.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtFechaVencimientoGarantia, imgFechaVencimientoGarantia);

            #endregion
            #region FECHA PRESCRIPCION

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblFechaPrescripcionGarantia.ID);
            this.lblFechaPrescripcionGarantia.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtFechaPrescripcionGarantia.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtFechaPrescripcionGarantia, imgFechaPrescripcionGarantia);

            #endregion
            #region PORCENTAJE ACEPTACIÓN BCR

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblPorcentajeAceptBCR.ID);
            this.lblPorcentajeAceptBCR.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtPorcentajeAceptBCR.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtPorcentajeAceptBCR, this.mskPorcentajeAceptBCR);
            //Ajustes javendano 2015-01-12
            this.wmPorcentajeAceptBCR.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion
            #region PORCENTAJE ACEPTACIÓN SUGEF

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblPorcentajeAceptSugef.ID);
            this.lblPorcentajeAceptSugef.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtPorcentajeAceptSugef.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtPorcentajeAceptSugef, this.mskPorcentajeAceptSugef);
            //Ajustes javendano 2015-01-12
            this.wmPorcentajeAceptSugef.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            #endregion
            #region PORCENTAJE RESPONSABILIDAD SUGEF

            controlSeleccionado = BuscarControlesFiduciaria(controles, this.lblPorcentajeResponSugef.ID);
            this.lblPorcentajeResponSugef.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, this.txtPorcentajeResponSugef.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtPorcentajeResponSugef, this.mskPorcentajeResponSugef);
            ////Ajustes javendano 2015-01-12
            //this.wmPorcentajeResponSugef.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            //DESHABILITA EL CAMPO PORCENTAJE RESPONSABILIDAD SUGEF Ajustes cloaiza 2015-10-20
            this.txtPorcentajeResponSugef.Enabled = false;

            #endregion

            #region MONTO MITIGADOR CALCULADO

            controlSeleccionado = BuscarControlesFiduciaria(controles, lblMontoMitigadorCalculado.ID);
            lblMontoMitigadorCalculado.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesFiduciaria(controles, txtMontoMitigadorCalculado.ID);
            CargarTextBoxControl(controlSeleccionado, txtMontoMitigadorCalculado, mskMontoMitigadorCalculado);
            //Ajustes javendano 2015-01-12
            //this.wmMontoMitigadorCalculado.WatermarkText = string.Format("{0:N}", decimal.Parse(controlSeleccionado.ValorDefecto));

            //DESHABILITA EL CAMPO MONTO MITIGADOR CALCULADO 
            this.txtMontoMitigadorCalculado.Enabled = false;

            #endregion
            #endregion

            updFiduciariaPopUpControl.Update();
        }
        catch (Exception ex)
        {
            throw ex;
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

                _entidad.IdTipoIdentificacionRUC = int.Parse(ddlIdTipoIdentificacionRUC.SelectedItem.Value);
                _entidad.IdentificacionRUC = txtIdentificacionRUC.Text;

                #endregion

                _consulta = wsGarantias.OperacionesGarantiasFiduciariasBusqueda(_entidad);
                if (_consulta != null)
                {
                    idGarantiaFiduciariaOculto.Value = _consulta.IdGarantiaFiduciaria.ToString();
                    txtIdentificacionSICC.Text = _consulta.IdentificacionSICC;
                    txtSalarioNetoFiador.Text = _consulta.SalarioNetoFiador.ToString();

                    //DESHABILITAR LA TABLA GENERALES
                    _generadorControles.Bloquear_Controles(tableGeneral, false);
                    //HABILITAR LA TABLA ADICIONALES
                    tableAdicionales.Disabled = false;
                    btnConsultarGarantia.Enabled = false;
                    btnConsultarGarantia.CssClass = "botonConsultarRelacionDisabled";
                }
                else
                {
                    // MENSAJE SESIÓN CADUCADA
                    this.InformarBox1_SetConfirmationBoxEvent(null, e, "GAR_1");
                    this.mpeInformarBox.Show();
                }
                updFiduciariaPopUpControl.Update();
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
            GarantiasWS.RespuestaEntidad result = new GarantiasWS.RespuestaEntidad(); ;

            _entidad.IdOperacion = int.Parse(sesion[3]);
            _entidad.IdGarantiaOperacion = int.Parse(sesion[3]);
            _entidad.IdGarantiaFiduciaria = int.Parse(idGarantiaFiduciariaOculto.Value);
            _entidad.IdTipoGarantia = int.Parse(sesion[4]);

            #region APARTADO DETALLE

            //TIPO IDENTIFICACION RUC
            _entidad.IdTipoIdentificacionRUC = int.Parse(ddlIdTipoIdentificacionRUC.SelectedItem.Value);
            //IDENTIFICACION RUC
            _entidad.IdentificacionRUC = txtIdentificacionRUC.Text;
            //IDENTIFICACION SICC
            _entidad.IdentificacionSICC = txtIdentificacionSICC.Text;
            //SALARIO NETO FIADOR
            if (txtSalarioNetoFiador.Text.Length < 1)
                _entidad.SalarioNetoFiador = null;
            else
                _entidad.SalarioNetoFiador = decimal.Parse(txtSalarioNetoFiador.Text);

            #endregion
            #region APARTADO ADICIONALES

            //TIPO MONEDA GRADO GRAVAMEN
            _entidad.IdTipoMonedaGradoGravamen = int.Parse(ddlIdTipoMonedaGradoGravamen.SelectedItem.Value);
            //TIPO DOCUMENTO LEGAL
            _entidad.IdTipoDocumentoLegal = int.Parse(ddlIdTipoDocumentoLegal.SelectedItem.Value);
            //TIPO MITIGADOR RIESGO
            _entidad.IdTipoMitigadorRiesgo = int.Parse(ddlIdTipoMitigadorRiesgo.SelectedItem.Value);

            //MONTO GRADO GRAVAMEN
            //Ajuste cloaiza 2015-10-20
            if (txtMontoGradoGravamen.Text.Length > 0)
                _entidad.MontoGradoGravamen = decimal.Parse(txtMontoGradoGravamen.Text);
            else
                _entidad.MontoGradoGravamen = decimal.Parse(wmMontoGradoGravamenFiduciarias.WatermarkText);

            //MONTO MITIGADOR
            if (txtMontoMitigador.Text.Length > 0)
                _entidad.MontoMitigador = decimal.Parse(txtMontoMitigador.Text);
            else
                _entidad.MontoMitigador = null;
            //MONTO MITIGADOR CALCULADO
            if (txtMontoMitigadorCalculado.Text.Length > 0)
                _entidad.MontoMitigadorCalculado = decimal.Parse(txtMontoMitigadorCalculado.Text);
            else
                // _entidad.MontoMitigadorCalculado = decimal.Parse(wmMontoMitigadorCalculado.WatermarkText);
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
            if (txtPorcentajeResponSugef.Text.Length > 0)
                _entidad.PorcentajeResponSugef = decimal.Parse(txtPorcentajeResponSugef.Text);
            else
                _entidad.PorcentajeResponSugef = null;
                //_entidad.PorcentajeResponSugef = decimal.Parse(wmPorcentajeResponSugef.WatermarkText);

            //INDICADOR RECOMENDACION PERITO
            _entidad.IdIndicadorRecomendacion = 0;
            //INDICADOR INSPECCION PERITO
            _entidad.IdIndicadorInspeccion = 0;
            //INDICADOR POLIZA
            //_entidad.IdPoliza = 0;
            //INDICADOR HABITA
            _entidad.IdDeudorHabita = 0;

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

    public void DeEntidadAControles(GarantiasOperacionesRelacionEntidad _entidadOperacion, GarantiasFiduciariasEntidad _entidadFiduciarias)
    {
        try
        {
            idGarantiaFiduciariaOculto.Value = _entidadOperacion.IdGarantiaFiduciaria.ToString();

            #region APARTADO DETALLE

            //TIPO IDENTIFICACION RUC
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoIdentificacionRUC, _entidadFiduciarias.IdTipoIdentificacionRUC.ToString());

            //Ajustes javendano 2015-01-08
            ddlIdTipoIdentificacionRUC_SelectedIndexChanged(ddlIdTipoIdentificacionRUC, null);

            //IDENTIFICACION RUC
            txtIdentificacionRUC.Text = _entidadFiduciarias.CodGarantia;
            //IDENTIFICACION SICC
            txtIdentificacionSICC.Text = _entidadFiduciarias.IdentificacionSICC;
            //SALARIO NETO FIADOR
            txtSalarioNetoFiador.Text = _entidadFiduciarias.SalarioNetoFiador.ToString();

            #endregion
            #region APARTADO ADICIONALES

            /*//TIPO DOCUMENTO LEGAL
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoDocumentoLegal, _entidadOperacion.IdTipoDocumentoLegal.ToString());
            //TIPO MITIGADOR RIESGO
            _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlIdTipoMitigadorRiesgo, _entidadOperacion.IdTipoMitigadorRiesgo.ToString());*/

            //Ajustes javendano 2015-01-08
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

    protected void ddlIdTipoIdentificacionRUC_SelectedIndexChanged(object sender, EventArgs e)
    {
        string valorSeleccionado = string.Empty;

        if (mskIdentificacionRUC != null && txtIdentificacionRUC != null)
        {
            txtIdentificacionRUC.Text = string.Empty;

            valorSeleccionado = ddlIdTipoIdentificacionRUC.SelectedItem.Text.Substring(0, 3);

            //ESTABLECE LA MASCARA SEGUN EL TIPO DE IDENTIFICACION
            switch (valorSeleccionado)
            {
                case "1 -":
                    mskIdentificacionRUC.Enabled = true;
                    mskIdentificacionRUC.Mask = "9-9999-9999";
                    mskIdentificacionRUC.Filtered = string.Empty;
                    txtIdentificacionRUC.ToolTip = "#-####-####";
                    //txtIdentificacionRUC.MaxLength = 12;
                    break;
                case "2 -":
                    mskIdentificacionRUC.Enabled = true;
                    mskIdentificacionRUC.Mask = "9-999-999999";
                    mskIdentificacionRUC.Filtered = string.Empty;
                    txtIdentificacionRUC.ToolTip = "#-###-######";
                    //txtIdentificacionRUC.MaxLength = 12;
                    break;
                case "5 -":
                    mskIdentificacionRUC.Enabled = false;
                    txtIdentificacionRUC.MaxLength = 17;
                    //Ajuste javendano 2015-01-09
                    txtIdentificacionRUC.ToolTip = "Texto Id Garantía";
                    break;
                default:
                    txtIdentificacionRUC.MaxLength = 30;
                    mskIdentificacionRUC.Enabled = false;
                    //Ajuste javendano 2015-01-09
                    txtIdentificacionRUC.ToolTip = "Texto Id Garantía";
                    break;
            }
            updFiduciariaPopUpControl.Update();
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

    private ControlEntidad BuscarControlesFiduciaria(List<ControlEntidad> controlEntidad, string nombreControl)
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
        updFiduciariaPopUpControl.Update();
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