<%@ control language="C#" autoeventwireup="true" inherits="Library_controls_wucMenuLateral, App_Web_uwnnvwvb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--
<link rel="Stylesheet" type="text/css" href="../styles/LoadingControl.css" />
<link rel="Stylesheet" type="text/css" href="../styles/MenuLateral.css" />
--%>
<div style="width: 183px; height: 100%;">
    <script type="text/javascript" language="javascript">
        function selectedNode(_ruta, idSesionOculto, codUsuarioOculto, pantallaModuloOculto) 
        {
            var form = document.createElement("form");

            form.setAttribute("id", "Form1");
            form.setAttribute("name", "PostForm");
            form.setAttribute("action", ValidateUrl(_ruta));
            form.setAttribute("method", "post");
            form.setAttribute("target", "_self");

            newInput1 = document.createElement('input');
            newInput1.type = 'hidden';
            newInput1.name = 'idSesion';
            newInput1.value = idSesionOculto;

            newInput2 = document.createElement('input');
            newInput2.type = 'hidden';
            newInput2.name = 'codUsuario';
            newInput2.value = codUsuarioOculto;

            newInput3 = document.createElement('input');
            newInput3.type = 'hidden';
            newInput3.name = 'pantallaModulo';
            newInput3.value = pantallaModuloOculto;

            form.appendChild(newInput1);
            form.appendChild(newInput2);
            form.appendChild(newInput3);
            document.body.appendChild(form);

            form.submit();
            document.body.removeChild(form);

            function ValidateUrl(s) 
            {
                if (self.location.href.search("Paginas") != -1) 
                {
                    return "../../" + s;
                }
                else
                {
                    return s;
                }
            }
        }
    </script>

    <%--VALORES SESION--%>
    <input type="hidden" id="idSesionOculto" runat="server" />
    <input type="hidden" id="codUsuarioOculto" runat="server" />
    <input type="hidden" id="pantallaModuloOculto" runat="server" />

    <div class="divArbolMenuLateral">
        <asp:Panel ID="MenuLateralArbol" runat="server" ScrollBars="Auto" CssClass="panelMenuLateralArbol">
            
        </asp:Panel>
    </div>
    <div class="divAreasMenuLateral">
        <asp:UpdatePanel ID="udpAreasBotones" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <Triggers>
                <asp:PostBackTrigger ControlID="cmdAreaContactoComercial"  />
                <asp:PostBackTrigger ControlID="cmdAreaValuaciones"  />
                <asp:PostBackTrigger ControlID="cmdAreaPolizas" />
                <asp:PostBackTrigger ControlID="cmdAreaFormalizacion"/>
                <asp:PostBackTrigger ControlID="cmdAreaFideicomisos" />
                <asp:PostBackTrigger ControlID="cmdAreaAbogados" />
                <asp:PostBackTrigger ControlID="cmdAreaSeguimiento" />
                <asp:PostBackTrigger ControlID="cmdAreaBienesRealizables"  />
                <asp:PostBackTrigger ControlID="cmdAreaAdministracion" />
				<asp:PostBackTrigger ControlID="cmdAreaReportes"  />
            </Triggers>
            <ContentTemplate>
                <asp:Button ID="cmdAreaContactoComercial" CssClass="AreasMenuLateralContactoComercial" runat="server" CausesValidation="false"
                    Text="Contacto Comercial" OnClick="cmdAreaContactoComercial_Click" />
                <asp:Button ID="cmdAreaValuaciones" CssClass="AreasMenuLateralValuaciones" runat="server" CausesValidation="false"
                    Text="Valuaciones" OnClick="cmdAreaValuaciones_Click" />
                <asp:Button ID="cmdAreaPolizas" CssClass="AreasMenuLateralPolizas" runat="server" CausesValidation="false"
                    Text="Pólizas" OnClick="cmdAreaPolizas_Click" />
                <asp:Button ID="cmdAreaFormalizacion" CssClass="AreasMenuLateralFormalizacion" runat="server" CausesValidation="false"
                    Text="Formalización" OnClick="cmdAreaFormalizacion_Click" />
                <asp:Button ID="cmdAreaFideicomisos" CssClass="AreasMenuLateralFideicomisos" runat="server" CausesValidation="false"
                    Text="Fideicomisos" OnClick="cmdAreaFideicomisos_Click" />
                <asp:Button ID="cmdAreaAbogados" CssClass="AreasMenuLateralAbogados" runat="server" CausesValidation="false"
                    Text="Abogados" OnClick="cmdAreaAbogados_Click" />
                <asp:Button ID="cmdAreaSeguimiento" CssClass="AreasMenuLateralSeguimiento" runat="server" CausesValidation="false"
                    Text="Seguimiento" OnClick="cmdAreaSeguimiento_Click" />
                <asp:Button ID="cmdAreaBienesRealizables" CssClass="AreasMenuLateralBienesRealizables"  runat="server" CausesValidation="false"
                    Text="Bienes Realizables" OnClick="cmdAreaBienesRealizables_Click" />
                <asp:Button ID="cmdAreaAdministracion" CssClass="AreasMenuLateralAdministracion" runat="server" CausesValidation="false"
                    Text="Administración" OnClick="cmdAreaAdministracion_Click" />
				<asp:Button ID="cmdAreaReportes" CssClass="AreasMenuLateralReportes" runat="server" CausesValidation="false" 
                    Text="Reportes" OnClick="cmdAreaReportes_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
