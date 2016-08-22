using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections.Specialized;

using SesionesWCF;
using SeguridadWS;

using BCR.SIGANEM.UT;
using System.Text.RegularExpressions;

public partial class Login : System.Web.UI.Page
{

    #region PROPIEDADES

    #region VARIABLES

    private RespuestaSesion _rs = new RespuestaSesion();
    private VariablesSesionEntidad[] _variableArreglo = new VariablesSesionEntidad[3];

    //CONTROL ATAQUES XSRF
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;

    #endregion

    #region REFERENCIAS

    private BitacoraFlags _bitacoraFlags = new BitacoraFlags();
    private TiposRolesEntidad _RolesEntidad = new TiposRolesEntidad();
    private UsuariosEntidad _UsuariosEntidad = new UsuariosEntidad();
    private BitacorasEntidad _bitacoraEntidad = new BitacorasEntidad();

    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            #region ATAQUES XSRF

            //EL SIGUIENTE CODIGO AYUDA EN LA PROTECCIÓN CONTROL ATAQUES XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                //UTILIZA EL TOKEN Anti-XSRF DESDE EL COOKIE
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                //GENERA EL TOKEN Anti-XSRF Y LO GUARDA EN EL COOKIE
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += login_Page_PreLoad;

            #endregion

            this.AsignaWebServicesTypeNames();
            this.txtUsuario.Focus();

            #region MENSAJE DE REMOTO

            Button BtnAceptar = (Button)this.RemoteBox1.FindControl("wucBtnAceptar");
            BtnAceptar.Click += new EventHandler(BtnAceptar_Click);

