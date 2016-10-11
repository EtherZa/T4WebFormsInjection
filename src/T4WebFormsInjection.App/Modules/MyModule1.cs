namespace T4WFI.App.Modules
{
    using System.Web;

    using T4WFI.App.Code;

    public partial class MyModule1 : IHttpModule
    {
        public MyModule1(IDummyInterface dummyInterface)
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