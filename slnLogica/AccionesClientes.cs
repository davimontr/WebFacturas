using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{


    public interface IserviciosClientes
{
    List<Cliente> obtenerTodos();
    void eliminarCliente(int id);
    Cliente obtenClienteSegunIdentificador(int Id);
    void actualizaCliente(int Id, string cedula, string nombreCompleto);
    void incluirCliente(string cedula, string nombreCompleto);
}

    public class AccionesClientes : IserviciosClientes 
    {
        private FacturacionEntidades contexto;
        //constructor de la clase de acciones roles
        public AccionesClientes()
        {
            this.contexto = new FacturacionEntidades();
        }

        public List<Cliente> obtenerTodos()
        {
            return this.contexto.Clientes.ToList();

        }

        // metodo de agregar

        public void incluirCliente(string cedula, string nombreCompleto)
        {
            this.contexto.Clientes.Add(new Cliente { Cedula = cedula, NombreCompleto = nombreCompleto});
            this.contexto.SaveChanges();

        }

        //actualiza 
        public void actualizaCliente(int Id, string cedula, string nombreCompleto)
        {
            Cliente client = this.obtenClienteSegunIdentificador(Id);
            client.Cedula = cedula;
            client.NombreCompleto = nombreCompleto;
            this.contexto.SaveChanges();
        }


        //metodo eliminar
        public void eliminarCliente(int id)
        {
            Cliente clie = this.obtenClienteSegunIdentificador(id);
            this.contexto.Clientes.Remove(clie);
            this.contexto.SaveChanges();

        }

        // obtener por id
        public Cliente obtenClienteSegunIdentificador(int Id)
        {
            return this.contexto.Clientes.FirstOrDefault(u => u.Id == Id);
        }





    }
}
