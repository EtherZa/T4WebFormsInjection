namespace T4WFI.App
{
    using T4WFI.App.Code;
    using T4WFI.App.Code.Pseudo;

    public static class ContainerConfig
    {
        public static void Register()
        {
            Container.Instance = new PseudoContainer();
        }
    }
}