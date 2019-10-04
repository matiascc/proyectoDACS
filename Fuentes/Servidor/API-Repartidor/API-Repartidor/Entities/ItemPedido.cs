using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Entities
{
    public class ItemPedido : BaseEntity
    {
        public virtual int Cantidad { get; set; }
        public virtual int CantidadRechazada { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
