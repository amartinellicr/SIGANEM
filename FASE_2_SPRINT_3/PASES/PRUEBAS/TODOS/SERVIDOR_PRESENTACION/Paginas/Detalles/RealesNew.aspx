<%@ page title="" language="C#" masterpagefile="~/Library/styles/MasterPages/SubMain.Master" autoeventwireup="true" inherits="RealesNew, App_Web_m1u5jfjs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Reference Control="~/Library/controls/wucMenuLateralDetalle.ascx" %>
<%@ Reference Control="~/Library/controls/wucMenuSuperiorDetalle.ascx" %>

<%@ Register Src="~/Library/controls/wucMensajeEliminar.ascx" tagname="MensajeEliminar" tagprefix="uc3" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformar" tagprefix="uc4" %>
<%@ Register Src="~/Library/controls/wucGridControl.ascx" tagname="GridTasadores" tagprefix="uc5" %>

<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" tagname="VentaBusquedaClaseVehiculo" tagprefix="uc6" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarVentanaBusquedaClaseVehiculo" tagprefix="uc7" %>

<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" tagname="VentaBusquedaEmpresaTasadora" tagprefix="uc8" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarVentanaBusquedaEmpresaTasadora" tagprefix="uc9" %>

<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" tagname="VentaBusquedaPersonaTasadora" tagprefix="uc10" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarVentanaBusquedaPersonaTasadora" tagprefix="uc11" %>

<%@ Register Src="~/Library/controls/wucCedulasHipotecarias.ascx" tagname="VentaCedulasHipotecarias" tagprefix="uc12" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarCedulasHipotecarias" tagprefix="uc13" %>

<%@ Register Src="~/Library/controls/wucMensajeConfirmar.ascx" tagname="MensajeConfirmar" tagprefix="uc14" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeAdvertencia" tagprefix="uc15" %>

<%@ Register Src="~/Library/controls/wucGravamenGarantia.ascx" tagname="VentaGravamenGarantia" tagprefix="uc16" %>

