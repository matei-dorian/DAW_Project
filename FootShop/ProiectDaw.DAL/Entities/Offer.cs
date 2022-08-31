using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities
{
    [Table("Offer")]
    public class Offer
    {
        public int Id { get; set; }

        [Range(0, 10)]
        public int Discount { get; set; }

        public DateTime EndDate { get; set;}

        public int? ShoeId { get; set; }

        public virtual Shoe Shoe { get; set; }
    }
}
