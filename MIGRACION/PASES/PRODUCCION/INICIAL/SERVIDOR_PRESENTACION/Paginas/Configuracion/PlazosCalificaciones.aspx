<%@ page language="C#" title="Plazos de Calificación" masterpagefile="~/Library/styles/MasterPages/Main.Master" autoeventwireup="true" inherits="PlazosCalificaciones, App_Web_htf5eloj" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Library/controls/wucMasterGrid.ascx" tagname="MasterGrid" tagprefix="uc1" %>
<%@ Register Src="~/Library/controls/wucMasterPager.ascx" tagname="MasterPager" tagprefix="uc2" %>
<%@ Register Src="~/Library/controls/wucMensajeEliminar.ascx" tagname="MensajeEliminar" tagprefix="uc3" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformar" tagprefix="uc4" %>

<%@ Reference Control="~/Library/controls/wucMenuSuperior.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Plazos de Calificación</title> 
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MensajePopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/ModalPopUp.css" />

    <script src="../../Library/scripts/Procesando.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />
    <input type="hidden" id="pantallaIdOculto" runat="server" />
    <input type="hidden" id="pantallaTituloOculto" runat="server" />
    <input type="hidden" id="pantallaModuloOculto" runat="server" />
    <input type="hidden" id="pantallaNombreOculto" runat="server" />

    <asp:UpdatePanel ID="updMasterGrid" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <uc1:MasterGrid ID="MasterGrid1" runat="server"/>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Panel runat="server" ID="popupEliminar" style="display: none; background-color: #FFFFFF;">
        <uc3:MensajeEliminar ID="EliminarBox1" runat="server" />
        <asp:LinkButton runat="server" ID="lkbModal" CssClass="modalPopup" style="visibility: hidden;" />
        <asp:ModalPopupExtender ID="mpeEliminarBox" runat="server"
            PopupControlID="popupEliminar" 
            TargetControlID="lkbModal" 
            BackgroundCssClass="modalBackground"
            DropShadow="false"
            RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
    </asp:Panel>

    <asp:Panel runat="server" ID="popupInformar" style="display: none; background-color: #FFFFFF;">
        <uc4:MensajeInformar ID="InformarBox1" runat="server" />
        <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" style="visibility: hidden;" />
        <asp:ModalPopupExtender ID="mpeInformarBox" runat="server"
            PopupControlID="popupInformar" 
            TargetControlID="lkbModalInfo" 
            BackgroundCssClass="modalBackground"
            DropShadow="false"
            RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:UpdatePanel ID="updMasterPager" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <uc2:MasterPager ID="MasterPager1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>