using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Dwk.Api.Models;

namespace Dwk.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Deseases")]
    public class DeseasesController : Controller
    {

		private readonly DwkApiContext _context;

		public DeseasesController(DwkApiContext context)
		{
			_context = context;
		}
		// GET: api/deseases
		//[HttpGet]
		//public IActionResult GetAll(int page)
		//{
		//   return Ok(new string[] { page.ToString(), "hh", "HIV", "Diabetes" });
		//}
		[HttpGet]
		public IEnumerable<Desease> GetDeseases(int page)
		{
			return _context.Deseases;
		}

		[HttpGet("search")]
        // GET: api/deseases/search
        public IActionResult Search(string content, int page)
        {
            return Ok(new string[] { page.ToString(), content, "what problem", "Yellow shit" });
        }

        [HttpGet("search-recommendations")]
        // GET: api/deseases/search-recommendations
        public IActionResult SearchRecommendation(string content, int page)
        {
            return Ok(new string[] { page.ToString(), content, "what problem", "Yellow shit" });
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDesease([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var desease = await _context.Deseases.SingleOrDefaultAsync(m => m.Id == id);

			if (desease == null)
			{
				return NotFound();
			}

			return Ok(desease);
		}

		// POST: api/deseases/add-desease
		[HttpPost("add-desease")]
		public async Task<IActionResult> PostDesease([FromBody] Desease desease)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.Deseases.Add(desease);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetDesease", new { id = desease.Id }, desease);
		}

		// PUT: api/deseases/update-desease/5
		[HttpPut("update-desease/{id}")]
		public async Task<IActionResult> PutDesease([FromRoute] int id, [FromBody] Desease desease)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != desease.Id)
			{
				return BadRequest();
			}

			_context.Entry(desease).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!DeseaseExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return NoContent();
		}
		// DELETE: api/deseases/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDesease([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var desease = await _context.Deseases.SingleOrDefaultAsync(m => m.Id == id);
			if (desease == null)
			{
				return NotFound();
			}

			_context.Deseases.Remove(desease);
			await _context.SaveChangesAsync();

			return Ok(desease);
		}
		// GET: 
		[HttpGet("attribute-recommendation")]
        public IEnumerable<string> AttributeRecommendation()
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
		private bool DeseaseExists(int id)
		{
			return _context.Deseases.Any(e => e.Id == id);
		}
	}
}
