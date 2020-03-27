create proc usp_GetEmployeesSalaryAboveNumber
	(@amount money)
as 
	select FirstName, LastName 
	from Employees
	where Salary >= @amount
go

exec usp_GetEmployeesSalaryAboveNumber 48100

drop proc usp_GetEmployeesSalaryAboveNumber