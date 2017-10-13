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
        bool iniciarSession(string correo, string clave,out Usuario usuariOutput);
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
        public bool iniciarSession( string correo, string clave, out Usuario  usuariOutput)
        { 

            string encriptada = this.encriptarClaveUsuario(clave);
            Usuario usuario = this.contexto.Usuarios.FirstOrDefault(u => u.Email.Equals( correo )&&(u.Clave.Equals(encriptada)));
            usuariOutput = usuario;
            return (usuario != null);
           
        }


        // Metodo de encriptar la clave
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


        public List<Usuario> obtenerTodos()
        {
            return this.contexto.Usuarios.ToList();

        }


        // se agrega el usuario
        public void incluirUsuario( string email,  string contrasenna,  int idrol)
        {
             string clave = this.encriptarClaveUsuario(contrasenna);
            this.contexto.Usuarios.Add(new Usuario { Email = email, Clave = clave, IdRol = idrol });
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
            string clave = this.encriptarClaveUsuario(contrasena);
            Usuario usu = this.obtenUsuarioSegunIdentificador(Id);
            usu.Email = correo;
            usu.Clave = clave;
            usu.IdRol = rol;
            this.contexto.SaveChanges();
        }


    }
}
