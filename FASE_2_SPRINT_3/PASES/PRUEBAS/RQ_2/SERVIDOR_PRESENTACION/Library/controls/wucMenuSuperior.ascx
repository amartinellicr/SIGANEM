<%@ control language="C#" autoeventwireup="true" inherits="wucMenuSuperior, App_Web_tk4isljl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformar" tagprefix="ucInfo" %>

<%--
<link rel="Stylesheet" type="text/css" href="../styles/MenuSuperior.css" />
<script src="../scripts/Procesando.js" type="text/javascript"></script>
--%>

<asp:Panel ID="WindowLoader" runat="server" CssClass="panelWindows">
    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />
    <input type="hidden" id="pantallaModuloOculto" runat="server" />
    <input type="hidden" id="pantallaCodOculto" runat="server" />

    <table width="100%" style="border-collapse: collapse;">
        <tr>
            <td>
                <div style="text-align: right; width: 100%; height: 8px;">
                </div>
                <asp:Panel ID="PanelMenu" runat="server">
                    <table runat="server" id="tableIdWindow" style="background-color: #FFFFFF; height: 115px;
                        width: 100%; border-collapse: collapse;">
                        <tr>
                            <td style="vertical-align: top">
                                <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" CssClass="Tab"
                                    Width="100%">
                                    <asp:TabPanel ID="tabDesconectar" runat="server" HeaderText="TabPanel1">
                                        <HeaderTemplate>
                                            <asp:Image ID="imgTabTituloAyuda" runat="server" ImageUrl="~/Library/img/Ribbon/Desconectar_icon.png">
                                            </asp:Image>
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:Panel ID="panelDesconectar" runat="server" Height="85px" Width="100%">
                                                <table class="tableControlContenedor">
                                                    <tr>
                                                        <td style="height: 100%;">
                                                            <table class="tableControlHorizontal">
                                                                <tr>
                                                                    <td>
                                                                        <div id="divDesconectar" runat="server" class="divTabsButtonsPreHoverDesconectar">
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="tdImgControlHorizontal">
                                                                                        <asp:UpdatePanel ID="UpdDesconectar" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:Button ID="cmdDesconectar" runat="server" CssClass="menuSuperiorBotonAyudaRegresar" Text="Desconectar" CausesValidation="false" />
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="cmdDesconectar" />
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
                                                                        <table>
                                                                            <tr>
                                                                                <td class="tdImgControlHorizontal">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
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
                                                            <div id="divInicio" runat="server" class="divTabsButtonsPreHover">
                                                                <table class="tableControl">
                                                                    <tr>
                                                                        <td class="tdImgControl">
                                                                            <asp:UpdatePanel ID="UpdAccionesInicio" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Button ID="cmdAccionesInicio" runat="server" Text="Inicio" OnClick="cmdAccionesInicio_Click" CssClass="menuSuperiorBotonAccionesInicio" CausesValidation="false" ClientIDMode="Static"/>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="cmdAccionesInicio" />
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
                                                            <div id="divNuevo" runat="server" class="divTabsButtonsPreHover">
                                                                <table class="tableControl">
                                                                    <tr>
                                                                        <td class="tdImgControl">
                                                                            <asp:UpdatePanel ID="updAccionesNuevo" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Button CssClass="menuSuperiorBotonAccionesNuevo" ID="cmdAccionesNuevo" runat="server" Text="Nuevo" ClientIDMode="Static"/>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="cmdAccionesNuevo" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                        <td style="height: 100%;">
                                                            <div id="divModificar" runat="server" class="divTabsButtonsPreHover">
                                                                <table class="tableControl">
                                                                    <tr>
                                                                        <td class="tdImgControl">
                                                                            <asp:UpdatePanel ID="updAccionesModificar" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Button CssClass="menuSuperiorBotonAccionesModificar" ID="cmdAccionesModificar" runat="server" Text="Modificar" ClientIDMode="Static"/>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="cmdAccionesModificar" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                            
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                        <td style="height: 100%;">
                                                            <div id="divEliminar" runat="server" class="divTabsButtonsPreHover">
                                                                <table class="tableControl">
                                                                    <tr>
                                                                        <td class="tdImgControl">
                                                                            <asp:UpdatePanel ID="udpAccionesEliminar" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Button CssClass="menuSuperiorBotonAccionesBorrar" ID="cmdAccionesEliminar" runat="server" Text="Eliminar"  ClientIDMode="Static"/>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="cmdAccionesEliminar" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                        <td style="height: 100%;">
                                                            <div id="divActualizar" runat="server" class="divTabsButtonsPreHover">
                                                                <table class="tableControl">
                                                                    <tr>
                                                                        <td class="tdImgControl">
                                                                            <asp:UpdatePanel ID="udpAccionesActualizar" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Button CssClass="menuSuperiorBotonAccionesActualizar" ID="cmdAccionesActualizar" runat="server" Text="Actualizar" ClientIDMode="Static" />
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="cmdAccionesActualizar" />
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
                                                            <table class="tableControlHorizontal">
                                                                <tr>
                                                                    <td>
                                                                        <div id="divExcel" runat="server" class="divTabsButtonsPreHoverHorizontal">
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="tdImgControlHorizontal">
                                                                                        <asp:UpdatePanel ID="UdpAccionesExcel" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:Button ID="cmdAccionesExcel" runat="server" CssClass="menuSuperiorBotonAccionesExcel"
                                                                                                    Text="Exportar" ClientIDMode="Static"/>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="cmdAccionesExcel" />
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
                                                                        <table>
                                                                            <tr>
                                                                                <td class="tdImgControlHorizontal">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td class="tdImgControlHorizontal">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td class="tdSeparador">
                                                            <div class="divSeparador">
                                                            </div>
                                                        </td>
                                                        <td style="height: 100%;" id="tdMasAcciones">
                                                            <div id="divMasAcciones" runat="server" class="divTabsButtonsPreHover">
                                                                <table class="tableControl">
                                                                    <tr>
                                                                        <td class="tdImgControl">
                                                                            <asp:UpdatePanel ID="udpAccionesMas" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Button ID="cmdAccionesMas" runat="server" CssClass="menuSuperiorBotonAccionesAcciones" Text="Acciones▼" CausesValidation="False" ClientIDMode="Static" OnClientClick="showPos(event,''); return false" />
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="cmdAccionesMas" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                            <div id='PopUpPosition' style="width: 62px;">
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <div id='PopUp' style='display: none; position: absolute; left: 100px; top: 50px;
                                                                    z-index: 10000; border: solid #C0C0C0 1px; background-color: White; text-align: justify;
                                                                    font-size: 12px; width: 155px; ' onmouseout="">
                                                                    <asp:Panel runat="server" ID="popupMas" CssClass="popUpMasAcciones">
                                                                        <table id="tblMasAcciones" class="popUpMasAccionesTabla" runat="server" >
                                                                            <tr id="trCopiarRol" runat="server">
                                                                                <td runat="server">
                                                                                    <div id="divCopiarRol" runat="server" class="divTabsButtonsPreHoverHorizontalMasAcciones">
                                                                                        <asp:UpdatePanel ID="udpCopiarRol" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:Button ID="cmdCopiarRol" runat="server" CssClass="menuSuperiorBotonAccionesCopiarRol" Text="Copiar Rol" />
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="cmdCopiarRol" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                                <tr id="trDescargaArchivo" style="Display:none" runat="server">
                                                                                <td runat="server">
                                                                                    <div id="div1" runat="server" class="divTabsButtonsPreHoverHorizontalMasAcciones">
                                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:Button ID="btnDescargaArchivo" runat="server" CssClass="menuSuperiorBotonAccionesDescargaArchivo" Text="Descarga de Archivos"/>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="btnDescargaArchivo" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trConsultarIPC" runat="server">
                                                                                <td runat="server">
                                                                                    <div id="divConsultarIPC" runat="server" class="divTabsButtonsPreHoverHorizontalMasAcciones">
                                                                                        <asp:UpdatePanel ID="udpConsultarIPC" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:Button ID="cmdConsultarIPC" runat="server" CssClass="menuSuperiorBotonAccionesConsultarIPC" OnClick="cmdConsultarIPC_Click" Text="Verificar IPC" CausesValidation="false" />
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="cmdConsultarIPC" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trEjecutarIPC" runat="server">
                                                                                <td runat="server">
                                                                                    <div id="divEjecutarIPC" runat="server" class="divTabsButtonsPreHoverHorizontalMasAcciones">
                                                                                        <asp:UpdatePanel ID="udpEjecutarIPC" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:Button ID="cmdEjecutarIPC" runat="server" CssClass="menuSuperiorBotonAccionesEjecutarIPC" OnClick="cmdEjecutarIPC_Click" Text="Ejecutar IPC" />
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="cmdEjecutarIPC" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trConsultarTC" runat="server">
                                                                                <td runat="server">
                                                                                    <div id="divConsultarTC" runat="server" class="divTabsButtonsPreHoverHorizontalMasAcciones">
                                                                                        <asp:UpdatePanel ID="udpConsultarTC" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:Button ID="cmdConsultarTC" runat="server" CssClass="menuSuperiorBotonAccionesConsultarTC" OnClick="cmdConsultarTC_Click" Text="Verificar Tipo Cambio" CausesValidation="false" />
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="cmdConsultarTC" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trEjecutarTC" runat="server">
                                                                                <td runat="server">
                                                                                    <div id="divEjecutarTC" runat="server" class="divTabsButtonsPreHoverHorizontalMasAcciones">
                                                                                        <asp:UpdatePanel ID="udpEjecutarTC" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:Button ID="cmdEjecutarTC" runat="server" CssClass="menuSuperiorBotonAccionesEjecutarTC" OnClick="cmdEjecutarTC_Click" Text="Ejecutar Tipo Cambio" />
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="cmdEjecutarTC" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td class="tdSeparador">
                                                            <div class="divSeparador">
                                                            </div>
                                                        </td>
                                                        <td style="height: 100%;">
                                                            <div id="divReportes" runat="server" class="divTabsButtonsPreHover">
                                                                <table class="tableControl">
                                                                    <tr>
                                                                        <td class="tdImgControl">
                                                                            <asp:UpdatePanel ID="udpAccionesNuevo" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Button CssClass="menuSuperiorBotonAccionesReportes" ID="cmdAccionesReportes" runat="server" Text="Reportes▼"  ClientIDMode="Static"/>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="cmdAccionesReportes" />
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
                                                            <div id="divGuardarNuevo" runat="server">
                                                                <table class="tableControl">
                                                                    <tr>
                                                                        <td class="tdImgControl">
                                                                            <asp:UpdatePanel ID="udpGuardarNuevo" runat="server" UpdateMode="Conditional">
                                                                                <ContentTemplate>
                                                                                    <asp:Button CssClass="menuSuperiorBotonAccionesGuardarNuevo" ID="cmdAccionesGuardarNuevo" Text="Guardar y Nuevo" runat="server" ClientIDMode="Static"/>
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
                                                        <td class="tdSeparador">
                                                            <div class="divSeparador" style="visibility:hidden">
                                                            </div>
                                                        </td>
                                                        <td style="height: 100%;">
                                                            <table class="tableControlHorizontal">
                                                                <tr>
                                                                    <td>
                                                                        <div id="divNuevoId" runat="server">
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="tdImgControlHorizontal">
                                                                                        <asp:UpdatePanel ID="updNuevoId" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:Button ID="cmdAccionesNuevoId" runat="server" CssClass="menuSuperiorBotonAccionesNuevoId" Text="Nuevo Id" ClientIDMode="Static"/>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="cmdAccionesNuevoId" />
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
                                                                        <table>
                                                                            <tr>
                                                                                <td class="tdImgControlHorizontal">
                                                                                    <asp:UpdatePanel ID="updOperacionId" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:Button ID="btnAccionesOperacionId" runat="server" CssClass="menuSuperiorBotonAccionesNuevoId" Text="Operacion Id" ClientIDMode="Static"/>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="btnAccionesOperacionId" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td class="tdImgControlHorizontal">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
</asp:Panel>

<asp:Panel runat="server" ID="popupInformarRibbon" style="display: none; background-color: #FFFFFF;">
    <ucInfo:MensajeInformar ID="InformarBox1" runat="server" />
    <asp:LinkButton runat="server" ID="lkbModalInfoRibbon" CssClass="modalPopup" style="visibility: hidden;" />
    <asp:ModalPopupExtender ID="mpeInformarBoxRibbon" runat="server"
        PopupControlID="popupInformarRibbon" 
        TargetControlID="lkbModalInfoRibbon" 
        BackgroundCssClass="modalBackground"
        DropShadow="false"
        RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
</asp:Panel>
