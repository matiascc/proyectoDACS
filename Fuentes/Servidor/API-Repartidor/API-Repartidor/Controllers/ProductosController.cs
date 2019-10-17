using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Repartidor.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly Services.ProductosService productosSrv;
        private readonly NHibernate.ISession session;

        public ProductosController(Services.ProductosService productosSrv, NHibernate.ISession sess)
        {
            this.productosSrv = productosSrv;
            this.session = sess;
        }

        [HttpGet]
        public IActionResult GetProductos ()
        {
            try
            {
                return Ok(this.productosSrv.GetProductos(this.session));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductosById(int id)
        {
            try
            {
                return Ok(this.productosSrv.GetProductoByID(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}