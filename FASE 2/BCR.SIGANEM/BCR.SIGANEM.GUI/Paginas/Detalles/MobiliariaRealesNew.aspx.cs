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

public partial class MobiliariaRealesNew : System.Web.UI.Page
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

            //  ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR DE LA PESTANA SUPERIOR IZQUIERDA NEGRA
            this.btnAyudaGuardar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAyuda").FindControl("cmdAyudaGuardar"));
            this.btnAyudaGuardar.Click += new EventHandler(btnAyudaGuardar_Click);

            //  ASIGNA CONTROL Y EVENTO AL BOTON DE MODIFICAR
            this.btnAyudaCerrar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAyuda").FindControl("cmdAyudaRegresar"));
            this.btnAyudaCerrar.Click += new EventHandler(btnAyudaCerrar_Click);
            this.btnAyudaCerrar.CausesValidation = false;

            //   ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR PRINCIPAL
            this.btnGuardar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardar"));
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);

            //   ASIGNA CONTROL Y EVENTO AL BOTON DE LIMPIAR
            this.btnLimpiarR = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesLimpiar"));
            this.btnLimpiarR.Click += new EventHandler(btnLimpiarR_Click);
            this.btnLimpiarR.CausesValidation = false;

            //   ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR Y NUEVO
            this.btnGuardarNuevo = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardarNuevo"));
            this.btnGuardarNuevo.Click += new EventHandler(btnGuardarNuevo_Click);

            //   ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR Y CERRAR
            this.btnGuardarCerrar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardarCerrar"));
            this.btnGuardarCerrar.Click += new EventHandler(btnGuardarCerrar_Click);

            //   ASIGNA CONTROL Y EVENTO AL BOTON DE CANCELAR
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

                    //CARGA FORMATO IDENTIFICACION VEHICULO
                    //DdlFormatoIdentificacionVehiculo();
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
                //LimpiarSubSeccionNotario();
                //ValidarBotonLimpiarNotario();
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


    #endregion

    #region CONTROL DE REGISTRO

    /*ASIGNA LOS VALORES DEL CONTROL DE REGISTRO A LA ENTIDAD */
    private void CrearControlRegistros(MobiliariaGarantiasRealesEntidad _entidad)
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
             MobiliariaGarantiasRealesEntidad resultado = ConsultarDetalleEntidad();

             ObtenerControlRegistros(resultado);
         }
         catch (Exception ex)
         {
             throw ex;
         }
     }

    /*OBTIENE LOS DATOS DEL CONTROL DE REGISTRO EN MODO EDICION*/
    private void ObtenerControlRegistros(MobiliariaGarantiasRealesEntidad _entidad)
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
        else 
        {
           AdministrarControlesExcepcionesDatosAdicionales(true);
           //HABILITAR CAMPOS DATOS ADICIONALES
           FormatoDatosAdicionales(this.ddlTipoBien.SelectedItem.Text);
        }
    }


    /*DESHABILITA LOS BOTONES DE GUARDADO EN EL MENU DE ACCIONES*/
    private void DeshabilitarControlesGuardar(bool deshabilitados)
    {
        ((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesGuardar(deshabilitados);
        //((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesEstilos(deshabilitados);
    }


    /*DESHABILITA EL BOTON DE BORRAR EN EL MENU DE ACCIONES*/
    private void DeshabilitarControlesBorrar(bool deshabilitados)
    {
        ((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesBorrar(deshabilitados);
        //((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesEstilos(deshabilitados);
    }

   /*ADMINISTRA LOS CONTROLES DE LA SECCION GENERALES*/
    private void AdministrarControlesExcepcionesGeneral(bool habilitado)
    {
        this.ddlClase.Enabled = habilitado;
        this.ddlTipoBien.Enabled = habilitado;
        this.txtClaseVehiculo.Enabled = habilitado;
        this.btnClaseVehiculo.Enabled = habilitado;
        this.txtDesClaseVehiculo.Enabled = habilitado;
        this.rfvDesClaseVehiculo.Enabled = habilitado;
        this.ddlFormato.Enabled = habilitado;
        this.txtNBien.Enabled = habilitado;
        this.rfvNBien.Enabled = habilitado;
        this.btnConsultar.Enabled = habilitado;
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION DETALLE RELACIÓN*/
    private void AdministrarControlesExcepcionesDetalleRelacion(bool habilitado)
    {
        //this.ddlTipoOperacion.Enabled = habilitado;
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
        this.txtConsecutivoSegII.Enabled = habilitado;
        this.txtConsecutivoSegIII.Enabled = habilitado;
        this.rfvConsecutivo.Enabled = habilitado;
        this.txtFechaPublicacion.Enabled = habilitado;
        this.calendarExtenderFechaPublicacion.Enabled = habilitado;
        this.rfvFechaPublicacion.Enabled = habilitado;
        this.imbFechaPublicacion.Enabled = habilitado;
        this.txtVIN.Enabled = habilitado;
        this.rfvVIN.Enabled = habilitado;
        this.txtMotor.Enabled = habilitado;
        this.rfvMotor.Enabled = habilitado;
        this.txtDescripcion.Enabled = habilitado;
        this.rfvDescripcion.Enabled = habilitado;
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION DATOS ADICIONALES CUANDO TIPO DE BIEN SEA 3*/
    private void AdministrarControlesExcepcionesDatosAdicionalesVehiculo(bool habilitado)
    {
        this.txtVIN.Enabled = habilitado;
        this.rfvVIN.Enabled = habilitado;
        this.txtMotor.Enabled = habilitado;
        this.rfvMotor.Enabled = habilitado;
    }


    #endregion

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

            if (pantallaIdOculto.Value.Equals("0"))
            {
                InsertarEntidadMobiliaria();
            }
            else
            {
                ModificarEntidadMobiliaria();
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
                    this.mpeBusquedaClaseVehiculo.Hide();
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

                //HABILITA CONTROLES GUARDAR BARRA SUPERIOR
                DeshabilitarControlesGuardar(false);

                //HABILITA SECCION DATOS ADICIONALES
                AdministrarControlesExcepcionesDatosAdicionales(true);

                //HABILITAR CAMPOS DATOS ADICIONALES
                FormatoDatosAdicionales(this.ddlTipoBien.SelectedItem.Text);
              
                if (!(this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -")))
                {            
                    //HABILITA CAMPOS ESPECIFICOS DE LA SECCION DATOS ADICIONALES
                    AdministrarControlesExcepcionesDatosAdicionalesVehiculo(false);
                    this.txtVIN.Text = string.Empty;
                    this.txtMotor.Text = string.Empty;
                }
            

                ////HABILITA CONTROLES CONSECUTIVO
                //ValidarConsecutivo();

                //ControlesDatosAdicionales();

                //DeEntidadAControlesDatosAdicionales(retornoDetalleGarantiaOperacionEntidad);
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
            #region SECCION GENERALES
            #region GARANTIA
            
            //LBL TIPOS DE BIENES
            controlSeleccionado = ControlesBuscar(this.lblTipoBien.ID);
            this.lblTipoBien.Text = controlSeleccionado.DesColumna;

            //LBL CLASES
            controlSeleccionado = ControlesBuscar(this.lblClase.ID);
            this.lblClase.Text = controlSeleccionado.DesColumna;

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
            #region OPERACION

            ////LBL TIPO OPERACION
            //controlSeleccionado = ControlesBuscar(this.lblTipoOperacion.ID);
            //this.lblTipoOperacion.Text = controlSeleccionado.DesColumna;

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

            #endregion
            #endregion

            #region SECCION DETALLE

            ////LBL OPERACION O CONTRATO
            //controlSeleccionado = ControlesBuscar(this.lblOperacionContrato.ID);
            //this.lblOperacionContrato.Text = controlSeleccionado.DesColumna;

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

            //LBL CONSECUTIVO
            controlSeleccionado = ControlesBuscar(this.lblConsecutivo.ID);
            this.lblConsecutivo.Text = controlSeleccionado.DesColumna;

            //LBL DIVISION CONSECUTIVO SEG I
            controlSeleccionado = ControlesBuscar(this.lblDivisionI.ID);
            this.lblDivisionI.Text = controlSeleccionado.DesColumna;

            //LBL DIVISION CONSECUTIVO SEG II
            controlSeleccionado = ControlesBuscar(this.lblDivisionII.ID);
            this.lblDivisionII.Text = controlSeleccionado.DesColumna;

            //LBL FECHA PUBLICACIÓN
            controlSeleccionado = ControlesBuscar(this.lblFechaPublicacion.ID);
            this.lblFechaPublicacion.Text = controlSeleccionado.DesColumna;

            //LBL VIN
            controlSeleccionado = ControlesBuscar(this.lblVIN.ID);
            this.lblVIN.Text = controlSeleccionado.DesColumna;

            //LBL MOTOR
            controlSeleccionado = ControlesBuscar(this.lblMotor.ID);
            this.lblMotor.Text = controlSeleccionado.DesColumna;

            //LBL TOMO
            controlSeleccionado = ControlesBuscar(this.lblDescripcion.ID);
            this.lblDescripcion.Text = controlSeleccionado.DesColumna;

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
            #region DDL TIPO BIEN
            controlSeleccionado = ControlesBuscar(this.ddlTipoBien.ID);
            this.ddlTipoBien.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoBien.DataTextField = "Texto";
            this.ddlTipoBien.DataValueField = "Valor";
            this.ddlTipoBien.DataBind();
            this.ddlTipoBien.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoBien, controlSeleccionado.ValorDefecto);

            if (ddlTipoBien.Items.Count > 0)
            {
                int cantidad = this.ddlTipoBien.Items.Count - 1;
                //for (int i = 0; i < this.ddlTipoBien.Items.Count; i++)
                for (int i = cantidad; i >= 0; i--)
                {
                    //if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("1 -") || this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("2 -") || this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("9 -")|| this.ddlTipoBien.SelectedItem.Text.Substring(0, 4).Equals("10 -"))
                    if ((this.ddlTipoBien.Items[i].Text.Substring(0, 3).Equals("1 -")) || (this.ddlTipoBien.Items[i].Text.Substring(0, 3).Equals("2 -")) || (this.ddlTipoBien.Items[i].Text.Substring(0, 3).Equals("9 -")) || (this.ddlTipoBien.Items[i].Text.Substring(0, 4).Equals("10 -")))
                    {
                        this.ddlTipoBien.Items.RemoveAt(i);
                        //i = this.ddlTipoBien.Items.Count;
                    }
                }
            }

            ////DDL CLASE
            DdlClases(this.ddlTipoBien.SelectedItem.Value);
            #endregion

            //DDL FORMATO IDENTIFICACION VEHICULO
            CargarFormatoIdentificacionVehiculo(this.ddlTipoBien.SelectedItem.Text);

            //EFECTO DE AUTOCOMPLETAR PARA EL CAMPO N BIEN 
            this.txtNBien.Attributes.Add("onblur", "AutoCompletar('" + this.txtNBien.ClientID + "','" + this.ddlTipoBien.ClientID + "','" + this.ddlFormato.ClientID + "','0')");

            #endregion

            ////EFECTO DE AUTOCOMPLETAR PARA EL CAMPO CONSECUTIVO SEG III 
            //this.txtConsecutivoSegIII.Attributes.Add("onblur", "AutoCompletar('" + this.txtConsecutivoSegIII.ClientID +"','0')");

            ControlesDatosAdicionales();

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


            //BLOQUEAR ESCRITURA EN EL CAMPO FECHA ANOTACION
            txtFechaPublicacion.Attributes.Add("readonly", "readonly");

            //CALENDARIO FECHA ULTIMA TASACION GARANTIA
            this.calendarExtenderFechaPublicacion.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();

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

        this.txtConsecutivoSegII.Text = string.Empty;
        this.txtConsecutivoSegIII.Text = string.Empty;
        this.txtFechaPublicacion.Text = string.Empty;
        this.txtVIN.Text = string.Empty;
        this.txtMotor.Text = string.Empty;
        this.txtDescripcion.Text = string.Empty;
        
        LimpiarBarraMensajeGeneral();
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

            //DESHABILITA EL CONTROL DE BORRAR
            DeshabilitarControlesBorrar(true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region MODIFICAR MOBILIARIA

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
                MobiliariaGarantiasRealesEntidad entidadConsulta = new MobiliariaGarantiasRealesEntidad();
                entidadConsulta.IdMobiliariaGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                MobiliariaGarantiasRealesEntidad entidadRetorno = wsGarantias.MobiliariaGarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

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
                MobiliariaGarantiasRealesEntidad entidadConsulta = new MobiliariaGarantiasRealesEntidad();
                entidadConsulta.IdMobiliariaGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                MobiliariaGarantiasRealesEntidad entidadRetorno = wsGarantias.MobiliariaGarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

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
                MobiliariaGarantiasRealesEntidad entidadConsulta = new MobiliariaGarantiasRealesEntidad();
                entidadConsulta.IdMobiliariaGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                MobiliariaGarantiasRealesEntidad entidadRetorno = wsGarantias.MobiliariaGarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                if (entidadRetorno != null)
                {

                    //Requerimiento Bloque 7 1-24381561 
                    ObtenerControlRegistros(entidadRetorno);

                    ControlesDatosAdicionales();

                    this.hdnIdClaseOperacion.Value = entidadRetorno.IdGarantiaOperacion.ToString();

                    if (entidadRetorno.FechaPublicacion.ToString().Length > 0)
                        txtFechaPublicacion.Text = string.Format("{0:d}", entidadRetorno.FechaPublicacion);

                    //generadorControles.SeleccionarOpcionDropDownList(this.ddlPartido, entidadRetorno.Partido.ToString());

                    //this.txtConsecutivoSegI.Text = entidadRetorno.Consecutivo;
                    //CARGAR EL VALOR CONSECUTIVO DESDE LA BD EN SECCIONES DIFERENTES
                    string[] valorConsecutivo = entidadRetorno.Consecutivo.Split('-');
                    this.txtConsecutivoSegI.Text = valorConsecutivo[0];
                    this.txtConsecutivoSegII.Text = valorConsecutivo[1];
                    this.txtConsecutivoSegIII.Text = valorConsecutivo[2];
                    this.txtVIN.Text = entidadRetorno.Vin;
                    this.txtMotor.Text = entidadRetorno.Motor;
                    this.txtDescripcion.Text = entidadRetorno.Descripcion;

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

    /*CARGA LOS VALORES DESDE LOS CONTROLES HACIA LA ENTIDAD PARA REALIZAR ACCIONES*/
    private MobiliariaGarantiasRealesEntidad DeControlesAEntidad()
    {
        try
        {
            MobiliariaGarantiasRealesEntidad entidad = null;

            if (pantallaModuloOculto.Value.Length > 0)
            {
                entidad = new MobiliariaGarantiasRealesEntidad();

                #region SECCION INSCRIPCION GARANTIA REAL

                if (this.hdnIdGeneral.Value.Length < 1)
                    entidad.IdMobiliariaGarantiaReal = 0;
                else
                    entidad.IdMobiliariaGarantiaReal = int.Parse(this.hdnIdGeneral.Value);

                if (this.hdnIdClaseOperacion.Value.Length < 1)
                    entidad.IdGarantiaOperacion = 0;
                else
                    entidad.IdGarantiaOperacion = int.Parse(this.hdnIdClaseOperacion.Value);

                // entidad.IndInscripcion = int.Parse(this.ddlIndInscripcion.SelectedItem.Value);
                if (this.txtConsecutivoSegII.Text.Length < 1 || this.txtConsecutivoSegIII.Text.Length < 1)
                    entidad.Consecutivo = null;
                else
                    entidad.Consecutivo = this.txtConsecutivoSegI.Text.Trim() + "-" + this.txtConsecutivoSegII.Text.Trim() + "-" + this.txtConsecutivoSegIII.Text.Trim();

                if (this.txtFechaPublicacion.Text.Length < 1)
                    entidad.FechaPublicacion = null;
                else
                    entidad.FechaPublicacion = DateTime.Parse(this.txtFechaPublicacion.Text);

                if (this.txtVIN.Text.Length < 1)
                    entidad.Vin = null;
                else
                    entidad.Vin = this.txtVIN.Text;

                if (this.txtMotor.Text.Length < 1)
                    entidad.Motor = null;
                else
                    entidad.Motor = this.txtMotor.Text;

                if (this.txtDescripcion.Text.Length < 1)
                    entidad.Descripcion = null;
                else
                    entidad.Descripcion = this.txtDescripcion.Text;
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

    /*VALIDACION DEL FORMATO DEL CONSECUTIVO */
    private bool ValidarConsecutivo(string texto)
    {
        var regex4Numerico = new Regex(@"^\d{4}$");

        bool existeError = false; // FALSE - NO | TRUE - SI

        //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES
        if (!regex4Numerico.IsMatch(texto))
        {
            existeError = true;
        }

        return existeError;
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

        var regexLetras = new Regex("^[a-zA-Z]*$");

        bool existeError = false; // FALSE - NO | TRUE - SI
        bool existeErrorSoloLetras = false; // FALSE - NO | TRUE - SI

        //VALOR SELECCIONADO EN EL TIPO BIEN (X -)
        string valorTipoBien = this.ddlTipoBien.SelectedItem.Text.Substring(0, 3);
        //VALOR SELECCIONADO EN EL TIPO BIEN (XX -)
        string valorTipoBien2 = this.ddlTipoBien.SelectedItem.Text.Substring(0, 4);

        //VALOR SELECCIONADO EN EL FORMATO DE IDENTIFICACION VEHICULO
        string valorFormatoIdentificacion = this.ddlFormato.SelectedItem.Text;

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

        retorno.Add(new KeyValuePair<string, bool>("errorFormato", existeError));
        retorno.Add(new KeyValuePair<string, bool>("errorLetras", existeErrorSoloLetras));

        return retorno;
    }



    /*EFECTO VALIDAR CARACTERES ESPECIALES DATOS ADICIONALES*/
    private bool ValidarGuardarExcepciones()
    {
        bool retorno = false;

        if (ValidarCaracterEspecial(this.txtVIN.Text) || ValidarCaracterEspecial(this.txtMotor.Text) || ValidarCaracterEspecial(this.txtDescripcion.Text))
        {
            //MENSAJE DE ERROR POR CARACTER ESPECIAL
            BarraMensaje(null, "");
            retorno = true;
        }

        if (!retorno)
        {
            retorno = ValidacionDatosAdicionales(null, null);
        }
        return retorno;
    }

    #endregion

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

            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #region SECCION GENERALES

    private void DdlTiposBienes()
    {
        try
        {
            //REALIZA LA CARGA DE LA CLASE
            DdlClases(this.ddlTipoBien.SelectedItem.Value);

            //REALIZA LA CARGA DEL FORMATO IDENTIFICACION VEHICULO
            CargarFormatoIdentificacionVehiculo(this.ddlTipoBien.SelectedItem.Text);

            //DESHABILITA CAJA TEXTO CLASE VEHICULO
            if (!ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
            {
                this.txtClaseVehiculo.Enabled = false;
                this.btnClaseVehiculo.Enabled = false;
                this.txtClaseVehiculo.Text = string.Empty;
                this.txtDesClaseVehiculo.Text = string.Empty;
                this.rfvDesClaseVehiculo.Enabled = false;
                this.hdnIdClaseVehiculo.Value = string.Empty;

                //EFECTO DE NUMERO DE BIEN [CONSTANTES]
                this.txtNBien.Text = string.Empty;
                this.txtNBien.MaxLength = 17;
                this.txtNBien.ToolTip = "Alfanumérico de 17 caracteres";
            }
            else
            {
                //HABILITA CAJA TEXTO CLASE VEHICULO        
                this.txtClaseVehiculo.Enabled = true;
                this.btnClaseVehiculo.Enabled = true;
                this.rfvDesClaseVehiculo.Enabled = true;
                //CARGA FORMATO IDENTIFICACION VEHICULO
                DdlFormatoIdentificacionVehiculo();
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
                    if ((this.ddlClase.Items[i].Text.Equals("Bono de Prenda")))
                    {
                        this.ddlClase.Items.RemoveAt(i);
                        i = this.ddlClase.Items.Count;
                    }
                }
            }

            this.ddlTipoBien.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlClase, controlSeleccionado.ValorDefecto);

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

                if (this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
                {
                    this.ddlClase.Enabled = false;
                    // this.ddlClase.Attributes.Add("readonly", "readonly");
                    generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlClase, valorDefecto[1]);
                    //BLOQUEAR ESCRITURA EN EL CAMPO FECHA ANOTACION
                }
                else
                {
                    this.ddlClase.Text = string.Empty;
                    this.ddlClase.Enabled = false;
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlClasesEfectos()
    {
        try
        {
            //SI EL TIPO DE BIEN ES IGUAL A 3 
            if (!this.ddlTipoBien.SelectedItem.Text.Substring(0, 3).Equals("3 -"))
            {
                this.ddlClase.Text = string.Empty;
                this.ddlClase.Enabled = false;
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

    private void FormatoDatosAdicionales(string valorFiltro)
    {
        try
        {
            if (valorFiltro.Substring(0, 3).Equals("3 -"))
            {
                this.txtVIN.Enabled = true;
                this.rfvVIN.Enabled = true;
                this.txtMotor.Enabled = true;
                this.rfvMotor.Enabled = true;
            }
            else
            {
                this.txtVIN.Enabled = false;
                this.rfvVIN.Enabled = false;
                this.txtMotor.Enabled = false;
                this.rfvMotor.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region SECCION DATOS ADICIONALES
    //private void CargarFormatoConsecutivo(string valorFiltro)
    //{
    //    try
    //    {
    //        if (valorFiltro.Substring(0, 3).Equals("3 -"))
    //        {

    //            this.ddlFormato.Items.Clear();
    //            this.ddlFormato.SelectedValue = null;
    //            this.ddlFormato.Items.Add(new ListItem("Numérico 6 enteros", "1"));
    //            this.ddlFormato.Items.Add(new ListItem("Alfanumérico 3 letras y 3 enteros", "2"));
    //            this.ddlFormato.Items.Add(new ListItem("Alfanumérico 17 caracteres", "3"));
    //            this.ddlFormato.SelectedIndex = 0;
    //            this.ddlFormato.Enabled = true;
    //        }
    //        else
    //        {
    //            this.ddlFormato.Items.Clear();
    //            this.ddlFormato.SelectedValue = null;
    //            AdministrarBlanco("ddlFormato", true);
    //            this.ddlFormato.Enabled = false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

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

    #endregion

    #region METODOS PARA TEXT BOX

    protected void TextBox_TextChanged(object sender, EventArgs e)
    {
        try
        {

            TextBox txt = ((TextBox)(sender));

            switch (txt.ID.ToString().ToUpper())
            {
                #region TXT CONSECUTIVO SEG II
                case "TXTCONSECUTIVOSEGII":
                    if (txt.Text.Replace("_","").Length > 0)
                    {
                     rfvConsecutivo.ControlToValidate = txtConsecutivoSegIII.ID;
                    }
                    //CompletarCerosIzquierda(txtConsecutivoSegII, mskConsecutivoSegII);
                    break;
                #endregion

                //#region TXT CONSECUTIVO SEG III
                //case "TXTCONSECUTIVOSEGIII":
                //    if (txt.Text.Length > 0)
                //    {
                //        ValidacionDatosAdicionales(sender, e);
                //        rfvConsecutivo.ControlToValidate = txtConsecutivoSegII.ID;
                //    }
                //    //CompletarCerosIzquierda(txtConsecutivoSegII, mskConsecutivoSegII);
                //    break;
                //#endregion
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void TextBox_TextChangedSegIII(object sender, EventArgs e)
    {
        try
        {

            TextBox txt = ((TextBox)(sender));

            switch (txt.ID.ToString().ToUpper())
            {
                //#region TXT CONSECUTIVO SEG II
                //case "TXTCONSECUTIVOSEGII":
                //    if (txt.Text.Length > 0)
                //    {
                //        rfvConsecutivo.ControlToValidate = txtConsecutivoSegIII.ID;
                //    }
                //    //CompletarCerosIzquierda(txtConsecutivoSegII, mskConsecutivoSegII);
                //    break;
                //#endregion

                #region TXT CONSECUTIVO SEG III
                case "TXTCONSECUTIVOSEGIII":
                    if (txt.Text.Replace("_","").Length > 0)
                    {
                        ValidacionDatosAdicionales(sender, e);
                      //  rfvConsecutivo.ControlToValidate = txtConsecutivoSegII.ID;
                    }
                    //CompletarCerosIzquierda(txtConsecutivoSegII, mskConsecutivoSegII);
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

    //protected void Comentario_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        this.txtComentario.MaxLength = 45;


    //        if (ValidarCaracterEspecial(this.txtComentario.Text))
    //        {
    //            //MENSAJE DE ERROR POR CARACTER ESPECIAL
    //            BarraMensaje(null, "");
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

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
                        List<GarantiasOperacionesEntidad> retornoOperacion = wsGarantias.MobiliariaGarantiasRealesOperacionesConsultar(validacionEntidad).ToList();

                        // VALIDACION SI EXISTEN OPERACIONES ASOCIADAS
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
                                LimpiarBarraMensaje();
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


    /*VALIDAR SECCION DATOS ADICIONALES*/
    protected bool ValidacionDatosAdicionales(object sender, EventArgs e)
    {
            bool existeError = false;

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (ValidarConsecutivo(this.txtConsecutivoSegIII.Text))
                {
                    existeError = true;
                    
                    string valorSegmento = string.Empty;
                    valorSegmento = "Consecutivo Seg III";
                    //MENSAJE DE ERROR DE FORMATO
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_6", valorSegmento, this.txtConsecutivoSegIII.ToolTip);
                    this.txtConsecutivoSegIII.Text = string.Empty;
                    this.mpeInformarBox.Show();
                    rfvConsecutivo.ControlToValidate = txtConsecutivoSegIII.ID;
                }
                else
                {
                    rfvConsecutivo.ControlToValidate = txtConsecutivoSegII.ID;
                }
            }

            return existeError;
       
    }

    #region ENTIDADES

    /*INSERTA EL REGISTRO*/
    private void InsertarEntidadMobiliaria()
    {
        try
        {
            MobiliariaGarantiasRealesEntidad entidad = new MobiliariaGarantiasRealesEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            //ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidad();

            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                //INSERCION DE LA SECCION ENCABEZADO
                respuesta = wsGarantias.MobiliariaGarantiasRealesInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

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
    private void ModificarEntidadMobiliaria()
    {
        try
        {
            MobiliariaGarantiasRealesEntidad entidad = new MobiliariaGarantiasRealesEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            //ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidad();

            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                //INSERCION DE LA SECCION ENCABEZADO
                respuesta = wsGarantias.MobiliariaGarantiasRealesModificar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));

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
    private MobiliariaGarantiasRealesEntidad ConsultarDetalleEntidad()
    {
        try
        {
            MobiliariaGarantiasRealesEntidad entidadRetorno = new MobiliariaGarantiasRealesEntidad();
            MobiliariaGarantiasRealesEntidad entidadConsulta = new MobiliariaGarantiasRealesEntidad();

            if (pantallaModuloOculto.Value != null && hdnIdGeneral.Value.Length > 0)//VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            {
                entidadConsulta.IdMobiliariaGarantiaReal = int.Parse(hdnIdGeneral.Value);

                entidadRetorno = wsGarantias.MobiliariaGarantiasRealesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
            }

            return entidadRetorno;
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
        //AdministrarControlesExcepcionesGeneral(false);
        //DeshabilitarControlesGuardar(true);
    }

    /*BLOQUEA LOS CONTROLES AL GUARDAR UN REGISTRO NUEVO*/
    private void BloquearControlesGuardar()
    {
        try
        {
            //AdministrarControlesExcepcionesGeneral(false);
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