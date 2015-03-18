namespace T4WebFormsInjection.App.Pages
{
    using T4WebFormsInjection.App.Code;

    public partial class WebForm2 : System.Web.UI.Page
    {
        public WebForm2(IDummyInterface dummyInterface, IDummyInterface2 dummyInterface2)
        {
        }
    }
}