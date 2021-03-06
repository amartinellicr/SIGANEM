﻿using System;
using System.Web;
using System.Data;
using System.Text;
using System.Linq;
using System.Web.UI;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

using SesionesWCF;
using GarantiasWS;
using SeguridadWS;
using ListasWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class Reales : System.Web.UI.Page
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

    #endregion

    #region CONTROLES

    private GridView gridView = null;
    private GridViewColumn gridViewColumna = null;

    private Button btnBuscar = null;
    private Button btnBuscarCancelar = null;
    
    private Button btnNuevo = null;
    private Button btnModificar = null;
    private Button btnEliminar = null;
    private Button btnActualizar = null;
    private Button btnExportarExcel = null;
    private Button btnGuardarNuevo = null;
    //Control de Cambios 1.2
    private Button btnNuevoId = null;

    private Label lblTitulo = null;
    private DropDownList ddlFiltro = null;

    private SliderExtender slider = null;

    private TextBox txtFiltro = null;
    private TextBox txtSlide = null;

    #endregion

    #region REFERENCIAS

    private BitacoraFlags bitacoraFlags = new BitacoraFlags(); 
    private RegistrarEventLog registroEventos = new RegistrarEventLog();
    private ListasWS.PantallasEntidad pantallasEntidad = new ListasWS.PantallasEntidad();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private GarantiasWS.BitacorasEntidad bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
    private GarantiasWS.GarantiasRealesEntidad garantiasRealesEntidad = new GarantiasWS.GarantiasRealesEntidad();
    private GarantiasWS.ParametrosConsultaEntidad consultaEntidad = new GarantiasWS.ParametrosConsultaEntidad();
    private GarantiasWS.ParametrosTotalFilasEntidad consultaTotalFilas = new GarantiasWS.ParametrosTotalFilasEntidad();

    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemGarantiasWS wsGarantias = new SiganemGarantiasWS();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();
    private SiganemListasWS wsListas = new SiganemListasWS();

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

                //// ASIGNA COLUMNAS PROPIAS DEL CONTROL
                this.gridView_Init(sender, e);

                //// ASIGNA EL EVENTO DE DATA BOUND
                this.gridView.RowCreated += new GridViewRowEventHandler(gridView_RowCreated);

                if (!Page.IsPostBack)
                {
                    #region ENTIDAD CONSULTA

                    consultaEntidad.IndiceInicioFila = (this.gridView.PageIndex * StaticParameters.RowCount);
                    consultaEntidad.MaximoFilas = StaticParameters.RowCount;
                    consultaEntidad.ValorFiltro = String.Empty;
                    consultaEntidad.ColumnaFiltro = "Codigo_Bien";
                    consultaEntidad.ColumnaOrdenar = "Codigo_Bien";

                    #endregion

                    // BINDEA EL GRIDVIEW
                    this.BindGridView(gridView, this.Consulta(consultaEntidad));
                }

                #region EVENTOS CLICK BOTONES

                // ASIGNA CONTROL Y EVENTO AL BOTON DE EXPORTAR EXCEL
                this.btnExportarExcel = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesExcel"));
                this.btnExportarExcel.Click += new EventHandler(btnExportarExcel_Click);

                // ASIGNA CONTROL Y EVENTO AL BOTON DE FILTRO
                this.btnBuscar = (Button)this.MasterGrid1.FindControl("imgBtnSearch");
                this.btnBuscar.Click += new EventHandler(btnBuscar_Click);

                // ASIGNA CONTROL Y EVENTO AL BOTON DE CLEAR
                this.btnBuscarCancelar = (Button)this.MasterGrid1.FindControl("imgBtnClear");
                this.btnBuscarCancelar.Click += new EventHandler(btnBuscarCancelar_Click);

                // ASIGNA CONTROL Y EVENTO AL BOTON DE NUEVO
                this.btnNuevo = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesNuevo"));
                this.btnNuevo.Click += new EventHandler(btnNuevo_Click);

                // ASIGNA CONTROL Y EVENTO AL BOTON DE NUEVO
                this.btnModificar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesModificar"));
                this.btnModificar.Click += new EventHandler(btnModificar_Click);

                // ASIGNA CONTROL Y EVENTO AL BOTON DE ELIMINAR
                this.btnEliminar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesEliminar"));
                this.btnEliminar.Click += new EventHandler(btnEliminar_Click);

                // ASIGNA CONTROL Y EVENTO AL BOTON DE ACTUALIZAR
                this.btnActualizar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesActualizar"));
                this.btnActualizar.Click += new EventHandler(btnActualizar_Click);

                // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR Y NUEVO
                this.btnGuardarNuevo = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardarNuevo"));
                this.btnGuardarNuevo.Click += new EventHandler(btnGuardarNuevo_Click);

                //Control de Cambios 1.2
                // ASIGNA CONTROL Y EVENTO AL BOTON DE NUEVO REGISTRO SEGUN UN ID
                this.btnNuevoId = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesNuevoId"));
                this.btnNuevoId.Click += new EventHandler(btnNuevoId_Click);
                                
                #endregion

                // ASIGNA DATA KEYS
                String[] dataKeysString = { "IdGarantiaReal" };
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

                // BUSCA LOS CONTROLES DE VISTA Y FILTROS
                this.ddlFiltro = ((DropDownList)this.MasterGrid1.FindControl("ddlfiltro"));
                this.txtFiltro = (TextBox)this.MasterGrid1.FindControl("txtFiltro");

                // CARGAR EL COMBO DE FILTRO
                this.CargarDDLFiltro();

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

                #region MENSAJE ELIMINAR

                Button btnAceptarEliminar = (Button)this.EliminarBox1.FindControl("wucBtnAceptar");
                btnAceptarEliminar.Click += new EventHandler(btnAceptarEliminar_Click);

                Button btnCancelarEliminar = (Button)this.EliminarBox1.FindControl("wucBtnCancelar");
                btnCancelarEliminar.Click += new EventHandler(btnCancelarEliminar_Click);

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
        gvTemplate.CrearCamposGridNoVisibles(gridView, "IdGarantiaReal", lblID);

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("DesTipoBien", string.Empty, "Tipo Bien", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("CodBien", string.Empty, "Número Bien", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("DesMontoTotalUltimaTasacion", string.Empty, "Monto Total Última Tasación", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("DesFechaUltimaTasacionGarantia", string.Empty, "Fecha Última Tasación", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("DesMontoTotalTasacionActualizada", string.Empty, "Monto Total Última Tasación Actualizada", HorizontalAlign.Center, false, true));

        this.gridViewColumna = new GridViewColumn();
        this.gridView.Columns.Add(this.gridViewColumna.CreateBoundField("DesFechaUltimoSeguimientoGarantia", string.Empty, "Fecha Último Seguimiento", HorizontalAlign.Center, false, true));
    }

    private void CargarDDLFiltro()
    {
        // CARGA EL DDL FILTRO CON LOS FILTROS CORRESPONDIENTES A CADA MANTENIMEINTO
        this.ddlFiltro.Items.Add(new ListItem("Tipo Bien", "Des_Tipo_Bien"));
        this.ddlFiltro.Items.Add(new ListItem("Número Bien", "Codigo_Bien"));
        this.ddlFiltro.Items.Add(new ListItem("Monto Total Última Tasación", "Des_Monto_Total_Ultima_Tasacion"));
        this.ddlFiltro.Items.Add(new ListItem("Fecha Última Tasación", "Des_Fecha_Ultima_Tasacion_Garantia"));
        this.ddlFiltro.Items.Add(new ListItem("Monto Total Última Tasación Actualizada", "Des_Monto_Total_Tasacion_Actualizada"));
        this.ddlFiltro.Items.Add(new ListItem("Fecha Último Seguimiento Garantía", "Des_Fecha_Ultimo_Seguimiento_Garantia"));
    }

    private void LimpiarGridView()
    {
        try
        {
            #region ENTIDAD CONSULTA

            consultaEntidad.IndiceInicioFila = (this.gridView.PageIndex * StaticParameters.RowCount);
            consultaEntidad.MaximoFilas = StaticParameters.RowCount;
            consultaEntidad.ValorFiltro = String.Empty;
            consultaEntidad.ColumnaFiltro = "Codigo_Bien";
            consultaEntidad.ColumnaOrdenar = "Codigo_Bien";

            #endregion
            this.txtFiltro.Text = String.Empty;
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

    protected void btnBuscarCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                LimpiarGridView();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                this.txtFiltro.Text = StaticParameters.RemoveSpecialCharacters(this.txtFiltro.Text);

                #region ENTIDAD CONSULTA

                consultaEntidad.IndiceInicioFila = (this.gridView.PageIndex * StaticParameters.RowCount);
                consultaEntidad.MaximoFilas = StaticParameters.RowCount;
                consultaEntidad.ValorFiltro = this.txtFiltro.Text;
                consultaEntidad.ColumnaFiltro = this.ddlFiltro.SelectedItem.Value;
                consultaEntidad.ColumnaOrdenar = "Codigo_Bien";

                #endregion

                // BINDEA EL GRIDVIEW
                this.BindGridView(gridView, this.Consulta(consultaEntidad));
                SetRegistrosLabelIndex();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (Page.IsPostBack)
                {
                    pantallaIdOculto.Value = "0";

                    HttpHelper post = new HttpHelper();
                    post.RedirectAndPOSTNewBigWindow(this.Page, "../Detalles/RealesNew.aspx", SetRutaVentana());
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
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
                                Label lbl = (Label)gridView.Rows[row.RowIndex].FindControl("lblIdGarantiaReal");
                                pantallaIdOculto.Value = lbl.Text;

                                HttpHelper post = new HttpHelper();
                                post.RedirectAndPOSTNewBigWindow(this.Page, "../Detalles/RealesNew.aspx", SetRutaVentana());
                                break;
                            }
                        }
                    }
                    else
                    { //SI EXISTE MÁS DE UN REGISTRO SELECCIONADO
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

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (Page.IsPostBack)
                {
                    foreach (GridViewRow row in gridView.Rows)
                    {
                        CheckBox checkBoxColumn = (CheckBox)gridView.Rows[row.RowIndex].FindControl("chkBox1");
                        if (checkBoxColumn.Checked)
                        {
                            this.mpeEliminarBox.Show();
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

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                LimpiarGridView();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void btnGuardarNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                LimpiarGridView();

                if (Page.IsPostBack)
                {
                    pantallaIdOculto.Value = "0";

                    HttpHelper post = new HttpHelper();
                    post.RedirectAndPOSTNewBigWindow(this.Page, "../Detalles/RealesNew.aspx", SetRutaVentana());
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void btnAceptarEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                GarantiasWS.RespuestaEntidad resultado = null;

                foreach (GridViewRow row in gridView.Rows)
                {
                    CheckBox checkBoxColumn = (CheckBox)gridView.Rows[row.RowIndex].FindControl("chkBox1");

                    if (checkBoxColumn.Checked)
                    {
                        #region ENTIDAD CONSULTA

                        Label lbl = (Label)gridView.Rows[row.RowIndex].FindControl("lblIdGarantiaReal");

                        pantallaIdOculto.Value = lbl.Text;
                        garantiasRealesEntidad.IdGarantiaReal = int.Parse(lbl.Text);
                        //REQUERIMIENTO: 1-24381561
                        garantiasRealesEntidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                        #endregion

                        resultado = this.Eliminar(garantiasRealesEntidad);
                    }
                }
                #region CONFIRMACIÓN ELIMINAR
                
                this.mpeInformarBox.Show();
                int valor = resultado.ValorEstado;
                int valorError = resultado.ValorError;

                if (valor != 0)
                {
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.DeleteOK.ToString());
                }
                else
                {
                    switch (valorError)
                    {
                        case 544: this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.PrimaryKey.ToString());
                            break;

                        case 547: this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.ForeignKey.ToString());
                            break;
                    }
                }

                #endregion
            }
        }
        catch (Exception ex)
        {
            //REGISTRA CADENA DE ERRORES EN LOG
            registroEventos.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);

            this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.DeleteErr.ToString());
            this.mpeInformarBox.Show();
        }
        finally
        {
            LimpiarGridView();
        }
    }

    protected void btnCancelarEliminar_Click(object sender, EventArgs e)
    {
        this.mpeEliminarBox.Hide();
    }

    protected void btnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBox.Hide();
    }

    //Control de Cambios 1.2  
    protected void btnNuevoId_Click(object sender, EventArgs e)
    {
        RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
        if (sesion.Codigo == 0)
        {
            if (Page.IsPostBack)
            {
                string[] ids = this.idGarantiaRealOculto.Value.Split(',');

                HttpHelper post;

                for (int i = 0; i < ids.Length; i++)
                {
                    idGarantiaRealOculto.Value = ids[i];
                    post = new HttpHelper();
                    post.RedirectAndPOSTNewBigWindow(this.Page, "../Detalles/RealesNew.aspx", SetRutaVentanaNuevoId(), ids[i]);
                }

                string[] idsOperaciones = this.idOperacionOculto.Value.Split(',');

                for (int i = 0; i < idsOperaciones.Length; i++)
                {
                    if (idsOperaciones[i].Length > 0)
                    {
                        idOperacionOculto.Value = idsOperaciones[i];
                        post = new HttpHelper();
                        post.RedirectAndPOSTNewBigWindow(this.Page, "../Detalles/OperacionesNew.aspx", SetRutaVentanaOperacionId(), idsOperaciones[i]);
                    }
                }


                LimpiarGridView();
            }
        }
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
                        if (Int32.Parse(this.txtSlide.Text) <= this.Registros)
                        {
                            StartRowIndex = intSlide * maxRows;
                            #region ENTIDAD CONSULTA

                            consultaEntidad.IndiceInicioFila = StartRowIndex;
                            consultaEntidad.MaximoFilas = maxRows;
                            consultaEntidad.ValorFiltro = this.txtFiltro.Text;
                            consultaEntidad.ColumnaFiltro = this.ddlFiltro.SelectedValue;
                            consultaEntidad.ColumnaOrdenar = "Codigo_Bien";

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
                            consultaEntidad.ValorFiltro = this.txtFiltro.Text;
                            consultaEntidad.ColumnaFiltro = this.ddlFiltro.SelectedValue;
                            consultaEntidad.ColumnaOrdenar = "Codigo_Bien";

                            #endregion
                            // BINDEA EL GRIDVIEW
                            this.BindGridView(gridView, this.Consulta(consultaEntidad));
                            lblPage1.Text = this.txtSlide.Text;
                        }
                        break;
                    case "Last":
                        if (Int32.Parse(this.txtSlide.Text) <= this.Registros)
                        {
                            this.txtSlide.Text = Convert.ToString((this.Registros));
                            StartRowIndex = (this.Registros - 1) * maxRows;
                            #region ENTIDAD CONSULTA

                            consultaEntidad.IndiceInicioFila = StartRowIndex;
                            consultaEntidad.MaximoFilas = maxRows;
                            consultaEntidad.ValorFiltro = this.txtFiltro.Text;
                            consultaEntidad.ColumnaFiltro = this.ddlFiltro.SelectedValue;
                            consultaEntidad.ColumnaOrdenar = "Codigo_Bien";

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
                            consultaEntidad.ValorFiltro = this.txtFiltro.Text;
                            consultaEntidad.ColumnaFiltro = this.ddlFiltro.SelectedValue;
                            consultaEntidad.ColumnaOrdenar = "Codigo_Bien";

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
                consultaEntidad.ValorFiltro = this.txtFiltro.Text;
                consultaEntidad.ColumnaFiltro = this.ddlFiltro.SelectedItem.Value;
                consultaEntidad.ColumnaOrdenar = "Codigo_Bien";

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

    private GarantiasWS.RespuestaEntidad Eliminar(GarantiasWS.GarantiasRealesEntidad _entidad)
    {
        return wsGarantias.GarantiasRealesEliminar(_entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));
    }
    
    private Int32 TotalFilas(GarantiasWS.ParametrosTotalFilasEntidad _entidad)
    {
        return wsGarantias.GarantiasRealesTotalFilas(_entidad);        
    }
    
    private List<GarantiasRealesEntidad> Consulta(GarantiasWS.ParametrosConsultaEntidad _entidad)
    {
        return (wsGarantias.GarantiasRealesConsultar(_entidad)).ToList();
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
                    }
                }
                #endregion
                ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesMasAcciones(false);
                ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trEjecutarIPC")).Attributes.Add("style", "display:none");
                ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trEjecutarTC")).Attributes.Add("style", "display:none");
                ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trCopiarRol")).Attributes.Add("style", "display:none");

                int permiso = wsSeguridad.UsuariosValidarAcceso(codUsuarioOculto.Value, pagina);
                if (permiso.Equals(0))
                {

                    HttpHelper httpPost = new HttpHelper();
                    Dictionary<string, string> dataSesion = new Dictionary<string, string>();
                    dataSesion.Add("idSesion", idSesionOculto.Value);
                    dataSesion.Add("codUsuario", codUsuarioOculto.Value);
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

            consultaTotalFilas.ValorFiltro = this.txtFiltro.Text;
            consultaTotalFilas.ColumnaFiltro = this.ddlFiltro.SelectedValue;

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
                    this.Registros = n;
                }
                else
                {
                    int n = (int)redondeo;
                    slider.Maximum = n;
                    slider.Steps = n;
                    this.Registros = n;
                }

                Label lblPage1 = (Label)this.MasterPager1.FindControl("lblPagingIni");
                lblPage1.Text = (this.gridView.PageIndex + 1).ToString();
                this.txtSlide.Text = (this.gridView.PageIndex + 1).ToString();
            }
            else
            {
                this.Registros = ((int)redondeo);

                Label lblPage1 = (Label)this.MasterPager1.FindControl("lblPagingIni");
                lblPage1.Text = "0";
            }

            Label lblPage2 = (Label)this.MasterPager1.FindControl("lblPagingFin");
            lblPage2.Text = this.Registros.ToString();
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

    protected Dictionary<string, string> SetRutaVentanaNuevoId()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("idSesion", idSesionOculto.Value);
        data.Add("codUsuario", codUsuarioOculto.Value);
        data.Add("idPagina", idGarantiaRealOculto.Value);
        data.Add("nombrePagina", pantallaNombreOculto.Value);
        data.Add("moduloPagina", pantallaModuloOculto.Value);
        data.Add("tituloPagina", pantallaTituloOculto.Value);

        return data;
    }

    protected Dictionary<string, string> SetRutaVentanaOperacionId()
    {
        List<SeguridadWS.PantallasEntidad> pantallas = wsSeguridad.PantallasConsulta().ToList();
        var retorno = (from pantalla in pantallas
                       where pantalla.CodPantalla.Equals(24)
                       select pantalla).FirstOrDefault();

        string[] tituloPagina = retorno.RutaPantalla.Replace(".aspx", "").Split('/');


        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("idSesion", idSesionOculto.Value);
        data.Add("codUsuario", codUsuarioOculto.Value);
        data.Add("idPagina", idOperacionOculto.Value);
        data.Add("nombrePagina", tituloPagina[tituloPagina.Length - 1]);
        data.Add("moduloPagina", retorno.CodPantalla.ToString());
        data.Add("tituloPagina", retorno.TituloPantalla);

        return data;
    }

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsSesiones.Url = ConfigurationManager.AppSettings["SesionesWCF"].ToString();
            wsSeguridad.Url = ConfigurationManager.AppSettings["SeguridadWS"].ToString();
            wsGarantias.Url = ConfigurationManager.AppSettings["GarantiasWS"].ToString();
            wsListas.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    protected GarantiasWS.BitacorasEntidad AsignarValoresBitacora(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA

            bitacorasEntidad.CodAccion = bitacoraFlags.TipoBitacoraConsulta(_tipo);
            bitacorasEntidad.CodModulo = int.Parse(pantallaModuloOculto.Value);
            bitacorasEntidad.CodEmpresa = int.Parse(Resources.Resource._empresa);
            bitacorasEntidad.CodSistema = Resources.Resource._sistema;
            bitacorasEntidad.CodUsuario = codUsuarioOculto.Value;

            #endregion

            return bitacorasEntidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    #region MASTER GRIDVIEW
    
    private void BindGridView(GridView _gridView, List<GarantiasRealesEntidad> _lista)
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

            e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
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

                if (wsGarantias != null)
                {
                    wsGarantias.Dispose();
                    wsGarantias = null;
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

                if (wsListas != null)
                {
                    wsListas.Dispose();
                    wsListas = null;
                }

                #endregion
            }
            bitacoraFlags = null;
            registroEventos = null;

            mensajesEntidad = null;
            pantallasEntidad = null;
            bitacorasEntidad = null;
            consultaEntidad = null;
            consultaTotalFilas = null;

            garantiasRealesEntidad = null;

            disponible = true;
        }
    }

    #endregion

}