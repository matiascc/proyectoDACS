using System;

namespace API_Repartidor.Exceptions
{
    public class IdNotFoundException: Exception
    {
        public IdNotFoundException(string entity): base("El id " + entity +  " ingresado no existe")
        {

        }
    }
}
