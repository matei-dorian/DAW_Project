using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }

        public String Address { get; set; }

        public String City { get; set; }

        public String Distributor { get; set; }

        [Range(0, int.MaxValue)]
        public double Price { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? ShippingDate { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<ShoeOrder> ShoeOrders { get; set; }

    }
}
