<%@ page title="" language="C#" masterpagefile="~/Library/styles/MasterPages/SubMain.Master" autoeventwireup="true" inherits="FideicomisosNew, App_Web_5tyb04lu" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Reference Control="~/Library/controls/wucMenuLateralDetalle.ascx" %>
<%@ Reference Control="~/Library/controls/wucMenuSuperiorDetalle.ascx" %>

<%@ Register Src="~/Library/controls/wucMensajeEliminar.ascx" tagname="MensajeEliminar" tagprefix="uc3" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeInformar" tagprefix="uc4" %>
<%@ Register Src="~/Library/controls/wucGridControl.ascx" tagname="GridFideicomisos" tagprefix="uc5" %>

<%--MENSAJES--%>
<%@ Register Src="~/Library/controls/wucMensajeConfirmar.ascx" tagname="MensajeConfirmar" tagprefix="uc14" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" tagname="MensajeAdvertencia" tagprefix="uc15" %>

<%--CONTROLES GARANTIAS REALES--%>
<%@ Register Src="~/Library/controls/wucGarantiasFideicomisoPrioridades.ascx" tagname="GarantiasFideicomisoPrioridades" tagprefix="uc16" %>

<%--//F02S02 - 2da Etapa CLS--%>
<%@ Register Src="~/Library/controls/wucGarantiasFideicomisoReales.ascx" tagname="GarantiasFideicomisoReales" tagprefix="uc17" %>

