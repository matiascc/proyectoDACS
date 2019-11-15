using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.Entities;
using API_Repartidor.DataComponents;

namespace API_Repartidor.DTOs
{
    public class PedidoCompletoDTO
    {
        public virtual long id { get; set; }
        public virtual DateTime fechaCreacion { get; set; }

        public virtual DateTime fechaFinalizacion { get; set; }

        public virtual DateTime fechaLimite { get; set; }

        public virtual Estado entregado { get; set; }

        public virtual double precioTotal { get; set; }
        public virtual ClienteReducidoDTO cliente { get; set; }

        public virtual ICollection<ItemPedidoCompletoDTO> itemPedido { get; set; }
    }
}
