using System.Web;
using T4WFI.App.Code;

namespace T4WFI.App.Handlers
{
    public partial class Handler1 : IHttpHandler
    {
        public Handler1(IDummyInterface dummyInterface)
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