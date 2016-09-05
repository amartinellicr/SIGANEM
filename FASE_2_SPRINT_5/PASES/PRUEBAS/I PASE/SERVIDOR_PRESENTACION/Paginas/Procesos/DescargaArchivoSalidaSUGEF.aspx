<%@ page title="Descarga Archivo Salida SUGEF" language="C#" masterpagefile="~/Library/styles/MasterPages/Main.Master" autoeventwireup="true" inherits="DescargaArchivoSalidaSUGEF, App_Web_n1h3jmbo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Library/styles/MasterPages/Main.Master" %>
<%@ Register Src="~/Library/controls/wucMensajeInformar.ascx" TagName="MensajeInformar" TagPrefix="uc1" %>
<%@ Register Src="~/Library/controls/wucMasterGridSinFiltro.ascx" TagName="MasterGrid" TagPrefix="uc2" %>
<%@ Register Src="~/Library/controls/wucMasterPager.ascx" TagName="MasterPager" TagPrefix="uc3" %>

<%@ Reference Control="~/Library/controls/wucMenuSuperior.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MensajePopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/ModalPopUp.css" />
    <script src="../../Library/scripts/Procesando.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />
    <input type="hidden" id="pantallaIdOculto" runat="server" />
    <input type="hidden" id="pantallaCodOculto" runat="server" />
    <input type="hidden" id="pantallaTituloOculto" runat="server" />
    <input type="hidden" id="pantallaModuloOculto" runat="server" />
    <input type="hidden" id="pantallaNombreOculto" runat="server" />
    <div id="body" class="body">
        <asp:UpdatePanel ID="udpDescargar" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div style="width: 100%; background-color: #E8ECF0">
                    <div style="background-color: #E8ECF0; width: 100%; height: 35px;">
                        <div style="top: 10px; left: 20px; position: relative; float: left">
                            <asp:Label ID="lblTituloPage" runat="server" CssClass="tdUpperTitle"></asp:Label>
                        </div>
                    </div>
                   <%-- <div>
                        <asp:UpdatePanel ID="updMasterGrid" runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <uc2:MasterGrid ID="MasterGrid1" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>--%>
                    <%--<div style="text-align: center">
                        <asp:Button ID="btnDescargar" runat="server" ClientIDMode="Static" Text="Descargar"
                            OnClick="btnDescargar_Click" CssClass="mainTableBoxesCss" />
                    </div>--%>
                </div>
            </ContentTemplate>
            <%--<Triggers>
                <asp:PostBackTrigger ControlID="btnGenerar" />
            </Triggers>--%>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="udpControles" runat="server">
            <ContentTemplate>
                <table class="tablaPrincipal" width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="PanelDisponibles" runat="server" Width="100%" Height="100%" ScrollBars="Auto">
                                <table class="tablaDescargaArchivos" width="100%">
                                    <tr>
                                        <td class="tablaArchivo" width="100%">
                                            <asp:Panel runat="server" ID="panel1" Style="overflow: auto; height: 100%; width: 100%;
                                                border-collapse: collapse; border-style: none;">
                                                <asp:GridView ID="grwDownload" runat="server" AllowPaging="True" Width="100%" CssClass="mainGridView"
                                                    GridLines="None" AllowSorting="True" ShowFooter="True" AutoGenerateColumns="False"
                                                    OnPageIndexChanging="grwDownload_PageIndexChanging" OnSelectedIndexChanging="grwDownload_SelectedIndexChanging">
                                                    <EmptyDataTemplate>
                                                        <div class="divSinDatos">
                                                            <asp:Label ID="lblSinDatos" runat="server" Text="No hay Datos Disponibles" CssClass="lblSinDatos" />
                                                        </div>
                                                    </EmptyDataTemplate>
                                                    <PagerStyle CssClass="gridPager" />
                                                    <HeaderStyle CssClass="headerGridView" />
                                                    <RowStyle CssClass="rowGridView" />
                                                    <AlternatingRowStyle CssClass="alternateRowGridView" />
                                                    <SelectedRowStyle CssClass="rowGridViewSelected" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Archivo">   
                                                         <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>                                                      
                                                        <asp:BoundField DataField="Tamano" HeaderText="Tamaño (bytes)" DataFormatString="{0:N}">
                                                            <HeaderStyle Width="120px" />
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Formato" HeaderText="Formato">
                                                            <HeaderStyle Width="70px" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Url" HeaderText="Url" Visible="false" />
                                                        <asp:CommandField SelectText="&lt;img src='../../Library/img/MasterGrid/download.png' border=0 height=23px title='Descargar Archivo' /&gt;"
                                                            ShowSelectButton="True">
                                                            <HeaderStyle Width="45px" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:CommandField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="grwDownload" />
            </Triggers>
        </asp:UpdatePanel>
        <%--MENSAJE INFORMAR GENERAL--%>
        <%--<asp:Panel runat="server" ID="popupInformar" Style="display: none; background-color: #FFFFFF;">
            <uc1:MensajeInformar ID="InformarBox1" runat="server" />
            <asp:LinkButton runat="server" ID="lkbModalInfo" CssClass="modalPopup" Style="visibility: hidden;" />
            <asp:ModalPopupExtender ID="mpeInformarBox" runat="server" PopupControlID="popupInformar"
                TargetControlID="lkbModalInfo" BackgroundCssClass="modalBackground" DropShadow="false"
                RepositionMode="RepositionOnWindowResizeAndScroll" />
        </asp:Panel>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">       
</asp:Content>
