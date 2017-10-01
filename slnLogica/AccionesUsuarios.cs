using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    public interface IServiciosUsuarios
    {
        bool iniciarSession(string correo, string clave);
    }

    public class AccionesUsuarios : IServiciosUsuarios
    {
        private FacturacionEntidades contexto;
        public AccionesUsuarios()
        {
            this.contexto = new FacturacionEntidades();
        }

        public bool iniciarSession(string correo, string clave)
        {
            // Encriptar clave.
            Usuario usuario = this.contexto.Usuarios.FirstOrDefault(u => u.Email.Equals(correo));
            return (usuario != null);
        }
    }
}
