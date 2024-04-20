using Microsoft.AspNetCore.Mvc;
using login.Data;
using login.Models;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using login.permisos;
using System.Linq;

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
        public async Task<IActionResult> Salida(DateTime horasalida){
            
            var IdEmpleado = this.HttpContext.Session.GetInt32("id_user");
            var registers = _context.Registro.OrderBy(r => r.Id).LastOrDefault(r => r.empleadoID==IdEmpleado);        
    
            registers.horaSalida = horasalida;
            _context.Registro.Update(registers);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        //////////////////////// CERRAR SESION //////////////

        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            this.HttpContext.Session = null;
            return RedirectToAction("Login", "Acceso");
        }
        //////////////////////// ELIMINAR USUARIO //////////////
       public async Task<IActionResult> Eliminar(string buscar)
        {
            var empleados = from employ in _context.Empleados select employ;
            /* if (!string.IsNullOrEmpty(buscar))
            {
                empleados = empleados.Where(e => e.Names.Contains(buscar) || e.Area.Contains(buscar) || e.CivilStatus.Contains(buscar) || e.About.Contains(buscar) );
            } */

            return View(await empleados.ToListAsync());
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var employ = await _context.Empleados.FirstOrDefaultAsync(e => e.Id == id);
            _context.Empleados.Remove(employ);
            await _context.SaveChangesAsync();
            return RedirectToAction("index"); 
        }

        //////////////////////// HISTORIAL USARIO //////////////
        public async Task<IActionResult> Historial()
        {
            var IdEmpleado = HttpContext.Session.GetInt32("id_user");
     
            var hitorial = _context.Registro.Where(employ => employ.empleadoID == IdEmpleado);

            return View(await hitorial.OrderByDescending(h=> h.Id).ToListAsync());
        }
    }
}
