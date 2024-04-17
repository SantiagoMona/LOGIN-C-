using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using login.Data;
using login.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

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
            var userExists = await _dbcontext.Empleados.FirstOrDefaultAsync(e=> e.Correo.Equals(correo) /* &&  e.Password.Equals(password) */ );
            

            if (userExists == null)
            {
                HttpContext.Session.Clear();
                return View("Login");
            }
            else
            {
                HttpContext.Session.SetInt32("id_user",userExists.Id);
                return RedirectToAction("Index", "Empleado",new { id = userExists.Id });
            }
        }
    }
}