using API_Repartidor.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace API_Repartidor.Mappings
{
    public class ItemPedidoMap : ClassMapping<ItemPedido>
    {
        public ItemPedidoMap()
        {
            Table("ItemPedido");

            Id(x => x.id, m => {
                m.Generator(Generators.Increment);
                m.UnsavedValue(0);
            });

            Property(x => x.cantidad);
            Property(x => x.cantidadRechazada);
            Property(x => x.precio);
            Property(x => x.idProducto);

            ManyToOne(x => x.pedido);
        }
    }
}
