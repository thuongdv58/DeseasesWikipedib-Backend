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
        // GET: api/deseases
        [HttpGet]
        public IEnumerable<string> GetAll(int page)
        {
            return new string[] { page.ToString(), "hh", "HIV", "Diabetes" };
        }
        [HttpGet("search")]
        // GET: api/deseases/search
        public IEnumerable<string> Search(string content, int page)
        {
            return new string[] { page.ToString(), content, "what problem", "Yellow shit" };
        }
        [HttpGet("search-recommendations")]
        // GET: api/deseases/search-recommendations
        public IEnumerable<string> SearchRecommendation(string content, int page)
        {
            return new string[] { page.ToString(), content, "what problem", "Yellow shit" };
        }
        // GET: api/deseases/5
        [HttpGet("{id}", Name = "GetDetail")]
        public string GetDetail(int id)
        {
            return "AIDS";
        }
        // POST: api/deseases/add-desease
        [HttpPost("add-desease")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/deseases/update-desease/5
        [HttpPut("update-desease/{id}")]
        public void Put(int id, [FromBody]string value)
        {


        }

        // DELETE: api/deseases/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "shit";
        }
        // GET: 
        [HttpGet("attribute-recommendation")]
        public string[] AttributeRecommendation()
        {
            string[] AttributeNameList = new string[] {
                "Biểu hiện lâm sàng",
                "Cách điều trị",
                "Triệu chứng",
                "Chẩn đoán",
                "Điều trị",
                "Tổng quan",
                "Nguyên nhân",
                "Phòng ngừa",
                "Thuốc"
            };
            return AttributeNameList;
        }
    }
}
