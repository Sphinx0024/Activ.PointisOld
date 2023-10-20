using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Models
{
    public partial class ConnexionClasse
    {
        public string RaisonSocialeSoc { get; set; }
        public string RCCMSoc { get; set; }
        public string EmailSoc { get; set; }
        public string TelephoneSoc { get; set; }
        public string LocalisationSoc { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Sexe { get; set; }
        public string Titre { get; set; }
        public string Matricule { get; set; }
        public string Responsable { get; set; }

    }
}