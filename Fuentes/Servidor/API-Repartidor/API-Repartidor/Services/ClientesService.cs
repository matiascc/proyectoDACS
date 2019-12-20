using System;
using System.Collections.Generic;
using API_Repartidor.DTOs;
using API_Repartidor.DTOs.ExternalApiDTOs;
using API_Repartidor.Exceptions;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serialization.Json;

namespace API_Repartidor.Services
{
    public class ClientesService
    {
        private string baseURL;

        public ClientesService(IConfiguration configuration)
        {
            this.baseURL = configuration.GetValue<string>("externalApiURL");
        }

        /// <summary>
        /// Obtiene y mapea todos los clientes recibidos de la API externa
        /// </summary>
        /// <returns></returns>
        internal List<ClienteDTO> GetClientes()
        {
            try
            {
                List<ClienteDTO> result = new List<ClienteDTO>();
                foreach (var cliente in ApiClientsGetAll())
                {
                    result.Add(Mapper.Map<ClientDTO, ClienteDTO>(cliente));
                }
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Obtiene y mapea un cliente determinado por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal ClienteDTO GetClienteByID(int id)
        {
            ClientDTO result = this.ApiClientsGetByID(id);
            if (result != null)
            {
                return Mapper.Map<ClientDTO, ClienteDTO>(result);
            }
            else
            {
                throw new Exception();
            }
        }



        /// <summary>
        /// Obtiene todos los clientes consultando la API externa.
        /// </summary>
        /// <returns></returns>
        private List<ClientDTO> ApiClientsGetAll()
        {
            List<ClientDTO> result = new List<ClientDTO>();
            var client = new RestClient(this.baseURL);
            var request = new RestRequest("/clients.json");
            request.Method = Method.GET;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            if (response.Content != null)
            {
                result = new JsonDeserializer().Deserialize<List<ClientDTO>>(response);
                return result;
            }
            else
            {
                throw new IdNotFoundException("Cliente");
            }
        }

        /// <summary>
        /// Consulta API externa y obtiene un cliente determinado por la ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private ClientDTO ApiClientsGetByID(int id)
        {
            ClientDTO resultwithID = new ClientDTO();
            var client = new RestClient(baseURL);
            var request = new RestRequest("/clients/{id}.json");
            request.Method = Method.GET;
            request.AddUrlSegment("id", id);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            if (response.Content != "null")
            {
                resultwithID = new JsonDeserializer().Deserialize<ClientDTO>(response);
                return resultwithID;
            }
            else
            {
                throw new IdNotFoundException("Cliente");
            }
        }

    }
}
