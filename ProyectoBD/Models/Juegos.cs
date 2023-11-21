using Microsoft.Extensions.Primitives;

namespace ProyectoBD.Models
{
    public class Juegos
    {
        public class Juego
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string ? descripcion { get; set; }
            public float? precio { get; set; }
            public float? descuento { get; set; }
            public string esbr { get; set; }
            public float calificacion { get; set; }
            public string? imagen_portada { get; set; }
            public string imagen_fondo { get; set; }
            public string fecha_lanzamiento { get; set; }
        }
        public class Genero
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string imagen { get; set; }
        }

        public class postBuscarJuegos
        {
            public string slug { get; set; }
        }
    }
}
