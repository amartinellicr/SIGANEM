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
using ListasWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;


public partial class SeguridadNew : System.Web.UI.Page
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

    #endregion

    #region REFERENCIAS

    private BitacoraFlags bitacoraBanderas = new BitacoraFlags();
    private GeneradorControles generadorControles = new GeneradorControles();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private SeguridadWS.BitacorasEntidad bitacorasEntidad = new SeguridadWS.BitacorasEntidad();
    private SeguridadWS.PantallasRolesEntidad pantallasEntidad = new SeguridadWS.PantallasRolesEntidad();

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
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

            #region MENSAJE INFORMAR

            Button btnAceptarInformar = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);

            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

            #endregion

            if (!IsPostBack)
            {
                VariablesGlobales();
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
                    //CARGA LOS VALORES PARA LOS TITULOS
                    Etiquetas(); 
                    //CARGA LOS VALORES DESDE BD PARA EL CASO DE LAS MODIFICACIONES
                    DeEntidadAControles(); 

                    switch (pantallaModuloOculto.Value)
                    {
                        #region PANTALLA ROLES
                        case "32":
                            TreeView opciones = (TreeView)this.tableData.FindControl("Opciones");
                            CargarArbol(opciones, 0);
                            opciones.CollapseAll();
                            TreeNodeCollection nodes = opciones.Nodes;
                            foreach (TreeNode n in nodes)
                            {
                                n.Expand();
                            }

                            if (!pantallaIdRoleOculto.Value.Equals("0") && pantallaIdRoleOculto.Value != null && pantallaIdRoleOculto.Value != "")
                            {
                                pantallasEntidad.IdTipoRol = int.Parse(pantallaIdRoleOculto.Value);
                            }
                            else
                            {
                                pantallasEntidad.IdTipoRol = int.Parse(pantallaIdOculto.Value);
                            }

                            if (!pantallaIdOculto.Value.Equals("0") || !pantallaIdRoleOculto.Value.Equals("0"))
                            {
                                ChequearArbol(opciones, wsSeguridad.PantallasRolesConsultaDetalle(pantallasEntidad).ToList());
                            }

                            //CONTROL DE CAMBIO 1-24372985
                            ////DESHABILITA TODOS LOS CONTROLES PARA EL ROL ADMINISTRADOR
                            //DeshabilitarControles();

                            break;
                        #endregion
                        #region PANTALLA USUARIOS
                        case "33":
                            TextBox codUsuario = (TextBox)this.tableData.FindControl("CodUsuario");
                            TextBox nombreUsuario = (TextBox)this.tableData.FindControl("NombreUsuario");

                            nombreUsuario.Enabled = false;

                            if (pantallaIdOculto.Value.Equals("0"))
                            {
                                ((Button)this.tableData.FindControl("imgButtonValidatorADCodUsuario")).Enabled = true;
                                codUsuario.Enabled = true;
                            }
                            else
                            {
                                ((Button)this.tableData.FindControl("imgButtonValidatorADCodUsuario")).Enabled = false;
                                codUsuario.Enabled = false;
                            }
                            break;
                        #endregion
                        #region PANTALLA PARAMETROS USUARIOS
                        case "169":
                            btnGuardarNuevo.Enabled = false;
                            break;
                        #endregion
                    }
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
            var result = ConsultarDetalleEntidad();
            if (result != null)
            {
                PropertyInfo[] propertiesDetalle = result.GetType().GetProperties();
                foreach (PropertyInfo propertyDetalle in propertiesDetalle)
                {
                    ObtenerControlRegistros(result, propertyDetalle);
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
                switch (pantallaModuloOculto.Value)
                {
                    #region PANTALLA ROLES
                    case "32":
                        TreeView Opciones = (TreeView)this.tableData.FindControl("Opciones");
                        LimpiarArbol(Opciones);
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

    private void btnValidadorAD_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                TextBox txtUsuario = (TextBox)this.tableData.FindControl("NombreUsuario");
                string txtCodUsuario = ((TextBox)this.tableData.FindControl("CodUsuario")).Text;

                if (!txtCodUsuario.Length.Equals(0))
                {
                    bool oExiste = wsSesiones.UsuarioExisteAd(txtCodUsuario);
                    if (oExiste)
                    {
                        divBarraMensaje.Visible = false;
                        txtUsuario.Text = wsSesiones.UsuarioNombreAd(txtCodUsuario);
                    }
                    else
                    {
                        BarraMensaje(null, pantallaIdOculto.Value, "SYS_3");
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

    #region VENTANAS DE MENSAJES

    protected void btnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBox.Hide();
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

        switch (pantallaModuloOculto.Value)
        {
            #region PANTALLA ROLES
            case "32":
                DeControlesAEntidad(tipoAccion);
                break;
            #endregion
            #region PANTALLA USUARIOS
            case "33":
                TextBox nombreUsuario = (TextBox)this.tableData.FindControl("NombreUsuario");
                if (nombreUsuario.Text.Length > 0)
                {
                    DeControlesAEntidad(tipoAccion);
                }
                break;
            #endregion
            #region PARAMETROS USUARIOS
            case "169":
                DeControlesAEntidad(tipoAccion);
                break;
            #endregion
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

    #region METODOS ARBOL DE ROLES

    private void CargarArbol(TreeView arbol, int padre)
    {
        try
        {
            TreeNode nodo;
            arbol.Nodes.Clear();
            SeguridadWS.PantallasEntidad elemento;
            List<SeguridadWS.PantallasEntidad> retorno = new List<SeguridadWS.PantallasEntidad>();

            List<SeguridadWS.PantallasEntidad> listaPantallas = wsSeguridad.PantallasConsulta().ToList();
            foreach (SeguridadWS.PantallasEntidad item in listaPantallas)
            {
                if (item.PadreOrigen.Equals(padre))
                {
                    elemento = new SeguridadWS.PantallasEntidad();
                    elemento.CodPantalla = item.CodPantalla;
                    elemento.TituloPantalla = item.TituloPantalla;
                    elemento.PadreOrigen = item.PadreOrigen;
                    elemento.SubPadreOrigen = item.SubPadreOrigen;
                    elemento.RutaPantalla = item.RutaPantalla;
                    elemento.DesPantalla = item.DesPantalla;

                    retorno.Add(elemento);
                }
            }

            foreach (SeguridadWS.PantallasEntidad item in retorno)
            {
                nodo = new TreeNode();
                nodo.Text = item.TituloPantalla;
                nodo.Value = item.CodPantalla.ToString();
                nodo.NavigateUrl = "javascript:void(0)";

                CargarNodo(nodo, listaPantallas);
                arbol.Nodes.Add(nodo);
            }

            //CONTROL DE CAMBIO 1-24372985
            if (arbol.Nodes[0].Text.Equals("Inicio"))
            {
                arbol.Nodes[0].Checked = true;
                arbol.Nodes[0].ShowCheckBox = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarNodo(TreeNode nodo, List<SeguridadWS.PantallasEntidad> item)
    {
        try
        {
            TreeNode nNodo;
            List<SeguridadWS.PantallasEntidad> lista = item.ToList();

            foreach (SeguridadWS.PantallasEntidad itemLista in lista)
            {
                if (itemLista.PadreOrigen.ToString().Equals(nodo.Value))
                {
                    nNodo = new TreeNode();
                    nNodo.Text = itemLista.TituloPantalla;
                    nNodo.Value = itemLista.CodPantalla.ToString();
                    nNodo.NavigateUrl = "javascript:void(0)";

                    CargarNodo(nNodo, item);
                    nodo.ChildNodes.Add(nNodo);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private DataTable ValidarArbol(TreeView _treeView)
    {
        try
        {
            DataTable table = new DataTable();
            TreeNodeCollection nodes = _treeView.Nodes;
            table.Columns.Add("Id_Tipo_Rol", typeof(int));
            table.Columns.Add("Id_Pantalla", typeof(int));

            foreach (TreeNode n in nodes)
            {
                if (n.Checked)
                {
                    string lbl = pantallaIdOculto.Value;
                    table.Rows.Add(lbl, n.Value);
                    RecorrerNodos(n, table);
                }
            }

            return table;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    private void RecorrerNodos(TreeNode treeNode, DataTable table)
    {
        try
        {
            foreach (TreeNode tn in treeNode.ChildNodes)
            {
                if (tn.Checked)
                {
                    string lbl = pantallaIdOculto.Value;
                    table.Rows.Add(lbl, tn.Value);
                }
                RecorrerNodos(tn, table);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private List<PantallasRolesEntidad> ChequearArbol(TreeView _treeView, List<PantallasRolesEntidad> list)
    {
        try
        {
            TreeNodeCollection nodes = _treeView.Nodes;

            foreach (PantallasRolesEntidad row in list)
            {
                string value = row.IdPantalla.ToString();

                foreach (TreeNode n in nodes)
                {
                    if (n.Value.Equals(value))
                    {
                        n.Checked = true;
                        ChequearNodos(n, value);
                    }
                    else
                    {
                        ChequearNodos(n, value);
                    }
                    n.Expand();
                }
            }

            return list;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    private void ChequearNodos(TreeNode treeNode, string value)
    {
        try
        {
            foreach (TreeNode tn in treeNode.ChildNodes)
            {
                if (tn.Value.Equals(value))
                {
                    tn.Checked = true;
                    tn.Expand();
                }
                ChequearNodos(tn, value);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    private void LimpiarArbol(TreeView arbol)
    {
        try
        {
            TreeNodeCollection nodes = arbol.Nodes;
            foreach (TreeNode n in nodes)
            {
                if (n.Checked)
                {
                    n.Checked = false;
                    LimpiarNodos(n);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }     
    }
    
    private void LimpiarNodos(TreeNode treeNode)
    {
        try
        {
            foreach (TreeNode tn in treeNode.ChildNodes)
            {
                if (tn.Checked)
                {
                    tn.Checked = false;
                    tn.Collapse();
                }
                LimpiarNodos(tn);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region CONTROLES

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

                //ESTABLECE LOS CONTROLES DE LA PANTALLA A CARGAR
                pantalla.Pestana = string.Empty;

                //LIMPIA TABLA DE LA PAGINA ACTUAL
                this.tableData.Controls.Clear();

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

    /*CARGA LOS CONTROLES AL FORMULARIO*/
    public void LlenarTabla(Table tblPrincipal, string strName, List<ControlEntidad> dsControles)
    {
        Boolean assocRowReady = false;
        #region CREA CONTROLES

        // CREA OBJETO REQUIRED FIELD VALIDATOR
        RequiredFieldValidator rfv = null;

        // CREA OBJETO MaskedEditExtender Ajax Control
        MaskedEditExtender msk = null;

        // CREA OBJETO CalendarExterder Ajax Control
        CalendarExtender calendarExtender = null;

        // CREA OBJETO TABLA TEMPORAL asp:Table
        tblPrincipal.ID = String.Concat("aspTable", strName);

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
                string assocID = control.NombrePropiedadAsociada;
                int ancho;
                //0 = SIN ITEMS | 1 = CON ITEMS (PARA DROPDOWNLIST)
                int bandera = 0; 

                if (((Control)tblPrincipal.FindControl(control.NombrePropiedad)) == null)
                {
                    tableRow = new TableRow();
                    if (control.NombrePropiedad.Length > 0)
                        tableRow.ID = string.Concat("tr", control.NombrePropiedad);
                    else
                        tableRow.ID = string.Concat("tr", control.NombreColumna);
                    tableRow.Height = Unit.Parse("10");

                    // CREA TABLE CELL
                    TableCell tc1 = new TableCell();
                    tc1.ID = String.Concat("tcRow", filasContador, "Cell", 0);
                    //CONTROL DE CAMBIO 1-24372961
                    switch (pantallaModuloOculto.Value)
                    {
                        case "169":
                            tc1.Width = Unit.Parse("350");
                            tc1.Height = Unit.Parse("15");
                            break;
                        default:
                            tc1.Width = Unit.Parse("150");
                            tc1.Height = Unit.Parse("15");
                            break;
                    }

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

                    // AGREGA LA ETIQUETA A LA CELDA1 
                    tc1.Controls.Add(cellLabel);

                    // ASIGNA EL VALOR DEL TIPO DE OBJETO 
                    string tipoContenido = control.TipoContenido;
                    tipoContenido = tipoContenido.ToUpper();

                    // CREA TABLE CELL 2
                    TableCell tc2 = new TableCell();
                    tc2.ID = String.Concat("tc", "Row", filasContador, "Cell", "2");
                    switch (pantallaModuloOculto.Value)
                    {
                        case "32":
                        case "33":
                            tc2.Width = Unit.Parse("410");
                            tc2.Height = Unit.Parse("15");
                            break;                        
                        default:
                            tc2.Width = Unit.Parse("150");
                            tc2.Height = Unit.Parse("15");
                            break;
                    }

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

                            if (!String.IsNullOrEmpty(control.GrupoValidacion))
                            {
                                txt.ValidationGroup = control.GrupoValidacion;
                            }

                            if (txt.MaxLength > 50)
                                ancho = 390;
                            else
                                ancho = (txt.MaxLength * 9);  

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
                                msk.ClearTextOnInvalid = true;
                                msk.TargetControlID = txt.ID;
                                msk.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();
                                msk.ClearMaskOnLostFocus = true;
                                msk.AutoComplete = false;

                                msk.MaskType = generadorControles.DeterminaTipoMascara(m);
                                msk.InputDirection = MaskedEditInputDirection.RightToLeft;
                                msk.Mask = generadorControles.DeterminaFormatoMascara(mType, control.ValorMascara);
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

                            break;
                        #endregion

                        #region MULTILINE
                        case "MULTILINE":

                            TextBox mtxt = new TextBox();
                            mtxt.ID = nombrePropiedad;
                            mtxt.Text = string.Empty;
                            mtxt.ToolTip = String.Concat("Texto ", control.DesColumna);
                            mtxt.Enabled = bool.Parse(control.IndModificar);
                            mtxt.Visible = bool.Parse(control.IndVisible);
                            mtxt.CssClass = control.CssTipo;
                            mtxt.MaxLength = Int32.Parse(control.LongitudMaxima);
                            mtxt.TextMode = TextBoxMode.MultiLine;
                            mtxt.Height = 130;
                            mtxt.Width = 400;

                            tc2.Controls.Add(mtxt);

                            #region REQUIREDFIELDVALIDATOR

                            if (control.IndRequerido.Equals("True"))
                            {
                                rfv = new RequiredFieldValidator();
                                rfv.ID = String.Concat("rfv", nombrePropiedad);
                                rfv.ControlToValidate = mtxt.ID;
                                rfv.ErrorMessage = "Required";
                                rfv.Display = ValidatorDisplay.Dynamic;
                                rfv.Text = " * ";
                                rfv.CssClass = "labelTabError";
                            }
                            #endregion

                            break;
                        #endregion

                        #region DROPDOWN LIST
                        case "DROPDOWNLIST":

                            DropDownList ddl = new DropDownList();
                            ddl.ID = nombrePropiedad;
                            string spText = control.MetodoServicioWeb;
                            assocRowReady = false;

                            if (String.IsNullOrEmpty(spText))
                            {
                                ddl.Items.Add(new ListItem("No hay Datos", "-1"));
                                bandera = 0; //NO HAY ITEMS
                            }
                            else
                            {
                                if (spText.Equals("DefaultLista"))
                                {
                                    ddl.Items.Clear();
                                    ddl.Items.Insert(0, new ListItem("NO","false"));
                                    ddl.Items.Insert(1, new ListItem("SI","true"));
                                }
                                else
                                {
                                    bandera = 1; //EXISTEN ITEMS
                                    ddl.Items.Clear();
                                    ddl.DataSource = LlenarDropDownList(spText, string.Empty);
                                    ddl.DataTextField = "Texto";
                                    ddl.DataValueField = "Valor";
                                    ddl.DataBind();
                                    ddlValorSeleccionado = ddl.SelectedValue.ToString(); //SE ASIGNA EL ELEMENTO SELECCIONADO POR DEFECTO
                                }
                            }

                            ddl.ToolTip = String.Concat("Lista de ", control.DesColumna);
                            ddl.Enabled = bool.Parse(control.IndModificar);
                            ddl.Visible = bool.Parse(control.IndVisible);
                            ddl.CssClass = control.CssTipo;
                            ddl.Width = Unit.Parse("150");

                            tc2.Controls.Add(ddl);

                            List<ControlEntidad> dsControles1 = dsControles;
                            foreach (ControlEntidad controlAsociado in dsControles1)
                            {
                                string assocParent = ddl.ID.ToUpper();
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
                                    ddlAssocID.ToolTip = String.Concat("Lista de ", Des_Columnar);
                                    ddlAssocID.Enabled = bool.Parse(controlAsociado.IndModificar);
                                    ddlAssocID.Visible = bool.Parse(controlAsociado.IndVisible);
                                    ddlAssocID.CssClass = controlAsociado.CssTipo;
                                    ddlAssocID.Width = Unit.Parse("100%");

                                    ddlAssocID.Items.Clear();

                                    if (bandera.Equals(0))//NO HAY ITEMS
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
                                                                , Des_Columnar
                                                                , String.Concat("Label ", Des_Columnar)
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

                                    assocRowReady = true;
                                    tblPrincipal.Rows.Add(tableRow);

                                    tableRowAssocID.Cells.Add(tcAssocIDLabel);
                                    tableRowAssocID.Cells.Add(tcAssocID);
                                    tblPrincipal.Rows.Add(tableRowAssocID);                              
                                }
                            }

                            break;
                        #endregion

                        #region TREEVIEW CHECKBOX
                        case "TREEVIEWCHECKBOX":

                            TreeView treeViewCheckBox = new TreeView();
                            treeViewCheckBox.ID = nombrePropiedad;
                            treeViewCheckBox.ShowCheckBoxes = TreeNodeTypes.All;
                            treeViewCheckBox.ShowLines = true;
                            treeViewCheckBox.Enabled = bool.Parse(control.IndModificar);
                            treeViewCheckBox.Visible = bool.Parse(control.IndVisible);
                            treeViewCheckBox.CssClass = control.CssTipo;

                            tc2.Controls.Add(treeViewCheckBox);

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
                            msk.ID = String.Concat("mask", nombrePropiedad);
                            msk.ClearTextOnInvalid = true;
                            msk.TargetControlID = txtCalendario.ID;

                            msk.MaskType = generadorControles.DeterminaTipoMascara(m2);
                            msk.InputDirection = MaskedEditInputDirection.LeftToRight;
                            msk.ClearMaskOnLostFocus = true;
                            msk.CultureName = ConfigurationManager.AppSettings["Culture"].ToString();

                            //SE ASIGNA EL TEXTBOX EN LA PRIMER CELDA
                            calendarCell_1.Controls.Add(txtCalendario);

                            //BOTON CON LA IMAGEN DEL CALENDARIO
                            ImageButton imbCalendario = new ImageButton();
                            imbCalendario.ID = String.Concat("imgButtonCalendarExtender", nombrePropiedad, filasContador);
                            imbCalendario.ToolTip = "Click para abrir el Calendario ";
                            imbCalendario.ImageUrl = ("~/Library/img/32/iconCalendario.gif");
                            imbCalendario.Enabled = bool.Parse(control.IndModificar);
                            imbCalendario.Visible = bool.Parse(control.IndVisible);
                            tc2.VerticalAlign = VerticalAlign.Top;

                            //SE ASIGNA LA IMAGEN DEL CALENDARIO EN LA SEGUNDA CELDA
                            calendarCell_2.Controls.Add(imbCalendario);

                            #region CALENDAR EXTENDER
                            //CONTROL CALENDARIO
                            calendarExtender = new CalendarExtender();
                            calendarExtender.ID = String.Concat("calendarExtender", nombrePropiedad, filasContador);
                            calendarExtender.TargetControlID = txtCalendario.ID;
                            calendarExtender.PopupPosition = CalendarPosition.Right;
                            calendarExtender.PopupButtonID = imbCalendario.ID;
                            calendarExtender.Enabled = bool.Parse(control.IndModificar);
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

                            calendarCell_2.Controls.Add(rfv);
                            #endregion

                            //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                            calendarRow.Cells.Add(calendarCell_1);
                            calendarRow.Cells.Add(calendarCell_2);
                            calendarTable.Rows.Add(calendarRow);
                            tc2.Controls.Add(calendarTable);

                            break;
                        #endregion

                        #region AD VALIDATOR
                        case "ADVALIDATOR":

                            //SE DEBDE DE CREAR UNA TABLA PARA QUE LOS CONTROLES QUEDEN ALINEADOS
                            HtmlTable validatorTable = new HtmlTable();
                            HtmlTableRow validatorRow = new HtmlTableRow();
                            HtmlTableCell validatorCell_1 = new HtmlTableCell();
                            HtmlTableCell validatorCell_2 = new HtmlTableCell();
                            validatorTable.Style.Add("valign", "middle");

                            #region TEXTBOX CONTROL

                            //CONTROL PARA LA BUSQUEDA DE ID USUARIO
                            TextBox txtAD = new TextBox();
                            txtAD.ID = nombrePropiedad;
                            txtAD.Text = string.Empty;
                            txtAD.MaxLength = Int32.Parse(control.LongitudMaxima);
                            txtAD.ToolTip = String.Concat("Validar ", control.DesColumna);
                            txtAD.Enabled = bool.Parse(control.IndModificar);
                            txtAD.Visible = bool.Parse(control.IndVisible);
                            txtAD.CssClass = control.CssTipo;

                            #endregion

                            //SE ASIGNA EL TEXTBOX EN LA PRIMER CELDA
                            validatorCell_1.Controls.Add(txtAD);

                            #region REQUIRED FIELD VALIDATOR

                            if (control.IndRequerido.Equals("True"))
                            {
                                rfv = new RequiredFieldValidator();
                                rfv.ID = String.Concat("rfv", nombrePropiedad);
                                rfv.ControlToValidate = txtAD.ID;
                                rfv.ErrorMessage = "Required";
                                rfv.Display = ValidatorDisplay.Dynamic;
                                rfv.Text = " * ";
                                rfv.CssClass = "labelTabError";
                            }

                            #endregion

                            #region BUTTON VALIDATOR

                            //BOTON CON LA IMAGEN DEL CONTROL
                            Button btnValidadorAD = new Button();
                            btnValidadorAD.ID = String.Concat("imgButtonValidatorAD", nombrePropiedad);
                            btnValidadorAD.ToolTip = "Click para validar usuario en Active Directory ";
                            btnValidadorAD.CssClass = "imgbuttonValidatorAD";
                            btnValidadorAD.Enabled = bool.Parse(control.IndModificar);
                            btnValidadorAD.Visible = bool.Parse(control.IndVisible);
                            btnValidadorAD.Click += new EventHandler(btnValidadorAD_Click);
                            btnValidadorAD.CausesValidation = false;
                            tc2.VerticalAlign = VerticalAlign.Top;

                            #endregion

                            //SE ASIGNA LA IMAGEN EN LA SEGUNDA CELDA
                            validatorCell_2.Controls.Add(btnValidadorAD);
                            validatorCell_2.Controls.Add(rfv);

                            //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                            validatorRow.Cells.Add(validatorCell_1);
                            validatorRow.Cells.Add(validatorCell_2);
                            validatorTable.Rows.Add(validatorRow);
                            tc2.Controls.Add(validatorTable);

                            break;
                        #endregion

                        #region AREA

                        case "AREA":

                            TableCell tc4 = new TableCell();
                            tc4.ID = String.Concat("tcRowArea", filasContador, "Cell", 0);
                            //tc4.Width = Unit.Parse("220");
                            tc4.Height = Unit.Parse("20");
                            //tc4.ColumnSpan = 2;
                            tc4.VerticalAlign = VerticalAlign.Bottom;

                            HtmlGenericControl divSub = new HtmlGenericControl("div");
                            divSub.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                            divSub.ID = String.Concat("ctl00_ContentPlaceHolder1_",control.Tab);

                            Label labelSubtitulo = new Label();
                            labelSubtitulo.ID = nombrePropiedad;
                            labelSubtitulo.Text = control.DesColumna;
                            labelSubtitulo.ToolTip = String.Concat("Etiqueta ", control.DesColumna);
                            labelSubtitulo.Enabled = bool.Parse(control.IndModificar);
                            labelSubtitulo.Visible = bool.Parse(control.IndVisible);
                            labelSubtitulo.CssClass = control.CssTipo;

                            divSub.Controls.Add(labelSubtitulo);
                            tc4.Controls.Add(divSub);

                            //// AGREGA LA CELDA4 A LA FILA
                            tableRow.Cells.Add(tc4);

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

                    #region SWITCH CONTROLES

                    switch (tipoContenido)
                    {
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
                        #region TEXTBOX
                        case "TEXTBOX":
                            if (msk != null)
                            {
                                tc2.Controls.Add(msk);
                            }

                            if (control.IndRequerido.Equals("True"))
                            {
                                tc2.Controls.Add(rfv);
                            }
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

                    #endregion

                    // CELDA PARA EL CONTROL REQUIRED FIELD VALIDATOR
                    TableCell tc3 = new TableCell();

                    tc3.Width = Unit.Parse("100");
                    tc3.HorizontalAlign = HorizontalAlign.Left;
                    tc3.Height = Unit.Parse("15");

                    // AGREGA LA CELDA3 A LA FILA
                    tableRow.Cells.Add(tc3);

                    if (!assocRowReady)
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
        try
        {
            object entidad = null;
            DataTable dt = new DataTable();

            #region CONTROLES COMODIN
            TextBox txt = null;
            DropDownList ddl = null;
            #endregion

            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null && !pantallaIdOculto.Value.Equals("0")) 
            {
                #region OBTIENE EL TIPO DE LA ENTIDAD A CREAR DINAMICAMENTE

                //OBTIENE LA ENTIDAD DINAMICAMENTE
                entidad = ObtenerEntidad(entidad, pantallaModuloOculto.Value); 
                //OBTIENE EL TIPO DE DATO DE LA ENTIDAD
                Type tipoEntidad = entidad.GetType(); 

                #endregion

                #region OBTIENE LAS PROPIEDADES DE LA ENTIDAD

                PropertyInfo[] properties = tipoEntidad.GetProperties();

                string entidadPropiedad = string.Empty;
                string entidadPropiedadTipo = string.Empty;

                #endregion

                #region ASIGNA EL VALOR DEL ID DEL REGISTRO A CONSULTAR

                foreach (PropertyInfo property in properties)
                {
                    if (property.Name.Contains("Id"))
                    {
                        entidadPropiedad = property.Name;
                        entidadPropiedadTipo = property.PropertyType.Name;
                        //ASIGNA EL VALOR A LA PROPIEDAD
                        property.SetValue(entidad, generadorControles.ConvertirTipoDato(entidadPropiedadTipo.ToUpper(), pantallaIdOculto.Value), null); 
                        //EL ID CORRESPONDE A LA PRIMERA PROPIEDAD DE CADA ENTIDAD
                        break; 
                    }
                }

                #endregion

                #region OBTIENE EL RESTO DE CAMPOS DEL REGISTRO A CONSULTAR DESDE LA BD

                string exec = string.Empty;

                Type tipoControl = null;
                Object control = null;

                #region PANTALLA ROLES
                if (pantallaModuloOculto.Value.Equals("32"))
                {
                    exec = pantallaNombreOculto.Value.Replace(" ", "") + "ConsultarDetalle";
                    Type ws = wsSeguridad.GetType();
                    MethodInfo method = ws.GetMethod(exec);
                    var resultado = method.Invoke(wsSeguridad, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
                    TiposRolesEntidad entidadResultado = ((TiposRolesEntidad)resultado);

                    #region RECORRE EL DATATABLE OBTENIDO

                    string asignarValor = string.Empty;
                    List<KeyValuePair<string, string>> entidadLista = new List<KeyValuePair<string, string>>();

                    PropertyInfo[] propiedadesDetalle = resultado.GetType().GetProperties();
                    foreach (PropertyInfo propiedadDetalle in propiedadesDetalle)
                    {
                        #region VALIDAR VALOR PROPIEDAD
                        if (propiedadDetalle.GetValue(resultado, null) != null)
                            asignarValor = propiedadDetalle.GetValue(resultado, null).ToString();
                        else
                            asignarValor = string.Empty;
                        #endregion
                        control = this.tableData.FindControl(propiedadDetalle.Name);

                        if (control != null)
                        {
                            tipoControl = control.GetType();

                            //SEGUN EL TIPO DE CONTROL
                            switch (control.GetType().Name.ToUpper()) 
                            {
                                #region TEXTBOX
                                case "TEXTBOX":
                                    // ASIGNACION DEL TEXTO DESDE LA BD
                                    txt = (TextBox)control;
                                    // ASIGNACION DEL TEXTO DESDE LA BD
                                    txt.Text = asignarValor; 
                                    txt.Enabled = true;
                                    if ((propiedadDetalle.Name).Contains("CodUsuario"))
                                        txt.Enabled = false;
                                    break;
                                #endregion
                                #region MULTILINE
                                case "MULTILINE":
                                    // ASIGNACION DEL TEXTO DESDE LA BD
                                    txt = (TextBox)control;
                                    // ASIGNACION DEL TEXTO DESDE LA BD
                                    txt.Text = asignarValor; 
                                    txt.Enabled = true;
                                    break;
                                #endregion
                                #region DROPDOWNLIST
                                case "DROPDOWNLIST":
                                    // ASIGNACION DEL VALOR DESDE LA BD
                                    ddl = (DropDownList)control;
                                    generadorControles.SeleccionarOpcionDropDownList(ddl, asignarValor);
                                    break;
                                #endregion
                            }
                        }
                        //Requerimiento Bloque 7 1-24381561 
                        else
                        {
                            ObtenerControlRegistros(resultado, propiedadDetalle);
                        }
                    }
                    #endregion
                }
                #endregion
                #region PANTALLA USUARIOS
                if (pantallaModuloOculto.Value.Equals("33"))
                {
                    exec = pantallaNombreOculto.Value.Replace(" ", "") + "ConsultarDetalle";
                    Type ws = wsSeguridad.GetType();
                    MethodInfo metodo = ws.GetMethod(exec);
                    var resultado = metodo.Invoke(wsSeguridad, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
                    UsuariosEntidad entidadResultado = ((UsuariosEntidad)resultado);

                    #region RECORRE EL DATATABLE OBTENIDO

                    string asignarValor = string.Empty;
                    List<KeyValuePair<string, string>> entidadLista = new List<KeyValuePair<string, string>>();

                    PropertyInfo[] propiedadesDetalle = resultado.GetType().GetProperties();
                    foreach (PropertyInfo propiedadDetalle in propiedadesDetalle)
                    {
                        #region VALIDAR VALOR PROPIEDAD
                        if (propiedadDetalle.GetValue(resultado, null) != null)
                            asignarValor = propiedadDetalle.GetValue(resultado, null).ToString();
                        else
                            asignarValor = string.Empty;
                        #endregion
                        control = this.tableData.FindControl(propiedadDetalle.Name);

                        if (control != null)
                        {
                            tipoControl = control.GetType();

                            //SEGUN EL TIPO DE CONTROL
                            switch (control.GetType().Name.ToUpper()) 
                            {
                                #region TEXTBOX
                                case "TEXTBOX":
                                    // ASIGNACION DEL TEXTO DESDE LA BD
                                    txt = (TextBox)control;
                                    // ASIGNACION DEL TEXTO DESDE LA BD
                                    txt.Text = asignarValor; 
                                    switch ((propiedadDetalle.Name))
                                    {
                                        case "CodUsuario": txt.Enabled = false;
                                            break;
                                        case "UltimaConexion": txt.Enabled = false;
                                            break;
                                        default: txt.Enabled = false;
                                            break;
                                    }
                                    break;
                                #endregion
                                #region MULTILINE
                                case "MULTILINE":
                                    // ASIGNACION DEL TEXTO DESDE LA BD
                                    txt = (TextBox)control;
                                    // ASIGNACION DEL TEXTO DESDE LA BD
                                    txt.Text = asignarValor; 
                                    txt.Enabled = true;
                                    break;
                                #endregion
                                #region DROPDOWNLIST
                                case "DROPDOWNLIST":
                                    // ASIGNACION DEL VALOR DESDE LA BD
                                    ddl = (DropDownList)control;
                                    generadorControles.SeleccionarOpcionDropDownList(ddl, asignarValor);
                                    break;
                                #endregion
                            }
                        }
                        //Requerimiento Bloque 7 1-24381561 
                        else
                        {
                            ObtenerControlRegistros(resultado, propiedadDetalle);
                        }
                    }
                    #endregion
                }
                #endregion
                #region PANTALLA PARAMETROS USUARIOS
                if (pantallaModuloOculto.Value.Equals("169"))
                {
                    exec = pantallaNombreOculto.Value.Replace(" ", "") + "BienesConsultarDetalle";
                    Type ws = wsSeguridad.GetType();
                    MethodInfo metodo = ws.GetMethod(exec);
                    var resultado = metodo.Invoke(wsSeguridad, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
                    ParametrosBienesEntidad entidadResultado = ((ParametrosBienesEntidad)resultado);

                    #region RECORRE LA ENTIDAD OBTENIDO
                    string asignarValor = string.Empty;
                    List<KeyValuePair<string, string>> entidadLista = new List<KeyValuePair<string, string>>();

                    PropertyInfo[] propiedadesDetalle = resultado.GetType().GetProperties();
                    foreach (PropertyInfo propiedadDetalle in propiedadesDetalle)
                    {
                        #region VALIDAR VALOR PROPIEDAD
                        if (propiedadDetalle.GetValue(resultado, null) == null)
                            asignarValor = string.Empty;
                        else
                            asignarValor = propiedadDetalle.GetValue(resultado, null).ToString();
                        #endregion
                        control = this.tableData.FindControl(propiedadDetalle.Name);

                        if (control != null)
                        {
                            tipoControl = control.GetType();
                            //SEGUN EL TIPO DE CONTROL
                            switch (control.GetType().Name.ToUpper()) 
                            {
                                #region TEXTBOX - MULTILINE
                                case "TEXTBOX":
                                case "MULTILINE":
                                    txt = (TextBox)control;
                                    txt.Text = asignarValor;
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
                    #endregion
                }
                #endregion

                #endregion
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
        // 0 = NO | 1 = SI
        int caracteresEspeciales = 0; 

        try
        {
            if (pantallaModuloOculto.Value != null)
            {
                #region OBTIENE EL TIPO DE LA ENTIDAD A CREAR DINAMICAMENTE

                //OBTIENE LA ENTIDAD DINAMICAMENTE
                entidad = ObtenerEntidad(entidad, pantallaModuloOculto.Value); 
                //OBTIENE EL TIPO DE DATO DE LA ENTIDAD
                Type tipoEntidad = entidad.GetType();

                #endregion

                #region CONTROLES COMODIN

                TextBox txt = new TextBox();
                DropDownList ddl = null;
                Type tipoControl = null;
                Object control = null;

                #endregion

                #region OBTIENE LAS PROPIEDADES DE LA ENTIDAD

                PropertyInfo[] propiedades = tipoEntidad.GetProperties();

                string entidadPropiedad = string.Empty;
                string entidadPropiedadTipo = string.Empty;

                #endregion

                #region  RECORRE EL DATATABLE OBTENIDO

                foreach (PropertyInfo propiedad in propiedades)
                {
                    control = null;

                    entidadPropiedad = propiedad.Name;
                    entidadPropiedadTipo = propiedad.PropertyType.Name;

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
                                case "TEXTBOX":
                                    txt = (TextBox)control;
                                    valorControl = txt.Text;
                                    break;

                                case "MULTILINE":
                                    txt = (TextBox)control;
                                    valorControl = txt.Text;
                                    break;

                                case "DROPDOWNLIST":
                                    ddl = (DropDownList)control;
                                    valorControl = generadorControles.ObtenerOpcionDropDownList(ddl);
                                    break;
                            }
                        }
                        #endregion

                        //PARA TODAS LAS PROPIEDADES DE LA ENTIDAD EXCEPTO EL ID DE LA ENTIDAD
                        if (control != null) 
                        {
                            //ASIGNA EL VALOR A LA PROPIEDAD
                            propiedad.SetValue(entidad, generadorControles.ConvertirTipoDato(entidadPropiedadTipo.ToUpper(), valorControl), null);
                        }
                        //PARA LA PROPIEDAD ID DE LA ENTIDAD
                        else 
                        {
                            //ASIGNA EL VALOR A LA PROPIEDAD
                            propiedad.SetValue(entidad, generadorControles.ConvertirTipoDato(entidadPropiedadTipo.ToUpper(), pantallaIdOculto.Value), null);
                        }
                    }

                    //Requerimiento Bloque 7 1-24381561
                    CrearControlRegistros(entidad, propiedad);
                }

                #endregion

                #region DIRECCIONAMIENTO SEGUN EL TIPO DE ACCION

                // NO EXISTEN CARACTERES ESPECIALES
                if (caracteresEspeciales != 1) 
                {
                    TreeView opciones = (TreeView)this.tableData.FindControl("Opciones");

                    switch (tipoAccion)
                    {
                        case 0:
                            #region PANTALLA USUARIOS
                            if (pantallaModuloOculto.Value.Equals("33"))
                            {
                                InsertarEntidad(pantallaNombreOculto.Value, wsSeguridad, entidad);
                            }
                            #endregion
                            #region PANTALLA ROLES
                            if (pantallaModuloOculto.Value.Equals("32"))
                            {
                                DataTable dtInsertar = ValidarArbol(opciones);
                                if (dtInsertar.Rows.Count != 0)
                                {
                                    SeguridadWS.RespuestaEntidad resultado = null;
                                    resultado = InsertarEntidad(pantallaNombreOculto.Value, wsSeguridad, entidad);
                                    if (!resultado.ValorEstado.Equals("0"))
                                    {
                                        //Bloque 7 Requerimiento 1-24381561
                                        foreach (PropertyInfo _prop in pantallasEntidad.GetType().GetProperties())
                                        {
                                            CrearControlRegistros(pantallasEntidad, _prop);
                                        }

                                        //VALIDACION DE SELECCION DE REGISTROS EN EL ARBOL
                                        foreach (DataRow row in dtInsertar.Rows)
                                        {
                                            pantallasEntidad.IdTipoRol = resultado.ValorEstado;
                                            pantallasEntidad.IdPantalla = int.Parse(row[1].ToString());
                                            wsSeguridad.PantallasRolesInsertar(pantallasEntidad);
                                        }
                                    }
                                }
                                else
                                {
                                    BarraMensaje(null, "0", "SYS_5");
                                }
                            }
                            #endregion
                            break;
                        case 1:
                            #region PANTALLA USUARIOS - PANTALLA PARAMETROS USUARIOS
                            if ((pantallaModuloOculto.Value.Equals("33")) || (pantallaModuloOculto.Value.Equals("169")))
                            {
                                ModificarEntidad(pantallaNombreOculto.Value, wsSeguridad, entidad);
                            }
                            #endregion
                            #region PANTALLA ROLES
                            if (pantallaModuloOculto.Value.Equals("32"))
                            {
                                DataTable dtInsertar = ValidarArbol(opciones);
                                if (dtInsertar.Rows.Count != 0)
                                {
                                    ModificarEntidad(pantallaNombreOculto.Value, wsSeguridad, entidad);

                                    pantallasEntidad.IdTipoRol = int.Parse(pantallaIdOculto.Value);
                                    wsSeguridad.PantallasRolesEliminar(pantallasEntidad);

                                    //Bloque 7 Requerimiento 1-24381561
                                    foreach (PropertyInfo _prop in pantallasEntidad.GetType().GetProperties())
                                    {
                                        CrearControlRegistros(pantallasEntidad, _prop);
                                    }

                                    DataTable dtModificar = ValidarArbol(opciones);
                                    foreach (DataRow row in dtModificar.Rows)
                                    {
                                        pantallasEntidad.IdTipoRol = int.Parse(row[0].ToString());
                                        pantallasEntidad.IdPantalla = int.Parse(row[1].ToString());

                                        wsSeguridad.PantallasRolesInsertar(pantallasEntidad);
                                    }
                                }
                                else
                                {
                                    BarraMensaje(null, "0", "SYS_5");
                                }
                            }
                            #endregion
                            break;
                        case 2:
                            EliminarEntidad(pantallaNombreOculto.Value, wsSeguridad, entidad);
                            break;
                    }

                    //Bloque 7 Requerimiento 1-24381561
                    MostrarControlRegistrosGuardar();
                }
                else
                {
                    BarraMensaje(null, "", "SYS_1");
                }

                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region METODOS PARA EL DROPDOWNLIST

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

    //CONTROL DE CAMBIO 1-24372985
    //private void DeshabilitarControles()
    //{
    //    if (((TextBox)this.tableData.FindControl("CodTipoRol")).Text.Equals("1"))
    //    {
    //        ((TextBox)this.tableData.FindControl("CodTipoRol")).Enabled = false;
    //        ((DropDownList)this.tableData.FindControl("Activo")).Enabled = false;
    //        ((TreeView)this.tableData.FindControl("Opciones")).Enabled = false;
    //        ((TextBox)this.tableData.FindControl("DesTipoRol")).Enabled = false;
    //    }
    //}

    #endregion

    #region ENTIDADES

    /*RETORNA LA ENTIDAD SEGUN EL CODIGO DE LA PANTALLA*/
    public object ObtenerEntidad(object _entidad, string codPagina)
    {
        switch (codPagina)
        {
            case "32":
                _entidad = new SeguridadWS.TiposRolesEntidad();
                break;
            case "33":
                _entidad = new SeguridadWS.UsuariosEntidad();
                break;
            case "169":
                _entidad = new SeguridadWS.ParametrosBienesEntidad();
                break;
        }

        return _entidad;
    }

    /*INSERTA UN NUEVO REGISTRO*/
    private SeguridadWS.RespuestaEntidad InsertarEntidad(string desPagina, SiganemSeguridadWS wsSeguridad, object entidad)
    {
        try
        {
            string exec = desPagina.Replace(" ", "") + "Insertar";
            Type ws = wsSeguridad.GetType();
            MethodInfo metodo = ws.GetMethod(exec);
            var resultado = metodo.Invoke(wsSeguridad, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR) });

            //IDENTIDAD { 0=NUEVO; X=EDITAR }
            BarraMensaje((SeguridadWS.RespuestaEntidad)resultado, pantallaIdOculto.Value);

            //Bloque 7 Requerimiento 1-24381561
            if (((SeguridadWS.RespuestaEntidad)resultado).ValorError.Equals(0))
                this.pantallaIdOculto.Value = ((SeguridadWS.RespuestaEntidad)resultado).ValorEstado.ToString();

            return (SeguridadWS.RespuestaEntidad)resultado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ELIMINA UN REGISTRO*/
    private void EliminarEntidad(string desPagina, SiganemSeguridadWS wsSeguridad, object entidad)
    {
        try
        {
            string exec = desPagina.Replace(" ", "") + "Eliminar";
            Type ws = wsSeguridad.GetType();
            MethodInfo metodo = ws.GetMethod(exec);
            var resultado = metodo.Invoke(wsSeguridad, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR) });
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*MODIFICA UN REGISTRO*/
    private void ModificarEntidad(string desPagina, SiganemSeguridadWS wsSeguridad, object entidad)
    {
        try
        {
            string exec = string.Empty;
            if (pantallaModuloOculto.Value.Equals("169"))
            {
                exec = desPagina.Replace(" ", "") + "BienesModificar";
                Type ws = wsSeguridad.GetType();
                MethodInfo metodo = ws.GetMethod(exec);
                var resultado = metodo.Invoke(wsSeguridad, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR) });

                //IDENTIDAD { 0=NUEVO; X=EDITAR }
                BarraMensaje((SeguridadWS.RespuestaEntidad)resultado, pantallaIdOculto.Value);
            }
            else
            {
                exec = desPagina.Replace(" ", "") + "Modificar";
                Type ws = wsSeguridad.GetType();
                MethodInfo metodo = ws.GetMethod(exec);
                var resultado = metodo.Invoke(wsSeguridad, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR) });

                //IDENTIDAD { 0=NUEVO; X=EDITAR }
                BarraMensaje((SeguridadWS.RespuestaEntidad)resultado, pantallaIdOculto.Value);
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
        object entidad = null;
        string exec = string.Empty;

        try
        {
            #region OBTIENE EL TIPO DE LA ENTIDAD A CREAR DINAMICAMENTE

            //OBTIENE LA ENTIDAD DINAMICAMENTE
            entidad = ObtenerEntidad(entidad, pantallaModuloOculto.Value);
            //OBTIENE EL TIPO DE DATO DE LA ENTIDAD
            Type tipoEntidad = entidad.GetType(); 

            #endregion

            #region OBTIENE LAS PROPIEDADES DE LA ENTIDAD

            PropertyInfo[] propiedades = tipoEntidad.GetProperties();

            string entidadPropiedad = string.Empty;
            string entidadPropiedadTipo = string.Empty;

            #endregion

            #region ASIGNA EL VALOR DEL ID DEL REGISTRO A CONSULTAR

            foreach (PropertyInfo propiedad in propiedades)
            {
                //EL ID CORRESPONDE A LA PRIMERA PROPIEDAD DE CADA ENTIDAD
                if (propiedad.Name.Contains("Id"))
                {
                    entidadPropiedad = propiedad.Name;
                    entidadPropiedadTipo = propiedad.PropertyType.Name;
                    propiedad.SetValue(entidad, generadorControles.ConvertirTipoDato(entidadPropiedadTipo.ToUpper(), pantallaIdOculto.Value), null); //ASIGNA EL VALOR A LA PROPIEDAD
                    break; 
                }
            }

            #endregion

            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null && pantallaIdOculto.Value != "0") 
            {
                #region PANTALLA ROLES
                if (pantallaModuloOculto.Value.Equals("32"))
                {
                    exec = pantallaNombreOculto.Value.Replace(" ", "") + "ConsultarDetalle";
                    Type ws = wsSeguridad.GetType();
                    MethodInfo metodo = ws.GetMethod(exec);
                    var resultado = metodo.Invoke(wsSeguridad, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
                    return resultado;

                }
                #endregion
                #region PANTALLA USUARIOS
                if (pantallaModuloOculto.Value.Equals("33"))
                {
                    exec = pantallaNombreOculto.Value.Replace(" ", "") + "ConsultarDetalle";
                    Type ws = wsSeguridad.GetType();
                    MethodInfo metodo = ws.GetMethod(exec);
                    var resultado = metodo.Invoke(wsSeguridad, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
                    return resultado;

                }
                #endregion
                #region PANTALLA PARAMETROS USUARIOS
                if (pantallaModuloOculto.Value.Equals("169"))
                {
                    exec = pantallaNombreOculto.Value.Replace(" ", "") + "BienesConsultarDetalle";
                    Type ws = wsSeguridad.GetType();
                    MethodInfo metodo = ws.GetMethod(exec);
                    var resultado = metodo.Invoke(wsSeguridad, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
                    return resultado;

                }
                #endregion

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
                    case "idRole":
                        if (Request.Form["idRole"] != "" && Request.Form["idRole"] != null)
                        {
                            pantallaIdRoleOculto.Value = Request.Form["idRole"].ToString();
                        }
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
    private void BarraMensaje(SeguridadWS.RespuestaEntidad ds, string tipoAccion)
    {
        try
        {
            if (ds != null) //MENSAJES RETORNADOS DESDE BD
            {
                if (ds.ValorEstado.Equals(0))//ERROR
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

    /*MUESTRA BARRA DE MENSAJE SUPERIOR*/
    private void BarraMensaje(SeguridadWS.RespuestaEntidad ds, string tipoAccion, string codigoMensaje)
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
                //MENSAJE DE VALIDACION DE EXISTENCIA DE USUARIO EN EL ACTIVE DIRECTORY
                // "SYS_3" o "SYS_5"
                mensajesEntidad.CodMensaje = codigoMensaje; 
                lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";
                resultadoProceso = -1;
            }

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

    protected SeguridadWS.BitacorasEntidad AsignarValoresBitacora(EnumTipoBitacora _tipo)
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
            pantallasEntidad = null;

            disponible = true;
        }
    }

    #endregion

}