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
        Factura obtenFacturaSegunIdentificador(int Id);
        void actualizaFactura(int Id, string factura, DateTime fecha, int idcliente, int desc);
        void eliminarFactura(int id);

    }

    public class AccionesFacturas : AccionesEntidades, IserviciosFacturas
    {

        public List<Factura> obtenerTodos()
        {
            return this.contexto.Facturas.ToList();

        }



        // metodo agregar
        public void incluirFactura(string fact, DateTime fecha, int idCliente, int descu)
        {
            this.contexto.Facturas.Add(new Factura { Factura1 = fact, Fecha = fecha, IdCliente = idCliente });
            this.contexto.SaveChanges();

        }

        public Factura obtenFacturaSegunIdentificador(int Id)
        {
            return this.contexto.Facturas.FirstOrDefault(u => u.Id == Id);
        }

        // Metodo de modifcar factura

        public void actualizaFactura(int Id, string factura, DateTime fecha, int idcliente, int desc)
        {
            Factura fact = this.obtenFacturaSegunIdentificador(Id);
            fact.Factura1 = factura;
            fact.Fecha = fecha;
            fact.IdCliente = idcliente;
            this.contexto.SaveChanges();
        }

        //metodo eliminar
        public void eliminarFactura(int id)
        {
            Factura fac = this.obtenFacturaSegunIdentificador(id);
            this.contexto.Facturas.Remove(fac);
            this.contexto.SaveChanges();

        }




    }
}
