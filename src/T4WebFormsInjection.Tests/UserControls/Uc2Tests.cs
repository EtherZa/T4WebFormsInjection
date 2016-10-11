namespace T4WebFormsInjection.Tests.UserControls
{
    using T4WebFormsInjection.Tests.Helper;

    using T4WFI.App.Code;
    using T4WFI.App.UserControls;

    using Xunit;

    public class Uc2Tests
    {
        [Fact]
        public void DependenciesCreated()
        {
            Target.CheckDependenciesAreConstructed<UC2>(Dependency.Create<IDummyInterface>(), Dependency.Create<IDummyInterface2>());
        }
    }
}