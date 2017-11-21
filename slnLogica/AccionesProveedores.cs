using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    public interface IserviciosProveedores
    {
        List<Proveedore> obtenerTodos();
        void incluirProveedor(string Nombre);
        void actualizaProveedor(int Id, string Nombre);
        void eliminarProveedor(int Id);
        Proveedore obtenProveedorSegunIdentificador(int Id);
        List<object> reportTodosProvee();
        List<object> reportProveedores(int idProvee);

    }

    public class AccionesProveedores : AccionesEntidades, IserviciosProveedores
    {

        public List<Proveedore> obtenerTodos()
        {
            return this.contexto.Proveedores.ToList();
        }

        // se agrega el proveedor
        public void incluirProveedor(string Nombre)
        {
            this.contexto.Proveedores.Add(new Proveedore {
                Nombre = Nombre
            });
            this.contexto.SaveChanges();
        }

        public Proveedore obtenProveedorSegunIdentificador(int Id)
        {
            return this.contexto.Proveedores.FirstOrDefault(p => p.Id == Id);
        }

        //actualiza el proveedor
        public void actualizaProveedor(int Id, string Nombre)
        {
            Proveedore proveed = this.obtenProveedorSegunIdentificador(Id);
            proveed.Nombre = Nombre;
            this.contexto.SaveChanges();
        }
 
        //metodo eliminar
        public void eliminarProveedor(int Id)
        {
            Proveedore proveedor = this.obtenProveedorSegunIdentificador(Id);
            this.contexto.Proveedores.Remove(proveedor);
            this.contexto.SaveChanges();
        }

        public List<object> reportTodosProvee()
        {

            return (from d in contexto.Proveedores
                    join p in contexto.Productos on d.Id equals p.IdProveedor
                    where p.IdProveedor == d.Id
                    select new
                    {
                        Codigo = p.Codigo,
                        Producto = p.Nombre,
                        Proveedores = d.Nombre
                    }
                    ).ToList().Cast<object>().ToList();

        }

        //metodo que contiene el select para unir
        public List<object> reportProveedores(int idProvee)
        {

            return (from d in contexto.Proveedores
                    join p in contexto.Productos on d.Id equals p.IdProveedor
                    where p.IdProveedor == idProvee
                    select new
                    {
                        Codigo = p.Id,
                        Producto = p.Nombre,
                        Proveedores = d.Nombre
                    }
                         ).ToList().Cast<object>().ToList();
        }

    }
}
