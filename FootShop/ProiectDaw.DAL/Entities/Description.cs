using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Entities
{
    public class Description
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? ShoeId { get; set; }
        public virtual Shoe Shoe { get; set; }

    }
}
