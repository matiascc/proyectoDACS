using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DTOs
{
    public class RepartoDTO
    {
        public virtual long id { get; set; }
        public virtual DateTime fecha { get; set; }

        public virtual bool finalizado { get; set; }

        public ICollection<PedidoDTO> pedidos { get; set; }
    }
}
