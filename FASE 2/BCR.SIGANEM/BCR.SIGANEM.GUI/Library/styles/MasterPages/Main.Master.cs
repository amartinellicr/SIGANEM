using System;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.Security;
using System.Configuration;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Threading;

using SesionesWCF;
using SeguridadWS;
using BCR.SIGANEM.UT;


public partial class Main : System.Web.UI.MasterPage
{

    #region PROPIEDADES

    #region VARIABLES

    private RespuestaConsultaSesion _sesion = new RespuestaConsultaSesion();
    private TiposRolesEntidad _roles = new TiposRolesEntidad();
    private UsuariosEntidad _usuarios = new UsuariosEntidad();
    private MensajesEntidad _mensajes = new MensajesEntidad();
    private BitacorasEntidad _bitacora = new BitacorasEntidad();
    private BitacoraFlags _bitacoraFlags = new BitacoraFlags();

    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();

    #endregion

    #region CONTROLES

    private Button cmdDesconectar = null;

    #endregion
    
    #endregion

    #region METODOS PERSONALIZADOS

    private void AsignarSesion()
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
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            this.AsignaWebServicesTypeNames();
            #region CONTROLES

            Button wcBtnAccept = (Button)this.InformarBox1.FindControl("wucBtnAceptar");
            wcBtnAccept.Click += new EventHandler(BtnAceptarInformar_Click);

            cmdDesconectar = ((Button)this.Ribbon1.FindControl("TabContainer1").FindControl("tabDesconectar").FindControl("cmdDesconectar"));
            cmdDesconectar.Click += new EventHandler(cmdDesconectar_Click);

            this.InformarBox1.SetConfirmationBoxEvent += new wucMensajeInformar.SetConfirmationBox(InformarBox1_SetConfirmationBoxEvent);

            #endregion

