using API_Repartidor.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Mappings
{
    public class StockMap : ClassMapping<Stock>
    {
        public StockMap()
        {
            Table("Stock");

            Id(x => x.Id, m => 
            {
                m.Generator(Generators.Increment);
                m.UnsavedValue(0);
            });

            Property(x => x.zone_id);
            Property(x => x.quantity);

            ManyToOne(x => x.producto);

        }
    }
}
