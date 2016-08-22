using System;
using System.Web;
using System.Data;
using System.Text;
using System.Linq;
using System.Web.UI;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

using SesionesWCF;
using SeguridadWS;
using ListasWS;

public partial class Parametros : System.Web.UI.Page
{

    #region PROPIEDADES

    #region VARIABLES

    protected Int32 Registros
    {
        get
        {
            Int32 n = (Int32)ViewState["Registros"];
            return ((n == 0) ? 0 : n);
        }
        set
        {
            ViewState["Registros"] = value;
        }
    }

    private String path = String.Empty;
    
    #endregion

    #region CONTROLES

    private GridView gridView = null;
    private GridViewColumn gridViewColumna = null;

    private Button btnBuscar = null;
    private Button btnBuscarCancelar = null;
    
    private Button btnModificar = null;
    private Button btnActualizar = null;
    private Button btnExportarExcel = null;

    private Label lblTitulo = null;
    private DropDownList ddlFiltro = null;

    private SliderExtender slider = null;

    private TextBox txtFiltro = null;
    private TextBox txtSlide = null;

    #endregion

    #region REFERENCIAS
    
    private BitacoraFlags bitacoraFlags = new BitacoraFlags();
    private ListasWS.PantallasEntidad pantallasEntidad = new ListasWS.PantallasEntidad();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private SeguridadWS.BitacorasEntidad bitacorasEntidad = new SeguridadWS.BitacorasEntidad();
    private SeguridadWS.ParametrosBienesEntidad paramUsuarios = new SeguridadWS.ParametrosBienesEntidad();
    private SeguridadWS.ParametrosConsultaEntidad consultaEntidad = new SeguridadWS.ParametrosConsultaEntidad();
    private SeguridadWS.ParametrosTotalFilasEntidad consultaTotalFilas = new SeguridadWS.ParametrosTotalFilasEntidad();

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS EDITABLES

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            //ASIGNANDO RUTAS DE SERVICIOS WEB
            this.AsignaWebServicesTypeNames();

