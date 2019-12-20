using System.Collections.Generic;
using API_Repartidor.Entities;
using NHibernate;

namespace API_Repartidor.DAO
{
    public class PedidosDAO : GenericDAO<Pedido, long>
    {
        public PedidosDAO(ISession session) : base(session)
        {

        }
        internal IList<Pedido> FindAllPending()
        {
            return this.session.QueryOver<Pedido>().Where(x => x.entregado == 0).List();
        }
    }
}
