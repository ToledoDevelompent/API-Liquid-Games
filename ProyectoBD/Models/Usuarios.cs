namespace ProyectoBD.Models
{
    public class Usuarios
    {
        public class GetUsuarioEspecifico
        {
            public int idUsuario { get; set; }
        }
        public class VerificarUsuario
        {
            public string username { get; set; }
        }
        public class VerificarCorreo
        {
            public string correo { get; set; }
        }
        public class PostUsuario
        {
            public string usuario { get; set; }
            public string contrasenia { get; set; }
            public string correo { get; set; }
            public string fechaNacimiento { get; set; }
        }
    }
}
