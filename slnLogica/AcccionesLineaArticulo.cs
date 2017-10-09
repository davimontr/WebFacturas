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
        List<Articulo> obtenerTodos();

    }

    public   class AcccionesLineaArticulo:IserviciosLineaArticulo
    {

        private FacturacionEntidades contexto;
      
        public AcccionesLineaArticulo()
        {
            this.contexto = new FacturacionEntidades();
        }

        public List<Articulo> obtenerTodos()
        {
            return this.contexto.Articulos.ToList();

        }

        // metodo de agregar

        public void incluirLineaArticulo(int idproducto, int cant,int idfact)
        {
            this.contexto.Articulos.Add(new Articulo { IdProducto = idproducto, Cantidad = cant,IdFactura=idfact });
            this.contexto.SaveChanges();

        }

        //actualiza articulos 
        public void actualizaLineaArticulos(int Id,int idproducto, int cant, int idfact)
        {
            Articulo artic = this.obtenLineaArticuloSegunIdentificador(Id);
            artic.IdProducto = idproducto;
            artic.Cantidad = cant;
            artic.IdFactura = idfact;
            this.contexto.SaveChanges();
        }


        //metodo eliminar
        public void eliminarLineaArticulo(int id)
        {
            Articulo art = this.obtenLineaArticuloSegunIdentificador(id);
            this.contexto.Articulos.Remove(art);

        }

        
        public Articulo obtenLineaArticuloSegunIdentificador(int Id)
        {
            return this.contexto.Articulos.FirstOrDefault(u => u.Id == Id);
        }


    }
}
