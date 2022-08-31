using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Models
{
    public class ShoeSizeModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int Size { get; set; }

        public int? ShoeId { get; set; }
    }
}
