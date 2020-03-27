select top 50 E.FirstName, E.LastName, T.Name as Town, A.AddressText
from Employees as E
join Addresses as A
on E.AddressID = A.AddressID
join Towns as T
on A.TownID = T.TownID
order by FirstName, LastName