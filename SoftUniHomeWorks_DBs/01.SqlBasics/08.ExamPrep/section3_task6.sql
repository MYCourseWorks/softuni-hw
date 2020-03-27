select distinct
	C.CustomerID, C.FirstName + ' ' + C.LastName as FullName, HT.TownName as HomeTown
from
	Tickets as T
	join Customers as C on C.CustomerID = T.CustomerID
	join Towns as HT on HT.TownID = C.HomeTownID
	join Flights as F on F.FlightID = T.FlightID
	join Airports as A on A.AirportID = F.OriginAirportID
	join Towns DT on DT.TownID = A.TownID
where
	DT.TownID = HT.TownID
order by
	CustomerID asc