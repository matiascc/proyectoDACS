using API_Repartidor.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Mappings
{
    public class PedidoMap : ClassMapping<Pedido>
    {
        public PedidoMap()
        {
            Table("Pedido");

            Id(x => x.Id, m => 
            {
                m.Generator(Generators.Increment);
                m.UnsavedValue(0);
            });

            Property(x => x.fechaCreación);
            Property(x => x.fechaFinalizacion);
            Property(x => x.fechaLimite);
            Property(x => x.entregado);
            Property(x => x.precioTotal);

            Set(x => x.itemPedido,
                cm =>
                {
                    cm.Lazy(CollectionLazy.Lazy);
                },
            action => action.OneToMany());

        }
    }
}
