using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Entities
{
    public abstract class BaseEntity
    {
        public virtual long id { get; protected set; }
    }
}
