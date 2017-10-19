using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    public interface IServiciosTipoMoneda
    {
        List<TipoMoneda> obtenerTodos();
    }

    public class AccionesTipoMoneda : AccionesEntidades, IServiciosTipoMoneda
    {

        public List<TipoMoneda> obtenerTodos()
        {
            return this.contexto.TipoMonedas.ToList();
        }
    }
}
