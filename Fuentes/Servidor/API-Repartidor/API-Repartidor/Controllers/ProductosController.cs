using Microsoft.AspNetCore.Mvc;

namespace API_Repartidor.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly Services.ProductosService productosSrv;

        public ProductosController(Services.ProductosService productosSrv)
        {
            this.productosSrv = productosSrv;
        }

        /// <summary>
        /// Trae todos los productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProductos ()
        {
            return Ok(this.productosSrv.GetProductos());
        }

        /// <summary>
        /// Trae un producto a partir de un ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductosById(int id)
        {
            return Ok(this.productosSrv.GetProductoByID(id));
        }
    }
}