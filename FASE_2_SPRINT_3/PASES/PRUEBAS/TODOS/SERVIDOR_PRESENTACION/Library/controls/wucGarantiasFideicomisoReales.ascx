<%@ control language="C#" autoeventwireup="true" inherits="wucGarantiasFideicomisoReales, App_Web_kr4tffwh" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Library/controls/wucGridControl.ascx" TagName="VentanaTasadores" TagPrefix="uc1" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformarError" TagPrefix="uc2" %>
<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" TagName="VentanaBusquedaClaseVehiculo" TagPrefix="uc3" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformarClaseVehiculo" TagPrefix="uc4" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterOperacionRelaciones.css" />

<asp:Panel ID="pnlFideicometidaReales" runat="server" Width="100%">
    <div class="divPrincipalTituloRelacion">
        <table style="padding-left: 5px; padding-top: 3px;">
            <tr>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Text="Relación a Garantía Fideicometida Real" CssClass="tituloRelacion"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="divPrincipalSuperiorReales">
        <asp:Panel ID="panelFideicometidaReales" ScrollBars="Vertical" runat="server" CssClass="panelPrincipalRelacion">
            <asp:UpdatePanel ID="updRealesPopUpControl" runat="server" UpdateMode="Conditional"
                ChildrenAsTriggers="false">
                <ContentTemplate>
                    <%--VALORES SESION--%>
                    <input type="hidden" id="valorSesionOculto" runat="server" />
                    <input type="hidden" id="tipoAccionOculto" runat="server" />
                    <input type="hidden" id="idGarantiaRealOculto" runat="server" />
                    <input type="hidden" id="estadoGarantiaOculto" runat="server" />
                    <input type="hidden" id="idGarantiaFideicometida" runat="server" />

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
                                <asp:Label ID="lblTipoBien" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlTipoBien" runat="server" CssClass="mainTableBoxesCss" 
                                    Width="95%" TabIndex="0" AutoPostBack="true" 
                                    OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion">
                                <asp:Label ID="lblIdClaseTipoBien" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td style="width: 350px;">
                                <asp:DropDownList ID="ddlIdClaseTipoBien" runat="server" CssClass="mainTableBoxesCss" Width="350px" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral1Relacion">
                                <asp:Label ID="lblIdProvincia" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdProvincia" runat="server" CssClass="mainTableBoxesCss" Width="175px" TabIndex="2" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion">
                                <asp:Label ID="lblIdCodigoHorizontalidad" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td colspan="4">
                                <div style="float: left; width: 85%">
                                    <asp:DropDownList ID="ddlIdCodigoHorizontalidad" runat="server" CssClass="mainTableBoxesCss" TabIndex="3" Width="100%" />
                                </div>
                                <div style="vertical-align: middle; float: right; left: 85%; width: 15%;">
                                    <asp:CheckBox ID="chkEstadoHorizontal" runat="server" TextAlign="Right" Text="No Aplica" TabIndex="4" CssClass="mainTableBoxesCss" AutoPostBack="true" OnCheckedChanged="checkBox_OnCheckedChanged" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion">
                                <asp:Label ID="lblIdCodigoDuplicado" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td colspan="4">
                                <div style="float: left; width: 85%">
                                    <asp:DropDownList ID="ddlIdCodigoDuplicado" runat="server" CssClass="mainTableBoxesCss" Width="100%" TabIndex="5" />
                                </div>
                                <div style="vertical-align: middle; float: right; left: 85%; width: 15%;">
                                    <asp:CheckBox ID="chkEstadoDuplicado" runat="server" TextAlign="Right" Text="No Aplica" TabIndex="6" CssClass="mainTableBoxesCss" AutoPostBack="true" OnCheckedChanged="checkBox_OnCheckedChanged" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion">
                                <asp:Label ID="lblIdClaseBuque" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlIdClaseBuque" runat="server" CssClass="mainTableBoxesCss" TabIndex="7" Width="95%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion">
                                <asp:Label ID="lblIdClaseAeronave" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:DropDownList ID="ddlIdClaseAeronave" runat="server" CssClass="mainTableBoxesCss" Width="95%" TabIndex="8" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion">
                                <asp:Label ID="lblClaseVehiculo" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="txtClaseVehiculo" runat="server" CssClass="mainTableBoxesCss" MaxLength="4" TabIndex="9" ToolTip="Valor Vehículo" Width="120"></asp:TextBox>
                                
                                <asp:Button ID="btnClaseVehiculo" runat="server" CssClass="imgCmdBuscarGarantia" TabIndex="10" Enabled="false" CausesValidation="false" OnClick="btnClaseVehiculo_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion">
                            </td>
                            <td colspan="4">
                                <asp:Label ID="lblclasev" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                                
                                <asp:HiddenField ID="hdnIdClaseVehiculo" runat="server" />
                                
                                <asp:TextBox ID="txtDesClaseVehiculo" runat="server" CssClass="mainTableBoxesCss" Enabled="false" Width="95%"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="rfvDesClaseVehiculo" runat="server" ControlToValidate="txtDesClaseVehiculo" ErrorMessage=" * " CssClass="labelTabErrorRelacion" Display="Dynamic" ValidationGroup="ValidacionRealesGeneral"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral0Relacion">
                                <asp:Label ID="lblIdFormatoIdentificacionVehiculo" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td style="width: 350px;">
                                <asp:DropDownList ID="ddlIdFormatoIdentificacionVehiculo" runat="server" CssClass="mainTableBoxesCss" TabIndex="11" Width="350px" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnGeneral1Relacion">
                                <asp:Label ID="lblCodigoBien" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCodigoBien" runat="server" CssClass="mainTableBoxesCss" Style="text-transform: uppercase" MaxLength="17" TabIndex="12" ToolTip="Texto N° Bien" Width="175px"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="rfvNBien" runat="server" ControlToValidate="txtCodigoBien" ErrorMessage=" * " CssClass="labelTabErrorRelacion" Display="Dynamic" ValidationGroup="ValidacionRealesGeneral"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" style="width: 100%;" align="right" valign="middle">
                                <asp:Button ID="btnConsultarGarantia" runat="server" Text="Consultar" ToolTip="Consultar Garantía" CssClass="botonConsultarRelacion" TabIndex="13" ValidationGroup="ValidacionRealesGeneral" CausesValidation="true" OnClick="btnConsultarGarantia_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                             <%--<td colspan="7" style="width: 100%;" align="right" valign="middle">
                                <asp:Button ID="btnConsultarGarantia" runat="server" Text="Consultar" ToolTip="Consultar Garantía" CssClass="botonConsultarRelacion" TabIndex="13" ValidationGroup="ValidacionRealesGeneral" CausesValidation="true" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>--%>
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
                                <asp:Label ID="lblIdTipoMoneda" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtIdTipoMoneda" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoTasacionActualizadaNoTerreno" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoTasacionActualizadaNoTerreno" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoUltimaTasacionTerreno" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoUltimaTasacionTerreno" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoTotalUltimaTasacionActualizada" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoTotalUltimaTasacionActualizada" CssClass="mainTableBoxesCss" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoUltimaTasacionNoTerreno" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoUltimaTasacionNoTerreno" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblFechaUltimoSeguimientoGarantia" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaUltimoSeguimientoGarantia" CssClass="mainTableBoxesCss" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoTotalUltimaTasacion" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoTotalUltimaTasacion" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblFechaUltimaTasacionGarantia" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaUltimaTasacionGarantia" CssClass="mainTableBoxesCss" runat="server" MaxLength="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblMontoTasacionActualizadaTerreno" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMontoTasacionActualizadaTerreno" CssClass="mainTableBoxesCss" runat="server"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                    </table>

                    <table id="tableTituloCedulas" style="width: 100%; text-align: left;">
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblCedulas" runat="server" Text="Cédulas Hipotecarias" CssClass="labelSubRelacion"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table id="tableCedulas" runat="server" style="width: 100%; text-align: left;">
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblValorTotalCedulas" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:TextBox ID="txtValorTotalCedulas" runat="server" CssClass="mainTableBoxesCss"></asp:TextBox>
                                
                                <asp:MaskedEditExtender ID="mskValorTotalCedulas" runat="server" InputDirection="RightToLeft" TargetControlID="txtValorTotalCedulas" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99">   
                                </asp:MaskedEditExtender>

                                <asp:RequiredFieldValidator ID="rfvValorTotalCedulas" runat="server" ControlToValidate="txtValorTotalCedulas" ErrorMessage=" * " CssClass="labelTabErrorRelacion" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblCantidadCedulas" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:TextBox ID="txtCantidadCedulas" runat="server" CssClass="mainTableBoxesCss"
                                    Width="150px" Enabled="false"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td colspan="5" class="tdLineSeparatorRelacion">
                                <div id="divCedulas" class="panelGridControl">
                                    <uc1:VentanaTasadores ID="grdCedulas" runat="server" />
                                </div>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td colspan="2">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td style="text-align: right">
                                <asp:Label ID="lblValorTotalFacial" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td style="text-align: right">
                                <asp:TextBox ID="txtValorTotalFacial" runat="server" CssClass="mainTableBoxesCss" Enabled="false"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
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
                                <asp:TextBox ID="txtIdDueno" CssClass="mainTableBoxesCss" runat="server" MaxLength="17" TabIndex="14"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvIdDueño" runat="server" ControlToValidate="txtIdDueno" 
                                 Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionRealesAdicional"></asp:RequiredFieldValidator>                                     
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td>
                                <asp:Label ID="lblMontoMitigador" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                               <asp:TextBox ID="txtMontoMitigador" CssClass="mainTableBoxesCss" runat="server" TabIndex="15"></asp:TextBox>
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
                                <asp:TextBox ID="txtNombreDueno" CssClass="mainTableBoxesCss" runat="server" MaxLength="75" TabIndex="16"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNombreDueño" runat="server" ControlToValidate="txtNombreDueno"
                                 Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionRealesAdicional"></asp:RequiredFieldValidator>                                                   
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeAceptTerrenoSUGEF" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptTerrenoSUGEF" CssClass="mainTableBoxesCss" runat="server" TabIndex="17"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoMonedaValorNominal" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoMonedaValorNominal" runat="server" CssClass="mainTableBoxesCss" TabIndex="18" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeAceptNoTerrenoSUGEF" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptNoTerrenoSUGEF" CssClass="mainTableBoxesCss" runat="server" TabIndex="19"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">                         
                                <asp:Label ID="lblValorNominal" runat="server" CssClass="mainTableBoxesCss"></asp:Label>               
                            </td>
                            <td>
                                <asp:TextBox ID="txtValorNominal" CssClass="mainTableBoxesCss" runat="server" TabIndex="20"></asp:TextBox>
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblPorcentajeAceptBCR" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtPorcentajeAceptBCR" CssClass="mainTableBoxesCss" runat="server" TabIndex="21"></asp:TextBox>
                                 <asp:TextBoxWatermarkExtender ID="wmPorcentajeAceptBCR" runat="server" TargetControlID="txtPorcentajeAceptBCR"
                                    WatermarkText=" " />
                                 <asp:MaskedEditExtender ID="mskPorcentajeAceptBCR" runat="server" TargetControlID="txtPorcentajeAceptBCR"
                                    Mask="999.99%" MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" />
                                 <asp:RequiredFieldValidator ID="rfvPorcentajeAceptBCR" runat="server" ControlToValidate="txtPorcentajeAceptBCR"
                                 Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionRealesAdicional"></asp:RequiredFieldValidator>                                                              
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">                                                               
                                <asp:Label ID="lblIdTipoMitigadorRiesgo" runat="server" CssClass="mainTableBoxesCss"></asp:Label>    
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoMitigadorRiesgo" runat="server" CssClass="mainTableBoxesCss" TabIndex="22" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td>
                                <asp:Label ID="lblFechaPresentacion" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaPresentacion" CssClass="mainTableBoxesCss" runat="server" OnTextChanged="txtFechaPresentacion_TextChanged" TabIndex="23"></asp:TextBox>
                                <asp:ImageButton ID="imbFechaPresentacion" TabIndex="24" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                <asp:CalendarExtender ID="calendarExtenderFechaPresentacion" runat="server" PopupButtonID="imbFechaPresentacion" PopupPosition="TopLeft" TargetControlID="txtFechaPresentacion"></asp:CalendarExtender> 
                                <asp:RequiredFieldValidator ID="rfvFechaPresentacion" runat="server" ControlToValidate="txtFechaPresentacion"
                                 Display="Dynamic" Text=" * " CssClass="labelTabErrorRelacion" ValidationGroup="ValidacionRealesAdicional"></asp:RequiredFieldValidator>                                                              
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdTipoDocumentoLegal" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdTipoDocumentoLegal" runat="server" CssClass="mainTableBoxesCss" TabIndex="25" />
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIdDeudorHabita" CssClass="mainTableBoxesCss" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlIdDeudorHabita" runat="server" CssClass="mainTableBoxesCss" TabIndex="26" />                             
                            </td>
                        </tr>
                        <tr>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                            <td class="tdColumnLabel1Relacion">
                                <asp:Label ID="lblIndInscripcion" runat="server" CssClass="mainTableBoxesCss"></asp:Label>
                            </td>
                            <td>                          
                                <asp:DropDownList ID="ddlIndInscripcion" runat="server" CssClass="mainTableBoxesCss" TabIndex="27"
                                 AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" />                  
                            </td>
                            <td class="tdSeparatorSmallRelacion">
                            </td>
                             <td colspan="2">
                            </td>
                        </tr>                                   
                        <tr style="height: 8px;">
                            <td colspan="7" class="tdLineSeparatorRelacion">
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>

                <Triggers>
                    <asp:PostBackTrigger ControlID="btnAceptarReales" />
                    <asp:PostBackTrigger ControlID="btnCancelarReales" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
    </div>
    <div class="divPrincipalInferiorRelacion">
        <table width="100%" style="padding-top: 5px; padding-right: 5px; height: 100%;">
            <tr>
                <td style="width: 100%">
                    <asp:Button ID="btnAceptarReales" runat="server" Text="Guardar y Cerrar" CssClass="botonAceptarRelacion" TabIndex="28" ValidationGroup="ValidacionRealesAdicional" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancelarReales" runat="server" Text="Cancelar y Cerrar" CssClass="botonCancelarRelacion" TabIndex="29" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>

