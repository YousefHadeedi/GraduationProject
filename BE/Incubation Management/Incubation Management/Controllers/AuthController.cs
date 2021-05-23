using Incubation_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Incubation_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly INCUBATORDBContext _context;
        public AuthController(INCUBATORDBContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UsersTb BodyUser)
        {


            var user = await _context.UsersTbs.Include(user => user.UserType).Where(user => user.UserName.Equals(BodyUser.UserName)).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("Username Or Password Error");
            }
            if (user.Password.Equals(BodyUser.Password))
            {
                return Ok(user);
            }
            else
            {
                return NotFound("Username Or Password Error");
            }


        }
    }


}
