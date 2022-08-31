using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities
{
    [Table("Shoe")]
    public class Shoe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        [Range(0, int.MaxValue)]
        public double Price { get; set; }

        [DefaultValue("multicolour")]
        public string Colour { get; set; }

        [DefaultValue("unisex")]
        public string Category { get; set; }

        public string Type { get; set; }

        public double Rating { get; set; }

        public string Image { get; set; }

        public virtual Description Description { get; set; }

        public virtual ICollection<ShoeSize> ShoeSizes { get; set; }

        public virtual ICollection<ShoeOrder> ShoeOrders { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

    }
}
