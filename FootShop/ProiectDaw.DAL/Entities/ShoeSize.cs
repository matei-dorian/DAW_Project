using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities
{
    [Table("ShoeSize")]
    public class ShoeSize
    {
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        
        public int Size { get; set; }

        public int? ShoeId { get; set; }

        public virtual Shoe Shoe { get; set; }


    }
}
