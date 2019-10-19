using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DAO
{
    public abstract class GenericDAO<T,ID>
    {
        private readonly ISessionFactory sessionFactory;
        public GenericDAO(ISessionFactory sessionfactory)
        {
            this.sessionFactory = sessionfactory;
        }

        protected ISession Session
        {
            get
            {
                return this.sessionFactory.GetCurrentSession();
            }
        }

        public T findByID(ID id)
        {
            try
            {
                return this.Session.Get<T>(id);
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
                return this.Session.CreateCriteria(typeof(T)).List<T>();
            }
            catch
            {
                throw;
            }
        }
        public T save(T entity)
        {
            try
            {
                this.Session.Save(entity);
                return entity;
            }
            catch
            {
                throw;
            }
        }
        public void delete(T entity)
        {
            try
            {
                this.Session.Delete(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
