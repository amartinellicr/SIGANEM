<%@ page title="SIGANEM - Inicio" language="C#" masterpagefile="~/Library/styles/MasterPages/Main.master" autoeventwireup="true" inherits="Default, App_Web_ywmpfav3" %>
<%@ Reference Control="~/Library/controls/wucMenuSuperior.ascx" %>
<%@ Reference Control="~/Library/controls/wucMenuLateral.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />
    <input type="hidden" id="pantallaModuloOculto" runat="server" />

    <div style="height: 100%; width:100%">
        <br />
    </div>
</asp:Content>

