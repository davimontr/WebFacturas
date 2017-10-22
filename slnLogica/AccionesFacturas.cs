﻿using System;
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
        void actualizaFactura(int Id, string Numero, DateTime Fecha, int Idcliente, int IdFormaPago, int IdTipoMoneda);
        void eliminarFactura(int Id);
        Factura obtenFacturaSegunNumero(string Numero);
        
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
                IdTipoMoneda = IdTipoMoneda,
                //Total = Total
            });
            this.contexto.SaveChanges();
        }

        public Factura obtenFacturaSegunIdentificador(int Id)
        {
            return this.contexto.Facturas.FirstOrDefault(f => f.Id == Id);
        }

        // Metodo de modifcar factura
        public void actualizaFactura(int Id, string Numero, DateTime Fecha, int Idcliente, int IdFormaPago, int IdTipoMoneda )
        {
            decimal total=0;
            decimal sumatoria = 0;
            var lista = this.Linea.obtenerTodosPorIdFactura(Id);
            foreach (LineaArticulo precio in lista)
            {
                precio.Precio = total;
                sumatoria = total;
            }

            Factura factura = this.obtenFacturaSegunIdentificador(Id);
            factura.Numero = Numero;
            factura.Fecha = Fecha;
            factura.IdCliente = Idcliente;
            factura.IdFormaPago = IdFormaPago;
            factura.IdTipoMoneda = IdTipoMoneda;
            factura.Total = sumatoria+total;
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
    }
}
