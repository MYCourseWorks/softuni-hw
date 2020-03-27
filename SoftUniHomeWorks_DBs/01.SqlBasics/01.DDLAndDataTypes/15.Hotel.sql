CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	Title VARCHAR(255) NOT NULL,
	Notes TEXT
)

CREATE TABLE Customers (
	AccountNumber VARCHAR(255) PRIMARY KEY,
	FirstName VARCHAR(255) NOT NULL,
	LastName VARCHAR(255) NOT NULL,
	PhoneNumber VARCHAR(255) NOT NULL,
	EmergencyName VARCHAR(255),
	EmergencyNumber VARCHAR(255),
	Notes TEXT
)

CREATE TABLE RoomStatus (
	RoomStatus VARCHAR(255) PRIMARY KEY,
	Notes TEXT
)

CREATE TABLE RoomTypes (
	RoomType VARCHAR(255) PRIMARY KEY,
	Notes TEXT
)

CREATE TABLE BedTypes (
	BedTypes VARCHAR(255) PRIMARY KEY,
	Notes TEXT
)

CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(255) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedTypes VARCHAR(255) FOREIGN KEY REFERENCES BedTypes(BedTypes),
	Rate DECIMAL,
	RoomStatus VARCHAR(255) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes TEXT
)

CREATE TABLE Payments (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE,
	AccountNumber VARCHAR(255) FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT,
	AmountCharged DECIMAL,
	TaxRate DECIMAL,
	TaxAmount DECIMAL, 
	PaymentTotal DECIMAL, 
	Notes TEXT
)

CREATE TABLE Occupancies (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE,
	AccountNumber VARCHAR(255) FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL,
	PhoneCharge DECIMAL,
	Notes TEXT
)

INSERT INTO Employees VALUES('Pesho', 'Peshev', 'Cleaner', NULL)
INSERT INTO Employees VALUES('Gaco', 'Gacov', 'Desk manager', NULL)
INSERT INTO Employees VALUES('Penka', 'Penata', 'Masseuse', NULL)

INSERT INTO Customers 
VALUES('account number', 'Test', 'Test 2', '0881234', NULL, NUll, NUll)
INSERT INTO Customers 
VALUES('account number 2', 'Test 1', 'Test 3', '0881235', NULL, NUll, NUll)
INSERT INTO Customers 
VALUES('account number 3', 'Test 2', 'Test 4', '0881236', NULL, NUll, NUll)

INSERT INTO RoomStatus VALUES('Good', NUll)
INSERT INTO RoomStatus VALUES('Bad', NUll)
INSERT INTO RoomStatus VALUES('Sad', NUll)

INSERT INTO RoomTypes VALUES('One bedroom', NUll)
INSERT INTO RoomTypes VALUES('Two bedroom', NUll)
INSERT INTO RoomTypes VALUES('Apartment', NUll)

INSERT INTO BedTypes VALUES('single', NUll)
INSERT INTO BedTypes VALUES('double', NUll)
INSERT INTO BedTypes VALUES('bunk', NUll)

INSERT INTO Rooms 
VALUES(111, 'One bedroom', 'single', 150.50, 'Bad', 'Mnoo zle we')
INSERT INTO Rooms 
VALUES(112, 'Two bedroom', 'bunk', 250.50, 'Bad', NUll)
INSERT INTO Rooms 
VALUES(113, 'Apartment', 'double', 350.50, 'Good', NUll)

INSERT INTO Payments 
VALUES(1, GETDATE(), 'account number', GETDATE(), GETDATE(), 10, 250.5, 2, 2, 25.23, NUll)
INSERT INTO Payments 
VALUES(2, GETDATE(), 'account number', GETDATE(), GETDATE(), 10, 250.5, 2, 2, 25.23, NUll)
INSERT INTO Payments 
VALUES(3, GETDATE(), 'account number', GETDATE(), GETDATE(), 10, 250.5, 2, 2, 25.23, NUll)

INSERT INTO Occupancies 
VALUES (1, GETDATE(), 'account number 2', 111, 0, 0, NULL)
INSERT INTO Occupancies 
VALUES (1, GETDATE(), 'account number 2', 111, 0, 0, NULL)
INSERT INTO Occupancies 
VALUES (1, GETDATE(), 'account number 2', 111, 0, 0, NULL)