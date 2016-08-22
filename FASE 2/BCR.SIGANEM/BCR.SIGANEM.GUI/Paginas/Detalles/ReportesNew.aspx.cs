using System;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections.Specialized;


public partial class ReportesNew : System.Web.UI.Page
{
    #region VARIABLES

    private NameValueCollection datosSesion = null;

    #endregion
        
    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            VariablesGlobales();
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
                this.frmReporte.Attributes["src"] = ObtenerURL();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string ObtenerURL()
    {
        string caracterSeparador = "%2f";

        StringBuilder url = new StringBuilder();
        url.Clear();

        url.Append(ConfigurationManager.AppSettings["ServidorReportes"].ToString());
        url.Append("/Pages/ReportViewer.aspx?");
        url.Append(caracterSeparador);
        url.Append(ConfigurationManager.AppSettings["CarpetaReportes"].ToString());
        url.Append(caracterSeparador);
        url.Append(ObtenerNombreParametrosReporte());
        url.Append("&rc:Parameters=false");

        return url.ToString();
    }

    private string ObtenerNombreParametrosReporte()
    {
        try
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Clear();

            datosSesion = Request.Form;
            string[] valores = datosSesion.AllKeys;
            foreach (string valor in valores)
            {
                switch (valor)
                {
                    case "nombreReporte":
                        retorno.Append(datosSesion["nombreReporte"].ToString());
                        break;

                }
            }

            retorno.Append("&");

            foreach (string valor in valores)
            {
                switch (valor)
                {
                    case "parametrosReporte":
                        retorno.Append(datosSesion["parametrosReporte"].ToString());
                        break;

                }
            }

            return retorno.ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
       
    /*CARGA LAS VARIABLES DEL POST*/
    private void VariablesGlobales()
    {
        try
        {
            #region OBTENER VALORES SESION
            //ALMACENA LA INFORMACION DE LA SESION
            datosSesion = Request.Form;
            string[] valores = datosSesion.AllKeys;
            foreach (string valor in valores)
            {
                switch (valor)
                {
                    case "idSesion":
                        idSesionOculto.Value = datosSesion["idSesion"].ToString();
                        break;
                    case "codUsuario":
                        codUsuarioOculto.Value = datosSesion["codUsuario"].ToString();
                        break;
                    case "pantallaModulo":
                        pantallaModuloOculto.Value = datosSesion["pantallaModulo"].ToString();
                        break;
                    //case "nombreReporte":
                    //    nombreReporteOculto.Value = dataSesion["nombreReporte"].ToString();
                    //    break;
                    //case "parametrosReporte":
                    //    parametrosReporteOculto.Value = dataSesion["parametrosReporte"].ToString();
                    //    break;

                }
            }
            #endregion

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}