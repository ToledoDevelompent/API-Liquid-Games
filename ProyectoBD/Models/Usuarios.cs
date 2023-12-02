namespace ProyectoBD.Models
{
    public class Usuarios
    {
        public class Usuario
        {
            public int idUsuario { get; set; }
            public string usuario { get; set; }
            public string contrasenia { get; set; }
            public string correo { get; set; }
            public string fechaNacimiento { get; set; }
        }
        public class getUsuarioEspecifico
        {
            public int id { get; set; }
        }
        public class postVerificarUsuario
        {
            public string username { get; set; }
        }
        public class postVerificarCorreo
        {
            public string correo { get; set; }
        }
        public class postUsuario
        {
            public string usuario { get; set; }
            public string contrasenia { get; set; }
            public string correo { get; set; }
            public string fechaNacimiento { get; set; }
        }
    }
}
