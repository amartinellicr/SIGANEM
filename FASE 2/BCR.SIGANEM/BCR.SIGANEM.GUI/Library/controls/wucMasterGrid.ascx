<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucMasterGrid.ascx.cs" Inherits="wucMasterGrid" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css" />
--%>
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
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblTituloPage" runat="server" CssClass="tdUpperTitle"></asp:Label>
                        </td>
                        <td class="tdright" valign="middle">
                            <asp:DropDownList ID="ddlfiltro" runat="server" class="ddlFilter" />
                            <asp:TextBox ID="txtFiltro" runat="server" class="txtFilter" Width="250px" />
                            <asp:TextBoxWatermarkExtender ID="txtweFiltro" WatermarkText="Búsqueda de registro"
                                runat="server" TargetControlID="txtFiltro" WatermarkCssClass="WaterMarkTextBox">
                            </asp:TextBoxWatermarkExtender>
                        </td>
                        <td class="tdright" style="width: 50px;">
                            <div style="text-align: center; height: 22px;">
                                <asp:UpdatePanel ID="UpdConsultar" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false"> 
                                    <ContentTemplate>                            
                                        <asp:Button ID="imgBtnSearch" runat="server" CssClass="imgBtnSearch" CausesValidation="false" ToolTip="Buscar Registro" />
                                        <asp:Button ID="imgBtnClear"  runat="server" CssClass="imgBtnClear" CausesValidation="false" ToolTip="Eliminar Búsqueda" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;                            
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="imgBtnSearch" />
                                        <asp:PostBackTrigger ControlID="imgBtnClear" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <asp:UpdateProgress ID="updConsultando" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdConsultar">
                                <ProgressTemplate>
                                    <div class="overlay" />
                                    <div class="overlayContent">
                                        <center>
                                            <asp:Image ImageUrl="~/Library/img/MasterGrid/imgLoading.gif" runat="server" />
                                            <h2></h2>
                                            <h2>Consultando...</h2>
                                        </center>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
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
