using System.Data.Common;

namespace NotificationApp.Data
{
    public interface IDbConnectionFactory
    {
        DbConnection Create();
    }
}