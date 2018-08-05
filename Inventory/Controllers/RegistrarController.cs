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
    public class RegistrarController : Controller
    {
       



        public IActionResult Index()
        {
            return View("Registrar");
        }



        [HttpPost]
        public IActionResult registrar(IFormCollection formData)
        {
            Persona persona = new Persona();
            persona.usuario = new Usuario();

            persona.usuario.username = Convert.ToString(formData["username"]);
            persona.usuario.role = Convert.ToString(formData["role"]);
            persona.usuario.password = Convert.ToString(formData["password"]);

            HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(persona));

            return RedirectToAction(nameof(next));
        }



        public IActionResult next()
        {
            //Persona persona =  JsonConvert.DeserializeObject<Persona>(HttpContext.Session.GetString("Usuario"));
            return View("Registrar_continuar");
        }

        [HttpPost]
        public IActionResult persistir(IFormCollection data)
        {

            Persona persona = JsonConvert.DeserializeObject<Persona>(HttpContext.Session.GetString("Usuario"));
            persona.nombre = Convert.ToString(data["nombre"]);
            persona.apellido = Convert.ToString(data["apellido"]);
            persona.cedula = Convert.ToString(data["cedula"]);
            persona.correo = Convert.ToString(data["correo"]);


            PersonaRepositorio pRepositorio = new PersonaRepositorio();

            

            return View("Registrar_continuar");
        }



    }
}