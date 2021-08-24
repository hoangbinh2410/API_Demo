using API.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly NVcontext _context;
        public LoginController(NVcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<User1> Get()
        {
            return _context.Passwords;
        }
        // Get id password
        [HttpGet("{id}")]
        public async Task<ActionResult<User1>> GetPass(int id)
        {
            var pass = await _context.Passwords.FindAsync(id);
            if (pass == null)
            {
                return NotFound();
            }
            return pass;
            // Put pass
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPass(int id, User1 password)
        {
            if (id != password.ID)
            {
                return BadRequest();
            }
            _context.Entry(password).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        [HttpPost]
        [Route("Test")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            RequetModel<User1> result = new RequetModel<User1>();
           try
           {
                var user = from u in _context.Passwords
                           where u.Name == model.Name && u.Pass == model.Password
                           select u;
                if (user != null && user.Count() > 0)
                {
                    result.data = user.FirstOrDefault();
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
        [Route("ChangePass")]
        public async Task<IActionResult> NewPass([FromBody] LoginModel model)
        {
            RequetModel<User1> result = new RequetModel<User1>();
            try
            {
                var user = (from u in _context.Passwords
                           where u.Name == model.Name
                           select u).FirstOrDefault();

                if (user != null)
                {
                    user.Pass = model.Password;
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

        //Post pass
        [HttpPost]
        public async Task<string> Creat(User1 password)
        {
            RequetModel<User1> requet = new RequetModel<User1>();
            bool status = true;
            _context.Passwords.Add(password);
             await _context.SaveChangesAsync();
            requet.success = status;
            string sJSONRequest = JsonConvert.SerializeObject(requet);
            return sJSONRequest;
        }
        private bool UsersExists(int id)
        {
            return _context.Passwords.Any(e => e.ID == id);
        }

    }
}
