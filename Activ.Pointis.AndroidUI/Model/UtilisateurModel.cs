using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetScan.Model
{
    public class UtilisateurModel
    {
        public long ConnexionID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long SocieteID { get; set; }
        public string Role { get; set; }
        public string Verification { get; set; }
    }
}
