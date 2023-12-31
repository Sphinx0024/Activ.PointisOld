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
    
    public partial class Societe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Societe()
        {
            this.Connexion = new HashSet<Connexion>();
            this.Employes = new HashSet<Employes>();
            this.EquipeTravail = new HashSet<EquipeTravail>();
            this.SiteTravail = new HashSet<SiteTravail>();
        }
    
        public long ID { get; set; }
        public string RaisonSociale { get; set; }
        public string RCCM { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Localisation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Connexion> Connexion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employes> Employes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipeTravail> EquipeTravail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiteTravail> SiteTravail { get; set; }
    }
}
