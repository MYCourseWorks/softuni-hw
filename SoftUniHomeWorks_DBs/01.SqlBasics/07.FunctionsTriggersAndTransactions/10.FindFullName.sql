create proc usp_GetHoldersFullName 
as 
	select FirstName + ' ' + LastName as [Full Name] 
	from AccountHolders
go
exec usp_GetHoldersFullName
drop proc usp_GetHoldersFullName