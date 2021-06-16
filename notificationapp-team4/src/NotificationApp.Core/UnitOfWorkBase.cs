using System;
using System.Collections.Generic;

namespace NotificationApp
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        private readonly List<Action> afterCommitActions = new List<Action>();
        private readonly List<Action> afterRollbackActions = new List<Action>();
        private bool isDisposed;

        public event EventHandler Disposing;

        public virtual void Commit()
        {
            this.CommitCore();
            this.RunAfterCommitActions();
        }

        public virtual void Rollback()
        {
            this.RollbackCore();
            this.RunAfterRollbackActions();
        }

        public void RegisterAfterCommitAction(Action action)
        {
            this.afterCommitActions.Add(action);
        }

        public void RegisterAfterRollbackAction(Action action)
        {
            this.afterRollbackActions.Add(action);
        }

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.isDisposed = true;

                this.OnDisposing();
                this.DisposeCore();
            }
        }

        private void RunAfterCommitActions()
        {
            foreach (var action in this.afterCommitActions)
            {
                action();
            }

            this.afterCommitActions.Clear();
        }

        private void RunAfterRollbackActions()
        {
            foreach (var action in this.afterRollbackActions)
            {
                action();
            }

            this.afterRollbackActions.Clear();
        }

        protected abstract void CommitCore();

        protected abstract void RollbackCore();

        protected abstract void DisposeCore();

        protected virtual void OnDisposing()
        {
            this.Disposing?.Invoke(this, EventArgs.Empty);
        }
    }
}