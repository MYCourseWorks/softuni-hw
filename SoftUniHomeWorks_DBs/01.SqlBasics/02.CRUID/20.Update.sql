update Employees
set Salary = (Salary + Salary * 12 / 100)
where DepartmentID = 1 or
	DepartmentID = 2 or
	DepartmentID = 4 or
	DepartmentID = 11

select Salary from Employees

update Employees
set Salary = (Salary - Salary * 12 / 100)
where DepartmentID = 1 or
	DepartmentID = 2 or
	DepartmentID = 4 or
	DepartmentID = 11