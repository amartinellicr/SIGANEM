using System;
using System.Net;
using System.Web;
using System.Text;
using System.Data;
using System.Linq;
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

public partial class OperacionesNew : System.Web.UI.Page
{
    #region PROPIEDADES

    #region VARIABLES

    private int tipoAccion = 0;
    private int banderaOculta = 0;
    private int banderaVentana = 0;
    private int resultadoProceso = 0;
    private bool rangoAcept = false;
    private bool rangoResponLegal = false;

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
    private Button btnBtnCancelar = null;
    private Button btnReplicar = null;

    private Button btnConsultarOperacion = null;
    private Button btnValidarOperacion = null;
    //AGREGAR REQUERIMIENTO 1-24493227
    private Button btnAgregarGarantia = null;
    private Button btnModificarGarantia = null;
    private Button btnEliminarGarantia = null;
    private Button btnBorrarSICC = null;
    private Button btnActualizarGrid = null;
    //AGREGAR REQUERIMIENTO 1-24493227
    private DropDownList ddlTipoOperacion = null;
    private DropDownList ddlTipoGarantia = null;

    Button btnAceptarFiduciaria = null;
    Button btnAceptarValores = null;
    Button btnAceptarReales = null;
    Button btnAceptarAvales = null;
    Button btnAceptarFideicomisos = null;

    #region GRID RELACIONES

    private GridView gridOperaciones = null;

    #endregion

    #region BCR CLIENTES RUC

    private GridView gridView = null;
    private Button btnCerrar = null;
    private Button btnAceptar = null;

    #endregion

    #endregion

    #region REFERENCIAS

    private BitacoraFlags bitacoraBanderas = new BitacoraFlags();
    private GeneradorControles generadorControles = new GeneradorControles();
    private MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private GarantiasWS.BitacorasEntidad bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
    private GarantiasWS.GarantiasOperacionesClientesEntidad entidadSICC = new GarantiasWS.GarantiasOperacionesClientesEntidad();
    private GarantiasWS.GarantiasOperacionesConsultaEntidad consultaEntidad = new GarantiasWS.GarantiasOperacionesConsultaEntidad();
    private GarantiasWS.GarantiasOperacionesClientesEntidad operacionesEntidad = new GarantiasWS.GarantiasOperacionesClientesEntidad();

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

