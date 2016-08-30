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

using SesionesWCF;
using SeguridadWS;
using GarantiasWS;
using ListasWS;

using BCRClientesWS;
using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class FiduciariasNew : System.Web.UI.Page
{

    #region PROPIEDADES

    #region VARIABLES

    private int tipoAccion = 0;
    private int banderaVentana = 0;
    private int resultadoProceso = 0;

    private string filtro = string.Empty;
    private string valorReemplazo = string.Empty;
    static string ddlValorSeleccionado = string.Empty;

    #endregion

    #region CONTROLES

    private Button btnAyudaGuardar = null;
    private Button btnAyudaCerrar = null;

    private Button btnGuardar = null;
    private Button btnLimpiar = null;

    private Button btnGuardarNuevo = null;
    private Button btnGuardarCerrar = null;
    private Button btnCancelar = null;

    #region BCR CLIENTES

    private GridView gridViewClientes = null;
    private Button btnCerrar = null;
    private Button btnAceptar = null;

    #endregion

    #endregion

    #region REFERENCIAS

    private BitacoraFlags bitacoraBanderas = new BitacoraFlags();
    private GeneradorControles generadorControles = new GeneradorControles();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private GarantiasWS.BitacorasEntidad bitacorasEntidad = new GarantiasWS.BitacorasEntidad();

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();
    private SiganemGarantiasWS wsGarantias = new SiganemGarantiasWS();
    private SiganemBCRClientesWS wsBCRClientes = new SiganemBCRClientesWS();
    
    #endregion

    #endregion

    #region METODOS PERSONALIZADOS EDITABLES

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            //ASIGNA LA RUTA DE LOS SERVICIOS WEB DEL WEB.CONFIG
            AsignaWebServicesTypeNames();

            #region EVENTOS CLICK BOTONES

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR DE LA PESTANA SUPERIOR IZQUIERDA NEGRA
            this.btnAyudaGuardar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAyuda").FindControl("cmdAyudaGuardar"));
            this.btnAyudaGuardar.Click += new EventHandler(btnAyudaGuardar_Click);

            // ASIGNA CONTROL Y EVENTO AL BOTON DE MODIFICAR
            this.btnAyudaCerrar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAyuda").FindControl("cmdAyudaRegresar"));
            this.btnAyudaCerrar.Click += new EventHandler(btnAyudaCerrar_Click);
            this.btnAyudaCerrar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR PRINCIPAL
            this.btnGuardar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardar"));
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);

            // ASIGNA CONTROL Y EVENTO AL BOTON DE LIMPIAR
            this.btnLimpiar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesLimpiar"));
            this.btnLimpiar.Click += new EventHandler(btnLimpiar_Click);
            this.btnLimpiar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR Y NUEVO
            this.btnGuardarNuevo = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardarNuevo"));
            this.btnGuardarNuevo.Click += new EventHandler(btnGuardarNuevo_Click);

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR Y CERRAR
            this.btnGuardarCerrar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardarCerrar"));
            this.btnGuardarCerrar.Click += new EventHandler(btnGuardarCerrar_Click);

            // ASIGNA CONTROL Y EVENTO AL BOTON DE CANCELAR
            this.btnCancelar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesRegresar"));
            this.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            this.btnCancelar.CausesValidation = false;

            #region MENSAJE INFORMAR

            Button btnAceptarInformar = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);
            btnAceptarInformar.CausesValidation = false;
            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

            #endregion

            if (!IsPostBack)
            {
                //LLAMADO A LOS EVENTOS QUE CREAN LOS CONTROLES EN EL FORMULARIO
                VariablesGlobales();
                valorReemplazo = string.Empty;
            }
            //else
            //{
            //    Set_RutaVentana();
            //}

            #region BCR CLIENTES

            #region GRIDVIEW

            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridViewClientes = (GridView)this.BCRClientes.FindControl("MasterGridView");
            this.BCRClientes.TextoGridVacio("Cliente no existe en BCR Clientes.");
            this.gridViewClientes.Init += new EventHandler(gridView_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridView_Init(sender, e);

            #endregion

            #region BOTONES

            btnCerrar = ((Button)this.BCRClientes.FindControl("cmdMainEmergenteCancelar"));
            btnCerrar.Click += new EventHandler(btnCerrar_Click);
            btnCerrar.CausesValidation = false;

            btnAceptar = ((Button)this.BCRClientes.FindControl("cmdMainEmergenteAceptar"));
            btnAceptar.Click += new EventHandler(btnAceptar_Click);
            btnAceptar.CausesValidation = false;

            #region MENSAJE INFORMAR BCR CLIENTES

            Button btnAceptarInformarClientes = (Button)this.InformarBoxBusqueda.FindControl("wucBtnAceptar");
            btnAceptarInformarClientes.Click += new EventHandler(btnAceptarInformarClientes_Click);
            this.InformarBoxBusqueda.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxBusqueda_SetConfirmationBoxEvent);

            #endregion

            #endregion

            if (!Page.IsPostBack)
            {
                //TITULOS
                ((Label)this.BCRClientes.FindControl("lblTitulo")).Text = "Información BCR Clientes";
                ((Label)this.BCRClientes.FindControl("lblSubTitulo")).Text = "Seleccione un registro.";

                //ASIGNA DATA KEYS
                String[] dataKeysString = { "IdSICC" };
                this.SetDataKeys(gridViewClientes, dataKeysString);
            }

            #endregion
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Tabs();
            Controles();

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {                
                if (!IsPostBack)
                {
                    ControlesItemBlanco();
                    //CARGA LOS VALORES PARA LOS TITULOS
                    Etiquetas();
                    //CARGA LOS VALORES DESDE BD PARA EL CASO DE LAS MODIFICACIONES
                    DeEntidadAControles(); 
                    ControlesSoloLecturaExcepciones();
                    DeshabilitarControlesExcepciones();
                }
            }
            else
            {
                // MENSAJE SESIÓN CADUCADA
                this.InformarBox1_SetConfirmationBoxEvent(null, e, EnumTipoMensaje.Caducado.ToString());
                this.mpeInformarBox.Show();
                BloquearControlesGuardar();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    //Requerimiento Bloque 7 1-24381561
    #region CONTROL DE REGISTRO

    /*ASIGNA LOS VALORES DEL CONTROL DE REGISTRO A LA ENTIDAD EN MODO NUEVO*/
    private void CrearControlRegistros(object _entidad, PropertyInfo _propiedad)
    {
        try
        {
            string lblCodigoUsuario = ((HtmlInputHidden)this.Master.FindControl("codUsuarioOculto")).Value;

            switch (_propiedad.Name.ToUpper())
            {
                case "INDMETODOINSERCION":
                    _propiedad.SetValue(_entidad, Resources.Resource._metodoInsercion, null);
                    break;
                case "CODUSUARIOINGRESO":
                    _propiedad.SetValue(_entidad, lblCodigoUsuario, null);
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void MostrarControlRegistrosGuardar()
    {
        try
        {
            var resultado = ConsultarDetalleEntidad();
            if (resultado != null)
            {
                PropertyInfo[] propiedadesDetalle = resultado.GetType().GetProperties();
                foreach (PropertyInfo propiedadDetalle in propiedadesDetalle)
                {
                    ObtenerControlRegistros(resultado, propiedadDetalle);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*OBTIENE LOS DATOS DEL CONTROL DE REGISTRO EN MODO EDICION*/
    private void ObtenerControlRegistros(object _entidad, PropertyInfo _propiedad)
    {
        try
        {
            Label lblCreadoPor = (Label)this.Master.FindControl("Propiedades1").FindControl("lblCreadoPor");
            Label lblModificadoPor = (Label)this.Master.FindControl("Propiedades1").FindControl("lblModificadoPor");
            Label lblFechaCreacion = (Label)this.Master.FindControl("Propiedades1").FindControl("lblFechaCreacion");
            Label lblFechaModificacion = (Label)this.Master.FindControl("Propiedades1").FindControl("lblFechaModificacion");
            Label lblFuente = (Label)this.Master.FindControl("Propiedades1").FindControl("lblFuente");


            switch (_propiedad.Name.ToUpper())
            {
                case "INDMETODOINSERCION":
                    lblFuente.Text = _propiedad.GetValue(_entidad, null).ToString();
                    break;
                case "CODUSUARIOINGRESO":
                    lblCreadoPor.Text = _propiedad.GetValue(_entidad, null).ToString();
                    break;
                case "DESUSUARIOINGRESO":
                    if (lblCreadoPor.Text.Length > 0)
                    {
                        lblCreadoPor.ToolTip = lblCreadoPor.Text + " | " + _propiedad.GetValue(_entidad, null).ToString();
                        lblCreadoPor.Text = (lblCreadoPor.ToolTip).Substring(0, 21);
                    }
                    break;
                case "FECHAINGRESO":
                    if (_propiedad.GetValue(_entidad, null) != null)
                        lblFechaCreacion.Text = DateTime.Parse(_propiedad.GetValue(_entidad, null).ToString()).ToString();
                    else
                        lblFechaCreacion.Text = string.Empty;
                    break;
                case "CODUSUARIOULTIMAMODIFICACION":
                    lblModificadoPor.Text = _propiedad.GetValue(_entidad, null).ToString();
                    break;
                case "DESUSUARIOULTIMAMODIFICACION":
                    if (lblModificadoPor.Text.Length > 0)
                    {
                        lblModificadoPor.ToolTip = lblModificadoPor.Text + " | " + _propiedad.GetValue(_entidad, null).ToString();
                        lblModificadoPor.Text = (lblModificadoPor.ToolTip).Substring(0, 21);
                    }
                    break;
                case "FECHAULTIMAMODIFICACION":
                    if (_propiedad.GetValue(_entidad, null) != null)
                        lblFechaModificacion.Text = DateTime.Parse(_propiedad.GetValue(_entidad, null).ToString()).ToString();
                    else
                        lblFechaModificacion.Text = string.Empty;
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region EXCEPCIONES

    /*VALIDACION AL GUARDAR EXCEPCION*/
    private bool ValidarGuardarExcepciones()
    {
        #region BUSQUEDA DE CONTROLES

        TextBox txtCodGarantia = ((TextBox)this.tableData.FindControl("CodGarantia"));
        //True = OK  False = NO SE PERMITE GUARDAR
        bool retorno = true; 

        #endregion

        if (txtCodGarantia != null)
        {
            //NO PERMITE GUARDAR SI LOS CAMPOS NO ESTAN COMPLETOS
            if (txtCodGarantia.Text.Length < 1)
                retorno = false;
        }

        return retorno; 
    }

    /*ESTABLE LAS EXCEPCIONES EN LA CARGA DE VALORES DE LOS CONTROLES A ENTIDAD*/
    private string DeControlesAEntidadExcepciones(string propiedad, string valor)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            DropDownList ddlIdTipoIdentificacionRUC = ((DropDownList)this.tableData.FindControl("TipoIdentificacionRUC"));
            string retorno = valor;

            #endregion

            //ASIGNA EL VALOR DEL ID DEL COMBO TIPO IDENTIFICACION RUC A LA PROPIEDAD IDTIPOIDENTIFICACIONRUC
            if (propiedad.Equals("IdTipoIdentificacionRUC"))
            {
                if (ddlIdTipoIdentificacionRUC != null)
                {
                    foreach (ListItem item in ddlIdTipoIdentificacionRUC.Items)
                    {
                        if (item.Text.Equals(valor))
                            retorno = item.Value;
                    }
                }
            }
            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ESTABLE LAS EXCEPCIONES EN LA CARGA DE VALORES DE LA ENTIDAD A LOS CONTROLES*/
    private void DeEntidadAControlesExcepciones(List<KeyValuePair<string, string>> entidad)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            DropDownList ddlTipoIdentificacionRUC = ((DropDownList)this.tableData.FindControl("TipoIdentificacionRUC"));
            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlIdPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlIdCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlIdCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));
            TextBox txtIdTipoIdentificacionRUC = ((TextBox)this.tableData.FindControl("IdTipoIdentificacionRUC"));
            TextBox txtGarantia = ((TextBox)this.tableData.FindControl("Garantia"));
            TextBox txtIdGarantia = ((TextBox)this.tableData.FindControl("CodGarantia"));
            TextBox txtSalarioNetoFiador = ((TextBox)this.tableData.FindControl("SalarioNetoFiador"));
            TextBox txtFechaVerificacionAsalariado = ((TextBox)this.tableData.FindControl("FechaVerificacionAsalariado"));
            MaskedEditExtender mskGarantia = ((MaskedEditExtender)this.tableData.FindControl("maskGarantia"));

            int elementos = 0;

            #endregion
            
            //ELIMINA LA MASCARA SI EL TIPO DE IDENTIFICACION ES IGUAL A 5 Y ASIGNA EL VALOR CORRESPONDIENTE DESDE BD
            if (ddlTipoIdentificacionRUC != null)
            {
                generadorControles.SeleccionarOpcionDropDownList(ddlTipoIdentificacionRUC, txtIdTipoIdentificacionRUC.Text);

                if (ddlTipoIdentificacionRUC.SelectedItem.Text.Substring(0, 3).Equals("5 -"))
                {
                    for (elementos = 0; elementos < entidad.Count; elementos++)
                    {
                        //if (entidad[elementos].Key.ToString().Equals("TipoIdentificacionRUC"))
                        if (entidad[elementos].Key.ToString().Equals("CodGarantia"))
                        {
                            mskGarantia.Enabled = false;
                            txtGarantia.Text = entidad[elementos].Value.ToString();
                        }
                    }
                }
            }

            if ((ddlTipoIdentificacionRUC != null) && (txtIdTipoIdentificacionRUC != null))
            {
                //ASIGNAR EL VALOR SELECCIONADO AL DDL TIPO IDENTIFICACION RUC
                generadorControles.SeleccionarOpcionDropDownList(ddlTipoIdentificacionRUC, txtIdTipoIdentificacionRUC.Text);
                //ASIGNAR EL TEXTO DEL DDL TIPO IDENTIFICACION RUC AL TXT TIPO ID RUC
                txtIdTipoIdentificacionRUC.Text = ddlTipoIdentificacionRUC.SelectedItem.Text;
            }

            if ((txtGarantia != null) && (txtIdGarantia != null))
            {
                //ASIGNAR AL TXT ID GARANTIA EL VALOR DEL TXT ID FIADOR
                txtGarantia.Text = txtIdGarantia.Text;
            }

            //EFECTOS SEGUN EL VALOR DEL COMBO TIPO AVAL O FIANZAS
            ddlTipoAvalFianza(null);
            for (elementos = 0; elementos < entidad.Count; elementos++)
            {
                if (entidad[elementos].Key.ToString().Equals("SalarioNetoFiador"))
                    txtSalarioNetoFiador.Text = entidad[elementos].Value.ToString();
                if (entidad[elementos].Key.ToString().Equals("FechaVerificacionAsalariado"))
                    if (entidad[elementos].Value.ToString().Trim().Length > 0)
                        txtFechaVerificacionAsalariado.Text = DateTime.Parse(entidad[elementos].Value.ToString()).ToShortDateString();
            }

            //EFECTOS SEGUN EL VALOR DEL COMBO TIPO ASIGNACION CALIFICACION
            ddlTipoAsignacionCalificacion(null);

            //CARGA DE EMPRESAS CALIFICADORAS
            if (ddlIdEmpresaCalificadora != null && ddlIdPlazoCalificacion != null)
            {
                if (!ddlIdPlazoCalificacion.SelectedValue.Equals("-1"))
                {
                    LimpiarDropDownList(ddlIdEmpresaCalificadora);

                    //CARGA LOS DATOS AL DDL
                    ddlIdEmpresaCalificadora.DataSource = wsListas.EmpresasCalificadorasLista(ddlIdPlazoCalificacion.SelectedValue).ToList();
                    ddlIdEmpresaCalificadora.DataTextField = "Texto";
                    ddlIdEmpresaCalificadora.DataValueField = "Valor";
                    ddlIdEmpresaCalificadora.DataBind();

                    //ASIGNA EL VALOR EXTRAIDO AL DDL
                    for (elementos = 0; elementos < entidad.Count; elementos++)
                    {
                        if (entidad[elementos].Key.ToString().Equals("IdEmpresaCalificadora"))
                            ddlIdEmpresaCalificadora.SelectedValue = entidad[elementos].Value.ToString();
                    }
                }
            }

            //ASIGNA EL VALOR EXTRAIDO AL DDL CATEGORIA RIESGO EMPRESA CALIFICADORA
            for (elementos = 0; elementos < entidad.Count; elementos++)
            {
                if (entidad[elementos].Key.ToString().Equals("IdCategoriaRiesgoEmpresaCalificadora"))
                    ddlIdCategoriaRiesgoEmpresaCalificadora.SelectedValue = entidad[elementos].Value.ToString();
            }

            if ((ddlIdCalificacionEmpresaCalificadora != null) && (ddlIdEmpresaCalificadora != null) && (ddlIdCategoriaRiesgoEmpresaCalificadora != null))
            {
                if (!ddlIdEmpresaCalificadora.SelectedValue.Equals("-1"))
                {
                    LimpiarDropDownList(ddlIdCalificacionEmpresaCalificadora);

                    //CARGA LOS DATOS AL DDL
                    ddlIdCalificacionEmpresaCalificadora.DataSource = wsListas.CalificacionesEmpresasCalificadorasCalificacionLista(ddlIdEmpresaCalificadora.SelectedValue + "|" + ddlIdCategoriaRiesgoEmpresaCalificadora.SelectedValue).ToList();
                    ddlIdCalificacionEmpresaCalificadora.DataTextField = "Texto";
                    ddlIdCalificacionEmpresaCalificadora.DataValueField = "Valor";
                    ddlIdCalificacionEmpresaCalificadora.DataBind();

                    //ASIGNA EL VALOR EXTRAIDO AL DDL
                    for (elementos = 0; elementos < entidad.Count; elementos++)
                    {
                        if (entidad[elementos].Key.ToString().Equals("IdCalificacionEmpresaCalificadora"))
                            ddlIdCalificacionEmpresaCalificadora.SelectedValue = entidad[elementos].Value.ToString();
                    }

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ESTABLECE LOS CONTROLES QUE SON SOLO LECTURA*/
    private void ControlesSoloLecturaExcepciones()
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            TextBox txtNombreRUC = ((TextBox)(this.tableData.FindControl("NombreRUC")));
            TextBox txtTipoIdentificacionRUC = ((TextBox)(this.tableData.FindControl("IdTipoIdentificacionRUC")));
            TextBox txtCodGarantia = ((TextBox)(this.tableData.FindControl("CodGarantia")));

            #endregion

            if ((txtNombreRUC != null) && (txtTipoIdentificacionRUC != null) && (txtCodGarantia != null))
            {
                txtNombreRUC.Attributes.Add("readonly", "readonly");
                txtNombreRUC.ToolTip += ". Protegido.";
                txtTipoIdentificacionRUC.Attributes.Add("readonly", "readonly");
                txtTipoIdentificacionRUC.ToolTip += ". Protegido.";
                txtCodGarantia.Attributes.Add("readonly", "readonly");
                txtCodGarantia.ToolTip += ". Protegido.";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*DESHABILITA LOS CONTROLES AL INGRESAR A LA PANTALLA*/
    private void DeshabilitarControlesExcepciones()
    {
        #region BUSQUEDA DE CONTROLES

        TextBox txtIdentificacionSICC = ((TextBox)(this.tableData.FindControl("IdentificacionSICC")));
        TextBox txtTipoIdentificacionRUC = ((TextBox)(this.tableData.FindControl("IdTipoIdentificacionRUC")));
        TextBox txtCodGarantia = ((TextBox)(this.tableData.FindControl("CodGarantia")));
        TextBox txtGarantia = ((TextBox)(this.tableData.FindControl("Garantia")));
        TextBox txtNombreRUC = ((TextBox)(this.tableData.FindControl("NombreRUC")));
        DropDownList ddlIdTipoAvalFianza = ((DropDownList)(this.tableData.FindControl("IdTipoAvalFianza")));
        DropDownList ddlIdTipoAsignacionCalificacion = ((DropDownList)(this.tableData.FindControl("IdTipoAsignacionCalificacion")));
        DropDownList ddlIdPlazoCalificacion = ((DropDownList)(this.tableData.FindControl("IdPlazoCalificacion")));
        DropDownList ddlIdEmpresaCalificadora = ((DropDownList)(this.tableData.FindControl("IdEmpresaCalificadora")));
        DropDownList ddlIdCategoriaRiesgoEmpresaCalificadora = ((DropDownList)(this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora")));
        DropDownList ddlIdCalificacionEmpresaCalificadora = ((DropDownList)(this.tableData.FindControl("IdCalificacionEmpresaCalificadora")));
        DropDownList ddlTipoIdentificacionRUC = ((DropDownList)(this.tableData.FindControl("TipoIdentificacionRUC")));
        TextBox txtSalarioNetoFiador = ((TextBox)(this.tableData.FindControl("SalarioNetoFiador")));
        TextBox txtFechaVerificacionAsalariado = ((TextBox)(this.tableData.FindControl("FechaVerificacionAsalariado")));
        ImageButton imbFechaVerificacionAsalariado = ((ImageButton)this.tableData.FindControl("imgBtnCalendarExtenderFechaVerificacionAsalariado"));
        RequiredFieldValidator rfvFechaVerificacionAsalariado = ((RequiredFieldValidator)this.tableData.FindControl("rfvFechaVerificacionAsalariado"));
        //RequiredFieldValidator rfvSalarioNetoFiador = ((RequiredFieldValidator)this.tableData.FindControl("rfvSalarioNetoFiador"));
        TextBoxWatermarkExtender wmSalarioNetoFiador = ((TextBoxWatermarkExtender)this.tableData.FindControl("wmSalarioNetoFiador"));

        #endregion

        //REGISTRO NUEVO
        if (pantallaIdOculto.Value.Equals("0"))
        {
            if (txtIdentificacionSICC != null)
                txtIdentificacionSICC.Enabled = false;
            if (txtTipoIdentificacionRUC != null)
                txtTipoIdentificacionRUC.Enabled = false;
            if (txtCodGarantia != null)
                txtCodGarantia.Enabled = false;
            if (txtNombreRUC != null)
                txtNombreRUC.Enabled = false;
            if (ddlIdTipoAvalFianza != null)
                ddlIdTipoAvalFianza.Enabled = false;
            if (ddlIdTipoAsignacionCalificacion != null)
                ddlIdTipoAsignacionCalificacion.Enabled = false;
            if (ddlIdPlazoCalificacion != null)
                ddlIdPlazoCalificacion.Enabled = false;
            if (ddlIdEmpresaCalificadora != null)
                ddlIdEmpresaCalificadora.Enabled = false;
            if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                ddlIdCategoriaRiesgoEmpresaCalificadora.Enabled = false;
            if (ddlIdCalificacionEmpresaCalificadora != null)
                ddlIdCalificacionEmpresaCalificadora.Enabled = false;
            if (txtSalarioNetoFiador != null)
                txtSalarioNetoFiador.Enabled = false;
            if (txtFechaVerificacionAsalariado != null)
                txtFechaVerificacionAsalariado.Enabled = false;
            if (imbFechaVerificacionAsalariado != null)
                imbFechaVerificacionAsalariado.Enabled = false;
            if (rfvFechaVerificacionAsalariado != null)
                rfvFechaVerificacionAsalariado.Enabled = false;
            //if (rfvSalarioNetoFiador != null)
            //    rfvSalarioNetoFiador.Enabled = false;
            if (wmSalarioNetoFiador != null)
                wmSalarioNetoFiador.Enabled = false;
        }
        //EDITAR REGISTRO
        else 
        {
            if (txtIdentificacionSICC != null)
                txtIdentificacionSICC.Enabled = false;
            if (txtTipoIdentificacionRUC != null)
                txtTipoIdentificacionRUC.Enabled = false;
            if (txtCodGarantia != null)
                txtCodGarantia.Enabled = false;
            if (txtGarantia != null)
                txtGarantia.Enabled = false;
            if (txtNombreRUC != null)
                txtNombreRUC.Enabled = false;
            if (ddlTipoIdentificacionRUC != null)
                ddlTipoIdentificacionRUC.Enabled = false;
        }
    }

    /*HABILITA LOS CONTROLES AL SELECCIONAR UN VALOR DE BCR CLIENTES*/
    private void HabilitarControlesExcepciones()
    {
        #region BUSQUEDA DE CONTROLES

        DropDownList ddlIdTipoAvalFianza = ((DropDownList)(this.tableData.FindControl("IdTipoAvalFianza")));
        DropDownList ddlIdTipoAsignacionCalificacion = ((DropDownList)(this.tableData.FindControl("IdTipoAsignacionCalificacion")));

        #endregion

        if (ddlIdTipoAvalFianza != null)
            ddlIdTipoAvalFianza.Enabled = true;
        if (ddlIdTipoAsignacionCalificacion != null)
            ddlIdTipoAsignacionCalificacion.Enabled = true;
    }

    /*EXCEPCIONES EN LA CONSTRUCCION DE LOS CONTROLES*/
    private void CargarControlesExcepciones(Table tblPrincipal, ControlEntidad control)
    {
        try
        {
            StringBuilder filtroBuilder = new StringBuilder();
            filtroBuilder.Clear();

            #region BUSQUEDA DE CONTROLES

            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlIdCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));

            #endregion

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

    /*AGREGA UN ITEM EN BLANCO PARA LOS DDLS*/
    private void ControlesItemBlanco()
    {
        try
        {
            AdministrarBlanco("IdPlazoCalificacion", true);
            AdministrarBlanco("IdEmpresaCalificadora", true);
            AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
            AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
        }
        catch (Exception ex)
        {
            throw ex;
        }      
    }
    
    #endregion
        
    #endregion

    #region METODOS PERSONALIZADOS NO EDITABLES

    #region EVENTOS CLICK

    #region BCR CLIENTES

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        this.mpeBusqueda.Hide();
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                SeleccionarBCRClientes(sender, e);
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        } 
    }

    #endregion

    protected void btnBuscar_Click(object sender, EventArgs e)
    {        
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                EjecutarBCRClientes(sender, e);
            }
        }
        catch (Exception ex)
        {
            //if (ex.Message.ToUpper().Contains("SSPI"))
            //{
            //    valorReemplazo = "BCR Clientes";
            //    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "Conexion");
            //    this.mpeInformarBox.Show();
            //}
            //else
            //{
                Application["Exception"] = ex;
                Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
            //}
        }
    }
    
    protected void btnAyudaGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                // 0 = SE MANTIENE EL MISMO REGISTRO
                banderaVentana = 0; 
                Guardar();
                ActualizarVentanaPadre();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                // 0 = SE MANTIENE EL MISMO REGISTRO
                banderaVentana = 0; 
                Guardar();
                ActualizarVentanaPadre();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnAyudaCerrar_Click(object sender, EventArgs e)
    {
        try
        {
            Cerrar();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                Limpiar();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }

    }

    protected void btnGuardarNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                // 1 = SE ABRE UNA NUEVA VENTANA
                banderaVentana = 1; 
                Guardar();

                // SI NO EXISTE ERROR EN EL PROCESO
                if (resultadoProceso.Equals(0)) 
                {
                    GuardarNuevoRegistro();
                    Cerrar();
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnGuardarCerrar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                // -1 = SE CIERRA LA VENTANA
                banderaVentana = -1; 
                Guardar();

                // SI NO EXISTE ERROR EN EL PROCESO
                if (resultadoProceso.Equals(0)) 
                {
                    Cerrar();
                    ActualizarVentanaPadre();
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            Cerrar();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #region VENTANAS DE MENSAJES

    protected void btnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBox.Hide();
    }

    protected void btnAceptarInformarClientes_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxBusqueda.Hide();
        this.mpeBusqueda.Show();
    }

    #endregion

    #endregion

    #region METODOS EVENTOS CLICK

    private void Cerrar()
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "closeWindow", "top.close();", true);
    }

    private void NuevoRegistro()
    {
        string script = "if (window.opener != null && !window.opener.closed) { window.parent.opener.document.getElementById('cmdAccionesNuevo').click(); top.focus(); }";
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "CreateNewWindow", script, true);
    }

    private void Guardar()
    {
        //EXCEPCION VALIDACION PARA GUARDAR LOS DATOS
        if (ValidarGuardarExcepciones())
        {
            tipoAccion = 0;
            if (pantallaIdOculto.Value.Equals("0"))
            {
                tipoAccion = 0;
            }
            else
            {
                tipoAccion = 1;
            }
            DeControlesAEntidad(tipoAccion);
        }
    }

    private void ActualizarVentanaPadre()
    {
        string script = "if (window.opener != null && !window.opener.closed) { window.parent.opener.document.getElementById('cmdAccionesActualizar').click(); }";
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "refreshNewWindow", script, true);
    }
    
    private void GuardarNuevoRegistro()
    {
        string script = "if (window.opener != null && !window.opener.closed) { window.parent.opener.document.getElementById('cmdAccionesGuardarNuevo').click(); }";
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "CreateSaveNewWindow", script, true);
    }

    #endregion

    #region BCR CLIENTES

    /*ESTABLECE LOS DATOS DE LA CONSULTA DE BCR CLIENTES EN EL GRID*/
    private void EjecutarBCRClientes(object sender, EventArgs e)
    {
        try
        {
            //NO SE PERMITEN CARACTERES ESPECIALES
            var regexItem = new Regex("^[a-zA-Z0-9]*$");

            TextBox txtGarantia = ((TextBox)this.tableData.FindControl("Garantia"));
            DropDownList ddlIdTipoIdentificacionRUC = ((DropDownList)this.tableData.FindControl("TipoIdentificacionRUC"));

            if ((txtGarantia != null) && (ddlIdTipoIdentificacionRUC != null))
            {
                //VALIDACION DEL CAMPO GARANTIA
                if (!txtGarantia.Text.Length.Equals(0))
                {
                    //VALIDACION DE CARACTERES ESPECIALES
                    if (regexItem.IsMatch(txtGarantia.Text))
                    {
                        //VALIDA EL TIPO DE PERSONA AL BUSCAR ***NOTA: VALIDACION DESACTIVADA POR SOLICITUD DEL USUARIO. 19 Mar 2014
                        if (ValidarTipoPersona())
                        {
                            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
                            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
                            {
                                this.divBarraMensaje.Visible = false;
                            }
                            ((wucGridEmergente)this.BCRClientes).BindGridView(this.Consulta(txtGarantia.Text, ddlIdTipoIdentificacionRUC.SelectedItem.Text));
                            this.mpeBusqueda.Show();
                        }
                        else
                        {
                            BarraMensaje(null, "9");
                        }
                    }
                    else
                    {
                        BarraMensaje(null, "");
                    }
                }
                else
                {
                    valorReemplazo = "el campo Id Garantía para realizar la búsqueda";
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "Requerido");
                    this.mpeInformarBox.Show();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL CLIENTE SELECCIONADO*/
    private void SeleccionarBCRClientes(object sender, EventArgs e)
    {
        try
        {
            TextBox txtIdentificacionSICC = ((TextBox)this.tableData.FindControl("IdentificacionSICC"));
            TextBox txtNombreRUC = ((TextBox)this.tableData.FindControl("NombreRUC"));
            TextBox txtTipoIdentificacionRUC = ((TextBox)this.tableData.FindControl("IdTipoIdentificacionRUC"));
            TextBox txtCodGarantia = ((TextBox)this.tableData.FindControl("CodGarantia"));
            TextBox txtGarantia = ((TextBox)this.tableData.FindControl("Garantia"));
            DropDownList ddlIdTipoIdentificacionRUC = ((DropDownList)this.tableData.FindControl("TipoIdentificacionRUC"));

            //VALIDA QUE SOLO UN ELEMENTO SEA EL SELECCIONADO
            if (((wucGridEmergente)this.BCRClientes).ContadorSeleccionados().Equals(1))
            {
                string[] valoresGrid;
                List<string> valorSeleccionado = ((wucGridEmergente)this.BCRClientes).ObtenerValoresSeleccionados("lblDescNombre");
                foreach (string valor in valorSeleccionado)
                {
                    valoresGrid = valor.Split('|');

                    if (txtIdentificacionSICC != null)
                        txtIdentificacionSICC.Text = valoresGrid[0];
                    if (txtNombreRUC != null)
                        txtNombreRUC.Text = StaticParameters.RemoveSpecialCharacters(valoresGrid[1]);
                    if ((txtTipoIdentificacionRUC != null) && (ddlIdTipoIdentificacionRUC != null))
                        txtTipoIdentificacionRUC.Text = ddlIdTipoIdentificacionRUC.SelectedItem.Text;
                    if ((txtCodGarantia != null) && (txtGarantia != null))
                        txtCodGarantia.Text = txtGarantia.Text;
                }
                HabilitarControlesExcepciones();
                this.mpeBusqueda.Hide();
            }
            else
            {
                //VERIFICA SI EL GRID CONTIENE REGISTROS
                if (((wucGridEmergente)this.BCRClientes).ContieneRegistros())
                {
                    this.InformarBoxBusqueda_SetConfirmationBoxEvent(sender, e, "SYS_4");
                    this.mpeInformarBoxBusqueda.Show();
                }
                else
                {
                    //SI EL REGISTRO A BUSCAR NO EXISTE
                    txtNombreRUC.Text = string.Empty;
                    txtCodGarantia.Text = string.Empty;
                    txtTipoIdentificacionRUC.Text = string.Empty;
                    txtIdentificacionSICC.Text = string.Empty;
                    Limpiar();
                    DeshabilitarControlesExcepciones();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*OBTIENE LA IP DEL EQUIPO*/
    private string ObtenerIP()
    {
        try
        {
            string ip = string.Empty;
            IPAddress[] direccion = Dns.GetHostAddresses(Dns.GetHostName());

            for (int i = 0; i < direccion.Length; i++)
            {
                if ((direccion[i].AddressFamily.ToString().Equals("InterNetwork")) && (!string.IsNullOrEmpty(direccion[i].ToString())))
                {
                    ip = direccion[i].ToString();
                    i = direccion.Length;
                }
            }

            if (string.IsNullOrEmpty(ip))
            {
                ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
            }

            return ip;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CONSULTA A BCR CLIENTES*/
    private List<BCRClientesEntidad> Consulta(string garantia, string codTipoPersona)
    {
        try
        {
            List<BCRClientesEntidad> retorno = null;

            string[] tipoPersonaArreglo = null;
            string ip = string.Empty;
            string idPersona = string.Empty;
            int tipoPersona = 0;

            idPersona = garantia;

            tipoPersonaArreglo = codTipoPersona.Split('-');
            tipoPersona = int.Parse(tipoPersonaArreglo[0].Trim());

            //OBTIENE LA IP DEL PC
            ip = ObtenerIP();

            if (!tipoPersona.Equals(0))
                retorno = wsBCRClientes.ConsultaClienteBCR(tipoPersona, idPersona, ip).ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region GRIDVIEW BCR CLIENTES

    private void gridView_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        gridViewColumn = new GridViewColumn();
        this.gridViewClientes.Columns.Add(gridViewColumn.CreateBoundField("IdSICC", string.Empty, "Id SICC", HorizontalAlign.Center, false, true));

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridViewClientes, "DescNombre", lblID);
    }

    private void SetDataKeys(GridView _gridView, String[] _dataKeysString)
    {
        _gridView.DataKeyNames = _dataKeysString;
    }

    #endregion

    #endregion

    #region CONTROLES

    /*CARGA LOS VALORES PARA LOS TITULOS*/
    private void Etiquetas()
    {
        try
        {
            Button btn = null;
            if (pantallaNombreOculto.Value != null)
            {
                //CARGA EL NOMBRE DE LA PANTALLA EN LA SECCION INFERIOR IZQUIERDA
                btn = ((Button)this.Master.FindControl("MenuLateral1").FindControl("cmdAreaMenuLateralDetalleBoton"));
                if (btn != null)
                    btn.Text = pantallaTituloOculto.Value;

                lblPagina.Text = pantallaTituloOculto.Value;
                lblForm.Text = lblForm.Text + pantallaTituloOculto.Value;

                if (pantallaIdOculto.Value.Equals("0"))
                {
                    lblPaginaSubtitulo.Text = "Nuevo";
                }
                else
                {
                    lblPaginaSubtitulo.Text = "Editar";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS TABS DEL WORKSPACE*/
    private void Tabs()
    {
        try
        {
            if (pantallaModuloOculto.Value != null)
            {
                ListasWS.PantallasEntidad pantalla = new ListasWS.PantallasEntidad();
                pantalla.CodPantalla = int.Parse(pantallaModuloOculto.Value);

                List<NodoMenuEntidad> menu = this.wsListas.AdministracionesContenidosConsultaPestanas(pantalla).ToList();

                // LLAMA AL METODO DE CREAR LOS CONTROLES DEL TAB CONTAINER
                ((wucMenuLateralDetalle)this.Master.FindControl("MenuLateral1")).CargarArbol(menu);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EXTRAE LOS CONTROLES DESDE BD*/
    private void Controles()
    {
        try
        {
            if (pantallaModuloOculto.Value != null)
            {

                ListasWS.PantallasEntidad pantalla = new ListasWS.PantallasEntidad();
                pantalla.CodPantalla = int.Parse(pantallaModuloOculto.Value);

                //LIMPIA TABLA DE LA PAGINA ACTUAL
                this.tableData.Controls.Clear();

                //ESTABLECE LOS CONTROLES DE LA PANTALLA A CARGAR
                pantalla.Pestana = string.Empty;

                //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD
                List<ControlEntidad> ds = new List<ControlEntidad>();
                ds = this.wsListas.AdministracionesContenidosConsultaControl(pantalla).ToList();

                //CREAR E INSERTA LOS CONTROLES EN LA PAGINA ACTUAL    
                LlenarTabla(this.tableData, pantallaNombreOculto.Value, ds);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*LIMPIA LOS CONTROLES TIPO TEXTBOX*/
    private void Limpiar()
    {
        try
        {
            //LIMPIA LOS CONTROLES TEXTBOX-DROPDOWNLIST
            generadorControles.Limpiar_Controles(this.tableData);

            TextBox txtFechaVerificacioAsalariado = ((TextBox)this.tableData.FindControl("FechaVerificacionAsalariado"));
            if (txtFechaVerificacioAsalariado != null && txtFechaVerificacioAsalariado.Enabled)
                txtFechaVerificacioAsalariado.Text = string.Empty;

            TextBox txtGarantia = ((TextBox)this.tableData.FindControl("Garantia"));
            if (txtGarantia != null && txtGarantia.Enabled)
                txtGarantia.Text = string.Empty;

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
            {
                this.divBarraMensaje.Visible = false;
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
        MaskedEditExtender msk = null;

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
            int filasContador = 0;

            //RECORRE LOS CONTROLES EXTRAIDOS DESDE LA BD            
            foreach (ControlEntidad control in dsControles)
            {
                string assocID = control.NombrePropiedadAsociada;
                filtro = string.Empty;
                int ancho;
                //0 = SIN ITEMS | 1 = CON ITEMS (PARA DROPDOWNLIST)
                int bandera = 0; 
                                
                if (((Control)tblPrincipal.FindControl(control.NombrePropiedad)) == null)
                {
                    tableRow = new TableRow();
                    tableRow.ID = string.Concat("tr", control.NombrePropiedad);
                    tableRow.Height = Unit.Parse("10");

                    //CREA TABLE CELL
                    TableCell tc1 = new TableCell();
                    tc1.ID = String.Concat("tcRow", filasContador, "Cell", 0);
                    tc1.Width = Unit.Parse("325");
                    tc1.Height = Unit.Parse("15");

                    //CREA ETIQUETA
                    Label cellLabel = new Label();
                    cellLabel = generadorControles.Tipo_Contenido(EnumTipoControl.LABEL
                                                , String.Concat("lbl", filasContador, "Cell", 0)
                                                , control.DesColumna
                                                , String.Concat("Etiqueta ", control.DesColumna)
                                                , true
                                                , true
                                                , "blacklabel"
                                                , String.Empty) as Label;

                    cellLabel.Style.Add("padding-left", "5px");

                    //ASIGNA EL NOMBRE 
                    string nombrePropiedad = control.NombrePropiedad;

                    //AGREGA LA ETIQUETA A LA CELDA1 
                    tc1.Controls.Add(cellLabel);

                    //ASIGNA EL VALOR DEL TIPO DE OBJETO 
                    string tipoContenido = control.TipoContenido;
                    tipoContenido = tipoContenido.ToUpper();

                    //CREA TABLE CELL 2
                    TableCell tc2 = new TableCell();
                    tc2.ID = String.Concat("tc", "Row", filasContador, "Cell", "2");
                    tc2.Height = Unit.Parse("15");

                    //CREA TABLE CELL PARA ASIGNAR LOS CONTROLES DEPENDIENTES
                    TableCell tcAssocIDLabel = null;
                    TableCell tcAssocID = null;

                    #region SWITCH CONTROLES

                    switch (tipoContenido)
                    {
                        #region LABEL
                        case "LABEL":

                            Label lbl = new Label();
                            lbl.ID = nombrePropiedad;
                            lbl.Text = string.Empty;
                            lbl.ToolTip = String.Concat("Etiqueta ", control.DesColumna);
                            lbl.Enabled = bool.Parse(control.IndModificar);
                            lbl.Visible = bool.Parse(control.IndVisible);
                            lbl.CssClass = "blacklabel";

                            tc2.Controls.Add(lbl);

                            break;
                        #endregion

                        #region TEXTBOX
                        case "TEXTBOX":

                            TextBox txt = new TextBox();
                            txt.ID = nombrePropiedad;
                            txt.Text = control.ValorDefecto;
                            txt.ToolTip = String.Concat("Texto ",control.DesColumna);
                            txt.Enabled = bool.Parse(control.IndModificar);
                            txt.Visible = bool.Parse(control.IndVisible);
                            txt.CssClass = control.CssTipo;
                            txt.MaxLength = Int32.Parse(control.LongitudMaxima);

                            txt.CausesValidation = false;

                            if (!String.IsNullOrEmpty(control.GrupoValidacion))
                            {
                                txt.ValidationGroup = control.GrupoValidacion;
                            }

                            if (txt.MaxLength > 50)
                            {
                                ancho = 400;
                            }
                            else
                            {
                                ancho = (txt.MaxLength * 8);
                            }
                            txt.Width = ancho;

                            tc2.Controls.Add(txt);

                            #region MASKEDEDITEXTENDER

                            int m = Int32.Parse(control.Mascara);

                            if (m > 0)
                            {
                                txt.MaxLength = Int32.Parse(control.LongitudMaxima);

                                int mType = Int32.Parse(control.LongitudMaxima);

                                msk = new MaskedEditExtender();
                                msk.ID = String.Concat("mask", nombrePropiedad);
                                msk.TargetControlID = txt.ID;

                                msk.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();
                                msk.ClearTextOnInvalid = true;
                                msk.ClearMaskOnLostFocus = true;
                                //mask.AutoComplete = false;

                                msk.MaskType = generadorControles.DeterminaTipoMascara(m);
                                msk.InputDirection = MaskedEditInputDirection.RightToLeft;

                                string mascara = generadorControles.DeterminaFormatoMascara(mType, control.ValorMascara);
                                msk.Mask = mascara;
                            }

                            #endregion

                            #region REQUIREDFIELDVALIDATOR

                            if (control.IndRequerido.Equals("True"))
                            {
                                rfv = new RequiredFieldValidator();
                                rfv.ID = String.Concat("rfv", nombrePropiedad);
                                rfv.ControlToValidate = txt.ID;
                                rfv.ErrorMessage = "Required";
                                rfv.Display = ValidatorDisplay.Dynamic;
                                rfv.Text = " * ";
                                rfv.CssClass = "labelTabError";
                            }

                            #endregion

                            #region TEXTBOX WATERMARKED

                            if (control.ValorMinimo.Length > 0)
                            {
                                TextBoxWatermarkExtender wm = new TextBoxWatermarkExtender();
                                wm.ID = string.Concat("wm", nombrePropiedad);
                                wm.TargetControlID = txt.ID;

                                if (control.ValorMascara.Contains("."))
                                    wm.WatermarkText = string.Format("{0:N}", decimal.Parse(control.ValorMinimo));
                                else
                                    wm.WatermarkText = control.ValorMinimo;

                                tc2.Controls.Add(wm);

                            }
                            #endregion

                            break;
                        #endregion

                        #region MULTILINE
                        case "MULTILINE":
                            TextBox mTxt = new TextBox();
                            mTxt.ID = nombrePropiedad;
                            mTxt.Text = string.Empty;
                            mTxt.ToolTip = String.Concat("Texto ", control.DesColumna);
                            mTxt.Enabled = bool.Parse(control.IndModificar);
                            mTxt.Visible = bool.Parse(control.IndVisible);
                            mTxt.CssClass = control.CssTipo;
                            mTxt.MaxLength = Int32.Parse(control.LongitudMaxima);
                            mTxt.TextMode = TextBoxMode.MultiLine;
                            mTxt.Height = 130;
                            mTxt.Width = 450;

                            tc2.Controls.Add(mTxt);

                            #region REQUIREDFIELDVALIDATOR

                            if (control.IndRequerido.Equals("True"))
                            {
                                rfv = new RequiredFieldValidator();
                                rfv.ID = String.Concat("rfv", "Row", filasContador, "Cell", "2");
                                rfv.ControlToValidate = mTxt.ID;
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

                            Button btn = new Button();
                            btn.ID = nombrePropiedad;
                            btn.Text = string.Empty;
                            btn.ToolTip = String.Concat("Botón ", control.DesColumna);
                            btn.Enabled = bool.Parse(control.IndModificar);
                            btn.Visible = bool.Parse(control.IndVisible);
                            btn.CssClass = control.CssTipo;

                            tc2.Controls.Add(btn);

                            break;
                        #endregion

                        #region DROPDOWN LIST
                        case "DROPDOWNLIST":

                            DropDownList ddl = new DropDownList();
                            ddl.ID = nombrePropiedad;
                            string spText = control.MetodoServicioWeb;
                            AssocRowReady = false;

                            if (String.IsNullOrEmpty(spText))
                            {
                                ddl.Items.Add(new ListItem("No hay Datos","-1"));
                                //NO HAY ITEMS
                                bandera = 0; 
                            }
                            else
                            {
                                //EXISTEN ITEMS
                                bandera = 1; 
                                ddl.Items.Clear();

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
                                CargarControlesExcepciones(tblPrincipal, control);

                                ddl.DataSource = LlenarDropDownList(spText, filtro);
                                ddl.DataTextField = "Texto";
                                ddl.DataValueField = "Valor";
                                ddl.DataBind();

                                //ESTABLE EL VALOR POR DEFECTO DEL CONTROL
                                if (!string.IsNullOrEmpty(control.IndValorDefecto))
                                {
                                    if (bool.Parse(control.IndValorDefecto))
                                    {
                                        for (int i = 0; i < ddl.Items.Count; i++)
                                        {
                                            if (ddl.Items[i].Text.Equals(control.ValorDefecto))
                                                ddl.SelectedIndex = i;
                                        }
                                    }
                                }

                                //SE ASIGNA EL ELEMENTO SELECCIONADO POR DEFECTO
                                ddlValorSeleccionado = ddl.SelectedValue.ToString(); 
                            }

                            ddl.ToolTip = String.Concat("Lista de ", control.DesColumna);
                            ddl.Enabled = bool.Parse(control.IndModificar);
                            ddl.Visible = bool.Parse(control.IndVisible);
                            ddl.CssClass = control.CssTipo;
                            ddl.Width = Unit.Parse("100%");

                            //EVENTO DE LA LISTA PADRE PARA EL MANEJO DE LISTAS ANIDADAS
                            ddl.AutoPostBack = true;
                            ddl.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);

                            tc2.Controls.Add(ddl);

                            //BUSQUEDA DE LOS CONTROLES DEPENDIENTES
                            List<ControlEntidad> dsControles1 = dsControles;
                            foreach (ControlEntidad controlAsociado in dsControles1)
                            {
                                string assocParent = ddl.ID.ToUpper();
                                string assocChild = controlAsociado.NombrePropiedadAsociada.ToUpper();

                                if (assocParent.Equals(assocChild))
                                {
                                    string nombreColumnaR = controlAsociado.NombrePropiedad;
                                    string desColumnaR = controlAsociado.DesColumna;
                                    string tipoContenidoR = controlAsociado.TipoContenido;
                                    string longitud = controlAsociado.LongitudMaxima;
                                    string mskR = controlAsociado.Mascara;
                                    string spR = controlAsociado.MetodoServicioWeb;
                                    string assocIDr = controlAsociado.NombrePropiedadAsociada;

                                    DropDownList ddlAssocID = new DropDownList();
                                    ddlAssocID.ID = nombreColumnaR;
                                    ddlAssocID.ToolTip = String.Concat("Lista de ", desColumnaR);
                                    ddlAssocID.Enabled = bool.Parse(controlAsociado.IndModificar);
                                    ddlAssocID.Visible = bool.Parse(controlAsociado.IndVisible); 
                                    ddlAssocID.CssClass = controlAsociado.CssTipo;
                                    ddlAssocID.Width = Unit.Parse("100%");

                                    ddlAssocID.Items.Clear();

                                    //NO HAY ITEMS
                                    if (bandera.Equals(0))
                                    {
                                        ddlAssocID.Items.Add("No hay Datos");
                                    }
                                    else
                                    {
                                        ddlAssocID.DataSource = LlenarDropDownList(spR, ddlValorSeleccionado);
                                        ddlAssocID.DataTextField = "Texto";
                                        ddlAssocID.DataValueField = "Valor";
                                        ddlAssocID.DataBind();
                                        ddlAssocID.AutoPostBack = true;
                                        ddlAssocID.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);
                                    }

                                    tableRowAssocID = new TableRow();
                                    tableRowAssocID.Height = Unit.Parse("10");

                                    tcAssocIDLabel = new TableCell();
                                    tcAssocIDLabel.ID = String.Concat("tcRow", filasContador, "LblCell", "AssocID4");
                                    tcAssocIDLabel.Width = Unit.Parse("150");
                                    tcAssocIDLabel.Style.Add("border-bottom", "1px dotted #FBFBEF");
                                    tcAssocIDLabel.Height = Unit.Parse("15");

                                    //CREA LA ETIQUETA ASOCIADA AL CONTROL
                                    Label lblAssocID = new Label();
                                    lblAssocID = generadorControles.Tipo_Contenido(EnumTipoControl.LABEL
                                                                , String.Concat("lbl", filasContador, "Cell", 4)
                                                                , desColumnaR
                                                                , String.Concat("Label ", desColumnaR)
                                                                , true
                                                                , true
                                                                , "blacklabel"
                                                                , String.Empty) as Label;
                                    lblAssocID.Style.Add("padding-left", "5px");
                                    //AGREGA LA ETIQUETA A LA CELDA
                                    tcAssocIDLabel.Controls.Add(lblAssocID);

                                    tcAssocID = new TableCell();
                                    tcAssocID.ID = String.Concat("tcRow", filasContador, "DdlCell", "AssocID4");
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

                        #region CALENDAR EXTENDER
                        case "CALENDAREXTENDER":
                            //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES DEL CALENDARIO QUEDEN ALINEADOS
                            HtmlTable calendarTable = new HtmlTable();
                            HtmlTableRow calendarRow = new HtmlTableRow();
                            HtmlTableCell calendarCell_1 = new HtmlTableCell();
                            HtmlTableCell calendarCell_2 = new HtmlTableCell();
                            calendarTable.Style.Add("valign", "middle");

                            //CALENDARIO QUE ALMACENA LA FECHA
                            TextBox txtCalendario = new TextBox();
                            txtCalendario.ID = nombrePropiedad;
                            txtCalendario.Text = string.Empty;
                            txtCalendario.ToolTip = String.Concat("Calendario ", control.DesColumna);
                            txtCalendario.Enabled = bool.Parse(control.IndModificar);
                            txtCalendario.Visible = bool.Parse(control.IndVisible);
                            txtCalendario.Attributes.Add("readonly", "readonly");
                            txtCalendario.CssClass = control.CssTipo;

                            int m2 = Int32.Parse(control.Mascara);
                            msk = new MaskedEditExtender();
                            msk.ID = String.Concat("mask", nombrePropiedad, filasContador);
                            msk.ClearTextOnInvalid = true;
                            msk.TargetControlID = txtCalendario.ID;

                            msk.MaskType = generadorControles.DeterminaTipoMascara(m2);
                            msk.InputDirection = MaskedEditInputDirection.LeftToRight;
                            msk.ClearMaskOnLostFocus = true;
                            msk.CultureName =  ConfigurationManager.AppSettings["Culture"].ToString();

                            //SE ASIGNA EL TEXTBOX EN LA PRIMER CELDA
                            calendarCell_1.Controls.Add(txtCalendario);

                            //BOTON CON LA IMAGEN DEL CALENDARIO
                            ImageButton imgbuttonCalendar = new ImageButton();
                            imgbuttonCalendar.ID = String.Concat("imgBtnCalendarExtender", nombrePropiedad);
                            imgbuttonCalendar.ToolTip = "Click para abrir el Calendario";
                            imgbuttonCalendar.ImageUrl = ("~/Library/img/32/iconCalendario.gif");
                            imgbuttonCalendar.Enabled = bool.Parse(control.IndModificar);
                            imgbuttonCalendar.Visible = bool.Parse(control.IndVisible);
                            imgbuttonCalendar.CausesValidation = false;
                            tc2.VerticalAlign = VerticalAlign.Top;

                            //SE ASIGNA LA IMAGEN DEL CALENDARIO EN LA SEGUNDA CELDA
                            calendarCell_2.Controls.Add(imgbuttonCalendar);

                            #region REQUIREDFIELDVALIDATOR

                            if (control.IndRequerido.Equals("True"))
                            {
                                rfv = new RequiredFieldValidator();
                                rfv.ID = String.Concat("rfv", nombrePropiedad);
                                rfv.ControlToValidate = txtCalendario.ID;
                                rfv.ErrorMessage = "Required";
                                rfv.Display = ValidatorDisplay.Dynamic;
                                rfv.Text = " * ";
                                rfv.CssClass = "labelTabError";
                            }

                            calendarCell_2.Controls.Add(rfv);
                            #endregion

                            //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                            calendarRow.Cells.Add(calendarCell_1);
                            calendarRow.Cells.Add(calendarCell_2);
                            calendarTable.Rows.Add(calendarRow);
                            tc2.Controls.Add(calendarTable);

                            #region CALENDAR EXTENDER
                            //CONTROL CALENDARIO
                            calendarExtender = new CalendarExtender();
                            calendarExtender.ID = String.Concat("calendarExtender", nombrePropiedad, filasContador);
                            calendarExtender.TargetControlID = txtCalendario.ID;
                            calendarExtender.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();
                            calendarExtender.PopupPosition = CalendarPosition.Right;
                            calendarExtender.PopupButtonID = imgbuttonCalendar.ID;
                            calendarExtender.Enabled = bool.Parse(control.IndModificar);
                            #endregion

                            break;
                        #endregion

                        #region HIDDEN FIELD
                        case "HIDDENFIELD":

                            HiddenField hdn = new HiddenField();
                            hdn.ID = nombrePropiedad;
                            hdn.Value = string.Empty;
                            hdn.Visible = true;

                            tc2.Controls.Add(hdn);

                            break;
                        #endregion

                        #region IMAGE BUTTON
                        case "IMAGE BUTTON":

                            ImageButton imb = new ImageButton();
                            imb.ID = nombrePropiedad;
                            imb.ToolTip = String.Concat("Botón ", control.DesColumna);
                            imb.Enabled = bool.Parse(control.IndModificar);
                            imb.Visible = bool.Parse(control.IndVisible);
                            imb.CssClass = control.CssTipo;
                            imb.ImageUrl = string.Empty;
                            tc2.Controls.Add(imb);

                            break;
                        #endregion

                        #region IMAGE
                        case "IMAGE":

                            Image img = new Image();
                            img.ID = nombrePropiedad;
                            img.ToolTip = String.Concat("Imagen ", control.DesColumna);
                            img.Enabled = bool.Parse(control.IndModificar);
                            img.Visible = bool.Parse(control.IndVisible);
                            img.CssClass = control.CssTipo;
                            img.ImageUrl = string.Empty;

                            break;

                        #endregion

                        #region AREA

                        case "AREA":

                            TableCell tc4 = new TableCell();
                            tc4.ID = String.Concat("tcRowArea", filasContador, "Cell", 0);
                            tc4.Width = Unit.Parse("220");
                            tc4.Height = Unit.Parse("20");
                            tc4.ColumnSpan = 2;
                            tc4.VerticalAlign = VerticalAlign.Bottom;

                            HtmlGenericControl divSub = new HtmlGenericControl("div");
                            divSub.ID = control.Tab;

                            Label lblSubtitulo = new Label();
                            lblSubtitulo.ID = control.NombreColumna;
                            lblSubtitulo.Text = control.DesColumna;
                            lblSubtitulo.ToolTip = String.Concat("Etiqueta ", control.DesColumna);
                            lblSubtitulo.Enabled = bool.Parse(control.IndModificar);
                            lblSubtitulo.Visible = bool.Parse(control.IndVisible);
                            lblSubtitulo.CssClass = control.CssTipo;

                            divSub.Controls.Add(lblSubtitulo);
                            tc4.Controls.Add(divSub);

                            //// AGREGA LA CELDA4 A LA FILA
                            tableRow.Cells.Add(tc4);

                            break;

                        #endregion

                        #region SEARCHBOX
                        case "SEARCHBOX":

                            //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES QUEDEN ALINEADOS
                            HtmlTable validatorTable = new HtmlTable();
                            HtmlTableRow validatorRow = new HtmlTableRow();
                            HtmlTableCell validatorCell_1 = new HtmlTableCell();
                            HtmlTableCell validatorCell_2 = new HtmlTableCell();
                            validatorTable.Style.Add("valign", "middle");

                            //CONTROL PARA LA BUSQUEDA DE ID GARANTIA
                            TextBox txtAD = new TextBox();
                            txtAD.ID = nombrePropiedad;
                            txtAD.Text = string.Empty;
                            txtAD.MaxLength = Int32.Parse(control.LongitudMaxima);
                            txtAD.ToolTip = String.Concat("Texto ", control.DesColumna);
                            txtAD.Enabled = bool.Parse(control.IndModificar);
                            txtAD.Visible = bool.Parse(control.IndVisible);
                            txtAD.CssClass = control.CssTipo;

                            if (!String.IsNullOrEmpty(control.GrupoValidacion))
                            {
                                txtAD.ValidationGroup = control.GrupoValidacion;
                            }

                            if (txtAD.MaxLength > 50)
                            {
                                ancho = 400;
                            }
                            else
                            {
                                ancho = (txtAD.MaxLength * 8);
                            }
                            txtAD.Width = ancho;

                            #region MASKEDEDITEXTENDER

                            int m4 = Int32.Parse(control.Mascara);

                            if (m4 > 0)
                            {
                                int m3 = Int32.Parse(control.LongitudMaxima);

                                msk = new MaskedEditExtender();
                                msk.ID = String.Concat("mask", nombrePropiedad);
                                
                                msk.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();
                                msk.ClearTextOnInvalid = true;
                                msk.ClearMaskOnLostFocus = true;
                                msk.AutoComplete = false;

                                msk.MaskType = generadorControles.DeterminaTipoMascara(m4);
                                msk.InputDirection = MaskedEditInputDirection.LeftToRight;
                                msk.Mask = generadorControles.DeterminaFormatoMascara(m3, control.ValorMascara);

                                msk.TargetControlID = txtAD.ID;
                            }
                            #endregion

                            //SE ASIGNA EL TEXTBOX EN LA PRIMER CELDA
                            validatorCell_1.Controls.Add(txtAD);

                            #region SEARCH IMAGE

                            //BOTON CON LA IMAGEN DEL CONTROL
                            Button btnBuscar = new Button();
                            btnBuscar.ID = String.Concat("imgCmd", nombrePropiedad);
                            btnBuscar.ToolTip = "Click para ejecutar la búsqueda.";
                            btnBuscar.CssClass = "imgCmdBuscarGarantia";
                            //imgCmdBuscar.ImageUrl = ("~/Library/img/16/iconConsultaSol.gif");
                            btnBuscar.Enabled = bool.Parse(control.IndModificar);
                            btnBuscar.Visible = bool.Parse(control.IndVisible);
                            btnBuscar.Click +=new EventHandler(btnBuscar_Click);
                            btnBuscar.CausesValidation = false;
                            tc2.VerticalAlign = VerticalAlign.Top;

                            //SE ASIGNA LA IMAGEN EN LA SEGUNDA CELDA
                            validatorCell_2.Controls.Add(btnBuscar);

                            #endregion

                            //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                            validatorRow.Cells.Add(validatorCell_1);
                            validatorRow.Cells.Add(validatorCell_2);
                            validatorTable.Rows.Add(validatorRow);
                            tc2.Controls.Add(validatorTable);

                            break;
                        #endregion

                    }

                        #endregion

                    if (!tipoContenido.Equals("AREA") && !tipoContenido.Equals("GRIDVIEW"))
                    {
                        //AGREGA LA CELDA1 AL TABLE ROW
                        tableRow.Cells.Add(tc1);
                        //AGREGA LA CELDA2 A LA FILA
                        tableRow.Cells.Add(tc2);
                    }

                    //CELDA PARA EL CONTROL REQUIRED FIELD VALIDATOR
                    TableCell tc3 = new TableCell();

                    if (tipoContenido.Equals("DROPDOWNLIST"))
                    {
                        Label hdnLabel = new Label();
                        hdnLabel.ID = String.Concat("hiddenLabel", filasContador);
                        hdnLabel.Text = String.Empty;
                        hdnLabel.Enabled = false;
                        hdnLabel.Visible = false;

                        tc3.Controls.Add(hdnLabel);
                    }
                    else
                    {
                        if (tipoContenido.Equals("TEXTBOX")|| tipoContenido.Equals("SEARCHBOX"))
                        {
                            if (msk != null)
                            {
                                tc3.Controls.Add(msk);
                            }
                            if (control.IndRequerido.Equals("True"))
                            {
                                tc3.Controls.Add(rfv);
                            }
                        }
                        else
                        {
                            if (tipoContenido.Equals("CALENDAREXTENDER"))
                            {
                                if (calendarExtender != null)
                                {
                                    tc3.Controls.Add(calendarExtender);
                                }
                            }
                        }
                    }

                    tc3.Width = Unit.Parse("150");
                    tc3.HorizontalAlign = HorizontalAlign.Left;
                    tc3.Height = Unit.Parse("15");

                    //AGREGA LA CELDA3 A LA FILA
                    tableRow.Cells.Add(tc3);

                    if (!AssocRowReady)
                    {
                        tblPrincipal.Rows.Add(tableRow);
                    }

                    filasContador++;
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE BD PARA EL CASO DE LAS MODIFICACIONES*/
    private void DeEntidadAControles()
    {
        DataTable dt = new DataTable();

        #region CONTROLES COMODIN

        TextBox txt = null;
        DropDownList ddl = null;

        #endregion

        try
        {
            //Bloque 7 Requerimiento 1-24381561
            /*if (pantallaModuloOculto.Value != null && !pantallaIdOculto.Value.Equals("0")) //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            {
                #region OBTIENE EL TIPO DE LA ENTIDAD A CREAR DINAMICAMENTE

                _entidad = ObtenerEntidad(_entidad); //OBTIENE LA ENTIDAD DINAMICAMENTE
                Type _tipoEntidad = _entidad.GetType(); //OBTIENE EL TIPO DE DATO DE LA ENTIDAD

                #endregion

                //OBTIENE LAS PROPIEDADES DE LA ENTIDAD
                PropertyInfo[] properties = _tipoEntidad.GetProperties();

                string _entidadPropiedad = string.Empty;
                string _entidadPropiedadTipo = string.Empty;

                //ASIGNA EL VALOR DEL ID DEL REGISTRO A CONSULTAR
                foreach (PropertyInfo property in properties)
                {                
                    if (property.Name.Contains("Id"))
                    {
                        _entidadPropiedad = property.Name;
                        _entidadPropiedadTipo = property.PropertyType.Name;
                        //ASIGNA EL VALOR A LA PROPIEDAD EL ID CORRESPONDE A LA PRIMERA PROPIEDAD DE CADA ENTIDAD
                        property.SetValue(_entidad, _generadorControles.ConvertirTipoDato(_entidadPropiedadTipo.ToUpper(), pantallaIdOculto.Value), null); 
                        break;
                    }
                }
            
                //OBTIENE EL RESTO DE CAMPOS DEL REGISTRO A CONSULTAR DESDE LA BD            
                string exec = "GarantiasFiduciariasConsultarDetalle";
                Type ws = wsGarantias.GetType();
                MethodInfo method = ws.GetMethod(exec);
                var result = method.Invoke(wsGarantias, new object[] { _entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
                */

            var resultado = ConsultarDetalleEntidad();
            if (resultado != null)
            {
                Type tipoControl = null;
                Object control = null;
                string asignarValor = string.Empty;
                List<KeyValuePair<string, string>> entidadLista = new List<KeyValuePair<string, string>>();

                PropertyInfo[] propiedadesDetalle = resultado.GetType().GetProperties();
                foreach (PropertyInfo propiedadDetalle in propiedadesDetalle)
                {
                    asignarValor = string.Empty;
                    control = this.tableData.FindControl(propiedadDetalle.Name);
                    if (control != null)
                    {
                        tipoControl = control.GetType();

                        //SEGUN EL TIPO DE CONTROL
                        switch (control.GetType().Name.ToUpper()) 
                        {
                            #region TEXTBOX
                            case "TEXTBOX":
                                txt = (TextBox)control;
                                if (propiedadDetalle.GetValue(resultado, null) == null)
                                    asignarValor = string.Empty;
                                else
                                {
                                    //SI ES UN VALOR DECIMAL SE DEBE DE MANTENER EL FORMATO
                                    //if (propertyDetalle.GetValue(result, null).GetType().Name.ToUpper().Equals("DOUBLE"))
                                    if (propiedadDetalle.GetValue(resultado, null).GetType().Name.ToUpper().Equals("DECIMAL"))
                                        asignarValor = String.Format("{0:0.00}", propiedadDetalle.GetValue(resultado, null));
                                    else
                                        asignarValor = propiedadDetalle.GetValue(resultado, null).ToString();
                                }
                                // ASIGNACION DEL TEXTO DESDE LA BD
                                txt.Text = asignarValor; 
                                txt.Enabled = true;
                                if ((propiedadDetalle.Name.Substring(0, 3)).Contains("Cod"))
                                    txt.Enabled = false;
                                break;
                            #endregion

                            #region DROPDOWNLIST
                            case "DROPDOWNLIST":
                                ddl = (DropDownList)control;
                                if (propiedadDetalle.GetValue(resultado, null) == null)
                                    asignarValor = "-1";
                                else
                                {
                                    asignarValor = propiedadDetalle.GetValue(resultado, null).ToString();
                                    //ELIMINA EL ITEM EN BLANCO EN CASO DE EXISTIR
                                    AdministrarBlanco(ddl.ID, false);
                                }
                                //ASIGNACION DEL VALOR DESDE LA BD
                                generadorControles.SeleccionarOpcionDropDownList(ddl, asignarValor);
                                if ((propiedadDetalle.Name.ToString()).Contains("IdTipoPersona"))
                                    ddl.Enabled = false;
                                break;
                            #endregion
                        }

                        entidadLista.Add(new KeyValuePair<string, string>(propiedadDetalle.Name, asignarValor));
                    }
                    //Requerimiento Bloque 7 1-24381561 
                    else
                    {
                        ObtenerControlRegistros(resultado, propiedadDetalle);
                    }
                }
                //REALIZA LAS EXCEPCIONES DE LA CARGA DE DATOS A LOS CONTROLES
                DeEntidadAControlesExcepciones(entidadLista);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE LOS CONTROLES HACIA LA ENTIDAD PARA REALIZAR ACCIONES*/
    private void DeControlesAEntidad(int tipoAccion)
    {
        object entidad = null;
        string valorControl = string.Empty;
        var regexItem = new Regex("^[a-zA-Z0-9 .,/:ÁÉÍÓÚÑáéíóúñ()]*$");
        int banderaPropiedad = 1;

        // 0 = NO | 1 = SI
        int caracteresEspeciales = 0; 

        try
        {
            if (pantallaModuloOculto.Value != null)
            {
                #region OBTIENE EL TIPO DE LA ENTIDAD A CREAR DINAMICAMENTE

                //OBTIENE LA ENTIDAD DINAMICAMENTE
                entidad = ObtenerEntidad(entidad);
                //OBTIENE EL TIPO DE DATO DE LA ENTIDAD
                Type tipoEntidad = entidad.GetType();

                #endregion

                #region CONTROLES COMODIN

                TextBox txt = new TextBox();
                DropDownList ddl = null;

                #endregion

                Type tipoControl = null;
                Object control = null;

                //OBTIENE LAS PROPIEDADES DE LA ENTIDAD
                PropertyInfo[] propiedades = tipoEntidad.GetProperties();

                string entidadPropiedad = string.Empty;
                string entidadPropiedadTipo = string.Empty;

                foreach (PropertyInfo propiedad in propiedades)
                {
                    control = null;

                    entidadPropiedad = propiedad.Name;
                    entidadPropiedadTipo = propiedad.PropertyType.FullName;

                    //BUSCA EL CONTROL QUE POSEA EL MISMO NOMBRE QUE LA PROPIEDAD
                    control = this.tableData.FindControl(entidadPropiedad);

                    //SI EXISTE CONTROL O LA PROPIEDAD CORRESPONDE AL ID DE LA ENTIDAD
                    if ((control != null) || (propiedad.Name.Contains("Id"))) 
                    {

                        #region CREA LOS TIPOS DE CONTROL

                        if (control != null)
                        {
                            tipoControl = control.GetType();

                            switch (control.GetType().Name.ToUpper())
                            {
                                #region TEXTBOX
                                case "TEXTBOX":
                                    txt = (TextBox)control;
                                    valorControl = txt.Text;

                                    //EXCEPCION DE CONTROLES A ENTIDAD
                                    valorControl = DeControlesAEntidadExcepciones(propiedad.Name, valorControl);
                                    if (!regexItem.IsMatch(valorControl))
                                    {
                                        caracteresEspeciales = 1;
                                    }

                                    if (txt.ID.Contains("SalarioNetoFiador"))
                                    {
                                        TextBoxWatermarkExtender wm = (TextBoxWatermarkExtender)this.tableData.FindControl(string.Concat("wm", txt.ID));
                                        if (valorControl.Length < 1)
                                            valorControl = wm.WatermarkText;
                                    }
                                    break;
                                #endregion

                                #region MULTILINE
                                case "MULTILINE":
                                    txt = (TextBox)control;
                                    valorControl = txt.Text;
                                    if (!regexItem.IsMatch(valorControl))
                                    {
                                        caracteresEspeciales = 1;
                                    }
                                    break;
                                #endregion

                                #region DROPDOWNLIST
                                case "DROPDOWNLIST":
                                    ddl = (DropDownList)control;
                                    valorControl = generadorControles.ObtenerOpcionDropDownList(ddl);
                                    if (valorControl.Equals("-1"))
                                        valorControl = string.Empty;
                                    break;
                                #endregion
                            }

                        }
                        #endregion

                        //OBTIENE EL TIPO DE DATO CON EL FIN DE DETERMINAR CUALES ACEPTAN VALORES NULOS O NO (NULLEABLE TYPE)
                        entidadPropiedadTipo = ObtenerTipoDato(entidadPropiedadTipo, valorControl);

                        //PARA TODAS LAS PROPIEDADES DE LA ENTIDAD EXEPTO EL ID DE LA ENTIDAD
                        if (control != null) 
                        {
                            propiedad.SetValue(entidad, generadorControles.ConvertirTipoDato(entidadPropiedadTipo.ToUpper(), valorControl), null);//ASIGNA EL VALOR A LA PROPIEDAD
                        }
                        //PARA LA PROPIEDAD ID DE LA ENTIDAD
                        else 
                        {
                            //SI EL PROCESO CORRESPONDE A UNA MODIFICACION SE ASIGNA EL TIPO DE DATO ENTERO A LA PROPIEDAD DE LA ENTIDAD
                            propiedad.SetValue(entidad, generadorControles.ConvertirTipoDato(propiedad.PropertyType.Name.ToUpper(), pantallaIdOculto.Value), null);//ASIGNA EL VALOR A LA PROPIEDAD
                        }
                        banderaPropiedad++;
                    }

                    //Requerimiento Bloque 7 1-24381561
                    CrearControlRegistros(entidad, propiedad);
                }

                //VALIDA EL TIPO DE PERSONA ***NOTA: VALIDACION DESACTIVADA POR SOLICITUD DEL USUARIO. 19 Mar 2014
                if (ValidarTipoPersona(entidad))
                {
                    #region DIRECCIONAMIENTO SEGUN EL TIPO DE ACCION

                    if (!caracteresEspeciales.Equals(1)) // NO EXISTEN CARACTERES ESPECIALES
                    {
                        switch (tipoAccion)
                        {
                            case 0:
                                InsertarEntidad(pantallaNombreOculto.Value, wsGarantias, entidad);
                                break;
                            case 1:
                                ModificarEntidad(pantallaNombreOculto.Value, wsGarantias, entidad);
                                break;
                        }

                        //Bloque 7 Requerimiento 1-24381561
                        MostrarControlRegistrosGuardar();
                    }
                    else
                    {
                        BarraMensaje(null, "");
                    }

                    #endregion
                }
                else
                {
                    BarraMensaje(null, "9");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ACORTA LA CADENA DEL TIPO DE DATO*/
    private string ObtenerTipoDato(string tipoDatoLargo, string valorAsignar)
    {
        string retorno = tipoDatoLargo;

        if (tipoDatoLargo.ToUpper().Contains("INT32"))
            retorno = "INT32";
        if (tipoDatoLargo.ToUpper().Contains("DOUBLE"))
            retorno = "DOUBLE";
        if (tipoDatoLargo.ToUpper().Contains("DECIMAL"))
            retorno = "DECIMAL";
        if (tipoDatoLargo.ToUpper().Contains("STRING"))
            retorno = "STRING";
        if (tipoDatoLargo.ToUpper().Contains("DATETIME"))
            retorno = "DATETIME";
        if (tipoDatoLargo.ToUpper().Contains("BOOLEAN"))
            retorno = "BOOLEAN";
        if (valorAsignar.Length.Equals(0))
            retorno = "NULL";
       
        return retorno;
    }

    /*VALIDA EL NUMERO DE IDENTICACION PARA EL TIPO DE PERSONA 3 AL GUARDAR*/
    private bool ValidarTipoPersona(object _entidad) 
    {
        //***NOTA: VALIDACION DESACTIVADA POR SOLICITUD DEL USUARIO. 19 Mar 2014

        //DropDownList ddlIdTipoIdentificacionRUC = ((DropDownList)this.tableData.FindControl("TipoIdentificacionRUC"));

        //bool result = true;
        //String maskCampo = String.Empty;

        //if (ddlIdTipoIdentificacionRUC != null)
        //{
        //    if (!((GarantiasFiduciariasEntidad)_entidad).CodGarantia.StartsWith("1"))
        //    {
        //        if (ddlIdTipoIdentificacionRUC.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
        //            result = false;
        //    }
        //}

        //return result;

        return true;
    }

    /*VALIDA EL NUMERO DE IDENTICACION PARA EL TIPO DE PERSONA 3 AL BUSCAR EN BCR CLIENTES*/
    private bool ValidarTipoPersona()
    {
        //***NOTA: VALIDACION DESACTIVADA POR SOLICITUD DEL USUARIO. 19 Mar 2014

        //DropDownList ddlIdTipoIdentificacionRUC = ((DropDownList)this.tableData.FindControl("TipoIdentificacionRUC"));
        //TextBox txtGarantia = ((TextBox)this.tableData.FindControl("Garantia"));

        //bool result = true;
        //String maskCampo = String.Empty;

        //if (ddlIdTipoIdentificacionRUC != null && txtGarantia != null)
        //{
        //    if (ddlIdTipoIdentificacionRUC.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
        //    {
        //        if (!txtGarantia.Text.StartsWith("1"))
        //            result = false;
        //    }
        //}

        //return result;

        return true;
    }

    #region METODOS PARA EL DROPDOWNLIST

    protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string idDropDownList = ((DropDownList)(sender)).ID.ToString().ToUpper();

            switch (idDropDownList)
            {
                #region ID TIPO IDENTIFICACION RUC
                case "TIPOIDENTIFICACIONRUC":
                    ddlTipoPersona(sender);
                    break;
                #endregion

                #region ID TIPO AVAL O FIANZA
                case "IDTIPOAVALFIANZA":
                    ddlTipoAvalFianza(sender);
                    break;
                #endregion

                #region ID TIPO ASIGNACION CALIFICACION
                case "IDTIPOASIGNACIONCALIFICACION":
                    ddlTipoAsignacionCalificacion(sender);
                    break;
                #endregion

                #region ID PLAZO CALIFICACION
                case "IDPLAZOCALIFICACION":
                    ddlPlazoCalificacion(sender);
                    break;
                #endregion

                #region ID EMPRESA CALIFICADORA
                case "IDEMPRESACALIFICADORA":
                    ddlEmpresaCalificadora(sender);
                    break;
                #endregion

                #region ID CATEGORIA RIESGO  (CAT CALIFICACION)
                case "IDCATEGORIARIESGOEMPRESACALIFICADORA":
                    ddlCategoriaCalificacion(sender);
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

    private void ddlTipoAvalFianza(object sender)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            string seleccionado = ((DropDownList)this.tableData.FindControl("IdTipoAvalFianza")).SelectedItem.Text.Substring(0, 3);

            TextBox txtSalarioNetoFiador = ((TextBox)this.tableData.FindControl("SalarioNetoFiador"));
            TextBox txtFechaVerificacionAsalariado = ((TextBox)this.tableData.FindControl("FechaVerificacionAsalariado"));
            ImageButton imbFechaVerificacionAsalariado = ((ImageButton)this.tableData.FindControl("imgBtnCalendarExtenderFechaVerificacionAsalariado"));
            RequiredFieldValidator rfvFechaVerificacionAsalariado = ((RequiredFieldValidator)this.tableData.FindControl("rfvFechaVerificacionAsalariado"));
            //RequiredFieldValidator rfvSalarioNetoFiador = ((RequiredFieldValidator)this.tableData.FindControl("rfvSalarioNetoFiador"));
            TextBoxWatermarkExtender wmSalarioNetoFiador = ((TextBoxWatermarkExtender)this.tableData.FindControl("wmSalarioNetoFiador"));

            #endregion

            //SI EL VALOR EN TIPO AVAL O FIANZA NO ES IGUAL A 3 SE DEBEN DE INHABILITAR LOS SIGUIENTES OBJETOS
            if (!seleccionado.Equals("3 -"))
            {
                if (txtSalarioNetoFiador != null)
                {
                    txtSalarioNetoFiador.Enabled = false;
                    txtSalarioNetoFiador.Text = string.Empty;
                }
                if (txtFechaVerificacionAsalariado != null)
                {
                    txtFechaVerificacionAsalariado.Enabled = false;
                    txtFechaVerificacionAsalariado.Text = string.Empty;
                }
                if (imbFechaVerificacionAsalariado != null)
                    imbFechaVerificacionAsalariado.Enabled = false;
                if (rfvFechaVerificacionAsalariado != null)
                    rfvFechaVerificacionAsalariado.Enabled = false;
                //if (rfvSalarioNetoFiador != null)
                //    rfvSalarioNetoFiador.Enabled = false;
                if (wmSalarioNetoFiador != null)
                    wmSalarioNetoFiador.Enabled = false;
            }
            //SI EL VALOR EN TIPO AVAL O FIANZA ES IGUAL A 3 SE DEBEN DE HABILITAR LOS SIGUIENTES OBJETOS
            else
            {
                if (txtSalarioNetoFiador != null)
                {
                    txtSalarioNetoFiador.Enabled = true;
                    txtSalarioNetoFiador.Text = string.Empty;
                }
                if (txtFechaVerificacionAsalariado != null)
                {
                    txtFechaVerificacionAsalariado.Enabled = true;
                    txtFechaVerificacionAsalariado.Text = string.Empty;
                }
                if (imbFechaVerificacionAsalariado != null)
                    imbFechaVerificacionAsalariado.Enabled = true;
                if (rfvFechaVerificacionAsalariado != null)
                    rfvFechaVerificacionAsalariado.Enabled = true;
                //if (rfvSalarioNetoFiador != null)
                //    rfvSalarioNetoFiador.Enabled = true;

                if (wmSalarioNetoFiador != null)
                    wmSalarioNetoFiador.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlTipoAsignacionCalificacion(object sender)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            string seleccionado = ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion")).SelectedItem.Text.Substring(0, 3);

            DropDownList ddlIdPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlIdCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlIdCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            #endregion

            //SI TIPO ASIGNACIÓN CALIFICACIÓN ES DIFERENTE AL POR DEFECTO (“0 – NO TIENE CALIFICACIÓN”) SE DEBEN DE HABILITAR LOS SIGUIENTES OBJETOS
            if (!seleccionado.Equals("0 -"))
            {
                if (ddlIdPlazoCalificacion != null)
                {
                    AdministrarBlanco("IdPlazoCalificacion", false);
                    ddlIdPlazoCalificacion.Enabled = true;
                }
                if (ddlIdEmpresaCalificadora != null)
                {
                    AdministrarBlanco("IdEmpresaCalificadora", false);
                    ddlIdEmpresaCalificadora.Enabled = true;
                }
                if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                {
                    LimpiarDropDownList(ddlIdCategoriaRiesgoEmpresaCalificadora);
                    ddlEmpresaCalificadora(null);
                    AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", false);
                    ddlIdCategoriaRiesgoEmpresaCalificadora.Enabled = true;
                }
                if (ddlIdCalificacionEmpresaCalificadora != null)
                {
                    LimpiarDropDownList(ddlIdCalificacionEmpresaCalificadora);
                    ddlCategoriaCalificacion(sender);
                    AdministrarBlanco("IdCalificacionEmpresaCalificadora", false);
                    ddlIdCalificacionEmpresaCalificadora.Enabled = true;
                }
            }
            else
            {
                //SI TIPO ASIGNACIÓN CALIFICACIÓN ES IGUAL AL POR DEFECTO (“0 – NO TIENE CALIFICACIÓN”) SE DEBEN DE INHABILITAR LOS SIGUIENTES OBJETOS
                if (ddlIdPlazoCalificacion != null)
                {
                    AdministrarBlanco("IdPlazoCalificacion", true);
                    ddlIdPlazoCalificacion.Enabled = false;
                }
                if (ddlIdEmpresaCalificadora != null)
                {
                    AdministrarBlanco("IdEmpresaCalificadora", true);
                    ddlIdEmpresaCalificadora.Enabled = false;
                }
                if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                {
                    AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
                    ddlIdCategoriaRiesgoEmpresaCalificadora.Enabled = false;
                }
                if (ddlIdCalificacionEmpresaCalificadora != null)
                {
                    AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
                    ddlIdCalificacionEmpresaCalificadora.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlPlazoCalificacion(object sender)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            DropDownList ddlIdPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));

            #endregion

            if (ddlIdPlazoCalificacion != null)
            {

                if (!ddlIdPlazoCalificacion.SelectedValue.Equals("-1"))
                {
                    string valorfiltro = string.Empty;
                    valorfiltro = ddlIdPlazoCalificacion.SelectedValue;

                    if (ddlIdEmpresaCalificadora != null)
                    {
                        ddlIdEmpresaCalificadora.DataSource = LlenarDropDownList("EmpresasCalificadorasLista", valorfiltro);
                        ddlIdEmpresaCalificadora.DataTextField = "Texto";
                        ddlIdEmpresaCalificadora.DataValueField = "Valor";
                        ddlIdEmpresaCalificadora.DataBind();

                        ddlEmpresaCalificadora(sender);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlEmpresaCalificadora(object sender)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlIdCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));

            #endregion

            if (ddlIdEmpresaCalificadora != null)
            {
                if (!ddlIdEmpresaCalificadora.SelectedValue.Equals("-1"))
                {
                    string valorfiltro = string.Empty;
                    valorfiltro = ddlIdEmpresaCalificadora.SelectedValue;

                    if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                    {
                        LimpiarDropDownList(ddlIdCategoriaRiesgoEmpresaCalificadora);

                        ddlIdCategoriaRiesgoEmpresaCalificadora.DataSource = LlenarDropDownList("CalificacionesEmpresasCalificadorasCategoriaRiesgoLista", valorfiltro);
                        ddlIdCategoriaRiesgoEmpresaCalificadora.DataTextField = "Texto";
                        ddlIdCategoriaRiesgoEmpresaCalificadora.DataValueField = "Valor";
                        ddlIdCategoriaRiesgoEmpresaCalificadora.DataBind();

                        ddlCategoriaCalificacion(sender);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlCategoriaCalificacion(object sender)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            StringBuilder valorfiltro = new StringBuilder();
            valorfiltro.Clear();

            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlIdCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlIdCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            #endregion

            if (ddlIdEmpresaCalificadora != null)
            {
                if (!ddlIdEmpresaCalificadora.SelectedValue.Equals("-1"))
                {
                    if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                    {
                        valorfiltro.Append(ddlIdEmpresaCalificadora.SelectedValue);
                        valorfiltro.Append("|");
                        valorfiltro.Append(ddlIdCategoriaRiesgoEmpresaCalificadora.SelectedValue);

                        if (ddlIdCalificacionEmpresaCalificadora != null)
                        {
                            LimpiarDropDownList(ddlIdCalificacionEmpresaCalificadora);

                            ddlIdCalificacionEmpresaCalificadora.DataSource = LlenarDropDownList("CalificacionesEmpresasCalificadorasCalificacionLista", valorfiltro.ToString());
                            ddlIdCalificacionEmpresaCalificadora.DataTextField = "Texto";
                            ddlIdCalificacionEmpresaCalificadora.DataValueField = "Valor";
                            ddlIdCalificacionEmpresaCalificadora.DataBind();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ddlTipoPersona(object sender)
    {
        try
        {
            MaskedEditExtender mask = null;
            TextBox txt = null;
            String maskCampo = "Garantia";
            string valorSeleccionado = string.Empty;

            #region BUSQUEDA DE CONTROLES

            mask = ((MaskedEditExtender)this.tableData.FindControl(string.Concat("mask", maskCampo)));
            txt = ((TextBox)this.tableData.FindControl(maskCampo));

            #endregion

            if (mask != null && txt != null)
            {
                txt.Text = string.Empty;
                mask.InputDirection = MaskedEditInputDirection.LeftToRight;

                valorSeleccionado = ((DropDownList)(sender)).SelectedItem.Text.Substring(0, 3);

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
                        //mask.Mask = "9-999-999999-99";
                        mask.Filtered = string.Empty;
                        //txt.ToolTip = "1-###-######-##";
                        //txt.ToolTip = "#-###-######-##";
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
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE BD AL DDL*/
    private Object LlenarDropDownList(string wsMethodName, string filtro)
    {
        try
        {
            Type ws = wsListas.GetType();
            MethodInfo metodo = ws.GetMethod(wsMethodName);
            var resultado = metodo.Invoke(wsListas, new object[] { filtro });

            return resultado;
        }
        catch (Exception ex)
        {
            throw ex;
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

    #region ENTIDADES

    /*RETORNA LA ENTIDAD*/
    public object ObtenerEntidad(object _entidad)
    {
        _entidad = new GarantiasWS.GarantiasFiduciariasEntidad();
        return _entidad;
    }

    /*INSERTA UN NUEVO REGISTRO*/
    private void InsertarEntidad(string desPagina, SiganemGarantiasWS wsGarantias, object entidad)
    {
        try
        {
            string exec = "GarantiasFiduciariasInsertar";
            Type ws = wsGarantias.GetType();
            MethodInfo metodo = ws.GetMethod(exec);
            var resultado = metodo.Invoke(wsGarantias, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR) });
            //IDENTIDAD { 0=NUEVO; X=EDITAR }
            BarraMensaje((GarantiasWS.RespuestaEntidad)resultado, pantallaIdOculto.Value);

            //Bloque 7 Requerimiento 1-24381561
            if (((GarantiasWS.RespuestaEntidad)resultado).ValorError.Equals(0))
                this.pantallaIdOculto.Value = ((GarantiasWS.RespuestaEntidad)resultado).ValorEstado.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*MODIFICA UN REGISTRO*/
    private void ModificarEntidad(string desPagina, SiganemGarantiasWS wsGarantias, object entidad)
    {
        try
        {
            string exec = "GarantiasFiduciariasModificar";
            Type ws = wsGarantias.GetType();
            MethodInfo metodo = ws.GetMethod(exec);
            var resultado = metodo.Invoke(wsGarantias, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR) });
            BarraMensaje((GarantiasWS.RespuestaEntidad)resultado, pantallaIdOculto.Value);

            if (((GarantiasWS.RespuestaEntidad)resultado).ValorError.Equals(0))
                this.pantallaIdOculto.Value = ((GarantiasWS.RespuestaEntidad)resultado).ValorEstado.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Bloque 7 Requerimiento 1-24381561
    /*OBTIENE LOS DETALLES DEL ID DEL REGISTRO*/
    private object ConsultarDetalleEntidad()
    {
        try
        {
            GarantiasFiduciariasEntidad entidad = new GarantiasFiduciariasEntidad();
            if (pantallaModuloOculto.Value != null && pantallaIdOculto.Value != "0") //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            {
                #region OBTIENE EL TIPO DE LA ENTIDAD A CREAR DINAMICAMENTE

                Type tipoEntidad = entidad.GetType(); //OBTIENE EL TIPO DE DATO DE LA ENTIDAD

                #endregion

                //OBTIENE LAS PROPIEDADES DE LA ENTIDAD
                PropertyInfo[] propiedades = tipoEntidad.GetProperties();

                string entidadPropiedad = string.Empty;
                string entidadPropiedadTipo = string.Empty;

                //ASIGNA EL VALOR DEL ID DEL REGISTRO A CONSULTAR
                foreach (PropertyInfo propiedad in propiedades)
                {
                    if (propiedad.Name.Contains("Id"))
                    {
                        entidadPropiedad = propiedad.Name;
                        entidadPropiedadTipo = propiedad.PropertyType.Name;
                        //ASIGNA EL VALOR A LA PROPIEDAD EL ID CORRESPONDE A LA PRIMERA PROPIEDAD DE CADA ENTIDAD
                        propiedad.SetValue(entidad, generadorControles.ConvertirTipoDato(entidadPropiedadTipo.ToUpper(), pantallaIdOculto.Value), null);
                        break;
                    }
                }


                //OBTIENE EL RESTO DE CAMPOS DEL REGISTRO A CONSULTAR DESDE LA BD            
                string exec = "GarantiasFiduciariasConsultarDetalle";
                Type ws = wsGarantias.GetType();
                MethodInfo metodo = ws.GetMethod(exec);
                var resultado = metodo.Invoke(wsGarantias, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
                return resultado;
            }

            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region OTROS METODOS

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsSesiones.Url = ConfigurationManager.AppSettings["SesionesWCF"].ToString();
            wsSeguridad.Url = ConfigurationManager.AppSettings["SeguridadWS"].ToString();
            wsGarantias.Url = ConfigurationManager.AppSettings["GarantiasWS"].ToString();
            wsBCRClientes.Url = ConfigurationManager.AppSettings["BCRClientesWS"].ToString();
            wsListas.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(ConfigurationManager.AppSettings["Culture"].ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ConfigurationManager.AppSettings["Culture"].ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ESTABLECE LA RUTA A ESTA MISMA PAGINA PARA EFECTOS DE INSERTAR UN NUEVO REGISTRO*/
    protected Dictionary<string, string> Set_RutaVentana()
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

    /*CARGA LAS VARIABLES GLOBALES QUE VIENEN POR URL*/
    private void VariablesGlobales()
    {
        try
        {
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
                    case "idPagina":
                        pantallaIdOculto.Value = Request.Form["idPagina"].ToString();
                        break;
                    case "nombrePagina":
                        pantallaNombreOculto.Value = Request.Form["nombrePagina"].ToString();
                        break;
                    case "moduloPagina":
                        pantallaModuloOculto.Value = Request.Form["moduloPagina"].ToString();
                        break;
                    case "tituloPagina":
                        pantallaTituloOculto.Value = Request.Form["tituloPagina"].ToString();
                        break;
                }
            }
            #endregion

            this.Page.Title = pantallaTituloOculto.Value + " Detalle";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*MUESTRA BARRA DE MENSAJE SUPERIOR*/
    private void BarraMensaje(GarantiasWS.RespuestaEntidad ds, string tipoAccion)
    {
        try
        {
            SeguridadWS.MensajesEntidad mensajes = new SeguridadWS.MensajesEntidad();

            //MENSAJES RETORNADOS DESDE BD
            if (ds != null) 
            {
                //ERROR
                if (ds.ValorEstado.Equals(0))
                {
                    //CODIGO DE ERROR
                    mensajes.CodMensaje = "SQL_" + ds.ValorError; 
                    lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";
                    resultadoProceso = -1;
                }
                else
                {
                    mensajes.CodMensaje = "SYS_1";
                    lblBarraMensaje.CssClass = "etiquetaBarraMensajeExito";
                    resultadoProceso = 0;
                }
            }
            else
            {
                // MENSAJE DE VALIDACION DE TIPO CEDULA: EXTRANJERO RESIDENTE
                if (tipoAccion.Equals("9")) 
                {
                    //MENSAJE DE VALIDACION DE CARACTERES ESPECIALES
                    mensajes.CodMensaje = "VAL_1";
                    lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";
                    resultadoProceso = -1;
                }
                else
                {
                    //MENSAJE DE VALIDACION DE CARACTERES ESPECIALES
                    mensajes.CodMensaje = "SYS_2";
                    lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";
                    resultadoProceso = -1;
                }
            }

            //RETORNA MENSAJE DE ERROR
            lblBarraMensaje.Text = wsSeguridad.MensajesConsulta(mensajes).DesMensaje;
            this.divBarraMensaje.Visible = true;

            if (ds != null)
            {
                //PARA NUEVO REGISTRO INSERTADO SE DEBE REDIRECCIONAR AUTOMATICAMENTE A LA PANTALLA DE EDICION
                if (tipoAccion.Equals("0") && (!ds.ValorEstado.Equals(0)))
                {
                    BloquearControlesGuardar();
                }
            }
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

            bitacorasEntidad.CodAccion = bitacoraBanderas.TipoBitacoraConsulta(_tipo);
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

    private void BloquearControlesGuardar()
    {
        btnGuardar.Enabled = false;
        btnGuardarNuevo.Enabled = false;
        btnGuardarCerrar.Enabled = false;
        btnLimpiar.Enabled = false;
        btnAyudaGuardar.Enabled = false;

        tableData.Enabled = false;
    }

    private void LimpiarDropDownList(DropDownList _dropDownList)
    {
        //BORRA LOS VALORES DEL DDL, SE DEBE DE REALIZAR DE ESTA MANERA PARA ELIMINAR LOS DATOS EN CACHÉ DEL OBJ
        _dropDownList.ClearSelection();
        _dropDownList.Items.Clear();
        _dropDownList.SelectedValue = null;
        _dropDownList.DataSource = null;
        _dropDownList.DataBind();
    }

    #endregion

    #region MENSAJE CONFIRMAR

    /*OBTIENE EL MENSAJE DESDE BD*/
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

    /*EVENTO MESAJES EMERGENTES FORMULARIO FIANZAS*/
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

    /*EVENTO MENSAJES EMEGENTES DE BCR CLIENTES*/
    protected void InformarBoxBusqueda_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBoxBusqueda.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo));
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

                if (wsBCRClientes != null)
                {
                    wsBCRClientes.Dispose();
                    wsBCRClientes = null;
                }
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
            bitacoraBanderas = null;
            generadorControles = null;

            mensajesEntidad = null;
            bitacorasEntidad = null;

            disponible = true;
        }
    }

    #endregion

}