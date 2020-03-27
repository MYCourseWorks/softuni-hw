select top 10 E1.FirstName, E1.LastName, E1.DepartmentID 
from Employees as E1
where E1.Salary > (select avg(Salary) 
					from Employees as E2
					where E2.DepartmentID = E1.DepartmentID
					group by DepartmentID)
order by E1.DepartmentID