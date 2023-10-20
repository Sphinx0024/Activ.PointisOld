using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activ.Pointis.Android.PersonnelUI.Models
{
    public class V_Pointage
    {
        public long EmployeID { get; set; }
        public string EmployeNom { get; set; }
        public string EmployePrenom { get; set; }
        public string EmployeEmail { get; set; }
        public string EmployeTelephone { get; set; }
        public string EmployeSexe { get; set; }
        public long SocieteID { get; set; }
        public string SocieteRaisonSociale { get; set; }
        public string SocieteRCCM { get; set; }
        public string SocieteEmail { get; set; }
        public string SocieteTelephone { get; set; }
        public long PointageID { get; set; }
        public System.DateTime PointageJour { get; set; }
        public System.DateTime PointageHeureEntree { get; set; }
        public Nullable<System.DateTime> PointageHeureSortie { get; set; }
        public Nullable<int> PointageDureeSeconde { get; set; }
        public Nullable<int> PointageDureeHeure { get; set; }
        public Nullable<int> PointageDureeMinute { get; set; }
        public string EmployeTitre { get; set; }
        public string EmployeMatricule { get; set; }
        public string EquipeTitre { get; set; }
        public string EquipeHeureDebut { get; set; }
        public string EquipeHeureFin { get; set; }
        public long EquipeID { get; set; }
        public long ID { get; set; }
    }
}
