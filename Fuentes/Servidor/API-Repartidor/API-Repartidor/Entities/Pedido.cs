using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Entities
{

    public class Pedido: BaseEntity
    {

        public enum Estado
        {
            Pendiente,
            EnCurso,
            Finalizado
        }


        public virtual DateTime fechaCreacion { get; set; }

        public virtual DateTime fechaFinalizacion { get; set; }

        public virtual DateTime fechaLimite { get; set; }

        public virtual Estado entregado { get; set; }

        public virtual double precioTotal { get; set; }

    }
}
