<%@ page title="Reporte" language="C#" masterpagefile="~/Library/styles/MasterPages/Main.Master" autoeventwireup="true" inherits="Reportes, App_Web_jvzvwain" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ MasterType VirtualPath="~/Library/styles/MasterPages/Main.Master"%>

<%@ Reference Control="~/Library/controls/wucMenuSuperior.ascx" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformar" tagprefix="uc1" %>
<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" tagname="VentaBusquedaClaseVehiculo" tagprefix="uc2" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarVentanaBusquedaClaseVehiculo" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MensajePopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/ModalPopUp.css" />

    <script src="../../Library/scripts/TextBox.js" language="javascript" type="text/javascript"></script>
    <script src="../../Library/scripts/Procesando.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<input type="hidden" id="idSesionOculto" runat="server" /> 
    <input type="hidden" id="codUsuarioOculto" runat="server" />
    <input type="hidden" id="pantallaIdOculto" runat="server" />
    <input type="hidden" id="pantallaCodOculto" runat="server" />
    <input type="hidden" id="pantallaTituloOculto" runat="server" />
    <input type="hidden" id="pantallaModuloOculto" runat="server" />
    <input type="hidden" id="pantallaNombreOculto" runat="server" />

    <div id="body" class="body">
        <asp:UpdatePanel ID="UpdatePanelControlesReportes" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="width: 100%; background-color: #E8ECF0">
                    <div style="background-color: #E8ECF0; width: 100%; height: 35px;">
                        <div style="top: 10px; left: 20px; position: relative; float: left">
                            <asp:Label ID="lblTituloPage" runat="server" CssClass="tdUpperTitle"></asp:Label>
                        </div>
                    </div>
                    <div id="divControlesReportes" class="divControles">
                        <div style="left: 3px; bottom: 3px; background-color: white; width: 99.5%; position: relative">
                            <div style="width: 740px; position: relative">
                                <asp:Table runat="server" ID="tableData" EnableViewState="true">
                                </asp:Table>
                                <br/>
                                <div style="text-align: center">
                                    <asp:Button ID="btnGenerar" runat="server" ClientIDMode="Static" Text="Consultar" OnClick="btnGenerar_Click" CssClass="mainTableBoxesCss" />
                                </div>
                                <br/>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnGenerar" />
            </Triggers>
        </asp:UpdatePanel>
        
        <%--MENSAJE INFORMAR GENERAL--%>
        <asp:Panel runat="server" ID="popupInformar" style="display: none; background-color: #FFFFFF;">
        <uc1:MensajeInformar ID="InformarBox1" runat="server" />
        <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" style="visibility: hidden;" />
        <asp:ModalPopupExtender ID="mpeInformarBox" runat="server" 
            PopupControlID="popupInformar" 
            TargetControlID="lkbModalInfo" 
            BackgroundCssClass="modalBackground"
            DropShadow="false"
            RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <%--POPUP BUSQUEDA CLASE VEHICULO--%>
        <asp:Panel runat="server" ID="popupBusquedaClaseVehiculo" style="display: none; background-color: #FFFFFF; height: 306px; width: 550px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc2:VentaBusquedaClaseVehiculo ID="BusquedaClaseVehiculo" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalBusquedaClaseVehiculo" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeBusquedaClaseVehiculo" runat="server"
                PopupControlID="popupBusquedaClaseVehiculo" 
                TargetControlID="lkbModalBusquedaClaseVehiculo" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>
        <%--MENSAJE INFORMAR POPUP BUSQUEDA CLASE VEHICULO--%>
        <asp:Panel runat="server" ID="popupInformarBusquedaClaseVehiculo" style="display: none; background-color: #FFFFFF;">
            <uc3:MensajeInformarVentanaBusquedaClaseVehiculo ID="InformarBoxBusquedaClaseVehiculo" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInformarBusquedaClaseVehiculo" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBoxBusquedaClaseVehiculo" runat="server" 
                PopupControlID="popupInformarBusquedaClaseVehiculo" 
                TargetControlID="lkbModalInformarBusquedaClaseVehiculo" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

