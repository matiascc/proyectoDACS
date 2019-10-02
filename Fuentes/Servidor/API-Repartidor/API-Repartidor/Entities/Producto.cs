using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Entities
{
    public class Producto: BaseEntity
    {
        public virtual int store_number { get; set; }

        public virtual int corridor { get; set; }

        public virtual char side { get; set; }

        public virtual int cabinet { get; set; }

        public virtual int shelf { get; set; }

        public virtual Position position { get; set; }

        public virtual string codigoQR { get; set; }

        public virtual double precio { get; set; }

    }
}
