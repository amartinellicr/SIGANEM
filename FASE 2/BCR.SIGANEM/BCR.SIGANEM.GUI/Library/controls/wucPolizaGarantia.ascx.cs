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
using GarantiasWS;

using BCR.SIGANEM.UT;

public partial class wucPolizaGarantia : System.Web.UI.UserControl
{
    #region PROPIEDADES

    #region VARIABLES

    private GeneradorControles generadorControles = new GeneradorControles();

    #endregion

    #region REFERENCIAS

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();
    private SiganemGarantiasWS wsGarantias = new SiganemGarantiasWS();

    #endregion

    #endregion

    #region FUNCIONES

    /*LIMPIA LOS CONTROLES*/
    public void LimpiarContenido()
    {
        this.txtPolizaMontoPoliza.Text = string.Empty;
        this.txtPolizaMontoPolizaColonizado.Text = string.Empty;
        this.txtPolizaNumPoliza.Text = string.Empty;
        this.txtPolizaNumSap.Text = string.Empty;      
        this.txtPolizaFechaEmision.Text = string.Empty;
        this.txtPolizaFechaVencimiento.Text = string.Empty;

        this.txtPolizaIdentificacion.Text = string.Empty;
        this.hdnPolizaIdPolizaOculto.Value = string.Empty;

        LimpiarDatosCliente();
    }

    public bool ValidarPolizaIdentificacion()
    {
        bool exiteError = false;

        rfvPolizaIdentificacion.Validate();

        if (!rfvPolizaIdentificacion.IsValid)
            exiteError = true;

        return exiteError;
    }

    private void LimpiarDatosCliente()
    {
        this.txtPolizaNombre.Text = string.Empty;
        this.txtPolizaPrimerApellido.Text = string.Empty;
        this.txtPolizaSegundoApellido.Text = string.Empty;
        this.txtPolizaTelHabitacion.Text = string.Empty;
        this.txtPolizaTelMovil.Text = string.Empty;
        this.txtPolizaTelTrabajo.Text = string.Empty;
        this.txtPolizaCanton.Text = string.Empty;
        this.txtPolizaProvincia.Text = string.Empty;
        this.txtPolizaDireccion.Text = string.Empty;
        this.txtPolizaDistrito.Text = string.Empty;
        this.txtPolizaRazonSocial.Text = string.Empty;
    }

    /*HABILITA Y DESHABILITA LOS CONTROLES SEGUN LA FUNCION (INSERTAR O MODIFICAR)*/
    public void EfectosControles(bool habilitado)
    {
        this.ddlPolizaTipoPoliza.Enabled = habilitado;
        this.txtPolizaNumSap.Enabled = habilitado;
        this.txtPolizaNumPoliza.Enabled = habilitado;
        this.ddlPolizaTipoMoneda.Enabled = habilitado;
        this.ddlPolizaTipoIdentificacion.Enabled = habilitado;
        this.txtPolizaIdentificacion.Enabled = habilitado;
    }

    /*HABILITA Y DESHABILITA LOS CONTROLES SEGUN LA FUNCION (INSERTAR O MODIFICAR) EXCEPCIONES*/
    public void EfectosControlesExcepciones(bool habilitado)
    {
        this.btnPolizaIdentificacionBuscar.Enabled = habilitado;
        this.txtPolizaNumSap.Enabled = habilitado;
        if (this.hdnPolizaIdPolizaOculto.Value.Length > 0)
            this.btnPolizaLimpiar.Enabled = false;
        else
            this.btnPolizaLimpiar.Enabled = true;
    }

