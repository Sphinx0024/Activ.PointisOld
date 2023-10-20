 
using System.Collections.Generic;
 
using System.Web.Http;
 

namespace Authentification.Controllers
{
    [Authorize]
    public class PaysController : ApiController
    {
        // GET: api/Pays
        public IEnumerable<string> Get()
        {
            var p = Request.Headers;
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pays/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Pays
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pays/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pays/5
        public void Delete(int id)
        {
        }
    }
}