            if (AccesoPermisoPagina())
            {
                // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
                this.gridView = (GridView)this.MasterGrid1.FindControl("MasterGridView");
                this.gridView.Init += new EventHandler(gridView_Init);

                // ASIGNA COLUMNAS PROPIAS DEL CONTROL
                this.gridView_Init(sender, e);

                // ASIGNA EL EVENTO DE DATA BOUND
                this.gridView.RowCreated += new GridViewRowEventHandler(gridView_RowCreated);

                if (!Page.IsPostBack)
                {
                    #region ENTIDAD CONSULTA

                    consultaEntidad.IndiceInicioFila = (this.gridView.PageIndex * StaticParameters.RowCount);
                    consultaEntidad.MaximoFilas = StaticParameters.RowCount;
                    consultaEntidad.ValorFiltro = String.Empty;
                    consultaEntidad.ColumnaFiltro = "Id_Parametro_Bien";
                    consultaEntidad.ColumnaOrdenar = "Id_Parametro_Bien";

                    #endregion

                    // BINDEA EL GRIDVIEW
                    this.BindGridView(gridView, this.Consulta(consultaEntidad));
                }

                #region EVENTOS CLICK BOTONES

                // ASIGNA CONTROL Y EVENTO AL BOTON DE EXPORTAR EXCEL
                this.btnExportarExcel = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesExcel"));
                this.btnExportarExcel.Click += new EventHandler(btnExportarExcel_Click);

                // ASIGNA CONTROL Y EVENTO AL BOTON DE NUEVO
                this.btnModificar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesModificar"));
                this.btnModificar.Click += new EventHandler(btnModificar_Click);

                // ASIGNA CONTROL Y EVENTO AL BOTON DE ACTUALIZAR
                this.btnActualizar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesActualizar"));
                this.btnActualizar.Click += new EventHandler(btnActualizar_Click);

                #endregion

                #region ASIGNA / ESCONDE CONTROL

                this.ddlFiltro = (DropDownList)this.MasterGrid1.FindControl("ddlfiltro");
                this.ddlFiltro.Visible = false;

                // ASIGNA CONTROL Y ESCONDE EL TEXTBOX DE FILTRO
                this.txtFiltro = (TextBox)this.MasterGrid1.FindControl("txtFiltro");
                this.txtFiltro.Visible = false;

                // ASIGNA CONTROL Y ESCONDE EL BOTON DE FILTRO
                this.btnBuscar = (Button)this.MasterGrid1.FindControl("imgBtnSearch");
                this.btnBuscar.Visible = false;

                // ASIGNA CONTROL Y ESCONDE EL BOTON DE CLEAR
                this.btnBuscarCancelar = (Button)this.MasterGrid1.FindControl("imgBtnClear");
                this.btnBuscarCancelar.Visible = false;

                ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesParametros();

                #endregion

                // ASIGNA DATA KEYS
                String[] dataKeysString = { "IdParametroBien" };
                this.SetDataKeys(gridView, dataKeysString);

                // BUSCA NOMBRE DE LA PANTALLA
                pantallasEntidad.RutaPantalla = Page.AppRelativeVirtualPath.ToString();
                pantallasEntidad = wsListas.AdministracionesContenidosConsultaPantallas(pantallasEntidad);

                pantallaTituloOculto.Value = pantallasEntidad.TituloPantalla;
                pantallaModuloOculto.Value = pantallasEntidad.Modulo;
                pantallaNombreOculto.Value = Request.Url.Segments[Request.Url.Segments.Length - 1].Replace(".aspx", "");

                // ASIGNA EL TITULO AL MANTENIMIENTO
                this.lblTitulo = (Label)this.MasterGrid1.FindControl("lblTituloPage");
                this.lblTitulo.Text = "Listado de " + pantallaTituloOculto.Value;

                #region CONTROL SLIDER

                // CREA EL TEXT Y SLIDER PARA PAGINACION
                this.slider = (SliderExtender)this.MasterPager1.FindControl("SliderExtender1");
                this.txtSlide = (TextBox)this.MasterPager1.FindControl("txtSlide");

                txtSlide.TextChanged += new EventHandler(txtSlide_Changed);
                slider.TargetControlID = txtSlide.ID;

                Button btnFirst = (Button)this.MasterPager1.FindControl("imgBtnFirst");
                btnFirst.CommandName = "First";
                btnFirst.Command += new CommandEventHandler(PagerCommand);

                Button btnPrev = (Button)this.MasterPager1.FindControl("imgBtnPrev");
                btnPrev.CommandName = "Previous";
                btnPrev.Command += new CommandEventHandler(PagerCommand);

                Button btnNext = (Button)this.MasterPager1.FindControl("imgBtnNext");
                btnNext.CommandName = "Next";
                btnNext.Command += new CommandEventHandler(PagerCommand);

                Button btnLast = (Button)this.MasterPager1.FindControl("imgBtnLast");
                btnLast.CommandName = "Last";
                btnLast.Command += new CommandEventHandler(PagerCommand);

                SetRegistrosLabelIndex();

                #endregion

                #region MENSAJE INFORMAR

                Button btnAceptarInformar = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
                btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);

                this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

