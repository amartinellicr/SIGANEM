using System;
using System.Web;
using System.Text;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Reflection;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

using SesionesWCF;
using SeguridadWS;
using GarantiasWS;
using ListasWS;
using BCRMQWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class ValoresNew : System.Web.UI.Page
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

    #region  GRID ADMINISTRACION GRAVAMENES

    private Button btnAgregarGravamen = null;
    private Button btnEliminarGravamen = null;
    private Button btnModificarGravamen = null;

    #endregion

    #region  VENTANA ADMINISTRACION DE GRAVAMENES

    private Button btnGravamenesGarantiasAceptar = null;
    private Button btnGravamenesGarantiasCancelar = null;

    #endregion

    #region GRID ADMINISTRACION GRAVAMENES

    private GridView gridGravamenesInterno = null;

    #endregion

    private wucGridControl grid = null;

    #endregion

    #region REFERENCIAS

    private BitacoraFlags bitacoraBanderas = new BitacoraFlags();
    private GeneradorControles generadorControles = new GeneradorControles();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private GarantiasWS.BitacorasEntidad bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
    private ListasWS.PantallasEntidad pantallasEntidad = new ListasWS.PantallasEntidad();
    private Object garantiaValorEntidad = new Object();

    private WSMQ wsMQBCR = new WSMQ();
    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemGarantiasWS wsGarantias = new SiganemGarantiasWS();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();

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

            #region MENSAJE CONFIRMAR ELIMINAR GRAVAMENES

            //SE ESTABLECEN LAS DESCRIPCIONES A MOSTRAR EN EL MENSAJE DE CONFIRMACION PARA ELIMINACION
            this.MensajeConfirmarEliminarGravamenes1.EstablecerMensaje("Se eliminarán los gravamenes asociados.");
            this.MensajeConfirmarEliminarGravamenes1.EstablecerNombreBotones("Sí", "No");

            Button btnAceptarConfirmarEliminarGravamen = (Button)this.MensajeConfirmarEliminarGravamenes1.FindControl("wucBtnAceptar");
            btnAceptarConfirmarEliminarGravamen.Click += new EventHandler(btnAceptarConfirmarEliminarGravamen_Click);
            btnAceptarConfirmarEliminarGravamen.CausesValidation = false;

            Button btnCancelarConfirmarEliminarGravamen = (Button)this.MensajeConfirmarEliminarGravamenes1.FindControl("wucBtnCancelar");
            btnCancelarConfirmarEliminarGravamen.Click += new EventHandler(btnCancelarConfirmarEliminarGravamen_Click);
            btnCancelarConfirmarEliminarGravamen.CausesValidation = false;

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

            #region MENSAJE INFORMAR

            Button btnAceptarInformar = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);

            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

            #endregion

            if (!IsPostBack)
            {
                //LLAMADO A LOS EVENTOS QUE CREAN LOS CONTROLES EN EL FORMULARIO
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
            // LLAMADO A LOS EVENTOS QUE CREAN LOS CONTROLES EN EL FORMULARIO
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
                    //BLOQUEA LOS CONTROLES GENERALES NO UTILIZADOS
                    ControlesSoloLecturaExcepciones();
                    //BLOQUEA LOS CONTROLES NO UTILIZADOS SEGUN TIPO VALOR
                    ControlesModificacionExcepcion();
                    //BLOQUEA LOS CONTROLES NO UTILIZADOS
                    DeshabilitarControlesExcepciones();
                    //MUESTRA LAS NOTIFICACIONES DEL MANEJO DE GRIDS
                    MensajesGrid();
                    //EFECTO DEL DLL IND GRAVAMEN - SECCION GRAVAMENES
                    EfectoDdlIndGravamen();
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

    protected void btnControl_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                switch (((Button)sender).ID.ToUpper())
                {
                    case "VALIDAR":
                        BtnValidar();
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    private void BtnValidar()
    {
        if (!ValidarSeccionGeneral())
            if(!ValidarEntidadValor())
                CargarControlSinError();
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

    protected void btnBusqueda_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                switch (ValorTipoValor())
                {
                    case 1:
                        EjecutarBusquedaISIN(sender, e);
                        break;
                    case 2:
                        EjecutarCertificadosDepositoPlazo(sender, e);
                        break;
                }
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

    #region BUSQUEDAS

    /*ESTABLECE LOS DATOS DE LA CONSULTA DE BCR CLIENTES EN EL GRID*/
    private void EjecutarCertificadosDepositoPlazo(object sender, EventArgs e)
    {
        try
        {
            #region VARIABLES

            //NO SE PERMITEN CARACTERES ESPECIALES
            var regexItem = new Regex("^[a-zA-Z0-9]*$");
            GarantiasValoresRespuestaCDPEntidad entidadCDP = null;

            #endregion

            #region BUSCAR CONTROLES

            string txtBuscarCDP = ((TextBox)this.tableData.FindControl("txtCustomBusqueda")).Text;

            #endregion

            if ((txtBuscarCDP != null))
            {
                //VALIDACION DEL CAMPO GARANTIA
                if (!txtBuscarCDP.Length.Equals(0))
                {
                    //VALIDACION DE CARACTERES ESPECIALES
                    if (regexItem.IsMatch(txtBuscarCDP))
                    {
                        //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
                        if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
                        {
                            this.divBarraMensaje.Visible = false;
                        }

                        entidadCDP = wsGarantias.GarantiasValoresConsultarCDP(txtBuscarCDP);
                        if (entidadCDP != null)
                        {
                            if (!entidadCDP.ValorEstado.Equals(-1))
                            {
                                InsertarExcepcionBusquedaCDP(entidadCDP);
                            }
                            else
                            {
                                entidadCDP = null;
                                InsertarExcepcionBusquedaCDP(entidadCDP);

                                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_30");
                                this.mpeInformarBox.Show();
                            }
                        }
                        else
                        {
                            InsertarExcepcionBusquedaCDP(entidadCDP);

                            this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_30");
                            this.mpeInformarBox.Show();
                        }
                    }
                    else
                    {
                        BarraMensaje(null, "SYS_2");
                    }
                }
                else
                {
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_29");
                    this.mpeInformarBox.Show();
                }
            }
        }
        catch (System.Web.Services.Protocols.SoapException sx)
        {
            if (sx.Message.Contains("Error."))
            {
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_31");
                this.mpeInformarBox.Show();
            }
        }
    }

    private void EjecutarBusquedaISIN(object sender, EventArgs e)
    {
        #region VARIABLES

        //NO SE PERMITEN CARACTERES ESPECIALES
        var regexItem = new Regex("^[a-zA-Z0-9]*$");
        var regexExcepcion = new Regex("^[NoNOno ]*$");
        GarantiasValoresRespuestaISINEntidad entidadISIN = null;

        #endregion

        #region BUSCAR CONTROLES

        string txtBuscarISIN = ((TextBox)this.tableData.FindControl("txtCustomBusqueda")).Text;

        #endregion

        if ((txtBuscarISIN != null))
        {
            //VALIDACION DEL CAMPO GARANTIA
            if (!txtBuscarISIN.Length.Equals(0))
            {
                //VALIDACION DE CARACTERES ESPECIALES
                if (regexItem.IsMatch(txtBuscarISIN))
                {
                    #region LIMPIAR MENSAJES

                    //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
                    if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
                    {
                        this.divBarraMensaje.Visible = false;
                    }

                    #endregion

                    if (!regexExcepcion.IsMatch(txtBuscarISIN))
                    {
                        entidadISIN = wsGarantias.GarantiasValoresConsultarISIN(txtBuscarISIN);
                        if (entidadISIN != null)
                        {
                            InsertarExcepcionResultadoISIN(entidadISIN);
                        }
                        else
                        {
                            InsertarExcepcionBusquedaConISIN(false);

                            this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_30");
                            this.mpeInformarBox.Show();
                        }
                    }
                    else
                    {
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_34");
                        this.mpeInformarBox.Show();
                    }
                }
                else
                {
                    BarraMensaje(null, "SYS_2");
                }
            }
            else
            {
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_29");
                this.mpeInformarBox.Show();
            }
        }
    }

    #endregion

    #region GRID ADMINISTRACION GRAVAMENES

    protected void btnAgregarGravamen_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                this.VentanaGravamenesGarantias1.LimpiarContenido();
                this.VentanaGravamenesGarantias1.EfectosControles(true);
                this.VentanaGravamenesGarantias1.CargarContenido(CargaArregloControles());
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

            wucGridControl grdGravamenes = (wucGridControl)this.tableData.FindControl("gridGravamenes");
            this.gridGravamenesInterno = (GridView)grdGravamenes.FindControl("MasterGridView");
            

            if (sesion.Codigo == 0)
            {
                if (grdGravamenes.ContadorSeleccionados() > 0)
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
                                //BloquearControlesDesactualizados();
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
                    if (grdGravamenes.ContadorElementos() > 0)
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
            wucGridControl grdGravamenes = (wucGridControl)this.tableData.FindControl("gridGravamenes");
            this.gridGravamenesInterno = (GridView)grdGravamenes.FindControl("MasterGridView");

            if (sesion.Codigo == 0)
            {
                if (grdGravamenes.ContadorElementos() > 0)
                {
                    if (grdGravamenes.ContadorSeleccionados().Equals(1))
                    {
                        //CARGA LOS VALORES DE LOS CONTROLES
                        CargaArregloControles();
                        this.VentanaGravamenesGarantias1.LimpiarContenido();
                        this.VentanaGravamenesGarantias1.EfectosControles(false);
                        this.VentanaGravamenesGarantias1.CargarContenido(CargaArregloControles());

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

            entidad.IdGarantiaReal = null;
            entidad.IdGarantiaValor = int.Parse(this.hdnIdGeneral.Value);

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
                AdministrarControlesExcepcionesGeneral(false);
                AdministrarControlesExcepcionesGravamenes(false);
                DeshabilitarControlesGuardar(true);
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
                this.gridGravamenesInterno = (GridView)this.tableData.FindControl("gridGravamenes").FindControl("MasterGridView");

                if (gridGravamenesInterno != null)
                {
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

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS NO EDITABLES

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

    /*CARGA LOS CONTROLES PARA EL POUP DE ADMINSTRACION DE GRAVAMENES*/
    private List<ControlEntidad> CargaArregloControles()
    {
        try
        {
            List<ControlEntidad> controlEntidad = null;

            ListasWS.PantallasEntidad pantalla = new ListasWS.PantallasEntidad();
            pantalla.CodPantalla = int.Parse(pantallaModuloOculto.Value);
            pantalla.Pestana = string.Empty;

            //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD        
            controlEntidad = this.wsListas.AdministracionesContenidosConsultaControl(pantalla).ToList();

            return controlEntidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES PARA LOS TITULOS*/
    private void Etiquetas()
    {
        try
        {
            if (pantallaNombreOculto.Value != null)
            {
                ((Button)this.Master.FindControl("MenuLateral1").FindControl("cmdAreaMenuLateralDetalleBoton")).Text = pantallaTituloOculto.Value; //CARGA EL NOMBRE DE LA PANTALLA EN LA SECCION INFERIOR IZQUIERDA

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
                List<ControlEntidad> controles = new List<ControlEntidad>();
                controles = this.wsListas.AdministracionesContenidosConsultaControl(pantalla).ToList();

                //CREAR E INSERTA LOS CONTROLES EN LA PAGINA ACTUAL    
                LlenarTabla(this.tableData, pantallaNombreOculto.Value, controles);
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
            #region LIMPIAR CONTROLES NO BLOQUEADOS

            //LIMPIA LOS CONTROLES TEXTBOX-DROPDOWNLIST
            generadorControles.Limpiar_Controles(this.tableData);

            #endregion

            #region LIMPIAR MENSAJES

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            LimpiarBarraMensaje();

            #endregion

            #region ASIGNAR VALORES DEFAULT

            #region BUSCAR CONTROLES

            DropDownList ddlTipoVal = ((DropDownList)this.tableData.FindControl("IdTipoValor"));
            DropDownList ddlTipoAsignCalif = ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion"));
            DropDownList ddlMonedaValorFacial = ((DropDownList)this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = ((DropDownList)this.tableData.FindControl("IdMonedaValorMercado"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));
            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlClasificInstrum = ((DropDownList)this.tableData.FindControl("ddlCustomClasificacionInstrumento"));
            DropDownList ddlTipoPersonaEmisor = ((DropDownList)this.tableData.FindControl("IdTipoPersonaEmisor"));

            #endregion

            if (pantallaIdOculto.Value.Equals("0"))
            {

                LimpiarContenidoFormulario();
                generadorControles.SeleccionarOpcionDropDownList(ddlTipoVal, "1");
                DdlTipoValor(ddlTipoVal);
                generadorControles.SeleccionarOpcionDropDownList(ddlTipoAsignCalif, "1");
                DdlTipoAsignacionCalificacion(ddlTipoAsignCalif);
            }
            else
            {
                #region LIMPIAR MODIFICAR
                switch (ValorTipoValor())
                {
                    case 1:
                        #region LIMPIAR DROPDOWNLIST
                        generadorControles.SeleccionarOpcionDropDownList(ddlTipoAsignCalif, "1");
                        DdlTipoAsignacionCalificacion(ddlTipoAsignCalif);
                        generadorControles.SeleccionarOpcionDropDownList(ddlTipoPersonaEmisor, "1");
                        generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorFacial, "1");
                        generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, "1");
                        #endregion
                        #region LIMPIAR TEXTBOX
                        CargarIdentificacionInstrumento(ddlInstrumento);
                        ((TextBox)this.tableData.FindControl("FechaValorMercado")).Text = string.Empty;
                        ((TextBox)this.tableData.FindControl("FechaConstitucionGarantia")).Text = string.Empty;
                        ((TextBox)this.tableData.FindControl("FechaVencimiento")).Text = string.Empty;
                        #endregion
                        break;
                    case 2:
                        #region LIMPIAR DROPDOWNLIST
                        generadorControles.SeleccionarOpcionDropDownList(ddlTipoAsignCalif, "1");
                        DdlTipoAsignacionCalificacion(ddlTipoAsignCalif);
                        generadorControles.SeleccionarOpcionDropDownList(ddlClasificInstrum, "1");
                        #endregion
                        #region LIMPIAR TEXTBOX
                        ((TextBox)this.tableData.FindControl("Premio")).Text = string.Empty;
                        ((TextBox)this.tableData.FindControl("MontoValorMercado")).Text = string.Empty;
                        ((TextBox)this.tableData.FindControl("FechaValorMercado")).Text = string.Empty;
                        #endregion
                        break;
                    case 3:
                        #region LIMPIAR DROPDOWNLIST
                        generadorControles.SeleccionarOpcionDropDownList(ddlTipoAsignCalif, "1");
                        DdlTipoAsignacionCalificacion(ddlTipoAsignCalif);
                        generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorFacial, "1");
                        generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, "1");
                        #endregion
                        #region LIMPIAR TEXTBOX
                        ((TextBox)this.tableData.FindControl("FechaValorMercado")).Text = string.Empty;
                        ((TextBox)this.tableData.FindControl("FechaConstitucionGarantia")).Text = string.Empty;
                        ((TextBox)this.tableData.FindControl("FechaVencimiento")).Text = string.Empty;
                        #endregion
                        break;
                    case 4:
                        #region LIMPIAR DROPDOWNLIST
                        generadorControles.SeleccionarOpcionDropDownList(ddlTipoAsignCalif, "1");
                        DdlTipoAsignacionCalificacion(ddlTipoAsignCalif);
                        generadorControles.SeleccionarOpcionDropDownList(ddlClasificInstrum, "1");
                        generadorControles.SeleccionarOpcionDropDownList(ddlTipoPersonaEmisor, "1");
                        generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorFacial, "1");
                        generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, "1");
                        #endregion
                        #region LIMPIAR TEXTBOX
                        CargarDropDownIdentificacionEmisor(ddlEmisor);
                        CargarIdentificacionInstrumento(ddlInstrumento);
                        ((TextBox)this.tableData.FindControl("FechaValorMercado")).Text = string.Empty;
                        ((TextBox)this.tableData.FindControl("FechaConstitucionGarantia")).Text = string.Empty;
                        ((TextBox)this.tableData.FindControl("FechaVencimiento")).Text = string.Empty;
                        #endregion
                        break;
                }
                #endregion
            }

            #endregion
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

    /*CARGA LOS CONTROLES AL NO EXISTIR ERROR EN LA VALIDACION DEL GARANTIA VALOR*/
    private void CargarControlSinError()
    {
        try
        {
            LimpiarBarraMensaje();

            //DESHABILITA LA SECCION GENERAL
            AdministrarControlesExcepcionesGeneral(false);

            //HABILITA LOS CONTROLES DE GUARDADO
            DeshabilitarControlesGuardar(false);

            //HABILITA LA SECCION GRAVAMENES
            AdministrarControlesExcepcionesGravamenes(true);
            //CARGA LOS CONTROLES DE LA SECCION GRAVAMENES
            ControlesGravamenes();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*DESHABILITA LOS CONTROLES AL INGRESAR A LA PANTALLA*/
    private void DeshabilitarControlesExcepciones()
    {
        //REGISTRO NUEVO
        if (pantallaIdOculto.Value.Equals("0"))
        {
            DropDownList ddlTipoValor = (DropDownList)this.tableData.FindControl("IdTipoValor");
            AdministrarControlesExcepcionesGravamenes(false);

            if (ddlTipoValor.Enabled)
                DeshabilitarControlesGuardar(true);
            else
                DeshabilitarControlesGuardar(false);
        }
    }

    /*DESHABILITA LOS BOTONES DE GUARDADO EN EL MENU DE ACCIONES*/
    private void DeshabilitarControlesGuardar(bool deshabilitados)
    {
        ((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesGuardar(deshabilitados);
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION GRAVAMENES*/
    private void AdministrarControlesExcepcionesGravamenes(bool habilitado)
    {
        DropDownList ddlIndGravamen = (DropDownList)this.tableData.FindControl("IndGravamen");

        if(ddlIndGravamen != null)
            ddlIndGravamen.Enabled = habilitado;

        this.gridGravamenesInterno = (GridView)this.tableData.FindControl("gridGravamenes").FindControl("MasterGridView");
        if (gridGravamenesInterno != null)
            this.gridGravamenesInterno.Enabled = habilitado;
        
        this.btnAgregarGravamen.Enabled = habilitado;
        this.btnEliminarGravamen.Enabled = habilitado;
        this.btnModificarGravamen.Enabled = habilitado;
        
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION GENERAL*/
    private void AdministrarControlesExcepcionesGeneral(bool habilitado)
    {
        DropDownList ddlTipoValor = (DropDownList)this.tableData.FindControl("IdTipoValor");

        CheckBox chkBusqueda = (CheckBox)this.tableData.FindControl("chkCustomBusqueda");
        TextBox txtBusqueda = (TextBox)this.tableData.FindControl("txtCustomBusqueda");
        RequiredFieldValidator rfvBusqueda = (RequiredFieldValidator)this.tableData.FindControl("rfvBusqueda");
        Button btnBusqueda = (Button)this.tableData.FindControl("imgCustomBusqueda");

        TextBox txtCodGarantiaBCR = (TextBox)this.tableData.FindControl("CodGarantiaBCR");
        RequiredFieldValidator rfvCodGarantiaBCR = (RequiredFieldValidator)this.tableData.FindControl("rfvCodGarantiaBCR");

        DropDownList ddlTipoInstrumento = (DropDownList)this.tableData.FindControl("IdTipoInstrumento");
        DropDownList ddlInstrumento = (DropDownList)this.tableData.FindControl("IdInstrumento");
        DropDownList ddlEmisor = (DropDownList)this.tableData.FindControl("IdEmisor");

        DropDownList ddlISIN1 = (DropDownList)this.tableData.FindControl("ISIN1");
        DropDownList ddlISIN = (DropDownList)this.tableData.FindControl("ISIN");

        TextBox txtSerie = (TextBox)this.tableData.FindControl("txtCustomSerie");
        DropDownList ddlSerie = (DropDownList)this.tableData.FindControl("ddlCustomSerie");

        TextBox txtCodGarantia = (TextBox)this.tableData.FindControl("CodGarantia");

        //CUSTOM INSTRUMENTO
        TextBox txtInstrumento = (TextBox)this.tableData.FindControl("txtCustomInstrumento");
        RequiredFieldValidator rfvInstrumento = (RequiredFieldValidator)this.tableData.FindControl("rfvInstrumento");

        DropDownList ddlTipoPersonaEmisor = (DropDownList)this.tableData.FindControl("IdTipoPersonaEmisor");
        TextBox txtIdentificacionEmisor = (TextBox)this.tableData.FindControl("IdentificacionEmisor");

        TextBox txtIdentificacionInstrumento = (TextBox)this.tableData.FindControl("IdentificacionInstrumento");
        RequiredFieldValidator rfvIdentificacionInstrumento = (RequiredFieldValidator)this.tableData.FindControl("rfvIdentificacionInstrumento");

        TextBox txtPremio = (TextBox)this.tableData.FindControl("Premio");
        DropDownList ddlTipoAsignacionCalificacion = (DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion");
        DropDownList ddlPlazoCalificacion = (DropDownList)this.tableData.FindControl("IdPlazoCalificacion");
        DropDownList ddlEmpresaCalificadora = (DropDownList)this.tableData.FindControl("IdEmpresaCalificadora");
        DropDownList ddlCategoriaRiesgoEmpresaCalificadora = (DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora");
        DropDownList ddlCalificacionEmpresaCalificadora = (DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora");
        TextBox txtMontoValorFacial = (TextBox)this.tableData.FindControl("MontoValorFacial");
        DropDownList ddlMonedaValorFacial = (DropDownList)this.tableData.FindControl("IdMonedaValorFacial");
        TextBox txtMontoValorMercado = (TextBox)this.tableData.FindControl("MontoValorMercado");
        DropDownList ddlMonedaValorMercado = (DropDownList)this.tableData.FindControl("IdMonedaValorMercado");

        TextBox txtFechaValorMercado = (TextBox)this.tableData.FindControl("FechaValorMercado");
        ImageButton imbFechaValorMercado = (ImageButton)this.tableData.FindControl("imgButtonCalendarExtenderFechaValorMercado");
        RequiredFieldValidator rfvFechaValorMercado = (RequiredFieldValidator)this.tableData.FindControl("rfvFechaValorMercado");

        TextBox txtFechaConstitucionGarantia = (TextBox)this.tableData.FindControl("FechaConstitucionGarantia");
        ImageButton imbFechaConstitucionGarantia = (ImageButton)this.tableData.FindControl("imgButtonCalendarExtenderFechaConstitucionGarantia");
        RequiredFieldValidator rfvFechaConstitucionGarantia = (RequiredFieldValidator)this.tableData.FindControl("rfvFechaConstitucionGarantia");

        TextBox txtFechaVencimiento = (TextBox)this.tableData.FindControl("FechaVencimiento");
        ImageButton imbFechaVencimiento = (ImageButton)this.tableData.FindControl("imgButtonCalendarExtenderFechaVencimiento");
        RequiredFieldValidator rfvFechaVencimiento = (RequiredFieldValidator)this.tableData.FindControl("rfvFechaVencimiento");

        DropDownList ddlEstadoGarantia = (DropDownList)this.tableData.FindControl("IdEstadoGarantia");

        Button btnValidar = (Button)this.tableData.FindControl("Validar");

        if (ddlTipoValor != null)
            ddlTipoValor.Enabled = habilitado;
        if (chkBusqueda != null)
            chkBusqueda.Enabled = habilitado;
        if (txtBusqueda != null)
            txtBusqueda.Enabled = habilitado;
        if (rfvBusqueda != null)
            rfvBusqueda.Enabled = habilitado;
        if (btnBusqueda != null)
            btnBusqueda.Enabled = habilitado;
        if (txtCodGarantiaBCR != null)
            txtCodGarantiaBCR.Enabled = habilitado;
        if (rfvCodGarantiaBCR != null)
            rfvCodGarantiaBCR.Enabled = habilitado;
        if (ddlTipoInstrumento != null)
            ddlTipoInstrumento.Enabled = habilitado;
        if (ddlInstrumento != null)
            ddlInstrumento.Enabled = habilitado;
        if (ddlEmisor != null)
            ddlEmisor.Enabled = habilitado;
        if (ddlISIN1 != null)
            ddlISIN1.Enabled = habilitado;
        if (ddlISIN != null)
            ddlISIN.Enabled = habilitado;
        if (txtSerie != null)
            txtSerie.Enabled = habilitado;
        if (ddlSerie != null)
            ddlSerie.Enabled = habilitado;
        if (txtCodGarantia != null)
            txtCodGarantia.Enabled = habilitado;
        if (txtInstrumento != null)
            txtInstrumento.Enabled = habilitado;
        if (rfvInstrumento != null)
            rfvInstrumento.Enabled = habilitado;
        if (ddlTipoPersonaEmisor != null)
            ddlTipoPersonaEmisor.Enabled = habilitado;
        if (txtIdentificacionEmisor != null)
            txtIdentificacionEmisor.Enabled = habilitado;
        if (txtIdentificacionInstrumento != null)
            txtIdentificacionInstrumento.Enabled = habilitado;
        if (rfvIdentificacionInstrumento != null)
            rfvIdentificacionInstrumento.Enabled = habilitado;
        if (txtPremio != null)
            txtPremio.Enabled = habilitado;
        if (ddlTipoAsignacionCalificacion != null)
            ddlTipoAsignacionCalificacion.Enabled = habilitado;
        if (ddlPlazoCalificacion != null)
            ddlPlazoCalificacion.Enabled = habilitado;
        if (ddlEmpresaCalificadora != null)
            ddlEmpresaCalificadora.Enabled = habilitado;
        if (ddlCategoriaRiesgoEmpresaCalificadora != null)
            ddlCategoriaRiesgoEmpresaCalificadora.Enabled = habilitado;
        if (ddlCalificacionEmpresaCalificadora != null)
            ddlCalificacionEmpresaCalificadora.Enabled = habilitado;
        if (ddlCalificacionEmpresaCalificadora != null)
            ddlCalificacionEmpresaCalificadora.Enabled = habilitado;
        if (txtMontoValorFacial != null)
            txtMontoValorFacial.Enabled = habilitado;
        if (ddlMonedaValorFacial != null)
            ddlMonedaValorFacial.Enabled = habilitado;
        if (txtMontoValorMercado != null)
            txtMontoValorMercado.Enabled = habilitado;
        if (ddlMonedaValorMercado != null)
            ddlMonedaValorMercado.Enabled = habilitado;
        if (txtFechaValorMercado != null)
            txtFechaValorMercado.Enabled = habilitado;
        if (imbFechaValorMercado != null)
            imbFechaValorMercado.Enabled = habilitado;
        if (rfvFechaValorMercado != null)
            rfvFechaValorMercado.Enabled = habilitado;
        if (txtFechaConstitucionGarantia != null)
            txtFechaConstitucionGarantia.Enabled = habilitado;
        if (imbFechaConstitucionGarantia != null)
            imbFechaConstitucionGarantia.Enabled = habilitado;
        if (rfvFechaConstitucionGarantia != null)
            rfvFechaConstitucionGarantia.Enabled = habilitado;
        if (txtFechaVencimiento != null)
            txtFechaVencimiento.Enabled = habilitado;
        if (imbFechaVencimiento != null)
            imbFechaVencimiento.Enabled = habilitado;
        if (rfvFechaVencimiento != null)
            rfvFechaVencimiento.Enabled = habilitado;
        if (ddlEstadoGarantia != null)
            ddlEstadoGarantia.Enabled = habilitado;
        if (btnValidar != null)
            btnValidar.Enabled = habilitado;
    }

    /*CARGA LOS CONTROLES AL FORMULARIO*/
    public void LlenarTabla(Table tblPrincipal, string desPagina, List<ControlEntidad> dsControles)
    {
        Boolean AssocRowReady = false;
        #region CREA CONTROLES

        // CREA OBJETO REQUIRED FIELD VALIDATOR
        RequiredFieldValidator rfv = null;

        // CREA OBJETO MaskedEditExtender Ajax Control
        MaskedEditExtender msk = null;

        // CREA OBJETO CalendarExterder Ajax Control
        CalendarExtender calendarExtender = null;

        // CREA OBJETO TABLA TEMPORAL asp:Table
        tblPrincipal.ID = String.Concat("aspTable", desPagina);

        // CREA TABLE ROW
        TableRow tableRow;

        // CREA TABLE ROW PARA CONTROLES DEPENDIENTES
        TableRow tableRowAssocID = null;

        #endregion

        try
        {
            // VARIABLE ROWCOUNT
            int filasContador = 0;

            // RECORRE LOS CONTROLES EXTRAIDOS DESDE LA BD            
            foreach (ControlEntidad control in dsControles)
            {
                filtro = string.Empty;
                string assocID = control.NombrePropiedadAsociada;
                int ancho;
                //0 = SIN ITEMS | 1 = CON ITEMS (PARA DROPDOWNLIST)
                int bandera = 0;

                //SOLO LOS REGISTROS QUE SE DEBEN INCLUIR EN TABS
                if (control.Tab.Length > 0)
                {
                    if (((Control)tblPrincipal.FindControl(control.NombrePropiedad)) == null)
                    {
                        tableRow = new TableRow();
                        tableRow.ID = string.Concat("tr", control.NombrePropiedad);
                        tableRow.Height = Unit.Parse("10");

                        // CREA TABLE CELL
                        TableCell tc1 = new TableCell();
                        tc1.ID = String.Concat("tcRow", filasContador, "Cell", 0);
                        tc1.Width = Unit.Parse("325");
                        tc1.Height = Unit.Parse("15");

                        // CREA ETIQUETA
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

                        // ASIGNA EL NOMBRE 
                        string nombrePropiedad = control.NombrePropiedad;

                        // ASIGNA EL VALOR DEL TIPO DE OBJETO 
                        string tipoContenido = control.TipoContenido;
                        tipoContenido = tipoContenido.ToUpper();

                        // AGREGA LA ETIQUETA A LA CELDA1 
                        if (!tipoContenido.Equals("BUTTON") && !tipoContenido.Equals("AREA") /*&& !tipoContenido.Equals("GRIDVIEW")*/)
                            tc1.Controls.Add(cellLabel);

                        // CREA TABLE CELL 2
                        TableCell tc2 = new TableCell();
                        tc2.ID = String.Concat("tc", "Row", filasContador, "Cell", "2");
                        tc2.Width = Unit.Parse("150");
                        tc2.Height = Unit.Parse("15");

                        // CREA TABLE CELL PARA ASIGNAR LOS CONTROLES DEPENDIENTES
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

                            #region BUTTON
                            case "BUTTON":

                                Button btn = new Button();
                                btn.ID = nombrePropiedad;
                                btn.Text = control.DesColumna;
                                btn.ToolTip = String.Concat("Botón ", control.DesColumna);
                                btn.Enabled = bool.Parse(control.IndModificar);
                                btn.Visible = bool.Parse(control.IndVisible);
                                btn.CssClass = control.CssTipo;

                                btn.Click += new EventHandler(btnControl_Click);

                                tc2.Controls.Add(btn);
                                tc2.Style.Add("text-align", "right");

                                break;
                            #endregion

                            #region TEXTBOX
                            case "TEXTBOX":

                                TextBox txt = new TextBox();
                                txt.ID = nombrePropiedad;
                                txt.Text = control.ValorDefecto;
                                txt.ToolTip = String.Concat("Texto ", control.DesColumna);
                                txt.Enabled = bool.Parse(control.IndModificar);
                                txt.Visible = bool.Parse(control.IndVisible);
                                txt.CssClass = control.CssTipo;
                                txt.MaxLength = Int32.Parse(control.LongitudMaxima);
                                txt.CausesValidation = false;

                                if (nombrePropiedad.Equals("CodGarantiaBCR"))
                                {
                                    //CONTROL PARA LA BUSQUEDA DE ID GARANTIA
                                    txt.AutoPostBack = true;
                                    txt.TextChanged += new EventHandler(CodGarantiaBCR_TextChanged);
                                }

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
                                    ancho = (txt.MaxLength * 9);
                                }
                                txt.Width = ancho;

                                tc2.Controls.Add(txt);

                                #region MASKED EDITEXTENDER

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

                                    msk.MaskType = generadorControles.DeterminaTipoMascara(m);
                                    msk.InputDirection = MaskedEditInputDirection.RightToLeft;
                                    msk.Mask = generadorControles.DeterminaFormatoMascara(mType, control.ValorMascara);
                                }

                                #endregion

                                #region REQUIRED FIELD VALIDATOR

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
                                    wm.ID = string.Concat("wm", control.NombrePropiedad);
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

                            #region DROPDOWN LIST
                            case "DROPDOWNLIST":

                                DropDownList ddl = new DropDownList();
                                ddl.ID = nombrePropiedad;
                                string spTexto = control.MetodoServicioWeb;
                                AssocRowReady = false;

                                if (String.IsNullOrEmpty(spTexto))
                                {
                                    ddl.Items.Add(new ListItem("No hay Datos", "-1"));
                                    bandera = 0; //NO HAY ITEMS
                                }
                                else
                                {
                                    bandera = 1; //EXISTEN ITEMS
                                    LimpiarDropDownList(ddl);

                                    //BUSQUEDA DE LOS VALORES DE FILTRO PARA LOS COMBOS DEPENDIENTES
                                    if (((Control)tblPrincipal.FindControl(control.NombrePropiedadAsociada)) != null)
                                    {
                                        filtro = ((DropDownList)tblPrincipal.FindControl(control.NombrePropiedadAsociada)).SelectedValue;
                                    }
                                    else
                                    {
                                        filtro = control.ValorServicioWeb;
                                    }

                                    //EXCEPCION
                                    if (control.NombrePropiedad.Equals("IdEstadoGarantia"))
                                        filtro = "3";

                                    //EJECUTA LAS EXCEPCIONES PARA LA CARGA DE CONTROLES
                                    CargarControlesExcepciones(tblPrincipal, control);

                                    ddl.DataSource = LlenarDropDownList(spTexto, filtro);
                                    ddl.DataTextField = "Texto";
                                    ddl.DataValueField = "Valor";
                                    ddl.DataBind();
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
                                    ddlValorSeleccionado = ddl.SelectedValue.ToString(); //SE ASIGNA EL ELEMENTO SELECCIONADO POR DEFECTO
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
                                        string longitudR = controlAsociado.LongitudMaxima;
                                        string mascaraR = controlAsociado.Mascara;
                                        string spTextoR = controlAsociado.MetodoServicioWeb;
                                        string assocIDr = controlAsociado.NombrePropiedadAsociada;

                                        DropDownList ddlAssocID = new DropDownList();
                                        ddlAssocID.ID = nombreColumnaR;
                                        ddlAssocID.ToolTip = String.Concat("Lista de ", desColumnaR);
                                        ddlAssocID.Enabled = bool.Parse(controlAsociado.IndModificar);
                                        ddlAssocID.Visible = bool.Parse(controlAsociado.IndVisible);
                                        ddlAssocID.CssClass = controlAsociado.CssTipo;
                                        ddlAssocID.Width = Unit.Parse("100%");

                                        ddlAssocID.Items.Clear();

                                        if (bandera.Equals(0))
                                        {
                                            ddlAssocID.Items.Add("No hay Datos");
                                        }
                                        else
                                        {
                                            ddlAssocID.DataSource = LlenarDropDownList(spTextoR, ddlValorSeleccionado);
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

                                        // CREA LA ETIQUETA ASOCIADA AL CONTROL
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
                                        // AGREGA LA ETIQUETA A LA CELDA
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
                                HtmlGenericControl div = new HtmlGenericControl("div");
                                div.Style.Add("position", "relative");
                                //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES DEL CALENDARIO QUEDEN ALINEADOS
                                HtmlTable calendarTable = new HtmlTable();
                                HtmlTableRow calendarRow = new HtmlTableRow();
                                HtmlTableCell calendarCell_1 = new HtmlTableCell();
                                HtmlTableCell calendarCell_2 = new HtmlTableCell();
                                calendarTable.Style.Add("valign", "middle");

                                #region TEXTBOX

                                //CALENDARIO QUE ALMACENA LA FECHA
                                TextBox txtCalendario = new TextBox();
                                txtCalendario.ID = nombrePropiedad;
                                txtCalendario.Text = string.Empty;
                                txtCalendario.ToolTip = String.Concat("Calendario ", control.DesColumna);
                                txtCalendario.Enabled = bool.Parse(control.IndModificar);
                                txtCalendario.Visible = bool.Parse(control.IndVisible);
                                txtCalendario.Attributes.Add("readonly", "readonly");
                                txtCalendario.CssClass = control.CssTipo;
                                txtCalendario.CausesValidation = false;

                                #endregion

                                #region MASKEDEDITEXTENDER

                                int m2 = Int32.Parse(control.Mascara);
                                msk = new MaskedEditExtender();
                                msk.ID = String.Concat("mask", nombrePropiedad, filasContador);
                                msk.ClearTextOnInvalid = true;
                                msk.TargetControlID = txtCalendario.ID;

                                msk.MaskType = generadorControles.DeterminaTipoMascara(m2);
                                msk.InputDirection = MaskedEditInputDirection.LeftToRight;
                                msk.ClearMaskOnLostFocus = true;
                                msk.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();

                                #endregion

                                //SE ASIGNA EL TEXTBOX EN LA PRIMER CELDA
                                calendarCell_1.Controls.Add(txtCalendario);

                                #region IMAGEBUTTON

                                //BOTON CON LA IMAGEN DEL CALENDARIO
                                ImageButton imbCalendario = new ImageButton();
                                imbCalendario.ID = String.Concat("imgButtonCalendarExtender", nombrePropiedad);
                                imbCalendario.ToolTip = "Click para abrir el Calendario ";
                                imbCalendario.ImageUrl = (bool.Parse(control.IndModificar)) ? "~/Library/img/32/iconCalendario.gif" : "~/Library/img/32/iconCalendario_dis.gif";
                                imbCalendario.Enabled = bool.Parse(control.IndModificar);
                                imbCalendario.Visible = bool.Parse(control.IndVisible);
                                imbCalendario.CausesValidation = false;
                                tc2.VerticalAlign = VerticalAlign.Top;

                                #endregion

                                #region CALENDAR EXTENDER
                                //CONTROL CALENDARIO
                                calendarExtender = new CalendarExtender();
                                calendarExtender.ID = String.Concat("calendarExtender", nombrePropiedad);
                                calendarExtender.TargetControlID = txtCalendario.ID;
                                calendarExtender.PopupPosition = CalendarPosition.TopLeft;
                                calendarExtender.PopupButtonID = imbCalendario.ID;
                                calendarExtender.Enabled = bool.Parse(control.IndModificar);
                                calendarExtender.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();
                                #endregion

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

                                #endregion

                                //SE ASIGNA LA IMAGEN DEL CALENDARIO EN LA SEGUNDA CELDA
                                calendarCell_2.Controls.Add(imbCalendario);
                                calendarCell_2.Controls.Add(rfv);

                                //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                                calendarRow.Cells.Add(calendarCell_1);
                                calendarRow.Cells.Add(calendarCell_2);
                                calendarTable.Rows.Add(calendarRow);

                                div.Controls.Add(calendarTable);

                                tc2.Controls.Add(div);
                                //tc2.Controls.Add(calendarTable);

                                break;
                            #endregion
                            //REQUERIMIENTO: 1-24653531
                            #region CUSTOM_SERIE
                            case "CUSTOM_SERIE":
                                //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES DEL CONTROL
                                HtmlTable serieTable = new HtmlTable();
                                HtmlTableRow serieRow = new HtmlTableRow();
                                HtmlTableCell serieCell_1 = new HtmlTableCell();
                                HtmlTableCell serieCell_2 = new HtmlTableCell();
                                serieTable.Style.Add("valign", "middle");

                                #region CONTROL DEFAULT

                                TextBox txtSerie = new TextBox();
                                txtSerie.ID = String.Concat("txtCustom", nombrePropiedad);
                                txtSerie.Text = string.Empty;
                                txtSerie.ToolTip = String.Concat("Texto ", control.DesColumna);
                                txtSerie.Enabled = bool.Parse(control.IndModificar);
                                txtSerie.Visible = bool.Parse(control.IndVisible);
                                txtSerie.CssClass = control.CssTipo;
                                txtSerie.MaxLength = Int32.Parse(control.LongitudMaxima);
                                txtSerie.Width = 380;

                                #region REQUIREDFIELDVALIDATOR

                                if (control.IndRequerido.Equals("True"))
                                {
                                    rfv = new RequiredFieldValidator();
                                    rfv.ID = String.Concat("rfv", nombrePropiedad);
                                    rfv.ControlToValidate = txtSerie.ID;
                                    rfv.ErrorMessage = "Required";
                                    rfv.Display = ValidatorDisplay.Dynamic;
                                    rfv.Text = " * ";
                                    rfv.CssClass = "labelTabError";
                                }
                                #endregion

                                #endregion

                                //SE ASIGNA EL DROPDOWNLIST DEFAULT EN LA PRIMERA CELDA
                                serieCell_1.Controls.Add(txtSerie);

                                #region CONTROL COMPLETO

                                DropDownList ddlSerie = new DropDownList();
                                ddlSerie.ID = String.Concat("ddlCustom", nombrePropiedad);

                                string spTextoSerie = control.MetodoServicioWeb;
                                AssocRowReady = false;


                                if (String.IsNullOrEmpty(spTextoSerie))
                                {
                                    ddlSerie.Items.Add(new ListItem("No hay Datos", "-1"));
                                    //NO HAY ITEMS
                                    bandera = 0;
                                }
                                else
                                {
                                    //EXISTEN ITEMS
                                    bandera = 1;
                                    ddlSerie.Items.Clear();

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

                                    ddlSerie.DataSource = LlenarDropDownList(spTextoSerie, filtro);
                                    ddlSerie.DataTextField = "Texto";
                                    ddlSerie.DataValueField = "Valor";
                                    ddlSerie.DataBind();
                                    if (!string.IsNullOrEmpty(control.IndValorDefecto))
                                    {
                                        if (bool.Parse(control.IndValorDefecto))
                                        {
                                            for (int i = 0; i < ddlSerie.Items.Count; i++)
                                            {
                                                if (ddlSerie.Items[i].Text.Equals(control.IndValorDefecto))
                                                    ddlSerie.SelectedIndex = i;
                                            }
                                        }
                                    }
                                    ddlValorSeleccionado = ddlSerie.SelectedValue.ToString(); //SE ASIGNA EL ELEMENTO SELECCIONADO POR DEFECTO
                                }

                                ddlSerie.ToolTip = String.Concat("Lista de ", control.DesColumna);
                                ddlSerie.Enabled = bool.Parse(control.IndModificar);
                                ddlSerie.Visible = bool.Parse(control.IndVisible);
                                ddlSerie.CssClass = control.CssTipo;
                                ddlSerie.Width = Unit.Parse("380");

                                //EVENTO DE LA LISTA PADRE PARA EL MANEJO DE LISTAS ANIDADAS
                                ddlSerie.AutoPostBack = true;
                                ddlSerie.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);

                                #endregion

                                //SE ASIGNA EL DROPDOWNLIST EN LA SEGUNDA CELDA
                                serieCell_2.Controls.Add(ddlSerie);

                                //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                                serieRow.Cells.Add(serieCell_1);
                                serieRow.Cells.Add(serieCell_2);
                                serieTable.Rows.Add(serieRow);
                                tc2.Controls.Add(serieTable);

                                break;
                            #endregion

                            #region CUSTOM_INSTRUMENTO
                            case "CUSTOM_INSTRUMENTO":
                                //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES DEL CONTROL
                                HtmlTable instrumentoTable = new HtmlTable();
                                HtmlTableRow instrumentoRow = new HtmlTableRow();
                                HtmlTableCell instrumentoCell_1 = new HtmlTableCell();
                                HtmlTableCell instrumentoCell_2 = new HtmlTableCell();
                                instrumentoTable.Style.Add("valign", "middle");

                                #region CONTROL DEFAULT

                                TextBox txtInstrumento = new TextBox();
                                txtInstrumento.ID = String.Concat("txtCustom", nombrePropiedad);
                                txtInstrumento.Text = string.Empty;
                                txtInstrumento.ToolTip = String.Concat("Texto ", control.DesColumna);
                                txtInstrumento.Enabled = bool.Parse(control.IndModificar);
                                txtInstrumento.Visible = bool.Parse(control.IndVisible);
                                txtInstrumento.CssClass = control.CssTipo;
                                txtInstrumento.MaxLength = Int32.Parse(control.LongitudMaxima);
                                txtInstrumento.TextMode = TextBoxMode.MultiLine;
                                txtInstrumento.Height = 50;
                                txtInstrumento.Width = 375;

                                #region REQUIREDFIELDVALIDATOR

                                if (control.IndRequerido.Equals("True"))
                                {
                                    rfv = new RequiredFieldValidator();
                                    rfv.ID = String.Concat("rfv", nombrePropiedad);
                                    rfv.ControlToValidate = txtInstrumento.ID;
                                    rfv.ErrorMessage = "Required";
                                    rfv.Display = ValidatorDisplay.Dynamic;
                                    rfv.Text = " * ";
                                    rfv.CssClass = "labelTabError";
                                }
                                #endregion

                                #endregion

                                //SE ASIGNA EL DROPDOWNLIST DEFAULT EN LA PRIMERA CELDA
                                instrumentoCell_1.Controls.Add(txtInstrumento);

                                #region CONTROL COMPLETO

                                DropDownList ddlInstrumento = new DropDownList();
                                ddlInstrumento.ID = String.Concat("ddlCustom", nombrePropiedad);

                                string spTextoInstrumento = control.MetodoServicioWeb;
                                AssocRowReady = false;


                                if (String.IsNullOrEmpty(spTextoInstrumento))
                                {
                                    ddlInstrumento.Items.Add(new ListItem("No hay Datos", "-1"));
                                    //NO HAY ITEMS
                                    bandera = 0;
                                }
                                else
                                {
                                    //EXISTEN ITEMS
                                    bandera = 1;
                                    ddlInstrumento.Items.Clear();

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

                                    ddlInstrumento.DataSource = LlenarDropDownList(spTextoInstrumento, filtro);
                                    ddlInstrumento.DataTextField = "Texto";
                                    ddlInstrumento.DataValueField = "Valor";
                                    ddlInstrumento.DataBind();
                                    if (!string.IsNullOrEmpty(control.IndValorDefecto))
                                    {
                                        if (bool.Parse(control.IndValorDefecto))
                                        {
                                            for (int i = 0; i < ddlInstrumento.Items.Count; i++)
                                            {
                                                if (ddlInstrumento.Items[i].Text.Equals(control.IndValorDefecto))
                                                    ddlInstrumento.SelectedIndex = i;
                                            }
                                        }
                                    }
                                    ddlValorSeleccionado = ddlInstrumento.SelectedValue.ToString(); //SE ASIGNA EL ELEMENTO SELECCIONADO POR DEFECTO
                                }

                                ddlInstrumento.ToolTip = String.Concat("Lista de ", control.DesColumna);
                                ddlInstrumento.Enabled = true;
                                ddlInstrumento.Visible = false;
                                ddlInstrumento.CssClass = control.CssTipo;
                                ddlInstrumento.Width = Unit.Parse("380");

                                //EVENTO DE LA LISTA PADRE PARA EL MANEJO DE LISTAS ANIDADAS
                                ddlInstrumento.AutoPostBack = true;
                                ddlInstrumento.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);

                                #endregion

                                //SE ASIGNA EL DROPDOWNLIST EN LA SEGUNDA CELDA
                                instrumentoCell_2.Controls.Add(ddlInstrumento);

                                //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                                instrumentoRow.Cells.Add(instrumentoCell_1);
                                instrumentoRow.Cells.Add(instrumentoCell_2);
                                instrumentoTable.Rows.Add(instrumentoRow);
                                tc2.Controls.Add(instrumentoTable);

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

                                #region ISIN DEFAULT

                                DropDownList ddlISIN = new DropDownList();
                                ddlISIN.ID = String.Concat(nombrePropiedad, "1");
                                string spTextISIN = "DefaultLista";

                                if (spTextISIN.Equals("DefaultLista"))
                                {
                                    ddlISIN.Items.Clear();
                                    ddlISIN.Items.Insert(0, new ListItem("SI", "true"));
                                    ddlISIN.Items.Insert(1, new ListItem("NO", "false"));
                                }

                                ddlISIN.ToolTip = String.Concat("Lista de ", control.DesColumna);
                                ddlISIN.Enabled = bool.Parse(control.IndModificar);
                                ddlISIN.Visible = bool.Parse(control.IndVisible);
                                ddlISIN.CssClass = control.CssTipo;
                                ddlISIN.Width = Unit.Parse("40");

                                #endregion

                                //SE ASIGNA EL DROPDOWNLIST DEFAULT EN LA SEGUNDA CELDA
                                validatorCell_1.Controls.Add(ddlISIN);
                                validatorCell_1.Width = "45px";

                                #region ISIN COMPLETO

                                DropDownList ddlISIN_1 = new DropDownList();
                                ddlISIN_1.ID = nombrePropiedad;
                                string spTextoISIN_1 = control.MetodoServicioWeb;
                                AssocRowReady = false;

                                if (String.IsNullOrEmpty(spTextoISIN_1))
                                {
                                    ddlISIN_1.Items.Add(new ListItem("No hay Datos", "-1"));
                                    //NO HAY ITEMS
                                    bandera = 0;
                                }
                                else
                                {
                                    //EXISTEN ITEMS
                                    bandera = 1;
                                    LimpiarDropDownList(ddlISIN_1);
                                    //dropDownISIN_1.Items.Clear();

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

                                    ddlISIN_1.DataSource = LlenarDropDownList(spTextoISIN_1, filtro);
                                    ddlISIN_1.DataTextField = "Texto";
                                    ddlISIN_1.DataValueField = "Valor";
                                    ddlISIN_1.DataBind();
                                    if (!string.IsNullOrEmpty(control.IndValorDefecto))
                                    {
                                        if (bool.Parse(control.IndValorDefecto))
                                        {
                                            for (int i = 0; i < ddlISIN_1.Items.Count; i++)
                                            {
                                                if (ddlISIN_1.Items[i].Text.Equals(control.IndValorDefecto))
                                                    ddlISIN_1.SelectedIndex = i;
                                            }
                                        }
                                    }
                                    ddlValorSeleccionado = ddlISIN_1.SelectedValue.ToString(); //SE ASIGNA EL ELEMENTO SELECCIONADO POR DEFECTO
                                }

                                ddlISIN_1.ToolTip = String.Concat("Lista de ", control.DesColumna);
                                ddlISIN_1.Enabled = !bool.Parse(control.IndModificar);
                                ddlISIN_1.Visible = bool.Parse(control.IndVisible);
                                ddlISIN_1.CssClass = control.CssTipo;
                                ddlISIN_1.Width = Unit.Parse("100%");

                                //EVENTO DE LA LISTA PADRE PARA EL MANEJO DE LISTAS ANIDADAS
                                ddlISIN_1.AutoPostBack = true;
                                ddlISIN_1.SelectedIndexChanged += new EventHandler(dropDownList_SelectedIndexChanged);

                                #endregion

                                //SE ASIGNA EL DROPDOWNLIST EN LA SEGUNDA CELDA
                                validatorCell_2.Controls.Add(ddlISIN_1);
                                validatorCell_2.Width = "200px";

                                //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                                validatorRow.Cells.Add(validatorCell_1);
                                validatorRow.Cells.Add(validatorCell_2);
                                validatorTable.Rows.Add(validatorRow);
                                tc2.Controls.Add(validatorTable);

                                break;
                            #endregion
                            //REQUERIMIENTO: 1-24653531
                            #region CUSTOM_BUSQUEDA
                            case "CUSTOM_BUSQUEDA":
                                //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES DEL CONTROL
                                HtmlTable busquedaTable = new HtmlTable();
                                HtmlTableRow busquedaRow = new HtmlTableRow();
                                HtmlTableCell busquedaCell_1 = new HtmlTableCell();
                                HtmlTableCell busquedaCell_2 = new HtmlTableCell();
                                HtmlTableCell busquedaCell_3 = new HtmlTableCell();
                                busquedaTable.Style.Add("valign", "middle");

                                #region BUSQUEDA CHECK

                                CheckBox chkBusqueda = new CheckBox();
                                chkBusqueda.ID = String.Concat("chkCustom", nombrePropiedad);
                                chkBusqueda.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                                chkBusqueda.Enabled = bool.Parse(control.IndModificar);
                                chkBusqueda.Visible = bool.Parse(control.IndVisible);
                                chkBusqueda.CssClass = control.CssTipo;

                                chkBusqueda.AutoPostBack = true;
                                chkBusqueda.CheckedChanged += new EventHandler(chkCustomBusqueda_CheckedChanged);

                                #endregion

                                //SE ASIGNA EL DROPDOWNLIST DEFAULT EN LA PRIMERA CELDA
                                busquedaCell_1.Controls.Add(chkBusqueda);
                                busquedaCell_1.Width = "20px";

                                #region BUSQUEDA TEXTBOX

                                TextBox txtBusqueda = new TextBox();
                                txtBusqueda.ID = String.Concat("txtCustom", nombrePropiedad);
                                txtBusqueda.Text = string.Empty;
                                txtBusqueda.Text.ToUpper();
                                txtBusqueda.Visible = bool.Parse(control.IndVisible);
                                txtBusqueda.CssClass = control.CssTipo;
                                txtBusqueda.MaxLength = Int32.Parse(control.LongitudMaxima);
                                txtBusqueda.CausesValidation = false;
                                txtBusqueda.Width = Unit.Pixel(300);
                                txtBusqueda.ToolTip = String.Concat("Texto ", control.DesColumna);
                                //busquedaTexto.Style.Add("text-transform", "uppercase");

                                if (!String.IsNullOrEmpty(control.GrupoValidacion))
                                {
                                    txtBusqueda.ValidationGroup = control.GrupoValidacion;
                                }

                                if (chkBusqueda.Checked)
                                    txtBusqueda.Enabled = bool.Parse(control.IndModificar);
                                else
                                    txtBusqueda.Enabled = !bool.Parse(control.IndModificar);

                                #endregion

                                //SE ASIGNA EL DROPDOWNLIST EN LA SEGUNDA CELDA
                                busquedaCell_2.Controls.Add(txtBusqueda);

                                #region REQUIRED FIELD VALIDATOR

                                if (control.IndRequerido.Equals("True"))
                                {
                                    rfv = new RequiredFieldValidator();
                                    rfv.ID = String.Concat("rfv", nombrePropiedad);
                                    rfv.ControlToValidate = txtBusqueda.ID;
                                    rfv.ErrorMessage = "Required";
                                    rfv.Display = ValidatorDisplay.Dynamic;
                                    rfv.Text = " * ";
                                    rfv.CssClass = "labelTabError";
                                }

                                #endregion

                                #region SEARCH IMAGE

                                //BOTON CON LA IMAGEN DEL CONTROL
                                Button btnBusqueda = new Button();
                                btnBusqueda.ID = String.Concat("imgCustom", nombrePropiedad);
                                btnBusqueda.CssClass = "imgCmdBuscarGarantiaDisabled";
                                btnBusqueda.Visible = bool.Parse(control.IndVisible);
                                btnBusqueda.CausesValidation = false;
                                btnBusqueda.ToolTip = "Click para ejecutar la búsqueda.";
                                btnBusqueda.Click += new EventHandler(btnBusqueda_Click);

                                tc2.VerticalAlign = VerticalAlign.Top;

                                if (chkBusqueda.Checked)
                                    btnBusqueda.Enabled = bool.Parse(control.IndModificar);
                                else
                                    btnBusqueda.Enabled = !bool.Parse(control.IndModificar);

                                #endregion

                                //SE ASIGNA LA IMAGEN EN LA SEGUNDA CELDA
                                busquedaCell_3.Controls.Add(btnBusqueda);
                                busquedaCell_3.Controls.Add(rfv);

                                //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                                busquedaRow.Cells.Add(busquedaCell_1);
                                busquedaRow.Cells.Add(busquedaCell_2);
                                busquedaRow.Cells.Add(busquedaCell_3);
                                busquedaTable.Rows.Add(busquedaRow);
                                tc2.Controls.Add(busquedaTable);

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
                                divSub.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                                divSub.ID = String.Concat("ctl00_ContentPlaceHolder1_", control.Tab);

                                Label labelSubtitulo = new Label();
                                labelSubtitulo.ID = nombrePropiedad;
                                labelSubtitulo.Text = control.DesColumna;
                                labelSubtitulo.ToolTip = String.Concat("Etiqueta ", control.DesColumna);
                                labelSubtitulo.Enabled = bool.Parse(control.IndModificar);
                                labelSubtitulo.Visible = bool.Parse(control.IndVisible);
                                labelSubtitulo.CssClass = control.CssTipo;
                                //labelSubtitulo.ClientIDMode = ClientIDMode.Static;

                                divSub.Controls.Add(labelSubtitulo);
                                tc4.Controls.Add(divSub);

                                // AGREGA LA CELDA4 A LA FILA
                                tableRow.Cells.Add(tc4);

                                break;

                            #endregion

                            #region GRIDVIEW

                            case "GRIDVIEW":

                                Panel pn = new Panel();
                                pn.ID = string.Concat("panel", nombrePropiedad);
                                pn.Height = Unit.Parse("150");
                                pn.ScrollBars = ScrollBars.Auto;

                                TableCell tc5 = new TableCell();
                                tc5.ID = String.Concat("tcGrid", filasContador, "Cell", 0);
                                tc5.Width = Unit.Parse("220");
                                tc5.ColumnSpan = 2;
                                tc5.VerticalAlign = VerticalAlign.Top;

                                grid = ((wucGridControl)LoadControl("~/Library/controls/wucGridControl.ascx"));
                                grid.ID = string.Concat("grid", nombrePropiedad);
                                grid.Visible = bool.Parse(control.IndVisible);

                                grid.GridView_Init(control.NombreColumna, control.DesColumna);
                                grid.BindGridView(GridDataTable(control.MetodoServicioWeb));

                                pn.Controls.Add(grid);
                                tc5.Controls.Add(pn);

                                // AGREGA LA CELDA5 A LA FILA
                                tableRow.Cells.Add(tc5);

                                btnAgregarGravamen = (Button)grid.FindControl("imgCmdAgregar");
                                btnAgregarGravamen.Click += new EventHandler(btnAgregarGravamen_Click);
                                btnAgregarGravamen.CausesValidation = false;

                                btnEliminarGravamen = (Button)grid.FindControl("imgCmdEliminar");
                                btnEliminarGravamen.Click += new EventHandler(btnEliminarGravamen_Click);
                                btnEliminarGravamen.CausesValidation = false;

                                btnModificarGravamen = (Button)grid.FindControl("imgCmdModificar");
                                btnModificarGravamen.Click += new EventHandler(btnModificarGravamen_Click);
                                btnModificarGravamen.CausesValidation = false;
                                btnModificarGravamen.Visible = true;

                                break;

                            #endregion
                        }

                        #endregion

                        if (!tipoContenido.Equals("AREA") && !tipoContenido.Equals("GRIDVIEW"))
                        {
                            // AGREGA LA CELDA1 AL TABLE ROW
                            tableRow.Cells.Add(tc1);

                            // AGREGA LA CELDA2 A LA FILA
                            tableRow.Cells.Add(tc2);
                        }

                        switch (tipoContenido)
                        {
                            #region TEXTBOX
                            case "TEXTBOX":
                                if (msk != null)
                                {
                                    //AGREGA EL CONTROL A LA LINEA
                                    tc2.Controls.Add(msk);
                                }
                                if (control.IndRequerido.Equals("True"))
                                {
                                    //AGREGA EL CONTROL A LA LINEA
                                    tc2.Controls.Add(rfv);
                                }
                                break;
                            #endregion
                            #region DROPDOWNLIST
                            case "DROPDOWNLIST":
                                Label hdnLabel = new Label();
                                hdnLabel.ID = String.Concat("hiddenLabel", filasContador);
                                hdnLabel.Text = String.Empty;
                                hdnLabel.Enabled = false;
                                hdnLabel.Visible = false;
                                //AGREGA EL CONTROL A LA LINEA
                                tc2.Controls.Add(hdnLabel);
                                break;
                            #endregion
                            #region CALENDAR EXTENDER
                            case "CALENDAREXTENDER":
                                if (calendarExtender != null)
                                {
                                    //AGREGA EL CONTROL A LA LINEA
                                    tc2.Controls.Add(calendarExtender);
                                }
                                break;
                            #endregion
                        }

                        // CELDA PARA EL CONTROL REQUIRED FIELD VALIDATOR
                        TableCell tc3 = new TableCell();

                        tc3.Width = Unit.Parse("150");
                        tc3.HorizontalAlign = HorizontalAlign.Left;
                        tc3.Height = Unit.Parse("15");

                        // AGREGA LA CELDA3 A LA FILA
                        tableRow.Cells.Add(tc3);

                        if (!AssocRowReady)
                        {
                            tblPrincipal.Rows.Add(tableRow);
                        }

                        filasContador++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*VALIDA LA SECCION GENERAL DEL FORMULARIO, SI EL REGISTRO EXISTE, SI ESTÁ INCOMPLETO O COMPLETO*/
    private bool ValidarEntidadValor()
    {
        GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();
        bool existeError = false;

        //VERIFICACION DE LA ASIGNACION
        if (garantiaValorEntidad != null)
        {
            respuesta = wsGarantias.GarantiasValoresValidar((GarantiasValoresEntidad)garantiaValorEntidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

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
                    existeError = true;
                    this.hdnIdGeneral.Value = "-1";
                    //ERROR POR DUPLICADO DEBIDO A QUE LA GARANTIA EXISTE DE FORMA COMPLETA 
                    BarraMensaje(respuesta, pantallaIdOculto.Value);
                }
            }
        }

        return existeError;
    }

    /*VALIDA LOS DATOS DE LA SECCIÓN GENERAL*/
    private bool ValidarSeccionGeneral()
    {
        bool existeError = false;

        object entidad = null;
        string valorControl = string.Empty;

        var regexAlfa = new Regex("^[a-zA-Z0-9]*$");
        var regexLetras = new Regex("^[a-zA-Z]*$");

        bool validarFechas = false;
        int banderaPropiedad = 1;

        // 0 = NO | 1 = SI
        int soloLetras = 0;
        // 0 = NO | 1 = SI
        int caracteresEspeciales = 0;

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
            CheckBox chk = null;

            Type tipoControl = null;
            Object control = null;

            #endregion
            #region PROPIEDADES ENTIDAD

            //OBTIENE LAS PROPIEDADES DE LA ENTIDAD
            PropertyInfo[] propiedades = tipoEntidad.GetProperties();

            string entidadPropiedad = string.Empty;
            string entidadPropiedadTipo = string.Empty;

            foreach (PropertyInfo propiedad in propiedades)
            {
                control = null;

                entidadPropiedad = propiedad.Name;
                entidadPropiedadTipo = propiedad.PropertyType.FullName;

                switch (entidadPropiedad)
                {
                    #region CLASIFICACION INSTRUMENTO
                    case "ClasificacionInstrumento":
                        if (!ValorTipoValor().Equals(4))
                        {
                            string Valor = ((TextBox)this.tableData.FindControl("txtCustomClasificacionInstrumento")).Text;
                            DropDownList ddlValor = ((DropDownList)this.tableData.FindControl("ddlCustomClasificacionInstrumento"));

                            generadorControles.SeleccionarOpcionDropDownListTexto(ddlValor, Valor);
                        }

                        //OBTIENE EL VALOR DEL CONTROL DROPDOWNLIST DE CLASIFICACION INSTRUMENTO
                        control = this.tableData.FindControl("ddlCustomClasificacionInstrumento");
                        break;
                    #endregion
                    #region SERIE
                    case "Serie":
                        switch (ValorTipoValor())
                        {
                            case 1:
                                if (!ObtenerCheckBoxBusqueda())
                                {
                                    control = this.tableData.FindControl("ddlCustomSerie");
                                }
                                else
                                {
                                    control = this.tableData.FindControl("txtCustomSerie");
                                }
                                break;
                            default:
                                control = this.tableData.FindControl("txtCustomSerie");
                                break;
                        }
                        break;
                    #endregion
                    #region BUSQUEDA ISIN
                    case "IndBusquedaISIN":
                        if (entidadPropiedad.Equals("IndBusquedaISIN"))
                        {
                            //OBTIENE EL VALOR DEL CONTROL DROPDOWNLIST DE CLASIFICACION INSTRUMENTO
                            control = this.tableData.FindControl("chkCustomBusqueda");
                        }
                        break;
                    #endregion
                    default:
                        //BUSCA EL CONTROL QUE POSEA EL MISMO NOMBRE QUE LA PROPIEDAD
                        control = this.tableData.FindControl(entidadPropiedad);
                        break;
                }

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
                                if (txt.ID.Contains("CodGarantiaBCR"))
                                {//REQUERIMIENTO: 1-24653531
                                    if (regexLetras.IsMatch(valorControl))
                                    {
                                        soloLetras = 1;
                                    }

                                    if (!regexAlfa.IsMatch(valorControl))
                                    {
                                        caracteresEspeciales = 1;
                                    }
                                }
                                if (txt.ID.Contains("MontoValorFacial") || txt.ID.Contains("MontoValorMercado"))
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
                                if (!regexAlfa.IsMatch(valorControl))
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
                            #region CHECKBOX
                            case "CHECKBOX":
                                chk = (CheckBox)control;
                                valorControl = chk.Checked.ToString();
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

                //REQUERIMIENTO: 1-24381561
                CrearControlRegistros(entidad, propiedad);
            }

            #endregion

            #region DIRECCIONAMIENTO SEGUN EL TIPO DE ACCION
            //REQUERIMIENTO: 1-24653531

            #region VALIDAR FECHAS

            string vencimiento = ((GarantiasValoresEntidad)entidad).FechaVencimiento.ToString();
            string constitucion = ((GarantiasValoresEntidad)entidad).FechaConstitucionGarantia.ToString();
            string valorMercado = ((GarantiasValoresEntidad)entidad).FechaValorMercado.ToString();

            validarFechas = ValidarFechasIncongruentes(constitucion, vencimiento, valorMercado);

            #endregion

            // EXISTEN CARACTERES ESPECIALES
            if (caracteresEspeciales == 1 && soloLetras == 1 )
            {
                //REQUERIMIENTO: 1-24653531
                if (caracteresEspeciales.Equals(1) && soloLetras.Equals(0))
                    BarraMensaje(null, "SYS_2");

                if (caracteresEspeciales.Equals(0) && soloLetras.Equals(1))
                    BarraMensaje(null, "SYS_32");
                
                existeError = true;
            }

            if (!validarFechas)
            {
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_33");
                this.mpeInformarBox.Show();

                existeError = true;
            }

            #endregion
        }

        //ASIGNACION DEL ID
        if (this.hdnIdGeneral.Value.Length < 1)
            ((GarantiasValoresEntidad)entidad).IdGarantiaValor = 0;
        else
            ((GarantiasValoresEntidad)entidad).IdGarantiaValor = int.Parse(this.hdnIdGeneral.Value);


        garantiaValorEntidad = entidad;

        return existeError;
    }

    /*VALIDA QUE AL MENOS EXISTA UN REGISTRO EN A SECCION DE ADMINISTRAR GRAVAMENES*/
    private bool ValidarSeccionGravamenes()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        wucGridControl grdGravamenes = (wucGridControl)this.tableData.FindControl("gridGravamenes");
        Label lblGravamenes = (Label)this.tableData.FindControl("ctl33");
        DropDownList ddlIndGravamen = (DropDownList)this.tableData.FindControl("IndGravamen");

        if (ddlIndGravamen != null)
        {
            if (grdGravamenes != null)
            {
                if (ddlIndGravamen.SelectedItem.Text.Equals("SI"))
                {
                    if (grdGravamenes.ContadorElementos().Equals(0))
                    {
                        existeError = true;

                        if (lblGravamenes != null)
                        {
                            //MENSAJE DE ERROR DE REQUERIDO
                            valorReemplazo = "la sección " + lblGravamenes.Text;
                            this.InformarBox1_SetConfirmationBoxEvent(null, null, "Requerido");
                            this.mpeInformarBox.Show();
                        }
                    }
                }
            }
        }

        return existeError;
    }

    /*CARGA LOS VALORES DESDE BD PARA EL CASO DE LAS MODIFICACIONES*/
    private void DeEntidadAControles()
    {
        try
        {

            if (pantallaModuloOculto.Value != null && !pantallaIdOculto.Value.Equals("0")) //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            {
                this.hdnIdGeneral.Value = pantallaIdOculto.Value;

                //DESHABILITA LA SECCION GENERAL
                AdministrarControlesExcepcionesGeneral(false);
            }


            DataTable dt = new DataTable();

            #region CONTROLES COMODIN
            TextBox txt = null;
            DropDownList ddl = null;
            CheckBox chk = null;
            #endregion
            #region PROPIEDADES ENTIDAD

            var resultado = ConsultarDetalleEntidad();
            if (resultado != null)
            {
                Type tipoControl = null;
                Object control = null;
                string asignarValor = string.Empty;
                List<KeyValuePair<string, string>> entidadLista = new List<KeyValuePair<string, string>>();

                PropertyInfo[] propiedadesDetalle = resultado.GetType().GetProperties();

                string entidadPropiedad = string.Empty;
                string entidadPropiedadTipo = string.Empty;

                foreach (PropertyInfo propiedad in propiedadesDetalle)
                {
                    control = null;

                    entidadPropiedad = propiedad.Name;
                    entidadPropiedadTipo = propiedad.PropertyType.FullName;

                    asignarValor = string.Empty;
                    control = this.tableData.FindControl(propiedad.Name);

                    switch (entidadPropiedad)
                    {
                        #region CLASIFICACION INSTRUMENTO
                        case "ClasificacionInstrumento":
                            switch (ValorTipoValor())
                            {
                                case 4:
                                    control = this.tableData.FindControl("ddlCustomClasificacionInstrumento");
                                    break;
                                default:
                                    control = this.tableData.FindControl("txtCustomClasificacionInstrumento");
                                    break;
                            }
                            break;
                        #endregion
                        #region SERIE
                        case "Serie":
                            switch (ValorTipoValor())
                            {
                                case 1:
                                    if (ObtenerCheckBoxBusqueda())
                                        control = this.tableData.FindControl("txtCustomSerie");
                                    else
                                        control = this.tableData.FindControl("ddlCustomSerie");
                                    break;
                                default:
                                    control = this.tableData.FindControl("txtCustomSerie");
                                    break;
                            }
                            break;
                        #endregion
                        #region INDICADOR BUSQUEDA ISIN
                        case "IndBusquedaISIN":
                            control = this.tableData.FindControl("chkCustomBusqueda");
                            break;
                        #endregion
                        #region VALOR BUSQUEDA ISIN
                        case "ValorBusqueda":
                            control = this.tableData.FindControl("txtCustomBusqueda");
                            break;
                        #endregion
                    }

                    if (control != null)
                    {
                        tipoControl = control.GetType();
                        switch (control.GetType().Name.ToUpper()) //SEGUN EL TIPO DE CONTROL
                        {
                            #region TEXTBOX
                            case "TEXTBOX":
                            case "MULTILINE":
                                txt = (TextBox)control;
                                if (propiedad.GetValue(resultado, null) == null)
                                    asignarValor = string.Empty;
                                else
                                    //SI ES UN VALOR DECIMAL SE DEBE DE MANTENER EL FORMATO
                                    if (propiedad.GetValue(resultado, null).GetType().Name.ToUpper().Equals("DECIMAL"))
                                        asignarValor = String.Format("{0:0.00}", propiedad.GetValue(resultado, null));
                                    else
                                        asignarValor = propiedad.GetValue(resultado, null).ToString();
                                txt.Text = asignarValor; // ASIGNACION DEL TEXTO DESDE LA BD
                                txt.Enabled = ModificarTextBoxExcepciones(propiedad.Name);
                                break;
                            #endregion
                            #region DROPDOWNLIST
                            case "DROPDOWNLIST":
                                ddl = (DropDownList)control;
                                if (propiedad.GetValue(resultado, null) == null)
                                    asignarValor = "-1";
                                else
                                    if (string.IsNullOrEmpty(propiedad.GetValue(resultado, null).ToString()))
                                        asignarValor = "-1";
                                    else
                                        asignarValor = propiedad.GetValue(resultado, null).ToString();

                                if (propiedad.Name.Equals("ClasificacionInstrumento"))
                                {
                                    generadorControles.SeleccionarOpcionDropDownListTexto(ddl, asignarValor); // ASIGNACION DEL VALOR DESDE LA BD
                                }
                                else
                                {
                                    generadorControles.SeleccionarOpcionDropDownList(ddl, asignarValor); // ASIGNACION DEL VALOR DESDE LA BD
                                }

                                ddl.Enabled = ModificarDropDownExcepciones(propiedad.Name);
                                break;
                            #endregion
                            #region CHECKBOX
                            case "CHECKBOX":
                                chk = (CheckBox)control;
                                if (propiedad.GetValue(resultado, null) == null)
                                    asignarValor = string.Empty;
                                else
                                    asignarValor = propiedad.GetValue(resultado, null).ToString();
                                break;
                            #endregion
                        }

                        entidadLista.Add(new KeyValuePair<string, string>(propiedad.Name, asignarValor));
                    }
                    //REQUERIMIENTO: 1-24381561
                    else
                    {
                        ObtenerControlRegistros(resultado, propiedad);
                    }
                }
                //REALIZA LAS EXCEPCIONES DE LA CARGA DE DATOS A LOS CONTROLES
                DeEntidadAControlesExcepciones(entidadLista);
            }

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*CARGA LOS VALORES DESDE LOS CONTROLES HACIA LA ENTIDAD PARA REALIZAR ACCIONES*/
    private void DeControlesAEntidad(int tipoAccion)
    {
        try
        {
            // NO EXISTEN ERRORES
            if (!ValidarSeccionGeneral())
            {
                if (!ValidarSeccionGravamenes())
                {
                    //switch (tipoAccion)
                    //{
                    //    case 0:
                    //        InsertarEntidad(pantallaNombreOculto.Value, wsGarantias, garantiaValorEntidad);
                    //        break;
                    //    case 1:
                    ModificarEntidad(pantallaNombreOculto.Value, wsGarantias, garantiaValorEntidad);
                    //        break;
                    //    case 2:
                    //        EliminarEntidad(pantallaNombreOculto.Value, wsGarantias, garantiaValorEntidad);
                    //        break;
                    //}

                    //Bloque 7 Requerimiento 1-24381561
                    MostrarControlRegistrosGuardar();
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EXTRAE LOS CONTROLES DESDE BD PARA LA SECCION DE GRAVAMENES*/
    private void ControlesGravamenes()
    {
        try
        {
            DropDownList ddlIndGravamen = (DropDownList)this.tableData.FindControl("IndGravamen");

            if (ddlIndGravamen != null)
            {
                ControlEntidad controlSeleccionado = ControlesBuscar(ddlIndGravamen.ID);

                AdministrarBlanco("IndGravamen", false);
                generadorControles.SeleccionarOpcionDropDownListTexto(ddlIndGravamen, controlSeleccionado.ValorDefecto);

                GridViewGravamenesInternoActualizar();

                EfectoDdlIndGravamen();

                //EJECUTA LAS FUNCIONES DE IND GRAVAMEN
                DdlIndGravamen();
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
            nombreControl = nombreControl.Replace("txt", "").Replace("ddl", "").Replace("imb", "").Replace("lbl", "").Replace("btn", "").Replace("chk", "");
            ControlEntidad controlRetorno = (from control in CargaArregloControles()
                                             where control.NombrePropiedad.Equals(nombreControl)
                                             select control).First();

            return controlRetorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region EVENTOS DE CONTROLES

    #region METODOS PARA LA CARGA DE DROPDOWNLIST

    private void CargarTipoInstrumento()
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlTipoInstrumento = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));
            DropDownList ddlTipoValor = (DropDownList)(this.tableData.FindControl("IdTipoValor"));

            #endregion

            LimpiarDropDownList(ddlTipoInstrumento);
            if (ddlTipoInstrumento != null)
            {
                ddlTipoInstrumento.Items.Clear();
                ddlTipoInstrumento.DataSource = LlenarDropDownList("InstrumentosTipoInstrumentoLista", string.Empty);
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
                if (ddlISIN1.SelectedValue.Equals("NO") || ddlISIN1.SelectedValue.Equals(" ") || ddlISIN1.SelectedValue.Length.Equals(0))
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
                    CargarSerieDropBox(ddlInstrumento, ddlEmisor, ddlISIN);
                    CargarIdgarantia(ddlISIN1, ddlISIN);
                    break;
                case 4:
                    CargarIdgarantia();
                    CargarIdentificacionInstrumento(ddlInstrumento);
                    break;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

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

    private void CargarEmpresaCalificadora(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlEmpresaCalificadora = (DropDownList)(this.tableData.FindControl("IdEmpresaCalificadora"));

            #endregion

            LimpiarDropDownList(ddlEmpresaCalificadora);
            if (ddlEmpresaCalificadora != null)
            {
                ddlEmpresaCalificadora.Items.Clear();
                ddlEmpresaCalificadora.DataSource = LlenarDropDownList("EmpresasCalificadorasLista", ((DropDownList)(sender)).SelectedValue);
                ddlEmpresaCalificadora.DataTextField = "Texto";
                ddlEmpresaCalificadora.DataValueField = "Valor";
                ddlEmpresaCalificadora.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarCategoriaRiesgoEmpresaCalificadora(DropDownList ddlCategoriaRiesgoEmpresaCalificadora)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlEmpresaCalificadora = (DropDownList)(this.tableData.FindControl("IdEmpresaCalificadora"));

            #endregion

            #region CONTRUIR FILTROS

            StringBuilder filtro = new StringBuilder();
            filtro.Append(ddlEmpresaCalificadora.SelectedValue.ToString());

            #endregion

            LimpiarDropDownList(ddlCategoriaRiesgoEmpresaCalificadora);
            if (ddlCategoriaRiesgoEmpresaCalificadora != null)
            {
                ddlCategoriaRiesgoEmpresaCalificadora.Items.Clear();
                ddlCategoriaRiesgoEmpresaCalificadora.DataSource = LlenarDropDownList("CalificacionesEmpresasCalificadorasCategoriaRiesgoLista", filtro.ToString());
                ddlCategoriaRiesgoEmpresaCalificadora.DataTextField = "Texto";
                ddlCategoriaRiesgoEmpresaCalificadora.DataValueField = "Valor";
                ddlCategoriaRiesgoEmpresaCalificadora.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarCalificacionEmpresaCalificadora(DropDownList ddlEmpresaCalificadora, DropDownList ddlCategoriaRiesgoEmpresaCalificadora)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlCalificacionEmpresaCalificadora = (DropDownList)(this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            #endregion

            #region CONTRUIR FILTROS

            StringBuilder filtro = new StringBuilder();
            filtro.Append(ddlEmpresaCalificadora.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlCategoriaRiesgoEmpresaCalificadora.SelectedValue.ToString());

            #endregion

            LimpiarDropDownList(ddlCalificacionEmpresaCalificadora);
            if (ddlCalificacionEmpresaCalificadora != null)
            {
                ddlCategoriaRiesgoEmpresaCalificadora.Items.Clear();
                ddlCalificacionEmpresaCalificadora.DataSource = LlenarDropDownList("CalificacionesEmpresasCalificadorasCalificacionLista", filtro.ToString());
                ddlCalificacionEmpresaCalificadora.DataTextField = "Texto";
                ddlCalificacionEmpresaCalificadora.DataValueField = "Valor";
                ddlCalificacionEmpresaCalificadora.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarSerieDropBox(DropDownList ddlInstrumento, DropDownList ddlEmisor, DropDownList ddlISIN)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("ddlCustomSerie"));

            #endregion

            #region CONSTRUIR FILTROS

            StringBuilder filtro = new StringBuilder();
            filtro.Append(ddlInstrumento.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlEmisor.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlISIN.SelectedValue.ToString());

            #endregion

            LimpiarDropDownList(ddlSerie);
            if (ddlSerie != null)
            {
                ddlSerie.Items.Clear();
                ddlSerie.DataSource = null;
                ddlSerie.SelectedValue = null;
                ddlSerie.DataSource = LlenarDropDownList("EmisionesInstrumentosSerieLista", filtro.ToString());
                ddlSerie.DataTextField = "Texto";
                ddlSerie.DataValueField = "Valor";
                ddlSerie.DataBind();
            }

            switch (ValorTipoValor())
            {
                case 1:
                    CargarClasificacionPremio(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie);
                    break;
                case 4:
                    CargarIdentificacionInstrumento(ddlInstrumento);
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarSerieTextBox(DropDownList ddlInstrumento, DropDownList ddlEmisor, DropDownList ddlISIN)
    {
        try
        {
            #region BUSCAR COMPONENTES

            TextBox txtSerie = (TextBox)(this.tableData.FindControl("txtCustomSerie"));

            #endregion

            #region CONSTRUIR FILTROS

            StringBuilder filtro = new StringBuilder();
            filtro.Append(ddlInstrumento.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlEmisor.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlISIN.SelectedValue.ToString());

            #endregion

            txtSerie.Text = string.Empty;
            if (txtSerie != null)
            {
                List<ListasWS.ListaEntidad> lista = new List<ListasWS.ListaEntidad>();
                lista = wsListas.EmisionesInstrumentosSerieLista(filtro.ToString()).ToList();
                foreach (ListasWS.ListaEntidad elemento in lista)
                {
                    txtSerie.Text = elemento.Texto;
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarClasificacion(DropDownList ddlInstrum, DropDownList ddlEmisor, DropDownList ddlISIN, DropDownList ddlSerie)
    {
        try
        {
            #region BUSCAR COMPONENTES

            TextBox txtPremio = (TextBox)(this.tableData.FindControl("Premio"));
            TextBox txtClasifInstrum = (TextBox)(this.tableData.FindControl("txtCustomClasificacionInstrumento"));

            #endregion

            #region CONSTRUIR FILTROS

            String serie = (string.IsNullOrEmpty(ddlSerie.SelectedValue) ? null : ddlSerie.SelectedValue.ToString());

            StringBuilder filtro = new StringBuilder();
            filtro.Append(ddlInstrum.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlEmisor.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlISIN.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(serie);

            #endregion

            #region CARGAR INFO PREMIO / CLASIFICACION

            txtPremio.Enabled = false;
            if ((txtClasifInstrum != null) || (txtPremio != null))
            {
                List<ListasWS.ListaEntidad> lista = new List<ListasWS.ListaEntidad>();
                lista = wsListas.EmisionesInstrumentosTipoClasificacionPremioLista(filtro.ToString()).ToList();
                foreach (ListasWS.ListaEntidad elemento in lista)
                {
                    txtClasifInstrum.Text = elemento.Valor;
                    txtPremio.Text = elemento.Texto;
                }
            }

            #endregion

            #region CARGAR INFO FECHA VENCIMIENTO

            CargarFechaVencimiento(ddlInstrum, ddlEmisor, ddlISIN, ddlSerie, txtPremio.Text);

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarClasificacionPremio(DropDownList ddlInstrumento, DropDownList ddlEmisor, DropDownList ddlISIN, DropDownList ddlSerie)
    {
        try
        {
            #region BUSCAR COMPONENTES

            TextBox txtPremio = (TextBox)(this.tableData.FindControl("Premio"));
            TextBox txtIdentificacionEmisor = (TextBox)(this.tableData.FindControl("IdentificacionEmisor"));
            TextBox txtIdentificacionInstrumento = (TextBox)(this.tableData.FindControl("IdentificacionInstrumento"));

            TextBox txtClasifInstrum = (TextBox)(this.tableData.FindControl("txtCustomClasificacionInstrumento"));
            DropDownList ddlClasifInstrum = (DropDownList)(this.tableData.FindControl("ddlCustomClasificacionInstrumento"));
            DropDownList ddlTipoInstrumento = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));

            #endregion

            #region CONSTRUIR FILTROS

            String serie = (string.IsNullOrEmpty(ddlSerie.SelectedValue) ? null : ddlSerie.SelectedValue.ToString());

            StringBuilder filtro = new StringBuilder();
            filtro.Append(ddlInstrumento.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlEmisor.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlISIN.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(serie);

            #endregion

            #region CARGAR INFO PREMIO / CLASIFICACION

            txtPremio.Enabled = false;
            if ((txtClasifInstrum != null) || (txtPremio != null))
            {
                List<ListasWS.ListaEntidad> lista = new List<ListasWS.ListaEntidad>();
                lista = wsListas.EmisionesInstrumentosTipoClasificacionPremioLista(filtro.ToString()).ToList();
                foreach (ListasWS.ListaEntidad elemento in lista)
                {
                    txtClasifInstrum.Text = elemento.Valor;
                    txtPremio.Text = elemento.Texto;
                }
            }

            #endregion

            #region CARGAR INFO IDENTIFICACION EMISOR

            CargarDropDownIdentificacionEmisor(ddlEmisor);

            #endregion

            #region INFO IDENTIFICACION INSTRUMENTO

            if ((txtIdentificacionInstrumento != null) && (ddlInstrumento.SelectedItem != null))
            {
                txtIdentificacionInstrumento.Text = generadorControles.BuscaCadenaConSubstring(ddlInstrumento.SelectedItem.ToString().Trim(), " - ");
            }

            #endregion

            #region CARGAR INFO FECHA VENCIMIENTO

            CargarMoneda(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie, ddlTipoInstrumento);
            CargarFechaVencimiento(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie, txtPremio.Text);

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarFechaVencimiento(DropDownList ddlInstrumento, DropDownList ddlEmisor, DropDownList ddlISIN, DropDownList ddlSerie, string txtPremio)
    {
        try
        {
            string isin = string.Empty;
            string premio = string.Empty;

            #region BUSCAR COMPONENTES

            TextBox txtFechaVencimiento = (TextBox)(this.tableData.FindControl("FechaVencimiento"));

            #endregion

            #region CONSTRUIR FILTROS

            String serie = (string.IsNullOrEmpty(ddlSerie.SelectedValue) ? null : ddlSerie.SelectedValue.ToString());

            if (pantallaIdOculto.Value.Equals("0"))
            {
                isin = (string.IsNullOrEmpty(ddlISIN.SelectedValue)) ? null : ddlISIN.SelectedValue.ToString();
                premio = (string.IsNullOrEmpty(txtPremio) ? null : txtPremio);
            }
            else
            {
                AdministrarBlanco("ddlISIN", false);
                isin = (ddlISIN.SelectedValue.Equals("-1")) ? null : ddlISIN.SelectedValue.ToString();
                premio = (string.IsNullOrEmpty(txtPremio) ? null : (decimal.Parse(txtPremio)).ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
            }

            StringBuilder filtro = new StringBuilder();
            filtro.Append(ddlInstrumento.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlEmisor.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(isin);
            filtro.Append('|');
            filtro.Append(serie);
            filtro.Append('|');
            filtro.Append(premio);

            #endregion

            #region CARGAR INFO FECHA VENCIMIENTO

            if (txtPremio != null)
            {
                List<ListasWS.ListaEntidad> lista = new List<ListasWS.ListaEntidad>();
                lista = wsListas.EmisionesInstrumentosFechaVencimientoLista(filtro.ToString()).ToList();
                foreach (ListasWS.ListaEntidad elemento in lista)
                {
                    if (elemento.Texto.Length != 0)
                        txtFechaVencimiento.Text = DateTime.Parse(elemento.Texto, new System.Globalization.CultureInfo("en-US")).ToShortDateString();
                        ////Formato Fecha Local
                        //txtFechaVencimiento.Text = elemento.Texto;
                }
            }

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarMoneda(DropDownList ddlInstrumento, DropDownList ddlEmisor, DropDownList ddlISIN, DropDownList ddlSerie, DropDownList ddlTipoInstrumento)
    {
        try
        {
            string isin = string.Empty;

            #region BUSCAR COMPONENTES

            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));

            #endregion

            #region CONSTRUIR FILTROS

            String serie = (string.IsNullOrEmpty(ddlSerie.SelectedValue) ? null : ddlSerie.SelectedValue.ToString());

            if (pantallaIdOculto.Value.Equals("0"))
            {
                isin = (string.IsNullOrEmpty(ddlISIN.SelectedValue)) ? null : ddlISIN.SelectedValue.ToString();
            }
            else
            {
                AdministrarBlanco("ddlISIN", false);
                isin = (ddlISIN.SelectedValue.Equals("-1")) ? null : ddlISIN.SelectedValue.ToString();
            }

            StringBuilder filtro = new StringBuilder();
            filtro.Append(ddlInstrumento.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(ddlEmisor.SelectedValue.ToString());
            filtro.Append('|');
            filtro.Append(isin);
            filtro.Append('|');
            filtro.Append(serie);
            filtro.Append('|');
            filtro.Append(ddlTipoInstrumento.SelectedValue.ToString());

            #endregion

            #region CARGAR VALOR TIPO MONEDAS

            List<ListasWS.ListaEntidad> _list = new List<ListasWS.ListaEntidad>();
            _list = wsListas.EmisionesInstrumentosMonedaLista(filtro.ToString()).ToList();
            foreach (ListasWS.ListaEntidad ls in _list)
            {
                if (ls.Valor.Length != 0)
                {
                    generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorFacial, ls.Valor);
                    generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, ls.Valor);
                }
            }

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //REQUERIMIENTO: 1-24653531
    private void CargarMoneda(string procedimiento)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));

            #endregion

            #region CARGAR VALOR TIPO MONEDAS

            LimpiarDropDownList(ddlMonedaValorFacial);
            if (ddlMonedaValorFacial != null)
            {
                ddlMonedaValorFacial.Items.Clear();
                ddlMonedaValorFacial.DataSource = LlenarDropDownList(procedimiento, "");
                ddlMonedaValorFacial.DataTextField = "Texto";
                ddlMonedaValorFacial.DataValueField = "Valor";
                ddlMonedaValorFacial.DataBind();
            }

            LimpiarDropDownList(ddlMonedaValorMercado);
            if (ddlMonedaValorMercado != null)
            {
                ddlMonedaValorMercado.Items.Clear();
                ddlMonedaValorMercado.DataSource = LlenarDropDownList(procedimiento, "");
                ddlMonedaValorMercado.DataTextField = "Texto";
                ddlMonedaValorMercado.DataValueField = "Valor";
                ddlMonedaValorMercado.DataBind();
            }

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarIdentificacionInstrumento(DropDownList ddlInstrumento)
    {
        try
        {
            #region BUSCAR COMPONENTES

            TextBox txtIdentificacionInstrumento = ((TextBox)this.tableData.FindControl("IdentificacionInstrumento"));

            #endregion

            txtIdentificacionInstrumento.Text = generadorControles.BuscaCadenaConSubstring(ddlInstrumento.SelectedItem.ToString().Trim(), " - ");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region METODOS PARA DROPDOWNLIST

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

    protected void dropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string idDropDownList = ((DropDownList)(sender)).ID.ToString().ToUpper();

            switch (idDropDownList)
            {
                #region TIPO INSTRUMENTO
                case "IDTIPOINSTRUMENTO":
                    DdlTipoInstrumento(sender);
                    break;
                #endregion

                #region INSTRUMENTO
                case "IDINSTRUMENTO":
                    DdlInstrumento(sender);
                    break;
                #endregion

                #region EMISOR
                case "IDEMISOR":
                    DdlEmisor(sender);
                    break;
                #endregion

                #region ISIN
                case "ISIN":
                    DdlISIN(sender);
                    break;
                #endregion

                #region SERIE
                case "SERIE":
                    DdlSerie(sender);
                    break;
                #endregion

                #region ID TIPO ASIGNACION CALIFICACION
                case "IDTIPOASIGNACIONCALIFICACION":
                    DdlTipoAsignacionCalificacion(sender);
                    break;
                #endregion

                #region DDL CUSTOM CLASIFICACION INSTRUMENTO
                case "DDLCUSTOMCLASIFICACIONINSTRUMENTO":
                    DdlClasificacionInstrumento(sender);
                    break;
                #endregion

                #region ID PLAZO CALIFICACION
                case "IDPLAZOCALIFICACION":
                    DdlPlazoCalificacion(sender);
                    break;
                #endregion

                #region ID EMPRESA CALIFICADORA
                case "IDEMPRESACALIFICADORA":
                    DdlEmpresaCalificadora(sender);
                    break;
                #endregion

                #region ID CATEGORIA RIESGO  (CAT CALIFICACION)
                case "IDCATEGORIARIESGOEMPRESACALIFICADORA":
                    DdlCategoriaCalificacion(sender);
                    break;
                #endregion

                #region TIPOVALOR
                case "IDTIPOVALOR":
                    DdlTipoValor(sender);
                    break;
                #endregion

                #region MONEDAVALORFACIAL
                case "IDMONEDAVALORFACIAL":
                    DdlMonedaValorFacial(sender);
                    break;
                #endregion

                #region IND GRAVAMEN
                case "INDGRAVAMEN":
                    DdlIndGravamen();
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

    private void DdlTipoValor(object sender)
    {
        try
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
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlTipoInstrumento(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlTipoInstrumento = (DropDownList)sender;
            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));
            DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
            DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));
            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("ddlCustomSerie"));

            #endregion

            switch (ValorTipoValor())
            {
                case 1:
                    CargarInstrumento(sender);
                    CargarEmisor(ddlInstrumento);
                    CargarISIN(ddlEmisor, ddlInstrumento);
                    CargarSerieDropBox(ddlInstrumento, ddlEmisor, ddlISIN);
                    CargarIdgarantia(ddlISIN1, ddlISIN);
                    CargarClasificacionPremio(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie);
                    CargarMoneda(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie, ddlTipoInstrumento);
                    break;
                case 4:
                    CargarIdgarantia();
                    #region VALIDAR FECHA VENCIMIENTO

                    string tipoInstrumento = ((DropDownList)this.tableData.FindControl("IdTipoInstrumento")).SelectedItem.Text;
                    if (tipoInstrumento.Contains("ACCIO") || tipoInstrumento.Contains("TPART"))
                        HabilitarFechasFormularioVencimiento(false, true);
                    else
                        HabilitarFechasFormularioVencimiento(true, true);

                    #endregion
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlInstrumento(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlInstrumento = ((DropDownList)sender);
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));
            DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
            DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));
            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("ddlCustomSerie"));
            DropDownList ddlTipoInstrumento = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));

            #endregion

            switch (ValorTipoValor())
            {
                case 1:
                    CargarEmisor(sender);
                    CargarISIN(ddlEmisor, ddlInstrumento);
                    CargarSerieDropBox(ddlInstrumento, ddlEmisor, ddlISIN);
                    CargarIdgarantia(ddlISIN1, ddlISIN);
                    CargarClasificacionPremio(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie);
                    CargarMoneda(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie, ddlTipoInstrumento);
                    break;
                case 4:
                    CargarIdgarantia();
                    CargarIdentificacionInstrumento(ddlInstrumento);
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlEmisor(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlEmisor = ((DropDownList)sender);
            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
            DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));
            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("ddlCustomSerie"));
            DropDownList ddlTipoInstrumento = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));

            #endregion

            switch (ValorTipoValor())
            {
                case 1:
                    CargarISIN(ddlEmisor, ddlInstrumento);
                    CargarSerieDropBox(ddlInstrumento, ddlEmisor, ddlISIN);
                    CargarIdgarantia(ddlISIN1, ddlISIN);
                    CargarClasificacionPremio(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie);
                    CargarMoneda(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie, ddlTipoInstrumento);
                    break;
                case 3:
                    CargarIdgarantia();
                    CargarDropDownIdentificacionEmisor(ddlEmisor);
                    break;
                case 4:
                    CargarIdgarantia();
                    CargarDropDownIdentificacionEmisor(ddlEmisor);
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlISIN(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlISIN = ((DropDownList)sender);
            DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));
            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("ddlCustomSerie"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));
            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlTipoInstrumento = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));

            TextBox txtIdGarantia = (TextBox)(this.tableData.FindControl("CodGarantia"));
            TextBox txtIdGarantiaBCR = ((TextBox)this.tableData.FindControl("CodGarantiaBCR"));

            #endregion

            string valorISIN = ddlISIN.SelectedItem.Text;
            if (!String.IsNullOrEmpty(valorISIN) && !valorISIN.Equals("NO"))
            {
                ddlISIN.Enabled = true;
                AdministrarBlanco("ISIN", false);
                ddlISIN1.SelectedIndex = 0;
                txtIdGarantia.Text = ddlISIN.SelectedValue.ToString();
                generadorControles.SeleccionarOpcionDropDownListTexto(ddlISIN1, "SI");
            }
            else
            {
                ddlISIN.Enabled = false;
                AdministrarBlanco("ISIN", true);
                generadorControles.SeleccionarOpcionDropDownListTexto(ddlISIN1, "NO");
                txtIdGarantia.Text = txtIdGarantiaBCR.Text;
            }

            switch (ValorTipoValor())
            {
                case 1:
                    CargarSerieDropBox(ddlInstrumento, ddlEmisor, ddlISIN);
                    CargarIdgarantia(ddlISIN1, ddlISIN);
                    CargarClasificacionPremio(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie);
                    CargarMoneda(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie, ddlTipoInstrumento);
                    break;
                case 4:
                    CargarIdgarantia();
                    CargarIdentificacionInstrumento(ddlInstrumento);
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlSerie(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("ddlCustomSerie"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));
            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));

            #endregion

            CargarClasificacionPremio(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie);
            CargarMoneda(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie, (DropDownList)sender);
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
            string seleccionado = ((DropDownList)(sender)).SelectedItem.Text.Substring(0, 3);

            #region BUSCAR COMPONENTES

            DropDownList ddlIdPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlIdCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlIdCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            #endregion

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
                if (ddlIdCalificacionEmpresaCalificadora != null)
                {
                    LimpiarDropDownList(ddlIdCalificacionEmpresaCalificadora);
                    AdministrarBlanco("IdCalificacionEmpresaCalificadora", false);
                    ddlIdCalificacionEmpresaCalificadora.Enabled = true;
                }
                if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                {
                    LimpiarDropDownList(ddlIdCategoriaRiesgoEmpresaCalificadora);
                    AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", false);
                    ddlIdCategoriaRiesgoEmpresaCalificadora.Enabled = true;
                }

                DdlPlazoCalificacion(sender);
            }
            else
            {
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
                if (ddlIdCalificacionEmpresaCalificadora != null)
                {
                    LimpiarDropDownList(ddlIdCalificacionEmpresaCalificadora);
                    AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
                    ddlIdCalificacionEmpresaCalificadora.Enabled = false;
                }
                if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                {
                    LimpiarDropDownList(ddlIdCategoriaRiesgoEmpresaCalificadora);
                    AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
                    ddlIdCategoriaRiesgoEmpresaCalificadora.Enabled = false;
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
            #region BUSCAR COMPONENTES

            DropDownList ddlIdPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));

            #endregion

            if (ddlIdPlazoCalificacion != null)
            {
                if (!ddlIdPlazoCalificacion.SelectedValue.Equals("-1"))
                {
                    string _filtro = ddlIdPlazoCalificacion.SelectedValue;

                    if (ddlIdEmpresaCalificadora != null)
                    {
                        LimpiarDropDownList(ddlIdEmpresaCalificadora);
                        ddlIdEmpresaCalificadora.DataSource = LlenarDropDownList("EmpresasCalificadorasLista", _filtro);
                        ddlIdEmpresaCalificadora.DataTextField = "Texto";
                        ddlIdEmpresaCalificadora.DataValueField = "Valor";
                        ddlIdEmpresaCalificadora.DataBind();

                        DdlEmpresaCalificadora(sender);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlEmpresaCalificadora(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlIdCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));

            #endregion

            if (ddlIdEmpresaCalificadora != null)
            {
                if (!ddlIdEmpresaCalificadora.SelectedValue.Equals("-1"))
                {
                    string _filtro = ddlIdEmpresaCalificadora.SelectedValue;

                    if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                    {
                        LimpiarDropDownList(ddlIdCategoriaRiesgoEmpresaCalificadora);
                        ddlIdCategoriaRiesgoEmpresaCalificadora.DataSource = LlenarDropDownList("CalificacionesEmpresasCalificadorasCategoriaRiesgoLista", _filtro);
                        ddlIdCategoriaRiesgoEmpresaCalificadora.DataTextField = "Texto";
                        ddlIdCategoriaRiesgoEmpresaCalificadora.DataValueField = "Valor";
                        ddlIdCategoriaRiesgoEmpresaCalificadora.DataBind();

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
            StringBuilder filtro = new StringBuilder();

            #region BUSCAR COMPONENTES

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
                        filtro.Append(ddlIdEmpresaCalificadora.SelectedValue);
                        filtro.Append("|");
                        filtro.Append(ddlIdCategoriaRiesgoEmpresaCalificadora.SelectedValue);

                        if (ddlIdCalificacionEmpresaCalificadora != null)
                        {
                            LimpiarDropDownList(ddlIdCalificacionEmpresaCalificadora);
                            ddlIdCalificacionEmpresaCalificadora.DataSource = LlenarDropDownList("CalificacionesEmpresasCalificadorasCalificacionLista", filtro.ToString());
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

    private void DdlClasificacionInstrumento(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));

            #endregion

            #region CARGAR INFO IDENTIFICACION EMISOR

            CargarDropDownIdentificacionEmisor(ddlEmisor);

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlMonedaValorFacial(object sender)
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));

            #endregion

            string _Seleccionado = ddlMonedaValorFacial.SelectedValue;
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, _Seleccionado);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EFECTO DEL DLL IND GRAVAMEN - SECCION GRAVAMENES*/
    private void EfectoDdlIndGravamen()
    {
        DropDownList ddlIndGravamen = (DropDownList)this.tableData.FindControl("IndGravamen");

        if (ddlIndGravamen != null)
        {
            this.gridGravamenesInterno = (GridView)this.tableData.FindControl("gridGravamenes").FindControl("MasterGridView");
            if (gridGravamenesInterno != null)
            {
                if (ddlIndGravamen.Enabled)
                {
                    if (gridGravamenesInterno.Rows.Count > 0)
                        generadorControles.SeleccionarOpcionDropDownListTexto(ddlIndGravamen, "SI");
                    else
                        generadorControles.SeleccionarOpcionDropDownListTexto(ddlIndGravamen, "NO");
                }
            }
        }
    }

    private void DdlIndGravamen()
    {
        DropDownList ddlIndGravamen = (DropDownList)this.tableData.FindControl("IndGravamen");
        this.gridGravamenesInterno = (GridView)this.tableData.FindControl("gridGravamenes").FindControl("MasterGridView");

        if (ddlIndGravamen != null)
        {
            if (ddlIndGravamen.SelectedItem.Text.Equals("SI"))
            {
                this.gridGravamenesInterno.Enabled = true;
                this.btnAgregarGravamen.Enabled = true;
                this.btnEliminarGravamen.Enabled = true;
            }
            else
            {
                this.gridGravamenesInterno.Enabled = false;
                this.btnAgregarGravamen.Enabled = false;
                this.btnEliminarGravamen.Enabled = false;

                if (gridGravamenesInterno.Rows.Count > 0)
                {
                    this.mpeConfirmarEliminarGravamenes.Show();
                }
            }
        }
    }

    #endregion

    #region METODOS PARA TEXTBOXES

    private void CargarIdgarantia()
    {
        TextBox txtIdGarantia = ((TextBox)this.tableData.FindControl("CodGarantia"));
        TextBox txtIdGarantiaBCR = ((TextBox)this.tableData.FindControl("CodGarantiaBCR"));
        txtIdGarantia.Style.Add("text-transform", "uppercase");
        //txtIdGarantiaBCR.Style.Add("text-transform", "uppercase");

        txtIdGarantia.Text = txtIdGarantiaBCR.Text;
    }

    private void CargarIdgarantia(DropDownList _ddlISIN1, DropDownList _ddlISIN)
    {
        try
        {
            CheckBox chkCustomBusqueda = (CheckBox)(this.tableData.FindControl("chkCustomBusqueda"));
            TextBox txtIdGarantia = (TextBox)(this.tableData.FindControl("CodGarantia"));
            TextBox txtIdGarantiaBCR = (TextBox)(this.tableData.FindControl("CodGarantiaBCR"));
            TextBox txtSerie = (TextBox)(this.tableData.FindControl("txtCustomSerie"));

            txtIdGarantia.Style.Add("text-transform", "uppercase");
            txtIdGarantiaBCR.Style.Add("text-transform", "uppercase");
            txtSerie.Style.Add("text-transform", "uppercase");

            if ((_ddlISIN != null) && (_ddlISIN1 != null))
            {
                if (!chkCustomBusqueda.Checked)
                {
                    switch (_ddlISIN1.SelectedItem.Text)
                    {
                        case "SI":
                            txtIdGarantia.Text = _ddlISIN.SelectedValue.ToString();
                            break;
                        case "NO":
                            txtIdGarantia.Text = txtIdGarantiaBCR.Text;
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void CodGarantiaBCR_TextChanged(object sender, EventArgs e)
    {
        try
        {

            #region LIMPIAR MENSAJES

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
            {
                this.divBarraMensaje.Visible = false;
            }

            #endregion

            #region BUSCAR COMPONENTES

            DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
            DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));
            ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Text.ToUpper();
            ((TextBox)this.tableData.FindControl("CodGarantia")).Text.ToUpper();

            #endregion

            switch (ValorTipoValor())
            {
                case 1:
                    CargarIdgarantia(ddlISIN1, ddlISIN);
                    break;
                case 2:
                case 3:
                case 4:
                    CargarIdgarantia();
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarDropDownIdentificacionEmisor(DropDownList ddlEmisor)
    {
        string valorEmisor = null;

        #region BUSCAR COMPONENTES

        TextBox txtIdentificacionEmisor = (TextBox)(this.tableData.FindControl("IdentificacionEmisor"));
        DropDownList ddlClasifInstrum = (DropDownList)(this.tableData.FindControl("ddlCustomClasificacionInstrumento"));

        #endregion

        if (ddlClasifInstrum != null)
        {
            if (pantallaIdOculto.Value.Equals("0"))
            {
                txtIdentificacionEmisor.Text = string.Empty;
            }

            switch (ValorTipoValor())
            {
                case 4:
                    txtIdentificacionEmisor.Enabled = true;
                    break;
            }

            valorEmisor = generadorControles.BuscaCadenaConSubstring(ddlClasifInstrum.SelectedItem.ToString(), " - ");
            switch (int.Parse(valorEmisor))
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    if (ddlEmisor != null)
                    {
                        txtIdentificacionEmisor.Text = generadorControles.BuscaCadenaConSubstring(ddlEmisor.SelectedItem.ToString().Trim(), " - ");
                    }
                    break;
                case 5:
                case 7:
                    txtIdentificacionEmisor.MaxLength = 10;
                    break;
                case 6:
                    txtIdentificacionEmisor.Text = string.Empty;
                    txtIdentificacionEmisor.Enabled = false;
                    break;
            }
        }
    }

    #endregion

    #region METODOS PARA CHECKBOXES

    protected void chkCustomBusqueda_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)sender).Checked)
        {
            AsignarEstadoControlBusqueda(true);
            if (ValorTipoValor().Equals(1))
                InsertarExcepcionBusquedaConISIN(false);
        }
        else
        {
            AsignarEstadoControlBusqueda(false);
            if (ValorTipoValor().Equals(1))
                InsertarExcepcionBusquedaSinISIN(true);
        }
    }

    #endregion

    #region METODOS PARA GRIDVIEW CONTROL

    private void SetDataKeys(GridView _gridView, String[] _dataKeysString)
    {
        _gridView.DataKeyNames = _dataKeysString;
    }

    private Object GridDataTable(string metodoWS)
    {
        try
        {
            GarantiasGravemenesEntidad entidadGravamen = new GarantiasGravemenesEntidad();
            int idGarantiaValor = 0;

            if (int.Parse(this.pantallaIdOculto.Value).Equals(0) && this.hdnIdGeneral.Value.Equals(""))
                idGarantiaValor = 0;

            if (int.Parse(this.pantallaIdOculto.Value).Equals(0) && !this.hdnIdGeneral.Value.Equals(""))
                idGarantiaValor = int.Parse(this.hdnIdGeneral.Value);

            if (!int.Parse(this.pantallaIdOculto.Value).Equals(0))
                idGarantiaValor = int.Parse(this.pantallaIdOculto.Value);

            entidadGravamen.IdGarantiaValor = idGarantiaValor;
            entidadGravamen.IdGarantiaReal = 0;

            return LlenarDataTable(metodoWS, pantallaIdOculto.Value, entidadGravamen);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private Object LlenarDataTable(string wsMethodName, string filtro, GarantiasGravemenesEntidad gravamenes)
    {
        try
        {
            Type ws = wsGarantias.GetType();
            MethodInfo metodo = ws.GetMethod(wsMethodName);
            var resultado = metodo.Invoke(wsGarantias, new object[] { gravamenes });

            return resultado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ACTUALIZA LOS DATOS DEL GRIDVIEW ADMINISTRACION GRAVAMENES*/
    private void GridViewGravamenesInternoActualizar()
    {
        try
        {
            if (pantallaModuloOculto.Value != null)
            {
                ListasWS.PantallasEntidad pantalla = new ListasWS.PantallasEntidad();
                pantalla.CodPantalla = int.Parse(pantallaModuloOculto.Value);

                //ESTABLECE LOS CONTROLES DE LA PANTALLA A CARGAR
                pantalla.Pestana = string.Empty;

                //EXTRAE LOS CONTROLES DE LA PANTALLA DESDE BD
                List<ControlEntidad> controles = new List<ControlEntidad>();
                controles = this.wsListas.AdministracionesContenidosConsultaControl(pantalla).ToList();

                //CONTROL DEL GRID
                wucGridControl grid = null;

                foreach (ControlEntidad control in controles)
                {
                    if (control.TipoContenido.Equals("GRIDVIEW"))
                    {
                        grid = (wucGridControl)this.tableData.FindControl(string.Concat("grid", control.NombrePropiedad));
                        if (grid != null)
                        {
                            grid.BindGridView(GridDataTable(control.MetodoServicioWeb));
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

    /*MUESTRA LAS NOTIFICACIONES DEL MANEJO DE GRIDS*/
    private void MensajesGrid()
    {
        //SI ES MODO EDICION
        if (!this.pantallaIdOculto.Value.Equals("0"))
        {
            wucGridControl grdGravamenes = (wucGridControl)this.tableData.FindControl("gridGravamenes");
            this.gridGravamenesInterno = (GridView)grdGravamenes.FindControl("MasterGridView");

            if (gridGravamenesInterno != null)
            {
                //SI POSEE REGISTROS SE DEBE DESPLEGAR EL MENSAJE DE ADVERTENCIA
                if (gridGravamenesInterno.Rows.Count > 0)
                {
                    //MENSAJE DE ADVERTENCIA GRID
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_39");
                    this.mpeInformarBox.Show();
                }
            }
        }

    }

    #endregion

    #endregion

    #region ENTIDADES

    /*RETORNA LA ENTIDAD*/
    public object ObtenerEntidad(object _entidad)
    {
        _entidad = new GarantiasWS.GarantiasValoresEntidad();
        return _entidad;
    }

    /*INSERTA UN NUEVO REGISTRO*/
    private void InsertarEntidad(string desPagina, SiganemGarantiasWS wsGarantias, object entidad)
    {
        try
        {
            string exec = "GarantiasValoresInsertar";
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

    /*ELIMINA UN REGISTRO*/
    private void EliminarEntidad(string desPagina, SiganemGarantiasWS wsGarantias, object entidad)
    {
        try
        {
            string exec = "GarantiasValoresEliminar";
            Type ws = wsGarantias.GetType();
            MethodInfo metodo = ws.GetMethod(exec);
            var resultado = metodo.Invoke(wsGarantias, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR) });
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
            //string exec = "GarantiasValoresModificar";
            //Type ws = wsGarantias.GetType();
            //MethodInfo metodo = ws.GetMethod(exec);
            //var resultado = metodo.Invoke(wsGarantias, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR) });

            var resultado = wsGarantias.GarantiasValoresModificar((GarantiasValoresEntidad)entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));

            //IDENTIDAD { 0=NUEVO; X=EDITAR }
            BarraMensaje((GarantiasWS.RespuestaEntidad)resultado, pantallaIdOculto.Value);
            //BloquearControlesNuevo();

            if (((GarantiasWS.RespuestaEntidad)resultado).ValorError.Equals(0))
            {
                this.pantallaIdOculto.Value = ((GarantiasWS.RespuestaEntidad)resultado).ValorEstado.ToString();
                this.hdnIdGeneral.Value = this.pantallaIdOculto.Value;
            }
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
            GarantiasValoresEntidad entidad = new GarantiasValoresEntidad();

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
                    if (propiedad.Name.Equals("IdGarantiaValor"))
                    {
                        entidadPropiedad = propiedad.Name;
                        entidadPropiedadTipo = propiedad.PropertyType.Name;
                        //ASIGNA EL VALOR A LA PROPIEDAD EL ID CORRESPONDE A LA PRIMERA PROPIEDAD DE CADA ENTIDAD
                        propiedad.SetValue(entidad, generadorControles.ConvertirTipoDato(entidadPropiedadTipo.ToUpper(), pantallaIdOculto.Value), null);
                        break;
                    }
                }


                //OBTIENE EL RESTO DE CAMPOS DEL REGISTRO A CONSULTAR DESDE LA BD            
                string exec = "GarantiasValoresConsultarDetalle";
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
            wsMQBCR.Url = ConfigurationManager.AppSettings["BCRMQWS"].ToString();
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
            //MENSAJES RETORNADOS DESDE BD
            if (ds != null)
            {
                //ERROR
                if (ds.ValorEstado.Equals(0))
                {
                    //CODIGO DE ERROR
                    mensajesEntidad.CodMensaje = "SQL_" + ds.ValorError;
                    lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";
                    resultadoProceso = -1;
                }
                else
                {
                    mensajesEntidad.CodMensaje = "SYS_1";
                    lblBarraMensaje.CssClass = "etiquetaBarraMensajeExito";
                    resultadoProceso = 0;
                }
            }
            else
            {
                //REQUERIMIENTO: 1-24653531
                //MENSAJE DE VALIDACION DE CARACTERES ESPECIALES
                mensajesEntidad.CodMensaje = tipoAccion;
                lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";
                resultadoProceso = -1;
            }

            //RETORNA MENSAJE DE ERROR
            lblBarraMensaje.Text = wsSeguridad.MensajesConsulta(mensajesEntidad).DesMensaje;
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

    /*AGREGA UN ITEM EN BLANCO PARA LOS DROPDOWNS*/
    private void ControlesItemBlanco()
    {
        AdministrarBlanco("IdPlazoCalificacion", true);
        AdministrarBlanco("IdEmpresaCalificadora", true);
        AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
        AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
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

    private void ControlesSoloLecturaExcepciones()
    {
        try
        {
            #region BUSCAR COMPONENTES

            DropDownList ddlInstrumento = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));
            DropDownList ddlISIN = (DropDownList)(this.tableData.FindControl("ISIN"));
            DropDownList ddlISIN1 = (DropDownList)(this.tableData.FindControl("ISIN1"));
            TextBox txtSerie = ((TextBox)this.tableData.FindControl("txtCustomSerie"));
            DropDownList ddlSerie = (DropDownList)(this.tableData.FindControl("ddlCustomSerie"));

            TextBox txtPremio = (TextBox)(this.tableData.FindControl("Premio"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));

            TextBox txtFechaVenc = (TextBox)(this.tableData.FindControl("FechaVencimiento"));
            RequiredFieldValidator rfvFechaVenc = (RequiredFieldValidator)(this.tableData.FindControl("rfvFechaVencimiento"));
            CalendarExtender caltxtFechaVenc = (CalendarExtender)(this.tableData.FindControl("calendarExtenderFechaVencimiento"));
            ImageButton imgFechaVenc = (ImageButton)(this.tableData.FindControl("imgButtonCalendarExtenderFechaVencimiento"));

            CheckBox chkCustomBusqueda = (CheckBox)(this.tableData.FindControl("chkCustomBusqueda"));
            RequiredFieldValidator rfvBusqueda = (RequiredFieldValidator)(this.tableData.FindControl("rfvBusqueda"));

            #endregion

            if (pantallaIdOculto.Value.Equals("0"))
            {
                txtPremio.Enabled = true;
                ddlMonedaValorMercado.Enabled = false;

                if (!chkCustomBusqueda.Checked)
                    rfvBusqueda.Enabled = false;

                #region FECHA VENCIMIENTO

                txtFechaVenc.Enabled = false;
                rfvFechaVenc.Enabled = false;
                imgFechaVenc.Enabled = false;
                caltxtFechaVenc.Enabled = false;

                #endregion
                #region CARGAR COMPONENTES

                CargarISIN(ddlEmisor, ddlInstrumento);
                CargarSerieDropBox(ddlInstrumento, ddlEmisor, ddlISIN);

                txtSerie.Visible = false;
                txtSerie.Enabled = false;

                ddlSerie.Visible = true;
                ddlSerie.Enabled = true;

                CargarIdgarantia(ddlISIN1, ddlISIN);
                CargarClasificacionPremio(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie);

                #endregion

                #region GRAVAMENES
                AdministrarBlanco("IndGravamen", true);
                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ControlesModificacionExcepcion()
    {
        //MODIFICACION
        if (!pantallaIdOculto.Value.Equals("0"))
        {
            switch (ValorTipoValor())
            {
                case 1:
                    ModificacionExcepcionOtrosValores();
                    break;
                case 2:
                    ModificacionExcepcionCDPBCR();
                    break;
                case 3:
                    ModificacionExcepcionCDPOtrosEmisores();
                    break;
                case 4:
                    ModificacionExcepcionOtrosValoresExcepcion();
                    break;
            }

            //DESHABILITA EL BOTÓN DE VALIDAR PARA LAS EDICICIONES
            Button btnValidar = (Button)this.tableData.FindControl("Validar");
            if (btnValidar != null)
                btnValidar.Enabled = false;
        }
    }

    /*ACORTA LA CADENA DEL TIPO DE DATO*/
    private string ObtenerTipoDato(string tipoDatoLargo, string valorAsignar)
    {
        string retorno = tipoDatoLargo;

        if (tipoDatoLargo.ToUpper().Contains("INT32"))
            retorno = "INT32";
        if (tipoDatoLargo.ToUpper().Contains("STRING"))
            retorno = "STRING";
        if (tipoDatoLargo.ToUpper().Contains("DATETIME"))
            retorno = "DATETIME";
        if (tipoDatoLargo.ToUpper().Contains("BOOLEAN"))
            retorno = "BOOLEAN";
        if (tipoDatoLargo.ToUpper().Contains("DECIMAL"))
            retorno = "DECIMAL";
        if (valorAsignar.Length.Equals(0))
            retorno = "NULL";

        return retorno;
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

    private void LimpiarDropDownList(DropDownList _dropDownList)
    {
        //BORRA LOS VALORES DEL DDL, SE DEBE DE REALIZAR DE ESTA MANERA PARA ELIMINAR LOS DATOS EN CACHÉ DEL OBJ
        _dropDownList.ClearSelection();
        _dropDownList.Items.Clear();
        _dropDownList.SelectedValue = null;
        _dropDownList.DataSource = null;
    }

    private void LimpiarContenidoFormulario()
    {
        ((TextBox)this.tableData.FindControl("Premio")).Text = string.Empty;
        ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Text = string.Empty;
        ((TextBox)this.tableData.FindControl("CodGarantia")).Text = string.Empty;
        ((TextBox)this.tableData.FindControl("IdentificacionEmisor")).Text = string.Empty;
        ((TextBox)this.tableData.FindControl("IdentificacionInstrumento")).Text = string.Empty;
        ((TextBox)this.tableData.FindControl("MontoValorFacial")).Text = string.Empty;
        ((TextBox)this.tableData.FindControl("MontoValorMercado")).Text = string.Empty;
        ((TextBox)this.tableData.FindControl("FechaValorMercado")).Text = string.Empty;
        ((TextBox)this.tableData.FindControl("FechaConstitucionGarantia")).Text = string.Empty;
        ((TextBox)this.tableData.FindControl("FechaVencimiento")).Text = string.Empty;

        DropDownList ddlTipoInstrum = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));
        DropDownList ddlTipoPersona = ((DropDownList)this.tableData.FindControl("IdTipoPersonaEmisor"));
        DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
        DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));
        DropDownList ddlClasificacionInstrum = (DropDownList)(this.tableData.FindControl("ddlCustomClasificacionInstrumento"));

        ddlTipoInstrum.SelectedIndex = -1;
        ddlTipoPersona.SelectedIndex = -1;
        ddlMonedaValorFacial.SelectedIndex = -1;
        ddlMonedaValorMercado.SelectedIndex = -1;
        ddlClasificacionInstrum.SelectedIndex = -1;
    }

    private int ValorTipoValor()
    {
        return int.Parse(((DropDownList)this.tableData.FindControl("IdTipoValor")).SelectedValue);
    }

    private bool ValidarFechasIncongruentes(string fechaConstitucion, string fechaVencimiento, string fechaMercado)
    {
        bool resultado = true;
        //FECHA CONSTITUCION NO PUEDE SER MAYOR A FECHA ACTUAL
        if (generadorControles.ObtenerComparacion(fechaConstitucion, DateTime.Now.ToString(), EnumTipoComparacion.MAYOR, TypeCode.DateTime))
        {
            resultado = false;
        }
        //FECHA VENCIMIENTO NO PUEDE SER MENOR O IGUAL A FECHA ACTUAL
        if (generadorControles.ObtenerComparacion(fechaVencimiento, DateTime.Now.ToString(), EnumTipoComparacion.MENORIGUAL, TypeCode.DateTime))
        {
            resultado = false;
        }
        //FECHA VALOR MERCADO NO PUEDE SER MENOR  A FECHA CONSTITUCION
        if (generadorControles.ObtenerComparacion(fechaMercado, fechaConstitucion, EnumTipoComparacion.MENOR, TypeCode.DateTime))
        {
            resultado = false;
        }

        return resultado;
    }

    private void HabilitarFechasFormulario(string _nombreCalendar, bool _estado, bool _limpiar)
    {
        ((TextBox)this.tableData.FindControl(_nombreCalendar)).Enabled = _estado;
        ((RequiredFieldValidator)this.tableData.FindControl("rfv" + _nombreCalendar)).Enabled = _estado;
        ((CalendarExtender)this.tableData.FindControl("calendarExtender" + _nombreCalendar)).Enabled = _estado;
        ((ImageButton)this.tableData.FindControl("imgButtonCalendarExtender" + _nombreCalendar)).Enabled = _estado;
        ((ImageButton)this.tableData.FindControl("imgButtonCalendarExtender" + _nombreCalendar)).ImageUrl = (_estado) ? "~/Library/img/32/iconCalendario.gif" : "~/Library/img/32/iconCalendario_dis.gif";

        if (_limpiar)
            ((TextBox)this.tableData.FindControl(_nombreCalendar)).Text = string.Empty;
    }

    private void HabilitarFechasFormularioVencimiento(bool _estado, bool _limpiar)
    {
        ((TextBox)this.tableData.FindControl("FechaVencimiento")).Enabled = true;
        ((RequiredFieldValidator)this.tableData.FindControl("rfv" + "FechaVencimiento")).Enabled = _estado;
        ((CalendarExtender)this.tableData.FindControl("calendarExtender" + "FechaVencimiento")).Enabled = true;
        ((ImageButton)this.tableData.FindControl("imgButtonCalendarExtender" + "FechaVencimiento")).Enabled = true;
        ((ImageButton)this.tableData.FindControl("imgButtonCalendarExtender" + "FechaVencimiento")).ImageUrl = "~/Library/img/32/iconCalendario.gif";

        if (_limpiar)
            ((TextBox)this.tableData.FindControl("FechaVencimiento")).Text = string.Empty;
    }

    private void AsignarTipoPersona()
    {
        ((DropDownList)this.tableData.FindControl("IdTipoPersonaEmisor")).Enabled = false;
        generadorControles.SeleccionarOpcionDropDownList(((DropDownList)this.tableData.FindControl("IdTipoPersonaEmisor")), "2");
    }

    private bool ObtenerCheckBoxBusqueda()
    {
        return ((CheckBox)this.tableData.FindControl("chkCustomBusqueda")).Checked;
    }

    private void AsignarEstadoControlBusqueda(bool _estadoControl)
    {
        ((TextBox)this.tableData.FindControl("txtCustomBusqueda")).Text = string.Empty;
        ((TextBox)this.tableData.FindControl("txtCustomBusqueda")).Enabled = _estadoControl;
        ((Button)this.tableData.FindControl("imgCustomBusqueda")).Enabled = _estadoControl;
        ((RequiredFieldValidator)this.tableData.FindControl("rfvBusqueda")).Enabled = _estadoControl;
        ((Button)this.tableData.FindControl("imgCustomBusqueda")).CssClass = _estadoControl ? "imgCmdBuscarGarantia" : "imgCmdBuscarGarantiaDisabled";
    }

    #endregion

    //REQUERIMIENTO: 1-24381561
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

    #region EXCEPCIONES DEL FORMULARIO

    /*EXCEPCIONES EN LA CONSTRUCCION DE LOS CONTROLES*/
    private void CargarControlesExcepciones(Table tblPrincipal, ControlEntidad control)
    {
        try
        {
            StringBuilder _filtroBuilder = new StringBuilder();
            _filtroBuilder.Clear();

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
                    _filtroBuilder.Append(ddlIdEmpresaCalificadora.SelectedValue);

                _filtroBuilder.Append("|");

                if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                    _filtroBuilder.Append(ddlIdCategoriaRiesgoEmpresaCalificadora.SelectedValue);

                filtro = _filtroBuilder.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private Boolean ModificarTextBoxExcepciones(string control)
    {
        bool estado = false;

        switch (control)
        {
            case "CodGarantiaBCR":
            case "CodGarantia":
            case "ClasificacionInstrumento":
            case "IdentificacionEmisor":
            case "Premio":
                estado = false;
                break;
            default:
                estado = true;
                break;
        }

        return estado;
    }

    private Boolean ModificarDropDownExcepciones(string control)
    {
        bool estado = false;
        switch (control)
        {
            case "IdTipoValor":
            case "IdTipoInstrumento":
            case "IdInstrumento":
            case "IdEmisor":
            case "ISIN":
            case "Serie":
            case "IdMonedaValorMercado":
                estado = false;
                break;
            default:
                estado = true;
                break;
        }
        return estado;
    }

    /*ESTABLE LAS EXCEPCIONES EN LA CARGA DE VALORES DE LA ENTIDAD A LOS CONTROLES*/
    private void DeEntidadAControlesExcepciones(List<KeyValuePair<string, string>> entidad)
    {
        try
        {
            string seleccionado = string.Empty;

            #region BUSQUEDA DE CONTROLES

            CheckBox chkBusqueda = ((CheckBox)this.tableData.FindControl("chkCustomBusqueda"));
            DropDownList ddlIdTipoInstrumento = ((DropDownList)this.tableData.FindControl("IdTipoInstrumento"));
            DropDownList ddlIdInstrumento = ((DropDownList)this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlIdEmisor = ((DropDownList)this.tableData.FindControl("IdEmisor"));

            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("ddlCustomSerie"));
            DropDownList ddlIdClasificacionInstrumento = ((DropDownList)this.tableData.FindControl("ddlCustomClasificacionInstrumento"));

            DropDownList ddlTipoAsignacionCalif = ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion"));
            DropDownList ddlIdPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlIdEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlIdCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));
            DropDownList ddlIdCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));

            TextBox txtSerie = ((TextBox)this.tableData.FindControl("txtCustomSerie"));
            TextBox txtIdGarantia = ((TextBox)this.tableData.FindControl("CodGarantia"));
            TextBox txtPremio = ((TextBox)this.tableData.FindControl("Premio"));
            TextBox txtIdentificacionEmisor = ((TextBox)this.tableData.FindControl("IdentificacionEmisor"));
            TextBox txtIdentificacionInstrumento = ((TextBox)this.tableData.FindControl("IdentificacionInstrumento"));
            DropDownList ddlMonedaValorFacial = ((DropDownList)this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = ((DropDownList)this.tableData.FindControl("IdMonedaValorMercado"));

            TextBox txtFechaVencimiento = ((TextBox)this.tableData.FindControl("FechaVencimiento"));

            #endregion
            #region LIMPIAR FORMATO FECHA

            TextBox txtFechaValo = ((TextBox)this.tableData.FindControl("FechaValorMercado"));
            TextBox txtFechaConst = ((TextBox)this.tableData.FindControl("FechaConstitucionGarantia"));
            TextBox txtFechaVenc = ((TextBox)this.tableData.FindControl("FechaVencimiento"));
            txtFechaValo.Text = txtFechaValo.Text.Replace(" 0:00:00", "");
            txtFechaConst.Text = txtFechaConst.Text.Replace(" 0:00:00", "");
            txtFechaVenc.Text = txtFechaVenc.Text.Replace(" 0:00:00", "");

            #endregion

            #region TIPO VALOR
            switch (ValorTipoValor())
            {
                case 2:
                    ((Label)this.tableData.FindControl("lbl1Cell0")).Text = "Búsqueda CDP";
                    break;
            }
            #endregion

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISORES

            if (ddlIdTipoInstrumento != null)
            {
                LimpiarDropDownList(ddlIdTipoInstrumento);
                switch (ValorTipoValor())
                {
                    case 1:
                        CargarTipoInstrumento();
                        break;
                    default:
                        CargarTipoInstrumentoTodos();
                        break;
                }
                generadorControles.SeleccionarOpcionDropDownList(ddlIdTipoInstrumento, entidad[11].Value);//SELECCIONA TIPO INSTRUMENTO
            }

            if (ddlIdTipoInstrumento != null && ddlIdInstrumento != null)
            {
                LimpiarDropDownList(ddlIdInstrumento);
                switch (ValorTipoValor())
                {
                    case 1:
                        CargarInstrumento(ddlIdTipoInstrumento);
                        break;
                    default:
                        CargarInstrumentosTodos();
                        break;
                }
                generadorControles.SeleccionarOpcionDropDownList(ddlIdInstrumento, entidad[5].Value);//SELECCIONA INSTRUMENTO FINANCIERO
            }

            if (ddlIdInstrumento != null && ddlIdEmisor != null)
            {
                LimpiarDropDownList(ddlIdEmisor);
                switch (ValorTipoValor())
                {
                    case 1:
                        CargarEmisor(ddlIdInstrumento);
                        break;
                    default:
                        CargarOtrosEmisores();
                        break;
                }
                generadorControles.SeleccionarOpcionDropDownList(ddlIdEmisor, entidad[3].Value);//SELECCIONA EMISOR
            }

            #endregion
            #region ASIGNACION CALIFICACION / EMPRESAS CALIFICADORAS / CALIFICACION EMPRESA CALIFICADORA

            seleccionado = ddlTipoAsignacionCalif.SelectedItem.Text.Substring(0, 3);
            if (!seleccionado.Equals("0 -"))
            {
                DdlTipoAsignacionCalificacion(ddlIdPlazoCalificacion);
                generadorControles.SeleccionarOpcionDropDownList(ddlIdPlazoCalificacion, entidad[9].Value);//SELECCIONA PLAZO CALIFICACION

                if ((ddlIdPlazoCalificacion != null) && (ddlIdCalificacionEmpresaCalificadora != null) && (ddlIdEmpresaCalificadora != null) && (ddlIdCategoriaRiesgoEmpresaCalificadora != null))
                {
                    if (!ddlIdPlazoCalificacion.SelectedValue.Equals("-1"))
                    {
                        LimpiarDropDownList(ddlIdEmpresaCalificadora);
                        CargarEmpresaCalificadora(ddlIdPlazoCalificacion);
                        generadorControles.SeleccionarOpcionDropDownList(ddlIdEmpresaCalificadora, entidad[4].Value);//SELECCIONA EMPRESA CALIFICADORA
                    }

                    if (!ddlIdEmpresaCalificadora.SelectedValue.Equals("-1"))
                    {
                        LimpiarDropDownList(ddlIdCalificacionEmpresaCalificadora);
                        CargarCalificacionEmpresaCalificadora(ddlIdEmpresaCalificadora, ddlIdCategoriaRiesgoEmpresaCalificadora);
                        generadorControles.SeleccionarOpcionDropDownList(ddlIdCalificacionEmpresaCalificadora, entidad[1].Value);//SELECCIONA CATEGORIA CALIFICACION
                    }

                    if (!ddlIdCalificacionEmpresaCalificadora.SelectedValue.Equals("-1"))
                    {
                        LimpiarDropDownList(ddlIdCategoriaRiesgoEmpresaCalificadora);
                        CargarCategoriaRiesgoEmpresaCalificadora(ddlIdCategoriaRiesgoEmpresaCalificadora);
                        generadorControles.SeleccionarOpcionDropDownList(ddlIdCategoriaRiesgoEmpresaCalificadora, entidad[2].Value);//SELECCIONA CATEGORIA RIESGO EMPRESA CALIFICADORA
                    }
                }
            }
            #endregion
            #region REVISION ASIGNACION CALIFICACION  / EMPRESAS CALIFICADORAS / CALIFICACION EMPRESA CALIFICADORA

            seleccionado = ddlTipoAsignacionCalif.SelectedItem.Text.Substring(0, 3);
            if (!seleccionado.Equals("0 -"))
            {
                if (ddlIdPlazoCalificacion != null)
                {
                    ddlIdPlazoCalificacion.Enabled = true;
                }
                if (ddlIdEmpresaCalificadora != null)
                {
                    ddlIdEmpresaCalificadora.Enabled = true;
                }
                if (ddlIdCategoriaRiesgoEmpresaCalificadora != null)
                {
                    ddlIdCategoriaRiesgoEmpresaCalificadora.Enabled = true;
                }
                if (ddlIdCalificacionEmpresaCalificadora != null)
                {
                    ddlIdCalificacionEmpresaCalificadora.Enabled = true;
                }
            }
            else
            {
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

            #endregion
            #region ASIGNACION VALORES A CONTROLES

            if (!pantallaIdOculto.Value.Equals("0"))//MODIFICACION
            {                
                CargarISIN(ddlIdEmisor, ddlIdInstrumento);//CARGA ISIN
                generadorControles.SeleccionarOpcionDropDownList(ddlISIN, entidad[16].Value);//SELECCIONA ISIN
                txtIdGarantia.Text = entidad[12].Value;//CARGA ID GARANTIA
                CargarClasificacionPremio(ddlIdInstrumento, ddlIdEmisor, ddlISIN, ddlSerie);//CARGA CLASIFICACION / PREMIO
                generadorControles.SeleccionarOpcionDropDownList(ddlTipoAsignacionCalif, entidad[8].Value);//SELECCIONA ASIGNACION CALIFICACION
                generadorControles.SeleccionarOpcionDropDownList(ddlIdPlazoCalificacion, entidad[9].Value);//SELECCIONA PLAZO CALIFICACION
                DdlEmpresaCalificadora(ddlIdEmpresaCalificadora);//CARGA EMPRESA CALIFICADORA
                generadorControles.SeleccionarOpcionDropDownList(ddlIdCategoriaRiesgoEmpresaCalificadora, entidad[2].Value);//SELECCIONA CALIFICACION RIESGO
                txtIdentificacionEmisor.Text = entidad[14].Value;
                txtIdentificacionInstrumento.Text = entidad[15].Value;
                chkBusqueda.Checked = bool.Parse(entidad[26].Value);
                txtPremio.Text = entidad[21].Value;
                generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorFacial, entidad[6].Value);
                generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, entidad[6].Value);
                if (entidad[20].Value.Length > 0)
                    txtFechaVencimiento.Text = DateTime.Parse(entidad[20].Value).ToShortDateString();

                switch (ValorTipoValor())
                {
                    case 1:
                        if (!chkBusqueda.Checked)
                        {
                            CargarSerieDropBox(ddlIdInstrumento, ddlIdEmisor, ddlISIN);//CARGA SERIE
                            generadorControles.SeleccionarOpcionDropDownList(ddlSerie, entidad[17].Value);//SELECCIONA SERIE
                        }
                        else
                        {
                            CargarSerieTextBox(ddlIdInstrumento, ddlIdEmisor, ddlISIN);//CARGA SERIE
                            txtSerie.Text = entidad[17].Value;
                        }
                        break;
                    case 4:
                        generadorControles.SeleccionarOpcionDropDownListTexto(ddlISIN1, "NO");//SELECCIONA ISIN1
                        AdministrarBlanco("ISIN", true);
                        generadorControles.SeleccionarOpcionDropDownList(ddlISIN, entidad[16].Value);//SELECCIONA ISIN
                        generadorControles.SeleccionarOpcionDropDownListTexto(ddlIdClasificacionInstrumento, entidad[13].Value);//SELECCIONA CLASIFICACION INSTRUMENTO
                        break;
                }

            }

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region EXCEPCIONES TIPO VALORES. REQUERIMIENTO: 1-24292751

    #region INSERTAR FORMULARIO

    //REQUERIMIENTO: 1-24653531
    private void InsertarExcepcionOtrosValores()
    {
        try
        {
            #region LIMPIAR MENSAJES

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
            {
                this.divBarraMensaje.Visible = false;
            }

            #endregion

            #region CONTROLES CUSTOM BUSQUEDA / ID GARANTÍA BCR

            this.tableData.FindControl("trBusqueda").Visible = true;

            ((CheckBox)this.tableData.FindControl("chkCustomBusqueda")).Checked = false;
            ((CheckBox)this.tableData.FindControl("chkCustomBusqueda")).Enabled = true;
            chkCustomBusqueda_CheckedChanged(((CheckBox)this.tableData.FindControl("chkCustomBusqueda")), null);

            ((Label)this.tableData.FindControl("lbl1Cell0")).Text = "Búsqueda ISIN";
            ((TextBox)this.tableData.FindControl("txtCustomBusqueda")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("txtCustomBusqueda")).ToolTip = "Texto Búsqueda ISIN";
            ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Enabled = true;
            ((RequiredFieldValidator)this.tableData.FindControl("rfvCodGarantiaBCR")).Enabled = true;

            LimpiarContenidoFormulario();

            #endregion

            #region TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            DropDownList ddlTipoInstrum = (DropDownList)(this.tableData.FindControl("IdTipoInstrumento"));
            DropDownList ddlInstrum = (DropDownList)(this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlEmisor = (DropDownList)(this.tableData.FindControl("IdEmisor"));

            ddlTipoInstrum.Enabled = true;
            ddlInstrum.Enabled = true;
            ddlEmisor.Enabled = true;

            CargarInstrumento(ddlTipoInstrum);
            CargarEmisor(ddlInstrum);

            #endregion

            #region ISIN / SERIE / ID GARANTIA / CLASIFICACION INSTRUMENTO / PREMIO

            TextBox txtSerie = ((TextBox)this.tableData.FindControl("txtCustomSerie"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("ddlCustomSerie"));

            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            TextBox txtIdGarantia = ((TextBox)this.tableData.FindControl("CodGarantia"));
            TextBox txtClasifInstrum = (TextBox)(this.tableData.FindControl("txtCustomClasificacionInstrumento"));
            DropDownList ddlClasifInstrum = (DropDownList)(this.tableData.FindControl("ddlCustomClasificacionInstrumento"));

            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Visible = false;
            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Enabled = true;
            ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Visible = true;
            AdministrarBlanco("Serie", true);


            txtClasifInstrum.Visible = true;
            ddlClasifInstrum.Visible = false;
            ddlISIN.Enabled = true;

            CargarISIN(ddlEmisor, ddlInstrum);
            CargarSerieDropBox(ddlInstrum, ddlEmisor, ddlISIN);
            if (ddlISIN1.SelectedItem.Text.Equals("SI"))
            {
                txtIdGarantia.Text = ((DropDownList)this.tableData.FindControl("ISIN")).Text;
            }
            else
            {
                txtIdGarantia.Text = ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Text;
            }
            CargarClasificacion(ddlInstrum, ddlEmisor, ddlISIN, ddlSerie);
            CargarMoneda(ddlInstrum, ddlEmisor, ddlISIN, ddlSerie, ddlTipoInstrum);

            #endregion

            #region TIPO PERSONA / IDENTIFICACION EMISOR / IDENTIFICACION INSTRUMENTO

            TextBox txtIdentificacionEmisor = ((TextBox)this.tableData.FindControl("IdentificacionEmisor"));
            TextBox txtIdentificacionInstrumento = ((TextBox)this.tableData.FindControl("IdentificacionInstrumento"));

            AsignarTipoPersona();
            txtIdentificacionInstrumento.Enabled = false;
            CargarDropDownIdentificacionEmisor(ddlEmisor);
            txtIdentificacionEmisor.Enabled = true;
            txtIdentificacionInstrumento.Text = generadorControles.BuscaCadenaConSubstring(ddlInstrum.SelectedItem.ToString().Trim(), " - ");

            #endregion

            #region TIPO ASIGNACION CALIFICACION / PLAZO CALIFICACION / EMPRESA CALIFICADORA / CATEGORIA CALIFICACION / CALIFICACION RIESGO

            DropDownList ddlTipoAsignacionCalificacion = ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion"));
            DropDownList ddlPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            if (ddlTipoAsignacionCalificacion != null)
            {
                ddlTipoAsignacionCalificacion.SelectedIndex = -1;
            }
            if (ddlPlazoCalificacion != null)
            {
                AdministrarBlanco("IdPlazoCalificacion", true);
                ddlPlazoCalificacion.Enabled = false;
            }
            if (ddlEmpresaCalificadora != null)
            {
                AdministrarBlanco("IdEmpresaCalificadora", true);
                ddlEmpresaCalificadora.Enabled = false;
            }
            if (ddlCalificacionEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCalificacionEmpresaCalificadora);
                AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
                ddlCalificacionEmpresaCalificadora.Enabled = false;
            }
            if (ddlCategoriaRiesgoEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCategoriaRiesgoEmpresaCalificadora);
                AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
                ddlCategoriaRiesgoEmpresaCalificadora.Enabled = false;
            }

            #endregion

            #region VALORES MONEDAS

            TextBox txtMonedaValorFacial = (TextBox)(this.tableData.FindControl("MontoValorFacial"));
            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            //RequiredFieldValidator rfvMontoValorFacial = (RequiredFieldValidator)(this.tableData.FindControl("rfvMontoValorFacial"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));

            ddlMonedaValorFacial.Enabled = false;
            ddlMonedaValorMercado.Enabled = false;
            txtMonedaValorFacial.Enabled = true;
            //rfvMontoValorFacial.Enabled = true;

            string _Seleccionado = ddlMonedaValorFacial.SelectedValue;
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, _Seleccionado);

            #endregion

            #region FECHA CONSTITUCION / FECHA VENCIMIENTO

            //javendano
            HabilitarFechasFormulario("FechaValorMercado", true, true);

            HabilitarFechasFormulario("FechaConstitucionGarantia", true, true);
            HabilitarFechasFormulario("FechaVencimiento", false, true);

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //REQUERIMIENTO: 1-24653531
    private void InsertarExcepcionCDPBCR()
    {
        try
        {
            #region LIMPIAR MENSAJES

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
            {
                this.divBarraMensaje.Visible = false;
            }

            #endregion

            #region CONTROLES CUSTOM BUSQUEDA / ID GARANTÍA BCR

            this.tableData.FindControl("trBusqueda").Visible = true;

            ((CheckBox)this.tableData.FindControl("chkCustomBusqueda")).Checked = true;
            ((CheckBox)this.tableData.FindControl("chkCustomBusqueda")).Enabled = false;
            chkCustomBusqueda_CheckedChanged(((CheckBox)this.tableData.FindControl("chkCustomBusqueda")), null);

            ((Label)this.tableData.FindControl("lbl1Cell0")).Text = "Búsqueda CDP";
            ((TextBox)this.tableData.FindControl("txtCustomBusqueda")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("txtCustomBusqueda")).ToolTip = "Texto Búsqueda CDP";
            ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Enabled = false;

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

            #region ISIN / SERIE / ID GARANTIA / CLASIFICACION INSTRUMENTO

            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            TextBox txtSerie = ((TextBox)this.tableData.FindControl("txtCustomSerie"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("ddlCustomSerie"));
            TextBox txtClasifInstrum = (TextBox)(this.tableData.FindControl("txtCustomClasificacionInstrumento"));
            DropDownList ddlClasifInstrum = (DropDownList)(this.tableData.FindControl("ddlCustomClasificacionInstrumento"));

            txtClasifInstrum.Visible = true;
            ddlClasifInstrum.Visible = false;
            ddlISIN.Enabled = false;

            #region VALIDACION SERIE

            txtSerie.Enabled = false;
            txtSerie.Visible = true;
            txtSerie.Text = string.Empty;

            ddlSerie.Enabled = false;
            ddlSerie.Visible = false;

            #endregion

            LimpiarDropDownList(ddlISIN);
            LimpiarDropDownList(ddlSerie);
            generadorControles.SeleccionarOpcionDropDownListTexto(ddlISIN1, "NO");
            CargarIdgarantia();
            generadorControles.SeleccionarOpcionDropDownList(ddlClasifInstrum, "5");
            txtClasifInstrum.Text = ddlClasifInstrum.SelectedItem.Text;

            #endregion

            #region TIPO PERSONA / IDENTIFICACION EMISOR / IDENTIFICACION INSTRUMENTO / PREMIO

            TextBox txtIdentificacionEmisor = ((TextBox)this.tableData.FindControl("IdentificacionEmisor"));
            TextBox txtIdentificacionInstrumento = ((TextBox)this.tableData.FindControl("IdentificacionInstrumento"));
            TextBox txtPremio = ((TextBox)this.tableData.FindControl("Premio"));

            txtPremio.Enabled = false;
            txtIdentificacionInstrumento.Enabled = false;
            AsignarTipoPersona();
            txtIdentificacionEmisor.Text = "BCR";
            txtIdentificacionEmisor.Enabled = false;
            txtIdentificacionInstrumento.Text = generadorControles.BuscaCadenaConSubstring(ddlInstrum.SelectedItem.ToString().Trim(), " - ");

            #endregion

            #region TIPO ASIGNACION CALIFICACION / PLAZO CALIFICACION / EMPRESA CALIFICADORA / CATEGORIA CALIFICACION / CALIFICACION RIESGO

            DropDownList ddlTipoAsignacionCalificacion = ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion"));
            DropDownList ddlPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            ddlTipoAsignacionCalificacion.Enabled = true;
            AdministrarBlanco("IdTipoAsignacionCalificacion", false);

            if (ddlTipoAsignacionCalificacion != null)
            {
                ddlTipoAsignacionCalificacion.SelectedIndex = -1;
            }
            if (ddlPlazoCalificacion != null)
            {
                AdministrarBlanco("IdPlazoCalificacion", true);
                ddlPlazoCalificacion.Enabled = false;
            }
            if (ddlEmpresaCalificadora != null)
            {
                AdministrarBlanco("IdEmpresaCalificadora", true);
                ddlEmpresaCalificadora.Enabled = false;
            }
            if (ddlCalificacionEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCalificacionEmpresaCalificadora);
                AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
                ddlCalificacionEmpresaCalificadora.Enabled = false;
            }
            if (ddlCategoriaRiesgoEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCategoriaRiesgoEmpresaCalificadora);
                AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
                ddlCategoriaRiesgoEmpresaCalificadora.Enabled = false;
            }

            #endregion

            #region VALORES MONEDAS

            TextBox txtMonedaValorFacial = (TextBox)(this.tableData.FindControl("MontoValorFacial"));
            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            //RequiredFieldValidator rfvMontoValorFacial = (RequiredFieldValidator)(this.tableData.FindControl("rfvMontoValorFacial"));

            TextBox txtMonedaValorMercado = (TextBox)(this.tableData.FindControl("MontoValorMercado"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));
            //RequiredFieldValidator rfvMontoValorMercado = (RequiredFieldValidator)(this.tableData.FindControl("rfvMontoValorMercado"));

            ddlMonedaValorFacial.Enabled = false;
            txtMonedaValorFacial.Enabled = false;
            //rfvMontoValorFacial.Enabled = true;

            ddlMonedaValorMercado.Enabled = false;
            txtMonedaValorMercado.Enabled = true;
            //rfvMontoValorMercado.Enabled = true;

            CargarMoneda("MonedasLista");
            string _Seleccionado = ddlMonedaValorFacial.SelectedValue;
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, _Seleccionado);

            #endregion

            #region FECHA MERCADO / FECHA CONSTITUCION / FECHA VENCIMIENTO

            HabilitarFechasFormulario("FechaValorMercado", true, true);
            HabilitarFechasFormulario("FechaConstitucionGarantia", false, true);
            HabilitarFechasFormulario("FechaVencimiento", false, true);

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
            #region LIMPIAR MENSAJES

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
            {
                this.divBarraMensaje.Visible = false;
            }

            #endregion

            //REQUERIMIENTO: 1-24653531
            #region CONTROLES CUSTOM BUSQUEDA / ID GARANTÍA BCR

            this.tableData.FindControl("trBusqueda").Visible = false;
            ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Enabled = true;
            ((RequiredFieldValidator)this.tableData.FindControl("rfvCodGarantiaBCR")).Enabled = true;

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

            #region ISIN / SERIE / ID GARANTIA / CLASIFICACION INSTRUMENTO

            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            TextBox txtSerie = ((TextBox)this.tableData.FindControl("txtCustomSerie"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("ddlCustomSerie"));
            TextBox txtClasifInstrum = (TextBox)(this.tableData.FindControl("txtCustomClasificacionInstrumento"));
            DropDownList ddlClasifInstrum = (DropDownList)(this.tableData.FindControl("ddlCustomClasificacionInstrumento"));

            txtClasifInstrum.Visible = true;
            ddlClasifInstrum.Visible = false;
            ddlISIN.Enabled = false;

            #region VALIDACION SERIE

            txtSerie.Enabled = false;
            txtSerie.Visible = true;
            txtSerie.Text = string.Empty;

            ddlSerie.Enabled = false;
            ddlSerie.Visible = false;

            #endregion

            LimpiarDropDownList(ddlISIN);
            LimpiarDropDownList(ddlSerie);
            generadorControles.SeleccionarOpcionDropDownListTexto(ddlISIN1, "NO");
            CargarIdgarantia();
            generadorControles.SeleccionarOpcionDropDownList(ddlClasifInstrum, "5");
            txtClasifInstrum.Text = ddlClasifInstrum.SelectedItem.Text;

            #endregion

            #region TIPO PERSONA / IDENTIFICACION EMISOR / IDENTIFICACION INSTRUMENTO / PREMIO

            TextBox txtIdentificacionEmisor = ((TextBox)this.tableData.FindControl("IdentificacionEmisor"));
            TextBox txtIdentificacionInstrumento = ((TextBox)this.tableData.FindControl("IdentificacionInstrumento"));
            TextBox txtPremio = ((TextBox)this.tableData.FindControl("Premio"));

            txtPremio.Enabled = true;
            txtIdentificacionInstrumento.Enabled = false;
            AsignarTipoPersona();
            CargarDropDownIdentificacionEmisor(ddlEmisor);
            txtIdentificacionEmisor.Enabled = false;
            txtIdentificacionInstrumento.Text = generadorControles.BuscaCadenaConSubstring(ddlInstrum.SelectedItem.ToString().Trim(), " - ");

            #endregion

            #region TIPO ASIGNACION CALIFICACION / PLAZO CALIFICACION / EMPRESA CALIFICADORA / CATEGORIA CALIFICACION / CALIFICACION RIESGO

            DropDownList ddlTipoAsignacionCalificacion = ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion"));
            DropDownList ddlPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            if (ddlTipoAsignacionCalificacion != null)
            {
                ddlTipoAsignacionCalificacion.SelectedIndex = -1;
            }
            if (ddlPlazoCalificacion != null)
            {
                AdministrarBlanco("IdPlazoCalificacion", true);
                ddlPlazoCalificacion.Enabled = false;
            }
            if (ddlEmpresaCalificadora != null)
            {
                AdministrarBlanco("IdEmpresaCalificadora", true);
                ddlEmpresaCalificadora.Enabled = false;
            }
            if (ddlCalificacionEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCalificacionEmpresaCalificadora);
                AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
                ddlCalificacionEmpresaCalificadora.Enabled = false;
            }
            if (ddlCategoriaRiesgoEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCategoriaRiesgoEmpresaCalificadora);
                AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
                ddlCategoriaRiesgoEmpresaCalificadora.Enabled = false;
            }

            #endregion

            #region VALORES MONEDAS

            TextBox txtMonedaValorFacial = (TextBox)(this.tableData.FindControl("MontoValorFacial"));
            TextBox txtMontoValorMercado = (TextBox)(this.tableData.FindControl("MontoValorMercado"));

            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));

            //RequiredFieldValidator rfvMontoValorFacial = (RequiredFieldValidator)(this.tableData.FindControl("rfvMontoValorFacial"));
            //RequiredFieldValidator rfvMontoValorMercado = (RequiredFieldValidator)(this.tableData.FindControl("rfvMontoValorMercado"));

            ddlMonedaValorFacial.Enabled = true;
            txtMonedaValorFacial.Enabled = true;
            //rfvMontoValorFacial.Enabled = true;

            txtMontoValorMercado.Enabled = true;
            //rfvMontoValorMercado.Enabled = true;
            ddlMonedaValorMercado.Enabled = false;

            CargarMoneda("MonedasLista");
            string seleccionado = ddlMonedaValorFacial.SelectedValue;
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, seleccionado);

            #endregion

            #region FECHA CONSTITUCION / FECHA VENCIMIENTO

            HabilitarFechasFormulario("FechaConstitucionGarantia", true, true);
            HabilitarFechasFormulario("FechaVencimiento", true, true);

            #endregion

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //REQUERIMIENTO: 1-24653531
    private void InsertarExcepcionOtrosValoresExcepcion()
    {
        try
        {
            #region LIMPIAR MENSAJES

            //LIMPIA LA ETIQUETA SUPERIOR DEL MENSAJE DE ERROR
            if (lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError") && this.divBarraMensaje.Visible)
            {
                this.divBarraMensaje.Visible = false;
            }

            #endregion

            #region CONTROLES CUSTOM BUSQUEDA / ID GARANTÍA BCR

            this.tableData.FindControl("trBusqueda").Visible = false;
            ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Enabled = true;
            ((RequiredFieldValidator)this.tableData.FindControl("rfvCodGarantiaBCR")).Enabled = true;

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

            #region ISIN / SERIE / ID GARANTIA / CLASIFICACION INSTRUMENTO

            TextBox txtPremio = ((TextBox)this.tableData.FindControl("Premio"));
            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            TextBox txtSerie = ((TextBox)this.tableData.FindControl("txtCustomSerie"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("ddlCustomSerie"));
            TextBox txtClasifInstrum = ((TextBox)this.tableData.FindControl("txtCustomClasificacionInstrumento"));
            DropDownList ddlClasifInstrum = ((DropDownList)this.tableData.FindControl("ddlCustomClasificacionInstrumento"));

            ddlISIN.Enabled = false;

            #region VALIDACION SERIE

            txtSerie.Enabled = false;
            txtSerie.Visible = true;
            txtSerie.Text = string.Empty;

            ddlSerie.Enabled = false;
            ddlSerie.Visible = false;

            #endregion

            txtClasifInstrum.Visible = false;
            ddlClasifInstrum.Visible = true;
            LimpiarDropDownList(ddlISIN);
            LimpiarDropDownList(ddlSerie);
            generadorControles.SeleccionarOpcionDropDownListTexto(ddlISIN1, "NO");
            CargarIdgarantia();

            #endregion

            #region TIPO PERSONA / IDENTIFICACION EMISOR / IDENTIFICACION INSTRUMENTO / PREMIO

            TextBox txtIdentificacionEmisor = ((TextBox)this.tableData.FindControl("IdentificacionEmisor"));
            TextBox txtIdentificacionInstrumento = ((TextBox)this.tableData.FindControl("IdentificacionInstrumento"));

            txtPremio.Enabled = true;
            txtIdentificacionInstrumento.Enabled = false;
            CargarDropDownIdentificacionEmisor(ddlEmisor);

            txtIdentificacionEmisor.Enabled = true;
            CargarIdentificacionInstrumento(ddlInstrum);
            AsignarTipoPersona();

            #endregion

            #region TIPO ASIGNACION CALIFICACION / PLAZO CALIFICACION / EMPRESA CALIFICADORA / CATEGORIA CALIFICACION / CALIFICACION RIESGO

            DropDownList ddlTipoAsignacionCalificacion = ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion"));
            DropDownList ddlPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            if (ddlTipoAsignacionCalificacion != null)
            {
                ddlTipoAsignacionCalificacion.SelectedIndex = -1;
            }
            if (ddlPlazoCalificacion != null)
            {
                AdministrarBlanco("IdPlazoCalificacion", true);
                ddlPlazoCalificacion.Enabled = false;
            }
            if (ddlEmpresaCalificadora != null)
            {
                AdministrarBlanco("IdEmpresaCalificadora", true);
                ddlEmpresaCalificadora.Enabled = false;
            }
            if (ddlCalificacionEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCalificacionEmpresaCalificadora);
                AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
                ddlCalificacionEmpresaCalificadora.Enabled = false;
            }
            if (ddlCategoriaRiesgoEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCategoriaRiesgoEmpresaCalificadora);
                AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
                ddlCategoriaRiesgoEmpresaCalificadora.Enabled = false;
            }

            #endregion

            #region VALORES MONEDAS

            TextBox txtMonedaValorFacial = (TextBox)(this.tableData.FindControl("MontoValorFacial"));
            TextBox txtMontoValorMercado = (TextBox)(this.tableData.FindControl("MontoValorMercado"));

            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));

            //RequiredFieldValidator rfvMontoValorFacial = (RequiredFieldValidator)(this.tableData.FindControl("rfvMontoValorFacial"));
            //RequiredFieldValidator rfvMontoValorMercado = (RequiredFieldValidator)(this.tableData.FindControl("rfvMontoValorMercado"));

            ddlMonedaValorFacial.Enabled = true;
            txtMonedaValorFacial.Enabled = true;
            //rfvMontoValorFacial.Enabled = true;

            txtMontoValorMercado.Enabled = true;
            //rfvMontoValorMercado.Enabled = true;
            ddlMonedaValorMercado.Enabled = false;

            CargarMoneda("MonedasLista");
            string seleccionado = ddlMonedaValorFacial.SelectedValue;
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, seleccionado);

            #endregion

            #region FECHA CONSTITUCION / FECHA VENCIMIENTO

            HabilitarFechasFormulario("FechaConstitucionGarantia", true, true);
            HabilitarFechasFormulario("FechaVencimiento", false, true);

            string tipoInstrumento = ddlTipoInstrum.SelectedItem.Text;
            if (tipoInstrumento.Contains("ACCIO") || tipoInstrumento.Contains("TPART"))
                HabilitarFechasFormularioVencimiento(false, true);
            else
                HabilitarFechasFormularioVencimiento(true, true);

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //REQUERIMIENTO: 1-24653531
    private void InsertarExcepcionBusquedaConISIN(Boolean valorCheck)
    {
        try
        {
            #region VALIDACION CONTROLES COMBOBOXES

            ((DropDownList)this.tableData.FindControl("IdTipoInstrumento")).Enabled = valorCheck;
            ((DropDownList)this.tableData.FindControl("IdInstrumento")).Enabled = valorCheck;
            ((DropDownList)this.tableData.FindControl("IdEmisor")).Enabled = valorCheck;
            ((DropDownList)this.tableData.FindControl("ISIN1")).Enabled = valorCheck;
            ((DropDownList)this.tableData.FindControl("ISIN")).Enabled = valorCheck;

            ((DropDownList)this.tableData.FindControl("ddlCustomClasificacionInstrumento")).Visible = false;
            ((DropDownList)this.tableData.FindControl("IdTipoPersonaEmisor")).Enabled = valorCheck;

            ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion")).Enabled = valorCheck;
            ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion")).Enabled = valorCheck;
            ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora")).Enabled = valorCheck;
            ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora")).Enabled = valorCheck;
            ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora")).Enabled = valorCheck;

            AdministrarBlanco("IdTipoInstrumento", !valorCheck);
            AdministrarBlanco("IdInstrumento", !valorCheck);
            AdministrarBlanco("IdEmisor", !valorCheck);
            AdministrarBlanco("ISIN1", !valorCheck);
            AdministrarBlanco("ISIN", !valorCheck);
            AdministrarBlanco("IdTipoPersonaEmisor", !valorCheck);
            AdministrarBlanco("IdTipoAsignacionCalificacion", !valorCheck);
            AdministrarBlanco("IdPlazoCalificacion", !valorCheck);
            AdministrarBlanco("IdEmpresaCalificadora", !valorCheck);
            AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", !valorCheck);
            AdministrarBlanco("IdCalificacionEmpresaCalificadora", !valorCheck);

            #endregion
            #region VALIDACION SERIE

            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Enabled = false;
            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Visible = true;
            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Text = string.Empty;

            ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Visible = false;

            #endregion
            #region VALIDACION CONTROLES TEXTBOXES

            ((TextBox)this.tableData.FindControl("txtCustomClasificacionInstrumento")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("txtCustomClasificacionInstrumento")).Visible = !valorCheck;

            ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Enabled = valorCheck;
            ((TextBox)this.tableData.FindControl("CodGarantia")).Enabled = valorCheck;
            ((TextBox)this.tableData.FindControl("IdentificacionEmisor")).Enabled = valorCheck;
            ((TextBox)this.tableData.FindControl("IdentificacionInstrumento")).Enabled = valorCheck;

            ((TextBox)this.tableData.FindControl("Premio")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("CodGarantia")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("IdentificacionEmisor")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("IdentificacionInstrumento")).Text = string.Empty;

            #endregion
            #region LIMPIAR VALORES MONEDAS

            TextBox txtMonedaValorFacial = (TextBox)(this.tableData.FindControl("MontoValorFacial"));
            AdministrarBlanco("IdMonedaValorFacial", !valorCheck);
            txtMonedaValorFacial.Text = string.Empty;
            txtMonedaValorFacial.Enabled = valorCheck;

            TextBox txtMonedaValorMercado = (TextBox)(this.tableData.FindControl("MontoValorMercado"));
            AdministrarBlanco("IdMonedaValorMercado", !valorCheck);
            txtMonedaValorMercado.Text = string.Empty;
            txtMonedaValorMercado.Enabled = valorCheck;

            #endregion
            #region FECHA MERCADO / FECHA CONSTITUCION / FECHA VENCIMIENTO

            HabilitarFechasFormulario("FechaValorMercado", valorCheck, true);
            HabilitarFechasFormulario("FechaConstitucionGarantia", valorCheck, true);
            HabilitarFechasFormulario("FechaVencimiento", valorCheck, true);

            ((RequiredFieldValidator)this.tableData.FindControl("rfvFechaValorMercado")).Enabled = true;
            ((RequiredFieldValidator)this.tableData.FindControl("rfvFechaConstitucionGarantia")).Enabled = true;
            ((RequiredFieldValidator)this.tableData.FindControl("rfvFechaVencimiento")).Enabled = valorCheck;

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //REQUERIMIENTO: 1-24653531
    private void InsertarExcepcionBusquedaSinISIN(Boolean valorCheck)
    {
        try
        {
            #region BUSCAR CONTROLES

            CheckBox chkBusquedaISIN = (CheckBox)(this.tableData.FindControl("chkCustomBusqueda"));
            DropDownList ddlTipoInstrum = ((DropDownList)this.tableData.FindControl("IdTipoInstrumento"));
            DropDownList ddlInstrum = ((DropDownList)this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlEmisor = ((DropDownList)this.tableData.FindControl("IdEmisor"));
            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            TextBox txtSerie = ((TextBox)this.tableData.FindControl("txtCustomSerie"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("ddlCustomSerie"));
            DropDownList ddlTipoPersona = ((DropDownList)this.tableData.FindControl("IdTipoPersonaEmisor"));

            DropDownList ddlClasificacionInstrumento = (DropDownList)(this.tableData.FindControl("ddlCustomClasificacionInstrumento"));
            DropDownList ddlTipoAsignacionCalificacion = ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion"));
            DropDownList ddlPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));

            TextBox txtCodGarantiaBCR = ((TextBox)this.tableData.FindControl("CodGarantiaBCR"));
            TextBox txtIdGarantia = ((TextBox)this.tableData.FindControl("CodGarantia"));
            TextBox txtIdentificacionEmisor = ((TextBox)this.tableData.FindControl("IdentificacionEmisor"));
            TextBox txtIdentificacionInstrumento = ((TextBox)this.tableData.FindControl("IdentificacionInstrumento"));
            TextBox txtClasificacionInstrumento = (TextBox)(this.tableData.FindControl("txtCustomClasificacionInstrumento"));

            TextBox txtMonedaValorFacial = (TextBox)(this.tableData.FindControl("MontoValorFacial"));
            TextBox txtMonedaValorMercado = (TextBox)(this.tableData.FindControl("MontoValorMercado"));

            #endregion

            #region GARANTIA BCR / TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR

            LimpiarContenidoFormulario();
            txtCodGarantiaBCR.Enabled = valorCheck;

            ddlTipoInstrum.Enabled = valorCheck;
            AdministrarBlanco("IdTipoInstrumento", false);
            CargarTipoInstrumento();

            ddlInstrum.Enabled = valorCheck;
            AdministrarBlanco("IdInstrumento", false);
            CargarInstrumento(ddlTipoInstrum);

            ddlEmisor.Enabled = valorCheck;
            //AdministrarBlanco("IdEmisor", false);
            CargarEmisor(ddlInstrum);

            #endregion

            #region ISIN / SERIE / ID GARANTIA / CLASIFICACION INSTRUMENTO / PREMIO

            ddlISIN1.Enabled = false;
            AdministrarBlanco("ISIN1", false);

            ddlISIN.Enabled = valorCheck;
            AdministrarBlanco("ISIN", false);
            CargarISIN(ddlEmisor, ddlInstrum);

            txtSerie.Visible = false;
            txtSerie.Enabled = false;
            ddlSerie.Enabled = true;
            ddlSerie.Visible = true;
            AdministrarBlanco("Serie", true);
            CargarSerieDropBox(ddlInstrum, ddlEmisor, ddlISIN);

            txtIdGarantia.Enabled = false;
            if (ddlISIN1.SelectedItem.Text.Equals("SI"))
            {
                txtIdGarantia.Text = ((DropDownList)this.tableData.FindControl("ISIN")).Text;
            }
            else
            {
                txtIdGarantia.Text = ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Text;
            }

            txtClasificacionInstrumento.Visible = true;
            ddlClasificacionInstrumento.Visible = false;

            CargarClasificacionPremio(ddlInstrum, ddlEmisor, ddlISIN, ddlSerie);

            #endregion

            #region TIPO PERSONA / IDENTIFICACION EMISOR / IDENTIFICACION INSTRUMENTO

            AdministrarBlanco("IdTipoPersonaEmisor", false);
            AsignarTipoPersona();
            //ddlTipoPersona.Enabled = valorCheck;
            ddlTipoPersona.Enabled = false;

            txtIdentificacionEmisor.Enabled = valorCheck;
            CargarDropDownIdentificacionEmisor(ddlEmisor);

            txtIdentificacionInstrumento.Enabled = false;
            txtIdentificacionInstrumento.Text = generadorControles.BuscaCadenaConSubstring(ddlInstrum.SelectedItem.ToString().Trim(), " - ");

            #endregion

            #region TIPO ASIGNACION CALIFICACION / PLAZO CALIFICACION / EMPRESA CALIFICADORA / CATEGORIA CALIFICACION / CALIFICACION RIESGO

            ddlTipoAsignacionCalificacion.Enabled = valorCheck;
            AdministrarBlanco("IdTipoAsignacionCalificacion", false);
            if (ddlTipoAsignacionCalificacion != null)
            {
                ddlTipoAsignacionCalificacion.SelectedIndex = -1;
            }
            if (ddlPlazoCalificacion != null)
            {
                AdministrarBlanco("IdPlazoCalificacion", true);
                ddlPlazoCalificacion.Enabled = false;
            }
            if (ddlEmpresaCalificadora != null)
            {
                AdministrarBlanco("IdEmpresaCalificadora", true);
                ddlEmpresaCalificadora.Enabled = false;
            }
            if (ddlCalificacionEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCalificacionEmpresaCalificadora);
                AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
                ddlCalificacionEmpresaCalificadora.Enabled = false;
            }
            if (ddlCategoriaRiesgoEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCategoriaRiesgoEmpresaCalificadora);
                AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
                ddlCategoriaRiesgoEmpresaCalificadora.Enabled = false;
            }

            #endregion

            #region MONEDA VALOR FACIAL / MONEDA VALOR MERCADO

            CargarMoneda("TiposMonedasLista");

            txtMonedaValorFacial.Enabled = true;
            AdministrarBlanco("IdMonedaValorFacial", false);
            ddlMonedaValorFacial.Enabled = false;

            txtMonedaValorMercado.Enabled = true;
            AdministrarBlanco("IdMonedaValorMercado", false);
            ddlMonedaValorMercado.Enabled = false;

            string seleccionado = ddlMonedaValorFacial.SelectedValue;
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, seleccionado);

            #endregion

            #region FECHA MERCADO / FECHA CONSTITUCION / FECHA VENCIMIENTO

            HabilitarFechasFormulario("FechaValorMercado", true, true);
            HabilitarFechasFormulario("FechaConstitucionGarantia", true, true);
            HabilitarFechasFormulario("FechaVencimiento", false, true);

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //REQUERIMIENTO: 1-24653531
    private void InsertarExcepcionBusquedaCDP(GarantiasValoresRespuestaCDPEntidad _entidadCDP)
    {
        if (_entidadCDP != null)
        {
            #region GARANTIA BCR / GARANTIA

            ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Text = _entidadCDP.NumeroCDP.ToString();
            ((TextBox)this.tableData.FindControl("CodGarantia")).Text = _entidadCDP.NumeroCDP.ToString();

            #endregion
            #region VALOR FACIAL / VALOR MERCADO

            ((TextBox)this.tableData.FindControl("MontoValorFacial")).Text = String.Format("{0:N}", _entidadCDP.MontoCDP);
            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorFacial, _entidadCDP.MonedaCDP.ToString());
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, _entidadCDP.MonedaCDP.ToString());

            #endregion
            #region FECHA CONSTITUCION / FECHA VENCIMIENTO

            ((TextBox)this.tableData.FindControl("FechaConstitucionGarantia")).Text = _entidadCDP.FechaEmisionCDP.ToShortDateString();
            ((TextBox)this.tableData.FindControl("FechaVencimiento")).Text = _entidadCDP.FechaVencimientoCDP.ToShortDateString();

            #endregion
        }
        else
        {
            #region GARANTIA BCR / GARANTIA

            ((TextBox)this.tableData.FindControl("CodGarantiaBCR")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("CodGarantia")).Text = string.Empty;

            #endregion
            #region TIPO ASIGNACION CALIFICACION / PLAZO CALIFICACION / EMPRESA CALIFICADORA / CATEGORIA CALIFICACION / CALIFICACION RIESGO

            DropDownList ddlTipoAsignacionCalificacion = ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion"));
            DropDownList ddlPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            ddlTipoAsignacionCalificacion.Enabled = true;
            AdministrarBlanco("IdTipoAsignacionCalificacion", false);
            if (ddlTipoAsignacionCalificacion != null)
            {
                ddlTipoAsignacionCalificacion.SelectedIndex = -1;
            }

            if (ddlPlazoCalificacion != null)
            {
                AdministrarBlanco("IdPlazoCalificacion", true);
                ddlPlazoCalificacion.Enabled = false;
            }

            if (ddlEmpresaCalificadora != null)
            {
                AdministrarBlanco("IdEmpresaCalificadora", true);
                ddlEmpresaCalificadora.Enabled = false;
            }

            if (ddlCalificacionEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCalificacionEmpresaCalificadora);
                AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
                ddlCalificacionEmpresaCalificadora.Enabled = false;
            }

            if (ddlCategoriaRiesgoEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCategoriaRiesgoEmpresaCalificadora);
                AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
                ddlCategoriaRiesgoEmpresaCalificadora.Enabled = false;
            }

            #endregion
            #region VALOR FACIAL / VALOR MERCADO

            ((TextBox)this.tableData.FindControl("MontoValorFacial")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("MontoValorMercado")).Text = string.Empty;
            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorFacial, "1");
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, "1");

            #endregion
            #region FECHA VALOR MERCADO / FECHA CONSTITUCION / FECHA VENCIMIENTO

            ((TextBox)this.tableData.FindControl("FechaValorMercado")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("FechaConstitucionGarantia")).Text = string.Empty;
            ((TextBox)this.tableData.FindControl("FechaVencimiento")).Text = string.Empty;

            #endregion
        }
    }

    //REQUERIMIENTO: 1-24653531
    private void InsertarExcepcionResultadoISIN(GarantiasValoresRespuestaISINEntidad _entidadISIN)
    {
        try
        {
            #region BUSCAR CONTROLES

            DropDownList ddlTipoInstrumento = ((DropDownList)this.tableData.FindControl("IdTipoInstrumento"));
            DropDownList ddlInstrumento = ((DropDownList)this.tableData.FindControl("IdInstrumento"));
            DropDownList ddlEmisor = ((DropDownList)this.tableData.FindControl("IdEmisor"));
            DropDownList ddlISIN1 = ((DropDownList)this.tableData.FindControl("ISIN1"));
            DropDownList ddlISIN = ((DropDownList)this.tableData.FindControl("ISIN"));
            DropDownList ddlSerie = ((DropDownList)this.tableData.FindControl("ddlCustomSerie"));
            DropDownList ddlTipoPersona = ((DropDownList)this.tableData.FindControl("IdTipoPersonaEmisor"));

            DropDownList ddlClasifInstrum = (DropDownList)(this.tableData.FindControl("ddlCustomClasificacionInstrumento"));
            DropDownList ddlTipoAsignacionCalificacion = ((DropDownList)this.tableData.FindControl("IdTipoAsignacionCalificacion"));
            DropDownList ddlPlazoCalificacion = ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion"));
            DropDownList ddlEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdEmpresaCalificadora"));
            DropDownList ddlCategoriaRiesgoEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"));
            DropDownList ddlCalificacionEmpresaCalificadora = ((DropDownList)this.tableData.FindControl("IdCalificacionEmpresaCalificadora"));

            TextBox txtCodGarantiaBCR = ((TextBox)this.tableData.FindControl("CodGarantiaBCR"));
            TextBox txtIdGarantia = ((TextBox)this.tableData.FindControl("CodGarantia"));
            TextBox txtIdentificacionEmisor = ((TextBox)this.tableData.FindControl("IdentificacionEmisor"));
            TextBox txtIdentificacionInstrumento = ((TextBox)this.tableData.FindControl("IdentificacionInstrumento"));
            TextBox txtClasifInstrum = (TextBox)(this.tableData.FindControl("txtCustomClasificacionInstrumento"));
            TextBox txtPremio = (TextBox)(this.tableData.FindControl("Premio"));
            TextBox txtSerie = ((TextBox)this.tableData.FindControl("txtCustomSerie"));

            #endregion

            #region GARANTIA BCR / TIPO INSTRUMENTO / INSTRUMENTOS / EMISOR / ISIN

            LimpiarContenidoFormulario();
            txtCodGarantiaBCR.Enabled = true;

            AdministrarBlanco("IdTipoInstrumento", false);
            CargarTipoInstrumento();
            ddlTipoInstrumento.Enabled = false;
            generadorControles.SeleccionarOpcionDropDownList(ddlTipoInstrumento, _entidadISIN.IdTipoInstrumento.ToString());

            AdministrarBlanco("IdInstrumento", false);
            CargarInstrumento(ddlTipoInstrumento);
            ddlInstrumento.Enabled = false;
            generadorControles.SeleccionarOpcionDropDownList(ddlInstrumento, _entidadISIN.IdInstrumento.ToString());

            CargarEmisor(ddlInstrumento);
            ddlEmisor.Enabled = false;
            generadorControles.SeleccionarOpcionDropDownList(ddlEmisor, _entidadISIN.IdEmisor.ToString());

            AdministrarBlanco("ISIN1", false);
            AdministrarBlanco("ISIN", false);
            CargarISIN(ddlEmisor, ddlInstrumento);
            ddlISIN1.Enabled = false;
            ddlISIN.Enabled = false;
            generadorControles.SeleccionarOpcionDropDownList(ddlISIN, _entidadISIN.ISIN);

            #endregion

            #region SERIE / ID GARANTIA / CLASIFICACION INSTRUMENTO / PREMIO

            #region VALIDACION SERIE

            txtSerie.Enabled = false;
            txtSerie.Visible = true;
            txtSerie.Text = string.Empty;

            ddlSerie.Enabled = false;
            ddlSerie.Visible = false;

            #endregion

            txtIdGarantia.Enabled = false;
            txtClasifInstrum.Visible = true;
            ddlClasifInstrum.Visible = false;
            CargarSerieTextBox(ddlInstrumento, ddlEmisor, ddlISIN);
            CargarClasificacionPremio(ddlInstrumento, ddlEmisor, ddlISIN, ddlSerie);

            txtClasifInstrum.Text = _entidadISIN.ClasificacionInstrumento;
            txtPremio.Text = _entidadISIN.Premio.ToString();
            txtIdGarantia.Text = _entidadISIN.ISIN;

            #endregion

            #region TIPO PERSONA / IDENTIFICACION EMISOR / IDENTIFICACION INSTRUMENTO

            AdministrarBlanco("IdTipoPersonaEmisor", false);
            AsignarTipoPersona();
            txtIdentificacionEmisor.Enabled = false;
            CargarDropDownIdentificacionEmisor(ddlEmisor);

            txtIdentificacionInstrumento.Enabled = false;
            txtIdentificacionInstrumento.Text = generadorControles.BuscaCadenaConSubstring(ddlInstrumento.SelectedItem.ToString().Trim(), " - ");

            #endregion

            #region TIPO ASIGNACION CALIFICACION / PLAZO CALIFICACION / EMPRESA CALIFICADORA / CATEGORIA CALIFICACION / CALIFICACION RIESGO

            ddlTipoAsignacionCalificacion.Enabled = true;
            AdministrarBlanco("IdTipoAsignacionCalificacion", false);
            if (ddlTipoAsignacionCalificacion != null)
            {
                ddlTipoAsignacionCalificacion.SelectedIndex = -1;
            }

            if (ddlPlazoCalificacion != null)
            {
                AdministrarBlanco("IdPlazoCalificacion", true);
                ddlPlazoCalificacion.Enabled = false;
            }

            if (ddlEmpresaCalificadora != null)
            {
                AdministrarBlanco("IdEmpresaCalificadora", true);
                ddlEmpresaCalificadora.Enabled = false;
            }

            if (ddlCalificacionEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCalificacionEmpresaCalificadora);
                AdministrarBlanco("IdCalificacionEmpresaCalificadora", true);
                ddlCalificacionEmpresaCalificadora.Enabled = false;
            }

            if (ddlCategoriaRiesgoEmpresaCalificadora != null)
            {
                LimpiarDropDownList(ddlCategoriaRiesgoEmpresaCalificadora);
                AdministrarBlanco("IdCategoriaRiesgoEmpresaCalificadora", true);
                ddlCategoriaRiesgoEmpresaCalificadora.Enabled = false;
            }

            #endregion

            #region MONEDA VALOR FACIAL / MONEDA VALOR MERCADO

            TextBox txtMonedaValorFacial = (TextBox)(this.tableData.FindControl("MontoValorFacial"));
            TextBox txtMonedaValorMercado = (TextBox)(this.tableData.FindControl("MontoValorMercado"));
            DropDownList ddlMonedaValorFacial = (DropDownList)(this.tableData.FindControl("IdMonedaValorFacial"));
            DropDownList ddlMonedaValorMercado = (DropDownList)(this.tableData.FindControl("IdMonedaValorMercado"));

            txtMonedaValorFacial.Enabled = true;
            txtMonedaValorMercado.Enabled = true;
            string seleccionado = _entidadISIN.IdMonedaValorFacial.ToString();
            AdministrarBlanco("IdMonedaValorFacial", false);
            AdministrarBlanco("IdMonedaValorMercado", false);
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorFacial, seleccionado);
            generadorControles.SeleccionarOpcionDropDownList(ddlMonedaValorMercado, seleccionado);

            #endregion

            #region FECHA MERCADO / FECHA CONSTITUCION / FECHA VENCIMIENTO

            HabilitarFechasFormulario("FechaValorMercado", true, true);
            HabilitarFechasFormulario("FechaConstitucionGarantia", true, true);
            HabilitarFechasFormulario("FechaVencimiento", false, true);

            if (_entidadISIN.FechaVencimiento.ToString().Length > 0)
                ((TextBox)this.tableData.FindControl("FechaVencimiento")).Text = DateTime.Parse(_entidadISIN.FechaVencimiento.ToString()).ToShortDateString();

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion
    #region MODIFICAR FORMULARIO

    //REQUERIMIENTO: 1-24653531
    private void ModificacionExcepcionOtrosValores()
    {
        try
        {
            #region ASIGNACION CONTROLES

            ((TextBox)this.tableData.FindControl("txtCustomBusqueda")).Enabled = false;
            ((CheckBox)this.tableData.FindControl("chkCustomBusqueda")).Enabled = false;
            ((RequiredFieldValidator)this.tableData.FindControl("rfvBusqueda")).EnableClientScript = false;
            ((RequiredFieldValidator)this.tableData.FindControl("rfvBusqueda")).Visible = false;

            ((DropDownList)this.tableData.FindControl("ISIN")).Enabled = false;
            ((TextBox)this.tableData.FindControl("IdentificacionEmisor")).Enabled = false;
            ((TextBox)this.tableData.FindControl("Premio")).Enabled = false;
            ((TextBox)this.tableData.FindControl("IdentificacionInstrumento")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("IdMonedaValorFacial")).Enabled = false;
            ((TextBox)this.tableData.FindControl("FechaVencimiento")).Enabled = false;

            AsignarTipoPersona();

            if (ObtenerCheckBoxBusqueda())
            {
                ((TextBox)this.tableData.FindControl("txtCustomSerie")).Enabled = false;
                ((TextBox)this.tableData.FindControl("txtCustomSerie")).Visible = true;

                ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Enabled = false;
                ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Visible = false;
            }
            else
            {
                ((TextBox)this.tableData.FindControl("txtCustomSerie")).Enabled = false;
                ((TextBox)this.tableData.FindControl("txtCustomSerie")).Visible = false;

                ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Enabled = false;
                ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Visible = true;
            }

            //javendano
            HabilitarFechasFormulario("FechaValorMercado", true, false);

            HabilitarFechasFormulario("FechaConstitucionGarantia", true, false);

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //REQUERIMIENTO: 1-24653531
    private void ModificacionExcepcionCDPBCR()
    {
        try
        {
            #region BUSQUEDA CONTROLES

            ((CheckBox)this.tableData.FindControl("chkCustomBusqueda")).Enabled = false;
            ((TextBox)this.tableData.FindControl("txtCustomBusqueda")).Enabled = false;
            ((RequiredFieldValidator)this.tableData.FindControl("rfvBusqueda")).EnableClientScript = false;
            ((DropDownList)this.tableData.FindControl("ISIN")).Enabled = false;
            ((TextBox)this.tableData.FindControl("txtCustomClasificacionInstrumento")).Enabled = false;
            ((TextBox)this.tableData.FindControl("txtCustomClasificacionInstrumento")).Visible = true;
            ((DropDownList)this.tableData.FindControl("IdTipoPersonaEmisor")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("IdMonedaValorFacial")).Enabled = false;
            ((TextBox)this.tableData.FindControl("IdentificacionEmisor")).Enabled = false;
            ((TextBox)this.tableData.FindControl("IdentificacionInstrumento")).Enabled = false;
            ((TextBox)this.tableData.FindControl("MontoValorFacial")).Enabled = false;
            ((TextBox)this.tableData.FindControl("Premio")).Enabled = true;
            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Enabled = false;
            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Visible = true;
            ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Visible = false;

            CargarMoneda("MonedasLista");

            //javendano
            HabilitarFechasFormulario("FechaValorMercado", true, false);

            HabilitarFechasFormulario("FechaConstitucionGarantia", false, false);
            HabilitarFechasFormulario("FechaVencimiento", false, false);

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ModificacionExcepcionCDPOtrosEmisores()
    {
        try
        {
            #region BUSQUEDA CONTROLES

            this.tableData.FindControl("trBusqueda").Visible = false;
            ((DropDownList)this.tableData.FindControl("ISIN")).Enabled = false;
            ((TextBox)this.tableData.FindControl("Premio")).Enabled = true;
            ((DropDownList)this.tableData.FindControl("IdTipoPersonaEmisor")).Enabled = false;
            ((TextBox)this.tableData.FindControl("IdentificacionEmisor")).Enabled = false;
            ((TextBox)this.tableData.FindControl("IdentificacionInstrumento")).Enabled = false;
            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Enabled = false;
            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Visible = true;
            ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Visible = false;

            CargarMoneda("MonedasLista");

            //javendano
            HabilitarFechasFormulario("FechaValorMercado", true, false);

            HabilitarFechasFormulario("FechaConstitucionGarantia", true, false);
            HabilitarFechasFormulario("FechaVencimiento", true, false);

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //REQUERIMIENTO: 1-24653531
    private void ModificacionExcepcionOtrosValoresExcepcion()
    {
        try
        {
            #region BUSQUEDA CONTROLES

            this.tableData.FindControl("trBusqueda").Visible = false;
            ((TextBox)this.tableData.FindControl("IdentificacionEmisor")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("ISIN")).Enabled = false;
            ((TextBox)this.tableData.FindControl("txtCustomClasificacionInstrumento")).Enabled = false;
            ((TextBox)this.tableData.FindControl("txtCustomClasificacionInstrumento")).Visible = false;
            ((DropDownList)this.tableData.FindControl("ddlCustomClasificacionInstrumento")).Enabled = true;
            ((DropDownList)this.tableData.FindControl("ddlCustomClasificacionInstrumento")).Visible = true;
            ((TextBox)this.tableData.FindControl("IdentificacionInstrumento")).Enabled = false;
            ((TextBox)this.tableData.FindControl("Premio")).Enabled = true;
            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Enabled = false;
            ((TextBox)this.tableData.FindControl("txtCustomSerie")).Visible = true;
            ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("ddlCustomSerie")).Visible = false;

            AsignarTipoPersona();
            CargarMoneda("MonedasLista");
            DdlClasificacionInstrumento(null);

            //javendano
            HabilitarFechasFormulario("FechaValorMercado", true, false);

            HabilitarFechasFormulario("FechaConstitucionGarantia", true, false);

            string tipoInstrumento = ((DropDownList)this.tableData.FindControl("IdTipoInstrumento")).SelectedItem.Text;
            if (tipoInstrumento.Contains("ACCIO") || tipoInstrumento.Contains("TPART"))
                HabilitarFechasFormularioVencimiento(false, false);
            else
                HabilitarFechasFormularioVencimiento(true, false);

            #endregion
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

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
            InformarBox1.SetMessageBox(mensaje.DesTipoMensaje, mensaje.DesMensaje.Replace("@@@", valorReemplazo));
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

                if (wsMQBCR != null)
                {
                    wsMQBCR.Dispose();
                    wsMQBCR = null;
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
            pantallasEntidad = null;
            bitacorasEntidad = null;

            disponible = true;
        }
    }

    #endregion



}