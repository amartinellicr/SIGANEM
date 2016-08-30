using System;
using System.Net;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Reflection;
using AjaxControlToolkit;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.Services.Protocols;
using System.Text.RegularExpressions;

using BCR.SIGANEM.EN;


namespace BCR.SIGANEM.UT
{
    public class GeneradorControles
    {

        #region METODOS PUBLICOS

        #region VALIDADORES

        public MaskedEditType DeterminaTipoMascara(int tipo)
        {
            MaskedEditType maskEditType = new MaskedEditType();
            
            switch (tipo)
            {
                // NUMERICA
                case 1:
                    maskEditType = MaskedEditType.Number;
                    break;

                // FECHA
                case 2:
                    maskEditType = MaskedEditType.Date;
                    break;

            }

            return maskEditType;
        }

        public String DeterminaFormatoMascara(int cantidad, string mascaraEspecial)
        {
            StringBuilder maskFormat = new StringBuilder();

            //if (cantidad != 14) //Sin decimales
            //{
            //    for (int i = 1; i <= cantidad; i++)
            //    {
            //        maskFormat.Append("9");
            //    }
            //}
            //else{ //Decimales
            //    maskFormat.Append("99,999,999.99");
            //}

            if (string.IsNullOrEmpty(mascaraEspecial))
            {
                for (int i = 1; i <= cantidad; i++)
                {
                    maskFormat.Append("9");
                }
            }
            else
            {
                maskFormat.Append(mascaraEspecial);
            }

            return maskFormat.ToString();
        }

        public static DateTime? ValidaDateTime(string valor)
        {
            if (String.IsNullOrEmpty(valor))
                return null;
            else
                return DateTime.Parse(valor);
        }

        public static Decimal ValidaNumeroNull(string valor)
        {
            Decimal returnDecimal;

            try
            {
                Convert.ToString(valor);

                if (String.IsNullOrEmpty(valor.Trim()))
                    return returnDecimal = Decimal.Parse("0.000");
                else if (valor.Equals("__,___,___,___.___"))
                    return returnDecimal = Decimal.Parse("0.000");
                else
                    return returnDecimal = Decimal.Parse(valor);
            }
            catch
            {
                throw;
            }
        }

        public static Decimal? AceptaNumeroNull(string valor)
        {
            switch (valor.Trim())
            {
                case "___________.___": valor = string.Empty;
                    break;
                case "____________.__": valor = string.Empty;
                    break;
                case "_____________._": valor = string.Empty;
                    break;
                case "______________": valor = string.Empty;
                    break;
            }

            if (String.IsNullOrEmpty(valor))
                return null;
            else
                return decimal.Parse(valor);

        }

        public static Boolean CadenaEsNumero(string valor)
        {
            Boolean _isNumber = false;

            ArrayList arrayList = new ArrayList();
            for (int num = 0; num < 10; num++)
            {
                arrayList.Add(num.ToString());
            }

            for (int i = 0; i < arrayList.Count; i++)
            {
                if (valor.Contains(arrayList[i].ToString()))
                    _isNumber = true;
            }

            return _isNumber;
        }

        public static string ReemplazaCadenaNullVacia(string valor)
        {
            if (String.IsNullOrEmpty(valor))
                return " ";
            else
                return valor;
        }

        public String BuscaCadenaConSubstring(string control, char caracter)
        {
            string str = string.Empty;
            int index = control.IndexOf(caracter);
            if (index > 0)
            {
                str = control.Substring(0, index).Trim();
            }

            return str;
        }

        public String BuscaCadenaConSubstring(string control, string caracter)
        {
            string str = string.Empty;
            int index = control.IndexOf(caracter);
            if (index > 0)
            {
                str = control.Substring(0, index).Trim();
            }

            return str;
        }

        #endregion

        #region CONTROLES

