using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.DTOs
{
    public class ClienteDTO
    {
        public virtual int id { get; set; }

        public virtual string nombre { get; set; }

        public virtual string direccion { get; set; }

        public virtual string email { get; set; }

        //public virtual string posicion { get; set; }

        public virtual string telefonoFijo { get; set; }

        public virtual string telefonoCelular { get; set; }

        public virtual string cuit { get; set; }

    }
}
