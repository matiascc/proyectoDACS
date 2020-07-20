using API_Repartidor.Entities;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace API_Repartidor.Mappings
{
    public class ProductoMap : ClassMapping<Producto>
    {
        public ProductoMap()
        {
            Table("Producto");

            Id(x => x.id, m => {
                m.Generator(Generators.Increment);
                m.UnsavedValue(0);
            });

            Property(x => x.precio);  
        }
    }
}
