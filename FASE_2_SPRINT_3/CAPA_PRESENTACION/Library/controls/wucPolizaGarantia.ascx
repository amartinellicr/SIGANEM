<%@ control language="C#" autoeventwireup="true" inherits="wucPolizaGarantia, App_Web_uvl4zszt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarPoliza" tagprefix="ucp1" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css" />
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterEmergente.css" />
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterSubMain.css" />
<asp:UpdatePanel ID="upPrincipalPoliza" runat="server" >
    <ContentTemplate>
        <asp:Panel ID="pnlControlesPolizaGarantia" runat="server" class="mainPanel" Width="100%">
            <div class="divPrincipalTitulo">
                <table style="padding-left: 5px; padding-top: 3px;">
                    <tr>
                        <td>
                            <asp:Label ID="lblTitulo" runat="server" Text="Administración de Pólizas" CssClass="titulo"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lblSubtitulo" runat="server" Text="Complete el formulario" CssClass="subTitulo"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="divPrincipalSuperior Mayor">
                <asp:Panel ID="panelGrid" ScrollBars="Auto" runat="server" CssClass="panelPrincipalControles"
                    Height="100%">
                    <table style="width: 100%; border-collapse: collapse; background-color: #E8ECF0">
                        <tr>
                            <td style="width: 100%; height: 100%;">
                                <asp:Panel ID="pnlContainer" runat="server" Height="100%">
                                    
                                    <input type="hidden" id="hdnPolizaIdPolizaOculto" runat="server" clientidmode="Static" />
                                    
                                    <table class="masterGridTable" style="width: 95%; margin-left: 15px; text-align: left;">
                                        <tr>
                                            <td style="width: 35%" colspan="2">
                                                <asp:Label ID="lblSeccionPolizaDatos" Text="Datos Generales Póliza" CssClass="labelSubRelacion"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaTipoPoliza" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddlPolizaTipoPoliza" CssClass="mainTableBoxesCss" TabIndex="1" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlPolizaTipoPoliza_SelectedIndexChanged" Width="100%" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaNumSap" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaNumSap" CssClass="mainTableBoxesCss" Width="99%" TabIndex="2"
                                                    Enabled="true" runat="server"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="mskPolizaNumSap" runat="server" InputDirection="RightToLeft"
                                                    TargetControlID="txtPolizaNumSap" MaskType="Number" ClearMaskOnLostFocus="true"
                                                    ClearTextOnInvalid="true" Mask="999999999999">
                                                </asp:MaskedEditExtender>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaNumPoliza" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaNumPoliza" CssClass="mainTableBoxesCss" Width="99%" TabIndex="3" 
                                                    Enabled="true" MaxLength="42" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvGPolizaNumPoliza" runat="server" ControlToValidate="txtPolizaNumPoliza"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="PolizaGarantia" Enabled="false"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaFechaEmision" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaFechaEmision" CssClass="mainTableBoxesCss" Width="105" OnTextChanged="txtPolizaFechas_TextChanged"
                                                    AutoPostBack="true" TabIndex="4" runat="server" ></asp:TextBox>
                                                <asp:ImageButton ID="imbPolizaFechaEmision" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif"
                                                    ImageAlign="AbsMiddle" CausesValidation="false" />
                                                <asp:CalendarExtender ID="calendarExtenderPolizaFechaEmision" runat="server" PopupButtonID="imbPolizaFechaEmision"
                                                    PopupPosition="Left" TargetControlID="txtPolizaFechaEmision">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvPolizaFechaEmision" runat="server" ControlToValidate="txtPolizaFechaEmision"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="PolizaGarantia"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaFechaVencimiento" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaFechaVencimiento" CssClass="mainTableBoxesCss" Width="105" OnTextChanged="txtPolizaFechas_TextChanged"
                                                   AutoPostBack="true" TabIndex="5" runat="server" ></asp:TextBox>
                                                <asp:ImageButton ID="imbPolizaFechaVencimiento" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif"
                                                    ImageAlign="AbsMiddle" CausesValidation="false" />
                                                <asp:CalendarExtender ID="calendarExtenderPolizaFechaVencimiento" runat="server"
                                                    PopupButtonID="imbPolizaFechaVencimiento" PopupPosition="Left" TargetControlID="txtPolizaFechaVencimiento">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvPolizaFechaVencimiento" runat="server" ControlToValidate="txtPolizaFechaVencimiento"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="PolizaGarantia"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaTipoMoneda" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddlPolizaTipoMoneda" CssClass="mainTableBoxesCss" TabIndex="6" AutoPostBack="true"
                                                    Width="100%" OnSelectedIndexChanged="ddlPolizaTipoMoneda_SelectedIndexChanged" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaMontoPoliza" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaMontoPoliza" CssClass="mainTableBoxesCss" Width="55%" TabIndex="7" AutoPostBack="true"
                                                   OnTextChanged="txtPolizaMontoPoliza_TextChanged" runat="server" ></asp:TextBox>
                                                <asp:MaskedEditExtender ID="mskPolizaMontoPoliza" runat="server" InputDirection="RightToLeft"
                                                    TargetControlID="txtPolizaMontoPoliza" MaskType="Number" ClearMaskOnLostFocus="true"
                                                    ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99">
                                                </asp:MaskedEditExtender>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvPolizaMontoPoliza" runat="server" ControlToValidate="txtPolizaMontoPoliza"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="PolizaGarantia"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaMontoPolizaColonizado" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaMontoPolizaColonizado" Enabled="false" CssClass="mainTableBoxesCss" 
                                                    Width="55%" TabIndex="8" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvPolizaMontoPolizaColonizado" runat="server" ControlToValidate="txtPolizaMontoPolizaColonizado"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="PolizaGarantia"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaCobertura" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddlPolizaCobertura" CssClass="mainTableBoxesCss" TabIndex="9"
                                                    Width="100%" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%; height:30px; vertical-align:bottom;" colspan="2">
                                                <asp:Label ID="lblSeccionPolizaCliente" Text="Datos Cliente Póliza" CssClass="labelSubRelacion"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaTipoIdentificacion" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddlPolizaTipoIdentificacion" CssClass="mainTableBoxesCss" TabIndex="10"
                                                   OnSelectedIndexChanged="ddlPolizaTipoIdentificacion_SelectedIndexChanged" AutoPostBack="true"  Width="100%" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaIdentificacion" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaIdentificacion" CssClass="mainTableBoxesCss" Width="55%" AutoPostBack="true"
                                                    TabIndex="11" runat="server"  OnTextChanged="txtPolizaIdentificacion_TextChanged"></asp:TextBox>
                                                <asp:Button ID="btnPolizaIdentificacionBuscar" runat="server" CssClass="imgCmdBuscarGarantia" TabIndex="11" OnClick="btnPolizaIdentificacionBuscar_Click"
                                                    CausesValidation="true" ValidationGroup="PolizaGarantiaIdentificacion" ToolTip="Click para ejecutar la búsqueda" />
                                                <asp:Button ID="btnPolizaLimpiar" runat="server" CssClass="botonLimpiar" ToolTip="Limpiar Identificación" Enabled="false" Height="19px" 
                                                      OnClick="btnPolizaLimpiar_Click" CausesValidation="false"/> 
                                                <asp:MaskedEditExtender ID="mskPolizaIdentificacion" TargetControlID="txtPolizaIdentificacion"
                                                    runat="server" Mask="9-9999-9999" MaskType="Number" Enabled="false"></asp:MaskedEditExtender>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvPolizaIdentificacion" runat="server" ControlToValidate="txtPolizaIdentificacion"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="PolizaGarantiaIdentificacion"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaNombre" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaNombre" Enabled="false" CssClass="mainTableBoxesCss" Width="99.5%"
                                                    TabIndex="12" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvPolizaNombre" runat="server" ControlToValidate="txtPolizaNombre"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="PolizaGarantia" Enabled="false"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaPrimerApellido" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaPrimerApellido" Enabled="false" CssClass="mainTableBoxesCss"
                                                    Width="99.5%" TabIndex="13" runat="server"></asp:TextBox>                                                
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvPolizaPrimerApellido" runat="server" ControlToValidate="txtPolizaPrimerApellido"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="PolizaGarantia" Enabled="false"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaSegundoApellido" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaSegundoApellido" Enabled="false" CssClass="mainTableBoxesCss"
                                                    Width="99.5%" TabIndex="14" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaRazonSocial" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaRazonSocial" Enabled="false" CssClass="mainTableBoxesCss"
                                                    Width="99.5%" TabIndex="15" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                                <asp:RequiredFieldValidator ID="rfvPolizaRazonSocial" runat="server" ControlToValidate="txtPolizaRazonSocial"
                                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="PolizaGarantia" Enabled="false"
                                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>                                        
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaProvincia" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaProvincia" Enabled="false" CssClass="mainTableBoxesCss"
                                                    Width="99.5%" TabIndex="19" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaCanton" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaCanton" Enabled="false" CssClass="mainTableBoxesCss" Width="99.5%"
                                                    TabIndex="20" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaDistrito" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaDistrito" Enabled="false" CssClass="mainTableBoxesCss"
                                                    Width="99.5%" TabIndex="21" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaDireccion" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaDireccion" Enabled="false" CssClass="mainTableBoxesCss"
                                                    Width="99.5%" TabIndex="22" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaTelHabitacion" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaTelHabitacion" Enabled="false" CssClass="mainTableBoxesCss"
                                                    Width="99.5%" TabIndex="16" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaTelMovil" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaTelMovil" Enabled="false" CssClass="mainTableBoxesCss"
                                                    Width="99.5%" TabIndex="17" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 35%">
                                                <asp:Label ID="lblPolizaTelTrabajo" Text="" CssClass="blackLabel" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 60%">
                                                <asp:TextBox ID="txtPolizaTelTrabajo" Enabled="false" CssClass="mainTableBoxesCss"
                                                    Width="99.5%" TabIndex="18" runat="server"></asp:TextBox>
                                            </td>
                                            <td style="width: 5%">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <div class="divPrincipalInferior">
                <table width="100%" style="padding-top: 10px; padding-right: 5px; height: 100%;">
                    <tr>
                        <td style="width: 100%">
                            <asp:Button ID="btnGravamenGarantiaAceptar" runat="server" Text="Guardar y Cerrar" CausesValidation="true"
                                CssClass="botonAceptar" TabIndex="23" ValidationGroup="PolizaGarantia" />
                            <asp:Button ID="btnGravamenGarantiaCancelar" runat="server" Text="Cancelar y Cerrar"
                                CssClass="botonCancelar" TabIndex="24" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:Panel runat="server" ID="popupInformarPoliza" style="display: none; background-color: #FFFFFF;">
    <ucp1:MensajeInformarPoliza ID="InformarBoxPoliza1" runat="server" />
    <asp:LinkButton runat="server" ID="lkbModalInfoPoliza" CssClass="modalPopup" style="visibility: hidden;" />
    <asp:ModalPopupExtender ID="mpeInformarBoxPoliza" runat="server" 
        PopupControlID="popupInformarPoliza" 
        TargetControlID="lkbModalInfoPoliza" 
        BackgroundCssClass="modalBackground"
        DropShadow="false"
        RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
</asp:Panel>