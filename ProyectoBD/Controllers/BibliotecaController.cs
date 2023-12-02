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
    public class BibliotecaController : Controller
    {
        MySqlConnection db;
        public BibliotecaController(MySqlConnection _db)
        {
            db = _db;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> postVerJuegosEnBiblioteca([FromBody] Biblioteca.postVerJuegosEnBiblioteca model)
        {
            IEnumerable<Juegos.Juego> juego = await db.QueryAsync<Juegos.Juego>("Call BibliotecaObtenerJuegos(@id);", model);
            return Ok(juego);
        }
    }
}
