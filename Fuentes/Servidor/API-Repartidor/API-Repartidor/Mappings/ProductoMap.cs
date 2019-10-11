﻿using API_Repartidor.Entities;
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

            Property(x => x.codigo);
            Property(x => x.nombre);
            Property(x => x.descripcion);
            Property(x => x.imagen);
            //Property(x => x.position);
            Property(x => x.codigoQR);
            Property(x => x.precio);

            Set(x => x.itemPedido,
                cm =>
                {
                    cm.Lazy(CollectionLazy.Lazy);
                },
            action => action.OneToMany());

            Set(x => x.stock,
                cm =>
                {
                    cm.Lazy(CollectionLazy.Lazy);
                },
            action => action.OneToMany());

        }
    }
}