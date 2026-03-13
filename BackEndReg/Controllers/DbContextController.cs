using BackEndReg.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static BackEndReg.Model.AppDbContext;

namespace BackEndReg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class DbContextController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DbContextController(AppDbContext context)
        {
            _context = context;
        }

        //Sign Up Form Submission
        [HttpPost("signup")]
        public IActionResult SaveSignUp(SignUp data)
        {
            var userExists = _context.SaveSignUp.SingleOrDefault(m => m.emailId == data.emailId);
            if (userExists == null)
            {
                _context.Set<SignUp>().Add(data);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Sign up successful. Welcome aboard!"
                });
            }
            else
            {
                return Conflict(new
                {
                    message = "This email is already registered. Please use a different email."
                });
            }
        }

        //Login Form Submission
        [HttpPost("login")]
        public IActionResult Login(LoginDTO data)
        {
            var user = _context.SaveSignUp.SingleOrDefault(m => m.emailId == data.emailId && m.password == data.password);
            if (user != null)
            {
                return Ok(new
                {
                    message = "Login successful. Welcome back!"
                });
            }
            else
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password. Please try again."
                });
            }
        }

        //Admin Login
        [HttpPost("adminLog")]
        public IActionResult adminLog(adminLogin data)
        {
            var admin = _context.AdminLogins.SingleOrDefault(m => m.emailId == data.emailId && m.password == data.password);
            if (admin != null)
            {
                return Ok(new
                {
                    message = "Admin login successful. Welcome back!"
                });
            }
            else
            {
                return Unauthorized(new
                {
                    message = "Invalid admin email or password. Please try again."
                });
            }
        }
    }
}