<asp:Panel runat="server" ID="popupInformar" Style="display: none; background-color: #FFFFFF;">
    <uc2:MensajeInformarError ID="InformarBox1" runat="server" />
    <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" Style="visibility: hidden;" />
    <asp:ModalPopupExtender ID="mpeInformarBox" runat="server" PopupControlID="popupInformar"
        TargetControlID="lkbModalInfo" BackgroundCssClass="modalBackground" DropShadow="false"
        X="285" Y="275" RepositionMode="RepositionOnWindowResizeAndScroll" />
</asp:Panel>
<asp:Panel runat="server" ID="popupBusquedaClaseVehiculo" Style="display: none; background-color: #FFFFFF;
    height: 306px; width: 550px; border-width: 3px; border-color: Black; border-style: solid;">
    <uc3:VentanaBusquedaClaseVehiculo ID="BusquedaClaseVehiculo" runat="server" />
    <asp:LinkButton runat="server" ID="lkbModalBusquedaClaseVehiculo" CssClass="modalPopup"
        Style="visibility: hidden;" />
    <asp:ModalPopupExtender ID="mpeBusquedaClaseVehiculo" runat="server" PopupControlID="popupBusquedaClaseVehiculo"
        TargetControlID="lkbModalBusquedaClaseVehiculo" BackgroundCssClass="modalBackground"
        DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll" />
</asp:Panel>
<asp:Panel runat="server" ID="popupInformarClaseVehiculo" Style="display: none; background-color: #FFFFFF;">
    <uc4:MensajeInformarClaseVehiculo ID="InformarClaseVehiculo" runat="server" />
    <asp:LinkButton runat="server" ID="lkbModalInformarClaseVehiculo" CssClass="modalPopup"
        Style="visibility: hidden;" />
    <asp:ModalPopupExtender ID="mpeInformarClaseVehiculo" runat="server" PopupControlID="popupInformarClaseVehiculo"
        TargetControlID="lkbModalInformarClaseVehiculo" BackgroundCssClass="modalBackground"
        DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll" />
</asp:Panel>
