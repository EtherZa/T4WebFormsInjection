namespace T4WebFormsInjection.Tests.Pages
{
    using T4WebFormsInjection.Tests.Helper;

    using T4WFI.App.Code;
    using T4WFI.App.Pages;

    using Xunit;

    public class WebForm2Tests
    {
        [Fact]
        public void DependenciesCreated()
        {
            Target.CheckDependenciesAreConstructed<WebForm2>(Dependency.Create<IDummyInterface>(), Dependency.Create<IDummyInterface2>());
        }
    }
}