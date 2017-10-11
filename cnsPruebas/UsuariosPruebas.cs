using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnLogica;

namespace cnsPruebas
{
    class UsuariosPruebas
    {
        private IServiciosUsuarios usuarios = new AccionesUsuarios();

        public void ejecutar()
        {
            //this.iniciarSession();
            this.ModificarUsu();
            //this.ingresarUsuario();
            //this.eliminar();
            
        }

        //public void iniciarSession()
        //{
        //    if (this.usuarios.iniciarSession("keboca@gmail.com", "clave"))
        //    {
        //        Console.WriteLine("Session iniciada!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("No se logra iniciar session.");
        //    }
        //}

        public void ModificarUsu()
        {

            this.usuarios.actualizaUsuario(1, "olgeragt@gmail.com", "12345,", 1);

            Console.WriteLine("Usuario modificado!");


        }

        //public void ingresarUsuario()
        //{
        //    this.usuarios.incluirUsuario("andres@gmail.com", "111,", 2);
        //    Console.WriteLine("Usuario agregado!");
        //}

        //public void eliminar()
        //{
        // this.usuarios.eliminarUsuario(5);
        //  Console.WriteLine("Usuario eliminado!");
        //}



    }
}
