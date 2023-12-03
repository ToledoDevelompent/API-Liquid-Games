namespace ProyectoBD.Models
{
    public class Carritos
    {
        public class postCarritoJuego
        {
            public int idUsuario { get; set; }
            public int idJuego { get; set; }
        }
        public class postVerJuegosEnCarrito
        {
            public int id{ get; set; }
        }
        public class postEliminarCarritoJuego
        {
            public int idUsuario{ get; set; }
            public int idJuego{ get; set; }
        }
        public class postVentaCarrito
        {
            public int id{ get; set; }
        }
    }
}
