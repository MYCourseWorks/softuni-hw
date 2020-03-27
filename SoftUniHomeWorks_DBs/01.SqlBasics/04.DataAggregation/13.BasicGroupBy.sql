select DepartmentID, sum(Salary) as TotalSalary
from Employees
group by DepartmentID
order by DepartmentID