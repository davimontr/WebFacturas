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
            return (from c in contexto.Clientes
                    join f in contexto.Facturas on c.Id equals f.IdCliente
                    select new
                    {
                        Venta = f.Numero,
                        Fecha = f.Fecha,
                        Cliente = c.NombreCompleto,
                        f.Total
                    }).ToList().Cast<object>().ToList();
        }
        
        public List<object> reportFacturas(string numFac)
        {
            return (from c in contexto.Clientes
                    join f in contexto.Facturas on c.Id equals f.IdCliente
                    join l in contexto.LineaArticuloes on f.Id equals l.IdFactura
                    join p in contexto.Productos on l.IdProducto equals p.Id
                    where f.Numero == numFac
                    select new
                    {
                        Venta = f.Numero,
                        Fecha = f.Fecha,
                        Cliente = c.NombreCompleto,
                        Producto = p.Nombre,
                        l.Precio,
                        f.Total
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
