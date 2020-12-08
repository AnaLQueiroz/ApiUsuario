using System.Collections.Generic;
using ApiUsuarios.Models;
using ApiUsuarios.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuariosController(IUsuarioRepositorio usuarioRepo)
        {
            _usuarioRepositorio = usuarioRepo;
        }


        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepositorio.GetAll();
        }


        [HttpGet("{id}",Name="GetUsuario")]
        public IActionResult GetById(long id)
        {
            var usuario = _usuarioRepositorio.Find(id);
            if(usuario==null)
                return NotFound();

            return new ObjectResult(usuario);
        }

        [HttpPost]

        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            else {
                _usuarioRepositorio.Add(usuario);
                return CreatedAtRoute("GetUsuario", new {id=usuario.UsuarioId},usuario);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id,[FromBody] Usuario usuario)
        {
              if (usuario == null || usuario.UsuarioId != id)
                  return BadRequest();


              var usuarioLocalizado = _usuarioRepositorio.Find(id);
                if(usuarioLocalizado==null)
                   return NotFound();

              usuarioLocalizado.Email=usuario.Email;
              usuarioLocalizado.Nome=usuario.Nome;
              usuarioLocalizado.Cel=usuario.Cel;

              _usuarioRepositorio.Update(usuarioLocalizado);
                return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
           var usuarioLocalizado = _usuarioRepositorio.Find(id);
                if(usuarioLocalizado==null)
                   return NotFound();

                _usuarioRepositorio.Remove(id);
                return new NoContentResult();
        }


    }
}