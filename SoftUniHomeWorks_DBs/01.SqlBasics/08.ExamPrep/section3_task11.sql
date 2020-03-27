select
	A.AirportID,
	A.AirportName,
	count(T.TicketID) as Passengers
from 
	Flights as F
	join Airports as A on A.AirportID = F.OriginAirportID
	join Tickets as T on T.FlightID = F.FlightID
where
	F.Status = 'Departing'
group by
	A.AirportID, A.AirportName
order by
	A.AirportID