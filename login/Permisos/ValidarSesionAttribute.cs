using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;





namespace login.permisos
{
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
       /*  public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;

            if (session == null)
            {
                RedirectToActionResult("Index", "Empleado");
            }

            base.OnActionExecuting(filterContext);
        }

        private void RedirectToActionResult(string v1, string v2)
        {
            throw new NotImplementedException();
        } */
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session == null )
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}

    

