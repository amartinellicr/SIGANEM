<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucMasterGridSinFiltro.ascx.cs" Inherits="wucMasterGridSinFiltro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Panel ID="pnlGridView" runat="server" class="mainPanel" Width="100%">
    <table style="width: 100%; border-collapse: collapse; background-color: #E8ECF0">
        <tr style="border: 1px Solid #E8ECF0">
            <td class="separator">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 85%;">
                <table class="masterGridTable" style="width: 100%;">
                    <tr id="dragHandle" class="dragHandle">
                        <td class="tdleft" valign="middle">
                        </td>
                        <td class="tdright" valign="middle">
                        </td>
                        <td class="tdright" style="width: 50px;">
                        </td>
                    </tr>
                    <tr style="border: 1px Solid #E8ECF0">
                        <td class="separator">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center;">
                            <asp:Panel ID="gridContainer" runat="server" Style="display: block; height: 100%;">
                                <asp:GridView ID="MasterGridView" runat="server" AutoGenerateColumns="False" CssClass="mainGridView"
                                        HorizontalAlign="Center" Style="width: 100%;" GridLines="Horizontal" AllowSorting="true" ShowHeaderWhenEmpty="true">
                                    <HeaderStyle CssClass="headerGridView" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <RowStyle CssClass="rowGridView" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <AlternatingRowStyle CssClass="alternateRowGridView" HorizontalAlign="Center" />
                                    <PagerSettings Visible="true" />
                                    <EmptyDataTemplate>
                                        <div class="lblEmptyData" style="background-color: #F2F5A9;">
                                            <asp:Label ID="labelEmptyData" runat="server" Text="No existen registros asociados" />
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