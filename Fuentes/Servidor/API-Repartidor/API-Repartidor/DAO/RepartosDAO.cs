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
