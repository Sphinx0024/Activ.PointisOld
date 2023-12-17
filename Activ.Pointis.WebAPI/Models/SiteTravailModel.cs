using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Models
{
    public class SiteTravailModel
    {
        public static List<SiteTravail> afficher(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<SiteTravail> donnees = (from p in _db.SiteTravail
                                               where p.SocieteID == id
                                               select p).OrderByDescending(d => d.ID).ToList();
                return donnees;
            }
        }

        public static List<SiteTravail> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<SiteTravail> donnees = (from p in _db.SiteTravail
                                               where p.ID == id
                                               select p).ToList();
                return donnees;
            }
        }

        public static void Ajouter(SiteTravail siteTravail)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                _db.SiteTravail.Add(siteTravail);
                _db.SaveChanges();

            }

        }

        public static void Modifier(long id, SiteTravail siteTravail)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<SiteTravail> donnees = (from p in _db.SiteTravail
                                             where p.ID == id
                                               select p).ToList();

                foreach (SiteTravail site in donnees)
                {
                    site.Quartier = siteTravail.Quartier;
                    site.SocieteID = siteTravail.SocieteID;
                    site.Commune = siteTravail.Commune;
                    site.CoordonnerGPS = siteTravail.CoordonnerGPS;
                    site.Ville = siteTravail.Ville;
                    site.Pays = siteTravail.Pays;

                }
                _db.SaveChanges();
            }
        }

        public static void supprimer(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<SiteTravail> donnees = (from p in _db.SiteTravail
                                               where p.ID == id
                                               select p).ToList();

                _db.SiteTravail.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }
    }
}