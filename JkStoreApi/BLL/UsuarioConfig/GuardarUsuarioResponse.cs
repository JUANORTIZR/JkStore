using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UsuarioConfig
{
    public class GuardarUsuarioResponse
    {
        public Usuario Usuario { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public GuardarUsuarioResponse(Usuario usuario)
        {
            Error = false;
            Usuario = usuario;
        }

        public GuardarUsuarioResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
