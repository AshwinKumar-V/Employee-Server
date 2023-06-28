namespace Employee_Server.Models
{
    public class PaymentRule
    {
        public int Id { get; set; }
        public string Rule { get; set; } = null!;
        public ICollection<Employee>? Employees { get; set; }
    }
}