namespace T4WFI.App.Code
{
    public static class Container
    {
        static Container()
        {
            Container.SyncRoot = new object();
        }

        public static object SyncRoot { get; }

        public static IContainer Instance { get; set; }

        public static T GetInstance<T>()
            where T : class
        {
            return Container.Instance.GetInstance<T>();
        }

        public static void Release(object o)
        {
            Container.Instance.Release(o);
        }
    }
}