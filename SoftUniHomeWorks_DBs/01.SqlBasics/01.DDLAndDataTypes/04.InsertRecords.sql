INSERT INTO dbo.towns 
            (Id, Name) 
     VALUES (1, 'Sofia') 

INSERT INTO dbo.towns 
            (Id, Name) 
     VALUES (2, 'Plovdiv') 

INSERT INTO dbo.towns 
            (Id, Name) 
     VALUES (3, 'Varna')

INSERT INTO dbo.minions 
            (Id, Name, Age, Townid) 
     VALUES(1, 'Kevin', 22, 1) 

INSERT INTO dbo.minions 
            (Id, Name, Age, TownId) 
     VALUES(2, 'Bob', 15, 3) 

INSERT INTO dbo.minions 
            (Id, Name, Age, TownId) 
     VALUES(3, 'Steward', NULL, 2)


select * from dbo.Minions
select * from dbo.Towns