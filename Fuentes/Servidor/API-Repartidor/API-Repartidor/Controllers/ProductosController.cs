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

        [HttpGet]
        public IActionResult GetProductos ()
        {
            return Ok(this.productosSrv.GetProductos());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductosById(int id)
        {
            return Ok(this.productosSrv.GetProductoByID(id));
        }
    }
}