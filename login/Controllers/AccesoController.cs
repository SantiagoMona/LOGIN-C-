using Microsoft.EntityFrameworkCore;
using login.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Reflection;
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
            var userExists = await _dbcontext.Empleados.FirstOrDefaultAsync(e=> e.Correo.Equals(correo) &&  e.Password.Equals(password) );
            

            if (userExists == null)
            {

                return View("Login");
            }
            else
            {
                this.HttpContext.Session.SetInt32("id_user",userExists.Id);

                return RedirectToAction("Index", "Empleado");
            }
        }
    }
}