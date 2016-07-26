<%@ page language="C#" autoeventwireup="true" masterpagefile="~/Library/styles/MasterPages/SubMain.Master" inherits="MobiliariaRealesNew, App_Web_5tyb04lu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Reference Control="~/Library/controls/wucMenuLateralDetalle.ascx" %>
<%@ Reference Control="~/Library/controls/wucMenuSuperiorDetalle.ascx" %>
<%@ Register Src="~/Library/controls/wucMensajeEliminar.ascx" TagName="MensajeEliminar"
    TagPrefix="uc3" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformar"
    TagPrefix="uc4" %>
<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" TagName="VentaBusquedaClaseVehiculo"
    TagPrefix="uc6" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformarVentanaBusquedaClaseVehiculo"
    TagPrefix="uc7" %>
<%@ Register Src="~/Library/controls/wucMensajeConfirmar.ascx" TagName="MensajeConfirmar"
    TagPrefix="uc14" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeAdvertencia"
    TagPrefix="uc15" %>
<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" TagName="VentaBusquedaClaseOperacion"
    TagPrefix="uc16" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformarVentanaBusquedaClaseOperacion"
    TagPrefix="uc17" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="Server">
    <title>Detalle</title>
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterSubMain.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MensajePopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/ModalPopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css" />
    <script src="../../Library/scripts/Procesando.js" language="javascript" type="text/javascript"></script>
    <script src="../../Library/scripts/TextBox.js" language="javascript" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--CAMBIAR SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" clientidmode="Static" />
    <input type="hidden" id="codUsuarioOculto" runat="server" clientidmode="Static" />
    <input type="hidden" id="pantallaIdOculto" runat="server" clientidmode="Static" />
    <input type="hidden" id="pantallaTituloOculto" runat="server" clientidmode="Static" />
    <input type="hidden" id="pantallaModuloOculto" runat="server" clientidmode="Static" />
    <input type="hidden" id="pantallaNombreOculto" runat="server" clientidmode="Static" />
    <div id="body" class="body">
        <asp:UpdatePanel ID="UpdatePanelControles" runat="server" UpdateMode="Always">
            <ContentTemplate>
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
                                <div id="Generales">
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
                    <table id="tblGenerales" style="width: 100%;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab1">
                                    <asp:Label ID="lblGenerales" Text="Generales" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblTipoBien" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlTipoBien" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static"
                                    Width="100%" ToolTip="Lista de Tipo Bien" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <%--    <td colspan="5">
                                <asp:DropDownList ID="ddlTipoBien" runat="server" CssClass="mainTableBoxesCss"
                                    ClientIDMode="Static" Width="100%" ToolTip="Lista de Tipo Bien" TabIndex="1"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </td>--%>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblClase" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlClase" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static"
                                    AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged"
                                    TabIndex="2" ToolTip="Lista de Clase" Width="100%">
                                </asp:DropDownList>
                                <%--<asp:DropDownList ID="ddlClase" runat="server" CssClass="mainTableBoxesCss"
                                    ClientIDMode="Static" AutoPostBack="true" TabIndex="2" ToolTip="Lista de Clase"
                                    Width="100%">
                                </asp:DropDownList>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblClaseVehiculo" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5" style="vertical-align: middle;">
                                <asp:TextBox ID="txtClaseVehiculo" runat="server" CssClass="mainTableBoxesCss" MaxLength="4"
                                    TabIndex="3" ToolTip="Valor Vehículo" Width="120"></asp:TextBox>
                                <asp:Button ID="btnClaseVehiculo" runat="server" CssClass="imgCmdBuscar" TabIndex="4"
                                    Enabled="true" CausesValidation="false" ToolTip="Click para ejecutar la búsqueda"
                                    OnClick="btnClaseVehiculo_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblclasev" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnIdClaseVehiculo" runat="server" />
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDesClaseVehiculo" runat="server" CssClass="mainTableBoxesCss"
                                    Enabled="false" TabIndex="5" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 3%;">
                                <asp:RequiredFieldValidator ID="rfvDesClaseVehiculo" ValidationGroup="General" runat="server"
                                    ControlToValidate="txtDesClaseVehiculo" ErrorMessage=" * " CssClass="labelTabError"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblFormato" runat="server" CssClass="blackLabel" Text="Formato Identificación Vehículo"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlFormato" runat="server" CssClass="mainTableBoxesCss" AutoPostBack="true"
                                    ClientIDMode="Static" TabIndex="6" ToolTip="Lista de Formato Identificación Vehículo"
                                    Width="100%" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged">
                                </asp:DropDownList>
                                <%--   <asp:DropDownList ID="DropDownList1" runat="server" CssClass="mainTableBoxesCss"
                                    AutoPostBack="true" ClientIDMode="Static" TabIndex="6" ToolTip="Lista de Formato Identificación Vehículo"
                                    Width="100%">
                                </asp:DropDownList>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblNBien" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtNBien" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static"
                                    MaxLength="17" TabIndex="7" ToolTip="Texto N° Bien" Width="150"></asp:TextBox>
                            </td>
                            <td style="width: 3%;">
                                <asp:RequiredFieldValidator ID="rfvNBien" runat="server" ControlToValidate="txtNBien"
                                    ErrorMessage=" * " CssClass="labelTabError" ValidationGroup="General" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblIdGeneral" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnIdGeneral" runat="server" />
                            </td>
                            <td style="width: 20%; text-align: right;">
                                <asp:Button ID="btnConsultar" runat="server" CssClass="botonValidar" ValidationGroup="General"
                                    TabIndex="8" ToolTip="Consultar Sección General" OnClick="btnConsultar_Click" />
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <%--    <asp:Label ID="lblTipoOperacion" runat="server" CssClass="blackLabel"></asp:Label>--%>
                            </td>
                            <td>
                                <%-- <asp:DropDownList ID="ddlTipoOperacion" runat="server" CssClass="mainTableBoxesCss"
                                    ClientIDMode="Static" Width="100%" ToolTip="Lista de Tipo Operación" TabIndex="9"
                                    AutoPostBack="true">
                                </asp:DropDownList>--%>
                            </td>
                            <%--    <td colspan="5">
                                <asp:DropDownList id="DropDownList5" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static" 
                                    Width="100%" ToolTip="Lista de Tipo Operación" TabIndex="1" AutoPostBack="true"
                                    onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </td>--%>
                        </tr>
                    </table>
                    <table id="tblDetalleRelacion" style="width: 100%;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab2">
                                    <asp:Label ID="lblDetalleRelacion" Text="Detalle Relación" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblContabilidad" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtContabilidad" runat="server" CssClass="mainTableBoxesCss" Enabled="false"
                                    TabIndex="10" Width="99.5%"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                                <asp:HiddenField ID="hdnIdOperacion" runat="server" />
                            </td>
                            <td style="width: 20%">
                                <asp:HiddenField ID="hdnIdClaseOperacion" runat="server" />
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblOficina" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtOficina" runat="server" CssClass="mainTableBoxesCss" Enabled="false"
                                    TabIndex="11" Width="99.5%"></asp:TextBox>
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
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblMoneda" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtMoneda" runat="server" CssClass="mainTableBoxesCss" Enabled="false"
                                    TabIndex="12" Width="99.5%"></asp:TextBox>
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
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblProducto" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtProducto" runat="server" CssClass="mainTableBoxesCss" Enabled="false"
                                    TabIndex="13" Width="99.5%"></asp:TextBox>
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
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblNumero" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtNumero" runat="server" CssClass="mainTableBoxesCss" Enabled="false"
                                    TabIndex="14" Width="99.5%"></asp:TextBox>
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
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblIdentificacionCliente" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtIdentificacionCliente" runat="server" CssClass="mainTableBoxesCss"
                                    Enabled="false" TabIndex="15" Width="99.5%"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%; padding-left: 5px;">
                            </td>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblNombreCliente" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="mainTableBoxesCss" Enabled="false"
                                    TabIndex="17" Width="99.5%"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblClaseGarantia" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtClaseGarantia" runat="server" CssClass="mainTableBoxesCss" Enabled="false"
                                    TabIndex="16" Width="99.5%"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%; padding-left: 5px;">
                            </td>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                            </td>
                        </tr>
                    </table>
                    <table id="tblDatosAdiciones" style="width: 100%;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab3">
                                    <asp:Label ID="lblDatosAdicionales" Text="Datos Adicionales" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblConsecutivo" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtConsecutivoSegI" runat="server" CssClass="mainTableBoxesCss"
                                    Enabled="false" TabIndex="18" Text="GM" Width="13%"></asp:TextBox>
                                <asp:Label ID="lblDivisionI" Text="-" runat="server" CssClass="blackLabel"></asp:Label>
                                <asp:TextBox ID="txtConsecutivoSegII" runat="server" AutoPostBack="true" CssClass="mainTableBoxesCss"
                                    OnTextChanged="TextBox_TextChanged" Enabled="false" TabIndex="19" Width="35%"></asp:TextBox>
                                <asp:MaskedEditExtender ID="mskConsecutivoSegII" InputDirection="RightToLeft" runat="server"
                                    TargetControlID="txtConsecutivoSegII" MaskType="Number" AutoComplete="false"
                                    Mask="9999999">
                                </asp:MaskedEditExtender>
                                <asp:Label ID="lblDivisionII" Text="-" runat="server" CssClass="blackLabel"></asp:Label>
                                <asp:TextBox ID="txtConsecutivoSegIII" runat="server" AutoPostBack="true" OnTextChanged="TextBox_TextChangedSegIII"
                                    CssClass="mainTableBoxesCss" Enabled="false" ToolTip="4 Enteros" TabIndex="20"
                                    Width="26%"></asp:TextBox>
                                <asp:MaskedEditExtender ID="mskConsecutivoSegIII" InputDirection="RightToLeft" runat="server"
                                    TargetControlID="txtConsecutivoSegIII" MaskType="Number" AutoComplete="false"
                                    Mask="9999">
                                </asp:MaskedEditExtender>
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvConsecutivo" runat="server" ControlToValidate="txtConsecutivoSegII"
                                    ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblFechaPublicacion" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <%--    <div style="position: relative;">--%>
                                <asp:TextBox ID="txtFechaPublicacion" Style="width: 69%" runat="server" CssClass="mainTableBoxesCss"
                                    Width="105" ToolTip="Calendario Fecha Publicación" TabIndex="21"></asp:TextBox>
                                <asp:ImageButton ID="imbFechaPublicacion" TabIndex="22" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif"
                                    ImageAlign="AbsMiddle" CausesValidation="false" />
                                <asp:CalendarExtender ID="calendarExtenderFechaPublicacion" runat="server" PopupButtonID="imbFechaPublicacion"
                                    PopupPosition="Left" TargetControlID="txtFechaPublicacion">
                                </asp:CalendarExtender>
                                <%--  </div>--%>
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvFechaPublicacion" runat="server" ControlToValidate="txtFechaPublicacion"
                                    ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblVIN" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtVIN" runat="server" CssClass="mainTableBoxesCss" Enabled="false"
                                    MaxLength="17" TabIndex="23" Width="99.5%"></asp:TextBox>
                            </td>
                            <td style="width: 3%">
                                <asp:RequiredFieldValidator ID="rfvVIN" runat="server" ControlToValidate="txtVIN"
                                    ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblMotor" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtMotor" runat="server" CssClass="mainTableBoxesCss" Enabled="false"
                                    MaxLength="17" TabIndex="24" Width="98%"></asp:TextBox>
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvMotor" runat="server" ControlToValidate="txtMotor"
                                    ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="2000" CssClass="mainTableBoxesCss"
                                    Enabled="false" TabIndex="25" Width="99.5%"></asp:TextBox>
                            </td>
                            <td style="width: 3%;">
                                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion"
                                    ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                            </td>
                            <td style="width: 20%">
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
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                            </td>
                            <td style="width: 20%">
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:UpdatePanelAnimationExtender ID="upae" BehaviorID="animation" runat="server"
            TargetControlID="UpdatePanelControles" Enabled="True">
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
                </OnUpdated>
            </Animations>
        </asp:UpdatePanelAnimationExtender>
        <div id="updateProgressDiv" class="overlay" style="display: none">
            <div class="overlay">
                <div class="overlayContent">
                    <center>
                        <asp:Image ID="Image1" ImageUrl="~/Library/img/MasterGrid/imgLoading.gif" runat="server" />
                        <h2>
                        </h2>
                        <h2>
                            Procesando...</h2>
                    </center>
                </div>
            </div>
        </div>
        <asp:Panel runat="server" ID="popupInformar" Style="display: none; background-color: #FFFFFF;">
            <uc4:MensajeInformar ID="InformarBox1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBox" runat="server" PopupControlID="popupInformar"
                TargetControlID="lkbModalInfo" BackgroundCssClass="modalBackground" DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll" />
        </asp:Panel>
        <asp:Panel runat="server" ID="popupInformarBusquedaClaseVehiculo" Style="display: none;
            background-color: #FFFFFF;">
            <uc7:MensajeInformarVentanaBusquedaClaseVehiculo ID="InformarBoxBusquedaClaseVehiculo"
                runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInformarBusquedaClaseVehiculo" CssClass="modalPopup"
                Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBoxBusquedaClaseVehiculo" runat="server" PopupControlID="popupInformarBusquedaClaseVehiculo"
                TargetControlID="lkbModalInformarBusquedaClaseVehiculo" BackgroundCssClass="modalBackground"
                DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll" />
        </asp:Panel>
        <asp:Panel runat="server" ID="popupBusquedaClaseVehiculo" Style="display: none; background-color: #FFFFFF;
            height: 306px; width: 550px; border-width: 3px; border-color: Black; border-style: solid;">
            <uc6:VentaBusquedaClaseVehiculo ID="BusquedaClaseVehiculo" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalBusquedaClaseVehiculo" CssClass="modalPopup"
                Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeBusquedaClaseVehiculo" runat="server" PopupControlID="popupBusquedaClaseVehiculo"
                TargetControlID="lkbModalBusquedaClaseVehiculo" BackgroundCssClass="modalBackground"
                DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll" />
        </asp:Panel>
        <asp:Panel runat="server" ID="popupConfirmarActualizar" Style="display: none; background-color: #FFFFFF;">
            <uc14:MensajeConfirmar ID="ConfirmarBoxActualizar" runat="server"></uc14:MensajeConfirmar>
            <asp:LinkButton runat="server" ID="lkbModalConfirmarActualizar" CssClass="modalPopup"
                Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeConfirmarBoxActualizar" runat="server" PopupControlID="popupConfirmarActualizar"
                TargetControlID="lkbModalConfirmarActualizar" BackgroundCssClass="modalBackground"
                DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll" />
        </asp:Panel>
        <asp:Panel runat="server" ID="popupAdvertencia" Style="display: none; background-color: #FFFFFF;">
            <uc15:MensajeAdvertencia ID="MensajeAdvertencia1" runat="server" />
            <asp:LinkButton runat="server" ID="lblModalAdv" CssClass="modalPopup" Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeAdvertenciaBox" runat="server" PopupControlID="popupAdvertencia"
                TargetControlID="lblModalAdv" BackgroundCssClass="modalBackground" DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll" />
        </asp:Panel>
        <asp:Panel runat="server" ID="popupBusquedaClaseOperacion" Style="display: none;
            background-color: #FFFFFF; height: 306px; width: 550px; border-width: 3px; border-color: Black;
            border-style: solid;">
            <uc16:VentaBusquedaClaseOperacion ID="BusquedaClaseOperacion" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalBusquedaClaseOperacion" CssClass="modalPopup"
                Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeBusquedaClaseOperacion" runat="server" PopupControlID="popupBusquedaClaseOperacion"
                TargetControlID="lkbModalBusquedaClaseOperacion" BackgroundCssClass="modalBackground"
                DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll" />
        </asp:Panel>
        <asp:Panel runat="server" ID="popupInformarBusquedaClaseOperacion" Style="display: none;
            background-color: #FFFFFF;">
            <uc17:MensajeInformarVentanaBusquedaClaseOperacion ID="InformarBoxBusquedaClaseOperacion"
                runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInformarBusquedaClaseOperacion" CssClass="modalPopup"
                Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBoxBusquedaClaseOperacion" runat="server"
                PopupControlID="popupInformarBusquedaClaseOperacion" TargetControlID="lkbModalInformarBusquedaClaseOperacion"
                BackgroundCssClass="modalBackground" DropShadow="false" RepositionMode="RepositionOnWindowResizeAndScroll" />
        </asp:Panel>
    </div>
</asp:Content>
