namespace login.Models 
{
    public class Empleados
    {
        public int Id { get; set;}
        public string Nombre { get; set; }
        public string Apellido{ get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public int Document { get; set; }
    }
}