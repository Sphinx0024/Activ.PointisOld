using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Activ.Pointis.WebAPI.Utilities;

namespace Activ.Pointis.WebAPI.Models
{
    public class ConnexionModel
    {
        /*public static List<Connexion> Get()
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           select p).OrderByDescending(d => d.ConnexionID).ToList();
                return donnees;
            }
        }*/

        public static List<Connexion> afficher(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.SocieteID == id
                                           select p).OrderByDescending(d => d.ConnexionID).ToList();
                return donnees;
            }
        }

        public static List<Connexion> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.ConnexionID == id
                                         select p).ToList();
                return donnees;
            }

        }



        public static string Connecter(ConnexionInfos connexionInfos)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                string id = null;
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.Login == connexionInfos.Login && p.Password == connexionInfos.Password
                                           select p).ToList();

                if (donnees.Count > 0)
                {
                    foreach (Connexion connexion in donnees)
                    {
                        var idConnex = connexion.ConnexionID;
                        var idSoc = connexion.SocieteID;
                        id = idConnex + "#" + idSoc;
                        return id;
                    }
                }
                return id;
            }

        }

        public static string Connect(string login, string passe)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                string id = null;
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.Login == login && p.Password == passe
                                           select p).ToList();

                if(donnees.Count > 0)
                {
                    foreach(Connexion connexion in donnees)
                    {
                        var idConnex = connexion.ConnexionID;
                        var idEmp = connexion.SocieteID;
                        id = idConnex + "#" + idEmp;
                        return id;
                    }
                }
                return id;
            }

        }

        /*public static long EmployesID(string tel)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long id = 0;
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.Login == tel
                                           select p).ToList();

                if (donnees.Count > 0)
                {
                    foreach (Connexion connexion in donnees)
                    {
                        id = (long)connexion.EmployeID;
                        return id;
                    }
                }
                return id;
            }

        }*/

        public static string Verifier(string tel)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                string code = "";
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.Login == tel
                                           select p).ToList();
                if (donnees.Count > 0)
                {
                    code = GenerateCode();
                }
                return code;
            }

        }

        public static long Confirmer(string tel, string passe)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long code = 0;
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.Login == tel && p.Password == passe
                                           select p).ToList();
                if (donnees.Count > 0)
                {
                    foreach(Connexion p in donnees)
                    {
                        code = (long)p.SocieteID;
                    }
                }
                return code;
            }

        }

        /*public static Connexion Verifier(string tel)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                Connexion connexion = new Connexion();
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.Login == tel
                                           select p).ToList();
                if (donnees.Count > 0)
                {
                    foreach (Connexion connexion1 in donnees)
                    {
                            connexion.Login = connexion1.Login;
                            connexion.Password = GenerateCode();
                            connexion.EmployeID = connexion1.EmployeID;
                            connexion.Role = connexion1.Role;

                        return connexion;
                    }
                   
                }
                return connexion;
            }

        }*/


        public static long Ajouter(Connexion connexion)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                

                string nom = EmployesModel.afficherParMail(connexion.SocieteID, connexion.Login);

                string msg = string.Format(Logics.ConstanteNotification.msg_user, nom, connexion.Role, connexion.Login, connexion.Password, Logics.ConstanteNotification.lien_store, Logics.ConstanteNotification.lien_login);
                Mailling.EnvoyerMailAvecCopie(Mapping.MailConfig, msg, Logics.ConstanteNotification.obj_user, new List<string>() { connexion.Login }, null);

                _db.Connexion.Add(connexion);
                _db.SaveChanges();

                return connexion.ConnexionID;
            }
            
        }

        public static long Add(Connexion connexion)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                Connexion connexion1 = new Connexion()
                {
                    Login = connexion.Login,
                    Password = SocieteModel.GenererCode(),
                    Role = connexion.Role,
                    SocieteID = connexion.SocieteID,
                    Verification = connexion.Verification
                };

                _db.Connexion.Add(connexion1);
                _db.SaveChanges();

                return connexion1.ConnexionID;
            }

        }

        public static void Modifier(long id, Connexion connexion)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.ConnexionID == id
                                         select p).ToList();

                foreach (Connexion connexion1 in donnees)
                {
                    connexion1.Login = connexion.Login;
                    connexion1.Password = connexion.Password;
                    connexion1.SocieteID = connexion.SocieteID;
                    connexion1.Role = connexion.Role;
                    connexion1.Verification = connexion1.Verification;
                    _db.SaveChanges();
                }
                
            }
        }

        public static bool VerifierConnexion(long id, string email)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                bool resp = false;
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.ConnexionID == id && p.Login == email
                                           select p).ToList();
                //return donnees;

                if(donnees.Count > 0)
                {
                    resp = true;
                }
                return resp;
            }
        }

        public static void ModifierPasse(long id, Password password)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.ConnexionID == id && p.Password == password.Ancien
                                           select p).ToList();

                foreach (Connexion connexion1 in donnees)
                {
                    connexion1.Login = connexion1.Login;
                    connexion1.Password = password.Nouveau;
                    connexion1.SocieteID = connexion1.SocieteID;
                    connexion1.Role = connexion1.Role;
                    connexion1.Verification = "No_First";
                    _db.SaveChanges();
                }
            }
        }

        /*public static void ModifierPasse(long id, Connexion connexion)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.ConnexionID == id
                                           select p).ToList();

                foreach (Connexion connexion1 in donnees)
                {
                    connexion1.Login = connexion1.Login;
                    connexion1.Password = connexion.Password;
                    connexion1.EmployeID = connexion1.EmployeID;
                    connexion1.Role = connexion1.Role;
                    _db.SaveChanges();
                }

            }
        }*/

        public static void supprimer(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.ConnexionID == id
                                         select p).ToList();

                _db.Connexion.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }

        public static string GenerateCode()
        {
            Random rand = new Random();
            int code = rand.Next(1000, 9999);
            return code.ToString();
        }

        public static bool IsValidUser(string login, string pwd)
        {
            
            using (PointisEntities _db = new PointisEntities())
            {
                bool isValid = false;
                var donnees = (from c in _db.Connexion
                                          where c.Login == login && c.Password == pwd
                                          select c);
                 if(donnees.Any())
                {
                    return isValid;
                }
                 else 
                {
                    isValid = true;
                    return isValid;
                }

            }
        }
    }
}