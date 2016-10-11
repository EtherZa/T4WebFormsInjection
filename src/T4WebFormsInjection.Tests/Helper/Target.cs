namespace T4WebFormsInjection.Tests.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Moq;

    using T4WFI.App.Code;

    public static class Target
    {
        private static readonly MethodInfo SetupMethod;

        private static readonly MethodInfo VerifyMethod;

        static Target()
        {
            Target.SetupMethod = typeof(Target).GetMethod(nameof(Target.Setup), BindingFlags.NonPublic | BindingFlags.Static);
            Target.VerifyMethod = typeof(Target).GetMethod(nameof(Target.Verify), BindingFlags.NonPublic | BindingFlags.Static);
        }

        public static void CheckDependenciesAreConstructed<T>(params Dependency[] dependencies) where T : new()
        {
            lock (Container.SyncRoot)
            {
                var mockContainer = new Mock<IContainer>(MockBehavior.Strict);
                Container.Instance = mockContainer.Object;

                try
                {
                    Target.SetupDependencies(mockContainer, dependencies);

                    var target = new T();
                    (target as IDisposable)?.Dispose();

                    Target.VerifyDependencies(mockContainer, dependencies);
                }
                finally
                {
                    Container.Instance = null;
                }
            }
        }

        private static void SetupDependencies(Mock<IContainer> mock, IEnumerable<Dependency> types)
        {
            foreach (var type in types.Select(x => x.Type))
            {
                var parameters = new object[]
                                     {
                                         mock
                                     };

                var genericMethod = Target.SetupMethod.MakeGenericMethod(type);
                genericMethod.Invoke(null, parameters);
            }
        }

        private static void VerifyDependencies(Mock<IContainer> mock, IEnumerable<Dependency> dependencies)
        {
            foreach (var dependency in dependencies)
            {
                var parameters = new object[]
                                     {
                                         mock,
                                         dependency.TimesCalled
                                     };

                var genericMethod = Target.VerifyMethod.MakeGenericMethod(dependency.Type);
                genericMethod.Invoke(null, parameters);
            }
        }

        private static void Setup<T>(Mock<IContainer> mock) where T : class
        {
            mock.Setup(x => x.GetInstance<T>()).Returns(
                    () =>
                        {
                            var dependency = new Mock<T>();
                            return dependency.Object;
                        }).Verifiable();
        }

        private static void Verify<T>(Mock<IContainer> mock, int timesCalled) where T : class
        {
            mock.Verify(x => x.GetInstance<T>(), Times.Exactly(timesCalled));
        }
    }
}