--19
select * from Towns
select * from Departments
select * from Employees

--20
select * from Towns order by Name
select * from Departments order by Name 
select * from Employees order by Salary desc

--21
select Name from Towns order by Name
select Name from Departments order by Name
select FirstName, LastName, JobTitle, Salary from Employees order by Salary desc

--22
update Employees
set Salary=(Salary + Salary *  10 / 100)

select Salary from Employees

--23
update Payments
set TaxRate=(TaxRate - TaxRate *  3 / 100)

select TaxRate from Payments

--24
truncate table Occupancies