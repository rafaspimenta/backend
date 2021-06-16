using System;

namespace NotificationApp
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();

        void RegisterAfterCommitAction(Action action);

        event EventHandler Disposing;
    }
}
