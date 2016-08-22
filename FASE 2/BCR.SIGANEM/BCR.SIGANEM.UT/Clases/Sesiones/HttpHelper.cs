using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using AjaxControlToolkit;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;


/// <summary>
/// Summary description for HttpHelper
/// </summary>
/// <Author>Samer Abu Rabie</Author>
/// <Modify>Francisco Guevara</Modify>
namespace BCR.SIGANEM.UT
{
    public class HttpHelper
    {

        #region METODOS PUBLICOS

        /// <summary>
        /// This method prepares an Html form which holds all data in hidden field in the addetion to form submitting script.
        /// </summary>
        /// <param name="url">The destination Url to which the post and redirection will occur, the Url can be in the same App or ouside the App.</param>
        /// <param name="data">A collection of data that will be posted to the destination Url.</param>
        /// <returns>Returns a string representation of the Posting form.</returns>
        /// <Author>Samer Abu Rabie</Author>
        private String PreparePOSTForm(string url, Dictionary<string, string> collection)
        {
            //Set a name for the form
            string formID = "PostForm";

            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"POST\">");

            foreach (KeyValuePair<string, string> data in collection)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + data.Key + "\" value=\"" + data.Value + "\">");
            }
            strForm.Append("</form>");

            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." + formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");

            //Return the form and the script concatenated. (The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }

        /// <summary>
        /// POST data and Redirect to the specified url using the specified page.
        /// </summary>
        /// <param name="page">The page which will be the referrer page.</param>
        /// <param name="destinationUrl">The destination Url to which the post and redirection is occuring.</param>
        /// <param name="data">The data should be posted.</param>
        /// <Author>Samer Abu Rabie</Author>
        public void RedirectAndPOST(Page page, string destinationUrl, Dictionary<string, string> collection)
        {
            //Prepare the Posting form
            string strForm = PreparePOSTForm(destinationUrl, collection);

            //Add a literal control the specified page holding the Post Form, this is to submit the Posting form with the request.
            page.Controls.Add(new LiteralControl(strForm));
        }



        //CORRECION PARA LA SOLUCION DE SIGANEM MANTENIMIENTOS GENERICOS
        //REALIZADA POR FRANCISCO GUEVARA
        private String PreparePOSTFormNewWindow(string url, Dictionary<string, string> collection)
        {
            //SET A NAME FOR THE FORM
            string formID = "PostForm";
            string hiloId = "Ventana" + (DateTime.Now.TimeOfDay.ToString().Replace(":", "")).Replace(".", "");

            //BUILD THE JAVASCRIPT WHICH WILL DO CREATE THE NEW WINDOW.
            StringBuilder strPopup = new StringBuilder();
            strPopup.Append("<script type=\"text/javascript\" language=\"javascript\">");
            strPopup.Append("function Popup(f) { ");
            strPopup.Append("window.open(\"\", \"" + hiloId + "\", \"height=600, width=850, toolbar=no\"); }");
            strPopup.Append("</script>");

            //BUILD THE FORM USING THE SPECIFIED DATA TO BE POSTED.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"post\" target=\"" + hiloId + "\">");
            foreach (KeyValuePair<string, string> data in collection)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + data.Key + "\" value=\"" + data.Value + "\">");
            }
            strForm.Append("</form>");

            //BUILD THE JAVASCRIPT WHICH WILL DO THE POSTING OPERATION.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script type=\"text/javascript\" language=\"javascript\">");
            strScript.Append("var v" + formID + " = document." + formID + "; ");
            strScript.Append("v" + formID + ".submit(Popup(this.form));");
            strScript.Append("</script>");
            
            //RETURN THE FORM AND THE SCRIPT CONCATENATED. (THE ORDER IS IMPORTANT, FORM THEN JAVASCRIPT)
            StringBuilder strJavaScript = new StringBuilder();
            strJavaScript.Append(strPopup.ToString());
            strJavaScript.Append(strForm.ToString());
            strJavaScript.Append(strScript.ToString());
            
            return  strJavaScript.ToString();
        }

        //CORRECION PARA LA SOLUCION DE SIGANEM MANTENIMIENTOS GENERICOS
        //REALIZADA POR FRANCISCO GUEVARA
        private String PreparePOSTFormNewWindow(string url, Dictionary<string, string> collection, string target)
        {
            //SET A NAME FOR THE FORM
            string formID = "PostForm";
            string hiloId = "Ventana" + (DateTime.Now.TimeOfDay.ToString().Replace(":", "")).Replace(".", "");

            //BUILD THE JAVASCRIPT WHICH WILL DO CREATE THE NEW WINDOW.
            StringBuilder strPopup = new StringBuilder();
            strPopup.Append("<script type=\"text/javascript\" language=\"javascript\">");
            strPopup.Append("function Popup(f) { ");
            strPopup.Append("window.open(\"\", \"" + hiloId + "\"); }");
            strPopup.Append("</script>");

            //BUILD THE FORM USING THE SPECIFIED DATA TO BE POSTED.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"post\" target=\"" + hiloId + "\">");
            foreach (KeyValuePair<string, string> data in collection)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + data.Key + "\" value=\"" + data.Value + "\">");
            }
            strForm.Append("</form>");

            //BUILD THE JAVASCRIPT WHICH WILL DO THE POSTING OPERATION.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script type=\"text/javascript\" language=\"javascript\">");
            strScript.Append("var v" + formID + " = document." + formID + "; ");
            strScript.Append("v" + formID + ".submit(Popup(this.form));");
            strScript.Append("</script>");

            //RETURN THE FORM AND THE SCRIPT CONCATENATED. (THE ORDER IS IMPORTANT, FORM THEN JAVASCRIPT)
            StringBuilder strJavaScript = new StringBuilder();
            strJavaScript.Append(strPopup.ToString());
            strJavaScript.Append(strForm.ToString());
            strJavaScript.Append(strScript.ToString());

            return strJavaScript.ToString();
        }

        //CORRECION PARA LA SOLUCION DE SIGANEM GARANTIAS REALES
        //REALIZADA POR FRANCISCO GUEVARA
        private String PreparePOSTFormNewBigWindow(string url, Dictionary<string, string> collection)
        {
            //SET A NAME FOR THE FORM
            string formID = "PostForm";
            string hiloId = "Ventana" + (DateTime.Now.TimeOfDay.ToString().Replace(":", "")).Replace(".", "");

            //BUILD THE JAVASCRIPT WHICH WILL DO CREATE THE NEW WINDOW.
            StringBuilder strPopup = new StringBuilder();
            strPopup.Append("<script type=\"text/javascript\" language=\"javascript\">");
            strPopup.Append("function Popup(f) { ");
            strPopup.Append("window.open(\"\", \"" + hiloId + "\", \"height=700, width=950, toolbar=no\"); }");
            strPopup.Append("</script>");

            //BUILD THE FORM USING THE SPECIFIED DATA TO BE POSTED.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"post\" target=\"" + hiloId + "\">");
            foreach (KeyValuePair<string, string> data in collection)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + data.Key + "\" value=\"" + data.Value + "\">");
            }
            strForm.Append("</form>");

            //BUILD THE JAVASCRIPT WHICH WILL DO THE POSTING OPERATION.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script type=\"text/javascript\" language=\"javascript\">");
            strScript.Append("var v" + formID + " = document." + formID + "; ");
            strScript.Append("v" + formID + ".submit(Popup(this.form));");
            strScript.Append("</script>");

            //RETURN THE FORM AND THE SCRIPT CONCATENATED. (THE ORDER IS IMPORTANT, FORM THEN JAVASCRIPT)
            StringBuilder strJavaScript = new StringBuilder();
            strJavaScript.Append(strPopup.ToString());
            strJavaScript.Append(strForm.ToString());
            strJavaScript.Append(strScript.ToString());

            return strJavaScript.ToString();
        }

        //CORRECION PARA LA SOLUCION DE SIGANEM MANTENIMIENTOS GENERICOS
        //REALIZADA POR FRANCISCO GUEVARA
        private String PreparePOSTFormNewBigWindow(string url, Dictionary<string, string> collection, string id)
        {
            //SET A NAME FOR THE FORM
            string formID = "PostForm"+id;
            string hiloId = "Ventana" + (DateTime.Now.TimeOfDay.ToString().Replace(":", "")).Replace(".", "")+id;

            //BUILD THE JAVASCRIPT WHICH WILL DO CREATE THE NEW WINDOW.
            StringBuilder strPopup = new StringBuilder();
            strPopup.Append("<script type=\"text/javascript\" language=\"javascript\">");
            strPopup.Append("function Popup(f) { ");
            strPopup.Append("window.open(\"\", \"" + hiloId + "\", \"height=700, width=950, toolbar=no\"); }");
            strPopup.Append("</script>");

            //BUILD THE FORM USING THE SPECIFIED DATA TO BE POSTED.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" + formID + "\" action=\"" + url + "\" method=\"post\" target=\"" + hiloId + "\">");
            foreach (KeyValuePair<string, string> data in collection)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + data.Key + "\" value=\"" + data.Value + "\">");
            }
            strForm.Append("</form>");

            //BUILD THE JAVASCRIPT WHICH WILL DO THE POSTING OPERATION.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script type=\"text/javascript\" language=\"javascript\">");
            strScript.Append("var v" + formID + " = document." + formID + "; ");
            strScript.Append("v" + formID + ".submit(Popup(this.form));");
            strScript.Append("</script>");

            //RETURN THE FORM AND THE SCRIPT CONCATENATED. (THE ORDER IS IMPORTANT, FORM THEN JAVASCRIPT)
            StringBuilder strJavaScript = new StringBuilder();
            strJavaScript.Append(strPopup.ToString());
            strJavaScript.Append(strForm.ToString());
            strJavaScript.Append(strScript.ToString());

            return strJavaScript.ToString();
        }



        //CORRECION PARA LA SOLUCION DE SIGANEM MANTENIMIENTOS GENERICOS
        //REALIZADA POR FRANCISCO GUEVARA
        public void RedirectAndPOSTNewWindow(Page page, string destinationUrl, Dictionary<string, string> collection)
        {
            //Prepare the Posting form
            string strForm = PreparePOSTFormNewWindow(destinationUrl, collection);

            //Add a literal control the specified page holding the Post Form, this is to submit the Posting form with the request.
            page.Controls.Add(new LiteralControl(strForm));
        }

        //CORRECION PARA LA SOLUCION DE SIGANEM MANTENIMIENTOS GENERICOS
        //REALIZADA POR FRANCISCO GUEVARA
        public void RedirectAndPOSTNewWindow(Page page, string destinationUrl, Dictionary<string, string> collection, string target)
        {
            //Prepare the Posting form
            string strForm = PreparePOSTFormNewWindow(destinationUrl, collection, target);

            //Add a literal control the specified page holding the Post Form, this is to submit the Posting form with the request.
            page.Controls.Add(new LiteralControl(strForm));
        }

        //CORRECION PARA LA SOLUCION DE SIGANEM GARANTIAS REALES
        //REALIZADA POR FRANCISCO GUEVARA
        public void RedirectAndPOSTNewBigWindow(Page page, string destinationUrl, Dictionary<string, string> collection)
        {
            //Prepare the Posting form
            string strForm = PreparePOSTFormNewBigWindow(destinationUrl, collection);

            //Add a literal control the specified page holding the Post Form, this is to submit the Posting form with the request.
            page.Controls.Add(new LiteralControl(strForm));
        }

        //CORRECION PARA LA SOLUCION DE SIGANEM GARANTIAS REALES
        //REALIZADA POR FRANCISCO GUEVARA
        public void RedirectAndPOSTNewBigWindow(Page page, string destinationUrl, Dictionary<string, string> collection, string id)
        {
            //Prepare the Posting form
            string strForm = PreparePOSTFormNewBigWindow(destinationUrl, collection, id);

            //Add a literal control the specified page holding the Post Form, this is to submit the Posting form with the request.
            page.Controls.Add(new LiteralControl(strForm));
        }

        #endregion

    }
}