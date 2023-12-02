using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using ProyectoBD.Models;

namespace ProyectoBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsImplementationPolicy")]
    public class UsuariosController : Controller
    {

        MySqlConnection db;
        public UsuariosController(MySqlConnection _db)
        {
            db = _db;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> postUsuario([FromBody] Usuarios.postUsuario model)
        {
            var user = await db.QueryFirstOrDefaultAsync("Call UsuariosInsertarUsuario (@usuario, @contrasenia, @fechaNacimiento, @correo);", model);

            if (user && user.idUsuario)
            {
                return Ok(new { user.idUsuario });
            }
            else
            {
                return BadRequest("No se ha podido registrar el usuario");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> postVerificarUsuario([FromBody] Usuarios.postVerificarUsuario model)
        {
            var user = await db.QueryAsync("Call UsuariosVerificarUsuario (@username);", model);
            if (user.Count() > 0)
            {
                return Ok(false);
            }
            else
            {
                return Ok(true);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> postVerificarCorreo([FromBody] Usuarios.postVerificarCorreo model)
        {
            var user = await db.QueryAsync("Call UsuariosVerificarCorreo (@correo);", model);
            if (user.Count() > 0)
            {
                return Ok(false);
            }
            else
            {
                return Ok(true);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> getUsuarioEspecifico([FromBody] Usuarios.getUsuarioEspecifico model)
        {
            var user = await db.QueryFirstOrDefaultAsync("Call UsuariosObtenerUsuario (@id);", model);
            return Ok(user);
        }

    }
}
