using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DataComponents;

namespace API_Repartidor.DTOs.ExternalApiDTOs
{
    public class ClientDTO
    {
        public virtual int id { get; set; }

        public virtual string name { get; set; }

        public virtual string address { get; set; }

        public virtual Posicion position { get; set; }

        public virtual string email { get; set; }

        public virtual string fixed_phone { get; set; }

        public virtual string cell_phone { get; set; }

        public virtual string legal_id { get; set; }
    }
}
