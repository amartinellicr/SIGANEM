<%@ control language="C#" autoeventwireup="true" inherits="wucOperacionRelacionAvales, App_Web_tk4isljl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformar"
    TagPrefix="uc4" %>
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterOperacionRelaciones.css" />
<asp:Panel ID="pnlOperacionesAvales" runat="server" Width="100%" ClientIDMode="Static">
    <div class="divPrincipalTituloRelacion">
        <table style="padding-left: 5px; padding-top: 3px;">
            <tr>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Text="Relación a Garantía Aval" CssClass="tituloRelacion"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="divPrincipalSuperiorAvales">
        <asp:Panel ID="panelOperacionesAvales" runat="server" CssClass="panelPrincipalRelacion">
            <asp:UpdatePanel ID="updAvalesPopUpControl" runat="server" UpdateMode="Conditional"
                ChildrenAsTriggers="false">
                <ContentTemplate>
                    <%--VALORES SESION--%>
                    <input type="hidden" id="valorSesionOculto" runat="server" />
                    <input type="hidden" id="tipoAccionOculto" runat="server" />
                    <input type="hidden" id="idGarantiaAvalesOculto" runat="server" />
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
                            <td class="tdColumnGeneral0Relacion">
                                <asp:Label ID="lblIdTipoAval" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td style="width: 350px;">
                            <asp:DropDownList ID="ddlIdTipoAval" Enabled="true" runat="server" CssClass="mainTableBoxesCss"
                                    TabIndex="1" Width="350px"/>
                            <asp:RequiredFieldValidator ID="rfvIdTipoAval" runat="server" ControlToValidate="ddlIdTipoAval"
                            ErrorMessage=" * " CssClass="labelTabErrorRelacion" Display="Dynamic" ValidationGroup="ValidacionAvalesGeneral"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral1Relacion">
                                <asp:Label ID="lblNAval" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNAval" runat="server" CssClass="mainTableBoxesCss" Style="text-transform: uppercase" AutoPostBack="true"
                                    MaxLength="30" TabIndex="2" ToolTip="Texto N° Aval" Enabled="true" Width="85%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNAval" runat="server" ControlToValidate="txtNAval"
                                    ErrorMessage=" * " CssClass="labelTabErrorRelacion" Display="Dynamic" ValidationGroup="ValidacionAvalesGeneral"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" style="width: 100%;" align="right" valign="middle">
                               <%-- <asp:Button ID="btnConsultarGarantia" runat="server" Text="Consultar" ToolTip="Consultar Garantía"
                                    CssClass="botonConsultarRelacion" TabIndex="13" ValidationGroup="ValidacionRealesGeneral"
                                    CausesValidation="true" />--%>
                                    <asp:Button ID="btnConsultarGarantia" runat="server" Text="Consultar" ToolTip="Consultar Garantía"
                                    CssClass="botonConsultarRelacion" TabIndex="3" ValidationGroup="ValidacionAvalesGeneral"
                                    CausesValidation="true" OnClick="btnConsultarGarantia_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                    </table>

                    <table id="tableTituloDetalle" style="width: 100%; text-align: left;">
                       <%-- <tr style="height: 8px;">
                            <td colspan="2" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>--%>
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
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoIdentificacionAvalista" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIdTipoIdentificacionAvalista" runat="server" CssClass="mainTableBoxesCss"
                                    Width="198px" TabIndex="4" />
                            </td>

                            <td class="tdSeparatorSmallRelacion">
                            </td>

                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoAvalado" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoAvalado" CssClass="mainTableBoxesCss" runat="server"
                                    Width="198px" TabIndex="5"></asp:TextBox>
                                <%--<asp:MaskedEditExtender ID="msktxtMontoAvalado" runat="server" TargetControlID="txtMontoAvalado"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />--%>
                            </td>
                        </tr>                      
                           <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdentificacionAvalista" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                    <asp:TextBox ID="txtIdentificacionAvalista" CssClass="mainTableBoxesCss" runat="server" Width="198px" TabIndex="6"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                           </td>
                            <td>   &nbsp;&nbsp                            
                            </td>
                        </tr>                  
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
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
                                <asp:Label ID="lblIdClaseGarantiaPrt17" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdClaseGarantiaPrt17" runat="server" CssClass="mainTableBoxesCss"
                                    Width="200px" TabIndex="7" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>

                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoMitigadorRiesgo" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoMitigadorRiesgo" runat="server" CssClass="mainTableBoxesCss"
                                    Width="200px" TabIndex="8" />
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
                            <td>
                                <asp:Label ID="lblIdTipoDocumentoLegal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoDocumentoLegal" runat="server" CssClass="mainTableBoxesCss"
                                    TabIndex="10" Width="200px" />
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
                                    TabIndex="11" Width="200px" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>

                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoMitigador" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoMitigador" CssClass="mainTableBoxesCss" runat="server" Width="198px"
                                    TabIndex="12"></asp:TextBox>
                                 <asp:MaskedEditExtender ID="mskMontoMitigador" runat="server" TargetControlID="txtMontoMitigador"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true"
                                    AutoComplete="true" />
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
                                    Width="200px" TabIndex="13" />
                            </td>

                            <td class="tdSeparatorSmallRelacion">
                            </td>

                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoMitigadorCalculado" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoMitigadorCalculado" CssClass="mainTableBoxesCss" runat="server"
                                    Width="198px" TabIndex="14"></asp:TextBox>
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
                                <asp:Label ID="lblMontoGradoGravamen" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoGradoGravamen" CssClass="mainTableBoxesCss" runat="server" Enabled="true"
                                    TabIndex="15" Width="198px"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="wmMontoGradoGravamenAvales" runat="server" TargetControlID="txtMontoGradoGravamen"
                                    WatermarkText=" " />
                                <asp:MaskedEditExtender ID="mskMontoGradoGravamen" runat="server" TargetControlID="txtMontoGradoGravamen"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                                <asp:RequiredFieldValidator ID="rfvMontoGradoGravamen" runat="server" ControlToValidate="txtMontoGradoGravamen"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionAvalesAdicional"></asp:RequiredFieldValidator>
                            </td>

                            <td class="tdSeparatorSmallRelacion">
                            </td>

                            <td>
                                <asp:Label ID="lblPorcentajeAceptBCR" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptBCR" CssClass="mainTableBoxesCss" runat="server" Enabled="true" AutoPostBack = "true"
                                    Width="55px" TabIndex="16" OnTextChanged="txtPorcentajeAceptBCR_TextChanged"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="wmPorcentajeAceptBCR" runat="server" TargetControlID="txtPorcentajeAceptBCR"
                                    WatermarkText=" " />
                                <asp:MaskedEditExtender ID="mskPorcentajeAceptBCR" runat="server" TargetControlID="txtPorcentajeAceptBCR"
                                    Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                                    <%--<asp:RequiredFieldValidator ID="rfvPorcentajeAceptBCR" runat="server" ControlToValidate="txtPorcentajeAceptBCR"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionAvalesAdicional"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td>
                                <asp:Label ID="lblFechaConstitucionGarantia" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaConstitucionGarantia" CssClass="mainTableBoxesCss" runat="server"
                                    Width="105px" TabIndex="17" MaxLength="10"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaConstitucionGarantia" runat="server" ImageAlign="AbsMiddle"
                                    CausesValidation="false" />
                                <asp:CalendarExtender ID="caeFechaConstitucionGarantia" runat="server" PopupButtonID="ceFechaConstitucionGarantia"
                                    PopupPosition="Left" TargetControlID="txtFechaConstitucionGarantia">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFechaConstitucionGarantia" runat="server" ControlToValidate="txtFechaConstitucionGarantia"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionAvalesAdicional"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>

                              <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeAceptSugef" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptSugef" CssClass="mainTableBoxesCss" runat="server"
                                    Width="55px" TabIndex="18"></asp:TextBox>
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
                                <asp:Label ID="lblFechaVencimientoGarantia" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaVencimientoGarantia" CssClass="mainTableBoxesCss" runat="server"
                                    Width="105px" TabIndex="19" MaxLength="10"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaVencimientoGarantia" runat="server" ImageAlign="AbsMiddle"
                                    CausesValidation="false" />
                                <asp:CalendarExtender ID="caeFechaVencimientoGarantia" runat="server" PopupButtonID="ceFechaVencimientoGarantia"
                                    PopupPosition="Left" TargetControlID="txtFechaVencimientoGarantia">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFechaVencimientoGarantia" runat="server" ControlToValidate="txtFechaVencimientoGarantia"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionAvalesAdicional"></asp:RequiredFieldValidator>
                            </td>

                            <td class="tdSeparatorSmallRelacion">
                            </td>

                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeResponSugef" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeResponSugef" CssClass="mainTableBoxesCss" runat="server"
                                    Width="55px" TabIndex="20"></asp:TextBox>
                                <asp:MaskedEditExtender ID="mskPorcentajeResponSugef" runat="server" TargetControlID="txtPorcentajeResponSugef"
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
                            <td>
                                <asp:TextBox ID="txtFechaPrescripcionGarantia" CssClass="mainTableBoxesCss" runat="server"
                                    Width="105px" TabIndex="21" MaxLength="10"></asp:TextBox>
                                <asp:ImageButton ID="imgFechaPrescripcionGarantia" runat="server" ImageAlign="AbsMiddle"
                                    CausesValidation="false" />
                                <asp:CalendarExtender ID="caeFechaPrescripcionGarantia" runat="server" PopupButtonID="ceFechaPrescripcionGarantia"
                                    PopupPosition="Left" TargetControlID="txtFechaPrescripcionGarantia">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rfvFechaPrescripcionGarantia" runat="server" ControlToValidate="txtFechaPrescripcionGarantia"
                                    Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionAvalesAdicional"></asp:RequiredFieldValidator>
                            </td>

                            <td class="tdSeparatorSmallRelacion">
                            </td>
                                 <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeResponLegal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeResponLegal" CssClass="mainTableBoxesCss" runat="server"
                                    Width="55px" TabIndex="22"></asp:TextBox>
                                <asp:TextBoxWatermarkExtender ID="wmPorcentajeResponLegal" runat="server" TargetControlID="txtPorcentajeResponLegal"
                                    WatermarkText=" " />
                                <asp:MaskedEditExtender ID="mskPorcentajeResponLegal" runat="server" TargetControlID="txtPorcentajeResponLegal"
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
                    <asp:PostBackTrigger ControlID="btnAceptarAvales" />
                    <asp:PostBackTrigger ControlID="btnCancelarAvales" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    <div class="divPrincipalInferiorRelacion">
        <table width="100%" style="padding-top: 5px; padding-right: 5px; height: 100%;">
            <tr>
                <td style="width: 100%">
                    <asp:Button ID="btnAceptarAvales" runat="server" Text="Guardar y Cerrar" CssClass="botonAceptarRelacion"
                        TabIndex="23" ValidationGroup="ValidacionAvalesAdicional" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancelarAvales" runat="server" Text="Cancelar y Cerrar" CssClass="botonCancelarRelacion"
                        TabIndex="24" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>

    <asp:Panel ID="pnlInformarAval" runat="server" Style="display: none; background-color: #FFFFFF; "
        ClientIDMode="Static">
            <uc4:MensajeInformar ID="InformarBox1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBox" runat="server" PopupControlID="pnlInformarAval"
                TargetControlID="lkbModalInfo" BackgroundCssClass="modalBackground" DropShadow="false" X="285" Y="275"
                RepositionMode="RepositionOnWindowResizeAndScroll" />
    </asp:Panel>
