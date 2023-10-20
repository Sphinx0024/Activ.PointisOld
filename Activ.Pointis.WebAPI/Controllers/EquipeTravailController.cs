using Activ.Pointis.Data;
using Activ.Pointis.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Activ.Pointis.WebAPI.Controllers
{
    [RoutePrefix("api/EquipeTravail")]
    public class EquipeTravailController : ApiController
    {
        [HttpGet]
        // GET: api/Societe
        public IEnumerable<EquipeTravail> Get(long id)
        {
            return EquipeTravailModel.afficher(id);
        }

        [HttpGet]
        // GET: api/Societe/5
        public List<EquipeTravail> GetUn(int id)
        {
            return EquipeTravailModel.AfficherUnSeul(id);
        }

        [HttpGet]
        [Route("GetID/{id}/{entree}/{sortie}")]
        // GET: api/Societe/5
        public IHttpActionResult GetID(long id, string entree, string sortie)
        {
            long ident = EquipeTravailModel.AfficherId(id,entree,sortie);
            return Ok(ident);
        }

        [HttpPost]
        // POST: api/Societe
        public IHttpActionResult Post([FromBody] EquipeTravail equipeTravail)
        {
            long id = EquipeTravailModel.Ajouter(equipeTravail);
            return Ok(id);
        }

        [HttpPut]
        // PUT: api/Societe/5
        public void Put(long id, [FromBody] EquipeTravail equipeTravail)
        {
            EquipeTravailModel.Modifier(id, equipeTravail);
        }

        [HttpDelete]
        // DELETE: api/Societe/5
        public void Delete(long id)
        {
            EquipeTravailModel.supprimer(id);
        }
    }
}
