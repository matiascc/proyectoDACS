using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DAO
{
    public abstract class GenericDAO<T,ID>
    {
        protected ISession session;
        public GenericDAO(ISession session)
        {
            this.session = session;
        }

        public T findByID(ID id)
        {
            try
            {
                return this.session.Get<T>(id);
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
                return this.session.CreateCriteria(typeof(T)).List<T>();
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
                this.session.Save(entity);
                this.session.Flush();
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
                this.session.Delete(entity);
                this.session.Flush();
            }
            catch
            {
                throw;
            }
        }

        public void update(T entity)
        {
            try
            {
                this.session.Update(entity);
                this.session.Flush();
            }
            catch
            {
                throw;
            }
        }
    }
}
