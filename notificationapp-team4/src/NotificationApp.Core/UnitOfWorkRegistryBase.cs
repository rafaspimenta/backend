using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationApp
{
    public abstract class UnitOfWorkRegistryBase : IUnitOfWorkRegistry
    {
        private readonly IUnitOfWorkRegistry alternateRegistry;

        protected UnitOfWorkRegistryBase(IUnitOfWorkRegistry alternateRegistry = null)
        {
            this.alternateRegistry = alternateRegistry;
        }

        protected IUnitOfWorkRegistry AlternateRegistry
        {
            get
            {
                if (this.alternateRegistry == null)
                {
                    throw new InvalidOperationException($"The {this.GetType()} was not able to provide current unit of work and there is no alternate registry configured!");
                }

                return this.alternateRegistry;
            }
        }

        protected abstract Stack<IUnitOfWork> GetStack();

        public void RegisterUnitOfWork(IUnitOfWork unitOfWork)
        {
            var unitOfWorkStack = this.GetStack();
            if (unitOfWorkStack == null)
            {
                this.AlternateRegistry.RegisterUnitOfWork(unitOfWork);
            }
            else
            {
                unitOfWorkStack.Push(unitOfWork);
            }
        }

        public void UnregisterUnitOfWork(IUnitOfWork unitOfWork)
        {
            var unitOfWorkStack = this.GetStack();
            if (unitOfWorkStack == null)
            {
                this.AlternateRegistry.UnregisterUnitOfWork(unitOfWork);
            }
            else
            {
                if (unitOfWorkStack.Any())
                {
                    if (unitOfWorkStack.Pop() == unitOfWork)
                    {
                        return;
                    }
                }
                throw new InvalidOperationException("Some of the unit of works was not disposed correctly!");
            }
        }

        public IUnitOfWork GetCurrent(int ancestorLevel = 0)
        {
            var unitOfWorkStack = this.GetStack();
            if (unitOfWorkStack == null)
            {
                return this.AlternateRegistry.GetCurrent(ancestorLevel);
            }

            if (ancestorLevel >= unitOfWorkStack.Count)
            {
                return null;
            }
            else if (ancestorLevel == 0)
            {
                return unitOfWorkStack.Peek();
            }
            else
            {
                return unitOfWorkStack.ToArray()[ancestorLevel];
            }
        }
    }
}