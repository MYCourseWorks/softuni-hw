create proc usp_WithdrawMoney
(@accountId int, @moneyAmount money)
as
begin tran
begin try
	if (@moneyAmount <= 0)
	begin
		rollback tran
		return
	end

	declare @currentBalance int

	select @currentBalance = Balance 
	from Accounts
	where Id = @accountId

	if(@currentBalance < @moneyAmount)
	begin
		rollback tran
		return
	end

	update Accounts
	set Balance = Balance - @moneyAmount
	where Id = @accountId

	commit tran
end try
begin catch
	declare @ErrorMessage nvarchar(max)
	declare @ErrorSeverity int
	declare @ErrorState int

	select @ErrorMessage = ERROR_MESSAGE() + ' Line ' + cast(ERROR_LINE() as nvarchar(5)), 
			@ErrorSeverity = ERROR_SEVERITY(), 
			@ErrorState = ERROR_STATE()
	
	rollback tran
	RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
end catch

drop proc usp_WithdrawMoney