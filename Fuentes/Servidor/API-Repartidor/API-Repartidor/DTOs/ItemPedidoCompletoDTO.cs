using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.Entities;

namespace API_Repartidor.DTOs
{
    public class ItemPedidoCompletoDTO
    {
        public virtual long id { get; set; }
        public virtual int cantidad { get; set; }
        public virtual int cantidadRechazada { get; set; }
        public virtual double precio { get; set; }
        public virtual ProductoCompletoReducidoDTO producto { get; set; }
    }
}
