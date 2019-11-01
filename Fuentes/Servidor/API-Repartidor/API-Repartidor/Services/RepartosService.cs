﻿using API_Repartidor.DTOs;
using API_Repartidor.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using API_Repartidor.DataComponents;

namespace API_Repartidor.Services
{
    public class RepartosService
    {
        private readonly RepartosDAO repartosDAO;
        private readonly ClientesService clientesService;
        public RepartosService(RepartosDAO repartosDAO, ClientesService clientesService)
        {
            this.repartosDAO = repartosDAO;
            this.clientesService = clientesService;
        }

        public List<RepartoDTO> GetRepartos()
        {
            List<RepartoDTO> repartosDTO = new List<RepartoDTO>();

            foreach (var reparto in repartosDAO.findAll())
            {
                RepartoDTO repDTO = new RepartoDTO();

                repDTO = Mapper.Map<Entities.Reparto, RepartoDTO>(reparto);
                repartosDTO.Add(repDTO);
            }
            return repartosDTO;
        }

        public List<PedidoDTO> GetPedidosOfReparto(int id)
        {
            RepartoDTO repDTO = this.GetRepartoByID(id);
            List<PedidoDTO> pedidosDTO = new List<PedidoDTO>();
            foreach (var pedido in repDTO.pedidos)
            {
                pedidosDTO.Add(pedido);
            }
            return pedidosDTO;
        }

        public RepartoDTO AddReparto(RepartoDTO reparto)
        {
            //Cambiar la ubicacion por la que viene del dispositivo!!!
            Posicion ubicacionActual = new Posicion
            {
                Longitude = 0,
                Latitude = 0
            };

            reparto.pedidos = OrdenarPedidos(ubicacionActual, reparto.pedidos.ToList());

            Entities.Reparto repartoEntity = Mapper.Map<RepartoDTO, Entities.Reparto>(reparto);
            this.repartosDAO.save(repartoEntity);
            return reparto;
        }

        private List<PedidoDTO> OrdenarPedidos(Posicion ubicActual, List<PedidoDTO> pedidosSinOrdenar)
        {
            List<PedidoDTO> listaPedidosOrdenada = new List<PedidoDTO>();
            List<ClienteDTO> clientesSinAsignar = new List<ClienteDTO>();
            
            //Obtiene todos los clientes de los pedidos
            foreach (var pedido in pedidosSinOrdenar)
            {
                clientesSinAsignar.Add(this.clientesService.GetClienteByID(Convert.ToInt32(pedido.idCliente)));
            }
            
            while (clientesSinAsignar.Count > 0)
            {
                ClienteDTO clienteMinimo = clientesSinAsignar[0];

                //Recorre todos los clientes para averiguar el minimo
                foreach (var cliente in clientesSinAsignar)
                {
                    clienteMinimo = ClienteMenorDistancia(ubicActual, clienteMinimo, cliente);
                }

                //Cambia la ubicacion actual a la posicion del ultimo cliente hasta el momento
                ubicActual = clienteMinimo.posicion;

                //Agrega el pedido a la lista final, borra ese pedido de los sin asignar y el cliente asociado de los clientes sin asignar
                listaPedidosOrdenada.Add(pedidosSinOrdenar[clientesSinAsignar.IndexOf(clienteMinimo)]);
                pedidosSinOrdenar.Remove(pedidosSinOrdenar[clientesSinAsignar.IndexOf(clienteMinimo)]);
                clientesSinAsignar.Remove(clienteMinimo);
            }
            return listaPedidosOrdenada;
        }

        private ClienteDTO ClienteMenorDistancia(Posicion ubicActual, ClienteDTO cliente1, ClienteDTO cliente2)
        {
            //Calcula la distancia al 1er y 2di cliente con pitágoras
            double distanciaCli1 = Math.Sqrt( Math.Pow(Decimal.ToDouble(Math.Abs(ubicActual.Latitude - cliente1.posicion.Latitude)),2) +
                                    Math.Pow(Decimal.ToDouble(Math.Abs(ubicActual.Longitude - cliente1.posicion.Longitude)), 2));

            double distanciaCli2 = Math.Sqrt(Math.Pow(Decimal.ToDouble(Math.Abs(ubicActual.Latitude - cliente2.posicion.Latitude)), 2) +
                                    Math.Pow(Decimal.ToDouble(Math.Abs(ubicActual.Longitude - cliente2.posicion.Longitude)), 2));

            if (distanciaCli1 <= distanciaCli2)
            {
                return cliente1;
            }
            else
            {
                return cliente2;
            }
        }

        public RepartoDTO GetRepartoByID(int id)
        {
            RepartoDTO repDTO = Mapper.Map<Entities.Reparto, RepartoDTO>(this.repartosDAO.findByID(id));
            return repDTO;
        }

        public void DeleteRepartoByID(int id)
        {
            this.repartosDAO.delete(this.repartosDAO.findByID(id));
        }

        public void UpdateRepartoByID(RepartoDTO reparto)
        {
            Entities.Reparto repartoEntity = Mapper.Map<RepartoDTO, Entities.Reparto>(reparto);
            this.repartosDAO.update(repartoEntity);
        }
    }
}
