using System;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using SesionesWCF;
using SeguridadWS;

using BCR.SIGANEM.UT;


public partial class wucMenuSuperiorDetalle : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region REFERENCIAS

    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();

    private BitacoraFlags _bitacoraFlags = new BitacoraFlags();
    private TiposRolesEntidad _Roles = new TiposRolesEntidad();
    private BitacorasEntidad _bitacora = new BitacorasEntidad();

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            AsignaWebServicesTypeNames();
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
                    }
                }
                #endregion
                DatosUsuario();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    private void DatosUsuario()
    {
        try
        {
            #region VALORES BITACORA
            _bitacora.CodUsuario = codUsuarioOculto.Value;
            _bitacora.CodAccion = _bitacoraFlags.TipoBitacoraConsulta(EnumTipoBitacora.CONSULTAR);
            _bitacora.CodModulo = 1;
            _bitacora.CodEmpresa = int.Parse(Resources.Resource._empresa);
            _bitacora.CodSistema = Resources.Resource._sistema;
            #endregion
            #region ROL USUARIO
            _Roles.IdTipoRol = int.Parse(wsSeguridad.UsuariosObtenerRolUsuario(codUsuarioOculto.Value).IdTipoRol.ToString());
            rolUsuarioOculto.Value = wsSeguridad.RolesConsultarDetalle(_Roles, _bitacora).DesTipoRol.ToString();
            nombreUsuarioOculto.Value = wsSesiones.UsuarioNombreAd(codUsuarioOculto.Value);
            #endregion
            StringBuilder sb = new StringBuilder();
            sb.Append(nombreUsuarioOculto.Value);
            sb.Append(" | ");
            sb.Append(rolUsuarioOculto.Value);

            //ASIGNAR VALORES DE USUARIO
            this.ExtraText(sb.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region METODOS NO PERSONALIZABLES

    public void ExtraText(string value) 
    {
        lblDatosUsuario.Text = value;        
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

    #region EFECTOS DE BOTONES

    public void DeshabilitarBotonesGuardar(bool disabled)
    {
        if (disabled)
        {
            this.cmdAccionesGuardar.Enabled = false;
            this.cmdAccionesGuardar.CssClass = "menuSuperiorDetalleBotonAccionesGuardarDisabled";
            this.divGuardar.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");

            this.cmdAccionesGuardarCerrar.Enabled = false;
            this.cmdAccionesGuardarCerrar.CssClass = "menuSuperiorDetalleBotonAccionesGuardarCerrarDisabled";
            this.div1.Attributes.Add("class", "divTabsButtonsPreHoverHorizontalDisabled");

            this.cmdAccionesGuardarNuevo.Enabled = false;
            this.cmdAccionesGuardarNuevo.CssClass = "menuSuperiorDetalleBotonAccionesGuardarNuevoDisabled";
            this.divGuardarNuevo.Attributes.Add("class", "divTabsButtonsPreHoverHorizontalDisabled");

            this.cmdAyudaGuardar.Enabled = false;
            this.cmdAyudaGuardar.CssClass = "menuSuperiorDetalleBotonAyudaGuardarDisabled";
            this.divAyudaGuardar.Attributes.Add("class", "divTabsButtonsPreHoverHorizontalDisabled");
        }
        else
        {
            this.cmdAccionesGuardar.Enabled = true;
            this.cmdAccionesGuardar.CssClass = "menuSuperiorDetalleBotonAccionesGuardar";
            this.divGuardar.Attributes.Add("class", "divTabsButtonsPreHover");

            this.cmdAccionesGuardarCerrar.Enabled = true;
            this.cmdAccionesGuardarCerrar.CssClass = "menuSuperiorDetalleBotonAccionesGuardarCerrar";
            this.div1.Attributes.Add("class", "divTabsButtonsPreHoverHorizontal");

            this.cmdAccionesGuardarNuevo.Enabled = true;
            this.cmdAccionesGuardarNuevo.CssClass = "menuSuperiorDetalleBotonAccionesGuardarNuevo";
            this.divGuardarNuevo.Attributes.Add("class", "divTabsButtonsPreHoverHorizontal");

            this.cmdAyudaGuardar.Enabled = true;
            this.cmdAyudaGuardar.CssClass = "menuSuperiorDetalleBotonAyudaGuardar";
            this.divAyudaGuardar.Attributes.Add("class", "divTabsButtonsPreHoverHorizontal");
        }

        UpdGuardar.Update();
        udpGuardarCerrar.Update();
        updGuardarNuevo.Update();
        udpAyudaGuardar.Update();
        udpLimpiar.Update();
    }

    public void DeshabilitarBotonesReplicar(bool disabled)
    {
        if (disabled)
        {
            this.cmdAccionesReplicar.Enabled = false;
            this.cmdAccionesReplicar.CssClass = "menuSuperiorDetalleBotonAccionesReplicarDisabled";
            this.divReplicar.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
        }
        else
        {
            this.cmdAccionesReplicar.Enabled = true;
            this.cmdAccionesReplicar.CssClass = "menuSuperiorDetalleBotonAccionesReplicar";
            this.divReplicar.Attributes.Add("class", "divTabsButtonsPreHover");
        }

        udpReplicar.Update();
    }

    public void DeshabilitarBotonesBorrar(bool disabled)
    {
        if (disabled)
        {
            this.cmdAccionesLimpiar.Enabled = false;
            this.cmdAccionesLimpiar.CssClass = "menuSuperiorDetalleBotonAccionesBorrarDisabled";
            this.divBorrar.Attributes.Add("class", "divTabsButtonsPreHoverDisabled");
        }
        else
        {
            this.cmdAccionesLimpiar.Enabled = true;
            this.cmdAccionesLimpiar.CssClass = "menuSuperiorDetalleBotonAccionesBorrar";
            this.divReplicar.Attributes.Add("class", "divTabsButtonsPreHover");
        }

        udpLimpiar.Update();
    }

    #endregion

    #endregion

}