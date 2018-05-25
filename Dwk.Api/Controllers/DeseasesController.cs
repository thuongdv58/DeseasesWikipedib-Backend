using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Dwk.Api.Models;
using System.Collections;
using System.Diagnostics;

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
		[HttpGet]
		public IEnumerable<DeseaseListData> GetDeseases(int page)
		{
			return _context.Deseases.Select(q=> new DeseaseListData(q.Id, q.name, q.@abstract));
		}

		[HttpGet("search")]
        // GET: api/deseases/search
        public IEnumerable<DeseaseListData> Search(string content, int page)
        {
			return _context.Deseases.Where(q => (q.name.Contains(content)||q.@abstract.Contains(content))).Select(q => new DeseaseListData(q.Id, q.name, q.@abstract));
		}

        [HttpGet("search-recommendations")]
        // GET: api/deseases/search-recommendations
        public IEnumerable<RecommendData> SearchRecommendation(string content)
        {
			return _context.Deseases.Where(q => q.name.Contains(content)).Select(q=> new RecommendData(q.Id, q.name));
        }
		// GET: api/deseases/5
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
			/*
			List<Models.Attribute> AttributeField = new List<Models.Attribute>();
			var attributeList = ((IEnumerable)desease.attributes).GetEnumerator();
			while(attributeList.MoveNext())
			{
				var current = attributeList.Current;
				AttributeField.Add(new Models.Attribute { name= current.ToString(), content= current.ToString() });
			}
			desease.attributes = ((IEnumerable)attributeList).Cast<Attribute>().ToList();
			desease.attributes = AttributeField.ToArray();
			return Ok(desease.attributes);
			*/

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

	public class RecommendData
	{
		public int id;
		public string name;
		public RecommendData(int id, string name)
		{
			this.name = name;
			this.id = id;
		}
	}
	
	public class DeseaseListData
	{
		public int id;
		public string name;
		public string @abstract;
		public DeseaseListData(int id, string name, string @abstract)
		{
			this.id = id;
			this.name = name;
			this.@abstract = @abstract;
		}
	}
}
