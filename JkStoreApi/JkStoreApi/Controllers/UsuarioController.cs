using BLL.UsuarioConfig;
using DAL;
using Entity;
using JkStoreApi.Models.UsuarioModels;
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
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService usuarioService;
        public UsuarioController(JkStoreContext context)
        {
            usuarioService = new UsuarioService(context);
        }
        // GET: api/<UsuarioController>
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            var response = usuarioService.Consultar();
            if (response.Error)
            {
                ModelState.AddModelError("Consultar usuario", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Usuarios);
        }

        // GET api/<UsuarioController>/5
        //Corregir estooooo"""""""
        [HttpPost("Login")]
        public ActionResult<Usuario> Get(UsuarioInputModel usuarioInput)
        {
            Usuario usuario = Mapear(usuarioInput);
            var response = usuarioService.BuscarUsuario(usuario);
            if (response.Error)
            {
                ModelState.AddModelError("Inicio sesion", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Usuario);
        }
        private Usuario Mapear(UsuarioInputModel usuarioInput)
        {
            var usuario = new Usuario
            {
                NombreDeUsuario = usuarioInput.NombreDeUsuario,
                Clave = usuarioInput.Clave
            };
            return usuario;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario usuario)
        {
            var response = usuarioService.Guardar(usuario);
            if (response.Error)
            {
                ModelState.AddModelError("Guardar usuario", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
