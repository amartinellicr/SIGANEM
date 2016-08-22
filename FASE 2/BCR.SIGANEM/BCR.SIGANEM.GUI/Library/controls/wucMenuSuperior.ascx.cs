using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections.Specialized;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

using SesionesWCF;
using SeguridadWS;
using IndicadoresWS;


public partial class wucMenuSuperior : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region VARIABLES

    private RespuestaConsultaSesion _sesion = new RespuestaConsultaSesion();
    private RegistrarEventLog _registroEventos = new RegistrarEventLog();
    private BitacoraFlags _bitacoraBanderas = new BitacoraFlags();
    private IndicadorEconomicoEntidad _indicadorEntidad = new IndicadorEconomicoEntidad();
    private IndicadoresWS.BitacorasEntidad _bitacorasEntidad = new IndicadoresWS.BitacorasEntidad();
    private SeguridadWS.BitacorasEntidad _bitacorasEntidadS = new SeguridadWS.BitacorasEntidad();
    private IndicadoresWS.BitacorasEntidad _bitacorasEntidadRegistrar = new IndicadoresWS.BitacorasEntidad();

    #endregion

    #region REFERENCIAS

    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();
    private SiganemIndicadoresWS wsIndicadores = new SiganemIndicadoresWS();

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            AsignaWebServicesTypeNames();

            #region MENSAJE INFORMAR

            Button wcBtnAccept = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            wcBtnAccept.Click += new EventHandler(BtnAceptarInformar_Click);

            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
            scriptManager.RegisterPostBackControl(this.cmdAccionesExcel);
            if (!IsPostBack)
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
                        case "pantallaModulo":
                            pantallaModuloOculto.Value = Request.Form["pantallaModulo"].ToString();
                            break;
                    }
                }
                #endregion

                //SE ASIGNA EL CODIGO DE LA PANTALLA PARA EL REGISTRO DE LAS BITACORAS
                if (pantallaModuloOculto.Value.Length > 0)
                {
                    SeguridadWS.PantallasEntidad _pantalla = new PantallasEntidad();
                    _pantalla.IdPantalla = int.Parse(pantallaModuloOculto.Value);
                    pantallaCodOculto.Value = wsSeguridad.PantallasConsultarDetalle(_pantalla, AsignarValoresBitacoraS(EnumTipoBitacora.CONSULTAR)).CodPantalla.ToString();
                }

                DeshabilitarBotonesReportes(true);
                this.cmdAccionesGuardarNuevo.Style.Add("visibility", "hidden");
                this.cmdAccionesNuevoId.Style.Add("visibility", "hidden");
                this.btnAccionesOperacionId.Style.Add("visibility", "hidden");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void cmdAccionesInicio_Click(object sender, EventArgs e)
    {
        try
        {
            _sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (_sesion.Codigo == 0)
            {
                string url = string.Empty;
                HttpHelper httpPost = new HttpHelper();
                Dictionary<string, string>  dataSesion = new Dictionary<string, string>();
                dataSesion.Add("idSesion", idSesionOculto.Value);
                dataSesion.Add("codUsuario", codUsuarioOculto.Value);
                dataSesion.Add("pantallaModulo", pantallaModuloOculto.Value);

                if (this.Page.Request.FilePath.Contains("Paginas"))
                {
                    url = "../../";
                }
                httpPost.RedirectAndPOST(this.Page, url + "Default.aspx", dataSesion);
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdConsultarIPC_Click(object sender, EventArgs e)
    {
        try
        {
            _sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (_sesion.Codigo == 0)
            {
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "IPC");
                this.mpeInformarBoxRibbon.Show();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdEjecutarIPC_Click(object sender, EventArgs e)
    {
        try
        {           
            _sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);

            if (_sesion.Codigo == 0)
            {
                wsIndicadores.RegistraEjecucionServicioBitacora(AsignarValoresBitacoraRegistrar(EnumTipoBitacora.EJECUCION));

                //SE VERIFICA LA CONEXION AL BCCR
                if (ExisteConexionBCCR(sender, e))
                {
                    //SE PROCEDE CON LA CONSULTA E INSERCION DEL INDICADOR
                    InsertarIndicadorBCCR(sender, e, "IPC");
                }
            }
        }
        catch (Exception ex)
        {
            _registroEventos.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);

            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdConsultarTC_Click(object sender, EventArgs e)
    {
        try
        {
            _sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (_sesion.Codigo == 0)
            {
                this.InformarBox1_SetConfirmationBoxEvent(sender, e, "TC");
                this.mpeInformarBoxRibbon.Show();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdEjecutarTC_Click(object sender, EventArgs e)
    {
        try
        {
            _sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);            

            if (_sesion.Codigo == 0)
            {
                wsIndicadores.RegistraEjecucionServicioBitacora(AsignarValoresBitacoraRegistrar(EnumTipoBitacora.EJECUCION));

                //SE VERIFICA LA CONEXION AL BCCR
                if (ExisteConexionBCCR(sender, e))
                {
                    //SE PROCEDE CON LA CONSULTA E INSERCION DEL INDICADOR
                    InsertarIndicadorBCCR(sender, e, "TC");

                }                                
            }
        }
        catch (Exception ex)
        {
            _registroEventos.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);

            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #endregion

    #region METODOS NO PERSONALIZABLES

    /*BITACORA INDICADORES ECONOMICOS*/
    protected IndicadoresWS.BitacorasEntidad AsignarValoresBitacora(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA

            _bitacorasEntidad.CodAccion = _bitacoraBanderas.TipoBitacoraConsulta(_tipo);
            _bitacorasEntidad.CodModulo = int.Parse(pantallaCodOculto.Value);
            _bitacorasEntidad.CodEmpresa = int.Parse(Resources.Resource._empresa);
            _bitacorasEntidad.CodSistema = Resources.Resource._sistema;
            _bitacorasEntidad.CodUsuario = codUsuarioOculto.Value;

            #endregion

            return _bitacorasEntidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*BITACORA SEGURIDAD*/
    protected SeguridadWS.BitacorasEntidad AsignarValoresBitacoraS(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA

            _bitacorasEntidadS.CodAccion = _bitacoraBanderas.TipoBitacoraConsulta(_tipo);
            _bitacorasEntidadS.CodModulo = int.Parse(pantallaModuloOculto.Value);
            _bitacorasEntidadS.CodEmpresa = int.Parse(Resources.Resource._empresa);
            _bitacorasEntidadS.CodSistema = Resources.Resource._sistema;
            _bitacorasEntidadS.CodUsuario = codUsuarioOculto.Value;

            #endregion

            return _bitacorasEntidadS;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*BITACORA SEGURIDAD*/
    protected IndicadoresWS.BitacorasEntidad AsignarValoresBitacoraRegistrar(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA

            _bitacorasEntidadRegistrar.CodAccion = _bitacoraBanderas.TipoBitacoraConsulta(_tipo);
            _bitacorasEntidadRegistrar.CodModulo = int.Parse(pantallaCodOculto.Value);
            _bitacorasEntidadRegistrar.CodEmpresa = int.Parse(Resources.Resource._empresa);
            _bitacorasEntidadRegistrar.CodSistema = Resources.Resource._sistema;
            _bitacorasEntidadRegistrar.CodUsuario = codUsuarioOculto.Value;
            _bitacorasEntidadRegistrar.DesRegistro = Resources.Resource._ejecucionBCCR;

            #endregion

            return _bitacorasEntidadRegistrar;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void AsignaValoresIndicadoresBCCR(String tipoServicio)
    {
        _indicadorEntidad = new IndicadorEconomicoEntidad();
        LectorFechasSistema _fechas = new LectorFechasSistema();

        try
        {
            #region VALORES GENERICOS
                        
            _indicadorEntidad.NombreBanco = Resources.Resource._nombreBanco; 
            _indicadorEntidad.SubNiveles = Resources.Resource._subNivel;
            _indicadorEntidad.CodUsuarioIngreso = this.codUsuarioOculto.Value;
            _indicadorEntidad.IndMetodoInsercion = Resources.Resource._metodoInsercion;
            AsignarValoresBitacora(EnumTipoBitacora.INSERTAR);
            
            #endregion

            #region VALORES POR SERVICIO

            switch (tipoServicio)
            {
                case "TC":
                    _indicadorEntidad.Indicador = ConfigurationManager.AppSettings["SistemaTC"].ToString();
                    _indicadorEntidad.FechaInicio = _fechas.ObtenerDiaAnterior().ToShortDateString();
                    _indicadorEntidad.FechaFinal = _fechas.ObtenerDiaActual().ToShortDateString();
                    break;
                case "IPC":
                    _indicadorEntidad.Indicador = ConfigurationManager.AppSettings["SistemaIPC"].ToString();
                    _indicadorEntidad.FechaInicio = _fechas.ObtenerUltimoDiaMesAnterior().ToShortDateString();
                    _indicadorEntidad.FechaFinal = _fechas.ObtenerUltimoDiaMesAnterior().ToShortDateString();
                    break;
            }

            #endregion

        }
        catch (Exception ex)
        {
            _registroEventos.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);
            throw ex;
        }
    }

    /*CONSULTA E INSERCION DEL INDICADOR*/
    private void InsertarIndicadorBCCR(object sender, EventArgs e, String tipoServicio)
    {
        List<IndicadoresWS.RespuestaEntidad> _respuesta = new List<IndicadoresWS.RespuestaEntidad>();
        bool _existeError = false;

        //SE ASIGNAN LOS VALORES A LAS PROPIEDADES DE LA ENTIDAD
        AsignaValoresIndicadoresBCCR(tipoServicio);

        //SE CONSULTA E INSERTA EL VALOR
        switch (tipoServicio)
        {
            case "TC":
                _respuesta = wsIndicadores.ConsultaIndicadorEconomicoTC(_indicadorEntidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR)).ToList();
                break;
            case "IPC":
                _respuesta = wsIndicadores.ConsultaIndicadorEconomicoIPC(_indicadorEntidad, AsignarValoresBitacora(EnumTipoBitacora.INSERTAR)).ToList();
                break;
        }
        
        //SE VERIFICA EL RESULTADO DE LA TRANSACCION
        foreach (IndicadoresWS.RespuestaEntidad _dato in _respuesta)
        {
            if (!_dato.ValorError.Equals(0))
                _existeError = true;
        }

        //SI NO EXISTEN ERRORES SE ENVIA MENSAJE DE EJECUCION SATISFACTORIA
        if (!_existeError)
        {
            InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_1");
        }
        else
        { 
            InformarBox1_SetConfirmationBoxEvent(sender, e, "Inesperado");
        }

        this.mpeInformarBoxRibbon.Show();
    }

    /*VERIFICA LA CONEXION AL BCCR*/
    private bool ExisteConexionBCCR(object sender, EventArgs e)
    {
        bool _existeError = true;
        string _estadoConexion = string.Empty;

        _estadoConexion = wsIndicadores.ValidaConexionWebServiceIndicadores();
        if (_estadoConexion.ToUpper().Contains("ERROR"))
        {
            _existeError = false;
            this.InformarBox1_SetConfirmationBoxEvent(sender, e, "SYS_22");
            this.mpeInformarBoxRibbon.Show();
        }

        return _existeError;
    }

    public void ExportToExcel(string filename, GridView dg)
    {
        _sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
        if (_sesion.Codigo == 0)
        {
            DataTable dtEmp = new DataTable();

            if (dg.HeaderRow != null)
            {

                for (int i = 1; i <= dg.HeaderRow.Cells.Count - 1; i++)
                {
                    dtEmp.Columns.Add(dg.HeaderRow.Cells[i].Text);
                }
            }

            int column = 0;
            for (int r = 0; r < dg.Rows.Count; r++)
            {
                DataRow dr;
                dr = dtEmp.NewRow();
                column = 0;
                for (int c = 1; c <= dg.Rows[r].Cells.Count - 2; c++)
                {
                    dr[column] = dg.Rows[r].Cells[c].Text;
                    column++;
                }
                dtEmp.Rows.Add(dr);
            }

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + filename + ".xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = Encoding.Unicode;
            Response.BinaryWrite(Encoding.Unicode.GetPreamble());

            string tab = string.Empty;
            foreach (DataColumn dtcol in dtEmp.Columns)
            {
                Response.Write(tab + dtcol.ColumnName);
                tab = "\t";
            }
            Response.Write("\n");
            foreach (DataRow dr in dtEmp.Rows)
            {
                tab = string.Empty;
                for (int j = 0; j < dtEmp.Columns.Count; j++)
                {
                    Response.Write(tab + Convert.ToString(dr[j]));
                    tab = "\t";
                }
                Response.Write("\n");
            }
            Response.End();
        }
    }

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsSesiones.Url = ConfigurationManager.AppSettings["SesionesWCF"].ToString();
            wsSeguridad.Url = ConfigurationManager.AppSettings["SeguridadWS"].ToString();
            wsIndicadores.Url = ConfigurationManager.AppSettings["IndicadoresWS"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ActualizarVentana()
    {
        string script = "if (window != null && !window.closed) { window.document.getElementById('cmdAccionesActualizar').click(); }";
        ScriptManager.RegisterStartupScript(this.Page, typeof(string), "refreshNewWindow", script, true);
    }

    #region EFECTOS DE BOTONES

    public void DeshabilitarBotonesNuevoModificarEliminar(Boolean disabled)
    {
        if (disabled)
        {
            #region BOTON NUEVO
            this.cmdAccionesNuevo.Enabled = false;
            this.cmdAccionesNuevo.CssClass = "menuSuperiorBotonAccionesNuevoDisabled";
            this.divNuevo.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
            #endregion

            #region BOTON MODIFICAR
            this.cmdAccionesModificar.Enabled = false;
            this.cmdAccionesModificar.CssClass = "menuSuperiorBotonAccionesModificarDisabled";
            this.divModificar.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
            #endregion

            #region BOTON BORRAR
            this.cmdAccionesEliminar.Enabled = false;
            this.cmdAccionesEliminar.CssClass = "menuSuperiorBotonAccionesBorrarDisabled";
            this.divEliminar.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
            #endregion
        }
        else
        {
            #region BOTON NUEVO
            this.cmdAccionesNuevo.Enabled = true;
            this.cmdAccionesNuevo.CssClass = "menuSuperiorBotonAccionesNuevo";
            this.divNuevo.Attributes.Add("class", "divTabsButtonsPreHover");
            #endregion

            #region BOTON MODIFICAR
            this.cmdAccionesModificar.Enabled = true;
            this.cmdAccionesModificar.CssClass = "menuSuperiorBotonAccionesModificar";
            this.divModificar.Attributes.Add("class", "divTabsButtonsPreHover");
            #endregion

            #region BOTON BORRAR
            this.cmdAccionesEliminar.Enabled = true;
            this.cmdAccionesEliminar.CssClass = "menuSuperiorBotonAccionesBorrar";
            this.divEliminar.Attributes.Add("class", "divTabsButtonsPreHover");
            #endregion
        }
    }

    public void DeshabilitarBotonesAcciones(Boolean disabled) 
    {
        if (disabled)
        {
            #region BOTON NUEVO
            this.cmdAccionesNuevo.Enabled = false;
            this.cmdAccionesNuevo.CssClass = "menuSuperiorBotonAccionesNuevoDisabled";
            this.divNuevo.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
            #endregion

            #region BOTON MODIFICAR
            this.cmdAccionesModificar.Enabled = false;
            this.cmdAccionesModificar.CssClass = "menuSuperiorBotonAccionesModificarDisabled";
            this.divModificar.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
            #endregion

            #region BOTON BORRAR
            this.cmdAccionesEliminar.Enabled = false;
            this.cmdAccionesEliminar.CssClass = "menuSuperiorBotonAccionesBorrarDisabled";
            this.divEliminar.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
            #endregion

            #region BOTON ACTUALIZAR
            this.cmdAccionesActualizar.Enabled = false;
            this.cmdAccionesActualizar.CssClass = "menuSuperiorBotonAccionesActualizarDisabled";
            this.divActualizar.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
            #endregion
        }
        else 
        {
            #region BOTON NUEVO
            this.cmdAccionesNuevo.Enabled = true;
            this.cmdAccionesNuevo.CssClass = "menuSuperiorBotonAccionesNuevo";
            this.divNuevo.Attributes.Add("class", "divTabsButtonsPreHover");
            #endregion

            #region BOTON MODIFICAR
            this.cmdAccionesModificar.Enabled = true;
            this.cmdAccionesModificar.CssClass = "menuSuperiorBotonAccionesModificar";
            this.divModificar.Attributes.Add("class", "divTabsButtonsPreHover");
            #endregion

            #region BOTON BORRAR
            this.cmdAccionesEliminar.Enabled = true;
            this.cmdAccionesEliminar.CssClass = "menuSuperiorBotonAccionesBorrar";
            this.divEliminar.Attributes.Add("class", "divTabsButtonsPreHover");
            #endregion

            #region BOTON ACTUALIZAR
            this.cmdAccionesActualizar.Enabled = true;
            this.cmdAccionesActualizar.CssClass = "menuSuperiorBotonAccionesActualizar";
            this.divActualizar.Attributes.Add("class", "divTabsButtonsPreHover");
            #endregion
        }
    }

    public void DeshabilitarBotonesParametros()
    {
        #region BOTON NUEVO
        this.cmdAccionesNuevo.Enabled = false;
        this.cmdAccionesNuevo.CssClass = "menuSuperiorBotonAccionesNuevoDisabled";
        this.divNuevo.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
        #endregion

        #region BOTON BORRAR
        this.cmdAccionesEliminar.Enabled = false;
        this.cmdAccionesEliminar.CssClass = "menuSuperiorBotonAccionesBorrarDisabled";
        this.divEliminar.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
        #endregion
    }

    public void DeshabilitarBotonesDatos(Boolean disabled)
    {

        if (disabled)
        {
            #region BOTON EXCEL
            this.cmdAccionesExcel.Enabled = false;
            this.cmdAccionesExcel.CssClass = "menuSuperiorBotonAccionesExcelDisabled";
            this.divExcel.Attributes.Add("class", "divTabsButtonsPreHoverHorizontalDisabled");
            #endregion
        }
        else 
        {
            #region BOTON EXCEL
            this.cmdAccionesExcel.Enabled = true;
            this.cmdAccionesExcel.CssClass = "menuSuperiorBotonAccionesExcel";
            this.divExcel.Attributes.Add("class", "divTabsButtonsPreHoverHorizontal");
            #endregion
        }
    }

    public void DeshabilitarBotonesMasAcciones(Boolean disabled)
    {
        if (disabled)
        {
            #region BOTON ACCIONES
            this.cmdAccionesMas.Enabled = false;
            this.cmdAccionesMas.CssClass = "menuSuperiorBotonAccionesAccionesDisabled";
            this.divMasAcciones.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
            #endregion
        }
        else
        {
            #region BOTON ACCIONES
            this.cmdAccionesMas.Enabled = true;
            this.cmdAccionesMas.CssClass = "menuSuperiorBotonAccionesAcciones";
            this.divMasAcciones.Attributes.Add("class", "divTabsButtonsPreHover");
            #endregion
        }
    }

    public void DeshabilitarBotonesReportes(Boolean disabled)
    {
        if (disabled)
        {
            #region BOTON REPORTES
            this.cmdAccionesReportes.Enabled = false;
            this.cmdAccionesReportes.CssClass = "menuSuperiorBotonAccionesReportesDisabled";
            this.divReportes.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
            #endregion
        }
        else
        {
            #region BOTON REPORTES
            this.cmdAccionesReportes.Enabled = true;
            this.cmdAccionesReportes.CssClass = "menuSuperiorBotonAccionesReportes";
            this.divReportes.Attributes.Add("class", "divTabsButtonsPreHover");
            #endregion
        }
    }

    public void OcultarBotones(Boolean visible)
    {
        if (visible)
        {
            #region BOTON OCULTOS
            this.cmdAccionesGuardarNuevo.Style.Add("visibility", "hidden");
            this.cmdAccionesNuevoId.Style.Add("visibility", "hidden");
            #endregion
        }
        else
        {
            #region BOTON OCULTOS
            this.cmdAccionesGuardarNuevo.Style.Add("visibility", "visible");
            this.cmdAccionesNuevoId.Style.Add("visibility", "visible");
            #endregion
        }
    }

    #endregion

    #region MENSAJE INFORMAR

    protected void BtnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBoxRibbon.Hide();
        ActualizarVentana();
    }

    private MensajesEntidad Mensaje(string type)
    {
        try
        {
            MensajesEntidad msj = null;
            switch (type)
            { 
                case "IPC":
                    msj = wsSeguridad.IndicesPreciosConsumidorConsultarBCCR();
                    break;
                case "TC":
                    msj = wsSeguridad.TiposCambiosConsultarBCCR();
                    break;
                default:
                    msj = new MensajesEntidad();
                    msj.CodMensaje = type;
                    msj = wsSeguridad.MensajesConsulta(msj);
                    break;
            }
            
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
            MensajesEntidad _mensaje = this.Mensaje(type);
            InformarBox1.SetMessageBox(_mensaje.DesTipoMensaje, _mensaje.DesMensaje);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

}
