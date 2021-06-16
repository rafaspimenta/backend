namespace NotificationApp.Data
{
    public class DbUnitOfWorkProvider : UnitOfWorkProviderBase
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public DbUnitOfWorkProvider(IUnitOfWorkFactory unitOfWorkFactory, IUnitOfWorkRegistry unitOfWorkRegistry)
            : base(unitOfWorkRegistry)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        protected override IUnitOfWork CreateUnitOfWork(object parameter) =>
            this.unitOfWorkFactory.Create();
    }
}