<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucPropiedadesRegistro.ascx.cs" Inherits="wucPropiedadesRegistro" %>
<%--
<link href="../styles/PropiedadesRegistro.css" rel="stylesheet" type="text/css" />
--%>
<div class="fondoPropiedades">
    <table class="tablaPropiedades">
        <tr>
            <td>
                <span class="tituloPropiedades">Creado:&nbsp;</span>                
            </td>
            <td>
                <asp:Label ID="lblCreadoPor" Text="" CssClass="descripcionPropiedades" runat="server"></asp:Label>
            </td>
            <td>
                <span class="tituloPropiedades">Fecha Creación:&nbsp;</span>
            </td>  
            <td>
                <asp:Label ID="lblFechaCreacion" Text="" CssClass="descripcionPropiedades" runat="server"></asp:Label>
            </td>          
            <td>
                <span class="tituloPropiedades">Fuente:&nbsp;</span>
                <asp:Label ID="lblFuente" Text="" CssClass="descripcionPropiedades" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <span class="tituloPropiedades">Modificado:&nbsp;</span>
            </td>          
            <td>
                <asp:Label ID="lblModificadoPor" Text="" CssClass="descripcionPropiedades" runat="server"></asp:Label>
            </td>
            <td>
                <span class="tituloPropiedades">Fecha Modificación:&nbsp;</span>
            </td>          
            <td>
                <asp:Label ID="lblFechaModificacion" Text="" CssClass="descripcionPropiedades" runat="server"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
    </table>
</div>
