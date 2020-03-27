namespace AutoMapping
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string ManagerLastName { get; set; }

        public override string ToString()
        {
            string managerName = this.ManagerLastName != null ? this.ManagerLastName : "[no manager]";
            return $"{this.FirstName} {this.LastName} {this.Salary} - Manager: {managerName}";
        }
    }
}
