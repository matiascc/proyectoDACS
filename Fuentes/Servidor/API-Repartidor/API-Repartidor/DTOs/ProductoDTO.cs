using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DTOs
{
    public class ProductoDTO
    {
        public virtual int id { get; set; }

        public virtual string codigoQR { get; set; }

        public virtual string nombre { get; set; }

        public virtual string descripcion { get; set; }

        public virtual string fabricante { get; set; }

        //public virtual int id { get; set; }

        public virtual List<StockDTO> stock { get; set; }
    }
}
