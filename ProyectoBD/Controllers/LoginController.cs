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
    public class LoginController : Controller
    {
        MySqlConnection db;
        public LoginController(MySqlConnection _db)
        {
            db = _db;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> TryLogin([FromBody] Login.TryLogin model)
        {
            var User = await db.QueryFirstOrDefaultAsync<dynamic>("Call LoginIntentarLogin (@username, @password);", model);

            if (User != null)
            {
                return Ok(new {User.idUsuario});
            }
            else
            {
                return Unauthorized("El usuario o contraseña son incorrectos");
            }
        }
    }
}
