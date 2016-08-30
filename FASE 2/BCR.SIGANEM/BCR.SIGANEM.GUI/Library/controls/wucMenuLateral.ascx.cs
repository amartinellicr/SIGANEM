using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

using SeguridadWS;


public partial class Library_controls_wucMenuLateral : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region VARIABLES
    

    TreeView treeReportes = new TreeView();
    TreeView treeContacto = new TreeView();
    TreeView treeValuaciones = new TreeView();
    TreeView treePolizas = new TreeView();
    TreeView treeFormalizacion = new TreeView();
    TreeView treeFideicomisos = new TreeView();
    TreeView treeAbogados = new TreeView();
    TreeView treeSeguimiento = new TreeView();
    TreeView treeBienes = new TreeView();
    TreeView treeAdministracion = new TreeView();
    TreeView treeViewAreaOpciones = new TreeView();

    #endregion

    #region REFERENCIAS

    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS

    protected void Page_Init(object sender, EventArgs e)
    {
        AsignaWebServicesTypeNames();

        this.MenuLateralArbol.Controls.Clear();
        this.MenuLateralArbol.Controls.Add(treeViewAreaOpciones);
        treeViewAreaOpciones.NodeStyle.CssClass = "AreasMenuLateralArbolNodo";
        treeViewAreaOpciones.LeafNodeStyle.CssClass = "AreasMenuLateralArbolHoja";
    }

    private void ObtenerValoresSesion()
    {
        //ALMACENA LA INFORMACION DE LA SESION
        string[] valores = Request.Form.AllKeys;
        foreach (string valor in valores)
        {
            switch (valor)
            {
                case "idSesion":
                    idSesionOculto.Value = Request.Form["idSesion"].ToString();
                    break;
                case "codUsuario":
                    codUsuarioOculto.Value = Request.Form["codUsuario"].ToString();
                    break;
                case "pantallaModulo":
                    pantallaModuloOculto.Value = Request.Form["pantallaModulo"].ToString();
                    break;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            #region OBTENER VALORES SESION
            ObtenerValoresSesion();
            #endregion
            Arboles();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Dispose();//PRUEBA
        }
    }

    #region EVENTOS CLICK

    protected void cmdAreaReportes_Click(object sender, EventArgs e)
    {
        try
        {
            ObtenerValoresSesion();

            #region EFECTOS SOBRE LAS AREAS DEL MENU

            this.cmdAreaReportes.CssClass = "AreasMenuLateralReportesSeleccionado";
            this.cmdAreaContactoComercial.CssClass = "AreasMenuLateralContactoComercial";
            this.cmdAreaValuaciones.CssClass = "AreasMenuLateralValuaciones";
            this.cmdAreaPolizas.CssClass = "AreasMenuLateralPolizas";
            this.cmdAreaFormalizacion.CssClass = "AreasMenuLateralFormalizacion";
            this.cmdAreaFideicomisos.CssClass = "AreasMenuLateralFideicomisos";
            this.cmdAreaAbogados.CssClass = "AreasMenuLateralAbogados";
            this.cmdAreaSeguimiento.CssClass = "AreasMenuLateralSeguimiento";
            this.cmdAreaBienesRealizables.CssClass = "AreasMenuLateralBienesRealizables";
            this.cmdAreaAdministracion.CssClass = "AreasMenuLateralAdministracion";

            #endregion

            treeViewAreaOpciones = treeReportes;

            setNavigateUrl(treeViewAreaOpciones);
            EfectosArbol();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdAreaContactoComercial_Click(object sender, EventArgs e)
    {
        try
        {
            ObtenerValoresSesion(); 

            #region EFECTOS SOBRE LAS AREAS DEL MENU

            //this.cmdAreaReportes.CssClass = "AreasMenuLateralReportes";
            this.cmdAreaContactoComercial.CssClass = "AreasMenuLateralContactoComercialSeleccionado";
            this.cmdAreaValuaciones.CssClass = "AreasMenuLateralValuaciones";
            this.cmdAreaPolizas.CssClass = "AreasMenuLateralPolizas";
            this.cmdAreaFormalizacion.CssClass = "AreasMenuLateralFormalizacion";
            this.cmdAreaFideicomisos.CssClass = "AreasMenuLateralFideicomisos";
            this.cmdAreaAbogados.CssClass = "AreasMenuLateralAbogados";
            this.cmdAreaSeguimiento.CssClass = "AreasMenuLateralSeguimiento";
            this.cmdAreaBienesRealizables.CssClass = "AreasMenuLateralBienesRealizables";
            this.cmdAreaAdministracion.CssClass = "AreasMenuLateralAdministracion";

            #endregion

            treeViewAreaOpciones = treeContacto;

            setNavigateUrl(treeViewAreaOpciones);
            EfectosArbol();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdAreaValuaciones_Click(object sender, EventArgs e)
    {
        try
        {
            #region EFECTOS SOBRE LAS AREAS DEL MENU

            this.cmdAreaReportes.CssClass = "AreasMenuLateralReportes";
            this.cmdAreaContactoComercial.CssClass = "AreasMenuLateralContactoComercial";
            this.cmdAreaValuaciones.CssClass = "AreasMenuLateralValuacionesSeleccionado";
            this.cmdAreaPolizas.CssClass = "AreasMenuLateralPolizas";
            this.cmdAreaFormalizacion.CssClass = "AreasMenuLateralFormalizacion";
            this.cmdAreaFideicomisos.CssClass = "AreasMenuLateralFideicomisos";
            this.cmdAreaAbogados.CssClass = "AreasMenuLateralAbogados";
            this.cmdAreaSeguimiento.CssClass = "AreasMenuLateralSeguimiento";
            this.cmdAreaBienesRealizables.CssClass = "AreasMenuLateralBienesRealizables";
            this.cmdAreaAdministracion.CssClass = "AreasMenuLateralAdministracion";

            #endregion

            treeViewAreaOpciones = treeValuaciones;

            setNavigateUrl(treeViewAreaOpciones);
            EfectosArbol();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdAreaPolizas_Click(object sender, EventArgs e)
    {
        try
        {
            #region EFECTOS SOBRE LAS AREAS DEL MENU

            this.cmdAreaReportes.CssClass = "AreasMenuLateralReportes";
            this.cmdAreaContactoComercial.CssClass = "AreasMenuLateralContactoComercial";
            this.cmdAreaValuaciones.CssClass = "AreasMenuLateralValuaciones";
            this.cmdAreaPolizas.CssClass = "AreasMenuLateralPolizasSeleccionado";
            this.cmdAreaFormalizacion.CssClass = "AreasMenuLateralFormalizacion";
            this.cmdAreaFideicomisos.CssClass = "AreasMenuLateralFideicomisos";
            this.cmdAreaAbogados.CssClass = "AreasMenuLateralAbogados";
            this.cmdAreaSeguimiento.CssClass = "AreasMenuLateralSeguimiento";
            this.cmdAreaBienesRealizables.CssClass = "AreasMenuLateralBienesRealizables";
            this.cmdAreaAdministracion.CssClass = "AreasMenuLateralAdministracion";

            #endregion

            treeViewAreaOpciones = treePolizas;

            setNavigateUrl(treeViewAreaOpciones);
            EfectosArbol();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdAreaFormalizacion_Click(object sender, EventArgs e)
    {
        try
        {
            #region EFECTOS SOBRE LAS AREAS DEL MENU

            this.cmdAreaReportes.CssClass = "AreasMenuLateralReportes";
            this.cmdAreaContactoComercial.CssClass = "AreasMenuLateralContactoComercial";
            this.cmdAreaValuaciones.CssClass = "AreasMenuLateralValuaciones";
            this.cmdAreaPolizas.CssClass = "AreasMenuLateralPolizas";
            this.cmdAreaFormalizacion.CssClass = "AreasMenuLateralFormalizacionSeleccionado";
            this.cmdAreaFideicomisos.CssClass = "AreasMenuLateralFideicomisos";
            this.cmdAreaAbogados.CssClass = "AreasMenuLateralAbogados";
            this.cmdAreaSeguimiento.CssClass = "AreasMenuLateralSeguimiento";
            this.cmdAreaBienesRealizables.CssClass = "AreasMenuLateralBienesRealizables";
            this.cmdAreaAdministracion.CssClass = "AreasMenuLateralAdministracion";

            #endregion

            treeViewAreaOpciones = treeFormalizacion;

            setNavigateUrl(treeViewAreaOpciones);
            EfectosArbol();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdAreaFideicomisos_Click(object sender, EventArgs e)
    {
        try
        {
            #region EFECTOS SOBRE LAS AREAS DEL MENU

            this.cmdAreaReportes.CssClass = "AreasMenuLateralReportes";
            this.cmdAreaContactoComercial.CssClass = "AreasMenuLateralContactoComercial";
            this.cmdAreaValuaciones.CssClass = "AreasMenuLateralValuaciones";
            this.cmdAreaPolizas.CssClass = "AreasMenuLateralPolizas";
            this.cmdAreaFormalizacion.CssClass = "AreasMenuLateralFormalizacion";
            this.cmdAreaFideicomisos.CssClass = "AreasMenuLateralFideicomisosSeleccionado";
            this.cmdAreaAbogados.CssClass = "AreasMenuLateralAbogados";
            this.cmdAreaSeguimiento.CssClass = "AreasMenuLateralSeguimiento";
            this.cmdAreaBienesRealizables.CssClass = "AreasMenuLateralBienesRealizables";
            this.cmdAreaAdministracion.CssClass = "AreasMenuLateralAdministracion";

            #endregion

            treeViewAreaOpciones = treeFideicomisos;

            setNavigateUrl(treeViewAreaOpciones);
            EfectosArbol();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdAreaAbogados_Click(object sender, EventArgs e)
    {
        try
        {
            #region EFECTOS SOBRE LAS AREAS DEL MENU

            this.cmdAreaReportes.CssClass = "AreasMenuLateralReportes";
            this.cmdAreaContactoComercial.CssClass = "AreasMenuLateralContactoComercial";
            this.cmdAreaValuaciones.CssClass = "AreasMenuLateralValuaciones";
            this.cmdAreaPolizas.CssClass = "AreasMenuLateralPolizas";
            this.cmdAreaFormalizacion.CssClass = "AreasMenuLateralFormalizacion";
            this.cmdAreaFideicomisos.CssClass = "AreasMenuLateralFideicomisos";
            this.cmdAreaAbogados.CssClass = "AreasMenuLateralAbogadosSeleccionado";
            this.cmdAreaSeguimiento.CssClass = "AreasMenuLateralSeguimiento";
            this.cmdAreaBienesRealizables.CssClass = "AreasMenuLateralBienesRealizables";
            this.cmdAreaAdministracion.CssClass = "AreasMenuLateralAdministracion";

            #endregion

            treeViewAreaOpciones = treeAbogados;

            setNavigateUrl(treeViewAreaOpciones);
            EfectosArbol();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdAreaSeguimiento_Click(object sender, EventArgs e)
    {
        try
        {
            #region EFECTOS SOBRE LAS AREAS DEL MENU

            this.cmdAreaReportes.CssClass = "AreasMenuLateralReportes";
            this.cmdAreaContactoComercial.CssClass = "AreasMenuLateralContactoComercial";
            this.cmdAreaValuaciones.CssClass = "AreasMenuLateralValuaciones";
            this.cmdAreaPolizas.CssClass = "AreasMenuLateralPolizas";
            this.cmdAreaFormalizacion.CssClass = "AreasMenuLateralFormalizacion";
            this.cmdAreaFideicomisos.CssClass = "AreasMenuLateralFideicomisos";
            this.cmdAreaAbogados.CssClass = "AreasMenuLateralAbogados";
            this.cmdAreaSeguimiento.CssClass = "AreasMenuLateralSeguimientoSeleccionado";
            this.cmdAreaBienesRealizables.CssClass = "AreasMenuLateralBienesRealizables";
            this.cmdAreaAdministracion.CssClass = "AreasMenuLateralAdministracion";

            #endregion

            treeViewAreaOpciones = treeSeguimiento;

            setNavigateUrl(treeViewAreaOpciones);
            EfectosArbol();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdAreaBienesRealizables_Click(object sender, EventArgs e)
    {
        try
        {
            #region EFECTOS SOBRE LAS AREAS DEL MENU

            this.cmdAreaReportes.CssClass = "AreasMenuLateralReportes";
            this.cmdAreaContactoComercial.CssClass = "AreasMenuLateralContactoComercial";
            this.cmdAreaValuaciones.CssClass = "AreasMenuLateralValuaciones";
            this.cmdAreaPolizas.CssClass = "AreasMenuLateralPolizas";
            this.cmdAreaFormalizacion.CssClass = "AreasMenuLateralFormalizacion";
            this.cmdAreaFideicomisos.CssClass = "AreasMenuLateralFideicomisos";
            this.cmdAreaAbogados.CssClass = "AreasMenuLateralAbogados";
            this.cmdAreaSeguimiento.CssClass = "AreasMenuLateralSeguimiento";
            this.cmdAreaBienesRealizables.CssClass = "AreasMenuLateralBienesRealizablesSeleccionado";
            this.cmdAreaAdministracion.CssClass = "AreasMenuLateralAdministracion";

            #endregion

            treeViewAreaOpciones = treeBienes;

            setNavigateUrl(treeViewAreaOpciones);
            EfectosArbol();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void cmdAreaAdministracion_Click(object sender, EventArgs e)
    {
        try
        {
            #region EFECTOS SOBRE LAS AREAS DEL MENU

            this.cmdAreaReportes.CssClass = "AreasMenuLateralReportes";
            this.cmdAreaContactoComercial.CssClass = "AreasMenuLateralContactoComercial";
            this.cmdAreaValuaciones.CssClass = "AreasMenuLateralValuaciones";
            this.cmdAreaPolizas.CssClass = "AreasMenuLateralPolizas";
            this.cmdAreaFormalizacion.CssClass = "AreasMenuLateralFormalizacion";
            this.cmdAreaFideicomisos.CssClass = "AreasMenuLateralFideicomisos";
            this.cmdAreaAbogados.CssClass = "AreasMenuLateralAbogados";
            this.cmdAreaSeguimiento.CssClass = "AreasMenuLateralSeguimiento";
            this.cmdAreaBienesRealizables.CssClass = "AreasMenuLateralBienesRealizables";
            this.cmdAreaAdministracion.CssClass = "AreasMenuLateralAdministracionSeleccionado";

            #endregion

            treeViewAreaOpciones = treeAdministracion;

            setNavigateUrl(treeViewAreaOpciones);
            EfectosArbol();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region METODOS ARBOL DE ROLES

    private void CargarArbol(TreeView arbol, int padre)
    {
        try
        {
            TreeNode nodo;
            arbol.Nodes.Clear();
            PantallasEntidad elemento;
            List<PantallasEntidad> retorno = new List<PantallasEntidad>();

            List<PantallasEntidad> _listaPantallas = wsSeguridad.PantallasConsulta().ToList();
            foreach (PantallasEntidad item in _listaPantallas)
            {
                if (item.PadreOrigen.Equals(padre))
                {
                    elemento = new PantallasEntidad();
                    elemento.CodPantalla = item.CodPantalla;
                    elemento.TituloPantalla = item.TituloPantalla;
                    elemento.PadreOrigen = item.PadreOrigen;
                    elemento.SubPadreOrigen = item.SubPadreOrigen;
                    elemento.RutaPantalla = item.RutaPantalla;
                    elemento.DesPantalla = item.DesPantalla;

                    retorno.Add(elemento);
                }
            }

            foreach (PantallasEntidad item in retorno)
            {
                nodo = new TreeNode();
                nodo.Text = item.TituloPantalla;
                nodo.Value = item.CodPantalla.ToString();
                nodo.NavigateUrl = item.RutaPantalla;
                nodo.ImageUrl = item.DesPantalla;

                CargarNodo(nodo, _listaPantallas);
                arbol.Nodes.Add(nodo);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarNodo(TreeNode nodo, List<PantallasEntidad> item)
    {
        try
        {
            TreeNode nNodo;
            List<PantallasEntidad> _lista = item.ToList();

            foreach (PantallasEntidad _item in _lista)
            {
                if (_item.PadreOrigen.ToString().Equals(nodo.Value))
                {
                    nNodo = new TreeNode();
                    nNodo.Text = _item.TituloPantalla;
                    nNodo.Value = _item.CodPantalla.ToString();
                    nNodo.NavigateUrl = _item.RutaPantalla;
                    nNodo.ImageUrl = _item.DesPantalla;

                    CargarNodo(nNodo, item);
                    nodo.ChildNodes.Add(nNodo);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void Arboles()
    {
        CargarArbol(treeContacto, 2);
        CargarArbol(treeValuaciones, 3);
        CargarArbol(treePolizas, 4);
        CargarArbol(treeFormalizacion, 5);
        CargarArbol(treeFideicomisos, 6);
        CargarArbol(treeAbogados, 7);
        CargarArbol(treeSeguimiento, 8);
        CargarArbol(treeBienes, 9);
        CargarArbol(treeAdministracion, 10);
        CargarArbol(treeReportes, 11);
    }

    private void EfectosArbol()
    {        
        treeViewAreaOpciones.NodeWrap = true;
        treeViewAreaOpciones.NodeIndent = 5;

        //MANTENER LOS NODOS CONTRAIDOS
        treeViewAreaOpciones.CollapseAll();
        treeViewAreaOpciones.ExpandDepth = 0;        

        this.MenuLateralArbol.Controls.Clear();
        this.MenuLateralArbol.Controls.Add(treeViewAreaOpciones);

        //ESTILO PARA EL ARBOL DEL MENU
        treeViewAreaOpciones.NodeStyle.CssClass = "AreasMenuLateralArbolNodo";
        treeViewAreaOpciones.LeafNodeStyle.CssClass = "AreasMenuLateralArbolHoja";
    }

    #endregion

    #endregion

    #region METODOS NO PERSONALIZABLES

    protected void setNavigateUrl(TreeView arbol)
    {
        int i = 0;
        foreach (TreeNode t in arbol.Nodes)
        {
            t.NavigateUrl = "javascript:selectedNode('" + t.NavigateUrl.Replace("~/", "") + "', '" + idSesionOculto.Value + "', '" + codUsuarioOculto.Value + "', '" + t.Value + "'); ";
            setNavigateUrlForChildren(arbol, t, ref i);
        }
    }

    private void setNavigateUrlForChildren(TreeView arbol, TreeNode t, ref int i)
    {
        i++;
        foreach (TreeNode child in t.ChildNodes)
        {
            child.NavigateUrl = "javascript:selectedNode('" + child.NavigateUrl.Replace("~/", "") + "', '" + idSesionOculto.Value + "', '" + codUsuarioOculto.Value + "', '" + child.Value + "'); ";
            setNavigateUrlForChildren(arbol, child, ref i);
        }
    }

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsSeguridad.Url = ConfigurationManager.AppSettings["SeguridadWS"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    #endregion
    
}