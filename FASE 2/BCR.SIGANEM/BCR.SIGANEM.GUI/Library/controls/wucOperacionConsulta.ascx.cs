using System;
using System.Web;
using System.Text;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Reflection;
using System.Web.Services;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using ListasWS;
using GarantiasWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;


public partial class wucOperacionConsulta : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region VARIABLES

    private GeneradorControles _generadorControles = new GeneradorControles();

    #endregion

    #region REFERENCIAS

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemGarantiasWS wsGarantias = new SiganemGarantiasWS();

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS EDITABLES

    public void LimpiarControlesOperacionConsulta()
    {
        this.txtConta.Text = string.Empty;
        this.txtOficina.Text = string.Empty;
        this.txtMoneda.Text = string.Empty;
        this.txtProducto.Text = string.Empty;
        this.txtNumero.Text = string.Empty;
        _generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoOperacion, "1");
    }

    public void CargarControlesOperacionConsulta(List<ControlEntidad> controles)
    {
        try
        {
            AsignaWebServicesTypeNames();
            ControlEntidad controlSeleccionado = null;

            #region CONTROLES OPERACION
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblTipoOperacion.ID);
            this.lblTipoOperacion.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.ddlTipoOperacion.ID);
            //LIMPIAR EL CONTROL DROPDOWNLIST
            LimpiarDropDownList(this.ddlTipoOperacion);
            //CARGAR EL DROPDOWNLIS
            this.ddlTipoOperacion.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoOperacion.DataValueField = "Valor";
            this.ddlTipoOperacion.DataTextField = "Texto";
            this.ddlTipoOperacion.DataBind();
            this.ddlTipoOperacion.CssClass = controlSeleccionado.CssTipo;
            _generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoOperacion, controlSeleccionado.ValorDefecto);
            #endregion

            #region CONTROLES CONTA

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblConta.ID);
            this.lblConta.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.txtConta.ID);
            CargarTextBoxConsultaOperacion(controlSeleccionado, this.txtConta, this.mskConta);

            #endregion

            #region CONTROLES OFICINA

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblOficina.ID);
            this.lblOficina.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.txtOficina.ID);
            CargarTextBoxConsultaOperacion(controlSeleccionado, this.txtOficina, this.mskOficina);

            #endregion

            #region CONTROLES MONEDA

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblMoneda.ID);
            this.lblMoneda.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.txtMoneda.ID);
            CargarTextBoxConsultaOperacion(controlSeleccionado, this.txtMoneda, this.mskMoneda);

            #endregion

            #region CONTROLES PRODUCTO

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblProducto.ID);
            this.lblProducto.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.txtProducto.ID);
            CargarTextBoxConsultaOperacion(controlSeleccionado, this.txtProducto, this.mskProducto);

            #endregion

            #region CONTROLES NUMERO

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblNumero.ID);
            this.lblNumero.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.txtNumero.ID);
            CargarTextBoxConsultaOperacion(controlSeleccionado, this.txtNumero, this.mskNumero);

            #endregion
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    public void CargarCerosOperacionConsulta()
    {
        //Ajustes javendano 2015-01-12
        mskConta.AutoComplete = false;
        mskMoneda.AutoComplete = false;
        mskNumero.AutoComplete = false;
        mskOficina.AutoComplete = false;
        mskProducto.AutoComplete = false;

        txtConta.Attributes.Add("onblur", "CompletarCerosIzquierda('" + txtConta.ClientID + "','" + txtConta.MaxLength + "')");
        txtOficina.Attributes.Add("onblur", "CompletarCerosIzquierda('" + txtOficina.ClientID + "','" + txtOficina.MaxLength + "')");
        txtMoneda.Attributes.Add("onblur", "CompletarCerosIzquierda('" + txtMoneda.ClientID + "','" + txtMoneda.MaxLength + "')");
        txtProducto.Attributes.Add("onblur", "CompletarCerosIzquierda('" + txtProducto.ClientID + "','" + txtProducto.MaxLength + "')");
        txtNumero.Attributes.Add("onblur", "CompletarCerosIzquierda('" + txtNumero.ClientID + "','" + txtNumero.MaxLength + "')");
    }

    public void HabilitarContenido(bool estado)
    {
        if (estado)
        {
            btnConsultarOperacion.CssClass = "botonConsultarSICC";
        }
        else
        {
            btnConsultarOperacion.CssClass = "botonConsultarSICCDisabled";
        }

        btnConsultarOperacion.Enabled = estado;
        _generadorControles.Bloquear_Controles(tblParametros, estado);
    }

    #endregion

    #region METODOS PERSONALIZADOS NO EDITABLES

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsListas.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();
            wsGarantias.Url = ConfigurationManager.AppSettings["GarantiasWS"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(ConfigurationManager.AppSettings["Culture"].ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ConfigurationManager.AppSettings["Culture"].ToString());
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    private ControlEntidad BuscarControlesConsultaOperacion(List<ControlEntidad> controlEntidad, string nombreControl)
    {
        nombreControl = nombreControl.Replace("txt", "").Replace("ddl", "").Replace("lbl", "").Replace("msk", "").Replace("rfv", "");
        ControlEntidad _control = (from control in controlEntidad
                                   where control.NombrePropiedad.Equals(nombreControl)
                                   select control).First();

        return _control;
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
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);

            return null;
        }
    }

    private void CargarTextBoxConsultaOperacion(ControlEntidad _control, TextBox _textBox, MaskedEditExtender _maskedEditExtender)
    {
        #region TEXTBOX
        _textBox.Text = _control.ValorDefecto;
        _textBox.ToolTip = String.Concat("Texto ", _control.DesColumna);
        _textBox.Enabled = bool.Parse(_control.IndModificar);
        _textBox.Visible = bool.Parse(_control.IndVisible);
        _textBox.CssClass = _control.CssTipo;

        #endregion
        #region MASKEDEDIT EXTENDER

        int m = Int32.Parse(_control.Mascara);
        if (m > 0)
        {
            _textBox.MaxLength = Int32.Parse(_control.LongitudMaxima);
            _maskedEditExtender.ClearTextOnInvalid = true;
            _maskedEditExtender.ClearMaskOnLostFocus = false;
            _maskedEditExtender.MaskType = _generadorControles.DeterminaTipoMascara(m);
            _maskedEditExtender.InputDirection = MaskedEditInputDirection.RightToLeft;

            string mascara = _generadorControles.DeterminaFormatoMascara(Int32.Parse(_control.LongitudMaxima), _control.ValorMascara);
            _maskedEditExtender.Mask = mascara;
        }

        #endregion
    }

    #endregion

}
