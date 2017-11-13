using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    public interface IserviciosFacturas
    {
        List<Factura> obtenerTodos();
        void incluirFactura(string Numero, DateTime Fecha, int IdCliente, int IdFormaPago, int IdTipoMoneda);
        Factura obtenFacturaSegunIdentificador(int Id);
        void actualizaFactura(int Id, string Numero, DateTime Fecha, int Idcliente, 
            int IdFormaPago, int IdTipoMoneda, decimal Pagado, Nullable<decimal> convertido);
        void actualizaTotalFactura(int Id, decimal Total);
        void eliminarFactura(int Id);
        Factura obtenFacturaSegunNumero(string Numero);
        decimal reporteCierre(DateTime fecha);
      
        
    }

    public class AccionesFacturas : AccionesEntidades, IserviciosFacturas
    {
        private IserviciosLineaArticulo Linea = new AccionesLineaArticulo();


        public List<Factura> obtenerTodos()
        {
            return this.contexto.Facturas.ToList();

        }

        // metodo agregar
        public void incluirFactura(string Numero, DateTime Fecha, int IdCliente, int IdFormaPago, int IdTipoMoneda)
        {
            this.contexto.Facturas.Add(new Factura {
                Numero = Numero,
                Fecha = Fecha,
                IdCliente = IdCliente,
                IdFormaPago = IdFormaPago,
                IdTipoMoneda = IdTipoMoneda
            });
            this.contexto.SaveChanges();
        }

        public Factura obtenFacturaSegunIdentificador(int Id)
        {
            return this.contexto.Facturas.FirstOrDefault(f => f.Id == Id);
        }

        // Metodo de modifcar factura
        public void actualizaFactura(int Id, string Numero, DateTime Fecha, int Idcliente, 
            int IdFormaPago, int IdTipoMoneda, decimal Pagado, Nullable<decimal> Convertido)
        {
            decimal total = 0;
            List<LineaArticulo> lineas = this.Linea.obtenerTodosPorIdFactura(Id);
            foreach (LineaArticulo Linea in lineas )
            {

                total = total + Linea.Precio;
             
            }

            Factura factura = this.obtenFacturaSegunIdentificador(Id);
            factura.Numero = Numero;
            factura.Fecha = Fecha;
            factura.IdCliente = Idcliente;
            factura.IdFormaPago = IdFormaPago;
            factura.IdTipoMoneda = IdTipoMoneda;
            factura.Total = total;
            factura.Pagado = Pagado;
            factura.Convertido = Convertido;
            this.contexto.SaveChanges();
        }

        public void actualizaTotalFactura(int Id, decimal Total)
        {
            Factura factura = this.obtenFacturaSegunIdentificador(Id);
            factura.Total = Total;
            this.contexto.SaveChanges();
        }

        //metodo eliminar
        public void eliminarFactura(int Id)
        {
            Factura factura = this.obtenFacturaSegunIdentificador(Id);
            this.contexto.Facturas.Remove(factura);
            this.contexto.SaveChanges();
        }

        public Factura obtenFacturaSegunNumero(string Numero)
        {
            return this.contexto.Facturas.FirstOrDefault(f => f.Numero.Equals(Numero));
        }


        public decimal reporteCierre(DateTime fecha)
        {
            return (from f in contexto.Facturas
                    where f.Fecha == fecha
                    select f.Total
                     ).Sum();
               
        }


    



    }
}
