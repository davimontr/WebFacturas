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


    }


    public class AccionesDepartamentos : AccionesEntidades, IServiciosDepartamentos
    {
        private FacturacionEntidades contexto;

        public AccionesDepartamentos()
        {
            this.contexto = new FacturacionEntidades();
        }

        public List<Departamento> obtenerDepartamento()
        {
            return this.contexto.Departamentos.ToList();

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
            Departamento depa = this.obtenLineaDepartamentoSegunIdentificador(id);
            depa.Nombre = nombre;
            this.contexto.SaveChanges();
        }


        //metodo eliminar
        public void eliminarDepartamento(int id)
        {
            Departamento dep = this.obtenLineaDepartamentoSegunIdentificador(id);
            this.contexto.Departamentos.Remove(dep);

        }


        public Departamento obtenLineaDepartamentoSegunIdentificador(int Id)
        {
            return this.contexto.Departamentos.FirstOrDefault(u => u.Id == Id);
        }


        public Departamento obtenerDepartamentoSegunID(int Id)
        {
            return this.contexto.Departamentos.FirstOrDefault(c => c.Id == Id);
        }


    }
}
