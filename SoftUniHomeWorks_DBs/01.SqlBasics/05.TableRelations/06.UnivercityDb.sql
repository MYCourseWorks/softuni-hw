create table Majors 
(
	MajorID int primary key,
	Name nvarchar(255)
);

create table Students 
(
	StudentID int primary key,
	StudentNumber nvarchar(255),
	StudentName nvarchar(255),
	MajorID int foreign key references Majors(MajorID)
);

create table Payments 
(
	PaymentID int primary key,
	PaymentDate date,
	PaymentAmount money,
	StudentID int foreign key references Students(StudentID)
);

create table Subjects
(
	SubjectID int primary key,
	SubjectName nvarchar(255)
);

create table Agenda
(
	StudentID int foreign key references Students(StudentID),
	SubjectID int foreign key references Subjects(SubjectID),
	constraint PK_StudentSubject primary key (StudentID, SubjectID)
);

drop table Agenda
drop table Subjects
drop table Payments
drop table Students
drop table Majors