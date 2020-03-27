select
	F.FlightID,
	F.DepartureTime,
	F.ArrivalTime,
	OA.AirportName as Origin,
	DA.AirportName as Destination
from 
	(
		select top 5 * 
		from Flights 
		where Status = 'Departing'
		order by DepartureTime desc
	) as F
	join Airports as DA on DA.AirportID = F.DestinationAirportID
	join Airports as OA on OA.AirportID = F.OriginAirportID
order by
	F.DepartureTime asc, F.FlightID asc