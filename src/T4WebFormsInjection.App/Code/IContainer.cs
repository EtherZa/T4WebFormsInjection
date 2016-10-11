namespace T4WFI.App.Code
{
    public interface IContainer
    {
        T GetInstance<T>();
    }
}