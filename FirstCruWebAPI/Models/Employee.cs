using System.ComponentModel.DataAnnotations;

namespace FirstCruWebAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDescription { get; set; }
        public int EmployeeSalary { get; set; }
        public int YearOfService { get; set; }
    }
}
