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
using ConfiguracionWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class AvalesNew : System.Web.UI.Page
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

    #endregion

    #region REFERENCIAS

    private BitacoraFlags bitacoraBanderas = new BitacoraFlags();
    private GeneradorControles generadorControles = new GeneradorControles();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private GarantiasWS.BitacorasEntidad bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
    private ConsultasWS.BitacorasEntidad bitacorasConsultasWSEntidad = new ConsultasWS.BitacorasEntidad();
    private ConfiguracionWS.BitacorasEntidad bitacorasConfiguracionWSEntidad = new ConfiguracionWS.BitacorasEntidad();

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();
    private SiganemGarantiasWS wsGarantias = new SiganemGarantiasWS();
    private SiganemConsultasWS wsConsultas = new SiganemConsultasWS();
    private SiganemConfiguracionWS wsConfiguracion = new SiganemConfiguracionWS();

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
                LimpiarBarraMensaje();
                Tabs();
                if (!IsPostBack)
                {
                    ControlesNombre();
                    Controles();
                    
                    CargarEfectosDetalleGarantiasAvales();
                              
                    //CARGA LOS VALORES PARA LOS TITULOS
                    Etiquetas();
                   //Efectos();

                    //CARGA LA MASCARA PARA EL CAMPO TIPO PERSONA DEUDOR
                    DdlTipoPersonaDeudor(sender);

                    //CARGA LOS VALORES DESDE BD PARA EL CASO DE LAS MODIFICACIONES
                    DeEntidadAControles();

                    ////BLOQUEA LOS CONTROLES NO UTILIZADOS
                    //DeshabilitarControlesExcepciones();

                    //DESHABILITA BOTON LIMPIAR DEUDOR
                    HabilitaBotonLimpiarDeudor(false);
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
                LimpiarR();
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
                Limpiar();
                HabilitaBotonesBusquedaDeudor(true);
                HabilitaBotonLimpiarDeudor(false);
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

    #endregion

    #endregion

    #region CONTROL DE REGISTRO

    /*ASIGNA LOS VALORES DEL CONTROL DE REGISTRO A LA ENTIDAD */
    private void CrearControlRegistros(GarantiasAvalesEntidad _entidad)
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
            GarantiasAvalesEntidad resultado = ConsultarDetalleEntidad();

            ObtenerControlRegistros(resultado);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*OBTIENE LOS DATOS DEL CONTROL DE REGISTRO EN MODO EDICION*/
    private void ObtenerControlRegistros(GarantiasAvalesEntidad _entidad)
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
            //AdministrarControlesExcepcionesDetalleRelacion(false);
            //AdministrarControlesExcepcionesDatosAdicionales(false);

            //if (this.ddlTipoBien.Enabled)
            //    DeshabilitarControlesGuardar(true);
            //else
            //    DeshabilitarControlesGuardar(false);
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

    /*DESHABILITA BOTON LIMPIAR DEUDOR*/
    private void HabilitaBotonLimpiarDeudor(bool habilitado)
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

    /*DESHABILITA BOTONES BUSQUEDA DEUDOR*/
    private void HabilitaBotonesBusquedaDeudor(bool habilitado)
    {
        try
        {
            this.ddlTipoPersonaDeudor.Enabled = habilitado;
            this.txtIdDeudor.Enabled = habilitado;
            this.btnConsultar.Enabled = habilitado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    /*ADMINISTRA LOS CONTROLES DE LA SECCION GENERAL*/
    private void AdministrarControlesExcepcionesGeneral(bool habilitado)
    {
        this.ddlTipoAval.Enabled = habilitado;

        this.txtNumeroAval.Enabled = habilitado;
        this.rfvNumeroAval.Enabled = habilitado;
        this.txtIdGarantiaBCR.Enabled = habilitado;
        this.txtFechaEmision.Attributes.Add("readonly", "readonly");
        this.txtFechaVencimiento.Attributes.Add("readonly", "readonly");
        this.ddlTipoPersonaDeudor.Enabled = habilitado;
        this.txtIdDeudor.Enabled = habilitado;       
        this.btnConsultar.Enabled = habilitado;
        this.btnLimpiar.Enabled = habilitado;
        this.txtNombreDeudor.Enabled = habilitado;

    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION GENERAL*/
    private void AdministrarControlesExcepcionesTotal(bool habilitado)
    {
        this.ddlTipoAval.Enabled = habilitado;
        this.txtTipoPersonaAvalista.Enabled = habilitado;
        this.txtIdAvalista.Enabled = habilitado;
        this.txtNumeroAval.Enabled = habilitado;
        this.rfvNumeroAval.Enabled = habilitado;
        this.txtMontoAvalado.Enabled = habilitado;
        this.rfvMontoAvalado.Enabled = habilitado;
        this.txtIdGarantiaBCR.Enabled = habilitado;
        this.txtFechaEmision.Enabled = habilitado;
        this.txtFechaEmision.Attributes.Add("readonly", "readonly");
        this.rfvFechaEmision.Enabled = habilitado;
        this.imbFechaEmision.Enabled = habilitado;
        this.imbFechaVencimiento.Enabled = habilitado;
        this.txtFechaVencimiento.Enabled = habilitado;
        this.txtFechaVencimiento.Attributes.Add("readonly", "readonly");
        this.rfvFechaVencimiento.Enabled = habilitado;
        this.ddlTipoPersonaDeudor.Enabled = habilitado;
        this.txtIdDeudor.Enabled = habilitado;
        this.btnConsultar.Enabled = habilitado;
        this.btnLimpiar.Enabled = habilitado;
        this.txtNombreDeudor.Enabled = habilitado;
        this.rfvNombreDeudor.Enabled = habilitado;
        this.ddlTipoAsignacionCalificacion.Enabled = habilitado;
        this.ddlPlazoCalificacion.Enabled = habilitado;
        this.ddlCodigoEmpresaCalificadora.Enabled = habilitado;
        this.ddlCategoriaCalificacion.Enabled = habilitado;
        this.ddlCalificacionRiesgo.Enabled = habilitado;
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

            //if (!ValidarRangoFechaMayor())
            //{
                if (pantallaIdOculto.Value.Equals("0"))
                {
                    InsertarEntidadGarantiaAval();
                }
                else
                {
                    ModificarEntidadGarantiaAval();
                }
            //}
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

    #region DETALLE RELACION

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
        //DdlTiposBienes();
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

            //LBL TIPOS DE AVALES
            controlSeleccionado = ControlesBuscar(this.lblTipoAval.ID);
            this.lblTipoAval.Text = controlSeleccionado.DesColumna;

            //LBL TIPO PERSONA AVALISTA
            controlSeleccionado = ControlesBuscar(this.lblTipoPersonaAvalista.ID);
            this.lblTipoPersonaAvalista.Text = controlSeleccionado.DesColumna;

            //LBL ID AVALISTA
            controlSeleccionado = ControlesBuscar(this.lblIdAvalista.ID);
            this.lblIdAvalista.Text = controlSeleccionado.DesColumna;

            #endregion

            #region SECCION DETALLE GARANTÍAS AVALES

            //LBL NUMERO AVAL
            controlSeleccionado = ControlesBuscar(this.lblNumeroAval.ID);
            this.lblNumeroAval.Text = controlSeleccionado.DesColumna;

            //LBL MONTO AVALADO
            controlSeleccionado = ControlesBuscar(this.lblMontoAvalado.ID);
            this.lblMontoAvalado.Text = controlSeleccionado.DesColumna;

            //LBL ID GARANTÍA BCR
            controlSeleccionado = ControlesBuscar(this.lblIdGarantiaBCR.ID);
            this.lblIdGarantiaBCR.Text = controlSeleccionado.DesColumna;

            //LBL FECHA EMISION
            controlSeleccionado = ControlesBuscar(this.lblFechaEmision.ID);
            this.lblFechaEmision.Text = controlSeleccionado.DesColumna;

            //LBL FECHA VENCIMIENTO
            controlSeleccionado = ControlesBuscar(this.lblFechaVencimiento.ID);
            this.lblFechaVencimiento.Text = controlSeleccionado.DesColumna;

            //LBL TIPO PERSONA DEUDOR
            controlSeleccionado = ControlesBuscar(this.lblTipoPersonaDeudor.ID);
            this.lblTipoPersonaDeudor.Text = controlSeleccionado.DesColumna;

            //LBL ID DEUDOR
            controlSeleccionado = ControlesBuscar(this.lblIdDeudor.ID);
            this.lblIdDeudor.Text = controlSeleccionado.DesColumna;

            //BTN LIMPIAR
            controlSeleccionado = ControlesBuscar(this.btnLimpiar.ID);
            this.btnLimpiar.Text = controlSeleccionado.DesColumna;

            //LBL NOMBRE DEUDOR
            controlSeleccionado = ControlesBuscar(this.lblNombreDeudor.ID);
            this.lblNombreDeudor.Text = controlSeleccionado.DesColumna;

            //LBL TIPO ASIGNACIÓN CALIFICACIÓN
            controlSeleccionado = ControlesBuscar(this.lblTipoAsignacionCalificacion.ID);
            this.lblTipoAsignacionCalificacion.Text = controlSeleccionado.DesColumna;

            //LBL PLAZO CALIDICACIÓN
            controlSeleccionado = ControlesBuscar(this.lblPlazoCalificacion.ID);
            this.lblPlazoCalificacion.Text = controlSeleccionado.DesColumna;

            //LBL CÓDIGO EMPRESA CALIFICADORA
            controlSeleccionado = ControlesBuscar(this.lblCodigoEmpresaCalificadora.ID);
            this.lblCodigoEmpresaCalificadora.Text = controlSeleccionado.DesColumna;

            //LBL CATEGORÍA CALIFICACIÓN
            controlSeleccionado = ControlesBuscar(this.lblCategoriaCalificacion.ID);
            this.lblCategoriaCalificacion.Text = controlSeleccionado.DesColumna;

            //LBL CALIFICACIÓN RIESGO
            controlSeleccionado = ControlesBuscar(this.lblCalificacionRiesgo.ID);
            this.lblCalificacionRiesgo.Text = controlSeleccionado.DesColumna;

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

            //DDL TIPOS DE AVALES
            controlSeleccionado = ControlesBuscar(this.ddlTipoAval.ID);
            this.ddlTipoAval.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoAval.DataTextField = "Texto";
            this.ddlTipoAval.DataValueField = "Valor";
            this.ddlTipoAval.DataBind();
            this.ddlTipoAval.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoAval, controlSeleccionado.ValorDefecto);

            ConsultasWS.TiposAvalesEntidad entidadConsulta = new ConsultasWS.TiposAvalesEntidad();
            this.txtTipoPersonaAvalista.Text = entidadConsulta.DesTipoPersona;
            ////EFECTO DE AUTOCOMPLETAR PARA EL CAMPO N BIEN 
            ////this.txtNBien.Attributes.Add("onblur", "AutoCompletar('ctl00_ContentPlaceHolder1_txtNBien','ctl00_ContentPlaceHolder1_ddlTipoBien','ctl00_ContentPlaceHolder1_ddlFormato','0')");
            //this.txtNBien.Attributes.Add("onblur", "AutoCompletar('" + this.txtNBien.ClientID + "','" + this.ddlTipoBien.ClientID + "','" + this.ddlFormato.ClientID + "','0')");
            CargarDatosTipoAval();

            #endregion

            #region DETALLE GARANTÍAS AVALES

            //DDL TIPOS DE IDENTIFICACION RUC
            controlSeleccionado = ControlesBuscar(this.ddlTipoPersonaDeudor.ID);
            this.ddlTipoPersonaDeudor.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoPersonaDeudor.DataTextField = "Texto";
            this.ddlTipoPersonaDeudor.DataValueField = "Valor";
            this.ddlTipoPersonaDeudor.DataBind();
            this.ddlTipoPersonaDeudor.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoPersonaDeudor, controlSeleccionado.ValorDefecto);


            //DDL TIPOS DE ASIGNACION CALIFICACION
            controlSeleccionado = ControlesBuscar(this.ddlTipoAsignacionCalificacion.ID);
            this.ddlTipoAsignacionCalificacion.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoAsignacionCalificacion.DataTextField = "Texto";
            this.ddlTipoAsignacionCalificacion.DataValueField = "Valor";
            this.ddlTipoAsignacionCalificacion.DataBind();
            this.ddlTipoAsignacionCalificacion.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoAsignacionCalificacion, controlSeleccionado.ValorDefecto);


            /**************/
            //DDL PLAZO CALIFICACIÓN 
            controlSeleccionado = ControlesBuscar(this.ddlPlazoCalificacion.ID);
            this.ddlPlazoCalificacion.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlPlazoCalificacion.DataTextField = "Texto";
            this.ddlPlazoCalificacion.DataValueField = "Valor";
            this.ddlPlazoCalificacion.DataBind();
            this.ddlPlazoCalificacion.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlPlazoCalificacion, controlSeleccionado.ValorDefecto);
            
            //DDL CÓDIGO EMPRESA CALIFICADORA 
            string ddlFiltro = this.ddlPlazoCalificacion.SelectedValue.ToString();
            controlSeleccionado = ControlesBuscar(this.ddlCodigoEmpresaCalificadora.ID);
            this.ddlCodigoEmpresaCalificadora.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, ddlFiltro);
            this.ddlCodigoEmpresaCalificadora.DataTextField = "Texto";
            this.ddlCodigoEmpresaCalificadora.DataValueField = "Valor";
            this.ddlCodigoEmpresaCalificadora.DataBind();
            this.ddlCodigoEmpresaCalificadora.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlCodigoEmpresaCalificadora, controlSeleccionado.ValorDefecto);

            //DDL CATEGORIA CALIFICADORA
            string ddlFiltro2 = this.ddlCodigoEmpresaCalificadora.SelectedValue.ToString();
            controlSeleccionado = ControlesBuscar(this.ddlCategoriaCalificacion.ID);
            this.ddlCategoriaCalificacion.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, ddlFiltro2);
            this.ddlCategoriaCalificacion.DataTextField = "Texto";
            this.ddlCategoriaCalificacion.DataValueField = "Valor";
            this.ddlCategoriaCalificacion.DataBind();
            this.ddlCategoriaCalificacion.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlCategoriaCalificacion, controlSeleccionado.ValorDefecto);

            //DDL CATEGORIA RIESGO CALIFICADORA 
            string ddlFiltro3 = this.ddlCategoriaCalificacion.SelectedValue.ToString();
            controlSeleccionado = ControlesBuscar(this.ddlCalificacionRiesgo.ID);
            this.ddlCalificacionRiesgo.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, ddlFiltro3);
            this.ddlCalificacionRiesgo.DataTextField = "Texto";
            this.ddlCalificacionRiesgo.DataValueField = "Valor";
            this.ddlCalificacionRiesgo.DataBind();
            this.ddlCalificacionRiesgo.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlCalificacionRiesgo, controlSeleccionado.ValorDefecto);

            //CALENDARIO FECHA ULTIMA TASACION GARANTIA
            this.calendarExtenderFechaEmision.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();

            //CALENDARIO FECHA ULTIMO SEGUIMIENTO GARANTIA
            this.calendarExtenderFechaVencimiento.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();

            #endregion

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA ITEMS EN BLANCO PARA LA SECCION DETALLLE GARANTÍAS AVALES*/
    private void ControlesDatosDetalleGarantiasAvales()
    {
        try
        {
            #region DATOS DETALLLE GARANTÍAS AVALES

            if (this.ddlTipoAsignacionCalificacion.SelectedItem.Text.Substring(0, 3).Equals("0 -"))
            {
                AdministrarBlanco(this.ddlPlazoCalificacion.ID, true);
                this.ddlPlazoCalificacion.Enabled = false;

                AdministrarBlanco(this.ddlCodigoEmpresaCalificadora.ID, true);
                this.ddlCodigoEmpresaCalificadora.Enabled = false;

                AdministrarBlanco(this.ddlCategoriaCalificacion.ID, true);
                this.ddlCategoriaCalificacion.Enabled = false;

                AdministrarBlanco(this.ddlCalificacionRiesgo.ID, true);
                this.ddlCalificacionRiesgo.Enabled = false;
            }
            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*LIMPIA LOS CONTROLES TIPO TEXTBOX*/
    private void LimpiarR()
    {
        if (this.txtNumeroAval.Enabled)
        {
            this.txtNumeroAval.Text = string.Empty;
            this.txtMontoAvalado.Text = string.Empty;
            this.txtIdGarantiaBCR.Text = string.Empty;
            this.txtFechaEmision.Text = string.Empty;
            this.txtFechaVencimiento.Text = string.Empty;
            this.txtIdDeudor.Text = string.Empty;
            this.txtNombreDeudor.Text = string.Empty;
            this.txtIdDeudor.Enabled = true;
            this.btnConsultar.Enabled = true;
            this.btnLimpiar.Enabled = false;         
        }
        this.txtMontoAvalado.Text = string.Empty;
        this.txtFechaEmision.Text = string.Empty;
        this.txtFechaVencimiento.Text = string.Empty;
        //this.txtNBien.Text = string.Empty;     
         
        LimpiarBarraMensaje();
    }

    /*LIMPIA LOS CONTROLES TIPO TEXTBOX*/
    private void Limpiar()
    {
        this.txtIdDeudor.Text = string.Empty;
        this.txtNombreDeudor.Text = string.Empty;

        LimpiarBarraMensaje();
    }

    private void CargarControlesSinError()
    {
        try
        {
            //DESHABILITA LA SECCION GENERAL
            AdministrarControlesExcepcionesTotal(true);

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

    /*CARGA LOS VALORES DE TIPO AVAL SELECCIONADO */
    private void CargarDatosTipoAval()
    {
        if (ddlTipoAval.Items.Count > 0)
        {
            ConfiguracionWS.TiposAvalesEntidad entidadConsulta = new ConfiguracionWS.TiposAvalesEntidad();
            entidadConsulta.IdTipoAval = int.Parse(this.ddlTipoAval.SelectedItem.Value);
            ConfiguracionWS.TiposAvalesEntidad entidadRetorno = wsConfiguracion.TipoAvalConsultarDetalle(entidadConsulta, AsignarValoresBitacoraConfiguracionWS(EnumTipoBitacora.CONSULTAR));

            ConfiguracionWS.TiposPersonasEntidad entidadConsultaPersona = new ConfiguracionWS.TiposPersonasEntidad();
            entidadConsultaPersona.IdTipoPersona = entidadRetorno.IdTipoPersona;
            ConfiguracionWS.TiposPersonasEntidad entidadRetornoPersona = wsConfiguracion.TiposPersonasConsultarDetalle(entidadConsultaPersona, AsignarValoresBitacoraConfiguracionWS(EnumTipoBitacora.CONSULTAR));

            this.txtTipoPersonaAvalista.Text = entidadRetorno.IdTipoPersona.ToString() + " - " + entidadRetornoPersona.DesTipoPersona.ToString();
            this.txtIdAvalista.Text = entidadRetorno.IdAvalista;
        }
    }

    private void CargarEfectosDetalleGarantiasAvales()
    {
        //EFECTO DE NUMERO DE AVAL
        this.txtNumeroAval.MaxLength = 30;
        this.txtNumeroAval.ToolTip = "Alfanumérico de 30 caracteres";

        //BLOQUEAR ESCRITURA CAMPOS FECHAS
        this.txtFechaEmision.Attributes.Add("readonly", "readonly");
        this.txtFechaVencimiento.Attributes.Add("readonly", "readonly");

        //CARGA ITEMS EN BLANCO PARA LA SECCION DETALLLE GARANTÍAS AVALES*/
        ControlesDatosDetalleGarantiasAvales(); 
    }

    private void CargarIdGarantiaBCR(object sender, EventArgs e)
    {
        try
        {
            //TEXTBOX ID GARANTIAS AVALES
            this.txtIdGarantiaBCR.Text = this.txtNumeroAval.Text;
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
                ControlesDatosDetalleGarantiasAvales();
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
                GarantiasAvalesEntidad entidadConsulta = new GarantiasAvalesEntidad();
                entidadConsulta.IdGarantiaAval = int.Parse(this.hdnIdGeneral.Value);

                GarantiasAvalesEntidad entidadRetorno = wsGarantias.GarantiasAvalesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                if (entidadRetorno != null)
                {
                    //Requerimiento Bloque 7 1-24381561 
                    ObtenerControlRegistros(entidadRetorno);

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlTipoAval, entidadRetorno.IdTipoAval.ToString());
                    CargarDatosTipoAval();
                    //DdlTiposBienes();
                    this.txtNumeroAval.Text = entidadRetorno.NumeroAval;
                    this.txtMontoAvalado.Text = entidadRetorno.MontoAvalado.ToString();
                    this.txtIdGarantiaBCR.Text = entidadRetorno.CodGarantiaBCR;

                    if (entidadRetorno.FechaEmision.ToString().Length > 0)
                        txtFechaEmision.Text = string.Format("{0:d}", entidadRetorno.FechaEmision);

                    if (entidadRetorno.FechaVencimiento.ToString().Length > 0)
                        txtFechaVencimiento.Text = string.Format("{0:d}", entidadRetorno.FechaVencimiento);

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlTipoPersonaDeudor, entidadRetorno.IdTipoPersonaDeudor.ToString());

                    this.txtIdDeudor.Text = entidadRetorno.IdDeudor;

                    ObtenerDatosCliente();

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlTipoAsignacionCalificacion, entidadRetorno.IdTipoAsignacionCalificacion.ToString());

                    DdlTipoAsignacionCalificacion(null);

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlPlazoCalificacion, entidadRetorno.IdPlazoCalificacion.ToString());

                    DdlPlazoCalificacion(null);

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlCodigoEmpresaCalificadora, entidadRetorno.IdEmpresaCalificadora.ToString());

                    DdlCodigoEmpresaCalificadora(null);

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlCategoriaCalificacion, entidadRetorno.IdCategoriaRiesgoEmpresaCalificadora.ToString());

                    DdlCategoriaCalificacion(null);

                    generadorControles.SeleccionarOpcionDropDownList(this.ddlCalificacionRiesgo, entidadRetorno.IdCalificacionEmpresaCalificadora.ToString());
                 
                    this.hdnIdGeneral.Value = entidadRetorno.IdGarantiaAval.ToString();                  
                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region INSERTAR GARANTÍAS AVALES 
    /*CARGA LOS VALORES DESDE LOS CONTROLES DE LA SECCION GENERAL, HACIA LA ENTIDAD PARA REALIZAR ACCIONES*/
    private GarantiasAvalesEntidad DeControlesAEntidad()
    {
        try
        {
            GarantiasAvalesEntidad entidad = null;

            if (pantallaModuloOculto.Value.Length > 0)
            {
                entidad = new GarantiasAvalesEntidad();

                #region SECCION GENERAL

                entidad.IdTipoAval = int.Parse(this.ddlTipoAval.SelectedItem.Value);
               
                if (this.hdnIdGeneral.Value.Length < 1)
                    entidad.IdGarantiaAval = 0;
                else
                    entidad.IdGarantiaAval = int.Parse(this.hdnIdGeneral.Value);

                if (this.txtNumeroAval.Text.Length < 1)
                    entidad.NumeroAval = string.Empty;
                else
                    entidad.NumeroAval = this.txtNumeroAval.Text;

                if (this.txtMontoAvalado.Text.Length < 1)
                    entidad.MontoAvalado = 0;
                else
                    entidad.MontoAvalado = decimal.Parse(this.txtMontoAvalado.Text);

                if (this.txtIdGarantiaBCR.Text.Length < 1)
                    entidad.CodGarantiaBCR = string.Empty;
                else
                    entidad.CodGarantiaBCR = this.txtIdGarantiaBCR.Text;

                if (this.txtFechaEmision.Text.Length < 1)
                    entidad.FechaEmision = null;
                else
                    entidad.FechaEmision = DateTime.Parse(this.txtFechaEmision.Text);

                if (this.txtFechaVencimiento.Text.Length < 1)
                    entidad.FechaVencimiento = null;
                else
                    entidad.FechaVencimiento = DateTime.Parse(this.txtFechaVencimiento.Text);

                if (this.ddlTipoPersonaDeudor.Items.Count.Equals(0))
                    entidad.IdTipoPersonaDeudor = null;
                else
                {
                    if (this.ddlTipoPersonaDeudor.SelectedItem.Value.Equals("-1"))
                        entidad.IdTipoPersonaDeudor = null;
                    else
                        entidad.IdTipoPersonaDeudor = int.Parse(this.ddlTipoPersonaDeudor.SelectedItem.Value);
                }

                if (this.txtIdDeudor.Text.Length < 1)
                    entidad.IdDeudor = null;
                else
                    entidad.IdDeudor = txtIdDeudor.Text;

                if (this.ddlTipoAsignacionCalificacion.SelectedItem.Value.Equals("-1"))
                    entidad.IdTipoAsignacionCalificacion = null;
                else
                    entidad.IdTipoAsignacionCalificacion = int.Parse(this.ddlTipoAsignacionCalificacion.SelectedItem.Value);

                if (this.ddlPlazoCalificacion.SelectedItem.Value.Equals("-1"))
                    entidad.IdPlazoCalificacion = null;
                else
                    entidad.IdPlazoCalificacion = int.Parse(this.ddlPlazoCalificacion.SelectedItem.Value);

                if (this.ddlCodigoEmpresaCalificadora.SelectedItem.Value.Equals("-1"))
                    entidad.IdEmpresaCalificadora = null;
                else
                    entidad.IdEmpresaCalificadora = int.Parse(this.ddlCodigoEmpresaCalificadora.SelectedItem.Value);

                if (this.ddlCategoriaCalificacion.SelectedItem.Value.Equals("-1"))
                    entidad.IdCategoriaRiesgoEmpresaCalificadora = null;
                else
                    entidad.IdCategoriaRiesgoEmpresaCalificadora = int.Parse(this.ddlCategoriaCalificacion.SelectedItem.Value);

                if (this.ddlCalificacionRiesgo.SelectedItem.Value.Equals("-1"))
                    entidad.IdCalificacionEmpresaCalificadora = null;
                else
                    entidad.IdCalificacionEmpresaCalificadora = int.Parse(this.ddlCalificacionRiesgo.SelectedItem.Value);
                
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

    /*VALIDACION RANGO DE FECHA MAYOR A*/
    //private bool ValidarRangoFechaMayor()
    //{
    //    // FALSE - NO | TRUE - SI
    //    bool existeError = false;

    //    if (generadorControles.ObtenerComparacion(txtFechaEmision.Text, txtFechaVencimiento.Text, EnumTipoComparacion.MAYORIGUAL, TypeCode.DateTime))
    //    {
    //        existeError = true;

    //        //MENSAJE DE ERROR DE FECHAS DIFERENTES
    //        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblFechaVencimiento.Text, "mayor a " + this.lblFechaEmision.Text);
    //        this.mpeInformarBox.Show();
    //    }
    //    return existeError;
    //}

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

    ///*VALIDACION DEL FORMATO DEL N BIEN */
    //private List<KeyValuePair<string, bool>> ValidarNumeroBien()
    //{
    //    List<KeyValuePair<string, bool>> retorno = new List<KeyValuePair<string, bool>>();

    //    var regex6Numerico = new Regex(@"^\d{6}$");
    //    var regex3letras3numeros = new Regex(@"^[a-zA-Z]{3}\d{3}$");

    //    var regexNoVocales = new Regex(@"^[^aeiouAEIOU]{3}");

    //    //Control de Cambios 1.1
    //    var regex17alfanumericosFijo = new Regex(@"^([a-zA-Z]|\d){17}$");
    //    var regex17alfanumericos = new Regex(@"^([a-zA-Z]|\d){1,17}$");

    //    var regexLetras = new Regex("^[a-zA-Z]*$");

    //    bool existeError = false; // FALSE - NO | TRUE - SI
    //    bool existeErrorSoloLetras = false; // FALSE - NO | TRUE - SI

    //    //VALOR SELECCIONADO EN EL TIPO BIEN (X -)
    //    string valorTipoBien = this.ddlTipoBien.SelectedItem.Text.Substring(0, 3);
    //    //VALOR SELECCIONADO EN EL TIPO BIEN (XX -)
    //    string valorTipoBien2 = this.ddlTipoBien.SelectedItem.Text.Substring(0, 4);

    //    //VALOR SELECCIONADO EN EL FORMATO DE IDENTIFICACION VEHICULO
    //    string valorFormatoIdentificacion = this.ddlFormato.SelectedItem.Text;

    //    if (valorTipoBien.Equals("1 -") || valorTipoBien.Equals("2 -") || valorTipoBien.Equals("9 -") || valorTipoBien2.Equals("10 -"))
    //    {
    //        //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES
    //        if (!regex6Numerico.IsMatch(this.txtNBien.Text))
    //        {
    //            existeError = true;
    //        }
    //    }
    //    else
    //    {
    //        if (!valorTipoBien.Equals("3 -"))
    //        {
    //            //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES
    //            if (!regex17alfanumericos.IsMatch(this.txtNBien.Text))
    //            {
    //                existeError = true;
    //            }

    //            //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES PERO NO DEBEN SER SOLO LETRAS
    //            if (regexLetras.IsMatch(this.txtNBien.Text))
    //            {
    //                existeError = true;
    //                existeErrorSoloLetras = true;
    //            }
    //        }
    //    }

    //    if (valorTipoBien.Equals("3 -"))
    //    {
    //        if (valorFormatoIdentificacion.Equals("Numérico 6 enteros"))
    //        {
    //            //VERIFICACION DEL FORMATO NUMERICO 6 CARACTERES
    //            if (!regex6Numerico.IsMatch(this.txtNBien.Text))
    //            {
    //                existeError = true;
    //            }
    //        }
    //        else
    //        {
    //            if (valorFormatoIdentificacion.Equals("Alfanumérico 3 letras y 3 enteros"))
    //            {
    //                //VERIFICACION DEL FORMATO 3 LETRAS Y 3 NUMEROS
    //                if (!regex3letras3numeros.IsMatch(this.txtNBien.Text))
    //                {
    //                    existeError = true;
    //                }
    //                if (!regexNoVocales.IsMatch(this.txtNBien.Text))
    //                {
    //                    existeError = true;
    //                }
    //            }
    //            else
    //            {
    //                //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES
    //                if (!regex17alfanumericosFijo.IsMatch(this.txtNBien.Text))
    //                {
    //                    existeError = true;
    //                }

    //                //VERIFICACION DEL FORMATO ALFANUMERICO 17 CARACTERES PERO NO DEBEN SER SOLO LETRAS
    //                if (regexLetras.IsMatch(this.txtNBien.Text))
    //                {
    //                    existeError = true;
    //                    existeErrorSoloLetras = true;
    //                }
    //            }
    //        }
    //    }

    //    retorno.Add(new KeyValuePair<string, bool>("errorFormato", existeError));
    //    retorno.Add(new KeyValuePair<string, bool>("errorLetras", existeErrorSoloLetras));

    //    return retorno;
    //}

    /*EFECTO FORMATO MAXIMO CAMPO*/
    private bool ValidarGuardarExcepciones()
    {
        bool retorno = false;

        if (ValidarCaracterEspecial(this.txtNumeroAval.Text) || ValidarCaracterEspecial(this.txtIdDeudor.Text))
        {
            //MENSAJE DE ERROR POR CARACTER ESPECIAL
            BarraMensaje(null, "");
            retorno = true;
        }

        return retorno;
    }

     #region METODOS PARA EL DROPDOWNLIST

    protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddl = ((DropDownList)(sender));

            switch (ddl.ID.ToString().ToUpper())
            {
                #region DDL TIPOS AVALES
                case "DDLTIPOAVAL":
                    //DdlTiposAvales();
                    CargarDatosTipoAval();
                    break;
                #endregion

                #region DDL TIPOS PERSONAS DEUDOR
                case "DDLTIPOPERSONADEUDOR":
                    DdlTipoPersonaDeudor(sender);
                    break;
                #endregion

                #region DDL TIPO ASIGNACION CALIFICACION
                case "DDLTIPOASIGNACIONCALIFICACION":
                    DdlTipoAsignacionCalificacion(sender);                   
                break;
                #endregion

                #region DDL TIPO PLAZO CALIFICACIÓN
                case "DDLPLAZOCALIFICACION":
                    DdlPlazoCalificacion(sender);                   
                break;
                #endregion

                #region DDL CÓDIGO EMPRESA CALIFICADORA
                case "DDLCODIGOEMPRESACALIFICADORA":
                    DdlCodigoEmpresaCalificadora(sender);                   
                break;
                #endregion

                #region DDL CATEGORIA CALIFICACION
                case "DDLCATEGORIACALIFICACION":
                    DdlCategoriaCalificacion(sender);                   
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

    /*CARGAR MASCARA ID DEUDOR*/
    private void DdlTipoPersonaDeudor(object sender)
    {
        try
        {

            this.txtIdDeudor.Text = "";
            maskIdDeudor.Enabled = false;

            if (this.ddlTipoPersonaDeudor.SelectedItem.Text.Substring(0, 3).Equals("5 -"))
            {
                this.txtIdDeudor.MaxLength = 17;
                this.txtIdDeudor.ToolTip = "#################";
            }
            else
            {
                this.txtIdDeudor.MaxLength = 30;
                this.txtIdDeudor.ToolTip = "##############################";
            }

            if (this.ddlTipoPersonaDeudor.SelectedItem.Text.Substring(0, 3).Equals("1 -"))
            {
                maskIdDeudor.Enabled = true;
                maskIdDeudor.Mask = "9-9999-9999";
                this.txtIdDeudor.ToolTip = "#-####-####";
                this.txtIdDeudor.MaxLength = 30;
            }
            if (this.ddlTipoPersonaDeudor.SelectedItem.Text.Substring(0, 3).Equals("2 -"))
            {
                maskIdDeudor.Enabled = true;
                maskIdDeudor.Mask = "9-999-999999";
                this.txtIdDeudor.ToolTip = "#-###-######";
                this.txtIdDeudor.MaxLength = 30;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlTipoAsignacionCalificacion(object sender)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            string seleccionado = ddlTipoAsignacionCalificacion.SelectedItem.Text.Substring(0, 3);

            #endregion

            //SI TIPO ASIGNACIÓN CALIFICACIÓN ES DIFERENTE AL POR DEFECTO (“0 – NO TIENE CALIFICACIÓN”) SE DEBEN DE HABILITAR LOS SIGUIENTES OBJETOS
            if (!seleccionado.Equals("0 -"))
            {
                if (ddlPlazoCalificacion != null)
                {
                    AdministrarBlanco("ddlPlazoCalificacion", false);
                    ddlPlazoCalificacion.Enabled = true;
                }
                if (ddlCodigoEmpresaCalificadora != null)
                {
                    AdministrarBlanco("ddlCodigoEmpresaCalificadora", false);
                    ddlCodigoEmpresaCalificadora.Enabled = true;
                }
                if (ddlCategoriaCalificacion != null)
                {
                    LimpiarDropDownList(ddlCategoriaCalificacion);
                    DdlCodigoEmpresaCalificadora(null);
                    AdministrarBlanco("ddlCategoriaCalificacion", false);
                    ddlCategoriaCalificacion.Enabled = true;
                }
                if (ddlCalificacionRiesgo != null)
                {
                    LimpiarDropDownList(ddlCalificacionRiesgo);
                    DdlCategoriaCalificacion(sender);
                    AdministrarBlanco("ddlCalificacionRiesgo", false);
                    ddlCalificacionRiesgo.Enabled = true;
                }
            }
            else
            {
                //SI TIPO ASIGNACIÓN CALIFICACIÓN ES IGUAL AL POR DEFECTO (“0 – NO TIENE CALIFICACIÓN”) SE DEBEN DE INHABILITAR LOS SIGUIENTES OBJETOS
                if (ddlPlazoCalificacion != null)
                {
                    AdministrarBlanco("ddlPlazoCalificacion", true);
                    ddlPlazoCalificacion.Enabled = false;
                }
                if (ddlCodigoEmpresaCalificadora != null)
                {
                    AdministrarBlanco("ddlCodigoEmpresaCalificadora", true);
                    ddlCodigoEmpresaCalificadora.Enabled = false;
                }
                if (ddlCategoriaCalificacion != null)
                {
                    AdministrarBlanco("ddlCategoriaCalificacion", true);
                    ddlCategoriaCalificacion.Enabled = false;
                }
                if (ddlCalificacionRiesgo != null)
                {
                    AdministrarBlanco("ddlCalificacionRiesgo", true);
                    ddlCalificacionRiesgo.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlPlazoCalificacion(object sender)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            #endregion

            if (ddlPlazoCalificacion != null)
            {

                if (!ddlPlazoCalificacion.SelectedValue.Equals("-1"))
                {
                    string valorfiltro = string.Empty;
                    valorfiltro = ddlPlazoCalificacion.SelectedValue;

                    if (ddlCodigoEmpresaCalificadora != null)
                    {
                        LimpiarDropDownList(ddlCodigoEmpresaCalificadora);

                        ddlCodigoEmpresaCalificadora.DataSource = LlenarDropDownList("EmpresasCalificadorasLista", valorfiltro);
                        ddlCodigoEmpresaCalificadora.DataTextField = "Texto";
                        ddlCodigoEmpresaCalificadora.DataValueField = "Valor";
                        ddlCodigoEmpresaCalificadora.DataBind();

                        DdlCodigoEmpresaCalificadora(sender);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlCodigoEmpresaCalificadora(object sender)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            #endregion

            if (ddlCodigoEmpresaCalificadora != null)
            {
                if (!ddlCodigoEmpresaCalificadora.SelectedValue.Equals("-1"))
                {
                    string valorfiltro = string.Empty;
                    valorfiltro = ddlCodigoEmpresaCalificadora.SelectedValue;

                    if (ddlCategoriaCalificacion != null)
                    {
                        LimpiarDropDownList(ddlCategoriaCalificacion);

                        ddlCategoriaCalificacion.DataSource = LlenarDropDownList("CalificacionesEmpresasCalificadorasCategoriaRiesgoLista", valorfiltro);
                        ddlCategoriaCalificacion.DataTextField = "Texto";
                        ddlCategoriaCalificacion.DataValueField = "Valor";
                        ddlCategoriaCalificacion.DataBind();

                        DdlCategoriaCalificacion(sender);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlCategoriaCalificacion(object sender)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            StringBuilder valorfiltro = new StringBuilder();
            valorfiltro.Clear();
  
            #endregion

            if (ddlCodigoEmpresaCalificadora != null)
            {
                if (!ddlCodigoEmpresaCalificadora.SelectedValue.Equals("-1"))
                {
                    if (ddlCategoriaCalificacion != null)
                    {
                        valorfiltro.Append(ddlCodigoEmpresaCalificadora.SelectedValue);
                        valorfiltro.Append("|");
                        valorfiltro.Append(ddlCategoriaCalificacion.SelectedValue);

                        if (ddlCalificacionRiesgo != null)
                        {
                            LimpiarDropDownList(ddlCalificacionRiesgo);

                            ddlCalificacionRiesgo.DataSource = LlenarDropDownList("CalificacionesEmpresasCalificadorasCalificacionLista", valorfiltro.ToString());
                            ddlCalificacionRiesgo.DataTextField = "Texto";
                            ddlCalificacionRiesgo.DataValueField = "Valor";
                            ddlCalificacionRiesgo.DataBind();
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

    /*METODO BTN BUSCAR CLIENTE*/
    private void ObtenerDatosCliente()
    {
        //  LimpiarDatosCliente();

        string identificacion = this.txtIdDeudor.Text.TrimEnd().TrimStart();
        string tipoPersona = this.ddlTipoPersonaDeudor.SelectedItem.Text.Substring(0, 3);

        if (identificacion.Length > 0)
        {
            
            PolizaClienteEntidad infoCliente = wsGarantias.GarantiasRealesPolizaConsultarCliente(identificacion);

            if (infoCliente != null)
            {
                if (infoCliente.CodigoError.Equals("0"))
                {
                    if (tipoPersona.Equals("1 -") || tipoPersona.Equals("3 -") || tipoPersona.Equals("5 -"))
                    {
                        this.txtNombreDeudor.Text = infoCliente.Nombre + " " + infoCliente.PrimerApellido + " " + infoCliente.SegundoApellido;
                    }
                    else
                    {
                        if (tipoPersona.Equals("2 -") || tipoPersona.Equals("4 -") || tipoPersona.Equals("6 -"))
                        {
                            this.txtNombreDeudor.Text = infoCliente.RazonSocial;
                        }
                        else
                        {
                            this.txtNombreDeudor.Text = string.Empty;
                        }
                    }

                    HabilitaBotonesBusquedaDeudor(false);

                    HabilitaBotonLimpiarDeudor(true);

                    ////DESHABILITA EL DDL TIPO IDENTIFICACIÓN Y TXT IDENTIFICACION
                    //this.ddlPolizaTipoIdentificacion.Enabled = false;
                    //this.txtPolizaIdentificacion.Enabled = false;
                    //this.btnPolizaIdentificacionBuscar.Enabled = false;

                    ////HABILITA EL BTN LIMPIAR 
                    //this.btnPolizaLimpiar.Enabled = true;
                }
                else
                {
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_30");
                    this.mpeInformarBox.Show();
                }
            }
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

    #region METODOS PARA EL BOTONES

    /*BOTON DE BUSQUEDA DEUDOR*/
    protected void btnConsultarDeudor_Click(object sender, EventArgs e)
    {
        try
        {
            LimpiarBarraMensaje();
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (ValidarCaracterEspecial(this.txtIdDeudor.Text))
                {
                    //MENSAJE DE ERROR POR CARACTER ESPECIAL
                    BarraMensaje(null, "");
                }
                else
                {
                    ObtenerDatosCliente();
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

    //#endregion

    #region METODOS PARA TEXT BOX

    protected void txtNumeroAval_TextChanged(object sender, EventArgs e)
    {
        try
        {
            CargarIdGarantiaBCR(sender, e);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //protected void TextBox_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {

    //        TextBox txt = ((TextBox)(sender));

    //        switch (txt.ID.ToString().ToUpper())
    //        {
    //            #region TXT NUMERO AVAL
    //            case "TXTNUMEROAVAL":
    //                CargarEfectosDetalleGarantiasAvales();
    //                break;
    //            #endregion

    //            //#region TXT FOLIO
    //            //case "TXTFOLIO":
    //            //    CompletarCerosIzquierda(txtFolio, mskFolio);
    //            //    break;
    //            //#endregion

    //            //#region TXT ASIENTO
    //            //case "TXTASIENTO":
    //            //    CompletarCerosIzquierda(txtAsiento, mskAsiento);
    //            //    break;
    //            //#endregion

    //            //#region TXT SECUENCIA
    //            //case "TXTSECUENCIA":
    //            //    CompletarCerosIzquierda(txtSecuencia, mskSecuencia);
    //            //    break;
    //            //#endregion

    //            //#region TXT SUB SECUENCIA
    //            //case "TXTSUBSECUENCIA":
    //            //    CompletarCerosIzquierda(txtSubSecuencia, mskSubSecuencia);
    //            //    break;
    //            //#endregion

    //            //#region TXT CONSECUTIVO
    //            //case "TXTCONSECUTIVO":
    //            //    CompletarCerosIzquierda(txtConsecutivo, mskConsecutivo);
    //            //    break;
    //            //#endregion

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Application["Exception"] = ex;
    //        Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
    //    }
    //}

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
    #endregion

    ///*AUTOCOMPLETAR CEROS A LA IZQUIERDA SECCION DATOS ADICIONALES*/
    //private void CompletarCerosIzquierda(TextBox txtNombre, MaskedEditExtender mskLongitud)
    //{
    //    try
    //    {

    //        int cantidadTotal = mskLongitud.Mask.Length;
    //        int cantidadTxt = txtNombre.Text.Length;

    //        int diferencia = cantidadTotal - cantidadTxt;

    //        string valorFinal = string.Empty;

    //        for (int i = 0; i < diferencia; i++)
    //        {
    //            valorFinal = valorFinal + '0';
    //        }

    //        valorFinal = valorFinal + txtNombre.Text;
    //        txtNombre.Text = valorFinal;

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //#endregion
 
    #region ENTIDADES

    /*INSERTA EL REGISTRO*/
    private void InsertarEntidadGarantiaAval()
    {
        try
        {
            GarantiasAvalesEntidad entidad = new GarantiasAvalesEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            //ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidad();

            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                //INSERCION DE LA SECCION TOTAL
                respuesta = wsGarantias.GarantiasAvalesInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

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
    private void ModificarEntidadGarantiaAval()
    {
        try
        {
            GarantiasAvalesEntidad entidad = new GarantiasAvalesEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            //ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidad();

            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                //INSERCION DE LA SECCION ENCABEZADO
                respuesta = wsGarantias.GarantiasAvalesModificar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));

                //SI EXISTE ERROR EN LA VALIDACION
                if (!respuesta.ValorEstado.Equals(0))
                {
                    this.hdnIdGeneral.Value = respuesta.ValorEstado.ToString();
                    //CargarControlesSinError();
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
    private GarantiasAvalesEntidad ConsultarDetalleEntidad()
    {
        try
        {
            GarantiasAvalesEntidad entidadRetorno = new GarantiasAvalesEntidad();
            GarantiasAvalesEntidad entidadConsulta = new GarantiasAvalesEntidad();

            if (pantallaModuloOculto.Value != null && hdnIdGeneral.Value.Length > 0)//VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            {
                entidadConsulta.IdGarantiaAval = int.Parse(hdnIdGeneral.Value);

                entidadRetorno = wsGarantias.GarantiasAvalesConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
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
            wsConfiguracion.Url = ConfigurationManager.AppSettings["ConfiguracionWS"].ToString();

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

    protected ConfiguracionWS.BitacorasEntidad AsignarValoresBitacoraConfiguracionWS(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA

            bitacorasConfiguracionWSEntidad.CodAccion = bitacoraBanderas.TipoBitacoraConsulta(_tipo);
            bitacorasConfiguracionWSEntidad.CodModulo = int.Parse(pantallaModuloOculto.Value);
            bitacorasConfiguracionWSEntidad.CodEmpresa = int.Parse(Resources.Resource._empresa);
            bitacorasConfiguracionWSEntidad.CodSistema = Resources.Resource._sistema;
            bitacorasConfiguracionWSEntidad.CodUsuario = codUsuarioOculto.Value;

            #endregion

            return bitacorasConfiguracionWSEntidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*BLOQUEA LOS CONTROLES CUANDO LA GARANTIA ESTÁ DESACTUALIZADA*/
    private void BloquearControlesDesactualizados()
    {
        AdministrarControlesExcepcionesTotal(false);
        DeshabilitarControlesGuardar(true);
    }

    /*BLOQUEA LOS CONTROLES AL GUARDAR UN REGISTRO NUEVO*/
    private void BloquearControlesGuardar()
    {
        try
        {
            AdministrarControlesExcepcionesTotal(false);
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

    //EVENTO MESAJES EMERGENTES FORMULARIO 
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

                if (wsConfiguracion != null)
                {
                    wsConfiguracion.Dispose();
                    wsConfiguracion = null;
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
    #endregion
   
}


