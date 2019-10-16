using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DataComponents;

namespace API_Repartidor.DTOs
{
    public class PedidoDTO
    {
        public virtual DateTime fechaCreacion { get; set; }

        public virtual DateTime fechaFinalizacion { get; set; }

        public virtual DateTime fechaLimite { get; set; }

        public virtual Estado entregado { get; set; }

        public virtual double precioTotal { get; set; }

        
    }
}
