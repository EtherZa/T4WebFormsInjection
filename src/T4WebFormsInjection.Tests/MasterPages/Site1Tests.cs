namespace T4WebFormsInjection.Tests.MasterPages
{
    using T4WebFormsInjection.Tests.Helper;

    using T4WFI.App.Code;
    using T4WFI.App.MasterPages;

    using Xunit;

    public class Site1Tests
    {
        [Fact]
        public void DependencyCreated()
        {
            Target.CheckDependenciesAreConstructed<Site1>(Dependency.Create<IDummyInterface>());
        }
    }
}