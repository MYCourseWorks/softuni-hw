create table Users (
	[Id] bigint primary key identity(1, 1),
	[Username] varchar(30) NOT NULL,
	[Password] varchar(26) NOT NULL,
	[ProfilePicture] image,
	[LastLoginTime] date,
	[IsDeleted] bit
)

insert into Users 
		(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
	values ('Pesho', '1234', NULL, GETDATE(), 0)

insert into Users 
		(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
	values ('Gosho', '1234', NULL, GETDATE(), 0)

insert into Users 
		(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
	values ('Paco', '1234', NULL, GETDATE(), 0)

insert into Users 
		(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
	values ('Gaco', '1234', NULL, GETDATE(), 0)

insert into Users 
		(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
	values ('Vayo', '1234', NULL, GETDATE(), 0)

select * from dbo.Users