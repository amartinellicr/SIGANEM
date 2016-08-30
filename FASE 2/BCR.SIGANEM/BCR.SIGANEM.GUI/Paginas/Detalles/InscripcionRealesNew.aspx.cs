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
using ConsultasWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class InscripcionRealesNew : System.Web.UI.Page
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

    #region VENTANA CONSULTA CLASE OPERACION

    private GridView gridViewClaseOperacion = null;
    private Button btnCerrarClaseOperacion = null;
    private Button btnAceptarClaseOperacion = null;

    #endregion

    #region VENTANA CONSULTA CLASE NOTARIO

    private GridView gridViewClaseNotario = null;
    private Button btnCerrarClaseNotario = null;
    private Button btnAceptarClaseNotario = null;

    #endregion
    #endregion

    #region REFERENCIAS

    private BitacoraFlags bitacoraBanderas = new BitacoraFlags();
    private GeneradorControles generadorControles = new GeneradorControles();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private GarantiasWS.BitacorasEntidad bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
    private ConsultasWS.BitacorasEntidad bitacorasConsultasWSEntidad = new ConsultasWS.BitacorasEntidad();

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();
    private SiganemGarantiasWS wsGarantias = new SiganemGarantiasWS();
    private SiganemConsultasWS wsConsultas = new SiganemConsultasWS();

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

            #region MENSAJE INFORMAR FORMULARIO

            Button btnAceptarInformar = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);
            btnAceptarInformar.CausesValidation = false;
            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

            #endregion

            #region EVENTOS GRIDVIEWS

            //GRID VENTANA BUSQUEDA CLASE VEHICULO
            GridViewClaseVehiculo(sender, e);

            //GRID VENTANA BUSQUEDA CLASE OPERACION
            GridViewClaseOperacion(sender, e);

            //GRID VENTANA BUSQUEDA CLASE NOTARIO
            GridViewClaseNotario(sender, e);

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

            #region VENTANA BUSQUEDA CLASE OPERACION

            #region BOTONES CLASE OPERACION

            btnCerrarClaseOperacion = ((Button)this.BusquedaClaseOperacion.FindControl("cmdMainEmergenteCancelar"));
            btnCerrarClaseOperacion.Click += new EventHandler(btnCerrarClaseOperacion_Click);
            btnCerrarClaseOperacion.CausesValidation = false;

            btnAceptarClaseOperacion = ((Button)this.BusquedaClaseOperacion.FindControl("cmdMainEmergenteAceptar"));
            btnAceptarClaseOperacion.Click += new EventHandler(btnAceptarClaseOperacion_Click);
            btnAceptarClaseOperacion.CausesValidation = false;

            #region MENSAJE INFORMAR VENTANA BUSQUEDA CLASE OPERACION GARANTIA REAL

            Button btnAceptarInformarOperacionGarantiaReal = (Button)this.InformarBoxBusquedaClaseOperacion.FindControl("wucBtnAceptar");
            btnAceptarInformarOperacionGarantiaReal.Click += new EventHandler(btnAceptarInformarEmergenteClaseOperacion_Click);
            btnAceptarInformarOperacionGarantiaReal.CausesValidation = false;
            this.InformarBoxBusquedaClaseOperacion.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxBusquedaClaseOperacion_SetConfirmationBoxEvent);

            #endregion

            #endregion

            #endregion

            #region VENTANA BUSQUEDA CLASE NOTARIO

            #region BOTONES CLASE NOTARIO

            btnCerrarClaseNotario = ((Button)this.BusquedaClaseNotario.FindControl("cmdMainEmergenteCancelar"));
            btnCerrarClaseNotario.Click += new EventHandler(btnCerrarClaseNotario_Click);
            btnCerrarClaseNotario.CausesValidation = false;

            btnAceptarClaseOperacion = ((Button)this.BusquedaClaseNotario.FindControl("cmdMainEmergenteAceptar"));
            btnAceptarClaseOperacion.Click += new EventHandler(btnAceptarClaseNotario_Click);
            btnAceptarClaseOperacion.CausesValidation = false;

            #region MENSAJE INFORMAR VENTANA BUSQUEDA CLASE OPERACION GARANTIA REAL

            Button btnAceptarInformarClaseNotario = (Button)this.InformarBoxBusquedaClaseNotario.FindControl("wucBtnAceptar");
            btnAceptarInformarClaseNotario.Click += new EventHandler(btnAceptarInformarEmergenteClaseNotario_Click);
            btnAceptarInformarClaseNotario.CausesValidation = false;
            this.InformarBoxBusquedaClaseNotario.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBoxBusquedaClaseNotario_SetConfirmationBoxEvent);

            #endregion

            #endregion

            #endregion

            if (!IsPostBack)
            {
                VariablesGlobales();
                valorReemplazo = string.Empty;
            }
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
                Tabs();
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

    #region VENTANA BUSQUEDA CLASE OPERACION

    protected void btnCerrarClaseOperacion_Click(object sender, EventArgs e)
    {
        this.mpeBusquedaClaseOperacion.Hide();
    }

    protected void btnAceptarClaseOperacion_Click(object sender, EventArgs e)
    {
        try
        {
            SeleccionarRegistroClaseOperacion(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #region VENTANA BUSQUEDA CLASE NOTARIO

    protected void btnCerrarClaseNotario_Click(object sender, EventArgs e)
    {
        this.mpeBusquedaClaseNotario.Hide();
    }

    protected void btnAceptarClaseNotario_Click(object sender, EventArgs e)
    {
        try
        {
            SeleccionarRegistroClaseNotario(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
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

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                LimpiarSubSeccionNotario();
                ValidarBotonLimpiarNotario();
            }
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

    protected void btnAceptarInformarEmergenteClaseVehiculo_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxBusquedaClaseVehiculo.Hide();
        this.mpeBusquedaClaseVehiculo.Show();
    }

    protected void btnAceptarInformarEmergenteClaseOperacion_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxBusquedaClaseOperacion.Hide();
        this.mpeBusquedaClaseOperacion.Show();
    }

    protected void btnAceptarInformarEmergenteClaseNotario_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxBusquedaClaseNotario.Hide();
        this.mpeBusquedaClaseNotario.Show();
    }

    #endregion

    #endregion

    #region CONTROL DE REGISTRO

    /*ASIGNA LOS VALORES DEL CONTROL DE REGISTRO A LA ENTIDAD */
    private void CrearControlRegistros(InscripcionGarantiasRealesEntidad _entidad)
    {
        try
        {
            string lblCodigoUsuario = ((HtmlInputHidden)this.Master.FindControl("codUsuarioOculto")).Value;

            _entidad.CodUsuarioIngreso = lblCodigoUsuario;

            _entidad.IndMetodoInsercion = Resources.Resource._metodoInsercion;

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
            InscripcionGarantiasRealesEntidad resultado = ConsultarDetalleEntidad();

            ObtenerControlRegistros(resultado);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*OBTIENE LOS DATOS DEL CONTROL DE REGISTRO EN MODO EDICION*/
    private void ObtenerControlRegistros(InscripcionGarantiasRealesEntidad _entidad)
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
            AdministrarControlesExcepcionesDetalleRelacion(false);
            AdministrarControlesExcepcionesDatosAdicionales(false);

            if (this.ddlTipoBien.Enabled)
                DeshabilitarControlesGuardar(true);
            else
                DeshabilitarControlesGuardar(false);
        }
        //else
        //{
        //    //AdministrarControlesExcepcionesDatosAdicionales(true);
        //}
    }

    /*DESHABILITA LOS BOTONES DE GUARDADO EN EL MENU DE ACCIONES*/
    private void DeshabilitarControlesGuardar(bool deshabilitados)
    {
        ((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesGuardar(deshabilitados);   
        //((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesEstilos(deshabilitados);
    }

    /*DESHABILITA LOS BOTONES DE GUARDADO EN EL MENU DE ACCIONES*/
    private void DeshabilitarControlesBorrar(bool deshabilitados)
    {     
        ((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesBorrar(deshabilitados);  
    }

    /*DESHABILITA BOTON DATOS ADICIONALES NOTARIO*/
    private void HabilitaBotonLimpiarNotario(bool habilitado)
    {
        try
        {
            this.btnLimpiar.Enabled = habilitado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
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
        this.btnConsultar.Enabled = habilitado;

        //Control de Cambios 1.1
        this.chkEstadoDuplicado.Enabled = habilitado;
        this.chkEstadoHorizontal.Enabled = habilitado;
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION DETALLE RELACIÓN*/
    private void AdministrarControlesExcepcionesDetalleRelacion(bool habilitado)
    {
        this.txtContabilidad.Enabled = habilitado;
        this.txtOficina.Enabled = habilitado;
        this.txtMoneda.Enabled = habilitado;
        this.txtProducto.Enabled = habilitado;
        this.txtNumero.Enabled = habilitado;
        this.txtIdentificacionCliente.Enabled = habilitado;
        this.txtNombreCliente.Enabled = habilitado;
        this.txtClaseGarantia.Enabled = habilitado;
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION DATOS ADICIONALES*/
    private void AdministrarControlesExcepcionesDatosAdicionales(bool habilitado)
    {
        this.ddlIndInscripcion.Enabled = habilitado;
        this.txtFechaAnotacion.Enabled = habilitado;
        this.calendarExtenderFechaAnotacion.Enabled = habilitado;
        this.rfvFechaAnotacion.Enabled = habilitado;
        this.imbFechaAnotacion.Enabled = habilitado;
        this.txtFechaInscripcion.Enabled = habilitado;
        this.rfvFechaInscripcion.Enabled = habilitado;
        this.imbFechaInscripcion.Enabled = habilitado;
        this.calendarExtenderFechaInscripcion.Enabled = habilitado;
        this.ddlPartido.Enabled = habilitado;
        this.txtTomo.Enabled = habilitado;
        this.rfvTomo.Enabled = habilitado;
        this.txtFolio.Enabled = habilitado;
        this.rfvFolio.Enabled = habilitado;
        this.txtAsiento.Enabled = habilitado;
        this.rfvAsiento.Enabled = habilitado;
        this.txtSecuencia.Enabled = habilitado;
        //this.rfvSecuencia.Enabled = habilitado;
        this.txtSubSecuencia.Enabled = habilitado;
        //this.rfvSubSecuencia.Enabled = habilitado;
        this.txtConsecutivo.Enabled = habilitado;
        //this.rfvConsecutivo.Enabled = habilitado;
        this.txtValorConsultarAbogado.Enabled = habilitado;
        this.imbValorConsultar.Enabled = habilitado;
        this.txtTipoIdentificacion.Enabled = habilitado;
        this.rfvTipoIdentificacion.Enabled = habilitado;
        this.txtIdentificacion.Enabled = habilitado;
        this.rfvIdentificacion.Enabled = habilitado;
        this.txtNombre.Enabled = habilitado;
        this.rfvNombre.Enabled = habilitado;
        this.btnLimpiar.Enabled = habilitado;
        this.txtComentario.Enabled = habilitado;
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
        //EXCEPCION VALIDACION PARA GUARDAR LOS DATOS
        if (!ValidarGuardarExcepciones())
        {
           LimpiarBarraMensajeGeneral();

            if (!ValidarRangoFechaMayor())
            {

                if (pantallaIdOculto.Value.Equals("0"))
                {
                    InsertarEntidadInscripcion();
                }
                else
                {
                    ModificarEntidadInscripcion();
                }
            }
            //Requerimiento Bloque 7 1-24381561 
            MostrarControlRegistrosGuardar();
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
                    hdnIdClaseVehiculo.Value = valoresGrid[1];
                    txtDesClaseVehiculo.Text = valoresGrid[0];
                }
                this.mpeBusquedaClaseVehiculo.Hide();
            }
            else
            {
                //VERIFICA SI EL GRID CONTIENE MAS DE UN REGISTRO SELECCIONADO
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

    #region GRIDVIEW CLASE OPERACION

    private void gridViewClaseOperacion_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        gridViewColumn = new GridViewColumn();
        this.gridViewClaseOperacion.Columns.Add(gridViewColumn.CreateBoundField("DesTipoOperacion", string.Empty, "Tipo Operación", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridViewClaseOperacion.Columns.Add(gridViewColumn.CreateBoundField("DesNumeroOperacion", string.Empty, "Número Operación", HorizontalAlign.Center, false, true));

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridViewClaseOperacion, "IdGarantiaOperacion", lblID);

        lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridViewClaseOperacion, "Operacion", lblID);
    }

    #endregion

    #region BUSQUEDA CLASE OPERACION

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE CLASE OPERACIONES SELECCIONADO*/
    private void SeleccionarRegistroClaseOperacion(object sender, EventArgs e)
    {
        try
        {
            //VALIDA QUE SOLO UN ELEMENTO SEA EL SELECCIONADO
            if (((wucGridEmergente)this.BusquedaClaseOperacion).ContadorSeleccionados().Equals(1))
            {
                string[] valoresGrid;
                GarantiasOperacionesRelacionEntidad retornoDetalleGarantiaOperacionEntidad = new GarantiasOperacionesRelacionEntidad();
                List<string> valorSeleccionado = ((wucGridEmergente)this.BusquedaClaseOperacion).ObtenerValoresSeleccionadosOcultos("lblIdGarantiaOperacion", "lblOperacion");

                foreach (string valor in valorSeleccionado)
                {
                    valoresGrid = valor.Split('|');

                    //ID OPERACION
                    hdnIdOperacion.Value = valoresGrid[0];

                    //ID GARANTIA OPERACION
                    hdnIdClaseOperacion.Value = valoresGrid[1];

                    if (this.hdnIdClaseOperacion.Value.Length > 0)
                    {
                        retornoDetalleGarantiaOperacionEntidad = DeEntidadAControlesDetalleRelacionCargar(this.hdnIdOperacion.Value, this.hdnIdClaseOperacion.Value);
                    }
                }

                this.mpeBusquedaClaseOperacion.Hide();

                //DESHABILITA SECCION GENERAL
                AdministrarControlesExcepcionesGeneral(false);

                //HABILITA SECCION DATOS ADICIONALES
                AdministrarControlesExcepcionesDatosAdicionales(true);

                //HABILITA CONTROLES GUARDAR BARRA SUPERIOR
                DeshabilitarControlesGuardar(false);

                //DESHABILITA CONTROLES LIMPIAR SECCION NOTARIO
                HabilitaBotonLimpiarNotario(false);

                ControlesDatosAdicionales();
                DdlIndIscripcion();
                DeEntidadAControlesDatosAdicionales(retornoDetalleGarantiaOperacionEntidad);
            }
            else
            {
                //VERIFICA SI EL GRID CONTIENE MAS DE UN REGISTRO SELECCIONADO
                if (((wucGridEmergente)this.BusquedaClaseOperacion).ContieneRegistros())
                {
                    this.mpeBusquedaClaseOperacion.Hide();
                    this.InformarBoxBusquedaClaseOperacion_SetConfirmationBoxEvent(sender, e, "SYS_4");
                    this.mpeInformarBoxBusquedaClaseOperacion.Show();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewClaseOperacion(object sender, EventArgs e)
    {
        // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
        this.gridViewClaseOperacion = (GridView)this.BusquedaClaseOperacion.FindControl("MasterGridView");

        // ASIGNA COLUMNAS PROPIAS DEL CONTROL
        this.gridViewClaseOperacion.Init += new EventHandler(gridViewClaseOperacion_Init);

        // ASIGNA COLUMNAS PROPIAS DEL CONTROL
        this.gridViewClaseOperacion_Init(sender, e);

        //TITULOS
        ((Label)this.BusquedaClaseOperacion.FindControl("lblTitulo")).Text = "Administración de Operaciones";
        ((Label)this.BusquedaClaseOperacion.FindControl("lblSubTitulo")).Text = "Seleccione un registro.";

        //ASIGNA DATA KEYS
        String[] DataKeysString = { "IdGarantiaOperacion" };
        this.SetDataKeys(gridViewClaseOperacion, DataKeysString);
    }

    #endregion

    #region BUSQUEDA CLASE NOTARIO

    /*REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE CLASE NOTARIO SELECCIONADO*/
    private void SeleccionarRegistroClaseNotario(object sender, EventArgs e)
    {
        try
        {
            //VALIDA QUE SOLO UN ELEMENTO SEA EL SELECCIONADO
            if (((wucGridEmergente)this.BusquedaClaseNotario).ContadorSeleccionados().Equals(1))
            {
                string[] valoresGrid;
                List<KeyValuePair<int, string>> valorSeleccionado = ((wucGridEmergente)this.BusquedaClaseNotario).ObtenerTodosValoresSeleccionados("lblIdNotario");
                foreach (KeyValuePair<int, string> valor in valorSeleccionado)
                {
                    valoresGrid = valor.Value.Split('|');
                    hdnIdClaseNotario.Value = valoresGrid[3];
                    txtTipoIdentificacion.Text = valoresGrid[0];
                    txtIdentificacion.Text = valoresGrid[1];
                    txtNombre.Text = valoresGrid[2];

                    //DESHABILITA CAMPOS INSCRIPCION - BOTON LIMPIAR DATOS NOTARIO
                    if (txtIdentificacion.Text == "")
                    {
                        btnLimpiar.Enabled = false;
                    }
                    else
                    {
                        btnLimpiar.Enabled = true;
                    }
                }
                this.mpeBusquedaClaseNotario.Hide();
            }
            else
            {
                //VERIFICA SI EL GRID CONTIENE MAS DE UN REGISTRO SELECCIONADO
                if (((wucGridEmergente)this.BusquedaClaseNotario).ContieneRegistros())
                {
                    this.mpeBusquedaClaseNotario.Hide();
                    this.InformarBoxBusquedaClaseNotario_SetConfirmationBoxEvent(sender, e, "SYS_4");
                    this.mpeInformarBoxBusquedaClaseNotario.Show();
                }
                else
                {
                    //SI EL REGISTRO A BUSCAR NO EXISTE
                    txtNombre.Text = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CONSULTA CLASES ABOGADOS*/
    private List<NotariosEntidad> ConsultarClaseNotario()
    {
        try
        {
            NotariosEntidad notarioConsulta = new NotariosEntidad();
            List<NotariosEntidad> retornoListaNotarioEntidad = null;

            notarioConsulta.CodNotario = txtValorConsultarAbogado.Text;
            retornoListaNotarioEntidad = wsConsultas.NotariosConsultarIdentificacion(notarioConsulta, AsignarValoresBitacoraConsultasWS(EnumTipoBitacora.CONSULTAR)).ToList();

            return retornoListaNotarioEntidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewClaseNotario(object sender, EventArgs e)
    {
        // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
        this.gridViewClaseNotario = (GridView)this.BusquedaClaseNotario.FindControl("MasterGridView");
        this.BusquedaClaseNotario.TextoGridVacio("No hay Disponible ningún registro en este Catálogo.");

        // ASIGNA COLUMNAS PROPIAS DEL CONTROL
        this.gridViewClaseNotario.Init += new EventHandler(gridViewClaseNotario_Init);

        // ASIGNA COLUMNAS PROPIAS DEL CONTROL
        this.gridViewClaseNotario_Init(sender, e);

        //TITULOS
        ((Label)this.BusquedaClaseNotario.FindControl("lblTitulo")).Text = "Administración de Abogados";
        ((Label)this.BusquedaClaseNotario.FindControl("lblSubTitulo")).Text = "Seleccione un registro.";

        //ASIGNA DATA KEYS
        String[] DataKeysString = { "IdNotario" };
        this.SetDataKeys(gridViewClaseNotario, DataKeysString);
    }

    #endregion

    #region GRIDVIEW CLASE NOTARIO

    private void gridViewClaseNotario_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridViewClaseNotario, "IdNotario", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridViewClaseNotario.Columns.Add(gridViewColumn.CreateBoundField("DesTipoPersona", string.Empty, "Tipo Identificación", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridViewClaseNotario.Columns.Add(gridViewColumn.CreateBoundField("CodNotario", string.Empty, "Identificación", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridViewClaseNotario.Columns.Add(gridViewColumn.CreateBoundField("DesNotario", string.Empty, "Nombre", HorizontalAlign.Center, false, true));
    }

    #endregion

    #region DETALLE RELACION

    /*ASIGNA LOS VALORES DE LA ENTIDAD A LOS CONTROLES DE LA SECCION DETALLE RELACION*/
    private GarantiasOperacionesRelacionEntidad DeEntidadAControlesDetalleRelacionCargar(string idOperacion, string idClase)
    {
        try
        {
            GarantiasOperacionesRelacionEntidad retornoDetalleGarantiaOperacionEntidad = new GarantiasOperacionesRelacionEntidad();
            GarantiasOperacionesEntidad consultaOperacionEntidad = new GarantiasOperacionesEntidad();
            GarantiasOperacionesConsultaEntidad consultaGarantiaOperacionEntidad = new GarantiasOperacionesConsultaEntidad();

            GarantiasOperacionesEntidad retornoDetalleOperacionEntidad = new GarantiasOperacionesEntidad();
            GarantiasOperacionesClientesEntidad retornoInformacionClienteEntidad = new GarantiasOperacionesClientesEntidad();

            //SE ASIGNA EL ID DE LA OPERACION PARA CONSULTAR EL DETALLE
            consultaOperacionEntidad.IdGarantiaOperacion = int.Parse(idOperacion);
            //SE OBTIENE EL DETALLE DE LA OPERACION SELECCIONADA
            retornoDetalleOperacionEntidad = wsGarantias.GarantiasOperacionesConsultarDetalle(consultaOperacionEntidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

            //SE ASIGNA EL ID DE LA GARANTIA OPERACION PARA CONSULTAR EL DETALLE
            consultaOperacionEntidad.IdGarantiaOperacion = int.Parse(idClase);
            //SE OBTIENE EL DETALLE DE LA GARANTIA DE OPERACION
            retornoDetalleGarantiaOperacionEntidad = wsGarantias.GarantiasOperacionesConsultarRelacion(consultaOperacionEntidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

            //SE ASIGNAN LOS DATOS DE OPERACION 
            consultaGarantiaOperacionEntidad.IdTipoOperacion = retornoDetalleOperacionEntidad.IdTipoOperacion;
            consultaGarantiaOperacionEntidad.Conta = retornoDetalleOperacionEntidad.Conta;
            consultaGarantiaOperacionEntidad.Oficina = retornoDetalleOperacionEntidad.Oficina;
            consultaGarantiaOperacionEntidad.Moneda = retornoDetalleOperacionEntidad.Moneda;
            consultaGarantiaOperacionEntidad.Producto = retornoDetalleOperacionEntidad.Producto;
            consultaGarantiaOperacionEntidad.Numero = retornoDetalleOperacionEntidad.Numero;

            //SE OBTIENE EL DETALLE DEL CLIENTE ASOCIADO A AL OPERACION
            retornoInformacionClienteEntidad = wsGarantias.GarantiasOperacionesConsultaDataBridge(consultaGarantiaOperacionEntidad);

            if (retornoDetalleOperacionEntidad != null)
            {
                DeEntidadAControlesDetalleRelacion(retornoDetalleOperacionEntidad, retornoInformacionClienteEntidad, retornoDetalleGarantiaOperacionEntidad);
            }

            return retornoDetalleGarantiaOperacionEntidad;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region CONTROLES

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

            //BTN CONSULTAR
            controlSeleccionado = ControlesBuscar(this.btnConsultar.ID);
            this.btnConsultar.Text = controlSeleccionado.DesColumna;

            #endregion

            #region SECCION DETALLE RELACION

            //LBL CONTABILIDAD
            controlSeleccionado = ControlesBuscar(this.lblContabilidad.ID);
            this.lblContabilidad.Text = controlSeleccionado.DesColumna;

            //LBL OFICINA
            controlSeleccionado = ControlesBuscar(this.lblOficina.ID);
            this.lblOficina.Text = controlSeleccionado.DesColumna;

            //LBL MONEDA
            controlSeleccionado = ControlesBuscar(this.lblMoneda.ID);
            this.lblMoneda.Text = controlSeleccionado.DesColumna;

            //LBL PRODUCTO
            controlSeleccionado = ControlesBuscar(this.lblProducto.ID);
            this.lblProducto.Text = controlSeleccionado.DesColumna;

            //LBL NÚMERO
            controlSeleccionado = ControlesBuscar(this.lblNumero.ID);
            this.lblNumero.Text = controlSeleccionado.DesColumna;

            //LBL IDENTIFICACIÓN CLIENTE
            controlSeleccionado = ControlesBuscar(this.lblIdentificacionCliente.ID);
            this.lblIdentificacionCliente.Text = controlSeleccionado.DesColumna;

            //LBL NOMBRE DE CLIENTE
            controlSeleccionado = ControlesBuscar(this.lblNombreCliente.ID);
            this.lblNombreCliente.Text = controlSeleccionado.DesColumna;

            //LBL CLASE DE GARANTIA
            controlSeleccionado = ControlesBuscar(this.lblClaseGarantia.ID);
            this.lblClaseGarantia.Text = controlSeleccionado.DesColumna;

            #endregion

            #region SECCION DATOS ADICIONALES

            //LBL IND. INSCRIPCION
            controlSeleccionado = ControlesBuscar(this.lblIndInscripcion.ID);
            this.lblIndInscripcion.Text = controlSeleccionado.DesColumna;

            //LBL FECHA ANOTACIÓN
            controlSeleccionado = ControlesBuscar(this.lblFechaAnotacion.ID);
            this.lblFechaAnotacion.Text = controlSeleccionado.DesColumna;

            //LBL FECHA INSCRIPCION
            controlSeleccionado = ControlesBuscar(this.lblFechaInscripcion.ID);
            this.lblFechaInscripcion.Text = controlSeleccionado.DesColumna;

            //LBL PARTIDO
            controlSeleccionado = ControlesBuscar(this.lblPartido.ID);
            this.lblPartido.Text = controlSeleccionado.DesColumna;

            //LBL TOMO
            controlSeleccionado = ControlesBuscar(this.lblTomo.ID);
            this.lblTomo.Text = controlSeleccionado.DesColumna;

            //LBL FOLIO
            controlSeleccionado = ControlesBuscar(this.lblFolio.ID);
            this.lblFolio.Text = controlSeleccionado.DesColumna;

            //LBL ASIENTO
            controlSeleccionado = ControlesBuscar(this.lblAsiento.ID);
            this.lblAsiento.Text = controlSeleccionado.DesColumna;

            //LBL SECUENCIA
            controlSeleccionado = ControlesBuscar(this.lblSecuencia.ID);
            this.lblSecuencia.Text = controlSeleccionado.DesColumna;

            //LBL SUB SECUENCIA
            controlSeleccionado = ControlesBuscar(this.lblSubSecuencia.ID);
            this.lblSubSecuencia.Text = controlSeleccionado.DesColumna;

            //LBL CONSECUTIVO
            controlSeleccionado = ControlesBuscar(this.lblConsecutivo.ID);
            this.lblConsecutivo.Text = controlSeleccionado.DesColumna;

            #region ABOGADO ASIGNADO

            //LBL TITULO ABOGADO ASIGNADO
            controlSeleccionado = ControlesBuscar(this.lblAbogadoAsignado.ID);
            this.lblAbogadoAsignado.Text = controlSeleccionado.DesColumna;

            //LBL VALOR A CONSULTAR
            controlSeleccionado = ControlesBuscar(this.lblValorConsultar.ID);
            this.lblValorConsultar.Text = controlSeleccionado.DesColumna;

            //LBL TIPO IDENTIFICACIÓN
            controlSeleccionado = ControlesBuscar(this.lblTipoIdentificacion.ID);
            this.lblTipoIdentificacion.Text = controlSeleccionado.DesColumna;

            //LBL IDENTIFICACIÓN
            controlSeleccionado = ControlesBuscar(this.lblIdentificacion.ID);
            this.lblIdentificacion.Text = controlSeleccionado.DesColumna;

            //LBL NOMBRE
            controlSeleccionado = ControlesBuscar(this.lblNombre.ID);
            this.lblNombre.Text = controlSeleccionado.DesColumna;

            //LBL COMENTARIO
            controlSeleccionado = ControlesBuscar(this.lblComentario.ID);
            this.lblComentario.Text = controlSeleccionado.DesColumna;

            //BTN LIMPIAR
            controlSeleccionado = ControlesBuscar(this.btnLimpiar.ID);
            this.btnLimpiar.Text = controlSeleccionado.DesColumna;

            #endregion

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
                                             select control).FirstOrDefault();

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
            #region GENERAL
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

            ////EFECTO DE AUTOCOMPLETAR PARA EL CAMPO N BIEN 
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

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EXTRAE LOS CONTROLES DESDE BD A LA SECCION DATOS ADICIONALES*/
    private void ControlesDatosAdicionales()
    {
        try
        {
            #region DATOS ADICIONALES

            //DDL IND INSCRIPCION
            controlSeleccionado = ControlesBuscar(this.ddlIndInscripcion.ID);
            this.ddlIndInscripcion.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, controlSeleccionado.ValorServicioWeb);
            this.ddlIndInscripcion.DataTextField = "Texto";
            this.ddlIndInscripcion.DataValueField = "Valor";
            this.ddlIndInscripcion.DataBind();
            this.ddlIndInscripcion.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndInscripcion, controlSeleccionado.ValorDefecto);

            //DDL PARTIDO 
            if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -") || this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("9 -") || this.ddlTipoBien.SelectedItem.Text.Substring(0, 4).Equals("10 -"))
            {
                this.ddlPartido.Text = string.Empty;
            }
                else
            {
                controlSeleccionado = ControlesBuscar(this.ddlPartido.ID);
                this.ddlPartido.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
                this.ddlPartido.DataTextField = "Texto";
                this.ddlPartido.DataValueField = "Valor";
                this.ddlPartido.DataBind();
                this.ddlPartido.CssClass = controlSeleccionado.CssTipo;
                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlPartido, controlSeleccionado.ValorDefecto);
            }

            //BLOQUEAR ESCRITURA EN EL CAMPO FECHA ANOTACION
            txtFechaAnotacion.Attributes.Add("readonly", "readonly");

            //BLOQUEAR ESCRITURA EN EL CAMPO FECHA INSCRIPCION
            txtFechaInscripcion.Attributes.Add("readonly", "readonly");

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*LIMPIA LOS CONTROLES TIPO TEXTBOX*/
    private void Limpiar()
    {
        if (this.txtNBien.Enabled)
        {
            this.txtClaseVehiculo.Text = string.Empty;
            this.txtDesClaseVehiculo.Text = string.Empty;
            this.hdnIdClaseVehiculo.Value = string.Empty;
            this.txtNBien.Text = string.Empty;
        }

        this.txtFechaAnotacion.Text = string.Empty;
        this.txtFechaInscripcion.Text = string.Empty;
        this.txtTomo.Text = string.Empty;
        this.txtFolio.Text = string.Empty;
        this.txtAsiento.Text = string.Empty;
        this.txtSecuencia.Text = string.Empty;
        this.txtSubSecuencia.Text = string.Empty;
        this.txtConsecutivo.Text = string.Empty;
        this.txtValorConsultarAbogado.Text = string.Empty;
        this.txtTipoIdentificacion.Text = string.Empty;
        this.txtIdentificacion.Text = string.Empty;
        this.txtNombre.Text = string.Empty;
        this.txtComentario.Text = string.Empty;
        this.hdnIdClaseNotario.Value = string.Empty;

        LimpiarBarraMensaje();
    }

    /*LIMPIA LOS CONTROLES TIPO TEXTBOX SUB SECCION NOTARIOS*/
    private void LimpiarSubSeccionNotario()
    {
        #region SECCION DATOS ADICIONALES NOTARIOS

        this.hdnIdClaseNotario.Value = string.Empty;
        this.txtValorConsultarAbogado.Text = string.Empty;
        this.txtIdentificacion.Text = string.Empty;
        this.txtTipoIdentificacion.Text = string.Empty;
        this.txtNombre.Text = string.Empty;

        #endregion

        LimpiarBarraMensaje();
    }

    private void CargarControlesSinError()
    {
        try
        {
            //DESHABILITA LA SECCION GENERAL
            AdministrarControlesExcepcionesGeneral(false);

            //DESHABILITA LA SECCION DETALLE REALACION
            AdministrarControlesExcepcionesDetalleRelacion(false);

            //DESHABILITA LA SECCION DATOS ADICIONALES
            AdministrarControlesExcepcionesDatosAdicionales(false);

            //DESHABILITA LOS CONTROLES DE GUARDADO
            DeshabilitarControlesGuardar(true);

            //DESHABILITA LOS CONTROLES DE BORRAR
            DeshabilitarControlesBorrar(true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region MODIFICAR INSCRIPCION

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

                //CARGA LOS VALORES DESDE BD
                DeEntidadAControlesDetalleRelacion();

                //DESHABILITA LA SECCION DETALLE RELACION
                AdministrarControlesExcepcionesDetalleRelacion(false);

                //CARGA LOS VALORES DESDE BD
                DeEntidadAControlesDatosAdicionalesCargar();
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
                InscripcionGarantiasRealesEntidad entidadConsulta = new InscripcionGarantiasRealesEntidad();
                entidadConsulta.IdInscripcionGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                InscripcionGarantiasRealesEntidad entidadRetorno = wsGarantias.InscripcionGarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                if (entidadRetorno != null)
                {
                    // GarantiasRealesEntidad GarantiasRealesConsultarDetalle

                    GarantiasRealesEntidad entidadConsultaGarantiaReal = new GarantiasRealesEntidad();
                    entidadConsultaGarantiaReal.IdGarantiaReal = entidadRetorno.IdGarantiaReal;

                    GarantiasRealesEntidad entidadRetornoGarantiaReal = wsGarantias.GarantiasRealesConsultarDetalle(entidadConsultaGarantiaReal, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                    //Requerimiento Bloque 7 1-24381561 
                    ObtenerControlRegistros(entidadRetorno);

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlTipoBien, entidadRetornoGarantiaReal.IdTipoBien.ToString());
                    DdlTiposBienes();

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlClase, entidadRetornoGarantiaReal.IdClaseTipoBien.ToString());

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlProvincia, entidadRetornoGarantiaReal.IdProvincia.ToString());

                    if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("1 -") || this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
                    {
                        if (entidadRetornoGarantiaReal.IdCodigoHorizontalidad == null)
                        {
                            AdministrarBlanco(this.ddlHorizontal.ID, true);
                            this.chkEstadoHorizontal.Checked = true;
                        }
                        else
                        {
                            generadorControles.SeleccionarOpcionDropDownList(this.ddlHorizontal, entidadRetornoGarantiaReal.IdCodigoHorizontalidad.ToString());
                            this.chkEstadoHorizontal.Checked = false;
                        }

                        if (entidadRetornoGarantiaReal.IdCodigoDuplicado == null)
                        {
                            AdministrarBlanco(this.ddlDuplicado.ID, true);
                            this.chkEstadoDuplicado.Checked = true;
                        }
                        else
                        {
                            generadorControles.SeleccionarOpcionDropDownList(this.ddlDuplicado, entidadRetornoGarantiaReal.IdCodigoDuplicado.ToString());
                            this.chkEstadoDuplicado.Checked = false;
                        }
                    }
                    else
                    {
                        generadorControles.SeleccionarOpcionDropDownList(this.ddlHorizontal, entidadRetornoGarantiaReal.IdCodigoHorizontalidad.ToString());
                        generadorControles.SeleccionarOpcionDropDownList(this.ddlDuplicado, entidadRetornoGarantiaReal.IdCodigoDuplicado.ToString());
                    }

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlClaseBuque, entidadRetornoGarantiaReal.IdClaseBuque.ToString());
                    generadorControles.SeleccionarOpcionDropDownList(this.ddlClaseAeronave, entidadRetornoGarantiaReal.IdClaseAeronave.ToString());

                    this.hdnIdClaseVehiculo.Value = entidadRetornoGarantiaReal.IdClaseVehiculo.ToString();
                    this.txtDesClaseVehiculo.Text = entidadRetornoGarantiaReal.DesClaseVehiculo;

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlFormato, entidadRetornoGarantiaReal.FormatoIdentificacionVehiculo.ToString());
                    DdlFormatoIdentificacionVehiculo();

                    this.txtNBien.Text = entidadRetornoGarantiaReal.CodBien;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES PARA LA SECCION DETALLE RELACION DESDE BD PARA EL CASO DE LAS MODIFICACIONES */
    private void DeEntidadAControlesDetalleRelacion()
    {
        try
        {
            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null && !pantallaIdOculto.Value.Equals("0"))
            {
                InscripcionGarantiasRealesEntidad entidadConsulta = new InscripcionGarantiasRealesEntidad();
                entidadConsulta.IdInscripcionGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                InscripcionGarantiasRealesEntidad entidadRetorno = wsGarantias.InscripcionGarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                if (entidadRetorno != null)
                {
                    //entidadRetorno.IdGarantiaOperacion ES EL IDOPERACION                   
                    DeEntidadAControlesDetalleRelacionCargar(entidadRetorno.IdOperacion.ToString(), entidadRetorno.IdGarantiaOperacion.ToString());

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES PARA LA SECCION DATOS ADICIONALES DESDE BD PARA EL CASO DE LAS MODIFICACIONES */
    private void DeEntidadAControlesDatosAdicionalesCargar()
    {
        try
        {
            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null && !pantallaIdOculto.Value.Equals("0"))
            {
                InscripcionGarantiasRealesEntidad entidadConsulta = new InscripcionGarantiasRealesEntidad();
                entidadConsulta.IdInscripcionGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                InscripcionGarantiasRealesEntidad entidadRetorno = wsGarantias.InscripcionGarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                if (entidadRetorno != null)
                {

                    //Requerimiento Bloque 7 1-24381561 
                    ObtenerControlRegistros(entidadRetorno);

                    ControlesDatosAdicionales();
                    generadorControles.SeleccionarOpcionDropDownList(this.ddlIndInscripcion, entidadRetorno.IndInscripcion.ToString());
                    DdlIndIscripcion();

                    this.hdnIdClaseOperacion.Value = entidadRetorno.IdGarantiaOperacion.ToString();

                    if (entidadRetorno.FechaAnotacion.ToString().Length > 0)
                        txtFechaAnotacion.Text = string.Format("{0:d}", entidadRetorno.FechaAnotacion);


                    if (entidadRetorno.FechaInscripcion.ToString().Length > 0)
                        txtFechaInscripcion.Text = string.Format("{0:d}", entidadRetorno.FechaInscripcion);

                    if (entidadRetorno.Partido != null)
                        generadorControles.SeleccionarOpcionDropDownList(this.ddlPartido, entidadRetorno.Partido.ToString());
                    else
                        AdministrarBlanco(this.ddlPartido.ID, true);

                    this.txtTomo.Text = entidadRetorno.Tomo;
                    this.txtFolio.Text = entidadRetorno.Folio;
                    this.txtAsiento.Text = entidadRetorno.Asiento;
                    this.txtSecuencia.Text = entidadRetorno.Secuencia;
                    this.txtSubSecuencia.Text = entidadRetorno.SubSecuencia;
                    this.txtConsecutivo.Text = entidadRetorno.Consecutivo;

                    this.txtComentario.Text = entidadRetorno.Comentario;
                    
                    if (entidadRetorno.IdAbogado != null)
                    {
                        List<NotariosEntidad> retornoNotarios = new List<NotariosEntidad>();
                        retornoNotarios = ConsultarClaseNotario();

                        if (retornoNotarios != null)
                        {
                            NotariosEntidad notario = (from elemento in retornoNotarios
                                                       where elemento.IdNotario.Equals(entidadRetorno.IdAbogado)
                                                       select elemento).FirstOrDefault();

                            if (notario != null)
                            {
                                txtTipoIdentificacion.Text = notario.DesTipoPersona;
                                txtIdentificacion.Text = notario.CodNotario;
                                txtNombre.Text = notario.DesNotario;
                                hdnIdClaseNotario.Value = notario.IdNotario.ToString();

                                //HABILITA BOTON LIMPIAR DATOS NOTARIO
                                if (txtIdentificacion.Text.Length > 0)
                                {
                                    btnLimpiar.Enabled = true;
                                }
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

    #endregion

    /*CARGA LOS VALORES DESDE LOS CONTROLES DE LA SECCION GENERAL, HACIA LA ENTIDAD PARA REALIZAR ACCIONES*/
    private GarantiasRealesEntidad DeControlesAEntidadGeneral()
    {
        try
        {
            GarantiasRealesEntidad reales = null;

            if (pantallaModuloOculto.Value.Length > 0)
            {
                reales = new GarantiasRealesEntidad();

                #region SECCION GENERAL

                reales.IdTipoBien = int.Parse(this.ddlTipoBien.SelectedItem.Value);

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

            }

            return reales;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE LA ENTIDAD GARANTIAS OPERACIONES, HACIA LOS CONTROLES DE LA SECCION DETALLE RELACION PARA REALIZAR ACCIONES*/
    private void DeEntidadAControlesDetalleRelacion(GarantiasOperacionesEntidad _entidad, GarantiasOperacionesClientesEntidad _entidad2, GarantiasOperacionesRelacionEntidad _entidad3)
    {
        try
        {

            this.txtContabilidad.Text = _entidad.Conta;
            this.txtOficina.Text = _entidad.Oficina;
            this.txtMoneda.Text = _entidad.Moneda;
            this.txtProducto.Text = _entidad.Producto;
            this.txtNumero.Text = _entidad.Numero;
            this.txtIdentificacionCliente.Text = _entidad.IdentificacionClienteRUC;
            this.txtNombreCliente.Text = _entidad2.NombreClienteSICC;

            List<ListasWS.ListaEntidad> clasesGarantias = wsListas.ClasesGarantiasPRT17Lista(string.Empty).ToList();

            string claseGarantia = (from elemento in clasesGarantias
                                    where elemento.Valor.Equals(_entidad3.IdClaseGarantiaPrt17.ToString())
                                    select elemento.Texto).FirstOrDefault();

            this.txtClaseGarantia.Text = claseGarantia;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE LA ENTIDAD GARANTIAS OPERACIONES, HACIA LOS CONTROLES DE LA SECCION DATOS ADICIONALES PARA REALIZAR ACCIONES*/
    private void DeEntidadAControlesDatosAdicionales(GarantiasOperacionesRelacionEntidad relacionEntidad)
    {
        try
        {

            if (relacionEntidad.IdPartido != null)
            {
                generadorControles.SeleccionarOpcionDropDownList(ddlPartido, relacionEntidad.IdPartido.ToString());
            }
            else
            {
                if (relacionEntidad.IdProvincia != null)
                {
                    generadorControles.SeleccionarOpcionDropDownList(ddlPartido, relacionEntidad.IdProvincia.ToString());
                }
                else
                {
                    AdministrarBlanco("ddlPartido", true);
                }

            }

            ddlPartido.Enabled = false;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE LOS CONTROLES HACIA LA ENTIDAD PARA REALIZAR ACCIONES*/
    private InscripcionGarantiasRealesEntidad DeControlesAEntidad()
    {
        try
        {
            InscripcionGarantiasRealesEntidad entidad = null;

            if (pantallaModuloOculto.Value.Length > 0)
            {
                entidad = new InscripcionGarantiasRealesEntidad();

                #region SECCION INSCRIPCION GARANTIA REAL

                if (this.hdnIdGeneral.Value.Length < 1)
                    entidad.IdInscripcionGarantiaReal = 0;
                else
                    entidad.IdInscripcionGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                if (this.hdnIdClaseOperacion.Value.Length < 1)
                    entidad.IdGarantiaOperacion = 0;
                else
                    entidad.IdGarantiaOperacion = int.Parse(this.hdnIdClaseOperacion.Value);

                entidad.IndInscripcion = int.Parse(this.ddlIndInscripcion.SelectedItem.Value);

                if (this.txtFechaAnotacion.Text.Length < 1)
                    entidad.FechaAnotacion = null;
                else
                    entidad.FechaAnotacion = DateTime.Parse(this.txtFechaAnotacion.Text);

                if (this.txtFechaInscripcion.Text.Length < 1)
                    entidad.FechaInscripcion = null;
                else
                    entidad.FechaInscripcion = DateTime.Parse(this.txtFechaInscripcion.Text);

                if (this.txtTomo.Text.Length < 1)
                    entidad.Tomo = null;
                else
                    entidad.Tomo = this.txtTomo.Text;

                if (this.txtFolio.Text.Length < 1)
                    entidad.Folio = null;
                else
                    entidad.Folio = this.txtFolio.Text;

                if (this.txtAsiento.Text.Length < 1)
                    entidad.Asiento = null;
                else
                    entidad.Asiento = this.txtAsiento.Text;

                if (this.txtSecuencia.Text.Length < 1)
                    entidad.Secuencia = null;
                else
                    entidad.Secuencia = this.txtSecuencia.Text;

                if (this.txtSubSecuencia.Text.Length < 1)
                    entidad.SubSecuencia = null;
                else
                    entidad.SubSecuencia = this.txtSubSecuencia.Text;

                if (this.txtConsecutivo.Text.Length < 1)
                    entidad.Consecutivo = null;
                else
                    entidad.Consecutivo = this.txtConsecutivo.Text;

                if (this.hdnIdClaseNotario.Value.Length < 1)
                    entidad.IdAbogado = null;
                else
                    entidad.IdAbogado = int.Parse(this.hdnIdClaseNotario.Value);

                if (this.txtComentario.Text.Length < 1)
                    entidad.Comentario = string.Empty;
                else
                    entidad.Comentario = this.txtComentario.Text;

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

    #region VALIDACIONES

    /*VALIDACION RANGO DE FECHA MAYOR A*/
    private bool ValidarRangoFechaMayor()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        if (generadorControles.ObtenerComparacion(txtFechaAnotacion.Text, txtFechaInscripcion.Text, EnumTipoComparacion.MAYORIGUAL, TypeCode.DateTime))
        {
            existeError = true;

            //MENSAJE DE ERROR DE FECHAS DIFERENTES
            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblFechaInscripcion.Text, "mayor a " + this.lblFechaAnotacion.Text);
            this.mpeInformarBox.Show();
        }
        return existeError;
    }

    /*VALIDACION DE CARACTERES ESPECIALES*/
    private bool ValidarCaracterEspecial(string texto)
    {
        bool existeCaracter = false;
        //NO SE PERMITEN CARACTERES ESPECIALES
        var regexItem = new Regex(@"^[a-zA-Z0-9 \-.,_:ÁÉÍÓÚÑáéíóúñ]*$");

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

        var regexNoVocales = new Regex(@"^[^aeiouAEIOU]{3}");

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
            //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES NO FIJO
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
                    if (!regexNoVocales.IsMatch(this.txtNBien.Text))
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

    /*EFECTO FORMATO MAXIMO CAMPO*/
    private bool ValidarGuardarExcepciones()
    {
        bool retorno = false;

        if (ValidarCaracterEspecial(this.txtComentario.Text))
        {
            //MENSAJE DE ERROR POR CARACTER ESPECIAL
            BarraMensaje(null, "");
            retorno = true;
        }

        return retorno;
    }

    #endregion

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

                #region DDL INDICADOR INSCRIPCION
                case "DDLINDINSCRIPCION":
                    DdlIndIscripcion();
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

            if (ddlClase.Items.Count > 0)
            {
                for (int i = 0; i < this.ddlClase.Items.Count; i++)
                {
                    if ((this.ddlClase.Items[i].Text.Equals("Cédula Hipotecaria")) || (this.ddlClase.Items[i].Text.Equals("Bono de Prenda")))
                    {
                        this.ddlClase.Items.RemoveAt(i);
                        i = this.ddlClase.Items.Count;
                    }
                }
            }

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

    #region SECCION DATOS ADICIONALES

    private void DdlIndIscripcion()
    {
        try
        {
            string valorIndInscripcion = string.Empty;
            string valorIndentificacionNotario = string.Empty;

            valorIndInscripcion = this.ddlIndInscripcion.SelectedItem.Text.Substring(0, 3);

            //SI EL IND. INSCRIPCION ES 2 //CALENDARIO FECHA ANOTACIÓN
            if (valorIndInscripcion.Equals("2 -"))
            {
                this.calendarExtenderFechaAnotacion.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();
                this.txtFechaAnotacion.Enabled = true;
                this.imbFechaAnotacion.Enabled = true;
                this.rfvFechaAnotacion.Enabled = true;

                //DESHABILITA Y LIMPIA CAMPOS CALENDARIO FECHA INSCRIPCION
                this.txtFechaInscripcion.Text = string.Empty;
                this.txtFechaInscripcion.Enabled = false;
                this.imbFechaInscripcion.Enabled = false;
                this.rfvFechaInscripcion.Enabled = false;

                //DESHABILITA CAMPOS INSCRIPCION - DATOS ADICIONALES
                this.txtTomo.Text = string.Empty;
                this.txtTomo.Enabled = false;
                this.rfvTomo.Enabled = false;

                this.txtFolio.Text = string.Empty;
                this.txtFolio.Enabled = false;
                this.rfvFolio.Enabled = false;

                this.txtAsiento.Text = string.Empty;
                this.txtAsiento.Enabled = false;
                this.rfvAsiento.Enabled = false;

                this.txtSecuencia.Text = string.Empty;
                this.txtSecuencia.Enabled = false;
                //this.rfvSecuencia.Enabled = false;

                this.txtSubSecuencia.Text = string.Empty;
                this.txtSubSecuencia.Enabled = false;
                //this.rfvSubSecuencia.Enabled = false;

                this.txtConsecutivo.Text = string.Empty;
                this.txtConsecutivo.Enabled = false;
                //this.rfvConsecutivo.Enabled = false;

                //DESHABILITA CAMPOS INSCRIPCION - DATOS ADICIONALES NOTARIO
                //this.txtTipoIdentificacion.Text = string.Empty;
                this.txtTipoIdentificacion.Enabled = false;
                this.rfvTipoIdentificacion.Enabled = false;

                //this.txtIdentificacion.Text = string.Empty;
                this.txtIdentificacion.Enabled = false;
                this.rfvIdentificacion.Enabled = false;

                //this.txtNombre.Text = string.Empty;
                this.txtNombre.Enabled = false;
                this.rfvNombre.Enabled = false;

            }
            else
            {
                //SI EL IND. INSCRIPCION  ES IGUAL A 3 
                if (valorIndInscripcion.Equals("3 -"))
                {                  
                    if ( (pantallaIdOculto.Value.Equals("0")) || txtFechaAnotacion.Text.Length.Equals(0))
                    {
                        this.txtFechaAnotacion.Text = string.Empty;
                    }
                    
                    //HABILITA CALENDARIO INSCRIPCION 
                    this.calendarExtenderFechaInscripcion.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();
                    this.txtFechaInscripcion.Enabled = true;
                    this.imbFechaInscripcion.Enabled = true;
                    this.rfvFechaInscripcion.Enabled = true;

                    //HABILITA CAMPOS INSCRIPCION
                    this.txtTomo.Enabled = true;
                    this.rfvTomo.Enabled = true;
                    this.txtFolio.Enabled = true;
                    this.rfvFolio.Enabled = true;
                    this.txtAsiento.Enabled = true;
                    this.rfvAsiento.Enabled = true;
                    this.txtSecuencia.Enabled = true;
                    //this.rfvSecuencia.Enabled = true;
                    this.txtSubSecuencia.Enabled = true;
                    //this.rfvSubSecuencia.Enabled = true;
                    this.txtConsecutivo.Enabled = true;
                    //this.rfvConsecutivo.Enabled = true;

                    //DESHABILITA Y LIMPIA CALENDARIO FECHA ANOTACIÓN               
                    //this.txtFechaAnotacion.Text = string.Empty;
                    this.txtFechaAnotacion.Enabled = false;
                    this.imbFechaAnotacion.Enabled = false;
                    this.rfvFechaAnotacion.Enabled = false;

                    //DESHABILITA CAMPOS INSCRIPCION - DATOS ADICIONALES NOTARIO

                    this.txtTipoIdentificacion.Enabled = false;
                    this.rfvTipoIdentificacion.Enabled = true;

                    this.txtIdentificacion.Enabled = false;
                    this.rfvIdentificacion.Enabled = true;

                    this.txtNombre.Enabled = false;
                    this.rfvNombre.Enabled = true;

                }
            }

            ValidarBotonLimpiarNotario();
            LimpiarBarraMensaje();
        }
        catch (Exception ex)
        {
            throw ex;
        }
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

    #region METODOS PARA EL BOTONES

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

    /*BOTON DE BUSQUEDA PARA LA CLASE OPERACIONES*/
    protected void btnClaseOperacion_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (ValidarCaracterEspecial(this.txtNBien.Text))
                {
                    //MENSAJE DE ERROR POR CARACTER ESPECIAL
                    BarraMensaje(null, "");
                }
                else
                {
                    ((wucGridEmergente)this.BusquedaClaseVehiculo).BindGridView(this.ConsultaClaseVehiculo(txtClaseVehiculo.Text));
                    LimpiarBarraMensaje();
                    this.mpeBusquedaClaseOperacion.Show();
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

    #region METODOS PARA TEXT BOX

    protected void TextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {

            TextBox txt = ((TextBox)(sender));

            switch (txt.ID.ToString().ToUpper())
            {
                #region TXT TOMO
                case "TXTTOMO":
                    CompletarCerosIzquierda(txtTomo, mskTomo);
                    break;
                #endregion

                #region TXT FOLIO
                case "TXTFOLIO":
                    CompletarCerosIzquierda(txtFolio, mskFolio);
                    break;
                #endregion

                #region TXT ASIENTO
                case "TXTASIENTO":
                    CompletarCerosIzquierda(txtAsiento, mskAsiento);
                    break;
                #endregion

                #region TXT SECUENCIA
                case "TXTSECUENCIA":
                    CompletarCerosIzquierda(txtSecuencia, mskSecuencia);
                    break;
                #endregion

                #region TXT SUB SECUENCIA
                case "TXTSUBSECUENCIA":
                    CompletarCerosIzquierda(txtSubSecuencia, mskSubSecuencia);
                    break;
                #endregion

                #region TXT CONSECUTIVO
                case "TXTCONSECUTIVO":
                    CompletarCerosIzquierda(txtConsecutivo, mskConsecutivo);
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

    protected void Comentario_TextChanged(object sender, EventArgs e)
    {
        try
        {
            this.txtComentario.MaxLength = 45;


            if (ValidarCaracterEspecial(this.txtComentario.Text))
            {
                //MENSAJE DE ERROR POR CARACTER ESPECIAL
                BarraMensaje(null, "");
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*AUTOCOMPLETAR CEROS A LA IZQUIERDA SECCION DATOS ADICIONALES*/
    private void CompletarCerosIzquierda(TextBox txtNombre, MaskedEditExtender mskLongitud)
    {
        try
        {

            int cantidadTotal = mskLongitud.Mask.Length;
            int cantidadTxt = txtNombre.Text.Length;

            int diferencia = cantidadTotal - cantidadTxt;

            string valorFinal = string.Empty;

            for (int i = 0; i < diferencia; i++)
            {
                valorFinal = valorFinal + '0';
            }

            valorFinal = valorFinal + txtNombre.Text;
            txtNombre.Text = valorFinal;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    /*BOTON DE VALIDACION DE LA SECCION GENERAL*/
    protected void btnConsultar_Click(object sender, EventArgs e)
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

                        GarantiasRealesEntidad validacionEntidad = DeControlesAEntidadGeneral();
                        List<GarantiasOperacionesEntidad> retornoOperacion = wsGarantias.InscripcionGarantiasRealesOperacionesConsultar(validacionEntidad).ToList();

                        //VALIDACION SI EXISTEN OPERACIONES ASOCIADAS
                        if (retornoOperacion != null)
                        {
                            if (retornoOperacion.Count.Equals(0))
                            {
                                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_30");
                                this.mpeInformarBox.Show();
                            }
                            else
                            {
                                ((wucGridEmergente)this.BusquedaClaseOperacion).BindGridView(retornoOperacion);
                                //LimpiarBarraMensaje();
                                this.mpeBusquedaClaseOperacion.Show();
                            }
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

    /*BOTON DE BUSQUEDA PARA LA CLASE NOTARIOS */
    protected void btnClaseConsultarNotario_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                ((wucGridEmergente)this.BusquedaClaseNotario).BindGridView(ConsultarClaseNotario());
                LimpiarBarraMensaje();
                this.mpeBusquedaClaseNotario.Show();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #region ENTIDADES

    /*INSERTA EL REGISTRO*/
    private void InsertarEntidadInscripcion()
    {
        try
        {
            InscripcionGarantiasRealesEntidad entidad = new InscripcionGarantiasRealesEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            //ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidad();

            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                //INSERCION DE LA SECCION ENCABEZADO
                respuesta = wsGarantias.InscripcionGarantiasRealesInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                //SI EXISTE ERROR EN LA VALIDACION
                if (!respuesta.ValorEstado.Equals(0))
                {
                    this.hdnIdGeneral.Value = respuesta.ValorEstado.ToString();
                    CargarControlesSinError();
                }

                BarraMensaje(respuesta, pantallaIdOculto.Value);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*MODIFICAR EL REGISTRO*/
    private void ModificarEntidadInscripcion()
    {
        try
        {
            InscripcionGarantiasRealesEntidad entidad = new InscripcionGarantiasRealesEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            //ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidad();

            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                //INSERCION DE LA SECCION ENCABEZADO
                respuesta = wsGarantias.InscripcionGarantiasRealesModificar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));

                //SI EXISTE ERROR EN LA VALIDACION
                if (!respuesta.ValorEstado.Equals(0))
                {
                    this.hdnIdGeneral.Value = respuesta.ValorEstado.ToString();
                    // CargarControlesSinError();
                }

                BarraMensaje(respuesta, pantallaIdOculto.Value);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*OBTIENE LOS DETALLES DEL ID DEL REGISTRO*/
    private InscripcionGarantiasRealesEntidad ConsultarDetalleEntidad()
    {
        try
        {
            InscripcionGarantiasRealesEntidad entidadRetorno = new InscripcionGarantiasRealesEntidad();
            InscripcionGarantiasRealesEntidad entidadConsulta = new InscripcionGarantiasRealesEntidad();

            if (pantallaModuloOculto.Value != null && hdnIdGeneral.Value.Length > 0)//VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            {
                entidadConsulta.IdInscripcionGarantiaReal = int.Parse(hdnIdGeneral.Value);

                entidadRetorno = wsGarantias.InscripcionGarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
            }

            return entidadRetorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

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
            wsConsultas.Url = ConfigurationManager.AppSettings["ConsultasWS"].ToString();

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
    
    /*LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE */
    private void LimpiarBarraMensajeGeneral()
    {
        if (this.divBarraMensaje.Visible)
        {
            this.divBarraMensaje.Visible = false;
        }
    }

    //HABILITA BOTON LIMPIAR DATOS ADICIONALES NOTARIO, SIEMPRE QUE IDENTIFICACION NOTARIO CONTENGA DATOS
    private void ValidarBotonLimpiarNotario()
    {
        if (this.txtIdentificacion.Text.Length > 0)
        {
            this.btnLimpiar.Enabled = true;
        }
        else
        {
            this.btnLimpiar.Enabled = false;
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

    protected ConsultasWS.BitacorasEntidad AsignarValoresBitacoraConsultasWS(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA

            bitacorasConsultasWSEntidad.CodAccion = bitacoraBanderas.TipoBitacoraConsulta(_tipo);
            bitacorasConsultasWSEntidad.CodModulo = int.Parse(pantallaModuloOculto.Value);
            bitacorasConsultasWSEntidad.CodEmpresa = int.Parse(Resources.Resource._empresa);
            bitacorasConsultasWSEntidad.CodSistema = Resources.Resource._sistema;
            bitacorasConsultasWSEntidad.CodUsuario = codUsuarioOculto.Value;

            #endregion

            return bitacorasConsultasWSEntidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*BLOQUEA LOS CONTROLES CUANDO LA GARANTIA ESTÁ DESACTUALIZADA*/
    private void BloquearControlesDesactualizados()
    {
        AdministrarControlesExcepcionesGeneral(false);
        DeshabilitarControlesGuardar(true);
    }

    /*BLOQUEA LOS CONTROLES AL GUARDAR UN REGISTRO NUEVO*/
    private void BloquearControlesGuardar()
    {
        try
        {
            AdministrarControlesExcepcionesGeneral(false);
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

    //EVENTO MENSAJES VENTANA EMERGENTE DE BUSQUEDA CLASE OPERACION
    protected void InformarBoxBusquedaClaseOperacion_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBoxBusquedaClaseOperacion.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //EVENTO MENSAJES VENTANA EMERGENTE DE BUSQUEDA CLASE NOTARIO
    protected void InformarBoxBusquedaClaseNotario_SetConfirmationBoxEvent(object sender, EventArgs e, string type)
    {
        try
        {
            MensajesEntidad mensaje = this.Mensaje(type);
            InformarBoxBusquedaClaseNotario.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo));
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

                if (wsConsultas != null)
                {
                    wsConsultas.Dispose();
                    wsConsultas = null;
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