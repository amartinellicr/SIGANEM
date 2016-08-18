<%@ control language="C#" autoeventwireup="true" inherits="wucMensajeSesion, App_Web_s3gx1syb" %>

<link rel="Stylesheet" type="text/css" href="../styles/MensajePopUp.css" />

<asp:UpdatePanel id="upPrincipal" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlSesion" runat="server" Height="185px" Width="350px">
            <table style="width: 100%; height: 100%; border: solid 3px #484848; border-collapse: collapse;">
                <tr>
                    <td style="height: 30px; background-color: #0B173B;">
                        <table style="width: 100%; padding-left: 5px;">
                            <tr>
                                <td style="width: 10px;">
                                    <asp:Image ID="imgWarning" runat="server" ImageUrl="~/Library/controls/warning.png" Width="20px" />
                                </td>
                                <td style="padding-left: 10px;">
                                    <asp:Label ID="lblTitle" runat="server" Text="Sesi&oacute;n Abierta" CssClass="TituloPopUpMsg"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 100px;" align="center" valign="middle">
                        <asp:Panel runat="server" ID="msgPnlScroller" Width="100%" Height="100%">
                            <br />
                            <br />
                            <asp:Label ID="lblMensajeSesion" runat="server" CssClass="MensajePopUpMsg" Text=" ... " />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px;" align="center" valign="middle">
                        <asp:Button ID="wucBtnAceptar" runat="server" OnClick="wucBtnAceptar_Click" Text="Aceptar" CssClass="buttonPopUpMsg" CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>