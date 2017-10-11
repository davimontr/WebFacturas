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
        Producto obtenProductoSegunIdentificador(int Id);
        void  incluirProducto(string product, int costo, int utilidad, int imp, int stock, int idProvee);
        void actualizaProducto(int Id, string product, int costo, int utilidad, int imp, int stock, int idProvee);
        void eliminarProducto(int id);
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


        // metodo agregar
        public void incluirProducto(string product, int costo, int utilidad, int imp, int stock, int idProvee)
        {
            this.contexto.Productos.Add(new Producto { Producto1 = product, Costo = costo, Utilidad = utilidad, Impuesto = imp, Existencia = stock, IdProveedor = idProvee });
            this.contexto.SaveChanges();

        }

        public Producto obtenProductoSegunIdentificador(int Id)
        {
            return this.contexto.Productos.FirstOrDefault(u => u.Id == Id);
        }

        //actualiza 
        public void actualizaProducto(int Id, string product, int costo, int utilidad, int imp, int stock, int idProvee)
        {
            Producto produc = this.obtenProductoSegunIdentificador(Id);
            produc.Producto1 = product;
            produc.Costo = costo;
            produc.Utilidad = utilidad;
            produc.Impuesto = imp;
            produc.Existencia = stock;
            produc.IdProveedor = idProvee;
            this.contexto.SaveChanges();
        }


        //metodo eliminar
        public void eliminarProducto(int id)
        {
            Producto prd = this.obtenProductoSegunIdentificador(id);
            this.contexto.Productos.Remove(prd);
            this.contexto.SaveChanges();

        }


    }
}
