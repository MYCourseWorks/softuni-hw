create table Students
(
	StudentID int primary key,
	Name nvarchar(255)
);

create table Exams
(
	ExamID int primary key,
	Name nvarchar(255)
);

create table StudentsExams
(
	StudentID int foreign key references Students(StudentID),
	ExamID int foreign key references Exams(ExamID),
	constraint pk_StudentsExams primary key (StudentID, ExamID)
);

insert into Students
values (1, 'Mila'), (2, 'Toni'), (3, 'Ron')
insert into Exams 
values (101, 'SpringMVC'), (102, 'Neo4j'), (103, 'Oracle 11g')
insert into StudentsExams
values (1, 101), (1, 102), (2, 101), (3, 103), (2, 102), (2, 103)

drop table StudentsExams
drop table Students
drop table Exams