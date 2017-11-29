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
        List<object> reporteCierre(DateTime fecha);
        List<object> reporteFechaFacturas();
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

        public List<object> reporteCierre(DateTime fecha)
        {
            var ventas = (from f in this.contexto.Facturas
                          where f.Fecha == fecha
                          select f)
                          .Sum(f => (decimal?)f.Total) ?? 0;

            var gravados = this.contexto.LineaArticuloes
                .Join(this.contexto.Facturas,
                ln => ln.IdFactura,
                f => f.Id,
                (ln, f) => new { ln, f })
                .Join(this.contexto.Productos,
                c => c.ln.IdProducto,
                p => p.Id,
                (ln, p) => new { ln, p }
                )
                .Where(ln => ln.ln.f.Fecha == fecha)
                .Where(ln => ln.p.Gravado == true)
                .Sum(s => (decimal?)s.ln.ln.Precio) ?? 0;

            var excentos = (from ln in this.contexto.LineaArticuloes
                            join f in this.contexto.Facturas on ln.IdFactura equals f.Id
                            join p in this.contexto.Productos on ln.IdProducto equals p.Id
                            where f.Fecha == fecha && p.Gravado == false
                            select ln)
                            .Sum(ln => (decimal?)ln.Precio) ?? 0;

            var colones = (from f in this.contexto.Facturas
                           where f.Fecha == fecha && f.IdTipoMoneda == 1
                           select f)
                          .Sum(f => (decimal?)f.Pagado) ?? 0;

            var dolares = (from f in this.contexto.Facturas
                           where f.Fecha == fecha && f.IdTipoMoneda == 2
                           select f)
                          .Sum(f => (decimal?)f.Pagado) ?? 0;

            var euros = (from f in this.contexto.Facturas
                         where f.Fecha == fecha && f.IdTipoMoneda == 3
                         select f)
                          .Sum(f => (decimal?)f.Pagado) ?? 0;

            var convertidos = (from f in this.contexto.Facturas
                               where f.Fecha == fecha
                               select f)
                          .Sum(f => (decimal?)f.Convertido) ?? 0;

            var credito = (from f in this.contexto.Facturas
                               where f.Fecha == fecha && f.IdFormaPago == 2
                               select f)
                         .Sum(f => (decimal?)f.Total);

            var pagado = colones + convertidos;

            var lista = new List<object>();
            lista.Add(new {
                Ventas = ventas,
                Gravados = gravados,
                Excentos = excentos,
                Colones = colones,
                Dolares = dolares,
                Euros = euros,
                Convertidos = convertidos,
                Pagado = pagado,
                Credito = credito,
                Diferencia = ventas - (pagado + credito)
            });

            return lista;
        }

        public List<object> reporteFechaFacturas()
        {
            return (from f in this.contexto.Facturas
                    select new {
                        Factura = f.Numero,
                        Fecha = f.Fecha,
                        Total = f.Total
                    })
                    .ToList()
                    .Cast<object>()
                    .ToList();
        }
    }
}
