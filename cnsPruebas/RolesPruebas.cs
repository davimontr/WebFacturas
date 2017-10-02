using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnLogica;
using slnDatos;

namespace cnsPruebas
{
    class RolesPruebas
    {
        private IServiciosRoles roles = new AccionesRoles();


        public void ejecutar()
        {
            this.obtenerTodos();
        }

        public void obtenerTodos()
        {
            var lista = this.roles.obtenerTodos();

            foreach (Role rol in lista)
            {
                Console.WriteLine(rol.Nombre);


            }

        }


    }
}
