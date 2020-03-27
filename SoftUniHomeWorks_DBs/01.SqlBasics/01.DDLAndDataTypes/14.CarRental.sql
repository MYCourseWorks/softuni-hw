CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Category VARCHAR(255) NOT NULL, 
	DailyRate INT, 
	WeeklyRate INT, 
	MonthlyRate INT, 
	WeekendRate INT
)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	PlateNumber INT NOT NULL,
	Make VARCHAR(255) NOT NULL,
	Model VARCHAR(255) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT NOT NULL,
	Picture IMAGE,
	Condition VARCHAR(255),
	Available BIT NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	Title VARCHAR(255) NOT NULL,
	Notes VARCHAR(255)
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DriverLicenceNumber VARCHAR(255) NOT NULL,
	FullName VARCHAR(255) NOT NULL,
	Address VARCHAR(255) NOT NULL,
	City VARCHAR(255) NOT NULL,
	ZIPCode VARCHAR(255),
	Notes VARCHAR(255)
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	CarCondition VARCHAR(255) NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE,
	EndDate DATE,
	TotalDays INT,
	RateApplied INT,
	TaxRate DECIMAL,
	OrderStatus INT,
	Notes TEXT
)

INSERT INTO Categories VALUES('Test Category', 1, 2, 3, NULL)
INSERT INTO Categories VALUES('Test Category 2', 1, NULL, 3, 2)
INSERT INTO Categories VALUES('Test Category 3', NULL, 2, 3, 1)

INSERT INTO Cars VALUES ('12345656', 'test', 'test model', GETDATE(), 1, 3, NULL, 'Bad sad bad', 1)
INSERT INTO Cars VALUES ('54321', 'test 2', 'test model 2', GETDATE(), 2, 1, NULL, 'Good', 0)
INSERT INTO Cars VALUES ('12345', 'test 3', 'test model 3', GETDATE(), 3, 5, NULL, 'Bad sad bad', 1)

INSERT INTO Employees VALUES ('Gaco', 'Bacov', 'No title', NULL)
INSERT INTO Employees VALUES ('Baco', 'Gacov', 'Bezraboten', NULL)
INSERT INTO Employees VALUES ('Paco', 'Pacov', 'Engineer', NULL)

INSERT INTO Customers VALUES ('12345', 'Pesho', 'Peshev', 'Sofia', NULL, NULL)
INSERT INTO Customers VALUES ('12346', 'Pesho 2', 'Peshev 2', 'Sofia', NULL, NULL)
INSERT INTO Customers VALUES ('12347', 'Pesho 3', 'Peshev 3', 'Sofia', NULL, NULL)

INSERT INTO RentalOrders 
VALUES (1, 2, 1, 'Great', 2, 0, 120, 4, GETDATE(), GETDATE(), 2, 1, 2, NULL, NULL)
INSERT INTO RentalOrders 
VALUES (1, 2, 1, 'Great', 2, 0, 120, 4, GETDATE(), GETDATE(), 2, 1, 2, NULL, NULL)
INSERT INTO RentalOrders 
VALUES (1, 2, 1, 'Great', 2, 0, 120, 4, GETDATE(), GETDATE(), 2, 1, 2, NULL, NULL)
