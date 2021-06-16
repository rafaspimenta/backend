namespace NotificationApp
{
    public interface IUnitOfWorkRegistry
    {
        void RegisterUnitOfWork(IUnitOfWork unitOfWork);

        void UnregisterUnitOfWork(IUnitOfWork unitOfWork);

        IUnitOfWork GetCurrent(int ancestorLevel = 0);
    }
}