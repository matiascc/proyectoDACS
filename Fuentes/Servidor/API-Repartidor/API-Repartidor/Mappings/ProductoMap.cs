using API_Repartidor.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Mappings
{
    public class ProductoMap : ClassMapping<Producto>
    {
        public ProductoMap()
        {
            Table("Producto");

            Id(x => x.Id, m => {
                m.Generator(Generators.Increment);
                m.UnsavedValue(0);
            });

            Property(x => x.store_number);
            Property(x => x.corridor);
            Property(x => x.side);
            Property(x => x.cabinet);
            Property(x => x.shelf);
            //Property(x => x.position);
            Property(x => x.codigoQR);
            Property(x => x.precio);

            Set(x => x.itemPedido,
                cm =>
                {
                    cm.Lazy(CollectionLazy.Lazy);
                },
            action => action.OneToMany());

        }
    }
}
