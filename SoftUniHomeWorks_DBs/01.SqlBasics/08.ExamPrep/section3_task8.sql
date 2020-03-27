select top 3
	C.CustomerID,
	C.FirstName + ' ' + C.LastName as FullName,
	T.Price as TicketPrice,
	DA.AirportName as Destination
from 
	Customers as C
	join Tickets as T on T.CustomerID = C.CustomerID
	join Flights as F on F.FlightID = T.FlightID
	join Airports as DA on DA.AirportID = F.DestinationAirportID
where
	F.Status = 'Delayed'
order by
	T.Price desc
