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
            this.iniciarSession();
        }

        public void iniciarSession()
        {
            if (this.usuarios.iniciarSession("keboca@gmail.com", "clave"))
            {
                Console.WriteLine("Session iniciada!");
            }
            else
            {
                Console.WriteLine("No se logra iniciar session.");
            }
        }


    }
}
