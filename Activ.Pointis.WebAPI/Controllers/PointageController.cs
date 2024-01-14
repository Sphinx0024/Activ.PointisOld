using Activ.Pointis.WebAPI.Models;
using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Activ.Pointis.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //[Authorize]
    [RoutePrefix("api/Pointage")]
    public class PointageController : ApiController
    {
        // GET: api/Pointage
        [HttpGet]
       
        public IEnumerable<V_Pointage> Get(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.afficher(id);
        }

        // GET: api/Pointage/5
        [HttpGet]
        [ActionName("GetUn")]
        public IEnumerable<V_Pointage> GetUn(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.AfficherUnSeul(id);
        }
        

        [HttpGet]
        [ActionName("GetAbsenceJour")]
        public IEnumerable<Employes> GetAbsenceJour(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.GetAbsenceJour(id);
        }

        [HttpGet]
        [ActionName("GetAbsenceJourEmployesParSociete")]
        public IEnumerable<Employes> GetAbsenceJourEmployesParSociete(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.GetAbsenceJourEmployesParSociete(id);
        }

        //[HttpGet]
        //[ActionName("GetAbsenceSemaineEmployesParSociete")]
        //public IEnumerable<Employes> GetAbsenceSemaineEmployesParSociete(long id)
        //{
        //    return PointageModel.GetAbsenceSemaineEmployesParSociete(id);
        //}

        [HttpGet]
        [ActionName("GetAbsenceSemaineEmployesParResponsable")]
        public IEnumerable<RespModel> GetAbsenceSemaineEmployesParResponsable(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.GetAbsenceSemaineEmployesParResponsable(id);
        }

        [HttpGet]
        [ActionName("RappelPointageSortie")]
        public IEnumerable<Employes> RappelPointageSortie(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.RappelPointageSortie(id);
        }

        //[HttpGet]
        //[ActionName("GetAbsenceJour")]
        //public void GetAbsenceJour(long id)
        //{
        //    PointageModel.GetAbsenceJour(id);
        //}


        //[HttpGet]
        //[ActionName("GetAbsenceJourResponsable")]
        //public IEnumerable<ResponsableModel> GetAbsenceJourResponsable(long id)
        //{
        //    return PointageModel.GetAbsenceJourResponsable(id);
        //}

        // GET: api/Employes/5
        [HttpGet]
        [ActionName("GetRespoPoint")]
        public List<V_Pointage> AfficherParResponsablePointage([FromUri] long id, [FromUri] string nom, [FromUri] string prenom)
        {
            PointageModel.RappelAbsence();
            return PointageModel.AfficherParResponsablePointage(id, nom, prenom);
        }

        [HttpGet]
        [ActionName("GetRespoPointJour")]
        public List<V_Pointage> AfficherParResponsablePointageJour([FromUri] long id, [FromUri] string nom, [FromUri] string prenom)
        {
            PointageModel.RappelAbsence();
            return PointageModel.AfficherParResponsablePointageJour(id, nom, prenom);
        }

        [HttpGet]
        [ActionName("GetRespoPointSem")]
        public List<V_Pointage> AfficherParResponsablePointageSemaine([FromUri] long id, [FromUri] string nom, [FromUri] string prenom)
        {
            PointageModel.RappelAbsence();
            return PointageModel.AfficherParResponsablePointageSemaine(id, nom, prenom);
        }

        [HttpGet]
        [ActionName("GetRespoPointMois")]
        public List<V_Pointage> AfficherParResponsablePointageMois([FromUri] long id, [FromUri] string nom, [FromUri] string prenom)
        {
            PointageModel.RappelAbsence();
            return PointageModel.AfficherParResponsablePointageMois(id, nom, prenom);
        }

        // GET: api/Employes/5
        [HttpGet]
        [ActionName("GetRetardJourRespo")]
        public IHttpActionResult NombreRetardRespoJour([FromUri] long id, [FromUri] string nom, [FromUri] string prenom)
        {
            PointageModel.RappelAbsence();
            double ret = PointageModel.NombreRetardRespoJour(id, nom, prenom);
            return Ok(ret);
        }

        [HttpGet]
        [ActionName("GetRetardSemRespo")]
        public IHttpActionResult NombreRetardRespoSem([FromUri] long id, [FromUri] string nom, [FromUri] string prenom)
        {
            PointageModel.RappelAbsence();
            double ret = PointageModel.NombreRetardRespoSem(id, nom, prenom);
            return Ok(ret);
        }

        [HttpGet]
        [ActionName("GetRetardMoisRespo")]
        public IHttpActionResult NombreRetardRespoMois([FromUri] long id, [FromUri] string nom, [FromUri] string prenom)
        {
            PointageModel.RappelAbsence();
            double ret = PointageModel.NombreRetardMoisRespo(id, nom, prenom);
            return Ok(ret);
        }

        [HttpGet]
        [Route("Point/{id}")] 
        public IHttpActionResult Point(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.Point(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("Day/{id}")]
        public IEnumerable<V_Pointage> Day(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.Day(id);
        }

        [HttpGet]
        [Route("DayTwenty/{id}")]
        public IEnumerable<V_Pointage> DayTwenty(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.DayTwenty(id);
        }

        [HttpGet]
        [Route("Week/{id}")]
        public IEnumerable<V_Pointage> Week(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.Week(id);
        }

        [HttpGet]
        [Route("Month/{id}")]
        public IEnumerable<V_Pointage> Mounth(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.Mounth(id);
        }

        [HttpGet]
        [Route("Quarter/{id}")]
        public IEnumerable<V_Pointage> Quarter(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.Quarter(id);
        }

        [HttpGet]
        [Route("Year/{id}")]
        public IEnumerable<V_Pointage> Year(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.Year(id);
        }

        [HttpGet]
        [Route("Jour/{id}")]
        public IEnumerable<V_Pointage> Jour(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.Jour(id);
        }

        [HttpGet]
        [Route("AbsenceJour/{id}")]
        /*public IEnumerable<V_Pointage> AbsenceJour(long id)
        {
            return PointageModel.AbsenceJour(id);
        }*/
        public long AbsenceJour(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.AbsenceJourEmp(id);
        }

       
        public List<Absence> AbsenceJourSoc(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.AbsenceJourSoc(id);
        }

        [HttpGet]
        [Route("Semaine/{id}")]
        public IEnumerable<V_Pointage> Semaine(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.Semaine(id);
        }

        [HttpGet]
        [Route("Mois/{id}")]
        public IEnumerable<V_Pointage> Mois(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.Mois(id);
        }

        [HttpGet]
        [Route("Trimestre/{id}")]
        public IEnumerable<V_Pointage> Trimestre(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.Trimestre(id);
        }

        [HttpGet]
        [Route("Annee/{id}")]
        public IEnumerable<V_Pointage> Annee(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.Annee(id);
        }

        [HttpGet]
        [Route("AbsenceMois/{id}")]
        public IEnumerable<V_Pointage> AbsenceMois(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.AbsenceMois(id);
        }

        // POST: api/Pointage
        [HttpPost]
        public void Post([FromBody]Pointage pointage)
        //public void Post()
        {
            PointageModel.RappelAbsence();
            PointageModel.Ajouter(pointage);
            //PointageModel.Ajouter(pointage);
        }

        // POST: api/Pointage
        
        [ActionName("AjouterAutomatique")]
        public void AjouterAutomatique([FromBody] Pointage pointage)
        //public void Post()
        {
            PointageModel.RappelAbsence();
            PointageModel.AjouterAutomatique();
            //PointageModel.AjouterAutomatique(pointage);
            //PointageModel.Ajouter(pointage);
        }

        [HttpGet]
        [Route("Entree/{id}")]
        public IHttpActionResult Entree(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.NombreEntree(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("EntreeSemaine/{id}")]
        public IHttpActionResult EntreeSemaine(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.EntreeSemaine(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("EntreeMois/{id}")]
        public IHttpActionResult EntreeMois(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.EntreeMois(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("EntreeTrimestre/{id}")]
        public IHttpActionResult EntreeTrimestre(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.EntreeTrimestre(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("EntreeAnnee/{id}")]
        public IHttpActionResult EntreeAnnee(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.EntreeAnnee(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("In/{id}")]
        public IHttpActionResult In(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.In(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("InWeek/{id}")]
        public IHttpActionResult InWeek(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.InWeek(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("InMonth/{id}")]
        public IHttpActionResult InMonth(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.InMonth(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("InQuarter/{id}")]
        public IHttpActionResult InQuarter(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.InQuarter(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("InYear/{id}")]
        public IHttpActionResult InYear(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.InYear(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("Out/{id}")]
        public IHttpActionResult Out(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.Out(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("OutWeek/{id}")]
        public IHttpActionResult OutWeek(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.OutWeek(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("OutMonth/{id}")]
        public IHttpActionResult OutMonth(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.OutMonth(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("Sortie/{id}")]
        public IHttpActionResult Sortie(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.NombreSortie(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("SortieSemaine/{id}")]
        public IHttpActionResult SortieSemaine(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.SortieSemaine(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("SortieMois/{id}")]
        public IHttpActionResult SortieMois(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.SortieMois(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("Missing/{id}")]
        public IHttpActionResult Missing(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.Missing(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingWeek/{id}")]
        public IHttpActionResult MissingWeek(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingWeek(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingMonth/{id}")]
        public IHttpActionResult MissingMonth(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingMonth(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingQuarter/{id}")]
        public IHttpActionResult MissingQuarter(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingQuarter(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingYear/{id}")]
        public IHttpActionResult MissingYear(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingYear(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingJour/{id}")]
        public IHttpActionResult MissingJour(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingJour(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingSemaine/{id}")]
        public IHttpActionResult MissingSemaine(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingSemaine(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingMois/{id}")]
        public IHttpActionResult MissingMois(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingMois(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingTrimestre/{id}")]
        public IHttpActionResult MissingTrimestre(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingTrimestre(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingAnnee/{id}")]
        public IHttpActionResult MissingAnnee(long id)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingAnnee(id);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingEquipJour")]
        public IHttpActionResult MissingEquipJour(long id, string nom, string prenom)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingEquipJour(id, nom, prenom);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingEquipSem")]
        public IHttpActionResult MissingEquipSem(long id, string nom, string prenom)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingEquipSem(id, nom, prenom);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingEquipMois")]
        public IHttpActionResult MissingEquipMois(long id, string nom, string prenom)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingEquipMois(id, nom, prenom);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingEquipTrimestre")]
        public IHttpActionResult MissingEquipTrimestre(long id, string nom, string prenom)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingEquipTrimestre(id, nom, prenom);
            return Ok(ident);
        }

        [HttpGet]
        [Route("MissingEquipAnnee")]
        public IHttpActionResult MissingEquipAnnee(long id, string nom, string prenom)
        {
            PointageModel.RappelAbsence();
            long ident = PointageModel.MissingEquipAnnee(id, nom, prenom);
            return Ok(ident);
        }

        [HttpGet]
        [Route("RetardJour/{id}")]
        public IHttpActionResult RetardJour(long id)
        {
            PointageModel.RappelAbsence();
            double time = PointageModel.NombreRetardJour(id);
            return Ok(time);
        }

        [HttpGet]
        [Route("RetardSemaine/{id}")]
        public IHttpActionResult RetardSemaine(long id)
        {
            PointageModel.RappelAbsence();
            double time = PointageModel.NombreRetardSemaine(id);
            return Ok(time);
        }

        [HttpGet]
        [Route("RetardMois/{id}")]
        public IHttpActionResult RetardMois(long id)
        {
            PointageModel.RappelAbsence();
            double time = PointageModel.NombreRetardMois(id);
            return Ok(time);
        }

        [HttpGet]
        [Route("RetardTrimestre/{id}")]
        public IHttpActionResult RetardTrimestre(long id)
        {
            PointageModel.RappelAbsence();
            double time = PointageModel.NombreRetardTrimestre(id);
            return Ok(time);
        }

        [HttpGet]
        [Route("RetardAnnee/{id}")]
        public IHttpActionResult RetardAnnee(long id)
        {
            PointageModel.RappelAbsence();
            double time = PointageModel.NombreRetardAnnee(id);
            return Ok(time);
        }

        [HttpGet]
        [Route("Late/{id}")]
        public IHttpActionResult Late(long id)
        {
            PointageModel.RappelAbsence();
            double time = PointageModel.late(id);
            return Ok(time);
        }

        [HttpGet]
        [Route("LateDate/{id}")]
        public IHttpActionResult LateDate(long id)
        {
            PointageModel.RappelAbsence();
            List<Retard> Retard = PointageModel.lateDateH(id);
            return Ok(Retard);
        }

        [HttpGet]
        [Route("LateWeek/{id}")]
        public IHttpActionResult LateWeek(long id)
        {
            PointageModel.RappelAbsence();
            double time = PointageModel.lateWeek(id);
            return Ok(time);
        }

        [HttpGet]
        [Route("LateMonth/{id}")]
        public IHttpActionResult LateMounth(long id)
        {
            PointageModel.RappelAbsence();
            double time = PointageModel.lateMounth(id);
            return Ok(time);
        }

        [HttpGet]
        [Route("LateTrimestre/{id}")]
        public IHttpActionResult LateTrimestre(long id)
        {
            PointageModel.RappelAbsence();
            double time = PointageModel.lateTrimestre(id);
            return Ok(time);
        }

        [HttpGet]
        [Route("LateAnnee/{id}")]
        public IHttpActionResult LateAnnee(long id)
        {
            PointageModel.RappelAbsence();
            double time = PointageModel.lateAnnee(id);
            return Ok(time);
        }

        [HttpGet]
        [Route("SearchPointage/{id}/{datedebut}/{datefin}")]
        public List<V_Pointage> SearchPointage(long id, DateTime datedebut, DateTime datefin)
        {
            PointageModel.RappelAbsence();
            return PointageModel.SearchPointage(id, datedebut, datefin);
        }

        [HttpGet]
        [Route("SearchPointageStart/{id}/{datedebut}")]
        public List<V_Pointage> SearchPointageStart(long id, DateTime datedebut)
        {
            PointageModel.RappelAbsence();
            return PointageModel.SearchPointageStart(id, datedebut);
        }

        [HttpGet]
        [Route("SearchPointageEnd/{id}/{datefin}")]
        public List<V_Pointage> SearchPointageEnd(long id, DateTime datefin)
        {
            PointageModel.RappelAbsence();
            return PointageModel.SearchPointageEnd(id, datefin);
            
        }

        [HttpGet]
        [Route("SearchPoint/{id}/{datedebut}/{datefin}")]
        public List<V_Pointage> SearchPoint(long id, DateTime datedebut, DateTime datefin)
        {
            PointageModel.RappelAbsence();
            return PointageModel.SearchPoint(id, datedebut, datefin);
        }

        [HttpGet]
        [Route("SearchPointStart/{id}/{datedebut}")]
        public List<V_Pointage> SearchPointStart(long id, DateTime datedebut)
        {
            PointageModel.RappelAbsence();
            return PointageModel.SearchPointStart(id, datedebut);
        }

        [HttpGet]
        [Route("SearchPointEnd/{id}/{datefin}")]
        public List<V_Pointage> SearchPointEnd(long id, DateTime datefin)
        {
            PointageModel.RappelAbsence();
            return PointageModel.SearchPointEnd(id, datefin);

        }

        // PUT: api/Pointage/5
        [HttpPut]
        public void Put(long id, [FromBody] Pointage pointage)
        {
            PointageModel.RappelAbsence();
            PointageModel.Modifier(id, pointage);
        }

        [Route("Modifier/{id}")] 
        public IHttpActionResult Modifier(long id, [FromBody] Pointage pointage)
        {
            PointageModel.RappelAbsence();
            PointageModel.Modifier(id, pointage);
            return Ok();
        }

        [Route("ModifierEntrer/{id}")]
        public IHttpActionResult ModifierEntrer(long id, [FromBody] Pointage pointage)
        {
            PointageModel.RappelAbsence();
            PointageModel.ModifierEntrer(id, pointage);
            return Ok();
        }

        // DELETE: api/Pointage/5
        [HttpDelete]
        public void Delete(long id)
        {
            PointageModel.RappelAbsence();
            PointageModel.supprimer(id);
        }

        [HttpGet]
        [Route("reportWeek/{id}")]
        public List<Report> reportWeek(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.reportWeek(id);

        }

        [HttpGet]
        [Route("MissingList/{id}")]
        public List<Employes> MissingList(long id)
        {
            PointageModel.RappelAbsence();
            return PointageModel.MissingList(id);

        }
    }
}
