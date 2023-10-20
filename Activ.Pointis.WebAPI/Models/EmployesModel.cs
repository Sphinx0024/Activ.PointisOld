using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Activ.Pointis.Data;
using Zen.Barcode;

namespace Activ.Pointis.WebAPI.Models
{
    public class EmployesModel
    {
        public static List<Employes> afficher(long id)
        {
            using(PointisEntities _db = new PointisEntities())
            {
                List<Employes> donnees = (from p in _db.Employes
                                          where p.SocieteID == id
                                          select p).OrderByDescending(p=>p.EmployeID).ToList();
                return donnees;
            }
        }

        public static List<Employes> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Employes> donnees = (from p in _db.Employes
                                          where p.EmployeID == id
                                          select p).ToList();
                return donnees;
            }
        }

        public static List<Employes> AfficherParResponsable(long idSoc, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                string famille = prenom+" "+nom;

                List<Employes> donnees = (from p in _db.Employes
                                          where p.SocieteID == idSoc && p.Responsable == famille
                                          select p).ToList();
                return donnees;
            }
        }



        // public static long Ajouter(Employes employes)
        public static long Ajouter(Employes employes)
          {
                using (PointisEntities _db = new PointisEntities())
                {

                    _db.Employes.Add(employes);
                    _db.SaveChanges();

                    /*List<Employes> donnees = (from p in _db.Employes select p).ToList();

                    if (donnees.Count > 0)
                    {
                        foreach (Employes p in donnees)
                        {
                            if (p.Email != employes.Email && p.Telephone != employes.Telephone)
                            {
                                _db.Employes.Add(employes);
                                _db.SaveChanges();
                            }
                        }
                    }*/

                    return employes.EmployeID;
                }
          }

        public static long AjouterStrict(long id, Employes employes)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                List<Employes> donnees = (from p in _db.Employes where p.SocieteID == id && employes.Email != p.Email || employes.Telephone != p.Telephone select p).ToList();

                if (donnees.Count > 0)
                {
                       _db.Employes.Add(employes);
                       _db.SaveChanges();
                }

                return employes.EmployeID;
            }
        }


        public static void Modifier(long id,Employes employes) {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Employes> donnees = (from p in _db.Employes
                                          where p.EmployeID == id
                                          select p).ToList();

                foreach(Employes emp in donnees)
                {
                    emp.Nom = employes.Nom;
                    emp.Prenom = employes.Prenom;
                    emp.Email = employes.Email;
                    emp.Telephone = employes.Telephone;
                    emp.Sexe = employes.Sexe;
                    emp.Matricule = employes.Matricule;
                    emp.Titre = employes.Titre;
                    emp.SocieteID= employes.SocieteID;
                    emp.EquipeID= employes.EquipeID;
                    emp.Password = employes.Password;
                    emp.Responsable = employes.Responsable;
                }
                _db.SaveChanges();
            }
        }

        public static void Passe(long id, Employes employes)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Employes> donnees = (from p in _db.Employes
                                          where p.EmployeID == id
                                          select p).ToList();

                foreach (Employes emp in donnees)
                {
                    emp.Nom = emp.Nom;
                    emp.Prenom = emp.Prenom;
                    emp.Email = emp.Email;
                    emp.Telephone = emp.Telephone;
                    emp.Sexe = emp.Sexe;
                    emp.Matricule = emp.Matricule;
                    emp.Titre = emp.Titre;
                    emp.SocieteID = emp.SocieteID;
                    emp.EquipeID = emp.EquipeID;
                    emp.Password = employes.Password;
                    emp.Responsable = emp.Responsable;
                }
                _db.SaveChanges();
            }
        }


        public static void supprimer(long id)
        {
            using(PointisEntities _db = new PointisEntities())
            {
                List<Employes> donnees = (from p in _db.Employes
                                          where p.EmployeID == id
                                          select p).ToList();

                _db.Employes.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }

        public static long Verifier(string tel)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                List<Employes> donnees = (from p in _db.Employes
                                          where p.Telephone == tel
                                           select p).ToList();
                if (donnees.Count > 0)
                {
                    foreach(Employes emp in donnees)
                    {
                        ident = emp.EmployeID;
                    }
                }
                return ident;
            }

        }

        public static System.Drawing.Image GenererQrcode(Employes employes)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            var infos = (employes.Nom + " " + employes.Prenom + " " + employes.Telephone + " " + employes.Email + " " + employes.Sexe);
            var result = qrcode.Draw(infos,60);

            return result;
        }

        public static System.Drawing.Image GenererQrcodeParId(long id)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            var infos = (id.ToString());
            var result = qrcode.Draw(infos, 60);

            return result;
        }

    }
}