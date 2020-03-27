create proc usp_GetEmployeesFromTown 
	(@name nvarchar(255))
as
	select E.FirstName, E.LastName 
	from Employees as E
	join Addresses as A
	on A.AddressID = E.AddressID
	join Towns as T
	on T.TownID = A.TownID
	where LOWER(T.Name) = LOWER(@name)