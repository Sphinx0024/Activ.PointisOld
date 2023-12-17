using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Models
{
    public class ResponsableModel
    {
        public static List<Responsable> afficher()
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Responsable> donnees = (from p in _db.Responsable
                                         select p).ToList();
                return donnees;
            }
        }

        public static List<Responsable> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Responsable> donnees = (from p in _db.Responsable
                                             where p.ID == id
                                         select p).ToList();
                return donnees;
            }

        }

        public static List<Responsable> AfficherParEmploye(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Responsable> donnees = (from p in _db.Responsable
                                             where p.EmployesID == id
                                             select p).ToList();
                return donnees;
            }

        }

        public static List<Responsable> AfficherParResponsable(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Responsable> donnees = (from p in _db.Responsable
                                             where p.ResponsableID == id
                                             select p).ToList();
                return donnees;
            }

        }


        public static long Ajouter(Responsable responsable)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                _db.Responsable.Add(responsable);
                _db.SaveChanges();

                return responsable.ID;
            }
        }

        public static void Modifier(long id, Responsable responsable)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Responsable> donnees = (from p in _db.Responsable
                                             where p.ID == id
                                         select p).ToList();

                foreach (Responsable responsable1 in donnees)
                {
                    responsable1.ResponsableID = responsable.ResponsableID;
                    responsable1.EmployesID = responsable.EmployesID;

                }
                _db.SaveChanges();
            }
        }

        public static void supprimer(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Responsable> donnees = (from p in _db.Responsable
                                         where p.ID == id
                                         select p).ToList();

                _db.Responsable.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }

    }
}