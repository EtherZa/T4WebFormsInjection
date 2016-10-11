namespace T4WebFormsInjection.Tests.Handlers
{
    using T4WebFormsInjection.Tests.Helper;

    using T4WFI.App.Code;
    using T4WFI.App.Handlers;

    using Xunit;

    public class Handler2Tests
    {
        [Fact]
        public void DependenciesCreated()
        {
            Target.CheckDependenciesAreConstructed<Handler2>(Dependency.Create<IDummyInterface>(), Dependency.Create<IDummyInterface2>());
        }
    }
}