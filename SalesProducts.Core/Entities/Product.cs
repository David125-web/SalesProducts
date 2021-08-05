using System;
using System.Collections.Generic;

namespace SalesProducts.Core.Entities
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        //public int ProId { get; set; }
        public string ProDesc { get; set; }
        public decimal ProValor { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
