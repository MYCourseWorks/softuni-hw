create function ufn_CalculateFutureValue 
(@sum money, @yearly_interest_rate float, @number_of_years int)
returns money
as 
begin
	return @sum * POWER((1 + @yearly_interest_rate), @number_of_years)
end
go

select dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
drop function dbo.ufn_CalculateFutureValue