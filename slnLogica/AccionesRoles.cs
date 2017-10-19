using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    //se definen los metodos
    public interface IServiciosRoles
    {
        //definimos el metodo
        List<Role> obtenerTodos();
    }


    public class AccionesRoles : AccionesEntidades, IServiciosRoles
    {

        //se hacen los metodos
        public List<Role> obtenerTodos()
        {
            return this.contexto.Roles.ToList();

        }
    }
}
