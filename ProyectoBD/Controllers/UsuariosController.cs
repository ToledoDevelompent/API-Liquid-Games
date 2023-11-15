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
        public async Task<IActionResult> PostUsuario([FromBody] Usuarios.PostUsuario model)
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
        public async Task<IActionResult> VerificarUsuario([FromBody] Usuarios.VerificarUsuario model)
        {
            var user = await db.QueryAsync("Call UsuariosVerificarUsuario (@username);", model);

            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> VerificarCorreo([FromBody] Usuarios.VerificarUsuario model)
        {
            var user = await db.QueryAsync("Call UsuariosVerificarCorreo (@correo);", model);

            return Ok(user);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetUsuarioEspecifico([FromBody] Usuarios.GetUsuarioEspecifico model)
        {
            var user = await db.QueryFirstOrDefaultAsync("Call UsuariosObtenerUsuario (@idUsuario);", model);
            return Ok(user);
        }

    }
}
