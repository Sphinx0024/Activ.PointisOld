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
    [RoutePrefix("api/EquipeTravail")]
    public class EquipeTravailController : ApiController
    {
        [HttpGet]
        [ActionName("Get")]
        // GET: api/Societe
        public IEnumerable<EquipeTravail> Get(long id)
        {
            PointageModel.RappelAbsence();
            return EquipeTravailModel.afficher(id);
        }

        [HttpGet]
        [ActionName("GetUn")]
        // GET: api/Societe/5
        public List<EquipeTravail> GetUn(int id)
        {
            PointageModel.RappelAbsence();
            return EquipeTravailModel.AfficherUnSeul(id);
        }

        [HttpGet]
        [Route("GetID/{id}/{entree}/{sortie}")]
        // GET: api/Societe/5
        public IHttpActionResult GetID(long id, string entree, string sortie)
        {
            PointageModel.RappelAbsence();
            long ident = EquipeTravailModel.AfficherId(id,entree,sortie);
            return Ok(ident);
        }

        [HttpPost]
        // POST: api/Societe
        public IHttpActionResult Post([FromBody] EquipeTravail equipeTravail)
        {
            PointageModel.RappelAbsence();
            long id = EquipeTravailModel.Ajouter(equipeTravail);
            return Ok(id);
        }

        [HttpPut]
        // PUT: api/Societe/5
        public void Put(long id, [FromBody] EquipeTravail equipeTravail)
        {
            PointageModel.RappelAbsence();
            EquipeTravailModel.Modifier(id, equipeTravail);
        }

        [HttpDelete]
        // DELETE: api/Societe/5
        public void Delete(long id)
        {
            PointageModel.RappelAbsence();
            EquipeTravailModel.supprimer(id);
        }
    }
}
