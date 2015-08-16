using System.Web.UI;
using T4WebFormsInjection.App.Code;

namespace T4WebFormsInjection.App.MasterPages
{
    public partial class Site1 : MasterPage
    {
        public Site1(IDummyInterface dummyInterface)
        {
        }
    }
}