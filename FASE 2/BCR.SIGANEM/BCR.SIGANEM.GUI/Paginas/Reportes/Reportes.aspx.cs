using System;
using System.Net;
using System.Web;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Reflection;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

using ListasWS;
using SesionesWCF;
using SeguridadWS;
using GarantiasWS;
using ConfiguracionWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class Reportes : System.Web.UI.Page
{
    #region REFERENCIAS

    private BitacoraFlags bitacoraFlags = new BitacoraFlags();
    private RegistrarEventLog registroEventos = new RegistrarEventLog();
    private GeneradorControles generadorControles = new GeneradorControles();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private GarantiasWS.BitacorasEntidad bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
    private SeguridadWS.PantallasEntidad pantallasEntidad = new SeguridadWS.PantallasEntidad();
    private SeguridadWS.BitacorasEntidad bitacorasSeguridadEntidad = new SeguridadWS.BitacorasEntidad();

    private SiganemListasWS wsLista = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();
    private SiganemConfiguracionWS wsConfiguracion = new SiganemConfiguracionWS();

    #endregion

    #region VARIABLES

    private HttpHelper httpPost = null;
    private NameValueCollection dataSesion = null;

    private string filtro = string.Empty;
    private string valorReemplazo = string.Empty;
    static string ddlValorSeleccionado = string.Empty;

    private List<ControlEntidad> controlEntidad = null;
    private ControlEntidad controlSeleccionado = null;

    #endregion

    #region CONTROLES

    #region VENTANA BUSQUEDA EMERGENTE

    private GridView gridViewClaseVehiculo = null;
    private Button btnCerrarClaseVehiculo = null;
    private Button btnAceptarClaseVehiculo = null;

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS EDITABLES

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            //ASIGNANDO RUTAS DE SERVICIOS WEB
            this.AsignaWebServicesTypeNames();

            #region CONTROLES

            Button btnAceptarInformar = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);

            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

            if (!IsPostBack)
            {
                VariablesGlobales();
            }

            MetodosEmergentes(sender, e);

            #region MENSAJE INFORMAR VENTANA BUSQUEDA CLASE VEHICULO

            Button btnAceptarInformarClaseVehiculo = (Button)this.InformarBoxBusquedaClaseVehiculo.FindControl("wucBtnAceptar");
            btnAceptarInformarClaseVehiculo.Click += new EventHandler(btnAceptarInformarEmergenteClaseVehiculo_Click);
            btnAceptarInformarClaseVehiculo.CausesValidation = false;
            this.InformarBoxBusquedaClaseVehiculo.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxBusquedaClaseVehiculo_SetConfirmationBoxEvent);

            #endregion

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
            //DESHABILITA LOS BOTONES DEL RIBBON
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesAcciones(true);
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesDatos(true);
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesReportes(true);
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).OcultarBotones(true);

            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesMasAcciones(false);
            ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trEjecutarIPC")).Attributes.Add("style", "display:none");
            ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trEjecutarTC")).Attributes.Add("style", "display:none");
            ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trCopiarRol")).Attributes.Add("style", "display:none");

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                Controles();

                if (AccesoPermisoPagina())
                {
                    if (!IsPostBack)
                    {
                        Efectos();
                        this.Master.RefrescarDatosUsuario();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #region METODOS EMERGENTES

    /*GENERA LOS CONTROLES Y METODOS NECESARIOS PARA LAS VENTANAS EMERGENTES*/
    private void MetodosEmergentes(object sender, EventArgs e)
    {
        try
        {
            GarantiasRealesEspecificasEmergentes(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    private void SetDataKeys(GridView _gridView, String[] _dataKeysString)
    {
        _gridView.DataKeyNames = _dataKeysString;
    }

    #region GARANTIAS REALES

    private void GarantiasRealesEspecificasEmergentes(object sender, EventArgs e)
    {
        try
        {
            btnCerrarClaseVehiculo = ((Button)this.BusquedaClaseVehiculo.FindControl("cmdMainEmergenteCancelar"));
            btnCerrarClaseVehiculo.Click += new EventHandler(btnCerrarClaseVehiculo_Click);
            btnCerrarClaseVehiculo.CausesValidation = false;

            btnAceptarClaseVehiculo = ((Button)this.BusquedaClaseVehiculo.FindControl("cmdMainEmergenteAceptar"));
            btnAceptarClaseVehiculo.Click += new EventHandler(btnAceptarClaseVehiculo_Click);
            btnAceptarClaseVehiculo.CausesValidation = false;

            //GRID VENTANA BUSQUEDA CLASE VEHICULO
            GridViewClaseVehiculo(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    private void GridViewClaseVehiculo(object sender, EventArgs e)
    {
        try
        {
            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridViewClaseVehiculo = (GridView)this.BusquedaClaseVehiculo.FindControl("MasterGridView");
            this.BusquedaClaseVehiculo.TextoGridVacio("No hay Disponible ningún registro en este Catálogo.");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridViewClaseVehiculo.Init += new EventHandler(gridViewClaseVehiculo_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridViewClaseVehiculo_Init(sender, e);

            //TITULOS
            ((Label)this.BusquedaClaseVehiculo.FindControl("lblTitulo")).Text = "Información Clase Vehículos";
            ((Label)this.BusquedaClaseVehiculo.FindControl("lblSubTitulo")).Text = "Seleccione un registro.";

            //ASIGNA DATA KEYS
            String[] DataKeysString = { "Texto" };
            this.SetDataKeys(gridViewClaseVehiculo, DataKeysString);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    private void gridViewClaseVehiculo_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        gridViewColumn = new GridViewColumn();
        this.gridViewClaseVehiculo.Columns.Add(gridViewColumn.CreateBoundField("Texto", string.Empty, "Descripción", HorizontalAlign.Center, false, true));

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridViewClaseVehiculo, "Valor", lblID);
    }

    /*CONSULTA CLASES VEHICULOS*/
    private List<ListasWS.ListaEntidad> ConsultaClaseVehiculo(string filtro)
    {
        try
        {
            List<ListasWS.ListaEntidad> retorno = null;
            retorno = wsLista.ClasesVehiculosLista2(filtro).ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*BOTON CERRAR DEL POPUP CLASE VEHICULOS*/
    protected void btnCerrarClaseVehiculo_Click(object sender, EventArgs e)
    {
        this.mpeBusquedaClaseVehiculo.Hide();
    }

    /*BOTON ACEPTAR DEL POPUP CLASE VEHICULOS*/
    protected void btnAceptarClaseVehiculo_Click(object sender, EventArgs e)
    {
        try
        {
            SeleccionarRegistroClaseVehiculo(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*BOTON ACEPTAR MENSAJE POPUP CLASE VEHICULOS*/
    protected void btnAceptarInformarEmergenteClaseVehiculo_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxBusquedaClaseVehiculo.Hide();
        this.mpeBusquedaClaseVehiculo.Show();
    }

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE CLASE VEHICULO SELECCIONADO*/
    private void SeleccionarRegistroClaseVehiculo(object sender, EventArgs e)
    {
        try
        {
            #region BUSQUEDA CONTROLES

            TextBox txtDesClaseVehiculo = null;
            txtDesClaseVehiculo = (TextBox)this.tableData.FindControl("DesClaseVehiculo");
            TextBox txtClaseVehiculo = null;
            txtClaseVehiculo = (TextBox)this.tableData.FindControl("CodClaseVehiculo");

            HiddenField hdnIdClaseVehiculo = null;
            hdnIdClaseVehiculo = (HiddenField)this.tableData.FindControl("IdClaseVehiculo");

            #endregion

            if (txtDesClaseVehiculo != null && hdnIdClaseVehiculo != null && txtClaseVehiculo != null)
            {

                //VALIDA QUE SOLO UN ELEMENTO SEA EL SELECCIONADO
                if (((wucGridEmergente)this.BusquedaClaseVehiculo).ContadorSeleccionados().Equals(1))
                {
                    string[] valoresGrid;
                    List<string> valorSeleccionado = ((wucGridEmergente)this.BusquedaClaseVehiculo).ObtenerValoresSeleccionados("lblValor");
                    foreach (string valor in valorSeleccionado)
                    {
                        valoresGrid = valor.Split('|');

                        //lblclasev.Text = valoresGrid[1];
                        hdnIdClaseVehiculo.Value = valoresGrid[1];
                        txtDesClaseVehiculo.Text = valoresGrid[0];
                    }
                    UpdatePanelControlesReportes.Update();
                    this.mpeBusquedaClaseVehiculo.Hide();
                }
                else
                {
                    //VERIFICA SI EL GRID CONTIENE REGISTROS
                    if (((wucGridEmergente)this.BusquedaClaseVehiculo).ContieneRegistros())
                    {
                        this.mpeBusquedaClaseVehiculo.Hide();
                        this.InformarBoxBusquedaClaseVehiculo_SetConfirmationBoxEvent(sender, e, "SYS_4");
                        this.mpeInformarBoxBusquedaClaseVehiculo.Show();
                    }
                    else
                    {
                        //SI EL REGISTRO A BUSCAR NO EXISTE
                        txtClaseVehiculo.Text = string.Empty;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

    #region VALIDACIONES

    /*VALIDACION DE CARACTERES ESPECIALES*/
    private bool ValidarCaracterEspecial(string texto)
    {
        try
        {
            bool existeCaracter = false;
            //NO SE PERMITEN CARACTERES ESPECIALES
            var regexItem = new Regex("^[a-zA-Z0-9-]*$");

            if (!regexItem.IsMatch(texto))
                existeCaracter = true;

            return existeCaracter;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*REALIZA LAS VALIDACIONES SEGUN EL CODIGO DE PANTALLA (REPORTE) PARA EL BOTON GENERAR RPT*/
    private bool ExisteError()
    {
        try
        {
            bool retorno = false;
            int retornoValidacion = 0; //0 SIN ERROR | 1 CON ERROR

            //SE ASIGNA EL CODIGO DE LA PANTALLA (REPORTE)
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int codPantalla = int.Parse(pantallaCodOculto.Value);

                switch (codPantalla)
                {
                    case 171:
                        retornoValidacion = ValidarGarantiasRealesPorUsuario();
                        break;
                    case 173:
                        retornoValidacion = ValidarGarantiasFiduciariasPorUsuario();
                        break;
                    case 175:
                        retornoValidacion = ValidarGarantiasValoresPorUsuario();
                        break;
                    case 176:
                    case 182://REQIERIMIENTO 1-24493287: OPERACIONES FIDUCIARIAS
                        retornoValidacion = ValidarGarantiasFiduciariasEspecificas();
                        break;
                    case 177:
                    case 184://REQIERIMIENTO 1-24493287: OPERACIONES VALORES
                        retornoValidacion = ValidarGarantiasValoresEspecificas();
                        break;
                    case 178:
                    case 183://REQIERIMIENTO 1-24493287: OPERACIONES REALES
                        retornoValidacion = ValidarGarantiasRealesEspecificas();
                        break;
                }
            }

            if (retornoValidacion.Equals(0))
                retorno = false;
            else
                retorno = true;

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*REALIZA LAS VALIDACIONES SEGUN EL CODIGO DE PANTALLA (REPORTE) PARA LOS BOTONES DE BUSQUEDA*/
    private bool ExisteErrorBuscar()
    {
        try
        {
            bool retorno = false;
            int retornoValidacion = 0; //0 SIN ERROR | 1 CON ERROR
            //SE ASIGNA EL CODIGO DE LA PANTALLA (REPORTE)
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int _codPantalla = int.Parse(pantallaCodOculto.Value);

                switch (_codPantalla)
                {
                    case 178:
                    case 183:
                        retornoValidacion = ValidarClaseVehiculoGarantiasReales();
                        break;
                }
            }

            if (retornoValidacion.Equals(0))
                retorno = false;
            else
                retorno = true;

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region GARANTIAS

    #region GARANTIAS REALES

    private int ValidarGarantiasRealesPorUsuario()
    {
        int existeError = 0;  //0 SIN ERROR | 1 CON ERROR

        #region BUSQUEDA CONTROLES

        TextBox txtFechaInicio = null;
        TextBox txtFechaFinal = null;
        TextBox txtUsuario = null;
        txtFechaInicio = (TextBox)this.tableData.FindControl("FechaInicio");
        txtFechaFinal = (TextBox)this.tableData.FindControl("FechaFinal");
        txtUsuario = (TextBox)this.tableData.FindControl("IdUsuario");

        Label lblFechaInicio = null;
        lblFechaInicio = (Label)this.tableData.FindControl("lblFechaInicio");
        Label lblFechaFinal = null;
        lblFechaFinal = (Label)this.tableData.FindControl("lblFechaFinal");

        #endregion

        if (txtFechaInicio == null || txtFechaFinal == null)
        {
            existeError = 1;
        }
        else
        {
            //SI LA FECHA DE INICIO ES MAYOR A LA FECHA ACTUAL
            if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
            {
                existeError = 1;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaInicio.Text, "menor o igual a la Fecha Actual");
                this.mpeInformarBox.Show();
            }
            else
            {
                //SI LA FECHA DE INICIO ES MAYOR A LA FECHA FINAL
                if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, txtFechaFinal.Text, EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                {
                    existeError = 1;
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "mayor o igual a " + lblFechaInicio.Text);
                    this.mpeInformarBox.Show();
                }
                else
                {
                    //SI LA FECHA DE FINAL ES MAYOR A LA FECHA ACTUAL
                    if (generadorControles.ObtenerComparacion(txtFechaFinal.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                    {
                        existeError = 1;
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "menor o igual a la Fecha Actual");
                        this.mpeInformarBox.Show();
                    }
                }
            }

        }

        //VALIDACION DE CARACTERES ESPECIALES
        if (txtUsuario == null)
            existeError = 1;
        else
        {
            //SI EXISTE UN CARACTER ESPECIAL
            if (ValidarCaracterEspecial(txtUsuario.Text))
            {
                existeError = 1;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_2");
                this.mpeInformarBox.Show();
            }
        }

        return existeError;
    }

    private int ValidarGarantiasRealesEspecificas()
    {
        //0 SIN ERROR | 1 CON ERROR
        int existeError = 0;  

        var regex6Numerico = new Regex(@"^\d{6}$");
        var regex3letras3numeros = new Regex(@"^[a-zA-Z]{3}\d{3}$");
        var regexNoVocales = new Regex(@"^[^aeiouAEIOU]{3}");

        //Control de Cambios FI 2016
        var regex6NumericoNoFijo = new Regex(@"^\d{1,6}$");

        //Control de Cambios 1.1
        var regex17alfanumericosFijo = new Regex(@"^([a-zA-Z]|\d){17}$");
        var regex17alfanumericos = new Regex(@"^([a-zA-Z]|\d){1,17}$");

        #region BUSQUEDA CONTROLES

        TextBox txtNBien = null;
        txtNBien = (TextBox)this.tableData.FindControl("NBien");

        DropDownList ddlTipoBien = (DropDownList)this.tableData.FindControl("IdTipoBien");
        DropDownList ddlFormato = (DropDownList)this.tableData.FindControl("IdFormatoIdentificacionVehiculo");

        TextBox txtFechaInicio = null;
        TextBox txtFechaFinal = null;
        txtFechaInicio = (TextBox)this.tableData.FindControl("FechaInicio");
        txtFechaFinal = (TextBox)this.tableData.FindControl("FechaFinal");

        Label lblFechaInicio = null;
        Label lblFechaFinal = null;
        Label lblNBien = null;
        lblFechaInicio = (Label)this.tableData.FindControl("lblFechaInicio");
        lblFechaFinal = (Label)this.tableData.FindControl("lblFechaFinal");
        lblNBien = (Label)this.tableData.FindControl("lblNBien");

        #endregion

        //REQIERIMIENTO 1-24493287
        if (this.pantallaCodOculto.Value.Equals("178"))
        {
            #region VALIDACION DE LAS FECHAS
            if (txtFechaInicio == null || txtFechaFinal == null)
            {
                existeError = 1;
            }
            else
            {
                //SI LA FECHA DE INICIO ES MAYOR A LA FECHA ACTUAL
                if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                {
                    existeError = 1;
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaInicio.Text, "menor o igual a la Fecha Actual");
                    this.mpeInformarBox.Show();
                }
                else
                {
                    //SI LA FECHA DE INICIO ES MAYOR A LA FECHA FINAL
                    if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, txtFechaFinal.Text, EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                    {
                        existeError = 1;
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "mayor o igual a " + lblFechaInicio.Text);
                        this.mpeInformarBox.Show();
                    }
                    else
                    {
                        //SI LA FECHA DE FINAL ES MAYOR A LA FECHA ACTUAL
                        if (generadorControles.ObtenerComparacion(txtFechaFinal.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                        {
                            existeError = 1;
                            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "menor o igual a la Fecha Actual");
                            this.mpeInformarBox.Show();
                        }
                    }
                }

            }
            #endregion
        }

        //VALIDACION DE NBIEN
        //SI LA VALIDACION ANTERIOR NO TIENE ERROR
        if (existeError.Equals(0))
        {
            if (ddlTipoBien == null || txtNBien == null || ddlFormato == null)
                existeError = 1;
            else
            {
                //VALOR SELECCIONADO EN EL TIPO BIEN (X -)
                string valorTipoBien = ddlTipoBien.SelectedItem.Text.Substring(0, 3);
                //VALOR SELECCIONADO EN EL TIPO BIEN (XX -)
                string valorTipoBien2 = ddlTipoBien.SelectedItem.Text.Substring(0, 4);

                //VALOR SELECCIONADO EN EL FORMATO DE IDENTIFICACION VEHICULO
                string valorFormatoIdentificacion = ddlFormato.SelectedItem.Text;

                if (valorTipoBien.Equals("1 -") || valorTipoBien.Equals("2 -"))
                {
                    //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES NO FIJOS
                    if (!regex6NumericoNoFijo.IsMatch(txtNBien.Text))
                    {
                        existeError = 1;
                    }
                }
                else
                {
                    if (valorTipoBien.Equals("9 -") || valorTipoBien2.Equals("10 -"))
                    {
                        //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES
                        if (!regex6Numerico.IsMatch(txtNBien.Text))
                        {
                            existeError = 1;
                        }
                    }
                    else
                    {
                        if (!valorTipoBien.Equals("3 -"))
                        {
                            //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES
                            if (!regex17alfanumericos.IsMatch(txtNBien.Text))
                            {
                                existeError = 1;
                            }
                        }
                    }
                }

                if (valorTipoBien.Equals("3 -"))
                {
                    if (valorFormatoIdentificacion.Equals("Numérico 6 enteros"))
                    {
                        //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES
                        if (!regex6Numerico.IsMatch(txtNBien.Text))
                        {
                            existeError = 1;
                        }
                    }
                    else
                    {
                        if (valorFormatoIdentificacion.Equals("Alfanumérico 3 letras y 3 enteros"))
                        {
                            //VERIFICACION DEL FORMATO 3 LETRAS Y 3 NUMEROS
                            if (!regex3letras3numeros.IsMatch(txtNBien.Text))
                            {
                                existeError = 1;
                            }

                            //VERIFICACION DEL FORMATO 3 LETRAS SIN VOCALES
                            if (!regexNoVocales.IsMatch(txtNBien.Text))
                            {
                                existeError = 1;
                            }
                        }
                        else
                        {
                            //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES
                            if (!regex17alfanumericosFijo.IsMatch(txtNBien.Text))
                            {
                                existeError = 1;
                            }
                        }
                    }
                }
            }

            //SI LA VALIDACION DE NBIEN TIENE UN ERROR ENTONCES SE MUESTRA EL MENSAJE DEL FORMATO
            if (existeError.Equals(1))
            {
                //MENSAJE DE ERROR DE FORMATO
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_6", lblNBien.Text, txtNBien.ToolTip);
                this.mpeInformarBox.Show();
            }

        }

        return existeError;
    }

    #endregion

    #region GARANTIAS FIDUCIARIAS

    private int ValidarGarantiasFiduciariasPorUsuario()
    {
        //0 SIN ERROR | 1 CON ERROR
        int existeError = 0;  

        #region BUSQUEDA CONTROLES

        TextBox txtFechaInicio = null;
        TextBox txtFechaFinal = null;
        TextBox txtUsuario = null;
        txtFechaInicio = (TextBox)this.tableData.FindControl("FechaInicio");
        txtFechaFinal = (TextBox)this.tableData.FindControl("FechaFinal");
        txtUsuario = (TextBox)this.tableData.FindControl("IdUsuario");

        Label lblFechaInicio = null;
        lblFechaInicio = (Label)this.tableData.FindControl("lblFechaInicio");
        Label lblFechaFinal = null;
        lblFechaFinal = (Label)this.tableData.FindControl("lblFechaFinal");

        #endregion

        if (txtFechaInicio == null || txtFechaFinal == null)
        {
            existeError = 1;
        }
        else
        {
            //SI LA FECHA DE INICIO ES MAYOR A LA FECHA ACTUAL
            if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
            {
                existeError = 1;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaInicio.Text, "menor o igual a la Fecha Actual");
                this.mpeInformarBox.Show();
            }
            else
            {
                //SI LA FECHA DE INICIO ES MAYOR A LA FECHA FINAL
                if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, txtFechaFinal.Text, EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                {
                    existeError = 1;
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "mayor o igual a " + lblFechaInicio.Text);
                    this.mpeInformarBox.Show();
                }
                else
                {
                    //SI LA FECHA DE FINAL ES MAYOR A LA FECHA ACTUAL
                    if (generadorControles.ObtenerComparacion(txtFechaFinal.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                    {
                        existeError = 1;
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "menor o igual a la Fecha Actual");
                        this.mpeInformarBox.Show();
                    }
                }
            }
        }

        //VALIDACION DE CARACTERES ESPECIALES
        if (txtUsuario == null)
            existeError = 1;
        else
        {
            //SI EXISTE UN CARACTER ESPECIAL
            if (ValidarCaracterEspecial(txtUsuario.Text))
            {
                existeError = 1;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_2");
                this.mpeInformarBox.Show();
            }
        }


        return existeError;
    }

    private int ValidarGarantiasFiduciariasEspecificas()
    {
        //0 SIN ERROR | 1 CON ERROR
        int existeError = 0;  

        #region BUSQUEDA CONTROLES

        TextBox txtIdRUC = null;
        txtIdRUC = (TextBox)this.tableData.FindControl("IdentificacionRUC");

        TextBox txtFechaInicio = null;
        TextBox txtFechaFinal = null;
        txtFechaInicio = (TextBox)this.tableData.FindControl("FechaInicio");
        txtFechaFinal = (TextBox)this.tableData.FindControl("FechaFinal");

        Label lblFechaInicio = null;
        lblFechaInicio = (Label)this.tableData.FindControl("lblFechaInicio");
        Label lblFechaFinal = null;
        lblFechaFinal = (Label)this.tableData.FindControl("lblFechaFinal");

        #endregion

        //REQIERIMIENTO 1-24493287
        if (this.pantallaCodOculto.Value.Equals("176"))
        {
            #region VALIDACION DE LAS FECHAS

            if (txtFechaInicio == null || txtFechaFinal == null)
            {
                existeError = 1;
            }
            else
            {
                //SI LA FECHA DE INICIO ES MAYOR A LA FECHA ACTUAL
                if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                {
                    existeError = 1;
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaInicio.Text, "menor o igual a la Fecha Actual");
                    this.mpeInformarBox.Show();
                }
                else
                {
                    //SI LA FECHA DE INICIO ES MAYOR A LA FECHA FINAL
                    if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, txtFechaFinal.Text, EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                    {
                        existeError = 1;
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "mayor o igual a " + lblFechaInicio.Text);
                        this.mpeInformarBox.Show();
                    }
                    else
                    {
                        //SI LA FECHA DE FINAL ES MAYOR A LA FECHA ACTUAL
                        if (generadorControles.ObtenerComparacion(txtFechaFinal.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                        {
                            existeError = 1;
                            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "menor o igual a la Fecha Actual");
                            this.mpeInformarBox.Show();
                        }
                    }
                }

            }

            #endregion
        }

        //VALIDACION DE CARACTERES ESPECIALES
        if (txtIdRUC == null)
            existeError = 1;
        else
        {
            //SI EXISTE UN CARACTER ESPECIAL
            if (ValidarCaracterEspecial(txtIdRUC.Text))
            {
                existeError = 1;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_2");
                this.mpeInformarBox.Show();
            }
        }

        return existeError;
    }

    #endregion

    #region GARANTIAS VALORES

    private int ValidarGarantiasValoresPorUsuario()
    {
        //0 SIN ERROR | 1 CON ERROR
        int existeError = 0;  

        #region BUSQUEDA CONTROLES

        TextBox txtFechaInicio = null;
        TextBox txtFechaFinal = null;
        TextBox txtUsuario = null;
        txtFechaInicio = (TextBox)this.tableData.FindControl("FechaInicio");
        txtFechaFinal = (TextBox)this.tableData.FindControl("FechaFinal");
        txtUsuario = (TextBox)this.tableData.FindControl("IdUsuario");

        Label lblFechaInicio = null;
        lblFechaInicio = (Label)this.tableData.FindControl("lblFechaInicio");
        Label lblFechaFinal = null;
        lblFechaFinal = (Label)this.tableData.FindControl("lblFechaFinal");

        #endregion

        if (txtFechaInicio == null || txtFechaFinal == null)
        {
            existeError = 1;
        }
        else
        {
            //SI LA FECHA DE INICIO ES MAYOR A LA FECHA ACTUAL
            if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
            {
                existeError = 1;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaInicio.Text, "menor o igual a la Fecha Actual");
                this.mpeInformarBox.Show();
            }
            else
            {
                //SI LA FECHA DE INICIO ES MAYOR A LA FECHA FINAL
                if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, txtFechaFinal.Text, EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                {
                    existeError = 1;
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "mayor o igual a " + lblFechaInicio.Text);
                    this.mpeInformarBox.Show();
                }
                else
                {
                    //SI LA FECHA DE FINAL ES MAYOR A LA FECHA ACTUAL
                    if (generadorControles.ObtenerComparacion(txtFechaFinal.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                    {
                        existeError = 1;
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "menor o igual a la Fecha Actual");
                        this.mpeInformarBox.Show();
                    }
                }
            }
        }

        //VALIDACION DE CARACTERES ESPECIALES
        if (txtUsuario == null)
            existeError = 1;
        else
        {
            //SI EXISTE UN CARACTER ESPECIAL
            if (ValidarCaracterEspecial(txtUsuario.Text))
            {
                existeError = 1;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_2");
                this.mpeInformarBox.Show();
            }
        }

        return existeError;
    }

    private int ValidarGarantiasValoresEspecificas()
    {
        //0 SIN ERROR | 1 CON ERROR
        int existeError = 0;  

        #region BUSQUEDA CONTROLES

        TextBox txtGarantia = null;
        txtGarantia = (TextBox)this.tableData.FindControl("CodGarantiaBCR");

        TextBox txtFechaInicio = null;
        TextBox txtFechaFinal = null;
        txtFechaInicio = (TextBox)this.tableData.FindControl("FechaInicio");
        txtFechaFinal = (TextBox)this.tableData.FindControl("FechaFinal");

        Label lblFechaInicio = null;
        lblFechaInicio = (Label)this.tableData.FindControl("lblFechaInicio");
        Label lblFechaFinal = null;
        lblFechaFinal = (Label)this.tableData.FindControl("lblFechaFinal");

        #endregion

        //REQIERIMIENTO 1-24493287
        if (this.pantallaCodOculto.Value.Equals("177"))
        {
            #region VALIDACION DE LAS FECHAS
            if (txtFechaInicio == null || txtFechaFinal == null)
            {
                existeError = 1;
            }
            else
            {
                //SI LA FECHA DE INICIO ES MAYOR A LA FECHA ACTUAL
                if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                {
                    existeError = 1;
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaInicio.Text, "menor o igual a la Fecha Actual");
                    this.mpeInformarBox.Show();
                }
                else
                {
                    //SI LA FECHA DE INICIO ES MAYOR A LA FECHA FINAL
                    if (generadorControles.ObtenerComparacion(txtFechaInicio.Text, txtFechaFinal.Text, EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                    {
                        existeError = 1;
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "mayor o igual a " + lblFechaInicio.Text);
                        this.mpeInformarBox.Show();
                    }
                    else
                    {
                        //SI LA FECHA DE FINAL ES MAYOR A LA FECHA ACTUAL
                        if (generadorControles.ObtenerComparacion(txtFechaFinal.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
                        {
                            existeError = 1;
                            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", lblFechaFinal.Text, "menor o igual a la Fecha Actual");
                            this.mpeInformarBox.Show();
                        }
                    }
                }
            }
            #endregion
        }

        //VALIDACION DE CARACTERES ESPECIALES
        if (existeError.Equals(0))
        {
            if (txtGarantia == null)
                existeError = 1;
            else
            {
                //SI EXISTE UN CARACTER ESPECIAL
                if (ValidarCaracterEspecial(txtGarantia.Text))
                {
                    existeError = 1;
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_2");
                    this.mpeInformarBox.Show();
                }
            }
        }

        return existeError;
    }

    #endregion

    #region CLASE VEHICULO

    private int ValidarClaseVehiculoGarantiasReales()
    {
        //0 SIN ERROR | 1 CON ERROR
        int existeError = 0;  

        #region BUSQUEDA CONTROLES

        TextBox txtClaseVehiculo = null;
        txtClaseVehiculo = (TextBox)this.tableData.FindControl("CodClaseVehiculo");

        #endregion

        //VALIDACION DE CARACTERES ESPECIALES
        if (txtClaseVehiculo == null)
            existeError = 1;
        else
        {
            //SI EXISTE UN CARACTER ESPECIAL
            if (ValidarCaracterEspecial(txtClaseVehiculo.Text))
            {
                existeError = 1;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_2");
                this.mpeInformarBox.Show();
            }
        }

        return existeError;
    }

    #endregion

    #endregion

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS NO EDITABLES

    #region CONTROLES

    #region LAYOUT CONTROLES

    /*EXTRAE LOS CONTROLES DESDE BD*/
    private void Controles()
    {
        try
        {
            if (pantallaModuloOculto.Value != null)
            {
                // BUSCA NOMBRE DE LA PANTALLA
                pantallasEntidad.RutaPantalla = Page.AppRelativeVirtualPath.ToString();
                //ASIGNA EL ID DE LA PANTALLA
                pantallasEntidad.IdPantalla = int.Parse(pantallaModuloOculto.Value); 

                //OBTIENE TODOS LOS DATOS DE LA PANTALLA SOLO CON EL ID DE LA PANTALLA
                pantallasEntidad = wsSeguridad.PantallasConsultarDetalle(pantallasEntidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                pantallaTituloOculto.Value = pantallasEntidad.TituloPantalla;
                pantallaModuloOculto.Value = pantallasEntidad.IdPantalla.ToString();
                pantallaCodOculto.Value = pantallasEntidad.CodPantalla.ToString();
                pantallaNombreOculto.Value = Request.Url.Segments[Request.Url.Segments.Length - 1].Replace(".aspx", "");

                // ASIGNA EL TITULO AL MANTENIMIENTO  
                this.lblTituloPage.Text = string.Concat("Reporte ", pantallasEntidad.TituloPantalla);

                ListasWS.PantallasEntidad pantalla = new ListasWS.PantallasEntidad();
                pantalla.CodPantalla = pantallasEntidad.CodPantalla;


                //LIMPIA TABLA DE LA PAGINA ACTUAL
                this.tableData.Controls.Clear();

                //ESTABLECE LOS CONTROLES DE LA PANTALLA A CARGAR
                pantalla.Pestana = string.Empty;

                //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD
                List<ControlEntidad> ds = new List<ControlEntidad>();
                ds = this.wsLista.AdministracionesContenidosConsultaControl(pantalla).ToList();

                //CREAR E INSERTA LOS CONTROLES EN LA PAGINA ACTUAL    
                LlenarTabla(this.tableData, pantallaNombreOculto.Value, ds);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS CONTROLES AL FORMULARIO*/
    public void LlenarTabla(Table tblPrincipal, string desPagina, List<ControlEntidad> dsControles)
    {
        Boolean AssocRowReady = false;

        #region CREA CONTROLES

        //CREA OBJETO REQUIRED FIELD VALIDATOR
        RequiredFieldValidator rfv = null;

        //CREA OBJETO MaskedEditExtender Ajax Control
        MaskedEditExtender mask = null;

        //CREA OBJETO CalendarExterder Ajax Control
        CalendarExtender calendarExtender = null;

        //CREA OBJETO TABLA TEMPORAL asp:Table
        tblPrincipal.ID = String.Concat("aspTable", desPagina);

        //CREA TABLE ROW
        TableRow tableRow;

        //CREA TABLE ROW PARA CONTROLES DEPENDIENTES
        TableRow tableRowAssocID = null;

        #endregion

        try
        {
            //OBTIENE LOS CONTROLES DESDE LA BASE DE DATOS

            //VARIABLE ROWCOUNT
            int rowCount = 0;

            /*********************
            DIMENSION DE LA TABLA
            *COL1 = 290 X 15
            *COL2 = 410 X 15
            *COL3 = 40 X 15
            *********************/

            //RECORRE LOS CONTROLES EXTRAIDOS DESDE LA BD            
            foreach (ControlEntidad control in dsControles)
            {
                string assocID = control.NombrePropiedadAsociada;
                filtro = string.Empty;
                int _width;
                int flag = 0; //0 = SIN ITEMS | 1 = CON ITEMS (PARA DROPDOWNLIST)

                if (((Control)tblPrincipal.FindControl(control.NombrePropiedad)) == null)
                {
                    tableRow = new TableRow();
                    tableRow.ID = string.Concat("tr", control.NombrePropiedad);
                    tableRow.Height = Unit.Parse("10");

                    //CREA TABLE CELL
                    TableCell tc1 = new TableCell();
                    tc1.ID = String.Concat("tcRow", rowCount, "Cell", 0);
                    //tc1.Width = Unit.Parse("325");
                    tc1.Width = Unit.Parse("290");
                    tc1.Height = Unit.Parse("15");

                    //CREA ETIQUETA
                    Label cellLabel = new Label();
                    cellLabel = generadorControles.Tipo_Contenido(EnumTipoControl.LABEL
                                                , String.Concat("lbl", control.NombrePropiedad)
                                                , control.DesColumna
                                                , String.Concat("Etiqueta ", control.DesColumna)
                                                , true
                                                , true
                                                , "blacklabel"
                                                , String.Empty) as Label;
                    cellLabel.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    cellLabel.Style.Add("padding-left", "5px");

                    //ASIGNA EL NOMBRE 
                    string codeName = control.NombrePropiedad;

                    //AGREGA LA ETIQUETA A LA CELDA1 
                    tc1.Controls.Add(cellLabel);

                    //ASIGNA EL VALOR DEL TIPO DE OBJETO 
                    string Tipo_Contenido = control.TipoContenido;
                    Tipo_Contenido = Tipo_Contenido.ToUpper();

                    //CREA TABLE CELL 2
                    TableCell tc2 = new TableCell();
                    tc2.ID = String.Concat("tc", "Row", rowCount, "Cell", "2");
                    tc2.Height = Unit.Parse("15");
                    tc2.Width = Unit.Parse("410");
                    tc2.HorizontalAlign = HorizontalAlign.Left;

                    //CREA TABLE CELL PARA ASIGNAR LOS CONTROLES DEPENDIENTES
                    TableCell tcAssocIDLabel = null;
                    TableCell tcAssocID = null;

                    #region SWITCH CONTROLES

                    switch (Tipo_Contenido)
                    {
                        #region LABEL
                        case "LABEL":

                            Label label = new Label();
                            label.ID = codeName;
                            label.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            label.Text = string.Empty;
                            label.ToolTip = String.Concat("Etiqueta ", control.DesColumna);
                            label.Enabled = bool.Parse(control.IndModificar);
                            label.Visible = bool.Parse(control.IndVisible);
                            label.CssClass = "blacklabel";

                            tc2.Controls.Add(label);

                            break;
                        #endregion

                        #region TEXTBOX
                        case "TEXTBOX":

                            TextBox textBox = new TextBox();
                            textBox.ID = codeName;
                            textBox.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            textBox.Text = control.ValorDefecto;
                            textBox.ToolTip = String.Concat("Texto ", control.DesColumna);
                            textBox.Enabled = bool.Parse(control.IndModificar);
                            textBox.Visible = bool.Parse(control.IndVisible);
                            textBox.CssClass = control.CssTipo;
                            textBox.MaxLength = Int32.Parse(control.LongitudMaxima);

                            textBox.CausesValidation = false;

                            if (!String.IsNullOrEmpty(control.GrupoValidacion))
                            {
                                textBox.ValidationGroup = control.GrupoValidacion;
                            }

                            if (textBox.MaxLength > 50)
                            {
                                _width = 400;
                            }
                            else
                            {
                                if (textBox.MaxLength < 20)
                                    _width = 147;
                                else
                                    _width = (textBox.MaxLength * 8);
                            }
                            textBox.Width = _width;

                            tc2.Controls.Add(textBox);

                            #region MASKEDEDITEXTENDER

                            int m = Int32.Parse(control.Mascara);

                            if (m > 0)
                            {
                                textBox.MaxLength = Int32.Parse(control.LongitudMaxima);

                                int mType = Int32.Parse(control.LongitudMaxima);

                                mask = new MaskedEditExtender();
                                mask.ID = String.Concat("mask", codeName);
                                mask.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                                mask.TargetControlID = textBox.ID;

                                mask.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();
                                mask.ClearTextOnInvalid = true;
                                mask.ClearMaskOnLostFocus = true;
                                //mask.AutoComplete = false;

                                mask.MaskType = generadorControles.DeterminaTipoMascara(m);
                                mask.InputDirection = MaskedEditInputDirection.RightToLeft;

                                string mascara = generadorControles.DeterminaFormatoMascara(mType, control.ValorMascara);
                                mask.Mask = mascara;
                            }

                            #endregion

                            #region REQUIREDFIELDVALIDATOR

                            if (control.IndRequerido.Equals("True"))
                            {
                                rfv = new RequiredFieldValidator();
                                rfv.ID = String.Concat("rfv", codeName);
                                rfv.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                                rfv.ControlToValidate = textBox.ID;
                                rfv.ErrorMessage = "Required";
                                rfv.Display = ValidatorDisplay.Dynamic;
                                rfv.Text = " * ";
                                rfv.CssClass = "labelTabError";
                            }

                            #endregion

                            break;
                        #endregion

                        #region MULTILINE
                        case "MULTILINE":
                            TextBox mTextBox = new TextBox();
                            mTextBox.ID = codeName;
                            mTextBox.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            mTextBox.Text = string.Empty;
                            mTextBox.ToolTip = String.Concat("Texto ", control.DesColumna);
                            mTextBox.Enabled = bool.Parse(control.IndModificar);
                            mTextBox.Visible = bool.Parse(control.IndVisible);
                            mTextBox.CssClass = control.CssTipo;
                            mTextBox.MaxLength = Int32.Parse(control.LongitudMaxima);
                            mTextBox.TextMode = TextBoxMode.MultiLine;
                            mTextBox.Height = 130;
                            mTextBox.Width = 450;

                            tc2.Controls.Add(mTextBox);

                            #region REQUIREDFIELDVALIDATOR

                            if (control.IndRequerido.Equals("True"))
                            {
                                rfv = new RequiredFieldValidator();
                                rfv.ID = String.Concat("rfv", codeName);
                                rfv.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                                rfv.ControlToValidate = mTextBox.ID;
                                rfv.ErrorMessage = "Required";
                                rfv.Display = ValidatorDisplay.Dynamic;
                                rfv.Text = " * ";
                                rfv.CssClass = "labelTabError";
                            }
                            #endregion

                            break;
                        #endregion

                        #region BUTTON
                        case "BUTTON":

                            Button button = new Button();
                            button.ID = codeName;
                            button.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            button.Text = string.Empty;
                            button.ToolTip = String.Concat("Botón ", control.DesColumna);
                            button.Enabled = bool.Parse(control.IndModificar);
                            button.Visible = bool.Parse(control.IndVisible);
                            button.CssClass = control.CssTipo;

                            tc2.Controls.Add(button);

                            break;
                        #endregion

                        #region DROPDOWN LIST
                        case "DROPDOWNLIST":

                            DropDownList dropDownList = new DropDownList();
                            dropDownList.ID = codeName;
                            dropDownList.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            string spText = control.MetodoServicioWeb;
                            AssocRowReady = false;

                            if (String.IsNullOrEmpty(spText))
                            {
                                dropDownList.Items.Add(new ListItem("No hay Datos", "-1"));
                                flag = 0; //NO HAY ITEMS
                            }
                            else
                            {
                                flag = 1; //EXISTEN ITEMS
                                dropDownList.Items.Clear();

                                //BUSQUEDA DE LOS VALORES DE FILTRO PARA LOS COMBOS DEPENDIENTES
                                if (((Control)tblPrincipal.FindControl(control.NombrePropiedadAsociada)) != null)
                                {
                                    filtro = ((DropDownList)tblPrincipal.FindControl(control.NombrePropiedadAsociada)).SelectedValue;
                                }
                                else
                                {
                                    filtro = control.ValorServicioWeb;
                                }

                                //EJECUTA LAS EXCEPCIONES PARA LA CARGA DE CONTROLES
                                //CargarControlesExcepciones(tblPrincipal, control);

                                dropDownList.DataSource = LlenarDropDownList(spText, filtro);
                                dropDownList.DataTextField = "Texto";
                                dropDownList.DataValueField = "Valor";
                                dropDownList.DataBind();

                                //ESTABLE EL VALOR POR DEFECTO DEL CONTROL
                                if (!string.IsNullOrEmpty(control.IndValorDefecto))
                                {
                                    if (bool.Parse(control.IndValorDefecto))
                                    {
                                        for (int i = 0; i < dropDownList.Items.Count; i++)
                                        {
                                            if (dropDownList.Items[i].Text.Equals(control.ValorDefecto))
                                                dropDownList.SelectedIndex = i;
                                        }
                                    }
                                }

                                ddlValorSeleccionado = dropDownList.SelectedValue.ToString(); //SE ASIGNA EL ELEMENTO SELECCIONADO POR DEFECTO
                            }

                            dropDownList.ToolTip = String.Concat("Lista de ", control.DesColumna);
                            dropDownList.Enabled = bool.Parse(control.IndModificar);
                            dropDownList.Visible = bool.Parse(control.IndVisible);
                            dropDownList.CssClass = control.CssTipo;
                            dropDownList.Width = Unit.Parse("100%");

                            //EVENTO DE LA LISTA PADRE PARA EL MANEJO DE LISTAS ANIDADAS
                            dropDownList.AutoPostBack = true;
                            dropDownList.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);

                            tc2.Controls.Add(dropDownList);

                            //BUSQUEDA DE LOS CONTROLES DEPENDIENTES
                            List<ControlEntidad> dsControles1 = dsControles;
                            foreach (ControlEntidad controlAsociado in dsControles1)
                            {
                                string assocParent = dropDownList.ID.ToUpper();
                                string assocChild = controlAsociado.NombrePropiedadAsociada.ToUpper();

                                if (assocParent.Equals(assocChild))
                                {
                                    string Nombre_Columnar = controlAsociado.NombrePropiedad;
                                    string Des_Columnar = controlAsociado.DesColumna;
                                    string Tipo_Contenidor = controlAsociado.TipoContenido;
                                    string lengthr = controlAsociado.LongitudMaxima;
                                    string maskTyper = controlAsociado.Mascara;
                                    string spTextr = controlAsociado.MetodoServicioWeb;
                                    string assocIDr = controlAsociado.NombrePropiedadAsociada;

                                    DropDownList ddlAssocID = new DropDownList();
                                    ddlAssocID.ID = Nombre_Columnar;
                                    ddlAssocID.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                                    ddlAssocID.ToolTip = String.Concat("Lista de ", Des_Columnar);
                                    ddlAssocID.Enabled = bool.Parse(controlAsociado.IndModificar);
                                    ddlAssocID.Visible = bool.Parse(controlAsociado.IndVisible);
                                    ddlAssocID.CssClass = controlAsociado.CssTipo;
                                    ddlAssocID.Width = Unit.Parse("100%");

                                    ddlAssocID.Items.Clear();

                                    if (flag.Equals(0))//NO HAY ITEMS
                                    {
                                        ddlAssocID.Items.Add("No hay Datos");
                                    }
                                    else
                                    {
                                        ddlAssocID.DataSource = LlenarDropDownList(spTextr, ddlValorSeleccionado);
                                        ddlAssocID.DataTextField = "Texto";
                                        ddlAssocID.DataValueField = "Valor";
                                        ddlAssocID.DataBind();
                                        ddlAssocID.AutoPostBack = true;
                                        ddlAssocID.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);
                                    }

                                    tableRowAssocID = new TableRow();
                                    tableRowAssocID.Height = Unit.Parse("10");

                                    tcAssocIDLabel = new TableCell();
                                    tcAssocIDLabel.ID = String.Concat("tcRow", rowCount, "LblCell", "AssocID4");
                                    tcAssocIDLabel.Width = Unit.Parse("150");
                                    tcAssocIDLabel.Style.Add("border-bottom", "1px dotted #FBFBEF");
                                    tcAssocIDLabel.Height = Unit.Parse("15");

                                    //CREA LA ETIQUETA ASOCIADA AL CONTROL
                                    Label lblAssocID = new Label();
                                    lblAssocID = generadorControles.Tipo_Contenido(EnumTipoControl.LABEL
                                                                , String.Concat("lbl", rowCount, "Cell", 4)
                                                                , Des_Columnar
                                                                , String.Concat("Label ", Des_Columnar)
                                                                , true
                                                                , true
                                                                , "blacklabel"
                                                                , String.Empty) as Label;
                                    lblAssocID.Style.Add("padding-left", "5px");
                                    //AGREGA LA ETIQUETA A LA CELDA
                                    tcAssocIDLabel.Controls.Add(lblAssocID);

                                    tcAssocID = new TableCell();
                                    tcAssocID.ID = String.Concat("tcRow", rowCount, "DdlCell", "AssocID4");
                                    tcAssocID.Width = Unit.Parse("20");
                                    tcAssocID.Style.Add("border-bottom", "1px dotted #FBFBEF");
                                    tcAssocID.Style.Add("vertical-align", "center");
                                    tcAssocID.Height = Unit.Parse("15");

                                    tcAssocID.Controls.Add(ddlAssocID);

                                    AssocRowReady = true;
                                    tblPrincipal.Rows.Add(tableRow);

                                    tableRowAssocID.Cells.Add(tcAssocIDLabel);
                                    tableRowAssocID.Cells.Add(tcAssocID);
                                    tblPrincipal.Rows.Add(tableRowAssocID);
                                }
                            }

                            break;
                        #endregion

                        #region CHECK DROPDOWN LIST
                        case "CHECKDROPDOWNLIST":

                            HtmlTable table = new HtmlTable();
                            HtmlTableRow row = new HtmlTableRow();
                            HtmlTableCell cell_1 = new HtmlTableCell();
                            HtmlTableCell cell_2 = new HtmlTableCell();
                            table.Style.Add("valign", "middle");
                            table.Attributes.Add("border-collapse", "collapse");
                            row.Style.Add("height", "15px");
                            row.Style.Add("width", "100%");
                            cell_1.Style.Add("width", "95%");
                            cell_2.Style.Add("width", "5%");
                            cell_2.Style.Add("min-width", "82px");

                            DropDownList checkDropDownList = new DropDownList();
                            checkDropDownList.ID = codeName;
                            checkDropDownList.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            string spText2 = control.MetodoServicioWeb;
                            AssocRowReady = false;

                            if (String.IsNullOrEmpty(spText2))
                            {
                                checkDropDownList.Items.Add(new ListItem("No hay Datos", "-1"));
                                flag = 0; //NO HAY ITEMS
                            }
                            else
                            {
                                flag = 1; //EXISTEN ITEMS
                                checkDropDownList.Items.Clear();

                                //BUSQUEDA DE LOS VALORES DE FILTRO PARA LOS COMBOS DEPENDIENTES
                                if (((Control)tblPrincipal.FindControl(control.NombrePropiedadAsociada)) != null)
                                {
                                    filtro = ((DropDownList)tblPrincipal.FindControl(control.NombrePropiedadAsociada)).SelectedValue;
                                }
                                else
                                {
                                    filtro = control.ValorServicioWeb;
                                }

                                checkDropDownList.DataSource = LlenarDropDownList(spText2, filtro);
                                checkDropDownList.DataTextField = "Texto";
                                checkDropDownList.DataValueField = "Valor";
                                checkDropDownList.DataBind();

                                //ESTABLE EL VALOR POR DEFECTO DEL CONTROL
                                if (!string.IsNullOrEmpty(control.IndValorDefecto))
                                {
                                    if (bool.Parse(control.IndValorDefecto))
                                    {
                                        for (int i = 0; i < checkDropDownList.Items.Count; i++)
                                        {
                                            if (checkDropDownList.Items[i].Text.Equals(control.IndValorDefecto))
                                                checkDropDownList.SelectedIndex = i;
                                        }
                                    }
                                }

                                ddlValorSeleccionado = checkDropDownList.SelectedValue.ToString(); //SE ASIGNA EL ELEMENTO SELECCIONADO POR DEFECTO
                            }

                            checkDropDownList.ToolTip = String.Concat("Lista de ", control.DesColumna);
                            checkDropDownList.Enabled = bool.Parse(control.IndModificar);
                            checkDropDownList.Visible = bool.Parse(control.IndVisible);
                            checkDropDownList.CssClass = control.CssTipo;
                            checkDropDownList.Width = Unit.Parse("100%");
                            //checkDropDownList.Style.Add("width", controlWidth);

                            //EVENTO DE LA LISTA PADRE PARA EL MANEJO DE LISTAS ANIDADAS
                            checkDropDownList.AutoPostBack = true;
                            checkDropDownList.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);

                            cell_1.Controls.Add(checkDropDownList);

                            #region CHECKBOX
                            CheckBox check = new CheckBox();
                            check.ID = string.Concat("chk", codeName);
                            check.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            check.Text = "No Aplica";
                            check.Visible = true;
                            check.AutoPostBack = true;
                            check.CheckedChanged += new EventHandler(check_CheckedChanged);

                            cell_2.Controls.Add(check);
                            #endregion

                            row.Cells.Add(cell_1);
                            row.Cells.Add(cell_2);
                            table.Rows.Add(row);
                            //_controlRetorno.Add(table);
                            tc2.Controls.Add(table);

                            break;
                        #endregion

                        #region CALENDAR EXTENDER
                        case "CALENDAREXTENDER":
                            //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES DEL CALENDARIO QUEDEN ALINEADOS
                            HtmlTable calendarTable = new HtmlTable();
                            HtmlTableRow calendarRow = new HtmlTableRow();
                            HtmlTableCell calendarCell_1 = new HtmlTableCell();
                            HtmlTableCell calendarCell_2 = new HtmlTableCell();
                            calendarTable.Style.Add("valign", "middle");
                            calendarTable.Attributes.Add("border-collapse", "collapse");

                            //CALENDARIO QUE ALMACENA LA FECHA
                            TextBox textBoxCalendar = new TextBox();
                            textBoxCalendar.ID = codeName;
                            textBoxCalendar.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            textBoxCalendar.Text = string.Empty;
                            textBoxCalendar.ToolTip = String.Concat("Calendario ", control.DesColumna);
                            textBoxCalendar.Enabled = bool.Parse(control.IndModificar);
                            textBoxCalendar.Visible = bool.Parse(control.IndVisible);
                            textBoxCalendar.Attributes.Add("readonly", "readonly");
                            textBoxCalendar.CssClass = control.CssTipo;

                            //SE ASIGNA EL TEXTBOX EN LA PRIMER CELDA
                            calendarCell_1.Controls.Add(textBoxCalendar);

                            //BOTON CON LA IMAGEN DEL CALENDARIO
                            ImageButton imgbuttonCalendar = new ImageButton();
                            imgbuttonCalendar.ID = String.Concat("imgBtnCalendarExtender", codeName);
                            imgbuttonCalendar.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            imgbuttonCalendar.ToolTip = "Click para abrir el Calendario";
                            imgbuttonCalendar.ImageUrl = ("~/Library/img/32/iconCalendario.gif");
                            imgbuttonCalendar.Enabled = bool.Parse(control.IndModificar);
                            imgbuttonCalendar.Visible = bool.Parse(control.IndVisible);
                            imgbuttonCalendar.CausesValidation = false;
                            tc2.VerticalAlign = VerticalAlign.Top;

                            //SE ASIGNA LA IMAGEN DEL CALENDARIO EN LA SEGUNDA CELDA                            
                            calendarCell_2.Controls.Add(imgbuttonCalendar);

                            #region CALENDAR EXTENDER
                            //CONTROL CALENDARIO
                            calendarExtender = new CalendarExtender();
                            calendarExtender.ID = String.Concat("calendarExtender", codeName);
                            calendarExtender.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            calendarExtender.TargetControlID = textBoxCalendar.ID;
                            calendarExtender.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();
                            calendarExtender.PopupPosition = CalendarPosition.Right;
                            calendarExtender.PopupButtonID = imgbuttonCalendar.ID;
                            calendarExtender.Enabled = bool.Parse(control.IndModificar);
                            #endregion

                            #region REQUIREDFIELDVALIDATOR

                            if (control.IndRequerido.Equals("True"))
                            {
                                rfv = new RequiredFieldValidator();
                                rfv.ID = String.Concat("rfv", codeName);
                                rfv.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                                rfv.ControlToValidate = textBoxCalendar.ID;
                                rfv.ErrorMessage = "Required";
                                rfv.Display = ValidatorDisplay.Dynamic;
                                rfv.Text = " * ";
                                rfv.CssClass = "labelTabError";
                            }

                            //calendarCell_2.Controls.Add(rfv);
                            #endregion

                            //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                            calendarRow.Cells.Add(calendarCell_1);
                            calendarRow.Cells.Add(calendarCell_2);
                            calendarTable.Rows.Add(calendarRow);
                            tc2.Controls.Add(calendarTable);

                            break;
                        #endregion

                        #region HIDDEN FIELD
                        case "HIDDENFIELD":

                            HiddenField hiddenField = new HiddenField();
                            hiddenField.ID = codeName;
                            hiddenField.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            hiddenField.Value = string.Empty;
                            hiddenField.Visible = true;

                            tc2.Controls.Add(hiddenField);

                            break;
                        #endregion

                        #region IMAGE BUTTON
                        case "IMAGE BUTTON":

                            ImageButton imageButton = new ImageButton();
                            imageButton.ID = codeName;
                            imageButton.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            imageButton.ToolTip = String.Concat("Botón ", control.DesColumna);
                            imageButton.Enabled = bool.Parse(control.IndModificar);
                            imageButton.Visible = bool.Parse(control.IndVisible);
                            imageButton.CssClass = control.CssTipo;
                            imageButton.ImageUrl = string.Empty;
                            tc2.Controls.Add(imageButton);

                            break;
                        #endregion

                        #region SEARCHBOX
                        case "SEARCHBOX":

                            //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES QUEDEN ALINEADOS
                            HtmlTable sTable = new HtmlTable();
                            HtmlTableRow sRow = new HtmlTableRow();
                            HtmlTableCell sCell_1 = new HtmlTableCell();
                            HtmlTableCell sCell_2 = new HtmlTableCell();
                            sTable.Style.Add("valign", "middle");
                            sTable.Attributes.Add("border-collapse", "collapse");

                            /*sRow.Style.Add("height", "15px");
                            sRow.Style.Add("width", "100%");
                            sCell_1.Style.Add("width", "97%");
                            sCell_2.Style.Add("width", "3%");
                            sCell_2.Style.Add("min-width", "18px");*/

                            //CONTROL PARA LA BUSQUEDA
                            TextBox textBoxAD = new TextBox();
                            textBoxAD.ID = codeName;
                            textBoxAD.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            textBoxAD.Text = string.Empty;
                            textBoxAD.MaxLength = Int32.Parse(control.LongitudMaxima);
                            textBoxAD.ToolTip = String.Concat("Texto ", control.DesColumna);
                            textBoxAD.Enabled = bool.Parse(control.IndModificar);
                            textBoxAD.Visible = bool.Parse(control.IndVisible);
                            textBoxAD.CssClass = control.CssTipo;

                            //textBoxAD.Style.Add("width", controlWidth);

                            #region MASKEDEDITEXTENDER

                            int m4 = Int32.Parse(control.Mascara);

                            if (m4 > 0)
                            {
                                int m3 = Int32.Parse(control.LongitudMaxima);

                                mask = new MaskedEditExtender();
                                mask.ID = String.Concat("mask", codeName);
                                mask.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                                mask.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();
                                mask.ClearTextOnInvalid = true;
                                mask.ClearMaskOnLostFocus = true;
                                mask.AutoComplete = false;

                                mask.MaskType = generadorControles.DeterminaTipoMascara(m4);
                                mask.InputDirection = MaskedEditInputDirection.LeftToRight;
                                mask.Mask = generadorControles.DeterminaFormatoMascara(m3, control.ValorMascara);

                                mask.TargetControlID = textBoxAD.ID;
                            }
                            #endregion

                            //SE ASIGNA EL TEXTBOX EN LA PRIMER CELDA
                            sCell_1.Controls.Add(textBoxAD);

                            #region SEARCH IMAGE

                            //BOTON CON LA IMAGEN DEL CONTROL
                            ImageButton imgCmdBuscar = new ImageButton();
                            imgCmdBuscar.ID = String.Concat("imgCmd", codeName);
                            imgCmdBuscar.ToolTip = "Click para ejecutar la búsqueda.";
                            imgCmdBuscar.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            imgCmdBuscar.ImageUrl = ("~/Library/img/16/iconConsultaSol.gif");
                            imgCmdBuscar.Enabled = bool.Parse(control.IndModificar);
                            imgCmdBuscar.Visible = bool.Parse(control.IndVisible);
                            imgCmdBuscar.Click += new ImageClickEventHandler(btnBuscar_Click);
                            imgCmdBuscar.CausesValidation = false;
                            //tc2.VerticalAlign = VerticalAlign.Top;

                            //SE ASIGNA LA IMAGEN EN LA SEGUNDA CELDA
                            sCell_2.Controls.Add(imgCmdBuscar);

                            #endregion

                            //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                            sRow.Cells.Add(sCell_1);
                            sRow.Cells.Add(sCell_2);
                            sTable.Rows.Add(sRow);
                            tc2.Controls.Add(sTable);

                            break;
                        #endregion

                        #region CUSTOM_ISIN
                        case "CUSTOM_ISIN":
                            //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES DEL CONTROL
                            HtmlTable validatorTable = new HtmlTable();
                            HtmlTableRow validatorRow = new HtmlTableRow();
                            HtmlTableCell validatorCell_1 = new HtmlTableCell();
                            HtmlTableCell validatorCell_2 = new HtmlTableCell();
                            validatorTable.Style.Add("valign", "middle");
                            validatorTable.Attributes.Add("border-collapse", "collapse");

                            #region ISIN DEFAULT

                            DropDownList dropDownISIN = new DropDownList();
                            dropDownISIN.ID = String.Concat(codeName, "1");
                            dropDownISIN.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            string spTextISIN = "DefaultLista";

                            if (spTextISIN.Equals("DefaultLista"))
                            {
                                dropDownISIN.Items.Clear();
                                dropDownISIN.Items.Insert(0, new ListItem("SI", "true"));
                                dropDownISIN.Items.Insert(1, new ListItem("NO", "false"));
                            }

                            dropDownISIN.ToolTip = String.Concat("Lista de ", control.DesColumna);
                            dropDownISIN.Enabled = bool.Parse(control.IndModificar);
                            dropDownISIN.Visible = bool.Parse(control.IndVisible);
                            dropDownISIN.CssClass = control.CssTipo;
                            dropDownISIN.Width = Unit.Parse("40");

                            #endregion

                            //SE ASIGNA EL DROPDOWNLIST DEFAULT EN LA SEGUNDA CELDA
                            validatorCell_1.Controls.Add(dropDownISIN);
                            validatorCell_1.Width = "45px";

                            #region ISIN COMPLETO

                            DropDownList dropDownISIN_1 = new DropDownList();
                            dropDownISIN_1.ID = codeName;
                            dropDownISIN_1.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            string spTextISIN_1 = control.MetodoServicioWeb;
                            AssocRowReady = false;

                            if (String.IsNullOrEmpty(spTextISIN_1))
                            {
                                dropDownISIN_1.Items.Add(new ListItem("No hay Datos", "-1"));
                                flag = 0; //NO HAY ITEMS
                            }
                            else
                            {
                                flag = 1; //EXISTEN ITEMS
                                LimpiarDropDownList(dropDownISIN_1);

                                //BUSQUEDA DE LOS VALORES DE FILTRO PARA LOS COMBOS DEPENDIENTES
                                if (((Control)tblPrincipal.FindControl(control.NombrePropiedadAsociada)) != null)
                                {
                                    filtro = ((DropDownList)tblPrincipal.FindControl(control.NombrePropiedadAsociada)).SelectedValue;
                                }
                                else
                                {
                                    filtro = control.ValorServicioWeb;
                                }

                                //GENERA EL FILTRO PARA CARGAR EL ISIN
                                CargarFiltroISIN(tblPrincipal, control);

                                dropDownISIN_1.DataSource = LlenarDropDownList(spTextISIN_1, filtro);
                                dropDownISIN_1.DataTextField = "Texto";
                                dropDownISIN_1.DataValueField = "Valor";
                                dropDownISIN_1.DataBind();
                                if (!string.IsNullOrEmpty(control.IndValorDefecto))
                                {
                                    if (bool.Parse(control.IndValorDefecto))
                                    {
                                        for (int i = 0; i < dropDownISIN_1.Items.Count; i++)
                                        {
                                            if (dropDownISIN_1.Items[i].Text.Equals(control.IndValorDefecto))
                                                dropDownISIN_1.SelectedIndex = i;
                                        }
                                    }
                                }
                                ddlValorSeleccionado = dropDownISIN_1.SelectedValue.ToString(); //SE ASIGNA EL ELEMENTO SELECCIONADO POR DEFECTO
                            }

                            dropDownISIN_1.ToolTip = String.Concat("Lista de ", control.DesColumna);
                            dropDownISIN_1.Enabled = !bool.Parse(control.IndModificar);
                            dropDownISIN_1.Visible = bool.Parse(control.IndVisible);
                            dropDownISIN_1.CssClass = control.CssTipo;
                            dropDownISIN_1.Width = Unit.Parse("100%");

                            //EVENTO DE LA LISTA PADRE PARA EL MANEJO DE LISTAS ANIDADAS
                            dropDownISIN_1.AutoPostBack = true;
                            dropDownISIN_1.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);

                            #endregion

                            //SE ASIGNA EL DROPDOWNLIST EN LA SEGUNDA CELDA
                            validatorCell_2.Controls.Add(dropDownISIN_1);
                            validatorCell_2.Width = "200px";

                            //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                            validatorRow.Cells.Add(validatorCell_1);
                            validatorRow.Cells.Add(validatorCell_2);
                            validatorTable.Rows.Add(validatorRow);
                            tc2.Controls.Add(validatorTable);

                            break;
                        #endregion

                        #region CUSTOM_GARANTIA
                        case "CUSTOM_GARANTIA":

                            //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES QUEDEN ALINEADOS
                            HtmlTable searchTable = new HtmlTable();
                            HtmlTableRow searchRow = new HtmlTableRow();
                            HtmlTableCell searchCell_1 = new HtmlTableCell();
                            HtmlTableCell searchCell_2 = new HtmlTableCell();
                            searchTable.Style.Add("valign", "middle");
                            searchTable.Attributes.Add("border-collapse", "collapse");

                            #region TEXTBOX CONTROL

                            //CONTROL PARA LA BUSQUEDA DE ID GARANTIA
                            TextBox textBoxGar = new TextBox();
                            textBoxGar.ID = codeName;
                            textBoxGar.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            textBoxGar.Text = string.Empty;
                            textBoxGar.MaxLength = Int32.Parse(control.LongitudMaxima);
                            textBoxGar.ToolTip = String.Concat("Texto ", control.DesColumna);
                            textBoxGar.Enabled = bool.Parse(control.IndModificar);
                            textBoxGar.Visible = bool.Parse(control.IndVisible);
                            textBoxGar.CssClass = control.CssTipo;

                            if (!String.IsNullOrEmpty(control.GrupoValidacion))
                            {
                                textBoxGar.ValidationGroup = control.GrupoValidacion;
                            }

                            if (textBoxGar.MaxLength > 50)
                            {
                                _width = 400;
                            }
                            else
                            {
                                _width = (textBoxGar.MaxLength * 8);
                            }
                            textBoxGar.Width = _width;

                            #endregion

                            //SE ASIGNA EL TEXTBOX EN LA PRIMER CELDA
                            searchCell_1.Controls.Add(textBoxGar);

                            #region REQUIRED FIELD VALIDATOR

                            if (control.IndRequerido.Equals("True"))
                            {
                                rfv = new RequiredFieldValidator();
                                rfv.ID = String.Concat("rfv", codeName);
                                rfv.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                                rfv.ControlToValidate = textBoxGar.ID;
                                rfv.ErrorMessage = "Required";
                                rfv.Display = ValidatorDisplay.Dynamic;
                                rfv.Text = " * ";
                                rfv.CssClass = "labelTabError";
                            }

                            #endregion

                            #region SEARCH IMAGE

                            //BOTON CON LA IMAGEN DEL CONTROL
                            Button imgCmdBuscarGarantia = new Button();
                            imgCmdBuscarGarantia.ID = String.Concat("imgCmd", codeName);
                            imgCmdBuscarGarantia.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            imgCmdBuscarGarantia.ToolTip = "Click para ejecutar la búsqueda.";
                            imgCmdBuscarGarantia.CssClass = "imgCmdBuscarGarantia";
                            imgCmdBuscarGarantia.Enabled = bool.Parse(control.IndModificar);
                            imgCmdBuscarGarantia.Visible = false;
                            imgCmdBuscarGarantia.Click += new EventHandler(btnBuscar_Click);
                            imgCmdBuscarGarantia.CausesValidation = false;
                            tc2.VerticalAlign = VerticalAlign.Top;

                            #endregion

                            //SE ASIGNA LA IMAGEN EN LA SEGUNDA CELDA
                            searchCell_2.Controls.Add(imgCmdBuscarGarantia);
                            //searchCell_2.Controls.Add(rfv);

                            //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                            searchRow.Cells.Add(searchCell_1);
                            searchRow.Cells.Add(searchCell_2);
                            searchTable.Rows.Add(searchRow);
                            tc2.Controls.Add(searchTable);

                            break;
                        #endregion

                    }

                    #endregion

                    if (!Tipo_Contenido.Equals("AREA") && !Tipo_Contenido.Equals("GRIDVIEW"))
                    {
                        //AGREGA LA CELDA1 AL TABLE ROW
                        tableRow.Cells.Add(tc1);
                        //AGREGA LA CELDA2 A LA FILA
                        tableRow.Cells.Add(tc2);
                    }

                    //OCULTA EL ROW PARA LOS CONTROLES HIDDENFIELDS
                    if (Tipo_Contenido.Equals("HIDDENFIELD"))
                    {
                        tableRow.Attributes.Add("style", "display:none");
                    }

                    //CELDA PARA EL CONTROL REQUIRED FIELD VALIDATOR
                    TableCell tc3 = new TableCell();

                    if (Tipo_Contenido.Equals("DROPDOWNLIST"))
                    {
                        Label hdnLabel = new Label();
                        hdnLabel.ID = String.Concat("hiddenLabel", rowCount);
                        hdnLabel.Text = String.Empty;
                        hdnLabel.Enabled = false;
                        hdnLabel.Visible = false;

                        tc3.Controls.Add(hdnLabel);
                    }
                    else
                    {
                        if (Tipo_Contenido.Equals("TEXTBOX") || Tipo_Contenido.Equals("SEARCHBOX") || Tipo_Contenido.Equals("CUSTOM_GARANTIA"))
                        {
                            if (mask != null)
                            {
                                tc3.Controls.Add(mask);
                            }
                            if (control.IndRequerido.Equals("True"))
                            {
                                tc3.Controls.Add(rfv);
                            }
                        }
                        else
                        {
                            if (Tipo_Contenido.Equals("CALENDAREXTENDER"))
                            {
                                if (calendarExtender != null)
                                {
                                    tc3.Controls.Add(calendarExtender);
                                }
                                if (control.IndRequerido.Equals("True"))
                                {
                                    tc3.Controls.Add(rfv);
                                }
                            }
                        }
                    }

                    //tc3.Width = Unit.Parse("150");
                    tc3.Width = Unit.Parse("40");
                    tc3.HorizontalAlign = HorizontalAlign.Left;
                    tc3.Height = Unit.Parse("15");

                    //AGREGA LA CELDA3 A LA FILA
                    tableRow.Cells.Add(tc3);

                    if (!AssocRowReady)
                    {
                        tblPrincipal.Rows.Add(tableRow);
                    }

                    rowCount++;
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargaArregloControles()
    {
        try
        {
            if (pantallaCodOculto.Value.Length > 0)
            {
                ListasWS.PantallasEntidad pantalla = new ListasWS.PantallasEntidad();
                pantalla.CodPantalla = int.Parse(pantallaCodOculto.Value);
                pantalla.Pestana = string.Empty;

                //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD        
                controlEntidad = this.wsLista.AdministracionesContenidosConsultaControl(pantalla).ToList();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*RETORNA UN CONTROL DE UN SET DE CONTROLES*/
    private ControlEntidad ControlesBuscar(string nombreControl)
    {
        try
        {
            CargaArregloControles();

            nombreControl = nombreControl.Replace("txt", "").Replace("ddl", "").Replace("imb", "").Replace("lbl", "").Replace("btn", "").Replace("chk", "");
            ControlEntidad _control = (from control in controlEntidad
                                       where control.NombrePropiedad.Equals(nombreControl)
                                       select control).First();

            return _control;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region METODOS CONTROLES

    #region METODOS CHEKBOX

    protected void check_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = ((CheckBox)(sender));
            switch (chk.ID.ToUpper())
            {
                #region CHK ESTADO HORIZONTAL
                case "CHKIDCODIGOHORIZONTALIDAD":
                    chkHorizontal();
                    break;
                #endregion

                #region CHK ESTADO DUPLICADO
                case "CHKIDCODIGODUPLICADO":
                    chkDuplicado();
                    break;
                #endregion
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    private void chkHorizontal()
    {
        try
        {
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int codPantalla = int.Parse(this.pantallaCodOculto.Value);

                #region GARANTIAS REALES
                //REQIERIMIENTO 1-24493287
                if (codPantalla.Equals(178) || codPantalla.Equals(183))
                {
                    #region BUSQUEDA CONTROLES

                    DropDownList ddlHorizontal = null;
                    ddlHorizontal = (DropDownList)this.tableData.FindControl("IdCodigoHorizontalidad");

                    CheckBox chkEstadoHorizontal = null;
                    chkEstadoHorizontal = (CheckBox)this.tableData.FindControl("chkIdCodigoHorizontalidad");

                    #endregion

                    if (chkEstadoHorizontal.Checked)
                    {
                        AdministrarBlanco(ddlHorizontal.ID, true);
                        ddlHorizontal.Enabled = false;
                    }
                    else
                    {
                        AdministrarBlanco(ddlHorizontal.ID, false);
                        ddlHorizontal.Enabled = true;
                    }
                }
                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void chkDuplicado()
    {
        try
        {
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int codPantalla = int.Parse(this.pantallaCodOculto.Value);

                #region GARANTIAS REALES
                //REQIERIMIENTO 1-24493287
                if (codPantalla.Equals(178) || codPantalla.Equals(183))
                {
                    #region BUSQUEDA CONTROLES

                    DropDownList ddlDuplicado = null;
                    ddlDuplicado = (DropDownList)this.tableData.FindControl("IdCodigoDuplicado");

                    CheckBox chkEstadoDuplicado = null;
                    chkEstadoDuplicado = (CheckBox)this.tableData.FindControl("chkIdCodigoDuplicado");

                    #endregion

                    if (chkEstadoDuplicado.Checked)
                    {
                        AdministrarBlanco(ddlDuplicado.ID, true);
                        ddlDuplicado.Enabled = false;
                    }
                    else
                    {
                        AdministrarBlanco(ddlDuplicado.ID, false);
                        ddlDuplicado.Enabled = true;
                    }
                }
                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region METODOS BOTON BUSCAR

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                //SI NO EXISTEN ERRORES DE VALIDACION
                if (!ExisteErrorBuscar())
                {
                    if (pantallaCodOculto.Value.Length > 0)
                    {
                        int _codPantalla = int.Parse(pantallaCodOculto.Value);

                        switch (_codPantalla)
                        {
                            case 178:
                            case 183:
                                BuscarClaseVehiculo();
                                break;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #region BUSCAR CLASE VEHICULO

    /*REALIZA EL BIND EN EL GRIDVIEW EMERGENTE*/
    private void BuscarClaseVehiculo()
    {
        try
        {
            #region BUSQUEDA CONTROLES

            TextBox txtClaseVehiculo = null;
            txtClaseVehiculo = (TextBox)this.tableData.FindControl("CodClaseVehiculo");

            #endregion

            if (txtClaseVehiculo != null)
            {
                ((wucGridEmergente)this.BusquedaClaseVehiculo).BindGridView(this.ConsultaClaseVehiculo(txtClaseVehiculo.Text));
                this.mpeBusquedaClaseVehiculo.Show();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #endregion

    #endregion

    #region METODOS DDL

    private Object LlenarDropDownList(string wsMethodName, string filtro)
    {
        try
        {
            Type ws = wsLista.GetType();
            MethodInfo method = ws.GetMethod(wsMethodName);
            var result = method.Invoke(wsLista, new object[] { filtro });

            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EVENTO CAMBIO DE INDICE DDL*/
    protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string controlPostBack = Page.Request.Params["__EVENTTARGET"];

            string idDropDownList = ((DropDownList)(sender)).ID.ToString().ToUpper();

            //SEGUN EL NOMBRE DEL DDL SE REDIRECCIONA A METODO DEL EVENTO
            switch (idDropDownList)
            {
                case "IDCLASE":
                    ddlClases();
                    break;
                case "IDEMISOR":
                    ddlEmisor();
                    break;
                case "IDFORMATOIDENTIFICACIONVEHICULO":
                    ddlFormatoIdentificacionVehiculo();
                    break;
                case "IDINSTRUMENTO":
                    ddlInstrumento();
                    break;
                case "IDTIPOBIEN":
                    ddlTiposBienes();
                    break;
                case "IDTIPOINSTRUMENTO":
                    ddlTipoInstrumento();
                    break;
                case "IDTIPOVALOR":
                    ddlTipoValor();
                    break;
                case "ISIN":
                    ddlISIN();
                    break;
                case "TIPOIDENTIFICACIONRUC":
                    ddlTipoIdentificacionRUC();
                    break;
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*ELIMINA TODOS LOS VALORES DEL DDL*/
    private void LimpiarDropDownList(DropDownList _dropDownList)
    {
        //BORRA LOS VALORES DEL DDL, SE DEBE DE REALIZAR DE ESTA MANERA PARA ELIMINAR LOS DATOS EN CACHÉ DEL OBJ
        if (_dropDownList != null)
        {
            _dropDownList.ClearSelection();
            _dropDownList.Items.Clear();
            _dropDownList.SelectedValue = null;
            _dropDownList.DataSource = null;
        }
    }

    /*AGREGA O ELIMINA UN ITEM EN BLANCO*/
    private void AdministrarBlanco(string ddlNombre, bool agregar)
    {
        try
        {
            bool existeBlanco = false;
            int posicion = 0;
            DropDownList ddl = (DropDownList)this.tableData.FindControl(ddlNombre);

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

                if (existeBlanco && agregar)
                    ddl.SelectedValue = "-1";

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

    #region CLASE BIEN

    private void ddlClases()
    {
        try
        {
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int codPantalla = int.Parse(this.pantallaCodOculto.Value);

                #region GARANTIAS REALES

                #region BUSQUEDA CONTROLES

                DropDownList ddlTipoBien = null;
                DropDownList ddlClase = null;
                DropDownList ddlFormato = null;
                ddlTipoBien = (DropDownList)this.tableData.FindControl("IdTipoBien");
                ddlClase = (DropDownList)this.tableData.FindControl("IdClase");
                ddlFormato = (DropDownList)this.tableData.FindControl("IdFormatoIdentificacionVehiculo");

                TextBox txtClaseVehiculo = null;
                TextBox txtDesClaseVehiculo = null;
                txtClaseVehiculo = (TextBox)this.tableData.FindControl("CodClaseVehiculo");
                txtDesClaseVehiculo = (TextBox)this.tableData.FindControl("DesClaseVehiculo");

                ImageButton btnClaseVehiculo = null;
                btnClaseVehiculo = (ImageButton)this.tableData.FindControl("imgCmdCodClaseVehiculo");

                HiddenField hdnIdClaseVehiculo = null;
                hdnIdClaseVehiculo = (HiddenField)this.tableData.FindControl("IdClaseVehiculo");

                RequiredFieldValidator rfvDesClaseVehiculo = null;
                rfvDesClaseVehiculo = (RequiredFieldValidator)this.tableData.FindControl("rfvDesClaseVehiculo");

                #endregion

                //SI EL TIPO DE BIEN ES IGUAL A 3 Y LA CLASE TIPO BIEN ES IGUAL A BONO PRENDA
                if (ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -") && ddlClase.SelectedItem.Text.ToUpper().Equals("BONO DE PRENDA"))
                {
                    txtClaseVehiculo.Text = string.Empty;
                    txtDesClaseVehiculo.Text = string.Empty;
                    hdnIdClaseVehiculo.Value = string.Empty;

                    txtClaseVehiculo.Enabled = false;
                    btnClaseVehiculo.Enabled = false;
                    rfvDesClaseVehiculo.Enabled = false;

                    generadorControles.SeleccionarOpcionDropDownListTexto(ddlFormato, "Numérico 6 enteros");
                    ddlFormato.Enabled = false;
                }
                //SI EL TIPO DE BIEN ES IGUAL A 3 Y LA CLASE TIPO BIEN ES DIFERENTE A BONO PRENDA
                if (ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -") && !ddlClase.SelectedItem.Text.ToUpper().Equals("BONO DE PRENDA"))
                {
                    txtClaseVehiculo.Text = string.Empty;
                    txtDesClaseVehiculo.Text = string.Empty;
                    hdnIdClaseVehiculo.Value = string.Empty;

                    txtClaseVehiculo.Enabled = true;
                    btnClaseVehiculo.Enabled = true;
                    rfvDesClaseVehiculo.Enabled = true;

                    ddlFormato.Enabled = true;
                }

                #endregion
                
                ddlFormatoIdentificacionVehiculo();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarClases(string valorFiltro)
    {
        try
        {
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int codPantalla = int.Parse(this.pantallaCodOculto.Value);

                #region GARANTIAS REALES
                //REQIERIMIENTO 1-24493287
                if (codPantalla.Equals(178) || codPantalla.Equals(183))
                {
                    #region BUSQUEDA CONTROLES

                    DropDownList ddlClase = null;
                    DropDownList ddlTipoBien = null;
                    ddlClase = (DropDownList)this.tableData.FindControl("IdClase");
                    ddlTipoBien = (DropDownList)this.tableData.FindControl("IdTipoBien");

                    #endregion

                    //DDL CLASES            
                    generadorControles.LimpiarDropDownList(ddlClase);
                    controlSeleccionado = ControlesBuscar(ddlClase.ID);

                    ddlClase.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, valorFiltro);
                    ddlClase.DataTextField = "Texto";
                    ddlClase.DataValueField = "Valor";
                    ddlClase.DataBind();
                    ddlClase.CssClass = controlSeleccionado.CssTipo;
                    string[] valorDefecto = controlSeleccionado.ValorDefecto.Split('|');

                    if (ddlClase.Items.Count < 1)
                    {
                        ddlClase.Items.Clear();
                        ddlClase.SelectedValue = null;
                        AdministrarBlanco(ddlClase.ID, true);
                        ddlClase.Enabled = false;
                    }
                    else
                    {
                        if (ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("1 -") || ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                        {
                            ddlClase.Enabled = true;
                            generadorControles.SeleccionarOpcionDropDownListTexto(ddlClase, valorDefecto[0]);
                        }
                        else
                        {
                            if (ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
                            {
                                ddlClase.Enabled = true;
                                generadorControles.SeleccionarOpcionDropDownListTexto(ddlClase, valorDefecto[1]);
                            }
                        }
                    }
                }
                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region EMISORES

    /*CARGA EMISOR PARA RPT GARANTIAS VALORES ESPECIFICAS*/
    private void CargarEmisor(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));

            #endregion

            LimpiarDropDownList(ddlEmisor);
            if (ddlEmisor != null)
            {
                ddlEmisor.Items.Clear();
                ddlEmisor.DataSource = LlenarDropDownList("EmisionesInstrumentosEmisorLista", ((DropDownList)(sender)).SelectedValue.ToString());
                ddlEmisor.DataTextField = "Texto";
                ddlEmisor.DataValueField = "Valor";
                ddlEmisor.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA EMISOR PARA RPT GARANTIAS VALORES ESPECIFICAS*/
    private void CargarOtrosEmisores()
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));

            #endregion

            LimpiarDropDownList(ddlEmisor);
            if (ddlEmisor != null)
            {
                ddlEmisor.Items.Clear();
                ddlEmisor.DataSource = LlenarDropDownList("EmisoresLista", string.Empty);
                ddlEmisor.DataTextField = "Texto";
                ddlEmisor.DataValueField = "Valor";
                ddlEmisor.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlEmisor()
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));
            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
            DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));
            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("Serie"));

            #endregion

            switch (ValorTipoValor())
            {
                case 1:
                    CargarISIN(ddlEmisor, ddlInstrumento);
                    CargarSerie(ddlInstrumento, ddlEmisor, ddlISIN);
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region FORMATO IDENTIFICACION VEHICULO

    private void CargarFormatoIdentificacionVehiculo(string valorFiltro)
    {
        try
        {
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int codPantalla = int.Parse(this.pantallaCodOculto.Value);

                #region GARANTIAS REALES
                //REQIERIMIENTO 1-24493287
                if (codPantalla.Equals(178) || codPantalla.Equals(183))
                {
                    #region BUSQUEDA CONTROLES

                    DropDownList ddlFormato = null;
                    ddlFormato = (DropDownList)this.tableData.FindControl("IdFormatoIdentificacionVehiculo");

                    #endregion

                    if (ddlFormato != null)
                    {
                        if (valorFiltro.Substring(0, 3).Equals("3 -"))
                        {

                            ddlFormato.Items.Clear();
                            ddlFormato.SelectedValue = null;
                            ddlFormato.Items.Add(new ListItem("Numérico 6 enteros", "1"));
                            ddlFormato.Items.Add(new ListItem("Alfanumérico 3 letras y 3 enteros", "2"));
                            ddlFormato.Items.Add(new ListItem("Alfanumérico 17 caracteres", "3"));
                            ddlFormato.SelectedIndex = 0;
                            ddlFormato.Enabled = true;
                        }
                        else
                        {
                            ddlFormato.Items.Clear();
                            ddlFormato.SelectedValue = null;
                            AdministrarBlanco("IdFormatoIdentificacionVehiculo", true);
                            ddlFormato.Enabled = false;
                        }
                    }
                }

                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlFormatoIdentificacionVehiculo()
    {
        try
        {
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int codPantalla = int.Parse(this.pantallaCodOculto.Value);

                #region GARANTIAS REALES
                //REQIERIMIENTO 1-24493287
                if (codPantalla.Equals(178) || codPantalla.Equals(183))
                {
                    #region BUSQUEDA CONTROLES

                    TextBox txtNBien = null;
                    txtNBien = (TextBox)this.tableData.FindControl("NBien");

                    DropDownList ddlFormato = null;
                    ddlFormato = (DropDownList)this.tableData.FindControl("IdFormatoIdentificacionVehiculo");

                    #endregion

                    //EFECTO DE NUMERO DE BIEN [CONSTANTES]
                    txtNBien.Text = string.Empty;

                    if (ddlFormato.SelectedItem.Text.Equals("Alfanumérico 17 caracteres"))
                    {
                        //EFECTO DE NUMERO DE BIEN
                        txtNBien.MaxLength = 17;
                        txtNBien.ToolTip = "Alfanumérico de 17 caracteres";
                    }
                    else
                    {
                        //EFECTO DE NUMERO DE BIEN
                        txtNBien.MaxLength = 6;

                        if (ddlFormato.SelectedItem.Text.Equals("Alfanumérico 3 letras y 3 enteros"))
                            //EFECTO DE NUMERO DE BIEN
                            txtNBien.ToolTip = "Alfanumérico 3 letras y 3 enteros (XXX999)";
                        else
                            //EFECTO DE NUMERO DE BIEN
                            txtNBien.ToolTip = "Númerico de 6 caracteres";
                    }
                }

                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region INSTRUMENTOS

    /*CARGA EMISOR PARA RPT GARANTIAS VALORES ESPECIFICAS*/
    private void CargarInstrumentosTodos()
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));

            #endregion

            LimpiarDropDownList(ddlInstrumento);
            if (ddlInstrumento != null)
            {
                ddlInstrumento.Items.Clear();
                ddlInstrumento.DataSource = LlenarDropDownList("InstrumentosLista", string.Empty);
                ddlInstrumento.DataTextField = "Texto";
                ddlInstrumento.DataValueField = "Valor";
                ddlInstrumento.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlInstrumento()
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));
            DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
            DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));
            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("Serie"));

            #endregion

            switch (ValorTipoValor())
            {
                case 1:
                    CargarEmisor(ddlInstrumento);
                    CargarISIN(ddlEmisor, ddlInstrumento);
                    CargarSerie(ddlInstrumento, ddlEmisor, ddlISIN);
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region ISIN

    /*CARGA EMISOR PARA RPT GARANTIAS VALORES ESPECIFICAS*/
    private void CargarISIN(DropDownList ddlEmisor, DropDownList ddlInstrumento)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
            DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));

            #endregion

            #region CONTRUIR FILTROS

            StringBuilder filtro = new StringBuilder();
            filtro.Append(ddlInstrumento.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlEmisor.SelectedValue.ToString());

            #endregion

            LimpiarDropDownList(ddlISIN);
            if (ddlISIN != null)
            {
                ddlISIN.Items.Clear();
                ddlISIN.DataSource = LlenarDropDownList("EmisionesInstrumentosISINLista", filtro.ToString());
                ddlISIN.DataTextField = "Texto";
                ddlISIN.DataValueField = "Valor";
                ddlISIN.DataBind();
            }

            if (ddlISIN.Items.Count > 1)
            {
                if (ddlISIN.SelectedValue.Equals("NO") || ddlISIN.SelectedValue.Equals(" ") || ddlISIN.SelectedValue.Length.Equals(0))
                {
                    generadorControles.SeleccionarOpcionDropDownList(ddlISIN1, "false");
                }
                else
                {
                    ddlISIN.Enabled = true;
                    generadorControles.SeleccionarOpcionDropDownList(ddlISIN1, "true");
                }
            }
            else
            {
                if (ddlISIN.SelectedValue.Equals("NO") || ddlISIN.SelectedValue.Equals(" ") || ddlISIN.SelectedValue.Length.Equals(0))
                {
                    ddlISIN.Enabled = false;
                    LimpiarDropDownList(ddlISIN);
                    generadorControles.SeleccionarOpcionDropDownList(ddlISIN1, "false");
                }
                else
                {
                    ddlISIN.Enabled = true;
                    generadorControles.SeleccionarOpcionDropDownList(ddlISIN1, "true");
                }
            }

            switch (ValorTipoValor())
            {
                case 1:
                    CargarSerie(ddlInstrumento, ddlEmisor, ddlISIN);
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA EL FILTRO DEL CODIGO ISIN PARA EL RPT GARANTIAS VALOES ESPECIFICAS*/
    private void CargarFiltroISIN(Table tblPrincipal, ControlEntidad control)
    {
        try
        {
            StringBuilder filtroBuilder = new StringBuilder();
            filtroBuilder.Clear();

            //ESTABLE LA EXCEPCION DEL VALOR DEL FILTRO PARA EL OBJETO IdCategoriaRiesgoEmpresaCalificadora
            if (control.NombrePropiedad.Equals("ISIN"))
            {
                filtro = ((DropDownList)this.tableData.FindControl("IdInstrumento")).SelectedValue;
                filtro += "|";
                filtro += ((DropDownList)this.tableData.FindControl("IdEmisor")).SelectedValue;
            }

            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlIdCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));

            //ESTABLE LA EXCEPCION DEL VALOR DEL FILTRO PARA EL OBJETO IdCategoriaRiesgoEmpresaCalificadora
            if (control.NombrePropiedad.Equals("IdCalificacionEmpresaCalificadora"))
            {
                if (ddlIdEmpresaCalificadora != null)
                    filtroBuilder.Append(ddlIdEmpresaCalificadora.SelectedValue);

                filtroBuilder.Append("|");

                if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                    filtroBuilder.Append(ddlIdCategoriaRiesgoEmpresaCalificadora.SelectedValue);

                filtro = filtroBuilder.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlISIN()
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
            DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));
            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("Serie"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));
            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));

            #endregion

            if (!String.IsNullOrEmpty(ddlISIN.SelectedValue))
            {
                ddlISIN1.SelectedIndex = 0;
            }
            else
            {
                generadorControles.SeleccionarOpcionDropDownListTexto(ddlISIN1, "NO");
            }

            switch (ValorTipoValor())
            {
                case 1:
                    CargarSerie(ddlInstrumento, ddlEmisor, ddlISIN);
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region SERIE

    /*CARGA EMISOR PARA RPT GARANTIAS VALORES ESPECIFICAS*/
    private void CargarSerie(DropDownList ddlInstrumento, DropDownList ddlEmisor, DropDownList ddlISIN)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("Serie"));

            #endregion

            #region CONSTRUIR FILTROS

            StringBuilder filtroBuilder = new StringBuilder();
            filtroBuilder.Append(ddlInstrumento.SelectedValue.ToString());
            filtroBuilder.Append('|');
            filtroBuilder.Append(ddlEmisor.SelectedValue.ToString());
            filtroBuilder.Append('|');
            filtroBuilder.Append(ddlISIN.SelectedValue.ToString());

            #endregion

            LimpiarDropDownList(ddlSerie);
            if (ddlSerie != null)
            {
                ddlSerie.Items.Clear();
                ddlSerie.DataSource = null;
                ddlSerie.SelectedValue = null;
                ddlSerie.DataSource = LlenarDropDownList("EmisionesInstrumentosSerieLista", filtroBuilder.ToString());
                ddlSerie.DataTextField = "Texto";
                ddlSerie.DataValueField = "Valor";
                ddlSerie.DataBind();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region TIPO BIEN

    private void ddlTiposBienes()
    {
        try
        {
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int codPantalla = int.Parse(this.pantallaCodOculto.Value);

                #region GARANTIAS REALES
                //REQIERIMIENTO 1-24493287
                if (codPantalla.Equals(178) || codPantalla.Equals(183))
                {
                    #region BUSQUEDA CONTROLES

                    DropDownList ddlTipoBien = null;
                    DropDownList ddlProvincia = null;
                    DropDownList ddlHorizontal = null;
                    DropDownList ddlDuplicado = null;
                    DropDownList ddlClaseAeronave = null;
                    DropDownList ddlClaseBuque = null;
                    DropDownList ddlFormato = null;
                    ddlTipoBien = (DropDownList)this.tableData.FindControl("IdTipoBien");
                    ddlProvincia = (DropDownList)this.tableData.FindControl("IdProvincia");
                    ddlHorizontal = (DropDownList)this.tableData.FindControl("IdCodigoHorizontalidad");
                    ddlDuplicado = (DropDownList)this.tableData.FindControl("IdCodigoDuplicado");
                    ddlClaseAeronave = (DropDownList)this.tableData.FindControl("IdClaseAeronave");
                    ddlClaseBuque = (DropDownList)this.tableData.FindControl("IdClaseBuque");
                    ddlFormato = (DropDownList)this.tableData.FindControl("IdFormatoIdentificacionVehiculo");

                    TextBox txtNBien = null;
                    TextBox txtClaseVehiculo = null;
                    TextBox txtDesClaseVehiculo = null;
                    txtNBien = (TextBox)this.tableData.FindControl("NBien");
                    txtClaseVehiculo = (TextBox)this.tableData.FindControl("CodClaseVehiculo");
                    txtDesClaseVehiculo = (TextBox)this.tableData.FindControl("DesClaseVehiculo");

                    HiddenField hdnIdClaseVehiculo = null;
                    hdnIdClaseVehiculo = (HiddenField)this.tableData.FindControl("IdClaseVehiculo");

                    ImageButton btnClaseVehiculo = null;
                    btnClaseVehiculo = (ImageButton)this.tableData.FindControl("imgCmdCodClaseVehiculo");

                    CheckBox chkEstadoHorizontal = null;
                    CheckBox chkEstadoDuplicado = null;
                    chkEstadoHorizontal = (CheckBox)this.tableData.FindControl("chkIdCodigoHorizontalidad");
                    chkEstadoDuplicado = (CheckBox)this.tableData.FindControl("chkIdCodigoDuplicado");

                    RequiredFieldValidator rfvDesClaseVehiculo = null;
                    rfvDesClaseVehiculo = (RequiredFieldValidator)this.tableData.FindControl("rfvDesClaseVehiculo");

                    #endregion

                    ////EFECTO DE AUTOCOMPLETAR PARA EL CAMPO N BIEN 
                    //txtNBien.Attributes.Add("onblur", "AutoCompletar('" + txtNBien.ClientID + "','" + ddlTipoBien.ClientID + "','" + ddlFormato.ClientID + "','0')");

                    //EFECTO DE AUTOCOMPLETAR PARA EL CAMPO N BIEN 

                    if (ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -") || ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("9 -") || ddlTipoBien.SelectedItem.Text.Substring(0, 4).Equals("10 -"))
                    {
                        txtNBien.Attributes.Add("onblur", "AutoCompletar('" + txtNBien.ClientID + "','" + ddlTipoBien.ClientID + "','" + ddlFormato.ClientID + "','0')");
                    }

                    //REALIZA LA CARGA DE LA CLASE
                    CargarClases(ddlTipoBien.SelectedItem.Value);

                    //REALIZA LA CARGA DEL FORMATO IDENTIFICACION VEHICULO
                    CargarFormatoIdentificacionVehiculo(ddlTipoBien.SelectedItem.Text);

                    //EFECTO DE NUMERO DE BIEN [CONSTANTES]
                    txtNBien.Text = string.Empty;
                    txtNBien.MaxLength = 17;
                    txtNBien.ToolTip = "Alfanumérico de 17 caracteres";

                    if (ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("1 -") || ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                    {
                        //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO PROVINCIAS
                        AdministrarBlanco(ddlProvincia.ID, false);
                        ddlProvincia.Enabled = true;

                        //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO HORIZONTALES                
                        AdministrarBlanco(ddlHorizontal.ID, false);
                        ddlHorizontal.Enabled = true;

                        //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO DUPLICADOS                
                        AdministrarBlanco(ddlDuplicado.ID, false);
                        ddlDuplicado.Enabled = true;

                        //EFECTO DE NUMERO DE BIEN
                        txtNBien.MaxLength = 6;
                        txtNBien.ToolTip = "Númerico de 6 caracteres";

                        AdministrarBlanco(ddlDuplicado.ID, true);
                        ddlDuplicado.Enabled = false;
                        chkEstadoDuplicado.Checked = true;
                        chkEstadoDuplicado.Enabled = true;

                        AdministrarBlanco(ddlHorizontal.ID, true);
                        ddlHorizontal.Enabled = false;
                        chkEstadoHorizontal.Checked = true;
                        chkEstadoHorizontal.Enabled = true;

                        txtNBien.Attributes.Add("onblur", "");
                    }
                    else
                    {
                        //AGREGA EL ITEM EN BLANCO Y DESHABILITA EL COMBO PROVINCIAS
                        AdministrarBlanco(ddlProvincia.ID, true);
                        ddlProvincia.Enabled = false;

                        //AGREGA EL ITEM EN BLANCO Y DESHABILITA EL COMBO HORIZONTALES
                        AdministrarBlanco(ddlHorizontal.ID, true);
                        ddlHorizontal.Enabled = false;

                        //AGREGA EL ITEM EN BLANCO Y DESHABILITA EL COMBO DUPLICADOS
                        AdministrarBlanco(ddlDuplicado.ID, true);
                        ddlDuplicado.Enabled = false;

                        //Control de Cambios 1.1
                        chkEstadoDuplicado.Checked = false;
                        chkEstadoDuplicado.Enabled = false;
                        chkEstadoHorizontal.Checked = false;
                        chkEstadoHorizontal.Enabled = false;

                        txtNBien.Attributes.Add("onblur", "AutoCompletar('" + txtNBien.ClientID + "','" + ddlTipoBien.ClientID + "','" + ddlFormato.ClientID + "','0')");
                    }

                    if (ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
                    {
                        //HABILITA LOS CONTROLES DE CLASE VEHICULO
                        txtClaseVehiculo.Text = string.Empty;
                        hdnIdClaseVehiculo.Value = string.Empty;
                        txtDesClaseVehiculo.Text = string.Empty;
                        rfvDesClaseVehiculo.Enabled = true;
                        txtClaseVehiculo.Enabled = true;
                        btnClaseVehiculo.Enabled = true;

                        //COMBO FORMATO DE IDENTIFICACION VEHICULO
                        ddlFormatoIdentificacionVehiculo();

                        txtNBien.Attributes.Add("onblur", "AutoCompletar('" + txtNBien.ClientID + "','" + ddlTipoBien.ClientID + "','" + ddlFormato.ClientID + "','0')");
                    }
                    else
                    {
                        //DESHABILITA LOS CONTROLES DE CLASE VEHICULO
                        txtClaseVehiculo.Text = string.Empty;
                        hdnIdClaseVehiculo.Value = string.Empty;
                        txtDesClaseVehiculo.Text = string.Empty;
                        rfvDesClaseVehiculo.Enabled = false;
                        txtClaseVehiculo.Enabled = false;
                        btnClaseVehiculo.Enabled = false;
                    }

                    if (ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("9 -"))
                    {
                        //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE AERONAVE
                        AdministrarBlanco(ddlClaseAeronave.ID, false);
                        ddlClaseAeronave.Enabled = true;

                        //Control de Cambios 1.1
                        //EFECTO DE NUMERO DE BIEN
                        txtNBien.MaxLength = 6;
                        txtNBien.ToolTip = "Númerico de 6 caracteres";
                    }
                    else
                    {
                        //AGREGA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE AERONAVE
                        AdministrarBlanco(ddlClaseAeronave.ID, true);
                        ddlClaseAeronave.Enabled = false;
                    }

                    if (ddlTipoBien.SelectedItem.Text.Substring(0, 4).Equals("10 -"))
                    {
                        //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE BUQUE
                        AdministrarBlanco(ddlClaseBuque.ID, false);
                        ddlClaseBuque.Enabled = true;

                        //EFECTO DE NUMERO DE BIEN
                        txtNBien.MaxLength = 6;
                        txtNBien.ToolTip = "Númerico de 6 caracteres";
                    }
                    else
                    {
                        //AGREGA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE BUQUE
                        AdministrarBlanco(ddlClaseBuque.ID, true);
                        ddlClaseBuque.Enabled = false;
                    }

                }
                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region TIPO IDENTIFICACION RUC

    private void ddlTipoIdentificacionRUC()
    {
        try
        {
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int codPantalla = int.Parse(this.pantallaCodOculto.Value);

                #region GARANTIAS FIDUCIARIAS
                //REQIERIMIENTO 1-24493287
                if (codPantalla.Equals(176) || codPantalla.Equals(182))
                {
                    DropDownList ddl = (DropDownList)this.tableData.FindControl("TipoIdentificacionRUC");
                    MaskedEditExtender mask = null;
                    TextBox txt = null;
                    String maskCampo = "IdentificacionRUC";
                    string valorSeleccionado = string.Empty;

                    #region BUSQUEDA CONTROLES

                    mask = ((MaskedEditExtender)this.tableData.FindControl(string.Concat("mask", maskCampo)));
                    txt = ((TextBox)this.tableData.FindControl(maskCampo));

                    #endregion

                    if (mask != null && txt != null)
                    {
                        txt.Text = string.Empty;
                        mask.InputDirection = MaskedEditInputDirection.LeftToRight;
                        mask.AutoComplete = false;

                        valorSeleccionado = ddl.SelectedItem.Text.Substring(0, 3);

                        //ESTABLECE LA MASCARA SEGUN EL TIPO DE IDENTIFICACION
                        switch (valorSeleccionado)
                        {
                            case "1 -":
                                mask.Enabled = true;
                                mask.Mask = "9-9999-9999";
                                mask.Filtered = string.Empty;
                                txt.ToolTip = "#-####-####";
                                txt.MaxLength = 30;
                                break;
                            case "2 -":
                                mask.Enabled = true;
                                mask.Mask = "9-999-999999";
                                mask.Filtered = string.Empty;
                                txt.ToolTip = "#-###-######";
                                txt.MaxLength = 30;
                                break;
                            case "3 -":
                                mask.Enabled = false;
                                mask.Filtered = string.Empty;
                                txt.MaxLength = 30;
                                txt.ToolTip = "Texto Id Garantía";
                                break;
                            case "5 -":
                                mask.Enabled = false;
                                txt.MaxLength = 17;
                                txt.ToolTip = "Texto Id Garantía";
                                break;
                            default:
                                txt.ToolTip = "Texto Id Garantía";
                                txt.MaxLength = 30;
                                mask.Enabled = false;
                                break;
                        }
                    }
                }

                #endregion

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region TIPO INSTRUMENTO

    /*CARGA INSTRUMENTO PARA RPT GARANTIAS VALORES ESPECIFICAS*/
    private void CargarInstrumento(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));

            #endregion

            LimpiarDropDownList(ddlInstrumento);
            if (ddlInstrumento != null)
            {
                ddlInstrumento.Items.Clear();
                ddlInstrumento.DataSource = LlenarDropDownList("InstrumentosEmisionesFiltradoLista", ((DropDownList)(sender)).SelectedValue.ToString());
                ddlInstrumento.DataTextField = "Texto";
                ddlInstrumento.DataValueField = "Valor";
                ddlInstrumento.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA INSTRUMENTO PARA RPT GARANTIAS VALORES ESPECIFICAS*/
    private void CargarTipoInstrumentoTodos()
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlTipoInstrumento = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));

            #endregion

            LimpiarDropDownList(ddlTipoInstrumento);
            if (ddlTipoInstrumento != null)
            {
                ddlTipoInstrumento.Items.Clear();
                ddlTipoInstrumento.DataSource = LlenarDropDownList("TiposInstrumentosFiltradoInstrumentosLista", string.Empty);
                ddlTipoInstrumento.DataTextField = "Texto";
                ddlTipoInstrumento.DataValueField = "Valor";
                ddlTipoInstrumento.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlTipoInstrumento()
    {
        try
        {
            if (this.pantallaCodOculto.Value.Length > 0)
            {
                int codPantalla = int.Parse(this.pantallaCodOculto.Value);

                #region GARANTIAS VALORES
                //REQIERIMIENTO 1-24493287
                if (codPantalla.Equals(177) || codPantalla.Equals(184))
                {

                    #region BUSCAR COMPONENTES

                    DropDownList ddlTipoInstrumento = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));
                    DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
                    DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));
                    DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
                    DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));
                    DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("Serie"));

                    #endregion

                    switch (ValorTipoValor())
                    {
                        case 1:
                            CargarInstrumento(ddlTipoInstrumento);
                            CargarEmisor(ddlInstrumento);
                            CargarISIN(ddlEmisor, ddlInstrumento);
                            CargarSerie(ddlInstrumento, ddlEmisor, ddlISIN);
                            break;
                    }
                }

                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region TIPO VALOR

    /*RETORNA EL VALOR SELECCIONADO DEL DROPDOWNLIST TIPO VALOR*/
    private int ValorTipoValor()
    {
        try
        {
            return int.Parse(((DropDownList)this.tableData.FindControl("IdTipoValor")).SelectedValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*LIMPIA LOS CONTROLES DE LA VENTANA DE RPT VALORES ESPECIFICOS*/
    private void LimpiarContenidoFormulario()
    {
        (((TextBox)this.tableData.FindControl("CodGarantiaBCR"))).Text = string.Empty;
        //REQIERIMIENTO 1-24493287
        if (this.pantallaCodOculto.Value.Equals("177"))
        {
            (((TextBox)this.tableData.FindControl("FechaInicio"))).Text = string.Empty;
            (((TextBox)this.tableData.FindControl("FechaFinal"))).Text = string.Empty;
        }
        DropDownList ddlTipoInstrum = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));

        ddlTipoInstrum.SelectedIndex = -1;
    }

    private void InsertarExcepcionOtrosValores()
    {
        try
        {
            #region CONTROLES GENERICOS

            Button btnBuscarCDP = (Button)this.tableData.FindControl("imgCmdCodGarantiaBCR");
            btnBuscarCDP.Visible = false;
            LimpiarContenidoFormulario();

            #endregion

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            DropDownList ddlTipoInstrum = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));
            DropDownList ddlInstrum = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));

            ddlTipoInstrum.Enabled = true;
            ddlInstrum.Enabled = true;
            CargarInstrumento(ddlTipoInstrum);
            ddlEmisor.Enabled = true;
            CargarEmisor(ddlInstrum);

            #endregion

            #region ISIN / SERIE

            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("Serie"));

            ddlISIN.Enabled = true;
            ddlSerie.Enabled = true;
            CargarISIN(ddlEmisor, ddlInstrum);
            CargarSerie(ddlInstrum, ddlEmisor, ddlISIN);


            #endregion

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
            #region CONTROLES GENERICOS

            Button btnBuscarCDP = (Button)this.tableData.FindControl("imgCmdCodGarantiaBCR");
            btnBuscarCDP.Visible = false;
            btnBuscarCDP.Enabled = false;
            LimpiarContenidoFormulario();

            #endregion

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            DropDownList ddlTipoInstrum = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));
            DropDownList ddlInstrum = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));

            ddlTipoInstrum.Enabled = false;
            ddlInstrum.Enabled = false;
            ddlEmisor.Enabled = false;

            CargarTipoInstrumentoTodos();
            generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoInstrum, "CDP-CI");
            CargarInstrumento(ddlTipoInstrum);
            generadorControles.SeleccionarOpcionDropDownListCodigo(ddlInstrum, "CDP-CI");
            CargarOtrosEmisores();
            generadorControles.SeleccionarOpcionDropDownListCodigo(ddlEmisor, "BCR");

            #endregion

            #region ISIN / SERIE

            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("Serie"));

            ddlISIN.Enabled = false;
            ddlSerie.Enabled = false;
            LimpiarDropDownList(ddlISIN);
            LimpiarDropDownList(ddlSerie);
            generadorControles.SeleccionarOpcionDropDownListTexto(ddlISIN1, "NO");

            #endregion

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
            #region CONTROLES GENERICOS

            Button btnBuscarCDP = (Button)this.tableData.FindControl("imgCmdCodGarantiaBCR");
            btnBuscarCDP.Visible = false;
            LimpiarContenidoFormulario();

            #endregion

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            DropDownList ddlTipoInstrum = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));
            DropDownList ddlInstrum = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));

            ddlTipoInstrum.Enabled = false;
            ddlInstrum.Enabled = false;
            ddlEmisor.Enabled = true;

            CargarTipoInstrumentoTodos();
            generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoInstrum, "CDP-CI");
            CargarInstrumento(ddlTipoInstrum);
            generadorControles.SeleccionarOpcionDropDownListCodigo(ddlInstrum, "CDP-CI");
            CargarOtrosEmisores();

            #endregion

            #region ISIN / SERIE

            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("Serie"));

            ddlISIN.Enabled = false;
            ddlSerie.Enabled = false;
            LimpiarDropDownList(ddlISIN);
            LimpiarDropDownList(ddlSerie);
            generadorControles.SeleccionarOpcionDropDownListTexto(ddlISIN1, "NO");

            #endregion

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
            #region CONTROLES GENERICOS

            Button btnBuscarCDP = (Button)this.tableData.FindControl("imgCmdCodGarantiaBCR");
            btnBuscarCDP.Visible = false;
            LimpiarContenidoFormulario();

            #endregion

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            DropDownList ddlTipoInstrum = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));
            DropDownList ddlInstrum = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));

            ddlTipoInstrum.Enabled = true;
            ddlInstrum.Enabled = true;
            ddlEmisor.Enabled = true;

            CargarTipoInstrumentoTodos();
            CargarInstrumentosTodos();
            CargarOtrosEmisores();

            #endregion

            #region ISIN / SERIE

            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("Serie"));

            ddlISIN.Enabled = false;
            ddlSerie.Enabled = false;
            LimpiarDropDownList(ddlISIN);
            LimpiarDropDownList(ddlSerie);
            generadorControles.SeleccionarOpcionDropDownListTexto(ddlISIN1, "NO");

            #endregion

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlTipoValor()
    {
        if (this.pantallaCodOculto.Value.Length > 0)
        {
            int codPantalla = int.Parse(this.pantallaCodOculto.Value);

            #region GARANTIAS VALORES
            //REQIERIMIENTO 1-24493287
            if (codPantalla.Equals(177) || codPantalla.Equals(184))
            {
                switch (ValorTipoValor())
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

            #endregion

        }
    }

    #endregion

    #endregion

    #endregion

    #region EVENTOS CONTROLES

    private void Efectos()
    {
        if (this.pantallaCodOculto.Value.Length > 0)
        {
            int codPantalla = int.Parse(this.pantallaCodOculto.Value);

            switch (codPantalla)
            {
                case 176:
                case 182://REQIERIMIENTO 1-24493287: OPERACIONES FIDUCIARIAS
                    ddlTipoIdentificacionRUC();
                    break;
                case 177:
                case 184://REQIERIMIENTO 1-24493287: OPERACIONES VALORES
                    ddlTipoValor();
                    break;
                case 178:
                case 183://REQIERIMIENTO 1-24493287: OPERACIONES REALES
                    ddlTiposBienes();
                    break;
            }
        }
    }

    /*GENERA LOS EVENTOS DE LOS CONTROLES SEGUN EL CODIGO DE PANTALLA (REPORTE)*/
    private void EventosControles()
    {
        try
        {
            int codPagina = int.Parse(this.pantallaCodOculto.Value);

            //EVENTO POR DEFECTO DEL BOTON GENERAR REPORTE
            //this.btnGenerar.Click += new EventHandler(btnGenerar_Click);                        

            switch (codPagina)
            {
                case 176:
                case 182://OPERACIONES FIDUCIARIAS
                    EventosControlesGarantiasFiduciariasEspecificas();
                    break;
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #region REPORTES GARANTIAS FIDUCIARIAS

    private void EventosControlesGarantiasFiduciariasEspecificas()
    {
        try
        {
            #region BUSQUEDA CONTROLES

            DropDownList ddlTipoIdentificacionRUC = null;
            ddlTipoIdentificacionRUC = (DropDownList)this.tableData.FindControl("TipoIdentificacionRUC");

            #endregion

            /*if (ddlTipoIdentificacionRUC != null)
            {
                ddlTipoIdentificacionRUC.AutoPostBack = true;
                ddlTipoIdentificacionRUC.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);
            }*/
            //ESTO NO SE DEBE USAR
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #endregion

    #region BOTON GENERAR RPT

    /*BOTON PARA EL DESPLIEGUE LA PANTALLA DE REPORTES*/
    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                pantallaIdOculto.Value = "0";

                //SI NO EXISTEN ERRORES DE VALIDACION
                if (!ExisteError())
                {
                    HttpHelper post = new HttpHelper();
                    post.RedirectAndPOSTNewWindow(this.Page, "../Detalles/ReportesNew.aspx", Set_RutaVentana(), "_blank");
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #endregion

    #region VENTANAS DE MENSAJES

    protected void btnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBox.Hide();
    }

    //OBTIENE EL MENSAJE DESDE BD
    private MensajesEntidad Mensaje(string msgType)
    {
        try
        {
            mensajesEntidad.CodMensaje = msgType.ToString();
            MensajesEntidad msj = wsSeguridad.MensajesConsulta(mensajesEntidad);
            return msj;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //EVENTO MESAJES EMERGENTES FORMULARIO REALES
    protected void InformarBox1_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBox1.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo));
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
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBox1.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo1).Replace("@$@", valorReemplazo2));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //EVENTO MENSAJES VENTANA EMERGENTE DE BUSQUEDA CLASE VEHICULO
    protected void InformarBoxBusquedaClaseVehiculo_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBoxBusquedaClaseVehiculo.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

    #region OTROS METODOS

    /*CARGA LAS VARIABLES GLOBALES QUE VIENEN POR URL*/
    private void VariablesGlobales()
    {
        try
        {
            #region OBTENER VALORES SESION
            //ALMACENA LA INFORMACION DE LA SESION
            dataSesion = Request.Form;
            string[] valores = dataSesion.AllKeys;
            foreach (string valor in valores)
            {
                switch (valor)
                {
                    case "idSesion":
                        idSesionOculto.Value = dataSesion["idSesion"].ToString();
                        break;
                    case "codUsuario":
                        codUsuarioOculto.Value = dataSesion["codUsuario"].ToString();
                        break;
                    case "pantallaModulo":
                        pantallaModuloOculto.Value = dataSesion["pantallaModulo"].ToString();
                        break;
                }
            }
            #endregion

            //EXTRAER EL CODIGO DE LA PANTALLA
            if (pantallaModuloOculto.Value.Length > 0)
            {
                pantallasEntidad.RutaPantalla = Page.AppRelativeVirtualPath.ToString();
                pantallasEntidad.IdPantalla = int.Parse(pantallaModuloOculto.Value); //ASIGNA EL ID DE LA PANTALLA

                pantallasEntidad = wsSeguridad.PantallasConsultarDetalle(pantallasEntidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                pantallaCodOculto.Value = pantallasEntidad.CodPantalla.ToString();
                pantallaModuloOculto.Value = pantallasEntidad.IdPantalla.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*VERIFICACION DEL PERMISO DE LA PAGINA*/
    private bool AccesoPermisoPagina()
    {
        bool resultado = true;

        try
        {
            int permiso = wsSeguridad.UsuariosValidarAccesoCodigo(codUsuarioOculto.Value, pantallaCodOculto.Value);
            if (permiso.Equals(0))
            {
                httpPost = new HttpHelper();
                Dictionary<string, string> dataSesion = new Dictionary<string, string>();
                dataSesion.Add("idSesion", idSesionOculto.Value);
                dataSesion.Add("codUsuario", codUsuarioOculto.Value);
                dataSesion.Add("pantallaModulo", pantallaModuloOculto.Value);
                httpPost.RedirectAndPOST(this.Page, "../Seguridad/SinPrivilegios.aspx", dataSesion);

                resultado = false;
            }
            return resultado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected Dictionary<string, string> Set_RutaVentana()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("idSesion", idSesionOculto.Value);
        data.Add("codUsuario", codUsuarioOculto.Value);
        data.Add("pantallaModulo", pantallaModuloOculto.Value);
        data.Add("nombreReporte", ObtenerNombreReporte());
        data.Add("parametrosReporte", ObtenerParametrosReporte());

        return data;
    }

    protected SeguridadWS.BitacorasEntidad AsignarValoresBitacora(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA

            bitacorasSeguridadEntidad.CodAccion = bitacoraFlags.TipoBitacoraConsulta(_tipo);
            bitacorasSeguridadEntidad.CodModulo = int.Parse(pantallaModuloOculto.Value);
            bitacorasSeguridadEntidad.CodEmpresa = int.Parse(Resources.Resource._empresa);
            bitacorasSeguridadEntidad.CodSistema = Resources.Resource._sistema;
            bitacorasSeguridadEntidad.CodUsuario = codUsuarioOculto.Value;

            #endregion

            return bitacorasSeguridadEntidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected ConfiguracionWS.BitacorasEntidad AsignarValoresBitacoraC(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA
            ConfiguracionWS.BitacorasEntidad bitacorasEntidadC = new ConfiguracionWS.BitacorasEntidad();
            bitacorasEntidadC.CodAccion = bitacoraFlags.TipoBitacoraConsulta(_tipo);
            bitacorasEntidadC.CodModulo = int.Parse(pantallaModuloOculto.Value);
            bitacorasEntidadC.CodEmpresa = int.Parse(Resources.Resource._empresa);
            bitacorasEntidadC.CodSistema = Resources.Resource._sistema;
            bitacorasEntidadC.CodUsuario = codUsuarioOculto.Value;

            #endregion

            return bitacorasEntidadC;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsLista.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();
            wsSesiones.Url = ConfigurationManager.AppSettings["SesionesWCF"].ToString();
            wsSeguridad.Url = ConfigurationManager.AppSettings["SeguridadWS"].ToString();
            wsConfiguracion.Url = ConfigurationManager.AppSettings["ConfiguracionWS"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(ConfigurationManager.AppSettings["Culture"].ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ConfigurationManager.AppSettings["Culture"].ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region REPORTE

    /*OBTIENE EL NOMBRE DEL REPORTE A MOSTRAR*/
    private string ObtenerNombreReporte()
    {
        try
        {
            ReportesEntidad retorno = new ReportesEntidad();
            ReportesEntidad reporte = new ReportesEntidad();
            reporte.IdPantalla = int.Parse(this.pantallaModuloOculto.Value);

            retorno = wsConfiguracion.ReportesConsultarDetalle(reporte, AsignarValoresBitacoraC(EnumTipoBitacora.CONSULTAR));

            return retorno.CodReporte;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*OBTIENE LOS PARAMETROS Y LOS VALORES CORRESPONDIENTES DEL REPORTE*/
    private string ObtenerParametrosReporte()
    {
        try
        {
            DropDownList ddl = null;

            Object control = null;
            string[] arregloParametros;

            ReportesEntidad retorno = new ReportesEntidad();
            ReportesEntidad reporte = new ReportesEntidad();

            StringBuilder retornoParametros = new StringBuilder();
            retornoParametros.Clear();

            //RETORNA LOS PARAMETROS DEL REPORTE
            reporte.IdPantalla = int.Parse(this.pantallaModuloOculto.Value);
            retorno = wsConfiguracion.ReportesConsultarDetalle(reporte, AsignarValoresBitacoraC(EnumTipoBitacora.CONSULTAR));

            arregloParametros = retorno.Parametros.Split('|');

            //NombreParametro1=ValorParametro1&NombreParametro2=ValorParametro2&...etc
            for (int c = 0; c < arregloParametros.Length; c++)
            {
                ddl = null;
                control = null;

                //NOMBRE DEL PARAMETRO
                retornoParametros.Append(arregloParametros[c]);
                //SEPARADOR DE PARAMETRO CON SU VALOR
                retornoParametros.Append("=");

                //BUSCA EL CONTROL QUE POSEA EL MISMO NOMBRE QUE EL PARAMETRO DEL RPT PARA EXTRAER SU VALOR
                control = this.tableData.FindControl(arregloParametros[c]);
                if (control != null)
                {
                    switch (control.GetType().Name.ToUpper())
                    {
                        #region TEXTBOX
                        case "MULTILINE":
                        case "TEXTBOX":
                            retornoParametros.Append(((TextBox)control).Text);
                            break;
                        #endregion

                        #region DROPDOWNLIST
                        case "DROPDOWNLIST":
                            ddl = (DropDownList)control;
                            if (ddl.Items.Count > 0)
                            {
                                if (ddl.SelectedItem.Value.ToString().Equals("-1")) //SI EL VALOR ES -1 CORRESPONDE A UN COMBO CON VALOR BLANCO (ADMINISTRAR BLANCO)
                                    retornoParametros.Append("");
                                else
                                    if (ddl.SelectedItem.Value.ToString().Length < 1) //SI EL DDL NO TIENE NINGUN DATO
                                        retornoParametros.Append("");
                                    else
                                        retornoParametros.Append(ddl.SelectedItem.Value.ToString());
                            }
                            else
                                retornoParametros.Append("");
                            break;
                        #endregion

                        #region HIDDENFIELD
                        case "HIDDENFIELD":
                            retornoParametros.Append(((HiddenField)control).Value);
                            break;
                        #endregion

                    }
                }
                else
                {
                    if (arregloParametros[c].ToUpper().Equals("CODUSUARIO"))
                        retornoParametros.Append(this.codUsuarioOculto.Value);
                }

                //SEPARADOR DE PARAMETROS
                if (c < arregloParametros.Length - 1)
                    retornoParametros.Append("&");
            }

            return retornoParametros.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

    #region MIEMBRO IDISPOSABLE

    #region VARIABLES

    private bool disponible = false;

    #endregion

    #region FINALIZADOR

    protected override void OnUnload(EventArgs e)
    {
        base.OnUnload(e);

        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion

    protected virtual void Dispose(bool disposing)
    {
        if (!disponible)
        {
            if (disposing)
            {
                if (wsConfiguracion != null)
                {
                    wsConfiguracion.Dispose();
                    wsConfiguracion = null;
                }

                if (wsSeguridad != null)
                {
                    wsSeguridad.Dispose();
                    wsSeguridad = null;
                }
            }
            pantallasEntidad = null;
            bitacorasSeguridadEntidad = null;

            dataSesion = null;
            disponible = true;
        }
    }

    #endregion

}