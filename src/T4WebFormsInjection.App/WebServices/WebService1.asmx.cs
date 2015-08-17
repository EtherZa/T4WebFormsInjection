using System.ComponentModel;
using System.Web.Services;
using T4WFI.App.Code;

namespace T4WFI.App.WebServices
{
    /// <summary>
    ///     Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public partial class WebService1 : WebService
    {
        public WebService1(IDummyInterface dummyInterface, IDummyInterface2 dummyInterface2)
        {
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}