namespace ProyectoBD.Models
{
    public class Ventas
    {
        public class postVentaJuego
        {
            public int idUsuario { get; set;}
            public JuegoForVenta[] juegos { get; set;}
        }

        public class JuegoForVenta 
        { 
            public int IDVenta { get; set;}
        }
    }
}
