namespace T4WebFormsInjection.Tests
{
    using Moq;

    using T4WFI.App;
    using T4WFI.App.Code;

    using Xunit;

    public class DependencyTrackerTests
    {
        [Fact]
        public void DependenciesAreReleased()
        {
            lock (Container.SyncRoot)
            {
                var mockContainer = new Mock<IContainer>(MockBehavior.Strict);
                Container.Instance = mockContainer.Object;
                try
                {
                    var o = new object();

                    mockContainer.Setup(x => x.Release(o)).Verifiable();

                    var target = new T4WebFormsInjection.DependencyTracker();
                    target.Add(o);

                    target.Release();

                    mockContainer.Verify(x => x.Release(o), Times.Once);
                }
                finally
                {
                    Container.Instance = null;
                }
            }
        }
    }
}