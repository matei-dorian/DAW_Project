using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities
{
    [Table("ShoeOrder")]
    public class ShoeOrder
    {
        public int Id { get; set; }

        public int? ShoeId { get; set; }
        
        public int? OrderId { get; set; }

        [DefaultValue(1)]
        public int Quantity { get; set; }

        public virtual Shoe Shoe { get; set; }

        public virtual Order Order { get; set; }
    }
}
