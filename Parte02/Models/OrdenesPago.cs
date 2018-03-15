using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parte02.Models
{
    public class OrdenesPago
    {
        public int IdOrdenPago { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPago { get; set; }
    }
}