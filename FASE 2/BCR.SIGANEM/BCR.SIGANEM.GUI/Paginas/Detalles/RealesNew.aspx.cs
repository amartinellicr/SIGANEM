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

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class RealesNew : System.Web.UI.Page
{

    #region PROPIEDADES

    #region VARIABLES

    private int tipoAccion = 0;
    private int banderaVentana = 0;
    private int resultadoProceso = 0;

    private string filtro = string.Empty;
    private string valorReemplazo = string.Empty;
    static string ddlValorSeleccionado = string.Empty;

    private List<ControlEntidad> controlEntidad = null;
    private ControlEntidad controlSeleccionado = null;

    #endregion

    #region CONTROLES

    private Button btnAyudaGuardar = null;
    private Button btnAyudaCerrar = null;

    private Button btnGuardar = null;
    private Button btnLimpiarR = null;

    private Button btnGuardarNuevo = null;
    private Button btnGuardarCerrar = null;
    private Button btnCancelar = null;

    #region VENTANA CONSULTA CLASE VEHICULO

    private GridView gridViewClaseVehiculo = null;
    private Button btnCerrarClaseVehiculo = null;
    private Button btnAceptarClaseVehiculo = null;

    #endregion

    #region VENTANA CONSULTA EMPRESA TASADORA

    private GridView gridViewEmpresaTasadora = null;
    private Button btnCerrarEmpresaTasadora = null;
    private Button btnAceptarEmpresaTasadora = null;

    #endregion

    #region VENTANA CONSULTA PERSONA TASADORA

    private GridView gridViewPersonaTasadora = null;
    private Button btnCerrarPersonaTasadora = null;
    private Button btnAceptarPersonaTasadora = null;

    #endregion

    #region  GRID ADMINISTRACION TASADORES

    private Button btnAgregarTasador = null;
    private Button btnEliminarTasador = null;

    #endregion

    #region  GRID ADMINISTRACION CEDULAS

    private Button btnAgregarCedula = null;
    private Button btnEliminarCedula = null;

    #endregion

    #region  GRID ADMINISTRACION GRAVAMENES

    private Button btnAgregarGravamen = null;
    private Button btnEliminarGravamen = null;
    private Button btnModificarGravamen = null;

    #endregion

    #region  GRID ADMINISTRACION POLIZAS

    //B16S01
    private Button btnAgregarPoliza = null;
    private Button btnEliminarPoliza = null;
    private Button btnModificarPoliza = null;

    #endregion

    #region  VENTANA ADMINISTRACION DE CEDULAS

    private TextBox txtCedulasHipotecariasFechaVencimiento = null;
    private TextBox txtCedulasHipotecariasFechaPrescripcion = null;
    private Button btnCedulasHipotecariasAceptar = null;
    private Button btnCedulasHipotecariasCancelar = null;

    #endregion

    #region  VENTANA ADMINISTRACION DE GRAVAMENES

    private Button btnGravamenesGarantiasAceptar = null;
    private Button btnGravamenesGarantiasCancelar = null;

    #endregion

    #region  VENTANA ADMINISTRACION DE POLIZAS

    //B16S01
    private Button btnPolizasGarantiasAceptar = null;
    private Button btnPolizasGarantiasCancelar = null;

    #endregion

    #region GRID ADMINISTRACION TASADORES

    private GridView gridTasadoresInterno = null;

    #endregion

    #region GRID ADMINISTRACION CEDULAS

    private GridView gridCedulasInterno = null;

    #endregion

    #region GRID ADMINISTRACION GRAVAMENES

    private GridView gridGravamenesInterno = null;

    #endregion

    #region GRID ADMINISTRACION POLIZAS

    //B16S01
    private GridView gridPolizasInterno = null;

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


    #endregion

    #endregion

    #region METODOS PERSONALIZADOS NO EDITABLES

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
            this.btnLimpiarR = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesLimpiar"));
            this.btnLimpiarR.Click += new EventHandler(btnLimpiarR_Click);
            this.btnLimpiarR.CausesValidation = false;

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

            #region GRID ADMINISTRAR TASADORES

            this.btnAgregarTasador = ((Button)this.grdTasadores.FindControl("imgCmdAgregar"));
            this.btnAgregarTasador.CausesValidation = false;
            this.btnAgregarTasador.Click += new EventHandler(btnAgregarTasador_Click);

            this.btnEliminarTasador = ((Button)this.grdTasadores.FindControl("imgCmdEliminar"));
            this.btnEliminarTasador.CausesValidation = false;
            this.btnEliminarTasador.Click += new EventHandler(btnEliminarTasador_Click);

            #endregion

            #region GRID ADMINISTRAR CEDULAS

            this.btnAgregarCedula = ((Button)this.grdCedulas.FindControl("imgCmdAgregar"));
            this.btnAgregarCedula.CausesValidation = false;
            this.btnAgregarCedula.Click += new EventHandler(btnAgregarCedula_Click);

            this.btnEliminarCedula = ((Button)this.grdCedulas.FindControl("imgCmdEliminar"));
            this.btnEliminarCedula.CausesValidation = false;
            this.btnEliminarCedula.Click += new EventHandler(btnEliminarCedula_Click);

            #endregion

            #region GRID ADMINISTRAR GRAVAMEN

            this.btnAgregarGravamen = ((Button)this.grdGravamenes.FindControl("imgCmdAgregar"));
            this.btnAgregarGravamen.CausesValidation = false;
            this.btnAgregarGravamen.Click += new EventHandler(btnAgregarGravamen_Click);

            this.btnEliminarGravamen = ((Button)this.grdGravamenes.FindControl("imgCmdEliminar"));
            this.btnEliminarGravamen.CausesValidation = false;
            this.btnEliminarGravamen.Click += new EventHandler(btnEliminarGravamen_Click);

            this.btnModificarGravamen = ((Button)this.grdGravamenes.FindControl("imgCmdModificar"));
            this.btnModificarGravamen.Visible = true;
            this.btnModificarGravamen.CausesValidation = false;
            this.btnModificarGravamen.Click += new EventHandler(btnModificarGravamen_Click);

            #endregion

            #region GRID ADMINISTRAR POLIZA

            this.btnAgregarPoliza = ((Button)this.grdPolizas.FindControl("imgCmdAgregar"));
            this.btnAgregarPoliza.CausesValidation = false;
            this.btnAgregarPoliza.Click += new EventHandler(btnAgregarPoliza_Click);

            this.btnEliminarPoliza = ((Button)this.grdPolizas.FindControl("imgCmdEliminar"));
            this.btnEliminarPoliza.CausesValidation = false;
            this.btnEliminarPoliza.Click += new EventHandler(btnEliminarPoliza_Click);

            this.btnModificarPoliza = ((Button)this.grdPolizas.FindControl("imgCmdModificar"));
            this.btnModificarPoliza.Visible = true;
            this.btnModificarPoliza.CausesValidation = false;
            this.btnModificarPoliza.Click += new EventHandler(btnModificarPoliza_Click);

            #endregion

            #region MENSAJE INFORMAR FORMULARIO

            Button btnAceptarInformar = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);
            btnAceptarInformar.CausesValidation = false;
            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

            #region MENSAJE INFORMAR FORMULARIO 2

            Button btnAceptarInformar2 = (Button)this.InformarBox2.FindControl("wucBtnAceptar");
            btnAceptarInformar2.Click += new EventHandler(btnAceptarInformar2_Click);
            btnAceptarInformar2.CausesValidation = false;
            this.InformarBox2.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox2_SetConfirmationBoxEvent);

            #endregion

            #region MENSAJE INFORMAR FORMULARIO 3

            Button btnAceptarInformar3 = (Button)this.InformarBox3.FindControl("wucBtnAceptar");
            btnAceptarInformar3.Click += new EventHandler(btnAceptarInformar3_Click);
            btnAceptarInformar3.CausesValidation = false;
            this.InformarBox3.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox3_SetConfirmationBoxEvent);

            #endregion

            #region MENSAJE INFORMAR FORMULARIO 4

            //B16S01
            Button btnAceptarInformar4 = (Button)this.InformarBox4.FindControl("wucBtnAceptar");
            btnAceptarInformar4.Click += new EventHandler(btnAceptarInformar4_Click);
            btnAceptarInformar4.CausesValidation = false;
            this.InformarBox4.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox4_SetConfirmationBoxEvent);

            #endregion

            //Control de Cambios 1.5 Garantias Reales II
            #region MENSAJE ADVERTENCIA ACTUALIZAR TIPO BIEN 2

            Button btnAceptarAdvertencia = (Button)this.MensajeAdvertencia1.FindControl("wucBtnAceptar");
            btnAceptarAdvertencia.Click += new EventHandler(btnAceptarAdvertencia_Click);
            btnAceptarAdvertencia.CausesValidation = false;
            this.MensajeAdvertencia1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(MensajeAdvertencia1_SetConfirmationBoxEvent);

            #endregion

            //Control de Cambios 1.2
            #region MENSAJE CONFIRMAR ACTUALIZAR TIPO BIEN 1 A TIPO BIEN 2

            Button btnAceptarActualizar = (Button)this.ConfirmarBoxActualizar.FindControl("wucBtnAceptar");
            btnAceptarActualizar.Click += new EventHandler(btnAceptarActualizar_Click);
            btnAceptarActualizar.CausesValidation = false;
            this.ConfirmarBoxActualizar.SetConfirmationBoxEvent += new wucMensajeConfirmar.SetConfirmationBox(ConfirmarBoxActualizar_SetConfirmationBoxEvent);

            Button btnCancelarActualizar = (Button)this.ConfirmarBoxActualizar.FindControl("wucBtnCancelar");
            btnCancelarActualizar.Click += new EventHandler(btnCancelarActualizar_Click);
            btnCancelarActualizar.CausesValidation = false;

            #endregion

            #region MENSAJE CONFIRMAR ELIMINAR GRAVAMENES

            //SE ESTABLECEN LAS DESCRIPCIONES A MOSTRAR EN EL MENSAJE DE CONFIRMACION PARA ELIMINACION
            this.MensajeConfirmarEliminarGravamenes1.EstablecerMensaje("Se eliminarán los gravámenes asociados.");
            this.MensajeConfirmarEliminarGravamenes1.EstablecerNombreBotones("Sí", "No");

            Button btnAceptarConfirmarEliminarGravamen = (Button)this.MensajeConfirmarEliminarGravamenes1.FindControl("wucBtnAceptar");
            btnAceptarConfirmarEliminarGravamen.Click += new EventHandler(btnAceptarConfirmarEliminarGravamen_Click);
            btnAceptarConfirmarEliminarGravamen.CausesValidation = false;

            Button btnCancelarConfirmarEliminarGravamen = (Button)this.MensajeConfirmarEliminarGravamenes1.FindControl("wucBtnCancelar");
            btnCancelarConfirmarEliminarGravamen.Click += new EventHandler(btnCancelarConfirmarEliminarGravamen_Click);
            btnCancelarConfirmarEliminarGravamen.CausesValidation = false;

            #endregion

            #region MENSAJE CONFIRMAR ELIMINAR POLIZAS

            //SE ESTABLECEN LAS DESCRIPCIONES A MOSTRAR EN EL MENSAJE DE CONFIRMACION PARA ELIMINACION
            this.MensajeConfirmarEliminarPolizas1.EstablecerMensaje("Se eliminarán las pólizas asociadas.");
            this.MensajeConfirmarEliminarPolizas1.EstablecerNombreBotones("Sí", "No");

            Button btnAceptarConfirmarEliminarPoliza = (Button)this.MensajeConfirmarEliminarPolizas1.FindControl("wucBtnAceptar");
            btnAceptarConfirmarEliminarPoliza.Click += new EventHandler(btnAceptarConfirmarEliminarPoliza_Click);
            btnAceptarConfirmarEliminarPoliza.CausesValidation = false;

            Button btnCancelarConfirmarEliminarPoliza = (Button)this.MensajeConfirmarEliminarPolizas1.FindControl("wucBtnCancelar");
            btnCancelarConfirmarEliminarPoliza.Click += new EventHandler(btnCancelarConfirmarEliminarPoliza_Click);
            btnCancelarConfirmarEliminarPoliza.CausesValidation = false;

            #endregion

            #endregion

            #region EVENTOS GRIDVIEWS

            //GRID VENTANA BUSQUEDA CLASE VEHICULO
            GridViewClaseVehiculo(sender, e);

            //GRID VENTANA BUSQUEDA EMPRESAS TASADORAS
            GridViewEmpresasTasadoras(sender, e);

            //GRID VENTANA BUSQUEDA PERSONAS TASADORAS
            GridViewPersonasTasadoras(sender, e);

            //GRID ADMINISTRACION TASADORES
            GridViewTasadoresInterno(sender, e);

            //GRID ADMINISTRACION CEDULAS
            GridViewCedulasInterno(sender, e);

            //GRID ADMINISTRACION GRAVAMENES
            GridViewGravamenesInterno(sender, e);

            //GRID ADMINISTRACION POLIZAS
            GridViewPolizasInterno(sender, e);

            #endregion

            #region VENTANA BUSQUEDA CLASE VEHICULO

            #region BOTONES CLASE VEHICULO

            btnCerrarClaseVehiculo = ((Button)this.BusquedaClaseVehiculo.FindControl("cmdMainEmergenteCancelar"));
            btnCerrarClaseVehiculo.Click += new EventHandler(btnCerrarClaseVehiculo_Click);
            btnCerrarClaseVehiculo.CausesValidation = false;

            btnAceptarClaseVehiculo = ((Button)this.BusquedaClaseVehiculo.FindControl("cmdMainEmergenteAceptar"));
            btnAceptarClaseVehiculo.Click += new EventHandler(btnAceptarClaseVehiculo_Click);
            btnAceptarClaseVehiculo.CausesValidation = false;

            #region MENSAJE INFORMAR VENTANA BUSQUEDA CLASE VEHICULO

            Button btnAceptarInformarClaseVehiculo = (Button)this.InformarBoxBusquedaClaseVehiculo.FindControl("wucBtnAceptar");
            btnAceptarInformarClaseVehiculo.Click += new EventHandler(btnAceptarInformarEmergenteClaseVehiculo_Click);
            btnAceptarInformarClaseVehiculo.CausesValidation = false;
            this.InformarBoxBusquedaClaseVehiculo.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxBusquedaClaseVehiculo_SetConfirmationBoxEvent);

            #endregion

            #endregion

            #endregion

            #region VENTANA BUSQUEDA EMPRESA TASADORA

            #region BOTONES EMPRESA TASADORA

            btnCerrarEmpresaTasadora = ((Button)this.BusquedaEmpresaTasadora.FindControl("cmdMainEmergenteCancelar"));
            btnCerrarEmpresaTasadora.Click += new EventHandler(btnCerrarEmpresaTasadora_Click);
            btnCerrarEmpresaTasadora.CausesValidation = false;

            btnAceptarEmpresaTasadora = ((Button)this.BusquedaEmpresaTasadora.FindControl("cmdMainEmergenteAceptar"));
            btnAceptarEmpresaTasadora.Click += new EventHandler(btnAceptarEmpresaTasadora_Click);
            btnAceptarEmpresaTasadora.CausesValidation = false;

            #endregion

            #region MENSAJE INFORMAR VENTANA BUSQUEDA EMPRESA TASADORA

            Button btnAceptarInformarEmpresaTasadora = (Button)this.InformarBoxBusquedaEmpresaTasadora.FindControl("wucBtnAceptar");
            btnAceptarInformarEmpresaTasadora.Click += new EventHandler(btnAceptarInformarEmergenteEmpresaTasadora_Click);
            this.InformarBoxBusquedaEmpresaTasadora.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxBusquedaEmpresaTasadora_SetConfirmationBoxEvent);

            #endregion

            #endregion

            #region VENTANA BUSQUEDA PERSONA TASADORA

            #region BOTONES PERSONA TASADORA

            btnCerrarPersonaTasadora = ((Button)this.BusquedaPersonaTasadora.FindControl("cmdMainEmergenteCancelar"));
            btnCerrarPersonaTasadora.Click += new EventHandler(btnCerrarPersonaTasadora_Click);
            btnCerrarPersonaTasadora.CausesValidation = false;

            btnAceptarPersonaTasadora = ((Button)this.BusquedaPersonaTasadora.FindControl("cmdMainEmergenteAceptar"));
            btnAceptarPersonaTasadora.Click += new EventHandler(btnAceptarPersonaTasadora_Click);
            btnAceptarPersonaTasadora.CausesValidation = false;

            #endregion

            #region MENSAJE INFORMAR VENTANA BUSQUEDA PERSONA TASADORA

            Button btnAceptarInformarPersonaTasadora = (Button)this.InformarBoxBusquedaPersonaTasadora.FindControl("wucBtnAceptar");
            btnAceptarInformarPersonaTasadora.Click += new EventHandler(btnAceptarInformarEmergentePersonaTasadora_Click);
            this.InformarBoxBusquedaPersonaTasadora.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxBusquedaPersonaTasadora_SetConfirmationBoxEvent);

            #endregion

            #endregion

            #region VENTANA ADMINISTRACION DE CEDULAS

            this.txtCedulasHipotecariasFechaVencimiento = ((TextBox)this.CedulasHipotecarias.FindControl("txtCedulasHipotecariasFechaVencimiento"));
            this.txtCedulasHipotecariasFechaVencimiento.TextChanged += new EventHandler(txtCedulasHipotecariasFechaVencimiento_TextChanged);
            this.txtCedulasHipotecariasFechaVencimiento.AutoPostBack = true;

            this.txtCedulasHipotecariasFechaPrescripcion = ((TextBox)this.CedulasHipotecarias.FindControl("txtCedulasHipotecariasFechaPrescripcion"));

            #region BOTONES VENTANA ADMINISTRACION DE CEDULAS

            this.btnCedulasHipotecariasAceptar = ((Button)this.CedulasHipotecarias.FindControl("btnCedulasHipotecariasAceptar"));
            this.btnCedulasHipotecariasAceptar.Click += new EventHandler(btnCedulasHipotecariasAceptar_Click);
            this.btnCedulasHipotecariasAceptar.CausesValidation = true;

            this.btnCedulasHipotecariasCancelar = ((Button)this.CedulasHipotecarias.FindControl("btnCedulasHipotecariasCancelar"));
            this.btnCedulasHipotecariasCancelar.Click += new EventHandler(btnCedulasHipotecariasCancelar_Click);
            this.btnCedulasHipotecariasCancelar.CausesValidation = false;

            #endregion

            #region MENSAJE INFORMAR VENTANA ADMINISTRACION DE CEDULAS
            Button btnAceptarInformarCedulasHipotecarias = (Button)this.InformarBoxCedulasHipotecarias.FindControl("wucBtnAceptar");
            btnAceptarInformarCedulasHipotecarias.Click += new EventHandler(btnAceptarInformarCedulasHipotecarias_Click);
            this.InformarBoxCedulasHipotecarias.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxCedulasHipotecarias_SetConfirmationBoxEvent);

            #endregion

            #endregion

            #region VENTANA ADMINISTRACION DE GRAVAMENES

            #region BOTONES VENTANA ADMINISTRACION DE GRAVAMENES

            this.btnGravamenesGarantiasAceptar = ((Button)this.VentanaGravamenesGarantias1.FindControl("btnGravamenGarantiaAceptar"));
            this.btnGravamenesGarantiasAceptar.Click += new EventHandler(btnGravamenesGarantiasAceptar_Click);
            this.btnGravamenesGarantiasAceptar.CausesValidation = true;

            this.btnGravamenesGarantiasCancelar = ((Button)this.VentanaGravamenesGarantias1.FindControl("btnGravamenGarantiaCancelar"));
            this.btnGravamenesGarantiasCancelar.Click += new EventHandler(btnGravamenesGarantiasCancelar_Click);
            this.btnGravamenesGarantiasCancelar.CausesValidation = false;

            #endregion

            #endregion

            //B16S01
            #region VENTANA ADMINISTRACION DE POLIZAS

            #region BOTONES VENTANA ADMINISTRACION DE POLIZAS

            this.btnPolizasGarantiasAceptar = ((Button)this.VentanaPolizasGarantia1.FindControl("btnGravamenGarantiaAceptar"));
            this.btnPolizasGarantiasAceptar.Click += new EventHandler(btnPolizasGarantiasAceptar_Click);
            this.btnPolizasGarantiasAceptar.CausesValidation = true;

            this.btnPolizasGarantiasCancelar = ((Button)this.VentanaPolizasGarantia1.FindControl("btnGravamenGarantiaCancelar"));
            this.btnPolizasGarantiasCancelar.Click += new EventHandler(btnPolizasGarantiasCancelar_Click);
            this.btnPolizasGarantiasCancelar.CausesValidation = false;

            #endregion

            #endregion

            if (!IsPostBack)
            {
                VariablesGlobales();
                valorReemplazo = string.Empty;
            }

            Tabs();
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
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (!IsPostBack)
                {
                    ControlesNombre();
                    Controles();

                    //CARGA LOS VALORES PARA LOS TITULOS
                    Etiquetas();
                    Efectos();
                    //CARGA LOS VALORES DESDE BD PARA EL CASO DE LAS MODIFICACIONES
                    DeEntidadAControles();
                    //BLOQUEA LOS CONTROLES NO UTILIZADOS
                    DeshabilitarControlesExcepciones();
                    //MUESTRA LAS NOTIFICACIONES DEL MANEJO DE GRIDS
                    MensajesGrid();
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

    #region EVENTOS CLICK

    #region VENTANA BUSQUEDA CLASE VEHICULO

    protected void btnCerrarClaseVehiculo_Click(object sender, EventArgs e)
    {
        this.mpeBusquedaClaseVehiculo.Hide();
    }

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

    #endregion

    #region VENTANA BUSQUEDA EMPRESA TASADORA

    protected void btnCerrarEmpresaTasadora_Click(object sender, EventArgs e)
    {
        this.mpeBusquedaEmpresaTasadora.Hide();
    }

    protected void btnAceptarEmpresaTasadora_Click(object sender, EventArgs e)
    {
        try
        {
            SeleccionarRegistroEmpresaTasadora(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #region VENTANA BUSQUEDA PERSONA TASADORA

    protected void btnCerrarPersonaTasadora_Click(object sender, EventArgs e)
    {
        this.mpeBusquedaPersonaTasadora.Hide();
    }

    protected void btnAceptarPersonaTasadora_Click(object sender, EventArgs e)
    {
        try
        {
            SeleccionarRegistroPersonaTasadora(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #region VENTANA ADMINISTRACION DE CEDULAS

    protected void btnCedulasHipotecariasAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            SeleccionarRegistroCedulasHipotecarias(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnCedulasHipotecariasCancelar_Click(object sender, EventArgs e)
    {
        this.mpeCedulasHipotecarias.Hide();
    }

    #endregion

    #region VENTANA ADMINISTRACION DE GRAVAMENES

    protected void btnGravamenesGarantiasAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            ObtenerValoresRegistroGravamenes(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnGravamenesGarantiasCancelar_Click(object sender, EventArgs e)
    {
        this.mpeGravamenesGarantias.Hide();
    }

    #endregion

    #region VENTANA ADMINISTRACION DE POLIZAS

    protected void btnPolizasGarantiasAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (!this.VentanaPolizasGarantia1.ValidarPolizaIdentificacion())
                ObtenerValoresRegistroPolizas(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnPolizasGarantiasCancelar_Click(object sender, EventArgs e)
    {
        this.mpePolizasGarantias.Hide();
    }

    #endregion

    protected void btnAyudaGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                banderaVentana = 0; // 0 = SE MANTIENE EL MISMO REGISTRO
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

    protected void btnLimpiarR_Click(object sender, EventArgs e)
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

    protected void btnAceptarInformar2_Click(object sender, EventArgs e)
    {
        this.mpeInformarBox2.Hide();
    }

    protected void btnAceptarInformar3_Click(object sender, EventArgs e)
    {
        this.mpeInformarBox3.Hide();
    }

    protected void btnAceptarInformar4_Click(object sender, EventArgs e)
    {
        //B16S01
        this.mpeInformarBox4.Hide();
    }

    //Control de Cambios 1.5 Garantias Reales II
    protected void btnAceptarAdvertencia_Click(object sender, EventArgs e)
    {
        try
        {
            this.mpeAdvertenciaBox.Hide();
            AbrirRegistrosActualizados();
            Cerrar();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnAceptarInformarEmergenteClaseVehiculo_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxBusquedaClaseVehiculo.Hide();
        this.mpeBusquedaClaseVehiculo.Show();
    }

    protected void btnAceptarInformarEmergenteEmpresaTasadora_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxBusquedaEmpresaTasadora.Hide();
        this.mpeBusquedaEmpresaTasadora.Show();
    }

    protected void btnAceptarInformarEmergentePersonaTasadora_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxBusquedaPersonaTasadora.Hide();
        this.mpeBusquedaPersonaTasadora.Show();
    }

    protected void btnAceptarInformarCedulasHipotecarias_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxCedulasHipotecarias.Hide();
        this.mpeCedulasHipotecarias.Show();
    }

    //Control de Cambios 1.2
    #region VENTANA CONFIRMAR

    protected void btnAceptarActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            ActualizarEntidadTipoBien();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnCancelarActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            this.mpeConfirmarBoxActualizar.Hide();
            InsertarEntidadTipoBien2();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #region VENTANA CONFIRMAR ELIMINAR GRAVAMENES

    protected void btnAceptarConfirmarEliminarGravamen_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                GarantiasGravemenesEntidad entidad = null;
                foreach (GridViewRow row1 in gridGravamenesInterno.Rows)
                {
                    Label lblId = (Label)gridGravamenesInterno.Rows[row1.RowIndex].FindControl("lblIdGravamen");

                    entidad = new GarantiasGravemenesEntidad();
                    entidad.IdGravamen = int.Parse(lblId.Text);
                    entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                    respuesta = wsGarantias.GarantiasGravamenesEliminar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));

                }

                GridViewGravamenesInternoActualizar();
                EfectoDdlIndGravamen();
                DdlIndGravamen();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnCancelarConfirmarEliminarGravamen_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                this.mpeConfirmarEliminarGravamenes.Hide();
                EfectoDdlIndGravamen();
                DdlIndGravamen();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #region VENTANA CONFIRMAR ELIMINAR POLIZAS

    protected void btnAceptarConfirmarEliminarPoliza_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                PolizaEntidad entidad = null;
                foreach (GridViewRow row1 in gridPolizasInterno.Rows)
                {
                    Label lblId = (Label)gridPolizasInterno.Rows[row1.RowIndex].FindControl("lblIdPoliza");

                    entidad = new PolizaEntidad();
                    entidad.IdPoliza = int.Parse(lblId.Text);
                    entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                    respuesta = wsGarantias.GarantiasRealesPolizaEliminar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));

                }

                GridViewPolizasInternoActualizar();
                EfectoDdlIndPoliza();
                DdlIndPoliza();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnCancelarConfirmarEliminarPoliza_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                this.mpeConfirmarEliminarPolizas.Hide();
                EfectoDdlIndPoliza();
                DdlIndPoliza();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #endregion

    #endregion

    //Requerimiento Bloque 7 1-24381561
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
                        propiedad.SetValue(_entidad, lblCodigoUsuario, null);
                        break;
                }
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
            GarantiasRealesEntidad resultado = ConsultarDetalleEntidad();

            ObtenerControlRegistros(resultado);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*OBTIENE LOS DATOS DEL CONTROL DE REGISTRO EN MODO EDICION*/
    private void ObtenerControlRegistros(GarantiasRealesEntidad _entidad)
    {
        try
        {
            Label lblCreadoPor = (Label)this.Master.FindControl("Propiedades1").FindControl("lblCreadoPor");
            Label lblModificadoPor = (Label)this.Master.FindControl("Propiedades1").FindControl("lblModificadoPor");
            Label lblFechaCreacion = (Label)this.Master.FindControl("Propiedades1").FindControl("lblFechaCreacion");
            Label lblFechaModificacion = (Label)this.Master.FindControl("Propiedades1").FindControl("lblFechaModificacion");
            Label lblFuente = (Label)this.Master.FindControl("Propiedades1").FindControl("lblFuente");

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
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region EXCEPCIONES

    /*DESHABILITA LOS CONTROLES AL INGRESAR A LA PANTALLA*/
    private void DeshabilitarControlesExcepciones()
    {
        //REGISTRO NUEVO
        if (pantallaIdOculto.Value.Equals("0"))
        {
            AdministrarControlesExcepcionesValuacion(false);
            AdministrarControlesExcepcionesTasadores(false);
            AdministrarControlesExcepcionesCedulas(false);
            AdministrarControlesExcepcionesGravamenes(false);
            //B16S01
            AdministrarControlesExcepcionesPolizas(false);

            if (this.ddlTipoBien.Enabled)
                DeshabilitarControlesGuardar(true);
            else
                DeshabilitarControlesGuardar(false);
        }
    }

    /*DESHABILITA LOS BOTONES DE GUARDADO EN EL MENU DE ACCIONES*/
    private void DeshabilitarControlesGuardar(bool deshabilitados)
    {
        ((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesGuardar(deshabilitados);
        //((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesEstilos(deshabilitados);
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION GENERAL*/
    private void AdministrarControlesExcepcionesGeneral(bool habilitado)
    {
        this.ddlTipoBien.Enabled = habilitado;
        this.ddlClase.Enabled = habilitado;
        this.ddlProvincia.Enabled = habilitado;
        this.ddlHorizontal.Enabled = habilitado;
        this.ddlDuplicado.Enabled = habilitado;
        this.ddlClaseBuque.Enabled = habilitado;
        this.ddlClaseAeronave.Enabled = habilitado;
        this.txtClaseVehiculo.Enabled = habilitado;
        this.btnClaseVehiculo.Enabled = habilitado;
        this.txtDesClaseVehiculo.Enabled = habilitado;
        this.rfvDesClaseVehiculo.Enabled = habilitado;
        this.ddlFormato.Enabled = habilitado;
        this.txtNBien.Enabled = habilitado;
        this.rfvNBien.Enabled = habilitado;
        this.btnValidar.Enabled = habilitado;

        //Control de Cambios 1.1
        this.chkEstadoDuplicado.Enabled = habilitado;
        this.chkEstadoHorizontal.Enabled = habilitado;
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION VALUACION*/
    private void AdministrarControlesExcepcionesValuacion(bool habilitado)
    {
        this.ddlLiquidezGarantia.Enabled = habilitado;
        this.txtMontoUltimaTasacionTerreno.Enabled = habilitado;
        this.rfvMontoUltimaTasacionTerreno.Enabled = habilitado;
        this.txtFechaConstruccionGarantia.Enabled = habilitado;
        this.txtFechaConstruccionGarantia.Attributes.Add("readonly", "readonly");
        this.rfvFechaConstruccionGarantia.Enabled = habilitado;
        this.imbFechaConstruccionGarantia.Enabled = habilitado;
        this.txtMontoUltimaTasacionNoTerreno.Enabled = habilitado;
        this.rfvMontoUltimaTasacionNoTerreno.Enabled = habilitado;
        this.txtFechaUltimaTasacionGarantia.Enabled = habilitado;
        this.txtFechaUltimaTasacionGarantia.Attributes.Add("readonly", "readonly");
        this.rfvFechaUltimaTasacionGarantia.Enabled = habilitado;
        this.imbFechaUltimaTasacionGarantia.Enabled = habilitado;
        this.txtFechaUltimoSeguimientoGarantia.Enabled = habilitado;
        this.txtFechaUltimoSeguimientoGarantia.Attributes.Add("readonly", "readonly");
        this.rfvFechaUltimoSeguimientoGarantia.Enabled = habilitado;
        this.imbFechaUltimoSeguimientoGarantia.Enabled = habilitado;
        this.txtMontoTasacionActualizadaTerreno.Enabled = habilitado;
        this.rfvMontoTasacionActualizadaTerreno.Enabled = habilitado;
        //this.txtFechaVencimientoAvaluo.Enabled = habilitado;
        //this.imbFechaVencimientoAvaluo.Enabled = habilitado;
        this.txtMontoTasacionActualizadaNoTerreno.Enabled = habilitado;
        this.rfvMontoTasacionActualizadaNoTerreno.Enabled = habilitado;
        this.txtFechaFabricacionGarantia.Enabled = habilitado;
        this.txtFechaFabricacionGarantia.Attributes.Add("readonly", "readonly");
        this.rfvFechaFabricacionGarantia.Enabled = habilitado;
        this.imbFechaFabricacionGarantia.Enabled = habilitado;
        this.ddlTipoAlmacen.Enabled = habilitado;
        this.ddlEstadoGarantia.Enabled = habilitado;
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION TASADORES*/
    private void AdministrarControlesExcepcionesTasadores(bool habilitado)
    {
        this.ddlTipoTasador.Enabled = habilitado;
        this.imbAdministrarEmpresaTasadora.Enabled = habilitado;
        this.btnAgregarTasador.Enabled = habilitado;
        this.btnEliminarCedula.Enabled = habilitado;
        this.btnLimpiar.Enabled = habilitado;
        //this.pnlTasadores.Enabled = habilitado;
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION CEDULAS*/
    private void AdministrarControlesExcepcionesCedulas(bool habilitado)
    {
        this.txtValorTotalCedulas.Enabled = habilitado;
        this.rfvValorTotalCedulas.Enabled = habilitado;
        //this.pnlCedulas.Enabled = habilitado;
        this.btnAgregarCedula.Enabled = habilitado;
        this.btnEliminarCedula.Enabled = habilitado;
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION GRAVAMENES*/
    private void AdministrarControlesExcepcionesGravamenes(bool habilitado)
    {
        this.ddlIndGravamen.Enabled = habilitado;
        this.gridGravamenesInterno.Enabled = habilitado;
        this.btnAgregarGravamen.Enabled = habilitado;
        this.btnEliminarGravamen.Enabled = habilitado;
        this.btnModificarGravamen.Enabled = habilitado;
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION POLIZAS*/
    private void AdministrarControlesExcepcionesPolizas(bool habilitado)
    {
        this.ddlIndPoliza.Enabled = habilitado;
        this.gridPolizasInterno.Enabled = habilitado;
        this.btnAgregarPoliza.Enabled = habilitado;
        this.btnEliminarPoliza.Enabled = habilitado;
        this.btnModificarPoliza.Enabled = habilitado;
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

    #region METODOS PERSONALIZADOS EDITABLES

    #region METODOS EVENTOS CLICK

    private void Cerrar()
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "closeWindow", "top.close();", true);
    }

    private void NuevoRegistro()
    {
        string script = "if (window.opener != null && !window.opener.closed) { window.parent.opener.document.getElementById('cmdAccionesNuevo').click(); }";
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "CreateNewWindow", script, true);
    }

    private void Guardar()
    {
        try
        {
            //Control de Cambios 1.5 Garantias Reales II
            if (this.divBarraMensaje.Visible)
                this.divBarraMensaje.Visible = false;

            if (!ValidarSeccionTasadores())
            {
                if (!ValidarSeccionCedulas())
                {
                    if (!ValidarSeccionGravamenes())
                    {
                        if (!ValidarSeccionPolizas())
                        {
                            //ACTUALIZA LA SECCION GENERAL Y VALUACION
                            ModificarEntidadReal();

                            //Control de Cambios 1.5 Garantias Reales II
                            /*
                            //PARA LOS NUEVOS REGISTROS AL SELECCIONAR UN TASADOR TIPO EMPRESA SE DEBE DE REALIZAR LA INSERCION DEL ÚNICO REGISTRO
                            if (pantallaIdOculto.Value.Equals("0"))
                            {
                                if (this.ddlTipoTasador.SelectedItem.Text.Equals("Empresa"))
                                    InsertarEntidadTasador();
                            }*/
                            //CAMBIO EN FUNCIONAMIENTO DE TASADORES
                            if (this.ddlTipoTasador.SelectedItem.Text.Equals("Empresa"))
                                InsertarEntidadTasador();

                            //Requerimiento Bloque 7 1-24381561 
                            MostrarControlRegistrosGuardar();

                            GridViewCedulasInternoActualizar();
                            GridViewTasadoresInternoActualizar();
                            GridViewGravamenesInternoActualizar();
                            GridViewGravamenesInternoActualizar();
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

    private void AbrirRegistrosActualizados()
    {
        string scriptOperaciones = string.Empty;
        if (this.idOperacionOculto.Value.Length > 0)
            scriptOperaciones = "window.parent.opener.document.getElementById('idOperacionOculto').value = '" + this.idOperacionOculto.Value + "'; ";

        if (this.idGarantiaRealTipoBienOculto.Value.Length > 0)
        {
            string script = scriptOperaciones + "window.parent.opener.document.getElementById('idGarantiaRealOculto').value = '" + this.idGarantiaRealTipoBienOculto.Value + "' ; window.parent.opener.document.getElementById('cmdAccionesNuevoId').click();";
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "CreateNewWindow", script, true);
        }
    }

    #endregion

    #region BUSQUEDA CLASE VEHICULO

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE CLASE VEHICULO SELECCIONADO*/
    private void SeleccionarRegistroClaseVehiculo(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CONSULTA CLASES VEHICULOS*/
    private List<ListasWS.ListaEntidad> ConsultaClaseVehiculo(string filtro)
    {
        try
        {
            List<ListasWS.ListaEntidad> retorno = null;
            retorno = wsListas.ClasesVehiculosLista2(filtro).ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewClaseVehiculo(object sender, EventArgs e)
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

    #endregion

    #region GRIDVIEW CLASE VEHICULO

    private void gridViewClaseVehiculo_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        gridViewColumn = new GridViewColumn();
        this.gridViewClaseVehiculo.Columns.Add(gridViewColumn.CreateBoundField("Texto", string.Empty, "Descripción", HorizontalAlign.Center, false, true));

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridViewClaseVehiculo, "Valor", lblID);
    }

    #endregion

    #region BUSQUEDA EMPRESAS TASADORAS

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE EMPRESA TASADORA SELECCIONADO*/
    private void SeleccionarRegistroEmpresaTasadora(object sender, EventArgs e)
    {
        try
        {
            //VALIDA QUE SOLO UN ELEMENTO SEA EL SELECCIONADO
            if (((wucGridEmergente)this.BusquedaEmpresaTasadora).ContadorSeleccionados().Equals(1))
            {
                string[] valoresGrid;
                List<KeyValuePair<int, string>> valorSeleccionado = ((wucGridEmergente)this.BusquedaEmpresaTasadora).ObtenerTodosValoresSeleccionados("lblIdTasador");
                valoresGrid = valorSeleccionado[0].Value.Split('|');

                //DDL TIPO PERSONA EMPRESA TASADORA
                controlSeleccionado = ControlesBuscar(this.ddlTipoPersonaEmpresaTasadora.ID);
                this.ddlTipoPersonaEmpresaTasadora.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
                this.ddlTipoPersonaEmpresaTasadora.DataTextField = "Texto";
                this.ddlTipoPersonaEmpresaTasadora.DataValueField = "Valor";
                this.ddlTipoPersonaEmpresaTasadora.DataBind();
                this.ddlTipoPersonaEmpresaTasadora.CssClass = controlSeleccionado.CssTipo;

                //ASIGNA LOS VALORES SELECCIONADOS AL FORMULARIO PRINCIPAL
                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoPersonaEmpresaTasadora, valoresGrid[0]);
                this.txtIdEmpresaTasadora.Text = valoresGrid[1];
                this.txtNombreEmpresaTasadora.Text = valoresGrid[2];
                this.hdnIdEmpresaTasadora.Value = valoresGrid[3];
                //this.lblEmpresaTasadora.Text = valoresGrid[3];

                //EL COMPONENTE TIPO TASADOR SE DEBE DESHABILITAR
                this.ddlTipoTasador.Enabled = false;

                this.mpeBusquedaEmpresaTasadora.Hide();

                //Control de Cambios 1.5 Garantias Reales II
                //SE DESHABILITA EL BOTON DE BUSQUEDA DE EMPRESAS TASADORAS
                this.imbAdministrarEmpresaTasadora.Enabled = false;
            }
            else
            {
                //VERIFICA SI EL GRID CONTIENE REGISTROS
                if (((wucGridEmergente)this.BusquedaEmpresaTasadora).ContadorSeleccionados().Equals(0))
                {
                    this.InformarBoxBusquedaEmpresaTasadora_SetConfirmationBoxEvent(sender, e, "SYS_8");
                    this.mpeInformarBoxBusquedaEmpresaTasadora.Show();
                }
                else
                {
                    if (((wucGridEmergente)this.BusquedaEmpresaTasadora).ContadorSeleccionados() > 1)
                    {
                        this.InformarBoxBusquedaEmpresaTasadora_SetConfirmationBoxEvent(sender, e, "SYS_4");
                        this.mpeInformarBoxBusquedaEmpresaTasadora.Show();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CONSULTA EMPRESAS TASADORAS*/
    private List<GarantiasWS.TasadoresEntidad> ConsultaEmpresasTasadoras()
    {
        try
        {
            List<GarantiasWS.TasadoresEntidad> retorno = null;
            retorno = wsGarantias.GarantiasRealesTasadoresConsultar().ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewEmpresasTasadoras(object sender, EventArgs e)
    {
        try
        {
            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridViewEmpresaTasadora = (GridView)this.BusquedaEmpresaTasadora.FindControl("MasterGridView");
            this.BusquedaEmpresaTasadora.TextoGridVacio("No hay Disponible ningún registro en este Catálogo.");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridViewEmpresaTasadora.Init += new EventHandler(gridViewEmpresasTasadoras_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridViewEmpresasTasadoras_Init(sender, e);

            //TITULOS
            ((Label)this.BusquedaEmpresaTasadora.FindControl("lblTitulo")).Text = "Administración de Empresas Tasadoras";
            ((Label)this.BusquedaEmpresaTasadora.FindControl("lblSubTitulo")).Text = "Seleccione un registro.";

            //ASIGNA DATA KEYS
            String[] DataKeysString = { "IdTasador" };
            this.SetDataKeys(gridViewEmpresaTasadora, DataKeysString);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region GRIDVIEW EMPRESAS TASADORAS

    private void gridViewEmpresasTasadoras_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridViewEmpresaTasadora, "IdTasador", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridViewEmpresaTasadora.Columns.Add(gridViewColumn.CreateBoundField("DesTipoPersona", string.Empty, "Tipo Persona Empresa Tasadora", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridViewEmpresaTasadora.Columns.Add(gridViewColumn.CreateBoundField("CodTasador", string.Empty, "Id Empresa Tasadora", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridViewEmpresaTasadora.Columns.Add(gridViewColumn.CreateBoundField("DesNombreTasador", string.Empty, "Nombre Empresa Tasadora", HorizontalAlign.Center, false, true));
    }

    #endregion

    #region BUSQUEDA PERSONAS TASADORAS

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE PERSONA TASADORA SELECCIONADO*/
    private void SeleccionarRegistroPersonaTasadora(object sender, EventArgs e)
    {
        try
        {
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (this.BusquedaPersonaTasadora.ContadorSeleccionados() > 0)
            {
                GarantiasRealesTasadoresEntidad entidad = null;
                CheckBox checkBoxColumn = null;

                foreach (GridViewRow row in gridViewPersonaTasadora.Rows)
                {
                    checkBoxColumn = (CheckBox)gridViewPersonaTasadora.Rows[row.RowIndex].FindControl("chkBox1");

                    if (checkBoxColumn.Checked)
                    {
                        Label lbl = (Label)gridViewPersonaTasadora.Rows[row.RowIndex].FindControl("lblIdTasador");

                        entidad = new GarantiasRealesTasadoresEntidad();
                        entidad.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);
                        entidad.IdTasador = int.Parse(lbl.Text);

                        //Bloque 7 Requerimiento 1-24381561
                        CrearControlRegistros(entidad);

                        respuesta = wsGarantias.GarantiasRealesTasadoresInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                        //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                        if (respuesta.ValorError.Equals(18))
                        {
                            BloquearControlesDesactualizados();
                            BarraMensaje(respuesta, pantallaIdOculto.Value);
                        }
                    }
                }

                int idGarantiaReal = 0;
                if (!this.hdnIdGeneral.Value.Length.Equals(0))
                    idGarantiaReal = int.Parse(this.hdnIdGeneral.Value);
                this.grdTasadores.BindGridView(this.ConsultaTasadoresInterno(idGarantiaReal));

                if (gridTasadoresInterno.Rows.Count > 0)
                    this.ddlTipoTasador.Enabled = false;

                this.mpeBusquedaPersonaTasadora.Hide();
            }
            else
            {
                //VERIFICA SI EL GRID CONTIENE REGISTROS
                if (((wucGridEmergente)this.BusquedaPersonaTasadora).ContieneRegistros())
                {
                    this.mpeBusquedaPersonaTasadora.Hide();
                    this.InformarBoxBusquedaPersonaTasadora_SetConfirmationBoxEvent(sender, e, "SYS_8");
                    this.mpeInformarBoxBusquedaPersonaTasadora.Show();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CONSULTA PERSONAS TASADORAS*/
    private List<GarantiasWS.TasadoresEntidad> ConsultaPersonasTasadoras()
    {
        try
        {
            List<GarantiasWS.TasadoresEntidad> retorno = null;
            retorno = wsGarantias.GarantiasRealesPersonasTasadorasConsultar().ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewPersonasTasadoras(object sender, EventArgs e)
    {
        try
        {
            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridViewPersonaTasadora = (GridView)this.BusquedaPersonaTasadora.FindControl("MasterGridView");
            this.BusquedaPersonaTasadora.TextoGridVacio("No hay Disponible ningún registro en este Catálogo.");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridViewPersonaTasadora.Init += new EventHandler(gridViewPersonasTasadoras_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridViewPersonasTasadoras_Init(sender, e);

            //TITULOS
            ((Label)this.BusquedaPersonaTasadora.FindControl("lblTitulo")).Text = "Administración de Tasadores";
            ((Label)this.BusquedaPersonaTasadora.FindControl("lblSubTitulo")).Text = "Seleccione uno o varios registros.";

            //ASIGNA DATA KEYS
            String[] dataKeysString = { "IdTasador" };
            this.SetDataKeys(gridViewEmpresaTasadora, dataKeysString);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region GRIDVIEW PERSONAS TASADORAS

    void gridViewPersonasTasadoras_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridViewPersonaTasadora, "IdTasador", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridViewPersonaTasadora.Columns.Add(gridViewColumn.CreateBoundField("DesTipoPersona", string.Empty, "Tipo Persona Tasador", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridViewPersonaTasadora.Columns.Add(gridViewColumn.CreateBoundField("CodTasador", string.Empty, "Id Tasador", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridViewPersonaTasadora.Columns.Add(gridViewColumn.CreateBoundField("DesNombreTasador", string.Empty, "Nombre Tasador", HorizontalAlign.Center, false, true));
    }

    #endregion

    #region VENTANA ADMINISTRAR CEDULAS

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE ADMINISTRACION DE CEDULAS*/
    private void SeleccionarRegistroCedulasHipotecarias(object sender, EventArgs e)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            TextBox txtCedulasHipotecariasSerie = (TextBox)this.CedulasHipotecarias.FindControl("txtCedulasHipotecariasSerie");
            TextBox txtCedulasHipotecariasCedula = (TextBox)this.CedulasHipotecarias.FindControl("txtCedulasHipotecariasCedula");
            DropDownList ddlCedulasHipotecariasGradoGravamen = (DropDownList)this.CedulasHipotecarias.FindControl("ddlCedulasHipotecariasGradoGravamen");
            TextBox txtCedulasHipotecariasFechaVencimiento = (TextBox)this.CedulasHipotecarias.FindControl("txtCedulasHipotecariasFechaVencimiento");
            TextBox txtCedulasHipotecariasFechaPrescripcion = (TextBox)this.CedulasHipotecarias.FindControl("txtCedulasHipotecariasFechaPrescripcion");
            DropDownList ddlCedulasHipotecariasMoneda = (DropDownList)this.CedulasHipotecarias.FindControl("ddlCedulasHipotecariasMoneda");
            TextBox txtCedulasHipotecariasValorFacial = (TextBox)this.CedulasHipotecarias.FindControl("txtCedulasHipotecariasValorFacial");

            #endregion

            //VALIDA EL FORMATO DEL CAMPO SERIES
            if (!this.CedulasHipotecarias.ValidarSerie())
            {
                GarantiasRealesCedulasEntidad entidad = new GarantiasRealesCedulasEntidad();

                entidad.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                if (txtCedulasHipotecariasSerie != null)
                    entidad.Serie = txtCedulasHipotecariasSerie.Text;

                if (txtCedulasHipotecariasCedula != null)
                    entidad.Cedula = int.Parse(txtCedulasHipotecariasCedula.Text);

                if (ddlCedulasHipotecariasGradoGravamen != null)
                    entidad.IdGradoGravamen = int.Parse(ddlCedulasHipotecariasGradoGravamen.SelectedItem.Value);

                if (txtCedulasHipotecariasFechaVencimiento != null)
                    entidad.FechaVencimientoCedula = DateTime.Parse(txtCedulasHipotecariasFechaVencimiento.Text);

                if (txtCedulasHipotecariasFechaPrescripcion != null)
                    entidad.FechaPrescripcionCedula = DateTime.Parse(txtCedulasHipotecariasFechaPrescripcion.Text);

                if (ddlCedulasHipotecariasMoneda != null)
                    entidad.IdMoneda = int.Parse(ddlCedulasHipotecariasMoneda.SelectedItem.Value);

                if (txtCedulasHipotecariasValorFacial != null)
                    entidad.ValorFacial = decimal.Parse(txtCedulasHipotecariasValorFacial.Text);

                //Bloque 7 Requerimiento 1-24381561
                CrearControlRegistros(entidad);

                GarantiasWS.RespuestaEntidad resultado = wsGarantias.GarantiasRealesCedulasInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                if (resultado.ValorError.Equals(18))
                {
                    BloquearControlesDesactualizados();
                    BarraMensaje(resultado, pantallaIdOculto.Value);
                }

                GridViewCedulasInternoActualizar();
            }
            else
            {
                //MENSAJE DE ERROR POR FORMATO
                this.InformarBoxCedulasHipotecarias_SetConfirmationBoxEvent(sender, e, "SYS_9", "Serie", "XX-XXX");
                this.mpeInformarBoxCedulasHipotecarias.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region VENTANA ADMINISTRAR GRAVAMENES

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE ADMINISTRACION DE GRAVAMENES*/
    private void ObtenerValoresRegistroGravamenes(object sender, EventArgs e)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            DropDownList ddlGravamenGarantiaGradoGravamen = (DropDownList)this.VentanaGravamenesGarantias1.FindControl("ddlGravamenGarantiaGradoGravamen");
            DropDownList ddlGravamenGarantiaTipoMonedaMontoGravamen = (DropDownList)this.VentanaGravamenesGarantias1.FindControl("ddlGravamenGarantiaTipoMonedaMontoGravamen");
            TextBox txtGravamenGarantiaSaldoGradoGravamen = (TextBox)this.VentanaGravamenesGarantias1.FindControl("txtGravamenGarantiaSaldoGradoGravamen");
            TextBox txtGravamenGarantiaEntidadAcreedora = (TextBox)this.VentanaGravamenesGarantias1.FindControl("txtGravamenGarantiaEntidadAcreedora");
            HtmlInputHidden hdnGravamenGarantiaIdGravamenOculto = (HtmlInputHidden)this.VentanaGravamenesGarantias1.FindControl("hdnGravamenGarantiaIdGravamenOculto");

            #endregion

            GarantiasGravemenesEntidad entidad = new GarantiasGravemenesEntidad();

            entidad.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);
            entidad.IdGarantiaValor = null;

            if (ddlGravamenGarantiaGradoGravamen != null)
                entidad.IdGradoGravamen = int.Parse(ddlGravamenGarantiaGradoGravamen.SelectedItem.Value);

            if (ddlGravamenGarantiaTipoMonedaMontoGravamen != null)
                entidad.IdTipoMonedaMontoGravamen = int.Parse(ddlGravamenGarantiaTipoMonedaMontoGravamen.SelectedItem.Value);


            if (txtGravamenGarantiaSaldoGradoGravamen != null)
                entidad.SaldoGradoGravamen = decimal.Parse(txtGravamenGarantiaSaldoGradoGravamen.Text);

            if (txtGravamenGarantiaEntidadAcreedora != null)
                entidad.EntidadAcreedora = txtGravamenGarantiaEntidadAcreedora.Text;

            if (hdnGravamenGarantiaIdGravamenOculto != null)
                if (hdnGravamenGarantiaIdGravamenOculto.Value.Length > 0)
                    entidad.IdGravamen = int.Parse(hdnGravamenGarantiaIdGravamenOculto.Value);

            //Bloque 7 Requerimiento 1-24381561
            CrearControlRegistros(entidad);

            GarantiasWS.RespuestaEntidad resultado = null;

            if (entidad.IdGravamen.Equals(0))
                resultado = wsGarantias.GarantiasGravamenesInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));
            else
                resultado = wsGarantias.GarantiasGravamenesModificar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));

            //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
            if (resultado.ValorError.Equals(18))
            {
                BloquearControlesDesactualizados();
                BarraMensaje(resultado, pantallaIdOculto.Value);
            }

            //MENSAJE DE ERROR POR DUPLICAOD
            if (resultado.ValorError.Equals(2601))
            {
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SQL_2601");
                this.mpeInformarBox.Show();
            }

            //SI NO EXISTE ERROR
            if (resultado.ValorError.Equals(0))
            {
                GridViewGravamenesInternoActualizar();
                this.mpeGravamenesGarantias.Hide();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ASIGNACION DE VALORES AL POPUP DE GRAVAMENES SEGUN EL REGISTRO SELECCIONADO*/
    private void AsignarValoresRegistroGravamenes()
    {
        #region BUSQUEDA DE CONTROLES

        DropDownList ddlGravamenGarantiaGradoGravamen = (DropDownList)this.VentanaGravamenesGarantias1.FindControl("ddlGravamenGarantiaGradoGravamen");
        DropDownList ddlGravamenGarantiaTipoMonedaMontoGravamen = (DropDownList)this.VentanaGravamenesGarantias1.FindControl("ddlGravamenGarantiaTipoMonedaMontoGravamen");
        TextBox txtGravamenGarantiaSaldoGradoGravamen = (TextBox)this.VentanaGravamenesGarantias1.FindControl("txtGravamenGarantiaSaldoGradoGravamen");
        TextBox txtGravamenGarantiaEntidadAcreedora = (TextBox)this.VentanaGravamenesGarantias1.FindControl("txtGravamenGarantiaEntidadAcreedora");
        HtmlInputHidden hdnGravamenGarantiaIdGravamenOculto = (HtmlInputHidden)this.VentanaGravamenesGarantias1.FindControl("hdnGravamenGarantiaIdGravamenOculto");

        #endregion

        GarantiasGravemenesEntidad entidad = null;

        foreach (GridViewRow row1 in gridGravamenesInterno.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)gridGravamenesInterno.Rows[row1.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                Label lblId = (Label)gridGravamenesInterno.Rows[row1.RowIndex].FindControl("lblIdGravamen");

                entidad = new GarantiasGravemenesEntidad();
                entidad.IdGravamen = int.Parse(lblId.Text);

                break;
            }
        }

        if (entidad != null)
        {
            entidad = wsGarantias.GarantiasGravamenesConsultaDetalle(entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

            //ASIGNA LOS VALORES DESDE BD
            hdnGravamenGarantiaIdGravamenOculto.Value = entidad.IdGravamen.ToString();
            txtGravamenGarantiaSaldoGradoGravamen.Text = entidad.SaldoGradoGravamen.ToString();
            txtGravamenGarantiaEntidadAcreedora.Text = entidad.EntidadAcreedora;
            generadorControles.SeleccionarOpcionDropDownList(ddlGravamenGarantiaGradoGravamen, entidad.IdGradoGravamen.ToString());
            generadorControles.SeleccionarOpcionDropDownList(ddlGravamenGarantiaTipoMonedaMontoGravamen, entidad.IdTipoMonedaMontoGravamen.ToString());

            this.VentanaGravamenesGarantias1.DdlGravamenGarantiaTipoMonedaMontoGravamen();

            //MUESTRA EL POPUP
            this.mpeGravamenesGarantias.Show();
        }
    }

    #endregion

    //B16S01
    #region VENTANA ADMINISTRAR POLIZAS

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE ADMINISTRACION DE POLIZAS*/
    private void ObtenerValoresRegistroPolizas(object sender, EventArgs e)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            DropDownList ddlPolizaTipoPoliza = (DropDownList)this.VentanaPolizasGarantia1.FindControl("ddlPolizaTipoPoliza");
            TextBox txtPolizaNumSap = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaNumSap");
            TextBox txtPolizaNumPoliza = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaNumPoliza");
            TextBox txtPolizaFechaEmision = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaFechaEmision");
            TextBox txtPolizaFechaVencimiento = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaFechaVencimiento");
            DropDownList ddlPolizaTipoMoneda = (DropDownList)this.VentanaPolizasGarantia1.FindControl("ddlPolizaTipoMoneda");
            TextBox txtPolizaMontoPoliza = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaMontoPoliza");
            TextBox txtPolizaMontoPolizaColonizado = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaMontoPolizaColonizado");
            DropDownList ddlPolizaCobertura = (DropDownList)this.VentanaPolizasGarantia1.FindControl("ddlPolizaCobertura");
            DropDownList ddlPolizaTipoIdentificacion = (DropDownList)this.VentanaPolizasGarantia1.FindControl("ddlPolizaTipoIdentificacion");
            TextBox txtPolizaIdentificacion = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaIdentificacion");

            HtmlInputHidden hdnPolizaIdPolizaOculto = (HtmlInputHidden)this.VentanaPolizasGarantia1.FindControl("hdnPolizaIdPolizaOculto");

            #endregion

            PolizaEntidad entidad = new PolizaEntidad();

            entidad.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

            if (ddlPolizaTipoPoliza != null)
                entidad.IdTipoNivelPoliza = ddlPolizaTipoPoliza.SelectedItem.Value;

            if (ddlPolizaTipoMoneda != null)
                entidad.IdTipoMoneda = int.Parse(ddlPolizaTipoMoneda.SelectedItem.Value);

            if (ddlPolizaCobertura != null)
                entidad.IndCobertura = ddlPolizaCobertura.SelectedItem.Value;

            if (ddlPolizaTipoIdentificacion != null)
                entidad.IdTipoIdentificacionRUC = int.Parse(ddlPolizaTipoIdentificacion.SelectedItem.Value);

            if (txtPolizaNumSap != null)
                if (txtPolizaNumSap.Text.TrimEnd().TrimStart().Length > 0)
                    entidad.Nsap = long.Parse(txtPolizaNumSap.Text);

            if (txtPolizaNumPoliza != null)
                entidad.NPoliza = txtPolizaNumPoliza.Text;

            if (txtPolizaFechaEmision != null)
                entidad.FechaEmision = DateTime.Parse(txtPolizaFechaEmision.Text);

            if (txtPolizaFechaVencimiento != null)
                entidad.FechaVencimiento = DateTime.Parse(txtPolizaFechaVencimiento.Text);

            if (txtPolizaMontoPoliza != null)
                entidad.MontoPoliza = decimal.Parse(txtPolizaMontoPoliza.Text);

            //CAMPO SE GENERA EN LÍNEA POR LO TANTO NO SE GUARDA
            entidad.MontoPolizaColonizado = null;
            //if (txtPolizaMontoPolizaColonizado != null)
            //    entidad.MontoPolizaColonizado = decimal.Parse(txtPolizaMontoPolizaColonizado.Text);

            if (txtPolizaIdentificacion != null)
                entidad.Identificacion = txtPolizaIdentificacion.Text;

            if (hdnPolizaIdPolizaOculto != null)
                if (hdnPolizaIdPolizaOculto.Value.Length > 0)
                    entidad.IdPoliza = int.Parse(hdnPolizaIdPolizaOculto.Value);

            //Bloque 7 Requerimiento 1-24381561
            CrearControlRegistros(entidad);

            GarantiasWS.RespuestaEntidad resultado = null;

            //VALIDACION DE DATOS EN LOS CAMPOS NSAP Y NPOLIZA
            if (!(txtPolizaNumPoliza.Text.TrimEnd().TrimStart().Length.Equals(0) &&
                txtPolizaNumSap.Text.TrimEnd().TrimStart().Length.Equals(0)))
            {
                //VALIDACION DE CARACTERES ESPECIALES 
                if (!ValidarCaracterEspecial(txtPolizaNumPoliza.Text))
                {

                    if (entidad.IdPoliza.Equals(0))
                        resultado = wsGarantias.GarantiasRealesPolizaInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));
                    else
                        resultado = wsGarantias.GarantiasRealesPolizaModificar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));

                    //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                    if (resultado.ValorError.Equals(18))
                    {
                        BloquearControlesDesactualizados();
                        BarraMensaje(resultado, pantallaIdOculto.Value);
                    }

                    //MENSAJE DE ERROR POR DUPLICAOD
                    if (resultado.ValorError.Equals(2601))
                    {
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SQL_2601");
                        this.mpeInformarBox.Show();
                    }

                    //SI NO EXISTE ERROR
                    if (resultado.ValorError.Equals(0))
                    {
                        GridViewPolizasInternoActualizar();
                        this.mpePolizasGarantias.Hide();
                    }
                }
                else
                {
                    //ERROR CARACTERES ESPECIALES
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_2");
                    this.mpeInformarBox.Show();
                }
            }
            else
            {
                //ERROR AL MENOS UNO DE LOS CAMPOS N° SAP O N° PÓLIZA DEBE TENER VALOR
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_41");
                this.mpeInformarBox.Show();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ASIGNACION DE VALORES AL POPUP DE POLIZAS SEGUN EL REGISTRO SELECCIONADO*/
    private void AsignarValoresRegistroPolizas()
    {
        #region BUSQUEDA DE CONTROLES

        DropDownList ddlPolizaTipoPoliza = (DropDownList)this.VentanaPolizasGarantia1.FindControl("ddlPolizaTipoPoliza");
        TextBox txtPolizaNumSap = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaNumSap");
        TextBox txtPolizaNumPoliza = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaNumPoliza");
        TextBox txtPolizaFechaEmision = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaFechaEmision");
        TextBox txtPolizaFechaVencimiento = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaFechaVencimiento");
        DropDownList ddlPolizaTipoMoneda = (DropDownList)this.VentanaPolizasGarantia1.FindControl("ddlPolizaTipoMoneda");
        TextBox txtPolizaMontoPoliza = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaMontoPoliza");
        TextBox txtPolizaMontoPolizaColonizado = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaMontoPolizaColonizado");
        DropDownList ddlPolizaCobertura = (DropDownList)this.VentanaPolizasGarantia1.FindControl("ddlPolizaCobertura");
        DropDownList ddlPolizaTipoIdentificacion = (DropDownList)this.VentanaPolizasGarantia1.FindControl("ddlPolizaTipoIdentificacion");
        TextBox txtPolizaIdentificacion = (TextBox)this.VentanaPolizasGarantia1.FindControl("txtPolizaIdentificacion");

        HtmlInputHidden hdnPolizaIdPolizaOculto = (HtmlInputHidden)this.VentanaPolizasGarantia1.FindControl("hdnPolizaIdPolizaOculto");

        #endregion

        PolizaEntidad entidad = null;

        foreach (GridViewRow row1 in gridPolizasInterno.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)gridPolizasInterno.Rows[row1.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                Label lblId = (Label)gridPolizasInterno.Rows[row1.RowIndex].FindControl("lblIdPoliza");

                entidad = new PolizaEntidad();
                entidad.IdPoliza = int.Parse(lblId.Text);

                break;
            }
        }

        if (entidad != null)
        {
            entidad = wsGarantias.GarantiasRealesPolizaConsultaDetalle(entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

            //ASIGNA LOS VALORES DESDE BD
            hdnPolizaIdPolizaOculto.Value = entidad.IdPoliza.ToString();
            generadorControles.SeleccionarOpcionDropDownList(ddlPolizaTipoPoliza, entidad.IdTipoNivelPoliza.ToString());
            this.VentanaPolizasGarantia1.DdlPolizaTipoPoliza();
            txtPolizaNumSap.Text = entidad.Nsap.ToString();
            txtPolizaNumPoliza.Text = entidad.NPoliza;
            txtPolizaFechaEmision.Text = entidad.FechaEmision.ToShortDateString();
            txtPolizaFechaVencimiento.Text = entidad.FechaVencimiento.ToShortDateString();
            generadorControles.SeleccionarOpcionDropDownList(ddlPolizaTipoMoneda, entidad.IdTipoMoneda.ToString());
            txtPolizaMontoPoliza.Text = entidad.MontoPoliza.ToString();
            this.VentanaPolizasGarantia1.DdlPolizaTipoMoneda();
            generadorControles.SeleccionarOpcionDropDownList(ddlPolizaCobertura, entidad.IndCobertura.ToUpper().Equals("TRUE") ? "1" : "0");
            generadorControles.SeleccionarOpcionDropDownList(ddlPolizaTipoIdentificacion, entidad.IdTipoIdentificacionRUC.ToString());
            txtPolizaIdentificacion.Text = entidad.Identificacion;
            this.VentanaPolizasGarantia1.ObtenerDatosCliente();

            //MUESTRA EL POPUP
            this.mpePolizasGarantias.Show();
        }
    }

    #endregion

    #region ADMINISTRACION TASADORES

    /*CONSULTA GRID ADMINISTRACION TASADORES*/
    private List<GarantiasRealesTasadoresEntidad> ConsultaTasadoresInterno(int filtro)
    {
        try
        {
            List<GarantiasRealesTasadoresEntidad> retorno = null;
            retorno = wsGarantias.GarantiasRealesTasadoresConsultarGridInterno(filtro).ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewTasadoresInterno(object sender, EventArgs e)
    {
        try
        {
            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridTasadoresInterno = (GridView)this.grdTasadores.FindControl("MasterGridView");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridTasadoresInterno.Init += new EventHandler(gridTasadoresInterno_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridTasadoresInterno_Init(sender, e);

            //ASIGNA DATA KEYS
            String[] dataKeysString = { "IdGarantiaRealTasador" };
            this.SetDataKeys(gridTasadoresInterno, dataKeysString);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ACTUALIZA LOS DATOS DEL GRIDVIEW ADMINISTRACION TASADORES*/
    private void GridViewTasadoresInternoActualizar()
    {
        int idGarantiaReal = 0;

        if (!this.hdnIdGeneral.Value.Length.Equals(0))
            idGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

        this.grdTasadores.BindGridView(this.ConsultaTasadoresInterno(idGarantiaReal));
    }

    #endregion

    #region GRIDVIEW INTERNO ADMINISTRACION TASADORES

    private void gridTasadoresInterno_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridTasadoresInterno, "IdGarantiaRealTasador", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridTasadoresInterno.Columns.Add(gridViewColumn.CreateBoundField("DesTipoPersona", string.Empty, "Tipo Persona", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridTasadoresInterno.Columns.Add(gridViewColumn.CreateBoundField("CodTasador", string.Empty, "Id Tasador", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridTasadoresInterno.Columns.Add(gridViewColumn.CreateBoundField("DesNombreTasador", string.Empty, "Nombre Tasador", HorizontalAlign.Center, false, true));

        TemplateField lblID2 = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridTasadoresInterno, "Id_Visible", lblID2);
    }

    #endregion

    #region ADMINISTRACION CEDULAS

    /*CONSULTA GRID ADMINISTRACION CEDULAS*/
    private List<GarantiasRealesCedulasEntidad> ConsultaCedulasInterno(int filtro)
    {
        try
        {
            List<GarantiasRealesCedulasEntidad> retorno = null;
            retorno = wsGarantias.GarantiasRealesCedulasConsultarGridInterno(filtro).ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewCedulasInterno(object sender, EventArgs e)
    {
        try
        {
            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridCedulasInterno = (GridView)this.grdCedulas.FindControl("MasterGridView");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridCedulasInterno.Init += new EventHandler(gridCedulasInterno_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridCedulasInterno_Init(sender, e);

            //ASIGNA DATA KEYS
            String[] dataKeysString = { "IdGarantiaRealCedula" };
            this.SetDataKeys(gridCedulasInterno, dataKeysString);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ACTUALIZA LOS DATOS DEL GRIDVIEW ADMINISTRACION CEDULAS*/
    private void GridViewCedulasInternoActualizar()
    {
        int idGarantiaReal = 0;

        if (!this.hdnIdGeneral.Value.Length.Equals(0))
            idGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

        this.grdCedulas.BindGridView(this.ConsultaCedulasInterno(idGarantiaReal));

        this.txtCantidadCedulas.Text = this.grdCedulas.ContadorElementos().ToString();
        this.txtValorTotalFacial.Text = this.grdCedulas.SumarElementos("ValorFacial").ToString();
    }

    #endregion

    #region GRIDVIEW INTERNO ADMINISTRACION CEDULAS

    private void gridCedulasInterno_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridCedulasInterno, "IdGarantiaRealCedula", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("Serie", string.Empty, "Serie", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("Cedula", string.Empty, "Cédula", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("DesGradoGravamen", string.Empty, "Grado Gravamen", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("FechaVencimientoCedula", "{0:d}", "Vencimiento", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("FechaPrescripcionCedula", "{0:d}", "Prescripción", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("DesMoneda", string.Empty, "Moneda", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridCedulasInterno.Columns.Add(gridViewColumn.CreateBoundField("ValorFacial", string.Empty, "Valor Facial", HorizontalAlign.Center, false, true));

        TemplateField lblID2 = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridCedulasInterno, "Id_Visible", lblID2);
    }

    #endregion

    #region ADMINISTRACION GRAVAMENES

    /*CONSULTA GRID ADMINISTRACION GRAVAMENES*/
    private List<GarantiasGravemenesEntidad> ConsultaGravamenesInterno(GarantiasGravemenesEntidad filtro)
    {
        try
        {
            List<GarantiasGravemenesEntidad> retorno = null;
            retorno = wsGarantias.GarantiasGravamenesConsultarGridInterno(filtro).ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewGravamenesInterno(object sender, EventArgs e)
    {
        try
        {
            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridGravamenesInterno = (GridView)this.grdGravamenes.FindControl("MasterGridView");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridGravamenesInterno.Init += new EventHandler(gridGravamenesInterno_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridGravamenesInterno_Init(sender, e);

            //ASIGNA DATA KEYS
            String[] dataKeysString = { "IdGravamen" };
            this.SetDataKeys(gridGravamenesInterno, dataKeysString);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ACTUALIZA LOS DATOS DEL GRIDVIEW ADMINISTRACION GRAVAMENES*/
    private void GridViewGravamenesInternoActualizar()
    {
        GarantiasGravemenesEntidad garantia = new GarantiasGravemenesEntidad();
        garantia.IdGarantiaReal = 0;
        garantia.IdGarantiaValor = 0;

        if (!this.hdnIdGeneral.Value.Length.Equals(0))
            garantia.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

        this.grdGravamenes.BindGridView(this.ConsultaGravamenesInterno(garantia));
    }

    #endregion

    #region GRIDVIEW INTERNO ADMINISTRACION GRAVAMENES

    private void gridGravamenesInterno_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridGravamenesInterno, "IdGravamen", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridGravamenesInterno.Columns.Add(gridViewColumn.CreateBoundField("DesGradoGravamen", string.Empty, "Grado Gravamen", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridGravamenesInterno.Columns.Add(gridViewColumn.CreateBoundField("DesTipoMonedaMontoGravamen", string.Empty, "Tipo Moneda Monto Gravamen", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridGravamenesInterno.Columns.Add(gridViewColumn.CreateBoundField("SaldoGradoGravamen", "{0:N}", "Saldo Grado Gravamen", HorizontalAlign.Center, false, true));

        TemplateField lblID2 = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridGravamenesInterno, "Id_Visible", lblID2);
    }

    #endregion

    //B16S01
    #region ADMINISTRACION POLIZAS

    /*CONSULTA GRID ADMINISTRACION POLIZAS*/
    private List<PolizaEntidad> ConsultaGravamenesInterno(PolizaEntidad filtro)
    {
        try
        {
            List<PolizaEntidad> retorno = null;
            retorno = wsGarantias.GarantiasRealesPolizaGridInterno(filtro).ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewPolizasInterno(object sender, EventArgs e)
    {
        try
        {
            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridPolizasInterno = (GridView)this.grdPolizas.FindControl("MasterGridView");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridPolizasInterno.Init += new EventHandler(gridPolizasInterno_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridPolizasInterno_Init(sender, e);

            //ASIGNA DATA KEYS
            String[] dataKeysString = { "IdPoliza" };
            this.SetDataKeys(gridPolizasInterno, dataKeysString);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ACTUALIZA LOS DATOS DEL GRIDVIEW ADMINISTRACION POLIZAS*/
    private void GridViewPolizasInternoActualizar()
    {
        PolizaEntidad poliza = new PolizaEntidad();
        poliza.IdGarantiaReal = 0;

        if (!this.hdnIdGeneral.Value.Length.Equals(0))
            poliza.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

        this.grdPolizas.BindGridView(this.ConsultaGravamenesInterno(poliza));
    }

    #endregion

    #region GRIDVIEW INTERNO ADMINISTRACION POLIZAS

    private void gridPolizasInterno_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridPolizasInterno, "IdPoliza", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridPolizasInterno.Columns.Add(gridViewColumn.CreateBoundField("IdTipoNivelPoliza", string.Empty, "Tipo Póliza", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridPolizasInterno.Columns.Add(gridViewColumn.CreateBoundField("Nsap", string.Empty, "N° SAP", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridPolizasInterno.Columns.Add(gridViewColumn.CreateBoundField("NPoliza", string.Empty, "N° Póliza", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridPolizasInterno.Columns.Add(gridViewColumn.CreateBoundField("FechaEmision", "{0:d}", "Fecha Emisión", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridPolizasInterno.Columns.Add(gridViewColumn.CreateBoundField("FechaVencimiento", "{0:d}", "Fecha Vencimiento", HorizontalAlign.Center, false, true));

        TemplateField lblID2 = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridPolizasInterno, "Id_Visible", lblID2);
    }

    #endregion

    #region CONTROLES

    private void CargaArregloControles()
    {
        try
        {
            ListasWS.PantallasEntidad pantalla = new ListasWS.PantallasEntidad();
            pantalla.CodPantalla = int.Parse(pantallaModuloOculto.Value);
            pantalla.Pestana = string.Empty;

            //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD        
            controlEntidad = this.wsListas.AdministracionesContenidosConsultaControl(pantalla).ToList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void Efectos()
    {
        DdlTiposBienes();

        //EFECTO DEL DLL IND GRAVAMEN - SECCION GRAVAMENES
        EfectoDdlIndGravamen();

        //B16S01
        //EFECTO DEL DLL IND POLIZA - SECCION POLIZAS
        EfectoDdlIndPoliza();
    }

    /*EFECTO DEL DLL IND GRAVAMEN - SECCION GRAVAMENES*/
    private void EfectoDdlIndGravamen()
    {
        if (gridGravamenesInterno != null)
        {
            if (gridGravamenesInterno.Rows.Count > 0)
                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndGravamen, "SI");
            else
                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndGravamen, "NO");
        }
    }

    /*EFECTO DEL DLL IND POLIZA - SECCION POLIZAS*/
    private void EfectoDdlIndPoliza()
    {
        //B16S01
        if (gridPolizasInterno != null)
        {
            if (gridPolizasInterno.Rows.Count > 0)
                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndPoliza, "SI");
            else
                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndPoliza, "NO");
        }

        if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("1 -"))
            this.ddlIndPoliza.Enabled = false;
    }

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
                List<NodoMenuEntidad> menu = new List<NodoMenuEntidad>();
                NodoMenuEntidad nodo = new NodoMenuEntidad();
                nodo.Nombre = "General";
                nodo.Url = "Tab1";
                menu.Add(nodo);

                nodo = new NodoMenuEntidad();
                nodo.Nombre = "Valuación";
                nodo.Url = "Tab2";
                menu.Add(nodo);

                nodo = new NodoMenuEntidad();
                nodo.Nombre = "Tasadores";
                nodo.Url = "Tab3";
                menu.Add(nodo);

                nodo = new NodoMenuEntidad();
                nodo.Nombre = "Cédulas";
                nodo.Url = "Tab4";
                menu.Add(nodo);

                nodo = new NodoMenuEntidad();
                nodo.Nombre = "Gravámenes";
                nodo.Url = "Tab5";
                menu.Add(nodo);

                //B16S01
                nodo = new NodoMenuEntidad();
                nodo.Nombre = "Póliza";
                nodo.Url = "Tab6";
                menu.Add(nodo);


                // LLAMA AL METODO DE CREAR LOS CONTROLES DEL TAB CONTAINER
                ((wucMenuLateralDetalle)this.Master.FindControl("MenuLateral1")).CargarArbol(menu);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LAS DESCRIPCIONES DE LAS ETIQUETAS DE LOS CAMPOS*/
    private void ControlesNombre()
    {
        try
        {
            #region SECCION GENERAL

            //LBL TIPOS DE BIENES
            controlSeleccionado = ControlesBuscar(this.lblTipoBien.ID);
            this.lblTipoBien.Text = controlSeleccionado.DesColumna;

            //LBL CLASES
            controlSeleccionado = ControlesBuscar(this.lblClase.ID);
            this.lblClase.Text = controlSeleccionado.DesColumna;

            //LBL PROVINCIA
            controlSeleccionado = ControlesBuscar(this.lblProvincia.ID);
            this.lblProvincia.Text = controlSeleccionado.DesColumna;

            //LBL HORIZONTALES
            controlSeleccionado = ControlesBuscar(this.lblHorizontal.ID);
            this.lblHorizontal.Text = controlSeleccionado.DesColumna;

            //Control de Cambios 1.1
            //CHK ESTADO HORIZONTAL
            controlSeleccionado = ControlesBuscar(this.chkEstadoHorizontal.ID);
            this.chkEstadoHorizontal.Text = controlSeleccionado.DesColumna;

            //LBL DUPLICADOS
            controlSeleccionado = ControlesBuscar(this.lblDuplicado.ID);
            this.lblDuplicado.Text = controlSeleccionado.DesColumna;

            //Control de Cambios 1.1
            //CHK ESTADO DUPLICADO
            controlSeleccionado = ControlesBuscar(this.chkEstadoDuplicado.ID);
            this.chkEstadoDuplicado.Text = controlSeleccionado.DesColumna;

            //LBL CLASE BUQUE
            controlSeleccionado = ControlesBuscar(this.lblClaseBuque.ID);
            this.lblClaseBuque.Text = controlSeleccionado.DesColumna;

            //LBL CLASE AERONAVE
            controlSeleccionado = ControlesBuscar(this.lblClaseAeronave.ID);
            this.lblClaseAeronave.Text = controlSeleccionado.DesColumna;

            //LBL CLASE VEHICULO    
            controlSeleccionado = ControlesBuscar(this.lblClaseVehiculo.ID);
            this.lblClaseVehiculo.Text = controlSeleccionado.DesColumna;

            //LBL FORMATO IDENTIFICACION VEHICULO  
            controlSeleccionado = ControlesBuscar(this.lblFormato.ID);
            this.lblFormato.Text = controlSeleccionado.DesColumna;

            //LBL NUMERO BIEN 
            controlSeleccionado = ControlesBuscar(this.lblNBien.ID);
            this.lblNBien.Text = controlSeleccionado.DesColumna;

            //BTN VALIDAR
            controlSeleccionado = ControlesBuscar(this.btnValidar.ID);
            this.btnValidar.Text = controlSeleccionado.DesColumna;

            #endregion

            #region VALUACION

            //LBL TIPO MONEDA
            controlSeleccionado = ControlesBuscar(this.lblTipoMoneda.ID);
            this.lblTipoMoneda.Text = controlSeleccionado.DesColumna;

            //LBL MONTO ULTIMA TASACION TERRENO
            controlSeleccionado = ControlesBuscar(this.lblMontoUltimaTasacionTerreno.ID);
            this.lblMontoUltimaTasacionTerreno.Text = controlSeleccionado.DesColumna;

            //LBL MONTO ULTIMA TASACION NO TERRENO
            controlSeleccionado = ControlesBuscar(this.lblMontoUltimaTasacionNoTerreno.ID);
            this.lblMontoUltimaTasacionNoTerreno.Text = controlSeleccionado.DesColumna;

            //LBL MONTO TOTAL ULTIMA TASACION
            controlSeleccionado = ControlesBuscar(this.lblMontoTotalUltimaTasacion.ID);
            this.lblMontoTotalUltimaTasacion.Text = controlSeleccionado.DesColumna;

            //LBL MONTO TASACION ACTUALIZADA TERRENO
            controlSeleccionado = ControlesBuscar(this.lblMontoTasacionActualizadaTerreno.ID);
            this.lblMontoTasacionActualizadaTerreno.Text = controlSeleccionado.DesColumna;

            //LBL MONTO TASACION ACTUALIZADA NO TERRENO
            controlSeleccionado = ControlesBuscar(this.lblMontoTasacionActualizadaNoTerreno.ID);
            this.lblMontoTasacionActualizadaNoTerreno.Text = controlSeleccionado.DesColumna;

            //LBL MONTO TOTAL ULTIMA TASACION ACTUALIZADA
            controlSeleccionado = ControlesBuscar(this.lblMontoTotalUltimaTasacionActualizada.ID);
            this.lblMontoTotalUltimaTasacionActualizada.Text = controlSeleccionado.DesColumna;

            //LBL LIQUIDEZ GARANTIA
            controlSeleccionado = ControlesBuscar(this.lblLiquidezGarantia.ID);
            this.lblLiquidezGarantia.Text = controlSeleccionado.DesColumna;

            //LBL FECHA CONSTRUCCION GARANTIA
            controlSeleccionado = ControlesBuscar(this.lblFechaConstruccionGarantia.ID);
            this.lblFechaConstruccionGarantia.Text = controlSeleccionado.DesColumna;

            //LBL FECHA ULTIMA TASACION GARANTIA    
            controlSeleccionado = ControlesBuscar(this.lblFechaUltimaTasacionGarantia.ID);
            this.lblFechaUltimaTasacionGarantia.Text = controlSeleccionado.DesColumna;

            //LBL FECHA ULTIMO SEGUIMIENTO GARANTIA   
            controlSeleccionado = ControlesBuscar(this.lblFechaUltimoSeguimientoGarantia.ID);
            this.lblFechaUltimoSeguimientoGarantia.Text = controlSeleccionado.DesColumna;

            //LBL FECHA VENCIMIENTO AVALUO SUGEF
            controlSeleccionado = ControlesBuscar(this.lblFechaVencimientoAvaluo.ID);
            this.lblFechaVencimientoAvaluo.Text = controlSeleccionado.DesColumna;

            //LBL FECHA FABRICACION GARANTIA
            controlSeleccionado = ControlesBuscar(this.lblFechaFabricacionGarantia.ID);
            this.lblFechaFabricacionGarantia.Text = controlSeleccionado.DesColumna;

            //LBL TIPO ALMACEN
            controlSeleccionado = ControlesBuscar(this.lblTipoAlmacen.ID);
            this.lblTipoAlmacen.Text = controlSeleccionado.DesColumna;

            //LBL ESTADO GARANTIA
            controlSeleccionado = ControlesBuscar(this.lblEstadoGarantia.ID);
            this.lblEstadoGarantia.Text = controlSeleccionado.DesColumna;

            #endregion

            #region TASADORES

            //LBL TIPO TASADOR
            controlSeleccionado = ControlesBuscar(this.lblTipoTasador.ID);
            this.lblTipoTasador.Text = controlSeleccionado.DesColumna;

            //LBL ADMINISTRAR EMPRESA TASADORA
            controlSeleccionado = ControlesBuscar(this.lblAdministrarEmpresaTasadora.ID);
            this.lblAdministrarEmpresaTasadora.Text = controlSeleccionado.DesColumna;

            //LBL TIPO PERSONA EMPRESA TASADORA
            controlSeleccionado = ControlesBuscar(this.lblTipoPersonaEmpresaTasadora.ID);
            this.lblTipoPersonaEmpresaTasadora.Text = controlSeleccionado.DesColumna;

            //LBL ID EMPRESA TASADORA
            controlSeleccionado = ControlesBuscar(this.lblIdEmpresaTasadora.ID);
            this.lblIdEmpresaTasadora.Text = controlSeleccionado.DesColumna;

            //LBL NOMBRE EMPRESA TASADORA
            controlSeleccionado = ControlesBuscar(this.lblNombreEmpresaTasadora.ID);
            this.lblNombreEmpresaTasadora.Text = controlSeleccionado.DesColumna;

            //LBL ADMINISTRAR TASADORES
            controlSeleccionado = ControlesBuscar(this.lblAdministrarTasadores.ID);
            this.lblAdministrarTasadores.Text = controlSeleccionado.DesColumna;

            //BTN LIMPIAR
            controlSeleccionado = ControlesBuscar(this.btnLimpiar.ID);
            this.btnLimpiar.Text = controlSeleccionado.DesColumna;

            #endregion

            #region CEDULAS

            //LBL VALOR TOTAL CEDULAS
            controlSeleccionado = ControlesBuscar(this.lblValorTotalCedulas.ID);
            this.lblValorTotalCedulas.Text = controlSeleccionado.DesColumna;

            //LBL CANTIDAD CEDULAS
            controlSeleccionado = ControlesBuscar(this.lblCantidadCedulas.ID);
            this.lblCantidadCedulas.Text = controlSeleccionado.DesColumna;

            //LBL VALOR TOTAL FACIAL
            controlSeleccionado = ControlesBuscar(this.lblValorTotalFacial.ID);
            this.lblValorTotalFacial.Text = controlSeleccionado.DesColumna;

            #endregion

            #region GRAVAMENES

            //DDL IND GRAVAMEN
            controlSeleccionado = ControlesBuscar(this.ddlIndGravamen.ID);
            this.lblIndGravamen.Text = controlSeleccionado.DesColumna;

            #endregion

            //B16S01
            #region POLIZAS

            //DDL IND POLIZA
            controlSeleccionado = ControlesBuscar(this.ddlIndPoliza.ID);
            this.lblIndPoliza.Text = controlSeleccionado.DesColumna;

            //DDL JUSTIFICACION
            controlSeleccionado = ControlesBuscar(this.txtJustificacion.ID);
            this.lblJustificacion.Text = controlSeleccionado.DesColumna;

            #endregion

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
            ControlEntidad controlRetorno = (from control in controlEntidad
                                             where control.NombrePropiedad.Equals(nombreControl)
                                             select control).First();

            return controlRetorno;
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
            //DDL TIPOS DE BIENES
            controlSeleccionado = ControlesBuscar(this.ddlTipoBien.ID);
            this.ddlTipoBien.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoBien.DataTextField = "Texto";
            this.ddlTipoBien.DataValueField = "Valor";
            this.ddlTipoBien.DataBind();
            this.ddlTipoBien.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoBien, controlSeleccionado.ValorDefecto);

            //DDL CLASE
            DdlClases(this.ddlTipoBien.SelectedItem.Value);

            //DDL FORMATO IDENTIFICACION VEHICULO
            CargarFormatoIdentificacionVehiculo(this.ddlTipoBien.SelectedItem.Text);

            ////EFECTO DE AUTOCOMPLETAR PARA EL CAMPO N BIEN 
            ////this.txtNBien.Attributes.Add("onblur", "AutoCompletar('ctl00_ContentPlaceHolder1_txtNBien','ctl00_ContentPlaceHolder1_ddlTipoBien','ctl00_ContentPlaceHolder1_ddlFormato','0')");
            //this.txtNBien.Attributes.Add("onblur", "AutoCompletar('" + this.txtNBien.ClientID + "','" + this.ddlTipoBien.ClientID + "','" + this.ddlFormato.ClientID + "','0')");

            //VALOR SELECCIONADO EN EL TIPO BIEN (X -)
            string valorTipoBien = this.ddlTipoBien.SelectedItem.Text.Substring(0, 3);
            //VALOR SELECCIONADO EN EL TIPO BIEN (XX -)
            string valorTipoBien2 = this.ddlTipoBien.SelectedItem.Text.Substring(0, 4);

            if (valorTipoBien.Equals("3 -") || valorTipoBien.Equals("9 -") || valorTipoBien2.Equals("10 -"))
            {
                this.txtNBien.Attributes.Add("onblur", "AutoCompletar('" + this.txtNBien.ClientID + "','" + this.ddlTipoBien.ClientID + "','" + this.ddlFormato.ClientID + "','0')");
            }

            //DDL PROVINCIAS
            controlSeleccionado = ControlesBuscar(this.ddlProvincia.ID);
            this.ddlProvincia.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlProvincia.DataTextField = "Texto";
            this.ddlProvincia.DataValueField = "Valor";
            this.ddlProvincia.DataBind();
            this.ddlProvincia.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlProvincia, controlSeleccionado.ValorDefecto);

            //DLL HORIZONTALIDADES
            controlSeleccionado = ControlesBuscar(this.ddlHorizontal.ID);
            this.ddlHorizontal.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlHorizontal.DataTextField = "Texto";
            this.ddlHorizontal.DataValueField = "Valor";
            this.ddlHorizontal.DataBind();
            this.ddlHorizontal.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlHorizontal, controlSeleccionado.ValorDefecto);

            //DLL CODIGOS DUPLICADOS
            controlSeleccionado = ControlesBuscar(this.ddlDuplicado.ID);
            this.ddlDuplicado.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlDuplicado.DataTextField = "Texto";
            this.ddlDuplicado.DataValueField = "Valor";
            this.ddlDuplicado.DataBind();
            this.ddlDuplicado.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlDuplicado, controlSeleccionado.ValorDefecto);

            //DDL CLASES BUQUES        
            controlSeleccionado = ControlesBuscar(this.ddlClaseBuque.ID);
            this.ddlClaseBuque.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlClaseBuque.DataTextField = "Texto";
            this.ddlClaseBuque.DataValueField = "Valor";
            this.ddlClaseBuque.DataBind();
            this.ddlClaseBuque.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlClaseBuque, controlSeleccionado.ValorDefecto);

            //DDL CLASES AERONAVES  
            controlSeleccionado = ControlesBuscar(this.ddlClaseAeronave.ID);
            this.ddlClaseAeronave.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlClaseAeronave.DataTextField = "Texto";
            this.ddlClaseAeronave.DataValueField = "Valor";
            this.ddlClaseAeronave.DataBind();
            this.ddlClaseAeronave.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlClaseAeronave, controlSeleccionado.ValorDefecto);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EXTRAE LOS CONTROLES DESDE BD PARA LA SECCION DE VALUACION*/
    private void ControlesValuacion()
    {
        try
        {
            string valorTipoBien = string.Empty;
            string valorTipoBien2 = string.Empty;

            valorTipoBien = this.ddlTipoBien.SelectedItem.Text.Substring(0, 3);
            valorTipoBien2 = this.ddlTipoBien.SelectedItem.Text.Substring(0, 4);

            //DDL TIPOS MONEDAS
            controlSeleccionado = ControlesBuscar(this.ddlTipoMoneda.ID);
            this.ddlTipoMoneda.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoMoneda.DataTextField = "Texto";
            this.ddlTipoMoneda.DataValueField = "Valor";
            this.ddlTipoMoneda.DataBind();
            this.ddlTipoMoneda.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoMoneda, controlSeleccionado.ValorDefecto);

            //DDL TIPOS LIQUIDEZ
            controlSeleccionado = ControlesBuscar(this.ddlLiquidezGarantia.ID);
            this.ddlLiquidezGarantia.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlLiquidezGarantia.DataTextField = "Texto";
            this.ddlLiquidezGarantia.DataValueField = "Valor";
            this.ddlLiquidezGarantia.DataBind();
            this.ddlLiquidezGarantia.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlLiquidezGarantia, controlSeleccionado.ValorDefecto);

            //DDL ESTADO GARANTIA
            controlSeleccionado = ControlesBuscar(this.ddlEstadoGarantia.ID);
            //SE CARGAN LOS DATOS FILTRADOS POR TIPO GARANTIA ( 2 = REALES )
            this.ddlEstadoGarantia.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, "2");
            this.ddlEstadoGarantia.DataTextField = "Texto";
            this.ddlEstadoGarantia.DataValueField = "Valor";
            this.ddlEstadoGarantia.DataBind();
            this.ddlEstadoGarantia.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlEstadoGarantia, controlSeleccionado.ValorDefecto);

            //CALENDARIO FECHA ULTIMA TASACION GARANTIA
            this.calendarExtenderFechaUltimaTasacionGarantia.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();

            //CALENDARIO FECHA ULTIMO SEGUIMIENTO GARANTIA
            this.calendarExtenderFechaUltimoSeguimientoGarantia.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();

            //CALENDARIO FECHA FABRICACION GARANTIA
            this.calendarFechaFabricacionGarantia.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();

            //B15S04
            this.txtMontoTasacionActualizadaNoTerreno.Enabled = false;
            this.rfvMontoTasacionActualizadaNoTerreno.Enabled = false;
            this.txtMontoTasacionActualizadaTerreno.Enabled = false;
            this.rfvMontoTasacionActualizadaTerreno.Enabled = false;


            if (valorTipoBien.Equals("1 -"))
            {
                //TXT MONTO ULTIMA TASACION NO TERRENO
                this.mskMontoUltimaTasacionNoTerreno.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();
                this.txtMontoUltimaTasacionNoTerreno.Enabled = false;
                this.rfvMontoUltimaTasacionNoTerreno.Enabled = false;

                //TXT MONTO TASACION ACTUALIZADA NO TERRENO
                //B15S04
                //this.mskMontoTasacionActualizadaNoTerreno.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();
                //this.txtMontoTasacionActualizadaNoTerreno.Enabled = false;
                //this.rfvMontoTasacionActualizadaNoTerreno.Enabled = false;
            }
            else
            {
                //TXT MONTO ULTIMA TASACION NO TERRENO
                this.txtMontoUltimaTasacionNoTerreno.Enabled = true;
                this.rfvMontoUltimaTasacionNoTerreno.Enabled = true;

                //TXT MONTO TASACION ACTUALIZADA NO TERRENO
                //B15S04
                //this.txtMontoTasacionActualizadaNoTerreno.Enabled = true;
                //this.rfvMontoTasacionActualizadaNoTerreno.Enabled = true;
            }

            if (valorTipoBien.Equals("2 -"))
            {
                //CALENDARIO FECHA CONSTITUCION GARANTIA
                this.calendarExtenderFechaConstruccionGarantia.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();
                this.txtFechaConstruccionGarantia.Enabled = true;
                this.imbFechaConstruccionGarantia.Enabled = true;
                this.rfvFechaConstruccionGarantia.Enabled = true;
            }
            else
            {
                //CALENDARIO FECHA CONSTITUCION GARANTIA
                this.txtFechaConstruccionGarantia.Enabled = false;
                this.imbFechaConstruccionGarantia.Enabled = false;
                this.rfvFechaConstruccionGarantia.Enabled = false;
            }

            if (valorTipoBien.Equals("1 -") || valorTipoBien.Equals("2 -"))
            {
                //TXT MONTO ULTIMA TASACION TERRENO
                this.mskMontoUltimaTasacionTerreno.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();
                this.txtMontoUltimaTasacionTerreno.Enabled = true;
                this.rfvMontoUltimaTasacionTerreno.Enabled = true;

                //TXT MONTO TASACION ACTUALIZADA TERRENO
                //B15S04
                //this.mskMontoTasacionActualizadaTerreno.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();
                //this.txtMontoTasacionActualizadaTerreno.Enabled = true;
                //this.rfvMontoTasacionActualizadaTerreno.Enabled = true;
            }
            else
            {
                //TXT MONTO ULTIMA TASACION TERRENO
                this.txtMontoUltimaTasacionTerreno.Enabled = false;
                this.rfvMontoUltimaTasacionTerreno.Enabled = false;

                //TXT MONTO TASACION ACTUALIZADA TERRENO
                //B15S04
                //this.txtMontoTasacionActualizadaTerreno.Enabled = false;
                //this.rfvMontoTasacionActualizadaTerreno.Enabled = false;
            }

            if (valorTipoBien.Equals("3 -") || valorTipoBien.Equals("4 -") || valorTipoBien.Equals("5 -") || valorTipoBien.Equals("9 -") || valorTipoBien2.Equals("10 -"))
            {
                //TXT FECHA FABRICACION GARANTIA
                this.txtFechaFabricacionGarantia.Enabled = true;
                this.imbFechaFabricacionGarantia.Enabled = true;
                this.rfvFechaFabricacionGarantia.Enabled = true;
            }
            else
            {
                //TXT FECHA FABRICACION GARANTIA
                this.txtFechaFabricacionGarantia.Enabled = false;
                this.imbFechaFabricacionGarantia.Enabled = false;
                this.rfvFechaFabricacionGarantia.Enabled = false;
            }

            //Control de Cambios 1.1
            //DDL TIPO ALMACEN POR DEFECTO DESHABILITADO A MENOS QUE SEA IGUAL A TIPO BIEN 3 CLASE BONO DE PRENDA
            this.ddlTipoAlmacen.Enabled = false;
            if (valorTipoBien.Equals("3 -") && this.ddlClase.SelectedItem.Text.ToUpper().Equals("BONO DE PRENDA"))
            {
                this.txtFechaFabricacionGarantia.Text = string.Empty;
                this.txtFechaFabricacionGarantia.Enabled = false;
                this.imbFechaFabricacionGarantia.Enabled = false;
                this.rfvFechaFabricacionGarantia.Enabled = false;

                //DDL TIPO ALMACEN
                controlSeleccionado = ControlesBuscar(this.ddlTipoAlmacen.ID);
                this.ddlTipoAlmacen.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
                this.ddlTipoAlmacen.DataTextField = "Texto";
                this.ddlTipoAlmacen.DataValueField = "Valor";
                this.ddlTipoAlmacen.DataBind();
                this.ddlTipoAlmacen.CssClass = controlSeleccionado.CssTipo;
                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoAlmacen, controlSeleccionado.ValorDefecto);
                this.ddlTipoAlmacen.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EXTRAE LOS CONTROLES DESDE BD PARA LA SECCION DE TASADORES*/
    private void ControlesTasadores()
    {
        try
        {
            //DDL TIPO TASADOR
            this.ddlTipoTasador.Items.Clear();
            this.ddlTipoTasador.SelectedValue = null;
            this.ddlTipoTasador.Items.Add(new ListItem("Empresa", "1"));
            this.ddlTipoTasador.Items.Add(new ListItem("Persona(s)", "2"));

            //EJECUTA LAS FUNCIONES DE TIPO TASADOR
            DdlTiposTasadores();

            //GRID ADMINISTRACION TASADORES
            GridViewTasadoresInternoActualizar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EXTRAE LOS CONTROLES DESDE BD PARA LA SECCION DE CEDULAS*/
    private void ControlesCedulas()
    {
        //GRID ADMINISTRACION CEDULAS
        GridViewCedulasInternoActualizar();
    }

    /*EXTRAE LOS CONTROLES DESDE BD PARA LA SECCION DE GRAVAMENES*/
    private void ControlesGravamenes()
    {
        try
        {
            this.ddlIndGravamen.Items.Clear();
            this.ddlIndGravamen.SelectedValue = null;
            controlSeleccionado = ControlesBuscar(this.ddlIndGravamen.ID);

            this.ddlIndGravamen.DataTextField = "Texto";
            this.ddlIndGravamen.DataValueField = "Valor";
            this.ddlIndGravamen.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlIndGravamen.DataBind();

            if (!this.hdnIdGeneral.Value.Equals("0"))
                this.ddlIndGravamen.Enabled = true;

            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndGravamen, controlSeleccionado.ValorDefecto);

            GridViewGravamenesInternoActualizar();

            EfectoDdlIndGravamen();

            //EJECUTA LAS FUNCIONES DE IND GRAVAMEN
            DdlIndGravamen();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EXTRAE LOS CONTROLES DESDE BD PARA LA SECCION DE POLIZAS*/
    private void ControlesPolizas()
    {
        try
        {
            this.ddlIndPoliza.Items.Clear();
            this.ddlIndPoliza.SelectedValue = null;
            controlSeleccionado = ControlesBuscar(this.ddlIndGravamen.ID);

            this.ddlIndPoliza.DataTextField = "Texto";
            this.ddlIndPoliza.DataValueField = "Valor";
            this.ddlIndPoliza.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlIndPoliza.DataBind();

            if (!this.hdnIdGeneral.Value.Equals("0"))
                this.ddlIndPoliza.Enabled = true;

            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndPoliza, controlSeleccionado.ValorDefecto);

            GridViewPolizasInternoActualizar();

            EfectoDdlIndPoliza();

            //EJECUTA LAS FUNCIONES DE IND POLIZA
            DdlIndPoliza();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*LIMPIA LOS CONTROLES TIPO TEXTBOX*/
    private void Limpiar()
    {
        #region SECCION GENERAL

        if (this.txtClaseVehiculo.Enabled)
        {
            this.txtClaseVehiculo.Text = string.Empty;
            this.txtDesClaseVehiculo.Text = string.Empty;
            this.hdnIdClaseVehiculo.Value = string.Empty;
        }

        if (this.txtNBien.Enabled)
            this.txtNBien.Text = string.Empty;

        #endregion

        #region SECCION VALUACION

        this.txtMontoTotalUltimaTasacion.Text = string.Empty;
        this.txtMontoUltimaTasacionTerreno.Text = string.Empty;
        this.txtMontoUltimaTasacionNoTerreno.Text = string.Empty;

        this.txtMontoTotalUltimaTasacionActualizada.Text = string.Empty;
        this.txtMontoTasacionActualizadaTerreno.Text = string.Empty;
        this.txtMontoTasacionActualizadaNoTerreno.Text = string.Empty;

        this.txtFechaFabricacionGarantia.Text = string.Empty;
        this.txtFechaVencimientoAvaluo.Text = string.Empty;
        this.txtFechaUltimoSeguimientoGarantia.Text = string.Empty;
        this.txtFechaUltimaTasacionGarantia.Text = string.Empty;
        this.txtFechaConstruccionGarantia.Text = string.Empty;

        #endregion

        #region SECCION CEDULAS

        if (this.txtValorTotalCedulas.Enabled)
            this.txtValorTotalCedulas.Text = string.Empty;

        #endregion

        #region SECCION POLIZAS

        if (this.txtJustificacion.Enabled)
            this.txtJustificacion.Text = string.Empty;

        #endregion

        LimpiarBarraMensaje();
    }

    /*LIMPIA LOS CONTROLES TIPO TEXTBOX*/
    private void LimpiarEmpresaTasadora()
    {
        try
        {
            //Control de Cambios 1.5 Garantias Reales II
            //ELIMINACION DEL REGISTRO DE LA EMPRESA TASADORA

            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (this.hdnIdEmpresaTasadora.Value.Length > 0)
            {
                GarantiasRealesTasadoresEntidad _empresaTasador = new GarantiasRealesTasadoresEntidad();
                _empresaTasador.IdGarantiaRealTasador = int.Parse(this.hdnIdEmpresaTasadora.Value);
                _empresaTasador.CodUsuarioIngreso = codUsuarioOculto.Value;
                respuesta = wsGarantias.GarantiasRealesTasadoresEliminar(_empresaTasador, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));
            }

            //GARANTIA DESACTUALIZADA
            if (respuesta.ValorError.Equals(18))
            {
                BloquearControlesDesactualizados();
                BarraMensaje(respuesta, pantallaIdOculto.Value);
            }
            else
            {
                //SE HABILITA EL BOTON DE BUSQUEDA
                this.imbAdministrarEmpresaTasadora.Enabled = true;

                //SE LIMPIAN LOS VALORES DE EMPRESA TASADORA
                this.txtIdEmpresaTasadora.Text = string.Empty;
                this.hdnIdEmpresaTasadora.Value = string.Empty;
                //this.lblEmpresaTasadora.Text = string.Empty;
                this.txtNombreEmpresaTasadora.Text = string.Empty;
                generadorControles.LimpiarDropDownList(this.ddlTipoPersonaEmpresaTasadora);
                AdministrarBlanco(this.ddlTipoPersonaEmpresaTasadora.ID, true);
                //SE HABILITA EL COMBO DE TIPO TASADOR
                this.ddlTipoTasador.Enabled = true;
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
        try
        {
            if (pantallaModuloOculto.Value != null && !pantallaIdOculto.Value.Equals("0")) //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            {
                this.hdnIdGeneral.Value = pantallaIdOculto.Value;

                //CARGA LOS VALORES DESDE BD
                DeEntidadAControlesGeneral();
                //DESHABILITA LA SECCION GENERAL
                AdministrarControlesExcepcionesGeneral(false);

                //HABILITA LA SECCION VALUACIÓN
                AdministrarControlesExcepcionesValuacion(true);
                //CARGA LOS CONTROLES DE LA SECCION VALUACION
                ControlesValuacion();
                //CARGA LOS VALORES DESDE BD
                DeEntidadAControlesValuacion();

                //HABILITA SECCION VALUACIÓN
                AdministrarControlesExcepcionesTasadores(true);
                //CARGA LOS CONTROLES DE LA SECCION TASADORES
                ControlesTasadores();
                //CARGA LOS VALORES DESDE BD
                DeEntidadAControlesTasadores();

                //CARGA LOS VALORES DESDE BD
                DeEntidadAControlesCedulas();

                //CARGA LA SECCION DE GRAVAMENES
                ControlesGravamenes();

                //B16S01
                //CARGA LA SECCION DE POLIZAS
                ControlesPolizas();
                //CARGA LOS VALORES DESDE BD
                DeEntidadAControlesPolizas();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES PARA LA SECCION GENERAL DESDE BD PARA EL CASO DE LAS MODIFICACIONES */
    private void DeEntidadAControlesGeneral()
    {
        try
        {
            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null && !pantallaIdOculto.Value.Equals("0"))
            {
                GarantiasRealesEntidad entidadConsulta = new GarantiasRealesEntidad();
                entidadConsulta.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                GarantiasRealesEntidad entidadRetorno = wsGarantias.GarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                if (entidadRetorno != null)
                {
                    //Requerimiento Bloque 7 1-24381561 
                    ObtenerControlRegistros(entidadRetorno);

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlTipoBien, entidadRetorno.IdTipoBien.ToString());
                    DdlTiposBienes();

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlClase, entidadRetorno.IdClaseTipoBien.ToString());

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlProvincia, entidadRetorno.IdProvincia.ToString());

                    //Control de Cambios 1.1
                    //_generadorControles.SeleccionarOpcionDropDownList(this.ddlHorizontal, _entidadRetorno.IdCodigoHorizontalidad.ToString());
                    //_generadorControles.SeleccionarOpcionDropDownList(this.ddlDuplicado, _entidadRetorno.IdCodigoDuplicado.ToString());

                    if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("1 -") || this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                    {
                        if (entidadRetorno.IdCodigoHorizontalidad == null)
                        {
                            AdministrarBlanco(this.ddlHorizontal.ID, true);
                            this.chkEstadoHorizontal.Checked = true;
                        }
                        else
                        {
                            generadorControles.SeleccionarOpcionDropDownList(this.ddlHorizontal, entidadRetorno.IdCodigoHorizontalidad.ToString());
                            this.chkEstadoHorizontal.Checked = false;
                        }

                        if (entidadRetorno.IdCodigoDuplicado == null)
                        {
                            AdministrarBlanco(this.ddlDuplicado.ID, true);
                            this.chkEstadoDuplicado.Checked = true;
                        }
                        else
                        {
                            generadorControles.SeleccionarOpcionDropDownList(this.ddlDuplicado, entidadRetorno.IdCodigoDuplicado.ToString());
                            this.chkEstadoDuplicado.Checked = false;
                        }
                    }
                    else
                    {
                        generadorControles.SeleccionarOpcionDropDownList(this.ddlHorizontal, entidadRetorno.IdCodigoHorizontalidad.ToString());
                        generadorControles.SeleccionarOpcionDropDownList(this.ddlDuplicado, entidadRetorno.IdCodigoDuplicado.ToString());
                    }

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlClaseBuque, entidadRetorno.IdClaseBuque.ToString());
                    generadorControles.SeleccionarOpcionDropDownList(this.ddlClaseAeronave, entidadRetorno.IdClaseAeronave.ToString());

                    this.hdnIdClaseVehiculo.Value = entidadRetorno.IdClaseVehiculo.ToString();
                    this.txtDesClaseVehiculo.Text = entidadRetorno.DesClaseVehiculo;

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlFormato, entidadRetorno.FormatoIdentificacionVehiculo.ToString());
                    DdlFormatoIdentificacionVehiculo();

                    this.txtNBien.Text = entidadRetorno.CodBien;

                    this.txtValorTotalCedulas.Text = entidadRetorno.MontoValorTotalCedula.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES PARA LA SECCION VALUACION DESDE BD PARA EL CASO DE LAS MODIFICACIONES */
    private void DeEntidadAControlesValuacion()
    {
        try
        {
            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null && !pantallaIdOculto.Value.Equals("0"))
            {
                GarantiasRealesEntidad entidadConsulta = new GarantiasRealesEntidad();
                entidadConsulta.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                GarantiasRealesEntidad entidadRetorno = wsGarantias.GarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                if (entidadRetorno != null)
                {
                    this.txtMontoUltimaTasacionTerreno.Text = entidadRetorno.MontoUltimaTasacionTerreno.ToString();
                    this.txtMontoUltimaTasacionNoTerreno.Text = entidadRetorno.MontoUltimaTasacionNoTerreno.ToString();
                    this.txtMontoTasacionActualizadaTerreno.Text = entidadRetorno.MontoTasacionActualizadaTerreno.ToString();
                    this.txtMontoTasacionActualizadaNoTerreno.Text = entidadRetorno.MontoTasacionActualizadaNoTerreno.ToString();
                    generadorControles.SeleccionarOpcionDropDownList(this.ddlLiquidezGarantia, entidadRetorno.IdTipoLiquidez.ToString());

                    if (entidadRetorno.FechaConstruccionGarantia.ToString().Length > 0)
                        this.txtFechaConstruccionGarantia.Text = DateTime.Parse(entidadRetorno.FechaConstruccionGarantia.ToString()).ToShortDateString();

                    if (entidadRetorno.FechaUltimaTasacionGarantia.ToString().Length > 0)
                        this.txtFechaUltimaTasacionGarantia.Text = DateTime.Parse(entidadRetorno.FechaUltimaTasacionGarantia.ToString()).ToShortDateString();

                    if (entidadRetorno.FechaUltimoSeguimientoGarantia.ToString().Length > 0)
                        this.txtFechaUltimoSeguimientoGarantia.Text = DateTime.Parse(entidadRetorno.FechaUltimoSeguimientoGarantia.ToString()).ToShortDateString();

                    if (entidadRetorno.FechaVencimientoAvaluoSUGEF.ToString().Length > 0)
                        this.txtFechaVencimientoAvaluo.Text = DateTime.Parse(entidadRetorno.FechaVencimientoAvaluoSUGEF.ToString()).ToShortDateString();

                    if (entidadRetorno.FechaFabricacionGarantia.ToString().Length > 0)
                        this.txtFechaFabricacionGarantia.Text = DateTime.Parse(entidadRetorno.FechaFabricacionGarantia.ToString()).ToShortDateString();

                    this.txtMontoTotalUltimaTasacion.Text = generadorControles.SumarRetornoString(txtMontoUltimaTasacionTerreno.Text, txtMontoUltimaTasacionNoTerreno.Text);
                    this.txtMontoTotalUltimaTasacionActualizada.Text = generadorControles.SumarRetornoString(txtMontoTasacionActualizadaTerreno.Text, txtMontoTasacionActualizadaNoTerreno.Text);

                    this.txtFechaFabricacionGarantia.Enabled = false;
                    this.imbFechaFabricacionGarantia.Enabled = false;

                    if (entidadRetorno.IdTipoAlmacen.ToString().Length > 0)
                    {
                        generadorControles.SeleccionarOpcionDropDownList(this.ddlTipoAlmacen, entidadRetorno.IdTipoAlmacen.ToString());
                        this.ddlTipoAlmacen.Enabled = false;
                    }

                    if (entidadRetorno.IdEstadoGarantia.ToString().Length > 0)
                        generadorControles.SeleccionarOpcionDropDownList(this.ddlEstadoGarantia, entidadRetorno.IdEstadoGarantia.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES PARA LA SECCION TASADORES DESDE BD PARA EL CASO DE LAS MODIFICACIONES */
    private void DeEntidadAControlesTasadores()
    {
        try
        {
            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null)
            {
                GarantiasRealesTasadoresEntidad entidadConsulta = new GarantiasRealesTasadoresEntidad();
                entidadConsulta.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                List<GarantiasRealesTasadoresEntidad> entidadRetorno = wsGarantias.GarantiasRealesTasadoresPersonasTasadorasConsultaDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR)).ToList();

                if (entidadRetorno != null)
                {
                    if (entidadRetorno.Count > 0)
                    {
                        //SE EXTRAE EL ORIGEN DEL TASADOR    E = EMPRESA | P = PERSONA
                        string tipoTasador = (from entidad in entidadRetorno
                                              select entidad.OrigenTasador).First();

                        //SI EL TASADOR ES DEL TIPO EMPRESA SE DEBE DE ASIGNAR EL UNICO VALOR A LAS CAJAS DE TEXTO
                        if (tipoTasador.Equals("E"))
                        {
                            foreach (GarantiasRealesTasadoresEntidad tasador in entidadRetorno)
                            {
                                //Control de Cambios 1.5 Garantias Reales II
                                /*
                                this.hdnIdEmpresaTasadora.Value = tasador.IdTasador.ToString();
                                 */
                                this.hdnIdEmpresaTasadora.Value = tasador.IdGarantiaReal.ToString();

                                this.txtIdEmpresaTasadora.Text = tasador.CodTasador;
                                this.txtNombreEmpresaTasadora.Text = tasador.DesNombreTasador;
                                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoTasador, "Empresa");

                                //DDL TIPO PERSONA EMPRESA TASADORA
                                controlSeleccionado = ControlesBuscar(this.ddlTipoPersonaEmpresaTasadora.ID);
                                this.ddlTipoPersonaEmpresaTasadora.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
                                this.ddlTipoPersonaEmpresaTasadora.DataTextField = "Texto";
                                this.ddlTipoPersonaEmpresaTasadora.DataValueField = "Valor";
                                this.ddlTipoPersonaEmpresaTasadora.DataBind();
                                this.ddlTipoPersonaEmpresaTasadora.CssClass = controlSeleccionado.CssTipo;

                                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoPersonaEmpresaTasadora, tasador.DesTipoPersona);
                            }
                            //EFECTUA LOS EFECTOS DEL DDL TIPO TASADOR
                            DdlTiposTasadores();

                            if (!pantallaIdOculto.Value.Equals("0"))
                            {
                                //Control de Cambios 1.5 Garantias Reales
                                /*this.imbAdministrarEmpresaTasadora.Enabled = false;
                                this.btnLimpiar.Enabled = false;
                                this.ddlTipoTasador.Enabled = false;*/
                                this.imbAdministrarEmpresaTasadora.Enabled = false;
                                this.btnLimpiar.Enabled = true;
                                this.ddlTipoTasador.Enabled = false;

                            }
                        }
                        else
                        {
                            //SI EL TASADOR ES DEL TIPO PERSONA SE DEBE MOSTRAR LOS VALORES DEL GRID DE ADMINISTRACION DE TASADOR
                            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoTasador, "Persona(s)");
                            this.ddlTipoTasador.Enabled = false;
                            GridViewTasadoresInternoActualizar();

                            //EFECTUA LOS EFECTOS DEL DDL TIPO TASADOR
                            DdlTiposTasadores();

                            if (!pantallaIdOculto.Value.Equals("0"))
                            {
                                //Control de Cambios 1.5 Garantias Reales II
                                /*this.imgAgregarTasador.Enabled = true;
                                this.imgEliminarTasador.Enabled = false;
                                this.gridTasadoresInterno.Enabled = false;*/
                                this.btnAgregarTasador.Enabled = true;
                                this.btnEliminarTasador.Enabled = true;

                            }
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

    /*CARGA LOS VALORES PARA LA SECCION CEDULAS DESDE BD PARA EL CASO DE LAS MODIFICACIONES */
    private void DeEntidadAControlesCedulas()
    {
        try
        {
            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null)
            {
                //HABILITA LA SECCION DE CEDULAS
                if (this.ddlClase.SelectedItem.Text.Equals("Cédula Hipotecaria"))
                {
                    //HABILITA LA SECCION DE CEDULAS
                    AdministrarControlesExcepcionesCedulas(true);
                    //CARGA LOS CONTROLES DE LA SECCION CEDULAS
                    ControlesCedulas();
                }
                else
                {
                    //DESHABILITA LA SECCION DE CEDULAS
                    AdministrarControlesExcepcionesCedulas(false);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES PARA LA SECCION POLIZAS DESDE BD PARA EL CASO DE LAS MODIFICACIONES */
    private void DeEntidadAControlesPolizas()
    {
        try
        {
            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null)
            {
                GarantiasRealesEntidad entidadConsulta = new GarantiasRealesEntidad();
                entidadConsulta.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                GarantiasRealesEntidad entidadRetorno = wsGarantias.GarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                if (entidadRetorno != null)
                {
                    //B16S01
                    this.txtJustificacion.Text = entidadRetorno.Justificacion;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE LOS CONTROLES DE LA SECCION GENERAL, VALUACION, CEDULAS Y POLIZAS HACIA LA ENTIDAD PARA REALIZAR ACCIONES*/
    private GarantiasRealesEntidad DeControlesAEntidadGeneralValuacionCedulasPolizas()
    {
        try
        {
            GarantiasRealesEntidad reales = null;

            if (pantallaModuloOculto.Value.Length > 0)
            {
                reales = new GarantiasRealesEntidad();

                #region SECCION GENERAL

                reales.IdTipoBien = int.Parse(this.ddlTipoBien.SelectedItem.Value);

                if (this.hdnIdGeneral.Value.Length < 1)
                    reales.IdGarantiaReal = 0;
                else
                    reales.IdGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                if (this.ddlClase.SelectedItem.Value.Equals("-1"))
                    reales.IdClaseTipoBien = null;
                else
                    reales.IdClaseTipoBien = int.Parse(this.ddlClase.SelectedItem.Value);

                if (this.ddlProvincia.SelectedItem.Value.Equals("-1"))
                    reales.IdProvincia = null;
                else
                    reales.IdProvincia = int.Parse(this.ddlProvincia.SelectedItem.Value);

                if (this.ddlHorizontal.SelectedItem.Value.Equals("-1"))
                    reales.IdCodigoHorizontalidad = null;
                else
                    reales.IdCodigoHorizontalidad = int.Parse(this.ddlHorizontal.SelectedItem.Value);

                if (this.ddlDuplicado.SelectedItem.Value.Equals("-1"))
                    reales.IdCodigoDuplicado = null;
                else
                    reales.IdCodigoDuplicado = int.Parse(this.ddlDuplicado.SelectedItem.Value);

                if (this.ddlClaseBuque.SelectedItem.Value.Equals("-1"))
                    reales.IdClaseBuque = null;
                else
                    reales.IdClaseBuque = int.Parse(this.ddlClaseBuque.SelectedItem.Value);

                if (this.ddlClaseAeronave.SelectedItem.Value.Equals("-1"))
                    reales.IdClaseAeronave = null;
                else
                    reales.IdClaseAeronave = int.Parse(this.ddlClaseAeronave.SelectedItem.Value);

                if (this.hdnIdClaseVehiculo.Value.Length < 1)
                    reales.IdClaseVehiculo = null;
                else
                    reales.IdClaseVehiculo = int.Parse(this.hdnIdClaseVehiculo.Value);

                if (this.ddlFormato.SelectedItem.Value.Equals("-1"))
                    reales.FormatoIdentificacionVehiculo = null;
                else
                    reales.FormatoIdentificacionVehiculo = int.Parse(this.ddlFormato.SelectedItem.Value);

                if (this.txtNBien.Text.Length < 1)
                    reales.CodBien = string.Empty;
                else
                    reales.CodBien = this.txtNBien.Text;

                #endregion

                #region SECCION VALUACION

                if (this.ddlTipoMoneda.Items.Count.Equals(0))
                    reales.IdTipoMoneda = null;
                else
                {
                    if (this.ddlTipoMoneda.SelectedItem.Value.Equals("-1"))
                        reales.IdTipoMoneda = null;
                    else
                        reales.IdTipoMoneda = int.Parse(this.ddlTipoMoneda.SelectedItem.Value);
                }

                if (this.txtMontoUltimaTasacionTerreno.Text.Length < 1)
                    reales.MontoUltimaTasacionTerreno = null;
                else
                    reales.MontoUltimaTasacionTerreno = decimal.Parse(this.txtMontoUltimaTasacionTerreno.Text);

                if (this.txtMontoUltimaTasacionNoTerreno.Text.Length < 1)
                    reales.MontoUltimaTasacionNoTerreno = null;
                else
                    reales.MontoUltimaTasacionNoTerreno = decimal.Parse(this.txtMontoUltimaTasacionNoTerreno.Text);

                if (this.txtMontoTasacionActualizadaTerreno.Text.Length < 1)
                    reales.MontoTasacionActualizadaTerreno = null;
                else
                    reales.MontoTasacionActualizadaTerreno = decimal.Parse(this.txtMontoTasacionActualizadaTerreno.Text);

                if (this.txtMontoTasacionActualizadaNoTerreno.Text.Length < 1)
                    reales.MontoTasacionActualizadaNoTerreno = null;
                else
                    reales.MontoTasacionActualizadaNoTerreno = decimal.Parse(this.txtMontoTasacionActualizadaNoTerreno.Text);

                if (this.ddlLiquidezGarantia.Items.Count.Equals(0))
                    reales.IdTipoLiquidez = null;
                else
                {
                    if (this.ddlLiquidezGarantia.SelectedItem.Value.Equals("-1"))
                        reales.IdTipoLiquidez = null;
                    else
                        reales.IdTipoLiquidez = int.Parse(this.ddlLiquidezGarantia.SelectedItem.Value);
                }

                if (this.txtFechaConstruccionGarantia.Text.Length < 1)
                    reales.FechaConstruccionGarantia = null;
                else
                    reales.FechaConstruccionGarantia = DateTime.Parse(this.txtFechaConstruccionGarantia.Text);

                if (this.txtFechaUltimaTasacionGarantia.Text.Length < 1)
                    reales.FechaUltimaTasacionGarantia = null;
                else
                    reales.FechaUltimaTasacionGarantia = DateTime.Parse(this.txtFechaUltimaTasacionGarantia.Text);

                if (this.txtFechaUltimoSeguimientoGarantia.Text.Length < 1)
                    reales.FechaUltimoSeguimientoGarantia = null;
                else
                    reales.FechaUltimoSeguimientoGarantia = DateTime.Parse(this.txtFechaUltimoSeguimientoGarantia.Text);

                if (this.txtFechaVencimientoAvaluo.Text.Length < 1)
                    reales.FechaVencimientoAvaluoSUGEF = null;
                else
                    reales.FechaVencimientoAvaluoSUGEF = DateTime.Parse(this.txtFechaVencimientoAvaluo.Text);

                if (this.txtFechaFabricacionGarantia.Text.Length < 1)
                    reales.FechaFabricacionGarantia = null;
                else
                    reales.FechaFabricacionGarantia = DateTime.Parse(this.txtFechaFabricacionGarantia.Text);

                if (this.ddlEstadoGarantia.Items.Count > 0)
                {
                    if (this.ddlEstadoGarantia.SelectedValue.Equals("-1"))
                        reales.IdEstadoGarantia = null;
                    else
                        reales.IdEstadoGarantia = int.Parse(this.ddlEstadoGarantia.SelectedValue);
                }

                if (this.ddlTipoAlmacen.Items.Count > 0)
                {
                    if (this.ddlTipoAlmacen.SelectedValue.Equals("-1"))
                        reales.IdTipoAlmacen = null;
                    else
                        reales.IdTipoAlmacen = int.Parse(this.ddlTipoAlmacen.SelectedValue);
                }

                #endregion

                #region SECCION CEDULAS

                if (this.txtValorTotalCedulas.Text.Length < 1)
                    reales.MontoValorTotalCedula = null;
                else
                    reales.MontoValorTotalCedula = decimal.Parse(this.txtValorTotalCedulas.Text);

                #endregion

                //B16S01
                #region SECCION POLIZAS

                if (this.txtJustificacion.Enabled)
                    reales.Justificacion = this.txtJustificacion.Text;

                #endregion

                //Requerimiento Bloque 7 1-24381561
                CrearControlRegistros(reales);
            }

            return reales;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE LOS CONTROLES DE LA SECCION TASADORES HACIA LA ENTIDAD PARA REALIZAR ACCIONES*/
    private GarantiasRealesTasadoresEntidad DeControlesAEntidadTasadores()
    {
        try
        {
            GarantiasRealesTasadoresEntidad realesTasadores = null;

            if (pantallaModuloOculto.Value.Length > 0)
            {
                realesTasadores = new GarantiasRealesTasadoresEntidad();

                realesTasadores.IdTasador = int.Parse(hdnIdEmpresaTasadora.Value);
                realesTasadores.IdGarantiaReal = int.Parse(hdnIdGeneral.Value);

                //Requerimiento Bloque 7 1-24381561
                CrearControlRegistros(realesTasadores);
            }

            return realesTasadores;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Control de Cambios 1.2
    /*CARGA LOS CONTROLES AL NO EXISTIR ERROR EN LA VALIDACION DEL GARANTIA REAL*/
    private void CargarControlesSinError()
    {
        try
        {
            LimpiarBarraMensaje();

            //DESHABILITA LA SECCION GENERAL
            AdministrarControlesExcepcionesGeneral(false);

            //HABILITA LOS CONTROLES DE GUARDADO
            DeshabilitarControlesGuardar(false);

            //HABILITA LA SECCION VALUACIÓN
            AdministrarControlesExcepcionesValuacion(true);
            //CARGA LOS CONTROLES DE LA SECCION VALUACION
            ControlesValuacion();

            //HABILITA LA SECCION DE TASADORES
            AdministrarControlesExcepcionesTasadores(true);
            //CARGA LOS CONTROLES DE LA SECCION TASADORES
            ControlesTasadores();

            //HABILITA LA SECCION DE CEDULAS
            if (this.ddlClase.SelectedItem.Text.Equals("Cédula Hipotecaria"))
            {
                //HABILITA LA SECCION DE CEDULAS
                AdministrarControlesExcepcionesCedulas(true);
                //CARGA LOS CONTROLES DE LA SECCION CEDULAS
                ControlesCedulas();
            }


            //HABILITA LA SECCIÓN DE GRAVAMENES
            AdministrarControlesExcepcionesGravamenes(true);
            //CARGA LOS CONTROLES DE LA SECCION GRAVAMENES
            ControlesGravamenes();

            //B16S01
            //HABILITA LA SECCIÓN DE POLIZAS
            AdministrarControlesExcepcionesPolizas(true);
            //CARGA LOS CONTROLES DE LA SECCION POLIZAS
            ControlesPolizas();

            DeEntidadAControlesTasadores();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region VALIDACIONES

    /*VALIDACION DE CARACTERES ESPECIALES*/
    private bool ValidarCaracterEspecial(string texto)
    {
        bool existeCaracter = false;
        //NO SE PERMITEN CARACTERES ESPECIALES
        var regexItem = new Regex("^[a-zA-Z0-9-]*$");

        if (!regexItem.IsMatch(texto))
            existeCaracter = true;

        return existeCaracter;
    }

    private bool ValidarCaracterEspecialAmpliado(string texto)
    {
        bool existeCaracter = false;
        //NO SE PERMITEN CARACTERES ESPECIALES 
        var regexItem = new Regex("^[a-zA-Z0-9 \\,\\-\\,\\.ÁÉÍÓÚÑáéíóúñ]*$");

        if (!regexItem.IsMatch(texto))
            existeCaracter = true;

        return existeCaracter;
    }

    //Control de Cambios FI 2016
    private void AutoCompletarNBien(bool texto)
    {
        if (texto)
        {
            this.txtNBien.Attributes.Add("onblur", "AutoCompletar('" + this.txtNBien.ClientID + "','" + this.ddlTipoBien.ClientID + "','" + this.ddlFormato.ClientID + "','0')");
        }
        else
        {
            this.txtNBien.Attributes.Add("onblur", "");
        }
    }

    /*VALIDACION DEL FORMATO DEL N BIEN */
    private List<KeyValuePair<string, bool>> ValidarNumeroBien()
    {
        List<KeyValuePair<string, bool>> retorno = new List<KeyValuePair<string, bool>>();

        var regex6Numerico = new Regex(@"^\d{6}$");
        var regex3letras3numeros = new Regex(@"^[a-zA-Z]{3}\d{3}$");

        //Control de Cambios 1.1
        var regex17alfanumericosFijo = new Regex(@"^([a-zA-Z]|\d){17}$");
        var regex17alfanumericos = new Regex(@"^([a-zA-Z]|\d){1,17}$");

        //Control de Cambios FI 2016
        var regex6NumericoNoFijo = new Regex(@"^\d{1,6}$");

        var regexLetras = new Regex("^[a-zA-Z]*$");

        bool existeError = false; // FALSE - NO | TRUE - SI
        bool existeErrorSoloLetras = false; // FALSE - NO | TRUE - SI

        //VALOR SELECCIONADO EN EL TIPO BIEN (X -)
        string valorTipoBien = this.ddlTipoBien.SelectedItem.Text.Substring(0, 3);
        //VALOR SELECCIONADO EN EL TIPO BIEN (XX -)
        string valorTipoBien2 = this.ddlTipoBien.SelectedItem.Text.Substring(0, 4);

        //VALOR SELECCIONADO EN EL FORMATO DE IDENTIFICACION VEHICULO
        string valorFormatoIdentificacion = this.ddlFormato.SelectedItem.Text;

        if (valorTipoBien.Equals("1 -") || valorTipoBien.Equals("2 -"))
        {
            //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES NO FIJOS
            if (!regex6NumericoNoFijo.IsMatch(this.txtNBien.Text))
            {
                existeError = true;
            }
        }
        else
        {
            if (valorTipoBien.Equals("9 -") || valorTipoBien2.Equals("10 -"))
            {
                //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES
                if (!regex6Numerico.IsMatch(this.txtNBien.Text))
                {
                    existeError = true;
                }
            }
            else
            {
                if (!valorTipoBien.Equals("3 -"))
                {
                    //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES
                    if (!regex17alfanumericos.IsMatch(this.txtNBien.Text))
                    {
                        existeError = true;
                    }

                    //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES PERO NO DEBEN SER SOLO LETRAS
                    if (regexLetras.IsMatch(this.txtNBien.Text))
                    {
                        existeError = true;
                        existeErrorSoloLetras = true;
                    }
                }
            }
        }

        if (valorTipoBien.Equals("3 -"))
        {
            if (valorFormatoIdentificacion.Equals("Numérico 6 enteros"))
            {
                //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES
                if (!regex6Numerico.IsMatch(this.txtNBien.Text))
                {
                    existeError = true;
                }
            }
            else
            {
                if (valorFormatoIdentificacion.Equals("Alfanumérico 3 letras y 3 enteros"))
                {
                    //VERIFICACION DEL FORMATO 3 LETRAS Y 3 NUMEROS
                    if (!regex3letras3numeros.IsMatch(this.txtNBien.Text))
                    {
                        existeError = true;
                    }
                }
                else
                {
                    //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES
                    if (!regex17alfanumericosFijo.IsMatch(this.txtNBien.Text))
                    {
                        existeError = true;
                    }

                    //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES PERO NO DEBEN SER SOLO LETRAS
                    if (regexLetras.IsMatch(this.txtNBien.Text))
                    {
                        existeError = true;
                        existeErrorSoloLetras = true;
                    }
                }
            }
        }

        retorno.Add(new KeyValuePair<string, bool>("errorFormato", existeError));
        retorno.Add(new KeyValuePair<string, bool>("errorLetras", existeErrorSoloLetras));

        return retorno;
    }

    /*VALIDA QUE AL MENOS EXISTA UN REGISTRO EN A SECCION DE ADMINISTRAR TASADOR*/
    private bool ValidarSeccionTasadores()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        if (this.hdnIdEmpresaTasadora.Value.Length.Equals(0) && this.grdTasadores.ContadorElementos().Equals(0))
        {
            existeError = true;

            //MENSAJE DE ERROR DE REQUERIDO
            valorReemplazo = "la sección " + this.lblTasadores.Text;
            this.InformarBox1_SetConfirmationBoxEvent(null, null, "Requerido");
            this.mpeInformarBox.Show();
        }

        return existeError;
    }

    /*VALIDA QUE AL MENOS EXISTA UN REGISTRO EN A SECCION DE ADMINISTRAR CEDULAS Y QUE EL VALOR TOTAL CEDULAS SEA IGUAL AL VALOR TOTAL FACIAL*/
    private bool ValidarSeccionCedulas()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        if (this.ddlClase.SelectedItem.Text.Equals("Cédula Hipotecaria"))
        {
            //VALIDACION DE CANTIDAD DE REGISTROS INSERTADOS
            if (this.grdCedulas.ContadorElementos().Equals(0))
            {
                existeError = true;

                //MENSAJE DE ERROR DE REQUERIDO
                valorReemplazo = "la sección " + this.lblCedulas.Text;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "Requerido");
                this.mpeInformarBox.Show();

            }
            else
            {
                //VALIDACION DE MONTOS IGUALES
                if (generadorControles.ObtenerComparacion(txtValorTotalFacial.Text, txtValorTotalCedulas.Text, EnumTipoComparacion.DIFERENTE, TypeCode.Decimal))
                {
                    existeError = true;

                    //MENSAJE DE ERROR DE MONTOS DIFERENTES
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblValorTotalFacial.Text, "igual a " + this.lblValorTotalCedulas.Text);
                    this.mpeInformarBox.Show();
                }
            }
        }

        return existeError;
    }

    /*VALIDA QUE AL MENOS EXISTA UN REGISTRO EN A SECCION DE ADMINISTRAR GRAVAMENES*/
    private bool ValidarSeccionGravamenes()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        if (this.ddlIndGravamen.SelectedItem.Text.Equals("SI"))
        {
            if (this.grdGravamenes.ContadorElementos().Equals(0))
            {
                existeError = true;

                //MENSAJE DE ERROR DE REQUERIDO
                valorReemplazo = "la sección " + this.lblGravamenes.Text;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "Requerido");
                this.mpeInformarBox.Show();
            }
        }

        return existeError;
    }

    /*VALIDA QUE AL MENOS EXISTA UN REGISTRO EN A SECCION DE ADMINISTRAR POLIZAS*/
    private bool ValidarSeccionPolizas()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        if (this.ddlIndPoliza.SelectedItem.Text.Equals("SI"))
        {
            if (this.grdPolizas.ContadorElementos().Equals(0))
            {
                existeError = true;

                //MENSAJE DE ERROR DE REQUERIDO
                valorReemplazo = "la sección " + this.lblPolizas.Text;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "Requerido");
                this.mpeInformarBox.Show();
            }
        }
        else
        {
            //VALIDACION CARACTERES ESPECIALES
            if (ValidarCaracterEspecialAmpliado(this.txtJustificacion.Text))
            {
                existeError = true;
                //MENSAJE DE ERROR POR CARACTER ESPECIAL
                BarraMensaje(null, "");
            }
        }

        return existeError;
    }

    #endregion

    //Control de Cambios 1.1
    #region METODOS PARA EL CHECKBOX

    protected void checkBox_OnCheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = ((CheckBox)(sender));
            switch (chk.ID.ToUpper())
            {
                #region CHK ESTADO HORIZONTAL
                case "CHKESTADOHORIZONTAL":
                    ChkHorizontal();
                    break;
                #endregion

                #region CHK ESTADO DUPLICADO
                case "CHKESTADODUPLICADO":
                    ChkDuplicado();
                    break;
                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ChkHorizontal()
    {
        try
        {
            if (this.chkEstadoHorizontal.Checked)
            {
                AdministrarBlanco(this.ddlHorizontal.ID, true);
                this.ddlHorizontal.Enabled = false;
            }
            else
            {
                AdministrarBlanco(this.ddlHorizontal.ID, false);
                this.ddlHorizontal.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ChkDuplicado()
    {
        try
        {
            if (this.chkEstadoDuplicado.Checked)
            {
                AdministrarBlanco(this.ddlDuplicado.ID, true);
                this.ddlDuplicado.Enabled = false;
            }
            else
            {
                AdministrarBlanco(this.ddlDuplicado.ID, false);
                this.ddlDuplicado.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ChkEfectos()
    {
        try
        {
            if (this.pantallaIdOculto.Value.Equals("0"))
            {
                if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("1 -") || this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                {
                    AdministrarBlanco(this.ddlDuplicado.ID, true);
                    this.ddlDuplicado.Enabled = false;
                    this.chkEstadoDuplicado.Checked = true;

                    AdministrarBlanco(this.ddlHorizontal.ID, true);
                    this.ddlHorizontal.Enabled = false;
                    this.chkEstadoHorizontal.Checked = true;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region METODOS PARA EL DROPDOWNLIST

    protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl = ((DropDownList)(sender));

            switch (ddl.ID.ToString().ToUpper())
            {
                #region DDL TIPOS BIENES
                case "DDLTIPOBIEN":
                    DdlTiposBienes();
                    break;
                #endregion

                //Control de Cambios 1.1
                #region DDL CLASE
                case "DDLCLASE":
                    DdlClasesEfectos();
                    break;
                #endregion

                #region DDL TIPO FORMATO IDENTIFICACION VEHICULO
                case "DDLFORMATO":
                    DdlFormatoIdentificacionVehiculo();
                    break;
                #endregion

                #region DDL TIPO TASADOR
                case "DDLTIPOTASADOR":
                    DdlTiposTasadores();
                    break;
                #endregion

                #region DDL IND GRAVAMEN
                case "DDLINDGRAVAMEN":
                    DdlIndGravamen();
                    break;
                #endregion

                //B16S01
                #region DDL IND POLIZA
                case "DDLINDPOLIZA":
                    DdlIndPoliza();
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

    #region SECCION GENERAL

    private void DdlTiposBienes()
    {
        try
        {
            //REALIZA LA CARGA DE LA CLASE
            DdlClases(this.ddlTipoBien.SelectedItem.Value);

            //REALIZA LA CARGA DEL FORMATO IDENTIFICACION VEHICULO
            CargarFormatoIdentificacionVehiculo(this.ddlTipoBien.SelectedItem.Text);

            //EFECTO DE NUMERO DE BIEN [CONSTANTES]
            this.txtNBien.Text = string.Empty;
            this.txtNBien.MaxLength = 17;
            this.txtNBien.ToolTip = "Alfanumérico de 17 caracteres";

            if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("1 -") || this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
            {
                //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO PROVINCIAS
                AdministrarBlanco("ddlProvincia", false);
                this.ddlProvincia.Enabled = true;

                //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO HORIZONTALES                
                AdministrarBlanco("ddlHorizontal", false);
                this.ddlHorizontal.Enabled = true;

                //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO DUPLICADOS                
                AdministrarBlanco("ddlDuplicado", false);
                this.ddlDuplicado.Enabled = true;

                //EFECTO DE NUMERO DE BIEN
                this.txtNBien.MaxLength = 6;
                this.txtNBien.ToolTip = "Númerico de 6 caracteres";

                //Control de Cambios 1.1
                //if (this.pantallaIdOculto.Value.Equals("0"))
                //{
                AdministrarBlanco(this.ddlDuplicado.ID, true);
                this.ddlDuplicado.Enabled = false;
                this.chkEstadoDuplicado.Checked = true;
                this.chkEstadoDuplicado.Enabled = true;

                AdministrarBlanco(this.ddlHorizontal.ID, true);
                this.ddlHorizontal.Enabled = false;
                this.chkEstadoHorizontal.Checked = true;
                this.chkEstadoHorizontal.Enabled = true;
                //}

                //METODO COMPLETAR CON CEROS EL NUMERO DE BIEN
                AutoCompletarNBien(false);
            }
            else
            {
                //AGREGA EL ITEM EN BLANCO Y DESHABILITA EL COMBO PROVINCIAS
                AdministrarBlanco("ddlProvincia", true);
                this.ddlProvincia.Enabled = false;

                //AGREGA EL ITEM EN BLANCO Y DESHABILITA EL COMBO HORIZONTALES
                AdministrarBlanco("ddlHorizontal", true);
                this.ddlHorizontal.Enabled = false;

                //AGREGA EL ITEM EN BLANCO Y DESHABILITA EL COMBO DUPLICADOS
                AdministrarBlanco("ddlDuplicado", true);
                this.ddlDuplicado.Enabled = false;

                //Control de Cambios 1.1
                this.chkEstadoDuplicado.Checked = false;
                this.chkEstadoDuplicado.Enabled = false;
                this.chkEstadoHorizontal.Checked = false;
                this.chkEstadoHorizontal.Enabled = false;

                //METODO COMPLETAR CON CEROS EL NUMERO DE BIEN
                AutoCompletarNBien(true);
            }

            if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
            {
                //HABILITA LOS CONTROLES DE CLASE VEHICULO
                this.txtClaseVehiculo.Text = string.Empty;
                this.hdnIdClaseVehiculo.Value = string.Empty;
                this.txtDesClaseVehiculo.Text = string.Empty;
                this.rfvDesClaseVehiculo.Enabled = true;
                this.txtClaseVehiculo.Enabled = true;
                this.btnClaseVehiculo.Enabled = true;

                //COMBO FORMATO DE IDENTIFICACION VEHICULO
                DdlFormatoIdentificacionVehiculo();

                //METODO COMPLETAR CON CEROS EL NUMERO DE BIEN
                AutoCompletarNBien(true);
            }
            else
            {
                //DESHABILITA LOS CONTROLES DE CLASE VEHICULO
                this.txtClaseVehiculo.Text = string.Empty;
                this.hdnIdClaseVehiculo.Value = string.Empty;
                this.lblclasev.Text = string.Empty;
                this.txtDesClaseVehiculo.Text = string.Empty;
                this.rfvDesClaseVehiculo.Enabled = false;
                this.txtClaseVehiculo.Enabled = false;
                this.btnClaseVehiculo.Enabled = false;
            }

            if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("9 -"))
            {
                //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE AERONAVE
                AdministrarBlanco("ddlClaseAeronave", false);
                this.ddlClaseAeronave.Enabled = true;

                //Control de Cambios 1.1
                //EFECTO DE NUMERO DE BIEN
                this.txtNBien.MaxLength = 6;
                this.txtNBien.ToolTip = "Númerico de 6 caracteres";
            }
            else
            {
                //AGREGA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE AERONAVE
                AdministrarBlanco("ddlClaseAeronave", true);
                this.ddlClaseAeronave.Enabled = false;
            }

            if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 4).Equals("10 -"))
            {
                //ELIMINA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE BUQUE
                AdministrarBlanco("ddlClaseBuque", false);
                this.ddlClaseBuque.Enabled = true;

                //EFECTO DE NUMERO DE BIEN
                this.txtNBien.MaxLength = 6;
                this.txtNBien.ToolTip = "Númerico de 6 caracteres";
            }
            else
            {
                //AGREGA EL ITEM EN BLANCO Y HABILITA EL COMBO CLASE BUQUE
                AdministrarBlanco("ddlClaseBuque", true);
                this.ddlClaseBuque.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlClases(string valorFiltro)
    {
        try
        {
            //DDL CLASES            
            generadorControles.LimpiarDropDownList(this.ddlClase);
            controlSeleccionado = ControlesBuscar(this.ddlClase.ID);
            this.ddlClase.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, valorFiltro);
            this.ddlClase.DataTextField = "Texto";
            this.ddlClase.DataValueField = "Valor";
            this.ddlClase.DataBind();
            this.ddlClase.CssClass = controlSeleccionado.CssTipo;
            string[] valorDefecto = controlSeleccionado.ValorDefecto.Split('|');
            if (this.ddlClase.Items.Count < 1)
            {
                this.ddlClase.Items.Clear();
                this.ddlClase.SelectedValue = null;
                AdministrarBlanco("ddlClase", true);
                this.ddlClase.Enabled = false;
            }
            else
            {
                if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("1 -") || this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                {
                    this.ddlClase.Enabled = true;
                    generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlClase, valorDefecto[0]);
                }
                else
                {
                    if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
                    {
                        this.ddlClase.Enabled = true;
                        generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlClase, valorDefecto[1]);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Control de Cambios 1.1
    private void DdlClasesEfectos()
    {
        try
        {
            //SI EL TIPO DE BIEN ES IGUAL A 3 Y LA CLASE TIPO BIEN ES IGUAL A BONO PRENDA
            if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -") && this.ddlClase.SelectedItem.Text.ToUpper().Equals("BONO DE PRENDA"))
            {
                this.txtClaseVehiculo.Text = string.Empty;
                this.txtDesClaseVehiculo.Text = string.Empty;
                this.hdnIdClaseVehiculo.Value = string.Empty;

                this.txtClaseVehiculo.Enabled = false;
                this.btnClaseVehiculo.Enabled = false;
                this.rfvDesClaseVehiculo.Enabled = false;

                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlFormato, "Numérico 6 enteros");
                this.ddlFormato.Enabled = false;
            }
            //SI EL TIPO DE BIEN ES IGUAL A 3 Y LA CLASE TIPO BIEN ES DIFERENTE A BONO PRENDA
            if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -") && !this.ddlClase.SelectedItem.Text.ToUpper().Equals("BONO DE PRENDA"))
            {
                this.txtClaseVehiculo.Text = string.Empty;
                this.txtDesClaseVehiculo.Text = string.Empty;
                this.hdnIdClaseVehiculo.Value = string.Empty;

                this.txtClaseVehiculo.Enabled = true;
                this.btnClaseVehiculo.Enabled = true;
                this.rfvDesClaseVehiculo.Enabled = true;

                this.ddlFormato.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlFormatoIdentificacionVehiculo()
    {
        try
        {
            //EFECTO DE NUMERO DE BIEN [CONSTANTES]
            this.txtNBien.Text = string.Empty;

            if (this.ddlFormato.SelectedItem.Text.Equals("Alfanumérico 17 caracteres"))
            {
                //EFECTO DE NUMERO DE BIEN
                this.txtNBien.MaxLength = 17;
                this.txtNBien.ToolTip = "Alfanumérico de 17 caracteres";
            }
            else
            {
                //EFECTO DE NUMERO DE BIEN
                this.txtNBien.MaxLength = 6;

                if (this.ddlFormato.SelectedItem.Text.Equals("Alfanumérico 3 letras y 3 enteros"))
                    //EFECTO DE NUMERO DE BIEN
                    this.txtNBien.ToolTip = "Alfanumérico 3 letras y 3 enteros (XXX999)";
                else
                    //EFECTO DE NUMERO DE BIEN
                    this.txtNBien.ToolTip = "Númerico de 6 caracteres";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarFormatoIdentificacionVehiculo(string valorFiltro)
    {
        try
        {
            if (valorFiltro.Substring(0, 3).Equals("3 -"))
            {

                this.ddlFormato.Items.Clear();
                this.ddlFormato.SelectedValue = null;
                this.ddlFormato.Items.Add(new ListItem("Numérico 6 enteros", "1"));
                this.ddlFormato.Items.Add(new ListItem("Alfanumérico 3 letras y 3 enteros", "2"));
                this.ddlFormato.Items.Add(new ListItem("Alfanumérico 17 caracteres", "3"));
                this.ddlFormato.SelectedIndex = 0;
                this.ddlFormato.Enabled = true;
            }
            else
            {
                this.ddlFormato.Items.Clear();
                this.ddlFormato.SelectedValue = null;
                AdministrarBlanco("ddlFormato", true);
                this.ddlFormato.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region SECCION TASADORES

    private void DdlTiposTasadores()
    {
        if (ddlTipoTasador.SelectedItem.Text.Equals("Empresa"))
        {
            this.btnLimpiar.Enabled = true;
            this.imbAdministrarEmpresaTasadora.Enabled = true;
            btnAgregarTasador.Enabled = false;
            btnEliminarTasador.Enabled = false;
        }
        else
        {
            this.btnLimpiar.Enabled = false;
            this.imbAdministrarEmpresaTasadora.Enabled = false;
            btnAgregarTasador.Enabled = true;
            btnEliminarTasador.Enabled = true;
        }
    }

    #endregion

    #region SECCION GRAVAMENES

    private void DdlIndGravamen()
    {
        if (ddlIndGravamen.SelectedItem.Text.Equals("SI"))
        {
            this.gridGravamenesInterno.Enabled = true;
            this.btnAgregarGravamen.Enabled = true;
            this.btnEliminarGravamen.Enabled = true;
            this.btnModificarGravamen.Enabled = true;
        }
        else
        {
            this.gridGravamenesInterno.Enabled = false;
            this.btnAgregarGravamen.Enabled = false;
            this.btnEliminarGravamen.Enabled = false;
            this.btnModificarGravamen.Enabled = false;

            if (gridGravamenesInterno.Rows.Count > 0)
            {
                this.mpeConfirmarEliminarGravamenes.Show();
            }
        }
    }

    #endregion

    #region SECCION POLIZAS

    private void DdlIndPoliza()
    {
        //B16S01
        if (ddlIndPoliza.SelectedItem.Text.Equals("SI"))
        {
            this.gridPolizasInterno.Enabled = true;
            this.btnAgregarPoliza.Enabled = true;
            this.btnEliminarPoliza.Enabled = true;
            this.btnModificarPoliza.Enabled = true;

            this.txtJustificacion.Enabled = false;
            this.rfvJustificacion.Enabled = false;
        }
        else
        {
            this.gridPolizasInterno.Enabled = false;
            this.btnAgregarPoliza.Enabled = false;
            this.btnEliminarPoliza.Enabled = false;
            this.btnModificarPoliza.Enabled = false;

            this.txtJustificacion.Enabled = true;
            this.rfvJustificacion.Enabled = true;

            if (gridPolizasInterno.Rows.Count > 0)
            {
                this.mpeConfirmarEliminarPolizas.Show();
            }
        }

        this.txtJustificacion.Text = string.Empty;
    }

    #endregion

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

    #region METODOS PARA EL TEXTBOX

    #region EVENTOS MONTOS

    protected void txtMontoUltimaTasacionTerreno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            MontoUltimaTasacionTerreno(sender, e);

            //DEBIDO AL BUG DEL MASKEDITEXTENDER SE DEBE DE VALIDAR SI LA MASCARA DEL CONTROL ESTÁ VACÍA
            //if (this.txtMontoTasacionActualizadaTerreno.Text.Contains("_"))
            //    this.txtMontoTasacionActualizadaTerreno.Text = string.Empty;

            //if (this.txtMontoTasacionActualizadaTerreno.Enabled && this.txtMontoTasacionActualizadaTerreno.Text.Length > 0)
            //{
            //    MontoTasacionActualizadaTerreno(sender, e);
            //    if (this.txtMontoTasacionActualizadaNoTerreno.Text.Length.Equals(0))
            //        this.txtMontoTotalUltimaTasacionActualizada.Text = string.Empty;
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtMontoUltimaTasacionNoTerreno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            MontoUltimaTasacionNoTerreno(sender, e);

            //DEBIDO AL BUG DEL MASKEDITEXTENDER SE DEBE DE VALIDAR SI LA MASCARA DEL CONTROL ESTÁ VACÍA
            //if (this.txtMontoTasacionActualizadaNoTerreno.Text.Contains("_"))
            //    this.txtMontoTasacionActualizadaNoTerreno.Text = string.Empty;

            //if (this.txtMontoTasacionActualizadaNoTerreno.Enabled && this.txtMontoTasacionActualizadaNoTerreno.Text.Length > 0)
            //{
            //    MontoTasacionActualizadaNoTerreno(sender, e);
            //    if (this.txtMontoTasacionActualizadaTerreno.Text.Length.Equals(0))
            //        this.txtMontoTotalUltimaTasacionActualizada.Text = string.Empty;
            //}

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtMontoTasacionActualizadaTerreno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            MontoTasacionActualizadaTerreno(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtMontoTasacionActualizadaNoTerreno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            MontoTasacionActualizadaNoTerreno(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region EVENTOS CALENDARIOS

    #region SECCION VALUACION

    protected void txtFechaConstruccionGarantia_TextChanged(object sender, EventArgs e)
    {
        try
        {
            FechaConstruccionGarantia(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtFechaUltimaTasacionGarantia_TextChanged(object sender, EventArgs e)
    {
        try
        {
            FechaUltimaTasacionGarantia(sender, e);
            if (this.txtFechaUltimoSeguimientoGarantia.Enabled && this.txtFechaUltimoSeguimientoGarantia.Text.Length > 0)
                FechaUltimoSeguimientoGarantia(sender, e);
            //if (this.txtFechaFabricacionGarantia.Enabled && this.txtFechaFabricacionGarantia.Text.Length > 0)
            if (this.txtFechaFabricacionGarantia.Text.Length > 0)
                FechaFabricacionGarantia(sender, e);
            if (this.txtFechaConstruccionGarantia.Enabled && this.txtFechaConstruccionGarantia.Text.Length > 0)
                FechaConstruccionGarantia(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtFechaUltimoSeguimientoGarantia_TextChanged(object sender, EventArgs e)
    {
        try
        {
            FechaUltimoSeguimientoGarantia(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtFechaFabricacionGarantia_TextChanged(object sender, EventArgs e)
    {
        try
        {
            FechaFabricacionGarantia(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region VENTANA ADMINISTRAR CEDULAS

    protected void txtCedulasHipotecariasFechaVencimiento_TextChanged(object sender, EventArgs e)
    {
        try
        {
            txtCedulasHipotecariasFechaPrescripcion.Text = DateTime.Parse(txtCedulasHipotecariasFechaVencimiento.Text).AddYears(10).ToShortDateString();
            this.mpeCedulasHipotecarias.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

    #region METODOS MONTOS

    private void MontoUltimaTasacionTerreno(object sender, EventArgs e)
    {
        try
        {
            txtMontoUltimaTasacionTerreno.Text = generadorControles.EliminarErrorMascara(txtMontoUltimaTasacionTerreno.Text);
            txtMontoUltimaTasacionNoTerreno.Text = generadorControles.EliminarErrorMascara(txtMontoUltimaTasacionNoTerreno.Text);

            //EL TXT MONTO ULTIMA TASACION TERRENO DEBE SER MAYOR A CERO
            if (generadorControles.ObtenerComparacion(txtMontoUltimaTasacionTerreno.Text, "0", EnumTipoComparacion.MAYOR, TypeCode.Decimal))
            {
                this.txtMontoTotalUltimaTasacion.Text = generadorControles.SumarRetornoString(txtMontoUltimaTasacionTerreno.Text, txtMontoUltimaTasacionNoTerreno.Text);
                //B15S04 ASIGNACION DEL MONTO TASACION ACTUALIZADA TERRENO
                if (pantallaIdOculto.Value.Equals("0"))
                {
                    this.txtMontoTasacionActualizadaTerreno.Text = txtMontoUltimaTasacionTerreno.Text;
                    txtMontoTasacionActualizadaTerreno_TextChanged(sender, e);
                }
            }
            else
            {
                //MENSAJE DE ERROR DEL VALOR
                if (this.txtMontoUltimaTasacionTerreno.Text.Length >= 0) //>0
                {
                    //LIMPIA LOS CAMPOS Y RECALCULA EL MONTO TOTAL
                    //this.txtMontoUltimaTasacionTerreno.Text = string.Empty;
                    if (this.txtMontoUltimaTasacionNoTerreno.Text.Length > 0)
                        this.txtMontoTotalUltimaTasacion.Text = generadorControles.SumarRetornoString(txtMontoUltimaTasacionTerreno.Text, txtMontoUltimaTasacionNoTerreno.Text);

                    if (this.txtMontoUltimaTasacionTerreno.Text.Length > 0)
                    {
                        this.txtMontoUltimaTasacionTerreno.Text = string.Empty;
                        //MENSAJE DE ERROR DEL VALOR
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblMontoUltimaTasacionTerreno.Text, "mayor a cero");
                        this.mpeInformarBox.Show();
                    }
                    else
                    {
                        //B15S04 ASIGNACION DEL MONTO TASACION ACTUALIZADA NO TERRENO
                        if (pantallaIdOculto.Value.Equals("0"))
                        {
                            this.txtMontoTasacionActualizadaTerreno.Text = string.Empty;
                            txtMontoTasacionActualizadaTerreno_TextChanged(sender, e);
                        }
                    }
                }
            }
            //VALIDACION DE LIMPIEZA DEL TOTAL
            if (this.txtMontoUltimaTasacionNoTerreno.Text.Length.Equals(0) && this.txtMontoUltimaTasacionTerreno.Text.Length.Equals(0))
                this.txtMontoTotalUltimaTasacion.Text = string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void MontoUltimaTasacionNoTerreno(object sender, EventArgs e)
    {
        try
        {
            txtMontoUltimaTasacionTerreno.Text = generadorControles.EliminarErrorMascara(txtMontoUltimaTasacionTerreno.Text);
            txtMontoUltimaTasacionNoTerreno.Text = generadorControles.EliminarErrorMascara(txtMontoUltimaTasacionNoTerreno.Text);

            //EL TXT MONTO ULTIMA TASACION NO TERRENO DEBE SER MAYOR A CERO
            if (generadorControles.ObtenerComparacion(txtMontoUltimaTasacionNoTerreno.Text, "0", EnumTipoComparacion.MAYOR, TypeCode.Decimal))
            {
                this.txtMontoTotalUltimaTasacion.Text = generadorControles.SumarRetornoString(txtMontoUltimaTasacionTerreno.Text, txtMontoUltimaTasacionNoTerreno.Text);
                //B15S04 ASIGNACION DEL MONTO TASACION ACTUALIZADA NO TERRENO
                if (pantallaIdOculto.Value.Equals("0"))
                {
                    this.txtMontoTasacionActualizadaNoTerreno.Text = txtMontoUltimaTasacionNoTerreno.Text;
                    txtMontoTasacionActualizadaNoTerreno_TextChanged(sender, e);
                }
            }
            else
            {
                //MENSAJE DE ERROR DEL VALOR
                if (this.txtMontoUltimaTasacionNoTerreno.Text.Length >= 0) //> 0
                {
                    //LIMPIA LOS CAMPOS Y RECALCULA EL MONTO TOTAL
                    //this.txtMontoUltimaTasacionNoTerreno.Text = string.Empty;
                    if (this.txtMontoUltimaTasacionTerreno.Text.Length > 0)
                        this.txtMontoTotalUltimaTasacion.Text = generadorControles.SumarRetornoString(txtMontoUltimaTasacionTerreno.Text, txtMontoUltimaTasacionNoTerreno.Text);

                    if (this.txtMontoUltimaTasacionNoTerreno.Text.Length > 0)
                    {
                        this.txtMontoUltimaTasacionNoTerreno.Text = string.Empty;
                        //MENSAJE DE ERROR DEL VALOR
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblMontoUltimaTasacionNoTerreno.Text, "mayor a cero");
                        this.mpeInformarBox.Show();
                    }
                    else
                    {
                        //B15S04 ASIGNACION DEL MONTO TASACION ACTUALIZADA NO TERRENO
                        if (pantallaIdOculto.Value.Equals("0"))
                        {
                            this.txtMontoTasacionActualizadaNoTerreno.Text = string.Empty;
                            txtMontoTasacionActualizadaNoTerreno_TextChanged(sender, e);
                        }
                    }
                }
            }

            //VALIDACION DE LIMPIEZA DEL TOTAL
            if (this.txtMontoUltimaTasacionNoTerreno.Text.Length.Equals(0) && this.txtMontoUltimaTasacionTerreno.Text.Length.Equals(0))
                this.txtMontoTotalUltimaTasacion.Text = string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void MontoTasacionActualizadaTerreno(object sender, EventArgs e)
    {
        try
        {
            /*//Control de Cambios 1.1
            txtMontoTasacionActualizadaTerreno.Text = _generadorControles.EliminarErrorMascara(txtMontoTasacionActualizadaTerreno.Text);
            txtMontoUltimaTasacionTerreno.Text = _generadorControles.EliminarErrorMascara(txtMontoUltimaTasacionTerreno.Text);
            txtMontoTasacionActualizadaNoTerreno.Text = _generadorControles.EliminarErrorMascara(txtMontoTasacionActualizadaNoTerreno.Text);

            //EL TXT MONTO TASACION ACTUALIZADA TERRENO DEBE SER MAYOR O IGUAL AL TXT MONTO ULTIMA TASACION TERRENO
            if (_generadorControles.ObtenerComparacion(txtMontoTasacionActualizadaTerreno.Text, txtMontoUltimaTasacionTerreno.Text, EnumTipoComparacion.MAYORIGUAL, TypeCode.Decimal))
                txtMontoTotalUltimaTasacionActualizada.Text = _generadorControles.SumarRetornoString(txtMontoTasacionActualizadaTerreno.Text, txtMontoTasacionActualizadaNoTerreno.Text);
            else
            {
                //LIMPIA LOS CAMPOS Y RECALCULA EL MONTO TOTAL ACTUALIZADO
                //this.txtMontoTasacionActualizadaTerreno.Text = string.Empty;
                //if (this.txtMontoTasacionActualizadaNoTerreno.Text.Length > 0)
                    txtMontoTotalUltimaTasacionActualizada.Text = _generadorControles.SumarRetornoString(txtMontoTasacionActualizadaTerreno.Text, txtMontoTasacionActualizadaNoTerreno.Text);

                if (this.txtMontoTasacionActualizadaTerreno.Text.Length > 0 && this.txtMontoUltimaTasacionTerreno.Text.Length > 0)
                {
                    this.txtMontoTasacionActualizadaTerreno.Text = string.Empty;

                    //MENSAJE DE ERROR DEL VALOR
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblMontoTasacionActualizadaTerreno.Text, string.Concat("mayor o igual al ", lblMontoUltimaTasacionTerreno.Text));
                    this.mpeInformarBox.Show();
                }
            }

            //VALIDACION DE LIMPIEZA DEL TOTAL
            if (this.txtMontoTasacionActualizadaTerreno.Text.Length.Equals(0) && this.txtMontoTasacionActualizadaNoTerreno.Text.Length.Equals(0))
                this.txtMontoTotalUltimaTasacionActualizada.Text = string.Empty;
            */

            txtMontoTasacionActualizadaTerreno.Text = generadorControles.EliminarErrorMascara(txtMontoTasacionActualizadaTerreno.Text);
            txtMontoTasacionActualizadaNoTerreno.Text = generadorControles.EliminarErrorMascara(txtMontoTasacionActualizadaNoTerreno.Text);

            //EL TXT MONTO TASACION ACTUALIZADA TERRENO DEBE SER MAYOR A CERO
            if (generadorControles.ObtenerComparacion(txtMontoTasacionActualizadaTerreno.Text, "0", EnumTipoComparacion.MAYOR, TypeCode.Decimal))
                this.txtMontoTotalUltimaTasacionActualizada.Text = generadorControles.SumarRetornoString(txtMontoTasacionActualizadaTerreno.Text, txtMontoTasacionActualizadaNoTerreno.Text);
            else
            {
                //MENSAJE DE ERROR DEL VALOR
                if (this.txtMontoTasacionActualizadaTerreno.Text.Length >= 0) //>0
                {
                    //LIMPIA LOS CAMPOS Y RECALCULA EL MONTO TOTAL
                    //this.txtMontoUltimaTasacionTerreno.Text = string.Empty;
                    if (this.txtMontoTasacionActualizadaNoTerreno.Text.Length > 0)
                        this.txtMontoTotalUltimaTasacionActualizada.Text = generadorControles.SumarRetornoString(txtMontoTasacionActualizadaTerreno.Text, txtMontoTasacionActualizadaNoTerreno.Text);

                    if (this.txtMontoTasacionActualizadaTerreno.Text.Length > 0)
                    {
                        this.txtMontoTasacionActualizadaTerreno.Text = string.Empty;
                        //MENSAJE DE ERROR DEL VALOR
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblMontoTasacionActualizadaTerreno.Text, "mayor a cero");
                        this.mpeInformarBox.Show();
                    }
                }
            }
            //VALIDACION DE LIMPIEZA DEL TOTAL
            if (this.txtMontoTasacionActualizadaNoTerreno.Text.Length.Equals(0) && this.txtMontoTasacionActualizadaTerreno.Text.Length.Equals(0))
                this.txtMontoTotalUltimaTasacionActualizada.Text = string.Empty;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void MontoTasacionActualizadaNoTerreno(object sender, EventArgs e)
    {
        try
        {
            /*//Control de Cambios 1.1
            txtMontoTasacionActualizadaNoTerreno.Text = _generadorControles.EliminarErrorMascara(txtMontoTasacionActualizadaNoTerreno.Text);
            txtMontoUltimaTasacionNoTerreno.Text = _generadorControles.EliminarErrorMascara(txtMontoUltimaTasacionNoTerreno.Text);
            txtMontoTasacionActualizadaTerreno.Text = _generadorControles.EliminarErrorMascara(txtMontoTasacionActualizadaTerreno.Text);

            //EL TXT MONTO TASACION ACTUALIZADA NO TERRENO DEBE SER MAYOR O IGUAL AL MONTO ULTIMA TASASCION NO TERRENO
            if (_generadorControles.ObtenerComparacion(txtMontoTasacionActualizadaNoTerreno.Text, txtMontoUltimaTasacionNoTerreno.Text, EnumTipoComparacion.MAYORIGUAL, TypeCode.Decimal))
                txtMontoTotalUltimaTasacionActualizada.Text = _generadorControles.SumarRetornoString(txtMontoTasacionActualizadaTerreno.Text, txtMontoTasacionActualizadaNoTerreno.Text);
            else
            {
                //LIMPIA LOS CAMPOS Y RECALCULA EL MONTO TOTAL ACTUALIZADO
                //this.txtMontoTasacionActualizadaNoTerreno.Text = string.Empty;
                //if (this.txtMontoTasacionActualizadaTerreno.Text.Length > 0)
                    txtMontoTotalUltimaTasacionActualizada.Text = _generadorControles.SumarRetornoString(txtMontoTasacionActualizadaTerreno.Text, txtMontoTasacionActualizadaNoTerreno.Text);
                
                if (this.txtMontoTasacionActualizadaNoTerreno.Text.Length > 0 && this.txtMontoUltimaTasacionNoTerreno.Text.Length > 0)
                {
                    this.txtMontoTasacionActualizadaNoTerreno.Text = string.Empty;
                    //MENSAJE DE ERROR DEL VALOR
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblMontoTasacionActualizadaNoTerreno.Text, string.Concat("mayor o igual al ", lblMontoUltimaTasacionNoTerreno.Text));
                    this.mpeInformarBox.Show();
                }
            }

            //VALIDACION DE LIMPIEZA DEL TOTAL
            if (this.txtMontoTasacionActualizadaTerreno.Text.Length.Equals(0) && this.txtMontoTasacionActualizadaNoTerreno.Text.Length.Equals(0))
                this.txtMontoTotalUltimaTasacionActualizada.Text = string.Empty;
            */

            txtMontoTasacionActualizadaNoTerreno.Text = generadorControles.EliminarErrorMascara(txtMontoTasacionActualizadaNoTerreno.Text);
            txtMontoTasacionActualizadaTerreno.Text = generadorControles.EliminarErrorMascara(txtMontoTasacionActualizadaTerreno.Text);

            //EL TXT MONTO TASACION ACTUALIZADA NO TERRENO DEBE SER MAYOR A CERO
            if (generadorControles.ObtenerComparacion(txtMontoTasacionActualizadaNoTerreno.Text, "0", EnumTipoComparacion.MAYOR, TypeCode.Decimal))
                this.txtMontoTotalUltimaTasacionActualizada.Text = generadorControles.SumarRetornoString(txtMontoTasacionActualizadaTerreno.Text, txtMontoTasacionActualizadaNoTerreno.Text);
            else
            {
                //MENSAJE DE ERROR DEL VALOR
                if (this.txtMontoTasacionActualizadaNoTerreno.Text.Length >= 0) //>0
                {
                    //LIMPIA LOS CAMPOS Y RECALCULA EL MONTO TOTAL
                    if (this.txtMontoTasacionActualizadaTerreno.Text.Length > 0)
                        this.txtMontoTotalUltimaTasacionActualizada.Text = generadorControles.SumarRetornoString(txtMontoTasacionActualizadaTerreno.Text, txtMontoTasacionActualizadaNoTerreno.Text);

                    if (this.txtMontoTasacionActualizadaNoTerreno.Text.Length > 0)
                    {
                        this.txtMontoTasacionActualizadaNoTerreno.Text = string.Empty;
                        //MENSAJE DE ERROR DEL VALOR
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblMontoTasacionActualizadaNoTerreno.Text, "mayor a cero");
                        this.mpeInformarBox.Show();
                    }
                }
            }

            //VALIDACION DE LIMPIEZA DEL TOTAL
            if (this.txtMontoTasacionActualizadaNoTerreno.Text.Length.Equals(0) && this.txtMontoTasacionActualizadaTerreno.Text.Length.Equals(0))
                this.txtMontoTotalUltimaTasacionActualizada.Text = string.Empty;
            //this.txtMontoTasacionActualizadaTerreno.Text = string.Empty;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region METODOS CALENDARIOS

    private void FechaConstruccionGarantia(object sender, EventArgs e)
    {
        try
        {
            if (this.txtFechaConstruccionGarantia.Enabled)
            {
                //LA FECHA CONSTRUCCION GARANTIA NO PUEDE SER MAYOR O IGUAL A LA FECHA ULTIMA TASACION GARANTIA
                if (generadorControles.ObtenerComparacion(this.txtFechaConstruccionGarantia.Text, this.txtFechaUltimaTasacionGarantia.Text, EnumTipoComparacion.MAYORIGUAL, TypeCode.DateTime))
                {
                    //LIMPIA LOS CAMPOS
                    this.txtFechaConstruccionGarantia.Text = string.Empty;
                    //MENSAJE DE ERROR DEL VALOR
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblFechaConstruccionGarantia.Text, string.Concat("menor a la ", this.lblFechaUltimaTasacionGarantia.Text));
                    this.mpeInformarBox.Show();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FechaUltimaTasacionGarantia(object sender, EventArgs e)
    {
        try
        {
            //BANDERA PARA LA ASIGNACION DE DATOS AL CAMPO TXT FECHA ULTIMO SEGUIMIENTO GARANTIA
            bool existeError = false;

            //PARA EL TIPO DE BIEN 1
            if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("1 -"))
            {
                if (this.txtFechaConstruccionGarantia.Enabled)
                {
                    //FECHA ULTIMA TASACION GARANTIA DEBE SER MAYOR O IGUAL A LA FECHA DE CONSTRUCCION GARANTIA
                    if (!generadorControles.ObtenerComparacion(this.txtFechaUltimaTasacionGarantia.Text, this.txtFechaConstruccionGarantia.Text, EnumTipoComparacion.MAYORIGUAL, TypeCode.DateTime))
                    {
                        existeError = true;
                        //LIMPIA LOS CAMPOS
                        this.txtFechaUltimaTasacionGarantia.Text = string.Empty;
                        //MENSAJE DE ERROR DEL VALOR
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblFechaUltimaTasacionGarantia.Text, string.Concat("mayor o igual al ", lblFechaConstruccionGarantia.Text));
                        this.mpeInformarBox.Show();
                    }
                    else
                    {
                        //FECHA ULTIMA TASACION GARANTIA DEBE SER MENOR A LA FECHA ACTUAL
                        if (!generadorControles.ObtenerComparacion(this.txtFechaUltimaTasacionGarantia.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MENOR, TypeCode.DateTime))
                        {
                            existeError = true;
                            //LIMPIA LOS CAMPOS
                            this.txtFechaUltimaTasacionGarantia.Text = string.Empty;
                            this.txtFechaUltimoSeguimientoGarantia.Text = string.Empty;
                            this.txtFechaVencimientoAvaluo.Text = string.Empty;
                            //MENSAJE DE ERROR DEL VALOR
                            this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblFechaUltimaTasacionGarantia.Text, "mayor a la Fecha Actual");
                            this.mpeInformarBox.Show();
                        }
                    }
                }
                else
                {
                    //FECHA ULTIMA TASACION GARANTIA DEBE SER MENOR A LA FECHA ACTUAL
                    if (!generadorControles.ObtenerComparacion(this.txtFechaUltimaTasacionGarantia.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MENOR, TypeCode.DateTime))
                    {
                        existeError = true;
                        //LIMPIA LOS CAMPOS
                        this.txtFechaUltimaTasacionGarantia.Text = string.Empty;
                        this.txtFechaUltimoSeguimientoGarantia.Text = string.Empty;
                        this.txtFechaVencimientoAvaluo.Text = string.Empty;
                        //MENSAJE DE ERROR DEL VALOR
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblFechaUltimaTasacionGarantia.Text, "menor a la Fecha Actual");
                        this.mpeInformarBox.Show();
                    }
                }
            }
            //PARA LOS TIPOS DE BIENES DISTINTOS A 1
            else
            {
                //FECHA ULTIMA TASACION GARANTIA DEBE SER MENOR A LA FECHA ACTUAL
                if (!generadorControles.ObtenerComparacion(this.txtFechaUltimaTasacionGarantia.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MENOR, TypeCode.DateTime))
                {
                    existeError = true;
                    //LIMPIA LOS CAMPOS
                    this.txtFechaUltimaTasacionGarantia.Text = string.Empty;
                    this.txtFechaUltimoSeguimientoGarantia.Text = string.Empty;
                    this.txtFechaVencimientoAvaluo.Text = string.Empty;
                    //MENSAJE DE ERROR DEL VALOR
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblFechaUltimaTasacionGarantia.Text, "menor a la Fecha Actual");
                    this.mpeInformarBox.Show();
                }
            }

            //SI NO EXISTEN ERRORES SE ASIGNA EL VALOR DEL TXT FECHA ULTIMA TASACION GARANTIA AL TXT FECHA ULTIMO SEGUIMIENTO GARANTIA Y SE REALIZA LA ASIGNACION DE LA FECHA VENCIMIENTO AVALUO SUGEF
            if (!existeError)
            {
                this.txtFechaUltimoSeguimientoGarantia.Text = this.txtFechaUltimaTasacionGarantia.Text;
                FechaVencimientoAvaluoSUGEF();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FechaUltimoSeguimientoGarantia(object sender, EventArgs e)
    {
        try
        {
            //LA FECHA ULTIMO SEGUIMIENTO GARANTIA DEBE SER MAYOR O IGUAL A LA FECHA ULTIMA TASACION GARANTIA
            if (generadorControles.ObtenerComparacion(this.txtFechaUltimoSeguimientoGarantia.Text, this.txtFechaUltimaTasacionGarantia.Text, EnumTipoComparacion.MENOR, TypeCode.DateTime))
            {
                //LIMPIA LOS CAMPOS
                this.txtFechaUltimoSeguimientoGarantia.Text = string.Empty;
                //MENSAJE DE ERROR DEL VALOR
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblFechaUltimoSeguimientoGarantia.Text, string.Concat("mayor o igual a la ", this.lblFechaUltimaTasacionGarantia.Text));
                this.mpeInformarBox.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FechaFabricacionGarantia(object sender, EventArgs e)
    {
        try
        {
            //bool existeError = false;

            //LA FECHA FABRICACION GARANTIA DEBE SER MENOR A LA FECHA ULTIMA TASACION GARANTIA
            if (generadorControles.ObtenerComparacion(this.txtFechaFabricacionGarantia.Text, this.txtFechaUltimaTasacionGarantia.Text, EnumTipoComparacion.MAYORIGUAL, TypeCode.DateTime))
            {
                //LIMPIA LOS CAMPOS
                if (!this.txtFechaFabricacionGarantia.Enabled && this.txtFechaFabricacionGarantia.Text.Length > 0)
                {
                    this.txtFechaUltimaTasacionGarantia.Text = string.Empty;
                    this.txtFechaUltimoSeguimientoGarantia.Text = string.Empty;
                }
                else
                    this.txtFechaFabricacionGarantia.Text = string.Empty;

                //MENSAJE DE ERROR DEL VALOR
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblFechaFabricacionGarantia.Text, string.Concat("menor a la ", this.lblFechaUltimaTasacionGarantia.Text, " y a la Fecha Actual"));
                this.mpeInformarBox.Show();
            }

            //LA FECHA FABRICACION GARANTIA DEBE SER MENOR A LA FECHA ACTUAL
            if (generadorControles.ObtenerComparacion(this.txtFechaFabricacionGarantia.Text, DateTime.Now.ToShortDateString(), EnumTipoComparacion.MAYORIGUAL, TypeCode.DateTime))
            {
                //LIMPIA LOS CAMPOS
                this.txtFechaFabricacionGarantia.Text = string.Empty;

                //MENSAJE DE ERROR DEL VALOR
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_7", this.lblFechaFabricacionGarantia.Text, string.Concat("menor a la ", this.lblFechaUltimaTasacionGarantia.Text, " y a la Fecha Actual"));
                this.mpeInformarBox.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FechaVencimientoAvaluoSUGEF()
    {
        try
        {
            string codigoBien = this.ddlTipoBien.SelectedItem.Text.Substring(0, 3);
            ListasWS.ListaEntidad retorno = null;

            retorno = wsListas.GarantiasRealesFechaVencimientoAvaluoSUGEF(this.ddlTipoBien.SelectedItem.Value);

            //Control de Cambios. Garantias Reales III 24-06-2014
            /*
            //FECHA VENCIMIENTO AVALUO SUGEF = FECHA ULTIMA TASACION GARANTIA + MESES VENCIMIENTO AVALÚO SUGEF TERRENO DE LA TABLA PARAMETROS USUARIOS
            if (_codigoBien.Equals("1 -"))
            {   
                if (_retorno.Valor.Equals("1"))
                {
                    if (this.txtFechaUltimaTasacionGarantia.Text.Length > 0)
                        this.txtFechaVencimientoAvaluo.Text = DateTime.Parse(this.txtFechaUltimaTasacionGarantia.Text).AddMonths(int.Parse(_retorno.Texto)).ToShortDateString();
                    else
                        this.txtFechaVencimientoAvaluo.Text = string.Empty;
                }
            }

            //FECHA VENCIMIENTO AVALUO SUGEF = FECHA ULTIMA TASACION GARANTIA + MESES VENCIMIENTO AVALÚO SUGEF EDIFICACIONES DE LA TABLA PARAMETROS USUARIOS
            if (_codigoBien.Equals("2 -"))
            {
                if (_retorno.Valor.Equals("1"))
                {
                    if (this.txtFechaUltimaTasacionGarantia.Text.Length > 0)
                        this.txtFechaVencimientoAvaluo.Text = DateTime.Parse(this.txtFechaUltimaTasacionGarantia.Text).AddMonths(int.Parse(_retorno.Texto)).ToShortDateString();
                    else
                        this.txtFechaVencimientoAvaluo.Text = string.Empty;
                }
            }
            */
            if (retorno.Valor.Equals("1"))
            {
                if (this.txtFechaUltimaTasacionGarantia.Text.Length > 0)
                    this.txtFechaVencimientoAvaluo.Text = DateTime.Parse(this.txtFechaUltimaTasacionGarantia.Text).AddMonths(int.Parse(retorno.Texto)).ToShortDateString();
                else
                    this.txtFechaVencimientoAvaluo.Text = string.Empty;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

    #region METODOS PARA BOTONES

    /*BOTON DE VALIDACION DE LA SECCION GENERAL*/
    protected void btnValidar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {

                List<KeyValuePair<string, bool>> validacionNumeroBien = ValidarNumeroBien();

                //VALIDACION DEL FORMATO DEL N BIEN
                if (validacionNumeroBien.First(errorformato => errorformato.Key == "errorFormato").Value &&
                    !validacionNumeroBien.First(errorformato => errorformato.Key == "errorLetras").Value)
                {
                    //MENSAJE DE ERROR DE FORMATO
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_6", this.lblNBien.Text, this.txtNBien.ToolTip);
                    this.mpeInformarBox.Show();
                }
                else
                {
                    //VALIDACION DE SOLO LETRAS PARA N BIEN DE 17 CARACTERES
                    if (validacionNumeroBien.First(errorformato => errorformato.Key == "errorLetras").Value)
                    {
                        //MENSAJE DE ERROR DE FORMATO
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_36", this.lblNBien.Text, this.txtNBien.ToolTip);
                        this.mpeInformarBox.Show();
                    }
                    else
                    {
                        //SI NO EXISTE ERROR EN LAS VALIDACIONES (FORMATO Y SOLO LETRAS PARA 17 CARACTERES)
                        if (!ValidarEntidadReal())
                        {
                            //Control de Cambios 1.2
                            /* LimpiarBarraMensaje();

                                //DESHABILITA LA SECCION GENERAL
                                AdministrarControlesExcepcionesGeneral(false);

                                //HABILITA LOS CONTROLES DE GUARDADO
                                DeshabilitarControlesGuardar(false);

                                //HABILITA LA SECCION VALUACIÓN
                                AdministrarControlesExcepcionesValuacion(true);
                                //CARGA LOS CONTROLES DE LA SECCION VALUACION
                                ControlesValuacion();

                                //HABILITA LA SECCION DE TASADORES
                                AdministrarControlesExcepcionesTasadores(true);
                                //CARGA LOS CONTROLES DE LA SECCION TASADORES
                                ControlesTasadores();

                                //HABILITA LA SECCION DE CEDULAS
                                if (this.ddlClase.SelectedItem.Text.Equals("Cédula Hipotecaria"))
                                {
                                    //HABILITA LA SECCION DE CEDULAS
                                    AdministrarControlesExcepcionesCedulas(true);
                                    //CARGA LOS CONTROLES DE LA SECCION CEDULAS
                                    ControlesCedulas();
                                }

                                DeEntidadAControlesTasadores();*/
                            CargarControlesSinError();
                        }
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

    /*BOTON DE BUSQUEDA PARA LA CLASE VEHICULO*/
    protected void btnClaseVehiculo_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (ValidarCaracterEspecial(this.txtClaseVehiculo.Text))
                {
                    //MENSAJE DE ERROR POR CARACTER ESPECIAL
                    BarraMensaje(null, "");
                }
                else
                {
                    ((wucGridEmergente)this.BusquedaClaseVehiculo).BindGridView(this.ConsultaClaseVehiculo(txtClaseVehiculo.Text));
                    LimpiarBarraMensaje();
                    this.mpeBusquedaClaseVehiculo.Show();
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*BOTON DE BUSQUEDA DE EMPRESAS TASADORAS*/
    protected void btnClaseAdministrarEmpresaTasadora_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                ((wucGridEmergente)this.BusquedaEmpresaTasadora).BindGridView(this.ConsultaEmpresasTasadoras());
                this.mpeBusquedaEmpresaTasadora.Show();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*BOTON DE LIMPIAR EMPRESAS TASADORAS*/
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            LimpiarEmpresaTasadora();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*BOTON DE AGREGAR PERSONA TASADOR*/
    protected void btnAgregarTasador_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                ((wucGridEmergente)this.BusquedaPersonaTasadora).BindGridView(this.ConsultaPersonasTasadoras());
                this.mpeBusquedaPersonaTasadora.Show();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*BOTON DE ELIMINAR TASADOR*/
    protected void btnEliminarTasador_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                if (this.grdTasadores.ContadorSeleccionados() > 0)
                {
                    GarantiasRealesTasadoresEntidad entidad = null;
                    foreach (GridViewRow row1 in gridTasadoresInterno.Rows)
                    {
                        CheckBox checkBoxColumn = (CheckBox)gridTasadoresInterno.Rows[row1.RowIndex].FindControl("chkBox1");
                        if (checkBoxColumn.Checked)
                        {
                            Label lblId = (Label)gridTasadoresInterno.Rows[row1.RowIndex].FindControl("lblIdGarantiaRealTasador");

                            entidad = new GarantiasRealesTasadoresEntidad();
                            entidad.IdGarantiaRealTasador = int.Parse(lblId.Text);
                            entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                            respuesta = wsGarantias.GarantiasRealesTasadoresEliminar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));

                            //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                            if (respuesta.ValorError.Equals(18))
                            {
                                BloquearControlesDesactualizados();
                                BarraMensaje(respuesta, pantallaIdOculto.Value);
                            }
                        }
                    }
                    GridViewTasadoresInternoActualizar();

                    if (gridTasadoresInterno.Rows.Count < 1)
                        this.ddlTipoTasador.Enabled = true;
                }
                else
                {
                    //VERIFICA SI EL GRID CONTIENE REGISTROS
                    if (this.grdTasadores.ContadorElementos() > 0)
                    {
                        //ERROR DE NO SELECCION DE REGISTROS
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_8");
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

    /*BOTON DE AGREGAR CEDULA*/
    protected void btnAgregarCedula_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                CargaArregloControles();
                this.CedulasHipotecarias.LimpiarContenido();
                this.CedulasHipotecarias.CargarContenido(controlEntidad);
                this.mpeCedulasHipotecarias.Show();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*BOTON DE ELIMINAR CEDULA*/
    protected void btnEliminarCedula_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                if (this.grdCedulas.ContadorSeleccionados() > 0)
                {
                    GarantiasRealesCedulasEntidad entidad = null;
                    foreach (GridViewRow row1 in gridCedulasInterno.Rows)
                    {
                        CheckBox checkBoxColumn = (CheckBox)gridCedulasInterno.Rows[row1.RowIndex].FindControl("chkBox1");
                        if (checkBoxColumn.Checked)
                        {
                            Label lblId = (Label)gridCedulasInterno.Rows[row1.RowIndex].FindControl("lblIdGarantiaRealCedula");

                            entidad = new GarantiasRealesCedulasEntidad();
                            entidad.IdGarantiaRealCedula = int.Parse(lblId.Text);
                            entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                            respuesta = wsGarantias.GarantiasRealesCedulasEliminar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));

                            //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                            if (respuesta.ValorError.Equals(18))
                            {
                                BloquearControlesDesactualizados();
                                BarraMensaje(respuesta, pantallaIdOculto.Value);
                            }
                        }
                    }
                    GridViewCedulasInternoActualizar();
                }
                else
                {
                    //VERIFICA SI EL GRID CONTIENE REGISTROS
                    if (this.grdCedulas.ContadorElementos() > 0)
                    {
                        //ERROR DE NO SELECCION DE REGISTROS
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_8");
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

    /*BOTON DE AGREGAR GRAVAMEN*/
    protected void btnAgregarGravamen_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                CargaArregloControles();
                this.VentanaGravamenesGarantias1.LimpiarContenido();
                this.VentanaGravamenesGarantias1.EfectosControles(true);
                this.VentanaGravamenesGarantias1.CargarContenido(controlEntidad);
                this.mpeGravamenesGarantias.Show();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*BOTON DE ELIMINAR GRAVAMEN*/
    protected void btnEliminarGravamen_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                if (this.grdGravamenes.ContadorSeleccionados() > 0)
                {
                    GarantiasGravemenesEntidad entidad = null;
                    foreach (GridViewRow row1 in gridGravamenesInterno.Rows)
                    {
                        CheckBox checkBoxColumn = (CheckBox)gridGravamenesInterno.Rows[row1.RowIndex].FindControl("chkBox1");
                        if (checkBoxColumn.Checked)
                        {
                            Label lblId = (Label)gridGravamenesInterno.Rows[row1.RowIndex].FindControl("lblIdGravamen");

                            entidad = new GarantiasGravemenesEntidad();
                            entidad.IdGravamen = int.Parse(lblId.Text);
                            entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                            respuesta = wsGarantias.GarantiasGravamenesEliminar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));

                            //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                            if (respuesta.ValorError.Equals(18))
                            {
                                BloquearControlesDesactualizados();
                                BarraMensaje(respuesta, pantallaIdOculto.Value);
                            }
                        }
                    }
                    GridViewGravamenesInternoActualizar();
                    EfectoDdlIndGravamen();
                    DdlIndGravamen();
                }
                else
                {
                    //VERIFICA SI EL GRID CONTIENE REGISTROS
                    if (this.grdGravamenes.ContadorElementos() > 0)
                    {
                        //ERROR DE NO SELECCION DE REGISTROS
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_8");
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

    /*BOTON DE MODIFICAR GRAVAMEN*/
    protected void btnModificarGravamen_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                if (this.grdGravamenes.ContadorElementos() > 0)
                {
                    if (this.grdGravamenes.ContadorSeleccionados().Equals(1))
                    {
                        //CARGA LOS VALORES DE LOS CONTROLES
                        CargaArregloControles();
                        this.VentanaGravamenesGarantias1.LimpiarContenido();
                        this.VentanaGravamenesGarantias1.EfectosControles(false);
                        this.VentanaGravamenesGarantias1.CargarContenido(controlEntidad);

                        //CARGA LOS VALORES DESDE BD
                        AsignarValoresRegistroGravamenes();
                    }
                    else
                    {
                        //ERROR DE NO SELECCION DE REGISTROS O MULTISELECCION
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_4");
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

    /*BOTON DE AGREGAR POLIZA - B16S01*/
    protected void btnAgregarPoliza_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (this.grdPolizas.ContadorElementos() < 1)
                {
                    CargaArregloControles();
                    this.VentanaPolizasGarantia1.LimpiarContenido();
                    this.VentanaPolizasGarantia1.EfectosControles(true);
                    this.VentanaPolizasGarantia1.CargarContenido(controlEntidad);
                    this.VentanaPolizasGarantia1.EfectosControlesExcepciones(true);
                    this.mpePolizasGarantias.Show();
                }
                else
                {
                    //ERROR DE CANTIDAD DE REGISTROS PERMITIDOS EN LA CUADRICULA
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "Grid_1");
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

    /*BOTON DE ELIMINAR POLIZA - B16S01*/
    protected void btnEliminarPoliza_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                if (this.grdPolizas.ContadorSeleccionados() > 0)
                {
                    PolizaEntidad entidad = null;
                    foreach (GridViewRow row1 in gridPolizasInterno.Rows)
                    {
                        CheckBox checkBoxColumn = (CheckBox)gridPolizasInterno.Rows[row1.RowIndex].FindControl("chkBox1");
                        if (checkBoxColumn.Checked)
                        {
                            Label lblId = (Label)gridPolizasInterno.Rows[row1.RowIndex].FindControl("lblIdPoliza");

                            entidad = new PolizaEntidad();
                            entidad.IdPoliza = int.Parse(lblId.Text);
                            entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                            respuesta = wsGarantias.GarantiasRealesPolizaEliminar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));

                            //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                            if (respuesta.ValorError.Equals(18))
                            {
                                BloquearControlesDesactualizados();
                                BarraMensaje(respuesta, pantallaIdOculto.Value);
                            }
                        }
                    }
                    GridViewPolizasInternoActualizar();
                    EfectoDdlIndPoliza();
                    DdlIndPoliza();
                }
                else
                {
                    //VERIFICA SI EL GRID CONTIENE REGISTROS
                    if (this.grdPolizas.ContadorElementos() > 0)
                    {
                        //ERROR DE NO SELECCION DE REGISTROS
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_8");
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

    /*BOTON DE MODIFICAR POLIZA - B16S01*/
    protected void btnModificarPoliza_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                if (this.grdPolizas.ContadorElementos() > 0)
                {
                    if (this.grdPolizas.ContadorSeleccionados().Equals(1))
                    {
                        //CARGA LOS VALORES DE LOS CONTROLES
                        CargaArregloControles();
                        this.VentanaPolizasGarantia1.LimpiarContenido();
                        this.VentanaPolizasGarantia1.CargarContenido(controlEntidad);
                        this.VentanaPolizasGarantia1.EfectosControles(false);
                        //CARGA LOS VALORES DESDE BD
                        AsignarValoresRegistroPolizas();

                        this.VentanaPolizasGarantia1.EfectosControlesExcepciones(false);
                    }
                    else
                    {
                        //ERROR DE NO SELECCION DE REGISTROS O MULTISELECCION
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_4");
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

    #endregion

    #endregion

    #region ENTIDADES

    //Bloque 7 Requerimiento 1-24381561
    /*OBTIENE LOS DETALLES DEL ID DEL REGISTRO*/
    private GarantiasRealesEntidad ConsultarDetalleEntidad()
    {
        try
        {
            GarantiasRealesEntidad entidadRetorno = new GarantiasRealesEntidad();
            GarantiasRealesEntidad entidadConsulta = new GarantiasRealesEntidad();

            if (pantallaModuloOculto.Value != null && hdnIdGeneral.Value.Length > 0)//VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            {
                entidadConsulta.IdGarantiaReal = int.Parse(hdnIdGeneral.Value);

                entidadRetorno = wsGarantias.GarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
            }

            return entidadRetorno;

            //if (pantallaModuloOculto.Value != null && pantallaIdOculto.Value != "0") //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            //{
            //    GarantiasRealesEntidad _entidadConsulta = new GarantiasRealesEntidad();
            //    _entidadConsulta.IdGarantiaReal = int.Parse(pantallaIdOculto.Value);

            //     _entidadRetorno = wsGarantias.GarantiasRealesConsultarDetalle(_entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

            //     return _entidadRetorno;
            //}

            //return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*MODIFICA UN REGISTRO DE LA ENTIDAD GARANTIA REAL*/
    private void ModificarEntidadReal()
    {
        try
        {
            GarantiasRealesEntidad entidad = null;
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            entidad = DeControlesAEntidadGeneralValuacionCedulasPolizas();
            if (entidad != null)
            {
                respuesta = wsGarantias.GarantiasRealesModificar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));
                BarraMensaje(respuesta, pantallaIdOculto.Value);

                //Bloque 7 Requerimiento 1-24381561
                if (respuesta.ValorError.Equals(0))
                {
                    this.pantallaIdOculto.Value = (respuesta.ValorEstado.ToString());
                    hdnIdGeneral.Value = (respuesta.ValorEstado.ToString());
                }

                //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                if (respuesta.ValorError.Equals(18))
                    BloquearControlesDesactualizados();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*VALIDA LA SECCION GENERAL DEL FORMULARIO, SI EL REGISTRO EXISTE, SI ESTÁ INCOMPLETO O COMPLETO*/
    private bool ValidarEntidadReal()
    {
        try
        {
            GarantiasRealesEntidad entidad = new GarantiasRealesEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();
            bool existeError = false;

            //Control de Cambios 1.2
            this.idGarantiaRealTipoBienOculto.Value = string.Empty;

            //ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidadGeneralValuacionCedulasPolizas();

            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                respuesta = wsGarantias.GarantiasRealesValidar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                //SI NO EXISTE ERROR EN LA VALIDACION
                if (respuesta.ValorError.Equals(0))
                {
                    //ASIGNACION DEL ID DE LA VALIDACION
                    //this.lblIdGeneral.Text = _respuesta.ValorEstado.ToString();//ELIMINAR
                    this.hdnIdGeneral.Value = respuesta.ValorEstado.ToString();
                    existeError = false;
                }
                else
                {
                    //SI LA GARANTIA EXISTE DE FORMA INCOMPLETA 
                    if (respuesta.ValorError.Equals(-1))
                    {
                        //this.lblIdGeneral.Text = "EXISTE";//ELIMINAR
                        this.hdnIdGeneral.Value = respuesta.ValorEstado.ToString();
                    }
                    else
                    {
                        //Control de Cambios 1.2
                        //_existeError = true;
                        //this.hdnIdGeneral.Value = "-1";
                        ////ERROR POR DUPLICADO DEBIDO A QUE LA GARANTIA EXISTE DE FORMA COMPLETA
                        //BarraMensaje(_respuesta, pantallaIdOculto.Value);

                        //VERIFICACION DE ACTUALIZACION DE TIPO BIEN 1 A TIPO BIEN 2
                        if (respuesta.ValorError.Equals(-2))
                        {
                            existeError = true;
                            //SE ESTABLECE EL ID GARANTIA EN LA SECCION GENERAL
                            if (respuesta.ValorEstadoCadena.Replace(" ", "").Substring(respuesta.ValorEstadoCadena.Replace(" ", "").Length - 1).Equals(","))
                                this.idGarantiaRealTipoBienOculto.Value = respuesta.ValorEstadoCadena.Replace(" ", "").Substring(0, respuesta.ValorEstadoCadena.Replace(" ", "").Length - 1);
                            else
                                this.idGarantiaRealTipoBienOculto.Value = respuesta.ValorEstadoCadena.Replace(" ", "");
                            //MENSAJE DE CONFIRMACIÓN
                            this.ConfirmarBoxActualizar_SetConfirmationBoxEvent(null, null, "SYS_10");
                            this.mpeConfirmarBoxActualizar.Show();
                        }
                        else
                        {
                            existeError = true;
                            this.hdnIdGeneral.Value = "-1";
                            //ERROR POR DUPLICADO DEBIDO A QUE LA GARANTIA EXISTE DE FORMA COMPLETA 
                            BarraMensaje(respuesta, pantallaIdOculto.Value);
                        }
                    }
                }
            }

            return existeError;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*INSERTA UN NUEVO REGISTRO TASADOR*/
    private void InsertarEntidadTasador()
    {
        try
        {
            GarantiasRealesTasadoresEntidad entidad = new GarantiasRealesTasadoresEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();
            //bool _existeError = false;

            //ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidadTasadores();
            //Control de Cambios 1.5 Garantias Reales II
            entidad.IdGarantiaRealTasador = entidad.IdTasador;

            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                respuesta = wsGarantias.GarantiasRealesTasadoresInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                /*//SI EXISTE ERROR EN LA VALIDACION
                if (_respuesta.ValorEstado.Equals(0))
                {
                    //MENSAJE DE ERROR
                    BarraMensaje(_respuesta, pantallaIdOculto.Value);
                }*/

                //Control de Cambios 1.5 Garantias Reales II
                //SI EXISTE ERROR EN LA VALIDACION
                if (!respuesta.ValorEstado.Equals(0))
                {
                    this.hdnIdEmpresaTasadora.Value = respuesta.ValorEstado.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Control de Cambios 1.2
    /*ACTUALIZAR EL TIPO DE BIEN 1 A TIPO BIEN 2*/
    private void ActualizarEntidadTipoBien()
    {
        try
        {
            GarantiasRealesEntidad entidad;
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            string script = string.Empty;

            //OBTIENE LAS GARANTIAS A ACTUALIZAR
            string[] idGarantiasReales = this.idGarantiaRealTipoBienOculto.Value.Split(',');

            //Control de Cambios 1.5 Garantias Reales II
            //REGISTROS QUE NO PUDIERON SER ACTUALIZADOS
            List<string> idGarantiaRealNoActualizado = new List<string>();
            //REGISTROS QUE PUDIERON SER ACTUALIZADOS
            List<string> idGarantiaRealActualizado = new List<string>();

            //OPERACIONES A MOSTRAR
            List<string> idOperacion = new List<string>();


            for (int i = 0; i < idGarantiasReales.Length; i++)
            {
                if (idGarantiasReales[i].Length > 0)
                {
                    script = string.Empty;
                    entidad = new GarantiasRealesEntidad();

                    //ASIGNA LOS VALORES A LA ENTIDAD
                    entidad.IdGarantiaReal = int.Parse(idGarantiasReales[i]);
                    //INDICADOR DEL NUEVO TIPO BIEN
                    entidad.CodTipoBien = 2;

                    //Requerimiento Bloque 7 1-24381561
                    CrearControlRegistros(entidad);

                    //ACTUALIZA EL VALOR DEL TIPO DE BIEN
                    respuesta = wsGarantias.GarantiasRealesModificarTipoBien(entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));

                    string garantiaRealActualizada = string.Empty;

                    if (respuesta.ValorEstadoCadena != null)
                        garantiaRealActualizada = respuesta.ValorEstadoCadena.Split('|')[0];

                    //Control de Cambios 1.5 Garantias Reales II
                    if (!respuesta.ValorError.Equals(0))
                        idGarantiaRealNoActualizado.Add(idGarantiasReales[i]);
                    else
                        //_idGarantiaRealActualizado.Add(_idGarantiasReales[i]);
                        //idGarantiaRealActualizado.Add(respuesta.ValorEstado.ToString());
                        idGarantiaRealActualizado.Add(garantiaRealActualizada);

                    //OBTIENE LAS OPERACIONES A MOSTRAR
                    if (respuesta.ValorEstadoCadena != null)
                    {
                        if (respuesta.ValorEstadoCadena.Contains("|"))
                        {
                            string[] operacionesMostrar = respuesta.ValorEstadoCadena.Split('|')[1].Split(',');
                            for (int c = 0; c < operacionesMostrar.Length; c++)
                            {
                                //VERIFICA SI LA OPERACION YA EXISTE EN EL CONTENEDOR
                                string existe = (from opera in idOperacion
                                                 where opera.Equals(operacionesMostrar[c])
                                                 select opera).FirstOrDefault();

                                //AGREGAR AL CONTENEDOR SI NO EXISTE PREVIAMENTE
                                if (existe == null)
                                    idOperacion.Add(operacionesMostrar[c]);
                            }
                        }
                    }

                }
            }

            //Control de Cambios 1.5 Garantias Reales II
            //LIMPIA LOS VALORES PREVIAMENTE ESTABLECIDOS GARANTIAS REALES
            this.idGarantiaRealTipoBienOculto.Value = string.Empty;
            //ESTABLECE PARA APERTURA LOS REGISTROS QUE FUERON MODIFICADOS
            for (int i = 0; i < idGarantiaRealActualizado.Count; i++)
            {
                this.idGarantiaRealTipoBienOculto.Value += idGarantiaRealActualizado[i];
                //SI NO ES EL ULTIMO REGISTRO ENTONCES SE AÑADE LA COMA
                if (!i.Equals(idGarantiaRealActualizado.Count - 1))
                    this.idGarantiaRealTipoBienOculto.Value += ",";
            }

            //LIMPIA LOS VALORES PREVIAMENTE ESTABLECIDOS OPERACIONES
            this.idOperacionOculto.Value = string.Empty;
            //ESTABLECE PARA APERTURA LAS OPERACIONES
            for (int c = 0; c < idOperacion.Count; c++)
            {
                this.idOperacionOculto.Value += idOperacion[c];
                //SI NO ES EL ULTIMO REGISTRO ENTONCES SE AÑADE LA COMA
                if (!c.Equals(idOperacion.Count - 1))
                    this.idOperacionOculto.Value += ",";
            }

            //Control de Cambios 1.5 Garantias Reales II
            //SI NO EXISTEN REGISTROS NO ACTUALIZADOS
            if (idGarantiaRealNoActualizado.Count.Equals(0))
            {
                AbrirRegistrosActualizados();
                //AbrirRegistrosOperaciones();
                //CIERRA LA VENTANA ACTUAL
                Cerrar();
            }
            else
            {
                //SI EXISTEN REGISTROS NO ACTUALIZADOS SE DEBE DE DESPLEGAR EL MENSAJE DE ADVERTENCIA
                this.MensajeAdvertencia1_SetConfirmationBoxEvent(null, null, "SYS_11");
                this.mpeAdvertenciaBox.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Control de Cambios 1.2
    /*INSERTA EL REGISTRO CON EL TIPO DE BIEN 2*/
    private void InsertarEntidadTipoBien2()
    {
        try
        {
            GarantiasRealesEntidad entidad = new GarantiasRealesEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            //ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidadGeneralValuacionCedulasPolizas();
            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                //INSERCION DE LA SECCION ENCABEZADO
                respuesta = wsGarantias.GarantiasRealesInsertarGenerales(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                //SI EXISTE ERROR EN LA VALIDACION
                if (respuesta.ValorEstado.Equals(0))
                {
                    //MENSAJE DE ERROR
                    BarraMensaje(respuesta, pantallaIdOculto.Value);
                }
                else
                {
                    this.hdnIdGeneral.Value = respuesta.ValorEstado.ToString();
                    CargarControlesSinError();
                }
            }
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

            ListasWS.PantallasEntidad pantalla = new ListasWS.PantallasEntidad();
            pantalla.CodPantalla = int.Parse(pantallaModuloOculto.Value);
            pantalla.Pestana = string.Empty;

            //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD        
            controlEntidad = this.wsListas.AdministracionesContenidosConsultaControl(pantalla).ToList();
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

    /*LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR*/
    private void LimpiarBarraMensaje()
    {
        if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
        {
            this.divBarraMensaje.Visible = false;
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

    /*BLOQUEA LOS CONTROLES CUANDO LA GARANTIA ESTÁ DESACTUALIZADA*/
    private void BloquearControlesDesactualizados()
    {
        AdministrarControlesExcepcionesCedulas(false);
        AdministrarControlesExcepcionesTasadores(false);
        AdministrarControlesExcepcionesValuacion(false);
        AdministrarControlesExcepcionesGeneral(false);
        DeshabilitarControlesGuardar(true);
    }

    /*BLOQUEA LOS CONTROLES AL GUARDAR UN REGISTRO NUEVO*/
    private void BloquearControlesGuardar()
    {
        try
        {
            AdministrarControlesExcepcionesGeneral(false);
            AdministrarControlesExcepcionesValuacion(false);
            AdministrarControlesExcepcionesTasadores(false);
            AdministrarControlesExcepcionesCedulas(false);
            AdministrarControlesExcepcionesGravamenes(false);
            AdministrarControlesExcepcionesPolizas(false);

            btnGuardar.Enabled = false;
            btnGuardarNuevo.Enabled = false;
            btnGuardarCerrar.Enabled = false;
            btnLimpiarR.Enabled = false;
            btnAyudaGuardar.Enabled = false;

            this.btnLimpiar.Enabled = false;
            this.btnEliminarTasador.Enabled = false;
            this.gridCedulasInterno.Enabled = false;
            this.gridTasadoresInterno.Enabled = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*MUESTRA LAS NOTIFICACIONES DEL MANEJO DE GRIDS*/
    private void MensajesGrid()
    {
        //SI ES MODO EDICION
        if (!this.pantallaIdOculto.Value.Equals("0"))
        {
            if (gridTasadoresInterno != null)
            {
                //SI POSEE REGISTROS SE DEBE DESPLEGAR EL MENSAJE DE ADVERTENCIA
                //if (gridTasadoresInterno.Rows.Count > 0)
                //{
                //MENSAJE DE ADVERTENCIA GRID
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_38");
                this.mpeInformarBox.Show();
                //}
            }

            if (gridCedulasInterno != null)
            {
                //SI POSEE REGISTROS SE DEBE DESPLEGAR EL MENSAJE DE ADVERTENCIA
                if (gridCedulasInterno.Rows.Count > 0)
                {
                    //MENSAJE DE ADVERTENCIA GRID
                    this.InformarBox2_SetConfirmationBoxEvent(null, null, "SYS_37");
                    this.mpeInformarBox2.Show();
                }
            }

            if (gridGravamenesInterno != null)
            {
                //SI POSEE REGISTROS SE DEBE DESPLEGAR EL MENSAJE DE ADVERTENCIA
                if (gridGravamenesInterno.Rows.Count > 0)
                {
                    //MENSAJE DE ADVERTENCIA GRID
                    this.InformarBox3_SetConfirmationBoxEvent(null, null, "SYS_39");
                    this.mpeInformarBox3.Show();
                }
            }

            //B16S01
            if (gridPolizasInterno != null)
            {
                //SI POSEE REGISTROS SE DEBE DESPLEGAR EL MENSAJE DE ADVERTENCIA
                if (gridPolizasInterno.Rows.Count > 0)
                {
                    //MENSAJE DE ADVERTENCIA GRID
                    this.InformarBox4_SetConfirmationBoxEvent(null, null, "SYS_40");
                    this.mpeInformarBox4.Show();
                }
            }
        }

    }

    private void SetDataKeys(GridView _gridView, String[] _dataKeysString)
    {
        _gridView.DataKeyNames = _dataKeysString;
    }

    #endregion

    #region VENTANAS MENSAJES

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

    protected void InformarBox2_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBox2.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void InformarBox3_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBox3.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void InformarBox4_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBox4.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Control de Cambios 1.5 Garantias Reales II
    protected void MensajeAdvertencia1_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            MensajeAdvertencia1.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje);
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

    //EVENTO MENSAJES VENTANA EMERGENTE DE BUSQUEDA EMPRESA TASADORA
    protected void InformarBoxBusquedaEmpresaTasadora_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBoxBusquedaEmpresaTasadora.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //EVENTO MENSAJES VENTANA EMERGENTE DE BUSQUEDA PERSONA TASADORA
    protected void InformarBoxBusquedaPersonaTasadora_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBoxBusquedaPersonaTasadora.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //EVENTO MENSAJES VENTANA EMERGENTE DE ADMINISTRACION DE CEDULAS
    protected void InformarBoxCedulasHipotecarias_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBoxCedulasHipotecarias.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void InformarBoxCedulasHipotecarias_SetConfirmationBoxEvent(object sender, EventArgs e, string type, string valorReemplazo1, string valorReemplazo2)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBoxCedulasHipotecarias.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo1).Replace("@$@", valorReemplazo2));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Control de Cambios 1.2
    #region MENSAJE CONFIRMAR

    protected void ConfirmarBoxActualizar_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            ConfirmarBoxActualizar.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

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
            bitacoraBanderas = null;
            generadorControles = null;

            mensajesEntidad = null;
            bitacorasEntidad = null;

            disponible = true;
        }
    }

    #endregion

}