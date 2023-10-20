using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Activ.Pointis.WebAPI.Models
{
    public class SocieteModel
    {
        public static List<Societe> afficher()
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Societe> donnees = (from p in _db.Societe
                                         select p).ToList();
                return donnees;
            }
        }

        public static List<Societe> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Societe> donnees = (from p in _db.Societe
                                         where p.ID == id
                                          select p).ToList();
                return donnees;
            }

        }


        public static long Ajouter(Societe societe)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                _db.Societe.Add(societe);
                _db.SaveChanges();

                return societe.ID;
            }
        }

        public static void Modifier(long id, Societe societe)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Societe> donnees = (from p in _db.Societe
                                         where p.ID == id
                                          select p).ToList();

                foreach (Societe societe1 in donnees)
                {
                    societe1.RaisonSociale = societe.RaisonSociale;
                    societe1.RCCM = societe.RCCM;
                    societe1.Telephone = societe.Telephone;
                    societe1.Email = societe.Email;

                }
                _db.SaveChanges();
            }
        }

        public static void supprimer(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Societe> donnees = (from p in _db.Societe
                                         where p.ID == id
                                          select p).ToList();

                _db.Societe.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }

        //public static string Inscription(string emailSoc, ConnexionClasse connexionClasse)

        /*public static string Inscription(Societe societe)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                string result = null;

                /*Societe societe = new Societe()
                {
                    RaisonSociale = connexionClasse.RaisonSocialeSoc,
                    RCCM = connexionClasse.RCCMSoc,
                    Email = connexionClasse.EmailSoc,
                    Telephone = connexionClasse.TelephoneSoc,
                    Localisation = connexionClasse.LocalisationSoc
                };*/

                /*_db.Societe.Add(societe);
                _db.SaveChanges();

                string passe = GenererCode();

                Connexion connexion = new Connexion()
                {
                    Login = societe.Email,
                    Password = passe,
                    SocieteID = societe.ID,
                    Role = "Admin"
                };

                _db.Connexion.Add(connexion);

                EquipeTravail equipeTravail = new EquipeTravail()
                {
                    Title = "Normal",
                    HeureDebutService = "08h00:00",
                    HeureFinService = "18h00:00",
                    SocieteID = societe.ID
                };

                _db.EquipeTravail.Add(equipeTravail);

                return result = societe.ID + "#" + equipeTravail.ID;


            }


            //_db.SaveChanges();

            //List<Societe> donnes = (from p in _db.Societe select societe).ToList();

            /*if (donnes.Count > 0)
            {
                foreach (Societe donne in donnes)
                {
                    if (donne.RaisonSociale != societe.RaisonSociale && donne.RCCM != societe.RCCM && donne.Telephone != societe.Telephone && donne.Email != societe.Email)
                    {
                        _db.Societe.Add(societe);
                        //_db.SaveChanges();

                        Connexion connexion = new Connexion()
                        {
                            Login = societe.Email,
                            Password = passe,
                            SocieteID = societe.ID,
                            Role = "Admin"
                        };

                        _db.Connexion.Add(connexion);

                        EquipeTravail equipeTravail = new EquipeTravail()
                        {
                            Title = "Normal",
                            HeureDebutService = "08h00:00",
                            HeureFinService = "18h00:00",
                            SocieteID = societe.ID
                        };

                        _db.EquipeTravail.Add(equipeTravail);

                        /*Employes employes = new Employes()
                        {
                            Nom = connexionClasse.Nom,
                            Prenom = connexionClasse.Prenom,
                            Email = connexionClasse.Email,
                            Telephone = connexionClasse.Telephone,
                            Sexe = connexionClasse.Sexe,
                            EquipeID = equipeTravail.ID,
                            SocieteID = societe.ID,
                            Titre = connexionClasse.Titre,
                            Matricule = connexionClasse.Matricule
                        };

                        _db.Employes.Add(employes);*/

            /*_db.SaveChanges();

            result = "OK";
        }

        else
        {
            result = "NO";

        }
    }
}*/
            //return result;

        //}
        public static string Inscription(ConnexionClasse connexionClasse) 
        {
            using (PointisEntities _db = new PointisEntities())
            {
                string result = null;

                Societe societe = new Societe()
                {
                    RaisonSociale = connexionClasse.RaisonSocialeSoc,
                    RCCM = connexionClasse.RCCMSoc,
                    Email = connexionClasse.EmailSoc,
                    Telephone = connexionClasse.TelephoneSoc,
                    Localisation = connexionClasse.LocalisationSoc
                };

                long id = Ajouter(societe);

                string passe = GenererCode();

                Connexion connexion = new Connexion()
                {
                    Login = connexionClasse.Email,
                    //Password = passe,
                    Password = "Passw0rd",
                    SocieteID = id,
                    Role = "Admin",
                    Verification = "First"
                };

                long idcon = ConnexionModel.Ajouter(connexion);

                EquipeTravail equipeTravail = new EquipeTravail()
                {
                    Title = "Normal",
                    HeureDebutService = "08h00",
                    HeureFinService = "16h30",
                    SocieteID = id
                };

                long ideq = EquipeTravailModel.Ajouter(equipeTravail);

                Employes employes = new Employes()
                {
                    Nom = connexionClasse.Nom,
                    Prenom = connexionClasse.Prenom,
                    Email = connexionClasse.Email,
                    Telephone = connexionClasse.Telephone,
                    Sexe = connexionClasse.Sexe,
                    EquipeID = ideq,
                    SocieteID = id,
                    Titre = connexionClasse.Titre,
                    Matricule = connexionClasse.Matricule,
                    Responsable = connexionClasse.Responsable
                };

                  long idemp = EmployesModel.Ajouter(employes);

                  result = id + "#"  + idcon + "#" + ideq + "#" + idemp;

                  return result;
            }

        }

        public static string GenererCode()
        {
            const string caracteresPermis = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var rand = new Random();
            var code = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int index = rand.Next(caracteresPermis.Length);
                code.Append(caracteresPermis[index]);
            }
            return code.ToString();
        }

    }
}