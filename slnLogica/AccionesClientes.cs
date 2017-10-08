using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{


    public interface IserviciosClientes
{
    List<Cliente> obtenerTodos();

}

    public class AccionesClientes : IserviciosClientes 
    {
        private FacturacionEntidades contexto;
        //constructor de la clase de acciones roles
        public AccionesClientes()
        {
            this.contexto = new FacturacionEntidades();
        }

        public List<Cliente> obtenerTodos()
        {
            return this.contexto.Clientes.ToList();

        }




    }
}
