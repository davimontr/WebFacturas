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
        void actualizaLineaArticulos(int Id, int IdProducto, int Cantidad, int IdFactura);
        void eliminarLineaArticulo(int Id);
        List<LineaArticulo> obtenerTodosPorIdFactura(int IdFactura);
    }

    public   class AccionesLineaArticulo : AccionesEntidades, IserviciosLineaArticulo
    {

        public List<LineaArticulo> obtenerTodos()
        {
            return this.contexto.LineaArticuloes.ToList();
        }

        // metodo de agregar
        public void incluirLineaArticulo(Producto Producto, int Cantidad, int IdFactura)
        {
            decimal impuesto = 0;
            if (Producto.Gravado)
            {
                impuesto = Producto.Costo * (Producto.Impuesto / 100);
            }
            decimal utilidad = Producto.Costo * (Producto.Utilidad / 100);

            this.contexto.LineaArticuloes.Add(new LineaArticulo
            {
                IdProducto = Producto.Id,
                Cantidad = Cantidad,
                IdFactura = IdFactura,
                Precio = (Producto.Costo + impuesto + utilidad) * Cantidad
            });
            this.contexto.SaveChanges();
        }

        //actualiza articulos 
        public void actualizaLineaArticulos(int Id,int IdProducto, int Cantidad, int IdFactura)
        {
            LineaArticulo linea = this.obtenLineaArticuloSegunIdentificador(Id);
            linea.IdProducto = IdProducto;
            linea.Cantidad = Cantidad;
            linea.IdFactura = IdFactura;
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
