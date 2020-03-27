create trigger logTrigger on dbo.Accounts
for update
as
	if update(Balance)
	begin
		declare @accountId int, @oldSum money, @newSum money

		select @newSum = Balance, @accountId = Id
		from Inserted

		select @oldSum = Balance
		from Deleted

		insert into Logs 
		values(@accountId, @oldSum, @newSum)
	end
go

update Accounts
set Balance = Balance + 1
where Id = 1

select * from Logs

drop trigger dbo.logTrigger