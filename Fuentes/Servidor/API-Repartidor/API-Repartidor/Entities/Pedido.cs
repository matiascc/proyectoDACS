using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Entities
{
    public class Pedido : BaseEntity
    {
        public virtual DateTime fechaCreación { get; set; }
        public virtual DateTime FechaFinalizacion { get; set; }
        public virtual Estado Entregado { get; set; }
        public virtual double PrecioTotal { get; set; }
        public virtual ItemPedido ItemPedido { get; set; }
    }
}
