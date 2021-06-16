using System.Data;
using System.Data.Common;

namespace NotificationApp.Data
{
    public class DbUnitOfWork : UnitOfWorkBase, IDbUnitOfWork
    {
        private readonly IDbConnectionFactory connectionFactory;
        private bool isTransacted;
        private IsolationLevel? isolationLevel;

        private readonly object objLock = new object();

        private DbConnection connection;
        private DbTransaction transaction;

        private bool isInitialized;

        public DbUnitOfWork(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public DbConnection Connection
        {
            get
            {
                this.CheckInitialized();
                return this.connection;
            }
        }

        public DbTransaction Transaction
        {
            get
            {
                this.CheckInitialized();
                return this.transaction;
            }
        }

        private void CheckInitialized()
        {
            if (this.isInitialized)
            {
                return;
            }

            lock (this.objLock)
            {
                if (this.isInitialized)
                {
                    return;
                }

                if (this.connection == null)
                {
                    this.connection = this.connectionFactory.Create();
                    this.connection.Open();
                }

                if (this.isTransacted)
                {
                    this.CreateTransaction();
                }

                this.isInitialized = true;
            }
        }

        private void CreateTransaction()
        {
            if (this.isolationLevel.HasValue)
            {
                this.transaction = this.connection.BeginTransaction(this.isolationLevel.Value);
            }
            else
            {
                this.transaction = this.connection.BeginTransaction();
            }
        }

        protected override void CommitCore()
        {
            if (this.transaction != null)
            {
                this.transaction.Commit();
            }
        }

        protected override void RollbackCore()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
            }
        }

        protected override void DisposeCore()
        {
            this.transaction?.Dispose();
            this.connection?.Dispose();
        }

        public void BeginTransaction()
        {
            this.isTransacted = true;
            if (this.isInitialized && this.transaction == null)
            {
                this.CreateTransaction();
            }
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            this.isolationLevel = isolationLevel;
            this.isTransacted = true;

            if (this.isInitialized && this.transaction == null)
            {
                this.CreateTransaction();
            }
        }
    }
}
