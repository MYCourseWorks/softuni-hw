create table Products(
	Id int identity(0, 1) primary key,
	Name nvarchar(25) unique,
	[Description] nvarchar(250),
	Recipe nvarchar(MAX),
	Price money,
	constraint ck_price check (Price > 0)
)

create table Countries (		
	Id int identity(0, 1) primary key,
	Name nvarchar(50) unique
)

create table Distributors (
	Id int identity(0, 1) primary key,
	Name nvarchar(25) unique,
	AddressText nvarchar(30),
	Summary nvarchar(200),
	CountryId int foreign key references Countries(Id)
)

create table Ingredients (
	Id int identity(0, 1) primary key,
	Name nvarchar(30),
	[Description] nvarchar(200),
	OriginCountryId int foreign key references Countries(Id),
	DistributorId int foreign key references Distributors(Id)
)

create table ProductsIngredients (
	ProductId int foreign key references Products(Id),
	IngredientId int foreign key references Ingredients(Id),
	constraint pk_PersonID primary key (ProductId, IngredientId)
)

create table Customers (
	Id int identity(0, 1) primary key,
	FirstName nvarchar(25),
	LastName nvarchar(25),
	Gender char(1),
	Age int,
	PhoneNumber char(10),
	CountryId int foreign key references Countries(Id),
	constraint ck_gender check (Gender in ('M', 'F'))
)

create table Feedbacks (
	Id int identity(0, 1) primary key,
	[Description] nvarchar(255),
	Rate decimal(10, 2),
	ProductId int foreign key references Products(Id),
	CustomerId int foreign key references Customers(Id),
	constraint ck_rate check (Rate between 0 and 10)
)

drop table Feedbacks
drop table Customers
drop table ProductsIngredients
drop table Ingredients
drop table Distributors
drop table Products
drop table Countries