        public Object Tipo_Contenido(EnumTipoControl ctype, string id, string text, string tooltip, bool enabled, bool visible, string Css, string imageURL)
        {
            object webControl = null;

            switch (ctype)
            {
                #region LABEL
                case EnumTipoControl.LABEL:

                    Label label = new Label();
                    label.ID = id;
                    label.Text = text;
                    label.ToolTip = tooltip;
                    label.Enabled = enabled;
                    label.Visible = visible;
                    label.CssClass = Css;

                    webControl = label;

                    break;
                #endregion

                #region TEXTBOX
                case EnumTipoControl.TEXTBOX:

                    TextBox textBox = new TextBox();
                    textBox.ID = id;
                    textBox.Text = text;
                    textBox.ToolTip = tooltip;
                    textBox.Enabled = enabled;
                    textBox.Visible = visible;
                    textBox.CssClass = Css;

                    webControl = textBox;

                    break;
                #endregion

                #region BUTTON
                case EnumTipoControl.BUTTON:

                    Button button = new Button();
                    button.ID = id;
                    button.Text = text;
                    button.ToolTip = tooltip;
                    button.Enabled = enabled;
                    button.Visible = visible;
                    button.CssClass = Css;

                    webControl = button;

                    break;
                #endregion

                #region DROP DOWN LIST
                case EnumTipoControl.DROPDOWNLIST:

                    DropDownList dropDownList = new DropDownList();

                    dropDownList.ID = id;
                    dropDownList.DataTextField = "";
                    dropDownList.DataValueField = "";
                    dropDownList.ToolTip = tooltip;
                    dropDownList.Enabled = enabled;
                    dropDownList.Visible = visible;
                    dropDownList.CssClass = Css;

                    webControl = dropDownList;

                    break;
                #endregion

                #region RADIO BUTTON
                case EnumTipoControl.RADIOBUTTON:

                    RadioButton radioButton = new RadioButton();

                    radioButton.ID = id;
                    radioButton.Text = text;
                    radioButton.ToolTip = tooltip;
                    radioButton.Enabled = enabled;
                    radioButton.Visible = visible;
                    radioButton.CssClass = Css;

                    webControl = radioButton;

                    break;
                #endregion

                #region CHECK BOX
                case EnumTipoControl.CHECKBOX:

                    CheckBox checkBox = new CheckBox();

                    checkBox.ID = id;
                    checkBox.Text = text;
                    checkBox.ToolTip = tooltip;
                    checkBox.Enabled = enabled;
                    checkBox.Visible = visible;
                    checkBox.CssClass = Css;

                    webControl = checkBox;

                    break;
                #endregion

                #region LIST BOX
                case EnumTipoControl.LISTBOX:

                    ListBox listBox = new ListBox();

                    listBox.ID = id;
                    listBox.Text = text;
                    listBox.ToolTip = tooltip;
                    listBox.Enabled = enabled;
                    listBox.Visible = visible;
                    listBox.CssClass = Css;

                    webControl = listBox;

                    break;
                #endregion

                #region CALENDAR
                case EnumTipoControl.CALENDAR:

                    Calendar calendar = new Calendar();

                    calendar.ID = id;
                    calendar.ToolTip = tooltip;
                    calendar.Enabled = enabled;
                    calendar.Visible = visible;
                    calendar.CssClass = Css;

                    webControl = calendar;

                    break;
                #endregion

                #region CALENDAR EXTENDER
                case EnumTipoControl.CALENDAREXTENDER:

                    TextBox textBoxCalendar = new TextBox();
                    textBoxCalendar.ID = id;
                    textBoxCalendar.Text = text;
                    textBoxCalendar.ToolTip = tooltip;
                    textBoxCalendar.Enabled = enabled;
                    textBoxCalendar.Visible = visible;
                    textBoxCalendar.CssClass = Css;


                    webControl = textBoxCalendar;

                    break;
                #endregion

                #region COLOR PICKER
                case EnumTipoControl.COLORPICKER:

                    ColorPickerExtender colorPickerExtender = new ColorPickerExtender();

                    break;
                #endregion

                #region HIDDEN FIELD
                case EnumTipoControl.HIDDENFIELD:

                    HiddenField hiddenField = new HiddenField();

                    hiddenField.ID = id;
                    hiddenField.Value = text;
                    hiddenField.Visible = visible;

                    webControl = hiddenField;

                    break;
                #endregion

                #region IMAGE BUTTON
                case EnumTipoControl.IMAGEBUTTON:

                    ImageButton imageButton = new ImageButton();

                    imageButton.ID = id;
                    imageButton.ToolTip = tooltip;
                    imageButton.Enabled = enabled;
                    imageButton.Visible = visible;
                    imageButton.CssClass = Css;

                    // Own Control Properties
                    imageButton.ImageUrl = imageURL;

                    webControl = imageButton;

                    break;
                #endregion

                #region IMAGE
                case EnumTipoControl.IMAGE:

                    Image image = new Image();

                    image.ID = id;
                    image.ToolTip = tooltip;
                    image.Enabled = enabled;
                    image.Visible = visible;
                    image.CssClass = Css;

                    // Own Control Properties
                    image.ImageUrl = imageURL;

                    webControl = image;

                    break;

                #endregion

                #region PANEL
                case EnumTipoControl.PANEL:

                    Panel panel = new Panel();

                    panel.ID = id;
                    panel.ToolTip = tooltip;
                    panel.Enabled = enabled;
                    panel.Visible = visible;
                    panel.CssClass = Css;

                    webControl = panel;

                    break;

                #endregion

                #region GRID
                case EnumTipoControl.GRID:

                    GridView grid = new GridView();

                    grid.ID = id;
                    grid.ToolTip = tooltip;
                    grid.Visible = visible;

                    webControl = grid;

                    break;

                #endregion
            }

            return webControl;
        }

