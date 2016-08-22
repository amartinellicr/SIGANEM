using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;


public class GridViewTemplate : ITemplate
{

    #region PROPIEDADES

    public GridViewTemplate() { }

    private DataControlRowType templateType;
    private string columnName;
    private string expression;

    #endregion

    #region ITEMPLATE METODOS

    public GridViewTemplate(DataControlRowType type, string colname)
    {
        templateType = type;
        columnName = colname;
    }

    public GridViewTemplate(DataControlRowType type, string colname, string _expression)
    {
        templateType = type;
        columnName = colname;
        expression = _expression;
    }

    public void InstantiateIn(System.Web.UI.Control container)
    {
        switch (templateType)
        {
            case DataControlRowType.Header:
                Literal lc = new Literal();
                lc.Text = "<b>" + columnName + "</b>";
                container.Controls.Add(lc);
                break;

            case DataControlRowType.DataRow:
                Label label = new Label();
                label.ID = "lbl" + columnName;
                label.DataBinding += new EventHandler(this.label_DataBinding);
                container.Controls.Add(label);
                break;
            default:
                break;
        }
    }

    private void label_DataBinding(Object sender, EventArgs e)
    {
        Label lb = (Label)sender;
        GridViewRow row = (GridViewRow)lb.NamingContainer;
        lb.Text = DataBinder.Eval(row.DataItem, this.expression).ToString();
    }

    public void CrearCamposGridNoVisibles(GridView _gridView, string _valor, TemplateField _campo)
    {
        _campo.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, _valor, _valor);
        _campo.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, _valor);
        _campo.HeaderText = _valor;
        _campo.Visible = false;
        _gridView.Columns.Add(_campo);
    }

    #endregion

    #region IDISPOSABLE MEMBERS

    /// <summary>
    /// Propiedad IDisposable
    /// </summary>
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing) { }
            disposed = true;
        }
    }

    ~GridViewTemplate()
    {
        Dispose(false);
    }

    #endregion

}
