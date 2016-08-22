<%@ Page Title="Genera Archivo Salida SUGEF" Language="C#" MasterPageFile="~/Library/styles/MasterPages/Main.Master"
    AutoEventWireup="true" CodeFile="GeneraArchivoSalidaSUGEF.aspx.cs" Inherits="GeneraArchivoSalidaSUGEF" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Library/styles/MasterPages/Main.Master" %>
<%@ Reference Control="~/Library/controls/wucMenuSuperior.ascx" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformar"
    TagPrefix="uc1" %>
<%--<%@ Register Src="~/Library/controls/wucMasterGridSinFiltro.ascx" TagName="MasterGrid" TagPrefix="uc2" %>--%>
<%@ Register Src="~/Library/controls/wucMasterPager.ascx" TagName="MasterPager" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MensajePopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/ModalPopUp.css" />
    <script src="../../Library/scripts/Procesando.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />
    <input type="hidden" id="pantallaIdOculto" runat="server" />
    <input type="hidden" id="pantallaCodOculto" runat="server" />
    <input type="hidden" id="pantallaTituloOculto" runat="server" />
    <input type="hidden" id="pantallaModuloOculto" runat="server" />
    <input type="hidden" id="pantallaNombreOculto" runat="server" />
    <div id="body" class="body">
        <asp:UpdatePanel ID="udpBitacora" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div style="width: 100%; background-color: #E8ECF0">
                    <div style="background-color: #E8ECF0; width: 100%; height: 35px;">
                        <div style="top: 10px; left: 20px; position: relative; float: left">
                            <asp:Label ID="lblTituloPage" runat="server" CssClass="tdUpperTitle"></asp:Label>
                        </div>
                    </div>
                    <div id="divControlesBitacora" class="divControles">
                        <div style="left: 3px; bottom: 3px; background-color: white; width: 99.5%; position: relative">
                            <div style="width: 740px; position: relative">
                                <asp:Table runat="server" ID="tableData" EnableViewState="true">
                                </asp:Table>
                                <br />
                                <div style="text-align: center">
                                    <asp:Button ID="btnGenerar" runat="server" ClientIDMode="Static" Text="Generar" OnClick="btnGenerar_Click"
                                        CssClass="mainTableBoxesCss" />
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <%--<Triggers>
                <asp:PostBackTrigger ControlID="btnGenerar" />
            </Triggers>--%>
        </asp:UpdatePanel>
        <%--MENSAJE INFORMAR GENERAL--%>
        <asp:Panel runat="server" ID="popupInformar" Style="display: none; background-color: #FFFFFF;">
            <uc1:MensajeInformar ID="InformarBox1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBox" runat="server" PopupControlID="popupInformar"
                TargetControlID="lkbModalInfo" BackgroundCssClass="modalBackground" DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll" />
        </asp:Panel>
        <%--
        <asp:UpdatePanelAnimationExtender ID="upae" BehaviorID="animation" runat="server"
            TargetControlID="UpdatePanelControles" Enabled="True">
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
                        <asp:Image ID="Image1" ImageUrl="~/Library/img/MasterGrid/imgLoading.gif" runat="server" />
                        <h2></h2>
                        <h2>Procesando...</h2>
                    </center>
                </div>
            </div>
        </div>

        --%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:UpdatePanel ID="updMasterPager" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <uc3:MasterPager ID="MasterPager1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
