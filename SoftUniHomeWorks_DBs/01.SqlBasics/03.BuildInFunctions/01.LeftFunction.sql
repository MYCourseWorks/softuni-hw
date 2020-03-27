select FirstName, LastName 
from Employees as e
where UPPER(LEFT(e.FirstName, 2)) = 'SA'