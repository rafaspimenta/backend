namespace NotificationApp.Data
{
    public class DbUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbConnectionFactory connectionFactory;

        public DbUnitOfWorkFactory(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IUnitOfWork Create()
        {
            return new DbUnitOfWork(connectionFactory);
        }
    }
}
