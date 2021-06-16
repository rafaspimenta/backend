using System.Collections.Generic;
using System.Threading;

namespace NotificationApp
{
    public class AsyncLocalUnitOfWorkRegistry : UnitOfWorkRegistryBase
    {
        private readonly AsyncLocal<Stack<IUnitOfWork>> stack = new AsyncLocal<Stack<IUnitOfWork>>();

        protected override Stack<IUnitOfWork> GetStack()
        {
            if (stack.Value == null)
            {
                stack.Value = new Stack<IUnitOfWork>();
            }
            return stack.Value;
        }
    }
}