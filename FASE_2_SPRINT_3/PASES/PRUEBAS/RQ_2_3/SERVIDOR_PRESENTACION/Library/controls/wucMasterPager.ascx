<%@ control language="C#" autoeventwireup="true" inherits="wucMasterPager, App_Web_s3gx1syb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--
<link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterPager.css" />
--%>
<asp:Panel ID="pnlGridView" runat="server" class="mainPanel" Width="100%">
    <table style="width: 100%; height: 100%;">
        <tr>
            <td class="tdPagerRight" style="height: 20px;">
                &nbsp; Página &nbsp;
                <asp:Label ID="lblPagingIni" runat="server" Text="" CssClass="pagerLabelCssMasterGrid" />&nbsp;
                de &nbsp;
                <asp:Label ID="lblPagingFin" runat="server" Text="" CssClass="pagerLabelCssMasterGrid" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td style="width: 10px;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="imgBtnFirst" runat="server" CssClass="pagerButtonFirstCssMasterGrid" CommandName="First" CausesValidation="false"/>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="imgBtnFirst" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 10px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="imgBtnPrev" runat="server" CssClass="pagerButtonPrevCssMasterGrid" CommandName="Previous" CausesValidation="false"/>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="imgBtnPrev" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 145px;">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtSlide" runat="server" Style="border: 1px solid #BDBDBD; background-color: #FAFAFA;"
                            AutoPostBack="true" Width="100%" />
                        <asp:SliderExtender ID="SliderExtender1" runat="server" TargetControlID="txtSlide"
                            BoundControlID="Label1" Orientation="Horizontal" Minimum="1" TooltipText="{0}" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="txtSlide" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 10px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="imgBtnNext" runat="server" CssClass="pagerButtonNextCssMasterGrid" CommandName="Next" CausesValidation="false"/>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="imgBtnNext" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 10px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="imgBtnLast" runat="server" CssClass="pagerButtonLastCssMasterGrid" CommandName="Last" CausesValidation="false"/>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="imgBtnLast" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="width: 5px;">
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Panel>
