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
        void  incluirProducto(string Nombre, int Costo, int Utilidad, int Impuesto, int Existencia, int IdProveedor);
        void actualizaProducto(int Id, string Nombre, int Costo, int Utilidad, int Impuesto, int Existencia, int IdProveedor);
        void eliminarProducto(int Id);
    }

    public class AccionesProductos : AccionesEntidades, IserviciosProductos
    {

        public List<Producto> obtenerTodos()
        {
            return this.contexto.Productos.ToList();

        }

        // metodo agregar
        public void incluirProducto(string Nombre, int Costo, int Utilidad, int Impuesto, int Existencia, int IdProveedor)
        {
            this.contexto.Productos.Add(new Producto {
                Nombre= Nombre,
                Costo = Costo,
                Utilidad = Utilidad,
                Impuesto = Impuesto,
                Existencia = Existencia,
                IdProveedor = IdProveedor
            });
            this.contexto.SaveChanges();
        }

        public Producto obtenProductoSegunIdentificador(int Id)
        {
            return this.contexto.Productos.FirstOrDefault(p => p.Id == Id);
        }

        //actualiza 
        public void actualizaProducto(int Id, string Nombre, int Costo, int Utilidad, int Impuesto, int Existencia, int IdProveedor)
        {
            Producto producto = this.obtenProductoSegunIdentificador(Id);
            producto.Nombre = Nombre;
            producto.Costo = Costo;
            producto.Utilidad = Utilidad;
            producto.Impuesto = Impuesto;
            producto.Existencia = Existencia;
            producto.IdProveedor = IdProveedor;
            this.contexto.SaveChanges();
        }


        //metodo eliminar
        public void eliminarProducto(int Id)
        {
            Producto producto = this.obtenProductoSegunIdentificador(Id);
            this.contexto.Productos.Remove(producto);
            this.contexto.SaveChanges();

        }


    }
}
