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
    [RoutePrefix("api/Employes")]
    public class EmployesController : ApiController
    {
        /*[HttpGet]
        public bool Get()
        {
            return true;
        }*/

        // GET: api/Employes
        [HttpGet]
        public List<Employes> Get(long id)
        {
            return EmployesModel.afficher(id);
        }

        // GET: api/Employes/5
        [HttpGet]
        [ActionName("GetUn")]
        public List<Employes> GetUn(long id)
        {
            return EmployesModel.AfficherUnSeul(id);
        }

        // GET: api/Employes/5
        [HttpGet]
        [ActionName("GetRespo")]
        public List<Employes> GetParRespo([FromUri] long id, [FromUri] string nom, [FromUri] string prenom)
        {
            return EmployesModel.AfficherParResponsable(id,nom,prenom);
        }

        [ActionName("GenerateQrcode")]
        public System.Drawing.Image GenerateQrcodeEmploye(Employes employes)
        {
            return EmployesModel.GenererQrcode(employes);
        }

        [ActionName("Generate")]
        public System.Drawing.Image GenerateQrcode(long id)
        {
            return EmployesModel.GenererQrcodeParId(id);
        }

        [Route("verifier/{name}")]
        public IHttpActionResult Verifier(string name)
        {
            long id = EmployesModel.Verifier(name);
            return Ok(id);
        }

        // POST: api/Employes
        [HttpPost]
        public IHttpActionResult Post([FromBody]Employes employes)
        {
           long id =EmployesModel.Ajouter(employes);
           return Ok( id);
        }

        [Route("Add/{id}")]
        [HttpPost]
        public IHttpActionResult Add(long id, [FromBody] Employes employes)
        {
            long ret = EmployesModel.AjouterStrict(id,employes);
            return Ok(ret);
        }

        // PUT: api/Employes/5
        [HttpPut]
        public void Put(long id, [FromBody] Employes employes)
        {
            EmployesModel.Modifier(id, employes);
        }

        [Route("Passe/{id}")]
        public IHttpActionResult Passe(long id, Employes employes)
        {
            EmployesModel.Passe(id, employes);
            return Ok(id);
        }

        // DELETE: api/Employes/5
        [HttpDelete]
        public void Delete(long id)
        {
            EmployesModel.supprimer(id);
        }
    }
}
