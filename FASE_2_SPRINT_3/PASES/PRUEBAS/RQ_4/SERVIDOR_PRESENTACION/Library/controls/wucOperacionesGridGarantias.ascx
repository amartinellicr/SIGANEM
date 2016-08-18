<%@ control language="C#" autoeventwireup="true" inherits="wucOperacionesGridGarantias, App_Web_4ficn4jk" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterOperacionConsulta.css" />

<asp:UpdatePanel id="upPrincipal" runat="server" >
    <ContentTemplate>
        <asp:Panel ID="pnlGridView" runat="server" class="mainPanel">
            <div class="divConsultaGridGarantia">
                <table id="tableGarantias" style="width: 97%; margin-left: 15px; text-align:left;">
                    <tr style="height: 8px;">
                        <td colspan="2" class="tdLineSeparator"></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:left">
                            <asp:Label ID="lblGarantias" runat="server" Text="Garantías Relacionadas" CssClass="labelSub" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdSeparatorSmall"></td>
                        <td style="width: 100%; height: 85%;">
                            <table class="masterGridTable" style="width: 100%;">
                                <tr id="dragHandle" class="dragHandle">
                                    <td class="tdleft" valign="middle" style="width: 52%;">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTipoGarantia" runat="server" CssClass="blackLabel"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTipoGarantia" runat="server" CssClass="mainTableBoxesCss" Width="250px" />
                                                </td> 
                                            </tr>
                                        </table>
                                    </td>                                
                                    <td class="tdright" valign="middle">
                                        <asp:Button ID="btnActualizarGrid" runat="server" CssClass="imgCmdActualizarSICCDisabled" Enabled="false" CausesValidation="false" ToolTip="Actualizar" />&nbsp;&nbsp;
                                        |&nbsp;&nbsp;
                                        <asp:Button ID="imgCmdAgregar" runat="server" CssClass="imgCmdAgregarSICCDisabled" Enabled="false" CausesValidation="false" ToolTip="Agregar Relación" />&nbsp;&nbsp;
                                        <asp:Button ID="imgCmdModificar"  runat="server" CssClass="imgCmdModificarSICCDisabled" Enabled="false"  CausesValidation="false" ToolTip="Modificar Relación" />&nbsp;&nbsp;
                                        <asp:Button ID="imgCmdEliminar"  runat="server" CssClass="imgCmdEliminarSICCDisabled" Enabled="false"  CausesValidation="false" ToolTip="Eliminar Relación" />&nbsp;&nbsp;
                                        |&nbsp;&nbsp;
                                        <asp:Button ID="imgCmdBorrarSICC"  runat="server" CssClass="imgCmdBorrarSICCDisabled" Enabled="false"  CausesValidation="false" ToolTip="Eliminar Réplica" />&nbsp;&nbsp;
                                    </td>                                        
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center;">
                                        <asp:Panel ID="gridContainer" runat="server" Style="display: block; height: 100%;">
                                            <asp:GridView id="MasterGridView" runat="server" autogeneratecolumns="False" cssclass="mainGridView"
                                                    horizontalalign="Center" style="width: 100%;" gridlines="Horizontal" allowsorting="True" 
                                                    ShowHeaderWhenEmpty="True" onrowcreated="MasterGridView_RowCreated" >
                                                <HeaderStyle CssClass="headerGridView" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <RowStyle CssClass="rowGridView" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <AlternatingRowStyle CssClass="alternateRowGridView" HorizontalAlign="Center" />
                                                <PagerSettings Visible="true" />                                                
                                                <EmptyDataTemplate>
                                                    <div class="lblEmptyData" style="background-color: #F2F5A9;">
                                                        <asp:Label ID="labelEmptyData" runat="server" Text="No hay Disponible ningún registro en este Mantenimiento" />
                                                    </div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>