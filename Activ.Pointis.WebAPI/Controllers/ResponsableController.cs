using Activ.Pointis.Data;
using Activ.Pointis.WebAPI.Models;
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
    [RoutePrefix("api/Responsable")]
    public class ResponsableController : ApiController
    {
        [HttpGet]
        // GET: api/Societe
        public IEnumerable<Responsable> Get()
        {
            PointageModel.RappelAbsence();
            return ResponsableModel.afficher();
        }

        [HttpGet]
        // GET: api/Societe/5
        public List<Responsable> Get(int id)
        {
            PointageModel.RappelAbsence();
            return ResponsableModel.AfficherUnSeul(id);
        }

        [HttpGet]
        [ActionName("AfficherParResponsable")]
        // GET: api/Societe/5
        public List<Responsable> AfficherParResponsable(int id)
        {
            PointageModel.RappelAbsence();
            return ResponsableModel.AfficherParResponsable(id);
        }

        [HttpGet]
        [ActionName("AfficherParEmploye")]
        // GET: api/Societe/5
        public List<Responsable> AfficherParEmploye(int id)
        {
            PointageModel.RappelAbsence();
            return ResponsableModel.AfficherParEmploye(id);
        }

        [HttpPost]
        // POST: api/Societe
        public IHttpActionResult Post([FromBody] Responsable responsable)
        {
            PointageModel.RappelAbsence();
            long id = ResponsableModel.Ajouter(responsable);
            return Ok(id);
        }

        [HttpPut]
        // PUT: api/Societe/5
        public void Put(long id, [FromBody] Responsable responsable)
        {
            PointageModel.RappelAbsence();
            ResponsableModel.Modifier(id, responsable);
        }

        [HttpDelete]
        // DELETE: api/Societe/5
        public void Delete(long id)
        {
            PointageModel.RappelAbsence();
            ResponsableModel.supprimer(id);
        }

    }
}
