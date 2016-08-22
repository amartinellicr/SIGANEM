<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        var ex = Server.GetLastError();
        var httpException = ex as HttpException ?? ex.InnerException as HttpException;
        if (httpException == null) return;

        if (httpException.WebEventCode == System.Web.Management.WebEventCodes.RuntimeErrorPostTooLarge)
        {
            //handle the error
            Response.Write("Too big a file, dude"); //for example
        }

    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        //SCRIPTING ENTRE MARCOS
        HttpContext.Current.Response.AddHeader("x-frame-options", "DENY");

        //CACHING
        //IE
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        //OTROS NAVEGADORES
        Response.Cache.SetNoStore();
    }
    
    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
