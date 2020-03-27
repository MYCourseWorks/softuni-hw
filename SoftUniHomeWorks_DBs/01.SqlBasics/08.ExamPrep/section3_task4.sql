select top 5
	A.AirlineID, A.AirlineName, A.Nationality, A.Rating
from
	Airlines as A
where
	A.AirlineID in (select AirlineID from Flights)
order by
	A.Rating desc, A.AirlineID asc