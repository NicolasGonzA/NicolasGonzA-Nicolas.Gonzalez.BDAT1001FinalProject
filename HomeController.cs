using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Private_API.Controllers
{
    public class HomeController : Controller

    {
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {

            var NicolasClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Gonzalez"),
                new Claim("Nicolas.has", "good grades"),
            };

            var StudentIDClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Nicolas Alejandro Gonzalez"),
                new Claim(ClaimTypes.Email, "200369901.student@georgianc.on.ca"),
                new Claim("Nicolas.is", "A.Student"),
            };
                


            var NicolasIdentity = new ClaimsIdentity(NicolasClaims, "Nicolas Identity");

            var StudentIDIdentity = new ClaimsIdentity(StudentIDClaims, "Georgian College");

            var userPrincipal = new ClaimsPrincipal(new[] { NicolasIdentity,StudentIDIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");

        }
    }



}
