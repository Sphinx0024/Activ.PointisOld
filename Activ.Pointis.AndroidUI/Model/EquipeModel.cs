using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetScan.Model
{
    public class EquipeModel
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string HeureDebutService { get; set; }
        public string HeureFinService { get; set; }
        public Nullable<long> SocieteID { get; set; }
    }
}
