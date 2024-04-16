using Microsoft.AspNetCore.Mvc;
using login.Data;
using login.Models;


namespace login.Controllers
{
    public class EmpleadoController : Controller
    {
        public readonly LoginContext _context;
        public EmpleadoController(LoginContext context)
        {
            _context = context;
        }

        public IActionResult Index(){
            return View();
        }
        public IActionResult Register(){
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(Empleados empleados){
            _context.Empleados.Add(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}