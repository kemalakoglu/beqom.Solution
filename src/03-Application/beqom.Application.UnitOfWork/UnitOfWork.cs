﻿using System;
using System.Collections;
using System.Transactions;
using beqom.Core.Contract;
using beqom.Domain.Context.Context;
using beqom.Domain.Repository;

namespace beqom.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Implementation of IUnitOfWork

        public CoreContext context { get; }
        private Hashtable repositories;
        private bool disposed;

        public UnitOfWork(CoreContext context)
        {
            this.context = context;
        }

        /// <summary>
        ///     MainRepository method
        /// </summary>
        /// <typeparam name="T">Entity Classes</typeparam>
        /// <returns>MainRepository Object</returns>
        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
                repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(MainRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(T)), context);

                repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)repositories[type];
        }

        /// <summary>
        ///     To clear memory leak
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     To clear memory leak byParameter
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();

            disposed = true;
        }

        /// <summary>
        ///     To save context data end end transaction
        /// </summary>
        public void EndTransaction()
        {
            using (var trScope = new TransactionScope())
            {
                context.SaveChanges();
                trScope.Complete();
            }
        }
    }

#endregion
}
