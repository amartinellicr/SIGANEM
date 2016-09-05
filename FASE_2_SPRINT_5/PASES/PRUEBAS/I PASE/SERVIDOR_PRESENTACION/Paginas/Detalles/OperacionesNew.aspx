<%@ page title="" language="C#" masterpagefile="~/Library/styles/MasterPages/SubMain.Master" autoeventwireup="true" inherits="OperacionesNew, App_Web_22pamoa0" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Reference Control="~/Library/controls/wucMenuLateralDetalle.ascx" %>
<%@ Reference Control="~/Library/controls/wucMenuSuperiorDetalle.ascx" %>
<%@ Reference Control="~/Library/controls/wucGridControl.ascx" %>

<%--MENSAJES--%>
<%@ Register Src="~/Library/controls/wucMensajeEliminar.ascx" tagname="MensajeEliminar" tagprefix="uc3" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformar" tagprefix="uc4" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarBCRClientes" tagprefix="uc5" %>
<%--CONTROLES--%>
<%@ Register Src="~/Library/controls/wucOperacionConsulta.ascx" TagName="ConsultaSICC" TagPrefix="uc6" %>
<%@ Register Src="~/Library/controls/wucOperacionClientes.ascx" TagName="ConsultaClienteSICC" TagPrefix="uc7" %>
<%--GRIDS DETALLE MAIN--%>
<%@ Register Src="~/Library/controls/wucOperacionesGridGarantias.ascx" tagname="ConsultaGridGarantia" tagprefix="uc8" %>
<%--GRIDS DETALLE POPUPS--%>
<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" tagname="BCRClientes" tagprefix="uc9" %>
<%--CONTROLES GARANTIAS FIDUCIARIAS--%>
<%@ Register Src="~/Library/controls/wucOperacionRelacionFiduciaria.ascx" tagname="GarantiaFiduciaria" tagprefix="uc10" %>
<%--CONTROLES GARANTIAS VALORES--%>
<%@ Register Src="~/Library/controls/wucOperacionRelacionValores.ascx" tagname="GarantiaValores" tagprefix="uc12" %>
<%--CONTROLES GARANTIAS VALORES--%>
<%@ Register Src="~/Library/controls/wucOperacionRelacionReales.ascx" tagname="GarantiaReales" tagprefix="uc13" %>
<%-- //Req F2S03 2016-21-06 G.Avales--%>
<%--CONTROLES GARANTIAS AVALES--%>
<%@ Register Src="~/Library/controls/wucOperacionRelacionAvales.ascx" tagname="GarantiaAvales" tagprefix="uc14" %>
<%--CONTROLES RELACION GARANTIAS FIDEICOMISO --%>
<%@ Register Src="~/Library/controls/wucOperacionesRelacionGarantiaFideicomiso.ascx" tagname="RelacionGarantiaFideicomiso" tagprefix="uc26" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="Server">
    <title>Operaciones Detalle</title>
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterSubMain.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MensajePopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/ModalPopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css"/>

    <link rel="Stylesheet" type="text/css" href="../../Library/styles/GridControl.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/LoadingControl.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterOperacionConsulta.css" />

    <script src="../../Library/scripts/TextBox.js" type="text/javascript"></script>
    <script src="../../Library/scripts/Procesando.js" type="text/javascript"></script>

    <!-- MIMIC INTERNET EXPLORER -->
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8, EmulateIE9" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" clientidmode="Static" />
    <input type="hidden" id="codUsuarioOculto" runat="server" clientidmode="Static" />
    <input type="hidden" id="pantallaIdOculto" runat="server" clientidmode="Static"/>
    <input type="hidden" id="pantallaTituloOculto" runat="server" clientidmode="Static"/>
    <input type="hidden" id="pantallaModuloOculto" runat="server" clientidmode="Static"/>
    <input type="hidden" id="pantallaNombreOculto" runat="server" clientidmode="Static"/>
    
    <div id="body" class="body">
        <asp:UpdatePanel ID="UpdatePanelControles" runat="server">
            <ContentTemplate>
                <%--VALORES OCULTOS--%>
                <input type="hidden" id="hdnValorConsulta" runat="server" clientidmode="Static"/>
                <input type="hidden" id="hdnResultadoRUC" runat="server" clientidmode="Static"/>
                <input type="hidden" id="hdnResultadoSICC" runat="server" clientidmode="Static"/>
                <input type="hidden" id="idOperacionOculto" runat="server" clientidmode="Static"/>

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
                    <asp:Table ID="tableData" runat="server" EnableViewState="true">
                        <asp:TableRow>
                            <asp:TableCell>
                                <table id="tblParametros" style="width:100%;">
                                    <tr>
                                        <td>
                                            <uc6:ConsultaSICC ID="ParametrosSICC" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblClientes" style="width:100%;">
                                    <tr>
                                        <td>
                                            <uc7:ConsultaClienteSICC ID="ClientesSICC" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                <table id="tblGarantiaGrid" style="width:100%;">
                                    <tr>
                                        <td>
                                            <uc8:ConsultaGridGarantia ID="GridGarantias" runat="server"/>
                                        </td>
                                    </tr>
                                </table>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br /><br />
        <asp:UpdatePanelAnimationExtender ID="upae" BehaviorID="animation" runat="server" TargetControlID="UpdatePanelControles" Enabled="True">
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
            <uc9:BCRClientes ID="BCRClientes" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalBusqueda" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeBusqueda" runat="server"
                PopupControlID="popupBusqueda" 
                TargetControlID="lkbModalBusqueda" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupFiduciaria" style="display: none; background-color: #FFFFFF; height: 387px; width: 840px; border-width: 3px;
            border-color: Black; border-style: solid;">
            <asp:UpdatePanel ID="updFiduciariaPopUp" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <uc10:GarantiaFiduciaria ID="GarantiaFiduciaria" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:LinkButton runat="server" ID="lkbModalFiduciaria" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeFiduciaria" runat="server"
                PopupControlID="popupFiduciaria" 
                TargetControlID="lkbModalFiduciaria" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>
        <asp:Panel runat="server" ID="popupValores" style="display: none; background-color: #FFFFFF; height: 495px; width: 840px; border-width: 3px;
            border-color: Black; border-style: solid; z-index: 1000;">
            <asp:UpdatePanel ID="updValoresPopUp" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <uc12:GarantiaValores ID="GarantiaValores" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:LinkButton runat="server" ID="lkbModalValores" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeValores" runat="server"
                PopupControlID="popupValores" 
                TargetControlID="lkbModalValores" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>
        <asp:Panel runat="server" ID="popupReales" style="display: none; background-color: #FFFFFF; height: 558px; width: 840px; border-width: 3px;
            border-color: Black; border-style: solid;">
            <asp:UpdatePanel ID="updRealesPopUp" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <uc13:GarantiaReales ID="GarantiaReales" runat="server" />
                    </ContentTemplate>
            </asp:UpdatePanel>
            <asp:LinkButton runat="server" ID="lkbModalReales" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeReales" runat="server"
                PopupControlID="popupReales" 
                TargetControlID="lkbModalReales" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>
        </asp:Panel>

        <%--Req F2S03 2016-21-06 G.Avales--%>
        <asp:Panel runat="server" ID="popupAvales" style="display: none; background-color: #FFFFFF; height: 387px; width: 840px; border-width: 3px;
            border-color: Black; border-style: solid;">
            <asp:UpdatePanel ID="updAvalesPopUp" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <uc14:GarantiaAvales ID="GarantiaAvales" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:LinkButton runat="server" ID="lkbModalAvales" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeAvales" runat="server"
                PopupControlID="popupAvales" 
                TargetControlID="lkbModalAvales" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>
        <asp:Panel runat="server" ID="popupRelacionGarantiaFideicomiso" style="display: none; background-color: #FFFFFF; height: 348x; width: 835px; border-width: 3px;
            border-color: Black; border-style: solid;">
            <asp:UpdatePanel ID="updRelacionGarantiaFideicomiso" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <uc26:RelacionGarantiaFideicomiso ID="RelacionGarantiaFideicomiso" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:LinkButton runat="server" ID="lkbModalRelacionGarantiaFideicomiso" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeRelacionGarantiaFideicomiso" runat="server"
                PopupControlID="popupRelacionGarantiaFideicomiso" 
                TargetControlID="lkbModalRelacionGarantiaFideicomiso" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>
        </asp:Panel>
    </div>
</asp:Content>