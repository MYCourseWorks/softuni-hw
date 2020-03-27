select E.FirstName, E.LastName, E.HireDate, D.Name as DepartmentName
from Employees as E
join Departments as D
on D.DepartmentID = E.DepartmentID
where D.Name in ('Sales', 'Finance') and E.HireDate > '1-1-1999'
order by E.HireDate