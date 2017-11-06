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
        TipoMoneda obtenerPorId(int Id);
        decimal obtenerTipoCambioDeMonedaPorId(int Id);
    }

    public class AccionesTipoMoneda : AccionesEntidades, IServiciosTipoMoneda
    {

        public List<TipoMoneda> obtenerTodos()
        {
            return this.contexto.TipoMonedas.ToList();
        }

        public TipoMoneda obtenerPorId(int Id)
        {
            return this.contexto.TipoMonedas.Where(tp => tp.Id == Id).SingleOrDefault();
        }

        public decimal obtenerTipoCambioDeMonedaPorId(int Id)
        {
            return this.obtenerPorId(Id).TipoCambio;
        }
    }
}
