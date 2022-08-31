using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public String Address { get; set; }

        public String City { get; set; }

        public String Distributor { get; set; }

        public double Price { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? ShippingDate { get; set; }

        public int? UserId { get; set; }

    }
}
