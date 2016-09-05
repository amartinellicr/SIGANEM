<%@ control language="C#" autoeventwireup="true" inherits="wucGridControl, App_Web_i5lovuna" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<link rel="Stylesheet" type="text/css" href="../../Library/styles/GridControl.css" />

<asp:UpdatePanel ID="updGridControl" runat="server" >
    <ContentTemplate> 
        <asp:Panel ID="pnlGridView" runat="server" class="mainPanel" Width="100%">
            <table style="width: 100%; border-collapse: collapse; background-color: transparent">
                <tr>
                    <td style="width: 100%; height: 85%;">
                        <table class="masterGridTable" style="width: 100%;">
                            <tr id="dragHandle" class="dragHandle">
                                <td class="tdright" valign="middle">
                                    <asp:Button ID="imgCmdBuscar" runat="server" CssClass="imgCmdBuscar" AlternateText="Buscar" Visible="false" CausesValidation="false" ToolTip="Buscar" />&nbsp;&nbsp;
                                    <asp:Button ID="imgCmdModificar" runat="server" CssClass="imgCmdModificar" AlternateText="Modificar" Visible="false" CausesValidation="false" ToolTip="Modificar" />&nbsp;&nbsp;
                                    <asp:Button ID="imgCmdAgregar" runat="server" CssClass="imgCmdAgregar" AlternateText="Agregar" CausesValidation="false" ToolTip="Agregar" />&nbsp;&nbsp;
                                    <asp:Button ID="imgCmdEliminar"  runat="server" CssClass="imgCmdEliminar" AlternateText="Eliminar" CausesValidation="false" ToolTip="Eliminar" />&nbsp;                                             
                                </td>
                            </tr> 
                            <tr>
                                <td style="text-align: center;">
                                    <asp:Panel ID="gridContainer" runat="server" Style="display: block; height: 100%;">
                                        <asp:GridView ID="MasterGridView" runat="server" AutoGenerateColumns="False" CssClass="mainGridView"
                                                HorizontalAlign="Center" Style="width: 100%;" AllowSorting="true" ShowHeaderWhenEmpty="true" 
                                                onrowcreated="MasterGridView_RowCreated" onrowdatabound="MasterGridView_RowDataBound" GridLines="Horizontal">
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
        </asp:Panel>
    </ContentTemplate>
    <Triggers>
<%--        <asp:PostBackTrigger ControlID="imgCmdAgregar" />
        <asp:PostBackTrigger ControlID="imgCmdEliminar" />--%>
        <asp:PostBackTrigger ControlID="imgCmdBuscar"/>
    </Triggers>
</asp:UpdatePanel>