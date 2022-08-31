using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Models
{
    public class ShoeModel
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public double Price { get; set; }

        public string Colour { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }

        public string Image { get; set; }

        public double Rating { get; set; }

        public bool Promo { get; set; }
    }
}
