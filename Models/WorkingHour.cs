namespace Employee_Server.Models
{
    public class WorkingHour
    {
        public int Id { get; set; }
        public string ShiftName { get; set; } = null!;
        public int ShiftHours { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}