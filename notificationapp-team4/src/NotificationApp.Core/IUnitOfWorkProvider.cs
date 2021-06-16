namespace NotificationApp
{
    public interface IUnitOfWorkProvider
    {
        IUnitOfWork Create();

        IUnitOfWork GetCurrent(int ancestorLever = 0);
    }
}
