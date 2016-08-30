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

using BCR.SIGANEM.UT;


public partial class wucCedulasHipotecarias : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region VARIABLES

    private GeneradorControles generadorControles = new GeneradorControles();

    #endregion

    #region REFERENCIAS

    private SiganemListasWS wsListas = new SiganemListasWS();

    #endregion

    #endregion

    #region FUNCIONES

    public bool ValidarSerie()
    {
        bool existeError = false;
        Regex regexSerie = null;

        switch (this.txtCedulasHipotecariasSerie.Text.Length)
        { 
            case 3:
                //FORMATO X-X
                regexSerie = new Regex(@"^(\d){1}[-]{1}(\d){1}$");
                if (!regexSerie.IsMatch(this.txtCedulasHipotecariasSerie.Text))
                    existeError = true;
                break;
            case 4:
                //FORMATO X-XX | XX-X
                regexSerie = new Regex(@"^((\d){1}[-]{1}(\d){2})|((\d){2}[-]{1}(\d){1})$");
                if (!regexSerie.IsMatch(this.txtCedulasHipotecariasSerie.Text))
                    existeError = true;
                
                break;
            case 5:
                //FORMATO X-XXX | XX-XX
                regexSerie = new Regex(@"^((\d){1}[-]{1}(\d){3})|((\d){2}[-]{1}(\d){2})$");
                if (!regexSerie.IsMatch(this.txtCedulasHipotecariasSerie.Text))
                    existeError = true;

                break;
            case 6:
                //FORMATO XX-XXX
                regexSerie = new Regex(@"^(\d){2}[-]{1}(\d){3}$");
                if (!regexSerie.IsMatch(this.txtCedulasHipotecariasSerie.Text))
                    existeError = true;
                break;
            default:
                existeError = true;
                break;
        }

        return existeError;
    }

    public void LimpiarContenido()
    {
        this.txtCedulasHipotecariasCedula.Text = string.Empty;
        this.txtCedulasHipotecariasFechaPrescripcion.Text = string.Empty;
        this.txtCedulasHipotecariasFechaVencimiento.Text = string.Empty;
        this.txtCedulasHipotecariasSerie.Text = string.Empty;
        this.txtCedulasHipotecariasValorFacial.Text = string.Empty;
    }

    public void CargarContenido(List<ControlEntidad> controles)
    {
        try
        {
            AsignaWebServicesTypeNames();
            ControlEntidad controlSeleccionado = null;

            //LBL SERIE
            controlSeleccionado = ControlesBuscar(controles, this.lblCedulasHipotecariasSerie.ID);
            this.lblCedulasHipotecariasSerie.Text = controlSeleccionado.DesColumna;

            //LBL NUMERO CEDULA
            controlSeleccionado = ControlesBuscar(controles, this.lblCedulasHipotecariasCedula.ID);
            this.lblCedulasHipotecariasCedula.Text = controlSeleccionado.DesColumna;

            //DLL GRADO GRAVAMEN
            controlSeleccionado = ControlesBuscar(controles, this.ddlCedulasHipotecariasGradoGravamen.ID);
            this.ddlCedulasHipotecariasGradoGravamen.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlCedulasHipotecariasGradoGravamen.DataTextField = "Texto";
            this.ddlCedulasHipotecariasGradoGravamen.DataValueField = "Valor";
            this.ddlCedulasHipotecariasGradoGravamen.DataBind();
            this.ddlCedulasHipotecariasGradoGravamen.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlCedulasHipotecariasGradoGravamen, controlSeleccionado.ValorDefecto);
            //LBL GRADO GRAVAMEN
            this.lblCedulasHipotecariasGradoGravamen.Text = controlSeleccionado.DesColumna;

            //DLL MONEDA
            controlSeleccionado = ControlesBuscar(controles, this.ddlCedulasHipotecariasMoneda.ID);
            this.ddlCedulasHipotecariasMoneda.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlCedulasHipotecariasMoneda.DataTextField = "Texto";
            this.ddlCedulasHipotecariasMoneda.DataValueField = "Valor";
            this.ddlCedulasHipotecariasMoneda.DataBind();
            this.ddlCedulasHipotecariasMoneda.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlCedulasHipotecariasMoneda, controlSeleccionado.ValorDefecto);
            //LBL MONEDA
            this.lblCedulasHipotecariasMoneda.Text = controlSeleccionado.DesColumna;

            //LBL FECHA VENCIMIENTO
            controlSeleccionado = ControlesBuscar(controles, this.lblCedulasHipotecariasFechaVencimiento.ID);
            this.lblCedulasHipotecariasFechaVencimiento.Text = controlSeleccionado.DesColumna;
            this.calendarExtenderCedulasHipotecariasFechaVencimiento.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();
            this.txtCedulasHipotecariasFechaVencimiento.Attributes.Add("readonly", "readonly");

            //LBL FECHA PRESCRIPCION CEDULA
            controlSeleccionado = ControlesBuscar(controles, this.lblCedulasHipotecariasFechaPrescripcion.ID);
            this.lblCedulasHipotecariasFechaPrescripcion.Text = controlSeleccionado.DesColumna;

            //DLL MONEDA
            controlSeleccionado = ControlesBuscar(controles, this.ddlCedulasHipotecariasMoneda.ID);
            this.ddlCedulasHipotecariasMoneda.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlCedulasHipotecariasMoneda.DataTextField = "Texto";
            this.ddlCedulasHipotecariasMoneda.DataValueField = "Valor";
            this.ddlCedulasHipotecariasMoneda.DataBind();
            this.ddlCedulasHipotecariasMoneda.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlCedulasHipotecariasMoneda, controlSeleccionado.ValorDefecto);
            //LBL MONEDA
            this.lblCedulasHipotecariasMoneda.Text = controlSeleccionado.DesColumna;

            //LBL VALOR FACIAL 
            controlSeleccionado = ControlesBuscar(controles, this.lblCedulasHipotecariasValorFacial.ID);
            this.lblCedulasHipotecariasValorFacial.Text = controlSeleccionado.DesColumna;
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #endregion

    #region OTROS

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsListas.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();

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

    #endregion

}