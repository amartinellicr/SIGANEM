<%@ page language="C#" autoeventwireup="true" inherits="ReportesNew, App_Web_wnuztasy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- MIMIC INTERNET EXPLORER 8 -->
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" /> 

    <title>Vista Reporte</title>
    <link rel="Stylesheet" type="text/css" href="../../Library/styles/ModalPopUp.css" />
</head>
<body style="height: 100%; width: 100%; margin: 0px 0px 0px 0px;">
    <form id="form1" runat="server" style="height: 100%; width: 100%; margin: 0px 0px 0px 0px;">
        <input type="hidden" id="idSesionOculto" runat="server" />
        <input type="hidden" id="codUsuarioOculto" runat="server" />    
        <input type="hidden" id="pantallaModuloOculto" runat="server" />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="height: 99.5%; width: 99.5%; position:absolute; float:left; left: 0px; top: 0px; bottom: 0px">
            <iframe id="frmReporte" runat="server" height="100%" width="100%"></iframe>
        </div> 
    </form>
</body>
</html>