            if (!IsPostBack)
            {
                #region OBTENER VALORES SESION
                //ALMACENA LA INFORMACION DE LA SESION
                AsignarSesion();
                #endregion
                #region ENTIDAD BITACORA
                _bitacora.CodAccion = _bitacoraFlags.TipoBitacoraConsulta(EnumTipoBitacora.CONSULTAR);
                if (pantallaModuloOculto.Value.Length > 0)
                {
                    _bitacora.CodModulo = int.Parse(pantallaModuloOculto.Value);
                }
                _bitacora.CodEmpresa = int.Parse(Resources.Resource._empresa);
                _bitacora.CodSistema = Resources.Resource._sistema;
                _bitacora.CodUsuario = codUsuarioOculto.Value;
                #endregion
                #region ROL USUARIO
                _roles.IdTipoRol = int.Parse(wsSeguridad.UsuariosObtenerRolUsuario(codUsuarioOculto.Value).IdTipoRol.ToString());
                rolUsuarioOculto.Value = wsSeguridad.RolesConsultarDetalle(_roles, _bitacora).DesTipoRol.ToString();
                nombreUsuarioOculto.Value = wsSesiones.UsuarioNombreAd(codUsuarioOculto.Value);
                #endregion
                #region VALORES USUARIO
                lblUsuario.Text = RetornarDatosUsuario(nombreUsuarioOculto.Value, rolUsuarioOculto.Value);
                #endregion
                #region FECHA CONEXION
                DateTime TheDate = DateTime.Now.Date;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                String Letra = TheDate.ToLongDateString();
                String FechaFinal = char.ToUpper(Letra[0]) + Letra.Substring(1);
                lblFecha.Text = FechaFinal;
                fechaSistemaOculto.Value = FechaFinal;
                #endregion
                //#region FECHA CONEXION
                //var input = DateTime.Now.ToLongDateString();
                //var format = "dddd, MMMM dd, yyyy";
                //var dt = DateTime.ParseExact(input, format, new CultureInfo("en-US"));
                //var result = dt.ToString("D", new CultureInfo("es-ES"));
                //string fecha = string.Empty;
                //for (int i = 0; i < result.ToString().Length; i++)
                //{
                //    if (i == 0)
                //        fecha = result[i].ToString().ToUpper();
                //    else
                //        fecha += result[i].ToString();
                //}
                //lblFecha.Text = fecha;
                //fechaSistemaOculto.Value = fecha;
                //#endregion
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            _sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);
            if (_sesion.Codigo != 0)
            {
                //MENSAJE SESIÓN CADUCADA
                this.InformarBox1_SetConfirmationBoxEvent(null, e, EnumTipoMensaje.Caducado.ToString());
                this.mpeInformarBox.Show();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    public void MenuScriptManager_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
    {
        if (e.Exception != null)
        {
            Application["Exception"] = e;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void BtnAceptarInformar_Click(object sender, EventArgs e)
    {
        this.mpeInformarBox.Hide();
        #region REGISTRAR BITACORA
        //CAMBIO FGUEVARA
        #region ENTIDAD USUARIO
        _usuarios.CodUsuario = codUsuarioOculto.Value;
        _usuarios.Conectado = false;
        _usuarios.Bloqueado = false;
        _usuarios.CantidadIntento = 0;
        _usuarios.UltimaConexion = DateTime.Now;
        _usuarios.FechaIntento = DateTime.Parse("1900-01-01");
        #endregion
        #region ENTIDAD BITACORA
        _bitacora.CodAccion = _bitacoraFlags.TipoBitacoraConsulta(EnumTipoBitacora.SESION_CADUCA);
        _bitacora.CodModulo = int.Parse(pantallaModuloOculto.Value);
        _bitacora.CodEmpresa = int.Parse(Resources.Resource._empresa);
        _bitacora.CodSistema = Resources.Resource._sistema;
        _bitacora.CodUsuario = codUsuarioOculto.Value;
        _bitacora.DesRegistro = String.Format(Resources.Sesiones.SesionCaducado, codUsuarioOculto.Value, DateTime.Now);
        #endregion
        wsSeguridad.UsuariosRegistrarIntentos(_usuarios, _bitacora);

        #endregion
        //REGRESAR A LOGIN PAGE SIGANEM        
        Response.Redirect("~/Aplicacion/Login.aspx", false);
    }

    protected void cmdDesconectar_Click(object sender, EventArgs e)
    {
        try
        {
            #region ENTIDAD USUARIO
            _usuarios.CodUsuario = codUsuarioOculto.Value;
            _usuarios.Conectado = false;
            _usuarios.Bloqueado = false;
            _usuarios.CantidadIntento = 0;
            _usuarios.UltimaConexion = DateTime.Now;
            _usuarios.FechaIntento = DateTime.Parse("1900-01-01");
            #endregion
            #region ENTIDAD BITACORA
            if (pantallaModuloOculto.Value.Length > 0)
            {
                _bitacora.CodModulo = int.Parse(pantallaModuloOculto.Value);
            }
            _bitacora.CodEmpresa = int.Parse(Resources.Resource._empresa);
            _bitacora.CodSistema = Resources.Resource._sistema;
            _bitacora.CodUsuario = codUsuarioOculto.Value;            
            #endregion
            #region ELIMINAR SESION
            //ELIMINA LA SESION
            wsSesiones.EliminarSesion(idSesionOculto.Value);

            _bitacora.CodAccion = _bitacoraFlags.TipoBitacoraConsulta(EnumTipoBitacora.REGISTRAR);//CAMBIO FGUEVARA
            _bitacora.DesRegistro = String.Format(Resources.Sesiones.SesionRegistrar, codUsuarioOculto.Value, DateTime.Now).Replace("conexión", "desconexión");
            wsSeguridad.UsuariosRegistrarIntentos(_usuarios, _bitacora);

            //REGISTRA INTENTOS Y CONEXION EN LA TABLA
            _bitacora.CodAccion = _bitacoraFlags.TipoBitacoraConsulta(EnumTipoBitacora.SESION_CIERRA);//CAMBIO FGUEVARA
            _bitacora.DesRegistro = String.Format(Resources.Sesiones.SesionCerrar, codUsuarioOculto.Value, DateTime.Now);
            wsSeguridad.UsuariosRegistrarConexion(_usuarios, _bitacora);
            
            //REGRESAR A LOGIN PAGE SIGANEM
            Response.Redirect("~/Aplicacion/Login.aspx", false);
            #endregion
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsSesiones.Url = ConfigurationManager.AppSettings["SesionesWCF"].ToString();
            wsSeguridad.Url = ConfigurationManager.AppSettings["SeguridadWS"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region MENSAJE CONFIRMAR

    private MensajesEntidad Mensaje(string msgType)
    {
        try
        {
            _mensajes.CodMensaje = EnumTipoMensaje.Caducado.ToString();
            MensajesEntidad msj = wsSeguridad.MensajesConsulta(_mensajes);
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

    /*PERMITE ASIGNAR LOS VALORES DEL USUARIO DESDE UNA PAGINA HIJA*/
    public void RefrescarDatosUsuario()
    {
        lblUsuario.Text = RetornarDatosUsuario(nombreUsuarioOculto.Value, rolUsuarioOculto.Value);
        lblFecha.Text = fechaSistemaOculto.Value;
    }


    /*REALIZA UN FORMATEO DE LOS DATOS DE USUARIO*/
    private string RetornarDatosUsuario(string nombre, string rol)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(nombre);
        sb.Append(" | ");
        sb.Append(rol);

        return sb.ToString();
    }

    #endregion

    #region MIEMBRO IDISPOSABLE

    #region VARIABLES

    private bool disposed = false;

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
        if (!disposed)
        {
            if (disposing)
            {
                if (wsSesiones != null)
                {
                    wsSesiones.Dispose();
                    wsSesiones = null;
                }

                if (wsSeguridad != null)
                {
                    wsSeguridad.Dispose();
                    wsSeguridad = null;
                }
            }
            _roles = null;
            _usuarios = null;
            _bitacora = null;
            _mensajes = null;
            _bitacora = null;
            _sesion = null;
            
            _bitacoraFlags = null;
            disposed = true;
        }
    }

    #endregion

}