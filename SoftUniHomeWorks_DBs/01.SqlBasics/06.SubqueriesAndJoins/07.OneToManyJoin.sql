select top 5 E.EmployeeID, E.FirstName, P.Name as ProjectName
from Employees as E
join EmployeesProjects as EP
on EP.EmployeeID = E.EmployeeID
join Projects as P
on EP.ProjectID = P.ProjectID
where (P.StartDate > '08-13-2002') and (P.EndDate is null)
order by EmployeeID