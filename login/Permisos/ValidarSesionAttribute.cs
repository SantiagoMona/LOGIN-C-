using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;




namespace login.permisos
{
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;

            if (session == null)
            {
                RedirectToActionResult("Index", "Empleado");
            }

           /*  // Assuming you want to set a key-value pair in the session
            string key = "myKey";
            byte[] value = System.Text.Encoding.UTF8.GetBytes("myValue");

            if (session.TryGetValue(key, out value))
            {
                // The key already exists in the session
            }
            else
            {
                // The key doesn't exist in the session, so set it
                session.Set(key, value);
            } 
 */
            base.OnActionExecuting(filterContext);
        }

        private void RedirectToActionResult(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}

    

