create table Manufacturers
(
	ManufacturerID int primary key,
	Name nvarchar(255),
	EstablishedOn date,
);

create table Models 
(
	ModelID int primary key,
	Name nvarchar(255),
	ManufacturerID int foreign key references Manufacturers(ManufacturerID)
);

insert into Manufacturers
values (1, 'BMW', '07/03/1916')
insert into Manufacturers
values (2, 'Tesla', '01/01/2003')
insert into Manufacturers
values (3, 'Lada', '01/05/1966')

insert into Models
values (101, 'X1', 1)
insert into Models
values (102, 'i6', 1)
insert into Models
values (103, 'Model S', 2)
insert into Models
values (104, 'Model X', 2)
insert into Models
values (105, 'Model 3', 2)
insert into Models
values (106, 'Nova', 3)

select * from Models
select * from Manufacturers

drop table Models
drop table Manufacturers