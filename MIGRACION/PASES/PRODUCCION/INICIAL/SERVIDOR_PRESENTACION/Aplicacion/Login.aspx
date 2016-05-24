<%@ page language="C#" autoeventwireup="true" inherits="Login, App_Web_axygfhbq" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Library/controls/wucMensajeSesion.ascx" TagName="RemoteBox" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SIGANEM - Inicio de sesión</title>

    <!-- MIMIC INTERNET EXPLORER 8 -->
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <%--HOJAS DE ESTILO (CSS)--%>
    <link rel="Stylesheet" type="text/css" href="../Library/styles/LoginPage.css" />
    <link rel="Stylesheet" type="text/css" href="../Library/styles/LoadingControl.css" />
    <link rel="Stylesheet" type="text/css" href="../Library/styles/ModalPopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../Library/styles/MensajePopUp.css" />

</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />
    <input type="hidden" id="nombreUsuarioOculto" runat="server" />
    <input type="hidden" id="rolUsuarioOculto" runat="server" />

    <div style="width: 100%;">
        <table width="100%">
            <tr>
                <td class="Header">
                    <asp:Image ID="imgSiganem" runat="server" ImageUrl="~/library/img/Login/imgSiganem.png" />
                </td>
                <td class="HeaderBCR">
                    <asp:Image ID="imgBCRLogo" runat="server" ImageUrl="~/library/img/Login/imgLogoBCR.png" />
                </td>
            </tr>
            <tr>
                <td class="ImageContainer">
                    <asp:Image ID="imgPrincipal" runat="server" ImageUrl="~/library/img/Login/imgPrincipal.jpg" CssClass="imgPrincipal" />
                </td>
                <td class="LoginContainer">
                    <table style="width: 100%">
                        <tr>
                            <td class="Separator">
                            </td>
                        </tr>
                        <tr>
                            <td class="LoginTitle">
                                <asp:Label ID="lblTituloSesion" runat="server" Text="Inicie sesi&oacute;n con el usuario de BCR"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="LoginCredential">
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="LoginTextbox" Width="100%" Height="22px" AutoCompleteType="Disabled" MaxLength="20" TabIndex="1"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="txtweUsuario" runat="server" TargetControlID="txtUsuario"
                                    WatermarkText="Usuario BCR" WatermarkCssClass="WaterMarkTextBox">
                                </asp:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="LoginCredential">
                                <asp:TextBox ID="txtContrasena" runat="server" CssClass="LoginTextbox" Width="100%" TabIndex="2" AutoCompleteType="Disabled" Height="22px" MaxLength="255" TextMode="Password"
                                    onkeydown="if (event.keyCode == 13) document.getElementById('btnIngresar').click()"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="txtweContrasena" runat="server" TargetControlID="txtContrasena"
                                    WatermarkText="Contrase&ntilde;a" WatermarkCssClass="WaterMarkTextBox">
                                </asp:TextBoxWatermarkExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="LoginCredential">
                                <asp:UpdatePanel ID="UpdCredenciales" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="Loginbutton" OnClick="btnIngresar_Click" OnClientClick="this.disabled=true" TabIndex="3" UseSubmitBehavior="false" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnIngresar" />
                                    </Triggers>
                                </asp:UpdatePanel>                                
                            </td>
                        </tr>
                        <tr>
                            <td class="SeparatorError">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center>
                                    <asp:UpdatePanel ID="updError" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <asp:Label ID="lblErrorLogin" runat="server" CssClass="LoginError"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </center>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <div id="divFooter" class="Footer">
                        <asp:Label ID="lblCopyright" runat="server" Text="© 2013 Derechos Reservados. <br>Banco de Costa Rica."></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
    </div>

    <asp:UpdatePanelAnimationExtender ID="upae" BehaviorID="animation" runat="server"
            TargetControlID="UpdCredenciales" Enabled="True">
            <Animations>
                <OnUpdating>
                    <Parallel duration="0">
                        <ScriptAction Script="onUpdating();" />  
                        </Parallel>
                </OnUpdating>
                <OnUpdated>
                    <Parallel duration="0">
                        <ScriptAction Script="onUpdated();" /> 
                    </Parallel> 
                </OnUpdated></Animations>
        </asp:UpdatePanelAnimationExtender>
        <div id="updateProgressDiv" class="overlay" style="display: none">
            <div class="overlay" >
                <div class="overlayContent">
                    <center>
                        <asp:Image ID="imgCargando" ImageUrl="~/Library/img/MasterGrid/imgLoading.gif" runat="server" />
                        <h2></h2>
                        <h2>Procesando...</h2>
                    </center>
                </div>
            </div>
        </div>

    <asp:Panel runat="server" ID="popupRemoteBox" Style="display: none; background-color: #FFFFFF;">
        <uc1:RemoteBox ID="RemoteBox1" runat="server" />
        <asp:LinkButton runat="server" ID="lkbModal" CssClass="modalPopup" Style="visibility: hidden;" />
        <asp:ModalPopupExtender ID="mpeRemoteBox" runat="server" PopupControlID="popupRemoteBox"
            TargetControlID="lkbModal" BackgroundCssClass="modalBackground" DropShadow="false"
            RepositionMode="RepositionOnWindowResizeAndScroll" />
    </asp:Panel>
    </form>
</body>
</html>
