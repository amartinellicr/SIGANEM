using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public static class StaticParameters
{

    #region PROPIEDADES

    public static int RowCount
    {
        get 
        {
            return int.Parse(ConfigurationManager.AppSettings["RowCount"].ToString()); 
        }
    }

    #endregion

    #region METODOS PERSONALIZADOS

    public static string RemoveSpecialCharacters(string input)
    {
        //Regex r = new Regex("(?:[^a-zA-Z0-9\\,\\.ÁÉÍÓÚÑáéíóúñ\\s]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        Regex r = new Regex("(?:[^a-zA-Z0-9 \\,\\-\\,\\.ÁÉÍÓÚÑáéíóúñ\\s]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        return r.Replace(input, String.Empty);
    }

    public static string RemoveSpecialCharactersExceptionDash(string input)
    {
        Regex r = new Regex("(?:[^a-zA-Z0-9\\/,\\.ÁÉÍÓÚÑáéíóúñ\\s]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        return r.Replace(input, String.Empty);
    }

    #endregion
    
}