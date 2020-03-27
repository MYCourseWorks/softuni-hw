select E.EmployeeID, E.FirstName, E.ManagerID, M.FirstName as ManagerName
from Employees as E
join Employees as M
on E.ManagerID = M.EmployeeID
where M.EmployeeID in (3, 7)
order by E.EmployeeID