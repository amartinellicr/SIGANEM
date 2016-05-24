<%@ control language="C#" autoeventwireup="true" inherits="wucOperacionClientes, App_Web_uwnnvwvb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterOperacionConsulta.css" />
--%>
<asp:UpdatePanel id="upPrincipal" runat="server" >
    <ContentTemplate>
        <asp:Panel id="pnlControlesConsultaOperacion" runat="server" class="mainPanel">
            <div class="divConsultaSICC">
                <table id="Table1" class="masterGridTable" runat="server" style="width: 97%; margin-left: 15px; text-align:left;">
                    <tr style="height: 8px;">
                        <td class="tdLineSeparator"></td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tableSICC" runat="server" style="width: 100%;">
                                <tr>
                                    <td colspan="6" style="text-align:left">
                                        <asp:Label ID="lblDetalleSICC" runat="server" Text="Detalle" CssClass="labelSub" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td colspan="5" style="text-align:left">
                                        <asp:Label ID="lblSubtituloSICC" runat="server" Text="SICC" CssClass="labelSub2" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblOficinaDeudorSICC"  CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOficinaDeudorSICC" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblFechaConstitucionSICC" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td style="width: 125px">
                                        <asp:TextBox ID="txtFechaConstitucionSICC" CssClass="mainTableBoxesCss" runat="server" Width="80px" Enabled="false" MaxLength="10"></asp:TextBox>
                                        <asp:ImageButton ID="imgFechaConstitucionSICC" runat="server" ImageUrl="~/Library/img/32/iconCalendario_dis.gif" ImageAlign="AbsMiddle" CausesValidation="false" Enabled="false"/>
                                        <asp:CalendarExtender ID="caeFechaConstitucionSICC" runat="server" PopupButtonID="ceFechaConstitucionSICC" PopupPosition="Left" TargetControlID="txtFechaConstitucionSICC"></asp:CalendarExtender> 
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblEstadoOperacion" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td style="width: 125px">
                                        <asp:TextBox ID="txtEstadoOperacion" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblFechaVencimientoSICC" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td style="width: 125px">
                                        <asp:TextBox ID="txtFechaVencimientoSICC" CssClass="mainTableBoxesCss" runat="server" Width="80px" Enabled="false" MaxLength="10"></asp:TextBox>
                                        <asp:ImageButton ID="imgFechaVencimientoSICC" runat="server" ImageUrl="~/Library/img/32/iconCalendario_dis.gif" ImageAlign="AbsMiddle" CausesValidation="false" Enabled="false"/>
                                        <asp:CalendarExtender ID="caeFechaVencimientoSICC" runat="server" PopupButtonID="ceFechaVencimientoSICC" PopupPosition="Left" TargetControlID="txtFechaVencimientoSICC"></asp:CalendarExtender> 
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblIdentificacionSICC" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtIdentificacionSICC" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblTipoIdentificacionSICC" CssClass="mainTableBoxesCss" runat="server" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoIdentificacionSICC" runat="server"  CssClass="mainTableBoxesCss" Width="205px" Enabled="false" Visible="false"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblNombreClienteSICC" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td  colspan="3">
                                        <asp:TextBox ID="txtNombreClienteSICC" CssClass="mainTableBoxesCss" runat="server" Width="99.5%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblIndDesembolso" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlIndDesembolso" runat="server"  CssClass="mainTableBoxesCss" Enabled="false"/>
                                    </td>
                                    <td class="tdColumnLabel1">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblSaldo" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSaldo" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblSaldoColonizado" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSaldoColonizado" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblSaldoOriginal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSaldoOriginal" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblSaldoOriginalColonizado" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSaldoOriginalColonizado" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="height: 8px;">
                                    <td colspan="6" class="tdLineSeparator"></td>
                                </tr>
                            </table>
                            <table id="tableRUC" runat="server" style="width: 100%;">
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td colspan="5" style="text-align:left">
                                        <asp:Label ID="lblSubtituloRUC" runat="server" Text="RUC" CssClass="labelSub2" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblTipoIdentificacionRUC" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoIdentificacionRUC" runat="server"  CssClass="mainTableBoxesCss" Width="205px" Enabled="false"/>
                                    </td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblIdentificacionRUC" CssClass="mainTableBoxesCss" runat="server"></asp:Label></td>
                                    <td style="width: 125px">
                                        <asp:TextBox ID="txtIdentificacionRUC" runat="server" CssClass="mainTableBoxesCss" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdSeparatorSmall"></td>
                                    <td class="tdColumnLabel1">
                                        <asp:Label ID="lblCategoriaRiesgoDeudor" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCategoriaRiesgoDeudor" runat="server" CssClass="mainTableBoxesCss"></asp:TextBox>
                                    </td>
                                    <td class="tdColumnLabel1">
                                        &nbsp;</td>
                                    <td style="width: 125px">
                                        &nbsp;</td>
                                </tr>
                                <tr style="height: 8px;">
                                    <td colspan="6" class="tdLineSeparator"></td>
                                </tr>
                                <tr>
                                    <td colspan="6" style="width: 100%;" align="right" valign="middle">
                                        <asp:Button ID="btnValidarOperacion" runat="server" Text="Validar" ToolTip="Validar Sección Detalle" CssClass="botonValidarOperacion" TabIndex="7" ValidationGroup="ConsultaOperacion"/>&nbsp;
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