            #endregion
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void login_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ESTABLECE EL TOKEN Anti-XSRF
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            //VALIDA EL TOKEN Anti-XSRF
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("La validación Anti-XSRF ha sido activada.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoServerCaching();
        }
        this.txtUsuario.Focus();
        this.txtContrasena.Attributes.Add("autocomplete", "off");
    }

    // CAMBIO INGRESO DE LOGIN POR SOLICITUD DE ALEXANDER MENDEZ
    // CORREO: CAMPO BLOQUEADO/FECHA: 31/07/2014
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        #region VARIABLES

        bool oExiste = false;
        bool oBloqueado = false;
        bool oAutenticado = false;

        int _tiempoEspera = 0;
        int _intentosUsuario = 0;
        int _cantidadIntentos = 0;
        
        DateTime? _fechaIntento = null;
        DateTime? _fechaUltimaConexion = null;

        lblErrorLogin.Text = string.Empty;
        
        string password = txtContrasena.Text;
        codUsuarioOculto.Value = txtUsuario.Text.Trim();

        var regexItem = new Regex("^[a-zA-Z0-9 .,/:ÁÉÍÓÚÑáéíóúñ()]*$");

        #endregion

        try
        {
            #region OBTENER VALORES INICIALES DEL SISTEMA
            //TIEMPO DE ESPERA DE BLOQUEO DE INTENTOS
            _tiempoEspera = int.Parse(ConfigurationManager.AppSettings["ExpiracionWCF"].ToString());
            //CANTIDAD DE INTENTOS DEL SISTEMA
            _cantidadIntentos = int.Parse(Resources.Sesiones.SesionCantidadIntentos);
            
            if (regexItem.IsMatch(codUsuarioOculto.Value) && regexItem.IsMatch(password))
            {
                try
                {
                    #region OBTENER INTENTOS DE SIGANEM
                    //VALIDAR CANTIDAD DE INTENTOS POR USUARIO LOGUEADO
                    UsuariosEntidad ds = wsSeguridad.UsuariosObtenerIntentos(codUsuarioOculto.Value);
                    oBloqueado = ds.Bloqueado;
                    _intentosUsuario = ds.CantidadIntento;
                    #endregion
                    //CAMBIO ALEXANDER MENDEZ 20140730
                    _fechaIntento = ds.FechaIntento;
                    _fechaUltimaConexion = ds.UltimaConexion;

                    //VALIDAR USUARIO EN ACTIVE DIRECTORY
                    oExiste = wsSesiones.UsuarioExisteAd(codUsuarioOculto.Value);
                    oAutenticado = wsSesiones.UsuarioAutenticadoAd(codUsuarioOculto.Value, password);
                }
                catch 
                {
                    lblErrorLogin.Text = Resources.Sesiones.SesionEquivocado;
                }
                #endregion
                //VALIDAR EXISTENCIA Y AUTENTICACION DEL USUARIO EN AD
                if ((oAutenticado) && (oExiste))
                {
                    if ((_fechaIntento != null) && (_fechaUltimaConexion != null))
                    {
                        if (ValidaTiempoIngreso(_fechaIntento.Value, _tiempoEspera) && (oBloqueado) )
                        {
                            #region INGRESAR CORRECTAMENTE

                            lblErrorLogin.Text = string.Empty;
                            ValoresRegistrarIntentos(false, 0, DateTime.Now, String.Format(Resources.Sesiones.SesionLogueo, codUsuarioOculto.Value, DateTime.Now));
                            wsSeguridad.UsuariosRegistrarIntentos(_UsuariosEntidad, _bitacoraEntidad);
                            #region REGISTRA INGRESO CON SESIONES
                            UsuariosEntidad _dtRol = wsSeguridad.UsuariosObtenerRolUsuario(codUsuarioOculto.Value);
                            if (_dtRol != null)
                            {
                                #region ROL USUARIO
                                _RolesEntidad.IdTipoRol = _dtRol.IdTipoRol;
                                string _rol = wsSeguridad.RolesConsultarDetalle(_RolesEntidad, _bitacoraEntidad).DesTipoRol;
                                #endregion
                                #region ASIGNAR VALORES OCULTOS
                                codUsuarioOculto.Value = txtUsuario.Text.Trim();
                                nombreUsuarioOculto.Value = wsSesiones.UsuarioNombreAd(codUsuarioOculto.Value);
                                rolUsuarioOculto.Value = _rol;
                                #endregion
                                #region REGISTRAR INGRESO EN BITACORA
                                ValoresRegistrarIngreso(String.Format(Resources.Sesiones.SesionIniciar, codUsuarioOculto.Value, DateTime.Now));//CAMBIO FGUEVARA
                                wsSeguridad.UsuariosRegistrarIntentos(_UsuariosEntidad, _bitacoraEntidad);
                                #endregion
                                #region CREAR Y VALIDA LA SESION

                                try
                                {
                                    //CREAR SESION
                                    _rs = wsSesiones.CrearSesion(Int64.Parse(codUsuarioOculto.Value));
                                }
                                catch (Exception ex)
                                {
                                    Application["Exception"] = ex;
                                    Response.Redirect("~/Aplicacion/Error.aspx", false);
                                }

                                //VALIDAR SI NO EXISTE LA SESION
                                if (!_rs.Codigo.ToString().Equals("0"))
                                {
                                    this.mpeRemoteBox.Show();
                                }
                                else
                                {
                                    idSesionOculto.Value = _rs.IdSesion;
                                    wsSeguridad.UsuariosRegistrarConexion(_UsuariosEntidad, _bitacoraEntidad);
                                    #region CARGA INFORMACION SESION

                                    //ALMACENA TEMPORALMENTE EL ID SESION DEL USUARIO
                                    HttpHelper httpPost = new HttpHelper();
                                    Dictionary<string, string> dataSesion = new Dictionary<string, string>();
                                    dataSesion.Add("idSesion", idSesionOculto.Value);
                                    dataSesion.Add("codUsuario", codUsuarioOculto.Value);
                                    dataSesion.Add("nomUsuario", nombreUsuarioOculto.Value);
                                    dataSesion.Add("rolUsuario", rolUsuarioOculto.Value);
                                    dataSesion.Add("pantallaModulo", "1"); //PAGINA DEFAULT
                                    httpPost.RedirectAndPOST(this.Page, "../Default.aspx", dataSesion);
                                    wsSeguridad.UsuariosRegistrarConexion(_UsuariosEntidad, _bitacoraEntidad);

                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                lblErrorLogin.Text = Resources.Sesiones.SesionPermisos;
                            }
                            #endregion

                            #endregion
                        }
                        else
                        {
                            if (!oBloqueado)
                            {
                                #region INGRESAR CORRECTAMENTE

                                lblErrorLogin.Text = string.Empty;
                                ValoresRegistrarIntentos(false, 0, DateTime.Now, String.Format(Resources.Sesiones.SesionLogueo, codUsuarioOculto.Value, DateTime.Now));
                                wsSeguridad.UsuariosRegistrarIntentos(_UsuariosEntidad, _bitacoraEntidad);
                                #region REGISTRA INGRESO CON SESIONES
                                UsuariosEntidad _dtRol = wsSeguridad.UsuariosObtenerRolUsuario(codUsuarioOculto.Value);
                                if (_dtRol != null)
                                {
                                    #region ROL USUARIO
                                    _RolesEntidad.IdTipoRol = _dtRol.IdTipoRol;
                                    string _rol = wsSeguridad.RolesConsultarDetalle(_RolesEntidad, _bitacoraEntidad).DesTipoRol;
                                    #endregion
                                    #region ASIGNAR VALORES OCULTOS
                                    codUsuarioOculto.Value = txtUsuario.Text.Trim();
                                    nombreUsuarioOculto.Value = wsSesiones.UsuarioNombreAd(codUsuarioOculto.Value);
                                    rolUsuarioOculto.Value = _rol;
                                    #endregion
                                    #region REGISTRAR INGRESO EN BITACORA
                                    ValoresRegistrarIngreso(String.Format(Resources.Sesiones.SesionIniciar, codUsuarioOculto.Value, DateTime.Now));
                                    //CAMBIO FGUEVARA
                                    _bitacoraEntidad.CodAccion = _bitacoraFlags.TipoBitacoraConsulta(EnumTipoBitacora.REGISTRAR);
                                    _bitacoraEntidad.DesRegistro = String.Format(Resources.Sesiones.SesionRegistrar, codUsuarioOculto.Value, DateTime.Now);
                                    wsSeguridad.UsuariosRegistrarIntentos(_UsuariosEntidad, _bitacoraEntidad);
                                    #endregion
                                    #region CREAR Y VALIDA LA SESION

                                    try
                                    {
                                        //CREAR SESION
                                        _rs = wsSesiones.CrearSesion(Int64.Parse(codUsuarioOculto.Value));
                                    }
                                    catch (Exception ex)
                                    {
                                        Application["Exception"] = ex;
                                        Response.Redirect("~/Aplicacion/Error.aspx", false);
                                    }

                                    //VALIDAR SI NO EXISTE LA SESION
                                    if (!_rs.Codigo.ToString().Equals("0"))
                                    {
                                        this.mpeRemoteBox.Show();
                                    }
                                    else
                                    {
                                        idSesionOculto.Value = _rs.IdSesion;
                                        #region CARGA INFORMACION SESION
                                        //ALMACENA TEMPORALMENTE EL ID SESION DEL USUARIO
                                        HttpHelper httpPost = new HttpHelper();
                                        Dictionary<string, string> dataSesion = new Dictionary<string, string>();
                                        dataSesion.Add("idSesion", idSesionOculto.Value);
                                        dataSesion.Add("codUsuario", codUsuarioOculto.Value);
                                        dataSesion.Add("nomUsuario", nombreUsuarioOculto.Value);
                                        dataSesion.Add("rolUsuario", rolUsuarioOculto.Value);
                                        dataSesion.Add("pantallaModulo", "1"); //PAGINA DEFAULT //CAMBIO FGUEVARA
                                        httpPost.RedirectAndPOST(this.Page, "../Default.aspx", dataSesion);
                                        //CAMBIO FGUEVARA
                                        _bitacoraEntidad.CodAccion = _bitacoraFlags.TipoBitacoraConsulta(EnumTipoBitacora.SESION_INICIA);
                                        _bitacoraEntidad.DesRegistro = String.Format(Resources.Sesiones.SesionIniciar, codUsuarioOculto.Value, DateTime.Now);
                                        wsSeguridad.UsuariosRegistrarConexion(_UsuariosEntidad, _bitacoraEntidad);
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    lblErrorLogin.Text = Resources.Sesiones.SesionPermisos;
                                }
                                #endregion

                                #endregion
                            }
                            else
                            {
                                #region REGISTRAR INTENTOS EN BITACORA / DESPLEGAR MENSAJE
                                ValoresRegistrarIntentos(true, _cantidadIntentos, DateTime.Now, String.Format(Resources.Sesiones.SesionBloqueado, codUsuarioOculto.Value, _tiempoEspera));
                                wsSeguridad.UsuariosRegistrarIntentos(_UsuariosEntidad, _bitacoraEntidad);
                                lblErrorLogin.Text = String.Format(Resources.Sesiones.SesionBloqueado, codUsuarioOculto.Value, _tiempoEspera);
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        #region REGISTRAR INTENTOS EN BITACORA / DESPLEGAR MENSAJE
                        ValoresRegistrarIntentos(true, _cantidadIntentos, DateTime.Now, String.Format(Resources.Sesiones.SesionPermisos));
                        wsSeguridad.UsuariosRegistrarIntentos(_UsuariosEntidad, _bitacoraEntidad);
                        lblErrorLogin.Text = Resources.Sesiones.SesionPermisos;
                        #endregion
                    }
                }
                else
                {
                    if (!oExiste)
                    {
                        #region REGISTRAR INTENTOS EN BITACORA / DESPLEGAR MENSAJE
                        ValoresRegistrarIntentos(true, _cantidadIntentos, DateTime.Now, String.Format(Resources.Sesiones.SesionEquivocado));
                        wsSeguridad.UsuariosRegistrarIntentos(_UsuariosEntidad, _bitacoraEntidad);
                        lblErrorLogin.Text = Resources.Sesiones.SesionEquivocado;
                        #endregion
                    }
                    else
                    {
                        if (!oAutenticado)
                        {
                            int intentos = (_intentosUsuario < _cantidadIntentos) ? ++_intentosUsuario : _intentosUsuario;                        
                            if (intentos < _cantidadIntentos)
                            {
                                #region REGISTRAR INTENTOS EN BITACORA / DESPLEGAR MENSAJE
                                ValoresRegistrarIntentos(false, intentos, DateTime.Now, String.Format(Resources.Sesiones.SesionIntento, codUsuarioOculto.Value, intentos, DateTime.Now));
                                wsSeguridad.UsuariosRegistrarIntentos(_UsuariosEntidad, _bitacoraEntidad);
                                lblErrorLogin.Text = Resources.Sesiones.SesionIncorrecto;
                                #endregion
                            }
                            else
                            {
                                #region REGISTRAR INTENTOS EN BITACORA / DESPLEGAR MENSAJE
                                ValoresRegistrarIntentos(true, _cantidadIntentos, DateTime.Now, String.Format(Resources.Sesiones.SesionBloqueado, codUsuarioOculto.Value, _tiempoEspera));
                                wsSeguridad.UsuariosRegistrarIntentos(_UsuariosEntidad, _bitacoraEntidad);
                                lblErrorLogin.Text = String.Format(Resources.Sesiones.SesionBloqueado, codUsuarioOculto.Value, _tiempoEspera);
                                #endregion
                            }
                        }
                    }
                }
            }
            else
            {
                lblErrorLogin.Text = "No se permiten caracteres especiales.";
            }
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

    private Boolean ValidaTiempoIngreso(DateTime _fechaIntento, int _tiempoEspera)
    {
        try
        {
            TimeSpan ts = DateTime.Now - _fechaIntento;

            if (_tiempoEspera < ts.Minutes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ValoresRegistrarIntentos(Boolean _bloqueado, int _cantidadIntento, DateTime _fechaIntento, string _desRegistro)
    {
        #region ENTIDAD USUARIO
        _UsuariosEntidad.CodUsuario = codUsuarioOculto.Value;
        _UsuariosEntidad.Bloqueado = _bloqueado;
        _UsuariosEntidad.CantidadIntento = _cantidadIntento;
        _UsuariosEntidad.FechaIntento = _fechaIntento;
        #endregion
        #region ENTIDAD BITACORA
        _bitacoraEntidad.CodAccion = _bitacoraFlags.TipoBitacoraConsulta(EnumTipoBitacora.SESION_CONSULTA);
        _bitacoraEntidad.CodModulo = 1;
        _bitacoraEntidad.CodEmpresa = int.Parse(Resources.Resource._empresa);
        _bitacoraEntidad.CodSistema = Resources.Resource._sistema;
        _bitacoraEntidad.CodUsuario = codUsuarioOculto.Value;
        _bitacoraEntidad.DesRegistro = _desRegistro;
        #endregion
    }

    private void ValoresRegistrarIngreso(string _desRegistro)
    {
        #region ENTIDAD USUARIO
        _UsuariosEntidad.CodUsuario = codUsuarioOculto.Value;
        _UsuariosEntidad.NombreUsuario = nombreUsuarioOculto.Value;
        _UsuariosEntidad.IdTipoRol = _RolesEntidad.IdTipoRol;
        _UsuariosEntidad.Conectado = true;
        _UsuariosEntidad.UltimaConexion = DateTime.Now;
        #endregion
        #region ENTIDAD BITACORA
        _bitacoraEntidad.CodAccion = _bitacoraFlags.TipoBitacoraConsulta(EnumTipoBitacora.SESION_CONSULTA);
        _bitacoraEntidad.CodModulo = 1;
        _bitacoraEntidad.CodEmpresa = int.Parse(Resources.Resource._empresa);
        _bitacoraEntidad.CodSistema = Resources.Resource._sistema;
        _bitacoraEntidad.CodUsuario = codUsuarioOculto.Value;
        _bitacoraEntidad.DesRegistro = _desRegistro;
        #endregion
    }

    #endregion

    #region EVENTOS CONTROL DE USUARIOS

    protected void BtnAceptar_Click(object sender, EventArgs e)
    {
        this.mpeRemoteBox.Hide();
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
                #region WEB SERVICES

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

                #endregion
            }
            _rs = null;
            _variableArreglo = null;

            _bitacoraFlags = null;
            _UsuariosEntidad = null;
            _bitacoraEntidad = null;
            
            disposed = true;
        }
    }

    #endregion

}
