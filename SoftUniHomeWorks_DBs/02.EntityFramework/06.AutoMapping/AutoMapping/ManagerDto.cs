using System.Collections.Generic;

namespace AutoMapping
{
    public class ManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> Employees { get; set; }

        public int EmployeeCount { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} | Employees: {this.EmployeeCount}";
        }
    }
}
