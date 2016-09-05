<%@ control language="C#" autoeventwireup="true" inherits="wucGarantiasFideicomisoValores, App_Web_vy014bao" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformar" TagPrefix="uc4" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterOperacionRelaciones.css" />

<asp:Panel ID="pnlOperacionesValores" runat="server" Width="100%" ClientIDMode="Static">
    <div class="divPrincipalTituloRelacion">
        <table style="padding-left: 5px; padding-top: 3px;">
            <tr>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Text="Relación a Garantía Fideicometida Valor" CssClass="tituloRelacion"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="divPrincipalSuperiorValores">
        <asp:Panel ID="panelOperacionesValores" runat="server" CssClass="panelPrincipalRelacion">
            <asp:UpdatePanel ID="updValoresPopUpControl" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>

                    <%--VALORES SESION--%>
                    <input type="hidden" id="valorSesionOculto" runat="server" />
                    <input type="hidden" id="tipoAccionOculto" runat="server" />
                    <input type="hidden" id="idGarantiaValorOculto" runat="server" />
                    <input type="hidden" id="idGarantiaFideicometida" runat="server" />
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
                                <asp:DropDownList ID="ddlIdTipoValor" runat="server" CssClass="mainTableBoxesCss" Width="200px" TabIndex="0" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
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
                                <asp:Label ID="lblIdTipoInstrumentoFinanciero" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlIdTipoInstrumentoFinanciero" runat="server" CssClass="mainTableBoxesCss" TabIndex="1" Width="650px" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdInstrumentoFinanciero" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlIdInstrumentoFinanciero" runat="server" CssClass="mainTableBoxesCss" TabIndex="2" Width="650px" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
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
                                <asp:DropDownList ID="ddlIdEmisor" runat="server" CssClass="mainTableBoxesCss" TabIndex="3" Width="650px" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
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
                                <asp:DropDownList ID="ddlIdISIN" runat="server" CssClass="mainTableBoxesCss" Width="200px" TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdSerieInstrumento" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdSerieInstrumento" runat="server" CssClass="mainTableBoxesCss" Width="175px" TabIndex="5" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdGarantiaBCR" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIdGarantiaBCR" runat="server" CssClass="mainTableBoxesCss"  Style="text-transform: uppercase" TabIndex="6" MaxLength="12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvIdGarantiaBCR" runat="server" ControlToValidate="txtIdGarantiaBCR" ErrorMessage=" * " CssClass="labelTabErrorRelacion" Display="Dynamic" ValidationGroup="ValidacionValores"></asp:RequiredFieldValidator>
                          
                                <%--<asp:RequiredFieldValidator ID="rfvIdGarantiaBCR" runat="server" ControlToValidate="txtIdGarantiaBCR" Display="Dynamic" ErrorMessage=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresGeneral"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                        <tr>
                           <%-- <td colspan="7" style="width: 100%;" align="right" valign="middle">
                                <asp:Button ID="btnConsultarGarantia" runat="server" Text="Consultar" ToolTip="Consultar Garantía" CssClass="botonConsultarRelacion" TabIndex="7" OnClick="btnConsultarGarantia_Click" CausesValidation="false"/>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>--%>
                             <td colspan="7" style="width: 100%;" align="right" valign="middle">
                                <asp:Button ID="btnConsultarGarantia" runat="server" Text="Consultar" ToolTip="Consultar Garantía" CssClass="botonConsultarRelacion" TabIndex="13" ValidationGroup="ValidacionValores" CausesValidation="true" OnClick="btnConsultarGarantia_Click" />
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
                                <asp:Label ID="lblTipoMonedaValorMercado" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTipoMonedaValorMercado" CssClass="mainTableBoxesCss" runat="server" Width="198px"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>  
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblTipoMonedaValorFacial" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTipoMonedaValorFacial" CssClass="mainTableBoxesCss" runat="server" Width="198px"></asp:TextBox>
                            </td>              
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblValorMercado" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValorMercado" CssClass="mainTableBoxesCss" runat="server" Width="198px"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>  
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblValorFacial" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValorFacial" CssClass="mainTableBoxesCss" runat="server" Width="198px"></asp:TextBox>
                            </td>              
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblValorMercadoColonizado" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValorMercadoColonizado" CssClass="mainTableBoxesCss" runat="server" Width="198px"></asp:TextBox>
                                
                              <%--  <asp:TextBoxWatermarkExtender ID="wmValorMercadoColonizado" runat="server" TargetControlID="txtValorMercado" WatermarkText=" " />
                                
                                <asp:MaskedEditExtender ID="mskValorMercadoColonizado" runat="server" TargetControlID="txtValorMercadoColonizado" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />--%>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>  
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblValorFacialColonizado" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValorFacialColonizado" CssClass="mainTableBoxesCss" runat="server" Width="198px"></asp:TextBox>
                                
                               <%-- <asp:TextBoxWatermarkExtender ID="wmValorFacialColonizado" runat="server" TargetControlID="txtValorMercado" WatermarkText=" " />
                                
                                <asp:MaskedEditExtender ID="mskValorFacialColonizado" runat="server" TargetControlID="txtValorFacialColonizado" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />--%>
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
                                <asp:Label ID="lblIdDueno" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                               <asp:TextBox ID="txtIdDueno" CssClass="mainTableBoxesCss" runat="server" Width="198px" MaxLength="17"></asp:TextBox>
                               
                                <asp:RequiredFieldValidator ID="rfvIdDueno" runat="server" ControlToValidate="txtIdDueno" Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresDatosAdicional" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIndInscripcion" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIndInscripcion" runat="server" CssClass="mainTableBoxesCss" Width="200px"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblNombreDueno" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNombreDueno" CssClass="mainTableBoxesCss" runat="server" Width="198px" MaxLength="75"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="rfvNombreDueno" runat="server" ControlToValidate="txtNombreDueno" Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresDatosAdicional" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblFechaPresentacion" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaPresentacion" CssClass="mainTableBoxesCss" runat="server" Width="198px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblTipoMonedaValorNominal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoMonedaValorNominal" runat="server" CssClass="mainTableBoxesCss" TabIndex="10" Width="200px" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoMitigador" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoMitigador" CssClass="mainTableBoxesCss" runat="server" Width="198px" TabIndex="13"></asp:TextBox>
                                
                                <asp:TextBoxWatermarkExtender ID="wmMontoMitigador" runat="server" TargetControlID="txtMontoMitigador" WatermarkText=" " />
                                
                                <asp:MaskedEditExtender ID="mskMontoMitigador" runat="server" TargetControlID="txtMontoMitigador" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblValorNominal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValorNominal" CssClass="mainTableBoxesCss" runat="server" Width="198px" TabIndex="11"></asp:TextBox>
                               
                                <asp:TextBoxWatermarkExtender ID="wmValorNominal" runat="server" TargetControlID="txtValorNominal" WatermarkText=" " />
                                
                                <asp:MaskedEditExtender ID="mskValorNominal" runat="server" TargetControlID="txtValorNominal" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                               <asp:Label ID="lblPorcentajeAceptacionSUGEF" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptacionSUGEF" CssClass="mainTableBoxesCss" runat="server" Width="198px" TabIndex="14"></asp:TextBox>
                                
                                <asp:TextBoxWatermarkExtender ID="wmPorcentajeAceptacionSUGEF" runat="server" TargetControlID="txtPorcentajeAceptacionSUGEF" WatermarkText=" " />
                                
                                <asp:MaskedEditExtender ID="mskPorcentajeAceptacionSUGEF" runat="server" TargetControlID="txtPorcentajeAceptacionSUGEF" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true"></asp:MaskedEditExtender>
                             </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblTipoMitagadorRiesgo" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                 <asp:DropDownList ID="ddlTipoMitagadorRiesgo" runat="server" CssClass="mainTableBoxesCss" TabIndex="12" Width="200px" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeAceptacionBCR" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptacionBCR" CssClass="mainTableBoxesCss" runat="server" Width="198px" TabIndex="15"></asp:TextBox>
                                
                                <asp:TextBoxWatermarkExtender ID="wmPorcentajeAceptacionBCR" runat="server" TargetControlID="txtPorcentajeAceptacionBCR" WatermarkText=" " />
                                
                                <asp:MaskedEditExtender ID="mskPorcentajeAceptacionBCR" runat="server" TargetControlID="txtPorcentajeAceptacionBCR" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true"></asp:MaskedEditExtender>
                                
                                <asp:RequiredFieldValidator ID="rfvPorcentajeAceptacionBCR" runat="server" ControlToValidate="txtPorcentajeAceptacionBCR" Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionValoresDatosAdicional" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblTipoDocumentoLegal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoDocumentoLegal" runat="server" CssClass="mainTableBoxesCss" Width="200px" />
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
                    <asp:Button ID="btnAceptarValores" runat="server" Text="Guardar y Cerrar" CssClass="botonAceptarRelacion" TabIndex="17" ValidationGroup="ValidacionValoresDatosAdicional" CausesValidation="true"/>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancelarValores" runat="server" Text="Cancelar y Cerrar" CssClass="botonCancelarRelacion" TabIndex="18" CausesValidation="false" />
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
