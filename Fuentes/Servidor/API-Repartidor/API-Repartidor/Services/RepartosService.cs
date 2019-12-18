using API_Repartidor.DTOs;
using API_Repartidor.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using API_Repartidor.Exceptions;
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
                Longitud = 0,
                Latitud = 0
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
            //Calcula la distancia al 1er y 2di cliente
            double distanciaCli1 = CalcularDistanciaDeUbicaciones(ubicActual, cliente1.posicion);

            double distanciaCli2 = CalcularDistanciaDeUbicaciones(ubicActual, cliente2.posicion);

            if (distanciaCli1 <= distanciaCli2)
            {
                return cliente1;
            }
            else
            {
                return cliente2;
            }
        }

        //Utiliza la Fórmula de Haversine para calcular ditancia entre 2 coordenadas
        private double CalcularDistanciaDeUbicaciones(Posicion origen, Posicion destino)
        {
            var difLatitud = EnRadianes(Convert.ToSingle(destino.Latitud) - Convert.ToSingle(origen.Latitud));
            var difLongitud = EnRadianes(Convert.ToSingle(destino.Longitud) - Convert.ToSingle(origen.Longitud));

            float radioTierraKm = 6378.0F;

            var a = Math.Pow(Math.Sin(difLatitud / 2), 2) +
                      Math.Cos(EnRadianes(Convert.ToSingle(origen.Latitud))) *
                      Math.Cos(EnRadianes(Convert.ToSingle(destino.Latitud))) *
                      Math.Pow(Math.Sin(difLongitud / 2), 2);


            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));


            return radioTierraKm * c;
        }

        private float EnRadianes(float valor)
        {
            return Convert.ToSingle(Math.PI / 180) * valor;
        }

        public RepartoDTO GetRepartoByID(int id)
        {
            var reparto = this.repartosDAO.findByID(id);
            if (reparto != null)
            {
                RepartoDTO repDTO = Mapper.Map<Entities.Reparto, RepartoDTO>(reparto);
                return repDTO;
            }
            else
            {
                throw new IdNotFoundException("Reparto");
            }
            
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
