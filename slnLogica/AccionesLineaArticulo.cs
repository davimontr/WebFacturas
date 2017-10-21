using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;
namespace slnLogica
{

    public interface IserviciosLineaArticulo
    {
        List<LineaArticulo> obtenerTodos();
        void incluirLineaArticulo(Producto Producto, int Cantidad, int IdFactura);
        void actualizaLineaArticulos(int Id, Producto Producto, int Cantidad, int IdFactura);
        void eliminarLineaArticulo(int Id);
        List<LineaArticulo> obtenerTodosPorIdFactura(int IdFactura);
        LineaArticulo obtenerSegunProductoFactura(int IdProducto, int IdFactura);
    }

    public   class AccionesLineaArticulo : AccionesEntidades, IserviciosLineaArticulo
    {

        public List<LineaArticulo> obtenerTodos()
        {
            return this.contexto.LineaArticuloes.ToList();
        }

        protected decimal calcularPrecio(Producto Producto, int Cantidad)
        {
            decimal impuesto = 0;
            if (Producto.Gravado)
            {
                impuesto = Producto.Costo * (decimal.Parse(Producto.Impuesto.ToString()) / 100);
            }

            decimal utilidad = Producto.Costo * (decimal.Parse(Producto.Utilidad.ToString()) / 100);

            return (Producto.Costo + impuesto + utilidad) * Cantidad;
        }

        public LineaArticulo obtenerSegunProductoFactura(int IdProducto, int IdFactura)
        {
            return this.contexto.LineaArticuloes
                .Where(ln => ln.IdProducto == IdProducto && ln.IdFactura == IdFactura)
                .FirstOrDefault()
        }

        // metodo de agregar
        public void incluirLineaArticulo(Producto Producto, int Cantidad, int IdFactura)
        {

            LineaArticulo linea = this.obtenerSegunProductoFactura(Producto.Id, IdFactura);
            if (linea == null)
            {

                this.contexto.LineaArticuloes.Add(new LineaArticulo
                {
                    IdProducto = Producto.Id,
                    Cantidad = Cantidad,
                    IdFactura = IdFactura,
                    Precio = this.calcularPrecio(Producto, Cantidad)
                });
                this.contexto.SaveChanges();
            }
            else
            {
                this.actualizaLineaArticulos(linea.Id, Producto, Cantidad, IdFactura);
            }
        }

        //actualiza articulos 
        public void actualizaLineaArticulos(int Id, Producto Producto, int Cantidad, int IdFactura)
        {
            LineaArticulo linea = this.obtenLineaArticuloSegunIdentificador(Id);
            linea.IdProducto = Producto.Id;
            linea.Cantidad = Cantidad;
            linea.IdFactura = IdFactura;
            linea.Precio = this.calcularPrecio(Producto, Cantidad);
            this.contexto.SaveChanges();
        }
        
        //metodo eliminar
        public void eliminarLineaArticulo(int Id)
        {
            LineaArticulo linea = this.obtenLineaArticuloSegunIdentificador(Id);
            this.contexto.LineaArticuloes.Remove(linea);
        }

        public LineaArticulo obtenLineaArticuloSegunIdentificador(int Id)
        {
            return this.contexto.LineaArticuloes.FirstOrDefault(ln => ln.Id == Id);
        }

        public List<LineaArticulo> obtenerTodosPorIdFactura(int IdFactura)
        {
            return this.contexto.LineaArticuloes.Where(ln => ln.IdFactura == IdFactura).ToList();
        }
    }
}
