using System;
using System.Web;
using System.Text;
using System.Linq;
using System.Data;
using System.Web.UI;
using System.Reflection;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using ListasWS;
using GarantiasWS;

using BCR.SIGANEM.UT;
using AjaxControlToolkit;

public partial class wucOperacionesGridGarantias : System.Web.UI.UserControl
{

    #region PROPIEDADES

    #region VARIABLES

    private GeneradorControles generadorControles = new GeneradorControles();

    #endregion

    #region REFERENCIAS

    private SiganemListasWS wsListas = new SiganemListasWS();
    private SiganemGarantiasWS wsGarantias = new SiganemGarantiasWS();

    #endregion

    public bool Enabled
    {
        set { pnlGridView.Enabled = value; }
    } 

    #endregion

    #region DATOS GRIDVIEW

    public void BindGridView(DataSet _dataSet)
    {
        this.MasterGridView.DataSource = _dataSet;
        this.MasterGridView.DataBind();
    }

    public void BindGridView(DataTable _dataTable)
    {
        this.MasterGridView.DataSource = _dataTable;
        this.MasterGridView.DataBind();
    }

    public void BindGridView(Object _object)
    {
        this.MasterGridView.DataSource = _object;
        this.MasterGridView.DataBind();
    }

    //AGREGA UNA CASILLA DE SELECCION AL FINAL DE CADA FILA
    protected void MasterGridView_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell tc = new TableCell();
            CheckBox chk = new CheckBox();
            chk.ID = "chkBox1";
            chk.AutoPostBack = false;
            tc.Controls.Add(chk);
            tc.Width = Unit.Pixel(5);

