using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Models
{
    public class DescriptionModel
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
