using API.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly NVcontext _context;

        public HomeController(NVcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Nhanvien> Get()
        {
            return _context.Nhanviens;
        }
        // GET: api/Home/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nhanvien>> GetProducts(int id)
        {
            var products = await _context.Nhanviens.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Nhanvien nhanvien)
        {
            if (id != nhanvien.ID)
            {
                return BadRequest();
            }

            _context.Entry(nhanvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        // POST: api/Home
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Nhanvien>> PostProducts(Nhanvien nhanvien)
        {
            _context.Nhanviens.Add(nhanvien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = nhanvien.ID }, nhanvien);
        }

        // DELETE: api/Home/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nhanvien>> DeleteProducts(int id)
        {
            var products = await _context.Nhanviens.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Nhanviens.Remove(products);
            await _context.SaveChangesAsync();

            return products;
        }

        private bool ProductsExists(int id)
        {
            return _context.Nhanviens.Any(e => e.ID == id);
        }
    }
}
