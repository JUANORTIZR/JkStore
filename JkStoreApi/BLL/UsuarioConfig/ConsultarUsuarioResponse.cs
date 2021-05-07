using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace BLL.UsuarioConfig
{
    public class ConsultarUsuarioResponse
    {
        public List<Usuario> Usuarios{ get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public ConsultarUsuarioResponse(List<Usuario> usuarios)
        {
            Error = false;
            Usuarios = usuarios;
        }

        public ConsultarUsuarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
