using System;
using System.Collections.Generic;
using API_Repartidor.DTOs;
using API_Repartidor.DTOs.ExternalApiDTOs;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serialization.Json;
using API_Repartidor.DAO;
using API_Repartidor.Exceptions;

namespace API_Repartidor.Services
{
    public class ProductosService
    {
        private string baseURL = null;
        private readonly ProductosDAO productosDAO;
        public ProductosService (IConfiguration configuration, ProductosDAO productosDAO)
        {
            this.baseURL = configuration.GetValue<string>("ExternalApiURL");
            this.productosDAO = productosDAO;
        }

        /// <summary>
        /// Obtiene y mapea todos los productos recibidos de la API externa
        /// </summary>
        /// <returns></returns>
        internal List<ProductoDTO> GetProductos()
        {
            List<ProductoDTO> result = new List<ProductoDTO>();
            foreach (var producto in ApiProductsGetAll())
            {
                result.Add(Mapper.Map<ProductDTO, ProductoDTO>(producto));
            }
            return result;
        }

        /// <summary>
        /// Obtiene y mapea un producto completo determinado por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal ProductoCompletoDTO GetProductoByID(int id)
        {
            ProductDTO result = this.ApiProductsGetByID(id);
            ProductoCompletoDTO prodConPrecio = new ProductoCompletoDTO();
            prodConPrecio = Mapper.Map<ProductDTO, ProductoCompletoDTO>(result);
            var prod = productosDAO.FindByID(Convert.ToInt64(result.id));
            if (prod != null)
            {
                prodConPrecio.precio = prod.precio;
            }
            return prodConPrecio;
        }


        /// <summary>
        /// Consulta API externa y obtiene un producto determinado por la ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private ProductDTO ApiProductsGetByID( int id)
        {
            ProductDTO resultwithID = new ProductDTO();
            var client = new RestClient(baseURL);
            var request = new RestRequest("/products/{id}.json");
            request.Method = Method.GET;
            request.AddUrlSegment("id", id);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            if (response.Content != "null")
            {
                resultwithID = new JsonDeserializer().Deserialize<ProductDTO>(response);
                return resultwithID;
            }
            else
            {
                throw new IdNotFoundException("Producto");
            }
        }

        /// <summary>
        /// Obtiene todos los productos consultando la API externa.
        /// </summary>
        /// <returns></returns>
        private List<ProductDTO> ApiProductsGetAll()
        {
            List<ProductDTO> result = new List<ProductDTO>();
            var client = new RestClient(this.baseURL);
            var request = new RestRequest("/products.json");
            request.Method = Method.GET;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               result = new JsonDeserializer().Deserialize<List<ProductDTO>>(response);
               return result;
            }
            else
            {
                return null;
            }
        }
    }
}
