//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Activ.Pointis.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Connexion
    {
        public long ConnexionID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long SocieteID { get; set; }
        public string Role { get; set; }
        public string Verification { get; set; }
    
        public virtual Societe Societe { get; set; }
    }
}
