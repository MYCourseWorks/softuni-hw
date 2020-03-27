select FirstName
from Employees as e
where (e.DepartmentID = 3 or e.DepartmentID = 10) and 
		(e.HireDate BETWEEN '1-1-1995' AND '12-31-2005')