namespace login.Models 
{
    public class Registros
    {
        public int Id { get; set; }
        public DateTime horaIngreso { get; set; }
        public DateTime horaSalida { get; set; }
        public int empleadoID { get; set; }
    }
}