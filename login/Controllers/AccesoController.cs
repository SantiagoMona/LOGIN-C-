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
        public async Task<ActionResult> Login(string correo, string password)
        {

            var userExists = await _dbcontext.Empleados.FirstOrDefaultAsync(e=> e.Password.Equals(password) && e.Correo.Equals(correo));

            if (userExists == null)
            {

                return View("Login");
            }

            else
            {
                return RedirectToAction("Index", "Empleado", new { id = userExists.Id });
            }
        }

    }
}