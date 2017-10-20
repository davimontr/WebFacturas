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
        void eliminarCliente(int Id);
        Cliente obtenClienteSegunIdentificador(int Id);
        void actualizaCliente(int Id, string Cedula, string NombreCompleto);
        void incluirCliente(string Cedula, string NombreCompleto);
    }

    public class AccionesClientes : AccionesEntidades, IserviciosClientes 
    {

        public List<Cliente> obtenerTodos()
        {
            return this.contexto.Clientes.ToList();
        }

        // metodo de agregar
        public void incluirCliente(string Cedula, string NombreCompleto)
        {
            this.contexto.Clientes.Add(new Cliente { Cedula = Cedula, NombreCompleto = NombreCompleto});
            this.contexto.SaveChanges();
        }

        //actualiza 
        public void actualizaCliente(int Id, string Cedula, string NombreCompleto)
        {
            Cliente cliente = this.obtenClienteSegunIdentificador(Id);
            cliente.Cedula = Cedula;
            cliente.NombreCompleto = NombreCompleto;
            this.contexto.SaveChanges();
        }


        //metodo eliminar
        public void eliminarCliente(int Id)
        {
            Cliente cliente = this.obtenClienteSegunIdentificador(Id);
            this.contexto.Clientes.Remove(cliente);
            this.contexto.SaveChanges();
        }

        // obtener por id
        public Cliente obtenClienteSegunIdentificador(int Id)
        {
            return this.contexto.Clientes.FirstOrDefault(c => c.Id == Id);
        }
        
    }
}
