using System;
using System.Collections.Generic;
using API_Repartidor.DataComponents;

namespace API_Repartidor.Entities
{
    public class Pedido : BaseEntity
    {
        public virtual DateTime fechaCreacion { get; set; }
        public virtual DateTime fechaFinalizacion { get; set; }
        public virtual DateTime fechaLimite { get; set; }
        public virtual double precioTotal { get; set; }
        public virtual Estado entregado { get; set; }
        public virtual ICollection<ItemPedido> itemPedido { get; set; }
        public virtual long idCliente { get; set; }
        public virtual Reparto reparto { get; set; }
    }
}
