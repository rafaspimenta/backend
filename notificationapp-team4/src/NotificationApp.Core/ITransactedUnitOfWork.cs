namespace NotificationApp
{
    public interface ITransactedUnitOfWork : IUnitOfWork
    {
        void BeginTransaction();
    }
}