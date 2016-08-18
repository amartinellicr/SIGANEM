<%@ control language="C#" autoeventwireup="true" inherits="wucOperacionRelacionFiduciaria, App_Web_sxpoynwp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformar"
    TagPrefix="uc4" %>
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterOperacionRelaciones.css" />
<asp:Panel ID="pnlOperacionesFiduciarias" runat="server" Width="100%" ClientIDMode="Static">
    <div class="divPrincipalTituloRelacion">
        <table style="padding-left: 5px; padding-top: 3px;">
            <tr>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Text="Relación a Garantía Fiduciaria" CssClass="tituloRelacion"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="divPrincipalSuperiorFiduciarias">
        <asp:Panel ID="panelOperacionesFiduciarias" runat="server" CssClass="panelPrincipalRelacion">
            <asp:UpdatePanel ID="updFiduciariaPopUpControl" runat="server" UpdateMode="Conditional"
                ChildrenAsTriggers="false">
                <ContentTemplate>
                    <%--VALORES SESION--%>
                    <input type="hidden" id="valorSesionOculto" runat="server" />
                    <input type="hidden" id="tipoAccionOculto" runat="server" />
                    <input type="hidden" id="idGarantiaFiduciariaOculto" runat="server" />
                    <input type="hidden" id="estadoGarantiaOculto" runat="server" />
                    <table id="tableTituloGeneral" style="width: 100%; text-align: left;">
                        <tr>
                            <td colspan="2" style="height: 28; vertical-align: middle;">
                                <div id="divBarraMensaje" class="divBarraMensaje" runat="server" visible="false">
                                    <asp:Label ID="lblBarraMensaje" runat="server" CssClass="etiquetaBarraMensajeExito" />
                                </div>
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="2" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td>
                                <asp:Label ID="lblSubtituloGeneral" runat="server" Text="General" CssClass="labelSubRelacion"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table id="tableGeneral" runat="server" style="width: 100%; text-align: left;">
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion" style="width: 75px;">
                                <asp:Label ID="lblIdTipoIdentificacionRUC" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td class="tdColumnGeneralCombosRelacion">
                                <asp:DropDownList ID="ddlIdTipoIdentificacionRUC" runat="server" CssClass="mainTableBoxesCss"
                                    Width="90%" TabIndex="0" AutoPostBack="true" OnSelectedIndexChanged="ddlIdTipoIdentificacionRUC_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion" style="width: 75px;">
                                <asp:Label ID="lblIdentificacionRUC" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td class="tdColumnGeneralCombosRelacion">
                                <asp:TextBox ID="txtIdentificacionRUC" CssClass="mainTableBoxesCss" runat="server"
                                    TabIndex="1" />
                                <asp:MaskedEditExtender ID="mskIdentificacionRUC" runat="server" TargetControlID="txtIdentificacionRUC"
                                    Mask="9" />
                                <asp:RequiredFieldValidator ID="rfvIdentificacionRUC" runat="server" ControlToValidate="txtIdentificacionRUC"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionFiduciariaGeneral" />
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="4" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="width: 100%;" align="right" valign="middle">
                                <asp:Button ID="btnConsultarGarantia" runat="server" Text="Consultar" ToolTip="Consultar Garantía"
                                    CssClass="botonConsultarRelacion" TabIndex="2" ValidationGroup="ValidacionFiduciariaGeneral"
                                    OnClick="btnConsultarGarantia_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="4" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                    </table>
                    <table id="tableTituloDetalle" style="width: 100%; text-align: left;">
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td>
                                <asp:Label ID="lblDetalle" runat="server" Text="Detalle" CssClass="labelSubRelacion"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table id="tableDetalle" runat="server" style="width: 100%; text-align: left;">
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion">
                                <asp:Label ID="lblIdentificacionSICC" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIdentificacionSICC" CssClass="mainTableBoxesCss" runat="server"
                                    TabIndex="3"></asp:TextBox>
                            </td>
                            <td class="tdColumnGeneral0Relacion">
                                <asp:Label ID="lblSalarioNetoFiador" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSalarioNetoFiador" CssClass="mainTableBoxesCss" runat="server"
                                    TabIndex="4"></asp:TextBox>
                                <asp:MaskedEditExtender ID="mskSalarioNetoFiador" runat="server" TargetControlID="txtSalarioNetoFiador"
                                    Mask="9">
                                </asp:MaskedEditExtender>
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="6" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                    </table>
                    <table id="tableTituloAdicionales" style="width: 100%; text-align: left;">
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td>
                                <asp:Label ID="lblAdicionales" runat="server" Text="Datos Adicionales" CssClass="labelSubRelacion"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table id="tableAdicionales" runat="server" style="width: 100%; text-align: left;">
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoMonedaGradoGravamen" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoMonedaGradoGravamen" runat="server" CssClass="mainTableBoxesCss"
                                    Width="200px" TabIndex="5" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoDocumentoLegal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoDocumentoLegal" runat="server" CssClass="mainTableBoxesCss"
                                    Width="200px" TabIndex="6" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoGradoGravamen" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoGradoGravamen" CssClass="mainTableBoxesCss" runat="server"
                                    TabIndex="7" Width="198px"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="wmMontoGradoGravamenFiduciarias" runat="server" TargetControlID="txtMontoGradoGravamen"
                                    WatermarkText=" " />
                                <asp:MaskedEditExtender ID="mskMontoGradoGravamen" runat="server" TargetControlID="txtMontoGradoGravamen"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                                 <%--<asp:RequiredFieldValidator ID="rfvMontoGradoGravamen" runat="server" ControlToValidate="txtMontoGradoGravamen"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionFiduciariaAdicional" />--%>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoMitigador" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtMontoMitigador" CssClass="mainTableBoxesCss" runat="server" TabIndex="8"
                                    Width="198px" ClientIDMode="Static"></asp:TextBox>
                               <%-- <asp:TextBoxWatermarkExtender ID="wmMontoMitigador" runat="server" TargetControlID="txtMontoMitigador"
                                    WatermarkText=" " />--%>
                                <asp:MaskedEditExtender ID="mskMontoMitigador" runat="server" TargetControlID="txtMontoMitigador"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblFechaConstitucionGarantia" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaConstitucionGarantia" CssClass="mainTableBoxesCss" runat="server"
                                    Width="105px" TabIndex="9" MaxLength="10"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaConstitucionGarantia" runat="server" ImageAlign="AbsMiddle"
                                    CausesValidation="false" />
                                <asp:CalendarExtender ID="caeFechaConstitucionGarantia" runat="server" PopupButtonID="ceFechaConstitucionGarantia"
                                    PopupPosition="Left" TargetControlID="txtFechaConstitucionGarantia">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtFechaConstitucionGarantia"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionFiduciariaAdicional"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                              <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoMitigadorCalculado" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoMitigadorCalculado" CssClass="mainTableBoxesCss" runat="server"
                                    Width="198px" TabIndex="30"></asp:TextBox>
                                <%--<asp:TextBoxWatermarkExtender ID="wmMontoMitigadorCalculado" runat="server" TargetControlID="txtMontoMitigadorCalculado"
                                    WatermarkText=" " />--%>
                                <asp:MaskedEditExtender ID="mskMontoMitigadorCalculado" runat="server" TargetControlID="txtMontoMitigadorCalculado"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                            </td>                           
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblFechaVencimientoGarantia" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtFechaVencimientoGarantia" CssClass="mainTableBoxesCss" runat="server"
                                    Width="105px" TabIndex="11" MaxLength="10"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaVencimientoGarantia" runat="server" ImageAlign="AbsMiddle"
                                    CausesValidation="false" />
                                <asp:CalendarExtender ID="caeFechaVencimientoGarantia" runat="server" PopupButtonID="ceFechaVencimientoGarantia"
                                    PopupPosition="Left" TargetControlID="txtFechaVencimientoGarantia">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaVencimientoGarantia"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionFiduciariaAdicional"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                             <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeAceptBCR" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptBCR" CssClass="mainTableBoxesCss" runat="server"
                                    Width="55px" TabIndex="10"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="wmPorcentajeAceptBCR" runat="server" TargetControlID="txtPorcentajeAceptBCR"
                                    WatermarkText=" " />
                                <asp:MaskedEditExtender ID="mskPorcentajeAceptBCR" runat="server" TargetControlID="txtPorcentajeAceptBCR"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblFechaPrescripcionGarantia" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtFechaPrescripcionGarantia" CssClass="mainTableBoxesCss" runat="server"
                                    Width="105px" TabIndex="13" MaxLength="10"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaPrescripcionGarantia" runat="server" ImageAlign="AbsMiddle"
                                    CausesValidation="false" />
                                <asp:CalendarExtender ID="caeFechaPrescripcionGarantia" runat="server" PopupButtonID="ceFechaPrescripcionGarantia"
                                    PopupPosition="Left" TargetControlID="txtFechaPrescripcionGarantia">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFechaPrescripcionGarantia" runat="server" ControlToValidate="txtFechaPrescripcionGarantia"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionFiduciariaAdicional"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                             <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeAceptSugef" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptSugef" CssClass="mainTableBoxesCss" runat="server"
                                    Width="55px" TabIndex="12"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="wmPorcentajeAceptSugef" runat="server" TargetControlID="txtPorcentajeAceptSugef"
                                    WatermarkText=" " />
                                <asp:MaskedEditExtender ID="mskPorcentajeAceptSugef" runat="server" TargetControlID="txtPorcentajeAceptSugef"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoMitigadorRiesgo" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoMitigadorRiesgo" runat="server" CssClass="mainTableBoxesCss"
                                    Width="200px" TabIndex="15" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>                     
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeResponSugef" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeResponSugef" CssClass="mainTableBoxesCss" runat="server"
                                    Width="55px" TabIndex="14"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="wmPorcentajeResponSugef" runat="server" TargetControlID="txtPorcentajeResponSugef"
                                    WatermarkText=" " />
                                <asp:MaskedEditExtender ID="mskPorcentajeResponSugef" runat="server" TargetControlID="txtPorcentajeResponSugef"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                            </td>

                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnAceptarFiduciaria" />
                    <asp:PostBackTrigger ControlID="btnCancelarFiduciaria" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    <div class="divPrincipalInferiorRelacion">
        <table width="100%" style="padding-top: 5px; padding-right: 5px; height: 100%;">
            <tr>
                <td style="width: 100%">
                    <asp:Button ID="btnAceptarFiduciaria" runat="server" Text="Guardar y Cerrar" CssClass="botonAceptarRelacion"
                        TabIndex="16" ValidationGroup="ValidacionFiduciariaAdicional" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancelarFiduciaria" runat="server" Text="Cancelar y Cerrar" CssClass="botonCancelarRelacion"
                        TabIndex="17" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>

    <asp:Panel ID="pnlInformarFid" runat="server" Style="display: none; background-color: #FFFFFF; "
        ClientIDMode="Static">
            <uc4:MensajeInformar ID="InformarBox1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBox" runat="server" PopupControlID="pnlInformarFid"
                TargetControlID="lkbModalInfo" BackgroundCssClass="modalBackground" DropShadow="false" X="285" Y="275"
                RepositionMode="RepositionOnWindowResizeAndScroll" />
    </asp:Panel>
