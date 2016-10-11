namespace T4WebFormsInjection.Tests.Handlers
{
    using T4WebFormsInjection.Tests.Helper;

    using T4WFI.App.Code;
    using T4WFI.App.Handlers;

    using Xunit;

    public class Handler1Tests
    {
        [Fact]
        public void DependencyCreated()
        {
            Target.CheckDependenciesAreConstructed<Handler1>(Dependency.Create<IDummyInterface>());
        }
    }
}