        public void Limpiar_Controles(Table tableData)
        {
            TextBox txt;
            DropDownList ddl;

            for (int r = 0; r < tableData.Rows.Count; r++)
            {
                for (int c = 0; c < tableData.Rows[r].Cells.Count; c++)
                {
                    for (int cont = 0; cont < tableData.Rows[r].Cells[c].Controls.Count; cont++)
                    {
                        #region LIMPIAR TEXTBOX

                        if (tableData.Rows[r].Cells[c].Controls[cont].GetType().ToString().Equals("System.Web.UI.WebControls.TextBox"))
                        {
                            txt = (TextBox)tableData.Rows[r].Cells[c].Controls[cont];
                            if (txt.Enabled)
                            {
                                txt.Text = string.Empty;
                            }
                        }

                        #endregion
                        #region LIMPIAR DROPDOWNLIST

                        if (tableData.Rows[r].Cells[c].Controls[cont].GetType().ToString().Equals("System.Web.UI.WebControls.DropDownList"))
                        {
                            ddl = (DropDownList)tableData.Rows[r].Cells[c].Controls[cont];
                            if (ddl.Enabled)
                            {
                                ddl.SelectedIndex = -1;
                            }
                        }

                        #endregion
                    }
                }
            }
        }

        public void Bloquear_Controles(Table tableData, bool estado)
        {
            TextBox txt;
            DropDownList ddl;

            for (int r = 0; r < tableData.Rows.Count; r++)
            {
                for (int c = 0; c < tableData.Rows[r].Cells.Count; c++)
                {
                    for (int cont = 0; cont < tableData.Rows[r].Cells[c].Controls.Count; cont++)
                    {
                        #region BLOQUEAR TEXTBOX

                        if (tableData.Rows[r].Cells[c].Controls[cont].GetType().ToString().Equals("System.Web.UI.WebControls.TextBox"))
                        {
                            txt = (TextBox)tableData.Rows[r].Cells[c].Controls[cont];
                            txt.Enabled = estado;
                        }

                        #endregion
                        #region BLOQUEAR DROPDOWNLIST

                        if (tableData.Rows[r].Cells[c].Controls[cont].GetType().ToString().Equals("System.Web.UI.WebControls.DropDownList"))
                        {
                            ddl = (DropDownList)tableData.Rows[r].Cells[c].Controls[cont];
                            ddl.Enabled = estado;
                        }

                        #endregion
                    }
                }
            }
        }

