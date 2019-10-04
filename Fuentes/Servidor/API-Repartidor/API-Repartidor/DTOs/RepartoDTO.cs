using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DTOs
{
    public class RepartoDTO
    {
        public virtual DateTime fecha { get; set; }

        public virtual bool finalizado { get; set; }

        public List<PedidoDTO> pedidos { get; set; }
    }
}
