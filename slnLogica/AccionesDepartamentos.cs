using System;
using System.Collections.Generic;
using System.Linq;
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
                        Codigo = p.Codigo,
                        Producto = p.Nombre,
                        Departamento = d.Nombre
                    }
                    ).ToList().Cast<object>().ToList();

        }
        
        public List<object> reportDepartamento(int idDepa)
        {
            return (from ln in contexto.LineaArticuloes
                    join f in contexto.Facturas on ln.IdFactura equals f.Id
                    join p in contexto.Productos on ln.IdProducto equals p.Id
                    join d in contexto.Departamentos on p.IdDepartamento equals d.Id
                    where p.IdDepartamento == idDepa
                    group ln by d.Nombre into g
                    select new
                    {
                        Nombre = g.Key,
                        Total = g.Sum(ln => ln.Precio)
                    }).ToList().Cast<object>().ToList();
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
