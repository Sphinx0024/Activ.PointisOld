using Microsoft.IdentityModel.Tokens;
using Activ.Pointis.WebAPI.Models;
using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.Http.Cors;

namespace Activ.Pointis.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Connexion")]
    public class ConnexionController : ApiController
    {
        //[HttpPost]
        //[Route("connexion")]
       
        //public IHttpActionResult Connexion(Connexion connexion)
        //{
        //    // validate user credentials
        //    if (ConnexionModel.IsValidUser(connexion.Login, connexion.Password))
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.UTF8.GetBytes("Activ.Pointis.WebAPI");
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //            new Claim(ClaimTypes.Name, connexion.Login)
        //            }),
        //            Expires = DateTime.UtcNow.AddDays(7),
        //            SigningCredentials = new SigningCredentials(
        //                new SymmetricSecurityKey(key),
        //                SecurityAlgorithms.HmacSha256Signature)
        //        };
        //        var token = tokenHandler.CreateToken(tokenDescriptor);
        //        var tokenString = tokenHandler.WriteToken(token);

        //        // return the JWT token as a response
        //        return Ok(new { Token = tokenString });
        //    }
        //    else
        //    {
        //        return Unauthorized();
        //    }
        //}

        // GET: api/Pointage
        [HttpGet]
        public IEnumerable<Connexion> Get(long id)
        {
            PointageModel.RappelAbsence();
            return ConnexionModel.afficher(id);
        }

        // GET: api/Pointage/5
        [HttpGet]
        public IEnumerable<Connexion> GetUn(long id)
        {
            PointageModel.RappelAbsence();
            return ConnexionModel.AfficherUnSeul(id);
        }


        //[Route("connecter")]
        public IHttpActionResult Connecter(ConnexionInfos connexionInfos)
        {
            PointageModel.RappelAbsence();
            string id = ConnexionModel.Connecter(connexionInfos);
            return Ok(id);
        }

        [Route("connect/{login}/{passe}")]
        public IHttpActionResult Connect(string login, string passe)
        {
            PointageModel.RappelAbsence();
            string id = ConnexionModel.Connect(login, passe);
            return Ok(id);
        }

        [HttpGet]
        [Route("VerifierCompte")]
        public IHttpActionResult VerifierConnexion([FromUri]long id, [FromUri] string email)
        {
            PointageModel.RappelAbsence();
            bool resp = ConnexionModel.VerifierConnexion(id,email);
            return Ok(resp);
        }


        /*[ActionName("Employe")]
        public IHttpActionResult Employe(string name)
        {
            long id = ConnexionModel.EmployesID(name);

            return Ok(id);
        }*/

        [Route("verifier/{name}")]
        //[HttpGet("{name}")]
        public IHttpActionResult verifier(string name)
        {
            PointageModel.RappelAbsence();
            string verif = ConnexionModel.Verifier(name);
            return Ok(verif);
        }

        [Route("confirmer/{name}")]
        public IHttpActionResult confirmer(string login, string passe)
        {
            PointageModel.RappelAbsence();
            long verif = ConnexionModel.Confirmer(login,passe);
            return Ok(verif);
        }

        // POST: api/Pointage
        [HttpPost]
        public IHttpActionResult Post([FromBody] Connexion connexion)
        {
            PointageModel.RappelAbsence();
            long id = ConnexionModel.Ajouter(connexion);
            return Ok(id);
        }

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add([FromBody] Connexion connexion)
        {
            PointageModel.RappelAbsence();
            long id = ConnexionModel.Add(connexion);
            return Ok(id);
        }

        [HttpPost]
        [Route("EditPasse/{id}")]
        public IHttpActionResult EditPasse(long id, Password password)
        {
            PointageModel.RappelAbsence();
            ConnexionModel.ModifierPasse(id,password);
            return Ok();
        }

        // PUT: api/Pointage/5
        //[HttpPut]
        public void Put(long id, [FromBody] Connexion connexion)
        {
            PointageModel.RappelAbsence();
            ConnexionModel.Modifier(id, connexion);
        }

        /*[Route("modifier/{id}")]
        public void modifier(long id, Connexion connexion)
        {
            ConnexionModel.ModifierPasse(id, connexion);
        }*/

        // DELETE: api/Pointage/5
        [HttpDelete]
        public void Delete(long id)
        {
            PointageModel.RappelAbsence();
            ConnexionModel.supprimer(id);
        }
    }
}
