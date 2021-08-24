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
        public async Task<ActionResult<Nhanvien>> GetUsers(int id)
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
        public async Task<IActionResult> PutUser(int id, Nhanvien nhanvien)
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
                if (!UserExists(id))
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
        [Route("UpdateNv")]
        public async Task<IActionResult> UPdatenv([FromBody] Nhanvien nhanvien)
        {
            RequetModel<Nhanvien> result = new RequetModel<Nhanvien>();
            try
            {
                var nv = (from u in _context.Nhanviens
                            where u.ID == nhanvien.ID
                            select u).FirstOrDefault();

                if (nv != null)
                {
                    nv.Ten = nhanvien.Ten;
                    nv.Manv = nhanvien.Manv;
                    nv.Phong = nhanvien.Phong;
                    nv.Gioitinh = nhanvien.Gioitinh;
                    nv.Diachi = nhanvien.Diachi;
                    nv.Ngaysinh = nhanvien.Ngaysinh;
                    _context.SaveChanges();
                    //result.data = user.FirstOrDefault();
                    result.success = true;
                    result.Message = "Thành công";
                    return Ok(result);
                }
                else
                {
                    result.data = null;
                    result.success = false;
                    result.Message = "Không có dữ liệu";
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                return Json(new { status = 500, error = "Loi tu server" });
            }
        }
        [HttpPost]
        public async Task<ActionResult<Nhanvien>> Creat(Nhanvien nhanvien)
        {
            _context.Nhanviens.Add(nhanvien);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = nhanvien.ID }, nhanvien);
        }

        // DELETE: Nhan vien
        [HttpGet]
        [Route("DeleteNv/{IDnv}")]
        public async Task<IActionResult> DeleteUser(int IDnv)
        {
            RequetModel<bool> result = new RequetModel<bool>();
            try
            {
                var deletenv = (from u in _context.Nhanviens
                                where u.ID == IDnv
                                select u).FirstOrDefault();
                if (deletenv == null)
                {
                    result.success = false;
                    //return Json(new { status = 500, error = "Loi tu server" }
                    return Ok(result);
                }
                _context.Nhanviens.Remove(deletenv);
                await _context.SaveChangesAsync();
                result.success = true;
                return Ok(result);

            }
            catch(Exception e)
            {
                return Json(new { status = 500, error = "Loi tu server" });
            }
        }
        private bool UserExists(int id)
        {
            return _context.Nhanviens.Any(e => e.ID == id);
        }
    }
}