            #region CONTROLES SUPERIORES

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR DE LA PESTANA SUPERIOR IZQUIERDA NEGRA
            this.btnAyudaGuardar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAyuda").FindControl("cmdAyudaGuardar"));
            this.btnAyudaGuardar.Click += new EventHandler(btnAyudaGuardar_Click);
            this.btnAyudaGuardar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE MODIFICAR
            this.btnAyudaCerrar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAyuda").FindControl("cmdAyudaRegresar"));
            this.btnAyudaCerrar.Click += new EventHandler(btnAyudaCerrar_Click);
            this.btnAyudaCerrar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR PRINCIPAL
            this.btnGuardar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardar"));
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);
            this.btnGuardar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE LIMPIAR
            this.btnLimpiar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesLimpiar"));
            this.btnLimpiar.Click += new EventHandler(btnLimpiar_Click);
            this.btnLimpiar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR Y NUEVO
            this.btnGuardarNuevo = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardarNuevo"));
            this.btnGuardarNuevo.Click += new EventHandler(btnGuardarNuevo_Click);
            this.btnGuardarNuevo.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR Y CERRAR
            this.btnGuardarCerrar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardarCerrar"));
            this.btnGuardarCerrar.Click += new EventHandler(btnGuardarCerrar_Click);
            this.btnGuardarCerrar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE CANCELAR
            this.btnBtnCancelar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesRegresar"));
            this.btnBtnCancelar.Click += new EventHandler(btnCancelar_Click);
            this.btnBtnCancelar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE REPLICA
            this.btnReplicar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesReplicar"));
            this.btnReplicar.Click += new EventHandler(btnReplicar_Click);
            this.btnReplicar.CausesValidation = false;
            this.btnReplicar.Visible = true;
            this.btnReplicar.Enabled = false;

            #endregion

            this.btnConsultarOperacion = ((Button)((wucOperacionConsulta)this.ParametrosSICC).FindControl("btnConsultarOperacion"));
            this.btnConsultarOperacion.CssClass = "botonConsultarSICC";
            this.btnConsultarOperacion.Click += new EventHandler(btnConsultarOperacion_Click);
            this.btnConsultarOperacion.CausesValidation = true;

            this.btnValidarOperacion = ((Button)((wucOperacionClientes)this.ClientesSICC).FindControl("btnValidarOperacion"));
            this.btnValidarOperacion.CssClass = "botonValidarOperacionDisabled";
            this.btnValidarOperacion.Click += new EventHandler(btnValidarOperacion_Click);
            this.btnValidarOperacion.Enabled = false;

            this.ddlTipoOperacion = ((DropDownList)((wucOperacionConsulta)this.ParametrosSICC).FindControl("ddlTipoOperacion"));
            this.ddlTipoOperacion.SelectedIndexChanged += new EventHandler(ddlTipoOperacion_SelectedIndexChanged);
            this.ddlTipoOperacion.AutoPostBack = true;

            #region REQUERIMIENTO 1-24493227

            this.ddlTipoGarantia = ((DropDownList)((wucOperacionesGridGarantias)this.GridGarantias).FindControl("ddlTipoGarantia"));

            this.btnAgregarGarantia = ((Button)((wucOperacionesGridGarantias)this.GridGarantias).FindControl("imgCmdAgregar"));
            this.btnAgregarGarantia.Click += new EventHandler(btnAgregarGarantia_Click);

            this.btnModificarGarantia = ((Button)((wucOperacionesGridGarantias)this.GridGarantias).FindControl("imgCmdModificar"));
            this.btnModificarGarantia.Click += new EventHandler(btnModificarGarantia_Click);

            this.btnEliminarGarantia = ((Button)((wucOperacionesGridGarantias)this.GridGarantias).FindControl("imgCmdEliminar"));
            this.btnEliminarGarantia.Click += new EventHandler(btnEliminarGarantia_Click);

            this.btnBorrarSICC = ((Button)((wucOperacionesGridGarantias)this.GridGarantias).FindControl("imgCmdBorrarSICC"));
            this.btnBorrarSICC.Click += new EventHandler(btnBorrarSICC_Click);

            this.btnActualizarGrid = ((Button)((wucOperacionesGridGarantias)this.GridGarantias).FindControl("btnActualizarGrid"));
            this.btnActualizarGrid.Click += new EventHandler(btnActualizarGrid_Click);

            this.btnAceptarFiduciaria = ((Button)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("btnAceptarFiduciaria"));
            btnAceptarFiduciaria.Click += new EventHandler(btnAceptarFiduciaria_Click);

            this.btnAceptarValores = ((Button)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("btnAceptarValores"));
            btnAceptarValores.Click += new EventHandler(btnAceptarValores_Click);

            this.btnAceptarReales = ((Button)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("btnAceptarReales"));
            btnAceptarReales.Click += new EventHandler(btnAceptarReales_Click);

            this.btnAceptarAvales = ((Button)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("btnAceptarAvales"));
            btnAceptarAvales.Click += new EventHandler(btnAceptarAvales_Click);

            #region RQ_MANT_2016022310547690_Backlog_865

            this.btnAceptarFideicomisos = ((Button)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("btnAceptarRelacionGarantiaFideicomiso"));
            btnAceptarFideicomisos.Click += new EventHandler(btnAceptarRelacionGarantiaFideicomiso_Click);

            #endregion
            #endregion

            #region MENSAJE INFORMAR

            Button btnAceptarInformar = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);
            btnAceptarInformar.CausesValidation = false;
            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

            #region MENSAJE ELIMINAR

            Button btnAceptarEliminar = (Button)this.EliminarBox1.FindControl("wucBtnAceptar");
            btnAceptarEliminar.Click += new EventHandler(btnAceptarEliminar_Click);

            Button btnCancelarEliminar = (Button)this.EliminarBox1.FindControl("wucBtnCancelar");
            btnCancelarEliminar.Click += new EventHandler(btnCancelarEliminar_Click);

            #endregion

            #endregion

            #region GRIDVIEW OPERACIONES

            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            gridOperaciones = (GridView)GridGarantias.FindControl("MasterGridView");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            gridOperaciones.Init += new EventHandler(gridOperaciones_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            gridOperaciones_Init(sender, e);

            #endregion

            if (!IsPostBack)
            {
                //LLAMADO A LOS EVENTOS QUE CREAN LOS CONTROLES EN EL FORMULARIO
                VariablesGlobales();
                valorReemplazo = string.Empty;

                #region GRIDVIEW OPERACIONES

                ClearGridView(0);

                //ASIGNA DATA KEYS
                String[] dataKeysString = { "IdGarantiaOperacion" };
                SetDataKeys(gridOperaciones, dataKeysString);

                #endregion
            }

            #region BCR CLIENTES RUC

            #region GRIDVIEW BCR CLIENTES RUC

            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridView = (GridView)this.BCRClientes.FindControl("MasterGridView");
            this.BCRClientes.TextoGridVacio("Cliente no existe en Clientes RUC.");
            this.gridView.Init += new EventHandler(gridView_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridView_Init(sender, e);

            #endregion

            #region BOTONES BCR CLIENTES RUC

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
                ((Label)this.BCRClientes.FindControl("lblTitulo")).Text = "Administración de Clientes RUC";
                ((Label)this.BCRClientes.FindControl("lblSubTitulo")).Text = "Seleccione un registro.";

                //ASIGNA DATA KEYS
                String[] dataKeysString = { "IdRUC" };
                this.SetDataKeys(gridView, dataKeysString);
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

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (!IsPostBack)
                {
                    //CARGA CONTROLES DEL FORM
                    Controles();
                    //CARGA LOS VALORES PARA LOS TITULOS
                    Etiquetas();
                    //CARGA LOS VALORES PARA LOS CONTROLES CON CEROS
                    ((wucOperacionConsulta)this.ParametrosSICC).CargarCerosOperacionConsulta();
                    DeEntidadAControles();//CARGA LOS VALORES DESDE BD PARA EL CASO DE LAS MODIFICACIONES
                    if (pantallaIdOculto.Value.Equals("0"))
                        BloquearControlesGuardar(true);
                    else
                    {
                        //Ajustes javendano 2015-01-13
                        BloquearControlesGuardar(true);
                        //AGREGAR REQUERIMIENTO 1-24493262
                        BloquearBotonesReplica();
                        //MENSAJE DE ADVERTENCIA DE GARANTIAS RELACIONADAS
                        this.InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_17");
                        this.mpeInformarBox.Show();
                    }
                }
            }
            else
            {
                // MENSAJE SESIÓN CADUCADA
                this.InformarBox1_SetConfirmationBoxEvent(null, e, EnumTipoMensaje.Caducado.ToString());
                this.mpeInformarBox.Show();

                this.btnReplicar.Enabled = false;
                btnLimpiar.Enabled = false;
                BloquearControlesGuardar(true);

                //REALIZA LAS EXCEPCIONES DE LA CARGA DE DATOS A LOS CONTROLES
                ((wucOperacionConsulta)this.ParametrosSICC).HabilitarContenido(false);
                ((wucOperacionClientes)this.ClientesSICC).HabilitarContenido(false);
                ((wucOperacionesGridGarantias)this.GridGarantias).habilitarBotonesGrid(false);
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    //REQUERIMIENTO BLOQUE 7 1-24381561
    #region CONTROL DE REGISTRO

    /*ASIGNA LOS VALORES DEL CONTROL DE REGISTRO A LA ENTIDAD */
    private void CrearControlRegistros(object _entidad)
    {
        try
        {
            string lblCodigoUsuario = ((HtmlInputHidden)this.Master.FindControl("codUsuarioOculto")).Value;
            foreach (PropertyInfo propiedad in _entidad.GetType().GetProperties())
            {

                switch (propiedad.Name.ToUpper())
                {
                    case "INDMETODOINSERCION":
                        propiedad.SetValue(_entidad, Resources.Resource._metodoInsercion, null);
                        break;
                    case "CODUSUARIOINGRESO":
                        propiedad.SetValue(_entidad, codUsuarioOculto.Value, null);
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void MostrarControlRegistrosGuardar(GarantiasOperacionesEntidad _entidad)
    {
        try
        {
            if (_entidad != null)
            {
                GarantiasOperacionesEntidad resultado = ((GarantiasOperacionesEntidad)ConsultarDetalleEntidad());
                ObtenerControlRegistros(resultado);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*OBTIENE LOS DATOS DEL CONTROL DE REGISTRO EN MODO EDICION*/
    private void ObtenerControlRegistros(GarantiasOperacionesEntidad _entidad)
    {
        try
        {
            Label lblCreadoPor = (Label)this.Master.FindControl("Propiedades1").FindControl("lblCreadoPor");
            Label lblModificadoPor = (Label)this.Master.FindControl("Propiedades1").FindControl("lblModificadoPor");
            Label lblFechaCreacion = (Label)this.Master.FindControl("Propiedades1").FindControl("lblFechaCreacion");
            Label lblFechaModificacion = (Label)this.Master.FindControl("Propiedades1").FindControl("lblFechaModificacion");
            Label lblFuente = (Label)this.Master.FindControl("Propiedades1").FindControl("lblFuente");

            if (_entidad != null)
            {
                if (lblFuente != null)
                    lblFuente.Text = _entidad.IndMetodoInsercion;

                if (lblCreadoPor != null)
                    lblCreadoPor.Text = _entidad.CodUsuarioIngreso;

                if (lblCreadoPor.Text.Length > 0)
                {
                    lblCreadoPor.ToolTip = lblCreadoPor.Text + " | " + _entidad.DesUsuarioIngreso;
                    lblCreadoPor.Text = (lblCreadoPor.ToolTip).Substring(0, 21);
                }

                if (lblFechaCreacion != null && _entidad.FechaIngreso != null)
                    lblFechaCreacion.Text = DateTime.Parse(_entidad.FechaIngreso.ToString()).ToString();
                else
                    lblFechaCreacion.Text = string.Empty;

                if (lblModificadoPor != null)
                    lblModificadoPor.Text = _entidad.CodUsuarioUltimaModificacion;

                if (lblModificadoPor.Text.Length > 0)
                {
                    lblModificadoPor.ToolTip = lblModificadoPor.Text + " | " + _entidad.DesUsuarioUltimaModificacion;
                    lblModificadoPor.Text = (lblModificadoPor.ToolTip).Substring(0, 21);
                }

                if (lblFechaModificacion != null && _entidad.FechaUltimaModificacion != null)
                    lblFechaModificacion.Text = DateTime.Parse(_entidad.FechaUltimaModificacion.ToString()).ToString();
                else
                    lblFechaModificacion.Text = string.Empty;
            }
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

    protected void btnAyudaGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                // 0 = SE MANTIENE EL MISMO REGISTRO
                banderaVentana = 0;
                //GUARDA Y ACTUALIZA PADRE
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
                //GUARDA Y ACTUALIZA PADRE
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

    protected void btnConsultarOperacion_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                #region BUSCAR CONTROLES

                DropDownList TipoOperacion = ((DropDownList)((wucOperacionConsulta)this.ParametrosSICC).FindControl("ddlTipoOperacion"));
                TextBox txtConta = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtConta"));
                TextBox txtOficina = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtOficina"));
                TextBox txtMoneda = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda"));
                TextBox txtProducto = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtProducto"));
                TextBox txtNumero = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtNumero"));

                #endregion

                if (txtProducto.Enabled)
                {
                    if (ValidarMascaraConsulta(txtConta) & ValidarMascaraConsulta(txtOficina) & ValidarMascaraConsulta(txtMoneda)
                    & ValidarMascaraConsulta(txtProducto) & ValidarMascaraConsulta(txtNumero))
                    {
                        RealizarConsultaRUC();
                    }
                }
                else
                {
                    if (ValidarMascaraConsulta(txtConta) & ValidarMascaraConsulta(txtOficina) & ValidarMascaraConsulta(txtMoneda)
                    & ValidarMascaraConsulta(txtNumero))
                    {
                        RealizarConsultaRUC();
                    }
                }
                this.btnValidarOperacion.Focus();
                this.btnValidarOperacion.CssClass = "botonValidarOperacion";
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnValidarOperacion_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (!ValidarSeccionOperacion())
                {
                    if (pantallaModuloOculto.Value != null)
                    {
                        //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD
                        List<ControlEntidad> controles = new List<ControlEntidad>();
                        controles = ObtenerControlesBD(pantallaModuloOculto.Value, "Tab3");

                        ((wucOperacionesGridGarantias)this.GridGarantias).CargarControlesOperacionGrid(controles);
                    }
                    ((wucOperacionesGridGarantias)this.GridGarantias).habilitarBotonesGrid(true);
                    ((Button)((wucOperacionConsulta)this.ParametrosSICC).FindControl("btnConsultarOperacion")).Enabled = false;
                    ((Button)((wucOperacionConsulta)this.ParametrosSICC).FindControl("btnConsultarOperacion")).CssClass = "botonConsultarSICCDisabled";

                    this.ClientesSICC.HabilitarContenido(false);

                    BloquearControlesGuardar(false);
                    btnLimpiar.Enabled = true;

                    #region CONSULTAR RELACIONES

                    ClearGridView(int.Parse(idOperacionOculto.Value));

                    #endregion
                }
                else
                {
                    //MENSAJE DE ERROR DE FORMATO
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SQL_2601");
                    this.mpeInformarBox.Show();
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnAgregarGarantia_Click(object sender, EventArgs e)
    {
        tipoAccion = 0;
        int valorFecha = 0;
        HtmlTable tableGeneral = null;
        string valorMoneda = string.Empty;
        string filtroFecha = string.Empty;
        string filtroMitigador = string.Empty;
        string TipoOperacion = string.Empty;
        string ValorColonizado = string.Empty;
        string ValorOriginalColonizado = string.Empty;
        List<GarantiasWS.ListaEntidad> resultadoFecha = null;
        List<GarantiasWS.ListaEntidad> resultadoPorcAceptSugef = null;

        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                ((wucOperacionesGridGarantias)this.GridGarantias).LimpiarValoresSeleccionados("lblIdGarantiaOperacion");
                DropDownList ddlTipoOperacion = ((DropDownList)((wucOperacionConsulta)this.ParametrosSICC).FindControl("ddlTipoOperacion"));
                TipoOperacion = ddlTipoOperacion.SelectedItem.Value;
                TextBox txtSaldoColonizado = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtSaldoColonizado"));
                ValorColonizado = txtSaldoColonizado.Text;
                TextBox txtSaldoOriginalColonizado = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtSaldoOriginalColonizado"));
                ValorOriginalColonizado = txtSaldoOriginalColonizado.Text;

                #region VALRES OCULTOS

                StringBuilder sesionBuilder = new StringBuilder();
                sesionBuilder.Append(idSesionOculto.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(pantallaModuloOculto.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(codUsuarioOculto.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(idOperacionOculto.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(ddlTipoGarantia.SelectedItem.Value); 
                sesionBuilder.Append("|");
                sesionBuilder.Append(ddlTipoOperacion.SelectedItem.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(txtSaldoColonizado.Text);
                sesionBuilder.Append("|");
                sesionBuilder.Append(txtSaldoOriginalColonizado.Text);
                

                #endregion

                switch (ddlTipoGarantia.SelectedItem.Value)
                {
                    #region GARANTIAS FIDUCIARIA
                    case "2":
                        mpeFiduciaria.Show();
                        ((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).LimpiarContenidoControlFiduciaria();

                        ((HtmlInputHidden)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                        ((HtmlInputHidden)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                        tableGeneral = ((HtmlTable)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("tableGeneral"));
                        generadorControles.Bloquear_Controles(tableGeneral, false);
                        ((Button)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("btnConsultarGarantia")).Enabled = true;
                        ((Button)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacion";
                        ((HtmlTable)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("tableAdicionales")).Disabled = true;

                        //CARGA LOS CONTROLES
                        List<ControlEntidad> controlesFiduciarias = ObtenerControlesBD(pantallaModuloOculto.Value, "Fiduciaria");
                        ((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).CargarContenidoControlFiduciaria(controlesFiduciarias);
                        ((UpdatePanel)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("updFiduciariaPopUpControl")).Update();

                        #region CARGAR VALORES DEFAULT

                        //SELECCIONA MONEDA ASIGNAR VALOR DEFAULT AL DROPDOWNLIST
                        DropDownList ddlTipoMonedaGravamenFiduciaria = ((DropDownList)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("ddlIdTipoMonedaGradoGravamen"));
                        valorMoneda = int.Parse(((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda")).Text).ToString();
                        generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMonedaGravamenFiduciaria, valorMoneda);

                        TextBox txtFechaConstitucionFiduciaria = ((TextBox)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("txtFechaConstitucionGarantia"));
                        txtFechaConstitucionFiduciaria.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC")).Text;

                        TextBox txtFechaVencimientoFiduciaria = ((TextBox)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("txtFechaVencimientoGarantia"));
                        txtFechaVencimientoFiduciaria.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;

                        filtroFecha = generadorControles.ValidarFechaPrescripcionGarantia("FIDUCIARIA", 0, 0);
                        resultadoFecha = wsGarantias.GarantiasOperacionesFechaPrescripcionGarantia(filtroFecha).ToList();
                        valorFecha = int.Parse(resultadoFecha[0].Texto);
                        TextBox txtFechaPrescripcionFiduciaria = ((TextBox)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("txtFechaPrescripcionGarantia"));
                        txtFechaPrescripcionFiduciaria.Text = DateTime.Parse(txtFechaVencimientoFiduciaria.Text).AddMonths(valorFecha).ToShortDateString();
                        
                        #endregion

                        ((UpdatePanel)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("updFiduciariaPopUpControl")).Update();
                        break;
                    #endregion
                    #region GARANTIAS REALES
                    case "3":
                        mpeReales.Show();
                        ((wucOperacionRelacionReales)this.GarantiaReales).LimpiarGridCedulas();

                        ((HtmlInputHidden)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                        ((HtmlInputHidden)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                        ((Button)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("btnConsultarGarantia")).Enabled = true;
                        ((Button)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacion";
                        ((wucOperacionRelacionReales)this.GarantiaReales).HabilitarContenidoGenerales(false);
                        ((HtmlTable)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("tableCedulas")).Disabled = true;
                        tableGeneral = ((HtmlTable)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("tableGeneral"));
                        generadorControles.Bloquear_Controles(tableGeneral, false);
                        ((HtmlTable)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("tableAdicionales")).Disabled = true;

                        //CARGA LOS CONTROLES
                        List<ControlEntidad> controlesReales = ObtenerControlesBD(pantallaModuloOculto.Value, "Reales");
                        ((wucOperacionRelacionReales)this.GarantiaReales).CargarContenidoControlReales(controlesReales);
                        ((wucOperacionRelacionReales)this.GarantiaReales).CargarContenidoDefaultReales();
                        ((UpdatePanel)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("updRealesPopUpControl")).Update();

                        #region CARGAR VALORES DEFAULT

                        //SELECCIONA MONEDA ASIGNAR VALOR DEFAULT AL DROPDOWNLIST
                        DropDownList ddlTipoMonedaGravamenReales = ((DropDownList)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("ddlIdTipoMonedaGradoGravamen"));
                        valorMoneda = int.Parse(((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda")).Text).ToString();
                        generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMonedaGravamenReales, valorMoneda);

                        TextBox txtFechaConstitucionReales = ((TextBox)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("txtFechaConstitucionGarantia"));
                        txtFechaConstitucionReales.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC")).Text;

                        TextBox txtFechaVencimientoReales = ((TextBox)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("txtFechaVencimientoGarantia"));
                        txtFechaVencimientoReales.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;

                        #endregion

                        ((UpdatePanel)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("updRealesPopUpControl")).Update();
                        break;
                    #endregion
                    #region GARANTIAS VALORES
                    case "4":
                        mpeValores.Show();
                        ((wucOperacionRelacionValores)this.GarantiaValores).LimpiarContenidoControlValores();

                        ((HtmlInputHidden)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                        ((HtmlInputHidden)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                        ((Button)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("btnConsultarGarantia")).Enabled = true;
                        ((Button)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacion";
                        tableGeneral = ((HtmlTable)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("tableGeneral"));
                        generadorControles.Bloquear_Controles(tableGeneral, false);
                        ((HtmlTable)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("tableAdicionales")).Disabled = true;

                        //CARGA LOS CONTROLES
                        List<ControlEntidad> controlesValores = ObtenerControlesBD(pantallaModuloOculto.Value, "Valores");
                        ((wucOperacionRelacionValores)this.GarantiaValores).CargarContenidoControlValores(controlesValores);
                        ((UpdatePanel)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("updValoresPopUpControl")).Update();

                        #region CARGAR VALORES DEFAULT

                        //SELECCIONA MONEDA ASIGNAR VALOR DEFAULT AL DROPDOWNLIST
                        DropDownList ddlTipoMonedaGravamenValores = ((DropDownList)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("ddlIdTipoMonedaGradoGravamen"));
                        valorMoneda = int.Parse(((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda")).Text).ToString();
                        generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMonedaGravamenValores, valorMoneda);

                        TextBox txtFechaConstitucionValores = ((TextBox)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("txtFechaConstitucionGarantia"));
                        txtFechaConstitucionValores.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC")).Text;

                        TextBox txtFechaVencimientoValores = ((TextBox)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("txtFechaVencimientoGarantia"));
                        txtFechaVencimientoValores.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;

                        filtroFecha = generadorControles.ValidarFechaPrescripcionGarantia("VALORES", 0, 0);
                        resultadoFecha = wsGarantias.GarantiasOperacionesFechaPrescripcionGarantia(filtroFecha).ToList();
                        valorFecha = int.Parse(resultadoFecha[0].Texto);

                        TextBox txtFechaPrescripcionValores = ((TextBox)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("txtFechaPrescripcionGarantia"));
                        txtFechaPrescripcionValores.Text = DateTime.Parse(txtFechaVencimientoValores.Text).AddMonths(valorFecha).ToShortDateString();

                        #endregion

                        ((UpdatePanel)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("updValoresPopUpControl")).Update();
                        break;
                    #endregion

                    //Req F2S03 2016-21-06
                    #region GARANTIAS AVALES
                    case "11":
                        mpeAvales.Show();
                        ((wucOperacionRelacionAvales)this.GarantiaAvales).LimpiarContenidoControlAvales();

                        ((HtmlInputHidden)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                        ((HtmlInputHidden)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                        tableGeneral = ((HtmlTable)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("tableGeneral"));
                        generadorControles.Bloquear_Controles(tableGeneral, false);
                        ((Button)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("btnConsultarGarantia")).Enabled = true;
                        ((Button)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacion";
                        ((HtmlTable)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("tableAdicionales")).Disabled = true;

                        //CARGA LOS CONTROLES
                        List<ControlEntidad> controlesAvales = ObtenerControlesBD(pantallaModuloOculto.Value, "Avales");
                        ((wucOperacionRelacionAvales)this.GarantiaAvales).CargarContenidoControlAvales(controlesAvales);
                        ((UpdatePanel)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("updAvalesPopUpControl")).Update();
                        ((wucOperacionRelacionAvales)this.GarantiaAvales).HabilitarContenidoExcepcionesGenerales(false);

                        #region CARGAR VALORES DEFAULT

                        //SELECCIONA MONEDA ASIGNAR VALOR DEFAULT AL DROPDOWNLIST
                        DropDownList ddlTipoMonedaGravamenAvales = ((DropDownList)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("ddlIdTipoMonedaGradoGravamen"));
                        valorMoneda = int.Parse(((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda")).Text).ToString();
                        generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMonedaGravamenAvales, valorMoneda);

                        TextBox txtFechaConstitucionAvales = ((TextBox)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("txtFechaConstitucionGarantia"));
                        txtFechaConstitucionAvales.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC")).Text;

                        TextBox txtFechaVencimientoAvales = ((TextBox)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("txtFechaVencimientoGarantia"));
                        txtFechaVencimientoAvales.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;

                        filtroFecha = generadorControles.ValidarFechaPrescripcionGarantia("AVAL", 0, 0);
                        resultadoFecha = wsGarantias.GarantiasOperacionesFechaPrescripcionGarantia(filtroFecha).ToList();
                        valorFecha = int.Parse(resultadoFecha[0].Texto);
                        TextBox txtFechaPrescripcionAvales = ((TextBox)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("txtFechaPrescripcionGarantia"));
                        txtFechaPrescripcionAvales.Text = DateTime.Parse(txtFechaVencimientoAvales.Text).AddMonths(valorFecha).ToShortDateString();

                        DropDownList ddlIdTipoMitigadorRiesgo = ((DropDownList)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("ddlIdTipoMitigadorRiesgo"));
                        filtroMitigador = ddlIdTipoMitigadorRiesgo.SelectedItem.Value;
                        resultadoPorcAceptSugef = wsGarantias.CategoriasCalificacionesTiposMitigadoresRiesgos(filtroMitigador,"11").ToList();
                        TextBox txtPorcentajeAceptSugef = ((TextBox)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("txtPorcentajeAceptSugef"));
                        txtPorcentajeAceptSugef.Text = resultadoPorcAceptSugef[0].Texto;

                        //DropDownList ddlTipoOperacion = ((DropDownList)((wucOperacionConsulta)this.ParametrosSICC).FindControl("ddlTipoOperacion"));
                        //TipoOperacion = ddlTipoOperacion.SelectedItem.Value;
                        //TextBox txtSaldoColonizado = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtSaldoColonizado"));
                        //ValorColonizado = txtSaldoColonizado.Text;
                        //TextBox txtSaldoOriginalColonizado = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtSaldoOriginalColonizado"));
                        //ValorOriginalColonizado = txtSaldoOriginalColonizado.Text;
                        ((wucOperacionRelacionAvales)this.GarantiaAvales).OperacionMontoMitigadorCalculado(TipoOperacion, ValorColonizado, ValorOriginalColonizado);

                        #endregion

                        ((UpdatePanel)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("updAvalesPopUpControl")).Update();
                        break;
                    #endregion

                    #region GARANTIAS FIDEICOMISO
                    case "8":
                        mpeRelacionGarantiaFideicomiso.Show();
                        ((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).LimpiarContenidoControlRelacionGarantiaFideicomiso();

                        ((HtmlInputHidden)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                        ((HtmlInputHidden)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                        ((Button)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("btnConsultarFideicomiso")).Enabled = true;
                        ((Button)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("btnConsultarFideicomiso")).CssClass = "botonConsultarRelacion";
                        tableGeneral = ((HtmlTable)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("tableGeneral"));
                        generadorControles.Bloquear_Controles(tableGeneral, false);
                        ((HtmlTable)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("tableAdicionales")).Disabled = true;

                        #region CARGA LOS CONTROLES

                        List<ControlEntidad> controlesFideicomiso = ObtenerControlesBD(pantallaModuloOculto.Value, "Fideico");
                        ((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).CargarContenidoControlRelacionGarantiaFideicomiso(controlesFideicomiso);
                        ((UpdatePanel)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("updRelacionGarantiaFideicomisoPopUpControl")).Update();

                        #endregion

                        #region CARGAR VALORES DEFAULT

                        //SELECCIONA MONEDA ASIGNAR VALOR DEFAULT AL DROPDOWNLIST
                        DropDownList ddlTipoMontoGravemen = ((DropDownList)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("ddlTipoMonedaMontoGraven"));
                        valorMoneda = int.Parse(((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda")).Text).ToString();
                        generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMontoGravemen, valorMoneda);

                        string fechaVencimientoFideicomiso = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;

                        filtroFecha = generadorControles.ValidarFechaPrescripcionGarantia("FIDEICOMISO DE GARANTÍA", 0, 0);
                        resultadoFecha = wsGarantias.GarantiasOperacionesFechaPrescripcionGarantia(filtroFecha).ToList();
                        valorFecha = int.Parse(resultadoFecha[0].Texto);

                        TextBox txtFechaPrescripcionFideicomiso = ((TextBox)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("txtFechaPrescripcionGarantia"));
                        txtFechaPrescripcionFideicomiso.Text = DateTime.Parse(fechaVencimientoFideicomiso).AddMonths(valorFecha).ToShortDateString();

                        this.RelacionGarantiaFideicomiso.LimpiarBarraMensaje();

                        #endregion

                        break;
                    #endregion
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }

    }

    protected void btnModificarGarantia_Click(object sender, EventArgs e)
    {
        try
        {
            tipoAccion = 1;
            int valorFecha = 0;
            HtmlTable tableGeneral = null;
            string estado = string.Empty;
            string valorMoneda = string.Empty;
            string filtroFecha = string.Empty;
            string TipoOperacion = string.Empty;
            string ValorColonizado = string.Empty;
            string ValorOriginalColonizado = string.Empty;
            List<GarantiasWS.ListaEntidad> resultadoFecha = null;
            string filtroMitigador = string.Empty;
            //List<GarantiasWS.ListaEntidad> resultadoPorcAceptSugef = null;

            GarantiasOperacionesEntidad entidad = new GarantiasOperacionesEntidad();
            GarantiasOperacionesRelacionEntidad resultadoOperacion = new GarantiasOperacionesRelacionEntidad();
            GarantiasFiduciariasEntidad resultadoFiduciaria = new GarantiasFiduciariasEntidad();
            GarantiasValoresEntidad resultadoValores = new GarantiasValoresEntidad();
            GarantiasRealesEntidad resultadoReales = new GarantiasRealesEntidad();
            GarantiasAvalesEntidad resultadoAvales = new GarantiasAvalesEntidad();
            GarantiasFideicomisosEntidad resultadoFideicomisos = new GarantiasFideicomisosEntidad();

            gridOperaciones = (GridView)GridGarantias.FindControl("MasterGridView");

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (((wucOperacionesGridGarantias)this.GridGarantias).ContadorSeleccionados().Equals(1)) //SI SOLO EXISTE UN REGISTRO SELECCIONADO
                {
                    foreach (GridViewRow row in gridOperaciones.Rows)
                    {
                        CheckBox checkBoxColumn = (CheckBox)gridOperaciones.Rows[row.RowIndex].FindControl("chkBox1");
                        if (checkBoxColumn.Checked)
                        {
                            List<string> valorSeleccionado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerValoresSeleccionados("lblIdGarantiaOperacion");
                            DropDownList ddlTipoOperacion = ((DropDownList)((wucOperacionConsulta)this.ParametrosSICC).FindControl("ddlTipoOperacion"));
                            TipoOperacion = ddlTipoOperacion.SelectedItem.Value;
                            TextBox txtSaldoColonizado = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtSaldoColonizado"));
                            ValorColonizado = txtSaldoColonizado.Text;
                            TextBox txtSaldoOriginalColonizado = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtSaldoOriginalColonizado"));
                            ValorOriginalColonizado = txtSaldoOriginalColonizado.Text;

                            entidad.IdGarantiaOperacion = int.Parse(valorSeleccionado[0]);
                            entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                            resultadoOperacion = wsGarantias.GarantiasOperacionesConsultarRelacion(entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                            #region CREAR LOS PARAMETROS AL POPUP

                            StringBuilder sesionBuilder = new StringBuilder();
                            sesionBuilder.Append(idSesionOculto.Value);
                            sesionBuilder.Append("|");
                            sesionBuilder.Append(pantallaModuloOculto.Value);
                            sesionBuilder.Append("|");
                            sesionBuilder.Append(codUsuarioOculto.Value);
                            sesionBuilder.Append("|");
                            sesionBuilder.Append(idOperacionOculto.Value);
                            sesionBuilder.Append("|");
                            sesionBuilder.Append(ddlTipoGarantia.SelectedItem.Value);
                            sesionBuilder.Append("|");
                            sesionBuilder.Append(ddlTipoOperacion.SelectedItem.Value);
                            sesionBuilder.Append("|");
                            sesionBuilder.Append(txtSaldoColonizado.Text);
                            sesionBuilder.Append("|");
                            sesionBuilder.Append(txtSaldoOriginalColonizado.Text);
                            
                            #endregion

                            switch (resultadoOperacion.IdTipoGarantia)
                            {
                                #region GARANTIAS FIDUCIARIA
                                case 2:
                                    bool replicado = ((wucOperacionesGridGarantias)this.GridGarantias).ValidarEstadoGarantiaFiduciaria(entidad.IdGarantiaOperacion);
                                    if (!replicado)
                                    {
                                        resultadoFiduciaria.IdGarantiaFiduciaria = int.Parse(resultadoOperacion.IdGarantiaFiduciaria.ToString());
                                        resultadoFiduciaria = wsGarantias.GarantiasFiduciariasConsultarDetalle(resultadoFiduciaria, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
                                        mpeFiduciaria.Show();

                                        #region CARGAR CONTROL

                                        ((HtmlInputHidden)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                                        ((HtmlInputHidden)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                                        ((Button)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("btnConsultarGarantia")).Enabled = false;
                                        ((Button)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacionDisabled";
                                        ((HtmlTable)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("tableAdicionales")).Disabled = false;

                                        //CARGA LOS CONTROLES
                                        List<ControlEntidad> controlesFiduciarias = ObtenerControlesBD(pantallaModuloOculto.Value, "Fiduciaria");
                                        ((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).CargarContenidoControlFiduciaria(controlesFiduciarias);
                                        ((UpdatePanel)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("updFiduciariaPopUpControl")).Update();

                                        //SELECCIONA MONEDA ASIGNAR VALOR DEFAULT AL DROPDOWNLIST
                                        DropDownList ddlTipoMonedaGravamenFiduciaria = ((DropDownList)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("ddlIdTipoMonedaGradoGravamen"));
                                        valorMoneda = int.Parse(((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda")).Text).ToString();
                                        generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMonedaGravamenFiduciaria, valorMoneda);

                                        tableGeneral = ((HtmlTable)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("tableGeneral"));
                                        generadorControles.Bloquear_Controles(tableGeneral, false);

                                        #endregion
                                        #region CARGAR VALORES

                                        ((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).DeEntidadAControles(resultadoOperacion, resultadoFiduciaria);
                                        estado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerEstadoGarantiaSeleccionado();
                                        ((HtmlInputHidden)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("estadoGarantiaOculto")).Value = estado;
                                        ((UpdatePanel)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("updFiduciariaPopUpControl")).Update();

                                        #endregion
                                        #region CARGAR VALORES DEFAULT

                                        this.GarantiaFiduciaria.LimpiarBarraMensaje();

                                        TextBox txtFechaConstitucionFiduciaria = ((TextBox)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("txtFechaConstitucionGarantia"));
                                        txtFechaConstitucionFiduciaria.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC")).Text;

                                        TextBox txtFechaVencimientoFiduciaria = ((TextBox)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("txtFechaVencimientoGarantia"));
                                        txtFechaVencimientoFiduciaria.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;

                                        filtroFecha = generadorControles.ValidarFechaPrescripcionGarantia("FIDUCIARIA", 0, 0);
                                        resultadoFecha = wsGarantias.GarantiasOperacionesFechaPrescripcionGarantia(filtroFecha).ToList();
                                        valorFecha = int.Parse(resultadoFecha[0].Texto);

                                        TextBox txtFechaPrescripcionFiduciaria = ((TextBox)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("txtFechaPrescripcionGarantia"));
                                        txtFechaPrescripcionFiduciaria.Text = DateTime.Parse(txtFechaVencimientoFiduciaria.Text).AddMonths(valorFecha).ToShortDateString();

                                        #endregion

                                        ((UpdatePanel)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("updFiduciariaPopUpControl")).Update();
                                    }
                                    else
                                    {
                                        //MENSAJE DE ADVERTENCIA DE GARANTIAS RELACIONADAS
                                        this.InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_14");
                                        this.mpeInformarBox.Show();
                                    }
                                    break;
                                #endregion
                                #region GARANTIAS REALES
                                case 3:
                                    resultadoReales.IdGarantiaReal = int.Parse(resultadoOperacion.IdGarantiaReal.ToString());
                                    resultadoReales = wsGarantias.GarantiasRealesConsultarDetalle(resultadoReales, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
                                    ((wucOperacionRelacionReales)this.GarantiaReales).LimpiarGridCedulas();
                                    mpeReales.Show();

                                    #region CARGAR CONTROL

                                    ((HtmlInputHidden)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                                    ((HtmlInputHidden)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                                    ((Button)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("btnConsultarGarantia")).Enabled = false;
                                    ((Button)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacionDisabled";
                                    ((HtmlTable)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("tableCedulas")).Disabled = true;
                                    ((HtmlTable)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("tableAdicionales")).Disabled = false;

                                    //CARGA LOS CONTROLES
                                    List<ControlEntidad> controlesReales = ObtenerControlesBD(pantallaModuloOculto.Value, "Reales");
                                    ((wucOperacionRelacionReales)this.GarantiaReales).CargarContenidoControlReales(controlesReales);
                                    ((wucOperacionRelacionReales)this.GarantiaReales).CargarContenidoDefaultReales();
                                    ((UpdatePanel)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("updRealesPopUpControl")).Update();

                                    //SELECCIONA MONEDA ASIGNAR VALOR DEFAULT AL DROPDOWNLIST
                                    DropDownList ddlTipoMonedaGravamenReales = ((DropDownList)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("ddlIdTipoMonedaGradoGravamen"));
                                    valorMoneda = int.Parse(((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda")).Text).ToString();
                                    generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMonedaGravamenReales, valorMoneda);

                                    ((wucOperacionRelacionReales)this.GarantiaReales).HabilitarContenidoGenerales(false);
                                    tableGeneral = ((HtmlTable)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("tableGeneral"));
                                    generadorControles.Bloquear_Controles(tableGeneral, false);

                                    #region CARGAR VALORES DEFAULT

                                    TextBox txtFechaConstitucionReales = ((TextBox)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("txtFechaConstitucionGarantia"));
                                    txtFechaConstitucionReales.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC")).Text;

                                    TextBox txtFechaVencimientoReales = ((TextBox)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("txtFechaVencimientoGarantia"));
                                    txtFechaVencimientoReales.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;

                                    this.GarantiaReales.LimpiarBarraMensaje();

                                    #endregion

                                    #endregion
                                    #region CARGAR VALORES

                                    ((wucOperacionRelacionReales)this.GarantiaReales).DeEntidadAControles(resultadoOperacion, resultadoReales);
                                    estado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerEstadoGarantiaSeleccionado();
                                    ((HtmlInputHidden)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("estadoGarantiaOculto")).Value = estado;
                                    ((UpdatePanel)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("updRealesPopUpControl")).Update();

                                    #endregion

                                    ((DropDownList)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("ddlIdClaseGarantiaPrt17")).Enabled = false;
                                    ((UpdatePanel)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("updRealesPopUpControl")).Update();

                                    break;
                                #endregion
                                #region GARANTIAS VALORES
                                case 4:
                                    resultadoValores.IdGarantiaValor = int.Parse(resultadoOperacion.IdGarantiaValor.ToString());
                                    resultadoValores = wsGarantias.GarantiasValoresConsultarDetalle(resultadoValores, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
                                    mpeValores.Show();

                                    #region CARGAR CONTROL

                                    ((HtmlInputHidden)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                                    ((HtmlInputHidden)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                                    ((Button)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("btnConsultarGarantia")).Enabled = false;
                                    ((Button)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacionDisabled";
                                    ((HtmlTable)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("tableAdicionales")).Disabled = false;

                                    //CARGA LOS CONTROLES
                                    List<ControlEntidad> controlesValores = ObtenerControlesBD(pantallaModuloOculto.Value, "Valores");
                                    ((wucOperacionRelacionValores)this.GarantiaValores).CargarContenidoControlValores(controlesValores);
                                    ((UpdatePanel)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("updValoresPopUpControl")).Update();

                                    //SELECCIONA MONEDA ASIGNAR VALOR DEFAULT AL DROPDOWNLIST
                                    DropDownList ddlTipoMonedaGravamenValores = ((DropDownList)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("ddlIdTipoMonedaGradoGravamen"));
                                    valorMoneda = int.Parse(((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda")).Text).ToString();
                                    generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMonedaGravamenValores, valorMoneda);

                                    tableGeneral = ((HtmlTable)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("tableGeneral"));
                                    generadorControles.Bloquear_Controles(tableGeneral, false);

                                    #endregion
                                    #region CARGAR VALORES

                                    ((wucOperacionRelacionValores)this.GarantiaValores).DeEntidadAControles(resultadoOperacion, resultadoValores);
                                    estado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerEstadoGarantiaSeleccionado();
                                    ((HtmlInputHidden)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("estadoGarantiaOculto")).Value = estado;
                                    ((UpdatePanel)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("updValoresPopUpControl")).Update();

                                    #endregion
                                    #region CARGAR VALORES DEFAULT

                                    TextBox txtFechaConstitucionValores = ((TextBox)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("txtFechaConstitucionGarantia"));
                                    txtFechaConstitucionValores.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC")).Text;

                                    TextBox txtFechaVencimientoValores = ((TextBox)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("txtFechaVencimientoGarantia"));
                                    txtFechaVencimientoValores.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;

                                    resultadoFecha = wsGarantias.GarantiasOperacionesFechaPrescripcionGarantia(generadorControles.ValidarFechaPrescripcionGarantia("VALORES", 0, 0)).ToList();
                                    valorFecha = int.Parse(resultadoFecha[0].Texto);
                                    TextBox txtFechaPrescripcionValores = ((TextBox)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("txtFechaPrescripcionGarantia"));
                                    txtFechaPrescripcionValores.Text = DateTime.Parse(txtFechaVencimientoValores.Text).AddMonths(valorFecha).ToShortDateString();

                                    this.GarantiaValores.LimpiarBarraMensaje();

                                    #endregion

                                    ((UpdatePanel)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("updValoresPopUpControl")).Update();
                                    break;
                                #endregion
                                //Req F2S03 2016-21-06
                                #region GARANTIAS AVALES
                                case 11:
                                    bool replicadoAvales = ((wucOperacionesGridGarantias)this.GridGarantias).ValidarEstadoGarantiaAvales(entidad.IdGarantiaOperacion);
                                    if (!replicadoAvales)
                                    {
                                        resultadoAvales.IdGarantiaAval = int.Parse(resultadoOperacion.IdGarantiaAval.ToString());
                                        resultadoAvales = wsGarantias.GarantiasAvalesConsultarDetalle(resultadoAvales, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
                                        mpeAvales.Show();

                                        #region CARGAR CONTROL

                                        ((HtmlInputHidden)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                                        ((HtmlInputHidden)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                                        ((Button)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("btnConsultarGarantia")).Enabled = false;
                                        ((Button)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacionDisabled";
                                        ((HtmlTable)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("tableAdicionales")).Disabled = false;

                                        //CARGA LOS CONTROLES
                                        List<ControlEntidad> controlesAvales = ObtenerControlesBD(pantallaModuloOculto.Value, "Avales");
                                        ((wucOperacionRelacionAvales)this.GarantiaAvales).CargarContenidoControlAvales(controlesAvales);
                                        ((UpdatePanel)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("updAvalesPopUpControl")).Update();
                                        ((wucOperacionRelacionAvales)this.GarantiaAvales).HabilitarContenidoExcepcionesAdicionales(false);

                                        //SELECCIONA MONEDA ASIGNAR VALOR DEFAULT AL DROPDOWNLIST
                                        DropDownList ddlTipoMonedaGravamenAvales = ((DropDownList)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("ddlIdTipoMonedaGradoGravamen"));
                                        valorMoneda = int.Parse(((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda")).Text).ToString();
                                        generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoMonedaGravamenAvales, valorMoneda);

                                        tableGeneral = ((HtmlTable)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("tableGeneral"));
                                        generadorControles.Bloquear_Controles(tableGeneral, false);

                                        #endregion
                                        #region CARGAR VALORES

                                        ((wucOperacionRelacionAvales)this.GarantiaAvales).DeEntidadAControles(resultadoOperacion, resultadoAvales);
                                        estado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerEstadoGarantiaSeleccionado();
                                        ((HtmlInputHidden)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("estadoGarantiaOculto")).Value = estado;
                                        ((UpdatePanel)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("updAvalesPopUpControl")).Update();

                                        #endregion
                                        #region CARGAR VALORES DEFAULT

                                        this.GarantiaAvales.LimpiarBarraMensaje();

                                        TextBox txtFechaConstitucionAvales = ((TextBox)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("txtFechaConstitucionGarantia"));
                                        txtFechaConstitucionAvales.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC")).Text;

                                        TextBox txtFechaVencimientoAvales = ((TextBox)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("txtFechaVencimientoGarantia"));
                                        txtFechaVencimientoAvales.Text = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;

                                        filtroFecha = generadorControles.ValidarFechaPrescripcionGarantia("AVAL", 0, 0);
                                        resultadoFecha = wsGarantias.GarantiasOperacionesFechaPrescripcionGarantia(filtroFecha).ToList();
                                        valorFecha = int.Parse(resultadoFecha[0].Texto);

                                        TextBox txtFechaPrescripcionAvales = ((TextBox)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("txtFechaPrescripcionGarantia"));
                                        txtFechaPrescripcionAvales.Text = DateTime.Parse(txtFechaVencimientoAvales.Text).AddMonths(valorFecha).ToShortDateString();

                                        #endregion

                                        ((UpdatePanel)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("updAvalesPopUpControl")).Update();
                                    }
                                    else
                                    {
                                        //MENSAJE DE ADVERTENCIA DE GARANTIAS RELACIONADAS
                                        this.InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_14");
                                        this.mpeInformarBox.Show();
                                    }
                                    break;
                                #endregion
                                #region GARANTIAS FIDEICOMISO
                                case 8:
                                    resultadoFideicomisos.IdGarantiaFideicomiso = resultadoOperacion.IdFideicomiso;
                                    resultadoFideicomisos = wsGarantias.GarantiasFideicomisosConsultarDetalle(resultadoFideicomisos, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
                                    mpeRelacionGarantiaFideicomiso.Show();

                                    #region CARGAR CONTROL

                                    ((HtmlInputHidden)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                                    ((HtmlInputHidden)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                                    ((Button)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("btnConsultarFideicomiso")).Enabled = false;
                                    ((Button)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("btnConsultarFideicomiso")).CssClass = "botonConsultarRelacionDisabled";
                                    ((HtmlTable)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("tableAdicionales")).Disabled = false;

                                    #region CARGA LOS CONTROLES

                                    List<ControlEntidad> controlesFideicomiso = ObtenerControlesBD(pantallaModuloOculto.Value, "Fideico");
                                    ((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).CargarContenidoControlRelacionGarantiaFideicomiso(controlesFideicomiso);
                                    ((UpdatePanel)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("updRelacionGarantiaFideicomisoPopUpControl")).Update();

                                    #endregion

                                    #endregion

                                    #region CARGAR VALORES DEFAULT

                                    string fechaVencimientoFideicomiso = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;

                                    filtroFecha = generadorControles.ValidarFechaPrescripcionGarantia("FIDEICOMISO DE GARANTÍA", 0, 0);
                                    resultadoFecha = wsGarantias.GarantiasOperacionesFechaPrescripcionGarantia(filtroFecha).ToList();
                                    valorFecha = int.Parse(resultadoFecha[0].Texto);

                                    TextBox txtFechaPrescripcionFideicomiso = ((TextBox)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("txtFechaPrescripcionGarantia"));
                                    txtFechaPrescripcionFideicomiso.Text = DateTime.Parse(fechaVencimientoFideicomiso).AddMonths(valorFecha).ToShortDateString();

                                    this.RelacionGarantiaFideicomiso.LimpiarBarraMensaje();

                                    #endregion

                                    #region CARGAR VALORES

                                    ((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).DeEntidadAControles(resultadoOperacion, resultadoFideicomisos);
                                    estado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerEstadoGarantiaSeleccionado();
                                    ((HtmlInputHidden)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("estadoGarantiaOculto")).Value = estado;
                                    ((UpdatePanel)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("updRelacionGarantiaFideicomisoPopUpControl")).Update();

                                    #endregion

                                    ((UpdatePanel)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("updRelacionGarantiaFideicomisoPopUpControl")).Update();
                                    break;
                                #endregion
                            }
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
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }

    }

    protected void btnEliminarGarantia_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (Page.IsPostBack)
                {
                    gridOperaciones = (GridView)GridGarantias.FindControl("MasterGridView");

                    //SI EXISTE AL MENOS UN REGISTRO SELECCIONADO
                    if (!((wucOperacionesGridGarantias)this.GridGarantias).ContadorSeleccionados().Equals(0))
                    {
                        //Ajuste javendano 2015-01-09
                        //SI LA CANTIDAD DE REGISTROS SELECCIONADOS ES DIFERENTE A LA TOTALIDAD DE REGISTROS DEL GRID
                        if (!((wucOperacionesGridGarantias)this.GridGarantias).ContadorSeleccionados().Equals(gridOperaciones.Rows.Count))
                        {
                            foreach (GridViewRow row in gridOperaciones.Rows)
                            {
                                CheckBox checkBoxColumn = (CheckBox)gridOperaciones.Rows[row.RowIndex].FindControl("chkBox1");
                                if (checkBoxColumn.Checked)
                                {
                                    this.mpeEliminarBox.Show();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            //SI TODOS LOS REGISTROS ESTÁN SELECCIONADOS
                            this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_16");
                            this.mpeInformarBox.Show();
                        }

                    }
                    else
                    {
                        //SI NO EXISTE REGISTRO SELECCIONADO
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_4");
                        this.mpeInformarBox.Show();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }

    }

    protected void btnBorrarSICC_Click(object sender, EventArgs e)
    {
        int varTipoBien = 0;
        int varClaseTipoBien = 0;
        int CantidadCorrectas = 0;
        string fechaPrescripcion = string.Empty;
        List<GarantiasWS.ListaEntidad> resultadoFecha = null;
        List<GarantiasOperacionesEntidad> valorPendiente = null;
        List<RespuestaSICCEntidad> respuesta = new List<RespuestaSICCEntidad>();
        List<GarantiasOperacionesEntidad> entidad = new List<GarantiasOperacionesEntidad>();

        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (Page.IsPostBack)
                {
                    #region OBTENER VALORES GRID

                    valorPendiente = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerValoresSeleccionadosSICC();

                    #endregion
                    #region CREAR ENTIDAD CONSULTA SICC

                    if (valorPendiente.Count().Equals(0))
                    {
                        //MENSAJE DE ADVERTENCIA DE GARANTIAS RELACIONADAS
                        this.InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_19");
                        this.mpeInformarBox.Show();
                    }
                    else
                    {
                        foreach (GarantiasOperacionesEntidad valor in valorPendiente)
                        {
                            string tipoGarantia = valor.DesTipoOperacion.Replace("Garantía ", "").ToUpper();

                            if (!valor.DesTipoBien.Equals(""))
                                varTipoBien = int.Parse(valor.DesTipoBien);
                            if (!valor.DesClaseTipoBien.Equals(""))
                                varClaseTipoBien = int.Parse(valor.DesClaseTipoBien);

                            fechaPrescripcion = generadorControles.ValidarFechaPrescripcionGarantia(tipoGarantia, varTipoBien, varClaseTipoBien);
                            resultadoFecha = wsGarantias.GarantiasOperacionesFechaPrescripcionGarantia(fechaPrescripcion).ToList();

                            string txtFechaVencimientoGarantia = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;
                            fechaPrescripcion = DateTime.Parse(txtFechaVencimientoGarantia).AddMonths(int.Parse(resultadoFecha[0].Texto)).ToShortDateString().Replace("/", "");

                            respuesta.Add(wsGarantias.GarantiasOperacionesEliminarReplicaSICC(valor.IdGarantiaOperacion.ToString(), fechaPrescripcion, codUsuarioOculto.Value));
                        }

                        foreach (RespuestaSICCEntidad error in respuesta)
                        {
                            if (error.ValorEstado.Equals("0"))
                            {
                                CantidadCorrectas++;
                            }
                            else
                            {
                                RegistrarEventLog registrarEventLog = new RegistrarEventLog();
                                registrarEventLog.RegistrarMensajeLog(error.ValorEstadoCadena, "ERROR", "Fuente SICC");
                            }
                        }

                        if (respuesta.Count() > CantidadCorrectas)
                        {
                            //MENSAJE DE ADVERTENCIA DE GARANTIAS RELACIONADAS
                            this.InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_20");
                            this.mpeInformarBox.Show();
                        }
                        else
                        {
                            //MENSAJE DE ADVERTENCIA DE GARANTIAS RELACIONADAS
                            this.InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_1");
                            this.mpeInformarBox.Show();
                        }
                    }
                    #endregion
                    #region CONSULTAR RELACIONES

                    if (idOperacionOculto.Value.Length > 0)
                        ClearGridView(int.Parse(idOperacionOculto.Value));

                    #endregion

                    BloquearBotonesReplica();
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnActualizarGrid_Click(object sender, EventArgs e)
    {
        try
        {
            ClearGridView(int.Parse(idOperacionOculto.Value));
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnReplicar_Click(object sender, EventArgs e)
    {
        int varTipoBien = 0;
        int varClaseTipoBien = 0;
        int cantidadCorrectas = 0;
        string fechaPrescripcion = string.Empty;
        DateTime fechaPrescripcionActualizada;
        List<GarantiasWS.ListaEntidad> resultadoFecha = null;
        List<GarantiasOperacionesEntidad> valorPendiente = null;
        List<RespuestaSICCEntidad> respuesta = new List<RespuestaSICCEntidad>();
        List<GarantiasOperacionesEntidad> entidad = new List<GarantiasOperacionesEntidad>();

        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (Page.IsPostBack)
                {
                    #region OBTENER VALORES GRID

                    valorPendiente = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerValoresTramasSICC();

                    #endregion
                    #region CREAR ENTIDAD CONSULTA SICC

                    foreach (GarantiasOperacionesEntidad valor in valorPendiente)
                    {
                        string tipoGarantia = valor.DesTipoOperacion.Replace("Garantía ", "").ToUpper();

                        if (!valor.DesTipoBien.Equals(""))
                            varTipoBien = int.Parse(valor.DesTipoBien);
                        if (!valor.DesClaseTipoBien.Equals(""))
                            varClaseTipoBien = int.Parse(valor.DesClaseTipoBien);

                        fechaPrescripcion = generadorControles.ValidarFechaPrescripcionGarantia(tipoGarantia, varTipoBien, varClaseTipoBien);
                        resultadoFecha = wsGarantias.GarantiasOperacionesFechaPrescripcionGarantia(fechaPrescripcion).ToList();

                        string txtFechaVencimientoGarantia = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text;
                        fechaPrescripcionActualizada = DateTime.Parse(txtFechaVencimientoGarantia).AddMonths(int.Parse(resultadoFecha[0].Texto));
                        fechaPrescripcion = fechaPrescripcionActualizada.ToShortDateString().Replace("/", "");

                        respuesta.Add(wsGarantias.GarantiasOperacionesInsertarReplicaSICC(valor.IdGarantiaOperacion.ToString(), fechaPrescripcion, fechaPrescripcionActualizada, valor.EstadoOperacionSICC, codUsuarioOculto.Value));
                    }

                    #region RESPUESTA REPLICA
                    foreach (RespuestaSICCEntidad error in respuesta)
                    {
                        if (error.ValorEstado.Equals("0"))
                        {
                            cantidadCorrectas++;
                        }
                        else
                        {
                            RegistrarEventLog registrarEventLog = new RegistrarEventLog();
                            registrarEventLog.RegistrarMensajeLog(error.ValorEstadoCadena, "ERROR", "Fuente SICC");
                        }
                    }

                    if (respuesta.Count() > cantidadCorrectas)
                    {
                        //MENSAJE DE ERROR EN LA OPERACIÓN.
                        this.InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_21");
                        this.mpeInformarBox.Show();
                    }
                    else
                    {
                        //MENSAJE DE TRANSACCION SATISFACTORIA
                        this.InformarBox1_SetConfirmationBoxEvent(null, e, "SYS_1");
                        this.mpeInformarBox.Show();
                    }
                    #endregion

                    #endregion
                    #region CONSULTAR RELACIONES

                    ClearGridView(int.Parse(idOperacionOculto.Value));

                    #endregion
                    BloquearBotonesReplica();
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void ddlTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoOperacion != null)
        {
            switch (ddlTipoOperacion.SelectedItem.Value)
            {
                case "1": HabilitarTextBoxProducto(true);
                    break;
                case "2": HabilitarTextBoxProducto(false);
                    ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtProducto")).Text = string.Empty;
                    break;
            }
        }
    }

    #region BCR CLIENTES RUC

    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        try
        {
            this.mpeBusqueda.Hide();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (SeleccionarBCRClientes())
                {
                    if (ValidarCamposRequeridosCliente())
                    {
                        this.btnValidarOperacion.Enabled = true;
                        ((wucOperacionClientes)this.ClientesSICC).HabilitarDesembolso(ObtenerControlesBD(pantallaModuloOculto.Value, "Tab2"));
                    }
                    else
                    {
                        BarraMensaje(null, "FuenteSICC");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #region VENTANAS DE MENSAJES INFORMAR

    protected void btnAceptarInformar_Click(object sender, EventArgs e)
    {
        try
        {
            this.mpeInformarBox.Hide();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnAceptarInformarClientes_Click(object sender, EventArgs e)
    {
        try
        {
            this.mpeInformarBoxBusqueda.Hide();
            this.mpeBusqueda.Show();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #region VENTANAS DE MENSAJES ELIMINAR

    protected void btnAceptarEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            GarantiasOperacionesEntidad entidad = new GarantiasOperacionesEntidad();

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                GarantiasWS.RespuestaEntidad resultado = null;

                gridOperaciones = (GridView)GridGarantias.FindControl("MasterGridView");
                foreach (GridViewRow row in gridOperaciones.Rows)
                {
                    CheckBox checkBoxColumn = (CheckBox)gridOperaciones.Rows[row.RowIndex].FindControl("chkBox1");
                    if (checkBoxColumn.Checked)
                    {
                        List<string> valorSeleccionado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerValoresSeleccionados("lblIdGarantiaOperacion");
                        foreach (string valor in valorSeleccionado)
                        {
                            entidad.IdGarantiaOperacion = int.Parse(valor);
                            entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                            Boolean valoresPendiente = ((wucOperacionesGridGarantias)this.GridGarantias).ValidarEstadoGarantiaEliminar(int.Parse(valor));
                            if (!valoresPendiente)
                            {
                                resultado = wsGarantias.GarantiasOperacionesEliminarRelacion(entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));
                            }
                            else
                            {
                                resultado = new GarantiasWS.RespuestaEntidad();
                                resultado.ValorError = 15;
                                resultado.ValorEstado = 0;
                            }
                        }
                    }
                }
                #region CONFIRMACIÓN ELIMINAR

                this.mpeInformarBox.Show();
                int valorE = resultado.ValorEstado;
                int valorError = resultado.ValorError;

                if (valorE != 0)
                {
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.DeleteOK.ToString());
                }
                else
                {
                    switch (valorError)
                    {
                        case 544:
                            this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.PrimaryKey.ToString());
                            break;
                        case 547:
                            this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.ForeignKey.ToString());
                            break;
                        case 15:
                            this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_15");
                            break;
                    }
                }

                #endregion
            }
        }
        catch
        {
            this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.DeleteErr.ToString());
            this.mpeInformarBox.Show();
        }
        finally
        {
            ClearGridView(int.Parse(idOperacionOculto.Value));
            ObtenerControlRegistros(((GarantiasOperacionesEntidad)ConsultarDetalleEntidad()));
        }
    }

    protected void btnCancelarEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            this.mpeEliminarBox.Hide();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #region BOTONES ACEPTAR VENTANAS

    protected void btnAceptarValores_Click(object sender, EventArgs e)
    {
        try
        {
            GarantiasWS.RespuestaEntidad resultado = null;

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                tipoAccion = 0;
                List<string> valorSeleccionado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerValoresSeleccionados("lblIdGarantiaOperacion");

                if (!valorSeleccionado.Count.Equals(0))
                {
                    tipoAccion = 1;

                    #region CREAR LOS PARAMETROS AL POPUP

                    StringBuilder sesionBuilder = new StringBuilder();
                    sesionBuilder.Append(idSesionOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(pantallaModuloOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(codUsuarioOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(int.Parse(valorSeleccionado[0]));
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(ddlTipoGarantia.SelectedItem.Value);

                    #endregion
                    ((HtmlInputHidden)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                }

                //VALIDAR RANGO PORCENTAJE ACEPTACION DE 0 A 100
                rangoAcept = ((wucOperacionRelacionValores)this.GarantiaValores).ValidarPorcentajeAceptacion();

                //VALIDAR RANGO PORCENTAJE RESPONSABILIDAD LEGAL MAYOR O IGUAL A 0
                //    rangoResponLegal = ((wucOperacionRelacionValores)this.GarantiaValores).ValidarPorcentajeResponsabilidadLegal();

                if (!rangoAcept /*|| !rangoResponLegal*/)
                {
                    resultado = ((wucOperacionRelacionValores)this.GarantiaValores).DeControlesAEntidad(tipoAccion);
                    //IDENTIDAD { 0=NUEVO; X=EDITAR }
                    if (!resultado.ValorError.Equals(0))
                    {
                        this.mpeValores.Show();
                        ((wucOperacionRelacionValores)this.GarantiaValores).DesplegarMensajeError(resultado);
                    }
                    else
                    {
                        #region CONSULTAR RELACIONES

                        ClearGridView(int.Parse(idOperacionOculto.Value));

                        #endregion
                        BloquearBotonesReplica();
                        ObtenerControlRegistros(((GarantiasOperacionesEntidad)ConsultarDetalleEntidad()));
                    }
                }
                else
                {
                    this.mpeValores.Show();
                }
            }

            ((UpdatePanel)((wucOperacionRelacionValores)this.GarantiaValores).FindControl("updValoresPopUpControl")).Update();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnAceptarFiduciaria_Click(object sender, EventArgs e)
    {
        try
        {
            GarantiasWS.RespuestaEntidad resultado = null;
            // bool rango = false;

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                tipoAccion = 0;
                List<string> valorSeleccionado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerValoresSeleccionados("lblIdGarantiaOperacion");

                if (!valorSeleccionado.Count.Equals(0))
                {
                    tipoAccion = 1;

                    #region CREAR LOS PARAMETROS AL POPUP

                    StringBuilder sesionBuilder = new StringBuilder();
                    sesionBuilder.Append(idSesionOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(pantallaModuloOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(codUsuarioOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(int.Parse(valorSeleccionado[0]));
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(ddlTipoGarantia.SelectedItem.Value);

                    #endregion
                    ((HtmlInputHidden)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                }

                //VALIDAR RANGO PORCENTAJE ACEPTACION DE 0 A 100
                rangoAcept = ((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).ValidarPorcentajeAceptacion();

                //VALIDAR RANGO PORCENTAJE RESPONSABILIDAD LEGAL MAYOR O IGUAL A 0
                // rangoResponLegal = ((wucOperacionRelacionReales)this.GarantiaReales).ValidarPorcentajeResponsabilidadLegal();

                if (!rangoAcept /*|| !rangoResponLegal*/)
                {
                    resultado = ((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).DeControlesAEntidad(tipoAccion);
                    //IDENTIDAD { 0=NUEVO; X=EDITAR }
                    if (!resultado.ValorError.Equals(0))
                    {
                        this.mpeFiduciaria.Show();
                        ((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).DesplegarMensajeError(resultado);
                    }
                    else
                        if (resultado.ValorError.Equals(0))
                        {
                            #region CONSULTAR RELACIONES

                            ClearGridView(int.Parse(idOperacionOculto.Value));

                            #endregion
                            BloquearBotonesReplica();
                            ObtenerControlRegistros(((GarantiasOperacionesEntidad)ConsultarDetalleEntidad()));
                        }
                }
                else
                {
                    this.mpeFiduciaria.Show();
                }
            }

            ((UpdatePanel)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("updFiduciariaPopUpControl")).Update();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnAceptarReales_Click(object sender, EventArgs e)
    {
        try
        {

            GarantiasWS.RespuestaEntidad resultado = null;

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                tipoAccion = 0;
                List<string> valorSeleccionado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerValoresSeleccionados("lblIdGarantiaOperacion");

                if (!valorSeleccionado.Count.Equals(0))
                {
                    tipoAccion = 1;

                    #region CREAR LOS PARAMETROS AL POPUP

                    StringBuilder sesionBuilder = new StringBuilder();
                    sesionBuilder.Append(idSesionOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(pantallaModuloOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(codUsuarioOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(int.Parse(valorSeleccionado[0]));
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(ddlTipoGarantia.SelectedItem.Value);

                    #endregion
                    ((HtmlInputHidden)((wucOperacionRelacionReales)this.GarantiaReales).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                }

                //VALIDAR RANGO PORCENTAJE ACEPTACION DE 0 A 100
                rangoAcept = ((wucOperacionRelacionReales)this.GarantiaReales).ValidarPorcentajeAceptacion();

                //VALIDAR RANGO PORCENTAJE RESPONSABILIDAD LEGAL DE 0 A 100
                rangoResponLegal = ((wucOperacionRelacionReales)this.GarantiaReales).ValidarPorcentajeResponsabilidadLegal();

                if (!rangoAcept && !rangoResponLegal)
                {

                    resultado = ((wucOperacionRelacionReales)this.GarantiaReales).DeControlesAEntidad(tipoAccion);
                    //IDENTIDAD { 0=NUEVO; X=EDITAR }
                    if (!resultado.ValorError.Equals(0))
                    {
                        this.mpeReales.Show();
                        // MENSAJE DE ERROR
                        ((wucOperacionRelacionReales)this.GarantiaReales).DesplegarMensajeError(resultado);
                    }
                    else
                    {
                        #region CONSULTAR RELACIONES

                        ClearGridView(int.Parse(idOperacionOculto.Value));

                        #endregion
                        BloquearBotonesReplica();
                        ObtenerControlRegistros(((GarantiasOperacionesEntidad)ConsultarDetalleEntidad()));
                    }
                }
                else
                {
                    this.mpeReales.Show();
                }
            }

            ((UpdatePanel)((wucOperacionRelacionFiduciaria)this.GarantiaFiduciaria).FindControl("updFiduciariaPopUpControl")).Update();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnAceptarAvales_Click(object sender, EventArgs e)
    {
        try
        {
            GarantiasWS.RespuestaEntidad resultado = null;
            // bool rango = false;

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                tipoAccion = 0;
                List<string> valorSeleccionado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerValoresSeleccionados("lblIdGarantiaOperacion");

                if (!valorSeleccionado.Count.Equals(0))
                {
                    tipoAccion = 1;

                    #region CREAR LOS PARAMETROS AL POPUP

                    StringBuilder sesionBuilder = new StringBuilder();
                    sesionBuilder.Append(idSesionOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(pantallaModuloOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(codUsuarioOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(int.Parse(valorSeleccionado[0]));
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(ddlTipoGarantia.SelectedItem.Value);

                    #endregion
                    ((HtmlInputHidden)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                }

                //VALIDAR RANGO PORCENTAJE ACEPTACION DE 0 A 100
                rangoAcept = ((wucOperacionRelacionAvales)this.GarantiaAvales).ValidarPorcentajeAceptacion();

                //VALIDAR RANGO PORCENTAJE RESPONSABILIDAD LEGAL MAYOR O IGUAL A 0
                // rangoResponLegal = ((wucOperacionRelacionReales)this.GarantiaReales).ValidarPorcentajeResponsabilidadLegal();

                if (!rangoAcept /*|| !rangoResponLegal*/)
                {
                    resultado = ((wucOperacionRelacionAvales)this.GarantiaAvales).DeControlesAEntidad(tipoAccion);
                    //IDENTIDAD { 0=NUEVO; X=EDITAR }
                    if (!resultado.ValorError.Equals(0))
                    {
                        this.mpeAvales.Show();
                        ((wucOperacionRelacionAvales)this.GarantiaAvales).DesplegarMensajeError(resultado);
                    }
                    else
                        if (resultado.ValorError.Equals(0))
                        {
                            #region CONSULTAR RELACIONES

                            ClearGridView(int.Parse(idOperacionOculto.Value));

                            #endregion
                            BloquearBotonesReplica();
                            ObtenerControlRegistros(((GarantiasOperacionesEntidad)ConsultarDetalleEntidad()));
                        }
                }
                else
                {
                    this.mpeAvales.Show();
                }
            }

            ((UpdatePanel)((wucOperacionRelacionAvales)this.GarantiaAvales).FindControl("updAvalesPopUpControl")).Update();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnAceptarRelacionGarantiaFideicomiso_Click(object sender, EventArgs e)
    {
        try
        {
            GarantiasWS.RespuestaEntidad resultado = null;

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                tipoAccion = 0;
                List<string> valorSeleccionado = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerValoresSeleccionados("lblIdGarantiaOperacion");

                if (!valorSeleccionado.Count.Equals(0))
                {
                    tipoAccion = 1;

                    #region CREAR LOS PARAMETROS AL POPUP

                    StringBuilder sesionBuilder = new StringBuilder();
                    sesionBuilder.Append(idSesionOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(pantallaModuloOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(codUsuarioOculto.Value);
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(int.Parse(valorSeleccionado[0]));
                    sesionBuilder.Append("|");
                    sesionBuilder.Append(ddlTipoGarantia.SelectedItem.Value);

                    #endregion

                    ((HtmlInputHidden)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                }

                //VALIDAR MONTO GRADO GRAVAMEN
                bool montoGradoGravamen = ((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).MontoGradoGravemen();

                if (!montoGradoGravamen)
                {
                    resultado = ((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).DeControlesAEntidad(tipoAccion);

                    //IDENTIDAD { 0=NUEVO; X=EDITAR }
                    if (!resultado.ValorError.Equals(0))
                    {
                        this.mpeRelacionGarantiaFideicomiso.Show();

                        // MENSAJE DE ERROR
                        ((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).DesplegarMensajeError(resultado);
                    }

                    else
                    {
                        #region CONSULTAR RELACIONES

                        ClearGridView(int.Parse(idOperacionOculto.Value));

                        #endregion

                        BloquearBotonesReplica();
                        ObtenerControlRegistros(((GarantiasOperacionesEntidad)ConsultarDetalleEntidad()));
                    }
                }

                else
                {
                    mpeRelacionGarantiaFideicomiso.Show();
                }
            }

            ((UpdatePanel)((wucOperacionesRelacionGarantiaFideicomiso)this.RelacionGarantiaFideicomiso).FindControl("updRelacionGarantiaFideicomisoPopUpControl")).Update();
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
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
        try
        {
            if (this.divBarraMensaje.Visible)
                this.divBarraMensaje.Visible = false;

            bool contadorGridRelacion = ((wucOperacionesGridGarantias)this.GridGarantias).ContieneRegistros();
            if (contadorGridRelacion)
            {
                //ACTUALIZA LA SECCION GENERAL
                ModificarEntidad();
            }
            else
            {
                //MENSAJE DE ERROR DE FORMATO
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "Relacion");
                this.mpeInformarBox.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
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
                //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD
                List<ControlEntidad> controles = new List<ControlEntidad>();

                //REALIZA LAS EXCEPCIONES DE LA CARGA DE DATOS A LOS CONTROLES
                ((wucOperacionConsulta)this.ParametrosSICC).HabilitarContenido(true);
                ((wucOperacionClientes)this.ClientesSICC).HabilitarContenido(false);

                //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD
                controles = ObtenerControlesBD(pantallaModuloOculto.Value, "Tab1");
                //CREAR E INSERTA LOS CONTROLES EN LA PAGINA CONSULTA PARAMETROS
                ((wucOperacionConsulta)this.ParametrosSICC).LimpiarControlesOperacionConsulta();
                ((wucOperacionConsulta)this.ParametrosSICC).CargarControlesOperacionConsulta(controles);

                //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD
                controles = ObtenerControlesBD(pantallaModuloOculto.Value, "Tab2");
                //CREAR E INSERTA LOS CONTROLES EN LA PAGINA CONSULTA CLEINTES
                ((wucOperacionClientes)this.ClientesSICC).LimpiarControlesOperacionClientes();
                ((wucOperacionClientes)this.ClientesSICC).CargarControlesOperacionClientes(controles);
                ((wucOperacionClientes)this.ClientesSICC).LimpiarControlesDropDownListClientes(true);

                ((wucOperacionesGridGarantias)this.GridGarantias).LimpiarControlesDropDownListOperacionGrid(true);
                //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD
                controles = ObtenerControlesBD(pantallaModuloOculto.Value, "Tab3");
                //CREAR E INSERTA LOS CONTROLES EN LA PAGINA CONSULTA RELACION
                ((wucOperacionesGridGarantias)this.GridGarantias).CargarControlesOperacionGrid(controles);
                ((wucOperacionesGridGarantias)this.GridGarantias).habilitarBotonesGrid(false);
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
            if (pantallaIdOculto.Value.Equals("0"))
            {
                #region LIMPIAR CONTROLES

                ((wucOperacionConsulta)this.ParametrosSICC).LimpiarControlesOperacionConsulta();

                ((wucOperacionClientes)this.ClientesSICC).LimpiarControlesDropDownListClientes(true);
                ((wucOperacionClientes)this.ClientesSICC).LimpiarControlesOperacionClientes();

                ((wucOperacionesGridGarantias)this.GridGarantias).LimpiarControlesDropDownListOperacionGrid(true);
                ((wucOperacionesGridGarantias)this.GridGarantias).habilitarBotonesGrid(false);

                #endregion
                #region OPCIONES DEFAULT

                this.btnConsultarOperacion.Enabled = true;
                this.btnConsultarOperacion.CssClass = "botonConsultarSICC";
                this.btnValidarOperacion.Enabled = false;
                this.btnValidarOperacion.CssClass = "botonValidarOperacionDisabled";

                HabilitarTextBoxProducto(true);
                BloquearControlesGuardar(true);

                #region CONSULTAR RELACIONES

                ClearGridView(0);

                #endregion

                #endregion
            }
            #region LIMPIAR MENSAJES

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
            {
                this.divBarraMensaje.Visible = false;
            }

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*OBTIENE LOS CONTROLES DESDE BD SEGUN PESTAÑA*/
    private List<ControlEntidad> ObtenerControlesBD(string _codPantalla, string _pestana)
    {
        try
        {
            ListasWS.PantallasEntidad pantalla = new ListasWS.PantallasEntidad();
            pantalla.CodPantalla = int.Parse(_codPantalla);

            //ESTABLECE LOS CONTROLES DE LA PANTALLA A CARGAR
            pantalla.Pestana = _pestana;

            //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD
            List<ControlEntidad> controles = new List<ControlEntidad>();
            controles = this.wsListas.AdministracionesContenidosConsultaControl(pantalla).ToList();

            return controles;
        }
        catch
        {
            throw;
        }

    }
    /*CARGA LOS VALORES DESDE LOS CONTROLES DE LA SECCION GENERAL, VALUACION Y CEDULAS HACIA LA ENTIDAD PARA REALIZAR ACCIONES*/
    private GarantiasWS.GarantiasOperacionesClientesEntidad DeControlesAEntidadSeccionOperacion()
    {
        try
        {
            GarantiasWS.GarantiasOperacionesClientesEntidad entidad = null;
            if (pantallaModuloOculto.Value.Length > 0)
            {
                entidad = new GarantiasWS.GarantiasOperacionesClientesEntidad();

                #region SECCION OPERACION

                #region CONTROLES

                DropDownList ddlTipoOperacion = ((DropDownList)((wucOperacionConsulta)this.ParametrosSICC).FindControl("ddlTipoOperacion"));
                TextBox txtConta = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtConta"));
                TextBox txtOficina = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtOficina"));
                TextBox txtMoneda = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda"));
                TextBox txtProducto = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtProducto"));
                TextBox txtNumero = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtNumero"));

                DropDownList ddlTipoIdentificacionSICC = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlTipoIdentificacionSICC"));
                TextBox txtIdentificacionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtIdentificacionSICC"));
                TextBox txtNombreClienteSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtNombreClienteSICC"));
                TextBox txtOficinaDeudorSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtOficinaDeudorSICC"));
                TextBox txtFechaConstitucionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC"));
                TextBox txtFechaVencimientoSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC"));
                TextBox txtEstadoOperacionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtEstadoOperacion"));

                DropDownList ddlTipoIdentificacionRUC = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlTipoIdentificacionRUC"));
                TextBox txtIdentificacionRUC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtIdentificacionRUC"));

                DropDownList ddlIndDesembolso = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlIndDesembolso"));


                #endregion

                entidad.IdTipoOperacion = (ddlTipoOperacion.SelectedItem.Value.Equals("-1")) ? 0 : int.Parse(ddlTipoOperacion.SelectedItem.Value);
                entidad.Conta = (txtConta.Text.Length < 1) ? string.Empty : txtConta.Text;
                entidad.Oficina = (txtOficina.Text.Length < 1) ? string.Empty : txtOficina.Text;
                entidad.Moneda = (txtMoneda.Text.Length < 1) ? string.Empty : txtMoneda.Text;
                entidad.Producto = (txtProducto.Text.Length < 1) ? string.Empty : txtProducto.Text;
                entidad.Numero = (txtNumero.Text.Length < 1) ? string.Empty : txtNumero.Text;

                entidad.TipoIdentificacionSICC = (ddlTipoIdentificacionSICC.SelectedItem.Value.Equals("-1")) ? string.Empty : ddlTipoIdentificacionSICC.SelectedItem.Value;
                entidad.IdentificacionSICC = (txtIdentificacionSICC.Text.Length < 1) ? string.Empty : txtIdentificacionSICC.Text;
                entidad.NombreClienteSICC = (txtNombreClienteSICC.Text.Length < 1) ? string.Empty : txtNombreClienteSICC.Text;
                entidad.OficinaDeudorSICC = int.Parse(txtOficinaDeudorSICC.Text);
                entidad.EstadoOperacionSICC = (txtEstadoOperacionSICC.Text.Length < 1) ? string.Empty : txtEstadoOperacionSICC.Text;
                entidad.FechaConstitucionSICC = DateTime.Parse(txtFechaConstitucionSICC.Text);
                entidad.FechaVencimientoSICC = DateTime.Parse(txtFechaVencimientoSICC.Text);

                entidad.TipoIdentificacionRUC = (ddlTipoIdentificacionRUC.SelectedItem.Value.Equals("-1")) ? string.Empty : ddlTipoIdentificacionRUC.SelectedItem.Value;
                entidad.IdentificacionClienteRUC = (txtIdentificacionRUC.Text.Length < 1) ? string.Empty : txtIdentificacionRUC.Text;

                entidad.IndDesembolso = int.Parse(ddlIndDesembolso.SelectedValue);

                #endregion

                //BLOQUE 7 REQUERIMIENTO 1-24381561
                CrearControlRegistros(entidad);
            }

            return entidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE BD PARA EL CASO DE LAS MODIFICACIONES*/
    private void DeEntidadAControles()
    {
        try
        {
            GarantiasOperacionesEntidad resultado = ((GarantiasOperacionesEntidad)ConsultarDetalleEntidad());
            if (resultado != null)
            {
                #region CARGAR VALORES DE BASE DATOS

                idOperacionOculto.Value = resultado.IdGarantiaOperacion.ToString();

                #region BUSCAR CONTROLES CONSULTA

                DropDownList ddlTipoOperacion = ((DropDownList)((wucOperacionConsulta)this.ParametrosSICC).FindControl("ddlTipoOperacion"));
                TextBox txtConta = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtConta"));
                TextBox txtOficina = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtOficina"));
                TextBox txtMoneda = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda"));
                TextBox txtProducto = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtProducto"));
                TextBox txtNumero = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtNumero"));
                DropDownList ddlIndDesembolso = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlIndDesembolso"));

                ddlTipoOperacion_SelectedIndexChanged(null, null);

                generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoOperacion, resultado.IdTipoOperacion.ToString());

                #endregion

                #region ASIGNAR VALORES CONSULTA

                txtConta.Text = resultado.Conta;
                txtOficina.Text = resultado.Oficina;
                txtMoneda.Text = resultado.Moneda;
                txtProducto.Text = resultado.Producto;
                txtNumero.Text = resultado.Numero;

                ddlTipoOperacion_SelectedIndexChanged(null, null);

                //INDICADOR DESEMBOLSO
                generadorControles.SeleccionarOpcionDropDownList(ddlIndDesembolso, resultado.IndDesembolso.ToString());

                #endregion

                #region REALIZAR CONSULTA SIC

                consultaEntidad.IdTipoOperacion = resultado.IdTipoOperacion;
                consultaEntidad.Conta = txtConta.Text;
                consultaEntidad.Oficina = txtOficina.Text;
                consultaEntidad.Moneda = txtMoneda.Text;
                consultaEntidad.Producto = (txtProducto.Enabled) ? txtProducto.Text : string.Empty;
                consultaEntidad.Numero = txtNumero.Text;

                operacionesEntidad = wsGarantias.GarantiasOperacionesConsultaDataBridge(consultaEntidad);

                //GUARDA LOS VALORES DE LA CONSULTA
                hdnResultadoSICC.Value = GuardarValoresCliente(operacionesEntidad);
                hdnResultadoRUC.Value = resultado.TipoIdentificacionRUC + "|" + resultado.IdentificacionClienteRUC;

                //REALIZA LA CONSULTA A RUC
                CargarValoresConsulta(hdnResultadoSICC.Value, hdnResultadoRUC.Value);

                #endregion

                #region VALIDAR  OPERACION

                if (pantallaModuloOculto.Value != null)
                {
                    //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD
                    List<ControlEntidad> controles = new List<ControlEntidad>();
                    controles = ObtenerControlesBD(pantallaModuloOculto.Value, "Tab3");

                    ((wucOperacionesGridGarantias)this.GridGarantias).CargarControlesOperacionGrid(controles);
                }
                ((wucOperacionesGridGarantias)this.GridGarantias).habilitarBotonesGrid(true);
                ((Button)((wucOperacionConsulta)this.ParametrosSICC).FindControl("btnConsultarOperacion")).Enabled = false;
                ((Button)((wucOperacionConsulta)this.ParametrosSICC).FindControl("btnConsultarOperacion")).CssClass = "botonConsultarSICCDisabled";

                #endregion

                #region CONSULTAR RELACIONES

                ClearGridView(int.Parse(idOperacionOculto.Value));

                #endregion

                #endregion

                //REALIZA LAS EXCEPCIONES DE LA CARGA DE DATOS A LOS CONTROLES
                ((wucOperacionConsulta)this.ParametrosSICC).HabilitarContenido(false);
                ((wucOperacionClientes)this.ClientesSICC).HabilitarContenido(false);
                ((wucOperacionesGridGarantias)this.GridGarantias).habilitarBotonesGrid(true);

                //Requerimiento Bloque 7 1-24381561
                ObtenerControlRegistros(resultado);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region ENTIDADES

    private bool ValidarSeccionOperacion()
    {
        try
        {
            GarantiasWS.GarantiasOperacionesClientesEntidad entidad = new GarantiasWS.GarantiasOperacionesClientesEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();
            bool existeError = false;

            //ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidadSeccionOperacion();

            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                respuesta = wsGarantias.GarantiasOperacionesValidar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                //SI NO EXISTE ERROR EN LA VALIDACION
                if (respuesta.ValorError.Equals(0))
                {
                    //ASIGNACION DEL ID DE LA VALIDACION
                    this.idOperacionOculto.Value = respuesta.ValorEstado.ToString();
                    existeError = false;
                }
                else
                {
                    //ERROR POR DUPLICADO DEBIDO A QUE LA GARANTIA EXISTE DE FORMA COMPLETA
                    if (respuesta.ValorError.Equals(2601))
                    {
                        existeError = true;
                        //ERROR POR DUPLICADO DEBIDO A QUE LA GARANTIA EXISTE DE FORMA COMPLETA
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SQL_2601");
                        this.mpeInformarBox.Show();
                    }
                }
            }

            return existeError;
        }
        catch
        {
            throw;
        }
    }

    /*OBTIENE LOS DETALLES DEL ID DEL REGISTRO*/
    private object ConsultarDetalleEntidad()
    {
        try
        {
            GarantiasOperacionesEntidad entidad = new GarantiasOperacionesEntidad();

            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null && pantallaIdOculto.Value != "0")
            {
                #region OBTIENE EL TIPO DE LA ENTIDAD A CREAR DINAMICAMENTE

                //OBTIENE EL TIPO DE DATO DE LA ENTIDAD
                Type tipoEntidad = entidad.GetType();

                #endregion

                //OBTIENE LAS PROPIEDADES DE LA ENTIDAD
                PropertyInfo[] propiedades = tipoEntidad.GetProperties();

                string entidadPropiedad = string.Empty;
                string entidadPropiedadTipo = string.Empty;

                //ASIGNA EL VALOR DEL ID DEL REGISTRO A CONSULTAR
                foreach (PropertyInfo propiedad in propiedades)
                {
                    if (propiedad.Name.Equals("IdGarantiaOperacion"))
                    {
                        entidadPropiedad = propiedad.Name;
                        entidadPropiedadTipo = propiedad.PropertyType.Name;
                        //ASIGNA EL VALOR A LA PROPIEDAD EL ID CORRESPONDE A LA PRIMERA PROPIEDAD DE CADA ENTIDAD
                        propiedad.SetValue(entidad, generadorControles.ConvertirTipoDato(entidadPropiedadTipo.ToUpper(), pantallaIdOculto.Value), null);
                        break;
                    }
                }

                //OBTIENE EL RESTO DE CAMPOS DEL REGISTRO A CONSULTAR DESDE LA BD            
                string exec = "GarantiasOperacionesConsultarDetalle";
                Type ws = wsGarantias.GetType();
                MethodInfo metodo = ws.GetMethod(exec);
                //var resultado = metodo.Invoke(wsGarantias, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
                var resultado = wsGarantias.GarantiasOperacionesConsultarDetalle(entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
                return resultado;
            }

            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ModificarEntidad()
    {
        try
        {
            GarantiasOperacionesEntidad entidad = null;
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            entidad = DeControlesAEntidadGeneral();
            if (entidad != null)
            {
                respuesta = wsGarantias.GarantiasOperacionesModificar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));
                BarraMensaje(respuesta, pantallaIdOculto.Value);

                //BLOQUE 7 REQUERIMIENTO 1-24381561
                if (respuesta.ValorError.Equals(0))
                {
                    this.pantallaIdOculto.Value = (respuesta.ValorEstado.ToString());
                    idOperacionOculto.Value = (respuesta.ValorEstado.ToString());
                    BloquearControlesGuardar(true);

                    this.btnReplicar.CausesValidation = false;
                    //this.btnReplicar.Visible = true;
                    // this.btnReplicar.Enabled = true;

                    ClearGridView(int.Parse(idOperacionOculto.Value));
                    BloquearControlesReplicar(false);

                    btnLimpiar.Enabled = false;

                    //REALIZA LAS EXCEPCIONES DE LA CARGA DE DATOS A LOS CONTROLES
                    ((wucOperacionConsulta)this.ParametrosSICC).HabilitarContenido(false);
                    ((wucOperacionClientes)this.ClientesSICC).HabilitarContenido(false);
                    ((wucOperacionesGridGarantias)this.GridGarantias).habilitarBotonesGrid(false);
                }

                //REQUERIMIENTO BLOQUE 7 1-24381561 
                MostrarControlRegistrosGuardar(entidad);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE LOS CONTROLES DE LA SECCION GENERAL, VALUACION Y CEDULAS HACIA LA ENTIDAD PARA REALIZAR ACCIONES*/
    private GarantiasOperacionesEntidad DeControlesAEntidadGeneral()
    {
        try
        {
            GarantiasOperacionesEntidad entidad = null;

            if (pantallaModuloOculto.Value.Length > 0)
            {
                entidad = new GarantiasOperacionesEntidad();

                entidad.IdGarantiaOperacion = int.Parse(idOperacionOculto.Value);
                if (!pantallaIdOculto.Value.Equals("0"))
                    entidad = ((GarantiasOperacionesEntidad)ConsultarDetalleEntidad());

                #region SECCION OPERACION

                entidad.IdTipoOperacion = int.Parse(((DropDownList)((wucOperacionConsulta)this.ParametrosSICC).FindControl("ddlTipoOperacion")).SelectedValue);
                entidad.Conta = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtConta")).Text;
                entidad.Oficina = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtOficina")).Text;
                entidad.Moneda = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda")).Text;
                entidad.Producto = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtProducto")).Text;
                entidad.Numero = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtNumero")).Text;

                #endregion
                #region SECCION DETALLE

                entidad.TipoIdentificacionSICC = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlTipoIdentificacionSICC")).SelectedValue;

                entidad.IdentificacionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtIdentificacionSICC")).Text;
                entidad.NombreClienteSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtNombreClienteSICC")).Text;
                entidad.OficinaDeudorSICC = int.Parse(((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtOficinaDeudorSICC")).Text);
                entidad.FechaConstitucionSICC = DateTime.Parse(((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC")).Text);
                entidad.FechaVencimientoSICC = DateTime.Parse(((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC")).Text);
                entidad.EstadoOperacionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtEstadoOperacion")).Text;

                //ASIGNAR DATOS RUC
                entidad.TipoIdentificacionRUC = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlTipoIdentificacionRUC")).SelectedValue;
                entidad.IdentificacionClienteRUC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtIdentificacionRUC")).Text;

                #endregion

                //Requerimiento Bloque 7 1-24381561
                CrearControlRegistros(entidad);
            }

            return entidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region METODOS GRIDVIEW OPERACIONES

    private void gridOperaciones_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridOperaciones, "IdGarantiaOperacion", lblID);

        gridViewColumn = new GridViewColumn();
        gridOperaciones.Columns.Add(gridViewColumn.CreateBoundField("DesTipoOperacion", string.Empty, "Tipo Garantía", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        gridOperaciones.Columns.Add(gridViewColumn.CreateBoundField("IdGarantia", string.Empty, "Id Garantía", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        gridOperaciones.Columns.Add(gridViewColumn.CreateBoundField("DesEstadoReplicado", string.Empty, "Estado", HorizontalAlign.Center, false, true));

        TemplateField lblID1 = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridOperaciones, "DesTipoBien", lblID1);

        TemplateField lblID2 = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridOperaciones, "DesClaseTipoBien", lblID2);
    }

    /*CONSULTA GRID ADMINISTRACION CEDULAS*/
    private List<GarantiasOperacionesEntidad> ConsultaOperacionesInterno(int filtro)
    {
        try
        {
            List<GarantiasOperacionesEntidad> retorno = null;
            retorno = wsGarantias.GarantiasOperacionesConsultarGarantiasGrid(filtro).ToList();

            return retorno;
        }
        catch
        {
            throw;
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
                switch (tipoAccion)
                {
                    case "SYS_12":
                        mensajes.CodMensaje = "SYS_12";
                        lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";
                        resultadoProceso = -1;
                        break;
                    case "FuenteSICC":
                        mensajes.CodMensaje = "FuenteSICC";
                        lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";
                        resultadoProceso = -1;
                        break;
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
                    BloquearControlesGuardar(true);
                    btnReplicar.Enabled = true;
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

    /*BLOQUEA LOS CONTROLES AL GUARDAR SATISFACTORIAMENTE. CORRECTO: TRUE, INCORRECTO: FALSE.*/
    private void BloquearControlesGuardar(bool _estado)
    {
        ((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesGuardar(_estado);
    }

    /*BLOQUEA LOS CONTROLES AL GUARDAR SATISFACTORIAMENTE. CORRECTO: TRUE, INCORRECTO: FALSE.*/
    private void BloquearControlesReplicar(bool _estado)
    {
        ((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesReplicar(_estado);
    }

    public void RealizarConsultaRUC()
    {
        #region BUSCAR CONTROLES

        DropDownList ddlTipoOperacion = ((DropDownList)((wucOperacionConsulta)this.ParametrosSICC).FindControl("ddlTipoOperacion"));
        TextBox txtConta = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtConta"));
        TextBox txtOficina = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtOficina"));
        TextBox txtMoneda = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtMoneda"));
        TextBox txtProducto = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtProducto"));
        TextBox txtNumero = ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtNumero"));

        #endregion

        #region REALIZAR CONSULTA

        consultaEntidad.IdTipoOperacion = int.Parse(ddlTipoOperacion.SelectedItem.Value);
        consultaEntidad.Conta = txtConta.Text;
        consultaEntidad.Oficina = txtOficina.Text;
        consultaEntidad.Moneda = txtMoneda.Text;
        consultaEntidad.Producto = (txtProducto.Enabled) ? txtProducto.Text : string.Empty;
        consultaEntidad.Numero = txtNumero.Text;

        #endregion

        operacionesEntidad = wsGarantias.GarantiasOperacionesConsultaDataBridge(consultaEntidad);
        if (operacionesEntidad == null)
        {
            BarraMensaje(null, "SYS_12");
        }
        else
        {
            //GUARDA LOS VALORES DE LA CONSULTA
            hdnValorConsulta.Value = GuardarValoresOperacion(consultaEntidad);
            hdnResultadoSICC.Value = GuardarValoresCliente(operacionesEntidad);

            EjecutarBCRClientes(operacionesEntidad);
        }
    }

    public void CargarValoresConsulta(string _hdnResultadoSICC, string _hdnResultadoRUC)
    {
        try
        {
            #region BUSCAR CONTROLES

            DropDownList ddlTipoIdentificacionSICC = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlTipoIdentificacionSICC"));

            TextBox txtIdentificacionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtIdentificacionSICC"));
            TextBox txtNombreClienteSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtNombreClienteSICC"));
            TextBox txtOficinaDeudorSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtOficinaDeudorSICC"));
            TextBox txtFechaConstitucionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC"));
            TextBox txtFechaVencimientoSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC"));
            TextBox txtEstadoOperacionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtEstadoOperacion"));

            //ASIGNAR DATOS RUC
            DropDownList ddlTipoIdentificacionRUC = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlTipoIdentificacionRUC"));
            TextBox txtIdentificacionRUC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtIdentificacionRUC"));
            DropDownList ddlIndDesembolso = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlIndDesembolso"));

            //SALDOS
            TextBox txtSaldo = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtSaldo"));
            TextBox txtSaldoColonizado = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtSaldoColonizado"));
            TextBox txtSaldoOriginal = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtSaldoOriginal"));
            TextBox txtSaldoOriginalColonizado = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtSaldoOriginalColonizado"));

            //CATEGORIA RIESGO DEUDOR
            TextBox txtCategoriaRiesgoDeudor = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtCategoriaRiesgoDeudor"));

            #endregion

            //REALIZA ASIGNACION DE LOS VALORES A LA ENTIDAD
            operacionesEntidad = ObtenerValoresCliente(_hdnResultadoSICC, _hdnResultadoRUC);

            #region ASIGNAR VALORES

            List<ListasWS.ListaEntidad> cboResultado = wsListas.GarantiasOperacionesTipoIdentificacionLista(operacionesEntidad.TipoIdentificacionSICC.ToString()).ToList();
            generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoIdentificacionSICC, cboResultado[0].Valor.ToString());

            txtIdentificacionSICC.Text = operacionesEntidad.IdentificacionSICC.ToString();
            txtNombreClienteSICC.Text = operacionesEntidad.NombreClienteSICC.ToString();
            txtOficinaDeudorSICC.Text = operacionesEntidad.OficinaDeudorSICC.ToString();
            txtEstadoOperacionSICC.Text = operacionesEntidad.EstadoOperacionSICC.ToString();
            txtFechaConstitucionSICC.Text = operacionesEntidad.FechaConstitucionSICC.Value.ToShortDateString();
            txtFechaVencimientoSICC.Text = operacionesEntidad.FechaVencimientoSICC.Value.ToShortDateString();

            List<ListasWS.ListaEntidad> cboResultado1 = wsListas.GarantiasOperacionesTipoIdentificacionLista(operacionesEntidad.TipoIdentificacionRUC.ToString()).ToList();
            generadorControles.SeleccionarOpcionDropDownListCodigo(ddlTipoIdentificacionRUC, cboResultado1[0].Valor.ToString());

            txtIdentificacionRUC.Text = operacionesEntidad.IdentificacionClienteRUC.ToString();

            txtSaldo.Text = string.Format("{0:N}", operacionesEntidad.Saldo);
            txtSaldoColonizado.Text = string.Format("{0:N}", operacionesEntidad.SaldoColonizado);
            txtSaldoOriginal.Text = string.Format("{0:N}", operacionesEntidad.SaldoOriginal);
            txtSaldoOriginalColonizado.Text = string.Format("{0:N}", operacionesEntidad.SaldoOriginalColonizado);

            #endregion

            #region CATEGORIA RIESGO DEUDOR

            GarantiasWS.GarantiasOperacionesClientesEntidad retornoClienteCategoriaRiesgo = new GarantiasWS.GarantiasOperacionesClientesEntidad();

            //BUSQUEDA DE LA CATEGORIA DE CALIFICACION MEDIANTE LOS DATOS RUC
            retornoClienteCategoriaRiesgo = wsGarantias.GarantiasOperacionesConsultaRuc(operacionesEntidad);

            if (retornoClienteCategoriaRiesgo != null)
            {
                //SI EXISTE CATEGORIA DE RIESGO MEDIANTE LOS DATOS RUC
                if (retornoClienteCategoriaRiesgo.CategoriaRiesgoDeudor.Length > 0)
                    txtCategoriaRiesgoDeudor.Text = retornoClienteCategoriaRiesgo.CategoriaRiesgoDeudor;
            }
            else
            {
                //SI NO EXISTE CATEGORIA DE RIESGO MEDIANTE LOS DATOS RUC, SE CONSULTA MEDIANTE LOS DATOS SUGEF (PARA OBTENER LOS DATOS SUGEF SE ENVIA LA INFORMACION RUC)
                BCRClientesWS.GarantiasOperacionesClientesEntidad retornoClienteCategoriaRiesgoSugef = new BCRClientesWS.GarantiasOperacionesClientesEntidad();
                retornoClienteCategoriaRiesgoSugef = wsBCRClientes.ConsultaClienteSugef(operacionesEntidad.TipoIdentificacionRUC, operacionesEntidad.IdentificacionClienteRUC);

                if (retornoClienteCategoriaRiesgoSugef != null)
                {
                    if (!String.IsNullOrEmpty(retornoClienteCategoriaRiesgoSugef.CategoriaRiesgoDeudor))
                        txtCategoriaRiesgoDeudor.Text = retornoClienteCategoriaRiesgoSugef.CategoriaRiesgoDeudor;
                }

                if (txtCategoriaRiesgoDeudor.Text.Length < 1)
                    txtCategoriaRiesgoDeudor.Text = "A1";
            }

            #endregion
        }
        catch
        {
            throw;
        }
    }

    private bool ValidarMascaraConsulta(TextBox _textBox)
    {
        bool estado = true;

        if (generadorControles.EliminarErrorMascara(_textBox.Text).Length.Equals(0))
        {
            estado = false;
        }

        string var = _textBox.ID.Replace("txt", "rfv");
        ((RequiredFieldValidator)((wucOperacionConsulta)this.ParametrosSICC).FindControl(var)).IsValid = estado;

        return estado;
    }

    private void HabilitarTextBoxProducto(bool _estado)
    {
        ((TextBox)((wucOperacionConsulta)this.ParametrosSICC).FindControl("txtProducto")).Enabled = _estado;
        ((MaskedEditExtender)((wucOperacionConsulta)this.ParametrosSICC).FindControl("mskProducto")).Enabled = _estado;
        ((RequiredFieldValidator)((wucOperacionConsulta)this.ParametrosSICC).FindControl("rfvProducto")).Enabled = _estado;
    }

    private string GuardarValoresOperacion(GarantiasWS.GarantiasOperacionesConsultaEntidad _consultaEntidad)
    {
        try
        {
            StringBuilder valorConsulta = new StringBuilder();

            #region GUARDAR VALORES

            valorConsulta.Append(_consultaEntidad.IdTipoOperacion + "|");
            valorConsulta.Append(_consultaEntidad.Conta + "|");
            valorConsulta.Append(_consultaEntidad.Oficina + "|");
            valorConsulta.Append(_consultaEntidad.Moneda + "|");
            valorConsulta.Append(_consultaEntidad.Producto + "|");
            valorConsulta.Append(_consultaEntidad.Numero);

            #endregion

            return valorConsulta.ToString();
        }
        catch
        {
            throw;
        }
    }

    private string GuardarValoresRUC(List<KeyValuePair<int, string>> _valores)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            string[] valoresGrid;

            foreach (var valor in _valores)
            {
                valoresGrid = valor.Value.Split('|');

                sb.Append(valoresGrid[0].Split('-')[0].Trim() + "|");
                sb.Append(valoresGrid[1]);
            }

            return sb.ToString();
        }
        catch
        {
            throw;
        }
    }

    private string GuardarValoresCliente(GarantiasWS.GarantiasOperacionesClientesEntidad _operacionesEntidad)
    {
        try
        {
            StringBuilder valorConsulta = new StringBuilder();

            #region GUARDAR VALORES

            valorConsulta.Append(_operacionesEntidad.OficinaDeudorSICC + "|");
            valorConsulta.Append(_operacionesEntidad.FechaConstitucionSICC + "|");
            valorConsulta.Append(_operacionesEntidad.EstadoOperacionSICC + "|");
            valorConsulta.Append(_operacionesEntidad.FechaVencimientoSICC + "|");
            valorConsulta.Append(_operacionesEntidad.TipoIdentificacionSICC + "|");
            valorConsulta.Append(_operacionesEntidad.IdentificacionSICC + "|");
            valorConsulta.Append(_operacionesEntidad.NombreClienteSICC + "|");

            valorConsulta.Append(_operacionesEntidad.Saldo + "|");
            valorConsulta.Append(_operacionesEntidad.SaldoColonizado + "|");
            valorConsulta.Append(_operacionesEntidad.SaldoOriginal + "|");
            valorConsulta.Append(_operacionesEntidad.SaldoOriginalColonizado);

            #endregion

            return valorConsulta.ToString();
        }
        catch
        {
            throw;
        }
    }

    private GarantiasWS.GarantiasOperacionesClientesEntidad ObtenerValoresOperacion(string _hdnvalorConsulta)
    {
        try
        {
            string[] valores = _hdnvalorConsulta.Split('|');

            operacionesEntidad.IdTipoOperacion = int.Parse(valores[0].ToString());
            operacionesEntidad.Conta = valores[1].ToString();
            operacionesEntidad.Oficina = valores[2].ToString();
            operacionesEntidad.Moneda = valores[3].ToString();
            operacionesEntidad.Producto = valores[4].ToString();
            operacionesEntidad.Numero = valores[5].ToString();

            return operacionesEntidad;
        }
        catch
        {
            throw;
        }
    }

    private GarantiasWS.GarantiasOperacionesClientesEntidad ObtenerValoresCliente(string _hdnResultadoSICC, string _hdnResultadoRUC)
    {
        try
        {
            string[] valoresSICC = _hdnResultadoSICC.Split('|');
            string[] valoresRUC = _hdnResultadoRUC.Split('|');

            operacionesEntidad.OficinaDeudorSICC = int.Parse(valoresSICC[0].ToString());
            operacionesEntidad.FechaConstitucionSICC = DateTime.Parse(valoresSICC[1].ToString());
            operacionesEntidad.EstadoOperacionSICC = valoresSICC[2].ToString();
            operacionesEntidad.FechaVencimientoSICC = DateTime.Parse(valoresSICC[3].ToString());
            operacionesEntidad.TipoIdentificacionSICC = valoresSICC[4].ToString();
            operacionesEntidad.IdentificacionSICC = valoresSICC[5].ToString();
            operacionesEntidad.NombreClienteSICC = valoresSICC[6].ToString();

            operacionesEntidad.TipoIdentificacionRUC = valoresRUC[0].ToString();
            operacionesEntidad.IdentificacionClienteRUC = valoresRUC[1].ToString();

            operacionesEntidad.Saldo = decimal.Parse(valoresSICC[7].ToString());
            operacionesEntidad.SaldoColonizado = decimal.Parse(valoresSICC[8].ToString());
            operacionesEntidad.SaldoOriginal = decimal.Parse(valoresSICC[9].ToString());
            operacionesEntidad.SaldoOriginalColonizado = decimal.Parse(valoresSICC[10].ToString());

            return operacionesEntidad;
        }
        catch
        {
            throw;
        }
    }

    private void ClearGridView(int _idOperacion)
    {
        try
        {
            #region CONSULTAR RELACIONES

            GridGarantias.BindGridView(ConsultaOperacionesInterno(_idOperacion));

            #endregion
        }
        catch
        {
            throw;
        }
    }

    private void BloquearBotonesReplica()
    {
        #region BLOQUEAR BOTON REPLICAR

        gridOperaciones = (GridView)GridGarantias.FindControl("MasterGridView");
        if (((wucOperacionesGridGarantias)this.GridGarantias).ContieneRegistros()) //SI POSEE UN REGISTRO EN EL GRID
        {
            List<string> valoresPendiente = ((wucOperacionesGridGarantias)this.GridGarantias).ObtenerValoresReplicaSICC("lblIdGarantiaOperacion");
            if (!valoresPendiente.Count().Equals(0))
            {
                //SE HABILITA UNA VEZ QUE SE HAYA GUARDADO LA OPERACION
                if (!btnGuardar.Enabled)
                    BloquearControlesReplicar(false);
            }
            else
            {
                BloquearControlesReplicar(true);
            }
        }

        #endregion
    }

    public void DesplegarMensajeError(GarantiasWS.RespuestaEntidad _result)
    {
        if (_result.ValorError.Equals(-1))
        {
            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_35");
        }
        else
        {
            // MENSAJE DE ERROR
            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SQL_" + _result.ValorError);
        }
        this.mpeInformarBox.Show();
    }

    #endregion

    #region BCR CLIENTES

    /*ESTABLECE LOS DATOS DE LA CONSULTA DE BCR CLIENTES EN EL GRID*/
    private void EjecutarBCRClientes(GarantiasWS.GarantiasOperacionesClientesEntidad _operacionesEntidad)
    {
        try
        {
            if (ValidarEntidadRequeridosSICC(_operacionesEntidad))
            {
                //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
                if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
                {
                    this.divBarraMensaje.Visible = false;
                }

                ((wucGridEmergente)this.BCRClientes).BindGridView(this.Consulta(_operacionesEntidad));
                this.mpeBusqueda.Show();
            }
            else
            {
                BarraMensaje(null, "FuenteSICC");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL CLIENTE SELECCIONADO*/
    private bool SeleccionarBCRClientes()
    {
        bool estado = false;
        List<KeyValuePair<int, string>> valorSeleccionado = null;

        try
        {
            //VALIDA QUE SOLO UN ELEMENTO SEA EL SELECCIONADO
            if (((wucGridEmergente)this.BCRClientes).ContadorSeleccionados().Equals(1))
            {
                valorSeleccionado = ((wucGridEmergente)this.BCRClientes).ObtenerTodosValoresSeleccionados("lblIdRUC").ToList();
                hdnResultadoRUC.Value = GuardarValoresRUC(valorSeleccionado);

                this.mpeBusqueda.Hide();

                CargarValoresConsulta(hdnResultadoSICC.Value, hdnResultadoRUC.Value);
                estado = true;
            }
            else
            {
                //VERIFICA SI EL GRID CONTIENE REGISTROS
                if (((wucGridEmergente)this.BCRClientes).ContieneRegistros())
                {
                    this.InformarBoxBusqueda_SetConfirmationBoxEvent(null, null, "SYS_4");
                    this.mpeInformarBoxBusqueda.Show();
                }
                else
                {
                    ((wucOperacionClientes)this.ClientesSICC).LimpiarControlesOperacionClientes();
                    ((wucOperacionClientes)this.ClientesSICC).LimpiarControlesDropDownListClientes(true);
                }
                estado = false;
            }
            return estado;
        }
        catch
        {
            throw;
        }
    }

    /*VALIDA SI LOS CAMPOS SICC ESTAN COMPLETADOS. COMPLETOS: TRUE, INCOMPLETOS: FALSE.*/
    private Boolean ValidarEntidadRequeridosSICC(GarantiasWS.GarantiasOperacionesClientesEntidad _operacionesEntidad)
    {
        if (
            (_operacionesEntidad.TipoIdentificacionSICC != null) && (_operacionesEntidad.IdentificacionSICC != null) &&
            (_operacionesEntidad.NombreClienteSICC != null) && (_operacionesEntidad.OficinaDeudorSICC != 0) &&
            (_operacionesEntidad.FechaConstitucionSICC != null) && (_operacionesEntidad.FechaVencimientoSICC != null)
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*VALIDA SI LOS CAMPOS SICC ESTAN COMPLETADOS. COMPLETOS: TRUE, INCOMPLETOS: FALSE.*/
    private Boolean ValidarCamposRequeridosCliente()
    {
        #region BUSCAR CONTROLES

        DropDownList ddlTipoIdentificacionSICC = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlTipoIdentificacionSICC"));
        TextBox txtIdentificacionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtIdentificacionSICC"));
        TextBox txtNombreClienteSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtNombreClienteSICC"));
        TextBox txtOficinaDeudorSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtOficinaDeudorSICC"));
        TextBox txtFechaConstitucionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaConstitucionSICC"));
        TextBox txtFechaVencimientoSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtFechaVencimientoSICC"));
        TextBox txtEstadoOperacionSICC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtEstadoOperacion"));

        DropDownList ddlTipoIdentificacionRUC = ((DropDownList)((wucOperacionClientes)this.ClientesSICC).FindControl("ddlTipoIdentificacionRUC"));
        TextBox txtIdentificacionRUC = ((TextBox)((wucOperacionClientes)this.ClientesSICC).FindControl("txtIdentificacionRUC"));

        #endregion

        if ((ddlTipoIdentificacionSICC != null) && (ddlTipoIdentificacionRUC != null) &&
            (!txtIdentificacionSICC.Text.Length.Equals(0)) && (!txtNombreClienteSICC.Text.Length.Equals(0)) &&
            (!txtOficinaDeudorSICC.Text.Length.Equals(0)) && (!txtEstadoOperacionSICC.Text.Length.Equals(0)) &&
            (!txtFechaConstitucionSICC.Text.Length.Equals(0)) && (!txtFechaVencimientoSICC.Text.Length.Equals(0)) &&
            (!txtIdentificacionRUC.Text.Length.Equals(0)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*CONSULTA A BCR CLIENTES*/
    private List<RUCClientesEntidad> Consulta(GarantiasWS.GarantiasOperacionesClientesEntidad _operacionesEntidad)
    {
        try
        {
            List<RUCClientesEntidad> retorno = null;

            string[] tipoIdentificacionArreglo = null;
            string idTipoIdentificacion = string.Empty;
            int tipoIdentificacion, tipoBusqueda = 0;

            tipoIdentificacionArreglo = _operacionesEntidad.TipoIdentificacionSICC.Split('-');
            tipoIdentificacion = int.Parse(tipoIdentificacionArreglo[0].Trim());

            if (!tipoIdentificacion.Equals(0))
                retorno = wsBCRClientes.ConsultaClienteRUC(tipoBusqueda, int.Parse(_operacionesEntidad.TipoIdentificacionSICC), _operacionesEntidad.IdentificacionSICC).ToList();

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
        GridViewColumn gridViewColumn;
        TemplateField lblID = new TemplateField();
        TemplateField lblNombre = new TemplateField();
        GridViewTemplate gvTemplate = new GridViewTemplate();

        gvTemplate.CrearCamposGridNoVisibles(gridView, "IdRUC", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridView.Columns.Add(gridViewColumn.CreateBoundField("TipoIdentificacionRUC", string.Empty, "Código Tipo Identificación", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridView.Columns.Add(gridViewColumn.CreateBoundField("IdentificacionClienteRUC", string.Empty, "Identificación Cliente", HorizontalAlign.Center, false, true));

    }

    private void SetDataKeys(GridView _gridView, String[] _dataKeysString)
    {
        _gridView.DataKeyNames = _dataKeysString;
    }

    #endregion

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
            entidadSICC = null;
            consultaEntidad = null;
            operacionesEntidad = null;

            disponible = true;
        }
    }

    #endregion

}