namespace T4WebFormsInjection.App.Handlers
{
    using System.Web;

    using T4WebFormsInjection.App.Code;

    public partial class Handler2 : IHttpHandler
    {
        public Handler2(IDummyInterface dummyInterface, IDummyInterface2 dummyInterface2)
        {
        }

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