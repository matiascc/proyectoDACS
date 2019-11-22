using API_Repartidor.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace API_Repartidor.Mappings
{
    public class RepartoMap : ClassMapping<Reparto>
    {
        public RepartoMap()
        {
            Table("Reparto");

            Id(x => x.id, m => 
            {
                m.Generator(Generators.Increment);
                m.UnsavedValue(0);
            });

            Property(x => x.fecha);
            Property(x => x.finalizado);

            Set(x => x.pedidos,
                cm =>
                {
                    cm.Lazy(CollectionLazy.Lazy);
                    cm.Cascade(Cascade.All);
                },
            action => action.OneToMany());

        }
    }
}
