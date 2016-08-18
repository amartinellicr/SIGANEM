<%@ control language="C#" autoeventwireup="true" inherits="wucOperacionConsulta, App_Web_4ficn4jk" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterOperacionConsulta.css" />
--%>
<asp:UpdatePanel id="upPrincipal" runat="server" >
    <ContentTemplate>
        <asp:Panel id="pnlControlesConsultaOperacion" runat="server" class="mainPanel">
            <div class="divConsultaOperacion">
                <table id="tblParametros" runat="server" style="width: 97%; margin-left: 15px; text-align:left;">
                    <tr style="height: 8px;">
                        <td colspan="2" class="tdLineSeparator"></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:left">
                            <asp:Label ID="lblParametro" runat="server" Text="Operación" CssClass="labelSub" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdSeparatorSmall"></td>
                        <td>
                            <table style="width: 100%;">
                                <tr>
                                    <td rowspan="2" class="tdColumnLabel">
                                        <asp:Label ID="lblTipoOperacion" runat="server" CssClass="blackLabel"></asp:Label>
                                    </td>
                                    <td rowspan="2" class="tdColumnDropDown">
                                        <asp:DropDownList ID="ddlTipoOperacion" TabIndex="1" CssClass="mainTableBoxesCss" Width="100%" runat="server"/>
                                    </td> 
                                    <td rowspan="2" class="tdSeparatorCenter"></td>
                                    <td class="tdColumnSeparator">
                                        <asp:Label ID="lblConta" runat="server" CssClass="blackLabel"></asp:Label>
                                    </td>
                                    <td class="tdColumnSeparator">
                                        <asp:Label ID="lblOficina" runat="server" CssClass="blackLabel"></asp:Label>
                                    </td>
                                    <td class="tdColumnSeparator">
                                        <asp:Label ID="lblMoneda" runat="server" CssClass="blackLabel"></asp:Label>
                                    </td>
                                    <td class="tdColumnSeparator">
                                        <asp:Label ID="lblProducto" runat="server" CssClass="blackLabel"></asp:Label>
                                    </td>
                                    <td class="tdColumnSeparator2">
                                        <asp:Label ID="lblNumero" runat="server" CssClass="blackLabel"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdColumnSeparator">
                                        <asp:TextBox ID="txtConta" runat="server" TabIndex="2" Width="20px" CssClass="mainTableBoxesCss" CausesValidation="True" ValidationGroup="GrupoValidacion"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="mskConta" runat="server" TargetControlID="txtConta" Mask="9"></asp:MaskedEditExtender>
                                        <asp:RequiredFieldValidator ID="rfvConta" runat="server" ControlToValidate="txtConta" Display="Dynamic" Text= " * " CssClass= "labelTabError" ValidationGroup="GrupoValidacion"></asp:RequiredFieldValidator>

                                    </td>
                                    <td class="tdColumnSeparator">
                                        <asp:TextBox ID="txtOficina" runat="server" TabIndex="3" Width="27px" CssClass="mainTableBoxesCss" CausesValidation="True" ValidationGroup="GrupoValidacion"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="mskOficina" runat="server" TargetControlID="txtOficina" Mask="9"></asp:MaskedEditExtender>
                                        <asp:RequiredFieldValidator ID="rfvOficina" runat="server" ControlToValidate="txtOficina" Display="Dynamic" Text= " * " CssClass= "labelTabError" ValidationGroup="GrupoValidacion" ></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="tdColumnSeparator">
                                        <asp:TextBox ID="txtMoneda" runat="server" TabIndex="4" Width="20px" CssClass="mainTableBoxesCss" CausesValidation="True" ValidationGroup="GrupoValidacion"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="mskMoneda" runat="server" TargetControlID="txtMoneda" Mask="9" AutoComplete="False"></asp:MaskedEditExtender>
                                        <asp:RequiredFieldValidator ID="rfvMoneda" runat="server" ControlToValidate="txtMoneda" Display="Dynamic" Text= " * " CssClass= "labelTabError" ValidationGroup="GrupoValidacion"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="tdColumnSeparator">
                                        <asp:TextBox ID="txtProducto" runat="server" TabIndex="5" Width="20px" CssClass="mainTableBoxesCss" CausesValidation="True" ValidationGroup="GrupoValidacion"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="mskProducto" runat="server" TargetControlID="txtProducto" Mask="9"></asp:MaskedEditExtender>
                                        <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto" Display="Dynamic" Text= " * " CssClass= "labelTabError" ValidationGroup="GrupoValidacion"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="tdColumnSeparator2">
                                        <asp:TextBox ID="txtNumero" runat="server" TabIndex="6" Width="58px" CssClass="mainTableBoxesCss" CausesValidation="True" ValidationGroup="GrupoValidacion"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="mskNumero" runat="server" TargetControlID="txtNumero" Mask="9"></asp:MaskedEditExtender>
                                        <asp:RequiredFieldValidator ID="rfvNumero" runat="server" ControlToValidate="txtNumero" Display="Dynamic" Text= " * " CssClass= "labelTabError" ValidationGroup="GrupoValidacion"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height: 8px;">
                                    <td colspan="8" class="tdLineSeparator"></td>
                                </tr>
                                <tr>
                                    <td colspan="8" style="width: 100%;"  align="right" valign="middle">
                                        <asp:Button ID="btnConsultarOperacion" runat="server" Text="Consultar Datos" ToolTip="Consulta Sección Operaciones en SICC" CssClass="botonConsultarSICC" TabIndex="7" CausesValidation="true" ValidationGroup="GrupoValidacion"/>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>