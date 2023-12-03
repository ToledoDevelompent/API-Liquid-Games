using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using ProyectoBD.Models;
using static ProyectoBD.Models.Usuarios;

namespace ProyectoBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsImplementationPolicy")]
    public class LoginController : Controller
    {
        MySqlConnection db;
        public LoginController(MySqlConnection _db)
        {
            db = _db;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> postTryLogin([FromBody] Login.postTryLogin model)
        {
            Usuario? User = await db.QueryFirstOrDefaultAsync<Usuarios.Usuario>("Call LoginIntentarLogin (@username, @password);", model);

            if (User != null)
            {
                return Ok(new {id = User.idUsuario});
            }
            else
            {
                return Unauthorized("El usuario o contraseña son incorrectos");
            }
        }
    }
}
