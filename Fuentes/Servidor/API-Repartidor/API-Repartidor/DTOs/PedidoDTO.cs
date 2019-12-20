using System;
using System.Collections.Generic;
using API_Repartidor.DataComponents;

namespace API_Repartidor.DTOs
{
    public class PedidoDTO
    {
        public virtual long id { get; set; }
        public virtual DateTime fechaCreacion { get; set; }

        public virtual DateTime fechaFinalizacion { get; set; }

        public virtual DateTime fechaLimite { get; set; }

        public virtual Estado entregado { get; set; }

        public virtual double precioTotal { get; set; }
        public virtual long idCliente { get; set; }

        public virtual ICollection<ItemPedidoDTO> itemPedido { get; set; }
    }
}
