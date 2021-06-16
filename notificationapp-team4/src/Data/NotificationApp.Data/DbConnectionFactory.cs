using System.Data.Common;

namespace NotificationApp.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly DbUnitOfWorkOptions options;

        public DbConnectionFactory(DbUnitOfWorkOptions options)
        {
            this.options = options;
        }

        public DbConnection Create()
        {
            return new MySql.Data.MySqlClient.MySqlConnection(options.ConnectionString);
        }
    }
}