<%@ Register Src="~/Library/controls/wucGarantiasFideicomisoValores.ascx" tagname="GarantiasFideicomisoValores" tagprefix="uc21" %>

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
                                    <asp:Label ID="lblGeneral" Text="Generales" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr> 

                        <tr>
                        <td style="width: 25%; padding-left: 5px;">
                            <asp:Label ID="lblIdFideicomisoBCR" runat="server" CssClass="blackLabel"></asp:Label>
                        </td>
                        <td style="width: 20%">
                             <asp:TextBox ID="txtIdFideicomisoBCR" runat="server" CssClass="mainTableBoxesCss" Enabled="false" TabIndex="1" 
                                 Width="97%"></asp:TextBox> 
                        </td>                                                    
                        <td style="width: 3%; padding-left: 5px;">
                                 <asp:RequiredFieldValidator ID="rfvIdFideicomisoBCR" runat="server" ControlToValidate="txtIdFideicomisoBCR"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 3%">
                        </td>
                        <td style="width: 25%; padding-left: 5px;">
                            <asp:Label ID="lblIdFideicomiso" runat="server" CssClass="blackLabel"></asp:Label>  
                        </td>
                        <td style="width: 20%">
                             <asp:TextBox ID="txtIdFideicomiso" runat="server" CssClass="mainTableBoxesCss" Enabled="True" TabIndex="2"  MaxLength="15"
                                 Width="97%"></asp:TextBox>                                                                     
                        </td>
                        <td style="width: 3%; padding-left: 5px;">   
                        </td>                         
                    </tr> 

                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblNombreFideicomiso" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td colspan="5">
                                   <asp:TextBox ID="txtNombreFideicomiso" runat="server" 
                                    CssClass="mainTableBoxesCss" Enabled="true" TabIndex="3" MaxLength="100" Width="99.2%"></asp:TextBox>
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                             <asp:RequiredFieldValidator ID="rfvNombreFideicomiso" runat="server" ValidationGroup="ValidarFideicomiso" ControlToValidate="txtNombreFideicomiso"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>  

                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblFechaConstitucion" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <div style="position:relative;" >
                                    <asp:TextBox ID="txtFechaConstitucion" runat="server" CssClass="mainTableBoxesCss" Width="102px" ToolTip="Calendario Fecha Constitución"
                                    TabIndex="4" AutoPostBack="true" OnTextChanged="txtFechaConstitucion_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="imbFechaConstitucion" TabIndex="5" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                    <asp:CalendarExtender ID="calendarExtenderFechaConstitucion" runat="server" PopupButtonID="imbFechaConstitucion" PopupPosition="TopLeft" TargetControlID="txtFechaConstitucion"></asp:CalendarExtender> 
                               </div>                                                                                                                                                                              
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvFechaConstitucion" runat="server" ValidationGroup="ValidarFideicomiso" ControlToValidate="txtFechaConstitucion"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td> 
                            <td style="width: 3%"></td>                                                
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblFechaVencimiento" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <div style="position:relative;" >
                                    <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="mainTableBoxesCss" Width="102px" ToolTip="Calendario Fecha Vencimiento"
                                    TabIndex="6"  AutoPostBack="true" OnTextChanged="txtFechaVencimiento_TextChanged"></asp:TextBox>
                                    <asp:ImageButton ID="imbFechaVencimiento" TabIndex="7" runat="server" ImageUrl="~/Library/img/32/iconCalendario.gif" ImageAlign="AbsMiddle" CausesValidation="false" />
                                    <asp:CalendarExtender ID="calendarExtenderFechaVencimiento" runat="server" PopupButtonID="imbFechaVencimiento" PopupPosition="TopLeft" TargetControlID="txtFechaVencimiento"></asp:CalendarExtender> 
                               </div>                                                                                                                                                                              
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvFechaVencimiento" runat="server" ValidationGroup="ValidarFideicomiso" ControlToValidate="txtFechaVencimiento"
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>                          
                        </tr>
                            
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblTipoMonedaValorNominal" runat="server" CssClass="blackLabel"></asp:Label>                                
                            </td>
                            <td style="width: 20%">                                                  
                              <asp:DropDownList id="ddlTipoMonedaValorNominal" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static"  Enabled="false"
                                    Width="99.5%" ToolTip="Lista de Tipo Moneda Valor Nominal" TabIndex="8" AutoPostBack="true"></asp:DropDownList>   
                                    <%--<asp:DropDownList id="DropDownList1" runat="server" CssClass="mainTableBoxesCss" ClientIDMode="Static" 
                                    Width="99.5%" ToolTip="Lista de Tipo Moneda Valor Nominal" TabIndex="5" AutoPostBack="true"
                                    onselectedindexchanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>     --%>                                                            
                            </td>
                            <td style="width: 3%; padding-left: 5px;">                      
                            </td>                            
                            <td style="width: 3%"></td>                                                
                            <td style="width: 25%; padding-left: 5px;">
                                <asp:Label ID="lblValorNominal" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtValorNominal" runat="server" 
                                    CssClass="mainTableBoxesCss" Enabled="false" TabIndex="9" Width="97%"></asp:TextBox>                                                                                                                                                                         
                            </td>
                            <td style="width: 3%; padding-left: 5px;">
                                <asp:RequiredFieldValidator ID="rfvValorNominal" runat="server" ValidationGroup="ValidarFideicomiso" ControlToValidate="txtValorNominal" 
                                ErrorMessage=" * " CssClass="labelTabError" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>                       
                        </tr>

                        <tr>
                            <td style="width: 25%; padding-left: 5px;" ></td>
                            <td style="width: 20%"></td>
                            <td style="width: 3%;" ></td>
                            <td style="width: 3%"></td>
                            <td style="width: 25%">
                            <asp:Label ID="lblIdGeneral" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnIdGeneral" runat="server" />
                            </td>
                            <td style="width: 20%; text-align: right;">
                            <%--    <asp:Button ID="btnValidar" runat="server" CssClass="botonValidar"  TabIndex="13" ToolTip="Validar Sección General"/>--%>
                                <asp:Button ID="btnValidar" runat="server" CssClass="botonValidar" ValidationGroup="ValidarFideicomiso" TabIndex="10" ToolTip="Validar Sección General" onclick="btnValidar_Click" />
                            </td>
                            <td style="width: 3%">
                            </td>
                         </tr>
                                             
                </table> 

                  <asp:UpdatePanel ID="udpAdjuntos" runat="server">
                    <ContentTemplate>
                  <table id="tblDocumentosAdjuntos" style="width:100%;">
                        <tr>
                            <td style="height: 29px;" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab2">
                                    <asp:Label ID="lblContratosAdendasAdjuntos" Text="Contratos/Adendas Adjuntos" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;">
                              <%--  <asp:TextBox ID="txtRutaArchivo" runat="server" Enabled="false" CssClass="mainTableBoxesCss" Width="150" ToolTip="Texto Valor Total Cédulas"></asp:TextBox>--%> 
                                <asp:FileUpload ID="FileUploadRutaArchivo" runat="server" /><br />
                            </td>
                            <td style="width: 20%; text-align:center;">   
                             <asp:Label ID="lblTipoDocumento" runat="server" CssClass="labelSub"></asp:Label>
                            </td>
                            <td style="width: 3%;">                               
                            </td>
                            <td style="width: 28%;" colspan="2" >
                                <asp:DropDownList id="ddlTipoDocumento" runat="server" CssClass="mainTableBoxesCss" Width="100%" ToolTip="Lista de Tipos de Documentos"
                                Enabled="true"></asp:DropDownList>        
                                <%-- <asp:DropDownList id="DropDownList1" runat="server" CssClass="mainTableBoxesCss" Width="100%" ToolTip="Lista de Indicador Prioridad"
                                Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>--%>                                          
                            </td>
                            <td style="width: 20%; text-align:center;">
                            <%--<td style="width: 20%; text-align: right;">--%>
                                <asp:Button ID="btnAgregar" runat="server" CssClass="botonAgregar" TabIndex="11" ToolTip="Agregar Documento" CausesValidation = "false" onclick="btnAgregar_Click"/>
                                <%--<asp:Button ID="Button1" runat="server" CssClass="botonValidar"  TabIndex="13" ToolTip="Validar Sección General" onclick="btnValidar_Click" />--%>
                      
                               </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                        <tr>
                            <td style=" padding-left: 5px;" colspan="6">
                                <div id="divDocumentosAdjuntos" class="panelGridControl">
                               <%-- <asp:Panel id="pnlDocumentosAdjuntos" runat="server" ScrollBars="Auto" max-height="150px">--%>
                                    <uc5:GridFideicomisos ID="grdDocumentosAdjuntos" runat="server" />
                                <%--</asp:Panel>--%>
                                </div>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                   </table>     
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID = "btnAgregar" />
                    </Triggers>
                    </asp:UpdatePanel>                                       
                  <table id="tblPrioridades" style="width:100%; ">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab3">
                                    <asp:Label ID="lblPrioridades" Text="Prioridades" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblIndPrioridad" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                               <asp:DropDownList id="ddlIndPrioridad" runat="server" CssClass="mainTableBoxesCss" Width="100%" ToolTip="Lista de Indicador Prioridad"
                                Enabled="true" AutoPostBack="true" onselectedIndexChanged="ddlIndPrioridad_SelectedIndexChanged"></asp:DropDownList>        
                                <%-- <asp:DropDownList id="DropDownList1" runat="server" CssClass="mainTableBoxesCss" Width="100%" ToolTip="Lista de Indicador Prioridad"
                                Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>--%>                           
                            </td>
                            <td style="width: 3%;">
                            </td>
                            <td style="width: 3%;">
                            </td>
                            <td style="width: 25%">
                            </td>
                            <td style="width: 20%; text-align: right;">                               
                            </td>
                            <td style="width: 3%;">
                            </td>
                        </tr>
                        <tr>
                            <td style=" padding-left: 5px;" colspan="6">
                                <div id="divPrioridad" class="panelGridControl">
                               <%-- <asp:Panel id="pnlPrioridades" runat="server" ScrollBars="Auto" max-height="150px">--%>
                                    <uc5:GridFideicomisos ID="grdPrioridad" runat="server" />
                                <%--</asp:Panel>--%>
                                </div>
                            </td>
                            <td style="width: 3%">
                            </td>
                        </tr>
                    </table>         
                    
                  <table id="tblGarantiasFideicometidas" style="width:100%;">
                        <tr>
                            <td style="height: 29px" colspan="7">
                                <div id="ctl00_ContentPlaceHolder1_Tab4">
                                    <asp:Label ID="lblGarantasFideicometidas" Text="Garantías Fideicometidas" runat="server" CssClass="labelSub"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%; padding-left: 5px;" >
                                <asp:Label ID="lblTipoGarantia" runat="server" CssClass="blackLabel"></asp:Label>
                            </td>
                            <td style="width: 20%">
                               <asp:DropDownList id="ddlTipoGarantia" runat="server" CssClass="mainTableBoxesCss" Width="100%" ToolTip="Lista de Tipos de Garantías"
                                Enabled="true" AutoPostBack="true"></asp:DropDownList>     
               <%--                  <asp:DropDownList id="DropDownList1" runat="server" CssClass="mainTableBoxesCss" Width="100%" ToolTip="Lista de Tipos de Garantías"
                                Enabled="true" AutoPostBack="true" OnSelectedIndexChanged="dropDownList_SelectedIndexChanged"></asp:DropDownList>  --%>                     
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
                                <div id="divGarantiaFideicometida" class="panelGridControl">
                                <%--<asp:Panel id="pnlGarantiasFideicometidas" runat="server" ScrollBars="Auto" max-height="150px">--%>
                                    <uc5:GridFideicomisos ID="grdGarantiaFideicometida" runat="server" />
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

         <%-- GARANTIAS FIDEICOMISO PRIORIDADES --%>
        <asp:Panel runat="server" ID="popupPrioridades" style="display: none; background-color: #FFFFFF; height: 305px; width: 650px; border-width: 3px;
        border-color: Black; border-style: solid;">
            <uc16:GarantiasFideicomisoPrioridades ID="VentanaPrioridades1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbPrioridades" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpePrioridades" runat="server"
                PopupControlID="popupPrioridades" 
                TargetControlID="lkbPrioridades" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>
        
        <asp:Panel runat="server" ID="popupConfirmarEliminarPrioridades" style="display: none; background-color: #FFFFFF;">
            <uc3:MensajeEliminar ID="MensajeConfirmarEliminarPrioridades1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbConfirmarEliminarPrioridades" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeConfirmarEliminarPrioridades" runat="server" 
                PopupControlID="popupConfirmarEliminarPrioridades" 
                TargetControlID="lkbConfirmarEliminarPrioridades" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>
 
         <%-- GARANTIAS FIDEICOMISO FIDEICOMETIDAS VALOR --%>
        <asp:Panel runat="server" ID="popupValores" style="display: none; background-color: #FFFFFF; height: 490px; width: 840px; border-width: 3px;
            border-color: Black; border-style: solid; z-index: 1000;">
            <asp:UpdatePanel ID="updValoresPopUp" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <uc21:GarantiasFideicomisoValores ID="GarantiasFideicomisoValores" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:LinkButton runat="server" ID="lkbModalValores" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeValores" runat="server"
                PopupControlID="popupValores" 
                TargetControlID="lkbModalValores" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>
                
         <asp:Panel runat="server" ID="popupConfirmarEliminarFideicometidas" style="display: none; background-color: #FFFFFF;">
            <uc3:MensajeEliminar ID="MensajeEliminarEliminarFideicometidas" runat="server" />
            <asp:LinkButton runat="server" ID="lkbConfirmarEliminarFideicometidas" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeConfirmarEliminarFideicometidas" runat="server" 
                PopupControlID="popupConfirmarEliminarFideicometidas" 
                TargetControlID="lkbConfirmarEliminarFideicometidas" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/>                            
        </asp:Panel>

        <%--//F02S02 - 2da Etapa CLS--%>
        <%-- GARANTIAS FIDEICOMISO REALES --%>
        <asp:Panel runat="server" ID="popupFideicomisoReales" style="display: none; background-color: #FFFFFF; height: 558px; width: 840px; border-width: 3px;
            border-color: Black; border-style: solid;">
            <uc17:GarantiasFideicomisoReales ID="VentanaFideicomisoReales" runat="server" />
            <asp:LinkButton runat="server" ID="lkbFideicomisoReales" CssClass="modalPopup" style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeFideicomisoReales" runat="server"
                PopupControlID="popupFideicomisoReales" 
                TargetControlID="lkbFideicomisoReales" 
                BackgroundCssClass="modalBackground"
                DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll"/> 
         </asp:Panel> 

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
