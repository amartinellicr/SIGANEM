<%@ control language="C#" autoeventwireup="true" inherits="GarantiasFideicomisoPrioridades, App_Web_tk4isljl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarPrioridad" tagprefix="ucg1" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css" />
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterEmergente.css" />
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterSubMain.css" />

<asp:UpdatePanel id="upPrincipalPrioridad" runat="server">
    <ContentTemplate>
        <asp:Panel id="pnlControlesPrioridad" runat="server" class="mainPanel" width="100%">
            <div class="divPrincipalTitulo">
                <table style="padding-left: 5px; padding-top: 3px;">
                    <tr>
                        <td>
                            <asp:Label ID="lblTitulo" runat="server" Text="Administración de Prioridades" CssClass="titulo"></asp:Label>
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

                                    <input type="hidden" id="hdnIdPrioridadesOculto" runat="server" clientidmode="Static" />
                                    
                                    <table class="masterGridTable" style="width: 95%; margin-left: 15px; text-align:left;">
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblGradoPrioridad" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddlGradoPrioridad" CssClass="mainTableBoxesCss" TabIndex="1" Width="55%" runat="server"></asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblTipoMonedaSaldoPrioridad" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddlTipoMonedaSaldoPrioridad" CssClass="mainTableBoxesCss" TabIndex="2" Width="55%" runat="server" AutoPostBack="true" onselectedindexchanged="ddlTipoMonedaSaldoPrioridad_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblSaldoPrioridad" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtSaldoPrioridad" CssClass="mainTableBoxesCss" Width="55%" AutoPostBack="true" TabIndex="3" runat="server" ontextchanged="txtSaldoPrioridad_TextChanged"></asp:TextBox>

                                                <asp:TextBoxWatermarkExtender ID="wmSaldoPrioridad" runat="server" TargetControlID="txtSaldoPrioridad" WatermarkText=" " />
                                
                                                <asp:MaskedEditExtender ID="mskSaldoPrioridad" runat="server" TargetControlID="txtSaldoPrioridad" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                                               
                                                <asp:RequiredFieldValidator ID="rfvSaldoPrioridad" runat="server" ControlToValidate="txtSaldoPrioridad" Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresGeneral" />
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblTipoPersonaBeneficiario" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddlTipoPersonaBeneficiario" CssClass="mainTableBoxesCss" TabIndex="4" Width="55%" runat="server" onselectedindexchanged="ddlTipoPersonaBeneficiario_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblIdBeneficiario" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtIdBeneficiario" CssClass="mainTableBoxesCss" Width="55%" TabIndex="5" runat="server"></asp:TextBox>
                                                
                                                <asp:RequiredFieldValidator ID="rfvIdBeneficiario" runat="server" ControlToValidate="txtIdBeneficiario" Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresGeneral" />
                                  
                                                <asp:MaskedEditExtender ID="mskIdBeneficiario" runat="server" InputDirection="RightToLeft" TargetControlID="txtIdBeneficiario" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="false" ></asp:MaskedEditExtender>                                              
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblNombreBeneficiario" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtNombreBeneficiario" CssClass="mainTableBoxesCss" Width="55%" TabIndex="6" runat="server" AutoPostBack="true" ontextchanged="txtNombreBeneficiario_TextChanged" MaxLength="100"></asp:TextBox>
                                                
                                                <asp:RequiredFieldValidator ID="rfvNombreBeneficiario" runat="server" ControlToValidate="txtNombreBeneficiario" Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresGeneral" />
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblTipoCambio" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtTipoCambio" CssClass="mainTableBoxesCss" Width="55%" TabIndex="7" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblSaldoColonizado" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtSaldoColonizado" CssClass="mainTableBoxesCss" Width="55%" TabIndex="8" runat="server"></asp:TextBox>

                                                <asp:TextBoxWatermarkExtender ID="wmSaldoColonizado" runat="server" TargetControlID="txtSaldoColonizado" WatermarkText=" " />
                                
                                                <asp:MaskedEditExtender ID="mskSaldoColonizado" runat="server" TargetControlID="txtSaldoColonizado" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
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
                            <asp:Button ID="btnPrioridadAceptar" runat="server" Text="Aceptar" CssClass="botonAceptar" TabIndex="9" ValidationGroup="ValidacionValoresGeneral" />
                            <asp:Button ID="btnPrioridadCancelar" runat="server" Text="Cancelar" CssClass="botonCancelar" TabIndex="10" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:Panel runat="server" ID="popupInformarPrioridad" style="display: none; background-color: #FFFFFF;">
    <ucg1:MensajeInformarPrioridad ID="InformarBoxPrioridad1" runat="server" />
    <asp:LinkButton runat="server" ID="lkbModalInfoPrioridad" CssClass="modalPopup" style="visibility: hidden;" />
    <asp:ModalPopupExtender ID="mpeInformarBoxPrioridad" runat="server" 
        PopupControlID="popupInformarPrioridad" 
        TargetControlID="lkbModalInfoPrioridad" 
        BackgroundCssClass="modalBackground"
        DropShadow="false"
        RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
</asp:Panel>