using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class wucMensajeEliminar : System.Web.UI.UserControl
{
    
    #region METODOS INTERNOS

    protected void Page_Load(object sender, EventArgs e)
    {
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

    public void EstablecerMensaje(string mensaje)
    {
        this.lblMensajeEliminar.Text = mensaje;
    }

    public void EstablecerNombreBotones(string textoBotonConfirmar, string textoBotonCancelar)
    {
        this.wucBtnAceptar.Text = textoBotonConfirmar;
        this.wucBtnCancelar.Text = textoBotonCancelar;
    }

    #endregion

    #region DELEGACION

    public delegate void OnAcceptClick(object sender, EventArgs e);
    public event OnAcceptClick OnAcceptClickEvent;

    public delegate void OnCancelClick(object sender, EventArgs e);
    public event OnCancelClick OnCancelClickEvent;

    #endregion

}