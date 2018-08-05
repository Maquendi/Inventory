using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Models;
using Inventory.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Inventory.Controllers
{
    public class LoginController : Controller
    {

        private PersonaRepositorio pRepositorio = new PersonaRepositorio();


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Autenticar(IFormCollection data)
        {
            string username = Convert.ToString(data["username"]);
            string password = Convert.ToString(data["password"]);

            Persona person = pRepositorio.Authenticar(username,password);

            if(person != null)
            {
                ViewBag.UsuarioEnSession = person;

                HttpContext.Session.SetString("Usuario_actual", JsonConvert.SerializeObject(person));

                return RedirectToAction("Cliente","Cliente");
            }
            
            return View("Login");
        }

    }
}