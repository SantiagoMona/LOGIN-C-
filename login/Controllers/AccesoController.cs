using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace login.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Login(){
            return View();
        }

    }
}