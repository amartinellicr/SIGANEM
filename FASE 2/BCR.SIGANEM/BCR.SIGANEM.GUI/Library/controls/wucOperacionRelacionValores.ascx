<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucOperacionRelacionValores.ascx.cs" Inherits="wucOperacionRelacionValores" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformar" TagPrefix="uc4" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterOperacionRelaciones.css" />

<asp:Panel ID="pnlOperacionesValores" runat="server" Width="100%" ClientIDMode="Static">
    <div class="divPrincipalTituloRelacion">
        <table style="padding-left: 5px; padding-top: 3px;">
            <tr>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Text="Relación a Garantía Valor" CssClass="tituloRelacion"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="divPrincipalSuperiorValores">
        <asp:Panel ID="panelOperacionesValores" runat="server" CssClass="panelPrincipalRelacion">
            <asp:UpdatePanel ID="updValoresPopUpControl" runat="server" UpdateMode="Conditional"
                ChildrenAsTriggers="false">
                <ContentTemplate>
                    <%--VALORES SESION--%>
                    <input type="hidden" id="valorSesionOculto" runat="server" />
                    <input type="hidden" id="tipoAccionOculto" runat="server" />
                    <input type="hidden" id="idGarantiaValorOculto" runat="server" />
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
                            <td colspan="2" class="tdLineSeparatorRelacion"></td>
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
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoValor" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoValor" runat="server" CssClass="mainTableBoxesCss"
                                    Width="200px" TabIndex="0" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoInstrumento" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlIdTipoInstrumento" runat="server" CssClass="mainTableBoxesCss"
                                    TabIndex="1" Width="650px" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdInstrumento" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlIdInstrumento" runat="server" CssClass="mainTableBoxesCss"
                                    TabIndex="2" Width="650px" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdEmisor" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlIdEmisor" runat="server" CssClass="mainTableBoxesCss" TabIndex="3"
                                    Width="650px" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdISIN" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdISIN" runat="server" CssClass="mainTableBoxesCss" Width="200px"
                                    TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdSerie" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdSerie" runat="server" CssClass="mainTableBoxesCss" Width="175px"
                                    TabIndex="5" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblCodGarantiaBCR" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCodGarantiaBCR" runat="server" CssClass="mainTableBoxesCss" Style="text-transform: uppercase"
                                    TabIndex="6" MaxLength="12"></asp:TextBox>
                                <asp:MaskedEditExtender ID="mskCodGarantiaBCR" runat="server" TargetControlID="txtCodGarantiaBCR"
                                    Mask="????????????" MaskType="None" />
                                <asp:RequiredFieldValidator ID="rfvCodGarantiaBCR" runat="server" ControlToValidate="txtCodGarantiaBCR"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresGeneral" />
                            </td>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" style="width: 100%;" align="right" valign="middle">
                                <asp:Button ID="btnConsultarGarantia" runat="server" Text="Consultar" ToolTip="Consultar Garantía"
                                    CssClass="botonConsultarRelacion" TabIndex="7" ValidationGroup="ValidacionValoresGeneral"
                                    OnClick="btnConsultarGarantia_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                    </table>
                    <table id="tableTituloDetalle" style="width: 100%; text-align: left;">
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblDetalle" runat="server" Text="Detalle" CssClass="labelSubRelacion"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table id="tableDetalle" style="width: 100%; text-align: left;">
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblTipoMonedaFacial" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTipoMonedaFacial" CssClass="mainTableBoxesCss" runat="server"
                                    Width="198px"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>  
                               <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoValorFacial" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoValorFacial" CssClass="mainTableBoxesCss" runat="server"
                                    Width="198px"></asp:TextBox>
                            </td>             
                           
                           
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                    </table>
                    <table id="tableTituloAdicionales" runat="server" style="width: 100%; text-align: left;">
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td style="text-align: left">
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
                                <asp:Label ID="lblIdClaseGarantiaPrt17" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdClaseGarantiaPrt17" runat="server" CssClass="mainTableBoxesCss"
                                    Width="200px" TabIndex="8" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>                        
                        <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoMitigadorRiesgo" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoMitigadorRiesgo" runat="server" CssClass="mainTableBoxesCss"
                                    Width="200px" TabIndex="11" />
                            </td>                          
                        </tr>
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
                                    Width="200px" TabIndex="10" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>

                              <%--CAMPO NUEVO 3--%>
                             <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoDocumentoLegal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoDocumentoLegal" runat="server" CssClass="mainTableBoxesCss"
                                    TabIndex="13" Width="200px" />
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
                                    TabIndex="12" Width="198px"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="wmMontoGradoGravamenValores" runat="server" TargetControlID="txtMontoGradoGravamen"
                                    WatermarkText=" " />
                                <asp:MaskedEditExtender ID="mskMontoGradoGravamenValores" runat="server" TargetControlID="txtMontoGradoGravamen"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                                <%--<asp:RequiredFieldValidator ID="rfvMontoGradoGravamen" runat="server" ControlToValidate="txtMontoGradoGravamen"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresAdicional" />--%>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                                     <%--CAMPO NUEVO 4--%>
                           <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoMitigador" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoMitigador" CssClass="mainTableBoxesCss" runat="server" Width="198px"
                                    TabIndex="15"></asp:TextBox>
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
                                <asp:Label ID="lblIdGradoGravamen" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdGradoGravamen" runat="server" CssClass="mainTableBoxesCss"
                                    TabIndex="14" Width="200px" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                              <%--CAMPO NUEVO 5--%>
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
                                <asp:Label ID="lblFechaConstitucionGarantia" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaConstitucionGarantia" CssClass="mainTableBoxesCss" runat="server"
                                    Width="105px" TabIndex="16" MaxLength="10"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaConstitucionGarantia" runat="server" ImageAlign="AbsMiddle"
                                    CausesValidation="false" />
                                <asp:CalendarExtender ID="caeFechaConstitucionGarantia" runat="server" PopupButtonID="ceFechaConstitucionGarantia"
                                    PopupPosition="Left" TargetControlID="txtFechaConstitucionGarantia">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFechaConstitucionGarantia" runat="server" ControlToValidate="txtFechaConstitucionGarantia"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresAdicional"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeAceptBCR" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptBCR" CssClass="mainTableBoxesCss" runat="server"
                                    Width="55px" TabIndex="17"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="wmPorcentajeAceptBCR" runat="server" TargetControlID="txtPorcentajeAceptBCR"
                                    WatermarkText=" " />
                                <asp:MaskedEditExtender ID="mskPorcentajeAceptBCR" runat="server" TargetControlID="txtPorcentajeAceptBCR"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true">
                                </asp:MaskedEditExtender>
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
                            <td>
                                <asp:TextBox ID="txtFechaVencimientoGarantia" CssClass="mainTableBoxesCss" runat="server"
                                    Width="105px" TabIndex="18" MaxLength="10"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaVencimientoGarantia" runat="server" ImageAlign="AbsMiddle"
                                    CausesValidation="false" />
                                <asp:CalendarExtender ID="caeFechaVencimientoGarantia" runat="server" PopupButtonID="ceFechaVencimientoGarantia"
                                    PopupPosition="Left" TargetControlID="txtFechaVencimientoGarantia">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFechaVencimientoGarantia" runat="server" ControlToValidate="txtFechaVencimientoGarantia"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresAdicional"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeAceptSugef" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptSugef" CssClass="mainTableBoxesCss" runat="server"
                                    Width="55px" TabIndex="19"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="wmPorcentajeAceptSugef" runat="server" TargetControlID="txtPorcentajeAceptSugef"
                                    WatermarkText=" " />
                                <asp:MaskedEditExtender ID="mskPorcentajeAceptSugef" runat="server" TargetControlID="txtPorcentajeAceptSugef"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true">
                                </asp:MaskedEditExtender>
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
                            <td>
                                <asp:TextBox ID="txtFechaPrescripcionGarantia" CssClass="mainTableBoxesCss" runat="server"
                                    Width="105px" TabIndex="20" MaxLength="10"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaPrescripcionGarantia" runat="server" ImageAlign="AbsMiddle"
                                    CausesValidation="false" />
                                <asp:CalendarExtender ID="caeFechaPrescripcionGarantia" runat="server" PopupButtonID="ceFechaPrescripcionGarantia"
                                    PopupPosition="Left" TargetControlID="txtFechaPrescripcionGarantia">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFechaPrescripcionGarantia" runat="server" ControlToValidate="txtFechaPrescripcionGarantia"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresAdicional"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeResponSugef" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeResponSugef" CssClass="mainTableBoxesCss" runat="server"
                                    Width="55px" TabIndex="21"></asp:TextBox>
                               <%-- <asp:TextBoxWatermarkExtender ID="wmPorcentajeResponSugef" runat="server" TargetControlID="txtPorcentajeResponSugef"
                                    WatermarkText=" " />--%>
                                <asp:MaskedEditExtender ID="mskPorcentajeResponSugef" runat="server" TargetControlID="txtPorcentajeResponSugef"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true">
                                </asp:MaskedEditExtender>
                            </td>
                        </tr>

                                <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                           <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTenenciaPrt15" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTenenciaPrt15" runat="server" CssClass="mainTableBoxesCss"
                                    Width="200px" TabIndex="9" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                         
                        </tr>

                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnAceptarValores" />
                    <asp:PostBackTrigger ControlID="btnCancelarValores" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    <div class="divPrincipalInferiorRelacion">
        <table width="100%" style="padding-top: 5px; padding-right: 5px; height: 100%;">
            <tr>
                <td style="width: 100%">
                    <asp:Button ID="btnAceptarValores" runat="server" Text="Guardar y Cerrar" CssClass="botonAceptarRelacion"
                        TabIndex="22" ValidationGroup="ValidacionValoresAdicional" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancelarValores" runat="server" Text="Cancelar y Cerrar" CssClass="botonCancelarRelacion"
                        TabIndex="23" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
<asp:Panel runat="server" ID="popupInformar" Style="display: none; background-color: #FFFFFF; z-index: 12001;">
    <asp:UpdatePanel ID="updValoresPopUp" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <uc4:MensajeInformar ID="InformarBox1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" Style="visibility: hidden;" />
    <asp:ModalPopupExtender ID="mpeInformarBox" runat="server" PopupControlID="popupInformar"
        TargetControlID="lkbModalInfo" BackgroundCssClass="modalBackground" DropShadow="false" X="285" Y="275"
        RepositionMode="RepositionOnWindowResizeAndScroll" />
</asp:Panel>
