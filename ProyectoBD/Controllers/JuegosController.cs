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

    public class JuegosController : Controller
    {
        MySqlConnection db;
        public JuegosController(MySqlConnection _db)
        {
            db = _db;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> getJuegosDestacados()
        {
            
            IEnumerable<Juegos.Juego> juegosDestacados = await db.QueryAsync<Juegos.Juego>("Call JuegosObtenerJuegosDestacados;");

            return Ok(juegosDestacados);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> getGeneros()
        {
            
            IEnumerable<Juegos.Genero> generos = await db.QueryAsync<Juegos.Genero>("Call GenerosObtenerGeneros;");

            return Ok(generos);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> postBuscarJuegos([FromBody] Juegos.postBuscarJuegos model)
        {
            
            IEnumerable<Juegos.Juego> generos = await db.QueryAsync<Juegos.Juego>("Call JuegosBuscarJuegos(@slug);", model);

            return Ok(generos);
        }
    }
}
