namespace T4WFI.App.Code.Pseudo
{
    using System.Diagnostics;

    public class PseudoContainer : IContainer
    {
        public T GetInstance<T>() where T : class
        {
            var target = new PseudoTarget() as T;

            Debug.WriteLine($"Created {target}", nameof(PseudoContainer));

            return target;
        }

        public void Release(object o)
        {
            Debug.WriteLine($"Releasing {o}", nameof(PseudoContainer));
        }

        private class PseudoTarget : IDummyInterface, IDummyInterface2
        {
            private static int instanceCount;

            private readonly int instance;

            static PseudoTarget()
            {
                PseudoTarget.instanceCount = 0;
            }

            public PseudoTarget()
            {
                this.instance = PseudoTarget.instanceCount++;
            }

            public override string ToString()
            {
                return $"Instance {this.instance}";
            }
        }
    }
}