namespace T4WFI.App.WebServices
{
    using System.ComponentModel;
    using System.Web.Services;

    using T4WFI.App.Code;

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