select FirstName + ' ' + MiddleName + ' ' + LastName as [Full Name] 
from Employees as e
where e.Salary = 25000 OR 
	e.Salary = 14000 OR 
	e.Salary = 12500 OR 
	e.Salary = 23600