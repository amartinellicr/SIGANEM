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

public partial class wucGravamenGarantia : System.Web.UI.UserControl
{
    #region PROPIEDADES

    #region VARIABLES

    private GeneradorControles generadorControles = new GeneradorControles();

    #endregion

    #region REFERENCIAS

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();

    #endregion

    #endregion

    #region FUNCIONES

    /*LIMPIA LOS CONTROLES*/
    public void LimpiarContenido()
    {
        this.txtGravamenGarantiaEntidadAcreedora.Text = string.Empty;
        this.txtGravamenGarantiaSaldoColonizado.Text = string.Empty;
        this.txtGravamenGarantiaSaldoGradoGravamen.Text = string.Empty;
        this.txtGravamenGarantiaTipoCambio.Text = string.Empty;
        this.hdnGravamenGarantiaIdGravamenOculto.Value = string.Empty;
    }

    /*HABILITA Y DESHABILITA LOS CONTROLES SEGUN LA FUNCION (INSERTAR O MODIFICAR)*/
    public void EfectosControles(bool habilitado)
    {
        this.ddlGravamenGarantiaTipoMonedaMontoGravamen.Enabled = habilitado;
        this.txtGravamenGarantiaEntidadAcreedora.Enabled = habilitado;
    }

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
            this.txtGravamenGarantiaTipoCambio.Text = string.Format("{0:N}",tipoCambio[0].Valor.ToString());
    }

    /*GENERA EL SALDO COLONIZADO SALDO GRADO GRAVAMEN X TIPO CAMBIO*/
    private void SaldoColonizadoDolares()
    {
        //SI EXISTEN DATOS EN EL CAMPO SALDO GRADO GRAVAMEN
        if (this.txtGravamenGarantiaSaldoGradoGravamen.Text.Trim().Length > 0)
        {
            //SI EXISTEN DATOS EN TIPO CAMBIO
            if (this.txtGravamenGarantiaTipoCambio.Text.Trim().Length > 0)
            {
                decimal saldoGravamen = decimal.Parse(this.txtGravamenGarantiaSaldoGradoGravamen.Text);
                decimal tipoCambio = decimal.Parse(this.txtGravamenGarantiaTipoCambio.Text);

                this.txtGravamenGarantiaSaldoColonizado.Text = string.Format("{0:N}", saldoGravamen * tipoCambio);
            }
        }
    }

    private void SaldoColonizadoColones()
    { 
        //SI EXISTEN DATOS EN EL CAMPO SALDO GRADO GRAVAMEN
        if (this.txtGravamenGarantiaSaldoGradoGravamen.Text.Trim().Length > 0)
        {
            decimal saldoGravamen = decimal.Parse(this.txtGravamenGarantiaSaldoGradoGravamen.Text);
            this.txtGravamenGarantiaSaldoColonizado.Text = string.Format("{0:N}", saldoGravamen);
        }
    }

    /*CARGA LOS CONTENIDOS EN LOS CONTROLES*/
    public void CargarContenido(List<ControlEntidad> controles)
    {
        try
        {
            ControlEntidad controlSeleccionado = null;

            //LBL GRADO GRAVAMEN
            controlSeleccionado = ControlesBuscar(controles, this.lblGravamenGarantiaGradoGravamen.ID);
            this.lblGravamenGarantiaGradoGravamen.Text = controlSeleccionado.DesColumna;
            //DDL GRADO GRAVAMEN
            controlSeleccionado = ControlesBuscar(controles, this.ddlGravamenGarantiaGradoGravamen.ID);
            this.ddlGravamenGarantiaGradoGravamen.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlGravamenGarantiaGradoGravamen.DataTextField = "Texto";
            this.ddlGravamenGarantiaGradoGravamen.DataValueField = "Valor";
            this.ddlGravamenGarantiaGradoGravamen.DataBind();
            this.ddlGravamenGarantiaGradoGravamen.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlGravamenGarantiaGradoGravamen, controlSeleccionado.ValorDefecto);

            //LBL TIPO MONEDA MONTO GRAVAMEN
            controlSeleccionado = ControlesBuscar(controles, this.lblGravamenGarantiaTipoMonedaMontoGravamen.ID);
            this.lblGravamenGarantiaTipoMonedaMontoGravamen.Text = controlSeleccionado.DesColumna;
            //DDL TIPO MONEDA MONTO GRAVAMEN
            controlSeleccionado = ControlesBuscar(controles, this.ddlGravamenGarantiaTipoMonedaMontoGravamen.ID);
            //SOLO SE DEBE MOSTRAR LAS MONEDAS COLONES Y DOLARES (1,2)
            this.ddlGravamenGarantiaTipoMonedaMontoGravamen.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, "1,2");
            this.ddlGravamenGarantiaTipoMonedaMontoGravamen.DataTextField = "Texto";
            this.ddlGravamenGarantiaTipoMonedaMontoGravamen.DataValueField = "Valor";
            this.ddlGravamenGarantiaTipoMonedaMontoGravamen.DataBind();
            this.ddlGravamenGarantiaTipoMonedaMontoGravamen.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlGravamenGarantiaTipoMonedaMontoGravamen, controlSeleccionado.ValorDefecto);

            //LBL SALDO GRADO GRAVAMEN
            controlSeleccionado = ControlesBuscar(controles, this.lblGravamenGarantiaSaldoGradoGravamen.ID);
            this.lblGravamenGarantiaSaldoGradoGravamen.Text = controlSeleccionado.DesColumna;

            //LBL ENTIDAD ACREEDORA
            controlSeleccionado = ControlesBuscar(controles, this.lblGravamenGarantiaEntidadAcreedora.ID);
            this.lblGravamenGarantiaEntidadAcreedora.Text = controlSeleccionado.DesColumna;

            //LBL TIPO CAMBIO
            controlSeleccionado = ControlesBuscar(controles, this.lblGravamenGarantiaTipoCambio.ID);
            this.lblGravamenGarantiaTipoCambio.Text = controlSeleccionado.DesColumna;

            //LBL SALDO COLONIZADO
            controlSeleccionado = ControlesBuscar(controles, this.lblGravamenGarantiaSaldoColonizado.ID);
            this.lblGravamenGarantiaSaldoColonizado.Text = controlSeleccionado.DesColumna;
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #endregion

    #region OTROS

    protected void ddlGravamenGarantiaTipoMonedaMontoGravamen_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DdlGravamenGarantiaTipoMonedaMontoGravamen();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void txtGravamenGarantiaSaldoGradoGravamen_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!ValidarSaldoGradoGravamen())
                DdlGravamenGarantiaTipoMonedaMontoGravamen();
            else
            { 
                //MENSAJE DE ERROR DE SALDO GRADO GRAVAMEN IGUAL A 0
                this.InformarBoxGravamen1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblGravamenGarantiaSaldoGradoGravamen.Text, "mayor a 0");
                this.mpeInformarBoxGravamen.Show();

                //SE LIMPIA EL CAMPO SALDO GRADO GRAVAMEN Y SALDO COLONIZADO
                this.txtGravamenGarantiaSaldoGradoGravamen.Text = string.Empty;
                this.txtGravamenGarantiaSaldoColonizado.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void txtGravamenGarantiaEntidadAcreedora_TextChanged(object sender, EventArgs e)
    {
        try
        {
            this.txtGravamenGarantiaEntidadAcreedora.Text = StaticParameters.RemoveSpecialCharacters(this.txtGravamenGarantiaEntidadAcreedora.Text);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    /*VALIDA SI EL SALDO ES MAYOR A 0*/
    private bool ValidarSaldoGradoGravamen() 
    {
        //0 = NO HAY ERROR | 1 = HAY ERROR
        bool existError = false;

        if (this.txtGravamenGarantiaSaldoGradoGravamen.Text.Trim().Length > 0)
        {
            decimal saldoGradoGravamen = decimal.Parse(this.txtGravamenGarantiaSaldoGradoGravamen.Text);
            if (saldoGradoGravamen.Equals(0))
                existError = true;
        }
        else
            this.txtGravamenGarantiaSaldoColonizado.Text = string.Empty;

        return existError;
    }

    public void DdlGravamenGarantiaTipoMonedaMontoGravamen()
    {
        if (this.ddlGravamenGarantiaTipoMonedaMontoGravamen.Items.Count > 0)
        {
            if (this.ddlGravamenGarantiaTipoMonedaMontoGravamen.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
            {
                ObtenerTipoCambio();
                SaldoColonizadoDolares();
            }
            else
            {
                txtGravamenGarantiaTipoCambio.Text = string.Empty;
                SaldoColonizadoColones();
            }
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            //MENSAJE INFORMAR
            Button btnAceptarInformar = (Button)this.InformarBoxGravamen1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);
            btnAceptarInformar.CausesValidation = false;
            this.InformarBoxGravamen1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxGravamen1_SetConfirmationBoxEvent);
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
            DdlGravamenGarantiaTipoMonedaMontoGravamen();
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

    private ControlEntidad ControlesBuscar(List<ControlEntidad> controlEntidad, string nombreControl)
    {
        nombreControl = nombreControl.Replace("txt", "").Replace("ddl", "").Replace("imb", "").Replace("lbl", "").Replace("btn", "");
        ControlEntidad _control = (from control in controlEntidad
                                   where control.NombrePropiedad.Equals(nombreControl)
                                   select control).First();

        return _control;
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

    #region MENSAJE INFORMAR

    protected void btnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxGravamen.Hide();
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
            InformarBoxGravamen1.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo1).Replace("@$@", valorReemplazo2));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion
}