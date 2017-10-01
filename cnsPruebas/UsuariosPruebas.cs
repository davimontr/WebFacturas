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
        public void ejecutar()
        {
            this.iniciarSession();
        }

        public void iniciarSession()
        {
            IServiciosUsuarios usuarios = new AccionesUsuarios();
            if (usuarios.iniciarSession("keboca@gmail.com", "clave"))
            {
                Console.WriteLine("Session iniciada!");
            }
            else
            {
                Console.WriteLine("No se logra iniciar session.");
            }
            Console.ReadKey();
        }
    }
}
