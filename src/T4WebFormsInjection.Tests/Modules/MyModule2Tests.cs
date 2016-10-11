namespace T4WebFormsInjection.Tests.Modules
{
    using T4WebFormsInjection.Tests.Helper;

    using T4WFI.App.Code;
    using T4WFI.App.Modules;

    using Xunit;

    public class MyModule2Tests
    {
        [Fact]
        public void DependenciesCreated()
        {
            Target.CheckDependenciesAreConstructed<MyModule2>(Dependency.Create<IDummyInterface>(), Dependency.Create<IDummyInterface2>());
        }
    }
}