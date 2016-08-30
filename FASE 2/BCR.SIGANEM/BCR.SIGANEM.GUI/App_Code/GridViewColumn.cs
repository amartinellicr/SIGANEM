using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Collections.Generic;


public class GridViewColumn
{

    #region PROPIEDADES

    public GridViewColumn() { }

    #endregion

    #region METODOS PERSONALIZADOS

    public BoundField CreateBoundField(String _DataField, BoundFieldType bType, Nullable<int> d, String _HeaderText,
        HorizontalAlign _HorizontalAlign, Boolean _ReadOnly, Boolean _Visible)
    {
        BoundField boundField = new BoundField();
        boundField.DataField = _DataField;
        boundField.DataFormatString = DetermineBoudFieldType(bType, d);
        boundField.HeaderText = _HeaderText;
        boundField.ItemStyle.HorizontalAlign = _HorizontalAlign;
        boundField.ReadOnly = _ReadOnly;
        boundField.Visible = _Visible;

        boundField.HtmlEncode = false;

        return boundField;
    }

    public BoundField CreateBoundField(String _DataField, String _DataFormatString, String _HeaderText,
        HorizontalAlign _HorizontalAlign, Boolean _ReadOnly, Boolean _Visible)
    {
        BoundField boundField = new BoundField();
        boundField.DataField = _DataField;
        boundField.DataFormatString = _DataFormatString;
        boundField.HeaderText = _HeaderText;
        boundField.ItemStyle.HorizontalAlign = _HorizontalAlign;
        boundField.ReadOnly = _ReadOnly;
        boundField.Visible = _Visible;

        boundField.HtmlEncode = false;

        return boundField;
    }

    public ButtonField CreateButtonField(Boolean _CausesValidation, String _cmdName, String _HeaderText,
        String _ImageURL, Boolean _ShowHeader)
    {
        ButtonField buttonField = new ButtonField();
        buttonField.ButtonType = ButtonType.Image;
        buttonField.CausesValidation = _CausesValidation;
        buttonField.CommandName = _cmdName;
        buttonField.HeaderText = _HeaderText;
        buttonField.ImageUrl = _ImageURL;
        buttonField.ShowHeader = _ShowHeader;

        return buttonField;
    }

    public CheckBoxField CreateCheckBoxField(String _HeaderText, Boolean _ShowHeader, bool _ReadOnly)
    {
        CheckBoxField checkBoxField = new CheckBoxField();
        checkBoxField.HeaderText = _HeaderText;
        checkBoxField.ShowHeader = _ShowHeader;
        checkBoxField.ReadOnly = _ReadOnly;
        checkBoxField.HeaderStyle.ForeColor = Color.White;
        checkBoxField.ItemStyle.Width = Unit.Pixel(5);

        return checkBoxField;
    }

    private String DetermineBoudFieldType(BoundFieldType bType, Nullable<int> d)
    {
        string _DateFormatString = string.Empty;

        switch (bType)
        {
            case BoundFieldType.Integer:
                _DateFormatString = "{0:C0}";
                break;

            case BoundFieldType.Decimal:
                _DateFormatString = "{0:C " + d + "}";
                break;

            case BoundFieldType.Varchar:
                _DateFormatString = string.Empty;
                break;

            case BoundFieldType.DateTime:
            default:
                _DateFormatString = "{0:d}";
                break;
        }

        return _DateFormatString;
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

    ~GridViewColumn()
    {
        Dispose(false);
    }

    #endregion

}