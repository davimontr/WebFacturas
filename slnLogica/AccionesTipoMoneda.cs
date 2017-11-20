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
        TipoMoneda obtenerPorNombre(string Nombre);
        decimal obtenerTipoCambioDeMonedaPorId(int Id);
        void actualizarTipoCambioMoneda(string Nombre, decimal TipoCambio);
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

        public TipoMoneda obtenerPorNombre(string Nombre)
        {
            return this.contexto.TipoMonedas.Where(tp => tp.Nombre.Equals(Nombre)).FirstOrDefault();
        }

        public void actualizarTipoCambioMoneda(string Nombre, decimal TipoCambio)
        {
            TipoMoneda tipoMoneda = this.obtenerPorNombre(Nombre);
            if(tipoMoneda != null)
            {
                tipoMoneda.TipoCambio = TipoCambio;
                this.contexto.SaveChanges();
            }
        }

        public decimal obtenerTipoCambioDeMonedaPorId(int Id)
        {
            return this.obtenerPorId(Id).TipoCambio;
        }
    }
}
