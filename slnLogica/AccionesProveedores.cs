using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    public interface IserviciosProveedores
    {
        List<Proveedore> obtenerTodos();

    }

    public class AccionesProveedores : IserviciosProveedores
    {
        private FacturacionEntidades contexto;
        //constructor de la clase de acciones roles
        public AccionesProveedores()
        {
            this.contexto = new FacturacionEntidades();
        }

        public List<Proveedore> obtenerTodos()
        {
            return this.contexto.Proveedores.ToList();

        }
    }
}
