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
    public class VentasController : Controller
    {

        MySqlConnection db;
        public VentasController(MySqlConnection _db)
        {
            db = _db;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> postVentaJuego([FromBody] Ventas.postVentaJuego model)
        {

            IEnumerable<Juegos.Juego> juego = await db.QueryAsync<Juegos.Juego>("Call BibliotecaVerificarJuegoEspecifico(@idUsuario, @idJuego);", model);

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
