using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Models
{
    public class OfferModel
    {
        public int Id { get; set; }

        public int Discount { get; set; }

        public DateTime EndDate { get; set; }

        public int? ShoeId { get; set; }

    }
}
