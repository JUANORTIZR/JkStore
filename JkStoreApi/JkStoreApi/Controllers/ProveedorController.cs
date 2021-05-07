using BLL.ProveedorConfig;
using DAL;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JkStoreApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {

        private readonly ProveedorService proveedorService;
        public ProveedorController(JkStoreContext context)
        {
            proveedorService = new ProveedorService(context);
        }
        // GET: api/<ProveedorController>
        [HttpGet]
        public ActionResult<Proveedor> Get()
        {
            var response = proveedorService.Consultar();
            if (response.Error)
            {
                ModelState.AddModelError("Consultar proveedor", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Proveedores);
        }

        // GET api/<ProveedorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProveedorController>
        [HttpPost]
        public ActionResult<Proveedor> Post([FromBody] Proveedor proveedor)
        {
            var response = proveedorService.Guardar(proveedor);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar proveedor", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Proveedor);
        }

        // PUT api/<ProveedorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProveedorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
