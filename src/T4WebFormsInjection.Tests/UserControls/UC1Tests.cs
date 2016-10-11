namespace T4WebFormsInjection.Tests.UserControls
{
    using T4WebFormsInjection.Tests.Helper;

    using T4WFI.App.Code;
    using T4WFI.App.UserControls;

    using Xunit;

    public class Uc1Tests
    {
        [Fact]
        public void DependencyCreated()
        {
            Target.CheckDependenciesAreConstructed<UC1>(Dependency.Create<IDummyInterface>());
        }
    }
}