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

        public static void CheckDependenciesAreConstructed<T>(params Dependency[] dependencies) where T : class, new()
        {
            lock (Container.SyncRoot)
            {
                var mockContainer = new Mock<IContainer>(MockBehavior.Strict);
                Container.Instance = mockContainer.Object;

                try
                {
                    var trackedDependencies = dependencies.Select(x => new TrackedDependency(x)).ToArray();
                    Target.SetupDependencies(mockContainer, trackedDependencies);

                    var target = new T();
                    (target as IDisposable)?.Dispose();
                    target = null;

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    Target.VerifyDependencies(mockContainer, dependencies);

                    // TODO: GC.Collect is not collecting as expected. As such dependencies are not released immediately.
                    // foreach (var trackedDependency in trackedDependencies)
                    // {
                    //     foreach (var value in trackedDependency.Values)
                    //     {
                    //         mockContainer.Verify(x => x.Release(value), Times.Once, $"Dependency {trackedDependency.Dependency.Type} was not released.");
                    //     }
                    // }
                }
                finally
                {
                    Container.Instance = null;
                }
            }
        }

        private static void SetupDependencies(Mock<IContainer> mock, IEnumerable<TrackedDependency> dependencies)
        {
            foreach (var dependency in dependencies)
            {
                var parameters = new object[]
                                     {
                                         mock,
                                         dependency
                                     };

                var genericMethod = Target.SetupMethod.MakeGenericMethod(dependency.Dependency.Type);
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

        private static void Setup<T>(Mock<IContainer> mock, TrackedDependency dependency) where T : class
        {
            mock.Setup(x => x.GetInstance<T>()).Returns(
                    () =>
                        {
                            var mockValue = new Mock<T>();
                            return (T)dependency.Add(mockValue.Object);
                        }).Verifiable();
        }

        private static void Verify<T>(Mock<IContainer> mock, int timesCalled) where T : class
        {
            mock.Verify(x => x.GetInstance<T>(), Times.Exactly(timesCalled));
        }

        private class TrackedDependency
        {
            private readonly List<object> objects;

            public TrackedDependency(Dependency dependency)
            {
                this.Dependency = dependency;
                this.objects = new List<object>();
            }

            public Dependency Dependency { get; }

            public IEnumerable<object> Values => this.objects;

            public object Add(object o)
            {
                this.objects.Add(o);
                return o;
            }
        }
    }
}