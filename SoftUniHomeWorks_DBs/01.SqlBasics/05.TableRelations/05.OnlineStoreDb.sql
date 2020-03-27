create table Cities 
(
	CityID int primary key,
	Name nvarchar(50)
);

create table Customers 
(
	CustomerID int primary key,
	Name nvarchar(50),
	Birthday date,
	CityID int foreign key references Cities(CityID)
);

create table Orders 
(
	OrderID int primary key,
	CustomerID int foreign key references Customers(CustomerID)
);

create table ItemTypes 
(
	ItemTypeID int primary key,
	Name nvarchar(50)
);

create table Items 
(
	ItemID int primary key,
	Name nvarchar(50),
	ItemTypeID int foreign key references ItemTypes(ItemTypeID)
);

create table OrderItems
(
	OrderID int foreign key references Orders(OrderID),
	ItemID int foreign key references Items(ItemID),
	constraint PK_OrderItems primary key (OrderID, ItemID)
);

drop table OrderItems
drop table Items
drop table ItemTypes
drop table Orders
drop table Customers
drop table Cities