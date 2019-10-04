using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DataComponents;

namespace API_Repartidor.Entities
{
    public class Producto : BaseEntity
    {
        public virtual int Store_number { get; set; }
        public virtual int Corridor { get; set; }
        public virtual char Side { get; set; }
        public virtual int Cabinet { get; set; }
        public virtual int Shelf { get; set; }
        public virtual Position Position { get; set; }
        public virtual string CodigoQR { get; set; }

    }
}
