using System;
using System.Web;
using System.Data;
using System.Text;
using System.Linq;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;


public partial class wucGridEmergente : System.Web.UI.UserControl
{

    #region DATOS GRIDVIEW

    /*CARGA LOS DATOS AL GRIDVIEW*/
    public void BindGridView(Object _dataSet)
    {
        this.MasterGridView.DataSource = _dataSet;
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
            tc.Controls.Add(chk);
            tc.Width = Unit.Pixel(5);

            e.Row.Cells.Add(tc);
        }
    }

    protected string AsignarGridVacio()
    {
        return hdnSinDatos.Value;
    }

    public void TextoGridVacio(string valor)
    {
        hdnSinDatos.Value = valor;
    }

    #endregion 

    #region VALIDACIONES

    //OBTIENE LA CANTIDAD DE FILAS SELECCIONADAS
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

    public bool ContieneRegistros()
    {
        if (this.MasterGridView.Rows.Count > 0)
            return true;
        else
            return false;
    }

    #endregion

    #region FUNCIONES

    public List<string> ObtenerValoresSeleccionados(string nombreColumnaOculta) 
    {
        List<string> retorno = new List<string>();
        string elemento = string.Empty;
        foreach (GridViewRow row1 in this.MasterGridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[row1.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                elemento = row1.Cells[0].Text + '|' + ((Label)row1.Cells[1].FindControl(nombreColumnaOculta)).Text;
                retorno.Add(elemento);
            }
        }

        return retorno;
    }

    public List<string> ObtenerValoresSeleccionadosOcultos(string nombreColumnaOculta1, string nombreColumnaOculta2)
    {
        List<string> retorno = new List<string>();
        string elemento = string.Empty;
        foreach (GridViewRow row1 in this.MasterGridView.Rows)
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[row1.RowIndex].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                elemento = ((Label)row1.Cells[1].FindControl(nombreColumnaOculta2)).Text + '|' + ((Label)row1.Cells[1].FindControl(nombreColumnaOculta1)).Text;
                retorno.Add(elemento);
            }
        }

        return retorno;
    }

    public List<KeyValuePair<int,string>> ObtenerTodosValoresSeleccionados(string nombreColumnaOcultaId)
    {
        List<KeyValuePair<int, string>> retorno = new List<KeyValuePair<int, string>>();
        StringBuilder elemento = new StringBuilder();

        for (int r = 0; r < this.MasterGridView.Rows.Count; r++ )
        {
            CheckBox checkBoxColumn = (CheckBox)MasterGridView.Rows[r].FindControl("chkBox1");
            if (checkBoxColumn.Checked)
            {
                elemento.Clear();

                //CELLS.COUNT-1 DEBIDO A QUE SE IGNORA LA CELDA DEL CHECKBOX
                for (int c = 1; c < MasterGridView.Rows[r].Cells.Count-1; c++)
                {
                    elemento.Append(MasterGridView.Rows[r].Cells[c].Text);
                    elemento.Append("|");
                }

                //SE AGREGA EL ID PRINCIPAL
                elemento.Append(((Label)MasterGridView.Rows[r].Cells[0].FindControl(nombreColumnaOcultaId)).Text);
                
                retorno.Add(new KeyValuePair<int, string>(r,elemento.ToString()));
            }
        }

        return retorno;
    }

    #endregion

}