<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Library/styles/MasterPages/SubMain.Master" CodeFile="InscripcionRealesNew.aspx.cs" Inherits="InscripcionRealesNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Reference Control="~/Library/controls/wucMenuLateralDetalle.ascx" %>
<%@ Reference Control="~/Library/controls/wucMenuSuperiorDetalle.ascx" %>

<%@ Register Src="~/Library/controls/wucMensajeEliminar.ascx" tagname="MensajeEliminar" tagprefix="uc3" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformar" tagprefix="uc4" %>

<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" tagname="VentaBusquedaClaseVehiculo" tagprefix="uc6" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarVentanaBusquedaClaseVehiculo" tagprefix="uc7" %>

<%@ Register Src="~/Library/controls/wucMensajeConfirmar.ascx" tagname="MensajeConfirmar" tagprefix="uc14" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeAdvertencia" tagprefix="uc15" %>

<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" tagname="VentaBusquedaClaseOperacion" tagprefix="uc16" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarVentanaBusquedaClaseOperacion" tagprefix="uc17" %>

<%@ Register Src="~/Library/controls/wucGridEmergente.ascx" tagname="VentaBusquedaClaseNotario" tagprefix="uc18" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformarVentanaBusquedaClaseNotario" tagprefix="uc19" %>

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
                            </tr>
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
                            </tr>
                        <tr> 
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblClaseVehiculo" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5" style="vertical-align: middle;">
                                <asp:TextBox ID="txtClaseVehiculo" runat="server" CssClass="mainTableBoxesCss" 
                                    MaxLength="4" TabIndex="8" ToolTip="Valor Vehículo" Width="120"></asp:TextBox>
                                <asp:Button ID="btnClaseVehiculo" runat="server" CssClass="imgCmdBuscar" TabIndex="9" Enabled="false" CausesValidation="false" ToolTip="Click para ejecutar la búsqueda" OnClick="btnClaseVehiculo_Click"/>
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
                                <asp:Button ID="btnConsultar" runat="server" CssClass="botonValidar"  TabIndex="13" ToolTip="Consultar Sección General" onclick="btnConsultar_Click" />
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                    </table>
                <table id="tblDetalleRelacion" style="width:100%;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab2">
                                    <asp:Label ID="lblDetalleRelacion" Text="Detalle Relación" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblContabilidad" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtContabilidad" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="15" Width="99.5%"></asp:TextBox>
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
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblOficina" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtOficina" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="15" Width="99.5%"></asp:TextBox>
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
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblMoneda" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtMoneda" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="16" Width="99.5%"></asp:TextBox>
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
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblProducto" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtProducto" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="17" Width="99.5%"></asp:TextBox>
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
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblNumero" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtNumero" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="18" Width="99.5%"></asp:TextBox>
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
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblIdentificacionCliente" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtIdentificacionCliente" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="19" Width="99.5%"></asp:TextBox>
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
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblNombreCliente" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%" colspan = "5">
                                <asp:TextBox ID="txtNombreCliente" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="20" Width="99%"></asp:TextBox>
                            </td>
                            <%--<td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 25%">
                            </td>
                            <td style="width: 20%">
                            </td>--%>
                            <td style="width: 3%">
                            </td>
                            
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblClaseGarantia" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtClaseGarantia" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="21" Width="99.5%"></asp:TextBox>
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
                <table id="tblDatosAdicionales">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab3">
                                    <asp:Label ID="lblDatosAdicionales" Text="Datos Adicionales" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
     
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblIndInscripcion" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:DropDownList id="ddlIndInscripcion" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static" 
                                 Width="150" ToolTip="Lista de Ind. Inscripcion" TabIndex="22" AutoPostBack="true"
                                 onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>                          
                            </td>
                            <td style="width: 3%">
                            </td> 
                            <td style="width: 3%">
                            </td> 
                                                 
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblFechaAnotacion" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td style="width: 20%">
                            <div style="position:relative;" >
                                <asp:TextBox ID="txtFechaAnotacion" style="width:69%" runat="server" CssClass="mainTableBoxesCss" Width="105" ToolTip="Calendario Fecha Anotación"
                                TabIndex="23"></asp:TextBox>
                                <asp:ImageButton ID="imbFechaAnotacion" TabIndex="24" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                <asp:CalendarExtender ID="calendarExtenderFechaAnotacion" runat="server" PopupButtonID="imbFechaAnotacion" PopupPosition="TopLeft" TargetControlID="txtFechaAnotacion"></asp:CalendarExtender> 
                           </div>
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvFechaAnotacion" runat="server" ControlToValidate="txtFechaAnotacion"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                           
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblFechaInscripcion" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td style="width: 20%">
                             <div style="position:relative;" >
                                <asp:TextBox ID="txtFechaInscripcion" style="width:70%" runat="server" CssClass="mainTableBoxesCss" Width="105" ToolTip="Calendario Fecha Inscripción"
                                TabIndex="24"></asp:TextBox>
                                <asp:ImageButton ID="imbFechaInscripcion"  TabIndex="24" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                <asp:CalendarExtender ID="calendarExtenderFechaInscripcion" runat="server" PopupButtonID="imbFechaInscripcion" PopupPosition="TopLeft" TargetControlID="txtFechaInscripcion"></asp:CalendarExtender> 
                              </div>
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvFechaInscripcion" runat="server" ControlToValidate="txtFechaInscripcion"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                             <td style="width: 3%">
                            </td>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblPartido" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                 <asp:DropDownList id="ddlPartido" runat="server" CssClass="mainTableBoxesCss" Width="150" ToolTip="Lista de Partido" TabIndex="25" Enabled="false"></asp:DropDownList>
                            </td>
                             <td style="width: 3%">
                            </td>
                             
                        </tr>
                        <tr>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblTomo" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                <asp:TextBox ID="txtTomo" runat="server" AutoPostBack = "true" OnTextChanged="TextBox_TextChanged"  
                                 CssClass="mainTableBoxesCss" Enabled="True" TabIndex="26" Width="99.5%"></asp:TextBox>
                                 <asp:MaskedEditExtender ID="mskTomo" InputDirection = "RightToLeft" runat="server"  TargetControlID="txtTomo"
                                 MaskType="Number" AutoComplete = "false" Mask="99999" ></asp:MaskedEditExtender>
                            </td>                                                    
                           <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvTomo" runat="server" ControlToValidate="txtTomo"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                               <td style="width: 3%">
                            </td>
                            </td>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblFolio" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                <asp:TextBox ID="txtFolio" runat="server" AutoPostBack = "true" OnTextChanged="TextBox_TextChanged" 
                                 CssClass="mainTableBoxesCss" Enabled="True" TabIndex="27" Width="99.5%"></asp:TextBox>
                                 <asp:MaskedEditExtender ID="mskFolio" InputDirection = "RightToLeft"  runat="server"  TargetControlID="txtFolio"
                                 MaskType="Number" AutoComplete = "false" Mask="9999" ></asp:MaskedEditExtender>
                            </td>
                             <td style="width: 3%; padding-left: 5px;"">
                               <asp:RequiredFieldValidator ID="rfvFolio" runat="server" ControlToValidate="txtFolio"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                               <td style="width: 3%">
                            </td>
                          
                        </tr>
                        <tr>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblAsiento" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                <asp:TextBox ID="txtAsiento" runat="server" AutoPostBack = "true" OnTextChanged="TextBox_TextChanged" 
                                 CssClass="mainTableBoxesCss" Enabled="True" TabIndex="28" Width="99.5%"></asp:TextBox>
                                 <asp:MaskedEditExtender ID="mskAsiento" InputDirection = "RightToLeft"  runat="server"  TargetControlID="txtAsiento"
                                MaskType="Number" AutoComplete = "false" Mask="999999" ></asp:MaskedEditExtender>
                            </td>
                           <td style="width: 3%; padding-left: 5px;"">
                               <asp:RequiredFieldValidator ID="rfvAsiento" runat="server" ControlToValidate="txtAsiento"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                              </td>
                             <td style="width: 3%">
                            </td>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblSecuencia" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                <asp:TextBox ID="txtSecuencia" runat="server" AutoPostBack = "true" OnTextChanged="TextBox_TextChanged" 
                                 CssClass="mainTableBoxesCss" Enabled="True" TabIndex="29" Width="99.5%"></asp:TextBox>
                                  <asp:MaskedEditExtender ID="mskSecuencia" InputDirection = "RightToLeft" runat="server"  TargetControlID="txtSecuencia"
                                MaskType="Number" AutoComplete = "false" Mask="9999" ></asp:MaskedEditExtender>
                            </td>
                           <td style="width: 3%; padding-left: 5px;"">
                              <%-- <asp:RequiredFieldValidator ID="rfvSecuencia" runat="server" ControlToValidate="txtSecuencia"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                              </td>
                            
                        </tr>
                        <tr>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblSubSecuencia" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                <asp:TextBox ID="txtSubSecuencia" runat="server" AutoPostBack = "true" OnTextChanged="TextBox_TextChanged" 
                                 CssClass="mainTableBoxesCss" Enabled="True" TabIndex="30" Width="99.5%"></asp:TextBox>
                                  <asp:MaskedEditExtender ID="mskSubSecuencia" InputDirection = "RightToLeft" runat="server"  TargetControlID="txtSubSecuencia"
                                MaskType="Number" AutoComplete = "false" Mask="999" ></asp:MaskedEditExtender>
                            </td>
                           <td style="width: 3%; padding-left: 5px;"">
                            <%--   <asp:RequiredFieldValidator ID="rfvSubSecuencia" runat="server" ControlToValidate="txtSubSecuencia"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                              </td>
                             <td style="width: 3%">
                            </td>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblConsecutivo" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                <asp:TextBox ID="txtConsecutivo" runat="server" AutoPostBack = "true" OnTextChanged="TextBox_TextChanged"  
                                 CssClass="mainTableBoxesCss" Enabled="True" TabIndex="29" Width="99.5%"></asp:TextBox>
                                  <asp:MaskedEditExtender ID="mskConsecutivo" InputDirection = "RightToLeft"  runat="server"  TargetControlID="txtConsecutivo"
                                MaskType="Number" AutoComplete = "false" Mask="99999" ></asp:MaskedEditExtender>
                            </td>
                           <td style="width: 3%; padding-left: 5px;"">
                              <%-- <asp:RequiredFieldValidator ID="rfvConsecutivo" runat="server" ControlToValidate="txtConsecutivo"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                              </td>
                            
                        </tr>                                               
  
                        <tr>
                            <td style=" padding-left: 5px; height:40px; " colspan="2">
                                <asp:Label ID="lblAbogadoAsignado" runat="server" CssClass="blackBoldLabel"></asp:Label>
                            </td>
                             <td style="width: 3%">
                            </td>
                            <td style="width: 3%">
                            </td>
                             <td style="width: 3%">
                            </td>
                             <td style="width: 3%">
                            </td>
                             <td style="width: 3%">
                            </td>               
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblValorConsultar" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtValorConsultarAbogado" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="True" TabIndex="30" Width="99.5%"></asp:TextBox>
                                 <asp:MaskedEditExtender ID="mskValorConsultarAbogado" AutoComplete="false" InputDirection = "RightToLeft"  runat="server"  TargetControlID="txtValorConsultarAbogado"
                                MaskType="Number"  Mask="999999999999" ></asp:MaskedEditExtender>
                             </td> 
                            <td style="width: 3%;padding-left: 5px;">
                             <asp:Button ID="imbValorConsultar" runat="server" CssClass="imgCmdBuscar" Enabled="True" CausesValidation="false" ToolTip="Click para ejecutar la búsqueda" OnClick="btnClaseConsultarNotario_Click"/>
                            </td>
                             <td style="width: 3%">
                            </td>
                            <td style="width: 25%;">
                              
                            </td>
                            <td style="width: 20%"> 
                                <asp:HiddenField ID="hdnIdClaseNotario" runat="server" /> 
                                <asp:Label ID="lblIdClaseNotario" runat="server"></asp:Label> 
                            </td>
                            <td style="width: 3%;">
                            </td>
                           
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblTipoIdentificacion" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%" colspan = "5">
                                <asp:TextBox ID="txtTipoIdentificacion" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="31" Width="99%"></asp:TextBox>
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvTipoIdentificacion" runat="server" ControlToValidate="txtTipoIdentificacion"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblIdentificacion" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtIdentificacion" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="32" Width="99.5%"></asp:TextBox>
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvIdentificacion" runat="server" ControlToValidate="txtIdentificacion"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
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
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblNombre" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%" colspan = "5">
                                <asp:TextBox ID="txtNombre" runat="server" 
                                 CssClass="mainTableBoxesCss" Enabled="false" TabIndex="33" Width="99%"></asp:TextBox>
                            </td>
                             <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            
                        </tr>                   
                        <tr>
                            <td style="width: 25%;";>
                            </td>
                            <td style="width: 20%">
                            </td>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 3%; ">
                            </td>
                            <td style="width: 25%">
                            </td>
                            <td style="width: 20%;height:20px;text-align: right;">
                            <asp:Button ID="btnLimpiar" runat="server" CssClass="botonLimpiar" CausesValidation="false" ToolTip="Limpiar Sección Abogados" OnClick="btnLimpiar_Click" />                        
                            </td>
                            <td style="width: 3%">
                            </td>                          
                         </tr>                     
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblComentario" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%" colspan = "5">
                                <asp:TextBox ID="txtComentario" runat="server" MaxLength = "45"
                                 CssClass="mainTableBoxesCss" Enabled="True" TabIndex="35" Width="99%"></asp:TextBox>
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
                </OnUpdated>
            </Animations>
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

        <asp:Panel runat="server" ID="popupBusquedaClaseOperacion" style="display: none; background-color: #FFFFFF; height: 306px; width: 550px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc16:VentaBusquedaClaseOperacion ID="BusquedaClaseOperacion" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalBusquedaClaseOperacion" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeBusquedaClaseOperacion" runat="server"
                PopupControlID="popupBusquedaClaseOperacion" 
                TargetControlID="lkbModalBusquedaClaseOperacion" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <asp:Panel runat="server" ID="popupInformarBusquedaClaseOperacion" style="display: none; background-color: #FFFFFF;">
            <uc17:MensajeInformarVentanaBusquedaClaseOperacion ID="InformarBoxBusquedaClaseOperacion" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInformarBusquedaClaseOperacion" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBoxBusquedaClaseOperacion" runat="server" 
                PopupControlID="popupInformarBusquedaClaseOperacion" 
                TargetControlID="lkbModalInformarBusquedaClaseOperacion" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

         <asp:Panel runat="server" ID="popupBusquedaClaseNotario" style="display: none; background-color: #FFFFFF; height: 306px; width: 550px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc18:VentaBusquedaClaseNotario ID="BusquedaClaseNotario" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalBusquedaClaseNotario" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeBusquedaClaseNotario" runat="server"
                PopupControlID="popupBusquedaClaseNotario" 
                TargetControlID="lkbModalBusquedaClaseNotario" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
            </asp:Panel>

            <asp:Panel runat="server" ID="popupInformarBusquedaClaseNotario" style="display: none; background-color: #FFFFFF;">
            <uc19:MensajeInformarVentanaBusquedaClaseNotario ID="InformarBoxBusquedaClaseNotario" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInformarBusquedaClaseNotario" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBoxBusquedaClaseNotario" runat="server" 
                PopupControlID="popupInformarBusquedaClaseNotario" 
                TargetControlID="lkbModalInformarBusquedaClaseNotario" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>
        
    </div>

</asp:Content>