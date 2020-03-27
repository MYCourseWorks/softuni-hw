create view V_EmployeeNameJobTitle as
select FirstName + ' ' + ISNULL(MiddleName, '')+ ' ' + LastName as [Full Name],
	JobTitle as [Job Title]
from Employees as e