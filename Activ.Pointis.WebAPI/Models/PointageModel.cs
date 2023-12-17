using Activ.Pointis.Data;
using Activ.Pointis.WebAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http;
using System.Text;
using System.Web.Configuration;
using System.Web.Services.Description;

namespace Activ.Pointis.WebAPI.Models
{
    public class PointageModel
    {
        public static DateTime GetDebutTrimestreEnCours()
        {
            DateTime dateActuelle = DateTime.Now;

            int trimestreEnCours = (dateActuelle.Month - 1) / 3 + 1;

            DateTime debutTrimestre = new DateTime(dateActuelle.Year, (trimestreEnCours - 1) * 3 + 1, 1).Date;

            return debutTrimestre;
        }

        public static DateTime GetFinTrimestreEnCours()
        {
            DateTime dateActuelle = DateTime.Now;

            int trimestreEnCours = (dateActuelle.Month - 1) / 3 + 1;

            DateTime debutProchainTrimestre = new DateTime(dateActuelle.Year, trimestreEnCours * 3 + 1, 1);
            DateTime finTrimestre = debutProchainTrimestre.AddDays(-1).Date;

            return finTrimestre;
        }

        public static DateTime GetDebutAnneeEnCours()
        {
            DateTime dateActuelle = DateTime.Now;
            
            DateTime debutAnnee = new DateTime(dateActuelle.Year, 1, 1).Date;

            return debutAnnee;
        }

        public static DateTime GetFinAnneeEnCours()
        {
            DateTime dateActuelle = DateTime.Now;

            DateTime finAnnee = new DateTime(dateActuelle.Year, 12, 31).Date;

            return finAnnee;
        }

        public static List<V_Pointage> afficher(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<V_Pointage> donnees = (from p in _db.V_Pointage
                                            where p.SocieteID == id
                                            select p).OrderByDescending(d => d.PointageID).ToList();
                return donnees;
            }
        }
        
