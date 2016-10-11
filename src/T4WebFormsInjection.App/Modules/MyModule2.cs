namespace T4WFI.App.Modules
{
    using System.Web;

    using T4WFI.App.Code;

    public partial class MyModule2 : IHttpModule
    {
        public MyModule2(IDummyInterface dummyInterface, IDummyInterface2 dummyInterface2)
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