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

using ListasWS;
using SesionesWCF;
using SeguridadWS;
using ConfiguracionWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;


public partial class ConfiguracionNew : System.Web.UI.Page
{

    #region PROPIEDADES

    #region VARIABLES

    private int tipoAccion = 0;
    private int banderaVentana = 0;
    private int resultadoProceso = 0;

    static DataTable tablaGrid = null;
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

    private Button btnAgregar = null;
    private Button btnEliminar = null;

    private wucGridControl grid = null;

    #endregion

    #region REFERENCIAS
    
    private BitacoraFlags bitacoraBanderas = new BitacoraFlags();
    private GeneradorControles generadorControles = new GeneradorControles();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();    
    private ConfiguracionWS.BitacorasEntidad bitacorasEntidad = new ConfiguracionWS.BitacorasEntidad();

    //SERVICIOS WEBS
    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();
    private SiganemConfiguracionWS wsConfiguracion = new SiganemConfiguracionWS();

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

            #region MENSAJE ELIMINAR

            Button btnAceptarEliminar = (Button)this.EliminarBox1.FindControl("wucBtnAceptar");
            btnAceptarEliminar.Click += new EventHandler(btnAceptarEliminar_Click);

            Button btnCancelarEliminar = (Button)this.EliminarBox1.FindControl("wucBtnCancelar");
            btnCancelarEliminar.Click += new EventHandler(btnCancelarEliminar_Click);

            #endregion

            #region MENSAJE INFORMAR

            Button btnAceptarInformar = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            btnAceptarInformar.Click += new EventHandler(btnAceptarInformar_Click);
            btnAceptarInformar.CausesValidation = false;

            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion


            #endregion

            if (!IsPostBack)
            {
                valorReemplazo = string.Empty;
                tablaGrid = null;
                VariablesGlobales();
            }
            //else
            //{
            //    Set_RutaVentana();
            //}
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
                //if (pantallaIdOculto.Value.Equals("0"))
                //{
                //    ControlGridExcepciones(false);
                //}
                //else
                //{
                //    //Ajuste Tipo Mitigador 27012015
                //    MensajesExcepciones();
                //}

                if (!IsPostBack)
                {
                    //CARGA LOS VALORES PARA LOS TITULOS
                    Etiquetas(); 
                    //CARGA LOS VALORES DESDE BD PARA EL CASO DE LAS MODIFICACIONES    
                    DeEntidadAControles(); 

                    if (pantallaIdOculto.Value.Equals("0"))
                    {
                        ControlGridExcepciones(false);
                        DdlExecpciones();
                    }
                    else
                    {
                        //Ajuste Tipo Mitigador 27012015
                        MensajesExcepciones();
                    }
                }
                ControlGridExcepcionesTipoMitigador();
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

    //Requerimiento Bloque 7 1-24381561
    /*ASIGNA LOS VALORES DEL CONTROL DE REGISTRO A LA ENTIDAD EN MODO NUEVO PARA LOS CATALOGOS CON EXCEPCIONES*/
    private void CrearControlRegistrosExcepciones(object _entidad)
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

