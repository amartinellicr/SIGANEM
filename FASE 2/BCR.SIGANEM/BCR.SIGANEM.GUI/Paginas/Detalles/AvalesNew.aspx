<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Library/styles/MasterPages/SubMain.Master" CodeFile="AvalesNew.aspx.cs" Inherits="AvalesNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Reference Control="~/Library/controls/wucMenuLateralDetalle.ascx" %>
<%@ Reference Control="~/Library/controls/wucMenuSuperiorDetalle.ascx" %>

<%@ Register Src="~/Library/controls/wucMensajeEliminar.ascx" tagname="MensajeEliminar" tagprefix="uc3" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformar" tagprefix="uc4" %>

<%@ Register Src="~/Library/controls/wucMensajeConfirmar.ascx" tagname="MensajeConfirmar" tagprefix="uc14" %>

<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeAdvertencia" tagprefix="uc15" %>

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
                <table id="tblGeneral" style="width:100%; border-collapse:collapse;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab1">
                                    <asp:Label ID="lblGeneral" Text="Datos Generales" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>                    
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblTipoAval" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:DropDownList id="ddlTipoAval" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static" 
                                    Width="96%" ToolTip="Lista de Tipo Aval" TabIndex="1" AutoPostBack="true"
                                    onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>                    
                        <tr>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblTipoPersonaAvalista" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                    <asp:TextBox ID="txtTipoPersonaAvalista" runat="server" 
                                    CssClass="mainTableBoxesCss" Enabled="false" TabIndex="2" Width="97%"></asp:TextBox>
                            </td>                                                    
                           <td style="width: 3%; padding-left: 5px;"></td>
                           <td style="width: 3%"></td>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblIdAvalista" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                <asp:TextBox ID="txtIdAvalista" runat="server" AutoPostBack = "true" CssClass="mainTableBoxesCss" Enabled="false" TabIndex="3" Width="97%"></asp:TextBox>                                
                            </td>
                           <td style="width: 3%; padding-left: 5px;">   
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIdAvalista"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                           </td>                         
                        </tr>                                              
                </table> 
                                         
                <table id="tblbDetalleGarantiasAvales" style="width:100%;  border-collapse:collapse;">
                    <tr>
                        <td style="height: 29px" colspan="7">
                            <div id="ctl00_ContentPlaceHolder1_Tab2">
                                    <asp:Label ID="lblDetalleGarantiasAvales" Text="Detalle Garantías Avales" runat="server" CssClass="labelSub"></asp:Label>
                            </div>
                        </td>
                    </tr> 
                    <tr>
                        <td style="width: 25%; padding-left: 5px;">
                            <asp:Label ID="lblNumeroAval" runat="server" CssClass="blackLabel"></asp:Label>
                        </td>
                        <td style="width: 20%">
                             <asp:TextBox ID="txtNumeroAval" runat="server" AutoPostBack = "true" CssClass="mainTableBoxesCss" Enabled="True" TabIndex="4" 
                                 Width="97%" OnTextChanged="txtNumeroAval_TextChanged"></asp:TextBox> 
                        </td>                                                    
                        <td style="width: 3%; padding-left: 5px;">
                            <asp:RequiredFieldValidator ID="rfvNumeroAval" runat="server" ControlToValidate="txtNumeroAval"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 3%">
                            <asp:Label ID="lblIdGeneral" runat="server"></asp:Label>
                            <asp:HiddenField ID="hdnIdGeneral" runat="server" />
                        </td>
                        <td style="width: 25%; padding-left: 5px;">
                            <asp:Label ID="lblMontoAvalado" runat="server" CssClass="blackLabel"></asp:Label>  
                        </td>
                        <td style="width: 20%">
                            <asp:TextBox ID="txtMontoAvalado" runat="server" AutoPostBack = "true" CssClass="mainTableBoxesCss" Enabled="True" TabIndex="5" Width="97%"></asp:TextBox>  
                            <asp:MaskedEditExtender ID="mskMontoAvalado" runat="server" InputDirection="RightToLeft" TargetControlID="txtMontoAvalado"
                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="99,999,999,999,999,999,999.99" ></asp:MaskedEditExtender>                                                                          
                        </td>
                        <td style="width: 3%; padding-left: 5px;">   
                            <asp:RequiredFieldValidator ID="rfvMontoAvalado" runat="server" ControlToValidate="txtMontoAvalado"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>                         
                    </tr> 
                    <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblIdGarantiaBCR" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">                            
                                 <asp:TextBox ID="txtIdGarantiaBCR" runat="server" AutoPostBack = "true" CssClass="mainTableBoxesCss" Enabled="false" TabIndex="6" Width="97%"></asp:TextBox>                                                                                                                
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                            </td> 
                            <td style="width: 3%"></td>                                                
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblFechaEmision" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td style="width: 20%">                       
                              <div style="position:relative;" >
                                <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="mainTableBoxesCss" Width="102px" ToolTip="Calendario Fecha Emisión" TabIndex="7"></asp:TextBox>
                                <asp:ImageButton ID="imbFechaEmision" TabIndex="8" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                <asp:CalendarExtender ID="calendarExtenderFechaEmision" runat="server" PopupButtonID="imbFechaEmision" PopupPosition="TopLeft" TargetControlID="txtFechaEmision"></asp:CalendarExtender> 
                           </div>                                     
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvFechaEmision" runat="server" ControlToValidate="txtFechaEmision"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>                           
                        </tr>  

                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblFechaVencimiento" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <div style="position:relative;" >
                                    <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="mainTableBoxesCss" Width="102px" ToolTip="Calendario Fecha Vencimiento"
                                    TabIndex="9"></asp:TextBox>
                                    <asp:ImageButton ID="imbFechaVencimiento" TabIndex="10" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                    <asp:CalendarExtender ID="calendarExtenderFechaVencimiento" runat="server" PopupButtonID="imbFechaVencimiento" PopupPosition="TopLeft" TargetControlID="txtFechaVencimiento"></asp:CalendarExtender> 
                               </div>                                                                                                                                                                              
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvFechaVencimiento" runat="server" ControlToValidate="txtFechaVencimiento"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td> 
                            <td style="width: 3%"></td>                                                
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblTipoPersonaDeudor" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td style="width: 20%">                                                  
                              <asp:DropDownList id="ddlTipoPersonaDeudor" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static" 
                                    Width="99.5%" ToolTip="Lista de Tipo Persona Deudor" TabIndex="11" AutoPostBack="true"
                                    onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>                                                                  
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                        
                            </td>                           
                        </tr>


                        <tr>

                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblIdDeudor" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%" colspan="6">                            
                                 <asp:TextBox ID="txtIdDeudor" runat="server" AutoPostBack = "true" CssClass="mainTableBoxesCss" Enabled="True"  MaxLength="30"  ToolTip="Texto Id Deudor" TabIndex="12" Width="143px"></asp:TextBox> 
                                  <asp:MaskedEditExtender ID="maskIdDeudor" runat="server" InputDirection="RightToLeft" TargetControlID="txtIdDeudor"
                                MaskType="Number" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="false" ></asp:MaskedEditExtender>                                                                                                                   
                           
                             <asp:RequiredFieldValidator ID="rfvIdDeudor" runat="server" validationgroup="Deudor" ControlToValidate="txtIdDeudor"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="rfvGuardarIdDeudor" runat="server" ControlToValidate="txtIdDeudor"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                               
                              <asp:Button ID="btnConsultar" runat="server" CssClass="imgCmdBuscarGarantia" Enabled="True" validationgroup="Deudor" CausesValidation="true" ToolTip="Click para ejecutar la búsqueda" OnClick="btnConsultarDeudor_Click"/> 
                            
                            <asp:Button ID="btnLimpiar" runat="server" CssClass="botonLimpiar" CausesValidation="false" ToolTip="Limpiar Sección Abogados" OnClick="btnLimpiar_Click" />                                                                   
                            </td>
                                          
                        </tr>


                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                            
                            </td>
                            <td style="width: 20%">                            
                                                                                                                                           
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                          
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
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblNombreDeudor" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5">
                                   <asp:TextBox ID="txtNombreDeudor" runat="server" 
                                    CssClass="mainTableBoxesCss" Enabled="false" TabIndex="13" Width="99.2%"></asp:TextBox>
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                             <asp:RequiredFieldValidator ID="rfvNombreDeudor" runat="server" ControlToValidate="txtNombreDeudor"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>  

                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblTipoAsignacionCalificacion" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="6">
                                <asp:DropDownList id="ddlTipoAsignacionCalificacion" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static" 
                                    Width="96%" ToolTip="Lista de Tipo Asignación Calificación" TabIndex="14" AutoPostBack="true"
                                    onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>  

                        <tr>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblPlazoCalificacion" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                    <asp:DropDownList id="ddlPlazoCalificacion" runat="server" CssClass="mainTableBoxesCss" Enabled="false" ClientIDMode="Static" 
                                    Width="99.5%" ToolTip="Lista de Tipo Plazo Calificación" TabIndex="15" AutoPostBack="true"
                                    onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </td>                                                    
                           <td style="width: 3%; padding-left: 5px;"></td>
                           <td style="width: 3%"></td>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblCodigoEmpresaCalificadora" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                 <asp:DropDownList id="ddlCodigoEmpresaCalificadora" runat="server" CssClass="mainTableBoxesCss" Enabled="false" ClientIDMode="Static" 
                                    Width="99.5%" ToolTip="Lista de Tipo Código Empresa Calificadora" TabIndex="16" AutoPostBack="true"
                                    onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>                        
                            </td>
                           <td style="width: 3%; padding-left: 5px;""></td>                         
                        </tr>          

                        <tr>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblCategoriaCalificacion" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                     <asp:DropDownList id="ddlCategoriaCalificacion" runat="server" CssClass="mainTableBoxesCss" Enabled="false" ClientIDMode="Static" 
                                    Width="99.5%" ToolTip="Lista de Tipo Categoría Calificación" TabIndex="17" AutoPostBack="true"
                                     onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </td>                                                    
                           <td style="width: 3%; padding-left: 5px;"></td>
                           <td style="width: 3%"></td>
                           <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblCalificacionRiesgo" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                           <td style="width: 20%">
                                <asp:DropDownList id="ddlCalificacionRiesgo" runat="server" CssClass="mainTableBoxesCss" Enabled="false" ClientIDMode="Static" 
                                    Width="99.5%" ToolTip="Lista de Tipo Calificación Riesgo" TabIndex="18" AutoPostBack="true"
                                    onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>            
                            </td>
                           <td style="width: 3%; padding-left: 5px;""></td>                         
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
        
    </div>

</asp:Content>