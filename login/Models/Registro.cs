using System.ComponentModel.DataAnnotations;

namespace login.Models 
{
    public class Registros
    {
       [Key]
        public int Id { get; set; }
        public DateTime horaIngreso { get; set; }
        public DateTime horaSalida { get; set; }
        public int? empleadoID { get; set; }
        
      /*   public required Empleados Empleados { get; set;} */
    }
}