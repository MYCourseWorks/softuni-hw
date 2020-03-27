create table Flights(
	FlightID int primary key,
	DepartureTime datetime not null,
	ArrivalTime datetime not null,
	[Status] varchar(9),
	OriginAirportID int foreign key references Airports(AirportID),
	DestinationAirportID int foreign key references Airports(AirportID),
	AirlineID int foreign key references Airlines(AirlineID),
	constraint chk_Status check ([Status] in ('Departing', 'Delayed', 'Arrived', 'Cancelled'))
)

create table Tickets (
	TicketID int primary key,
	Price decimal(8, 2) not null,
	Class varchar(6),
	Seat varchar(5) not null,
	CustomerID int foreign key references Customers(CustomerID),
	FlightID int foreign key references Flights(FlightID),
	constraint chk_Class check (Class in ('First', 'Second', 'Third'))
)