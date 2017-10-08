using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    public interface IserviciosProductos
    {
        List<Producto> obtenerTodos();

    }

    public class AccionesProductos : IserviciosProductos
    {
        private FacturacionEntidades contexto;
        //constructor de la clase de acciones roles
        public AccionesProductos()
        {
            this.contexto = new FacturacionEntidades();
        }

        public List<Producto> obtenerTodos()
        {
            return this.contexto.Productos.ToList();

        }
    }
}
