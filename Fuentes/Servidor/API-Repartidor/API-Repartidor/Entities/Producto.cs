using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DataComponents;

namespace API_Repartidor.Entities
{
    public class Producto : BaseEntity
    {
        public virtual int codigo { get; set; }
        public virtual int nombre { get; set; }
        public virtual string descripcion { get; set; }
        public virtual string imagen { get; set; }
        //public virtual Position position { get; set; }
        public virtual string codigoQR { get; set; }
        public virtual double precio { get; set; }
        public virtual ICollection<ItemPedido> itemPedido { get; set; }
        public virtual ICollection<Stock> stock { get; set; }

    }
}
