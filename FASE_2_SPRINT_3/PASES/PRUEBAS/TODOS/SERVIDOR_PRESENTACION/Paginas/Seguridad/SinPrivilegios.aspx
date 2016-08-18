<%@ page title="Sin Privilegios" language="C#" masterpagefile="~/Library/styles/MasterPages/Main.Master" autoeventwireup="true" inherits="SinPrivilegios, App_Web_3znd4qeo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Reference Control="~/Library/controls/wucMenuSuperior.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Sin Privilegios</title>
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MasterGrid.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/MensajePopUp.css" />
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/ModalPopUp.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />
    <br />
    <br />
    <br />
    <div style="height: 100%; width: 100%; text-align: center; position: fixed;">
        <center>
            <table>
                <tr>
                    <td style="text-align: center; width: 100%;">
                        <div style="text-align: center; height: 100%;">
                            <table style="height: 90px; width: 570px;">
                                <tr>
                                    <td rowspan="3">
                                        <asp:Image ID="img1" ImageUrl="~/Library/img/32/iconPermiso.png" runat="server" />
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblTitulo" Text="Permisos Insuficientes" runat="server" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblMensaje1" Text="No posee los permisos necesarios para ingresar a esta página."
                                            runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblMensaje2" Text="Contacte a su administrador del sistema." runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
