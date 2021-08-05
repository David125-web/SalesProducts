using System;
using System.Collections.Generic;

namespace SalesProducts.Core.Entities
{
    public partial class Order : BaseEntity
    {
        //public int PedId { get; set; }
        public int PedUsu { get; set; }
        public int PedProd { get; set; }
        public decimal PedVrUnit { get; set; }
        public double PedCant { get; set; }
        public decimal PedSubTot { get; set; }
        public double PedIva { get; set; }
        public decimal PedTotal { get; set; }

        public virtual Product PedProdNavigation { get; set; }
        public virtual User PedUsuNavigation { get; set; }
    }
}
