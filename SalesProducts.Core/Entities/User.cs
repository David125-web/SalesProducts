using System;
using System.Collections.Generic;

namespace SalesProducts.Core.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        //public int UsuId { get; set; }
        public string UsuNombre { get; set; }
        public string UsuPass { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
