//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace slnDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Facturas = new HashSet<Factura>();
        }
    
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
    
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
