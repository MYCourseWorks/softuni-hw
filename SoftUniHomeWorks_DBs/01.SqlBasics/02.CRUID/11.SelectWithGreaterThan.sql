select FirstName, LastName, Salary 
from Employees as e
where e.Salary > 50000
order by e.Salary desc