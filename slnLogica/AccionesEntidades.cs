using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using slnDatos;

namespace slnLogica
{
    public class AccionesEntidades
    {
        protected FacturacionEntidades contexto;

        public AccionesEntidades()
        {
            this.contexto = new FacturacionEntidades();
        }


        public void selectTotalFacturas()
        {
            using (var context = new FacturacionEntidades())
            {
                var fecha = from f in context.Facturas
                             where f.Fecha.Equals("Fecha")  
                             select f;

                //var total = from f in context.Facturas
                //             where f.Total.Equals("Total")
                //             select f;
                //var gravado = from p in context.Productos
                //              where p.Gravado.Equals("gravado")
                //              select p;


            }

        }




        }



    }

