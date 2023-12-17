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
    [RoutePrefix("api/SiteTravail")]
    public class SiteTravailController : ApiController
    {
        [HttpGet]
        // GET: api/Societe
        public IEnumerable<SiteTravail> Get(long id)
        {
            return SiteTravailModel.afficher(id);
        }

        [HttpGet]
        // GET: api/Societe/5
        public List<SiteTravail> GetUn(int id)
        {
            return SiteTravailModel.AfficherUnSeul(id);
        }

        [HttpPost]
        // POST: api/Societe
        public void Post([FromBody] SiteTravail siteTravail)
        {
            SiteTravailModel.Ajouter(siteTravail);
            
        }

        [HttpPut]
        // PUT: api/Societe/5
        public void Put(long id, [FromBody] SiteTravail siteTravail)
        {
            SiteTravailModel.Modifier(id, siteTravail);
        }

        [HttpDelete]
        // DELETE: api/Societe/5
        public void Delete(long id)
        {
            SiteTravailModel.supprimer(id);
        }
    }
}
