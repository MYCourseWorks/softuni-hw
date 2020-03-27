select min(G.AvgSalary) as AverageSalary
from (select E.DepartmentID, avg(E.Salary) as AvgSalary
		from Employees as E
		group by E.DepartmentID) as G
