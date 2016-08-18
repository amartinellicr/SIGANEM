<%@ control language="C#" autoeventwireup="true" inherits="wucMenuSuperiorDetalle, App_Web_s3gx1syb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link rel="Stylesheet" type="text/css" href="../styles/MenuSuperiorDetalle.css" />

<asp:Panel ID="WindowLoader" runat="server" CssClass="panelWindows">
    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />
    <input type="hidden" id="nombreUsuarioOculto" runat="server" />
    <input type="hidden" id="rolUsuarioOculto" runat="server" />
   
    <asp:UpdatePanel id="upPrincipal" runat="server">
        <ContentTemplate> 
            <table width="100%" style="border-collapse: collapse;">
                <tr>
                    <td>
                        <div style="text-align: right; width: 100%">
                            <asp:Label ID="lblDatosUsuario" runat="server" Text="Cédula - Nombre Completo | Rol" CssClass="lblDatosUsuario"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>
                        <asp:Panel ID="PanelMenu" runat="server">
                            <table runat="server" id="tableIdWindow" style="background-color: #FFFFFF; height: 115px;
                                width: 100%; border-collapse: collapse;">
                                <tr>
                                    <td style="vertical-align: top">
                                        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" CssClass="Tab"
                                            Width="100%">
                                            <asp:TabPanel ID="tabAyuda" runat="server" HeaderText="TabPanel1">
                                                <HeaderTemplate>
                                                    <asp:Image ID="imgTabTituloAyuda" runat="server" ImageUrl="~/Library/img/Ribbon/Ayuda_icon.png">
                                                    </asp:Image>
                                                </HeaderTemplate>
                                                <ContentTemplate>
                                                    <asp:Panel ID="panelAyuda" runat="server" Height="85px" Width="100%">
                                                        <table class="tableControlContenedor">
                                                            <tr>
                                                                <td style="height: 100%;">
                                                                    <table class="tableControlHorizontalAyuda">
                                                                        <tr>
                                                                            <td>
                                                                                <div id="divAyudaGuardar" runat="server" class="divTabsButtonsDetallePreHoverAyuda">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td class="tdImgControlHorizontalAyuda">
                                                                                                <asp:UpdatePanel ID="udpAyudaGuardar" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:Button ID="cmdAyudaGuardar" runat="server" CssClass="menuSuperiorDetalleBotonAyudaGuardar" Text="Guardar" />
                                                                                                    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="cmdAyudaGuardar" />
                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div id="divAyudaRegresar" runat="server" class="divTabsButtonsDetallePreHoverAyuda">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td class="tdImgControlHorizontalAyuda">
                                                                                                <asp:UpdatePanel ID="updAyudaRegresar" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:Button ID="cmdAyudaRegresar" runat="server" CssClass="menuSuperiorDetalleBotonAyudaRegresar" Text="Regresar" />
                                                                                                    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="cmdAyudaRegresar" />
                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td class="tdSeparador">
                                                                    <div class="divSeparador">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                            <asp:TabPanel ID="tabAcciones" runat="server" HeaderText="TabPanel1">
                                                <HeaderTemplate>
                                                    <asp:Image ID="imgTabTituloAcciones" runat="server" ImageUrl="~/Library/img/Ribbon/Acciones_icon.png">
                                                    </asp:Image>
                                                </HeaderTemplate>
                                                <ContentTemplate>
                                                    <asp:Panel ID="panelAcciones" runat="server" Height="85px" Width="100%">
                                                        <table class="tableControlContenedor">
                                                            <tr>
                                                                <td style="height: 100%;">
                                                                    <div id="divGuardar" runat="server" class="divTabsButtonsPreHover">
                                                                        <table class="tableControl">
                                                                            <tr>
                                                                                <td class="tdImgControl">
                                                                                    <asp:UpdatePanel ID="UpdGuardar" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                                                                                        <ContentTemplate>
                                                                                            <asp:Button ID="cmdAccionesGuardar" runat="server" CssClass="menuSuperiorDetalleBotonAccionesGuardar" Text="Guardar" UseSubmitBehavior="False" ClientIDMode="Static" />
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:PostBackTrigger ControlID="cmdAccionesGuardar" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                                <td style="height: 100%;">
                                                                    <table class="tableControlHorizontal">
                                                                        <tr>
                                                                            <td>
                                                                                <div id="divGuardarNuevo" runat="server" class="divTabsButtonsPreHoverHorizontal">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td class="tdImgControlHorizontal">
                                                                                                <asp:UpdatePanel ID="updGuardarNuevo" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:Button ID="cmdAccionesGuardarNuevo" runat="server" CssClass="menuSuperiorDetalleBotonAccionesGuardarNuevo" Text="Guardar y Nuevo" ClientIDMode="Static" />
                                                                                                    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="cmdAccionesGuardarNuevo" />
                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div id="div1" runat="server" class="divTabsButtonsPreHoverHorizontal">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td class="tdImgControlHorizontal">
                                                                                                <asp:UpdatePanel ID="udpGuardarCerrar" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:Button ID="cmdAccionesGuardarCerrar" runat="server" CssClass="menuSuperiorDetalleBotonAccionesGuardarCerrar" Text="Guardar y Cerrar" ClientIDMode="Static" />
                                                                                                    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="cmdAccionesGuardarCerrar" />
                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div id="div2" runat="server" class="divTabsButtonsPreHoverHorizontal">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td class="tdImgControlHorizontal">
                                                                                                <asp:UpdatePanel ID="updRegresar" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:Button ID="cmdAccionesRegresar" runat="server" CssClass="menuSuperiorDetalleBotonAccionesRegresar" Text="Regresar" ClientIDMode="Static" />
                                                                                                    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="cmdAccionesRegresar" />
                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td class="tdSeparador">
                                                                    <div class="divSeparador">
                                                                    </div>
                                                                </td>
                                                                <td style="height: 100%;">
                                                                    <div id="divBorrar" runat="server" class="divTabsButtonsPreHover">
                                                                        <table class="tableControl">
                                                                            <tr>
                                                                                <td class="tdImgControl">
                                                                                    <asp:UpdatePanel ID="udpLimpiar" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                                                                                        <ContentTemplate>
                                                                                            <asp:Button ID="cmdAccionesLimpiar" runat="server" CssClass="menuSuperiorDetalleBotonAccionesBorrar" Text="Borrar" ClientIDMode="Static" />
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:PostBackTrigger ControlID="cmdAccionesLimpiar" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                                <td class="tdSeparador">
                                                                    <div class="divSeparador">
                                                                    </div>
                                                                </td>
                                                                <td style="height: 100%;">
                                                                    <div id="divReplicar" runat="server" class="divTabsButtonsPreHoverDisabled">
                                                                        <table class="tableControl">
                                                                            <tr>
                                                                                <td class="tdImgControl">
                                                                                    <asp:UpdatePanel ID="udpReplicar" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                                                                                        <ContentTemplate>
                                                                                            <asp:Button ID="cmdAccionesReplicar" runat="server" CssClass="menuSuperiorDetalleBotonAccionesReplicarDisabled" Text="Replicar" ClientIDMode="Static" Visible="false" />
                                                                                        </ContentTemplate>
                                                                                        <Triggers>
                                                                                            <asp:PostBackTrigger ControlID="cmdAccionesReplicar" />
                                                                                        </Triggers>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:TabPanel>
                                        </asp:TabContainer>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