    /*EXTRAE EL TIPO DE CAMBIO MÁS RECIENTE*/
    private decimal ObtenerTipoCambio()
    {
        SeguridadWS.ParametrosConsultaEntidad consultaEntidad = new SeguridadWS.ParametrosConsultaEntidad();
        consultaEntidad.IndiceInicioFila = 0;
        consultaEntidad.MaximoFilas = 1;
        consultaEntidad.ValorFiltro = String.Empty;
        consultaEntidad.ColumnaFiltro = "Fecha";
        consultaEntidad.ColumnaOrdenar = "Fecha";

        List<TiposCambiosEntidad> tipoCambio = wsSeguridad.TiposCambiosConsultar(consultaEntidad).ToList();

        if (tipoCambio.Count.Equals(1))
            return tipoCambio[0].Valor;
        else
            return -1;
    }

    /*GENERA EL MONTO POLIZA COLONIZADO X TIPO CAMBIO*/
    private void SaldoColonizadoDolares()
    {
        //SI EXISTEN DATOS EN EL CAMPO MONTO POLIZA
        if (this.txtPolizaMontoPoliza.Text.Trim().Length > 0)
        {
            //SI EXISTEN DATOS EN TIPO CAMBIO
            decimal tipoCambio = ObtenerTipoCambio();
            if (tipoCambio > 0)
            {
                decimal montoPoliza = decimal.Parse(this.txtPolizaMontoPoliza.Text);

                this.txtPolizaMontoPolizaColonizado.Text = string.Format("{0:N}", montoPoliza * tipoCambio);
            }
        }
    }

    private void SaldoColonizadoColones()
    {
        //SI EXISTEN DATOS EN EL CAMPO MONTO POLIZA
        if (this.txtPolizaMontoPoliza.Text.Trim().Length > 0)
        {
            decimal montoPolizaColonizado = decimal.Parse(this.txtPolizaMontoPoliza.Text);
            this.txtPolizaMontoPolizaColonizado.Text = string.Format("{0:N}", montoPolizaColonizado);
        }
    }

    /*VALIDACION DE FECHA VENCIMIENTO Y FECHA EMISIÓN*/
    private bool ValidacionFechas()
    {
        bool error = false;

        if (txtPolizaFechaVencimiento.Text.Length > 0)
        {
            if (txtPolizaFechaEmision.Text.Length > 0)
            {
                //FECHA VENCIMIENTO DEBE SER MAYOR A FECHA EMISION
                if (generadorControles.ObtenerComparacion(this.txtPolizaFechaVencimiento.Text, this.txtPolizaFechaEmision.Text, EnumTipoComparacion.MENORIGUAL, TypeCode.DateTime))
                {
                    this.txtPolizaFechaVencimiento.Text = string.Empty;

                    this.InformarBoxPoliza1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblPolizaFechaVencimiento.Text, "mayor al campo " + this.lblPolizaFechaEmision.Text);
                    this.mpeInformarBoxPoliza.Show();
                    error = true;
                }
            }
        }

