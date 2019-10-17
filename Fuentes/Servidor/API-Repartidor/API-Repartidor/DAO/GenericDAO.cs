using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DAO
{
    public abstract class GenericDAO<T,ID>
    {
        public T findByID(ID id, ISession session)
        {
            try
            {
                return session.Get<T>(id);
            }
            catch
            {
                throw;
            }
        }
        public IList<T> findAll(ISession session)
        {
            try
            {
                return session.CreateCriteria(typeof(T)).List<T>();
            }
            catch
            {
                throw;
            }
        }
        public T makePersistent(T entity, ISession session)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Save(entity);
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
        public void delete(T entity, ISession session)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
