using System;

namespace NotificationApp
{
    public abstract class UnitOfWorkProviderBase : IUnitOfWorkProvider
    {
        private readonly IUnitOfWorkRegistry registry;

        protected UnitOfWorkProviderBase(IUnitOfWorkRegistry registry)
        {
            this.registry = registry;
        }

        public virtual IUnitOfWork Create()
        {
            return this.CreateCore(null);
        }

        protected IUnitOfWork CreateCore(object parameter)
        {
            var uow = this.CreateUnitOfWork(parameter);
            registry.RegisterUnitOfWork(uow);
            uow.Disposing += this.OnUnitOfWorkDisposing;
            return uow;
        }

        protected abstract IUnitOfWork CreateUnitOfWork(object parameter);


        private void OnUnitOfWorkDisposing(object sender, EventArgs e)
        {
            registry.UnregisterUnitOfWork((IUnitOfWork)sender);
        }


        public IUnitOfWork GetCurrent(int ancestorLevel = 0)
        {
            return registry.GetCurrent(ancestorLevel);
        }
    }
}