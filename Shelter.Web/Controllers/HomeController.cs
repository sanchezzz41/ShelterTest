using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shelter.Database;
using Shelter.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shelter.Web.Controllers
{
    [ApiController]
    [Route("Authorize")]
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly SignInManager<User> _signInManager;

        public HomeController(DatabaseContext context, SignInManager<User> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<Guid> Register(string email, string password, RoleOption role)
        {
            var user = new User
            {
                Email = email,
                Name = email,
                Password = password,
                RoleId = role
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.UserGuid;
        }

        [HttpPost("Login")]
        public async Task<bool> Login(string email, string password)
        {
            var resultUser = await _context.Users.SingleAsync(x => x.Email == email);
            await _signInManager.SignInAsync(resultUser, true);
            return true;
        }

        [HttpGet("Logout")]
        [Authorize]
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
