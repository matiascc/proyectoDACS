using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DTOs;
using API_Repartidor.DTOs.APIProductsDTOs;
using AutoMapper;
using RestSharp;
using RestSharp.Serialization.Json;

namespace API_Repartidor.Services
{
    public class ProductosService
    {
        private static string baseURL = "https://dacs2019-dist.firebaseio.com/products";


        public List<ProductoDTO> GetProductos()
        {
            List<ProductoDTO> result = new List<ProductoDTO>(); 
            foreach (var producto in ApiProductsGetAll())
            {
                result.Add(Mapper.Map<ProductDTO, ProductoDTO>(producto));
            }
            return result;
        }

        public ProductDTO GetProductoByID(int id)
        {
            return this.ApiProductsGetByID(id);
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
            var request = new RestRequest("/{id}.json");
            request.Method = Method.GET;
            request.AddUrlSegment("id", id);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resultwithID = new JsonDeserializer().Deserialize<ProductDTO>(response);
                return resultwithID;
            }
            else
            {
                return resultwithID;
            }
        }

        /// <summary>
        /// Obtiene todos los productos consultando la API externa.
        /// </summary>
        /// <returns></returns>
        private List<ProductDTO> ApiProductsGetAll()
        {
            List<ProductDTO> result = new List<ProductDTO>();
            var client = new RestClient("https://dacs2019-dist.firebaseio.com/products.json");
            var request = new RestRequest();
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
