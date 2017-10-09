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
        void incluirLineaArticulo(int idproducto, int cant, int idfact);
        void actualizaLineaArticulos(int Id, int idproducto, int cant, int idfact);
        void eliminarLineaArticulo(int id);


    }

    public   class AcccionesLineaArticulo:IserviciosLineaArticulo
    {

        private FacturacionEntidades contexto;
      
        public AcccionesLineaArticulo()
        {
            this.contexto = new FacturacionEntidades();
        }

        public List<LineaArticulo> obtenerTodos()
        {
            return this.contexto.LineaArticuloes.ToList();

        }

        // metodo de agregar

        public void incluirLineaArticulo(int idproducto, int cant,int idfact)
        {
            this.contexto.LineaArticuloes.Add(new LineaArticulo { IdProducto = idproducto, Cantidad = cant,IdFactura=idfact });
            this.contexto.SaveChanges();

        }

        //actualiza articulos 
        public void actualizaLineaArticulos(int Id,int idproducto, int cant, int idfact)
        {
            LineaArticulo artic = this.obtenLineaArticuloSegunIdentificador(Id);
            artic.IdProducto = idproducto;
            artic.Cantidad = cant;
            artic.IdFactura = idfact;
            this.contexto.SaveChanges();
        }


        //metodo eliminar
        public void eliminarLineaArticulo(int id)
        {
            LineaArticulo art = this.obtenLineaArticuloSegunIdentificador(id);
            this.contexto.LineaArticuloes.Remove(art);

        }

        
        public LineaArticulo obtenLineaArticuloSegunIdentificador(int Id)
        {
            return this.contexto.LineaArticuloes.FirstOrDefault(u => u.Id == Id);
        }


    }
}
