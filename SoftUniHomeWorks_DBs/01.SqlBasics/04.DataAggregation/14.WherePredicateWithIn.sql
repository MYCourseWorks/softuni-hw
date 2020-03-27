select DepartmentID, min(Salary) as MinimumSalary
from Employees
where DepartmentID in (2, 5, 7) and HireDate > '01-01-2000'
group by DepartmentID