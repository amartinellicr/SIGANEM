﻿<%@ Page Title="SIGANEM - Inicio" Language="C#" MasterPageFile="~/Library/styles/MasterPages/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>
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

