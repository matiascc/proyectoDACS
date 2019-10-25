using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.Entities;
using NHibernate;

namespace API_Repartidor.DAO
{
    public class RepartosDAO : GenericDAO<Reparto, long>
    {
        public RepartosDAO(ISession session) : base(session)
        {
        }
    }
}
