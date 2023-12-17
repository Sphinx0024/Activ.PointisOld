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
    [RoutePrefix("api/Societe")]
    public class SocieteController : ApiController
    {
        [HttpGet]
        // GET: api/Societe
        public IEnumerable<Societe> Get()
        {
            return SocieteModel.afficher() ;
        }

        [HttpGet]
        // GET: api/Societe/5
        public List<Societe> Get(int id)
        {
            return SocieteModel.AfficherUnSeul(id);
        }

        [HttpPost]
        // POST: api/Societe
        public IHttpActionResult Post([FromBody] Societe societe)
        {
            long id = SocieteModel.Ajouter(societe);
            return Ok(id);
        }

        /*[Route("Inscription/{login}/{password}")]
        public IHttpActionResult Inscription(string login, string password, Societe societe)
        {
            SocieteModel.Inscription(login, password, societe);
            return Ok();
        }*/

        [HttpPost]
        [Route("Inscription")]
        //public IHttpActionResult Inscription(string email,ConnexionClasse connexionClasse)
        public IHttpActionResult Inscription([FromBody] ConnexionClasse connexionClasse)
        {
           string result =SocieteModel.Inscription(connexionClasse);
            return Ok(result);
        }


        [HttpPut]
        // PUT: api/Societe/5
        public void Put(long id, [FromBody] Societe societe)
        {
            SocieteModel.Modifier(id, societe);
        }

        [HttpDelete]
        // DELETE: api/Societe/5
        public void Delete(long id)
        {
            SocieteModel.supprimer(id);
        }
    }
}
