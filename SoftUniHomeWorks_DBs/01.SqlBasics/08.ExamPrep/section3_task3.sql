select
	FlightID, DepartureTime, ArrivalTime
from
	Flights
where
	[Status] = 'Delayed'
order by
	FlightID asc