using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wucPropiedadesRegistro : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void EstablecerValoresPropiedades(string creadoPor, string fechaCreacion, string modificadoPor, string fechaModificacion, string fuente)
    {
        this.lblCreadoPor.Text = creadoPor;
        this.lblFechaCreacion.Text = fechaCreacion;
        this.lblModificadoPor.Text = modificadoPor;
        this.lblFechaModificacion.Text = fechaModificacion;
        this.lblFuente.Text = fuente;
    }
}