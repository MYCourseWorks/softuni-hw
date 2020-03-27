create table CustomerReviews (
	ReviewID int primary key,
	ReviewContent varchar(255) not null,
	ReviewGrade int,
	AirlineID int foreign key references Airlines(AirlineID),
	CustomerID int foreign key references Customers(CustomerID),
	constraint chk_Review check (ReviewGrade between 0 and 10)
)

create table CustomerBankAccounts (
	AccountID int primary key,
	AccountNumber varchar(10) not null unique,
	Balance decimal(10, 2) not null,
	CustomerID int foreign key references Customers(CustomerID)
)