using API_Repartidor.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Mappings
{
    public class ItemPedidoMap : ClassMapping<ItemPedido>
    {
        public ItemPedidoMap()
        {
            Table("ItemPedido");

            Id(x => x.Id, m => {
                m.Generator(Generators.Increment);
                m.UnsavedValue(0);
            });

            Property(x => x.cantidad);
            Property(x => x.cantidadRechazada);
            Property(x => x.precio);
            ManyToOne(x => x.producto);
            ManyToOne(x => x.pedido);
        }
    }
}
