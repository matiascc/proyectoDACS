using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Repartidor.DTOs;
using API_Repartidor.DTOs.ExternalApiDTOs;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Serialization.Json;
using NHibernate;
using API_Repartidor.DAO;

namespace API_Repartidor.Services
{
    public class ProductosService
    {
        private string baseURL = null;
        private ProductosDAO productosDAO = new ProductosDAO();
        public ProductosService (IConfiguration configuration)
        {
            this.baseURL = configuration.GetValue<string>("ExternalApiURL");
        }

        /// <summary>
        /// Obtiene y mapea todos los productos recibidos de la API externa
        /// </summary>
        /// <returns></returns>
        public List<ProductoDTO> GetProductos(ISession sess)
        {
            try
            {
                List<ProductoDTO> result = new List<ProductoDTO>();
                ProductoDTO prodConPrecio = new ProductoDTO();
                foreach (var producto in ApiProductsGetAll())
                {
                    prodConPrecio = Mapper.Map<ProductDTO, ProductoDTO>(producto);
                    var prod = productosDAO.findByID(Convert.ToInt64(producto.id), sess);
                    if (prod != null)
                    {
                        prodConPrecio.precio = prod.precio;
                    }
                    result.Add(prodConPrecio);
                }
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Obtiene y mapea un producto completo determinado por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductoCompletoDTO GetProductoByID(int id)
        {
            ProductDTO result = this.ApiProductsGetByID(id);
            if (result != null)
            {
                return Mapper.Map<ProductDTO, ProductoCompletoDTO>(result);
            }
            else
            {
                throw new Exception();
            }
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
