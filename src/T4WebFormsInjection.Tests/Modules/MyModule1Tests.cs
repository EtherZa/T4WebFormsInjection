namespace T4WebFormsInjection.Tests.Modules
{
    using T4WebFormsInjection.Tests.Helper;

    using T4WFI.App.Code;
    using T4WFI.App.Modules;

    using Xunit;

    public class MyModule1Tests
    {
        [Fact]
        public void DependencyCreated()
        {
            Target.CheckDependenciesAreConstructed<MyModule1>(Dependency.Create<IDummyInterface>());
        }
    }
}