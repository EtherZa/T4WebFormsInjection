namespace T4WebFormsInjection.App.Handlers
{
    using System.Web;

    /// <summary>
    /// Summary description for HandlerExcluded
    /// </summary>
    public class HandlerExcluded : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }
    }
}