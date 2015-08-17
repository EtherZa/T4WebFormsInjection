using System.Web;
using T4WFI.App.Code;

namespace T4WFI.App.Handlers
{
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