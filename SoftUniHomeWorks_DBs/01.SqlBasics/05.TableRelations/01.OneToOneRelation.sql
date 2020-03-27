create table Passports
(
	PassportID int not null,
	PassportNumber nvarchar(255)
);

create table Persons
(
	PersonID int not null,
	FirstName nvarchar(255),
	Salary money,
	PassportID int not null
);

alter table Passports
add constraint PK_PassportID
primary key (PassportID)

alter table Persons 
add constraint PK_PersonID 
primary key (PersonID)

alter table Persons
add constraint FK_Persons_Passports 
foreign key (PassportID)
references Passports(PassportID)

insert into Passports
values (101, 'N34FG21B')
insert into Passports
values (102, 'K65LO4R7')
insert into Passports
values (103, 'ZE657QP2')

insert into Persons 
values (1, 'Roberto', 43300.00, 102)
insert into Persons 
values (2, 'Tom', 56100.00, 103)
insert into Persons 
values (3, 'Yana', 60200.00, 101)

select * from Persons
select * from Passports

drop table Persons
drop table Passports