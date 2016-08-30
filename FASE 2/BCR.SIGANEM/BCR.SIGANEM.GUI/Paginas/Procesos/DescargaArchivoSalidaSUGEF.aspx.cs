using System;
using System.Net;
using System.Web;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Reflection;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using ICSharpCode.SharpZipLib.Zip;

using BCR.SIGANEM.UT;
using BCR.SIGANEM.EN;
using AjaxControlToolkit;

using ListasWS;
using SesionesWCF;
using SeguridadWS;
using ConfiguracionWS;
using ConsultasWS;

using System.IO;

public partial class DescargaArchivoSalidaSUGEF : System.Web.UI.Page
{

    #region REFERENCIAS

    private BitacoraFlags bitacoraFlags = new BitacoraFlags();
    private RegistrarEventLog registroEventos = new RegistrarEventLog();
    private GeneradorControles generadorControles = new GeneradorControles();
    private SeguridadWS.MensajesEntidad mensajesEntidad = new SeguridadWS.MensajesEntidad();
    private GarantiasWS.BitacorasEntidad bitacorasEntidad = new GarantiasWS.BitacorasEntidad();
    private SeguridadWS.PantallasEntidad pantallasEntidad = new SeguridadWS.PantallasEntidad();
    private SeguridadWS.BitacorasEntidad bitacorasSeguridadEntidad = new SeguridadWS.BitacorasEntidad();

    private ConsultasWS.ParametrosConsultaEntidad consultaEntidad = new ConsultasWS.ParametrosConsultaEntidad();
    private ConsultasWS.ParametrosTotalFilasEntidad consultaTotalFilas = new ConsultasWS.ParametrosTotalFilasEntidad();

    private SiganemListasWS wsLista = new SiganemListasWS();
    private SiganemSesionesWCF wsSesiones = new SiganemSesionesWCF();
    private SiganemSeguridadWS wsSeguridad = new SiganemSeguridadWS();
    private SiganemConfiguracionWS wsConfiguracion = new SiganemConfiguracionWS();
    private SiganemConsultasWS wsConsultas = new SiganemConsultasWS();

    #endregion

    #region VARIABLES

    protected Int32 Registros
    {
        get
        {
            Int32 n = (Int32)ViewState["Registros"];
            return ((n == 0) ? 0 : n);
        }
        set
        {
            ViewState["Registros"] = value;
        }
    }

    private HttpHelper httpPost = null;
    private NameValueCollection dataSesion = null;

    private string filtro = string.Empty;
    private string valorReemplazo = string.Empty;
    static string ddlValorSeleccionado = string.Empty;


    #endregion

    #region METODOS PERSONALIZADOS EDITABLES

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            //ASIGNANDO RUTAS DE SERVICIOS WEB
            this.AsignaWebServicesTypeNames();
       

            if (!IsPostBack)
            {
                VariablesGlobales();
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //DESHABILITA LOS BOTONES DEL RIBBON
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesAcciones(true);
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesDatos(true);
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesReportes(true);
            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).OcultarBotones(true);

            ((wucMenuSuperior)this.Master.FindControl("Ribbon1")).DeshabilitarBotonesMasAcciones(false);
            ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trEjecutarIPC")).Attributes.Add("style", "display:none");
            ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trEjecutarTC")).Attributes.Add("style", "display:none");
            ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trCopiarRol")).Attributes.Add("style", "display:none");
          //  ((HtmlTableRow)this.Master.FindControl("Ribbon1").FindControl("TabContainer1").FindControl("tabAcciones").FindControl("tblMasAcciones").FindControl("trDescargaArchivo")).Attributes.Add("style", "display:block");
           
            RespuestaConsultaSesion sesion = wsSesiones.ConsultarSesion(idSesionOculto.Value);

