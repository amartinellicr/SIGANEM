using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;


public partial class wucMensajeSesion : System.Web.UI.UserControl
{

    #region METODOS INTERNOS

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMensajeSesion.Text = "Sesi&oacute;n iniciada.<br> Por favor espere " + ConfigurationManager.AppSettings["ExpiracionWCF"].ToString() + " minutos para ingresar.";
        wucBtnAceptar.Focus();
    }

    protected void wucBtnAceptar_Click(object sender, EventArgs e)
    {
        if (OnAcceptClickEvent != null)
            OnAcceptClickEvent(this, e);
    }

    protected void wucBtnCancelar_Click(object sender, EventArgs e)
    {
        if (OnCancelClickEvent != null)
            OnCancelClickEvent(this, e);
    }

    #endregion

    #region DELEGACION

    public delegate void OnAcceptClick(object sender, EventArgs e);
    public event OnAcceptClick OnAcceptClickEvent;

    public delegate void OnCancelClick(object sender, EventArgs e);
    public event OnCancelClick OnCancelClickEvent;

    #endregion

}