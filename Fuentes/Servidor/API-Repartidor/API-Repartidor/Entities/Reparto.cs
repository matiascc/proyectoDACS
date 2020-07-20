using System;
using System.Collections.Generic;

namespace API_Repartidor.Entities
{
    public class Reparto : BaseEntity
    {
        public virtual DateTime fecha { get; set; }
        public virtual bool finalizado { get; set; }
        public virtual ICollection<Pedido> pedidos { get; set; }
    }
}