            if (sesion.Codigo == 0)
            {
                Controles();

                if (AccesoPermisoPagina())
                {
                    if (!IsPostBack)
                    {
                        this.Master.RefrescarDatosUsuario();
                      
                        this.grwDownload.PageSize = int.Parse(ConfigurationManager.AppSettings["RowCount"]);
                        BindGridView(ObtenerArchivos(4));

                    }
                }
            }

        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void grwDownload_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grwDownload.PageIndex = e.NewPageIndex;
            BindGridView(ObtenerArchivos(4));
            grwDownload.DataBind();
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    protected void grwDownload_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {

            using (Impersonador imp = new Impersonador(ConfigurationManager.AppSettings[Resources.Resource.Usuario],
                                                        ConfigurationManager.AppSettings[Resources.Resource.Dominio],
                                                        ConfigurationManager.AppSettings[Resources.Resource.Contrasena]
                                                      ))
            {

                GridViewRow dr = this.grwDownload.Rows[e.NewSelectedIndex];

                string nombreArchivo = dr.Cells[0].Text;
                string rutaArchivo = dr.Cells[3].Text;
                string tamanoArchivo = dr.Cells[1].Text;

                ComprimirZip(nombreArchivo, RutaArchivo(2), RutaArchivo(4));
            }
        }
        catch (Exception ex)
        {
            Application["Exception"] = ex;
            Response.Redirect("~/Aplicacion/Error.aspx", false);
        }
    }

    #endregion

    #region METODOS PERSONALIZADOS NO EDITABLES

    #region CONTROLES

    #region LAYOUT CONTROLES
  
    /*EXTRAE LOS CONTROLES DESDE BD*/
    private void Controles()
    {
        try
        {
            if (pantallaModuloOculto.Value != null)
            {
                // BUSCA NOMBRE DE LA PANTALLA
                pantallasEntidad.RutaPantalla = Page.AppRelativeVirtualPath.ToString();
                //ASIGNA EL ID DE LA PANTALLA
                pantallasEntidad.IdPantalla = int.Parse(pantallaModuloOculto.Value);

                //OBTIENE TODOS LOS DATOS DE LA PANTALLA SOLO CON EL ID DE LA PANTALLA
                pantallasEntidad = wsSeguridad.PantallasConsultarDetalle(pantallasEntidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                pantallaTituloOculto.Value = pantallasEntidad.TituloPantalla;
                pantallaModuloOculto.Value = pantallasEntidad.IdPantalla.ToString();
                pantallaCodOculto.Value = pantallasEntidad.CodPantalla.ToString();
                pantallaNombreOculto.Value = Request.Url.Segments[Request.Url.Segments.Length - 1].Replace(".aspx", "");

                // ASIGNA EL TITULO AL MANTENIMIENTO  
                this.lblTituloPage.Text = pantallasEntidad.TituloPantalla;

                ListasWS.PantallasEntidad pantalla = new ListasWS.PantallasEntidad();
                pantalla.CodPantalla = pantallasEntidad.CodPantalla;


               //LIMPIA TABLA DE LA PAGINA ACTUAL
              //B16S04  this.tableData.Controls.Clear();

                //ESTABLECE LOS CONTROLES DE LA PANTALLA A CARGAR
                pantalla.Pestana = string.Empty;

                //CREAR E INSERTA LOS CONTROLES EN LA PAGINA ACTUAL    
                //B16S04      LlenarTabla(this.tableData, pantallaNombreOculto.Value, ds);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void BindGridView(List<ArchivoDescargaEntidad> archivos)
    {
        this.grwDownload.DataSource = archivos;
        this.grwDownload.DataBind();
    }

    /*OBTIENE ARCHIVOS DE DESCARGA*/
    private List<ArchivoDescargaEntidad> ObtenerArchivos(int tipo)
    {
        List<ArchivoDescargaEntidad> resultado = new List<ArchivoDescargaEntidad>();

        try
        {
            resultado = this.ListarArchivos(RutaArchivo(tipo), ExtensionArchivo(tipo));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return resultado;
    }

    public List<ArchivoDescargaEntidad> ListarArchivos(String ruta, String extension)
    {
        try
        {
            using (Impersonador imp = new Impersonador(
                                                        ConfigurationManager.AppSettings[Resources.Resource.Usuario],
                                                        ConfigurationManager.AppSettings[Resources.Resource.Dominio],
                                                        ConfigurationManager.AppSettings[Resources.Resource.Contrasena]
                                                      ))
            {
                DirectoryInfo directorio = new DirectoryInfo(ruta);
                FileInfo[] archivosDirectorio = directorio.GetFiles(extension);

                List<ArchivoDescargaEntidad> listaArchivos = new List<ArchivoDescargaEntidad>();
                ArchivoDescargaEntidad objArchivo;
                foreach (FileInfo archivo in archivosDirectorio)
                {
                    objArchivo = new ArchivoDescargaEntidad();
                    objArchivo.Nombre = archivo.Name;
                    objArchivo.Url = archivo.FullName.ToString();
                    objArchivo.Tamano = archivo.Length;
                    objArchivo.Formato = archivo.Extension.ToString();
                    objArchivo.FechaIngreso = archivo.CreationTime;
                    objArchivo.FechaUltimaModificacion = archivo.LastWriteTime;
                    listaArchivos.Add(objArchivo);
                }
                //return listaArchivos;
                return listaArchivos.OrderByDescending(a => a.FechaUltimaModificacion).ToList();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void SalvarArchivo(string nombreArchivo, string tamanoArchivo, string url)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);
            Response.AddHeader("Content-Length", tamanoArchivo);
            Response.ContentType = "application/octet-stream";
            Response.TransmitFile(url);

            Response.Flush();

            File.Delete(url);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private string RutaArchivo(int tipoArchivo)
    {
        string ruta = string.Empty;

        try
        {
            switch (tipoArchivo)
            {
                //case 0: ruta = ConfigurationManager.AppSettings[Resources.Resource.DescargaArchivosXML];
                //    break;
                case 3:
                case 4:
                case 1: ruta = ConfigurationManager.AppSettings[Resources.Resource.DescargaArchivosDBF];
                    break;
                case 2: ruta = ConfigurationManager.AppSettings[Resources.Resource.CarpetaTemporal];
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ruta;
    }

    private string ExtensionArchivo(int tipoArchivo)
    {
        string extension = string.Empty;

        try
        {
            switch (tipoArchivo)
            {
                case 0: extension = "*.xml";
                    break;
                case 1: extension = "*.DBF";
                    break;
                case 3: extension = "*.XLS";
                    break;
                case 4: extension = "*.TXT";
                    break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return extension;
    }

    private void ComprimirZip(string nombre, string rutaCarpetaTemporal, string rutaSource)
    {
        try
        {
            // SE CONSTRUYE LA RUTA COMPLETA DEL ARCHIVO POR COMPRIMIR Y ENVIAR
            string urlArchivo = rutaSource + "\\" + nombre;

            // NOMBRE QUE TENDRIA EL ARCHIVO (IGUAL AL ORIGINAL PERO SE CAMBIA EL FORMATO A .ZIP)
            // SERÁ EL NOMBRE QUE SE LE SUGERIRÁ AL USUARIO CUANDO VAYA A DESCARGAR EL ARCHIVO A SU MÁQUINA
            string nombreZip = nombre.Substring(0, nombre.Length - 4) + ".zip";

            // SE CREA UN NOMBRE ÚNICO PARA EL ARCHIVO COMPRIMIDO QUE SE GUARDARÁ TEMPORALMENTE EN EL SERVIDOR
            string nombreUnicoZip = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + nombreZip;

            // RUTA COMPLETA DEL ARCHIVO COMPRIMIDA POR COPIAR
            string rutaZip = Server.MapPath(rutaCarpetaTemporal + "/" + nombreUnicoZip);

            // CREAR ARCHIVO COMPRIMIDO
            ZipOutputStream zipOutputStream = new ZipOutputStream(File.Create(rutaZip));

            // LEER EL CONTENIDO DEL ARCHIVO ORIGINAL
            // ASIGNAR LAS CREDENCIALES DEL USUARIO DEL DOMINIO PARA CUALQUIER OPERACIÓN RELACIONADA A LOS ARCHIVOS
            Impersonador personificador = new Impersonador(
                                                            ConfigurationManager.AppSettings[Resources.Resource.Usuario],
                                                            ConfigurationManager.AppSettings[Resources.Resource.Dominio],
                                                            ConfigurationManager.AppSettings[Resources.Resource.Contrasena]
                                                          );

            FileInfo infoArchivo = new FileInfo(urlArchivo);
            ZipEntry zipEntry = new ZipEntry(infoArchivo.Name);
            zipEntry.DateTime = infoArchivo.LastWriteTime;
            zipEntry.Size = infoArchivo.Length;
            zipOutputStream.PutNextEntry(zipEntry);

            byte[] buffer = new Byte[10000];
            int longitudTotalArchivo;

            FileStream fs = new System.IO.FileStream(urlArchivo, System.IO.FileMode.Open,
                        System.IO.FileAccess.Read, System.IO.FileShare.Read);


            long datosLeer = fs.Length;
            while (datosLeer > 0)
            {
                longitudTotalArchivo = fs.Read(buffer, 0, 10000);

                //AGREGA CADA SECCION LEIADA AL ARCHIVO FINAL
                zipOutputStream.Write(buffer, 0, longitudTotalArchivo);

                zipOutputStream.Flush();

                buffer = new Byte[10000];
                datosLeer = datosLeer - longitudTotalArchivo;
            }


            // COMPRIMIR EL CONTENIDO DEL ARCHIVO E INSERTARLO EN EL ARCHIVO COMPRIMIDO
            zipOutputStream.Finish();
            zipOutputStream.Close();

            fs.Close();

            // INDICARLE AL NAVEGADOR QUE LE MUESTRE AL USUARIO LA DESCARGA DEL ARCHIVO
            FileInfo fiZip = new FileInfo(rutaZip);
            SalvarArchivo(nombreZip, fiZip.Length.ToString(), rutaZip);

            // VOLVER A LAS CREDENCIALES ORIGINALES
            personificador.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion

    #endregion

    #region OTROS METODOS

    /*CARGA LAS VARIABLES GLOBALES QUE VIENEN POR URL*/
    private void VariablesGlobales()
    {
        try
        {
            #region OBTENER VALORES SESION
            //ALMACENA LA INFORMACION DE LA SESION
            dataSesion = Request.Form;
            string[] valores = dataSesion.AllKeys;
            foreach (string valor in valores)
            {
                switch (valor)
                {
                    case "idSesion":
                        idSesionOculto.Value = dataSesion["idSesion"].ToString();
                        break;
                    case "codUsuario":
                        codUsuarioOculto.Value = dataSesion["codUsuario"].ToString();
                        break;
                    case "pantallaModulo":
                        pantallaModuloOculto.Value = dataSesion["pantallaModulo"].ToString();
                        break;
                }
            }
            #endregion

            //EXTRAER EL CODIGO DE LA PANTALLA
            if (pantallaModuloOculto.Value.Length > 0)
            {
                pantallasEntidad.RutaPantalla = Page.AppRelativeVirtualPath.ToString();
                pantallasEntidad.IdPantalla = int.Parse(pantallaModuloOculto.Value); //ASIGNA EL ID DE LA PANTALLA

                pantallasEntidad = wsSeguridad.PantallasConsultarDetalle(pantallasEntidad, AsignarValoresBitacora(EnumTipoBitacora.CONSULTAR));

                pantallaCodOculto.Value = pantallasEntidad.CodPantalla.ToString();
                pantallaModuloOculto.Value = pantallasEntidad.IdPantalla.ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /*VERIFICACION DEL PERMISO DE LA PAGINA*/
    private bool AccesoPermisoPagina()
    {
        bool resultado = true;

        try
        {
            int permiso = wsSeguridad.UsuariosValidarAccesoCodigo(codUsuarioOculto.Value, pantallaCodOculto.Value);
            if (permiso.Equals(0))
            {
                httpPost = new HttpHelper();
                Dictionary<string, string> dataSesion = new Dictionary<string, string>();
                dataSesion.Add("idSesion", idSesionOculto.Value);
                dataSesion.Add("codUsuario", codUsuarioOculto.Value);
                dataSesion.Add("pantallaModulo", pantallaModuloOculto.Value);
                httpPost.RedirectAndPOST(this.Page, "../Seguridad/SinPrivilegios.aspx", dataSesion);

                resultado = false;
            }
            return resultado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected SeguridadWS.BitacorasEntidad AsignarValoresBitacora(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA

            bitacorasSeguridadEntidad.CodAccion = bitacoraFlags.TipoBitacoraConsulta(_tipo);
            bitacorasSeguridadEntidad.CodModulo = int.Parse(pantallaModuloOculto.Value);
            bitacorasSeguridadEntidad.CodEmpresa = int.Parse(Resources.Resource._empresa);
            bitacorasSeguridadEntidad.CodSistema = Resources.Resource._sistema;
            bitacorasSeguridadEntidad.CodUsuario = codUsuarioOculto.Value;

            #endregion

            return bitacorasSeguridadEntidad;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected ConfiguracionWS.BitacorasEntidad AsignarValoresBitacoraC(EnumTipoBitacora _tipo)
    {
        try
        {
            #region ENTIDAD BITACORA
            ConfiguracionWS.BitacorasEntidad bitacorasEntidadC = new ConfiguracionWS.BitacorasEntidad();
            bitacorasEntidadC.CodAccion = bitacoraFlags.TipoBitacoraConsulta(_tipo);
            bitacorasEntidadC.CodModulo = int.Parse(pantallaModuloOculto.Value);
            bitacorasEntidadC.CodEmpresa = int.Parse(Resources.Resource._empresa);
            bitacorasEntidadC.CodSistema = Resources.Resource._sistema;
            bitacorasEntidadC.CodUsuario = codUsuarioOculto.Value;

            #endregion

            return bitacorasEntidadC;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void AsignaWebServicesTypeNames()
    {
        try
        {
            wsLista.Url = ConfigurationManager.AppSettings["ListasWS"].ToString();
            wsSesiones.Url = ConfigurationManager.AppSettings["SesionesWCF"].ToString();
            wsSeguridad.Url = ConfigurationManager.AppSettings["SeguridadWS"].ToString();
            wsConfiguracion.Url = ConfigurationManager.AppSettings["ConfiguracionWS"].ToString();
            wsConsultas.Url = ConfigurationManager.AppSettings["ConsultasWS"].ToString();

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(ConfigurationManager.AppSettings["Culture"].ToString());
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ConfigurationManager.AppSettings["Culture"].ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #endregion

    #region MIEMBRO IDISPOSABLE

    #region VARIABLES

    private bool disponible = false;

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
        if (!disponible)
        {
            if (disposing)
            {
                if (wsConfiguracion != null)
                {
                    wsConfiguracion.Dispose();
                    wsConfiguracion = null;
                }

                if (wsSeguridad != null)
                {
                    wsSeguridad.Dispose();
                    wsSeguridad = null;
                }
            }
            pantallasEntidad = null;
            bitacorasSeguridadEntidad = null;

            dataSesion = null;
            disponible = true;
        }
    }

    #endregion
}