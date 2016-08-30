using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using BCR.SIGANEM.UT;


public partial class wucMensajeInformar : System.Web.UI.UserControl
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

    #endregion

    #region METODOS PERSONALIZADOS

    public void SetMessageBox(string titleMessage, string bodyMessage)
    {
        this.lblTitle.Text = titleMessage;
        this.lblMensajeInformar.Text = bodyMessage;
    }

    protected void On_SetConfirmationBoxEvent(object sender, EventArgs e, string tipo)
    {
        if (SetConfirmationBoxEvent != null)
            SetConfirmationBoxEvent(this, e, tipo);
        SetMessageBox(MessageFlags.TitleMessage, MessageFlags.BodyMessage);
    }
   
    #endregion

    #region DELEGACION

    public delegate void OnAcceptClick(object sender, EventArgs e);
    public event OnAcceptClick OnAcceptClickEvent;

    public delegate void SetConfirmationBox(object sender, EventArgs e, string tipo);
    public event SetConfirmationBox SetConfirmationBoxEvent;

    #endregion

}