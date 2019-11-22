using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.Entities;
using NHibernate;

namespace API_Repartidor.DAO
{
    public class ProductosDAO : GenericDAO<Producto, long>
    {
        public ProductosDAO(ISession session) : base(session)
        {

        }
    }
}