        return error;
    }

    /*CARGA LOS CONTENIDOS EN LOS CONTROLES*/
    public void CargarContenido(List<ControlEntidad> controles)
    {
        try
        {
            ControlEntidad controlSeleccionado = null;

            //LBL N SAP
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaNumSap.ID);
            this.lblPolizaNumSap.Text = controlSeleccionado.DesColumna;

            //LBL TIPO POLIZA
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaTipoPoliza.ID);
            this.lblPolizaTipoPoliza.Text = controlSeleccionado.DesColumna;
            //DDL TIPO POLIZA
            controlSeleccionado = ControlesBuscar(controles, this.ddlPolizaTipoPoliza.ID);
            this.ddlPolizaTipoPoliza.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlPolizaTipoPoliza.DataTextField = "Texto";
            this.ddlPolizaTipoPoliza.DataValueField = "Valor";
            this.ddlPolizaTipoPoliza.DataBind();
            this.ddlPolizaTipoPoliza.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlPolizaTipoPoliza, controlSeleccionado.ValorDefecto);
            
            //LBL N POLZA
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaNumPoliza.ID);
            this.lblPolizaNumPoliza.Text = controlSeleccionado.DesColumna;

            //LBL FECHA EMISION
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaFechaEmision.ID);
            this.lblPolizaFechaEmision.Text = controlSeleccionado.DesColumna;
            this.calendarExtenderPolizaFechaEmision.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();
            this.txtPolizaFechaEmision.Attributes.Add("readonly", "readonly");

            //LBL FECHA VENCIMIENTO
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaFechaVencimiento.ID);
            this.lblPolizaFechaVencimiento.Text = controlSeleccionado.DesColumna;
            this.calendarExtenderPolizaFechaVencimiento.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();
            this.txtPolizaFechaVencimiento.Attributes.Add("readonly", "readonly");

            //LBL TIPO MONEDA
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaTipoMoneda.ID);
            this.lblPolizaTipoMoneda.Text = controlSeleccionado.DesColumna;
            //DDL TIPO MONEDA
            controlSeleccionado = ControlesBuscar(controles, this.ddlPolizaTipoMoneda.ID);
            this.ddlPolizaTipoMoneda.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, "1,2");
            this.ddlPolizaTipoMoneda.DataTextField = "Texto";
            this.ddlPolizaTipoMoneda.DataValueField = "Valor";
            this.ddlPolizaTipoMoneda.DataBind();
            this.ddlPolizaTipoMoneda.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlPolizaTipoMoneda, controlSeleccionado.ValorDefecto);

            //LBL MONTO POLIZA
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaMontoPoliza.ID);
            this.lblPolizaMontoPoliza.Text = controlSeleccionado.DesColumna;

            //LBL MONTO POLIZA COLONIZADO
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaMontoPolizaColonizado.ID);
            this.lblPolizaMontoPolizaColonizado.Text = controlSeleccionado.DesColumna;

            //LBL COBERTURAS
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaCobertura.ID);
            this.lblPolizaCobertura.Text = controlSeleccionado.DesColumna;
            //DDL COBERTURAS
            this.ddlPolizaCobertura.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlPolizaCobertura.DataTextField = "Texto";
            this.ddlPolizaCobertura.DataValueField = "Valor";
            this.ddlPolizaCobertura.DataBind();
            this.ddlPolizaCobertura.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlPolizaCobertura, controlSeleccionado.ValorDefecto);

            //LBL TIPO IDENTIFICACION
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaTipoIdentificacion.ID);
            this.lblPolizaTipoIdentificacion.Text = controlSeleccionado.DesColumna;
            //DDL GRADO GRAVAMEN
            controlSeleccionado = ControlesBuscar(controles, this.ddlPolizaTipoIdentificacion.ID);
            this.ddlPolizaTipoIdentificacion.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlPolizaTipoIdentificacion.DataTextField = "Texto";
            this.ddlPolizaTipoIdentificacion.DataValueField = "Valor";
            this.ddlPolizaTipoIdentificacion.DataBind();
            this.ddlPolizaTipoIdentificacion.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlPolizaTipoIdentificacion, controlSeleccionado.ValorDefecto);
            DdlPolizaTipoIdentificacion();

            //LBL IDENTIFICACION
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaIdentificacion.ID);
            this.lblPolizaIdentificacion.Text = controlSeleccionado.DesColumna;

            //LBL NOMBRE
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaNombre.ID);
            this.lblPolizaNombre.Text = controlSeleccionado.DesColumna;

            //LBL PRIMER APELLIDO
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaPrimerApellido.ID);
            this.lblPolizaPrimerApellido.Text = controlSeleccionado.DesColumna;

            //LBL SEGUNDO APELLIDO
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaSegundoApellido.ID);
            this.lblPolizaSegundoApellido.Text = controlSeleccionado.DesColumna;

            //LBL RAZON SOCIAL
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaRazonSocial.ID);
            this.lblPolizaRazonSocial.Text = controlSeleccionado.DesColumna;

            //LBL TELEFONO HABITACION
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaTelHabitacion.ID);
            this.lblPolizaTelHabitacion.Text = controlSeleccionado.DesColumna;

            //LBL TELEFONO MOVIL    
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaTelMovil.ID);
            this.lblPolizaTelMovil.Text = controlSeleccionado.DesColumna;

            //LBL TELEFONO TRABAJO    
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaTelTrabajo.ID);
            this.lblPolizaTelTrabajo.Text = controlSeleccionado.DesColumna;

            //LBL PROVINCIA    
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaProvincia.ID);
            this.lblPolizaProvincia.Text = controlSeleccionado.DesColumna;

            //LBL CANTON    
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaCanton.ID);
            this.lblPolizaCanton.Text = controlSeleccionado.DesColumna;

            //LBL DISTRITO    
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaDistrito.ID);
            this.lblPolizaDistrito.Text = controlSeleccionado.DesColumna;

            //LBL DIRECCION    
            controlSeleccionado = ControlesBuscar(controles, this.lblPolizaDireccion.ID);
            this.lblPolizaDireccion.Text = controlSeleccionado.DesColumna;

            //BTN LIMPIAR
            controlSeleccionado = ControlesBuscar(controles, this.btnPolizaLimpiar.ID);
            this.btnPolizaLimpiar.Text = controlSeleccionado.DesColumna;
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #endregion

    #region OTROS

    protected void ddlPolizaTipoPoliza_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DdlPolizaTipoPoliza();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void ddlPolizaTipoMoneda_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DdlPolizaTipoMoneda();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void ddlPolizaTipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DdlPolizaTipoIdentificacion();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtPolizaMontoPoliza_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!ValidarMontoPoliza())
                DdlPolizaTipoMoneda();
            else
            {
                //MENSAJE DE ERROR DE SALDO GRADO GRAVAMEN IGUAL A 0
                //this.InformarBoxGravamen1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblGravamenGarantiaSaldoGradoGravamen.Text, "mayor a 0");
                //this.mpeInformarBoxGravamen.Show();

                //SE LIMPIA EL CAMPO SALDO GRADO GRAVAMEN Y SALDO COLONIZADO
                this.txtPolizaMontoPoliza.Text = string.Empty;
                this.txtPolizaMontoPolizaColonizado.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void txtPolizaFechas_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ValidacionFechas();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void btnPolizaIdentificacionBuscar_Click(object sender, EventArgs e)
    {
        try
        {
             ObtenerDatosCliente();
             DatosClienteRequerido();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void txtPolizaIdentificacion_TextChanged(object sender, EventArgs e)
    {
        try
        {
            EstadoRequeridosCliente(false);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    /*BOTON DE LIMPIAR IDENTIFICACION*/
    protected void btnPolizaLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            //HABILITA EL DDL TIPO IDENTIFICACIÓN Y TXT IDENTIFICACION
            this.ddlPolizaTipoIdentificacion.Enabled = true;
            this.txtPolizaIdentificacion.Enabled = true;
            this.btnPolizaIdentificacionBuscar.Enabled = true;
            //DESHABILITA EL BTN LIMPIAR 
            this.btnPolizaLimpiar.Enabled = false;

            this.txtPolizaIdentificacion.Text = string.Empty;

            LimpiarDatosCliente();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*VALIDA SI EL SALDO ES MAYOR A 0*/
    private bool ValidarMontoPoliza()
    {
        //0 = NO HAY ERROR | 1 = HAY ERROR
        bool existError = false;

        if (this.txtPolizaMontoPoliza.Text.Trim().Length > 0)
        {
            decimal saldoGradoGravamen = decimal.Parse(this.txtPolizaMontoPoliza.Text);
            if (saldoGradoGravamen.Equals(0))
                existError = true;
        }
        else
        {
            this.txtPolizaMontoPoliza.Text = string.Empty;
            this.txtPolizaMontoPolizaColonizado.Text = string.Empty;
        }

        return existError;
    }

    /*METODO DDL TIPO POLIZA*/
    public void DdlPolizaTipoPoliza()
    {
        if (this.ddlPolizaTipoPoliza.Items.Count > 0)
        {
            if (this.ddlPolizaTipoPoliza.SelectedItem.Text.ToUpper().Equals("INTERNA"))
            {
                this.txtPolizaNumSap.Enabled = true;
                this.rfvGPolizaNumPoliza.Enabled = false;
            }
            else
            {
                this.txtPolizaNumSap.Text = string.Empty;
                this.txtPolizaNumSap.Enabled = false;
                this.rfvGPolizaNumPoliza.Enabled = true;
            }
        }
    }

    /*METODO DDL TIPO MONEDA*/
    public void DdlPolizaTipoMoneda()
    {
        if (this.ddlPolizaTipoMoneda.Items.Count > 0)
        {
            if (this.ddlPolizaTipoMoneda.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                SaldoColonizadoDolares();
            else
                SaldoColonizadoColones();
        }
    }

    /*ESTABLE LOS DATOS REQUERIDOS DEL CLIENTE SEGUN EL TIPO DE IDENTIFICACION*/
    private void DatosClienteRequerido()
    {
        string codTipoIdentificacion = this.ddlPolizaTipoIdentificacion.SelectedItem.Text.Split('-')[0].Trim();

        switch (codTipoIdentificacion)
        {
            case "1":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "11":
            case "12":
            case "13":
            case "14":
            case "15":
            case "16":
                this.rfvPolizaRazonSocial.Enabled = false;
                this.rfvPolizaPrimerApellido.Enabled = true;
                this.rfvPolizaNombre.Enabled = true;
                break;
            default:
                this.rfvPolizaRazonSocial.Enabled = true;
                this.rfvPolizaPrimerApellido.Enabled = false;
                this.rfvPolizaNombre.Enabled = false;
                break;
        }
    }

    /*METODO DDL TIPO IDENTIFICACION*/
    public void DdlPolizaTipoIdentificacion()
    {
        if (this.ddlPolizaTipoIdentificacion.Items.Count > 0)
        {

            if (this.ddlPolizaTipoIdentificacion.SelectedItem.Text.Split('-').Length > 0)
            {
                string valorSeleccionado = this.ddlPolizaTipoIdentificacion.SelectedItem.Text.Split('-')[0].Trim();
                
                //ESTABLECE LA MASCARA SEGUN EL TIPO DE IDENTIFICACION
                switch (valorSeleccionado)
                {
                    case "1":
                        mskPolizaIdentificacion.Enabled = true;
                        mskPolizaIdentificacion.Mask = "9-9999-9999";
                        mskPolizaIdentificacion.Filtered = string.Empty;
                        txtPolizaIdentificacion.ToolTip = "#-####-####";
                        txtPolizaIdentificacion.MaxLength = 30;
                        break;
                    case "2":
                        mskPolizaIdentificacion.Enabled = true;
                        mskPolizaIdentificacion.Mask = "9-999-999999";
                        mskPolizaIdentificacion.Filtered = string.Empty;
                        txtPolizaIdentificacion.ToolTip = "#-###-######";
                        txtPolizaIdentificacion.MaxLength = 30;
                        break;
                    case "5":
                        mskPolizaIdentificacion.Enabled = false;
                        txtPolizaIdentificacion.MaxLength = 17;
                        txtPolizaIdentificacion.ToolTip = string.Empty;
                        break;
                    default:
                        txtPolizaIdentificacion.MaxLength = 30;
                        mskPolizaIdentificacion.Enabled = false;
                        txtPolizaIdentificacion.ToolTip = string.Empty;
                        break;
                }

                //REQUERIDOS SEGUN TIPO DE IDENTIFICACION
                //DatosClienteRequerido(valorSeleccionado);
                EstadoRequeridosCliente(false);

                this.txtPolizaIdentificacion.Text = string.Empty;
            }
        }
    }

    /*METODO BTN BUSCAR CLIENTE*/
    public void ObtenerDatosCliente()
    {
        LimpiarDatosCliente();

        string identificacion = this.txtPolizaIdentificacion.Text.TrimEnd().TrimStart();
        if (identificacion.Length > 0)
        {
            PolizaClienteEntidad infoCliente = wsGarantias.GarantiasRealesPolizaConsultarCliente(identificacion);

            if (infoCliente != null)
            {
                if (infoCliente.CodigoError.Equals("0"))
                {
                    if (!this.ddlPolizaTipoIdentificacion.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                        this.txtPolizaNombre.Text = infoCliente.Nombre;

                    if (!this.ddlPolizaTipoIdentificacion.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                        this.txtPolizaPrimerApellido.Text = infoCliente.PrimerApellido;

                    if (!this.ddlPolizaTipoIdentificacion.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                        this.txtPolizaSegundoApellido.Text = infoCliente.SegundoApellido;

                    if (this.ddlPolizaTipoIdentificacion.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                        this.txtPolizaRazonSocial.Text = infoCliente.RazonSocial;

                    if (!this.ddlPolizaTipoIdentificacion.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                        this.txtPolizaTelHabitacion.Text = infoCliente.Telefono;

                    if (this.ddlPolizaTipoIdentificacion.SelectedItem.Text.Substring(0,3).Equals("2 -"))
                        this.txtPolizaTelTrabajo.Text = infoCliente.TelefonoTrabajo;

                    if (!this.ddlPolizaTipoIdentificacion.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                        this.txtPolizaTelMovil.Text = infoCliente.TelefonoMovil;

                    this.txtPolizaProvincia.Text = infoCliente.Provincia;
                    this.txtPolizaCanton.Text = infoCliente.Canton;
                    this.txtPolizaDistrito.Text = infoCliente.Distrito;
                    this.txtPolizaDireccion.Text = infoCliente.Direccion;

                    //DESHABILITA EL DDL TIPO IDENTIFICACIÓN Y TXT IDENTIFICACION
                    this.ddlPolizaTipoIdentificacion.Enabled = false;
                    this.txtPolizaIdentificacion.Enabled = false;
                    this.btnPolizaIdentificacionBuscar.Enabled = false;

                    //HABILITA EL BTN LIMPIAR 
                    this.btnPolizaLimpiar.Enabled = true;
                }
                else
                {
                    this.InformarBoxPoliza1_SetConfirmationBoxEvent(null, null, "SYS_30");
                    this.mpeInformarBoxPoliza.Show();
                }
            }            
        }
    }

    private void EstadoRequeridosCliente(bool habilitado)
    {
        rfvPolizaNombre.Enabled = habilitado;
        rfvPolizaPrimerApellido.Enabled = habilitado;
        rfvPolizaRazonSocial.Enabled = habilitado;
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            //MENSAJE INFORMAR
            Button btnAceptarInformar = (Button)this.InformarBoxPoliza1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);
            btnAceptarInformar.CausesValidation = false;
            this.InformarBoxPoliza1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxPoliza1_SetConfirmationBoxEvent);
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
            if (!IsPostBack)
            {
                DdlPolizaTipoPoliza();
                DdlPolizaTipoMoneda();
                DdlPolizaTipoIdentificacion();
            }
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
        this.mpeInformarBoxPoliza.Hide();
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

    protected void InformarBoxPoliza1_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        MensajesEntidad mensaje = this.Mensaje(type);
        InformarBoxPoliza1.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje);
    }

    protected void InformarBoxPoliza1_SetConfirmationBoxEvent(object sender, EventArgs e, string type, string valorReemplazo1, string valorReemplazo2)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBoxPoliza1.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo1).Replace("@$@", valorReemplazo2));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion
}