        public static long Point(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;
                long ident = 0;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == now && d.EmployeID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    foreach (var item in donnees)
                    {
                        ident = item.PointageID;
                    }  
                }
                return ident;
            }
        }

        public static List<V_Pointage> Day(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == now && d.SocieteID ==id).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> DayTwenty(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == now && d.SocieteID == id).OrderByDescending(d => d.PointageID).Take(20).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> Jour(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == now  && d.EmployeID == id).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static long AbsenceJourEmp(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == now && d.EmployeID == id && d.PointageHeureEntree == null && d.PointageHeureSortie == null).OrderByDescending(d => d.PointageID).ToList();

                return donnees.Count;
            }
        }

        public static List<V_Pointage> IncompletPointageEmp(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;
                DateTime yesterday = now.AddDays(-1);
                //DateTime yesterdayDate = yesterday.Date;
                DateTimeOffset yesterdayDate = new DateTimeOffset(now.AddDays(-1).Date, TimeSpan.Zero);


                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == yesterdayDate && d.EmployeID == id && d.PointageHeureEntree != null && d.PointageHeureSortie == null).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<Absence> AbsenceJourSoc(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;
                List<Absence> absences = new List<Absence>();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == now && d.SocieteID == id).ToList();
                List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();

                
                Absence absence = new Absence()
                {
                    Jour = now.ToString("dddd"),
                    Total = (donneesEmp.Count - donnees.Count)
                };

                 absences.Add(absence);

                return absences;
            }
        }

        public static List<Employes> MissingList(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                var donnees = _db.V_Pointage.Where(d => d.PointageJour == now && d.SocieteID == id).Select(x => x.EmployeID);
                List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id && !donnees.Contains(d.EmployeID)).ToList();


                return donneesEmp;
            }
        }

        public static long Missing(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == now && d.SocieteID == id).ToList();
                List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();


                var absence = (donneesEmp.Count - donnees.Count);

                return absence;
            }
        }

        public static long MissingByDay(DateTime date, long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                //DateTime now = DateTime.Today;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == date && d.SocieteID == id).ToList();
                List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();


                var absence = (donneesEmp.Count - donnees.Count);

                return absence;
            }
        }

        public static List<Report> reportWeek(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);
                DateTime dat = new DateTime();
                List<Report>  reports = new List<Report>();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= debutDeLaSemaine && d.PointageJour <= finDeLaSemaine && d.SocieteID == id).ToList();
                List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();

                DateTime currentDate = DateTime.Now;
                DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;

                int numberOfDays = (currentDayOfWeek - DayOfWeek.Monday + 7) % 7;

                if (currentDayOfWeek == DayOfWeek.Saturday || currentDayOfWeek == DayOfWeek.Sunday)
                {
                    numberOfDays = 5; // Si aujourd'hui est samedi ou dimanche, le nombre de jours écoulés est 5 (du lundi au vendredi)
                }


                if (donnees.Count > 0)
                {
                    foreach (V_Pointage pointage in donnees)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {

                                    Report report = new Report()
                                    {
                                        Jour = pointage.PointageJour.ToString(),
                                        //Absences = ((donneesEmp.Count * numberOfDays) - donnees.Count),
                                        Retards = (pointage.PointageHeureEntree - dat).TotalMinutes
                                    };
                                    reports.Add(report);
                                }
                                else
                                {
                                    Report report = new Report()
                                    {
                                        Jour = pointage.PointageJour.ToString(),
                                        //Absences = ((donneesEmp.Count * numberOfDays) - donnees.Count),
                                        Retards = 0
                                    };
                                    reports.Add(report);
                                }
                            }
                            //return reports;

                        }
                        catch (Exception ex)
                        {
                            
                            throw ex;
                        }
                    }
                    return reports;
                }
                else
                {
                    return reports;
                }
            }
        }

        public static long MissingWeek(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);

                DateTime currentDate = DateTime.Now;
                DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;

                int numberOfDays = (currentDayOfWeek - DayOfWeek.Monday + 7) % 7;

                if (currentDayOfWeek == DayOfWeek.Saturday || currentDayOfWeek == DayOfWeek.Sunday)
                {
                    numberOfDays = 5; // Si aujourd'hui est samedi ou dimanche, le nombre de jours écoulés est 5 (du lundi au vendredi)
                }

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= debutDeLaSemaine && d.PointageJour >= finDeLaSemaine && d.SocieteID == id).ToList();
                List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();


                var absence = ((donneesEmp.Count * numberOfDays) - donnees.Count);

                return absence;
            }
        }

        public static long MissingMonth(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime currentDate = DateTime.Now;
                int numberOfBusinessDays = 0;
                int totalDays = currentDate.Day;

                for (int i = 1; i <= totalDays; i++)
                {
                    DateTime tempDate = new DateTime(currentDate.Year, currentDate.Month, i);
                    if (tempDate.DayOfWeek != DayOfWeek.Saturday && tempDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        numberOfBusinessDays++;
                    }
                }

                DateTime now = DateTime.Today;

                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= startOfMonth && d.PointageJour >= endOfMonth && d.SocieteID == id).ToList();
                List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();


                var absence = ((donneesEmp.Count * numberOfBusinessDays) - donnees.Count);

                return absence;
            }
        }

        public static long MissingQuarter(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                int numberOfBusinessDays = 0;
                DateTime currentDate = GetDebutTrimestreEnCours();
                DateTime finTrimestreEnCours = GetFinTrimestreEnCours();

                while (currentDate <= DateTime.Today)
                {
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        numberOfBusinessDays++;
                    }
                    currentDate = currentDate.AddDays(1);
                }

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= currentDate && d.PointageJour >= finTrimestreEnCours && d.SocieteID == id).ToList();
                List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();


                var absence = ((donneesEmp.Count * numberOfBusinessDays) - donnees.Count);

                return absence;
            }
        }

        public static long MissingYear(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                int numberOfBusinessDays = 0;
                DateTime currentDate = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime endDate = new DateTime(DateTime.Now.Year, 12, 31);

                while (currentDate <= DateTime.Today)
                {
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        numberOfBusinessDays++;
                    }
                    currentDate = currentDate.AddDays(1);
                }

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= currentDate && d.PointageJour >= endDate && d.SocieteID == id).ToList();
                List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();


                var absence = ((donneesEmp.Count * numberOfBusinessDays) - donnees.Count);

                return absence;
            }
        }

        public static long MissingJour(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == now && d.EmployeID == id).ToList();
                //List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();


                var absence = (1 - donnees.Count);

                return absence;
            }
        }

        public static long MissingSemaine(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);

                DateTime currentDate = DateTime.Now;
                DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;

                int numberOfDays = (currentDayOfWeek - DayOfWeek.Monday + 7) % 7;

                if (currentDayOfWeek == DayOfWeek.Saturday || currentDayOfWeek == DayOfWeek.Sunday)
                {
                    numberOfDays = 5; // Si aujourd'hui est samedi ou dimanche, le nombre de jours écoulés est 5 (du lundi au vendredi)
                }

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= debutDeLaSemaine && d.PointageJour >= finDeLaSemaine && d.EmployeID == id).ToList();
                //List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();


                var absence = ((numberOfDays) - donnees.Count);

                return absence;
            }
        }

        public static long MissingMois(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime currentDate = DateTime.Now;
                int numberOfBusinessDays = 0;
                int totalDays = currentDate.Day;

                for (int i = 1; i <= totalDays; i++)
                {
                    DateTime tempDate = new DateTime(currentDate.Year, currentDate.Month, i);
                    if (tempDate.DayOfWeek != DayOfWeek.Saturday && tempDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        numberOfBusinessDays++;
                    }
                }

                DateTime now = DateTime.Today;

                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= startOfMonth && d.PointageJour >= endOfMonth && d.EmployeID == id).ToList();
                //List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();


                var absence = ((numberOfBusinessDays) - donnees.Count);

                return absence;
            }
        }

        public static long MissingTrimestre(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                int numberOfBusinessDays = 0;
                DateTime currentDate = GetDebutTrimestreEnCours();
                DateTime finTrimestreEnCours = GetFinTrimestreEnCours();

                while (currentDate <= DateTime.Today)
                {
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        numberOfBusinessDays++;
                    }
                    currentDate = currentDate.AddDays(1);
                }

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= currentDate && d.PointageJour >= finTrimestreEnCours && d.EmployeID == id).ToList();
                

                var absence = ((numberOfBusinessDays) - donnees.Count);

                return absence;
            }
        }

        public static long MissingAnnee(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                int numberOfBusinessDays = 0;
                DateTime currentDate = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime endDate = new DateTime(DateTime.Now.Year, 12, 31);

                while (currentDate <= DateTime.Today)
                {
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        numberOfBusinessDays++;
                    }
                    currentDate = currentDate.AddDays(1);
                }

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= currentDate && d.PointageJour >= endDate && d.EmployeID == id).ToList();
                //List<Employes> donneesEmp = _db.Employes.Where(d => d.SocieteID == id).ToList();


                var absence = ((numberOfBusinessDays) - donnees.Count);

                return absence;
            }
        }

        public static long MissingEquipJour(long id, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;
                string famille = prenom + " " + nom;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour == now && d.SocieteID == id && d.EmployeResponsable == famille).ToList();
                List<Employes> donneesEmp = EmployesModel.AfficherParResponsable(id, nom, prenom);


                var absence = (donneesEmp.Count - donnees.Count);

                return absence;
            }
        }

        public static long MissingEquipSem(long id, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);

                DateTime currentDate = DateTime.Now;
                DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;

                int numberOfDays = (currentDayOfWeek - DayOfWeek.Monday + 7) % 7;

                if (currentDayOfWeek == DayOfWeek.Saturday || currentDayOfWeek == DayOfWeek.Sunday)
                {
                    numberOfDays = 5; // Si aujourd'hui est samedi ou dimanche, le nombre de jours écoulés est 5 (du lundi au vendredi)
                }

                string famille = prenom + " " + nom;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= debutDeLaSemaine && d.PointageJour >= finDeLaSemaine  && d.SocieteID == id && d.EmployeResponsable == famille).ToList();
                List<Employes> donneesEmp = EmployesModel.AfficherParResponsable(id, nom, prenom);


                var absence = ((donneesEmp.Count * numberOfDays) - donnees.Count);

                return absence;
            }
        }

        public static long MissingEquipMois(long id, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime currentDate = DateTime.Now;
                int numberOfBusinessDays = 0;
                int totalDays = currentDate.Day;

                for (int i = 1; i <= totalDays; i++)
                {
                    DateTime tempDate = new DateTime(currentDate.Year, currentDate.Month, i);
                    if (tempDate.DayOfWeek != DayOfWeek.Saturday && tempDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        numberOfBusinessDays++;
                    }
                }

                DateTime now = DateTime.Today;

                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                string famille = prenom + " " + nom;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= startOfMonth && d.PointageJour >= endOfMonth && d.SocieteID == id && d.EmployeResponsable == famille).ToList();
                List<Employes> donneesEmp = EmployesModel.AfficherParResponsable(id, nom, prenom);


                var absence = ((donneesEmp.Count * numberOfBusinessDays) - donnees.Count);

                return absence;
            }
        }

        public static long MissingEquipTrimestre(long id, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                int numberOfBusinessDays = 0;
                DateTime currentDate = GetDebutTrimestreEnCours();
                DateTime finTrimestreEnCours = GetFinTrimestreEnCours();

                while (currentDate <= DateTime.Today)
                {
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        numberOfBusinessDays++;
                    }
                    currentDate = currentDate.AddDays(1);
                }


                string famille = prenom + " " + nom;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= currentDate && d.PointageJour >= finTrimestreEnCours && d.SocieteID == id && d.EmployeResponsable == famille).ToList();
                List<Employes> donneesEmp = EmployesModel.AfficherParResponsable(id, nom, prenom);


                var absence = ((donneesEmp.Count * numberOfBusinessDays) - donnees.Count);

                return absence;
            }
        }


        public static long MissingEquipAnnee(long id, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                int numberOfBusinessDays = 0;
                DateTime currentDate = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime endDate = new DateTime(DateTime.Now.Year, 12, 31);

                while (currentDate <= DateTime.Today)
                {
                    if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        numberOfBusinessDays++;
                    }
                    currentDate = currentDate.AddDays(1);
                }


                string famille = prenom + " " + nom;

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour <= currentDate && d.PointageJour >= endDate && d.SocieteID == id && d.EmployeResponsable == famille).ToList();
                List<Employes> donneesEmp = EmployesModel.AfficherParResponsable(id, nom, prenom);


                var absence = ((donneesEmp.Count * numberOfBusinessDays) - donnees.Count);

                return absence;
            }
        }


        public static List<V_Pointage> Semaine(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= debutDeLaSemaine && d.PointageJour <= finDeLaSemaine && d.EmployeID==id).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> Week(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= debutDeLaSemaine && d.PointageJour <= finDeLaSemaine && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> Mounth(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> Quarter(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                DateTime debutTrimestreEnCours = GetDebutTrimestreEnCours();
                DateTime finTrimestreEnCours = GetFinTrimestreEnCours();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour.Value >= debutTrimestreEnCours && d.PointageJour.Value <= finTrimestreEnCours && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> Year(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                DateTime debutAnneeEnCours = GetDebutAnneeEnCours();

                DateTime finAnneeEnCours = GetFinAnneeEnCours();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= debutAnneeEnCours && d.PointageJour <= finAnneeEnCours && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> Mois(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.EmployeID == id).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> Trimestre(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                DateTime debutTrimestreEnCours = GetDebutTrimestreEnCours();
                DateTime finTrimestreEnCours = GetFinTrimestreEnCours();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= debutTrimestreEnCours && d.PointageJour <= finTrimestreEnCours && d.EmployeID == id).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> Annee(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                DateTime debutAnneeEnCours = GetDebutAnneeEnCours();
                DateTime finAnneeEnCours = GetFinAnneeEnCours();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= debutAnneeEnCours && d.PointageJour <= finAnneeEnCours && d.EmployeID == id).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> AbsenceMois(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;

                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.SocieteID == id && d.PointageHeureEntree == null && d.PointageHeureSortie == null).OrderByDescending(d => d.PointageID).ToList();

                return donnees;
            }
        }

        public static List<V_Pointage> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<V_Pointage> donnees = (from p in _db.V_Pointage
                                            where p.EmployeID == id
                                            select p).OrderByDescending(d => d.PointageID).ToList();
                return donnees;
            }

        }

        public static List<V_Pointage> LastPointage(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Now;
                DateTime Jour = now.Date.AddDays(-1);
                List<V_Pointage> donnees = (from p in _db.V_Pointage
                                            where p.EmployeID == id && p.PointageJour == Jour && p.PointageHeureSortie == null
                                            orderby p.PointageID descending
                                            select p).Take(1).ToList();
                return donnees;
            }

        }

        public static void Ajouter(Pointage pointage)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long id = pointage.EmployesID;
                List<Employes> donnees = EmployesModel.AfficherUnSeul(id);

                List<V_Pointage> IncompPoint = LastPointage(id);

                    
                    foreach(Employes emp in donnees) 
                    {
                        string mail = emp.Email;
                        string nom = emp.Prenom + " " + emp.Nom;
                        string respo = emp.Responsable;
                        long idEquip = emp.EquipeID;

                        if (IncompPoint.Count > 0)
                        {
                            if (respo != null)
                            {
                                //string nomresp = respo.Substring(0, respo.IndexOf(' '));
                                string[] detailresp = respo.Split('-');
                                string nomresp = detailresp[0].Trim();
                                string prenomresp = detailresp[1].Trim();
                                string telresp = detailresp[2].Trim();
                                long socID = emp.SocieteID;

                                List<Employes> donneesResp = EmployesModel.AfficherParDetailResponsable(socID, nomresp, prenomresp, telresp);
                                foreach (Employes p in donneesResp)
                                {
                                    string mailres = p.Email;
                                    string msg = string.Format(Logics.ConstanteNotification.msg_fraude_emp, nom);
                                    Mailling.EnvoyerMailAvecCopie(Mapping.MailConfig, msg, Logics.ConstanteNotification.obj_fraude, new List<string>() { mail, mailres }, null);
                                }

                                //string url = string.Format("{0}", Mapping.url_user);
                            }
                            else
                            {
                                string msg = string.Format(Logics.ConstanteNotification.msg_fraude_emp, nom);
                                Mailling.EnvoyerMailAvecCopie(Mapping.MailConfig, msg, Logics.ConstanteNotification.obj_fraude, new List<string>() { mail }, null);
                            }
                        }

                        List<EquipeTravail> equip = EquipeTravailModel.AfficherUnSeul(idEquip);

                        foreach(EquipeTravail q in equip)
                        {
                            string[] decoupheure  = q.HeureDebutService.Split('h');
                            string heuredebutstring = decoupheure[0] + ":" + decoupheure[1];
                            var heuredebut = DateTime.Parse(heuredebutstring);
                            heuredebut = heuredebut.AddHours(1);
                            var heure = pointage.HeureEntree;
                            if (heure.TimeOfDay.CompareTo(heuredebut.TimeOfDay) > 0)
                            {
                                if (respo != null)
                                {
                                    //string nomresp = respo.Substring(0, respo.IndexOf(' '));
                                    string[] detailresp = respo.Split('-');
                                    string nomresp = detailresp[0].Trim();
                                    string prenomresp = detailresp[1].Trim();
                                    string telresp = detailresp[2].Trim();
                                    long socID = emp.SocieteID;

                                    List<Employes> donneesResp = EmployesModel.AfficherParDetailResponsable(socID, nomresp, prenomresp, telresp);
                                    foreach (Employes p in donneesResp)
                                    {
                                        string mailres = p.Email;
                                        string msg = string.Format(Logics.ConstanteNotification.msg_retard_emp, nom, heure.TimeOfDay, heure.Date);
                                        Mailling.EnvoyerMailAvecCopie(Mapping.MailConfig, msg, Logics.ConstanteNotification.obj_retard, new List<string>() { mail, mailres }, null);
                                    }

                                    //string url = string.Format("{0}", Mapping.url_user);
                                }
                                else
                                {
                                    string msg = string.Format(Logics.ConstanteNotification.msg_retard_emp, nom, heure.TimeOfDay, heure.Date);
                                    Mailling.EnvoyerMailAvecCopie(Mapping.MailConfig, msg, Logics.ConstanteNotification.obj_retard, new List<string>() { mail }, null);
                                }
                            }

                        }

                    }

                _db.Pointage.Add(pointage);
                _db.SaveChanges();
            }

        }


        //public static void GetAbsenceJour(long id)
        //{

        //    using (PointisEntities _db = new PointisEntities())
        //    {

        //        DateTime now = DateTime.Now;
        //        DateTime Jour = now.Date;

        //        var donnees = (from e in _db.Employes
        //                       where !_db.Pointage.Any(p => p.EmployesID == e.EmployeID && p.Jour == Jour) && e.SocieteID == id
        //                       select e).ToList();


        //        foreach (Employes employes in donnees)
        //        {
        //            string mail = employes.Email;
        //            string nom = employes.Prenom + " " + employes.Nom;
        //            string respo = employes.Responsable;

        //            string msg = string.Format(Logics.ConstanteNotification.msg_absence, nom);
        //            Mailling.EnvoyerMailAvecCopie(Mapping.MailConfig, msg, Logics.ConstanteNotification.obj_absence, new List<string>() { mail }, null);
        //            //}

        //        }

        //        GetAbsenceJourResponsable(id);

        //        //return donnees;
        //    }
        //}



        public static List<Employes> GetAbsenceJour(long id)
        {

            using (PointisEntities _db = new PointisEntities())
            {

                DateTime now = DateTime.Now;
                DateTime Jour = now.Date;

                var donnees = (from e in _db.Employes
                               where !_db.Pointage.Any(p => p.EmployesID == e.EmployeID && p.Jour == Jour) && e.SocieteID == id
                               select e).ToList();

                //var donnees = (from e in _db.Employes
                //               where !_db.Pointage.Any(p => p.EmployesID == e.EmployeID && p.Jour == Jour) && e.SocieteID == id
                //               select e).GroupBy(p => p.Responsable).ToList();


                foreach (Employes employes in donnees)
                {
                    string mail = employes.Email;
                    string nom = employes.Prenom + " " + employes.Nom;
                    string respo = employes.Responsable;
                    //if (respo != null)
                    //{
                    //    string[] detailresp = respo.Split('-');
                    //    string nomresp = detailresp[0].Trim();
                    //    string prenomresp = detailresp[1].Trim();
                    //    string telresp = detailresp[2].Trim();
                    //    long socID = employes.SocieteID;

                    //    List<Employes> donneesResp = EmployesModel.AfficherParDetailResponsable(socID, nomresp, prenomresp, telresp);
                    //    foreach (Employes p in donneesResp)
                    //    {
                    //        string mailres = p.Email;
                    //        string msg = string.Format(Logics.ConstanteNotification.msg_absence, nom);
                    //        Mailling.EnvoyerMailAvecCopie(Mapping.MailConfig, msg, Logics.ConstanteNotification.obj_absence, new List<string>() { mail, mailres }, null);
                    //    }
                    //}
                    //else
                    //{
                    string msg = string.Format(Logics.ConstanteNotification.msg_absence, nom);
                    Mailling.EnvoyerMailAvecCopie(Mapping.MailConfig, msg, Logics.ConstanteNotification.obj_absence, new List<string>() { mail }, null);
                    //}

                }

                GetAbsenceJourResponsable(id);

                return donnees;
            }
        }

        public static List<RespModel> GetAbsenceJourResponsable(long id)
        {

            using (PointisEntities _db = new PointisEntities())
            {

                DateTime now = DateTime.Now;
                DateTime Jour = now.Date;

                var donnees = (from e in _db.Employes
                               where !_db.Pointage.Any(p => p.EmployesID == e.EmployeID && p.Jour == Jour) && e.SocieteID == id
                               group e by e.Responsable into g
                               select new RespModel
                               {
                                   Responsable = g.Key,
                                   Employes = g.ToList()
                               }).ToList();

                foreach (var responsable in donnees)
                {
                    string[] detailresp = responsable.Responsable.Split('-');
                    string nomresp = detailresp[0].Trim();
                    string prenomresp = detailresp[1].Trim();
                    string telresp = detailresp[2].Trim();
                    string mailres = "";
                    int compter = 0;

                    string msg = string.Format(Logics.ConstanteNotification.msg_absence_responsable, nomresp);
                    foreach (var employe in responsable.Employes)
                    {
                        long socID = employe.SocieteID;

                        List<Employes> donneesResp = EmployesModel.AfficherParDetailResponsable(socID, nomresp, prenomresp, telresp);
                        foreach (Employes p in donneesResp)
                        {
                            mailres = p.Email;
                            compter++;
                            msg += string.Format("{0}- {1} {2} {3}<br/>", compter, employe.Matricule, employe.Prenom, employe.Nom);
                        }
                    }
                    Mailling.EnvoyerMailAvecCopie(Mapping.MailConfig, msg, Logics.ConstanteNotification.obj_absence, new List<string>() { mailres }, null);
                }

                return donnees;
            }
        }


        public static void Modifier(long id, Pointage pointage)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Pointage> donnees = (from p in _db.Pointage
                                          where p.PointageID == id
                                          select p).ToList();

                foreach (Pointage point in donnees)
                {
                    point.Jour = point.Jour;
                    point.HeureEntree = point.HeureEntree;
                    point.HeureSortie = pointage.HeureSortie;
                    point.EmployesID = point.EmployesID;
                    point.Imei_employe_entree = point.Imei_employe_entree;
                    point.Imei_employe_sortie = point.Imei_employe_entree;
                    point.latitude_entree = point.latitude_entree;
                    point.latitude_sortie = pointage.latitude_sortie;
                    point.longitude_entree = point.longitude_entree;
                    point.longitude_sortie = pointage.longitude_sortie;


                    _db.SaveChanges();
                }

                
            }
        }

        public static void supprimer(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Pointage> donnees = (from p in _db.Pointage
                                          where p.PointageID == id
                                          select p).ToList();

                _db.Pointage.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }

        public static int NombreEntree(long id)
        {
            using(PointisEntities _db = new PointisEntities())
            {
                int compte = 0;
                DateTime now = DateTime.Today;
                List<Pointage> pointages = (from p in _db.Pointage where p.HeureEntree != null && p.Jour ==now && p.EmployesID == id select p).ToList();
                if(pointages.Count > 0)
                {
                    return compte = pointages.Count;
                }
                return compte;
            }
        }

        public static long EntreeSemaine(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= debutDeLaSemaine && d.PointageJour <= finDeLaSemaine && d.PointageHeureEntree != null && d.EmployeID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long EntreeMois(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime now = DateTime.Today;

                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.PointageHeureEntree != null && d.EmployeID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long EntreeTrimestre(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime now = DateTime.Today;

                DateTime startOfMonth = GetDebutTrimestreEnCours();

                DateTime endOfMonth = GetFinTrimestreEnCours();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.PointageHeureEntree != null && d.EmployeID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long EntreeAnnee(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime now = DateTime.Today;

                DateTime startOfMonth = GetDebutAnneeEnCours();

                DateTime endOfMonth = GetFinAnneeEnCours();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.PointageHeureEntree != null && d.EmployeID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long NombreSortie(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long compte = 0;
                DateTime now = DateTime.Today;
                List<Pointage> pointages = (from p in _db.Pointage where p.HeureSortie.Value !=null && p.Jour == now && p.EmployesID == id select p).ToList();
                if (pointages.Count > 0)
                {
                    return compte = pointages.Count;
                }
                return compte;
            }
        }

        public static long SortieSemaine(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= debutDeLaSemaine && d.PointageJour <= finDeLaSemaine && d.EmployeID == id && d.PointageHeureSortie.Value!=null).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long SortieMois(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime now = DateTime.Today;

                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.PointageHeureSortie.Value != null && d.EmployeID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static int In(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                int compte = 0;
                DateTime now = DateTime.Today;
                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.PointageHeureEntree != null && p.PointageJour == now && p.SocieteID == id select p).ToList();
                if (pointages.Count > 0)
                {
                    return compte = pointages.Count;
                }
                return compte;
            }
        }

        public static long InWeek(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= debutDeLaSemaine && d.PointageJour <= finDeLaSemaine && d.PointageHeureEntree != null && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long InMonth(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime now = DateTime.Today;

                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.PointageHeureEntree != null && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long InQuarter(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime now = DateTime.Today;

                DateTime startOfMonth = GetDebutTrimestreEnCours();

                DateTime endOfMonth = GetFinTrimestreEnCours();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.PointageHeureEntree != null && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long InYear(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime now = DateTime.Today;

                DateTime startOfMonth = GetDebutAnneeEnCours();

                DateTime endOfMonth = GetFinAnneeEnCours();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.PointageHeureEntree != null && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }


        public static long Out(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long compte = 0;
                DateTime now = DateTime.Today;
                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.PointageHeureSortie != null && p.PointageJour == now && p.SocieteID == id select p).ToList();
                if (pointages.Count > 0)
                {
                    return compte = pointages.Count;
                }
                return compte;
            }
        }

        public static long OutWeek(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= debutDeLaSemaine && d.PointageJour <= finDeLaSemaine && d.SocieteID == id && d.PointageHeureSortie.Value != null).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long OutMonth(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime now = DateTime.Today;

                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);

                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.PointageHeureSortie.Value != null && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long OutQuarter(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime now = DateTime.Today;

                DateTime startOfMonth = GetDebutTrimestreEnCours();

                DateTime endOfMonth = GetFinTrimestreEnCours();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.PointageHeureSortie.Value != null && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static long OutYear(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                long ident = 0;
                DateTime now = DateTime.Today;

                DateTime startOfMonth = GetDebutAnneeEnCours();

                DateTime endOfMonth = GetFinAnneeEnCours();

                List<V_Pointage> donnees = _db.V_Pointage.Where(d => d.PointageJour >= startOfMonth && d.PointageJour <= endOfMonth && d.PointageHeureSortie.Value != null && d.SocieteID == id).OrderByDescending(d => d.PointageID).ToList();

                if (donnees.Count > 0)
                {
                    return ident = donnees.Count;
                }
                return ident;
            }
        }

        public static double NombreRetardJour(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                
                DateTime now = DateTime.Now.Date;
                string date = "";
                DateTime dat = new DateTime();
                double retard = 0;



                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.EmployeID == id && p.PointageJour == now select p).ToList();
                

                if(pointages.Count > 0 )
                {
                    foreach(V_Pointage pointage in pointages)
                    {
                        try
                        {
                            var recup = pointage.EquipeHeureDebut.Split('h');
                            string heure = recup[0] + ":" + recup[1];
                            dat = pointage.PointageJour.Value;


                            dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));

                            
                            if (pointage.PointageHeureEntree > dat)
                            {
                                retard = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                return retard;
                            }
                            else
                            {
                                return retard;
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static double NombreRetardRespoJour(long id, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime now = DateTime.Now.Date;
                string date = "";
                DateTime dat = new DateTime();
                double retard = 0;
                string famille = prenom + " " + nom;


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour == now && p.EmployeResponsable == famille select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            var recup = pointage.EquipeHeureDebut.Split('h');
                            string heure = recup[0] + ":" + recup[1];
                            dat = pointage.PointageJour.Value;


                            dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                            if (pointage.PointageHeureEntree > dat)
                            {
                                retard = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                return retard;
                            }
                            else
                            {
                                return retard;
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static double NombreRetardRespoSem(long id, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);
                string date = "";
                DateTime dat = new DateTime();
                double retard = 0;
                string famille = prenom + " " + nom;


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour >= debutDeLaSemaine && p.PointageJour <= finDeLaSemaine && p.EmployeResponsable == famille select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            var recup = pointage.EquipeHeureDebut.Split('h');
                            string heure = recup[0] + ":" + recup[1];
                            dat = pointage.PointageJour.Value;


                            dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                            if (pointage.PointageHeureEntree > dat)
                            {
                                retard = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                return retard;
                            }
                            else
                            {
                                return retard;
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static double NombreRetardMoisRespo(long id, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                DateTime now = DateTime.Today;
                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                double retard = 0;
                DateTime dat = new DateTime();
                string famille = prenom + " " + nom;


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour >= startOfMonth && p.PointageJour <= endOfMonth && p.EmployeResponsable == famille select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static double NombreRetardTrimestreRespo(long id, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                DateTime now = DateTime.Today;
                double retard = 0;
                DateTime dat = new DateTime();
                string famille = prenom + " " + nom;

                DateTime debutTrimestreEnCours = GetDebutTrimestreEnCours();
                DateTime finTrimestreEnCours = GetFinTrimestreEnCours();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour >= debutTrimestreEnCours && p.PointageJour <= finTrimestreEnCours && p.EmployeResponsable == famille select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }


        public static double NombreRetardAnneeRespo(long id, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                DateTime now = DateTime.Today;
                double retard = 0;
                DateTime dat = new DateTime();
                string famille = prenom + " " + nom;

                DateTime debutAnneeEnCours = GetDebutAnneeEnCours();
                DateTime finAnneeEnCours = GetFinAnneeEnCours();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour >= debutAnneeEnCours && p.PointageJour <= finAnneeEnCours && p.EmployeResponsable == famille select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }


        public static double NombreRetardSemaine(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);
                double retard = 0;
                DateTime dat = new DateTime();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.EmployeID == id && p.PointageJour >= debutDeLaSemaine && p.PointageJour <= finDeLaSemaine select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                    //return retard;
                                }
                            }

                            /*DayOfWeek jourActuel = DateTime.Now.DayOfWeek;
                            string[] joursSemaine = { "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi", "dimanche" };

                            for (int i = 0; i <= (int)jourActuel; i++)
                            {
                                string jour = joursSemaine[i];
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];

                            }*/

                            /*var recup = pointage.EquipeHeureDebut.Split('h');
                            string heure = recup[0] + ":" + recup[1];
                            dat = pointage.PointageJour.Date;


                            dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                            if (pointage.PointageHeureEntree > dat)
                            {
                                double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                retard += ret;
                                //return retard;
                            }
                            /*else
                            {
                                return retard;
                            }*/
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static double NombreRetardMois(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                DateTime now = DateTime.Today;
                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                double retard = 0;
                DateTime dat = new DateTime();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.EmployeID == id && p.PointageJour >= startOfMonth && p.PointageJour <= endOfMonth select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static double NombreRetardTrimestre(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                DateTime now = DateTime.Today;
                double retard = 0;
                DateTime dat = new DateTime();

                DateTime debutTrimestreEnCours = GetDebutTrimestreEnCours();
                DateTime finTrimestreEnCours = GetFinTrimestreEnCours();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.EmployeID == id && p.PointageJour >= debutTrimestreEnCours && p.PointageJour <= finTrimestreEnCours select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static double NombreRetardAnnee(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                DateTime now = DateTime.Today;
                double retard = 0;
                DateTime dat = new DateTime();

                DateTime debutAnneeEnCours = GetDebutAnneeEnCours();
                DateTime finAnneeEnCours = GetFinAnneeEnCours();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.EmployeID == id && p.PointageJour >= debutAnneeEnCours && p.PointageJour <= finAnneeEnCours select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }


        public static double late(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime now = DateTime.Today;
                string date = "";
                DateTime dat = new DateTime();
                double retard = 0;



                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour == now select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            var recup = pointage.EquipeHeureDebut.Split('h');
                            string heure = recup[0] + ":" + recup[1];
                            dat = pointage.PointageJour.Value;


                            dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                            if (pointage.PointageHeureEntree > dat)
                            {
                                double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                retard += ret;
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static double lateByDate(DateTime dateJ ,long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                //DateTime now = DateTime.Today;
                string date = "";
                DateTime dat = new DateTime();
                double retard = 0;



                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour == dateJ select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            var recup = pointage.EquipeHeureDebut.Split('h');
                            string heure = recup[0] + ":" + recup[1];
                            dat = pointage.PointageJour.Value;


                            dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                            if (pointage.PointageHeureEntree > dat)
                            {
                                double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                retard += ret;
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static List<Retard> lateDateH(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime now = DateTime.Now.Date;
                string date = "";
                DateTime dat = new DateTime();
                double retard = 0;
                string currentDay = DateTime.Now.ToString("dddd");

                List<Retard> retards = new List<Retard>();

                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour == now select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            var recup = pointage.EquipeHeureDebut.Split('h');
                            string heure = recup[0] + ":" + recup[1];
                            dat = pointage.PointageJour.Value;


                            dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                            if (pointage.PointageHeureEntree > dat)
                            {
                                double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                retard += ret;
                                //return retard;
                            }
                            /*else
                            {
                                return retard;
                            }*/
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }

                Retard retard1 = new Retard()
                {
                    Day = currentDay,
                    TotalHours = retard
                };

                retards.Add(retard1);

                return retards;
            }
        }

        public static double lateWeek(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);
                double retard = 0;
                DateTime dat = new DateTime();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour >= debutDeLaSemaine && p.PointageJour <= finDeLaSemaine select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if(pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public List<Retard> lateDateWeek(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);
                double retard = 0;
                DateTime dat = new DateTime();

                List<Retard> retards = new List<Retard>();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour >= debutDeLaSemaine && p.PointageJour <= finDeLaSemaine select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                    //return retard;
                                }
                            }

                            /*DayOfWeek jourActuel = DateTime.Now.DayOfWeek;
                            string[] joursSemaine = { "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi", "dimanche" };

                            for (int i = 0; i <= (int)jourActuel; i++)
                            {
                                string jour = joursSemaine[i];
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];

                            }*/

                            /*var recup = pointage.EquipeHeureDebut.Split('h');
                            string heure = recup[0] + ":" + recup[1];
                            dat = pointage.PointageJour.Date;


                            dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                            if (pointage.PointageHeureEntree > dat)
                            {
                                double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                retard += ret;
                                //return retard;
                            }
                            /*else
                            {
                                return retard;
                            }*/
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retards;
            }
        }

        public static double lateMounth(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime dateDuJour = DateTime.Today;
                DateTime now = DateTime.Today;
                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                double retard = 0;
                DateTime dat = new DateTime();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour >= startOfMonth && p.PointageJour <= endOfMonth select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static double lateTrimestre(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime dateDuJour = DateTime.Today;
                DateTime now = DateTime.Today;
                double retard = 0;
                DateTime dat = new DateTime();

                DateTime debutTrimestreEnCours = GetDebutTrimestreEnCours();

                DateTime finTrimestreEnCours = GetFinTrimestreEnCours();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour >= debutTrimestreEnCours && p.PointageJour <= finTrimestreEnCours select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static double lateAnnee(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {

                DateTime dateDuJour = DateTime.Today;
                DateTime now = DateTime.Today;
                double retard = 0;
                DateTime dat = new DateTime();

                DateTime debutAnneeEnCours = GetDebutAnneeEnCours();
                DateTime finAnneeEnCours = GetFinAnneeEnCours();


                List<V_Pointage> pointages = (from p in _db.V_Pointage where p.SocieteID == id && p.PointageJour >= debutAnneeEnCours && p.PointageJour <= finAnneeEnCours select p).ToList();


                if (pointages.Count > 0)
                {
                    foreach (V_Pointage pointage in pointages)
                    {
                        try
                        {
                            if (pointage.PointageJour <= dateDuJour)
                            {
                                var recup = pointage.EquipeHeureDebut.Split('h');
                                string heure = recup[0] + ":" + recup[1];
                                dat = pointage.PointageJour.Value;

                                dat = dat.Add(TimeSpan.ParseExact(heure, "hh\\:mm", CultureInfo.InvariantCulture));


                                if (pointage.PointageHeureEntree > dat)
                                {
                                    double ret = (pointage.PointageHeureEntree - dat).TotalMinutes;
                                    retard += ret;
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
                return retard;
            }
        }

        public static List<V_Pointage> SearchPointage(long id, DateTime datedebut, DateTime datefin)
        {
            using(PointisEntities _db = new PointisEntities())
            {
                List<V_Pointage> donnees = (from f in _db.V_Pointage where f.EmployeID == id && f.PointageJour >= datedebut && f.PointageJour <= datefin select f).OrderByDescending(f => f.PointageID).ToList();
                return donnees;
            }
        }

        public static List<V_Pointage> SearchPointageStart(long id, DateTime datedebut)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime jour = DateTime.Today;
                List<V_Pointage> donnees = (from f in _db.V_Pointage where f.EmployeID == id && f.PointageJour >= datedebut && f.PointageJour <= jour select f).OrderByDescending(f => f.PointageID).ToList();
                return donnees;
            }
        }

        public static List<V_Pointage> SearchPointageEnd(long id, DateTime datefin)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                //DateTime jour = DateTime.Today;
                var oldestDate = _db.V_Pointage.Min(data => data.PointageJour);
                List<V_Pointage> donnees = (from f in _db.V_Pointage where f.EmployeID == id && f.PointageJour >= oldestDate && f.PointageJour <= datefin select f).OrderByDescending(f => f.PointageID).ToList();
                return donnees;
            }
        }

        public static List<V_Pointage> SearchPoint(long id, DateTime datedebut, DateTime datefin)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<V_Pointage> donnees = (from f in _db.V_Pointage where f.SocieteID == id && f.PointageJour >= datedebut && f.PointageJour <= datefin select f).OrderByDescending(f => f.PointageID).ToList();
                return donnees;
            }
        }

        public static List<V_Pointage> SearchPointStart(long id, DateTime datedebut)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime jour = DateTime.Today;
                List<V_Pointage> donnees = (from f in _db.V_Pointage where f.SocieteID == id && f.PointageJour >= datedebut && f.PointageJour <= jour select f).OrderByDescending(f => f.PointageID).ToList();
                return donnees;
            }
        }

        public static List<V_Pointage> SearchPointEnd(long id, DateTime datefin)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                //DateTime jour = DateTime.Today;
                var oldestDate = _db.V_Pointage.Min(data => data.PointageJour);
                List<V_Pointage> donnees = (from f in _db.V_Pointage where f.SocieteID == id && f.PointageJour >= oldestDate && f.PointageJour <= datefin select f).OrderByDescending(f => f.PointageID).ToList();
                return donnees;
            }
        }

        public static List<V_Pointage> AfficherParResponsablePointage(long idSoc, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                string famille = prenom + " " + nom;

                List<V_Pointage> donnees = (from p in _db.V_Pointage
                                          where p.SocieteID == idSoc && p.EmployeResponsable == famille && p.PointageHeureEntree != null
                                            select p).ToList();
                return donnees;
            }
        }

        public static List<V_Pointage> AfficherParResponsablePointageJour(long idSoc, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime now = DateTime.Today;
                string famille = prenom + " " + nom;

                List<V_Pointage> donnees = (from p in _db.V_Pointage
                                            where p.SocieteID == idSoc && p.PointageJour == now && p.EmployeResponsable == famille
                                            select p).ToList();
                return donnees;
            }
        }

        public static List<V_Pointage> AfficherParResponsablePointageSemaine(long idSoc, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                DateTime dateDuJour = DateTime.Today;
                int delta = DayOfWeek.Monday - dateDuJour.DayOfWeek;
                DateTime debutDeLaSemaine = dateDuJour.AddDays(delta);
                DateTime finDeLaSemaine = debutDeLaSemaine.AddDays(6);
                string famille = prenom + " " + nom;

                List<V_Pointage> donnees = (from p in _db.V_Pointage
                                            where p.SocieteID == idSoc && p.PointageJour >= debutDeLaSemaine && p.PointageJour <= finDeLaSemaine && p.EmployeResponsable == famille
                                            select p).ToList();
                return donnees;
            }
        }

        public static List<V_Pointage> AfficherParResponsablePointageMois(long idSoc, string nom, string prenom)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                string famille = prenom + " " + nom;

                DateTime now = DateTime.Today;
                DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);
                DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                List<V_Pointage> donnees = (from p in _db.V_Pointage
                                            where p.SocieteID == idSoc && p.PointageJour >= startOfMonth && p.PointageJour <= endOfMonth && p.EmployeResponsable == famille
                                            select p).ToList();
                return donnees;
            }
        }
    }
}