using Microsoft.EntityFrameworkCore;
using login.Controllers;
using login.Models;

namespace login.Data
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options): base(options){
            
        }

        public DbSet<Empleados> Empleados { get; set; }
    }
}