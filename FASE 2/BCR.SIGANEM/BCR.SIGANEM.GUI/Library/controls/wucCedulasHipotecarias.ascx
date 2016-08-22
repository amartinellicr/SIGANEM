<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucCedulasHipotecarias.ascx.cs" Inherits="wucCedulasHipotecarias" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css" />
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterEmergente.css" />
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterSubMain.css" />

<asp:UpdatePanel id="upPrincipal" runat="server">
    <ContentTemplate>
        <asp:Panel id="pnlControlesCedulasHipotecarias" runat="server" class="mainPanel" width="100%">
            <div class="divPrincipalTitulo">
                <table style="padding-left: 5px; padding-top: 3px;">
                    <tr>
                        <td>
                            <asp:Label ID="lblTitulo" runat="server" Text="Administración de Cédulas Hipotecarias" CssClass="titulo"></asp:Label>
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
                                    <table class="masterGridTable" style="width: 95%; margin-left: 15px; text-align:left;">
                                        <tr>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblCedulasHipotecariasSerie" Text="Serie" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 70%">
                                                <asp:TextBox ID="txtCedulasHipotecariasSerie" CssClass="mainTableBoxesCss" MaxLength="6" TabIndex="1" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvCedulasHipotecariasSerie" runat="server" ControlToValidate="txtCedulasHipotecariasSerie"
                                                ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="CedulasHipotecarias" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblCedulasHipotecariasCedula" Text="Número Cédula" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 70%">
                                                <asp:TextBox ID="txtCedulasHipotecariasCedula" CssClass="mainTableBoxesCss" TabIndex="2" runat="server"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="mskCedulasHipotecariasCedula" runat="server" InputDirection="RightToLeft" TargetControlID="txtCedulasHipotecariasCedula"
                                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="999" ></asp:MaskedEditExtender>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvCedulasHipotecariasCedula" runat="server" ControlToValidate="txtCedulasHipotecariasCedula"
                                                ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="CedulasHipotecarias" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblCedulasHipotecariasGradoGravamen" Text="Grado Gravamen" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 70%">
                                                <asp:DropDownList ID="ddlCedulasHipotecariasGradoGravamen" CssClass="mainTableBoxesCss" TabIndex="3" Width="100%" runat="server"></asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblCedulasHipotecariasFechaVencimiento" Text="Fecha Vencimiento" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 70%">
                                                <asp:TextBox ID="txtCedulasHipotecariasFechaVencimiento" CssClass="mainTableBoxesCss" Width="105" TabIndex="4" runat="server"></asp:TextBox>                                                
                                                <asp:ImageButton ID="imbCedulasHipotecariasFechaVencimiento" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                                <asp:CalendarExtender ID="calendarExtenderCedulasHipotecariasFechaVencimiento" runat="server" PopupButtonID="imbCedulasHipotecariasFechaVencimiento" PopupPosition="Left" TargetControlID="txtCedulasHipotecariasFechaVencimiento"></asp:CalendarExtender> 
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvCedulasHipotecariasFechaVencimiento" runat="server" ControlToValidate="txtCedulasHipotecariasFechaVencimiento"
                                                ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="CedulasHipotecarias" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblCedulasHipotecariasFechaPrescripcion" Text="Fecha Prescripción Cédula" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 70%">
                                                <asp:TextBox ID="txtCedulasHipotecariasFechaPrescripcion" CssClass="mainTableBoxesCss" TabIndex="6" Enabled="false" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblCedulasHipotecariasMoneda" Text="Moneda" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 70%">
                                                <asp:DropDownList ID="ddlCedulasHipotecariasMoneda" CssClass="mainTableBoxesCss" TabIndex="7" Width="100%" Enabled="false" runat="server"></asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 25%">
                                                <asp:Label ID="lblCedulasHipotecariasValorFacial" Text="Valor Facial" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 70%">
                                                <asp:TextBox ID="txtCedulasHipotecariasValorFacial" CssClass="mainTableBoxesCss" TabIndex="8" runat="server"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="mskCedulasHipotecariasValorFacial" runat="server" InputDirection="RightToLeft" TargetControlID="txtCedulasHipotecariasValorFacial"
                                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99" ></asp:MaskedEditExtender>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvCedulasHipotecariasValorFacial" runat="server" ControlToValidate="txtCedulasHipotecariasValorFacial"
                                                ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="CedulasHipotecarias" Display="Dynamic"></asp:RequiredFieldValidator>
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
                            <asp:Button ID="btnCedulasHipotecariasAceptar" runat="server" Text="Aceptar" CssClass="botonAceptar" TabIndex="9" ValidationGroup="CedulasHipotecarias" />
                            <asp:Button ID="btnCedulasHipotecariasCancelar" runat="server" Text="Cancelar" CssClass="botonCancelar" TabIndex="10" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnCedulasHipotecariasAceptar" />
        <asp:PostBackTrigger ControlID="btnCedulasHipotecariasCancelar" />
    </Triggers>
</asp:UpdatePanel>
