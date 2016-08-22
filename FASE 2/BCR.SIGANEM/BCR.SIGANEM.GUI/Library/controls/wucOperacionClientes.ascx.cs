using System;
using System.Web;
using System.Text;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Reflection;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using ListasWS;
using GarantiasWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;


public partial class wucOperacionClientes : System.Web.UI.UserControl
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

    public void LimpiarControlesOperacionClientes()
    {
        this.txtIdentificacionSICC.Text = string.Empty;
        this.txtNombreClienteSICC.Text = string.Empty;
        this.txtFechaConstitucionSICC.Text = string.Empty;
        this.txtFechaVencimientoSICC.Text = string.Empty;
        this.txtOficinaDeudorSICC.Text = string.Empty;
        this.txtIdentificacionRUC.Text = string.Empty;
        this.txtEstadoOperacion.Text = string.Empty;
        this.txtSaldo.Text = string.Empty;
        this.txtSaldoColonizado.Text = string.Empty;
        this.txtSaldoOriginal.Text = string.Empty;
        this.txtSaldoOriginalColonizado.Text = string.Empty;
        this.txtCategoriaRiesgoDeudor.Text = string.Empty;
        _generadorControles.SeleccionarOpcionDropDownList(ddlTipoIdentificacionRUC, "-1");
        _generadorControles.SeleccionarOpcionDropDownList(ddlTipoIdentificacionSICC, "-1");
        _generadorControles.SeleccionarOpcionDropDownList(ddlIndDesembolso, "-1");
    }

    public void LimpiarControlesDropDownListClientes(bool agregar)
    {
        AdministrarBlanco(ddlTipoIdentificacionRUC, agregar);
        AdministrarBlanco(ddlTipoIdentificacionSICC, agregar);
        AdministrarBlanco(ddlIndDesembolso, agregar);
    }

    public void CargarControlesOperacionClientes(List<ControlEntidad> controles)
    {
        try
        {
            AsignaWebServicesTypeNames();
            ControlEntidad controlSeleccionado = null;

            #region CONTROLES TIPO IDENTIFICACION SICC
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblTipoIdentificacionSICC.ID);
            this.lblTipoIdentificacionSICC.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.ddlTipoIdentificacionSICC.ID);
            //LIMPIAR EL CONTROL DROPDOWNLIST
            LimpiarDropDownList(this.ddlTipoIdentificacionSICC);
            //CARGAR EL DROPDOWNLIS
            this.ddlTipoIdentificacionSICC.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoIdentificacionSICC.DataValueField = "Valor";
            this.ddlTipoIdentificacionSICC.DataTextField = "Texto";
            this.ddlTipoIdentificacionSICC.DataBind();
            this.ddlTipoIdentificacionSICC.CssClass = controlSeleccionado.CssTipo;

            #endregion

            #region CONTROLES IDENTIFICACION SICC

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblIdentificacionSICC.ID);
            this.lblIdentificacionSICC.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.txtIdentificacionSICC.ID);
            CargarTextBoxOperacion(controlSeleccionado, this.txtIdentificacionSICC);

            #endregion

            #region CONTROLES NOMBRE CLIENTE

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblNombreClienteSICC.ID);
            this.lblNombreClienteSICC.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.txtNombreClienteSICC.ID);
            CargarTextBoxOperacion(controlSeleccionado, this.txtNombreClienteSICC);

            #endregion

            #region CONTROLES ESTADO OPERACION

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblEstadoOperacion.ID);
            this.lblEstadoOperacion.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.txtEstadoOperacion.ID);
            CargarTextBoxOperacion(controlSeleccionado, this.txtEstadoOperacion);

            #endregion

            #region CONTROLES FECHA CONSTITUCION

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblFechaConstitucionSICC.ID);
            this.lblFechaConstitucionSICC.Text = controlSeleccionado.DesColumna;
            ////ASIGNAR CONTROLES
            //controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblFechaConstitucionSICC.ID);
            //CargarTextBoxOperacion(controlSeleccionado, this.lblFechaConstitucionSICC);

            #endregion

            #region CONTROLES FECHA VENCIMIENTO

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblFechaVencimientoSICC.ID);
            this.lblFechaVencimientoSICC.Text = controlSeleccionado.DesColumna;
            ////ASIGNAR CONTROLES
            //controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblFechaVencimientoSICC.ID);
            //CargarTextBoxOperacion(controlSeleccionado, this.lblFechaVencimientoSICC);

            #endregion

            #region CONTROLES OFICINA DEUDOR

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblOficinaDeudorSICC.ID);
            this.lblOficinaDeudorSICC.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.txtOficinaDeudorSICC.ID);
            CargarTextBoxOperacion(controlSeleccionado, this.txtOficinaDeudorSICC);

            #endregion

            #region CONTROLES TIPO IDENTIFICACION RUC

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblTipoIdentificacionRUC.ID);
            this.lblTipoIdentificacionRUC.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.ddlTipoIdentificacionRUC.ID);

            LimpiarDropDownList(this.ddlTipoIdentificacionRUC);
            //CARGAR EL DROPDOWNLIS
            this.ddlTipoIdentificacionRUC.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoIdentificacionRUC.DataTextField = "Texto";
            this.ddlTipoIdentificacionRUC.DataValueField = "Valor";
            this.ddlTipoIdentificacionRUC.DataBind();
            this.ddlTipoIdentificacionRUC.CssClass = controlSeleccionado.CssTipo;

            #endregion

            #region CONTROLES IDENTIFICACION RUC

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblIdentificacionRUC.ID);
            this.lblIdentificacionRUC.Text = controlSeleccionado.DesColumna;
            //ASIGNAR CONTROLES
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.txtIdentificacionRUC.ID);
            CargarTextBoxOperacion(controlSeleccionado, this.txtIdentificacionRUC);

            #endregion

            #region CONTROLES CAT RIESGO DEUDOR

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblCategoriaRiesgoDeudor.ID);
            this.lblCategoriaRiesgoDeudor.Text = controlSeleccionado.DesColumna;

            #endregion

            #region CONTROLES DESEMBOLSOS

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblIndDesembolso.ID);
            this.lblIndDesembolso.Text = controlSeleccionado.DesColumna;
            //LIMPIAR EL CONTROL DROPDOWNLIST
            LimpiarDropDownList(this.ddlIndDesembolso);
            //CARGAR EL DROPDOWNLIS
            this.ddlIndDesembolso.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlIndDesembolso.DataValueField = "Valor";
            this.ddlIndDesembolso.DataTextField = "Texto";
            this.ddlIndDesembolso.DataBind();
            _generadorControles.SeleccionarOpcionDropDownListTexto(ddlIndDesembolso, controlSeleccionado.ValorDefecto);

            #endregion

            #region CONTROLES SALDO

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblSaldo.ID);
            this.lblSaldo.Text = controlSeleccionado.DesColumna;

            #endregion

            #region CONTROLES SALDO COLONIZADO

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblSaldoColonizado.ID);
            this.lblSaldoColonizado.Text = controlSeleccionado.DesColumna;

            #endregion

            #region CONTROLES SALDO ORIGINAL

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblSaldoOriginal.ID);
            this.lblSaldoOriginal.Text = controlSeleccionado.DesColumna;

            #endregion

            #region CONTROLES SALDO ORIGINAL COLONIZADO

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblSaldoOriginalColonizado.ID);
            this.lblSaldoOriginalColonizado.Text = controlSeleccionado.DesColumna;

            #endregion
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    public void HabilitarDesembolso(List<ControlEntidad> controles)
    {
        AsignaWebServicesTypeNames();
        AdministrarBlanco(ddlIndDesembolso, false);
        ControlEntidad controlSeleccionado = null;
        controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblIndDesembolso.ID);
        _generadorControles.SeleccionarOpcionDropDownListTexto(ddlIndDesembolso, controlSeleccionado.ValorDefecto);
        ddlIndDesembolso.Enabled = true;
    }

    public void HabilitarContenido(bool estado)
    {
        if (estado)
        {
            btnValidarOperacion.CssClass = "botonValidarOperacion";
        }
        else
        {
            btnValidarOperacion.CssClass = "botonValidarOperacionDisabled";
        }

        btnValidarOperacion.Enabled = estado;

        _generadorControles.Bloquear_Controles(tableSICC, estado);
        _generadorControles.Bloquear_Controles(tableRUC, estado);

        txtFechaConstitucionSICC.Enabled = false;
        imgFechaConstitucionSICC.Enabled = false;
        caeFechaConstitucionSICC.Enabled = false;

        txtFechaVencimientoSICC.Enabled = false;
        imgFechaVencimientoSICC.Enabled = false;
        caeFechaVencimientoSICC.Enabled = false;
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

    private void CargarTextBoxOperacion(ControlEntidad _control, TextBox _textBox)
    {
        #region TEXTBOX

        _textBox.Text = _control.ValorDefecto;
        _textBox.ToolTip = String.Concat("Texto ", _control.DesColumna);
        _textBox.Enabled = bool.Parse(_control.IndModificar);
        _textBox.Visible = bool.Parse(_control.IndVisible);
        _textBox.CausesValidation = false;

        if (int.Parse(_control.LongitudMaxima) < 51)
        {
            switch (_textBox.ID)
            {
                case "txtIdentificacionSICC":
                case "txtIdentificacionRUC":
                case "txtEstadoOperacion":
                    _textBox.Width = Unit.Parse("200px");
                    break;
                default:
                    _textBox.Width = Unit.Parse((int.Parse(_control.LongitudMaxima) * 9).ToString() + "px");
                    _textBox.CssClass = _control.CssTipo;
                    break;
            }
        }

        if (!String.IsNullOrEmpty(_control.GrupoValidacion))
        {
            _textBox.ValidationGroup = _control.GrupoValidacion;
        }

        #endregion
    }

    //AGREGA O ELIMINA UN ITEM EN BLANCO
    private void AdministrarBlanco(DropDownList _dropDownList, bool agregar)
    {
        try
        {
            bool existeBlanco = false;
            int posicion = 0;
            DropDownList ddl = _dropDownList;

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

    #endregion

}