using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;


namespace slnLogica
{

    public interface IServiciosDepartamentos
    {
        List<Departamento> obtenerDepartamento();
        void incluirDepartamento(string nombre);
        void actualizaDepartamento(int id, string nombre);
        void eliminarDepartamento(int id);
        Departamento obtenerDepartamentoSegunID(int Id);
        List<object> reportTodosDepa();
        List<object> reportDepartamento(int idDepa);
        List<object> reporteVentasDepartamentoFecha(DateTime fecha);
    }


    public class AccionesDepartamentos : AccionesEntidades, IServiciosDepartamentos
    {

        public List<Departamento> obtenerDepartamento()
        {
            return this.contexto.Departamentos.ToList();

        }


        public List<object> reportTodosDepa()
        {

            return (from d in contexto.Departamentos
                    join p in contexto.Productos on d.Id equals p.IdDepartamento
                    where p.IdDepartamento == d.Id
                    select new
                    {
                        Codigo = p.Id,
                        Producto = p.Nombre,
                        Departamento = d.Nombre
                    }
                    ).ToList().Cast<object>().ToList();

        }


        public List<object> reportDepartamento(int idDepa)
        {
            //return (from d in this.contexto.Departamentos where d.Id == 1 select d).ToList() ;

            //return (from d in this.contexto.Departamentos join
            //(from p in this.contexto.Productos );

            //    this.contexto.Departamentos where d.Id == 1 select d).ToList();

            // return   (SELECT Productos.Id AS Codigo, Productos.Nombre AS Producto, Departamentos.Nombre AS Departamento FROM Departamentos INNER JOIN Productos ON Departamentos.Id = Productos.IdDepartamento).ToList();

            //return (FROM Departamentos INNER JOIN Productos ON Departamentos.Id = Productos.IdDepartamento is this.contexto.Departamentos SELECT Productos.Id AS Codigo, Productos.Nombre AS Producto, Departamentos.Nombre AS Departamento ).ToList();


            //return (from d in contexto.Departamentos
            //        join p in contexto.Productos on d.Id equals p.IdDepartamento
            //        select new
            //        {
            //            Codigo = p.Id,
            //            Produ = p.Nombre,
            //            Depa = d.Nombre
            //        }).ToList();


            return  (from d in contexto.Departamentos
                         join p in contexto.Productos on d.Id equals p.IdDepartamento
                     where p.IdDepartamento == idDepa
                         select new
                         {
                             Codigo = p.Id,
                             Producto = p.Nombre,
                             Departamento = d.Nombre
                         }                         
                         ).ToList().Cast<object>().ToList();
        }



        // metodo de agregar

        public void incluirDepartamento(string nombre)
        {
            this.contexto.Departamentos.Add(new Departamento {Nombre = nombre});
            this.contexto.SaveChanges();

        }

        //actualiza articulos 
        public void actualizaDepartamento(int id, string nombre)
        {

            Departamento depa = this.obtenerDepartamentoSegunID(id);

            depa.Nombre = nombre;
            this.contexto.SaveChanges();
        }


        //metodo eliminar
        public void eliminarDepartamento(int id)
        {

            Departamento dep = this.obtenerDepartamentoSegunID(id);

            this.contexto.Departamentos.Remove(dep);
            this.contexto.SaveChanges();


        }



        //public Departamento obtenLineaDepartamentoSegunIdentificador(int Id)
        //{
        //    return this.contexto.Departamentos.FirstOrDefault(u => u.Id == Id);
        //}


        public Departamento obtenerDepartamentoSegunID(int Id)

        {
            return this.contexto.Departamentos.FirstOrDefault(c => c.Id == Id);
        }

        public List<object> reporteVentasDepartamentoFecha(DateTime fecha)
        {
            return (from ln in this.contexto.LineaArticuloes
                    join f in this.contexto.Facturas on ln.IdFactura equals f.Id
                    join p in this.contexto.Productos on ln.IdProducto equals p.Id
                    join d in this.contexto.Departamentos on p.IdDepartamento equals d.Id
                    where f.Fecha == fecha
                    group ln by ln.Producto.Departamento.Nombre into g
                    select new {
                        Departamento = g.Key,
                        Cantidades = g.Sum(ln => ln.Precio)
                    })
                .ToList()
                .Cast<object>()
                .ToList();
        }
    }
}
