namespace T4WebFormsInjection.Tests.WebServices
{
    using T4WebFormsInjection.Tests.Helper;

    using T4WFI.App.Code;
    using T4WFI.App.WebServices;

    using Xunit;

    public class WebService1Tests
    {
        [Fact]
        public void DependenciesCreated()
        {
            Target.CheckDependenciesAreConstructed<WebService1>(Dependency.Create<IDummyInterface>(), Dependency.Create<IDummyInterface2>());
        }
    }
}