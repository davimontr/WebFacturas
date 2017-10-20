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
        List<Proveedor> obtenerTodos();
        void incluirProveedor(string Nombre);
        void actualizaProveedor(int Id, string Nombre);
        void eliminarProveedor(int Id);
        Proveedor obtenProveedorSegunIdentificador(int Id);
    }

    public class AccionesProveedores : AccionesEntidades, IserviciosProveedores
    {

        public List<Proveedor> obtenerTodos()
        {
            return this.contexto.Proveedors.ToList();
        }

        // se agrega el proveedor
        public void incluirProveedor(string Nombre)
        {
            this.contexto.Proveedors.Add(new Proveedor {
                Nombre = Nombre
            });
            this.contexto.SaveChanges();
        }

        public Proveedor obtenProveedorSegunIdentificador(int Id)
        {
            return this.contexto.Proveedors.FirstOrDefault(p => p.Id == Id);
        }

        //actualiza el proveedor
        public void actualizaProveedor(int Id, string Nombre)
        {
            Proveedor proveed = this.obtenProveedorSegunIdentificador(Id);
            proveed.Nombre = Nombre;
            this.contexto.SaveChanges();
        }
 
        //metodo eliminar
        public void eliminarProveedor(int Id)
        {
            Proveedor proveedor = this.obtenProveedorSegunIdentificador(Id);
            this.contexto.Proveedors.Remove(proveedor);
            this.contexto.SaveChanges();
        }

    }
}
