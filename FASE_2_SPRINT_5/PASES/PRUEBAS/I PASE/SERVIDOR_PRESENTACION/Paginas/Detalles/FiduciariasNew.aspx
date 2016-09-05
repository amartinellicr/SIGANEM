﻿<%@ page title="" language="C#" masterpagefile="~/Library/styles/MasterPages/SubMain.Master" autoeventwireup="true" inherits="FiduciariasNew, App_Web_wcuz5xav" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Reference Control="~/Library/controls/wucMenuLateralDetalle.ascx" %>
<%@ Reference Control="~/Library/controls/wucMenuSuperiorDetalle.ascx" %>
<%@ Reference Control="~/Library/controls/wucGridControl.ascx" %>

<%@ Register Src="~/Library/controls/wucMensajeEliminar.ascx" tagname="MensajeEliminar" tagprefix="uc3" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformar" tagprefix="uc4" %>
<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" tagname="BCRClientes" tagprefix="uc5" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarBCRClientes" tagprefix="uc5" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="Server">
    <title>Fiduciarias Detalle</title>
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterSubMain.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MensajePopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/ModalPopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css"/>
    
    <script src="../../Library/scripts/Procesando.js" language="javascript" type="text/javascript"></script>
    <script src="../../Library/scripts/DropDownList.js" language="javascript" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" /> 
    <input type="hidden" id="pantallaIdOculto" runat="server" />
    <input type="hidden" id="pantallaTituloOculto" runat="server" />
    <input type="hidden" id="pantallaModuloOculto" runat="server" />
    <input type="hidden" id="pantallaNombreOculto" runat="server" />

    <div id="body" class="body">
        <asp:UpdatePanel ID="UpdatePanelControles" runat="server">
            <ContentTemplate>
                <div id="divHeader">
                    <table class="tablePage">
                        <tr>
                            <td colspan="4" style="height: 18px; vertical-align: middle;">
                                <div id="divBarraMensaje" class="divBarraMensaje" runat="server" visible="false">
                                    <asp:Label ID="lblBarraMensaje" runat="server" CssClass="etiquetaBarraMensajeExito" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 8px;">
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2" class="tdImage">
                                <asp:Image ID="imgPagina" runat="server" ImageUrl="~/Library/img/32/iconNuevo.png"
                                    Height="32px" Width="32px" Visible="true" />
                            </td>                            
                            <td class="tdTitle">
                                <asp:Label ID="lblPagina" runat="server" CssClass="titlePage"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdTitle">
                                <asp:Label ID="lblPaginaSubtitulo" runat="server" CssClass="titlePage2"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 12px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 12px;">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divForm">

                    <table class="tableForm">
                        <tr>
                            <td>
                                <asp:Label ID="lblForm" runat="server" Text="Mantenimiento de " CssClass="titleForm"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLine">
                                <div id="General">
                                    <asp:Label ID="lblFormSubtitulo" runat="server" CssClass="titleForm2"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>

                </div>
                <div id="divControls">
                    <asp:Table runat="server" ID="tableData" EnableViewState="true">
                    </asp:Table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        
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

        <asp:Panel runat="server" ID="popupInformarBusqueda" style="display: none; background-color: #FFFFFF;">
            <uc5:MensajeInformarBCRClientes ID="InformarBoxBusqueda" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInformarBusqueda" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBoxBusqueda" runat="server" 
                PopupControlID="popupInformarBusqueda" 
                TargetControlID="lkbModalInformarBusqueda" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>
        

        <asp:Panel runat="server" ID="popupBusqueda" style="display: none; background-color: #FFFFFF; height: 306px; width: 550px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc5:BCRClientes ID="BCRClientes" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalBusqueda" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeBusqueda" runat="server"
                PopupControlID="popupBusqueda" 
                TargetControlID="lkbModalBusqueda" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

    </div>
</asp:Content>
