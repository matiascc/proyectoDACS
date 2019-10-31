using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DataComponents;

namespace API_Repartidor.Entities
{
    public class Producto : BaseEntity
    {
        public virtual double precio { get; set; }
        //public virtual ICollection<ItemPedido> itemPedido { get; set; }

    }
}
