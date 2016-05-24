<%@ control language="C#" autoeventwireup="true" inherits="wucMenuLateralDetalle, App_Web_uwnnvwvb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--
<link rel="Stylesheet" type="text/css" href="../styles/LoadingControl.css" />
<link rel="Stylesheet" type="text/css" href="../styles/MenuLateralDetalle.css" />
<script src="../scripts/Procesando.js" type="text/javascript"></script>
--%>
<div style="width: 183px; height: 100%;">
    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />

    <div class="divArbolMenuLateralDetalle">
        <asp:Panel ID="MenuLateralDetalleArbol" runat="server" ScrollBars="Auto" CssClass="panelMenuLateralDetalleArbol">

        </asp:Panel>
    </div>
    <div class="divAreasMenuLateralDetalle" >
        <asp:UpdatePanel ID="udpAreasBotones" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false" >
            <Triggers>
                <asp:PostBackTrigger ControlID="cmdAreaMenuLateralDetalleBoton" />
            </Triggers>
            <ContentTemplate>
                <asp:Button CssClass="AreasMenuLateralDetalleBotonSeleccionado" ID="cmdAreaMenuLateralDetalleBoton"
                    runat="server" Text="Boton" CausesValidation="false" UseSubmitBehavior="False"  ClientIDMode="Static"/>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