    /*CONTIENE LAS EXCEPCION QUE POSEEN LOS CATALOGOS AL ASIGNAR VALORES A LAS ENTIDADES*/
    private object ControlesExcepciones(object entidad)
    {
        try
        {
            object obj = entidad;

            switch (pantallaModuloOculto.Value)
            {
                #region EXCEPCION TASADORES
                case "152":
                    ((TasadoresEntidad)obj).OrigenTasador = "P";
                    break;
                case "168":
                    ((TasadoresEntidad)obj).OrigenTasador = "P";
                    break;
                case "157":
                    ((TasadoresEntidad)obj).OrigenTasador = "E";
                    ((TasadoresEntidad)obj).CodTipoTasador = "E";
                    break;
                #endregion

                #region EXCEPCION ZONA TASADOR
                case "156":
                    ((DistribucionesZonasTasadoresEntidad)obj).CodTipoDistribucionZonaTasador = "I";
                    break;
                case "155":
                    ((DistribucionesZonasTasadoresEntidad)obj).CodTipoDistribucionZonaTasador = "X";
                    break;
                #endregion

                #region EXCEPCION ZONA TASADOR
                case "160":
                    ((ZonasTasadoresEntidad)obj).CodTipoZonaTasador = "I";
                    break;
                case "167":
                    ((ZonasTasadoresEntidad)obj).CodTipoZonaTasador = "X";
                    break;
                #endregion
            }

            return obj;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private int ValidacionesGridExcepciones()
    {
        try
        {
            int retorno = 0;

            switch (pantallaModuloOculto.Value)
            {
                //REQUERIMIENTO 1-24653624
                //TIPOS MITIGADORES
                case "139":
                    retorno = ((wucGridControl)this.tableData.FindControl(string.Concat("grid", "Calificacion_Tipo_Mitigador"))).ExisteRegistros(tablaGrid);
                    break;
                //TASADORES EXTERNOS
                case "152":
                    retorno = ((wucGridControl)this.tableData.FindControl(string.Concat("grid", "Caracteristicas"))).ExisteRegistros(tablaGrid);
                    break;
                //EMPRESAS CALIFICADORAS
                case "153":
                    retorno = ((wucGridControl)this.tableData.FindControl(string.Concat("grid", "Calificacion_Empresa"))).ExisteRegistros(tablaGrid);
                    break;
                //TASADORES INTERNOS
                case "168":
                    retorno = ((wucGridControl)this.tableData.FindControl(string.Concat("grid", "Caracteristicas"))).ExisteRegistros(tablaGrid);
                    break;
                default:
                    retorno = 1;
                    break;
            }
            return retorno;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DeEntidadAControlesExcepciones(List<KeyValuePair<string,string>> valorEntidad)
    {
        try
        {
            int contador = 0;
            string identificacion = string.Empty;
            MaskedEditExtender mskIdentificacion = null;
            DropDownList ddlTipoPersona = null;
            TextBox txtIdentificacion = null;
            DropDownList ddlCanton = null;
           
            switch (pantallaModuloOculto.Value)
            {
                //DISTRITOS
                case "73":
                    ddlCanton = ((DropDownList)this.tableData.FindControl("IdCanton"));
                    KeyValuePair<string, string> valorDdl = (from valor in valorEntidad
                                                             where valor.Key.ToString().Equals("IdCanton")
                                                             select valor).FirstOrDefault();
                    generadorControles.SeleccionarOpcionDropDownList(ddlCanton, valorDdl.Value.ToString());
                    break;
                //FISCALIZADORES
                case "158":
                //TASADORES INTERNOS
                case "168":
                //TASADORES EXTERNOS
                case "152":
                    identificacion = "CodTasador";
                    ddlTipoPersona = ((DropDownList)this.tableData.FindControl("IdTipoPersona"));
                    mskIdentificacion = ((MaskedEditExtender)this.tableData.FindControl(string.Concat("mask", identificacion)));
                    txtIdentificacion = ((TextBox)this.tableData.FindControl(identificacion));
                    break;
                //NOTARIOS
                case "159":
                    identificacion = "CodNotario";
                    ddlTipoPersona = ((DropDownList)this.tableData.FindControl("IdTipoPersona"));
                    mskIdentificacion = ((MaskedEditExtender)this.tableData.FindControl(string.Concat("mask", identificacion)));
                    txtIdentificacion = ((TextBox)this.tableData.FindControl(identificacion));
                    break;
                //TIPO AVAL
                case "191":
                    txtIdentificacion = ((TextBox)this.tableData.FindControl("IdAvalista"));
                    txtIdentificacion.Enabled = false;
                    break;


            }

            if (ddlTipoPersona != null && mskIdentificacion != null)
            {
                if (ddlTipoPersona.SelectedItem.Text.Substring(0, 3).Equals("5 -"))
                {
                    for (contador = 0; contador < valorEntidad.Count; contador++)
                    {
                        if (valorEntidad[contador].Key.ToString().Equals(identificacion))
                        {
                            mskIdentificacion.Enabled = false;
                            txtIdentificacion.Text = valorEntidad[contador].Value.ToString();
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

    /*CONTIENE LAS EXCEPCION QUE POSEEN LOS CATALOGOS AL INSERTAR*/
    private void InsertarExcepciones(ConfiguracionWS.RespuestaEntidad ds)
    {
        try
        {
            if (pantallaModuloOculto.Value.Equals("139") || pantallaModuloOculto.Value.Equals("152") || pantallaModuloOculto.Value.Equals("153") || pantallaModuloOculto.Value.Equals("168"))
            {
                if (!ds.ValorEstado.Equals(0))
                {
                    //PARA NUEVO REGISTRO INSERTADO SE DEBE REDIRECCIONAR AUTOMATICAMENTE A LA PANTALLA DE EDICION
                    if (tipoAccion.Equals(0) && (!ds.ValorEstado.Equals(0)))
                    {
                        pantallaIdOculto.Value = ds.ValorEstado.ToString();

                        //HttpHelper post = new HttpHelper();
                        //post.RedirectAndPOSTNewWindow(this.Page, "../Detalles/ConfiguracionNew.aspx", Set_RutaVentana());

                        //Cerrar();

                        //Ajuste Tipo Mitigador 27012015
                        BloquerControlesGuardarExcepcion();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Ajuste Tipo Mitigador 27012015
    private void DeshabilitarControlesExcepciones(int _tipoAccion)
    {
        try
        {
            if (!pantallaIdOculto.Value.Equals("0"))
            {
                if (pantallaModuloOculto.Value.Equals("155") || pantallaModuloOculto.Value.Equals("156"))
                {
                    ((DropDownList)(this.tableData.FindControl("IdZonaTasador"))).Enabled = false;
                    ((DropDownList)(this.tableData.FindControl("IdProvincia"))).Enabled = false;
                    ((DropDownList)(this.tableData.FindControl("IdCanton"))).Enabled = false;
                    ((DropDownList)(this.tableData.FindControl("IdDistrito"))).Enabled = false;
                }
                ControlGridExcepciones(true);
            }
            //else
            //{
            //    ControlGridExcepciones(false);
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ControlGridExcepcionesTipoMitigador()
    {
        try
        {
            
            //TIPO MITIGADOR
            if (pantallaModuloOculto.Value.Equals("139"))
            {
                DropDownList ddlTipoGarantia = ((DropDownList)(this.tableData.FindControl("IdTipoGarantia")));
                DropDownList ddlCategoriaCalificacion = ((DropDownList)(this.tableData.FindControl("IdCategoriaCalificacion")));
                TextBox txtPorcAceptacion = ((TextBox)(this.tableData.FindControl("PorcAceptacionCalificacionRiesgo")));
                Button btnAgregar = ((Button)((wucGridControl)(this.tableData.FindControl("gridCalificacion_Tipo_Mitigador"))).FindControl("imgCmdAgregar"));
                GridView gridView = ((GridView)this.tableData.FindControl(string.Concat("gridCalificacion_Tipo_Mitigador")).FindControl("MasterGridView"));
                TextBox txtCodMitigador = ((TextBox)(this.tableData.FindControl("CodTipoMitigadorRiesgo")));

                bool modificable = false;


                if (!pantallaIdOculto.Value.Equals("0"))
                {
                    int codMitigador = (txtCodMitigador.Text.Length > 0) ? int.Parse(txtCodMitigador.Text) : -1;

                    //SI EL MITIGADOR ESTÁ ENTRE 0 Y 9
                    if (codMitigador > -1 && codMitigador < 10)
                    {
                        if (gridView.Rows.Count > 0)
                            modificable = false;
                        else
                            modificable = true;

                        ddlTipoGarantia.Enabled = modificable;
                        ddlCategoriaCalificacion.Enabled = modificable;
                        txtPorcAceptacion.Enabled = modificable;
                        btnAgregar.Enabled = modificable;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlExecpciones()
    {
        if (pantallaModuloOculto.Value.Equals("191"))
        {
            DdlTipoPersonaTipoAval(null);
        }
    }
    
    private void ControlGridExcepciones(bool modificable)
    {
        try
        {
            if (pantallaModuloOculto.Value.Equals("139"))
            {
                ((DropDownList)(this.tableData.FindControl("IdTipoGarantia"))).Enabled = modificable;
                ((DropDownList)(this.tableData.FindControl("IdCategoriaCalificacion"))).Enabled = modificable;
                ((TextBox)(this.tableData.FindControl("PorcAceptacionCalificacionRiesgo"))).Enabled = modificable;
                ((MaskedEditExtender)(this.tableData.FindControl("maskPorcAceptacionCalificacionRiesgo"))).AutoComplete = true;                
                ((Button)((wucGridControl)(this.tableData.FindControl("gridCalificacion_Tipo_Mitigador"))).FindControl("imgCmdAgregar")).Enabled = modificable;
                ((Button)((wucGridControl)(this.tableData.FindControl("gridCalificacion_Tipo_Mitigador"))).FindControl("imgCmdEliminar")).Enabled = modificable;
            }

            if (pantallaModuloOculto.Value.Equals("152"))
            {
                ((DropDownList)(this.tableData.FindControl("IdZonaTasador"))).Enabled = modificable;
                ((DropDownList)(this.tableData.FindControl("IdTipoServicio"))).Enabled = modificable;
                ((TextBox)(this.tableData.FindControl("CodEmpresaTasadora"))).Enabled = modificable;
                ((TextBox)(this.tableData.FindControl("DesEmpresaTasadora"))).Enabled = modificable;
                ((Button)((wucGridControl)(this.tableData.FindControl("gridCaracteristicas"))).FindControl("imgCmdAgregar")).Enabled = modificable;
                ((Button)((wucGridControl)(this.tableData.FindControl("gridCaracteristicas"))).FindControl("imgCmdEliminar")).Enabled = modificable;
            }

            if (pantallaModuloOculto.Value.Equals("153"))
            {
                ((DropDownList)(this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora"))).Enabled = modificable;
                ((TextBox)(this.tableData.FindControl("Calificacion"))).Enabled = modificable;
                ((Button)((wucGridControl)(this.tableData.FindControl("gridCalificacion_Empresa"))).FindControl("imgCmdAgregar")).Enabled = modificable;
                ((Button)((wucGridControl)(this.tableData.FindControl("gridCalificacion_Empresa"))).FindControl("imgCmdEliminar")).Enabled = modificable;
            }

            if (pantallaModuloOculto.Value.Equals("168"))
            {
                ((DropDownList)(this.tableData.FindControl("IdZonaTasador"))).Enabled = modificable;
                ((DropDownList)(this.tableData.FindControl("IdTipoServicio"))).Enabled = modificable;
                ((Button)((wucGridControl)(this.tableData.FindControl("gridCaracteristicas"))).FindControl("imgCmdAgregar")).Enabled = modificable;
                ((Button)((wucGridControl)(this.tableData.FindControl("gridCaracteristicas"))).FindControl("imgCmdEliminar")).Enabled = modificable;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region EVENTOS CLICK

    #region EVENTOS BOTONES GRID

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                AgregarFilaGrid(sender, e);
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                string grid = string.Empty;
                switch (pantallaModuloOculto.Value)
                {
                    case "139":
                        grid = "Calificacion_Tipo_Mitigador";
                        break;                    
                    case "152":
                        grid = "Caracteristicas";
                        break;
                    case "153":
                        grid = "Calificacion_Empresa";
                        break;
                    case "168":
                        grid = "Caracteristicas";
                        break;
                }
                if (((wucGridControl)this.tableData.FindControl(string.Concat("grid", grid))).ContadorSeleccionados() > 0)
                {
                    mpeEliminarBox.Show();
                }
                else
                {
                    ActualizarGrid();
                    LimpiarCamposGrid();
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

    protected void btnAyudaGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            // 0 = SE MANTIENE EL MISMO REGISTRO
            banderaVentana = 0; 
            //GUARDA Y ACTUALIZA PADRE
            Guardar();
            ActualizarVentanaPadre();
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

                //Ajuste Tipo Mitigador 27012015
                //if ((!lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError")) && (!this.divBarraMensaje.Visible))
                if ((!lblBarraMensaje.CssClass.Equals("etiquetaBarraMensajeError")) )
                    ControlGridExcepciones(true);
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
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                Cerrar();
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
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                Cerrar();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/ErrorDetalle.aspx", false);
        }
    }

    #region VENTANAS DE MENSAJES

    protected void btnAceptarEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (sesion.Codigo == 0)
            {
                string grid = string.Empty;
                switch (pantallaModuloOculto.Value)
                {
                    case "139":
                        grid = "Calificacion_Tipo_Mitigador";
                        break;
                    case "152":
                        grid = "Caracteristicas";
                        break;
                    case "153":
                        grid = "Calificacion_Empresa";
                        break;
                    case "168":
                        grid = "Caracteristicas";
                        break;
                }
                EliminarFilaGrid(sender, e);
            }
        }
        catch
        {
            this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.DeleteErr.ToString());
            this.mpeInformarBox.Show();
        }
    }

    protected void btnCancelarEliminar_Click(object sender, EventArgs e)
    {
        this.mpeEliminarBox.Hide();
    }

    protected void btnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBox.Hide();
        ActualizarGrid();
        LimpiarCamposGrid();
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

        //Ajuste Tipo Mitigador 27012015
        if (tipoAccion.Equals(0))
            MensajesExcepciones();
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

    private void AgregarFilaGrid(object sender, EventArgs e)
    {
        try
        {
            ConfiguracionWS.RespuestaEntidad respuesta = null;

            bool correcto = true;

            switch (pantallaModuloOculto.Value)
            {
                //REQUERIMIENTO 1-24653624
                //TIPO MITIGADOR
                case "139":                    
                    if (correcto)
                    { 
                        CategoriasCalificacionesTiposMitigadoresRiesgosEntidad entidad = new CategoriasCalificacionesTiposMitigadoresRiesgosEntidad();

                        entidad.IdTipoGarantia = int.Parse(((DropDownList)this.tableData.FindControl("IdTipoGarantia")).SelectedItem.Value);
                        entidad.IdCategoriaCalificacion = int.Parse(((DropDownList)this.tableData.FindControl("IdCategoriaCalificacion")).SelectedItem.Value);
                        if (((TextBox)this.tableData.FindControl("PorcAceptacionCalificacionRiesgo")).Text.Length > 0)
                            entidad.PorcentajeAceptacionCalificacionRiesgo = decimal.Parse(((TextBox)this.tableData.FindControl("PorcAceptacionCalificacionRiesgo")).Text);
                        else
                            entidad.PorcentajeAceptacionCalificacionRiesgo = decimal.Parse(((TextBoxWatermarkExtender)this.tableData.FindControl("wtePorcAceptacionCalificacionRiesgo")).WatermarkText);
                        entidad.IdTipoMitigadorRiesgo = int.Parse(pantallaIdOculto.Value);

                        //Bloque 7 Requerimiento 1-24381561
                        CrearControlRegistrosExcepciones(entidad);

                        respuesta = wsConfiguracion.CategoriasCalificacionesTiposMitigadoresRiesgosInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                        //SI EXISTE ERROR EN LA OPERACION
                        if (respuesta.ValorEstado.Equals(0))
                        {
                            this.InformarBox1_SetConfirmationBoxEvent(sender, e, "PrimaryKey");
                            this.mpeInformarBox.Show();
                        }
                        else
                        {
                            ActualizarGrid();
                            LimpiarCamposGrid();
                            ControlGridExcepcionesTipoMitigador();
                        }
                    }
                    else
                    {
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "Requerido");
                        this.mpeInformarBox.Show();
                    }
                    break;
                //TASADORES EXTERNOS
                case "152":

                    if (!string.IsNullOrEmpty(((TextBox)this.tableData.FindControl("CodEmpresaTasadora")).Text) && string.IsNullOrEmpty(((TextBox)this.tableData.FindControl("DesEmpresaTasadora")).Text))
                    {
                        valorReemplazo = "el campo Descripción Empresa Tasadora";
                        correcto = false;
                    }
                    if (string.IsNullOrEmpty(((TextBox)this.tableData.FindControl("CodEmpresaTasadora")).Text) && !string.IsNullOrEmpty(((TextBox)this.tableData.FindControl("DesEmpresaTasadora")).Text))
                    {
                        valorReemplazo = "el campo Código Empresa Tasadora";
                        correcto = false;
                    }

                    if (correcto)
                    {
                        CaracteristicasTasadoresEntidad entidad = new CaracteristicasTasadoresEntidad();

                        entidad.CodEmpresaTasadora = ((TextBox)this.tableData.FindControl("CodEmpresaTasadora")).Text;
                        entidad.DesEmpresaTasadora = ((TextBox)this.tableData.FindControl("DesEmpresaTasadora")).Text;
                        entidad.IdTipoServicio = int.Parse(((DropDownList)this.tableData.FindControl("IdTipoServicio")).SelectedItem.Value);
                        entidad.IdTipoPersona = int.Parse(((DropDownList)this.tableData.FindControl("IdTipoPersonaEmpresaTasadora")).SelectedItem.Value);
                        entidad.IdZonaTasador = int.Parse(((DropDownList)this.tableData.FindControl("IdZonaTasador")).SelectedItem.Value);
                        entidad.CodTipoCaracteristicaTasador = "X";

                        entidad.IdTasador = int.Parse(pantallaIdOculto.Value);

                        //Bloque 7 Requerimiento 1-24381561
                        CrearControlRegistrosExcepciones(entidad);

                        respuesta = wsConfiguracion.CaracteristicasTasadoresInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                        //SI EXISTE ERROR EN LA OPERACION
                        if (respuesta.ValorEstado.Equals(0))
                        {
                            this.InformarBox1_SetConfirmationBoxEvent(sender, e, "PrimaryKey");
                            this.mpeInformarBox.Show();
                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "refreshNewWindow", "window.location.reload();", true);
                            ActualizarGrid();
                            LimpiarCamposGrid();
                        }

                    }
                    else
                    {
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "Requerido");
                        this.mpeInformarBox.Show();
                    }
                    break;
                //EMPRESAS CALIFICADORAS
                case "153":
                    if (!string.IsNullOrEmpty(((TextBox)this.tableData.FindControl("Calificacion")).Text))
                    {
                        CalificacionesEmpresasCalificadorasEntidad entidad = new CalificacionesEmpresasCalificadorasEntidad();
                        entidad.idCategoriaRiesgoEmpresaCalificadora = int.Parse(((DropDownList)this.tableData.FindControl("IdCategoriaRiesgoEmpresaCalificadora")).SelectedItem.Value);
                        entidad.Calificacion = ((TextBox)this.tableData.FindControl("Calificacion")).Text;
                        entidad.IdEmpresaCalificadora = int.Parse(pantallaIdOculto.Value);

                        //Bloque 7 Requerimiento 1-24381561
                        CrearControlRegistrosExcepciones(entidad);

                        respuesta = wsConfiguracion.CalificacionesEmpresasCalificadorasInsertar(entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                        //SI EXISTE ERROR EN LA OPERACION
                        if (respuesta.ValorEstado.Equals(0))
                        {
                            this.InformarBox1_SetConfirmationBoxEvent(sender, e, "PrimaryKey");
                            this.mpeInformarBox.Show();
                        }
                        else
                        {
                            //ScriptManager.RegisterStartupScript(this, typeof(string), "refreshNewWindow", "window.location.reload()", true);
                            ActualizarGrid();
                            LimpiarCamposGrid();
                        }

                    }
                    else
                    {
                        valorReemplazo = "el campo Calificación";
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "Requerido");
                        this.mpeInformarBox.Show();
                    }
                    break;
                //TASADORES INTERNOS
                case "168":
                    CaracteristicasTasadoresEntidad entidadInterna = new CaracteristicasTasadoresEntidad();

                    entidadInterna.IdTipoServicio = int.Parse(((DropDownList)this.tableData.FindControl("IdTipoServicio")).SelectedItem.Value);
                    entidadInterna.IdTipoPersona = int.Parse(((DropDownList)this.tableData.FindControl("IdTipoPersonaEmpresaTasadora")).SelectedItem.Value);
                    entidadInterna.IdZonaTasador = int.Parse(((DropDownList)this.tableData.FindControl("IdZonaTasador")).SelectedItem.Value);
                    entidadInterna.CodTipoCaracteristicaTasador = "I";

                    entidadInterna.IdTasador = int.Parse(pantallaIdOculto.Value);

                    //Bloque 7 Requerimiento
                    CrearControlRegistrosExcepciones(entidadInterna);

                    respuesta = wsConfiguracion.CaracteristicasTasadoresInsertarInterno(entidadInterna, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR));

                    //SI EXISTE ERROR EN LA OPERACION
                    if (respuesta.ValorEstado.Equals(0))
                    {
                        this.InformarBox1_SetConfirmationBoxEvent(sender, e, "PrimaryKey");
                        this.mpeInformarBox.Show();
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, typeof(string), "refreshNewWindow", "window.location.reload()", true);
                        ActualizarGrid();
                        LimpiarCamposGrid();
                    }

                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void EliminarFilaGrid(object sender, EventArgs e)
    {
        GridView gridView = null;
        ConfiguracionWS.RespuestaEntidad respuesta = null;
        string nombreGrid = string.Empty;
        string nombreId = string.Empty;

        CaracteristicasTasadoresEntidad entidadTasador = new CaracteristicasTasadoresEntidad();
        CalificacionesEmpresasCalificadorasEntidad entidadCalificacion = new CalificacionesEmpresasCalificadorasEntidad();
        CaracteristicasTasadoresEntidad entidadTasadorInterno = new CaracteristicasTasadoresEntidad();
        CategoriasCalificacionesTiposMitigadoresRiesgosEntidad entidadCategoriaTipoMitigador = new CategoriasCalificacionesTiposMitigadoresRiesgosEntidad();

        switch (pantallaModuloOculto.Value)
        {
            //TIPOS MITIGADORES
            case "139":
                nombreGrid = "Calificacion_Tipo_Mitigador";
                nombreId = "IdCategoriaCalificacionRiesgoTipoMitigador";
                break;
            //TASADORES EXTERNOS
            case "152":
                nombreGrid = "Caracteristicas";
                nombreId = "IdCaracteristicaTasador";
                break;
            //EMPRESAS CALIFICADORAS
            case "153":
                nombreGrid = "Calificacion_Empresa";
                nombreId = "IdCalificacionEmpresaCalificadora";
                break;
            //TASADORES INTERNOS
            case "168":
                nombreGrid = "Caracteristicas";
                nombreId = "IdCaracteristicaTasador";
                break;
        }

        try
        {
            gridView = ((GridView)this.tableData.FindControl(string.Concat("grid",nombreGrid)).FindControl("MasterGridView"));

            foreach (GridViewRow row in gridView.Rows)
            {
                CheckBox checkBoxColumn = (CheckBox)gridView.Rows[row.RowIndex].FindControl("chkBox1");

                if (checkBoxColumn.Checked)
                {
                    #region ENTIDAD CONSULTA

                    Label lbl = (Label)gridView.Rows[row.RowIndex].FindControl(string.Concat("lbl",nombreId));
                                      

                    #endregion

                    if (pantallaModuloOculto.Value.Equals("139"))
                    {
                        entidadCategoriaTipoMitigador.IdCategoriaCalificacionRiesgoTipoMitigador = int.Parse(lbl.Text);
                        respuesta = wsConfiguracion.CategoriasCalificacionesTiposMitigadoresRiesgosEliminar(entidadCategoriaTipoMitigador, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));
                    }
                    if (pantallaModuloOculto.Value.Equals("152"))
                    {
                        entidadTasador.IdCaracteristicaTasador = int.Parse(lbl.Text);
                        respuesta = wsConfiguracion.CaracteristicasTasadoresEliminar(entidadTasador, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));
                    }
                    if (pantallaModuloOculto.Value.Equals("153"))
                    {
                        entidadCalificacion.IdCalificacionEmpresaCalificadora = int.Parse(lbl.Text);
                        respuesta = wsConfiguracion.CalificacionesEmpresasCalificadorasEliminar(entidadCalificacion, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));
                    }
                    if (pantallaModuloOculto.Value.Equals("168"))
                    {
                        entidadTasadorInterno.IdCaracteristicaTasador = int.Parse(lbl.Text);
                        respuesta = wsConfiguracion.CaracteristicasTasadoresEliminar(entidadTasadorInterno, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR));
                    }
                }
            }
            if (!respuesta.ValorEstado.Equals(0))
            {
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.DeleteOK.ToString());
                ActualizarGrid();
                LimpiarCamposGrid();
                ControlGridExcepcionesTipoMitigador();
            }
                       
        }
        catch
        {
            this.InformarBox1_SetConfirmationBoxEvent(sender, e, EnumTipoMensaje.DeleteErr.ToString());
            this.mpeInformarBox.Show();
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
                //CARGA EL NOMBRE DE LA PANTALLA EN LA SECCION INFERIOR IZQUIERDA
                ((Button)this.Master.FindControl("MenuLateral1").FindControl("cmdAreaMenuLateralDetalleBoton")).Text = pantallaTituloOculto.Value;

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

                List<NodoMenuEntidad> menu = wsListas.AdministracionesContenidosConsultaPestanas(pantalla).ToList();

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
                controles = wsListas.AdministracionesContenidosConsultaControl(pantalla).ToList();

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
    public void LlenarTabla(Table tblPrincipal, string desPagina, List<ControlEntidad> dsControles)
    {
        Boolean AssocRowReady = false;
        #region CREA CONTROLES

        // CREA OBJETO REQUIRED FIELD VALIDATOR
        RequiredFieldValidator rfv = null;

        // CREA OBJETO MaskedEditExtender Ajax Control
        MaskedEditExtender msk = null;

        // CREA OBJETO TextBoxWatermarkExtender Ajax Control
        TextBoxWatermarkExtender wte = null;

        // CREA OBJETO CalendarExterder Ajax Control
        CalendarExtender calendarExtender = null;

        // CREA OBJETO TABLA TEMPORAL asp:Table
        tblPrincipal.ID = String.Concat("aspTable", pantallaNombreOculto.Value);

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
                msk = null;
                rfv = null;
                calendarExtender = null;

                string assocID = control.NombrePropiedadAsociada;
                int ancho;
                //0 = SIN ITEMS | 1 = CON ITEMS (PARA DROPDOWNLIST)
                int bandera = 0; 

                if (((Control)tblPrincipal.FindControl(control.NombrePropiedad)) == null)
                {
                    tableRow = new TableRow();
                    tableRow.ID = string.Concat("tr", control.NombrePropiedad);
                    tableRow.Height = Unit.Parse("10");

                    // CREA TABLE CELL
                    TableCell tc1 = new TableCell();
                    tc1.ID = String.Concat("tcRow", filasContador, "Cell", 0);
                    tc1.Width = Unit.Parse("200");
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

                    // AGREGA LA ETIQUETA A LA CELDA1 
                    tc1.Controls.Add(cellLabel);

                    // ASIGNA EL VALOR DEL TIPO DE OBJETO 
                    string tipoContenido = control.TipoContenido;
                    tipoContenido = tipoContenido.ToUpper();

                    // CREA TABLE CELL 2
                    TableCell tc2 = new TableCell();
                    tc2.ID = String.Concat("tc", "Row", filasContador, "Cell", "2");
                    tc2.Width = Unit.Parse("410");
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

                            txt.CausesValidation = true;

                            if (!String.IsNullOrEmpty(control.GrupoValidacion))
                            {
                                txt.ValidationGroup = control.GrupoValidacion;
                            }

                            if (txt.MaxLength > 50)
                                ancho = 390;
                            else
                                ancho = (txt.MaxLength * 9);

                            if (ancho > 390)
                                ancho = 390;

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

                            #region TEXTBOX WATERMARKEXTENDER

                            if (msk != null)
                            {
                                if (msk.MaskType == MaskedEditType.Number)
                                {
                                    if (control.ValorDefecto.Equals("0"))
                                    {
                                        wte = new TextBoxWatermarkExtender();
                                        wte.ID = String.Concat("wte", nombrePropiedad);
                                        wte.TargetControlID = txt.ID;
                                        wte.WatermarkText = string.Format("{0:N}", decimal.Parse(control.ValorDefecto));
                                    }
                                }
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
                            mTxt.Width = 390;

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
                                ddl.DataSource = LlenarDropDownList(spText, control.ValorServicioWeb);
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
                                //SE ASIGNA EL ELEMENTO SELECCIONADO POR DEFECTO
                                ddlValorSeleccionado = ddl.SelectedValue.ToString(); 
                            }

                            ddl.ToolTip = String.Concat("Lista de ", control.DesColumna);
                            ddl.Enabled = bool.Parse(control.IndModificar);
                            ddl.Visible = bool.Parse(control.IndVisible);
                            ddl.CssClass = control.CssTipo;
                            ddl.Width = Unit.Parse("150");

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
                                    ddlAssocID.Width = Unit.Parse("150");

                                    ddlAssocID.Items.Clear();

                                    //NO HAY ITEMS
                                    if (bandera.Equals(0))
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

                                    AssocRowReady = true;
                                    tblPrincipal.Rows.Add(tableRow);

                                    tableRowAssocID.Cells.Add(tcAssocIDLabel);
                                    tableRowAssocID.Cells.Add(tcAssocID);
                                    tblPrincipal.Rows.Add(tableRowAssocID);
                                }
                            }

                            break;
                        #endregion

                        #region RADIO BUTTON
                        case "RADIOBUTTON":

                            RadioButton rbn = new RadioButton();
                            rbn.ID = nombrePropiedad;
                            rbn.Text = string.Empty;
                            rbn.ToolTip = String.Concat("Botón de Selección ", control.DesColumna);
                            rbn.Enabled = bool.Parse(control.IndModificar);
                            rbn.Visible = bool.Parse(control.IndVisible);
                            rbn.CssClass = control.CssTipo;

                            tc2.Controls.Add(rbn);

                            break;
                        #endregion

                        #region CHECK BOX
                        case "CHECKBOX":

                            CheckBox chk = new CheckBox();
                            chk.ID = nombrePropiedad;
                            chk.Text = control.DesColumna;
                            chk.ToolTip = String.Concat("Caja de Selección ", control.DesColumna);
                            chk.Enabled = bool.Parse(control.IndModificar);
                            chk.Visible = bool.Parse(control.IndVisible);
                            chk.CssClass = control.CssTipo;
                            chk.Width = 90;
                            chk.AutoPostBack = true;

                            tc2.Controls.Add(chk);

                            break;
                        #endregion

                        #region TREEVIEW CHECKBOX
                        case "TREEVIEWCHECKBOX":

                            TreeView treeViewCheckBox = new TreeView();
                            treeViewCheckBox.ID = nombrePropiedad;
                            treeViewCheckBox.ShowCheckBoxes = TreeNodeTypes.All;                            
                            treeViewCheckBox.ToolTip = String.Concat("Árbol de ", control.DesColumna);
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
                            imbCalendario.ImageUrl = ("~/Library/img/32/iconCalendario.gif");
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
                            calendarExtender.PopupPosition = CalendarPosition.Right;
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

                            if (control.IndRequerido.Equals("True"))
                                calendarCell_2.Controls.Add(rfv);

                            //SE ASIGNAN LOS CONTROLES CREADOS ANTERIORMENTE A LA TABLA
                            calendarRow.Cells.Add(calendarCell_1);
                            calendarRow.Cells.Add(calendarCell_2);
                            calendarTable.Rows.Add(calendarRow);
                            tc2.Controls.Add(calendarTable);

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
                            grid.BindGridView(GridDataTable(control.NombreColumna, control.MetodoServicioWeb, 0));

                            pn.Controls.Add(grid);
                            tc5.Controls.Add(pn);

                            // AGREGA LA CELDA5 A LA FILA
                            tableRow.Cells.Add(tc5);

                            btnAgregar = (Button)grid.FindControl("imgCmdAgregar");
                            btnAgregar.Click +=new EventHandler(btnAgregar_Click);

                            btnEliminar = (Button)grid.FindControl("imgCmdEliminar");
                            btnEliminar.Click += new EventHandler(btnEliminar_Click);
                            btnEliminar.CausesValidation = false;

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
                            if (wte != null)
                            {
                                tc2.Controls.Add(wte);
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

                    tc3.Width = Unit.Parse("90");
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

            DeshabilitarControlesExcepciones(tipoAccion);

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
            //object _entidad = null;
            DataTable dt = new DataTable();
            List<KeyValuePair<string, string>> valoresEntidad = new List<KeyValuePair<string, string>>();

            #region CONTROLES COMODIN
            TextBox txt = null;
            DropDownList ddl = null;
            #endregion

            //Bloque 7 Requerimiento 1-24381561
            /*if (pantallaModuloOculto.Value != null && pantallaIdOculto.Value != "0") //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            {
                #region OBTIENE EL TIPO DE LA ENTIDAD A CREAR DINAMICAMENTE

                _entidad = ObtenerEntidad(_entidad, pantallaModuloOculto.Value); //OBTIENE LA ENTIDAD DINAMICAMENTE
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
            
                //CONTIENE LAS EXCEPCION QUE POSEEN LOS CATALOGOS
                _entidad = ControlesExcepciones(_entidad);

                //OBTIENE EL RESTO DE CAMPOS DEL REGISTRO A CONSULTAR DESDE LA BD            
                string exec = pantallaNombreOculto.Value.Replace(" ","").Replace("é","e").Replace("ó","o").Replace("í","i") + "ConsultarDetalle";
                exec = ExcepcionModuloOculto(exec, pantallaModuloOculto.Value, "ConsultarDetalle");
                Type ws = wsConfiguracion.GetType();
                MethodInfo method = ws.GetMethod(exec);
                var result = method.Invoke(wsConfiguracion, new object[] { _entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
            */

            var result = ConsultarDetalleEntidad();

            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (result != null) 
            {
                //RECORRE EL RESULTADO OBTENIDO
                Type tipoControl = null;
                Object control = null;
                string asignarValor = string.Empty;

                PropertyInfo[] propiedadesDetalle = result.GetType().GetProperties();
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
                                if (propiedadDetalle.GetValue(result, null) == null)
                                    asignarValor = string.Empty;
                                else
                                {
                                    //SI ES UN VALOR DECIMAL SE DEBE DE MANTENER EL FORMATO
                                    //if (propertyDetalle.GetValue(result, null).GetType().Name.ToUpper().Equals("DOUBLE"))
                                    if (propiedadDetalle.GetValue(result, null).GetType().Name.ToUpper().Equals("DECIMAL"))
                                        asignarValor = String.Format("{0:0.00}", propiedadDetalle.GetValue(result, null));
                                    else
                                        if (propiedadDetalle.GetValue(result, null).GetType().Name.ToUpper().Equals("DATETIME"))
                                            asignarValor = String.Format("{0:d}", propiedadDetalle.GetValue(result, null));
                                        else
                                            asignarValor = propiedadDetalle.GetValue(result, null).ToString();
                                }
                                // ASIGNACION DEL TEXTO DESDE LA BD
                                txt.Text = asignarValor; 
                                txt.Enabled = true;
                                if ((propiedadDetalle.Name.Substring(0, 3)).Contains("Cod"))
                                    txt.Enabled = false;
                                break;
                            #endregion

                            #region MULTILINE
                            case "MULTILINE":
                                txt = (TextBox)control;
                                if (propiedadDetalle.GetValue(result, null) == null)
                                    asignarValor = string.Empty;
                                else
                                {
                                    //SI ES UN VALOR DECIMAL SE DEBE DE MANTENER EL FORMATO
                                    //if (propertyDetalle.GetValue(result, null).GetType().Name.ToUpper().Equals("DOUBLE"))
                                    if (propiedadDetalle.GetValue(result, null).GetType().Name.ToUpper().Equals("DECIMAL"))
                                        asignarValor = String.Format("{0:0.00}", propiedadDetalle.GetValue(result, null));
                                    else
                                        asignarValor = propiedadDetalle.GetValue(result, null).ToString();
                                }
                                // ASIGNACION DEL TEXTO DESDE LA BD
                                txt.Text = asignarValor; 
                                txt.Enabled = true;
                                break;
                            #endregion

                            #region DROPDOWNLIST
                            case "DROPDOWNLIST":
                                ddl = (DropDownList)control;
                                if (propiedadDetalle.GetValue(result, null) == null)
                                    asignarValor = "-1";
                                else
                                {
                                    asignarValor = propiedadDetalle.GetValue(result, null).ToString();
                                }
                                //ASIGNACION DEL VALOR DESDE LA BD
                                generadorControles.SeleccionarOpcionDropDownList(ddl, asignarValor);
                                if ((propiedadDetalle.Name.ToString()).Contains("IdTipoPersona"))
                                    ddl.Enabled = false;
                                valoresEntidad.Add(new KeyValuePair<string, string>(propiedadDetalle.Name, asignarValor));
                                dropDownList_SelectedIndexChanged(ddl, null);
                                break;
                            #endregion
                        }
                    }
                    //Requerimiento Bloque 7 1-24381561 
                    else
                    {
                        ObtenerControlRegistros(result, propiedadDetalle);
                    }
                }

                //REALIZA LAS EXCEPCIONES DE LA CARGA DE DATOS A LOS CONTROLES
                DeEntidadAControlesExcepciones(valoresEntidad);
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
        try
        {
            object entidad = null;
            string valorControl = string.Empty;
            var regexItem = new Regex("^[a-zA-Z0-9 .,/:ÁÉÍÓÚÑáéíóúñ()]*$");
            int banderaPropiedad = 1;

            // 0 = NO | 1 = SI
            int caracteresEspeciales = 0; 

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
                    //_entidadPropiedadTipo = property.PropertyType.Name;

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
                                    if (pantallaModuloOculto.Value == "191" && propiedad.Name != "DesTipoAval")
                                    {
                                        if (!regexItem.IsMatch(valorControl))
                                        {
                                            caracteresEspeciales = 1;
                                        }
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
                            propiedad.SetValue(entidad, generadorControles.ConvertirTipoDato(entidadPropiedadTipo.ToUpper(), pantallaIdOculto.Value), null);//ASIGNA EL VALOR A LA PROPIEDAD
                        }
                        banderaPropiedad++;
                    }

                    //Requerimiento Bloque 7 1-24381561
                    CrearControlRegistros(entidad, propiedad);
                }

                //CONTIENE LAS EXCEPCION QUE POSEEN LOS CATALOGOS
                entidad = ControlesExcepciones(entidad);

                if (ValidarTipoPersona(entidad))
                {
                    #region DIRECCIONAMIENTO SEGUN EL TIPO DE ACCION

                    // NO EXISTEN CARACTERES ESPECIALES
                    if (caracteresEspeciales != 1) 
                    {
                        switch (tipoAccion)
                        {
                            case 0:
                                InsertarEntidad(pantallaNombreOculto.Value, wsConfiguracion, entidad);
                                break;
                            case 1:
                                ModificarEntidad(pantallaNombreOculto.Value, wsConfiguracion, entidad);
                                break;
                            case 2:
                                EliminarEntidad(pantallaNombreOculto.Value, wsConfiguracion, entidad);
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
        if (valorAsignar.Length.Equals(0) && tipoDatoLargo.ToUpper().Contains("NULL"))
            retorno = "NULL";

        return retorno;
    }

    private bool ValidarTipoPersona(object _entidad)
    {
        try
        {
            bool resultado = true;
            String maskCampo = String.Empty;

            switch (pantallaModuloOculto.Value)
            {
                case "152":
                case "168":
                    if (!((TasadoresEntidad)_entidad).CodTasador.StartsWith("1"))
                    {
                        if (((DropDownList)this.tableData.FindControl("IdTipoPersona")).SelectedItem.Text.Contains("3"))
                            resultado = false;
                    }
                    break;
                case "158":
                    if (!((FiscalizadoresEntidad)_entidad).CodTasador.StartsWith("1"))
                    {
                        if (((DropDownList)this.tableData.FindControl("IdTipoPersona")).SelectedItem.Text.Contains("3"))
                            resultado = false;
                    }
                    break;
                case "159":
                    if (!((NotariosEntidad)_entidad).CodNotario.StartsWith("1"))
                    {
                        if (((DropDownList)this.tableData.FindControl("IdTipoPersona")).SelectedItem.Text.Contains("3"))
                            resultado = false;
                    }
                    break;
            }
            return resultado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region METODOS PARA EL DROPDOWNLIST

    private void DdlProvincia(object sender)
    {
        try
        {
            DropDownList ddlAsociado = null;
            ddlAsociado = (DropDownList)(this.tableData.FindControl("IdCanton"));
            if (ddlAsociado != null)
            {
                ddlAsociado.Items.Clear();
                ddlAsociado.DataSource = LlenarDropDownList("CantonesLista", ((DropDownList)(sender)).SelectedValue.ToString());
                ddlAsociado.DataTextField = "Texto";
                ddlAsociado.DataValueField = "Valor";
                ddlAsociado.DataBind();

                DdlCanton(ddlAsociado);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlCanton(object sender)
    {
        try
        {
            DropDownList ddlAsociado = null;
            ddlAsociado = (DropDownList)(this.tableData.FindControl("IdDistrito"));
            if (ddlAsociado != null)
            {
                ddlAsociado.Items.Clear();
                ddlAsociado.DataSource = LlenarDropDownList("DistritosLista", ((DropDownList)(sender)).SelectedValue.ToString());
                ddlAsociado.DataTextField = "Texto";
                ddlAsociado.DataValueField = "Valor";
                ddlAsociado.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlTipoPersona(object sender)
    {
        try
        {
            MaskedEditExtender msk = null;
            String mskCampo = String.Empty;

            switch (pantallaModuloOculto.Value)
            {
                case "152":
                    mskCampo = "codTasador";
                    break;
                case "158":
                    mskCampo = "codTasador";
                    break;
                case "159":
                    mskCampo = "CodNotario";
                    break;
                case "168":
                    mskCampo = "codTasador";
                    break;
            }

            msk = ((MaskedEditExtender)this.tableData.FindControl(string.Concat("mask", mskCampo)));

            if (msk != null)
            {             
                if (((TextBox)this.tableData.FindControl(mskCampo)).Enabled)
                {
                    ((TextBox)this.tableData.FindControl(mskCampo)).Text = string.Empty;
                }

                msk.InputDirection = MaskedEditInputDirection.LeftToRight;

                if (((DropDownList)(sender)).SelectedItem.Text.Contains("1"))
                {
                    msk.Enabled = true;
                    msk.Mask = "9-9999-9999";
                    ((TextBox)this.tableData.FindControl(mskCampo)).ToolTip = "#-####-####";
                    ((TextBox)this.tableData.FindControl(mskCampo)).MaxLength = 30;
                }
                if (((DropDownList)(sender)).SelectedItem.Text.Contains("2"))
                {
                    msk.Enabled = true;
                    msk.Mask = "9-999-999999";
                    ((TextBox)this.tableData.FindControl(mskCampo)).ToolTip = "#-###-######";
                    ((TextBox)this.tableData.FindControl(mskCampo)).MaxLength = 30;
                }
                if (((DropDownList)(sender)).SelectedItem.Text.Contains("3"))
                {
                    msk.Enabled = true;
                    msk.Mask = "9-999-999999-99";
                    msk.InputDirection = MaskedEditInputDirection.LeftToRight;
                    ((TextBox)this.tableData.FindControl(mskCampo)).ToolTip = "1-###-######-##";
                }
                if (((DropDownList)(sender)).SelectedItem.Text.Contains("5"))
                {
                    msk.Enabled = false;
                    ((TextBox)this.tableData.FindControl(mskCampo)).MaxLength = 17;
                    ((TextBox)this.tableData.FindControl(mskCampo)).ToolTip = "#################";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void DdlTipoPersonaTipoAval(object sender)
    {
        try
        {
            MaskedEditExtender msk = null;
            String mskCampo = String.Empty;
            mskCampo = "IdAvalista";
            string ddlNombre = "IdTipoPersona";

            msk = ((MaskedEditExtender)this.tableData.FindControl(string.Concat("mask", mskCampo)));

            if (msk != null)
            {
                TextBox txt = ((TextBox)this.tableData.FindControl(mskCampo));

                if (txt != null)
                {
                    txt.Text = string.Empty;
                    msk.InputDirection = MaskedEditInputDirection.LeftToRight;

                    DropDownList ddl = ((DropDownList)this.tableData.FindControl(ddlNombre));

                    if (ddl != null)
                    {

                        if (ddl.SelectedItem.Text.Substring(0, 3).Contains("5 -"))
                        {
                            msk.Enabled = false;
                            txt.MaxLength = 17;
                            txt.ToolTip = "#################";
                        }
                        else
                        {
                            msk.Enabled = false;
                            txt.MaxLength = 30;
                            txt.ToolTip = "Alfanumérico " + txt.MaxLength.ToString();
                            txt.Attributes.Add("maxlength","30");
                        }

                        if (ddl.SelectedItem.Text.Substring(0, 3).Contains("1 -"))
                        {
                            msk.Enabled = true;
                            msk.Mask = "9-9999-9999";
                            txt.ToolTip = "#-####-####";
                            txt.MaxLength = 30;
                        }
                        if (ddl.SelectedItem.Text.Substring(0, 3).Contains("2 -"))
                        {
                            msk.Enabled = true;
                            msk.Mask = "9-999-999999";
                            txt.ToolTip = "#-###-######";
                            txt.MaxLength = 30;
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
                #region PROVINCIA
                case "IDPROVINCIA":
                    DdlProvincia(sender);
                    break;
                #endregion

                #region CANTON
                case "IDCANTON":
                    DdlCanton(sender);
                    break;
                #endregion

                #region TASADOR
                case "IDTIPOPERSONA":
                    DdlTipoPersona(sender);
                    DdlTipoPersonaTipoAval(sender);
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

    #endregion

    #region METODOS PARA EL GRID

    private void GridDataTable(string logica, string metodoWS)
    {
        try
        {
            if (tablaGrid == null)
            {
                tablaGrid = new DataTable();
                tablaGrid = LlenarDataTable(metodoWS, pantallaIdOculto.Value).Tables[0];
            }
            if (tablaGrid.Columns.Count < 1)
            {
                string[] _logica = logica.Split('|');
                for (int i = 0; i < _logica.Length; i++)
                {
                    tablaGrid.Columns.Add(_logica[i].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private Object GridDataTable(string logica, string metodoWS, int valor)
    {
        try
        {
            return LlenarDataTable(metodoWS, pantallaIdOculto.Value, valor);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private DataSet LlenarDataTable(string wsMethodName, string filtro)
    {
        try
        {
            DataSet ds = null;

            Type ws = wsConfiguracion.GetType();
            MethodInfo metodo = ws.GetMethod(wsMethodName);
            var resultado = metodo.Invoke(wsConfiguracion, new object[] { filtro });
            ds = (DataSet)resultado;

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private Object LlenarDataTable(string wsMethodName, string filtro, int valor)
    {
        try
        {
            Type ws = wsConfiguracion.GetType();
            MethodInfo metodo = ws.GetMethod(wsMethodName);
            var resultado = metodo.Invoke(wsConfiguracion, new object[] { filtro });

            return resultado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ActualizarGrid()
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

                foreach (ControlEntidad _control in controles)
                {
                    if (_control.TipoContenido.Equals("GRIDVIEW"))
                    {
                        grid = (wucGridControl)this.tableData.FindControl(string.Concat("grid", _control.NombrePropiedad));
                        if (grid != null)
                        {
                            //grid.GridView_Init(_control.NombreColumna, _control.DesColumna);
                            grid.BindGridView(GridDataTable(_control.NombreColumna, _control.MetodoServicioWeb, 0));
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

    private void LimpiarCamposGrid()
    {
        TextBox txtCodEmpresaTasadora = null;
        TextBox txtDesEmpresaTasadora = null;
        TextBox txtCalificacion = null;
        TextBox txtPorcentajeAceptacion = null;

        if (pantallaModuloOculto.Value.Equals("139"))
        {
            txtPorcentajeAceptacion = (TextBox)this.tableData.FindControl("PorcAceptacionCalificacionRiesgo");
            if (txtPorcentajeAceptacion != null)
                txtPorcentajeAceptacion.Text = string.Empty;
        }

        if (pantallaModuloOculto.Value.Equals("152"))
        {
            txtCodEmpresaTasadora = (TextBox)this.tableData.FindControl("CodEmpresaTasadora");
            if (txtCodEmpresaTasadora != null)
                txtCodEmpresaTasadora.Text = string.Empty;

            txtDesEmpresaTasadora = (TextBox)this.tableData.FindControl("DesEmpresaTasadora");
            if (txtDesEmpresaTasadora != null)
                txtDesEmpresaTasadora.Text = string.Empty;
        }

        if (pantallaModuloOculto.Value.Equals("153"))
        {
            txtCalificacion = (TextBox)this.tableData.FindControl("Calificacion");
            if (txtCalificacion != null)
                txtCalificacion.Text = string.Empty;
        }
    }

    #endregion

    #endregion

    #region ENTIDADES

    /*RETORNA LA ENTIDAD SEGUN EL CODIGO DE LA PANTALLA*/
    public object ObtenerEntidad(object _entidad, string _codPagina)
    {
        try
        {
            #region OBTENER ENTIDAD

            switch (_codPagina)
            {
                case "32":
                    _entidad = new SeguridadWS.TiposRolesEntidad();
                    break;
                case "50":
                    _entidad = new ConfiguracionWS.ActivosEntidad();
                    break;
                case "51":
                    _entidad = new ConfiguracionWS.AplicablesEntidad();
                    break;
                case "52":
                    _entidad = new ConfiguracionWS.BienesValorarEntidad();
                    break;
                case "53":
                    _entidad = new ConfiguracionWS.CajasBreakersEntidad();
                    break;
                case "54":
                    _entidad = new ConfiguracionWS.CanalizacionesElectricasEntidad();
                    break;
                case "55":
                    _entidad = new ConfiguracionWS.CanoasBajantesEntidad();
                    break;
                case "56":
                    _entidad = new ConfiguracionWS.CantidadesFincasEntidad();
                    break;
                case "57":
                    _entidad = new ConfiguracionWS.CantonesEntidad();
                    break;
                case "58":
                    _entidad = new ConfiguracionWS.CategoriasCalificacionesEntidad();
                    break;
                case "59":
                    _entidad = new ConfiguracionWS.CategoriasRiesgosDeudoresEntidad();
                    break;
                case "60":
                    _entidad = new ConfiguracionWS.CerrajeriasPiezasSanitariasEntidad();
                    break;
                case "61":
                    _entidad = new ConfiguracionWS.CielosRasosEntidad();
                    break;
                case "62":
                    _entidad = new ConfiguracionWS.ClasesAeronavesEntidad();
                    break;
                case "63":
                    _entidad = new ConfiguracionWS.ClasesBuquesEntidad();
                    break;
                case "64":
                    _entidad = new ConfiguracionWS.ClasesGarantiasPrt17Entidad();
                    break;
                case "65":
                    _entidad = new ConfiguracionWS.ClasesVehiculosEntidad();
                    break;
                case "66":
                    _entidad = new ConfiguracionWS.CodigosDuplicadosEntidad();
                    break;
                case "67":
                    _entidad = new ConfiguracionWS.CodigosHorizontalidadEntidad();
                    break;
                case "68":
                    _entidad = new ConfiguracionWS.ColindantesEntidad();
                    break;
                case "69":
                    _entidad = new ConfiguracionWS.CubiertasTechosEntidad();
                    break;
                case "70":
                    _entidad = new ConfiguracionWS.DecisionesEntidad();
                    break;
                case "71":
                    _entidad = new ConfiguracionWS.DelimitacionesLinderosEntidad();
                    break;
                case "72":
                    _entidad = new ConfiguracionWS.DerechosEntidad();
                    break;
                case "73":
                    _entidad = new ConfiguracionWS.DistritosEntidad();
                    break;
                case "74":
                    _entidad = new ConfiguracionWS.EmisionesInstrumentosEntidad();
                    break;
                case "75":
                    _entidad = new ConfiguracionWS.EmisoresEntidad();
                    break;
                case "76":
                    _entidad = new ConfiguracionWS.EnchapesEntidad();
                    break;
                case "77":
                    _entidad = new ConfiguracionWS.EnfoquesEntidad();
                    break;
                case "78":
                    _entidad = new ConfiguracionWS.EntidadesEntidad();
                    break;
                case "79":
                    _entidad = new ConfiguracionWS.EntrepisosEntidad();
                    break;
                case "80":
                    _entidad = new ConfiguracionWS.EscalerasEntidad();
                    break;
                case "81":
                    _entidad = new ConfiguracionWS.EstadosAvaluosEntidad();
                    break;
                case "82":
                    _entidad = new ConfiguracionWS.EstadosConstruccionesEntidad();
                    break;
                case "83":
                    _entidad = new ConfiguracionWS.EstadosInstalacionesElectricasEntidad();
                    break;
                case "84":
                    _entidad = new ConfiguracionWS.EstructurasTechosEntidad();
                    break;
                case "85":
                    _entidad = new ConfiguracionWS.FormasEntidad();
                    break;
                case "86":
                    _entidad = new ConfiguracionWS.GradosGravamenesEntidad();
                    break;
                case "87":
                    _entidad = new ConfiguracionWS.GruposFinancierosEntidad();
                    break;
                case "88":
                    _entidad = new ConfiguracionWS.GruposRiesgosDeudoresEntidad();
                    break;
                case "89":
                    _entidad = new ConfiguracionWS.IndicacionesAjustesAreasEntidad();
                    break;
                case "90":
                    _entidad = new ConfiguracionWS.IndicadoresGeneradoresDivisasEntidad();
                    break;
                case "91":
                    _entidad = new ConfiguracionWS.IndicadoresMonedasExtranjerasEntidad();
                    break;
                case "92":
                    _entidad = new ConfiguracionWS.InstrumentosEntidad();
                    break;
                case "93":
                    _entidad = new ConfiguracionWS.InterruptoresInstalacionesElectricasEntidad();
                    break;
                case "94":
                    _entidad = new ConfiguracionWS.LotesSegregadosEntidad();
                    break;
                case "95":
                    _entidad = new ConfiguracionWS.MaterialesConstruccionesPredominantesEntidad();
                    break;
                case "96":
                    _entidad = new ConfiguracionWS.MaterialesExternosInternosEntidad();
                    break;
                case "97":
                    _entidad = new ConfiguracionWS.MaterialesExternosTapichelesEntidad();
                    break;
                case "98":
                    _entidad = new ConfiguracionWS.MaterialesPisosEntidad();
                    break;
                case "99":
                    _entidad = new ConfiguracionWS.MaterialesPuertasEntidad();
                    break;
                case "100":
                    _entidad = new ConfiguracionWS.MaterialesViasAccesoEntidad();
                    break;
                case "101":
                    _entidad = new ConfiguracionWS.MonedasEntidad();
                    break;
                case "102":
                    _entidad = new ConfiguracionWS.NivelesSocioeconomicosEntidad();
                    break;
                case "103":
                    _entidad = new ConfiguracionWS.NivelesTerrenoEntidad();
                    break;
                case "104":
                    _entidad = new ConfiguracionWS.NumerosLineasEntidad();
                    break;
                case "105":
                    _entidad = new ConfiguracionWS.OrientacionesEntidad();
                    break;
                case "106":
                    _entidad = new ConfiguracionWS.PendientesEntidad();
                    break;
                case "107":
                    _entidad = new ConfiguracionWS.PinturasEntidad();
                    break;
                case "108":
                    _entidad = new ConfiguracionWS.PlanesInversionesEntidad();
                    break;
                case "109":
                    _entidad = new ConfiguracionWS.ProvinciasEntidad();
                    break;
                case "110":
                    _entidad = new ConfiguracionWS.PuntosReferenciasEntidad();
                    break;
                case "111":
                    _entidad = new ConfiguracionWS.RegimenesFiscalizacionesEntidad();
                    break;
                case "112":
                    _entidad = new ConfiguracionWS.SeccionesEntidad();
                    break;
                case "113":
                    _entidad = new ConfiguracionWS.SistemasConstructivosEntidad();
                    break;
                case "114":
                    _entidad = new ConfiguracionWS.SituacionesEntidad();
                    break;
                case "115":
                    _entidad = new ConfiguracionWS.SolicitantesEntidad();
                    break;
                case "116":
                    _entidad = new ConfiguracionWS.TenenciasPrt15Entidad();
                    break;
                case "117":
                    _entidad = new ConfiguracionWS.TenenciasPrt17Entidad();
                    break;
                case "118":
                    _entidad = new ConfiguracionWS.TiposAdjudicacionesBienesEntidad();
                    break;
                case "119":
                    _entidad = new ConfiguracionWS.TiposAsignacionesCalificacionesEntidad();
                    break;
                case "120":
                    _entidad = new ConfiguracionWS.TiposBienesEntidad();
                    break;
                case "121":
                    _entidad = new ConfiguracionWS.TiposCapacidadesPagosEntidad();
                    break;
                case "122":
                    _entidad = new ConfiguracionWS.TiposCarterasEntidad();
                    break;
                case "123":
                    _entidad = new ConfiguracionWS.TiposCasosEntidad();
                    break;
                case "124":
                    _entidad = new ConfiguracionWS.TiposClasificacionesInstrumentosEntidad();
                    break;
                case "125":
                    _entidad = new ConfiguracionWS.TiposComportamientosPagosEntidad();
                    break;
                case "126":
                    _entidad = new ConfiguracionWS.TiposConstruccionesEntidad();
                    break;
                case "127":
                    _entidad = new ConfiguracionWS.TiposDocumentosLegalesEntidad();
                    break;
                case "128":
                    _entidad = new ConfiguracionWS.TiposEmisoresEntidad();
                    break;
                case "129":
                    _entidad = new ConfiguracionWS.TiposEntidadesEntidad();
                    break;
                case "130":
                    _entidad = new ConfiguracionWS.TiposEstadosAvaluosEntidad();
                    break;
                case "131":
                    _entidad = new ConfiguracionWS.TiposGarantiasEntidad();
                    break;
                case "132":
                    _entidad = new ConfiguracionWS.TiposGradosEntidad();
                    break;
                case "133":
                    _entidad = new ConfiguracionWS.TiposGruposFinancierosEntidad();
                    break;
                case "134":
                    _entidad = new ConfiguracionWS.TiposIndicadoresInscripcionesEntidad();
                    break;
                case "135":
                    _entidad = new ConfiguracionWS.TiposIngresosEntidad();
                    break;
                case "136":
                    _entidad = new ConfiguracionWS.TiposInmueblesEntidad();
                    break;
                case "137":
                    _entidad = new ConfiguracionWS.TiposInstrumentosEntidad();
                    break;
                case "138":
                    _entidad = new ConfiguracionWS.TiposLiquidezEntidad();
                    break;
                case "139":
                    _entidad = new ConfiguracionWS.TiposMitigadoresRiesgosEntidad();
                    break;
                case "140":
                    _entidad = new ConfiguracionWS.TiposMonedasEntidad();
                    break;
                case "141":
                    _entidad = new ConfiguracionWS.TiposPersonasEntidad();
                    break;
                case "142":
                    _entidad = new ConfiguracionWS.TiposPolizasEntidad();
                    break;
                case "143":
                    _entidad = new ConfiguracionWS.TiposZonasEntidad();
                    break;
                case "144":
                    _entidad = new ConfiguracionWS.TopografiasEntidad();
                    break;
                case "145":
                    _entidad = new ConfiguracionWS.UnidadesEntidad();
                    break;
                case "146":
                    _entidad = new ConfiguracionWS.UsosSuelosActualEntornosEntidad();
                    break;
                case "147":
                    _entidad = new ConfiguracionWS.VentanasEntidad();
                    break;
                case "148":
                    _entidad = new ConfiguracionWS.VerjasEntidad();
                    break;
                case "149":
                    _entidad = new ConfiguracionWS.ViasAccesoEntidad();
                    break;
                case "150":
                    _entidad = new ConfiguracionWS.VoltajesInstalacionesElectricasEntidad();
                    break;
                case "152":
                    _entidad = new ConfiguracionWS.TasadoresEntidad();
                    break;
                case "153":
                    _entidad = new ConfiguracionWS.EmpresasCalificadorasEntidad();
                    break;
                case "154":
                    _entidad = new ConfiguracionWS.CategoriasRiesgosEmpresasCalificadorasEntidad();
                    break;
                case "155":
                    _entidad = new ConfiguracionWS.DistribucionesZonasTasadoresEntidad();
                    break;
                case "156":
                    _entidad = new ConfiguracionWS.DistribucionesZonasTasadoresEntidad();
                    break;
                case "157":
                    _entidad = new ConfiguracionWS.TasadoresEntidad();
                    break;
                case "158":
                    _entidad = new ConfiguracionWS.FiscalizadoresEntidad();
                    break;
                case "159":
                    _entidad = new ConfiguracionWS.NotariosEntidad();
                    break;
                case "160":
                    _entidad = new ConfiguracionWS.ZonasTasadoresEntidad();
                    break;
                case "161":
                    _entidad = new ConfiguracionWS.PlazosCalificacionesEntidad();
                    break;
                case "162":
                    _entidad = new ConfiguracionWS.ReportesRolesEntidad();
                    break;
                case "163":
                    _entidad = new ConfiguracionWS.ReportesSeguiEntidad();
                    break;
                case "164":
                    _entidad = new ConfiguracionWS.TiposAvalesFianzasEntidad();
                    break;
                case "165":
                    _entidad = new ConfiguracionWS.TiposIdentificacionesRUCEntidad();
                    break;
                case "166":
                    _entidad = new ConfiguracionWS.TiposServiciosEntidad();
                    break;
                case "167":
                    _entidad = new ConfiguracionWS.ZonasTasadoresEntidad();
                    break;
                case "168":
                    _entidad = new ConfiguracionWS.TasadoresEntidad();
                    break;
                case "191":
                    _entidad = new ConfiguracionWS.TiposAvalesEntidad();
                    break;
            }

            #endregion

            return _entidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*INSERTA UN NUEVO REGISTRO*/
    private void InsertarEntidad(string desPagina, SiganemConfiguracionWS wsConfiguracion, object entidad)
    {
        try
        {
            string exec = desPagina.Replace(" ", "").Replace("é", "e").Replace("ó", "o").Replace("í", "i") + "Insertar";
            exec = ExcepcionModuloOculto(exec, pantallaModuloOculto.Value, "Insertar");

            Type ws = wsConfiguracion.GetType();
            MethodInfo metodo = ws.GetMethod(exec);
            var resultado = metodo.Invoke(wsConfiguracion, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR) });
            //EXCEPCIONES PARA LA INSERCION
            InsertarExcepciones((ConfiguracionWS.RespuestaEntidad)resultado);
            //IDENTIDAD { 0=NUEVO; X=EDITAR }
            BarraMensaje((ConfiguracionWS.RespuestaEntidad)resultado, pantallaIdOculto.Value);

            //Bloque 7 Requerimiento 1-24381561
            if (((ConfiguracionWS.RespuestaEntidad)resultado).ValorError.Equals(0))
                this.pantallaIdOculto.Value = ((ConfiguracionWS.RespuestaEntidad)resultado).ValorEstado.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*ELIMINA UN REGISTRO*/
    private void EliminarEntidad(string desPagina, SiganemConfiguracionWS wsConfiguracion, object entidad)
    {
        try
        {
            string exec = desPagina.Replace(" ", "").Replace("é", "e").Replace("ó", "o").Replace("í", "i") + "Eliminar";
            Type ws = wsConfiguracion.GetType();
            MethodInfo metodo = ws.GetMethod(exec);
            var resultado = metodo.Invoke(wsConfiguracion, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.ELIMINAR) });
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*MODIFICA UN REGISTRO*/
    private void ModificarEntidad(string desPagina, SiganemConfiguracionWS wsConfiguracion, object entidad)
    {
        try
        {
            string exec = desPagina.Replace(" ", "").Replace("é", "e").Replace("ó", "o").Replace("í", "i") + "Modificar";
            exec = ExcepcionModuloOculto(exec, pantallaModuloOculto.Value, "Modificar");

            Type ws = wsConfiguracion.GetType();
            MethodInfo metodo = ws.GetMethod(exec);
            var resultado = metodo.Invoke(wsConfiguracion, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.ACTUALIZAR) });
            BarraMensaje((ConfiguracionWS.RespuestaEntidad)resultado, desPagina);
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
            object entidad = null;

            //VARIABLES GLOBALES (0 = NUEVO REGISTRO)
            if (pantallaModuloOculto.Value != null && pantallaIdOculto.Value != "0") 
            {
                #region OBTIENE EL TIPO DE LA ENTIDAD A CREAR DINAMICAMENTE

                //OBTIENE LA ENTIDAD DINAMICAMENTE
                entidad = ObtenerEntidad(entidad, pantallaModuloOculto.Value);
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
                    if (propiedad.Name.Contains("Id"))
                    {
                        entidadPropiedad = propiedad.Name;
                        entidadPropiedadTipo = propiedad.PropertyType.Name;
                        //ASIGNA EL VALOR A LA PROPIEDAD EL ID CORRESPONDE A LA PRIMERA PROPIEDAD DE CADA ENTIDAD
                        propiedad.SetValue(entidad, generadorControles.ConvertirTipoDato(entidadPropiedadTipo.ToUpper(), pantallaIdOculto.Value), null);
                        break;
                    }
                }

                entidad = ControlesExcepciones(entidad);

                //OBTIENE EL RESTO DE CAMPOS DEL REGISTRO A CONSULTAR DESDE LA BD            
                string exec = pantallaNombreOculto.Value.Replace(" ", "").Replace("é", "e").Replace("ó", "o").Replace("í", "i") + "ConsultarDetalle";
                exec = ExcepcionModuloOculto(exec, pantallaModuloOculto.Value, "ConsultarDetalle");
                Type ws = wsConfiguracion.GetType();
                MethodInfo metodo = ws.GetMethod(exec);
                var resultado = metodo.Invoke(wsConfiguracion, new object[] { entidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR) });
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
            wsConfiguracion.Url = ConfigurationManager.AppSettings["ConfiguracionWS"].ToString();
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

    /*MUESTRA BARRA DE MENSAJE SUPERIOR*/
    private void BarraMensaje(ConfiguracionWS.RespuestaEntidad ds, string tipoAccion)
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
                // MENSAJE DE VALIDACION DE TIPO CEDULA: EXTRANJERO RESIDENTE
                if (tipoAccion.Equals("9")) 
                {
                    //MENSAJE DE VALIDACION DE CARACTERES ESPECIALES
                    mensajesEntidad.CodMensaje = "VAL_1";
                    lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";
                    resultadoProceso = -1;
                }
                else
                {
                    //MENSAJE DE VALIDACION DE CARACTERES ESPECIALES
                    mensajesEntidad.CodMensaje = "SYS_2";
                    lblBarraMensaje.CssClass = "etiquetaBarraMensajeError";
                    resultadoProceso = -1;
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
                    //Ajuste Tipo Mitigador 27012015
                    if (!pantallaModuloOculto.Value.Equals("139") && !pantallaModuloOculto.Value.Equals("152") && !pantallaModuloOculto.Value.Equals("153") && !pantallaModuloOculto.Value.Equals("168"))
                    {
                        BloquearControlesGuardar();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected ConfiguracionWS.BitacorasEntidad AsignarValoresBitacora(EnumTipoBitacora _tipo)
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

        if (pantallaModuloOculto.Value.Equals("139") || pantallaModuloOculto.Value.Equals("152") || pantallaModuloOculto.Value.Equals("153") || pantallaModuloOculto.Value.Equals("168"))
        {
            if (pantallaModuloOculto.Value.Equals("139"))
            {
                ((TextBox)this.tableData.FindControl("CodTipoMitigadorRiesgo")).Enabled = false;
                ((TextBox)this.tableData.FindControl("DesTipoMitigadorRiesgo")).Enabled = false;
            }
            if (pantallaModuloOculto.Value.Equals("152"))
            {
                ((TextBox)this.tableData.FindControl("CodTasador")).Enabled = false;
                ((TextBox)this.tableData.FindControl("DesNombreTasador")).Enabled = false;
                ((DropDownList)this.tableData.FindControl("IdTipoPersona")).Enabled = false;
            }
            if (pantallaModuloOculto.Value.Equals("153"))
            { 
                ((TextBox)this.tableData.FindControl("CodEmpresaCalificadora")).Enabled = false;
                ((TextBox)this.tableData.FindControl("DesEmpresaCalificadora")).Enabled = false;
                ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion")).Enabled = false;
            }
            if (pantallaModuloOculto.Value.Equals("168"))
            {
                ((TextBox)this.tableData.FindControl("CodTasador")).Enabled = false;
                ((TextBox)this.tableData.FindControl("DesNombreTasador")).Enabled = false;
                ((DropDownList)this.tableData.FindControl("IdTipoPersona")).Enabled = false;
            }
        }
        else 
        {
            tableData.Enabled = false;
        }
    }

    //Ajuste Tipo Mitigador 27012015
    private void BloquerControlesGuardarExcepcion()
    {
        btnGuardar.Enabled = false;
        btnGuardarNuevo.Enabled = false;
        btnGuardarCerrar.Enabled = false;
        btnAyudaGuardar.Enabled = false;

        if (pantallaModuloOculto.Value.Equals("139"))
        {
            ((TextBox)this.tableData.FindControl("CodTipoMitigadorRiesgo")).Enabled = false;
            ((TextBox)this.tableData.FindControl("DesTipoMitigadorRiesgo")).Enabled = false;
        }

        if (pantallaModuloOculto.Value.Equals("152"))
        {
            ((TextBox)this.tableData.FindControl("CodTasador")).Enabled = false;
            ((TextBox)this.tableData.FindControl("DesNombreTasador")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("IdTipoPersona")).Enabled = false;
        }

        if (pantallaModuloOculto.Value.Equals("153"))
        {
            ((TextBox)this.tableData.FindControl("CodEmpresaCalificadora")).Enabled = false;
            ((TextBox)this.tableData.FindControl("DesEmpresaCalificadora")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("IdPlazoCalificacion")).Enabled = false;
        }

        if (pantallaModuloOculto.Value.Equals("168"))
        {
            ((TextBox)this.tableData.FindControl("CodTasador")).Enabled = false;
            ((TextBox)this.tableData.FindControl("DesNombreTasador")).Enabled = false;
            ((DropDownList)this.tableData.FindControl("IdTipoPersona")).Enabled = false;
        }
    }

    //Ajuste Tipo Mitigador 27012015
    private void MensajesExcepciones()
    {
        string codMensaje = string.Empty;

        if (pantallaModuloOculto.Value.Equals("139") || pantallaModuloOculto.Value.Equals("152") || pantallaModuloOculto.Value.Equals("153") || pantallaModuloOculto.Value.Equals("168"))
        {
            if (!this.pantallaIdOculto.Value.Equals("0"))
            {
                switch (pantallaModuloOculto.Value)
                {
                    case "139":
                        codMensaje = "SYS_26";
                        break;
                    case "152":
                        codMensaje = "SYS_24";
                        break;
                    case "153":
                        codMensaje = "SYS_23";
                        break;
                    case "168":
                        codMensaje = "SYS_25";
                        break;
                }

                this.InformarBox1_SetConfirmationBoxEvent(null, null, codMensaje);
                this.divBarraMensaje.Visible = false;
                this.mpeInformarBox.Show();
            }
        }
    }

    private string ExcepcionModuloOculto(string exec, string codModulo, string tipoEvento)
    {        
        switch (codModulo)
        {
            case "152": 
            case "157": 
            case "168":
                exec = "Tasadores" + tipoEvento;
                break;
            case "155":
            case "156":
                exec = "DistribucionZonasTasadores" + tipoEvento;
                break;
            case "160":
            case "167": exec = "ZonasTasadores" + tipoEvento;
                break;            
        }
        return exec;
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
