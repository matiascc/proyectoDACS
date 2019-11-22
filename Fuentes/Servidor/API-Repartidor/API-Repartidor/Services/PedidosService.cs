using API_Repartidor.DTOs;
using API_Repartidor.DAO;
using System;
using System.Collections.Generic;
using AutoMapper;
using API_Repartidor.Exceptions;

namespace API_Repartidor.Services
{
    public class PedidosService
    {
        private readonly PedidosDAO pedidosDAO;
        private readonly ItemPedidosDAO itemPedidosDAO;
        private readonly ClientesService clientesService;
        private readonly ProductosService productosService;
        public PedidosService(PedidosDAO pedidosDAO, ItemPedidosDAO itemPedidosDAO, ClientesService clientesService, ProductosService productosService)
        {
            this.pedidosDAO = pedidosDAO;
            this.itemPedidosDAO = itemPedidosDAO;
            this.clientesService = clientesService;
            this.productosService = productosService;
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
                        ItemPedidoDTO itemPedDTO = Mapper.Map<Entities.ItemPedido, ItemPedidoDTO>(item);
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

        public List<PedidoCompletoDTO> GetPedidosCompletos()
        {
            try
            {
                List<PedidoCompletoDTO> pedidosDTO = new List<PedidoCompletoDTO>();

                foreach (var pedido in pedidosDAO.findAllPending())
                {
                    PedidoCompletoDTO pedDTO = new PedidoCompletoDTO();
                    pedDTO = Mapper.Map<Entities.Pedido, PedidoCompletoDTO>(pedido);

                    var cli = clientesService.GetClienteByID(Convert.ToInt32(pedido.idCliente));
                    pedDTO.cliente = Mapper.Map<ClienteDTO, ClienteReducidoDTO>(cli);

                    List<ItemPedidoCompletoDTO> listItemPedidos = new List<ItemPedidoCompletoDTO>();

                    foreach (var item in pedido.itemPedido)
                    {
                        ItemPedidoCompletoDTO itemPedDTO = Mapper.Map<Entities.ItemPedido, ItemPedidoCompletoDTO>(item);
                        var prod = productosService.GetProductoByID(Convert.ToInt32(item.idProducto));
                        itemPedDTO.producto = Mapper.Map<ProductoCompletoDTO, ProductoCompletoReducidoDTO>(prod);
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
            Entities.Pedido pedidoEntity = Mapper.Map<PedidoDTO, Entities.Pedido>(pedido);
            this.pedidosDAO.save(pedidoEntity);
            return pedido;
        }

        public PedidoDTO GetPedidoByID(int id)
        {
            var pedido = this.pedidosDAO.findByID(id);
            if(pedido != null)
            { 
            PedidoDTO pedDTO = Mapper.Map<Entities.Pedido, PedidoDTO>(pedido);
            return pedDTO;
            }
            else
            {
                throw new IdNotFoundException("Pedido");
            }
        }

        public void DeletePedidoByID(int id)
        {
            this.pedidosDAO.delete(this.pedidosDAO.findByID(id));
        }

        public void UpdatePedidoByID(PedidoDTO pedido)
        {
            Entities.Pedido pedidoEntity = Mapper.Map<PedidoDTO, Entities.Pedido>(pedido);
            this.pedidosDAO.update(pedidoEntity);
        }
    }
}
