select FirstName, LastName
from Employees
where NOT(LOWER(JobTitle) like '%engineer%')