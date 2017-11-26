using System.Collections.Generic;
using System.Linq;
using slnDatos;

namespace slnLogica
{
    public interface IserviciosProductos
    {
        List<Producto> obtenerTodos();
        Producto obtenProductoSegunIdentificador(int Id);
        void  incluirProducto(int Codigo, string Nombre, int Costo, int Utilidad, int Impuesto, int Existencia, int IdProveedor, int IdDepartamento, bool Gravado);
        void actualizaProducto(int Id, int Codigo, string Nombre, int Costo, int Utilidad, int Impuesto, int Existencia, int IdProveedor, int IdDepartamento, bool Gravado);
        void eliminarProducto(int Id);
    }

    public class AccionesProductos : AccionesEntidades, IserviciosProductos
    {
        public List<Producto> obtenerTodos()
        {
            return this.contexto.Productos.ToList();
        }

        // metodo agregar
        public void incluirProducto(int Codigo, string Nombre, int Costo, int Utilidad, int Impuesto, int Existencia, int IdProveedor, int IdDepartamento, bool Gravado)
        {
            this.contexto.Productos.Add(new Producto {
                Codigo = Codigo,
                Nombre = Nombre,
                Costo = Costo,
                Utilidad = Utilidad,
                Impuesto = Impuesto,
                Existencia = Existencia,
                IdProveedor = IdProveedor,
                IdDepartamento = IdDepartamento,
                Gravado = Gravado
                
                
                
            });
            this.contexto.SaveChanges();
        }

        public Producto obtenProductoSegunIdentificador(int Id)
        {
            return this.contexto.Productos.FirstOrDefault(p => p.Id == Id);
        }

        //actualiza 
        public void actualizaProducto(int Id, int Codigo, string Nombre, int Costo, int Utilidad, int Impuesto, int Existencia, int IdProveedor, int IdDepartamento, bool Gravado)
        {
            Producto producto = this.obtenProductoSegunIdentificador(Id);
            producto.Codigo = Codigo;
            producto.Nombre = Nombre;
            producto.Costo = Costo;
            producto.Utilidad = Utilidad;
            producto.Impuesto = Impuesto;
            producto.Existencia = Existencia;
            producto.IdProveedor = IdProveedor;
            producto.IdDepartamento = IdDepartamento;
            producto.Gravado = Gravado;
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
