using API_Repartidor.DTOs;
using API_Repartidor.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;

namespace API_Repartidor.Services
{
    public class PedidosService
    {
        private readonly PedidosDAO pedidosDAO;
        public PedidosService(PedidosDAO pedidosDAO)
        {
            this.pedidosDAO = pedidosDAO;
        }
        public List<PedidoDTO> GetPedidos()
        {
            try
            {
                List<PedidoDTO> pedidosDTO = new List<PedidoDTO>();
                
                foreach (var pedido in pedidosDAO.findAll())
                {
                    PedidoDTO pedDTO = new PedidoDTO();
                    List<ItemPedidoDTO> listItemPedidos = new List<ItemPedidoDTO>();

                    pedDTO = Mapper.Map<Entities.Pedido, PedidoDTO>(pedido);
                    foreach (var item in pedido.itemPedido)
                    {
                        ItemPedidoDTO itemPedDTO = new ItemPedidoDTO();

                        itemPedDTO = Mapper.Map<Entities.ItemPedido, ItemPedidoDTO>(item);
                        listItemPedidos.Add(itemPedDTO);
                    }
                    pedDTO.itemPedido = listItemPedidos;
                    pedidosDTO.Add(pedDTO);
                }
                return pedidosDTO;
            }
            catch (Exception e)
            {
                throw e;
            }
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
