using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    public interface IServiciosFormaPago
    {
        List<FormaPago> obtenerTodos();
    }

    public class AccionesFormaPago : AccionesEntidades, IServiciosFormaPago
    {
        public List<FormaPago> obtenerTodos()
        {
            return this.contexto.FormaPagoes.ToList();
        }
    }
}
