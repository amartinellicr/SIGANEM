using System;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;


public class MasterGridConstructor
{

    #region PROPIEDADES

    public MasterGridConstructor()
	{
		
	}

    #endregion

    #region METODOS PERSONALIZADOS

    public Boolean DetermineMasterGridPermit(int ordinal)
    {
        bool result = false;

        if (ordinal == 1)
            result = true;

        return result;
    }

    public List<KeyValuePair<string, string>> ddlFilterItems(GridView _gridView, string [] _palabrasReservadas )
    {
        String stringEvaluated = String.Empty;

        List<string> _listGridView = new List<string>();
        for (int i = 0; i < _gridView.Columns.Count; i++)
        {
            stringEvaluated = _gridView.Columns[i].HeaderText;

            foreach(String s in _palabrasReservadas)
            {
                if(!stringEvaluated.ToUpper().Contains(s.ToUpper()))
                    _listGridView.Add(stringEvaluated);
            }            
        }

        List<KeyValuePair<string, string>> _ddlListItems = new List<KeyValuePair<string, string>>();

        for (int i = 0; i < _listGridView.Count; i++ )
        {
            _ddlListItems.Add(new KeyValuePair<string, string>(i.ToString(), _gridView.Columns[i].HeaderText));
        }

        return _ddlListItems;
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

    ~MasterGridConstructor()
    {
        Dispose(false);
    }

    #endregion

}
