create trigger tr_flight on Flights
for update
as
	declare cr_inserted cursor for (
		select 
			FlightID, 
			DepartureTime, 
			ArrivalTime, 
			Status, 
			OriginAirportID, 
			DestinationAirportID, 
			AirlineID 
		from 
			inserted
	)

	open cr_inserted 
		declare @flightId int,
				@departureTime datetime,
				@arrivalTime datetime,
				@status varchar(9),
				@originAirportId int,
				@destAirportId int,
				@airlineId int

		fetch next from cr_inserted into @flightId, @departureTime, @arrivalTime, 
				@status, @originAirportId, @destAirportId, @airlineId

		while (@@FETCH_STATUS = 0)
		begin
			if (@status = 'Arrived')
			begin
				declare @passangers int = (
					select 
						count(*) 
					from 
						Tickets as T 
						join Flights as F on F.FlightID = T.FlightID
					where 
						T.FlightID = @flightId
				)

				declare @destAirportName varchar(50)
				select @destAirportName = AirportName from Airports where AirportID = @destAirportId

				declare @originAirportName varchar(50)
				select @originAirportName = AirportName from Airports where AirportID = @originAirportId

				insert into ArrivedFlights(FlightID, ArrivalTime, Origin, Destination, Passengers)
				values (@flightId, @arrivalTime, @originAirportName, @destAirportName, @passangers)
			end

			fetch next from cr_inserted into @flightId, @departureTime, @arrivalTime, 
				@status, @originAirportId, @destAirportId, @airlineId
		end
	close cr_inserted 
	deallocate cr_inserted