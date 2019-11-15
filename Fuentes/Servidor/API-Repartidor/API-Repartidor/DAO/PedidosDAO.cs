using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.Entities;
using NHibernate;

namespace API_Repartidor.DAO
{
    public class PedidosDAO : GenericDAO<Pedido, long>
    {
        public PedidosDAO(ISession session) : base(session)
        {

        }
        public IList<Pedido> findAllPending()
        {
            try
            {
                return this.session.QueryOver<Pedido>().Where(x => x.entregado == 0).List();
                //return this.session.CreateCriteria(typeof(Pedido)).List<Pedido>();
            }
            catch
            {
                throw;
            }
        }
    }
}
