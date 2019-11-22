using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DTOs
{
    public class ProductoCompletoReducidoDTO
    {
        public virtual string codigoQR { get; set; }

        public virtual string nombre { get; set; }

        public virtual double precio { get; set; }
    }
}
