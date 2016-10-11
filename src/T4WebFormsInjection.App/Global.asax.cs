namespace T4WFI.App
{
    using System;
    using System.Web;

    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ContainerConfig.Register();
        }
    }
}