            e.Row.Cells.Add(tc);
        }
    }

    //OCULTA LAS FILAS ELIMINADAS DE FORMA VISUAL
    protected void MasterGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[e.Row.Cells.Count - 2].Text.Equals("0") || ((Label)e.Row.Cells[e.Row.Cells.Count - 2].FindControl("lblId_Visible")).Text.Equals("0"))
            {
                e.Row.Visible = false;
            }
        }
    }

    #endregion 

    #region METODOS PUBLICOS

    public void LimpiarControlesDropDownListOperacionGrid(bool agregar)
    {
        LimpiarDropDownList(ddlTipoGarantia);
    }

    public void habilitarBotonesGrid(bool _estado)
    {
        if (_estado)
        {
            this.imgCmdAgregar.Enabled = _estado;
            this.imgCmdAgregar.CssClass = "imgCmdAgregarSICC";

            this.imgCmdModificar.Enabled = _estado;
            this.imgCmdModificar.CssClass = "imgCmdModificarSICC";

            this.imgCmdEliminar.Enabled = _estado;
            this.imgCmdEliminar.CssClass = "imgCmdEliminarSICC";
            
            this.imgCmdBorrarSICC.Enabled = _estado;
            this.imgCmdBorrarSICC.CssClass = "imgCmdBorrarSICC";

            this.btnActualizarGrid.Enabled = _estado;
            this.btnActualizarGrid.CssClass = "imgCmdActualizarSICC";
        }
        else
        {
            this.imgCmdAgregar.Enabled = _estado;
            this.imgCmdAgregar.CssClass = "imgCmdAgregarSICCDisabled";

            this.imgCmdModificar.Enabled = _estado;
            this.imgCmdModificar.CssClass = "imgCmdModificarSICCDisabled";

            this.imgCmdEliminar.Enabled = _estado;
            this.imgCmdEliminar.CssClass = "imgCmdEliminarSICCDisabled";
            
            this.imgCmdBorrarSICC.Enabled = _estado;
            this.imgCmdBorrarSICC.CssClass = "imgCmdBorrarSICCDisabled";

            this.btnActualizarGrid.Enabled = _estado;
            this.btnActualizarGrid.CssClass = "imgCmdActualizarSICCDisabled";
        }

        AdministrarBlanco(ddlTipoGarantia, !_estado);
        this.ddlTipoGarantia.Enabled = _estado;
        this.MasterGridView.Enabled = _estado;
    }

    public void CargarControlesOperacionGrid(List<ControlEntidad> controles)
    {
        try
        {
            AsignaWebServicesTypeNames();
            ControlEntidad controlSeleccionado = null;

            #region CONTROLES TIPO GARANTIA

            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.lblTipoGarantia.ID);
            this.lblTipoGarantia.Text = controlSeleccionado.DesColumna;
            //ASIGNAR DROPDOWNLIST AL CONTROL
            controlSeleccionado = BuscarControlesConsultaOperacion(controles, this.ddlTipoGarantia.ID);
            //CARGAR EL DROPDOWNLIS
            //Req F2S03 2016-21-06 - Agregar filtros 8, 11
            CargarDropDownListControl(controlSeleccionado, ddlTipoGarantia, "2,3,4,8,11");
            AdministrarBlanco(ddlTipoGarantia, true);

            #endregion  
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    public int ContadorSeleccionados()
    {
        int cantidad = 0;

        //VERIFICA QUE SOLO EXISTA UN REGISTRO SELECCIONADO PARA LA EDICION
        foreach (GridViewRow row1 in MasterGridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[row1.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                cantidad++;
            }
        }

        return cantidad;
    }

    public bool ContieneRegistros()
    {
        if (this.MasterGridView.Rows.Count > 0)
            return true;
        else
            return false;
    }

    public List<string> ObtenerValoresSeleccionados(string nombreColumnaOculta)
    {
        List<string> retorno = new List<string>();
        string elemento = string.Empty;
        foreach (GridViewRow row in this.MasterGridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[row.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                elemento = ((Label)row.Cells[1].FindControl(nombreColumnaOculta)).Text;
                retorno.Add(elemento);
            }
        }

        return retorno;
    }

    public void LimpiarValoresSeleccionados(string nombreColumnaOculta)
    {
        List<string> retorno = new List<string>();
        string elemento = string.Empty;
        foreach (GridViewRow row1 in this.MasterGridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[row1.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                checkBoxColumn.Checked = false;
            }
        }
    }

    public List<KeyValuePair<int, string>> ObtenerTodosValoresSeleccionados(string nombreColumnaOcultaId)
    {
        List<KeyValuePair<int, string>> retorno = new List<KeyValuePair<int, string>>();
        StringBuilder elemento = new StringBuilder();

        for (int r = 0; r < this.MasterGridView.Rows.Count; r++)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[r].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                elemento.Clear();

                //CELLS.COUNT-1 DEBIDO A QUE SE IGNORA LA CELDA DEL CHECKBOX
                for (int c = 1; c < MasterGridView.Rows[r].Cells.Count - 1; c++)
                {
                    elemento.Append(MasterGridView.Rows[r].Cells[c].Text);
                    elemento.Append("|");
                }

                //SE AGREGA EL ID PRINCIPAL
                elemento.Append(((Label)MasterGridView.Rows[r].Cells[0].FindControl(nombreColumnaOcultaId)).Text);

                retorno.Add(new KeyValuePair<int, string>(r, elemento.ToString()));
            }
        }

        return retorno;
    }

    public int ContadorSeleccionadosReplicado()
    {
        int cantidad = 0;

        //VERIFICA QUE SOLO EXISTA UN REGISTRO SELECCIONADO PARA LA EDICION
        foreach (GridViewRow row in MasterGridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[row.RowIndex].FindControl("chkBox1");
            string Estado = MasterGridView.Rows[row.RowIndex].Cells[3].Text;
            if (checkBoxColumn.Checked && Estado.Equals("Replicado"))
            {
                cantidad++;
            }
        }

        return cantidad;
    }

    #region REQUERIMIENTO 1-24493262 REPLICAS SICC

    public List<string> ObtenerValoresReplicaSICC(string nombreColumnaOculta)
    {
        List<string> retorno = new List<string>();
        string elemento = string.Empty;
        foreach (GridViewRow row in this.MasterGridView.Rows)
        {
            string Estado = MasterGridView.Rows[row.RowIndex].Cells[3].Text;
            if (!Estado.Equals("Replicado"))
            {
                elemento = ((Label)row.Cells[1].FindControl(nombreColumnaOculta)).Text;

                retorno.Add(elemento);
            }
        }

        return retorno;
    }

    public List<GarantiasOperacionesEntidad> ObtenerValoresTramasSICC()
    {
        GarantiasOperacionesEntidad elemento = null;
        List<GarantiasOperacionesEntidad> retorno = new List<GarantiasOperacionesEntidad>();
        
        foreach (GridViewRow row in this.MasterGridView.Rows)
        {
            string Estado = MasterGridView.Rows[row.RowIndex].Cells[3].Text;
            if (!Estado.Equals("Replicado"))
            {
                elemento = new GarantiasOperacionesEntidad();
                elemento.IdGarantiaOperacion = int.Parse(((Label)row.Cells[1].FindControl("lblIdGarantiaOperacion")).Text);
                elemento.DesTipoOperacion = row.Cells[1].Text;
                elemento.EstadoOperacionSICC = row.Cells[3].Text;
                elemento.DesTipoBien = ((Label)row.Cells[4].FindControl("lblDesTipoBien")).Text;
                elemento.DesClaseTipoBien = ((Label)row.Cells[5].FindControl("lblDesClaseTipoBien")).Text;

                retorno.Add(elemento);
            }
        }

        return retorno;
    }

    public List<GarantiasOperacionesEntidad> ObtenerValoresSeleccionadosSICC()
    {
        GarantiasOperacionesEntidad elemento = null;
        List<GarantiasOperacionesEntidad> retorno = new List<GarantiasOperacionesEntidad>();

        foreach (GridViewRow row in this.MasterGridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[row.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                string Estado = MasterGridView.Rows[row.RowIndex].Cells[3].Text;
                if (Estado.Equals("Replicado"))
                {
                    elemento = new GarantiasOperacionesEntidad();
                    elemento.IdGarantiaOperacion = int.Parse(((Label)row.Cells[1].FindControl("lblIdGarantiaOperacion")).Text);
                    elemento.DesTipoOperacion = row.Cells[1].Text;
                    elemento.EstadoOperacionSICC = row.Cells[3].Text;
                    elemento.DesTipoBien = ((Label)row.Cells[4].FindControl("lblDesTipoBien")).Text;
                    elemento.DesClaseTipoBien = ((Label)row.Cells[5].FindControl("lblDesClaseTipoBien")).Text;

                    retorno.Add(elemento);
                }
            }
        }

        return retorno;
    }

    public Boolean ValidarEstadoGarantiaFiduciaria(int valorGarantiaOperacion)
    {
        bool retorno = false;
        
        foreach (GridViewRow row in this.MasterGridView.Rows)
        {
            int elemento = int.Parse(((Label)row.Cells[1].FindControl("lblIdGarantiaOperacion")).Text);
            if (elemento.Equals(valorGarantiaOperacion))
            {
                string Estado = MasterGridView.Rows[row.RowIndex].Cells[3].Text;
                if (Estado.Equals("Replicado") && row.Cells[1].Text.Contains("Fiduciaria"))
                {
                    retorno = true;
                    break;
                }
            }
        }

        return retorno;
    }

    public Boolean ValidarEstadoGarantiaAvales(int valorGarantiaOperacion)
    {
        bool valorRetorno = false;

        foreach (GridViewRow row in this.MasterGridView.Rows)
        {
            int elemento = int.Parse(((Label)row.Cells[1].FindControl("lblIdGarantiaOperacion")).Text);
            if (elemento.Equals(valorGarantiaOperacion))
            {
                string Estado = MasterGridView.Rows[row.RowIndex].Cells[3].Text;
                if (Estado.Equals("Replicado") && row.Cells[1].Text.Contains("Avales"))
                {
                    valorRetorno = true;
                    break;
                }
            }
        }

        return valorRetorno;
    }

    public Boolean ValidarEstadoGarantiaEliminar(int valorGarantiaOperacion)
    {
        bool retorno = false;

        foreach (GridViewRow row in this.MasterGridView.Rows)
        {
            int elemento = int.Parse(((Label)row.Cells[1].FindControl("lblIdGarantiaOperacion")).Text);
            if (elemento.Equals(valorGarantiaOperacion))
            {
                string Estado = MasterGridView.Rows[row.RowIndex].Cells[3].Text;
                if (Estado.Equals("Replicado"))
                {
                    retorno = true;
                    break;
                }
            }
        }

        return retorno;
    }

    public string ObtenerEstadoGarantiaSeleccionado()
    {
        string _estado = string.Empty;

        foreach (GridViewRow row in this.MasterGridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[row.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                _estado = MasterGridView.Rows[row.RowIndex].Cells[3].Text;
                break;
            }
        }

        return _estado;
    }

    #endregion

    #region VALIDACIONES

    //VERIFICA SI EL GRID SE ENCUENTRA VACIO
    public int ExisteRegistros(DataTable dt)
    {
        int retorno = 0; //0 =  NO EXISTE | 1 = EXISTE
        for (int r = 0; r < dt.Rows.Count ; r++)
        {
            //SI LA FILA ES VISIBLE
            if (dt.Rows[r][dt.Columns.Count - 1].ToString().Equals("1"))
            {
                retorno = 1;
                break;
            }
        }

        return retorno;
    }

    #endregion

    #endregion

    #region PRIVATOS METODOS

    private void AsignaWebServicesTypeNames()
    {
        try
        {
            wsListas.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();
            wsGarantias.Url = ConfigurationManager.AppSettings["GarantiasWS"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(ConfigurationManager.AppSettings["Culture"].ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ConfigurationManager.AppSettings["Culture"].ToString());
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    private ControlEntidad BuscarControlesConsultaOperacion(List<ControlEntidad> controlEntidad, string nombreControl)
    {
        nombreControl = nombreControl.Replace("txt", "").Replace("ddl", "").Replace("lbl", "").Replace("msk", "").Replace("rfv", "");
        ControlEntidad _control = (from control in controlEntidad
                                   where control.NombrePropiedad.Equals(nombreControl)
                                   select control).First();

        return _control;
    }

    private void CargarDropDownListControl(ControlEntidad _control, DropDownList _dropDownList, string _filtro)
    {
        #region DROPDOWNLIST
        //LIMPIAR EL CONTROL DROPDOWNLIST
        LimpiarDropDownList(_dropDownList);
        //CARGAR EL DROPDOWNLIS
        _dropDownList.DataSource = LlenarDropDownList(_control.MetodoServicioWeb, _filtro);
        _dropDownList.DataValueField = "Valor";
        _dropDownList.DataTextField = "Texto";
        _dropDownList.DataBind();
        _dropDownList.Enabled = bool.Parse(_control.IndModificar);
        _dropDownList.Visible = bool.Parse(_control.IndVisible);
        _dropDownList.CssClass = _control.CssTipo;

        #endregion
    }

    private void LimpiarDropDownList(DropDownList _dropDownList)
    {
        //BORRA LOS VALORES DEL DDL, SE DEBE DE REALIZAR DE ESTA MANERA PARA ELIMINAR LOS DATOS EN CACHÉ DEL OBJ
        _dropDownList.ClearSelection();
        _dropDownList.Items.Clear();
        _dropDownList.SelectedValue = null;
        _dropDownList.DataSource = null;
    }

    private Object LlenarDropDownList(string wsMethodName, string filtro)
    {
        try
        {
            Type ws = wsListas.GetType();
            MethodInfo method = ws.GetMethod(wsMethodName);
            var result = method.Invoke(wsListas, new object[] { filtro });

            return result;
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);

            return null;
        }
    }

    //AGREGA O ELIMINA UN ITEM EN BLANCO
    private void AdministrarBlanco(DropDownList _dropDownList, bool agregar)
    {
        try
        {
            bool existeBlanco = false;
            int posicion = 0;
            DropDownList ddl = _dropDownList;

            if (ddl != null)
            {
                //VERIFICA SI EXISTE EL ITEM EN BLANCO Y SU POSICION
                for (int c = 0; c < ddl.Items.Count; c++)
                {
                    if (ddl.Items[c].Text.Equals(" "))
                    {
                        existeBlanco = true;
                        posicion = c;
                    }
                }

                //AGREGA UN NUEVO ITEM EN BLANCO
                if ((!existeBlanco) && (agregar))
                {
                    ddl.Items.Add(new ListItem(" ", "-1"));
                    ddl.SelectedValue = "-1";
                }

                //ELIMINA EL ITEM EN BLANCO
                if ((existeBlanco) && (!agregar))
                {
                    ddl.Items.RemoveAt(posicion);
                    ddl.SelectedIndex = 0;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

}