select top 50 E.EmployeeID, 
		(E.FirstName + ' ' + E.LastName) as EmployeeName, 
		(M.FirstName + ' ' + M.LastName) as ManagerName,
		D.Name as DepartmentName
from Employees as E
join Employees as M
on E.ManagerID = M.EmployeeID
join Departments as D
on D.DepartmentID = E.DepartmentID
order by EmployeeID