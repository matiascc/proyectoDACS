using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Entities
{
    public class ItemPedido : BaseEntity
    {
        public virtual int cantidad { get; set; }
        public virtual int cantidadRechazada { get; set; }
        public virtual Producto producto { get; set; }
        public virtual Pedido pedido { get; set; }
    }
}
