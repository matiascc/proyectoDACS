using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DTOs
{
    public class StockDTO
    {
        public virtual int id { get; set; }

        public virtual int idZona { get; set; }

        public virtual int cantidad { get; set; }

    }
}
