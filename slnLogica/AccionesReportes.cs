using System;
using System.Collections.Generic;
using System.Linq;

namespace slnLogica
{

    public interface IserviciosReportes
    {

        List<object> reportTodasFactu();
        List<object> reportFacturas(string numFac);
        List<object> reportFacturasPorDepartamentos(DateTime fecha);
        List<object> reportFacturasDepartamentos();
        List<object> graficoVentasDepartamentos();

    }

    public class AccionesReportes : AccionesEntidades, IserviciosReportes
    {
        public List<object> reportTodasFactu()
        {
            return (from f in this.contexto.Facturas
                    join c in this.contexto.Clientes on f.IdCliente equals c.Id
                    select new
                    {
                        Factura = f.Numero,
                        Fecha = f.Fecha,
                        Cliente = c.NombreCompleto,
                        Total = f.Total
                    }).ToList().Cast<object>().ToList();
        }
        
        public List<object> reportFacturas(string numFac)
        {
            return (from f in this.contexto.Facturas 
                    join c in this.contexto.Clientes on f.IdCliente equals c.Id
                    where f.Numero == numFac
                    select new
                    {
                        Factura = f.Numero,
                        Fecha = f.Fecha,
                        Cliente = c.NombreCompleto,
                        Total = f.Total
                    }).ToList().Cast<object>().ToList();
        }

        public List<object> reportFacturasPorDepartamentos(DateTime fecha)
        {
            return (from ln in contexto.LineaArticuloes
                    join f in contexto.Facturas on ln.IdFactura equals f.Id
                    join p in contexto.Productos on ln.IdProducto equals p.Id
                    join d in contexto.Departamentos on p.IdDepartamento equals d.Id
                    where f.Fecha == fecha 
                    group ln by d.Nombre into g
                    select new
                    {
                        Nombre = g.Key,
                        Total = g.Sum(ln => ln.Precio)
                    }).ToList().Cast<object>().ToList();
        }
        
        public List<object> reportFacturasDepartamentos()
        {
            return  (from ln in contexto.LineaArticuloes
                     join f in contexto.Facturas on ln.IdFactura equals f.Id
                     join p in contexto.Productos on ln.IdProducto equals p.Id
                     join d in contexto.Departamentos on p.IdDepartamento equals d.Id
                     group ln by d.Nombre into g
                     select new
                     {
                         Nombre = g.Key,
                         Total = g.Sum(ln => ln.Precio)
                     }).ToList().Cast<object>().ToList();
        }

        public List<object> graficoVentasDepartamentos()
        {
            return (from ln in contexto.LineaArticuloes
                    join f in contexto.Facturas on ln.IdFactura equals f.Id
                    join p in contexto.Productos on ln.IdProducto equals p.Id
                    join d in contexto.Departamentos on p.IdDepartamento equals d.Id
                    group ln by d.Nombre into g
                    select new
                    {
                        Nombre = g.Key,
                        Total = g.Sum(ln => ln.Cantidad)
                    }).ToList().Cast<object>().ToList();
        }
    }
}
