<%@ control language="C#" autoeventwireup="true" inherits="wucOperacionesRelacionGarantiaFideicomiso, App_Web_uvl4zszt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformar" TagPrefix="uc4" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterOperacionRelaciones.css" />

<asp:Panel ID="pnlOperacionesRelacionGarantiaFideicomiso" runat="server" Width="100%" ClientIDMode="Static">
    <div class="divPrincipalTituloRelacion">
        <table style="padding-left: 5px; padding-top: 3px;">
            <tr>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Text="Relación a Garantía Fideicomisos" CssClass="tituloRelacion"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="divPrincipalSuperiorRelacionGarantiaFideicomiso">
        <asp:Panel ID="panelOperacionesRelacionGarantiaFideicomiso" runat="server" CssClass="panelPrincipalRelacion">
            <asp:UpdatePanel ID="updRelacionGarantiaFideicomisoPopUpControl" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>

                    <%--VALORES SESION--%>
                    <input type="hidden" id="valorSesionOculto" runat="server" />
                    <input type="hidden" id="tipoAccionOculto" runat="server" />
                    <input type="hidden" id="idFideicomisoOculto" runat="server" />
                    <input type="hidden" id="idGarantiaOperacion" runat="server" />
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
                            <td class="tdColumnLabel1Relacion" style="width: 21%;">
                                <asp:Label ID="lblIdFideicomisoBCR" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            <asp:TextBox ID="txtIdFideicomisoBCR" runat="server" CssClass="mainTableBoxesCss" 
                                    MaxLength="14" Style="text-transform: uppercase" TabIndex="6"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="rfvIdFideicomisoBCR" runat="server" 
                                    ControlToValidate="txtIdFideicomisoBCR" CssClass="labelTabErrorRelacion" 
                                    Display="Dynamic" ErrorMessage=" * " ValidationGroup="ValidacionFideicomiso"></asp:RequiredFieldValidator>
                            </td>             
                        </tr>
                        <tr>
                            <td class="tdLineSeparatorRelacion" colspan="5">
                            </td>
                            <td align="right" colspan="5" style="width: 100%;" valign="middle">
                                <asp:Button ID="btnConsultarFideicomiso" runat="server" CausesValidation="true" 
                                    CssClass="botonConsultarRelacion" OnClick="btnConsultarFideicomiso_Click" 
                                    TabIndex="13" Text="Consultar" ToolTip="Consultar Fideicomiso" 
                                    ValidationGroup="ValidacionFideicomiso" />
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
                                <asp:Label ID="lblTipoMonedaValorNominal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTipoMonedaValorNominal" CssClass="mainTableBoxesCss" runat="server" Width="198px"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>  
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblValorNominal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtValorNominal" CssClass="mainTableBoxesCss" runat="server" Width="198px"></asp:TextBox>
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
                                <asp:Label ID="lblClaseGarantia" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlClaseGarantia" runat="server" CssClass="mainTableBoxesCss" Width="200px"/>
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
                                <asp:Label ID="lblCodigoTenencia" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCodigoTenencia" runat="server" CssClass="mainTableBoxesCss" Width="200px"/>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblTipoMitigadorRiesgo" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoMitigadorRiesgo" runat="server" CssClass="mainTableBoxesCss" Width="200px"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblGradoGravamen" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlGradoGravamen" runat="server" CssClass="mainTableBoxesCss" TabIndex="10" Width="200px" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblTipoDocumentoLegal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoDocumentoLegal" runat="server" CssClass="mainTableBoxesCss" TabIndex="10" Width="200px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblTipoMonedaMontoGraven" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoMonedaMontoGraven" runat="server" CssClass="mainTableBoxesCss" TabIndex="10" Width="200px" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                               <asp:Label ID="lblMontoMitigador" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoMitigador" CssClass="mainTableBoxesCss" runat="server" Width="198px" TabIndex="14"></asp:TextBox>
                   
                                <asp:TextBoxWatermarkExtender ID="wmMontoMitigador" runat="server" TargetControlID="txtMontoMitigador" WatermarkText=" " />
                                
                                <asp:MaskedEditExtender ID="mskMontoMitigador" runat="server" TargetControlID="txtMontoMitigador" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true"></asp:MaskedEditExtender>
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
                                <asp:TextBox ID="txtMontoGradoGravamen" CssClass="mainTableBoxesCss" runat="server" Width="198px" TabIndex="14"></asp:TextBox>
                                
                                <asp:TextBoxWatermarkExtender ID="wmMontoGradoGravamen" runat="server" TargetControlID="txtMontoGradoGravamen" WatermarkText=" " />
                                
                                <asp:MaskedEditExtender ID="mskMontoGradoGravamen" runat="server" TargetControlID="txtMontoGradoGravamen" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true"></asp:MaskedEditExtender>
                             
                                 <asp:RequiredFieldValidator ID="rfvMontoGradoGravamen" runat="server" 
                                    ControlToValidate="txtMontoGradoGravamen" CssClass="labelTabErrorRelacion" 
                                    Display="Dynamic" ErrorMessage=" * " ValidationGroup="ValidacionDatosFideicomiso"></asp:RequiredFieldValidator>
                             </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeResponsabilidadSUGEF" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeResponsabilidadSUGEF" CssClass="mainTableBoxesCss" runat="server" Width="198px" TabIndex="15"></asp:TextBox>
                   
                                <asp:TextBoxWatermarkExtender ID="wmPorcentajeResponsabilidadSUGEF" runat="server" TargetControlID="txtPorcentajeResponsabilidadSUGEF" WatermarkText=" " />
                                
                                <asp:MaskedEditExtender ID="mskPorcentajeResponsabilidadSUGEF" runat="server" TargetControlID="txtPorcentajeResponsabilidadSUGEF" Mask="9" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true"></asp:MaskedEditExtender>
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
                                <asp:TextBox ID="txtFechaPrescripcionGarantia" CssClass="mainTableBoxesCss" runat="server" Width="198px" TabIndex="15"></asp:TextBox>                               
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
                    <asp:PostBackTrigger ControlID="btnAceptarRelacionGarantiaFideicomiso" />
                    <asp:PostBackTrigger ControlID="btnCancelarRelacionGarantiaFideicomiso" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    <div class="divPrincipalInferiorRelacion">
        <table width="100%" style="padding-top: 5px; padding-right: 5px; height: 100%;">
            <tr>
                <td style="width: 100%">
                    <asp:Button ID="btnAceptarRelacionGarantiaFideicomiso" runat="server" Text="Guardar y Cerrar" CssClass="botonAceptarRelacion" TabIndex="17" ValidationGroup="ValidacionDatosFideicomiso" CausesValidation="true"/>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancelarRelacionGarantiaFideicomiso" runat="server" Text="Cancelar y Cerrar" CssClass="botonCancelarRelacion" TabIndex="18" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>

<asp:Panel runat="server" ID="popupInformar" Style="display: none; background-color: #FFFFFF; z-index: 12001;">
    <asp:UpdatePanel ID="updFideicomisoPopUp" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <ContentTemplate>
            <uc4:MensajeInformar ID="InformarBox1" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" Style="visibility: hidden;" />
    <asp:ModalPopupExtender ID="mpeInformarBox" runat="server" PopupControlID="popupInformar"
        TargetControlID="lkbModalInfo" BackgroundCssClass="modalBackground" DropShadow="false" X="285" Y="275"
        RepositionMode="RepositionOnWindowResizeAndScroll" />
</asp:Panel>
