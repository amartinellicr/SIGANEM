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
using System.IO;

public partial class FideicomisosNew : System.Web.UI.Page
{
    #region PROPIEDADES

    #region VARIABLES

    private int tipoAccion = 0;
    private int banderaVentana = 0;
    private int resultadoProceso = 0;

    private bool rangoAcept = false;
    private bool rangoFecha = false;
    private bool validaEspecialesIdDueno = false;
    private bool validaEspecialesNombreDueno = false;

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

    #region  GRID ADMINISTRACION DOCUMENTOS ADJUNTOS

    private Button btnBuscarDocumentoAdjunto = null;
    private Button btnEliminarDocumentoAdjunto = null;
    private Button btnAgregarDocumentoAdjunto = null;

    #endregion

    #region  GRID ADMINISTRACION PRIORIDADES

    private Button btnAgregarPrioridad = null;
    private Button btnEliminarPrioridad = null;
    private Button btnModificarPrioridad = null;

    #endregion

    #region  GRID ADMINISTRACION GARANTÍA FIDEICOMETIDA

    private Button btnAgregarGarantiaFideicometida = null;
    private Button btnEliminarGarantiaFideicometida = null;
    private Button btnModificarGarantiaFideicometida = null;

    #endregion

    #region  VENTANA PRIORIDADES

    private Button btnPrioridadesAceptar = null;
    private Button btnPrioridadesCancelar = null;

    #endregion

    #region  VENTANA FIDEICOMETIDAS VALOR

    private Button btnFideicometidasValorAceptar = null;
    private Button btnFideicometidasValorCancelar = null;

    #endregion

    #region VENTANA FIDEICOMETIDAS REALES

    Button btnAceptarReales = null;

    #endregion

    #region GRID ADMINISTRACION DOCUMENTOS ADJUNTOS

    private GridView gridDocumentosAdjuntosInterno = null;

    #endregion

    #region GRID ADMINISTRACION PRIORIDADES

    private GridView gridPrioridadesInterno = null;

    #endregion

    #region GRID ADMINISTRACION GARANTÍA FIDEICOMETIDA

    private GridView gridGarantiasFideicometidasInterno = null;

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

