<%@ control language="C#" autoeventwireup="true" inherits="wucGravamenGarantia, App_Web_sxpoynwp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarGravamen" tagprefix="ucg1" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css" />
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterEmergente.css" />
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterSubMain.css" />

<asp:UpdatePanel id="upPrincipalGravamen" runat="server">
    <ContentTemplate>
        <asp:Panel id="pnlControlesGravamenGarantia" runat="server" class="mainPanel" width="100%">
            <div class="divPrincipalTitulo">
                <table style="padding-left: 5px; padding-top: 3px;">
                    <tr>
                        <td>
                            <asp:Label ID="lblTitulo" runat="server" Text="Administración de Gravamenes" CssClass="titulo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:left">
                            <asp:Label ID="lblSubtitulo" runat="server" Text="Complete el formulario" CssClass="subTitulo"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="divPrincipalSuperior">
                <asp:Panel ID="panelGrid" ScrollBars="Auto" runat="server" CssClass="panelPrincipalControles">
                    <table style="width: 100%; border-collapse: collapse; background-color: #E8ECF0">
                        <tr>
                            <td style="width: 100%; height: 100%;">
                                <asp:panel id="pnlContainer" runat="server" style="display: block; height: 100%;">

                                    <input type="hidden" id="hdnGravamenGarantiaIdGravamenOculto" runat="server" clientidmode="Static" />
                                    
                                    <table class="masterGridTable" style="width: 95%; margin-left: 15px; text-align:left;">
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblGravamenGarantiaGradoGravamen" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">                                                
                                                <asp:DropDownList ID="ddlGravamenGarantiaGradoGravamen" CssClass="mainTableBoxesCss" TabIndex="1" Width="100%" runat="server"></asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblGravamenGarantiaTipoMonedaMontoGravamen" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddlGravamenGarantiaTipoMonedaMontoGravamen" CssClass="mainTableBoxesCss" TabIndex="2" Width="100%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGravamenGarantiaTipoMonedaMontoGravamen_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>                                        
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblGravamenGarantiaSaldoGradoGravamen" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtGravamenGarantiaSaldoGradoGravamen" AutoPostBack="true" OnTextChanged="txtGravamenGarantiaSaldoGradoGravamen_TextChanged" CssClass="mainTableBoxesCss" Width="55%" TabIndex="4" runat="server"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="mskGravamenGarantiaSaldoGradoGravamen" runat="server" InputDirection="RightToLeft" TargetControlID="txtGravamenGarantiaSaldoGradoGravamen"
                                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99" ></asp:MaskedEditExtender>
                                            </td>
                                            <td style="width: 5%">   
                                                <asp:RequiredFieldValidator ID="rfvGravamenGarantiaSaldoGradoGravamen" runat="server" ControlToValidate="txtGravamenGarantiaSaldoGradoGravamen"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="GarantiaEntidadAcreedora" Display="Dynamic"></asp:RequiredFieldValidator>                                             
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblGravamenGarantiaEntidadAcreedora" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtGravamenGarantiaEntidadAcreedora" AutoPostBack="true" OnTextChanged="txtGravamenGarantiaEntidadAcreedora_TextChanged" CssClass="mainTableBoxesCss" Width="99%" TabIndex="5" Enabled="true" MaxLength="75" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvGravamenGarantiaEntidadAcreedora" runat="server" ControlToValidate="txtGravamenGarantiaEntidadAcreedora"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="GarantiaEntidadAcreedora" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblGravamenGarantiaTipoCambio" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtGravamenGarantiaTipoCambio" CssClass="mainTableBoxesCss" TabIndex="6" Enabled="false" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblGravamenGarantiaSaldoColonizado" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtGravamenGarantiaSaldoColonizado" Enabled="false" CssClass="mainTableBoxesCss" Width="55%"  TabIndex="7" runat="server"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="mskGravamenGarantiaSaldoColonizado" runat="server" InputDirection="RightToLeft" TargetControlID="txtGravamenGarantiaSaldoColonizado"
                                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99" ></asp:MaskedEditExtender>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <div class="divPrincipalInferior">
                <table width="100%" style="padding-top: 10px; padding-right: 5px; height:100%;">
                    <tr>
                        <td style="width: 100%">
                            <asp:Button ID="btnGravamenGarantiaAceptar" runat="server" Text="Aceptar" CssClass="botonAceptar" TabIndex="8" ValidationGroup="GarantiaEntidadAcreedora" />
                            <asp:Button ID="btnGravamenGarantiaCancelar" runat="server" Text="Cancelar" CssClass="botonCancelar" TabIndex="9" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <%--<Triggers>
        <asp:PostBackTrigger ControlID="btnGravamenGarantiaAceptar" />
        <asp:PostBackTrigger ControlID="btnGravamenGarantiaCancelar" />
    </Triggers>--%>
</asp:UpdatePanel>

<asp:Panel runat="server" ID="popupInformarGravamen" style="display: none; background-color: #FFFFFF;">
    <ucg1:MensajeInformarGravamen ID="InformarBoxGravamen1" runat="server" />
    <asp:LinkButton runat="server" ID="lkbModalInfoGravamen" CssClass="modalPopup" style="visibility: hidden;" />
    <asp:ModalPopupExtender ID="mpeInformarBoxGravamen" runat="server" 
        PopupControlID="popupInformarGravamen" 
        TargetControlID="lkbModalInfoGravamen" 
        BackgroundCssClass="modalBackground"
        DropShadow="false"
        RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
</asp:Panel>