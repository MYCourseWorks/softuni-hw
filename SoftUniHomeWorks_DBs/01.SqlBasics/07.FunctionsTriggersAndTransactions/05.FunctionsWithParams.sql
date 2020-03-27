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

select E.Salary, dbo.ufn_GetSalaryLevel(E.Salary) as [Salary Level]
from Employees as E

drop function dbo.ufn_GetSalaryLevel