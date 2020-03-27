select top 3 E.EmployeeID, E.FirstName
from Employees as E
left join EmployeesProjects as EP
on EP.EmployeeID = E.EmployeeID
where EP.ProjectID is null
order by E.EmployeeID