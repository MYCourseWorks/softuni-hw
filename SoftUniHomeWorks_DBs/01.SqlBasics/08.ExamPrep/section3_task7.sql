select distinct
	C.CustomerID, 
	C.FirstName + ' ' + C.LastName as FullName,
	DATEDIFF(YEAR, C.DateOfBirth, '2016') as Age
from 
	Customers as C
	join Tickets as T on T.CustomerID = C.CustomerID
	join Flights as F on F.FlightID = T.FlightID
where
	F.Status = 'Departing'
order by
	Age asc