using System;

namespace API_Repartidor.Exceptions
{
    public class UnauthorizedException:Exception
    {
        public UnauthorizedException():base("Usuario no autorizado")
        {

        }
    }
}
