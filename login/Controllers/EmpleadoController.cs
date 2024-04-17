using Microsoft.AspNetCore.Mvc;
using login.Data;
using login.Models;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace login.Controllers
{
    public class EmpleadoController : Controller
    {
        public readonly LoginContext _context;
        public EmpleadoController(LoginContext context)
        {
            _context = context;
        }
       

        public IActionResult Index(int id){
            var empleado = _context.Empleados.FirstOrDefault(e => e.Id == id);
            return View(empleado);
            
        }


        //////////////// REGISTRAR //////////////////
        public IActionResult Register(){
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Register(Empleados empleados){
            _context.Empleados.Add(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //////////////////////// REGISTRAR HORA ENTRADA //////////////
        public  IActionResult Ingreso(){
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ingreso(Registros registro)
        {
            _context.Registro.Add(registro);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Empleado");
        }
    }
}
