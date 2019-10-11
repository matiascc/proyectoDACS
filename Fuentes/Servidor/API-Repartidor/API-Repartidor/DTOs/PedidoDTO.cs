using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DTOs
{
    public class PedidoDTO
    {
        public enum Estado
        {
            Pendiente = 0,
            EnCurso = 1,
            Finalizado = 2
        }


        public virtual DateTime fechaCreacion { get; set; }

        public virtual DateTime fechaFinalizacion { get; set; }

        public virtual DateTime fechaLimite { get; set; }

        public virtual Estado entregado { get; set; }

        public virtual double precioTotal { get; set; }

        
    }
}
