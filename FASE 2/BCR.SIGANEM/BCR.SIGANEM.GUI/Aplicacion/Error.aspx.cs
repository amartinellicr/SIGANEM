using System;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Collections.Specialized;

using BCR.SIGANEM.UT;
using System.Configuration;


public partial class Error : System.Web.UI.Page
{

    #region PROPIEDADES

    #region VARIABLES


    #endregion

    #region REFERENCIAS

    private RegistrarEventLog _registroEventos = new RegistrarEventLog();

    #endregion

    #endregion
    
    #region METODOS PERSONALIZADOS

    protected void Page_Init(object sender, EventArgs e)
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

    protected void Page_Load(object sender, EventArgs e)
    {
        Exception ex = (Exception)Application["Exception"];

        //SI HAY UNA EXCEPCIÓN IDENTIFICADA, MOSTRAR LA INFORMACIÓN TÉCNICA
        if (ex != null)
        {
            string tituloError = "<h2>Excepción nivel #{0}</h2>";
            string tituloExcepcion = "<strong>Excepción:</strong>";
            string tituloMensaje = "<strong>Mensaje:</strong>";
            string tituloFuente = "<strong>Fuente:</strong>";
            string tituloTraza = "<strong>Traza:</strong>";
            string nuevaLinea = "<br/>";

            StringBuilder sb = new StringBuilder();
            int nivel = 1;

            while (ex != null)
            {
                //TITULO
                sb.Append(String.Format(tituloError, nivel));
                sb.Append(nuevaLinea);

                //MENSAJE EXCEPCION
                sb.Append(tituloExcepcion);
                sb.Append(nuevaLinea);
                if (ex.GetType() != null && ex.GetType().FullName != null)
                {
                    sb.Append(ex.GetType().FullName);
                }
                sb.Append(nuevaLinea);

                //MENSAJE ERROR
                sb.Append(tituloMensaje);
                sb.Append(nuevaLinea);
                if (ex.Message != null)
                {
                    sb.Append(ex.Message);
                }
                sb.Append(nuevaLinea);

                //ORIGEN ERROR
                sb.Append(tituloFuente);
                sb.Append(nuevaLinea);
                if (ex.Source != null)
                {
                    sb.Append(ex.Source);
                }
                sb.Append(nuevaLinea);

                //PILA DE SEGUIMIENTO
                sb.Append(tituloTraza);
                sb.Append(nuevaLinea);
                if (ex.StackTrace != null)
                {
                    sb.Append(ex.StackTrace);
                }
                sb.Append(nuevaLinea);

                //SEPARAR DE SIGUIENTE ERROR
                sb.Append(nuevaLinea);
                sb.Append(nuevaLinea);
                sb.Append(nuevaLinea);

                //REGISTRA CADENA DE ERRORES EN LOG
                _registroEventos.RegistrarMensajeLog(ex, Resources.Resource._eventoSource);

                //ASOCIAR SIGUIENTE ERROR
                ex = ex.InnerException;
                nivel++;
            }

            //REQUERIMIENTO: 61-OD_REQ TECNICO AJUSTAR MENSAJES ERROR
            ////MOSTRAR CADENA DE ERRORES
            if (MostrarErrorTecnico())
                ltlTextoDetalle.Text = sb.ToString();
            else
                ltlTextoDetalle.Text = MensajeErrorDefault();

            //LIMPIAR ERROR
            Server.ClearError();
            Application["Exception"] = null;
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbLog = new StringBuilder();

            //SI NO SE PUEDE OBTENER LA EXCEPCIÓN, MOSTAR MENSAJE GENÉRICO
            //CONSTRUIR MENSAJE GENÉRICO 
            sb.Append("<h2>Información del Error</h2>");
            sb.Append("<br/>");
            sb.Append("No se puede mostrar en este momento la información técnica de la excepción ocurrida. ");
            sb.Append("<br/>");
            sb.Append("Por favor póngase en contacto con el administrador para obtener más información.");
            sb.Append("<br/><br/>");

            //SI NO SE PUEDE OBTENER LA EXCEPCIÓN, MOSTAR MENSAJE GENÉRICO
            //CONSTRUIR MENSAJE GENÉRICO 
            sbLog.Append("Información del Error");
            sbLog.Append("\n\n");
            sbLog.Append("No se puede mostrar en este momento la información técnica de la excepción ocurrida. ");
            sbLog.Append("\n\n");
            sbLog.Append("Por favor póngase en contacto con el administrador para obtener más información.");
            sbLog.Append("\n\n\n");

            //REQUERIMIENTO: 61-OD_REQ TECNICO AJUSTAR MENSAJES ERROR
            ////MOSTRAR CADENA DE ERRORES
            if (MostrarErrorTecnico())
                ltlTextoDetalle.Text = sb.ToString();
            else
                ltlTextoDetalle.Text = MensajeErrorDefault();

            //REGISTRA CADENA DE ERRORES EN LOG
            _registroEventos.RegistrarMensajeLog(sbLog.ToString(), "INFORMACION", Resources.Resource._eventoSource);
        }
    }

    private string MensajeErrorDefault()
    {
        StringBuilder sb = new StringBuilder();

        //PERSONALIZAR EL MENSAJE
        sb.Append("<br/><br/><br/><br/><br/><br/>");
        sb.Append("<br/><br/><br/><br/><br/>");
        sb.Append("<font color=\"#FF0000\"><h3><strong>SIGANEM</strong></h3></font>");
        sb.Append("Está sufriendo inconvenientes técnicos, favor generar el tiquete de inconsistencia de forma inmediata para resolver el problema a la mayor brevedad posible");

        return sb.ToString();
    }

    private bool MostrarErrorTecnico()
    {
        bool retorno = false;
        LectorConfiguracion conf = new LectorConfiguracion();
        string mostrarErrorTec = ConfigurationManager.AppSettings["MostrarErrorTecnico"].ToString();

        if(mostrarErrorTec.Length > 0)
        {
            if (mostrarErrorTec.ToUpper().Equals("TRUE"))
                retorno = true;
        }

        return retorno;
    }

    #endregion
    
    #region MIEMBRO IDISPOSABLE

    #region VARIABLES

    private bool disposed = false;

    #endregion

    #region FINALIZADOR

    protected override void OnUnload(EventArgs e)
    {
        base.OnUnload(e);

        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {

                #region WEB SERVICES


                #endregion
            }
            _registroEventos = null;

            disposed = true;
        }
    }

    #endregion

}