using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinControl.Services;
using FinControl.Models;

namespace FinControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
       
            private readonly UsuariosService _usuarioService;

            public UsuariosController(UsuariosService usuarioService)
            {
                _usuarioService = usuarioService;
            }

           [HttpGet("{id:length(24)}", Name = "GetBook")]
            public ActionResult<Usuarios> Get(string id)
            {
                var usuario = _usuarioService.Get(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                return usuario;
            }

            [HttpPost]
            public ActionResult<Usuarios> Create(Usuarios user)
            {
                _usuarioService.Create(user);

                return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
            }

            [HttpPut("{id:length(24)}")]
            public IActionResult Update(string id, Usuarios userIn)
            {
                var user = _usuarioService.Get(id);

                if (user == null)
                {
                    return NotFound();
                }

                _usuarioService.Update(id, userIn);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public IActionResult Delete(string id)
            {
                var user = _usuarioService.Get(id);

                if (user == null)
                {
                    return NotFound();
                }

                _usuarioService.Remove(user.Id);

                return NoContent();
            }
        }
    }

