using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build4Both.PCL.Models
{

    public class Snapshot
    {
        public Snapshot() { }

        public int ID { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; }
        public DateTime DateTaken { get; set; }
    }
}
