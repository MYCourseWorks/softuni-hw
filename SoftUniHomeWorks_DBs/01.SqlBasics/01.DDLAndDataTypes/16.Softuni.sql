CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY(1,
		-1), 
	Name VARCHAR(255) NOT NULL
)

CREATE TABLE Address (
	Id INT PRIMARY KEY IDENTITY(1, 1), 
	AddressText VARCHAR(255) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Name VARCHAR(255) NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	FirstName VARCHAR(255) NOT NULL,
	MiddleName VARCHAR(255),
	LastName VARCHAR(255) NOT NULL,
	JobTitle VARCHAR(255) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary MONEY NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Address(Id)
)

INSERT INTO Towns VALUES('Sofia')
INSERT INTO Towns VALUES('Plovdiv')
INSERT INTO Towns VALUES('Varna')
INSERT INTO Towns VALUES('Burgas')

INSERT INTO Departments VALUES('Engineering')
INSERT INTO Departments VALUES('Sales')
INSERT INTO Departments VALUES('Marketing')
INSERT INTO Departments VALUES('Software Development')
INSERT INTO Departments VALUES('Quality Assurance')

INSERT INTO Employees 
VALUES('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00, NULL)
INSERT INTO Employees 
VALUES('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, NULL)
INSERT INTO Employees 
VALUES('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, NULL)
INSERT INTO Employees 
VALUES('Georgi', 'Terziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, NULL)
INSERT INTO Employees 
VALUES('Peter', 'Pan', 'Pan', 'Invern', 3, '2016-08-28', 59.88, NULL)