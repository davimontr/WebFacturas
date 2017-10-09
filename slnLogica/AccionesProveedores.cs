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
        void incluirProveedor(string nombre);
        void actualizaProveedor(int Id, string nombre);
        void eliminarProveedor(int id);
    }

    public class AccionesProveedores : IserviciosProveedores
    {
        private FacturacionEntidades contexto;
        //constructor de la clase de acciones roles
        public AccionesProveedores()
        {
            this.contexto = new FacturacionEntidades();
        }

        public List<Proveedore> obtenerTodos()
        {
            return this.contexto.Proveedores.ToList();

        }

        // se agrega el proveedor
        public void incluirProveedor(string nombre)
        {
            this.contexto.Proveedores.Add(new Proveedore { Nombre = nombre });
            this.contexto.SaveChanges();

        }

        public Proveedore obtenProveedorSegunIdentificador(int Id)
        {
            return this.contexto.Proveedores.FirstOrDefault(u => u.Id == Id);
        }

        //actualiza el proveedor
        public void actualizaProveedor(int Id, string nombre)
        {
            Proveedore proveed = this.obtenProveedorSegunIdentificador(Id);
            proveed.Nombre = nombre;
            this.contexto.SaveChanges();
        }
 

        //metodo eliminar
        public void eliminarProveedor(int id)
        {
            Proveedore usu = this.obtenProveedorSegunIdentificador(id);
            this.contexto.Proveedores.Remove(usu);

        }




    }
}
