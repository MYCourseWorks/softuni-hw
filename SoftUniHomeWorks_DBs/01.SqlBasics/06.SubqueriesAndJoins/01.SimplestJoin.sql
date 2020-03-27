select top 5 E.EmployeeID, E.JobTitle, E.AddressID, A.AddressText
from Employees as E
join Addresses as A
on A.AddressID = E.AddressID
order by E.AddressID