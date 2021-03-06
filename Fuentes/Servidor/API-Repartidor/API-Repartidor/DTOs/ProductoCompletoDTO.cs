﻿using System.Collections.Generic;

namespace API_Repartidor.DTOs
{
    public class ProductoCompletoDTO
    {
        public virtual int id { get; set; }

        public virtual string codigoQR { get; set; }

        public virtual string nombre { get; set; }

        public virtual string descripcion { get; set; }

        public virtual string fabricante { get; set; }

        public virtual string imagen { get; set; }

        public virtual List<StockDTO> stock { get; set; }

        public virtual double precio { get; set; }
    }
}
