using System.Collections.Generic;
using System.Threading;

namespace NotificationApp
{
    public class ThreadLocalUnitOfWorkRegistry : UnitOfWorkRegistryBase
    {
        private readonly ThreadLocal<Stack<IUnitOfWork>> stack
            = new ThreadLocal<Stack<IUnitOfWork>>(() => new Stack<IUnitOfWork>());

        protected override Stack<IUnitOfWork> GetStack()
        {
            return stack.Value;
        }
    }
}