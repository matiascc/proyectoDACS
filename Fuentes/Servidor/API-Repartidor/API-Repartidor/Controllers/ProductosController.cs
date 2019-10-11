using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Repartidor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly Services.ProductosService productosSrv; 

        public ProductosController(Services.ProductosService productosSrv )
        {
            this.productosSrv = productosSrv;
        }

        [HttpGet]
        public IActionResult GetProductos ()
        {
            var result = this.productosSrv.GetProductos();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductosById(int id)
        {
            var result = this.productosSrv.GetProductoByID(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}