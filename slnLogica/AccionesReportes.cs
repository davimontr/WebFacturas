using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{

    public interface IserviciosReportes
    {

        List<object> reportTodasFactu();
        List<object> reportFacturas(string numFac);

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
                    }
                    ).ToList().Cast<object>().ToList();
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
                    }
                    ).ToList().Cast<object>().ToList();

        }
    }
}
