using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;


public partial class SubMain : System.Web.UI.MasterPage
{
    protected override void OnInit(EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                #region OBTENER VALORES SESION
                //ALMACENA LA INFORMACION DE LA SESION
                AsignarSesion();
                #endregion
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

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
            }
        }
        #endregion
    }
}
