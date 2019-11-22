using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.Entities;
using NHibernate;

namespace API_Repartidor.DAO
{
    public class ItemPedidosDAO : GenericDAO<ItemPedido, long>
    {
        public ItemPedidosDAO(ISession session) : base(session)
        {
        }
    }
}
