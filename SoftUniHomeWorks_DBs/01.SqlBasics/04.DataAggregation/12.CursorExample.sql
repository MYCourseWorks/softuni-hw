declare @currentDeposit decimal(8, 2)
declare @previousDeposit decimal(8, 2)
declare @totalSum decimal(8, 2) = 0

declare wizzardCursor cursor for (select DepositAmount from WizzardDeposits)
open wizzardCursor 
fetch next from wizzardCursor into @currentDeposit
set @previousDeposit = @currentDeposit

while @@FETCH_STATUS = 0
begin
	set @totalSum += (@previousDeposit -  @currentDeposit)
	set @previousDeposit = @currentDeposit
	fetch next from wizzardCursor into @currentDeposit
end

close wizzardCursor
deallocate wizzardCursor

select @totalSum as SumDifference