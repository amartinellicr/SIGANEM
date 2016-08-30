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
using SeguridadWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class GarantiasFideicomisoPrioridades : System.Web.UI.UserControl
{
    #region PROPIEDADES

    #region VARIABLES

    private GeneradorControles _generadorControles = new GeneradorControles();

    #endregion

    #region REFERENCIAS

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS NO EDITABLES

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            //MENSAJE INFORMAR
            Button btnAceptarInformar = (Button)this.InformarBoxPrioridad1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);
            btnAceptarInformar.CausesValidation = false;

            this.InformarBoxPrioridad1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxGravamen1_SetConfirmationBoxEvent);
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            AsignaWebServicesTypeNames();
            DdlTipoMonedaSaldoPrioridad();
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsListas.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();
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

    /*CARGA LOS CONTENIDOS EN LOS CONTROLES*/
    public void CargarContenido(List<ControlEntidad> controles)
    {
        try
        {
            AsignaWebServicesTypeNames();
            ControlEntidad controlSeleccionado = null;

            #region GRADO PRIORIDAD

            controlSeleccionado = ControlesBuscar(controles, this.lblGradoPrioridad.ID);
            this.lblGradoPrioridad.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = ControlesBuscar(controles, this.ddlGradoPrioridad.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlGradoPrioridad, string.Empty);
            _generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlGradoPrioridad, controlSeleccionado.ValorDefecto);

            #endregion

            #region TIPO MONEDA SALDO PRIORIDAD

            controlSeleccionado = ControlesBuscar(controles, this.lblTipoMonedaSaldoPrioridad.ID);
            this.lblTipoMonedaSaldoPrioridad.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = ControlesBuscar(controles, this.ddlTipoMonedaSaldoPrioridad.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION (SOLO SE DEBE MOSTRAR LAS MONEDAS COLONES Y DOLARES (1, 2))
            CargarDropDownListControl(controlSeleccionado, ddlTipoMonedaSaldoPrioridad, "1, 2");
            _generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoMonedaSaldoPrioridad, controlSeleccionado.ValorDefecto);

            #endregion

            #region SALDO PRIORIDAD

            controlSeleccionado = ControlesBuscar(controles, this.lblSaldoPrioridad.ID);
            this.lblSaldoPrioridad.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = ControlesBuscar(controles, this.txtSaldoPrioridad.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtSaldoPrioridad, this.mskSaldoPrioridad);

            #endregion

            #region TIPO PERSONA BENEFICIARIO

            controlSeleccionado = ControlesBuscar(controles, this.lblTipoPersonaBeneficiario.ID);
            this.lblTipoPersonaBeneficiario.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = ControlesBuscar(controles, this.ddlTipoPersonaBeneficiario.ID);

            //CARGAR EL DROPDOWNLIST CON INFORMACION
            CargarDropDownListControl(controlSeleccionado, ddlTipoPersonaBeneficiario, string.Empty);
            _generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoPersonaBeneficiario, controlSeleccionado.ValorDefecto);
            TipoPersonaBeneficiario();

            #endregion

            #region ID BENEFICIARIO

            controlSeleccionado = ControlesBuscar(controles, this.lblIdBeneficiario.ID);
            this.lblIdBeneficiario.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = ControlesBuscar(controles, this.txtIdBeneficiario.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtIdBeneficiario);

            #endregion

            #region NOMBRE BENEFICIARIO

            controlSeleccionado = ControlesBuscar(controles, this.lblNombreBeneficiario.ID);
            this.lblNombreBeneficiario.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = ControlesBuscar(controles, this.txtNombreBeneficiario.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtNombreBeneficiario);

            #endregion

            #region TIPO CAMBIO

            controlSeleccionado = ControlesBuscar(controles, this.lblTipoCambio.ID);
            this.lblTipoCambio.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = ControlesBuscar(controles, this.txtTipoCambio.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtTipoCambio);

            #endregion

            #region SALDO COLONIZADO

            controlSeleccionado = ControlesBuscar(controles, this.lblSaldoColonizado.ID);
            this.lblSaldoColonizado.Text = controlSeleccionado.DesColumna;

            //ASIGNAR CONTROLES
            controlSeleccionado = ControlesBuscar(controles, this.txtSaldoColonizado.ID);
            CargarTextBoxControl(controlSeleccionado, this.txtSaldoColonizado, this.mskSaldoColonizado);

            #endregion
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    /*HABILITA Y DESHABILITA LOS CONTROLES SEGUN LA FUNCION (INSERTAR O MODIFICAR)*/
    public void EfectosControlesInsertar()
    {
        this.ddlTipoMonedaSaldoPrioridad.Enabled = true;
        this.ddlTipoPersonaBeneficiario.Enabled = true;
        this.txtIdBeneficiario.Enabled = true;
        this.txtNombreBeneficiario.Enabled = true;
        this.txtTipoCambio.Enabled = false;
        this.txtSaldoColonizado.Enabled = false;
    }

    /*HABILITA Y DESHABILITA LOS CONTROLES SEGUN LA FUNCION (INSERTAR O MODIFICAR)*/
    public void EfectosControlesModificar()
    {
        this.ddlGradoPrioridad.Enabled = true;
        this.ddlTipoMonedaSaldoPrioridad.Enabled = false;
        this.txtSaldoPrioridad.Enabled = true;
        this.ddlTipoPersonaBeneficiario.Enabled = false;
        this.txtIdBeneficiario.Enabled = false;
        this.txtNombreBeneficiario.Enabled = false;
        this.txtTipoCambio.Enabled = false;
        this.txtSaldoColonizado.Enabled = false;
    }

    /*LIMPIA LOS CONTROLES*/
    public void LimpiarContenido()
    {
        this.txtSaldoPrioridad.Text = string.Empty;
        this.txtIdBeneficiario.Text = string.Empty;
        this.txtNombreBeneficiario.Text = string.Empty;
        this.txtTipoCambio.Text = string.Empty;
        this.txtSaldoColonizado.Text = string.Empty;
        this.hdnIdPrioridadesOculto.Value = string.Empty;
    }

    #region FUNCIONES TEXTBOX

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
            if (textBox.ID.Contains("Monto") || textBox.ID.Contains("Saldo") || textBox.ID.Contains("Valor"))
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

    #endregion

    #region FUNCIONES DROPDOWNLIST

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

    private void LimpiarDropDownList(DropDownList dropDownList)
    {
        //BORRA LOS VALORES DEL DDL, SE DEBE DE REALIZAR DE ESTA MANERA PARA ELIMINAR LOS DATOS EN CACHÉ DEL OBJ
        dropDownList.ClearSelection();
        dropDownList.Items.Clear();
        dropDownList.SelectedValue = null;
        dropDownList.DataSource = null;
    }

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS EDITABLES

    /*EXTRAE EL TIPO DE CAMBIO MÁS RECIENTE*/
    private void ObtenerTipoCambio()
    {
        SeguridadWS.ParametrosConsultaEntidad consultaEntidad = new SeguridadWS.ParametrosConsultaEntidad();
        consultaEntidad.IndiceInicioFila = 0;
        consultaEntidad.MaximoFilas = 1;
        consultaEntidad.ValorFiltro = String.Empty;
        consultaEntidad.ColumnaFiltro = "Fecha";
        consultaEntidad.ColumnaOrdenar = "Fecha";

        List<TiposCambiosEntidad> tipoCambio = wsSeguridad.TiposCambiosConsultar(consultaEntidad).ToList();

        if (tipoCambio.Count.Equals(1))
            this.txtTipoCambio.Text = string.Format("{0:N}", tipoCambio[0].Valor.ToString());
    }

    /*GENERA EL SALDO COLONIZADO SALDO GRADO GRAVAMEN X TIPO CAMBIO*/
    private void SaldoColonizadoDolares()
    {
        //SI EXISTEN DATOS EN EL CAMPO SALDO PRIORIDAD
        if (this.txtSaldoPrioridad.Text.Trim().Length > 0)
        {
            //SI EXISTEN DATOS EN TIPO CAMBIO
            if (this.txtTipoCambio.Text.Trim().Length > 0)
            {
                decimal saldoPrioridad = decimal.Parse(this.txtSaldoPrioridad.Text);
                decimal tipoCambio = decimal.Parse(this.txtTipoCambio.Text);

                this.txtSaldoColonizado.Text = string.Format("{0:N}", saldoPrioridad * tipoCambio);
            }
        }
    }

    private void SaldoColonizadoColones()
    {
        //SI EXISTEN DATOS EN EL CAMPO SALDO PRIORIDAD
        if (this.txtSaldoPrioridad.Text.Trim().Length > 0)
        {
            decimal saldoPrioridad = decimal.Parse(this.txtSaldoPrioridad.Text);
            this.txtSaldoColonizado.Text = string.Format("{0:N}", saldoPrioridad);
        }
    }

    public void CalculoSaldoPrioridad()
    {
        if (!ValidarSaldoPrioridad())
            DdlTipoMonedaSaldoPrioridad();
        else
        {
            //MENSAJE DE ERROR DE SALDO PRIORIDAD IGUAL A 0
            this.InformarBoxGravamen1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblSaldoPrioridad.Text, "mayor a 0");
            this.mpeInformarBoxPrioridad.Show();

            //SE LIMPIA EL CAMPO SALDO PRIORIDAD Y SALDO COLONIZADO
            this.txtSaldoPrioridad.Text = string.Empty;
            this.txtSaldoColonizado.Text = string.Empty;
        }
    }

    private ControlEntidad ControlesBuscar(List<ControlEntidad> controlEntidad, string nombreControl)
    {
        nombreControl = nombreControl.Replace("txt", "").Replace("ddl", "").Replace("imb", "").Replace("lbl", "").Replace("btn", "");
        ControlEntidad _control = (from control in controlEntidad
                                   where control.NombrePropiedad.Equals(nombreControl)
                                   select control).First();

        return _control;
    }

    #region METODOS TEXT CHANGED

    protected void txtSaldoPrioridad_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if(!String.IsNullOrEmpty(txtSaldoPrioridad.Text))
                CalculoSaldoPrioridad();
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    /*VALIDA SI EL SALDO ES MAYOR A 0*/
    private bool ValidarSaldoPrioridad()
    {
        //0 = NO HAY ERROR | 1 = HAY ERROR
        bool existError = false;

        if (!String.IsNullOrEmpty(this.txtSaldoPrioridad.Text))
        {
            if (this.txtSaldoPrioridad.Text.Trim().Length > 0)
            {
                decimal saldoPrioridad = decimal.Parse(this.txtSaldoPrioridad.Text);
                if (saldoPrioridad.Equals(0))
                    existError = true;
            }

            else
                this.txtSaldoPrioridad.Text = string.Empty;
        }

        else
            this.txtSaldoPrioridad.Text = string.Empty;

        return existError;
    }

    protected void txtNombreBeneficiario_TextChanged(object sender, EventArgs e)
    {
        try
        {
            this.txtNombreBeneficiario.Text = StaticParameters.RemoveSpecialCharacters(this.txtNombreBeneficiario.Text);
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #endregion

    #region METODOS DROPDOWNLIST

    protected void ddlTipoMonedaSaldoPrioridad_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DdlTipoMonedaSaldoPrioridad();
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    public void DdlTipoMonedaSaldoPrioridad()
    {
        if (this.ddlTipoMonedaSaldoPrioridad.Items.Count > 0)
        {
            if (this.ddlTipoMonedaSaldoPrioridad.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
            {
                ObtenerTipoCambio();
                SaldoColonizadoDolares();
            }

            else
            {
                txtTipoCambio.Text = string.Empty;
                SaldoColonizadoColones();
            }
        }
    }

    protected void ddlTipoPersonaBeneficiario_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            TipoPersonaBeneficiario();
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void TipoPersonaBeneficiario()
    {
        this.txtIdBeneficiario.Text = "";
        mskIdBeneficiario.Enabled = false;

        if (this.ddlTipoPersonaBeneficiario.SelectedItem.Text.Substring(0, 3).Equals("5 -"))
        {
            this.txtIdBeneficiario.MaxLength = 17;
            this.txtIdBeneficiario.ToolTip = "#################";
        }

        else
        {
            this.txtIdBeneficiario.MaxLength = 30;
            this.txtIdBeneficiario.ToolTip = "##############################";
        }

        if (this.ddlTipoPersonaBeneficiario.SelectedItem.Text.Substring(0, 3).Equals("1 -"))
        {
            mskIdBeneficiario.Enabled = true;
            mskIdBeneficiario.Mask = "9-9999-9999";
            this.txtIdBeneficiario.ToolTip = "#-####-####";
            this.txtIdBeneficiario.MaxLength = 30;
        }

        if (this.ddlTipoPersonaBeneficiario.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
        {
            mskIdBeneficiario.Enabled = true;
            mskIdBeneficiario.Mask = "9-999-999999";
            this.txtIdBeneficiario.ToolTip = "#-###-######";
            this.txtIdBeneficiario.MaxLength = 30;
        }
    }

    #endregion

    #region MENSAJE INFORMAR

    protected void btnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxPrioridad.Hide();
    }

    /*OBTIENE EL MENSAJE DESDE BD*/
    private MensajesEntidad Mensaje(string msgType)
    {
        try
        {
            MensajesEntidad mensajesEntidad = new MensajesEntidad();
            mensajesEntidad.CodMensaje = msgType.ToString();
            MensajesEntidad msj = wsSeguridad.MensajesConsulta(mensajesEntidad);
            return msj;
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void InformarBoxGravamen1_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    { 
    }

    protected void InformarBoxGravamen1_SetConfirmationBoxEvent(object sender, EventArgs e, string type, string valorReemplazo1, string valorReemplazo2)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBoxPrioridad1.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo1).Replace("@$@", valorReemplazo2));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

}