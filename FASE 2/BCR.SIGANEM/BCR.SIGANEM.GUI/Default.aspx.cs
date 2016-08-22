using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Collections.Specialized;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class Default : System.Web.UI.Page
{

    #region METODOS PERSONALIZADOS NO EDITABLES

    protected void Page_Load(object sender, EventArgs e)
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
                    case "pantallaModulo":
                        pantallaModuloOculto.Value = Request.Form["pantallaModulo"].ToString();
                        break;
                }
            }
            #endregion
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesAcciones(true);
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesDatos(true);
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesMasAcciones(true);
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesReportes(true);
        }
    }

    #endregion

} 
