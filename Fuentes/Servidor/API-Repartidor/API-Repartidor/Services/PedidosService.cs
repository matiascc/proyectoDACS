using API_Repartidor.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Repartidor.Services
{
    public class PedidosService
    {


        //para cada unos de los metodos falta la parte de la interaccion con la DAO correspondiente.

        public List<PedidoDTO> GetPedidos()
        {
            List<PedidoDTO> pedidosDTO = new List<PedidoDTO>();
            return pedidosDTO;
        }

        public PedidoDTO AddPedido(PedidoDTO pedido)
        {
            return pedido;
        }

        public PedidoDTO GetPedidoByID(int id)
        {
            return null;
        }

        public void DeletePedidoByID(int id)
        {

        }

        public void UpdatePedidoByID(int id)
        {

        }
    }
}
