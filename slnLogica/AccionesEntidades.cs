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
    }
}
