using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Exceptions
{
    public class UnauthorizedException:Exception
    {
        public UnauthorizedException():base("Usuario no autorizado")
        {

        }
    }
}
