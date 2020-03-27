declare @highest_rated_airline_id int

select top 1 @highest_rated_airline_id = AirlineID
from Airlines
order by Rating desc

update Tickets
set Price = Price + Price * 0.5
where TicketID in 
(
	select T.TicketID
	from Airlines as A
	join Flights as F on F.AirlineID = A.AirlineID
	join Tickets as T on T.FlightID = F.FlightID
	where A.AirlineID = @highest_rated_airline_id
)