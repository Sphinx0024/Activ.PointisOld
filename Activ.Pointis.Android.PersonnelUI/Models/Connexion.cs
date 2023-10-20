using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activ.Pointis.Android.PersonnelUI.Models
{
    public class Connexion
    {
        public long ConnexionID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Nullable<long> EmployeID { get; set; }
        public string Role { get; set; }

        //public virtual Employes Employes { get; set; }
        public Employes Employes { get; set; }
    }
}
