using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DataComponents;

namespace API_Repartidor.Entities
{
    public class Reparto : BaseEntity
    {
        public virtual DateTime fecha { get; set; }
        public virtual bool finalizado { get; set; }
        public virtual ICollection<Pedido> pedidos { get; set; }
    }
}
