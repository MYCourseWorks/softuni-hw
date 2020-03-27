CREATE TABLE People (
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(200) NOT NULL,
	Picture image,
	Height float,
	Weight float,
	Gender char,
	Birthdate date,
	Biography nvarchar(MAX)
)

INSERT INTO dbo.People 
		   (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
	VALUES ('Pesho', NULL, 170, 100, 'm', GETDATE(), 'test')

INSERT INTO dbo.People 
		   (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
	VALUES ('Gosho', NULL, 172, 600, 'f', GETDATE(), NULL)

INSERT INTO dbo.People 
		   (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
	VALUES ('Cako', NULL, 1123, 100, 'm', GETDATE(), 'test 2')

INSERT INTO dbo.People 
		   (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
	VALUES ('Mako', NULL, 175, 50, 'f', GETDATE(), NULL)

INSERT INTO dbo.People 
		   (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
	VALUES ('Tako', NULL, 170, 120, 'm', GETDATE(), NULL)