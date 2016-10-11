namespace T4WFI.App.Handlers
{
    using System.Web;

    public class HandlerExcluded : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }
    }
}