select E.EmployeeID, E.FirstName, E.LastName, D.Name
from Employees as E
join Departments as D
on D.DepartmentID = E.DepartmentID
where D.Name = 'Sales'
order by EmployeeID