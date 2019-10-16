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
        private PedidosDAO pedidosDAO= new PedidosDAO();
        
        public List<PedidoDTO> GetPedidos(ISession sess)
        {
            try
            {
                List<PedidoDTO> pedidosDTO = new List<PedidoDTO>();
                
                foreach (var pedido in pedidosDAO.findAll(sess))
                {
                    PedidoDTO pedDTO = new PedidoDTO();
                    pedDTO.id = pedido.Id;
                    pedDTO.fechaCreacion = pedido.fechaCreacion;
                    pedDTO.fechaFinalizacion = pedido.fechaFinalizacion;
                    pedDTO.fechaLimite = pedido.fechaLimite;
                    pedDTO.entregado = pedido.entregado;
                    pedDTO.precioTotal = pedido.precioTotal;
                    pedidosDTO.Add(Mapper.Map<PedidoDTO, PedidoDTO>(pedDTO));
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
