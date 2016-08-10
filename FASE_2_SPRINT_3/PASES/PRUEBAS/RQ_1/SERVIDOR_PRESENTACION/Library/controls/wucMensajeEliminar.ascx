<%@ control language="C#" autoeventwireup="true" inherits="wucMensajeEliminar, App_Web_234hhtrh" %>

<link rel="Stylesheet" type="text/css" href="../styles/MensajePopUp.css" />


<asp:Panel ID="pnlEliminar" runat="server" Height="180px" Width="300px">    
    <table style="width: 100%; height: 100%; border: solid 3px #484848; border-collapse: collapse;">
        <tr>
            <td style="height: 30px; background-color: #0B173B;">
                <table style="width: 100%; padding-left: 5px; ">
                    <tr>
                        <td style="width: 10px;">
                            <asp:Image ID="imgWarning" runat="server" ImageUrl="~/Library/controls/warning.png" Width="20px" />
                        </td>
                        <td style="padding-left: 10px;">
                            <asp:Label ID="lblTitle" runat="server" Text="Eliminaci&oacute;n" CssClass="TituloPopUpMsg"></asp:Label>
                        </td>
                    </tr>
                </table>                
            </td>
        </tr>
        <tr>
            <td style="height: 70px;" align="center" valign="middle">
                <asp:Panel runat="server" ID="msgPnlScroller" Width="100%" Height="100%">
                    <br />
                    <asp:Label ID="lblMensajeEliminar" runat="server" CssClass="MensajePopUpMsg" 
                        Text="Desea eliminar el(los) elemento(s) seleccionado(s)?"/>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 30px;" align="center" valign="middle">
                <asp:Button ID="wucBtnAceptar" runat="server" OnClick="wucBtnAceptar_Click" Text="S&iacute;"
                    CssClass="buttonPopUpMsg" CausesValidation="False"/>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="wucBtnCancelar" runat="server" OnClick="wucBtnCancelar_Click" Text="No"
                    CssClass="buttonPopUpMsg" CausesValidation="False"/>
            </td>
        </tr>
    </table>
</asp:Panel>