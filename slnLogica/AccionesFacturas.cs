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
        void incluirFactura(string fact, DateTime fecha, int idCliente, int descu);
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



        // metodo agregar
        public void incluirFactura(string fact, DateTime fecha, int idCliente, int descu)
        {
            this.contexto.Facturas.Add(new Factura { Factura1 = fact, Fecha = fecha, IdCliente = idCliente, Descuento = descu });
            this.contexto.SaveChanges();

        }

        public Factura obtenFacturaSegunIdentificador(int Id)
        {
            return this.contexto.Facturas.FirstOrDefault(u => u.Id == Id);
        }




        //metodo eliminar
        public void eliminarFactura(int id)
        {
            Factura fac = this.obtenFacturaSegunIdentificador(id);
            this.contexto.Facturas.Remove(fac);

        }




    }
}
