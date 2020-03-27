update Countries
set CountryName = 'Burma'
where CountryCode = 'MM'

insert into Monasteries(CountryCode, Name) 
values ('TZ', 'Hanga Abbey')

select 
	CON.ContinentName as ContinentName,
	COU.CountryName as CountryName,
	count(M.Id) as MonasteriesCount
from 
	Countries as COU
	join Continents as CON on CON.ContinentCode = COU.ContinentCode
	left join Monasteries as M on M.CountryCode = COU.CountryCode
where
	COU.IsDeleted = 0
group by
	CON.ContinentName, COU.CountryName
order by 
	MonasteriesCount desc, COU.CountryName