using System;
using System.Collections.Generic;
using System.Text;

namespace SalesProducts.Core.DTOs
{
    public class OrderDTo
    {
        public int Id { get; set; }
        public int PedUsu { get; set; }
        public int PedProd { get; set; }
        public decimal PedVrUnit { get; set; }
        public double PedCant { get; set; }
        public decimal PedSubTot { get; set; }
        public double PedIva { get; set; }
        public decimal PedTotal { get; set; }
    }
}
