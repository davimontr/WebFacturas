using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    public interface IServiciosUsuarios
    {
        bool iniciarSession(string correo, string clave);
    }

    public class AccionesUsuarios : IServiciosUsuarios
    {
        private FacturacionEntidades contexto;
        public AccionesUsuarios()
        {
            this.contexto = new FacturacionEntidades();
        }
        //inicio de session
        public bool iniciarSession(string correo, string clave)
        {
            // Encriptar clave.
            Usuario usuario = this.contexto.Usuarios.FirstOrDefault(u => u.Email.Equals(correo));
            return (usuario != null);
        }

        // metodo para actualizar la clave de usuario 
        public void actualizaClaveUsuario(int Id, string Clave)
        {
            Usuario usuario = this.obtenUsuarioSegunIdentificador(Id);
            usuario.Clave = Clave;
            this.contexto.SaveChanges();
        }

        // metodo  para verificar correo
        public bool existeCorreo(string Correo)
        {
            return (this.contexto.Usuarios.Where(u => u.Email.Equals(Correo)).Count() == 1) ? true : false;
        }



        // se agrega el usuario
        public void incluirUsuario(string email, string contrasenna, int idrol)
        {
            this.contexto.Usuarios.Add(new Usuario { Email = email, Clave = contrasenna, IdRol = idrol });
            this.contexto.SaveChanges();
            
        }
        //se obtiene el usuario
        public Usuario obtenUsuarioSegunIdentificador(int Id)
        {
            return this.contexto.Usuarios.FirstOrDefault(u => u.Id == Id);
        }
        //actualiza clave de ususario
        public void actualizaClaveUsuario(int Id, string Clave)
        {
            Usuario usuario = this.obtenUsuarioSegunIdentificador(Id);
            usuario.Clave = Clave;
            this.contexto.SaveChanges();
        }
        //metodo para que lance un msj si el correo no exite
        public bool existeCorreo(string Correo)
        {
            return (this.contexto.Usuarios.Where(u => u.Email.Equals(Correo)).Count() == 1) ? true : false;
        }

        //metodo eliminar
        public void eliminarUsuario(int id)
        {
            Usuario usu = this.obtenUsuarioSegunIdentificador(id);
            this.contexto.Usuarios.Remove(usu);

        }





    }
}
