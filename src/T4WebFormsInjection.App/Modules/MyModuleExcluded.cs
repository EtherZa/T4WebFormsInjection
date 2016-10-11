namespace T4WFI.App.Modules
{
    using System;
    using System.Web;

    public class MyModuleExcluded : IHttpModule
    {
        public void OnLogRequest(object source, EventArgs e)
        {
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
        }
    }
}