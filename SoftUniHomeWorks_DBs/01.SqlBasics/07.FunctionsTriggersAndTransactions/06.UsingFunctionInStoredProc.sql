create function ufn_GetSalaryLevel (@salary money)
returns nvarchar(10)
as
begin
return 
	case 
		when @salary < 30000 then 'Low'
		when @salary between 30000 and 50000 then 'Average'
		else 'High'
	end
end
go

create proc usp_EmployeesBySalaryLevel (@levelOfSalary varchar(10))
as
	select FirstName, LastName
	from Employees
	where @levelOfSalary = dbo.ufn_GetSalaryLevel(Salary)
go

exec usp_EmployeesBySalaryLevel 'Average'

drop function dbo.ufn_GetSalaryLevel
drop proc usp_EmployeesBySalaryLevel