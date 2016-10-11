namespace T4WebFormsInjection.Tests.Helper
{
    using System;

    public sealed class Dependency
    {
        public Dependency(Type type, int timesCalled)
        {
            this.Type = type;
            this.TimesCalled = timesCalled;
        }

        public Type Type { get; }

        public int TimesCalled { get; }

        public static Dependency Create<T>(int timesCalled = 1) where T : class
        {
            return new Dependency(typeof(T), timesCalled);
        }
    }
}