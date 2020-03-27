create trigger notificationTrigger on Logs
for insert
as
	declare @accountId int, 
		@oldSum money, 
		@newSum money

	select 
		@accountId = AccountId,
		@oldSum = OldSum, 
		@newSum = NewSum
	from 
		Inserted

	declare @body nvarchar(MAX), @subject nvarchar(MAX)
	set @subject = 'Balance change for account: ' + CONVERT(varchar(10), @accountId)
	set @body = 'On ' + convert(varchar, getdate(), 100) + ' your balance was changed from ' + 
		CONVERT(varchar(10), @oldSum) + ' to ' + 
		CONVERT(varchar(10), @newSum) + '.'

	insert into NotificationEmails 
	values(@accountId, @subject, @body)
go

update Accounts
set Balance = Balance + 1
where Id = 1

select * from Logs
select * from NotificationEmails

drop trigger dbo.notificationTrigger