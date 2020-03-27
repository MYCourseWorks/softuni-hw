-- task 1 :
create table Monasteries (
	Id int identity(1, 1) primary key, 
	Name varchar(255), 
	CountryCode char(2) foreign key references Countries(CountryCode)
)

-- task 2 :
insert into Monasteries(Name, CountryCode) values
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

-- task 3 :
alter table Countries
add IsDeleted bit
go

alter table Countries
add constraint DF default 0 for IsDeleted
go

update Countries
set IsDeleted = 0

-- task 4 :
update Countries
set IsDeleted = 1
where CountryCode in 
(
	select 
		C.CountryCode
	from 
		Countries as C
		join CountriesRivers as CR on CR.CountryCode = C.CountryCode
		join Rivers as R on R.Id = CR.RiverId
	group by
		C.CountryCode
	having 
		count(R.Id) > 3
)

-- task 5 :
select 
	M.Name as Monastery,
	C.CountryName as Country 
from 
	Countries as C
	join Monasteries as M on M.CountryCode = C.CountryCode
where
	C.IsDeleted = 0
order by
	M.Name
