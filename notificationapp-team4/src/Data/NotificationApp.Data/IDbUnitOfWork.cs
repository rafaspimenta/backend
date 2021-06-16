using System.Data.Common;

namespace NotificationApp.Data
{
    public interface IDbUnitOfWork : IUnitOfWork
    {
        DbConnection Connection { get; }
    }
}
