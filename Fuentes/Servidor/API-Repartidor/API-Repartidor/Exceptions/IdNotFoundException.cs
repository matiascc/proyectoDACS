using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Exceptions
{
    public class IdNotFoundException: Exception
    {
        public IdNotFoundException(string entity): base("El id " + entity +  " ingresado no existe")
        {

        }
    }
}
