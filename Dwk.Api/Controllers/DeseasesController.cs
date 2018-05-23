using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dwk.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Deseases")]
    public class DeseasesController : Controller
    {
        // GET: api/Deseases
        [HttpGet]
        public IEnumerable<string> GetAll(int page)
        {
            return new string[] { page.ToString(),"hh", "HIV", "Diabetes" };
        }
		[HttpGet("search")]
		// GET: api/Deseases/search
		public IEnumerable<string> Search(string content, int page)
		{
			return new string[] { page.ToString(), content, "what problem", "Yellow shit" };
		}
        // GET: api/Deseases/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "AIDS";
        }
        // POST: api/Deseases
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Deseases/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

			
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