<%@ Register Src="~/Library/controls/wucPolizaGarantia.ascx" tagname="VentaPolizaGarantia" tagprefix="uc17" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="Server">
    <title>Detalle</title>
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterSubMain.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MensajePopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/ModalPopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css"/>

    <script src="../../Library/scripts/Procesando.js" language="javascript" type="text/javascript"></script>
    <script src="../../Library/scripts/TextBox.js" language="javascript" type="text/javascript"></script>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--CAMBIAR SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" clientidmode="Static" />
    <input type="hidden" id="codUsuarioOculto" runat="server" clientidmode="Static" />
    <input type="hidden" id="pantallaIdOculto" runat="server" clientidmode="Static"/>
    <input type="hidden" id="pantallaTituloOculto" runat="server" clientidmode="Static"/>
    <input type="hidden" id="pantallaModuloOculto" runat="server" clientidmode="Static"/>
    <input type="hidden" id="pantallaNombreOculto" runat="server" clientidmode="Static"/>

    <div id="body" class="body">
        <asp:UpdatePanel ID="UpdatePanelControles" runat="server"  >
            <ContentTemplate>
                
                <%--CONTROL DE CAMBIOS 1.2--%>
                <input type="hidden" id="idGarantiaRealTipoBienOculto" runat="server" clientidmode="Static" />
                <input type="hidden" id="idOperacionOculto" runat="server" clientidmode="Static" />

                <div id="divHeader">
                    <table class="tablePage">
                        <tr>
                            <td colspan="4" style="height: 18px; vertical-align: middle;">
                                <div id="divBarraMensaje" class="divBarraMensaje" runat="server" visible="false">
                                    <asp:Label ID="lblBarraMensaje" runat="server" CssClass="etiquetaBarraMensajeExito" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 8px;">
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2" class="tdImage">
                                <asp:Image ID="imgPagina" runat="server" ImageUrl="~/Library/img/32/iconNuevo.png"
                                    Height="32px" Width="32px" Visible="true" />
                            </td>                            
                            <td class="tdTitle">
                                <asp:Label ID="lblPagina" runat="server" CssClass="titlePage"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdTitle">
                                <asp:Label ID="lblPaginaSubtitulo" runat="server" CssClass="titlePage2"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 12px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="height: 12px;">
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divForm">

                    <table class="tableForm">
                        <tr>
                            <td>
                                <asp:Label ID="lblForm" runat="server" Text="Mantenimiento de " CssClass="titleForm"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLine">
                                <div id="General">
                                    <asp:Label ID="lblFormSubtitulo" runat="server" CssClass="titleForm2"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divControls">
                    <asp:Table runat="server" ID="tableData" EnableViewState="true">

                    </asp:Table>
                    <table id="tblGeneral" style="width:100%;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab1">
                                    <asp:Label ID="lblGeneral" Text="General" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblTipoBien" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:DropDownList id="ddlTipoBien" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static" 
                                    Width="100%" ToolTip="Lista de Tipo Bien" TabIndex="1" AutoPostBack="true"
                                    onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblClase" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlClase" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static" AutoPostBack="true"
                                     onselectedindexchanged="dropDownList_SelectedIndexChanged" TabIndex="2" ToolTip="Lista de Clase" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblProvincia" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td colspan="5">
                                <asp:DropDownList id="ddlProvincia" runat="server" CssClass="mainTableBoxesCss" 
                                    Width="100%" ToolTip="Lista de Provincias" TabIndex="3"></asp:DropDownList>
                            </td>
                        <tr>    
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblHorizontal" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5">
                                <div style="float:left; width:85%">
                                <asp:DropDownList ID="ddlHorizontal" runat="server" 
                                    CssClass="mainTableBoxesCss" TabIndex="4" ToolTip="Lista de Hizontales" 
                                    Width="100%">
                                </asp:DropDownList>
                                </div>
                                <div style="vertical-align: middle; float:right; left:85%; width: 15%;">
                                <asp:CheckBox ID="chkEstadoHorizontal" runat="server" TextAlign="Right" TabIndex="4" CssClass="mainTableBoxesCss" 
                                 OnCheckedChanged="checkBox_OnCheckedChanged" AutoPostBack="true" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblDuplicado" runat="server" CssClass="blackLabel"></asp:Label> 
                            </td>
                            <td colspan="5">
                                 <div style="float:left; width:85%">
                                <asp:DropDownList id="ddlDuplicado" runat="server" CssClass="mainTableBoxesCss" Width="100%" 
                                ToolTip="Lista de Duplicado" TabIndex="5"></asp:DropDownList>
                                </div>
                                <div style="vertical-align: middle; float:right; left:85%; width: 15%;">
                                <asp:CheckBox ID="chkEstadoDuplicado" runat="server" TabIndex="5"  CssClass="mainTableBoxesCss" 
                                 OnCheckedChanged="checkBox_OnCheckedChanged" AutoPostBack="true" /> 
                                </div>                               
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblClaseBuque" runat="server" CssClass="blackLabel" ></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlClaseBuque" runat="server" 
                                    CssClass="mainTableBoxesCss" TabIndex="6" ToolTip="Lista de Clase Buque" 
                                    Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblClaseAeronave" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td colspan="5">
                                <asp:DropDownList id="ddlClaseAeronave" runat="server" CssClass="mainTableBoxesCss" 
                                Width="100%" ToolTip="Lista de Clase Aeronave" TabIndex="7"></asp:DropDownList>                                                       
                            </td>
                        <tr> 
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblClaseVehiculo" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5" style="vertical-align: middle;">
                                <asp:TextBox ID="txtClaseVehiculo" runat="server" CssClass="mainTableBoxesCss" 
                                    MaxLength="4" TabIndex="8" ToolTip="Valor Vehículo" Width="120"></asp:TextBox>
                                <asp:Button ID="btnClaseVehiculo" runat="server" CssClass="imgCmdBuscarGarantia" TabIndex="9" Enabled="false" CausesValidation="false" ToolTip="Click para ejecutar la búsqueda" OnClick="btnClaseVehiculo_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label id="lblclasev" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnIdClaseVehiculo" runat="server" />
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDesClaseVehiculo" runat="server" 
                                    CssClass="mainTableBoxesCss" Enabled="false" TabIndex="10" Width="99.5%"></asp:TextBox>
                            </td>
                            <td style="width: 3%;">
                                <asp:RequiredFieldValidator ID="rfvDesClaseVehiculo" runat="server" ControlToValidate="txtDesClaseVehiculo"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr> 
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblFormato" runat="server" CssClass="blackLabel" 
                                    Text="Formato Identificación Vehículo"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlFormato" runat="server" CssClass="mainTableBoxesCss" AutoPostBack="true" ClientIDMode="Static"
                                    TabIndex="11" ToolTip="Lista de Formato Identificación Vehículo" Width="100%" onselectedindexchanged="dropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblNBien" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtNBien" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static" 
                                    MaxLength="17" TabIndex="12" ToolTip="Texto N° Bien" Width="150"></asp:TextBox>
                            </td>
                            <td style="width: 3%; " >
                            <asp:RequiredFieldValidator ID="rfvNBien" runat="server" ControlToValidate="txtNBien"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblIdGeneral" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnIdGeneral" runat="server" />
                            </td>
                            <td style="width: 20%; text-align: right;">
                                <asp:Button ID="btnValidar" runat="server" CssClass="botonValidar"  TabIndex="13" ToolTip="Validar Sección General" onclick="btnValidar_Click" />
                            </td>
                            <td style="width: 3%">
                            </td>
                        
                    </table>
                    <table id="tblValuacion" style="width:100%;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab2">
                                    <asp:Label ID="lblValuacion" Text="Valuación" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblTipoMoneda" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList id="ddlTipoMoneda" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Lista de Tipo Moneda" TabIndex="13" Enabled="false"></asp:DropDownList>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblLiquidezGarantia" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList id="ddlLiquidezGarantia" runat="server" TabIndex="20" CssClass="mainTableBoxesCss" Width="150" ToolTip="Lista de Liquidez Garantía"></asp:DropDownList>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblMontoUltimaTasacionTerreno" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtMontoUltimaTasacionTerreno" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Texto Monto Última Tasación Terreno"
                                AutoPostBack="true" TabIndex="14" OnTextChanged="txtMontoUltimaTasacionTerreno_TextChanged"></asp:TextBox>
                                <asp:MaskedEditExtender ID="mskMontoUltimaTasacionTerreno" runat="server" InputDirection="RightToLeft" TargetControlID="txtMontoUltimaTasacionTerreno"
                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99" ></asp:MaskedEditExtender>
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvMontoUltimaTasacionTerreno" runat="server" ControlToValidate="txtMontoUltimaTasacionTerreno"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblFechaConstruccionGarantia" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td style="width: 20%">
                                <div style="position: relative">
                                    <asp:TextBox ID="txtFechaConstruccionGarantia" runat="server" CssClass="mainTableBoxesCss" Width="105" ToolTip="Calendario Fecha Construcción Garantía"
                                    AutoPostBack="true" TabIndex="21" OnTextChanged="txtFechaConstruccionGarantia_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="imbFechaConstruccionGarantia" TabIndex="22" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                    <asp:CalendarExtender ID="calendarExtenderFechaConstruccionGarantia" runat="server" PopupButtonID="imbFechaConstruccionGarantia" PopupPosition="TopLeft" TargetControlID="txtFechaConstruccionGarantia"></asp:CalendarExtender> 
                                </div>
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvFechaConstruccionGarantia" runat="server" ControlToValidate="txtFechaConstruccionGarantia"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblMontoUltimaTasacionNoTerreno" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtMontoUltimaTasacionNoTerreno" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Texto Monto Última Tasación No Terreno"
                                AutoPostBack="true" TabIndex="15" OnTextChanged="txtMontoUltimaTasacionNoTerreno_TextChanged" ></asp:TextBox>
                                <asp:MaskedEditExtender ID="mskMontoUltimaTasacionNoTerreno" runat="server" InputDirection="RightToLeft" TargetControlID="txtMontoUltimaTasacionNoTerreno"
                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99" ></asp:MaskedEditExtender>                                
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvMontoUltimaTasacionNoTerreno" runat="server" ControlToValidate="txtMontoUltimaTasacionNoTerreno"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblFechaUltimaTasacionGarantia" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td style="width: 20%">
                                <div style="position: relative">
                                    <asp:TextBox ID="txtFechaUltimaTasacionGarantia" runat="server" CssClass="mainTableBoxesCss" Width="105" ToolTip="Calendario Fecha Última Tasación Garantía"
                                    AutoPostBack="true" TabIndex="23" OnTextChanged="txtFechaUltimaTasacionGarantia_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="imbFechaUltimaTasacionGarantia" TabIndex="24" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                    <asp:CalendarExtender ID="calendarExtenderFechaUltimaTasacionGarantia" runat="server" PopupButtonID="imbFechaUltimaTasacionGarantia" PopupPosition="TopLeft" TargetControlID="txtFechaUltimaTasacionGarantia"></asp:CalendarExtender> 
                                </div>
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvFechaUltimaTasacionGarantia" runat="server" ControlToValidate="txtFechaUltimaTasacionGarantia"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblMontoTotalUltimaTasacion" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtMontoTotalUltimaTasacion" TabIndex="16" runat="server" CssClass="mainTableBoxesCss" Width="150" Enabled="false" ToolTip="Texto Monto Total Última Tasación"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblFechaUltimoSeguimientoGarantia" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td style="width: 20%">
                                <div style="position: relative">
                                    <asp:TextBox ID="txtFechaUltimoSeguimientoGarantia" runat="server" CssClass="mainTableBoxesCss" Width="105" ToolTip="Calendario Fecha Último Seguimiento Garantía"
                                    AutoPostBack="true" TabIndex="25" OnTextChanged="txtFechaUltimoSeguimientoGarantia_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="imbFechaUltimoSeguimientoGarantia" TabIndex="26" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                    <asp:CalendarExtender ID="calendarExtenderFechaUltimoSeguimientoGarantia" runat="server" PopupButtonID="imbFechaUltimoSeguimientoGarantia" PopupPosition="TopLeft" TargetControlID="txtFechaUltimoSeguimientoGarantia"></asp:CalendarExtender> 
                                </div>
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvFechaUltimoSeguimientoGarantia" runat="server" ControlToValidate="txtFechaUltimoSeguimientoGarantia"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblMontoTasacionActualizadaTerreno" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtMontoTasacionActualizadaTerreno" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Texto Monto Tasación Actualizada Terreno"
                                AutoPostBack="true" TabIndex="17" OnTextChanged="txtMontoTasacionActualizadaTerreno_TextChanged"></asp:TextBox>
                                <asp:MaskedEditExtender ID="mskMontoTasacionActualizadaTerreno" runat="server" InputDirection="RightToLeft" TargetControlID="txtMontoTasacionActualizadaTerreno"
                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99" ></asp:MaskedEditExtender>                                                   
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvMontoTasacionActualizadaTerreno" runat="server" ControlToValidate="txtMontoTasacionActualizadaTerreno"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblFechaVencimientoAvaluo" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtFechaVencimientoAvaluo" TabIndex="27" runat="server" CssClass="mainTableBoxesCss" Width="146" Enabled="false" ToolTip="Fecha Vencimiento Avalúo"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblMontoTasacionActualizadaNoTerreno" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtMontoTasacionActualizadaNoTerreno" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Texto Monto Tasación Actualizada No Terreno"
                                AutoPostBack="true" TabIndex="18" OnTextChanged="txtMontoTasacionActualizadaNoTerreno_TextChanged"></asp:TextBox>
                                <asp:MaskedEditExtender ID="mskMontoTasacionActualizadaNoTerreno" runat="server" InputDirection="RightToLeft" TargetControlID="txtMontoTasacionActualizadaNoTerreno"
                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99" ></asp:MaskedEditExtender>                                                   
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvMontoTasacionActualizadaNoTerreno" runat="server" ControlToValidate="txtMontoTasacionActualizadaNoTerreno"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblFechaFabricacionGarantia" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td style="width: 20%">
                                <div style="position: relative">
                                    <asp:TextBox ID="txtFechaFabricacionGarantia" runat="server" CssClass="mainTableBoxesCss" Width="105" ToolTip="Calendario Fecha Fabricación Garantía"
                                    AutoPostBack="true" TabIndex="28" OnTextChanged="txtFechaFabricacionGarantia_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="imbFechaFabricacionGarantia" TabIndex="29" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                    <asp:CalendarExtender ID="calendarFechaFabricacionGarantia" runat="server" PopupButtonID="imbFechaFabricacionGarantia" PopupPosition="TopLeft" TargetControlID="txtFechaFabricacionGarantia"></asp:CalendarExtender> 
                                </div> 
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvFechaFabricacionGarantia" runat="server" ControlToValidate="txtFechaFabricacionGarantia"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblMontoTotalUltimaTasacionActualizada" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtMontoTotalUltimaTasacionActualizada" TabIndex="30" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Texto Monto Tasación Última Tasación Actualizada" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblTipoAlmacen" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList id="ddlTipoAlmacen" runat="server" TabIndex="31" CssClass="mainTableBoxesCss" ToolTip="Lista de Tipo Almacén"></asp:DropDownList>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblEstadoGarantia" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList id="ddlEstadoGarantia" runat="server" TabIndex="31" CssClass="mainTableBoxesCss" ToolTip="Lista de Estado Garantía"></asp:DropDownList>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                            </td>
                            <td style="width: 20%">                                
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                    </table>
                    <table id="tblTasadores">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab3">
                                    <asp:Label ID="lblTasadores" Text="Tasadores" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblTipoTasador" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList id="ddlTipoTasador" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Lista de Tipo de Tasador"
                                AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged" ></asp:DropDownList>                                
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">                                
                            </td>
                            <td style="width: 20%; text-align: right;">
                               <asp:Button ID="btnLimpiar" runat="server" CssClass="botonLimpiar" ToolTip="Limpiar Sección Tasadores" Enabled="false" 
                               OnClick="btnLimpiar_Click" CausesValidation="false"/>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblAdministrarEmpresaTasadora" runat="server" CssClass="blackBoldLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:Button ID="imbAdministrarEmpresaTasadora" runat="server" CssClass="imgCmdBuscarGarantia" Enabled="false" CausesValidation="false" ToolTip="Click para ejecutar la búsqueda" OnClick="btnClaseAdministrarEmpresaTasadora_Click"/>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%"> 
                                <asp:HiddenField ID="hdnIdEmpresaTasadora" runat="server" /> 
                                <asp:Label ID="lblEmpresaTasadora" runat="server"></asp:Label> 
                            </td>
                            <td style="width: 20%;">
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblTipoPersonaEmpresaTasadora" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList id="ddlTipoPersonaEmpresaTasadora" runat="server" CssClass="mainTableBoxesCss" Width="100%" ToolTip="Lista de Tipo Empresa Tasadora"
                                Enabled="false"></asp:DropDownList>                                
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblIdEmpresaTasadora" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%; text-align: right;">
                               <asp:TextBox ID="txtIdEmpresaTasadora" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Texto Id Empresa Tasadora" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                               <asp:Label ID="lblNombreEmpresaTasadora" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtNombreEmpresaTasadora" runat="server" CssClass="mainTableBoxesCss" Width="99.3%" ToolTip="Texto Nombre Empresa Tasadora" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style=" padding-left: 5px;" colspan="7">
                                <asp:Label ID="lblAdministrarTasadores" runat="server" CssClass="blackBoldLabel"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style=" padding-left: 5px;" colspan="6">
                                <%--<asp:Panel id="pnlTasadores" runat="server" ScrollBars="Auto" Height="150px">--%>
                                    <div id="divTasadores" class="panelGridControl">
                                    
                                    <uc5:GridTasadores ID="grdTasadores" runat="server" />
                                    </div>
                                <%--</asp:Panel>--%>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                    </table>
                    <table id="tblCedulas" style="width:100%;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab4">
                                    <asp:Label ID="lblCedulas" Text="Cédulas" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblValorTotalCedulas" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtValorTotalCedulas" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Texto Valor Total Cédulas"></asp:TextBox>
                                <asp:MaskedEditExtender ID="mskValorTotalCedulas" runat="server" InputDirection="RightToLeft" TargetControlID="txtValorTotalCedulas"
                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99" ></asp:MaskedEditExtender>                             
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvValorTotalCedulas" runat="server" ControlToValidate="txtValorTotalCedulas"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblCantidadCedulas" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%; text-align: right;">
                               <asp:TextBox ID="txtCantidadCedulas" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Texto Cantidad de Cédulas" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style=" padding-left: 5px;" colspan="6">
                                <div id="divCedulas" class="panelGridControl">
                                <%--<asp:Panel id="pnlCedulas" runat="server" ScrollBars="Auto" max-height="150px">--%>
                                    <uc5:GridTasadores ID="grdCedulas" runat="server" />
                                <%--</asp:Panel>--%>
                                </div>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                            </td>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblValorTotalFacial" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%; text-align: right;">
                               <asp:TextBox ID="txtValorTotalFacial" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Texto Total Facial" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                    </table>
                    <table id="tblGravamenes" style="width:100%;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab5">
                                    <asp:Label ID="lblGravamenes" Text="Gravámenes" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblIndGravamen" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                               <asp:DropDownList id="ddlIndGravamen" runat="server" CssClass="mainTableBoxesCss" Width="100%" ToolTip="Lista de Indicador Gravamen"
                                Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>                       
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                            </td>
                            <td style="width: 20%; text-align: right;">                               
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style=" padding-left: 5px;" colspan="6">
                                <div id="divGridGravamenes" class="panelGridControl">
                                <%--<asp:Panel id="pnlCedulas" runat="server" ScrollBars="Auto" max-height="150px">--%>
                                    <uc5:GridTasadores ID="grdGravamenes" runat="server" />
                                <%--</asp:Panel>--%>
                                </div>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>                        
                    </table>
                    <table id="tblPolizas" style="width:100%;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab6">
                                    <asp:Label ID="lblPolizas" Text="Póliza" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblIndPoliza" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                               <asp:DropDownList id="ddlIndPoliza" runat="server" CssClass="mainTableBoxesCss" Width="100%" ToolTip="Lista de Indicador Póliza"
                                Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>                       
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                            </td>
                            <td style="width: 20%; text-align: right;">                               
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                               <asp:Label ID="lblJustificacion" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtJustificacion" runat="server" CssClass="mainTableBoxesCss" Width="99.3%" ToolTip="Texto Justificación" MaxLength="250" Enabled="false"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvJustificacion" runat="server" ControlToValidate="txtJustificacion" Enabled="false"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style=" padding-left: 5px;" colspan="6">
                                <div id="divGridPolizas" class="panelGridControl">
                                <%--<asp:Panel id="pnlCedulas" runat="server" ScrollBars="Auto" max-height="150px">--%>
                                    <uc5:GridTasadores ID="grdPolizas" runat="server" />
                                <%--</asp:Panel>--%>
                                </div>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>    
                    </table>
                </div>
            </ContentTemplate>            
        </asp:UpdatePanel>
        <br /><br />
        <asp:UpdatePanelAnimationExtender ID="upae" BehaviorID="animation" runat="server" TargetControlID="UpdatePanelControles" Enabled="True">
            <Animations>
                <OnUpdating>
                    <Parallel duration="0">
                        <ScriptAction Script="onUpdating();" />  
                        </Parallel>
                </OnUpdating>
                <OnUpdated>
                    <Parallel duration="0">
                        <ScriptAction Script="onUpdated();" /> 
                    </Parallel> 
                </OnUpdated></Animations>
        </asp:UpdatePanelAnimationExtender>
        <div id="updateProgressDiv" class="overlay" style="display: none">
            <div class="overlay" >
                <div class="overlayContent">
                    <center>
                        <asp:Image ID="Image1" ImageUrl="~/Library/img/MasterGrid/imgLoading.gif" runat="server" />
                        <h2></h2>
                        <h2>Procesando...</h2>
                    </center>
                </div>
            </div>
        </div>

        <asp:Panel runat="server" ID="popupInformar" style="display: none; background-color: #FFFFFF;">
            <uc4:MensajeInformar ID="InformarBox1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBox" runat="server" 
                PopupControlID="popupInformar" 
                TargetControlID="lkbModalInfo" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupInformar2" style="display: none; background-color: #FFFFFF;">
            <uc4:MensajeInformar ID="InformarBox2" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInfo2" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBox2" runat="server" 
                PopupControlID="popupInformar2" 
                TargetControlID="lkbModalInfo2" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupInformar3" style="display: none; background-color: #FFFFFF;">
            <uc4:MensajeInformar ID="InformarBox3" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInfo3" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBox3" runat="server" 
                PopupControlID="popupInformar3" 
                TargetControlID="lkbModalInfo3" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupInformar4" style="display: none; background-color: #FFFFFF;">
            <uc4:MensajeInformar ID="InformarBox4" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInfo4" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBox4" runat="server" 
                PopupControlID="popupInformar4" 
                TargetControlID="lkbModalInfo4" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupInformarBusquedaClaseVehiculo" style="display: none; background-color: #FFFFFF;">
            <uc7:MensajeInformarVentanaBusquedaClaseVehiculo ID="InformarBoxBusquedaClaseVehiculo" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInformarBusquedaClaseVehiculo" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBoxBusquedaClaseVehiculo" runat="server" 
                PopupControlID="popupInformarBusquedaClaseVehiculo" 
                TargetControlID="lkbModalInformarBusquedaClaseVehiculo" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>
        
        <asp:Panel runat="server" ID="popupBusquedaClaseVehiculo" style="display: none; background-color: #FFFFFF; height: 306px; width: 550px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc6:VentaBusquedaClaseVehiculo ID="BusquedaClaseVehiculo" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalBusquedaClaseVehiculo" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeBusquedaClaseVehiculo" runat="server"
                PopupControlID="popupBusquedaClaseVehiculo" 
                TargetControlID="lkbModalBusquedaClaseVehiculo" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupInformarBusquedaEmpresaTasadora" style="display: none; background-color: #FFFFFF;">
            <uc9:MensajeInformarVentanaBusquedaEmpresaTasadora ID="InformarBoxBusquedaEmpresaTasadora" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInformarBusquedaEmpresaTasadora" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBoxBusquedaEmpresaTasadora" runat="server" 
                PopupControlID="popupInformarBusquedaEmpresaTasadora" 
                TargetControlID="lkbModalInformarBusquedaEmpresaTasadora" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupBusquedaEmpresaTasadora" style="display: none; background-color: #FFFFFF; height: 306px; width: 650px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc8:VentaBusquedaEmpresaTasadora  ID="BusquedaEmpresaTasadora" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalBusquedaEmpresaTasadora" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeBusquedaEmpresaTasadora" runat="server"
                PopupControlID="popupBusquedaEmpresaTasadora" 
                TargetControlID="lkbModalBusquedaEmpresaTasadora" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupInformarBusquedaPersonaTasadora" style="display: none; background-color: #FFFFFF;">
            <uc11:MensajeInformarVentanaBusquedaPersonaTasadora ID="InformarBoxBusquedaPersonaTasadora" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInformarBusquedaPersonaTasadora" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBoxBusquedaPersonaTasadora" runat="server" 
                PopupControlID="popupInformarBusquedaPersonaTasadora" 
                TargetControlID="lkbModalInformarBusquedaPersonaTasadora" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupBusquedaPersonaTasadora" style="display: none; background-color: #FFFFFF; height: 306px; width: 650px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc10:VentaBusquedaPersonaTasadora ID="BusquedaPersonaTasadora" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalBusquedaPersonaTasadora" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeBusquedaPersonaTasadora" runat="server"
                PopupControlID="popupBusquedaPersonaTasadora" 
                TargetControlID="lkbModalBusquedaPersonaTasadora" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupCedulasHipotecarias" style="display: none; background-color: #FFFFFF; height: 306px; width: 650px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc12:VentaCedulasHipotecarias ID="CedulasHipotecarias" runat="server" />
            <asp:LinkButton runat="server" ID="lkbCedulasHipotecarias" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeCedulasHipotecarias" runat="server"
                PopupControlID="popupCedulasHipotecarias" 
                TargetControlID="lkbCedulasHipotecarias" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupInformarCedulasHipotecarias" style="display: none; background-color: #FFFFFF;">
            <uc13:MensajeInformarCedulasHipotecarias ID="InformarBoxCedulasHipotecarias" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInformarCedulasHipotecarias" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBoxCedulasHipotecarias" runat="server" 
                PopupControlID="popupInformarCedulasHipotecarias" 
                TargetControlID="lkbModalInformarCedulasHipotecarias" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>      
        
        <asp:Panel runat="server" ID="popupConfirmarActualizar" style="display: none; background-color: #FFFFFF;">
            <uc14:MensajeConfirmar ID="ConfirmarBoxActualizar" runat="server"></uc14:MensajeConfirmar>
            <asp:LinkButton runat="server" ID="lkbModalConfirmarActualizar" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeConfirmarBoxActualizar" runat="server" 
                PopupControlID="popupConfirmarActualizar" 
                TargetControlID="lkbModalConfirmarActualizar" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupAdvertencia" style="display: none; background-color: #FFFFFF;">
            <uc15:MensajeAdvertencia ID="MensajeAdvertencia1" runat="server" />
            <asp:LinkButton runat="server" ID="lblModalAdv" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeAdvertenciaBox" runat="server" 
                PopupControlID="popupAdvertencia" 
                TargetControlID="lblModalAdv" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <%--GRAVAMENES GARANTIAS--%>
        <asp:Panel runat="server" ID="popupGravamenesGarantias" style="display: none; background-color: #FFFFFF; height: 306px; width: 650px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc16:VentaGravamenGarantia ID="VentanaGravamenesGarantias1" runat="server"/>
            <asp:LinkButton runat="server" ID="lkbGravamenesGarantias" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeGravamenesGarantias" runat="server"
                PopupControlID="popupGravamenesGarantias" 
                TargetControlID="lkbGravamenesGarantias" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

       <asp:Panel runat="server" ID="popupConfirmarEliminarGravamenes" style="display: none; background-color: #FFFFFF;">
            <uc3:MensajeEliminar ID="MensajeConfirmarEliminarGravamenes1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbConfirmarEliminarGravamenes" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeConfirmarEliminarGravamenes" runat="server" 
                PopupControlID="popupConfirmarEliminarGravamenes" 
                TargetControlID="lkbConfirmarEliminarGravamenes" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

         <%--POLIZAS GARANTIAS--%>
        <asp:Panel runat="server" ID="popupPolizasGarantias" style="display: none; background-color: #FFFFFF; height: 506px; width: 650px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc17:VentaPolizaGarantia ID="VentanaPolizasGarantia1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbPolizasGarantias" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpePolizasGarantias" runat="server"
                PopupControlID="popupPolizasGarantias" 
                TargetControlID="lkbPolizasGarantias" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupConfirmarEliminarPolizas" style="display: none; background-color: #FFFFFF;">
            <uc3:MensajeEliminar ID="MensajeConfirmarEliminarPolizas1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbConfirmarEliminarPolizas" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeConfirmarEliminarPolizas" runat="server" 
                PopupControlID="popupConfirmarEliminarPolizas" 
                TargetControlID="lkbConfirmarEliminarPolizas" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

    </div>
</asp:Content>
