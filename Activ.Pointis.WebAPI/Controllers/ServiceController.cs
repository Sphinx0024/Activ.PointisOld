using Activ.Pointis.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Timers;
using System.Web.Http;

namespace Activ.Pointis.WebAPI.Controllers
{
    public class ServiceController : ApiController
    {
        private Timer timer;

        public void DemarrerService()
        {
            // Définir l'heure à laquelle vous souhaitez exécuter l'action chaque jour
            DateTime heureExecution = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0); // Exemple : 12:00 PM

            // Calculer le délai jusqu'à la prochaine exécution
            TimeSpan tempsRestant = heureExecution - DateTime.Now;
            if (tempsRestant < TimeSpan.Zero)
            {
                tempsRestant = TimeSpan.FromHours(24) + tempsRestant; // Si l'heure est déjà passée aujourd'hui, programmer pour demain à la même heure
            }

            // Créer un minuteur pour exécuter l'action chaque jour à la même heure
            timer = new Timer(tempsRestant.TotalMilliseconds);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PointageModel.GetAbsenceJour(id);

            // Mettez ici le code de l'action que vous souhaitez exécuter
            Console.WriteLine("Action exécutée à l'heure spécifiée !");

            // Réinitialiser le minuteur pour la prochaine exécution quotidienne
            timer.Interval = TimeSpan.FromHours(24).TotalMilliseconds;
        }

        public void ArreterService()
        {
            // Arrêter le minuteur si nécessaire
            timer?.Stop();
            timer?.Dispose();
        }
    }
}