        public void Bloquear_Controles(HtmlTable tableData, bool estado)
        {
            TextBox txt;
            DropDownList ddl;

            for (int r = 0; r < tableData.Rows.Count; r++)
            {
                for (int c = 0; c < tableData.Rows[r].Cells.Count; c++)
                {
                    for (int cont = 0; cont < tableData.Rows[r].Cells[c].Controls.Count; cont++)
                    {
                        #region BLOQUEAR TEXTBOX

                        if (tableData.Rows[r].Cells[c].Controls[cont].GetType().ToString().Equals("System.Web.UI.WebControls.TextBox"))
                        {
                            txt = (TextBox)tableData.Rows[r].Cells[c].Controls[cont];
                            txt.Enabled = estado;
                        }

                        #endregion
                        #region BLOQUEAR DROPDOWNLIST

                        if (tableData.Rows[r].Cells[c].Controls[cont].GetType().ToString().Equals("System.Web.UI.WebControls.DropDownList"))
                        {
                            ddl = (DropDownList)tableData.Rows[r].Cells[c].Controls[cont];
                            ddl.Enabled = estado;
                        }

                        #endregion
                    }
                }
            }
        }

        #region METODOS PARA EL DROPDOWNLIST

        //SELECCIONA EL VALOR POR DEFECTO DESDE LA BD EN EL DROPDOWNLIST
        public void SeleccionarOpcionDropDownList(DropDownList ddl, string valor)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value.ToString().ToUpper().Equals(valor.ToUpper()))
                    ddl.SelectedIndex = i;                    
            }
        }

        //SELECCIONA EL VALOR POR DEFECTO DESDE LA BD EN EL DROPDOWNLIST
        public void SeleccionarOpcionDropDownListTexto(DropDownList ddl, string valor)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Text.ToString().ToUpper().Equals(valor.ToUpper()))
                    ddl.SelectedIndex = i;
            }
        }

        //SELECCIONA EL VALOR POR DEFECTO DESDE LA BD EN EL DROPDOWNLIST
        public void SeleccionarOpcionDropDownListCodigo(DropDownList ddl, string codigo)
        {
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (BuscaCadenaConSubstring(ddl.Items[i].Text.ToString().ToUpper(), " - ").Equals(codigo))
                    ddl.SelectedIndex = i;
            }
        }

        //SELECCIONA EL VALOR POR DEFECTO DESDE LA BD EN EL DROPDOWNLIST
        public string ObtenerOpcionDropDownList(DropDownList ddl)
        {
            return ddl.SelectedValue;
        }

        //LIMPIA EL DROPDOWNLIST
        public void LimpiarDropDownList(DropDownList ddl)
        {
            ddl.ClearSelection();
            ddl.Items.Clear();
            ddl.SelectedValue = null;
            ddl.SelectedIndex = -1;
            ddl.DataSource = null;
            ddl.DataBind();
        }

        public void EliminarValorDropDownList(DropDownList _dropDownList, String _textoEliminar)
        {
            ListItem removeItem = null;
            removeItem = _dropDownList.Items.FindByText(_textoEliminar);
            _dropDownList.Items.Remove(removeItem);
        }

        #endregion

        #endregion

        #region  TIPOS DE DATOS

        public object ConvertirTipoDato(string tipoDato, string valor)
        {
            object result = null;
            switch (tipoDato)
            {
                case "INT32":
                    if (valor.Length != 0)
                    {
                        result = (int)int.Parse(valor);
                    }
                    else
                    {
                        result = null;
                    }
                    break;
                case "DOUBLE":
                    if ((valor != null) && (valor.Length != 0))
                    {
                        result = Double.Parse(valor);
                    }
                    else
                    {
                        result = null;
                    }
                    break;
                case "STRING":
                    result = (string)valor;
                    break;
                case "DATETIME":
                    if ((valor != null) && (valor.Length != 0))
                    {
                        result = DateTime.Parse(valor);
                    }
                    else
                    {
                        result = ValidaDateTime(valor);
                    }
                    break;
                case "BOOLEAN":
                    result = bool.Parse(valor);
                    break;
                case "NULLABLE`1":
                    if ((valor != null) && (valor.Length != 0))
                    {
                        result = double.Parse(valor);
                    }
                    else
                    {
                        result = null;
                    }
                    break;
                case "DECIMAL":
                    if ((valor != null) && (valor.Length != 0))
                    {
                        result = decimal.Parse(valor);
                    }
                    else
                    {
                        result = null;
                    }
                    break;
            }

            return result;

        }

        /*ELIMINA LOS CARECTERES '_' DE LA MASCARA*/
        public string EliminarErrorMascara(string valor)
        {
            string retorno = string.Empty;
            int indice = -1;
            var caracter = new Regex(@"^\d$");

            for (int i = 0; i < valor.Length; i++)
            {
                if (caracter.IsMatch(valor[i].ToString()))
                {
                    indice = i;
                    i = valor.Length;
                }
            }

            if (indice > -1)
                retorno = valor.Substring(indice, valor.Length - indice);

            return retorno;
        }

        public static string Right(string param, int length)
        {
            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }

        public static string Left(string param, int length)
        {
            string result = param.Substring(0, length);
            return result;
        }

        #endregion

        #region OPERACION

        /*REALIZA LA SUMA DE 2 VALORES Y LOS RETORNA COMO UN STRING EN FORMATO 2 DECIMALES*/
        public String SumarRetornoString(string valor1, string valor2)
        {
            decimal monto1 = 0;
            decimal monto2 = 0;

            if (valor1.Length == 0)
                monto1 = 0;
            else
                monto1 = decimal.Parse(valor1);

            if (valor2.Length == 0)
                monto2 = 0;
            else
                monto2 = decimal.Parse(valor2);

             return String.Format("{0:0.00}", (monto1 + monto2));
        }

        //REALIZA LA COMPARACION DE 2 VALORES
        public bool ObtenerComparacion(string valor1, string valor2, EnumTipoComparacion comparacion, TypeCode tipo)
        {
            bool retorno = false;

            switch (comparacion)
            { 
                case EnumTipoComparacion.IGUAL:
                    retorno = ComparacionIgual(valor1, valor2, tipo);
                    break;
                case EnumTipoComparacion.DIFERENTE:
                    retorno = ComparacionDiferente(valor1, valor2, tipo);
                    break;
                case EnumTipoComparacion.MAYOR:
                    retorno = ComparacionMayor(valor1, valor2, tipo);
                    break;
                case EnumTipoComparacion.MENOR:
                    retorno = ComparacionMenor(valor1, valor2, tipo);
                    break;
                case EnumTipoComparacion.MAYORIGUAL:
                    retorno = ComparacionMayorIgual(valor1, valor2, tipo);
                    break;
                case EnumTipoComparacion.MENORIGUAL:
                    retorno = ComparacionMenorIgual(valor1, valor2, tipo);
                    break;
            }
            
            return retorno;
        }
        
        //OPERACIONES DE COMPARACION
        private bool ComparacionIgual(string valor1, string valor2, TypeCode tipo)
        {
            bool retorno = false;

            if (valor1.Length > 0 && valor2.Length > 0)
            {
                switch (tipo)
                {
                    case TypeCode.String:
                        if (valor1.Equals(valor2))
                            retorno = true;
                        break;
                    case TypeCode.Double:
                        if (double.Parse(valor1).Equals(double.Parse(valor2)))
                            retorno = true;
                        break;
                    case TypeCode.Int32:
                        if (Int32.Parse(valor1).Equals(Int32.Parse(valor2)))
                            retorno = true;
                        break;
                    case TypeCode.DateTime:
                        if (DateTime.Parse(valor1).Equals(DateTime.Parse(valor2)))
                            retorno = true;
                        break;
                    case TypeCode.Decimal:
                        if (Decimal.Parse(valor1).Equals(Decimal.Parse(valor2)))
                            retorno = true;
                        break;
                }
            }
            return retorno;
        }

        private bool ComparacionDiferente(string valor1, string valor2, TypeCode tipo)
        {
            bool retorno = false;

            if (valor1.Length > 0 && valor2.Length > 0)
            {
                switch (tipo)
                {
                    case TypeCode.String:
                        if (!valor1.Equals(valor2))
                            retorno = true;
                        break;
                    case TypeCode.Double:
                        if (!double.Parse(valor1).Equals(double.Parse(valor2)))
                            retorno = true;
                        break;
                    case TypeCode.Int32:
                        if (!Int32.Parse(valor1).Equals(Int32.Parse(valor2)))
                            retorno = true;
                        break;
                    case TypeCode.DateTime:
                        if (!DateTime.Parse(valor1).Equals(DateTime.Parse(valor2)))
                            retorno = true;
                        break;
                    case TypeCode.Decimal:
                        if (!Decimal.Parse(valor1).Equals(Decimal.Parse(valor2)))
                            retorno = true;
                        break;
                }
            }
            return retorno;
        }

        private bool ComparacionMayor(string valor1, string valor2, TypeCode tipo)
        {
            bool retorno = false;

            if (valor1.Length > 0 && valor2.Length > 0)
            {
                switch (tipo)
                {
                    case TypeCode.String:
                        if (valor1.CompareTo(valor2) > 0)
                            retorno = true;
                        break;
                    case TypeCode.Double:
                        if (double.Parse(valor1).CompareTo(double.Parse(valor2)) > 0)
                            retorno = true;
                        break;
                    case TypeCode.Int32:
                        if (Int32.Parse(valor1).CompareTo(Int32.Parse(valor2)) > 0)
                            retorno = true;
                        break;
                    case TypeCode.DateTime:
                        if (DateTime.Parse(valor1).CompareTo(DateTime.Parse(valor2)) > 0)
                            retorno = true;
                        break;
                    case TypeCode.Decimal:
                        if (Decimal.Parse(valor1).CompareTo(Decimal.Parse(valor2)) > 0)
                            retorno = true;
                        break;
                }

            }
            return retorno;
        }

        private bool ComparacionMenor(string valor1, string valor2, TypeCode tipo)
        {
            bool retorno = false;

            if (valor1.Length > 0 && valor2.Length > 0)
            {
                switch (tipo)
                {
                    case TypeCode.String:
                        if (valor1.CompareTo(valor2) < 0)
                            retorno = true;
                        break;
                    case TypeCode.Double:
                        if (double.Parse(valor1).CompareTo(double.Parse(valor2)) < 0)
                            retorno = true;
                        break;
                    case TypeCode.Int32:
                        if (Int32.Parse(valor1).CompareTo(Int32.Parse(valor2)) < 0)
                            retorno = true;
                        break;
                    case TypeCode.DateTime:
                        if (DateTime.Parse(valor1).CompareTo(DateTime.Parse(valor2)) < 0)
                            retorno = true;
                        break;
                    case TypeCode.Decimal:
                        if (Decimal.Parse(valor1).CompareTo(Decimal.Parse(valor2)) < 0)
                            retorno = true;
                        break;

                }
            }
            return retorno;
        }

        private bool ComparacionMayorIgual(string valor1, string valor2, TypeCode tipo)
        {
            bool retorno = false;

            if (valor1.Length > 0 && valor2.Length > 0)
            {
                switch (tipo)
                {
                    case TypeCode.String:
                        if (valor1.CompareTo(valor2) > 0 || valor1.CompareTo(valor2) == 0)
                            retorno = true;
                        break;
                    case TypeCode.Double:
                        if (double.Parse(valor1).CompareTo(double.Parse(valor2)) > 0 || double.Parse(valor1).CompareTo(double.Parse(valor2)) == 0)
                            retorno = true;
                        break;
                    case TypeCode.Int32:
                        if (Int32.Parse(valor1).CompareTo(Int32.Parse(valor2)) > 0 || Int32.Parse(valor1).CompareTo(Int32.Parse(valor2)) == 0)
                            retorno = true;
                        break;
                    case TypeCode.DateTime:
                        if (DateTime.Parse(valor1).CompareTo(DateTime.Parse(valor2)) > 0 || DateTime.Parse(valor1).CompareTo(DateTime.Parse(valor2)) == 0)
                            retorno = true;
                        break;
                    case TypeCode.Decimal:
                        if (Decimal.Parse(valor1).CompareTo(Decimal.Parse(valor2)) > 0 || Decimal.Parse(valor1).CompareTo(Decimal.Parse(valor2)) == 0)
                            retorno = true;
                        break;
                }
            }
            return retorno;
        }

        private bool ComparacionMenorIgual(string valor1, string valor2, TypeCode tipo)
        {
            bool retorno = false;

            if (valor1.Length > 0 && valor2.Length > 0)
            {
                switch (tipo)
                {
                    case TypeCode.String:
                        if (valor1.CompareTo(valor2) < 0 || valor1.CompareTo(valor2) == 0)
                            retorno = true;
                        break;
                    case TypeCode.Double:
                        if (double.Parse(valor1).CompareTo(double.Parse(valor2)) < 0 || double.Parse(valor1).CompareTo(double.Parse(valor2)) == 0)
                            retorno = true;
                        break;
                    case TypeCode.Int32:
                        if (Int32.Parse(valor1).CompareTo(Int32.Parse(valor2)) < 0 || Int32.Parse(valor1).CompareTo(Int32.Parse(valor2)) == 0)
                            retorno = true;
                        break;
                    case TypeCode.DateTime:
                        if (DateTime.Parse(valor1).CompareTo(DateTime.Parse(valor2)) < 0 || DateTime.Parse(valor1).CompareTo(DateTime.Parse(valor2)) == 0)
                            retorno = true;
                        break;
                    case TypeCode.Decimal:
                        if (Decimal.Parse(valor1).CompareTo(Decimal.Parse(valor2)) < 0 || Decimal.Parse(valor1).CompareTo(Decimal.Parse(valor2)) == 0)
                            retorno = true;
                        break;
                }
            }

            return retorno;
        }

        #endregion

        #region AUTOCOMPLETADO

        public static String Autocompletar(TextBox txt, string completarCon)
        {
            string _valorFinal = string.Empty;
            int _diferencia = 0;

            if (txt != null)
            {
                if (!txt.Text.Replace("_", "").Length.Equals(0))
                {
                    _diferencia = txt.Text.Length - txt.Text.Replace("_", "").Length;

                    for (int i = 0; i < _diferencia; i++)
                    {
                        _valorFinal += completarCon;
                    }

                    txt.Text = _valorFinal + txt.Text;
                }
            }

            return _valorFinal;
        }

        public static String ValorMinimo(TextBox txt, string valorMinimo)
        {
            if (txt.Text.Replace("_", "").Replace(".", "").Replace(",", "").Length.Equals(0))
                return valorMinimo;
            else
                return txt.Text;
        }

        #endregion

        #region TIPOS DE GARANTIAS

        public string ValidarFechaPrescripcionGarantia(string _tipoGarantia, int TipoBien, int ClaseTipoBien)
        {
            string _filtro = string.Empty;

            switch (_tipoGarantia)
            {
                case "FIDUCIARIA":
                    _filtro = "Meses_Prescripcion_Fianza";
                    break;
                case "VALORES":
                    _filtro = "Meses_Prescripcion_Valor";
                    break;
                case "REAL":
                    #region OBTENER FILTRO MEDIANTE TIPO BIEN

                    switch (TipoBien)
                    {
                        case 1:
                            _filtro = "Meses_Prescripcion_Terreno";
                            break;
                        case 2:
                            _filtro = "Meses_Prescripcion_Edificacion";
                            break;
                        case 3:
                            switch (ClaseTipoBien)
                            {
                                case 2:
                                case 7:
                                    _filtro = "Meses_Prescripcion_Vehiculo";
                                    break;
                                case 3:
                                case 8:
                                    _filtro = "Meses_Prescripcion_Bono_Prenda";
                                    break;
                            }
                            break;
                        case 4:
                            _filtro = "Meses_Prescripcion_Maquinaria_Equipo";
                            break;
                        case 5:
                            _filtro = "Meses_Prescripcion_Equipo_Computo";
                            break;
                        case 6:
                            _filtro = "Meses_Prescripcion_Materia_Prima";
                            break;
                        case 7:
                            _filtro = "Meses_Prescripcion_Mobiliario";
                            break;
                        case 8:
                            _filtro = "Meses_Prescripcion_Madera";
                            break;
                        case 9:
                            _filtro = "Meses_Prescripcion_Aeronave";
                            break;
                        case 10:
                            _filtro = "Meses_Prescripcion_Buque";
                            break;
                        case 11:
                            _filtro = "Meses_Prescripcion_Animal";
                            break;
                        case 12:
                            _filtro = "Meses_Prescripcion_Cultivo_Fruto";
                            break;
                        case 13:
                            _filtro = "Meses_Prescripcion_Alhaja";
                            break;
                        case 14:
                            _filtro = "Meses_Prescripcion_Otro_Tipo_Bien";
                            break;
                    }

                    #endregion
                    break;
                case "AVAL":
                    _filtro = "Meses_Prescripcion_Fianza";
                    break;
                case "FIDEICOMISO DE GARANTÍA":
                    _filtro = "Meses_Prescripcion_Fideicomiso";
                    break;
            }

            return _filtro;
        }

        #endregion

        #region SERVICIOS WEB

        public bool ExisteConexionWebService(string _urlServicio)
        {
            bool _retorno = true;

            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(_urlServicio);
                var response = (HttpWebResponse)myRequest.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                    _retorno = false;
            }
            catch
            {
                _retorno = false;
            }            

            return _retorno;
        }

        #endregion

        #region MESES

        public static String HomologarMes(int numeroMes)
        {
            string _retorno = string.Empty;
            string _nombreMes = string.Empty;
            string _numeroMes = string.Empty;

            switch(numeroMes)
            {
                case 1:
                    _nombreMes = "Enero";
                    break;
                case 2:
                    _nombreMes = "Febrero";
                    break;
                case 3:
                    _nombreMes = "Marzo";
                    break;
                case 4:
                    _nombreMes = "Abril";
                    break;
                case 5:
                    _nombreMes = "Mayo";
                    break;
                case 6:
                    _nombreMes = "Junio";
                    break;
                case 7:
                    _nombreMes = "Julio";
                    break;
                case 8:
                    _nombreMes = "Agosto";
                    break;
                case 9:
                    _nombreMes = "Setiembre";
                    break;
                case 10:
                    _nombreMes = "Octubre";
                    break;
                case 11:
                    _nombreMes = "Noviembre";
                    break;
                case 12:
                    _nombreMes = "Deciembre";
                    break;
            }

            _numeroMes = string.Concat("0", numeroMes.ToString());
            _numeroMes = _numeroMes.Substring(_numeroMes.Length - 2);

            _retorno = string.Concat(_numeroMes, "-", _nombreMes);

            return _retorno;
        }

        public static String ObtenerNombreMes(int numeroMes)
        {
            string _nombreMes = string.Empty;

            switch (numeroMes)
            {
                case 1:
                    _nombreMes = "Enero";
                    break;
                case 2:
                    _nombreMes = "Febrero";
                    break;
                case 3:
                    _nombreMes = "Marzo";
                    break;
                case 4:
                    _nombreMes = "Abril";
                    break;
                case 5:
                    _nombreMes = "Mayo";
                    break;
                case 6:
                    _nombreMes = "Junio";
                    break;
                case 7:
                    _nombreMes = "Julio";
                    break;
                case 8:
                    _nombreMes = "Agosto";
                    break;
                case 9:
                    _nombreMes = "Setiembre";
                    break;
                case 10:
                    _nombreMes = "Octubre";
                    break;
                case 11:
                    _nombreMes = "Noviembre";
                    break;
                case 12:
                    _nombreMes = "Deciembre";
                    break;
            }

            return _nombreMes;
        }

        #endregion

        #region FECHAS

        public static String ConvertirFecha(DateTime fecha, EnumFormatoFecha formato)
        {
            StringBuilder retorno = new StringBuilder();
            retorno.Clear();

            if (formato.Equals(EnumFormatoFecha.AAAAMMDD))
            {
                retorno.Append(fecha.Year);
                retorno.Append("-");
                retorno.Append(Right(("0" + fecha.Month), 2));
                retorno.Append("-");
                retorno.Append(Right(("0" + fecha.Day), 2));
            }

            if (formato.Equals(EnumFormatoFecha.DDMMAAAAHHMMSSTT))
            {
                retorno.Append(Right(("0" + fecha.Day), 2));
                retorno.Append("/");
                retorno.Append(Right(("0" + fecha.Month), 2));
                retorno.Append("/");
                retorno.Append(fecha.Year);
                retorno.Append(" ");
                retorno.Append(Right(("0" + ((fecha.Hour > 12) ? fecha.Hour - 12 : fecha.Hour)), 2));
                retorno.Append(":");
                retorno.Append(Right(("0" + fecha.Minute), 2));
                retorno.Append(":");
                retorno.Append(Right(("0" + fecha.Second), 2));
                retorno.Append(" ");
                retorno.Append((fecha.Hour >= 12) ? "p.m." : "a.m.");
            }

            return retorno.ToString();
        }

        #endregion

        #endregion

    }
}
