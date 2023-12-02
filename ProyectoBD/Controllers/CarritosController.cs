using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ProyectoBD.Models;

namespace ProyectoBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsImplementationPolicy")]
    public class CarritosController : Controller
    {
        MySqlConnection db;
        public CarritosController(MySqlConnection _db)
        {
            db = _db;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> postCarritoJuego([FromBody] Carritos.postCarritoJuego model)
        {

            var juego = await db.QueryFirstAsync("Call CarritosInsertarJuego(@idUsuario, @idJuego);", model);
            return Ok(true);

            if (juego == null)
            {
                return Ok(false);
            }
            else
            {
                return Ok(true);
            }
        }
    }
}
