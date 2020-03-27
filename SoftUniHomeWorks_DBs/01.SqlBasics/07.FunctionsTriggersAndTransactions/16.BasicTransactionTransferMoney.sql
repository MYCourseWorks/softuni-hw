create proc usp_TransferMoney(@senderId int, @receiverId int, @amount money)
as
begin tran
begin try
	if (@amount <= 0)
	begin
		rollback tran
		return
	end

	declare @currentBalance int

	select @currentBalance = Balance 
	from Accounts
	where Id = @senderId

	-- don't have enough money to send :
	if(@currentBalance < @amount)
	begin
		rollback tran
		return
	end

	update Accounts
	set Balance = Balance - @amount
	where Id = @senderId

	update Accounts
	set Balance = Balance + @amount
	where Id = @receiverId

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