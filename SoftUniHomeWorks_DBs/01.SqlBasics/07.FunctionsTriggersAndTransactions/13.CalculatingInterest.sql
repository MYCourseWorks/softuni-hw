create function ufn_CalculateFutureValue 
(@sum money, @yearly_interest_rate float, @number_of_years int)
returns money
as 
begin
	return @sum * POWER((1 + @yearly_interest_rate), @number_of_years)
end
go

create proc usp_CalculateFutureValueForAccount 
(@accountId int, @intrest_rate float)
as
	declare @number_of_years int = 5

	select 
		A.Id as [Account Id],
		AH.FirstName as [First Name],
		AH.LastName as [Last Name],
		A.Balance as [Current Balance],
		dbo.ufn_CalculateFutureValue(A.Balance, @intrest_rate, @number_of_years) as [Balance in 5 years]
	from Accounts as A
	join AccountHolders as AH on AH.Id = A.AccountHolderId
	where A.Id = @accountId
go

exec usp_CalculateFutureValueForAccount 1, 0.1
drop function dbo.ufn_CalculateFutureValue
drop proc usp_CalculateFutureValueForAccount