using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Employee_Server.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; } = null!;

        [DisplayName("Working Hour")]
        public int WorkingHourId { get; set; }
        public WorkingHour? WorkingHour { get; set; }

        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        public Designation? Designation { get; set; }

        [DisplayName("Payment Rule")]
        public int PaymentRuleId { get; set; }
        public PaymentRule? PaymentRule { get; set; }
    }
}
