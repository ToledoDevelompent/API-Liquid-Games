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

            await db.QueryFirstOrDefaultAsync("Call VentasInsertarVentaJuego(@idUsuario, @idJuego);", model);
            return Ok();
        }
    }
}
