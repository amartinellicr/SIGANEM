using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;

public partial class VisualizacionArchivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (Impersonador imp = new Impersonador(
            ConfigurationManager.AppSettings[Resources.Resource.Usuario],
            ConfigurationManager.AppSettings[Resources.Resource.Dominio],
            ConfigurationManager.AppSettings[Resources.Resource.Contrasena]))
        {
            byte[] buffer = File.ReadAllBytes(Request.Form["rutaArchivo"]);

            Response.Buffer = true;
            Response.Charset = "UTF-8";

            if (Request.Form["tipoAccion"].Contains("0"))
            {
                Response.ContentType = "application/pdf";

            }

            else if (Request.Form["tipoAccion"].Contains("1"))
            {
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request.Form["nombreArchivo"]);
                Response.ContentType = "application/msword";
            }

            else
            {
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Request.Form["nombreArchivo"]);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(buffer);
            Response.Flush();
            Response.End();
        }
    }
}