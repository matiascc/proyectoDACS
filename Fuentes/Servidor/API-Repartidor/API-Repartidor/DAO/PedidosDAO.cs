using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;

namespace API_Repartidor.DAO
{
    public class PedidosDAO // GenericDAO<Pedido,int>
    {
        //private ISessionFactory sessionFactory { get; }
        private static ISessionFactory sessions;

        /*public Pedido GetPedidoByID(int id)
        {
            return getSession.Load<Pedido>(id);
        }*/

        public IList<Pedido> GetPedidos()
        {
            try
            {
                sessions = new Configuration().BuildSessionFactory();
                using (ISession session = sessions.OpenSession())
                using (ITransaction tx = session.BeginTransaction())
                {
                    IList<Pedido> list = session.QueryOver<Pedido>().List<Pedido>();
                    tx.Commit();
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
