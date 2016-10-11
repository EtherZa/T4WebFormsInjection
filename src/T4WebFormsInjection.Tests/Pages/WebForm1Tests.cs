namespace T4WebFormsInjection.Tests.Pages
{
    using T4WebFormsInjection.Tests.Helper;

    using T4WFI.App.Code;
    using T4WFI.App.Pages;

    using Xunit;

    public class WebForm1Tests
    {
        [Fact]
        public void DependencyCreated()
        {
            Target.CheckDependenciesAreConstructed<WebForm1>(Dependency.Create<IDummyInterface>(), Dependency.Create<IDummyInterface2>());
        }
    }
}