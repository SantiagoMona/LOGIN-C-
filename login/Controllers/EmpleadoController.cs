using Microsoft.AspNetCore.Mvc;
using login.Data;
using login.Models;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using login.permisos;

namespace login.Controllers
{
    [ValidarSesion]
    public class EmpleadoController : Controller
    {
        public readonly LoginContext _context;
        public EmpleadoController(LoginContext context)
        {
            _context = context;
        }
       

        public IActionResult Index(){
            var id = this.HttpContext.Session.GetInt32("id_user");
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
        public async Task<IActionResult> Ingreso([Bind("empleadoID, horaIngreso")]Registros registro)
        {
            var IdEmpleado = this.HttpContext.Session.GetInt32("id_user");

            registro.empleadoID = IdEmpleado;

            _context.Registro.Add(registro);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Empleado");
        }
        //////////////////////// REGISTRAR HORA SALIDA //////////////
        public IActionResult Salida(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Salida([Bind("horaSalida")]Registros registro){
            
            var IdEmpleado = this.HttpContext.Session.GetInt32("id_user");
            var registers = (from register in _context.Registro orderby IdEmpleado descending select register ).FirstOrDefault();

            _context.Registro.Update(registro);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        //////////////////////// REGISTRAR HORA SALIDA //////////////

        public ActionResult CerrarSesion()
        {
            this.HttpContext.Session.Clear();
            return RedirectToAction("Login", "Acceso");
        }
    }
}
