using System.Data.Common;

namespace NotificationApp.Data
{
    public static class UnitOfWorkProviderExtensions
    {
        public static DbConnection GetConnection(this IUnitOfWorkProvider unitOfWorkProvider) =>
            (unitOfWorkProvider?.GetCurrent() as IDbUnitOfWork)?.Connection;
    }
}
