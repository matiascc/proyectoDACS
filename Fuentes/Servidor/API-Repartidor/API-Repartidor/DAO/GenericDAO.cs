using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DAO
{
    public abstract class GenericDAO<T,ID>
    {
        private ISessionFactory sessionFactory { get; }
        public T findByID(ID id)
        {
            try
            {
                return getSession.Load<T>(id);
            }
            catch
            {
                throw;
            }
        }
        public IList<T> findAll()
        {
            try
            {
                return getSession.CreateCriteria(typeof(T)).List<T>();
            }
            catch
            {
                throw;
            }
        }
        public T makePersistent(T entity)
        {
            using (ITransaction transaction = getSession.BeginTransaction())
            {
                try
                {
                    getSession.Save(entity);
                    transaction.Commit();
                    return entity;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void delete(T entity)
        {
            using (ITransaction transaction = getSession.BeginTransaction())
            {
                try
                {
                    getSession.Delete(entity);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        protected ISession getSession
        {
            get { return sessionFactory.GetCurrentSession(); }
        }
    }
}
