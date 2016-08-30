using System;
using System.Web;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections.Specialized;

using ListasWS;
using BCR.SIGANEM.UT;

using SeguridadWS;

public partial class wucMenuLateralDetalle : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region VARIABLES
    
    static TreeView treeViewAreaOpciones = new TreeView();

    #endregion

    #region REFERENCIAS

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();

    #endregion

    #endregion

    #region METODOS PERSONALIZADOS

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            AsignaWebServicesTypeNames();

            if (!IsPostBack)
            {
                #region OBTENER VALORES SESION
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
                    }
                }
                #endregion
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }   
    
    #region METODOS ARBOL DE ROLES

    public void CargarArbol(DataTable dataTable)
    {
        try
        {
            treeViewAreaOpciones.Nodes.Clear();

            TreeNode nodo = new TreeNode();
            nodo.Text = "Información";
            nodo.Value = "Informacion";
            CargarNodo(nodo, dataTable);
            treeViewAreaOpciones.Nodes.Add(nodo);

            EfectosArbol();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarNodo(TreeNode nodo, DataTable dt)
    {
        try
        {
            DataRow[] _DataRow = (DataRow[])dt.Select();
            TreeNode nNodo;

            foreach (DataRow item in _DataRow)
            {
                nNodo = new TreeNode();
                nNodo.Text = "<a href='#" + "ctl00_ContentPlaceHolder1_" + item[0].ToString() + "' class='AreasMenuLateralDetalleArbolAnclas'>" + item[1].ToString() + "</a>";
                nNodo.Value = item[0].ToString();
                nodo.ChildNodes.Add(nNodo);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void CargarArbol(List<NodoMenuEntidad> opcionMenu)
    {
        try
        {
            treeViewAreaOpciones.Nodes.Clear();

            TreeNode nodo = new TreeNode();
            nodo.Text = "Información";
            nodo.Value = "Informacion";
            CargarNodo(nodo, opcionMenu);
            treeViewAreaOpciones.Nodes.Add(nodo);

            EfectosArbol();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarNodo(TreeNode nodo, List<NodoMenuEntidad> opcionMenu)
    {
        try
        {
            TreeNode nNodo;

            foreach (NodoMenuEntidad item in opcionMenu)
            {
                nNodo = new TreeNode();
                nNodo.Text = "<a href='#" + "ctl00_ContentPlaceHolder1_" + item.Url + "' class='AreasMenuLateralDetalleArbolAnclas'>" + item.Nombre + "</a>";
                nNodo.Value = item.Url.ToString();
                nodo.ChildNodes.Add(nNodo);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void EfectosArbol()
    {
        treeViewAreaOpciones.NodeWrap = true;
        treeViewAreaOpciones.NodeIndent = 5;
        //MANTENER LOS NODOS CONTRAIDOS
        //treeViewAreaOpciones.CollapseAll();
        //treeViewAreaOpciones.ExpandDepth = 0;
        //EFECTOS DEL STYLE
        treeViewAreaOpciones.NodeStyle.CssClass = "AreasMenuLateralDetalleArbolNodo";
        treeViewAreaOpciones.LeafNodeStyle.CssClass = "AreasMenuLateralDetalleArbolHoja";
        //SE AGRE EL ARBOL AL CONTTROL
        this.MenuLateralDetalleArbol.Controls.Clear();
        this.MenuLateralDetalleArbol.Controls.Add(treeViewAreaOpciones);
    }

    #endregion

    #endregion

    #region METODOS NO PERSONALIZABLES

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsListas.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();
            wsSeguridad.Url = ConfigurationManager.AppSettings["SeguridadWS"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

}