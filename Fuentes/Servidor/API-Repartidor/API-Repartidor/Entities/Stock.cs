using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Entities
{
    public class Stock : BaseEntity
    {
        public virtual int zone_id { get; set; }
        public virtual int quantity { get; set; }
        public virtual Producto producto { get; set; }
    }
}
