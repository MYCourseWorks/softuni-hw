select 
	T.TicketID, A.AirportName as Destination, C.FirstName + ' ' + C.LastName as CustomerName
from 
	Tickets as T
	join Flights as F on F.FlightID = T.FlightID
	join Airports as A on A.AirportID = F.DestinationAirportID
	join Customers as C on C.CustomerID = T.CustomerID
where
	T.Price < 5000 and T.Class = 'First'