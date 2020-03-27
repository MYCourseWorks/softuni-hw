select DepartmentID, max(Salary) as MaxSalary
from Employees
group by DepartmentID
having max(Salary) not between 30000 and 70000