                #endregion
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    private void gridView_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridView, "IdParametroBien", lblID);

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("MesesVencimientoAvaluoSUGEFTerreno", string.Empty, "Meses Vencimiento Avalúo SUGEF Terreno", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("MesesVencimientoAvaluoSUGEFEdificacion", string.Empty, "Meses Vencimiento Avalúo SUGEF Edificaciones", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("MesesVencimientoAvaluoVehiculo", string.Empty, "Meses Vencimiento Avalúo Vehículos", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("MesesPrescripcionTerreno", string.Empty, "Meses Prescripción Terrenos", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("MesesPrescripcionEdificacion", string.Empty, "Meses Prescripción Edificaciones", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("MesesPrescripcionVehiculo", string.Empty, "Meses Prescripción Vehículo", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("MesesPrescripcionFianza", string.Empty, "Meses Prescripción Fianzas", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("MesesPrescripcionValor", string.Empty, "Meses Prescripción Valores", HorizontalAlign.Center, false, true));
    }

    private void ClearGridView()
    {
        try
        {
            #region ENTIDAD CONSULTA

            consultaEntidad.IndiceInicioFila = (this.gridView.PageIndex * StaticParameters.RowCount);
            consultaEntidad.MaximoFilas = StaticParameters.RowCount;
            consultaEntidad.ValorFiltro = String.Empty;
            consultaEntidad.ColumnaFiltro = "Id_Parametro_Bien";
            consultaEntidad.ColumnaOrdenar = "Id_Parametro_Bien";

            #endregion
            this.BindGridView(gridView, this.Consulta(consultaEntidad));
            SetRegistrosLabelIndex();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region EVENTOS CLICK

    protected void btnExportarExcel_Click(object sender, EventArgs e)
    {
        ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).ExportToExcel(pantallaTituloOculto.Value, this.gridView);
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (Page.IsPostBack)
                {
                    if (ContadorSeleccionados() < 2) //SI SOLO EXISTE UN REGISTRO SELECCIONADO
                    {
                        foreach (GridViewRow row in gridView.Rows)
                        {
                            CheckBox checkBoxColumn = (CheckBox)gridView.Rows[row.RowIndex].FindControl("chkBox1");
                            if (checkBoxColumn.Checked)
                            {
                                Label lbl = (Label)gridView.Rows[row.RowIndex].FindControl("lblIdParametroBien");
                                pantallaIdOculto.Value = lbl.Text;

                                HttpHelper post = new HttpHelper();
                                post.RedirectAndPOSTNewWindow(this.Page, "../Detalles/SeguridadNew.aspx", SetRutaVentana());
                                break;
                            }
                        }
                    }
                    else
                    {
                        //SI EXISTE MÁS DE UN REGISTRO SELECCIONADO
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_4");
                        this.mpeInformarBox.Show();
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

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                ClearGridView();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void btnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBox.Hide();
    }

    #endregion

    #region PAGINACION

    protected virtual void PagerCommand(object sender, CommandEventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                int intSlide = Int32.Parse(this.txtSlide.Text);
                int maxRows = StaticParameters.RowCount;
                int StartRowIndex = 0;

                Label lblPage1 = (Label)this.MasterPager1.FindControl("lblPagingIni");

                switch (e.CommandName)
                {
                    case "Next":
                        this.txtSlide.Text = Convert.ToString((intSlide + 1));
                        if (Int32.Parse(this.txtSlide.Text) <= Registros)
                        {
                            StartRowIndex = intSlide * maxRows;
                            #region ENTIDAD CONSULTA

                            consultaEntidad.IndiceInicioFila = StartRowIndex;
                            consultaEntidad.MaximoFilas = maxRows;
                            consultaEntidad.ValorFiltro = string.Empty;
                            consultaEntidad.ColumnaFiltro = "Id_Parametro_Bien";
                            consultaEntidad.ColumnaOrdenar = "Id_Parametro_Bien";

                            #endregion
                            // BINDEA EL GRIDVIEW
                            this.BindGridView(gridView, this.Consulta(consultaEntidad));
                            lblPage1.Text = this.txtSlide.Text;
                        }
                        break;
                    case "Previous":
                        this.txtSlide.Text = Convert.ToString((intSlide - 1));
                        if (Int32.Parse(this.txtSlide.Text) >= 1)
                        {
                            StartRowIndex = (intSlide - 2) * maxRows;
                            #region ENTIDAD CONSULTA

                            consultaEntidad.IndiceInicioFila = StartRowIndex;
                            consultaEntidad.MaximoFilas = maxRows;
                            consultaEntidad.ValorFiltro = string.Empty;
                            consultaEntidad.ColumnaFiltro = "Id_Parametro_Bien";
                            consultaEntidad.ColumnaOrdenar = "Id_Parametro_Bien";

                            #endregion
                            // BINDEA EL GRIDVIEW
                            this.BindGridView(gridView, this.Consulta(consultaEntidad));
                            lblPage1.Text = this.txtSlide.Text;
                        }
                        break;
                    case "Last":
                        if (Int32.Parse(this.txtSlide.Text) <= Registros)
                        {
                            this.txtSlide.Text = Convert.ToString((Registros));
                            StartRowIndex = (Registros - 1) * 10;
                            #region ENTIDAD CONSULTA

                            consultaEntidad.IndiceInicioFila = StartRowIndex;
                            consultaEntidad.MaximoFilas = maxRows;
                            consultaEntidad.ValorFiltro = string.Empty;
                            consultaEntidad.ColumnaFiltro = "Id_Parametro_Bien";
                            consultaEntidad.ColumnaOrdenar = "Id_Parametro_Bien";

                            #endregion
                            // BINDEA EL GRIDVIEW
                            this.BindGridView(gridView, this.Consulta(consultaEntidad));
                            lblPage1.Text = this.txtSlide.Text;
                        }
                        break;
                    case "First":
                    default:
                        if (Int32.Parse(this.txtSlide.Text) >= 1)
                        {
                            this.txtSlide.Text = "1";
                            #region ENTIDAD CONSULTA

                            consultaEntidad.IndiceInicioFila = 0;
                            consultaEntidad.MaximoFilas = maxRows;
                            consultaEntidad.ValorFiltro = string.Empty;
                            consultaEntidad.ColumnaFiltro = "Id_Parametro_Bien";
                            consultaEntidad.ColumnaOrdenar = "Id_Parametro_Bien";

                            #endregion
                            // BINDEA EL GRIDVIEW
                            this.BindGridView(gridView, this.Consulta(consultaEntidad));
                            lblPage1.Text = this.txtSlide.Text;
                        }
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void txtSlide_Changed(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                #region ENTIDAD CONSULTA

                consultaEntidad.IndiceInicioFila = (Int32.Parse(this.txtSlide.Text) - 1) * StaticParameters.RowCount;
                consultaEntidad.MaximoFilas = StaticParameters.RowCount;
                consultaEntidad.ValorFiltro = string.Empty;
                consultaEntidad.ColumnaFiltro = "Id_Parametro_Bien";
                consultaEntidad.ColumnaOrdenar = "Id_Parametro_Bien";

                #endregion

                // BINDEA EL GRIDVIEW
                this.BindGridView(gridView, this.Consulta(consultaEntidad));

                Label lblPage1 = (Label)this.MasterPager1.FindControl("lblPagingIni");
                lblPage1.Text = this.txtSlide.Text;
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #endregion

    #region METODOS CONSULTAS

    private Int32 TotalFilas(SeguridadWS.ParametrosTotalFilasEntidad _entidad)
    {
        return wsSeguridad.ParametrosBienesTotalFilas(_entidad);
    }

    private List<ParametrosBienesEntidad> Consulta(SeguridadWS.ParametrosConsultaEntidad _entidad)
    {
        return wsSeguridad.ParametrosBienesConsultar(_entidad).ToList();
    }

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS NO EDITABLES

    private bool AccesoPermisoPagina()
    {
        bool resultado = true;
        string pagina = Request.Url.Segments[Request.Url.Segments.Length - 1].Replace(".aspx", "");

        try
        {
            if (!Page.IsPostBack)
            {
                // ASIGNA LAS VARIABLES DE SESION
                #region OBTENER VALORES SESION
                //ALMACENA LA INFORMACION DE LA SESION
                string[] valores = Request.Form.AllKeys;
                foreach (string valor in valores)
                {
                    switch (valor)
                    {
                        case "idSesion":
                            idSesionOculto.Value = Request.Form["idSesion"].ToString();
                            break;
                        case "codUsuario":
                            codUsuarioOculto.Value = Request.Form["codUsuario"].ToString();
                            break;
                        case "pantallaModulo":
                            pantallaModuloOculto.Value = Request.Form["pantallaModulo"].ToString();
                            break;
                    }
                }
                #endregion
                ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesMasAcciones(false);
                ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trEjecutarIPC")).Attributes.Add("style", "display:none");
                ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trEjecutarTC")).Attributes.Add("style", "display:none");
                ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trCopiarRol")).Attributes.Add("style", "display:none");

                int permits = wsSeguridad.UsuariosValidarAcceso(codUsuarioOculto.Value, pagina);
                if (permits.Equals(0))
                {
                    HttpHelper httpPost = new HttpHelper();
                    Dictionary<string, string> dataSesion = new Dictionary<string, string>();
                    dataSesion.Add("idSesion", idSesionOculto.Value);
                    dataSesion.Add("codUsuario", codUsuarioOculto.Value);
                    dataSesion.Add("pantallaModulo", pantallaModuloOculto.Value);
                    httpPost.RedirectAndPOST(this.Page, "../Seguridad/SinPrivilegios.aspx", dataSesion);

                    resultado = false;
                }
            }
            return resultado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void SetDataKeys(GridView _gridView, String[] _dataKeysString)
    {
        _gridView.DataKeyNames = _dataKeysString;
    }

    protected void SetRegistrosLabelIndex()
    {
        try
        {
            #region ENTIDAD CONSULTA

            consultaTotalFilas.ValorFiltro = String.Empty;
            consultaTotalFilas.ColumnaFiltro = "Id_Parametro_Bien";

            #endregion

            decimal filasContador = this.TotalFilas(consultaTotalFilas);
            decimal maxFilas = Decimal.Parse(StaticParameters.RowCount.ToString());

            decimal resultadoFilas = (filasContador / maxFilas), redondeo = Math.Ceiling(resultadoFilas);

            decimal totalResultado = 0;
            if (resultadoFilas > redondeo)
                totalResultado = (resultadoFilas - redondeo);
            else if (resultadoFilas < redondeo)
                totalResultado = (redondeo - resultadoFilas);
            else if (resultadoFilas == redondeo)
                totalResultado = (int)redondeo;

            slider.Minimum = 1;

            if (totalResultado > 0)
            {
                if (redondeo == 0)
                {
                    int n = (int)redondeo + 1;
                    slider.Maximum = n;
                    slider.Steps = n;
                    Registros = n;
                }
                else
                {
                    int n = (int)redondeo;
                    slider.Maximum = n;
                    slider.Steps = n;
                    Registros = n;
                }

                Label lblPage1 = (Label)this.MasterPager1.FindControl("lblPagingIni");
                lblPage1.Text = (this.gridView.PageIndex + 1).ToString();
                this.txtSlide.Text = (this.gridView.PageIndex + 1).ToString();
            }
            else
            {
                Registros = ((int)redondeo);

                Label lblPage1 = (Label)this.MasterPager1.FindControl("lblPagingIni");
                lblPage1.Text = "0";
            }

            Label lblPage2 = (Label)this.MasterPager1.FindControl("lblPagingFin");
            lblPage2.Text = Registros.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected Dictionary<string, string> SetRutaVentana()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("idSesion", idSesionOculto.Value);
        data.Add("codUsuario", codUsuarioOculto.Value);
        data.Add("idPagina", pantallaIdOculto.Value);
        data.Add("nombrePagina", pantallaNombreOculto.Value);
        data.Add("moduloPagina", pantallaModuloOculto.Value);
        data.Add("tituloPagina", pantallaTituloOculto.Value);

        return data;
    }

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsSesiones.Url = ConfigurationManager.AppSettings["SesionesWCF"].ToString();
            wsSeguridad.Url = ConfigurationManager.AppSettings["SeguridadWS"].ToString();
            wsListas.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    #region MASTER GRIDVIEW

    private void BindGridView(GridView _gridView, List<ParametrosBienesEntidad> _lista)
    {
        _gridView.DataSource = _lista;
        _gridView.DataBind();
    }

    protected void gridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell tc = new TableCell();
            CheckBox cb = new CheckBox();
            cb.ID = "chkBox1";
            tc.Controls.Add(cb);
            tc.Width = Unit.Pixel(5);

            e.Row.Cells.Add(tc);
        }
    }

    private int ContadorSeleccionados()
    {
        int cantidad = 0;

        //VERIFICA QUE SOLO EXISTA UN REGISTRO SELECCIONADO PARA LA EDICION
        foreach (GridViewRow row1 in gridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)gridView.Rows[row1.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                cantidad++;
            }
        }

        return cantidad;
    }

    #endregion

    #region MENSAJE CONFIRMAR
    
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
    
    protected void InformarBox1_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBox1.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje);
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
                #region WEB SERVICES

                if (wsListas != null)
                {
                    wsListas.Dispose();
                    wsListas = null;
                }

                if (wsSeguridad != null)
                {
                    wsSeguridad.Dispose();
                    wsSeguridad = null;
                }
                if (wsSesiones != null)
                {
                    wsSesiones.Dispose();
                    wsSesiones = null;
                }

                #endregion
            }
            bitacoraFlags = null;

            mensajesEntidad = null;
            bitacorasEntidad = null;
            pantallasEntidad = null;
            consultaEntidad = null;
            consultaTotalFilas = null;

            paramUsuarios = null;

            disponible = true;
        }
    }

    #endregion

}
