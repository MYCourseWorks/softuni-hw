select E.EmployeeID, 
		E.FirstName, 
		case
			when (P.StartDate > '1-1-2005') then 'NULL'
			else P.Name
		end as ProjectName
from Employees as E
join EmployeesProjects as EP
on EP.EmployeeID = E.EmployeeID
join Projects as P
on P.ProjectID = EP.ProjectID
where E.EmployeeID = 24
