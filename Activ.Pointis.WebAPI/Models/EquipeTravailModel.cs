using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Models
{
    public class EquipeTravailModel
    {
        public static List<EquipeTravail> afficher(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<EquipeTravail> donnees = (from p in _db.EquipeTravail
                                               where p.SocieteID == id
                                               select p).OrderByDescending(d =>d.ID).ToList();
                return donnees;
            }
        }

        public static List<EquipeTravail> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<EquipeTravail> donnees = (from p in _db.EquipeTravail
                                               where p.ID == id
                                         select p).ToList();
                return donnees;
            }
        }

        public static long AfficherId(long id, string entree, string sortie)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                /*var recup = infos.Split('-');
                string entree = infos[0].ToString();
                string sortie = infos[1].ToString();*/
                List<EquipeTravail> donnees = (from p in _db.EquipeTravail
                                               where p.SocieteID == id && p.HeureDebutService == entree && p.HeureFinService== sortie
                                               select p).ToList();
                
                if(donnees.Count > 0)
                {
                    foreach(EquipeTravail item in donnees)
                    {
                        ident = item.ID;
                        return ident;
                    }
                }
                return ident;
            }
        }


        public static long Ajouter(EquipeTravail equipeTravail)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                _db.EquipeTravail.Add(equipeTravail);
                _db.SaveChanges();

                return equipeTravail.ID;
            }
            
        }

        public static void Modifier(long id, EquipeTravail equipeTravail)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<EquipeTravail> donnees = (from p in _db.EquipeTravail
                                         where p.ID == id
                                         select p).ToList();

                foreach (EquipeTravail equipeTravail1 in donnees)
                {
                    equipeTravail1.Title = equipeTravail.Title;
                    equipeTravail1.HeureDebutService = equipeTravail.HeureDebutService;
                    equipeTravail1.HeureFinService = equipeTravail.HeureFinService;
                    equipeTravail1.SocieteID = equipeTravail.SocieteID;

                }
                _db.SaveChanges();
            }
        }

        public static void supprimer(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<EquipeTravail> donnees = (from p in _db.EquipeTravail
                                               where p.ID == id
                                         select p).ToList();

                _db.EquipeTravail.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }
    }
}