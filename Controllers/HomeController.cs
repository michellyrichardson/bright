using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Bright.Models;

namespace Bright.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult LogReg()
        {
            return View("LogReg");
        }

        [HttpPost("/register")]
        public IActionResult Register(User RegForm)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == RegForm.Email))
                {
                    ModelState.AddModelError("Email", "A user with that email address already exists. If it is you, please try logging in.");
                    return LogReg();
                }

                PasswordHasher<User> hasher = new PasswordHasher<User>();

                RegForm.Password = hasher.HashPassword(RegForm, RegForm.Password);

                _context.Add(RegForm);
                _context.SaveChanges();

                HttpContext.Session.SetInt32("UserId", RegForm.UserId);

                
                return RedirectToAction("Dashboard");
            }
            else
            {
                return LogReg();
            }
        }

        [HttpPost("/login")]
        public IActionResult Login(LogUser LogForm)
        {
            if(ModelState.IsValid)
            {
                
                User userInDb = _context.Users
                    .FirstOrDefault(u => u.Email == LogForm.LogEmail);

                
                if(userInDb == null)
                {
                    ModelState.AddModelError("LogEmail", "Invalid username/password.");
                    return LogReg();
                }

                
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                var result = hasher.VerifyHashedPassword(userInDb, userInDb.Password, LogForm.LogPass);

                if(result == 0)
                {
                    ModelState.AddModelError("LogEmail", "Invalid username/password.");
                    return LogReg();
                }

                HttpContext.Session.SetInt32("UserId", userInDb.UserId);

                return RedirectToAction("Dashboard");
            }
            else
            {
                return LogReg();
            }
        }

        [HttpGet("/dashboard")]
        public IActionResult Dashboard()
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if(uId == null)
            {
                return RedirectToAction("LogReg");
            }
            IdeasWrapper WMod = new IdeasWrapper
            {
                LoggedUser = _context.Users
                    .Include(u => u.Ideas)
                    .ThenInclude(i => i.UserIdeas)
                    .ThenInclude(ui => ui.Idea)
                    .FirstOrDefault(u => u.UserId == uId),
                AllIdeas = _context.Ideas
                    .Include(i => i.User)
                    .Include(i => i.UserIdeas)
                    .ThenInclude(ui => ui.Idea)
                    .Where(i => i.UserId != uId)
                    .ToList()
            };
            return View("Dashboard", WMod);
        }

        [HttpGet("/new/idea")]
        public IActionResult NewIdea()
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if(uId == null)
            {
                return RedirectToAction("LogReg");
            }
            return View("Dashboard");
        }
        
        [HttpPost("/new/idea")]
        public IActionResult CreateIdea(Idea Form)
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if(uId == null)
            {
                return RedirectToAction("LogReg");
            }

            Form.UserId = (int)uId;

            if(ModelState.IsValid)
            {
                _context.Add(Form);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return Dashboard();
        } 

        

        [HttpGet("/idea/{id}")]
        public IActionResult OneIdea(int id)
        {
            int? uId = HttpContext.Session.GetInt32("UserId");
            if(uId == null)
            {
                return RedirectToAction("LogReg");
            }

            Idea ToDisplay = _context.Ideas
                .Include(i => i.UserIdeas)
                .ThenInclude(ui => ui.Idea)
                .FirstOrDefault(i => i.IdeaId == id);
            if (ToDisplay == null)
            {
                return RedirectToAction("Dashboard");
            }

            OneIdeaWrapper WMod = new OneIdeaWrapper
            {
                LoggedId = (int)uId,
                Idea = ToDisplay,
                AllIdea = _context.Ideas
                    .Include(i => i.UserIdeas)
                    .Where(u => !u.UserIdeas.Any(ui => ui.IdeaId == id))
                    .ToList()
            };

            return View("OneIdea", WMod);
        }

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LogReg");
        }
    }
}