            // ASIGNA CONTROL Y EVENTO AL BOTON DE MODIFICAR
            this.btnAyudaCerrar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAyuda").FindControl("cmdAyudaRegresar"));
            this.btnAyudaCerrar.Click += new EventHandler(btnAyudaCerrar_Click);
            this.btnAyudaCerrar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR PRINCIPAL
            this.btnGuardar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardar"));
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);
            this.btnGuardar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE LIMPIAR
            this.btnLimpiarR = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesLimpiar"));
            this.btnLimpiarR.Click += new EventHandler(btnLimpiarR_Click);
            this.btnLimpiarR.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR Y NUEVO
            this.btnGuardarNuevo = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardarNuevo"));
            this.btnGuardarNuevo.Click += new EventHandler(btnGuardarNuevo_Click);
            this.btnGuardarNuevo.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE GUARDAR Y CERRAR
            this.btnGuardarCerrar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesGuardarCerrar"));
            this.btnGuardarCerrar.Click += new EventHandler(btnGuardarCerrar_Click);
            this.btnGuardarCerrar.CausesValidation = false;

            // ASIGNA CONTROL Y EVENTO AL BOTON DE CANCELAR
            this.btnCancelar = ((Button)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("cmdAccionesRegresar"));
            this.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            this.btnCancelar.CausesValidation = false;

            #endregion

            #region GRID ADMINISTRAR DOCUMENTOS ADJUNTOS

            this.btnBuscarDocumentoAdjunto = ((Button)this.grdDocumentosAdjuntos.FindControl("imgCmdBuscar"));
            this.btnBuscarDocumentoAdjunto.Click += new EventHandler(btnBuscarDocumentoAdjunto_Click);
            this.btnBuscarDocumentoAdjunto.CausesValidation = false;
            this.btnBuscarDocumentoAdjunto.Visible = true;
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);

            this.btnEliminarDocumentoAdjunto = ((Button)this.grdDocumentosAdjuntos.FindControl("imgCmdEliminar"));
            this.btnEliminarDocumentoAdjunto.Click += new EventHandler(btnEliminarDocumentoAdjunto_Click);
            this.btnEliminarDocumentoAdjunto.CausesValidation = false;

            this.btnAgregarDocumentoAdjunto = ((Button)this.grdDocumentosAdjuntos.FindControl("imgCmdAgregar"));
            this.btnAgregarDocumentoAdjunto.CausesValidation = false;
            this.btnAgregarDocumentoAdjunto.Visible = false;

            #endregion

            #region GRID ADMINISTRAR PRIORIDADES

            this.btnAgregarPrioridad = ((Button)this.grdPrioridad.FindControl("imgCmdAgregar"));
            this.btnAgregarPrioridad.CausesValidation = false;
            this.btnAgregarPrioridad.Click += new EventHandler(btnAgregarPrioridad_Click);

            this.btnEliminarPrioridad = ((Button)this.grdPrioridad.FindControl("imgCmdEliminar"));
            this.btnEliminarPrioridad.CausesValidation = false;
            this.btnEliminarPrioridad.Click += new EventHandler(btnEliminarPrioridad_Click);

            this.btnModificarPrioridad = ((Button)this.grdPrioridad.FindControl("imgCmdModificar"));
            this.btnModificarPrioridad.Visible = true;
            this.btnModificarPrioridad.CausesValidation = false;
            this.btnModificarPrioridad.Click += new EventHandler(btnModificarPrioridad_Click);

            #endregion

            #region GRID ADMINISTRAR GARANTÍA FIDEICOMETIDA

            this.btnAgregarGarantiaFideicometida = ((Button)this.grdGarantiaFideicometida.FindControl("imgCmdAgregar"));
            this.btnAgregarGarantiaFideicometida.CausesValidation = false;
            this.btnAgregarGarantiaFideicometida.Click += new EventHandler(btnAgregarGarantiaFideicometida_Click);

            this.btnEliminarGarantiaFideicometida = ((Button)this.grdGarantiaFideicometida.FindControl("imgCmdEliminar"));
            this.btnEliminarGarantiaFideicometida.CausesValidation = false;
            this.btnEliminarGarantiaFideicometida.Click += new EventHandler(btnEliminarGarantiaFideicometida_Click);

            this.btnModificarGarantiaFideicometida = ((Button)this.grdGarantiaFideicometida.FindControl("imgCmdModificar"));
            this.btnModificarGarantiaFideicometida.Visible = true;
            this.btnModificarGarantiaFideicometida.CausesValidation = false;
            this.btnModificarGarantiaFideicometida.Click += new EventHandler(btnModificarGarantiaFideicometida_Click);

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

            #region MENSAJE ELIMINAR FIDECOMETIDAS

            Button btnAceptarEliminarFidecometidas = (Button)this.MensajeEliminarEliminarFideicometidas.FindControl("wucBtnAceptar");
            btnAceptarEliminarFidecometidas.Click += new EventHandler(btnAceptarEliminarFideicometidas_Click);

            Button btnCancelarEliminarFidecometidas = (Button)this.MensajeEliminarEliminarFideicometidas.FindControl("wucBtnCancelar");
            btnCancelarEliminarFidecometidas.Click += new EventHandler(btnCancelarEliminarFideicometidas_Click);

            #endregion

            #region MENSAJE ELIMINAR PRIORIDADES

            Button btnSiEliminarPrioridades = (Button)this.MensajeConfirmarEliminarPrioridades1.FindControl("wucBtnAceptar");
            btnSiEliminarPrioridades.Click += new EventHandler(btnSiEliminarPrioridades_Click);

            Button btnNoEliminarPrioridades = (Button)this.MensajeConfirmarEliminarPrioridades1.FindControl("wucBtnCancelar");
            btnNoEliminarPrioridades.Click += new EventHandler(btnNoEliminarPrioridades_Click);

            #endregion

            #endregion

            /* b16S02 */
            #region EVENTOS GRIDVIEWS

            //GRID ADMINISTRACION DOCUMENTOS ADJUNTOS
            GridViewAdjuntosInterno(sender, e);

            //GRID ADMINISTRACION PRIORIADADES
            GridViewPrioridadesInterno(sender, e);

            //GRID ADMINISTRACION FIDECOMETIDAS 
            GridViewFideicometidasInterno(sender, e);

            #endregion

            #region VENTANA PRIORIDADES

            #region BOTONES VENTANA PRIORIDADES

            this.btnPrioridadesAceptar = ((Button)this.VentanaPrioridades1.FindControl("btnPrioridadAceptar"));
            this.btnPrioridadesAceptar.Click += new EventHandler(btnPrioridadesAceptar_Click);
            this.btnPrioridadesAceptar.CausesValidation = true;

            this.btnPrioridadesCancelar = ((Button)this.VentanaPrioridades1.FindControl("btnPrioridadCancelar"));
            this.btnPrioridadesCancelar.Click += new EventHandler(btnPrioridadesCancelar_Click);
            this.btnPrioridadesCancelar.CausesValidation = false;

            #endregion

            #endregion

            #region VENTANA FIDECOMETIDAS

            #region BOTONES VENTANA FIDECOMETIDAS VALOR

            this.btnFideicometidasValorAceptar = ((Button)this.GarantiasFideicomisoValores.FindControl("btnAceptarValores"));
            this.btnFideicometidasValorAceptar.Click += new EventHandler(btnFideicometidasValorAceptar_Click);
            this.btnFideicometidasValorAceptar.CausesValidation = true;

            this.btnFideicometidasValorCancelar = ((Button)this.GarantiasFideicomisoValores.FindControl("btnCancelarValores"));
            this.btnFideicometidasValorCancelar.Click += new EventHandler(btnFideicometidasValorCancelar_Click);
            this.btnFideicometidasValorCancelar.CausesValidation = false;

            #endregion

            #region BOTONES VENTANA FIDECOMETIDAS REAL

            this.btnAceptarReales = ((Button)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("btnAceptarReales"));
            btnAceptarReales.Click += new EventHandler(btnAceptarReales_Click);

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
                    // Efectos();

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

    #region VENTANA PRIORIDADES

    protected void btnPrioridadesAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            ObtenerValoresRegistroPrioridades(sender, e);
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnPrioridadesCancelar_Click(object sender, EventArgs e)
    {
        this.mpePrioridades.Hide();
    }

    protected void btnSiEliminarPrioridades_Click(object sender, EventArgs e)
    {
        bool respuesta = true;

        VerficacionSesion(ref respuesta);
        VerficacionGridPrioridadesContadorSeleccionados(ref respuesta);

        if (respuesta)
        {
            if (ddlIndPrioridad.SelectedItem.Text.Equals("SI"))
            {
                foreach (GridViewRow row1 in gridPrioridadesInterno.Rows)
                    EfectuarBorradoPrioridadesIncompleto(row1.RowIndex);
            }

            if (ddlIndPrioridad.SelectedItem.Text.Equals("NO") && (this.grdPrioridad.ContadorElementos() > 0))
            {
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_45");
                this.mpeInformarBox.Show();

                foreach (GridViewRow row1 in gridPrioridadesInterno.Rows)
                    EfectuarBorradoPrioridadesCompleto(row1.RowIndex);
            }

            GridViewPrioridadesInternoActualizar();

            if (this.grdPrioridad.ContadorElementos() == 0)
                AplicarCambioIndPrioridad();
        }
    }

    protected void btnNoEliminarPrioridades_Click(object sender, EventArgs e)
    {
        try
        {
            this.mpeConfirmarEliminarPrioridades.Hide();
            //CLS PNS
            AplicarCambioIndPrioridadSi();
            AdministrarControlesExcepcionesPrioridades(true);
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #endregion

    #region VENTANA FIDECOMETIDAS VALOR

    protected void btnFideicometidasValorAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                string valorSeleccionado = ((HtmlInputHidden)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("estadoGarantiaOculto")).Value;

                #region CREAR LOS PARAMETROS AL POPUP

                StringBuilder sesionBuilder = new StringBuilder();
                sesionBuilder.Append(idSesionOculto.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(pantallaModuloOculto.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(codUsuarioOculto.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(ddlTipoGarantia.SelectedItem.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(int.Parse(this.hdnIdGeneral.Value));

                #endregion

                if (valorSeleccionado.Contains("U"))
                    tipoAccion = 1;
                else
                    tipoAccion = 0;

                ((HtmlInputHidden)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();

                //ID DUEÑO DE GARANTIA FIDEICOMETIDA VAlORES
                TextBox txtIdDueno = ((TextBox)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("txtIdDueno"));

                //NOMBRE DUEÑO DE GARANTIA FIDEICOMETIDA VALORES
                TextBox txtNombreDueno = ((TextBox)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("txtNombreDueno"));

                //VALIDAR CARACTERES ESPECIALES ID DUEÑO
                validaEspecialesIdDueno = ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).ValidarCaracterEspecial(txtIdDueno.Text);

                //VALIDAR CARACTERES ESPECIALES NOMBRE DUEÑO
                validaEspecialesNombreDueno = ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).ValidarCaracterEspecial(txtNombreDueno.Text);

                if (validaEspecialesIdDueno || validaEspecialesNombreDueno)
                {
                    this.mpeValores.Show();

                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_2");
                    this.mpeInformarBox.Show();
                }

                else
                {
                    //VALIDAR RANGO PORCENTAJE ACEPTACION DE 0 A 100
                    bool aceptacionBCR = ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).ValidarPorcentajeAceptacionBCR();
                    bool aceptacionSUGEF = ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).ValidarPorcentajeAceptacionSUGEF();
                    if (!aceptacionBCR && !aceptacionSUGEF)
                    {
                        GarantiasWS.RespuestaEntidad resultado = ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).DeControlesAEntidad(tipoAccion);

                        //IDENTIDAD { 0=NUEVO; X=EDITAR }
                        if (!resultado.ValorError.Equals(0))
                        {
                            this.mpeValores.Show();

                            // MENSAJE DE ERROR
                            ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).DesplegarMensajeError(resultado);
                        }

                        else
                        {
                            //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                            if (resultado.ValorError.Equals(18))
                            {
                                BloquearControlesDesactualizados();
                                BarraMensaje(resultado, pantallaIdOculto.Value);
                            }

                            //SI NO EXISTE ERROR
                            if (resultado.ValorError.Equals(0))
                            {
                                GridViewFideicometidasInternoActualizar();
                                this.mpeValores.Hide();

                                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_1");
                                this.mpeInformarBox.Show();
                            }
                        }
                    }

                    else
                    {
                        this.mpeValores.Show();
                    }
                }
            }

            ((UpdatePanel)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("updValoresPopUpControl")).Update();
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnFideicometidasValorCancelar_Click(object sender, EventArgs e)
    {
        this.mpeValores.Hide();
    }

    #endregion

    #region VENTANA FIDEICOMETIDA REALES

    protected void btnAceptarReales_Click(object sender, EventArgs e)
    {
        try
        {

            GarantiasWS.RespuestaEntidad resultado = null;

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                tipoAccion = 0;
                List<string> valorSeleccionado = ((wucGridControl)this.grdGarantiaFideicometida).ObtenerValoresSeleccionados("lblIdGarantiaFideicomisoFideicometida");

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

                    ((HtmlInputHidden)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                }


                //ID DUEÑO DE GARANTIA FIDEICOMETIDA REALES
                TextBox txtIdDueno = ((TextBox)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("txtIdDueno"));

                //NOMBRE DUEÑO DE GARANTIA FIDEICOMETIDA REALES
                TextBox txtNombreDueno = ((TextBox)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("txtNombreDueno"));

                //VALIDAR CARACTERES ESPECIALES ID DUEÑO
                validaEspecialesIdDueno = ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).ValidarCaracterEspecial(txtIdDueno.Text);

                //VALIDAR CARACTERES ESPECIALES NOMBRE DUEÑO
                validaEspecialesNombreDueno = ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).ValidarCaracterEspecial(txtNombreDueno.Text);

                if (validaEspecialesIdDueno || validaEspecialesNombreDueno)
                {
                    this.mpeFideicomisoReales.Show();

                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_2");
                    this.mpeInformarBox.Show();
                }
                else
                {
                    //VALIDAR RANGO PORCENTAJE ACEPTACION DE 0 A 100
                    rangoAcept = ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).ValidarPorcentajeAceptacion();

                    //VALIDAR RANGO FECHA MENOR O IGUAL A LA FECHA ACTUAL
                    rangoFecha = ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).ValidarRangoFechaMenorIgualFechaActualFR();

                    if (!rangoAcept && !rangoFecha)
                    {
                        resultado = ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).DeControlesAEntidad(tipoAccion);

                        //IDENTIDAD { 0=NUEVO; X=EDITAR }
                        if (!resultado.ValorError.Equals(0))
                        {
                            this.mpeFideicomisoReales.Show();

                            // MENSAJE DE ERROR
                            ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).DesplegarMensajeError(resultado);
                        }
                        else
                        {
                            //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                            if (resultado.ValorError.Equals(18))
                            {
                                BloquearControlesDesactualizados();
                                BarraMensaje(resultado, pantallaIdOculto.Value);
                            }

                            //SI NO EXISTE ERROR
                            if (resultado.ValorError.Equals(0))
                            {
                                GridViewFideicometidasInternoActualizar();
                                this.mpeFideicomisoReales.Hide();

                                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_1");
                                this.mpeInformarBox.Show();
                            }
                        }
                    }

                    else
                    {
                        this.mpeFideicomisoReales.Show();
                    }
                }
            }

            ((UpdatePanel)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("updRealesPopUpControl")).Update();

        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnCancelarReales_Click(object sender, EventArgs e)
    {
        this.mpeFideicomisoReales.Hide();
    }

    #endregion

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

    #endregion

    #region VENTANAS DE MENSAJE ELIMINAR FIDECOMETIDAS

    protected void btnAceptarEliminarFideicometidas_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            if (sesion.Codigo == 0)
            {
                if (this.grdGarantiaFideicometida.ContadorSeleccionados() > 0)
                {
                    GarantiasFideicomisosFideicometidasEntidad entidad = null;
                    foreach (GridViewRow row1 in gridGarantiasFideicometidasInterno.Rows)
                    {
                        CheckBox checkBoxColumn = (CheckBox)gridGarantiasFideicometidasInterno.Rows[row1.RowIndex].FindControl("chkBox1");
                        if (checkBoxColumn.Checked)
                        {
                            Label lblId = (Label)gridGarantiasFideicometidasInterno.Rows[row1.RowIndex].FindControl("lblIdGarantiaFideicomisoFideicometida");

                            entidad = new GarantiasFideicomisosFideicometidasEntidad();
                            entidad.IdGarantiaFideicomisoFideicometida = int.Parse(lblId.Text);
                            entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                            respuesta = wsGarantias.GarantiasFideicomisosFideicometidasEliminar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));

                            //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                            if (respuesta.ValorError.Equals(18))
                            {
                                BloquearControlesDesactualizados();
                                BarraMensaje(respuesta, pantallaIdOculto.Value);
                            }
                        }
                    }

                    GridViewFideicometidasInternoActualizar();
                }
            }
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnCancelarEliminarFideicometidas_Click(object sender, EventArgs e)
    {
        try
        {
            this.mpeConfirmarEliminarFideicometidas.Hide();
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
            GarantiasFideicomisosEntidad resultado = ConsultarDetalleEntidad();

            ObtenerControlRegistros(resultado);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*OBTIENE LOS DATOS DEL CONTROL DE REGISTRO EN MODO EDICION*/
    private void ObtenerControlRegistros(GarantiasFideicomisosEntidad _entidad)
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
            AdministrarControlesExcepcionesGeneral(true);
            AdministrarControlesExcepcionesDocumentosAdjuntos(false);

            this.ddlIndPrioridad.Enabled = false;
            AdministrarControlesExcepcionesPrioridades(false);

            AdministrarControlesExcepcionesGarantiaFideicometida(false);

            if (this.btnValidar.Enabled)
            {
                DeshabilitarControlesGuardar(true);
            }
            else
                DeshabilitarControlesGuardar(false);
        }
    }

    /*DESHABILITA LOS CONTROLES AL INGRESAR A LA PANTALLA*/
    private void HabilitarControlesExcepciones()
    {
        //REGISTRO NUEVO
        if (pantallaIdOculto.Value.Equals("0"))
        {
            AdministrarControlesExcepcionesGeneral(false);
            AdministrarControlesExcepcionesDocumentosAdjuntos(true);

            this.ddlIndPrioridad.Enabled = true;
            AdministrarControlesExcepcionesPrioridades(true);
            IndPrioridadesCambiarIndice(ddlIndPrioridad.SelectedItem.Text);

            AdministrarControlesExcepcionesGarantiaFideicometida(true);
            LimpiarBarraMensaje();

            if (this.btnValidar.Enabled)
            {
                DeshabilitarControlesGuardar(true);
            }
            else
                DeshabilitarControlesGuardar(false);
        }
    }

    /*DESHABILITA LOS BOTONES DE GUARDADO EN EL MENU DE ACCIONES*/
    private void DeshabilitarControlesGuardar(bool deshabilitados)
    {
        ((wucMenuSuperiorDetalle)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesGuardar(deshabilitados);
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION GENERAL*/
    private void AdministrarControlesExcepcionesGeneral(bool habilitado)
    {
        //this.txtIdFideicomisoBCR.Enabled = habilitado;
        this.rfvIdFideicomisoBCR.Enabled = habilitado;
        this.txtIdFideicomiso.Enabled = habilitado;
        this.txtNombreFideicomiso.Enabled = habilitado;
        this.rfvNombreFideicomiso.Enabled = habilitado;
        //this.txtFechaConstitucion.Enabled = habilitado;
        //this.rfvFechaConstitucion.Enabled = habilitado;
        this.imbFechaConstitucion.Enabled = habilitado;
        this.txtFechaVencimiento.Enabled = habilitado;
        this.rfvFechaVencimiento.Enabled = habilitado;
        this.imbFechaVencimiento.Enabled = habilitado;
        //this.ddlTipoMonedaValorNominal.Enabled = habilitado;
        //this.txtValorNominal.Enabled = habilitado;
        //this.txtValorNominal.Enabled = habilitado;
        this.btnValidar.Enabled = habilitado;
        if (pantallaIdOculto.Value.Equals("0"))
        {
            this.txtFechaConstitucion.Enabled = habilitado;
            this.rfvFechaConstitucion.Enabled = habilitado;
            this.imbFechaConstitucion.Enabled = habilitado;
            this.txtFechaVencimiento.Enabled = habilitado;
            this.rfvFechaVencimiento.Enabled = habilitado;
            this.imbFechaVencimiento.Enabled = habilitado;
            //this.btnValidar.Enabled = habilitado;          
        }
        else
        {
            this.txtFechaConstitucion.Enabled = !habilitado;
            this.rfvFechaConstitucion.Enabled = !habilitado;
            this.imbFechaConstitucion.Enabled = !habilitado;
            this.txtFechaVencimiento.Enabled = !habilitado;
            this.rfvFechaVencimiento.Enabled = !habilitado;
            this.imbFechaVencimiento.Enabled = !habilitado;
            //this.btnValidar.Enabled = habilitado;
        }
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION DOCUMENTOS ADJUNTOS*/
    private void AdministrarControlesExcepcionesDocumentosAdjuntos(bool habilitado)
    {
        this.FileUploadRutaArchivo.Enabled = habilitado;
        this.ddlTipoDocumento.Enabled = habilitado;
        this.btnBuscarDocumentoAdjunto.Enabled = habilitado;
        this.btnEliminarDocumentoAdjunto.Enabled = habilitado;
        this.btnAgregar.Enabled = habilitado;

        if (habilitado)
        {
            this.btnBuscarDocumentoAdjunto.CssClass = "imgCmdBuscar";
            this.btnEliminarDocumentoAdjunto.CssClass = "imgCmdEliminar";
            this.btnAgregar.CssClass = "botonAgregar";
        }
        else
        {
            this.btnBuscarDocumentoAdjunto.CssClass = "imgCmdBuscarDisabled";
            this.btnEliminarDocumentoAdjunto.CssClass = "imgCmdEliminarDisabled";
            this.btnAgregar.CssClass = "botonAgregarDisabled";
        }
    }


    /*ADMINISTRA LOS CONTROLES DE LA SECCION PRIORIDADES*/
    private void AdministrarControlesExcepcionesPrioridades(bool habilitado)
    {
        this.btnAgregarPrioridad.Enabled = habilitado;
        this.btnEliminarPrioridad.Enabled = habilitado;
        this.btnModificarPrioridad.Enabled = habilitado;

        if (habilitado)
        {
            this.btnAgregarPrioridad.CssClass = "imgCmdAgregar";
            this.btnEliminarPrioridad.CssClass = "imgCmdEliminar";
            this.btnModificarPrioridad.CssClass = "imgCmdModificar";
        }

        else
        {
            this.btnAgregarPrioridad.CssClass = "imgCmdAgregarDisabled";
            this.btnEliminarPrioridad.CssClass = "imgCmdEliminarDisabled";
            this.btnModificarPrioridad.CssClass = "imgCmdModificarDisabled";
        }
    }

    /*ADMINISTRA LOS CONTROLES DE LA SECCION GARANTÍA FIDEICOMETIDA*/
    private void AdministrarControlesExcepcionesGarantiaFideicometida(bool habilitado)
    {
        this.ddlTipoGarantia.Enabled = habilitado;
        this.btnAgregarGarantiaFideicometida.Enabled = habilitado;
        this.btnEliminarGarantiaFideicometida.Enabled = habilitado;
        this.btnModificarGarantiaFideicometida.Enabled = habilitado;

        if (habilitado)
        {
            this.btnAgregarGarantiaFideicometida.CssClass = "imgCmdAgregar";
            this.btnEliminarGarantiaFideicometida.CssClass = "imgCmdEliminar";
            this.btnModificarGarantiaFideicometida.CssClass = "imgCmdModificar";
        }
        else
        {
            this.btnAgregarGarantiaFideicometida.CssClass = "imgCmdAgregarDisabled";
            this.btnEliminarGarantiaFideicometida.CssClass = "imgCmdEliminarDisabled";
            this.btnModificarGarantiaFideicometida.CssClass = "imgCmdModificarDisabled";
        }
    }

    #endregion

    #region METODOS PERSONALIZADOS NO EDITABLES

    #region VENTANA PRIORIDADES

    /* REALIZA LA ASIGNACION DE VALORES SEGUN EL REGISTRO DE PRIORIDADES */
    private void ObtenerValoresRegistroPrioridades(object sender, EventArgs e)
    {
        try
        {
            #region BUSQUEDA DE CONTROLES

            DropDownList ddlGradoPrioridad = (DropDownList)this.VentanaPrioridades1.FindControl("ddlGradoPrioridad");
            DropDownList ddlTipoMonedaSaldoPrioridad = (DropDownList)this.VentanaPrioridades1.FindControl("ddlTipoMonedaSaldoPrioridad");
            TextBox txtSaldoPrioridad = (TextBox)this.VentanaPrioridades1.FindControl("txtSaldoPrioridad");
            DropDownList ddlTipoPersonaBeneficiario = (DropDownList)this.VentanaPrioridades1.FindControl("ddlTipoPersonaBeneficiario");
            TextBox txtIdBeneficiario = (TextBox)this.VentanaPrioridades1.FindControl("txtIdBeneficiario");
            TextBox txtNombreBeneficiario = (TextBox)this.VentanaPrioridades1.FindControl("txtNombreBeneficiario");
            TextBox txtTipoCambio = (TextBox)this.VentanaPrioridades1.FindControl("txtTipoCambio");
            TextBox txtSaldoColonizado = (TextBox)this.VentanaPrioridades1.FindControl("txtSaldoColonizado");
            HtmlInputHidden hdnPrioridadesOculto = (HtmlInputHidden)this.VentanaPrioridades1.FindControl("hdnIdPrioridadesOculto");

            #endregion

            GarantiasFideicomisosPrioridadesEntidad entidad = new GarantiasFideicomisosPrioridadesEntidad();

            entidad.IdGarantiaFideicomiso = int.Parse(this.hdnIdGeneral.Value);

            if (ddlGradoPrioridad != null)
                entidad.IdTipoGradoPrioridad = int.Parse(ddlGradoPrioridad.SelectedItem.Value);

            if (ddlTipoMonedaSaldoPrioridad != null)
                entidad.IdTipoMonedaSaldoPrioridad = int.Parse(ddlTipoMonedaSaldoPrioridad.SelectedItem.Value);

            if (txtSaldoPrioridad != null)
                entidad.SaldoPrioridad = decimal.Parse(txtSaldoPrioridad.Text);

            if (ddlTipoPersonaBeneficiario != null)
                entidad.IdTipoPersonaBeneficiario = int.Parse(ddlTipoPersonaBeneficiario.SelectedItem.Value);

            if (txtIdBeneficiario != null)
                entidad.IdBeneficiario = txtIdBeneficiario.Text;

            if (txtNombreBeneficiario != null)
                entidad.NombreBenefiario = txtNombreBeneficiario.Text;

            if (txtTipoCambio != null)
                entidad.TipoCambio = (String.IsNullOrEmpty(txtTipoCambio.Text) ? 0 : decimal.Parse(txtTipoCambio.Text));

            if (txtSaldoColonizado != null)
                entidad.SaldoColonizado = (String.IsNullOrEmpty(txtSaldoColonizado.Text) ? 0 : decimal.Parse(txtSaldoColonizado.Text));

            if (hdnPrioridadesOculto != null)
                if (hdnPrioridadesOculto.Value.Length > 0)
                    entidad.IdGarantiaFideicomisosPrioridad = int.Parse(hdnPrioridadesOculto.Value);
                else
                    entidad.IdGarantiaFideicomisosPrioridad = 0;

            //Bloque 7 Requerimiento 1-24381561
            CrearControlRegistros(entidad);

            GarantiasWS.RespuestaEntidad resultado = null;

            if (entidad.IdGarantiaFideicomisosPrioridad.Equals(0))
                resultado = wsGarantias.GarantiasFideicomisoPrioridadesInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));
            else
                resultado = wsGarantias.GarantiasFideicomisoPrioridadesModificar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));

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
                GridViewPrioridadesInternoActualizar();
                AplicarCambioIndPrioridad("SI");

                this.mpePrioridades.Hide();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /* ASIGNACION DE VALORES AL POPUP DE PRIORIDADES SEGUN EL REGISTRO SELECCIONADO */
    private void AsignarValoresRegistroPrioridades()
    {
        #region BUSQUEDA DE CONTROLES

        DropDownList ddlGradoPrioridad = (DropDownList)this.VentanaPrioridades1.FindControl("ddlGradoPrioridad");
        DropDownList ddlTipoMonedaSaldoPrioridad = (DropDownList)this.VentanaPrioridades1.FindControl("ddlTipoMonedaSaldoPrioridad");
        TextBox txtSaldoPrioridad = (TextBox)this.VentanaPrioridades1.FindControl("txtSaldoPrioridad");
        DropDownList ddlTipoPersonaBeneficiario = (DropDownList)this.VentanaPrioridades1.FindControl("ddlTipoPersonaBeneficiario");
        TextBox txtIdBeneficiario = (TextBox)this.VentanaPrioridades1.FindControl("txtIdBeneficiario");
        TextBox txtNombreBeneficiario = (TextBox)this.VentanaPrioridades1.FindControl("txtNombreBeneficiario");
        TextBox txtTipoCambio = (TextBox)this.VentanaPrioridades1.FindControl("txtTipoCambio");
        TextBox txtSaldoColonizado = (TextBox)this.VentanaPrioridades1.FindControl("txtSaldoColonizado");
        HtmlInputHidden hdnIdPrioridadesOculto = (HtmlInputHidden)this.VentanaPrioridades1.FindControl("hdnIdPrioridadesOculto");

        #endregion

        GarantiasFideicomisosPrioridadesEntidad entidad = null;

        foreach (GridViewRow row1 in gridPrioridadesInterno.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)gridPrioridadesInterno.Rows[row1.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                Label lblId = (Label)gridPrioridadesInterno.Rows[row1.RowIndex].FindControl("lblIdGarantiaFideicomisosPrioridad");

                entidad = new GarantiasFideicomisosPrioridadesEntidad();
                entidad.IdGarantiaFideicomisosPrioridad = int.Parse(lblId.Text);

                break;
            }
        }

        if (entidad != null)
        {
            entidad = wsGarantias.GarantiasFideicomisoPrioridadesConsultarDetalle(entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

            //ASIGNA LOS VALORES DESDE BD
            generadorControles.SeleccionarOpcionDropDownList(ddlGradoPrioridad, entidad.IdTipoGradoPrioridad.ToString());
            generadorControles.SeleccionarOpcionDropDownList(ddlTipoMonedaSaldoPrioridad, entidad.IdTipoMonedaSaldoPrioridad.ToString());
            txtSaldoPrioridad.Text = entidad.SaldoPrioridad.ToString();
            generadorControles.SeleccionarOpcionDropDownList(ddlTipoPersonaBeneficiario, entidad.IdTipoPersonaBeneficiario.ToString());
            txtIdBeneficiario.Text = entidad.IdBeneficiario.ToString();
            txtNombreBeneficiario.Text = entidad.NombreBenefiario;
            txtTipoCambio.Text = entidad.TipoCambio.ToString();
            txtSaldoColonizado.Text = entidad.SaldoColonizado.ToString();
            hdnIdPrioridadesOculto.Value = entidad.IdGarantiaFideicomisosPrioridad.ToString();

            this.VentanaPrioridades1.CalculoSaldoPrioridad();

            //MUESTRA EL POPUP
            this.mpePrioridades.Show();
        }
    }

    #endregion

    #region PRIORIDADES

    /*CONSULTA GRID ADMINISTRACION PRIORIDADES */
    private List<GarantiasFideicomisosPrioridadesEntidad> ConsultaPrioridadesInterno(GarantiasFideicomisosPrioridadesEntidad filtro)
    {
        try
        {
            List<GarantiasFideicomisosPrioridadesEntidad> retorno = null;
            retorno = wsGarantias.GarantiasFideicomisoPrioridadesConsultarGridInterno(filtro).ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewPrioridadesInterno(object sender, EventArgs e)
    {
        try
        {
            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridPrioridadesInterno = (GridView)this.grdPrioridad.FindControl("MasterGridView");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridPrioridadesInterno.Init += new EventHandler(gridPrioridadesInterno_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridPrioridadesInterno_Init(sender, e);

            //ASIGNA DATA KEYS
            String[] dataKeysString = { "IdGarantiaFideicomisosPrioridad" };
            this.SetDataKeys(gridPrioridadesInterno, dataKeysString);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /* ACTUALIZA LOS DATOS DEL GRIDVIEW ADMINISTRACION PRIORIDADES */
    private void GridViewPrioridadesInternoActualizar()
    {
        GarantiasFideicomisosPrioridadesEntidad _fideicomisos = new GarantiasFideicomisosPrioridadesEntidad();
        _fideicomisos.IdGarantiaFideicomiso = 0;

        if (!this.hdnIdGeneral.Value.Length.Equals(0))
            _fideicomisos.IdGarantiaFideicomiso = int.Parse(this.hdnIdGeneral.Value);

        this.grdPrioridad.BindGridView(this.ConsultaPrioridadesInterno(_fideicomisos));
    }

    #endregion

    #region GRIDVIEW INTERNO PRIORIDADES

    private void gridPrioridadesInterno_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridPrioridadesInterno, "IdGarantiaFideicomisosPrioridad", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridPrioridadesInterno.Columns.Add(gridViewColumn.CreateBoundField("DesTipoGradoPrioridad", string.Empty, "Grado Prioridades", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridPrioridadesInterno.Columns.Add(gridViewColumn.CreateBoundField("DesTipoMonedaSaldoPrioridad", string.Empty, "Tipo Moneda", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridPrioridadesInterno.Columns.Add(gridViewColumn.CreateBoundField("SaldoPrioridad", "{0:N}", "Saldo Prioridad", HorizontalAlign.Center, false, true));

        //TemplateField lblID2 = new TemplateField();
        //gvTemplate.CrearCamposGridNoVisibles(gridPrioridadesInterno, "Id_Visible", lblID2);
    }

    #endregion

    #region ADJUNTOS

    /*CONSULTA GRID ADMINISTRACION ADJUNTOS */
    private List<GarantiasFideicomisosAdjuntosEntidad> ConsultaAdjuntosInterno(GarantiasFideicomisosAdjuntosEntidad filtro)
    {
        try
        {
            List<GarantiasFideicomisosAdjuntosEntidad> retorno = null;
            retorno = wsGarantias.GarantiasFideicomisoAdjuntosConsultarGridInterno(filtro).ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewAdjuntosInterno(object sender, EventArgs e)
    {
        try
        {
            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridDocumentosAdjuntosInterno = (GridView)this.grdDocumentosAdjuntos.FindControl("MasterGridView");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridDocumentosAdjuntosInterno.Init += new EventHandler(gridAdjuntosInterno_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridAdjuntosInterno_Init(sender, e);

            //ASIGNA DATA KEYS
            String[] dataKeysString = { "IdGarantiaFideicomisoAdjunto" };
            this.SetDataKeys(gridDocumentosAdjuntosInterno, dataKeysString);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /* ACTUALIZA LOS DATOS DEL GRIDVIEW ADMINISTRACION ADJUNTOS */
    private void GridViewAdjuntosInternoActualizar()
    {
        GarantiasFideicomisosAdjuntosEntidad _fideicomisos = new GarantiasFideicomisosAdjuntosEntidad();
        _fideicomisos.IdGarantiaFideicomiso = 0;

        if (!this.hdnIdGeneral.Value.Length.Equals(0))
            _fideicomisos.IdGarantiaFideicomiso = int.Parse(this.hdnIdGeneral.Value);

        this.grdDocumentosAdjuntos.BindGridView(this.ConsultaAdjuntosInterno(_fideicomisos));
    }

    #endregion

    #region GRIDVIEW INTERNO ADJUNTOS

    private void gridAdjuntosInterno_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridDocumentosAdjuntosInterno, "IdGarantiaFideicomisoAdjunto", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridDocumentosAdjuntosInterno.Columns.Add(gridViewColumn.CreateBoundField("NombreAdjunto", string.Empty, "Nombre Documento", HorizontalAlign.Center, false, true));

        //TemplateField lblID2 = new TemplateField();
        //gvTemplate.CrearCamposGridNoVisibles(gridDocumentosAdjuntosInterno, "Id_Visible", lblID2);
    }

    #endregion

    #region FIDICOMETIDAS

    /*CONSULTA GRID ADMINISTRACION FIDEICOMETIDAS */
    private List<GarantiasFideicomisosFideicometidasEntidad> ConsultaFideicometidasInterno(GarantiasFideicomisosFideicometidasEntidad filtro)
    {
        try
        {
            List<GarantiasFideicomisosFideicometidasEntidad> retorno = null;
            retorno = wsGarantias.GarantiasFideicomisosFideicometidasConsultarGridInterno(filtro).ToList();

            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GridViewFideicometidasInterno(object sender, EventArgs e)
    {
        try
        {
            // ASIGNA AL GRIDVIEW DE LA ASPX EL GRIDVIEW DEL WUC
            this.gridGarantiasFideicometidasInterno = (GridView)this.grdGarantiaFideicometida.FindControl("MasterGridView");

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridGarantiasFideicometidasInterno.Init += new EventHandler(gridGarantiasFideicometidasInterno_Init);

            // ASIGNA COLUMNAS PROPIAS DEL CONTROL
            this.gridGarantiasFideicometidasInterno_Init(sender, e);

            //ASIGNA DATA KEYS
            String[] dataKeysString = { "IdGarantiaFideicomisoFideicometida" };
            this.SetDataKeys(gridGarantiasFideicometidasInterno, dataKeysString);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /* ACTUALIZA LOS DATOS DEL GRIDVIEW ADMINISTRACION Fideicometidas */
    private void GridViewFideicometidasInternoActualizar()
    {
        GarantiasFideicomisosFideicometidasEntidad _fideicomisos = new GarantiasFideicomisosFideicometidasEntidad();
        _fideicomisos.IdGarantiaFideicomiso = 0;

        if (!this.hdnIdGeneral.Value.Length.Equals(0))
            _fideicomisos.IdGarantiaFideicomiso = int.Parse(this.hdnIdGeneral.Value);

        this.grdGarantiaFideicometida.BindGridView(this.ConsultaFideicometidasInterno(_fideicomisos));
    }

    #endregion

    #region GRIDVIEW INTERNO FIDICOMETIDAS

    private void gridGarantiasFideicometidasInterno_Init(object sender, EventArgs e)
    {
        GridViewTemplate gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;

        TemplateField lblID = new TemplateField();
        gvTemplate.CrearCamposGridNoVisibles(gridGarantiasFideicometidasInterno, "IdGarantiaFideicomisoFideicometida", lblID);

        gridViewColumn = new GridViewColumn();
        this.gridGarantiasFideicometidasInterno.Columns.Add(gridViewColumn.CreateBoundField("DesTipoGarantia", string.Empty, "Tipo Garantía", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridGarantiasFideicometidasInterno.Columns.Add(gridViewColumn.CreateBoundField("CodIdGarantia", string.Empty, "ID Garantía", HorizontalAlign.Center, false, true));

        gridViewColumn = new GridViewColumn();
        this.gridGarantiasFideicometidasInterno.Columns.Add(gridViewColumn.CreateBoundField("ValorNominal", "{0:N}", "Valor Nominal Garantía", HorizontalAlign.Center, false, true));

        //TemplateField lblID2 = new TemplateField();
        //gvTemplate.CrearCamposGridNoVisibles(gridGarantiasFideicometidasInterno, "Id_Visible", lblID2);
    }

    #endregion

    #endregion

    #region  METODOS PARA LOS TEXBOX

    protected void txtFechaConstitucion_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ValidarRangoFechaMenorIgualFechaActual();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void txtFechaVencimiento_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ValidarRangoFechaMayorFechaActual();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region METODOS PARA EL DROPDONWLIST

    protected void ddlIndPrioridad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlIndPrioridad.Enabled)
        {
            if (ddlIndPrioridad.SelectedItem.Text.Equals("NO") && (this.grdPrioridad.ContadorElementos() > 0))
            {
                this.mpeConfirmarEliminarPrioridades.Show();
            }

            IndPrioridadesCambiarIndice(ddlIndPrioridad.SelectedItem.Text);
        }
    }

    private void IndPrioridadesCambiarIndice(string indPrioridad)
    {
        if (indPrioridad.Equals("SI"))
        {
            AdministrarControlesExcepcionesPrioridades(true);
        }

        else
        {
            AdministrarControlesExcepcionesPrioridades(false);
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

    #endregion

    #region METODOS PARA BOTONES

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
                if (this.divBarraMensaje.Visible)
                    this.divBarraMensaje.Visible = false;

                if (!ValidarSeccionGeneral())
                {
                    if (!ValidarSeccionPrioridades())
                    {
                        if (!ValidarSeccionFideicometidas())
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

                if (this.divBarraMensaje.Visible)
                    this.divBarraMensaje.Visible = false;

                if (!ValidarSeccionGeneral())
                {
                    if (!ValidarSeccionPrioridades())
                    {
                        if (!ValidarSeccionFideicometidas())
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

    /*BOTON DE AGREGAR DOCUMENTOS ADJUNTOS */
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            string nombreArchivo = Path.GetFileName(FileUploadRutaArchivo.PostedFile.FileName);

            if (FileUploadRutaArchivo.HasFile)
            {
                if (!VerificaTipoMIME(FileUploadRutaArchivo.PostedFile.ContentType).Equals(0))
                {
                    int tamanoArchivo = FileUploadRutaArchivo.PostedFile.ContentLength;

                    if ((tamanoArchivo != 0) && (tamanoArchivo <= 2000000))
                    {
                        string temporal = CreacionFormatoNombreArchivo(nombreArchivo);

                        using (Impersonador imp = new Impersonador(
                            ConfigurationManager.AppSettings[Resources.Resource.Usuario],
                            ConfigurationManager.AppSettings[Resources.Resource.Dominio],
                            ConfigurationManager.AppSettings[Resources.Resource.Contrasena]))
                        {
                            FileUploadRutaArchivo.SaveAs(Path.Combine(ConfigurationManager.AppSettings["CargaArchivos"] + Path.GetDirectoryName(nombreArchivo), Path.GetFileName(temporal)));
                        }

                        GarantiasFideicomisosAdjuntosEntidad entidad = new GarantiasFideicomisosAdjuntosEntidad();
                        entidad.IdGarantiaFideicomiso = int.Parse(this.hdnIdGeneral.Value);
                        entidad.NombreAdjunto = temporal;
                        entidad.IdTipoFideicomisoAdjunto = int.Parse(this.ddlTipoDocumento.SelectedValue);
                        entidad.IndMetodoInsercion = Resources.Resource._metodoInsercion;
                        entidad.CodUsuarioIngreso = this.codUsuarioOculto.Value;

                        GarantiasWS.RespuestaEntidad respuesta = wsGarantias.GarantiasFideicomisoAdjuntosInsertar(entidad, this.AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                        GridViewAdjuntosInternoActualizar();
                    }

                    else
                    {
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_43");
                        this.mpeInformarBox.Show();
                    }
                }

                else
                {
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_43");
                    this.mpeInformarBox.Show();
                }
            }
        }
        catch (Exception)
        {

            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_43");
            this.mpeInformarBox.Show();
        }
    }

    /*BOTON DE PREVIZUALIZACION DOCUMENTOS ADJUNTOS */
    protected void btnBuscarDocumentoAdjunto_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();
            bool existeArchivo = false;

            if (sesion.Codigo == 0)
            {
                if (this.grdDocumentosAdjuntos.ContadorSeleccionados().Equals(1))
                {
                    GarantiasFideicomisosAdjuntosEntidad entidad = null;
                    foreach (GridViewRow row1 in gridDocumentosAdjuntosInterno.Rows)
                    {
                        CheckBox checkBoxColumn = (CheckBox)gridDocumentosAdjuntosInterno.Rows[row1.RowIndex].FindControl("chkBox1");
                        if (checkBoxColumn.Checked)
                        {
                            Label lblId = (Label)gridDocumentosAdjuntosInterno.Rows[row1.RowIndex].FindControl("lblIdGarantiaFideicomisoAdjunto");

                            entidad = new GarantiasFideicomisosAdjuntosEntidad();
                            entidad.IdGarantiaFideicomisoAdjunto = int.Parse(lblId.Text);
                            entidad.IdGarantiaFideicomiso = int.Parse(hdnIdGeneral.Value);
                            entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                            List<GarantiasFideicomisosAdjuntosEntidad> registros = wsGarantias.GarantiasFideicomisoAdjuntosConsultarGridInterno(entidad).ToList();
                            if (registros != null)
                            {
                                GarantiasFideicomisosAdjuntosEntidad registro = (from r in registros
                                                                                 where r.IdGarantiaFideicomisoAdjunto.Equals(int.Parse(lblId.Text))
                                                                                 select r).FirstOrDefault();

                                if (registro != null)
                                {
                                    string rutaCompleta = string.Empty;
                                    using (Impersonador imp = new Impersonador(
                                        ConfigurationManager.AppSettings[Resources.Resource.Usuario],
                                        ConfigurationManager.AppSettings[Resources.Resource.Dominio],
                                        ConfigurationManager.AppSettings[Resources.Resource.Contrasena]))
                                    {
                                        rutaCompleta = String.Format("{0}{1}", ConfigurationManager.AppSettings["CargaArchivos"], registro.NombreAdjunto);

                                        if (!ExisteArchivo(rutaCompleta))
                                        {
                                            existeArchivo = true;
                                        }
                                    }

                                    if (existeArchivo)
                                    {
                                        string[] nombreArchivo = registro.NombreAdjunto.Split('.');
                                        Dictionary<string, string> dataSesion = new Dictionary<string, string>();
                                        HttpHelper httpPost = new HttpHelper();

                                        if (nombreArchivo[1].Contains("pdf"))
                                        {
                                            dataSesion.Add("tipoAccion", "0");
                                            dataSesion.Add("rutaArchivo", rutaCompleta);

                                            httpPost.RedirectAndPOSTNewWindow(this.Page, "VisualizacionArchivo.aspx", dataSesion);
                                        }

                                        else if (nombreArchivo[1].Contains("doc"))
                                        {
                                            dataSesion.Add("tipoAccion", "1");
                                            dataSesion.Add("rutaArchivo", rutaCompleta);
                                            dataSesion.Add("nombreArchivo", registro.NombreAdjunto);

                                            httpPost.RedirectAndPOST(this.Page, "VisualizacionArchivo.aspx", dataSesion);
                                        }

                                        else
                                        {
                                            dataSesion.Add("tipoAccion", "2");
                                            dataSesion.Add("rutaArchivo", rutaCompleta);
                                            dataSesion.Add("nombreArchivo", registro.NombreAdjunto);

                                            httpPost.RedirectAndPOST(this.Page, "VisualizacionArchivo.aspx", dataSesion);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                else
                {
                    //ERROR DE NO SELECCION DE REGISTROS
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_4");
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

    /*BOTON DE ELIMINAR DOCUMENTOS ADJUNTOS */
    protected void btnEliminarDocumentoAdjunto_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();
            bool existeErrorArchivo = false; //General
            bool errorArchivoEnProceso = false;

            if (sesion.Codigo == 0)
            {
                if (this.grdDocumentosAdjuntos.ContadorSeleccionados() > 0)
                {
                    GarantiasFideicomisosAdjuntosEntidad entidad = null;
                    foreach (GridViewRow row1 in gridDocumentosAdjuntosInterno.Rows)
                    {
                        errorArchivoEnProceso = false;
                        CheckBox checkBoxColumn = (CheckBox)gridDocumentosAdjuntosInterno.Rows[row1.RowIndex].FindControl("chkBox1");
                        if (checkBoxColumn.Checked)
                        {
                            Label lblId = (Label)gridDocumentosAdjuntosInterno.Rows[row1.RowIndex].FindControl("lblIdGarantiaFideicomisoAdjunto");

                            entidad = new GarantiasFideicomisosAdjuntosEntidad();
                            entidad.IdGarantiaFideicomisoAdjunto = int.Parse(lblId.Text);
                            entidad.IdGarantiaFideicomiso = int.Parse(hdnIdGeneral.Value);
                            entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                            List<GarantiasFideicomisosAdjuntosEntidad> registros = wsGarantias.GarantiasFideicomisoAdjuntosConsultarGridInterno(entidad).ToList();
                            if (registros != null)
                            {
                                GarantiasFideicomisosAdjuntosEntidad registro = (from r in registros
                                                                                 where r.IdGarantiaFideicomisoAdjunto.Equals(int.Parse(lblId.Text))
                                                                                 select r).FirstOrDefault();

                                if (registro != null)
                                {
                                    using (Impersonador imp = new Impersonador(
                                               ConfigurationManager.AppSettings[Resources.Resource.Usuario],
                                               ConfigurationManager.AppSettings[Resources.Resource.Dominio],
                                               ConfigurationManager.AppSettings[Resources.Resource.Contrasena]))
                                    {
                                        string rutaCompleta = String.Format("{0}{1}", ConfigurationManager.AppSettings["CargaArchivos"], registro.NombreAdjunto);

                                        if (!ExisteArchivo(rutaCompleta))
                                        {
                                            //ELIMINA EL ARCHIVO DE LA RUTA FISICA
                                            File.Delete(rutaCompleta);

                                            //EL ARCHIVO EN PROCESO SE ENCONTRABA EN LA RUTA
                                            errorArchivoEnProceso = false;
                                        }
                                        else
                                        {
                                            //UN ARCHIVO NO FUE ENCONTRADO, DEBE NOTIFICARSE AL FINAL
                                            existeErrorArchivo = true;

                                            //EL ARCHIVO EN PROCESO NO SE ENCONTRABA EN LA RUTA
                                            errorArchivoEnProceso = true;
                                        }

                                    }

                                    //SI EL ARCHIVO EN PROCESO NO TIENE ERROR (EXISTIA EN LA RUTA)
                                    if (!errorArchivoEnProceso)
                                    {
                                        //ELIMINA EL ARCHIVO DE LA BD
                                        respuesta = wsGarantias.GarantiasFideicomisoAdjuntosEliminar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));
                                    }
                                }
                            }

                            //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
                            if (respuesta.ValorError.Equals(18))
                            {
                                BloquearControlesDesactualizados();
                                BarraMensaje(respuesta, pantallaIdOculto.Value);
                            }
                        }
                    }

                    if (existeErrorArchivo)
                    {
                        this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_44");
                        this.mpeInformarBox.Show();
                    }

                    GridViewAdjuntosInternoActualizar();
                }

                else
                {
                    //SI EXISTE MÁS DE UN REGISTRO SELECCIONADO
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_8");
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

    /*BOTON DE AGREGAR PRIORIDAD */
    protected void btnAgregarPrioridad_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                CargaArregloControles();

                this.VentanaPrioridades1.LimpiarContenido();
                this.VentanaPrioridades1.CargarContenido(controlEntidad);
                this.VentanaPrioridades1.EfectosControlesInsertar();     
                this.mpePrioridades.Show();
            }
        }

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*BOTON DE ELIMINAR PRIORIDAD */
    protected void btnEliminarPrioridad_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (this.grdPrioridad.ContadorSeleccionados() > 0)
                {
                    this.mpeConfirmarEliminarPrioridades.Show();
                }

                else
                {
                    //SI EXISTE MÁS DE UN REGISTRO SELECCIONADO
                    this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_8");
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

    /*BOTON DE MODIFICAR PRIORIDAD */
    protected void btnModificarPrioridad_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (this.grdPrioridad.ContadorSeleccionados() == 1)
                {
                    //CARGA LOS VALORES DE LOS CONTROLES
                    CargaArregloControles();

                    this.VentanaPrioridades1.LimpiarContenido();
                    this.VentanaPrioridades1.CargarContenido(controlEntidad);
                    this.VentanaPrioridades1.EfectosControlesModificar();
                    
                    //CARGA LOS VALORES DESDE BD
                    AsignarValoresRegistroPrioridades();
                }

                else
                {
                    //ERROR DE NO SELECCION DE REGISTROS O MULTISELECCION
                    this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_4");
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

    /*BOTON DE AGREGAR GARANTIA FIDEICOMETIDA */
    protected void btnAgregarGarantiaFideicometida_Click(object sender, EventArgs e)
    {
        tipoAccion = 0;
        HtmlTable tableGeneral = null;
        HtmlTable tableAdicionales = null;
        string valorMoneda = string.Empty;
        string filtroFecha = string.Empty;

        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                ((wucGridControl)this.grdGarantiaFideicometida).LimpiarValoresSeleccionados("IdGarantiaFideicomisoFideicometida");

                #region VALRES OCULTOS

                StringBuilder sesionBuilder = new StringBuilder();
                sesionBuilder.Append(idSesionOculto.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(pantallaModuloOculto.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(codUsuarioOculto.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(hdnIdGeneral.Value);
                sesionBuilder.Append("|");
                sesionBuilder.Append(ddlTipoGarantia.SelectedItem.Value);

                #endregion

                switch (ddlTipoGarantia.SelectedItem.Value)
                {
                    #region GARANTIAS REALES

                    case "3":
                        mpeFideicomisoReales.Show();
                        ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).LimpiarGridCedulas();

                        ((HtmlInputHidden)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                        ((HtmlInputHidden)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();

                        ((Button)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("btnConsultarGarantia")).Enabled = true;
                        ((Button)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacion";
                        ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).HabilitarContenidoGenerales(false);
                        ((HtmlTable)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("tableCedulas")).Disabled = true;
                        tableGeneral = ((HtmlTable)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("tableGeneral"));
                        generadorControles.Bloquear_Controles(tableGeneral, false);
                        ((HtmlTable)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("tableAdicionales")).Disabled = true;

                        //CARGA LOS CONTROLES
                        List<ControlEntidad> controlesReales = ObtenerControlesBD(pantallaModuloOculto.Value, "Tab4");
                        ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).CargarContenidoControlReales(controlesReales);
                        ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).CargarContenidoDefaultReales();
                        ((UpdatePanel)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("updRealesPopUpControl")).Update();

                        /*CLS*/
                        tableAdicionales = ((HtmlTable)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("tableAdicionales"));
                        tableAdicionales.Disabled = true;
                        generadorControles.Bloquear_Controles(tableAdicionales, false);
                        ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).IndicadorInscripcionExcepcion();

                        ((UpdatePanel)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("updRealesPopUpControl")).Update();

                        break;

                    #endregion

                    #region GARANTIAS VALORES

                    case "4":
                        mpeValores.Show();

                        ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).LimpiarContenidoControlValores();

                        ((HtmlInputHidden)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                        ((HtmlInputHidden)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();
                        ((HtmlInputHidden)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("estadoGarantiaOculto")).Value = "I";

                        ((Button)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("btnConsultarGarantia")).Enabled = true;
                        ((Button)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacion";
                        ((HtmlTable)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("tableAdicionales")).Disabled = true;

                        tableGeneral = ((HtmlTable)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("tableGeneral"));
                        generadorControles.Bloquear_Controles(tableGeneral, false);

                        #region CARGAR CONTROLES

                        List<ControlEntidad> controlesValores = ObtenerControlesBD(pantallaModuloOculto.Value, "Tab6");
                        ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).CargarContenidoControlValores(controlesValores);
                        ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).EstadoControles(false);

                        ((UpdatePanel)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("updValoresPopUpControl")).Update();

                        #endregion

                        ((UpdatePanel)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("updValoresPopUpControl")).Update();
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

    /*BOTON DE MODIFICAR GARANTIA FIDEICOMETIDA */
    protected void btnModificarGarantiaFideicometida_Click(object sender, EventArgs e)
    {
        try
        {
            tipoAccion = 0;
            HtmlTable tableGeneral = null;
            string estado = string.Empty;

            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (this.grdGarantiaFideicometida.ContadorSeleccionados() == 1)
                {
                    GarantiasFideicomisosFideicometidasEntidad entidad = new GarantiasFideicomisosFideicometidasEntidad();

                    GarantiasValoresEntidad resultadoValores = new GarantiasValoresEntidad();
                    GarantiasRealesEntidad resultadoReales = new GarantiasRealesEntidad();

                    foreach (GridViewRow row1 in gridGarantiasFideicometidasInterno.Rows)
                    {
                        CheckBox checkBoxColumn = (CheckBox)gridGarantiasFideicometidasInterno.Rows[row1.RowIndex].FindControl("chkBox1");
                        if (checkBoxColumn.Checked)
                        {
                            Label lblId = (Label)gridGarantiasFideicometidasInterno.Rows[row1.RowIndex].FindControl("lblIdGarantiaFideicomisoFideicometida");

                            entidad.IdGarantiaFideicomisoFideicometida = int.Parse(lblId.Text);
                            entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

                            GarantiasFideicomisosFideicometidasEntidad resultadoOperacion = wsGarantias.GarantiasFideicomisosFideicometidasConsultarDetalle(entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                            #region CREAR LOS PARAMETROS AL POPUP

                            StringBuilder sesionBuilder = new StringBuilder();
                            sesionBuilder.Append(idSesionOculto.Value);
                            sesionBuilder.Append("|");
                            sesionBuilder.Append(pantallaModuloOculto.Value);
                            sesionBuilder.Append("|");
                            sesionBuilder.Append(codUsuarioOculto.Value);
                            sesionBuilder.Append("|");
                            sesionBuilder.Append(ddlTipoGarantia.SelectedItem.Value);

                            #endregion

                            switch (resultadoOperacion.IdTipoGarantia)
                            {
                                #region GARANTIAS REALES

                                case 3:
                                    resultadoReales.IdGarantiaReal = int.Parse(resultadoOperacion.IdGarantiaReal.ToString());
                                    resultadoReales = wsGarantias.GarantiasRealesConsultarDetalle(resultadoReales, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
                                    ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).LimpiarGridCedulas();
                                    mpeFideicomisoReales.Show();

                                    #region CARGAR CONTROL

                                    ((HtmlInputHidden)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                                    ((HtmlInputHidden)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();
                                    ((HtmlInputHidden)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("idGarantiaFideicometida")).Value = entidad.IdGarantiaFideicomisoFideicometida.ToString();

                                    ((Button)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("btnConsultarGarantia")).Enabled = false;
                                    ((Button)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacionDisabled";
                                    ((HtmlTable)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("tableCedulas")).Disabled = true;
                                    ((HtmlTable)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("tableAdicionales")).Disabled = false;

                                    //CARGA LOS CONTROLES
                                    List<ControlEntidad> controlesReales = ObtenerControlesBD(pantallaModuloOculto.Value, "Tab4");
                                    ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).CargarContenidoControlReales(controlesReales);
                                    ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).CargarContenidoDefaultReales();
                                    ((UpdatePanel)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("updRealesPopUpControl")).Update();

                                    ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).HabilitarContenidoGenerales(false);
                                    tableGeneral = ((HtmlTable)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("tableGeneral"));
                                    generadorControles.Bloquear_Controles(tableGeneral, false);

                                    #endregion

                                    #region CARGAR VALORES

                                    ((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).DeEntidadAControles(resultadoOperacion, resultadoReales);
                                    estado = ((wucGridControl)this.grdGarantiaFideicometida).ObtenerEstadoGarantiaSeleccionado();

                                    ((HtmlInputHidden)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("estadoGarantiaOculto")).Value = estado;
                                    ((UpdatePanel)((wucGarantiasFideicomisoReales)this.VentanaFideicomisoReales).FindControl("updRealesPopUpControl")).Update();

                                    #endregion

                                    break;

                                #endregion

                                #region GARANTIAS VALORES

                                case 4:
                                    resultadoValores.IdGarantiaValor = int.Parse(resultadoOperacion.IdGarantiaValor.ToString());
                                    resultadoValores = wsGarantias.GarantiasValoresConsultarDetalle(resultadoValores, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
                                    ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).LimpiarBarraMensaje();
                                    mpeValores.Show();

                                    ((HtmlInputHidden)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("valorSesionOculto")).Value = sesionBuilder.ToString();
                                    ((HtmlInputHidden)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("idGarantiaFideicometida")).Value = entidad.IdGarantiaFideicomisoFideicometida.ToString();
                                    ((HtmlInputHidden)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("tipoAccionOculto")).Value = tipoAccion.ToString();
                                    ((HtmlInputHidden)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("estadoGarantiaOculto")).Value = "U";

                                    ((Button)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("btnConsultarGarantia")).Enabled = false;
                                    ((Button)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("btnConsultarGarantia")).CssClass = "botonConsultarRelacionDisabled";
                                    ((HtmlTable)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("tableAdicionales")).Disabled = false;

                                    tableGeneral = ((HtmlTable)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("tableGeneral"));
                                    generadorControles.Bloquear_Controles(tableGeneral, false);

                                    #region CARGAR CONTROLES

                                    List<ControlEntidad> controlesValores = ObtenerControlesBD(pantallaModuloOculto.Value, "Tab6");
                                    ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).CargarContenidoControlValores(controlesValores);
                                    ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).EstadoControles(false);

                                    ((UpdatePanel)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("updValoresPopUpControl")).Update();

                                    #endregion

                                    #region CARGAR VALORES

                                    ((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).DeEntidadAControles(resultadoOperacion, resultadoValores);

                                    ((UpdatePanel)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("updValoresPopUpControl")).Update();

                                    #endregion

                                    ((UpdatePanel)((wucGarantiasFideicomisoValores)this.GarantiasFideicomisoValores).FindControl("updValoresPopUpControl")).Update();
                                    break;

                                #endregion
                            }
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

        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    /*BOTON DE ELIMINAR GARANTIA FIDEICOMETIDA */
    protected void btnEliminarGarantiaFideicometida_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                if (Page.IsPostBack)
                {
                    if (this.grdGarantiaFideicometida.ContadorSeleccionados() > 0)
                    {
                        foreach (GridViewRow row in gridGarantiasFideicometidasInterno.Rows)
                        {
                            CheckBox checkBoxColumn = (CheckBox)gridGarantiasFideicometidasInterno.Rows[row.RowIndex].FindControl("chkBox1");
                            if (checkBoxColumn.Checked)
                            {
                                this.mpeConfirmarEliminarFideicometidas.Show();
                                break;
                            }
                        }
                    }

                    else
                    {
                        //SI NO EXISTE REGISTRO SELECCIONADO
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_8");
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

    /*BOTON DE VALIDACION DE LA SECCION GENERAL*/
    protected void btnValidar_Click(object sender, EventArgs e)
    {
        try
        {
            //CLOAIZA
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {

                if (ValidarCaracterEspecial(this.txtNombreFideicomiso.Text))
                {
                    //MENSAJE DE ERROR POR CARACTER ESPECIAL
                    BarraMensaje(null, "");
                }
                else
                {
                    if (!ValidarEntidadFideicomiso())
                    {
                        HabilitarControlesExcepciones();
                        GridViewAdjuntosInternoActualizar();
                        GridViewPrioridadesInternoActualizar();
                        GridViewFideicometidasInternoActualizar();
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

    #region METODOS ADJUNTO ARCHIVOS

    /* VERIFICA EL TIPO MIME */
    private int VerificaTipoMIME(string tipoMIME)
    {
        string[] listaTipoMIME = { "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };

        return (from elemento in listaTipoMIME
                where elemento == tipoMIME
                select elemento).Count();
    }

    /* OBTIENE EL TAMAÑO DEL ARCHIVO EN KB */
    private byte[] ObtenerTamanoArchivo()
    {
        byte[] tamanoArchivo;

        using (Stream fs = FileUploadRutaArchivo.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                tamanoArchivo = br.ReadBytes((Int32)fs.Length);
            }
        }

        return tamanoArchivo;
    }

    private string CreacionFormatoNombreArchivo(String nombreArchivo)
    {
        int tipoDocumento = int.Parse(ddlTipoDocumento.SelectedValue);
        StringBuilder sb = new StringBuilder();

        if (tipoDocumento.Equals(1))
            sb.Append("C_");

        else if (tipoDocumento.Equals(2))
            sb.Append("A_");

        sb.Append(txtIdFideicomisoBCR.Text);
        sb.Append("_");
        sb.Append(ConsecutivoArchivo());
        sb.Append(Path.GetExtension(nombreArchivo));

        return sb.ToString();
    }

    private bool ExisteArchivo(string rutaCompleta)
    {
        bool respueta = false;

        if (File.Exists(rutaCompleta))
            respueta = false;

        else
            respueta = true;

        return respueta;
    }

    private string ConsecutivoArchivo()
    {
        string valorRetorno = "01";

        GarantiasFideicomisosAdjuntosEntidad entidad = new GarantiasFideicomisosAdjuntosEntidad();
        entidad.IdGarantiaFideicomiso = int.Parse(this.hdnIdGeneral.Value);

        List<GarantiasFideicomisosAdjuntosEntidad> registros = wsGarantias.GarantiasFideicomisoAdjuntosConsultarGridInterno(entidad).ToList();

        if (registros != null)
        {
            if (registros.Count > 0)
            {
                //C_BCR01042016666_01.PDF
                int nuevoConsecutivo = registros.Count + 1;
                if (nuevoConsecutivo < 100)
                    valorRetorno = GeneradorControles.Right("0" + nuevoConsecutivo.ToString(), 2);
                else
                    valorRetorno = nuevoConsecutivo.ToString();
            }
        }

        return valorRetorno;
    }

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

            if (!ValidarSeccionGeneral())
            {
                if (!ValidarSeccionPrioridades())
                {
                    if (!ValidarSeccionFideicometidas())
                    {
                        //ACTUALIZA LA SECCION GENERAL
                        ModificarEntidadFideicomiso();

                        //Requerimiento Bloque 7 1-24381561 
                        MostrarControlRegistrosGuardar();

                        //GridViewAdjuntosInternoActualizar();
                        //GridViewPrioridadesInternoActualizar();
                        //GridViewFideicometidasInternoActualizar();
                    }
                }
            }

            //}
            //else
            //{
            //    //MENSAJE DE ERROR DE FORMATO
            //    this.InformarBox1_SetConfirmationBoxEvent(null, null, "Relacion");
            //    this.mpeInformarBox.Show();
            //}
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

    #region METODOS PRIORIDADES

    private GarantiasFideicomisosPrioridadesEntidad CrearPrioridad(int iD)
    {
        GarantiasFideicomisosPrioridadesEntidad entidad = new GarantiasFideicomisosPrioridadesEntidad();
        entidad.IdGarantiaFideicomisosPrioridad = iD;
        entidad.CodUsuarioIngreso = codUsuarioOculto.Value;

        return entidad;
    }

    private void AplicarCambioIndPrioridad(string opcion = "NO")
    {
        generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndPrioridad, opcion);
        IndPrioridadesCambiarIndice(ddlIndPrioridad.SelectedItem.Text);
    }

    private void AplicarCambioIndPrioridadSi(string opcion = "SI")
    {
        generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndPrioridad, opcion);
        IndPrioridadesCambiarIndice(ddlIndPrioridad.SelectedItem.Text);
    }

    private void VerficacionSesion(ref bool respuesta)
    {
        if (wsSesiones.ConsultarSesion(idSesionOculto.Value).Codigo == 0)
            respuesta = true;
    }

    private void VerficacionGridPrioridadesContadorSeleccionados(ref bool respuesta)
    {
        if (this.grdPrioridad.ContadorSeleccionados() > 0)
            respuesta = true;
        //else
        //    VerificacionGridPrioridades();
    }

    private void VerificacionGridPrioridades()
    {
        //VERIFICA SI EL GRID CONTIENE REGISTROS
        if (this.grdPrioridad.ContadorElementos() > 0)
        {
            //ERROR DE NO SELECCION DE REGISTROS
            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_8");
            this.mpeInformarBox.Show();
        }
    }

    private GarantiasWS.RespuestaEntidad EfectuarBorrado(int indiceFila)
    {
        Label lblId = (Label)gridPrioridadesInterno.Rows[indiceFila].FindControl("lblIdGarantiaFideicomisosPrioridad");

        return wsGarantias.GarantiasFideicomisoPrioridadesEliminar(CrearPrioridad(int.Parse(lblId.Text)), AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));
    }

    private void EfectuarBorradoPrioridadesCompleto(int indiceFila)
    {
        GarantiasWS.RespuestaEntidad respuesta = EfectuarBorrado(indiceFila);

        //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
        if (respuesta.ValorError.Equals(18))
        {
            BloquearControlesDesactualizados();
            BarraMensaje(respuesta, pantallaIdOculto.Value);
        }
    }

    private void EfectuarBorradoPrioridadesIncompleto(int indiceFila)
    {
        CheckBox checkBoxColumn = (CheckBox)gridPrioridadesInterno.Rows[indiceFila].FindControl("chkBox1");
        if (checkBoxColumn.Checked)
        {
            GarantiasWS.RespuestaEntidad respuesta = EfectuarBorrado(indiceFila);

            //CUANDO LA GARANTIA ESTÁ DESACTUALIZADA
            if (respuesta.ValorError.Equals(18))
            {
                BloquearControlesDesactualizados();
                BarraMensaje(respuesta, pantallaIdOculto.Value);
            }
        }
    }

    #endregion

    #region CONTROLES

    /* CARGA LOS VALORES PARA LOS TITULOS */
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
                    btn.Text = pantallaTituloOculto.Value.Replace("Mantenimiento", "Garantías");

                lblPagina.Text = pantallaTituloOculto.Value.Replace("Mantenimiento", "Garantías");
                lblForm.Text = lblForm.Text + pantallaTituloOculto.Value.Replace("Mantenimiento", "Garantías");

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

    /*EFECTO DEL DLL IND POLIZA - SECCION POLIZAS*/
    private void EfectoDdlIndPrioridad()
    {
        //B16S01
        if (gridPrioridadesInterno != null)
        {
            if (gridPrioridadesInterno.Rows.Count > 0)
                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndPrioridad, "SI");
            else
                generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndPrioridad, "NO");

            IndPrioridadesCambiarIndice(ddlIndPrioridad.SelectedItem.Text);
        }
    }

    /* CARGA LOS TABS DEL WORKSPACE */
    private void Tabs()
    {
        try
        {
            if (pantallaModuloOculto.Value != null)
            {
                List<NodoMenuEntidad> menu = new List<NodoMenuEntidad>();
                NodoMenuEntidad nodo = new NodoMenuEntidad();
                nodo.Nombre = "Generales";
                nodo.Url = "Tab1";
                menu.Add(nodo);

                nodo = new NodoMenuEntidad();
                nodo.Nombre = "Contratos/Adendas adjuntos";
                nodo.Url = "Tab2";
                menu.Add(nodo);

                nodo = new NodoMenuEntidad();
                nodo.Nombre = "Prioridades";
                nodo.Url = "Tab3";
                menu.Add(nodo);

                nodo = new NodoMenuEntidad();
                nodo.Nombre = "Garantías Fideicometidas";
                nodo.Url = "Tab4";
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

    /* CARGA LAS DESCRIPCIONES DE LAS ETIQUETAS DE LOS CAMPOS */
    private void ControlesNombre()
    {
        try
        {
            #region SECCION GENERAL

            //LBL ID FIDEICOMISO BCR
            controlSeleccionado = ControlesBuscar(this.lblIdFideicomisoBCR.ID);
            this.lblIdFideicomisoBCR.Text = controlSeleccionado.DesColumna;

            //LBL ID FIDEICOMISO
            controlSeleccionado = ControlesBuscar(this.lblIdFideicomiso.ID);
            this.lblIdFideicomiso.Text = controlSeleccionado.DesColumna;

            //LBL NOMBRE FIDEICOMISO
            controlSeleccionado = ControlesBuscar(this.lblNombreFideicomiso.ID);
            this.lblNombreFideicomiso.Text = controlSeleccionado.DesColumna;

            //LBL FECHA CONSTITUCIÓN
            controlSeleccionado = ControlesBuscar(this.lblFechaConstitucion.ID);
            this.lblFechaConstitucion.Text = controlSeleccionado.DesColumna;

            //LBL FECHA VENCIMIENTO
            controlSeleccionado = ControlesBuscar(this.lblFechaVencimiento.ID);
            this.lblFechaVencimiento.Text = controlSeleccionado.DesColumna;

            //LBL TIPO MONEDA VALOR NOMINAL
            controlSeleccionado = ControlesBuscar(this.lblTipoMonedaValorNominal.ID);
            this.lblTipoMonedaValorNominal.Text = controlSeleccionado.DesColumna;

            //LBL VALOR NOMINAL
            controlSeleccionado = ControlesBuscar(this.lblValorNominal.ID);
            this.lblValorNominal.Text = controlSeleccionado.DesColumna;

            //BTN VALIDAR
            controlSeleccionado = ControlesBuscar(this.btnValidar.ID);
            this.btnValidar.Text = controlSeleccionado.DesColumna;

            #endregion

            #region DOCUMENTOS ADJUNTOS

            //LBL TIPO DE DOCUMENTO
            controlSeleccionado = ControlesBuscar(this.lblTipoDocumento.ID);
            this.lblTipoDocumento.Text = controlSeleccionado.DesColumna;

            //BTN AGREGAR
            controlSeleccionado = ControlesBuscar(this.btnAgregar.ID);
            this.btnAgregar.Text = controlSeleccionado.DesColumna;

            #endregion

            #region PRIORIDADES

            //LBL IND. PRIORIDAD
            controlSeleccionado = ControlesBuscar(this.lblIndPrioridad.ID);
            this.lblIndPrioridad.Text = controlSeleccionado.DesColumna;

            #endregion

            #region GARANTÍA FIDEICOMETIDA

            //LBL GARANTÍA FIDEICOMETIDA
            controlSeleccionado = ControlesBuscar(this.lblTipoGarantia.ID);
            this.lblTipoGarantia.Text = controlSeleccionado.DesColumna;

            #endregion

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /* EXTRAE LOS CONTROLES DESDE BD */
    private void Controles()
    {
        try
        {
            //DDL TIPOS MONEDA VALOR NOMINAL
            controlSeleccionado = ControlesBuscar(this.ddlTipoMonedaValorNominal.ID);
            this.ddlTipoMonedaValorNominal.DataSource = LlenarPrioridad(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoMonedaValorNominal.DataTextField = "Texto";
            this.ddlTipoMonedaValorNominal.DataValueField = "Valor";
            this.ddlTipoMonedaValorNominal.DataBind();
            this.ddlTipoMonedaValorNominal.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoMonedaValorNominal, controlSeleccionado.ValorDefecto);

            //DDL TIPO DE DOCUMENTO
            controlSeleccionado = ControlesBuscar(this.ddlTipoDocumento.ID);
            this.ddlTipoDocumento.DataSource = LlenarPrioridad(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlTipoDocumento.DataTextField = "Texto";
            this.ddlTipoDocumento.DataValueField = "Valor";
            this.ddlTipoDocumento.DataBind();
            this.ddlTipoDocumento.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoDocumento, controlSeleccionado.ValorDefecto);

            //DDL IND. PRIORIDAD
            controlSeleccionado = ControlesBuscar(this.ddlIndPrioridad.ID);
            this.ddlIndPrioridad.DataSource = LlenarPrioridad(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlIndPrioridad.DataTextField = "Texto";
            this.ddlIndPrioridad.DataValueField = "Valor";
            this.ddlIndPrioridad.DataBind();
            this.ddlIndPrioridad.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndPrioridad, controlSeleccionado.ValorDefecto);

            //DDL TIPOS DE GARANTÍA
            controlSeleccionado = ControlesBuscar(this.ddlTipoGarantia.ID);
            this.ddlTipoGarantia.DataSource = LlenarPrioridad(controlSeleccionado.MetodoServicioWeb, "3,4");
            this.ddlTipoGarantia.DataTextField = "Texto";
            this.ddlTipoGarantia.DataValueField = "Valor";
            this.ddlTipoGarantia.DataBind();
            this.ddlTipoGarantia.CssClass = controlSeleccionado.CssTipo;
            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoGarantia, controlSeleccionado.ValorDefecto);

            //TXT FECHA VENCIMIENTO
            this.txtFechaVencimiento.Attributes.Add("readonly", "readonly");

            //TXT FECHA CONSTITUCION
            this.txtFechaConstitucion.Attributes.Add("readonly", "readonly");

            //VALORES POR DEFECTO
            //VALOR NOMINAL
            controlSeleccionado = ControlesBuscar(this.txtValorNominal.ID, "Tab1");
            if (controlSeleccionado.IndValorDefecto.Equals("True"))
            {
                this.txtValorNominal.Text = string.Format("{0:N}", int.Parse(controlSeleccionado.ValorDefecto));
            }

            this.calendarExtenderFechaConstitucion.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();
            this.calendarExtenderFechaVencimiento.Format = ConfigurationManager.AppSettings["FormatoFecha"].ToString();

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

        if (this.txtIdFideicomiso.Enabled)
        {
            this.txtIdFideicomiso.Text = string.Empty;
            this.txtNombreFideicomiso.Text = string.Empty;
            this.txtFechaConstitucion.Text = string.Empty;
            this.txtFechaVencimiento.Text = string.Empty;
            //this.hdnIdClaseVehiculo.Value = string.Empty;
        }
        else
        {
            this.txtFechaConstitucion.Text = string.Empty;
            this.txtFechaVencimiento.Text = string.Empty;
        }

        #endregion

        LimpiarBarraMensaje();
    }

    /* RETORNA UN CONTROL DE UN SET DE CONTROLES */
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

    private ControlEntidad ControlesBuscar(string nombreControl, string tab)
    {
        try
        {
            CargaArregloControles();

            nombreControl = nombreControl.Replace("txt", "").Replace("ddl", "").Replace("imb", "").Replace("lbl", "").Replace("btn", "").Replace("chk", "");
            ControlEntidad controlRetorno = (from control in controlEntidad
                                             where control.NombrePropiedad.Equals(nombreControl)
                                                & control.Tab.Equals(tab)
                                             select control).First();

            return controlRetorno;
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
                
                //CARGA LOS CONTROLES DE LA SECCION DOCUMENTOS ADJUNTOS
                ControlesDocumentosAdjuntos();

                //CARGA LOS CONTROLES DE LA SECCION PRIORIDADES
                ControlesPrioridades();

                //CARGA LA SECCION DE GARANTIAS FIDEICOMETIDAS
                ControlesFideicometidas();

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
                GarantiasFideicomisosEntidad entidadConsulta = new GarantiasFideicomisosEntidad();
                entidadConsulta.IdGarantiaFideicomiso = int.Parse(this.hdnIdGeneral.Value);

                GarantiasFideicomisosEntidad entidadRetorno = wsGarantias.GarantiasFideicomisosConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                if (entidadRetorno != null)
                {
                    //Requerimiento Bloque 7 1-24381561 
                    ObtenerControlRegistros(entidadRetorno);

                    this.txtIdFideicomisoBCR.Text = entidadRetorno.CodFidecomisoBCR.ToString();

                    //if (entidadRetorno.CodFidecomiso.ToString().Length > 0)
                    //    this.txtIdFideicomiso.Text = entidadRetorno.CodFidecomiso.ToString();
                    //else
                    //    this.txtIdFideicomiso.Text = null;

                    if (!string.IsNullOrEmpty(entidadRetorno.CodFidecomiso))
                        this.txtIdFideicomiso.Text = entidadRetorno.CodFidecomiso.ToString();
                    else
                        this.txtIdFideicomiso.Text = null;

                    this.txtNombreFideicomiso.Text = entidadRetorno.NombreFideicomiso.ToString();

                    this.txtFechaConstitucion.Text = entidadRetorno.DesFechaConstitucion.ToString();

                    this.txtFechaVencimiento.Text = entidadRetorno.DesFechaVencimiento.ToString();

                    if (entidadRetorno.IdTipoMonedaValorNominal.ToString().Length > 0)
                        this.ddlTipoMonedaValorNominal.SelectedItem.Value = entidadRetorno.IdTipoMonedaValorNominal.ToString();
                    else
                        this.ddlTipoMonedaValorNominal.SelectedItem.Value = null;

                    this.txtValorNominal.Text = entidadRetorno.ValorNominal.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /* CARGA LOS VALORES DESDE LOS CONTROLES DE LA SECCION GENERAL HACIA LA ENTIDAD PARA REALIZAR ACCIONES */
    private GarantiasFideicomisosEntidad DeControlesAEntidadGeneral()
    {
        try
        {
            GarantiasFideicomisosEntidad fideicomisos = null;

            if (pantallaModuloOculto.Value.Length > 0)
            {
                fideicomisos = new GarantiasFideicomisosEntidad();

                #region SECCION GENERAL

                if (this.txtIdFideicomisoBCR.Text.Length < 1)
                    fideicomisos.CodFidecomisoBCR = null;
                else
                    fideicomisos.CodFidecomisoBCR = this.txtIdFideicomisoBCR.Text;

                if (this.txtIdFideicomiso.Text.Length < 1)
                    fideicomisos.CodFidecomiso = null;
                else
                    fideicomisos.CodFidecomiso = this.txtIdFideicomiso.Text;

                fideicomisos.NombreFideicomiso = this.txtNombreFideicomiso.Text;

                if (this.txtFechaConstitucion.Text.Length < 1)
                    fideicomisos.FechaConstitucion = null;
                else
                    fideicomisos.FechaConstitucion = DateTime.Parse(this.txtFechaConstitucion.Text);

                if (this.txtFechaVencimiento.Text.Length < 1)
                    fideicomisos.FechaVencimiento = null;
                else
                    fideicomisos.FechaVencimiento = DateTime.Parse(this.txtFechaVencimiento.Text);

                if (this.ddlTipoMonedaValorNominal.SelectedItem.Value.Equals("-1"))
                    fideicomisos.IdTipoMonedaValorNominal = null;
                else
                    fideicomisos.IdTipoMonedaValorNominal = int.Parse(this.ddlTipoMonedaValorNominal.SelectedItem.Value);

                if (this.txtValorNominal.Text.Length < 1)
                    fideicomisos.ValorNominal = null;
                else
                    fideicomisos.ValorNominal = Decimal.Parse(this.txtValorNominal.Text);

                if (this.hdnIdGeneral.Value.Length < 1)
                    fideicomisos.IdGarantiaFideicomiso = 0;
                else
                    fideicomisos.IdGarantiaFideicomiso = int.Parse(this.hdnIdGeneral.Value);

                #endregion

                //Requerimiento Bloque 7 1-24381561
                CrearControlRegistros(fideicomisos);
            }

            return fideicomisos;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EXTRAE LOS CONTROLES DESDE BD PARA LA SECCION DE PRIORIDADES*/
    private void ControlesDocumentosAdjuntos()
    {
        try
        {
            //this.ddlIndPrioridad.Items.Clear();
            //this.ddlIndPrioridad.SelectedValue = null;
            //controlSeleccionado = ControlesBuscar(this.ddlIndPrioridad.ID);

            //this.ddlIndPrioridad.DataTextField = "Texto";
            //this.ddlIndPrioridad.DataValueField = "Valor";
            //this.ddlIndPrioridad.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            //this.ddlIndPrioridad.DataBind();

            //if (!this.hdnIdGeneral.Value.Equals("0"))
            //    this.ddlIndPrioridad.Enabled = true;

            //generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndPrioridad, controlSeleccionado.ValorDefecto);

            GridViewAdjuntosInternoActualizar();

            ////EJECUTA LAS FUNCIONES DE IND PRIORIDAD
            //EfectoDdlIndPrioridad();

            ////EfectoDdlIndPoliza();
           
            //////EJECUTA LAS FUNCIONES DE IND POLIZA
            ////DdlIndPoliza();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EXTRAE LOS CONTROLES DESDE BD PARA LA SECCION DE PRIORIDADES*/
    private void ControlesPrioridades()
    {
        try
        {
            this.ddlIndPrioridad.Items.Clear();
            this.ddlIndPrioridad.SelectedValue = null;
            controlSeleccionado = ControlesBuscar(this.ddlIndPrioridad.ID);

            this.ddlIndPrioridad.DataTextField = "Texto";
            this.ddlIndPrioridad.DataValueField = "Valor";
            this.ddlIndPrioridad.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, string.Empty);
            this.ddlIndPrioridad.DataBind();

            if (!this.hdnIdGeneral.Value.Equals("0"))
                this.ddlIndPrioridad.Enabled = true;

            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlIndPrioridad, controlSeleccionado.ValorDefecto);

            GridViewPrioridadesInternoActualizar();

            //EJECUTA LAS FUNCIONES DE IND PRIORIDAD
            EfectoDdlIndPrioridad();

            //EfectoDdlIndPoliza();
           
            ////EJECUTA LAS FUNCIONES DE IND POLIZA
            //DdlIndPoliza();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*EXTRAE LOS CONTROLES DESDE BD PARA LA SECCION DE FIDEICOMETIDAS*/
    private void ControlesFideicometidas()
    {
        try
        {
            this.ddlTipoGarantia.Items.Clear();
            this.ddlTipoGarantia.SelectedValue = null;
            controlSeleccionado = ControlesBuscar(this.ddlTipoGarantia.ID);

            this.ddlTipoGarantia.DataTextField = "Texto";
            this.ddlTipoGarantia.DataValueField = "Valor";
            this.ddlTipoGarantia.DataSource = LlenarDropDownList(controlSeleccionado.MetodoServicioWeb, "3,4");
            this.ddlTipoGarantia.DataBind();

            if (!this.hdnIdGeneral.Value.Equals("0"))
                this.ddlTipoGarantia.Enabled = true;

            generadorControles.SeleccionarOpcionDropDownListTexto(this.ddlTipoGarantia, controlSeleccionado.ValorDefecto);

            GridViewFideicometidasInternoActualizar();

            //EfectoDdlIndPoliza();

            ////EJECUTA LAS FUNCIONES DE IND POLIZA
            //DdlIndPoliza();
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

    #endregion

    #region VALIDACIONES

    /*VALIDACION RANGO DE FECHA MENOR O IGUAL A LA FECHA ACTUAL*/
    private bool ValidarRangoFechaMenorIgualFechaActual()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        //FECHA ACTUAL
        string fechaActual = DateTime.Now.ToString();

        if (generadorControles.ObtenerComparacion(txtFechaConstitucion.Text, fechaActual, EnumTipoComparacion.MAYORIGUAL, TypeCode.DateTime))
        {
            existeError = true;

            //MENSAJE DE ERROR DE FECHAS DIFERENTES
            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblFechaConstitucion.Text, "menor o igual a Fecha Actual");
            this.mpeInformarBox.Show();
            this.txtFechaConstitucion.Text = string.Empty;
        }
        return existeError;
    }

    /*VALIDACION RANGO DE FECHA MAYOR A LA FECHA ACTUAL*/
    private bool ValidarRangoFechaMayorFechaActual()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        //FECHA ACTUAL
        string fechaActual = DateTime.Now.ToString();

        if (generadorControles.ObtenerComparacion(txtFechaVencimiento.Text, fechaActual, EnumTipoComparacion.MENOR, TypeCode.DateTime))
        {
            existeError = true;

            //MENSAJE DE ERROR DE FECHAS DIFERENTES
            this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_7", this.lblFechaVencimiento.Text, "mayor a la Fecha Actual");
            this.mpeInformarBox.Show();
            this.txtFechaVencimiento.Text = string.Empty;
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

    /*VALIDA QUE AL MENOS EXISTA UN REGISTRO EN A SECCION DE GENERALES*/
    private bool ValidarSeccionGeneral()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        if (this.txtFechaConstitucion.Text.Length.Equals(0)|| this.txtFechaVencimiento.Text.Length.Equals(0))
        {
                existeError = true;

                //MENSAJE DE ERROR DE REQUERIDO
                valorReemplazo = "la sección " + this.lblGeneral.Text;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "Requerido");
                this.mpeInformarBox.Show();

        }

        return existeError;
    }

    /*VALIDA QUE AL MENOS EXISTA UN REGISTRO EN A SECCION DE PRIORIDADES*/
    private bool ValidarSeccionPrioridades()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        if (this.ddlIndPrioridad.SelectedItem.Text.Equals("SI"))
        {
            if (this.grdPrioridad.ContadorElementos().Equals(0))
            {
                existeError = true;

                //MENSAJE DE ERROR DE REQUERIDO
                valorReemplazo = "la sección " + this.lblPrioridades.Text;
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "Requerido");
                this.mpeInformarBox.Show();
            }
        }

        return existeError;
    }

    /*VALIDA QUE AL MENOS EXISTA UN REGISTRO EN A SECCION DE FIDEICOMETIDAS*/
    private bool ValidarSeccionFideicometidas()
    {
        // FALSE - NO | TRUE - SI
        bool existeError = false;

        if (this.grdGarantiaFideicometida.ContadorElementos().Equals(0))
        {
            existeError = true;

            //MENSAJE DE ERROR DE REQUERIDO
            valorReemplazo = "la sección " + this.lblGarantasFideicometidas.Text;
            this.InformarBox1_SetConfirmationBoxEvent(null, null, "Requerido");
            this.mpeInformarBox.Show();
        }

        return existeError;
    }

    #endregion

    #region ENTIDADES

    //Bloque 7 Requerimiento 1-24381561
    /*OBTIENE LOS DETALLES DEL ID DEL REGISTRO*/
    private GarantiasFideicomisosEntidad ConsultarDetalleEntidad()
    {
        try
        {
            GarantiasFideicomisosEntidad entidadRetorno = new GarantiasFideicomisosEntidad();
            GarantiasFideicomisosEntidad entidadConsulta = new GarantiasFideicomisosEntidad();

            if (pantallaModuloOculto.Value != null && hdnIdGeneral.Value.Length > 0)//VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            {
                entidadConsulta.IdGarantiaFideicomiso = int.Parse(hdnIdGeneral.Value);

                entidadRetorno = wsGarantias.GarantiasFideicomisosConsultarDetalle(entidadConsulta, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));
            }

            return entidadRetorno;
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*MODIFICA UN REGISTRO DE LA ENTIDAD GARANTIA FIDEICOMISO*/
    private void ModificarEntidadFideicomiso()
    {
        try
        {
            GarantiasFideicomisosEntidad entidad = null;
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();

            entidad = DeControlesAEntidadGeneral();
            if (entidad != null)
            {
                respuesta = wsGarantias.GarantiasFideicomisosModificar(entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR));
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
    private bool ValidarEntidadFideicomiso()
    {
        try
        {
            GarantiasFideicomisosEntidad entidad = new GarantiasFideicomisosEntidad();
            GarantiasWS.RespuestaEntidad respuesta = new GarantiasWS.RespuestaEntidad();
            bool existeError = false;

            ////ASIGNA LOS VALORES A LA ENTIDAD
            entidad = DeControlesAEntidadGeneral();

            //VERIFICACION DE LA ASIGNACION
            if (entidad != null)
            {
                respuesta = wsGarantias.GarantiasFideicomisosValidar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                //SI NO EXISTE ERROR EN LA VALIDACION
                if (!respuesta.ValorEstado.Equals(0))
                {
                    //ASIGNACION DEL ID DE LA VALIDACION
                    //this.lblIdGeneral.Text = _respuesta.ValorEstado.ToString();//ELIMINAR
                    this.hdnIdGeneral.Value = respuesta.ValorEstado.ToString();
                    existeError = false;

                    GarantiasFideicomisosEntidad entidadFideicomiso = new GarantiasFideicomisosEntidad();
                    entidadFideicomiso = ConsultarDetalleEntidad();
                    if (entidadFideicomiso != null)
                    {
                        this.txtIdFideicomisoBCR.Text = entidadFideicomiso.CodFidecomisoBCR;
                    }
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

                        existeError = true;
                        this.hdnIdGeneral.Value = "-1";
                        //ERROR POR DUPLICADO DEBIDO A QUE LA GARANTIA EXISTE DE FORMA COMPLETA 
                        BarraMensaje(respuesta, pantallaIdOculto.Value);

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

    #endregion

    #region METODOS PARA EL Prioridad

    /*CARGA LOS VALORES DESDE BD AL DDL*/
    private Object LlenarPrioridad(string wsMethodName, string filtro)
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
        //AdministrarControlesExcepcionesCedulas(false);
        //AdministrarControlesExcepcionesTasadores(false);
        //AdministrarControlesExcepcionesValuacion(false);
        //AdministrarControlesExcepcionesGeneral(false);
        //DeshabilitarControlesGuardar(true);
    }

    /*BLOQUEA LOS CONTROLES AL GUARDAR UN REGISTRO NUEVO*/
    private void BloquearControlesGuardar()
    {
        try
        {
            AdministrarControlesExcepcionesGeneral(false);
            AdministrarControlesExcepcionesDocumentosAdjuntos(false);
            
            this.ddlIndPrioridad.Enabled = false;
            AdministrarControlesExcepcionesPrioridades(false);

            AdministrarControlesExcepcionesGarantiaFideicometida(false);
            //AdministrarControlesExcepcionesGravamenes(false);
            //AdministrarControlesExcepcionesPolizas(false);

            btnGuardar.Enabled = false;
            btnGuardarNuevo.Enabled = false;
            btnGuardarCerrar.Enabled = false;
            btnLimpiarR.Enabled = false;
            btnAyudaGuardar.Enabled = false;

            //this.btnLimpiar.Enabled = false;
            //this.btnEliminarTasador.Enabled = false;

            this.gridDocumentosAdjuntosInterno.Enabled = false;
            this.gridPrioridadesInterno.Enabled = false;
            this.gridGarantiasFideicometidasInterno.Enabled = false;

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
            //if (gridGarantiasFideicometidasInterno != null)
            //{
            //    //SI POSEE REGISTROS SE DEBE DESPLEGAR EL MENSAJE DE ADVERTENCIA
                //if (gridTasadoresInterno.Rows.Count > 0)
                //{
                //MENSAJE DE ADVERTENCIA GRID
                this.InformarBox1_SetConfirmationBoxEvent(null, null, "SYS_46");
                this.mpeInformarBox.Show();
                //}
            //}

            //if (gridDocumentosAdjuntosInterno != null)
            //{
            //    //SI POSEE REGISTROS SE DEBE DESPLEGAR EL MENSAJE DE ADVERTENCIA
            //    if (gridDocumentosAdjuntosInterno.Rows.Count > 0)
            //    {
                    //MENSAJE DE ADVERTENCIA GRID
                this.InformarBox2_SetConfirmationBoxEvent(null, null, "SYS_47");
                this.mpeInformarBox2.Show();
            //    }
            //}

            //if (gridPrioridadesInterno != null)
            //{
                ////SI POSEE REGISTROS SE DEBE DESPLEGAR EL MENSAJE DE ADVERTENCIA
                //if (gridPrioridadesInterno.Rows.Count > 0)
                //{
                    //MENSAJE DE ADVERTENCIA GRID
                this.InformarBox3_SetConfirmationBoxEvent(null, null, "SYS_48");
                this.mpeInformarBox3.Show();
            //    }
            //}
        }

    }

    private void SetDataKeys(GridView gridView, String[] dataKeysString)
    {
        gridView.DataKeyNames = dataKeysString;
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
