create table Teachers
(
	TeacherID int primary key,
	Name nvarchar(255),
	ManagerID int foreign key references Teachers(TeacherID)
);

insert into Teachers
values (101, 'John', NULL), 
	(102, 'Maya', 106), 
	(103, 'Silvia', 106), 
	(104, 'Ted', 105), 
	(105, 'Mark', 101), 
	(106, 'Greta', 101)

select * from Teachers

drop table Teachers