create proc usp_GetTownsStartingWith 
	(@str nvarchar(255))
as
	select Name as Town
	from Towns
	where LOWER(Name) like LOWER(@str + '%')
go

exec usp_GetTownsStartingWith 'b'

drop proc usp_GetTownsStartingWith