<%@ page language="C#" autoeventwireup="true" inherits="Error, App_Web_axygfhbq" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIGANEM - Página Error</title>
    <link href="../Library/styles/ErrorPage.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />

    <center>
    <div style="width: 950px; vertical-align: top; margin: 5px auto auto auto">
        <table style="height: 100%;" >
            <tr>
                <td colspan="3">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="3" >
                    <div id="header">
                        <table style="width: 100%; height: 60px;">
                            <tr>
                                <td>
                                    <asp:Image ID="imgError" runat="server" ImageUrl="~/Library/img/32/iconError.png" />
                                </td>
                                <td class="tituloMain">
                                    Ha ocurrido un problema inesperado con la aplicación SIGANEM        
                                </td>
                            </tr>
                        </table>
                        
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <tr>
                <td class="lineaMensaje">
                    <asp:Label ID="lblTituloQueHacer" runat="server" CssClass="tituloMensaje" Text="Qué puede hacer usted"></asp:Label>
                </td>
                <td align="left" colspan="2">
                    <div id="ocurrio">
                        Intente navegar a la página anterior utilizando el botón "Atrás" de su navegador
                        o haga clic
                        <asp:HyperLink ID="hlkPrincipal" runat="server" NavigateUrl="~/Aplicacion/Login.aspx">aquí</asp:HyperLink>&nbsp
                        para regresar a la página de inicio de sesión.<br />
                        <br />
                        Si desea ponerse en contacto con el administrador del sistema, puede utilizar la
                        información que se muestra abajo.</div>
                </td>
            </tr>                        
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <tr>
                <td class="lineaMensaje">
                    <asp:Label ID="lblTituloDetalle" runat="server" CssClass="tituloDetalle">Detalle</asp:Label>
                </td>
                <td align="left" colspan="2" style="height: 425px;">
                    <div style="overflow: auto; width: 100%; height: 100%" >
                        <asp:Panel ID="pnlTextoDetalle" runat="server" CssClass="detalle" ScrollBars="Auto">
                            <asp:Literal ID="ltlTextoDetalle" runat="server"></asp:Literal><br />
                        </asp:Panel>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
        </table>
    </div>
    </center>

    </form>
</body>
</html>
