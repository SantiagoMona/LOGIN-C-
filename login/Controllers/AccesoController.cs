using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using login.Data;
using login.Models;

namespace login.Controllers
{
    public class AccesoController : Controller
    {
        public readonly LoginContext _dbcontext;

        public AccesoController(LoginContext context)
        {
            _dbcontext = context;
        }
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            var userExists = _dbcontext.VerificarUsuario(correo, password);
            if (userExists)
            {
                    
                return RedirectToAction("Index", "Empleado");
            }
            else {
                ViewData["Mensaje"] = "usuario no encontrado";
                return View();
            }
        }

    }
}