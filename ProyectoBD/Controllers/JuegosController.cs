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
            
            IEnumerable<Juegos.Juego> juegosDestacados = await db.QueryAsync<Juegos.Juego>("Call JuegosObtenerJuegosDestacados();");

            return Ok(juegosDestacados);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> getGeneros()
        {
            
            IEnumerable<dynamic> generos = await db.QueryAsync<dynamic>("Call GenerosObtenerGeneros();");

            return Ok(generos);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> postBuscarJuegos([FromBody] Juegos.postBuscarJuegos model)
        {
            
            IEnumerable<Juegos.Juego> generos = await db.QueryAsync<Juegos.Juego>("Call JuegosBuscarJuegos(@slug);", model);

            return Ok(generos);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> postJuegosCategoria([FromBody] Juegos.postJuegosCategoria model)
        {
            
            IEnumerable<Juegos.Juego> juegos = await db.QueryAsync<Juegos.Juego>("Call JuegosObtenerJuesgosPorGenero(@id);", model);

            return Ok(juegos);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> postJuegoPorID([FromBody] Juegos.postJuegoPorID model)
        {
            
            IEnumerable<Juegos.Juego> juego = await db.QueryAsync<Juegos.Juego>("Call JuegosObtenerJuesgosPorGenero(@id);", model);          

            if(juego == null)
            {
                return BadRequest("No se pudo encontrar el juego");
            }
            else
            {
                return Ok(juego);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> postUsuarioTieneJuego([FromBody] Juegos.postUsuarioTieneJuego model)
        {
            
            IEnumerable<Juegos.Juego> juego = await db.QueryAsync<Juegos.Juego>("Call BibliotecaVerificarJuegoEspecifico(@idUsuario, @idJuego);", model);          

            if(juego == null)
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
