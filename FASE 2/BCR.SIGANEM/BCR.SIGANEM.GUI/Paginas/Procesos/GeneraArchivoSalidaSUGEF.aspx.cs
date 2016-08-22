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
using ConfiguracionWS;
using ConsultasWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class GeneraArchivoSalidaSUGEF : System.Web.UI.Page
{
    #region PROPIEDADES

    #region REFERENCIAS

    private BitacoraFlags bitacoraFlags = new BitacoraFlags();
    private RegistrarEventLog registroEventos = new RegistrarEventLog();
    private GeneradorControles generadorControles = new GeneradorControles();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private GarantiasWS.BitacorasEntidad bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
    private SeguridadWS.PantallasEntidad pantallasEntidad = new SeguridadWS.PantallasEntidad();
    private SeguridadWS.BitacorasEntidad bitacorasSeguridadEntidad = new SeguridadWS.BitacorasEntidad();

    private ConsultasWS.ParametrosConsultaEntidad consultaEntidad = new ConsultasWS.ParametrosConsultaEntidad();
    private ConsultasWS.ParametrosTotalFilasEntidad consultaTotalFilas = new ConsultasWS.ParametrosTotalFilasEntidad();

    private SiganemListasWS wsLista = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();
    private SiganemConfiguracionWS wsConfiguracion = new SiganemConfiguracionWS();
    private SiganemConsultasWS wsConsultas = new SiganemConsultasWS();

    #endregion

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

    private HttpHelper httpPost = null;
    private NameValueCollection dataSesion = null;

    private string filtro = string.Empty;
    private string valorReemplazo = string.Empty;
    static string ddlValorSeleccionado = string.Empty;

    private List<ControlEntidad> controlEntidad = null;
    private ControlEntidad controlSeleccionado = null;

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

            #region CONTROL SLIDER

            //SetRegistrosLabelIndex();

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
            ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trDescargaArchivo")).Attributes.Add("style", "display:none");

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                Controles();

                if (AccesoPermisoPagina())
                {
                    if (!IsPostBack)
                    {
                        this.Master.RefrescarDatosUsuario();
                        this.MasterPager1.Visible = false;
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
                this.lblTituloPage.Text = pantallasEntidad.TituloPantalla;

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

                TableCell tcArchivo = (TableCell)this.tableData.FindControl("tcRow0Cell0");
                tcArchivo.VerticalAlign = VerticalAlign.Top;
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
                            //dropDownList.AutoPostBack = true;
                            //dropDownList.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);

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
                                        //ddlAssocID.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);
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

                        #region CHECKBOXLIST
                        case "CHECKBOXLIST":
                            CheckBoxList chkList = new CheckBoxList();
                            chkList.ID = codeName;
                            chkList.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            chkList.ToolTip = String.Concat("Lista de ", control.DesColumna);
                            chkList.Enabled = bool.Parse(control.IndModificar);
                            chkList.Visible = bool.Parse(control.IndVisible);
                            chkList.CssClass = control.CssTipo;
                            chkList.Width = Unit.Parse("100%");
                            // string spText2 = control.MetodoServicioWeb;

                            if (String.IsNullOrEmpty(control.MetodoServicioWeb))
                            {
                                chkList.Items.Add(new ListItem("No hay Datos", "-1"));
                                flag = 0; //NO HAY ITEMS
                            }
                            else
                            {
                                flag = 1; //EXISTEN ITEMS
                                chkList.Items.Clear();

                                chkList.DataSource = LlenarDropDownList(control.MetodoServicioWeb, string.Empty);
                                chkList.DataTextField = "Texto";
                                chkList.DataValueField = "Valor";
                                chkList.DataBind();
                            }

                            if (!string.IsNullOrEmpty(control.IndValorDefecto))
                            {
                                if (bool.Parse(control.IndValorDefecto))
                                {
                                    for (int i = 0; i < chkList.Items.Count; i++)
                                    {
                                        if (chkList.Items[i].Text.Equals(control.ValorDefecto))
                                            chkList.SelectedIndex = i;
                                    }
                                }
                            }

                            tc2.Controls.Add(chkList);

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

                            //   if (String.IsNullOrEmpty(spText2))
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
                            //checkDropDownList.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);

                            cell_1.Controls.Add(checkDropDownList);


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


    #endregion

    #region METODOS CONTROLES

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

                #region BUSQUEDA DE CONTROLES

                CheckBoxList chkList = (CheckBoxList)this.tableData.FindControl("Archivo");
                bool bandera = false;
                byte generar = 1;

                #endregion

                for (int i = 0; i < chkList.Items.Count; i++)
                {

                    if (chkList.Items[i].Selected)
                    {
                        //LOGICA QUE NECESITA REALIZAR CON EL ELEMENTO SELECCIONADO  
                        wsConfiguracion.EjecutarArchivo(int.Parse(chkList.Items[i].Value), generar, AsignarValoresBitacoraC(EnumTipoBitacora.ACTUALIZAR));

                        bandera = true;
                        //chkList.Items[i].Value

                    }

                }

                if (bandera)
                {
                    //SI LA GENERACION FUE EXITOSA
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_1");
                    this.mpeInformarBox.Show();
                }
                else
                {
                    //SI NO EXISTE NINGUN REGISTRO SELECCIONADO
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_42");
                    this.mpeInformarBox.Show();
                }
                //pantallaIdOculto.Value = "0";

                ////SI NO EXISTEN ERRORES DE VALIDACION
                //if (!ExisteError())
                //{
                //    #region BUSQUEDA DE CONTROLES

                //    DropDownList ddlProceso = (DropDownList)this.tableData.FindControl("IdProceso");
                //    TextBox txtFechaDesde = (TextBox)this.tableData.FindControl("FechaDesde");
                //    TextBox txtFechaHasta = (TextBox)this.tableData.FindControl("FechaHasta");

                //    #endregion

                //    #region ENTIDAD CONSULTA

                //    consultaEntidad.IndiceInicioFila = (this.gridView.PageIndex * StaticParameters.RowCount);
                //    consultaEntidad.MaximoFilas = StaticParameters.RowCount;

                //    BitacoraProcesosConsulta consulta = new BitacoraProcesosConsulta();
                //    consulta.IdProceso = int.Parse(ddlProceso.SelectedValue);
                //    consulta.FechaDesde = DateTime.Parse(txtFechaDesde.Text);
                //    consulta.FechaHasta = DateTime.Parse(txtFechaHasta.Text);

                //    #endregion

                //    this.BindGridView(gridView, this.Consulta(consulta, consultaEntidad));

                //    this.MasterPager1.Visible = true;

                //    SetRegistrosLabelIndex();

                //    }
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
            wsConsultas.Url = ConfigurationManager.AppSettings["ConsultasWS"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(ConfigurationManager.AppSettings["Culture"].ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ConfigurationManager.AppSettings["Culture"].ToString());
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