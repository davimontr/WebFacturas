using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    public interface IserviciosFacturas
    {
        List<Factura> obtenerTodos();

    }

    public class AccionesFacturas : IserviciosFacturas
    {
        private FacturacionEntidades contexto;
        //constructor de la clase de acciones roles
        public AccionesFacturas()
        {
            this.contexto = new FacturacionEntidades();
        }

        public List<Factura> obtenerTodos()
        {
            return this.contexto.Facturas.ToList();

        }
    }
}
