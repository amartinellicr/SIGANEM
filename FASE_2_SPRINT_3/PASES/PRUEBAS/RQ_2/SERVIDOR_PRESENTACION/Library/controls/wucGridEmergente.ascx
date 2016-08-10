<%@ control language="C#" autoeventwireup="true" inherits="wucGridEmergente, App_Web_tk4isljl" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformar" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css" />
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterEmergente.css" />

<asp:UpdatePanel id="upPrincipal" runat="server">
    <ContentTemplate>
        <asp:Panel id="pnlGridView" runat="server" class="mainPanel" width="100%">
            <div class="divPrincipalTitulo">
                <table style="padding-left: 5px; padding-top: 3px;">
                    <tr>
                        <td>
                            <asp:Label ID="lblTitulo" runat="server" Text="Abc" CssClass="titulo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left">
                            <asp:Label ID="lblSubtitulo" runat="server" Text="Abc" CssClass="subTitulo"></asp:Label>
                            <asp:Label ID="lblIP" runat="server" Text="Abc" CssClass="subTitulo" Visible="false"></asp:Label>
                            <asp:HiddenField ID="hdnSinDatos" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="divPrincipalSuperior">
                <asp:Panel ID="panelGrid" ScrollBars="Auto" runat="server" CssClass="panelPrincipalGrid">
                    <table style="width: 100%; border-collapse: collapse; background-color: #E8ECF0">
                        <tr>
                            <td style="width: 100%; height: 100%;">
                                <table class="masterGridTable" style="width: 100%;">
                                    <tr>
                                        <td style="text-align: center;">
                                            <asp:panel id="gridContainer" runat="server" style="display: block; height: 100%;">
                                                <asp:gridview id="MasterGridView" runat="server" autogeneratecolumns="False" cssclass="mainGridView"
                                                    horizontalalign="Center" style="width: 100%;" gridlines="Horizontal" allowsorting="true"
                                                    showheaderwhenempty="true" onrowcreated="MasterGridView_RowCreated">
                                                    <headerstyle cssclass="headerGridView" horizontalalign="Center" verticalalign="Middle" />
                                                    <rowstyle cssclass="rowGridView" horizontalalign="Center" verticalalign="Middle" />
                                                    <alternatingrowstyle cssclass="alternateRowGridView" horizontalalign="Center" />
                                                    <pagersettings visible="true" />
                                                    <emptydatatemplate>
                                                       <div class="lblEmptyData" style="background-color: #F2F5A9;">                                                      
                                                            <asp:Label ID="labelEmptyData" runat="server" Text='<%#AsignarGridVacio() %>' />
                                                        </div>
                                                    </emptydatatemplate>
                                                </asp:gridview>
                                            </asp:panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <div class="divPrincipalInferior">
                <table width="100%" style="padding-top: 10px; padding-right: 5px; height:100%;">
                    <tr>
                        <td style="width: 100%">
                            <asp:Button ID="cmdMainEmergenteAceptar" runat="server" Text="Aceptar" CssClass="botonAceptar" />
                            <asp:Button ID="cmdMainEmergenteCancelar" runat="server" Text="Cancelar" CssClass="botonCancelar" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel runat="server" ID="popupInformar" style="display: none; background-color: #FFFFFF;">
                <uc3:MensajeInformar ID="InformarBox1" runat="server" />
                <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" style="visibility: hidden;" />
                <asp:ModalPopupExtender ID="mpeInformarBox" runat="server"
                    PopupControlID="popupInformar" 
                    TargetControlID="lkbModalInfo" 
                    BackgroundCssClass="modalBackground"
                    DropShadow="false"
                    RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
            </asp:Panel>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
