using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UsuarioConfig
{
   
    public class UsuarioService
    { 
        private readonly JkStoreContext context;
        public UsuarioService(JkStoreContext _context)
        {
            context = _context;
        }

        public GuardarUsuarioResponse Guardar(Usuario usuario)
        {
            try
            {
                Usuario usuarioEncontrado = context.Usuarios.Find(usuario.Identificacion);
                if (usuarioEncontrado != null) return new GuardarUsuarioResponse($"La identificacion ingresada ya se encuentra registrada: {usuario.Identificacion}");
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return new GuardarUsuarioResponse(usuario);
            }
            catch (Exception e)
            {
                return new GuardarUsuarioResponse(e.Message);
            }
        }

        public ConsultarUsuarioResponse Consultar() 
        {
            try
            {
                List<Usuario> usuarios = context.Usuarios.ToList();
                return new ConsultarUsuarioResponse(usuarios);
            }
            catch (Exception e)
            {
                return new ConsultarUsuarioResponse(e.Message);
            }
        }
    }
}
