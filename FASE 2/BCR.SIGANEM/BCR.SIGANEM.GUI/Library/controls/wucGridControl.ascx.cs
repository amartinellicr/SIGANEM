using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;


public partial class wucGridControl : System.Web.UI.UserControl
{
    
    #region DATOS GRIDVIEW

    public void GridView_Init(string logico, string visual)
    {
        GridViewTemplate _gvTemplate = new GridViewTemplate();
        GridViewColumn gridViewColumn;
        TemplateField lblID;
        String [] _logico =  logico.Split('|');
        String[] _visual = visual.Split('|');
        string formato = string.Empty;

        for (int r = 0; r < _logico.Length; r++) 
        {
            if (!_logico[r].ToString().Substring(0,2).Equals("Id"))
            {
                gridViewColumn = new GridViewColumn();
                if (_logico[r].ToString().Substring(0, 5).ToUpper().Contains("MONTO") || _logico[r].ToString().Substring(0, 5).ToUpper().Contains("VALOR") || _logico[r].ToString().Substring(0, 5).ToUpper().Contains("SALDO"))
                {
                    formato = "{0:N}";
                }
                else
                {
                    if (_logico[r].ToString().ToUpper().Contains("FECHA"))
                        formato = "{0:d}";
                    else
                        formato = string.Empty;
                }

                MasterGridView.Columns.Add(gridViewColumn.CreateBoundField(_logico[r].ToString(), formato, _visual[r].ToString(), HorizontalAlign.Center, false, true));
            }
            else
            {
                lblID = new TemplateField();
                _gvTemplate.CrearCamposGridNoVisibles(MasterGridView, _logico[r].ToString(), lblID);
            }
        }
        
    }
    
    /*CARGA LOS DATOS AL GRIDVIEW*/
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

    /*AGREGA UNA CASILLA DE SELECCION AL FINAL DE CADA FILA*/
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

    /*OCULTA LAS FILAS ELIMINADAS DE FORMA VISUAL*/
    protected void MasterGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblIdVisible = null;
        //    foreach (TableCell celda in e.Row.Cells)
        //    {
        //        lblIdVisible = (Label)celda.FindControl("lblId_Visible");
        //        if (lblIdVisible != null)
        //            break;
        //    }

        //    if (e.Row.Cells[e.Row.Cells.Count - 2].Text.Equals("0") || lblIdVisible.Text.Equals("0"))
        //    {
        //        e.Row.Visible = false;
        //    }

        //    //if (e.Row.Cells[e.Row.Cells.Count - 2].Text.Equals("0") || ((Label)e.Row.Cells[e.Row.Cells.Count - 2].FindControl("lblId_Visible")).Text.Equals("0"))
        //    //{
        //    //    e.Row.Visible = false;
        //    //}
        //}
    }

    #endregion 
     
    #region VALIDACIONES

    /*VERIFICA SI EL GRID SE ENCUENTRA VACIO*/
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

    public int VerificaDuplicado(DataTable dt, int celda_1, int celda_2, int celda_3, string valor_1, string valor_2, string valor_3)
    {
        int duplicado = 0; //0 = NO | 1 = SI
        
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i][dt.Columns.Count - 1].ToString().Equals("1"))
            {
                if (dt.Rows[i][celda_1].ToString().Equals(valor_1) && dt.Rows[i][celda_2].ToString().Equals(valor_2) && dt.Rows[i][celda_3].ToString().Equals(valor_3))
                {
                    duplicado = 1;
                }
            }
        }

        return duplicado;
    }

    public int VerificaDuplicado(DataTable dt, int celda_1, int celda_2, string valor_1, string valor_2)
    {
        int duplicado = 0; //0 = NO | 1 = SI
        
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i][dt.Columns.Count - 1].ToString().Equals("1"))
            {
                if (dt.Rows[i][celda_1].ToString().Equals(valor_1) && dt.Rows[i][celda_2].ToString().Equals(valor_2) )
                {
                    duplicado = 1;
                }
            }
        }

        return duplicado;
    }

    #endregion

    #region FUNCIONES

    public bool ContieneRegistros()
    {
        if (this.MasterGridView.Rows.Count > 0)
            return true;
        else
            return false;
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

    /*OBTIENE LA CANTIDAD DE FILAS SELECCIONADAS*/
    public int ContadorSeleccionados()
    {
        int cantidad = 0;

        foreach (GridViewRow row1 in this.MasterGridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[row1.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                cantidad++;
            }
        }

        return cantidad;
    }

    /*OBTIENE LA CANTIDAD DE FILAS*/
    public int ContadorElementos()
    {
        return this.MasterGridView.Rows.Count;

    }

    /*OBTIENE LA SUMA DE UNA COLUMNA*/
    public decimal SumarElementos(string nombreColuma)
    {
        decimal retorno = 0;
        int columna = 0;

        for(int i=0;i<this.MasterGridView.Columns.Count; i++)
        {
            if (this.MasterGridView.Columns[i].GetType().Name.Equals("BoundField"))
                if(((BoundField)this.MasterGridView.Columns[i]).DataField.ToString().Equals(nombreColuma) )
                    columna = i;
        }

        foreach (GridViewRow row1 in this.MasterGridView.Rows)
        {
            if (row1.RowType == DataControlRowType.DataRow)
            {
                if (row1.Cells[columna].Text.Length > 0)
                    retorno += decimal.Parse(row1.Cells[columna].Text);
            }
        }

        return retorno;

    }

    /*OCULTA FILAS AL ELIMINAR UN REGISTRO DE MANERA VISUAL*/
    public void OcultarFilas(DataTable dt) 
    {
        foreach (GridViewRow row1 in this.MasterGridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[row1.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                row1.Visible = false;
                dt.Rows[row1.RowIndex][row1.Cells.Count - 2] = "0";
                row1.Cells[row1.Cells.Count - 2].Text = "0";
            }
        }
    }

    public void HabilitarBotonesControl(bool _estado)
    {
        imgCmdAgregar.Enabled = _estado;
        imgCmdEliminar.Enabled = _estado;

        if (_estado)
        {
            imgCmdAgregar.CssClass = "imgCmdAgregar";
            imgCmdEliminar.CssClass = "imgCmdEliminar";
        }
        else
        {
            imgCmdAgregar.ToolTip = String.Empty;
            imgCmdEliminar.ToolTip = String.Empty;
            
            imgCmdAgregar.CssClass = "imgCmdAgregarDisabled";
            imgCmdEliminar.CssClass = "imgCmdEliminarDisabled";
        }
        
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

}
