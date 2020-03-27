select top 5 E.EmployeeID, E.FirstName, E.Salary, D.Name as DepartmentName
from Employees as E
join Departments as D
on D.DepartmentID = E.DepartmentID
where E.Salary > 15000
order by D.DepartmentID