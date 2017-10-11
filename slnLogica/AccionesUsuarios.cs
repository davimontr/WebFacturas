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

        List<Usuario> obtenerTodos();
        bool iniciarSession(string correo, string clave);
        void actualizaClaveUsuario(int Id, string Clave);
        void actualizarCorreo(int Id, string correo);
        bool existeCorreo(string Correo);
        string encriptarClaveUsuario(string clave);
        void incluirUsuario(string email, string contrasenna, int idrol);
        void eliminarUsuario(int id);
        void actualizaUsuario(int Id, string correo, string contrasena, int rol);
        Usuario obtenUsuarioSegunIdentificador(int Id);
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
            string encriptada = this.encriptarClaveUsuario(clave);
            Usuario usuario = this.contexto.Usuarios.FirstOrDefault(u => u.Email.Equals(correo )&&(u.Clave.Equals(clave)));
            return (usuario != null);

        }


      public  string encriptarClaveUsuario(string clave)
        {
  
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] datos = md5.ComputeHash(Encoding.Default.GetBytes(clave));
            StringBuilder strConstructor = new StringBuilder();
            for (int i = 0; i < datos.Length; i++)
            {
                strConstructor.Append(datos[i].ToString("x2"));
            }
            return strConstructor.ToString();
        }




        // metodo para actualizar la clave de usuario 
        public void actualizaClaveUsuario(int Id, string Clave)
        {

            Usuario usuario = this.obtenUsuarioSegunIdentificador(Id);
            string encriptada = this.encriptarClaveUsuario(Clave);
            usuario.Clave = Clave;
            this.encriptarClaveUsuario(Clave);
            this.contexto.SaveChanges();
        }

      public  void actualizarCorreo(int Id, string correo)
        {
        
            Usuario usuario = this.obtenUsuarioSegunIdentificador(Id);
            usuario.Email = correo;
            this.contexto.SaveChanges();
        }

        // metodo  para verificar correo
        public bool existeCorreo(string Correo)
        {
            return (this.contexto.Usuarios.Where(u => u.Email.Equals(Correo)).Count() == 1) ? true : false;
        }


        public List<Usuario> obtenerTodos()
        {
            return this.contexto.Usuarios.ToList();

        }


        // se agrega el usuario
        public void incluirUsuario(string email, string contrasenna, int idrol)
        {
             string clave = this.encriptarClaveUsuario(contrasenna);
            this.contexto.Usuarios.Add(new Usuario { Email = email, Clave = contrasenna, IdRol = idrol });
            clave = this.encriptarClaveUsuario(contrasenna);
            this.contexto.SaveChanges();
            
        }
        //se obtiene el usuario
        public Usuario obtenUsuarioSegunIdentificador(int Id)
        {
            return this.contexto.Usuarios.FirstOrDefault(u => u.Id == Id);
        }
        
        //metodo de eliminar 
        public void eliminarUsuario(int id)
        {
            Usuario usu = this.obtenUsuarioSegunIdentificador(id);
            this.contexto.Usuarios.Remove(usu);
            this.contexto.SaveChanges();

        }

        //metodo de modificar

        public void actualizaUsuario(int Id, string correo, string contrasena,int rol)
        {
            Usuario usu = this.obtenUsuarioSegunIdentificador(Id);
            usu.Email = correo;
            usu.Clave = contrasena;
            usu.IdRol = rol;
            this.contexto.SaveChanges();
        }


    }
}
